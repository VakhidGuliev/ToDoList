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
        private readonly IRegistrationUserService _registrationUserService;
        private readonly IAuthenticationService _authenticationsService;
        private readonly DataToDoListContext context;

        public HomeController(IRegistrationUserService registrationUserService,
                              IAuthenticationService authenticationsService,
                              DataToDoListContext context)
        {
            this._registrationUserService = registrationUserService;
            this._authenticationsService = authenticationsService;
            this.context = context;
        }

        public IActionResult Index() =>
              this.View(this._registrationUserService.GetRegistrationUsers());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,Birthday,Email,Password,ConfirmPassword,Id")]RegistrationUser authUser)
        {


            if (string.IsNullOrEmpty(authUser.Email))
            {
                ModelState.AddModelError(authUser.Email, "Not correct  email");
            }
            else if (string.IsNullOrEmpty(authUser.Password))
            {
                ModelState.AddModelError(authUser.Password, "Not correct password");
            }

            if (this.ModelState.IsValid)
            {
                ViewBag.Message = "Validation Passed";
                this._registrationUserService.Create(authUser);

            }
            ViewBag.Message = "Request failed validation";

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn([Bind("Email", "Password")]string email, string password)
        {

            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError(email, "Not correct  email");
            }
            else if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError(password, "Not correct password");
            }


            ViewBag.Message = "Request failed validation";
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
