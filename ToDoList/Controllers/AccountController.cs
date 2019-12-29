namespace ToDoList.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using ToDoList.Models.Business.Entites;
    using ToDoList.Models.Business.Service.Interface;
    using ToDoList.Models.Helpers;

    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAppRole _appRole;
        private readonly IAccountService _accountService;

        public AccountController(IUserService userService,
                                 IAppRole appRole,
                                 IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
            _appRole = appRole;
        }

        public IActionResult Registration() =>
               View();

        [HttpPost]
        public IActionResult CreateUser([Bind("FirstName,LastName,Birthday,Email,Password,ConfirmPassword,Id")]User authUser)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _userService.Create(authUser);
                }
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return RedirectToAction(nameof(this.Login));
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (!ModelState.IsValid) return View();
            var user = _accountService.InsertToAccount(email, password);
            if (user == null) return View();
            var role = _appRole.SetRole(email, password).ToString();

            ClaimsIdentity identity = null;

            var isAuthenticated = false;

            if (role.Equals("Admin"))
            {
                identity = new ClaimsIdentity(new[] {
                  new Claim(ClaimTypes.Email, email),
                  new Claim(ClaimTypes.Role, "Admin")
              }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticated = true;

            }

            if (!role.Equals("Admin"))
            {
                identity = new ClaimsIdentity(new[] {
                  new Claim(ClaimTypes.Email, email),
                  new Claim(ClaimTypes.Role, "User")
              }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticated = true;
            }

            if (!isAuthenticated) return View();
            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");


        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

    }
}