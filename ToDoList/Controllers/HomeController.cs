using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using ToDoList.Models.Business.Entites;
using ToDoList.Models.Business.Service.Implementation.Converters;
using ToDoList.Models.Business.Service.Interface;
using ToDoList.Models.DataAccess.Dal.Service.Interface;
using ToDoList.Models.DataAccess.Data;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataToDoListContext _context;
        private readonly ICategoryService _dataCategoryService;
        private readonly IDataCategoryService _dataCategoryDataService;

        public HomeController(DataToDoListContext context, ICategoryService categoryService, IDataCategoryService data)
        {
            _context = context;
            _dataCategoryService = categoryService;
            _dataCategoryDataService = data;
        }

        [Authorize(Roles = "Admin,User")]

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CategoryList()
        {
            return Json(_context.Categories.ToList());

        }
        [HttpGet]
        public JsonResult EditCategory(string name, int? id)
        {
            if (name == null)
            {
                return Json("Not Found");
            }

            var category = _context.Categories.Find(name);
            if (category == null)
            {
                return Json("Not Found");
            }
            return Json(category);
        }


        [HttpPut]
        public async Task<JsonResult> EditCategory(string name, int id, [Bind("Name")]Category category)
        {
            if (name != category.Name)
            {
                return Json($"Name {category.Name} is already in use.");
            }

            if (ModelState.IsValid)
            {
                try
                {

                    category.Id = id;
                    await _dataCategoryService.UpdateCategory(category);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExist(category.Name))
                    {
                        return Json($"Name {category.Name} is already in use.");
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return Json(category);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            Regex reg = new Regex(@"^([\d.,-]+)$");
            var isCheck = false;
            if (!reg.IsMatch(category.Name))
            {
                isCheck = _dataCategoryService.CreateCategory(category);
            }
            else
            {
                return BadRequest($"Name { category.Name} Please enter a valid name.");
            }
            if (!isCheck)
            {
                return BadRequest($"Name { category.Name} is already in use.");
            }
            return RedirectToAction("Index");
        }


        [HttpDelete]
        public async Task<JsonResult> DeleteCategory(int? id)
        {
            if (id == null)
            {
                return Json("Not found");
            }

            await Task.Run(() => _dataCategoryService.DeleteCategory(id));

            return Json($"Category was deleted !");
        }


        private bool CategoryExist(string name)
        {
            return _context.Categories.Any(e => e.Name == name);
        }
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}