namespace ToDoList.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using ToDoList.Models;
    using ToDoList.Models.Business.Entites;
    using ToDoList.Models.Business.Service.Interface;
    using ToDoList.Models.DataAccess.Data;

    public class HomeController : Controller
    {
        private readonly IRegistrationUserService userService;
        private readonly DataToDoListContext context;

        public HomeController(IRegistrationUserService service, DataToDoListContext context)
        {
            this.userService = service;
            this.context = context;
        }

        public IActionResult Index() =>
              this.View(this.userService.GetRegistrationUsers());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,Birthday,Email,Password,ConfirmPassword,Id")]RegistrationUser authUser)
        {
            if (this.ModelState.IsValid)
            {
                this.userService.Create(authUser);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult Privacy() =>
               this.View();

        public IActionResult Registration() =>
               this.View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
