using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models.Business.Entites;
using ToDoList.Models.Business.Service.Interface;
using ToDoList.Models.DataAccess.Dal.Service.Interface;
using ToDoList.Models.DataAccess.Data;
using ToDoList.Models.Helpers;

namespace ToDoList.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAppRole _appRole;
        private readonly IAccountService _accountService;
        private readonly IDataAccountService _dataAccountService;
        private DataToDoListContext _doListContext;

        private static string UserEmail{ get; set; }

        public static int UserAccountId { get; set; }

       public AccountController(IUserService userService,
                                 IAppRole appRole,
                                 IAccountService accountService,
                                 IDataAccountService dataAccountService,
                                 DataToDoListContext doListContext)
        {
            _userService = userService;
            _accountService = accountService;
            _appRole = appRole;
            _dataAccountService = dataAccountService;
            _doListContext = doListContext;
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
           
            var userId =_dataAccountService.SetUserAccountId(email, password);
        
            if (userId==0) return View();
            
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
                  new Claim(ClaimTypes.Role, role)
              }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticated = true;
            }

            if (!isAuthenticated) return View();
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
           return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public JsonResult GetUser()
        {
            var mail = HttpContext.User.Claims.FirstOrDefault().Value;
          
            Models.DataAccess.Dal.Entites.User user = _doListContext.Users.FirstOrDefault(x => x.Email == mail);

            return  Json(user);
        }

           string  GetUserAccountEmail()
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