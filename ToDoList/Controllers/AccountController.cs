namespace CookieDemo.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using ToDoList.Models.Business.Entites;
    using ToDoList.Models.Business.Service.Interface;
    using ToDoList.Models.DataAccess.Data;
    using ToDoList.Models.Helpers;

    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IAppRole appRole;
        private readonly DataToDoListContext context;

        public AccountController(IUserService userService,
                               IAppRole appRole,
                               DataToDoListContext context)
        {
            this.userService = userService;
            this.appRole = appRole;
            this.context = context;
        }

        public IActionResult Registration() =>
               this.View();

        [HttpPost]
        public IActionResult CreateUser([Bind("FirstName,LastName,Birthday,Email,Password,ConfirmPassword,Id")]User authUser)
        {
            try
            {
                if (this.ModelState.IsValid)
                {

                    this.userService.Create(authUser);
                }
            }
            catch (AppException ex)
            {
                return this.BadRequest(new { message = ex.Message });
            }

            return this.RedirectToAction(nameof(this.Login));
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            
          if (ModelState.IsValid)
            {
                var user = this.context.Users.Where(x => x.Email == email && x.Password == password)?.FirstOrDefault();

              
                if (user != null)
                {
                    var role = appRole.SetRole(email, password).ToString();

                    ClaimsIdentity identity = null;
                    bool isAuthenticated = false;

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

                    if (isAuthenticated)
                    {
                        var principal = new ClaimsPrincipal(identity);

                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
         
            
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return this.RedirectToAction("Login");
        }

    }
}