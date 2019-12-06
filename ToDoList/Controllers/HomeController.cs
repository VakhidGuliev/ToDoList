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
        private readonly IRegistrationUserService _userService;
        private readonly IAuthenticationService _authenticationsService;
        private readonly DataToDoListContext context;

        public HomeController(IRegistrationUserService service,
                              IAuthenticationService authenticationsService,
                              DataToDoListContext context)
        {
            this._userService = service;
            this._authenticationsService = authenticationsService;
            this.context = context;
        }

        public IActionResult Index() =>
              this.View(this._userService.GetRegistrationUsers());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,Birthday,Email,Password,ConfirmPassword,Id")]RegistrationUser authUser)
        {
            if (this.ModelState.IsValid)
            {
                this._userService.Create(authUser);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]

        public IActionResult SignIn([Bind("Email", "Password")]string email, string password)
        {
            this._authenticationsService.SignIn(email, password);
            return this.View();
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
