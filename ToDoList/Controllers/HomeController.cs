using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using ToDoList.Models.Business.Entites;
using ToDoList.Models.Business.Service.Interface;
using ToDoList.Models.DataAccess.Dal.Service.Interface;
using ToDoList.Models.DataAccess.Data;
using Task = ToDoList.Models.Business.Entites.Task;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly ITaskService _taskService;
        private readonly IEmailService _emailService;
        private readonly IDataAccountService _dataAccountService;
        private DataToDoListContext _doListContext;
        private int CategoryId { get; set; }
        public string UserEmail { get; private set; }
        public int UserAccountId { get; private set; }

        public HomeController
            (

            ICategoryService categoryService,
            ITaskService taskService,
            IEmailService emailService,
            IDataAccountService dataAccountService,
            DataToDoListContext dataToDoListContext
           )
        {

            _categoryService = categoryService;
            _taskService = taskService;
            _emailService = emailService;
            _dataAccountService = dataAccountService;
            _doListContext = dataToDoListContext;


        }

        [Authorize(Roles = "Admin,User")]

        public IActionResult Index()
        {
            return View();
        }



        //[HttpGet]

        //public JsonResult EditCategory(string name, int? id)
        //{
        //    if (name == null)
        //    {
        //        return Json( ResponseResult.Json.NotFound.ToStr());
        //    }

        //    var category = _context.Categories.Find(name);

        //    if (category == null)
        //    {
        //        return Json(Response().NotFound);
        //    }

        //    return Json(category);
        //}

        [HttpPost]

        public IActionResult CreateCategory(Category category)
        {
            Regex reg = new Regex(@"^([\d.,-]+)$");
            bool isCheck;

            CategoryId = category.Id;
            if (!reg.IsMatch(category.Name))
            {
                isCheck = _categoryService.CreateCategory(category);
            }
            else
            {
                return BadRequest($"Name { category.Name}");
            }

            if (!isCheck)
            {
                return BadRequest($"Name { category.Name} ");
            }

            return RedirectToAction("Index");
        }

        [HttpPut]

        public JsonResult EditCategory(string name, int id, [Bind("Name")]Category category, int userAccoundId)
        {

            if (name != category.Name)
            {
                return Json($"Name {category.Name}");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    category.Id = id;
                    _categoryService.UpdateCategory(category, userAccoundId);

                }
                catch (DbUpdateConcurrencyException)
                {

                    return Json($"Name {category.Name} Alread exist");


                    throw;
                }
            }

            return Json(category);
        }
        [HttpGet]
      //  [Route("{/CategoryList/{id}}")]
        public JsonResult CategoryList()
        {
            var userAccountId = GetUserAccountId();
            return Json(_categoryService.Categories(userAccountId).ToList());
        }
        string GetUserAccountEmail()
        {

            var email = HttpContext.User.Claims.FirstOrDefault().Value;

            UserEmail = email;

            return email;
        }

        int GetUserAccountId()
        {

            var getId = _doListContext.Users.FirstOrDefault(x => x.Email == GetUserAccountEmail()).UserAccountId;

            UserAccountId = getId;

            return getId;
        }
        //[HttpDelete]

        //public async Task<JsonResult> DeleteCategory(int? id)
        //{
        //    if (id == null)
        //    {
        //        return Json(Response().NotFound);
        //    }

        //    await System.Threading.Tasks.Task.Run(() => _dataCategoryService.DeleteCategory(id));

        //    return Json(Response().WasDeleted);
        //}

        //private bool CategoryExist(string name)
        //{
        //    return _context.Categories.Any(e => e.Name == name);
        //}

        [HttpGet]

        public int CategoryCount(int userAccountId)
        {
           return _categoryService.Count(userAccountId);
        }

        [HttpPost]

        public IActionResult CreateTask(Task task)
        {
            Regex reg = new Regex(@"^([\d.,-]+)$");
            task.UserAccountId = GetUserAccountId();
          if (!reg.IsMatch(task.Name))
            {
                _taskService.CreateTask(task);
            }
     
            return RedirectToAction("Index");
        }

        [HttpDelete]

        public async Task<JsonResult> DeleteTask(int id)
        {
            await System.Threading.Tasks.Task.Run(() => _categoryService.DeleteCategory(id));

            return Json("Was Deleted");
        }

        [HttpGet]

        public JsonResult GetTask(int id)
        {
            return Json(_taskService.GetTask(id));
        }

        [HttpGet]
       
        public JsonResult TaskList()
        {
            return Json(_taskService.GetTaskList(GetUserAccountId()).Result.ToList());
        }

      
        //[Required]
        //[BindProperty]
        //public string Email { get; set; }

        //public async Task<IActionResult> SendMessage()
        //{
        //   // var setting = _emailSender.GetEmailSettings();

        //  //  var status = await _emailSender.SendEmailAsync(setting.To, setting.Subject, setting.Message);

        //    var Ok = Response().Ok;

        //    if (!status.Equals(Ok))
        //    {
        //        return Json(Response().NotSendMessage);
        //    }

        //    this.EmailStatusMessage = this.Response().SuccesReport;

        //    return RedirectToAction("Index");
        //}

        [Authorize(Roles = "Admin")]

        public IActionResult Setting()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    }
}