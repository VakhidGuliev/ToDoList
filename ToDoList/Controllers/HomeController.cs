namespace ToDoList.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ToDoList.Models;
    using ToDoList.Models.Business.Entites;
    using ToDoList.Models.Business.Service.Interface;

    using ToDoList.Models.DataAccess.Data;

    public class HomeController : Controller
    {
        private readonly DataToDoListContext context;
        private readonly ICategoryService dataCategoryService;

        public HomeController(DataToDoListContext context, ICategoryService categoryService)
        {
            this.context = context;
            this.dataCategoryService = categoryService;
        }

        [Authorize(Roles = "Admin,User")]

        public IActionResult Index()
        {
            return this.View();
        }
 
        [HttpPost]

        public  IActionResult CreateCategory( Category category )
        {
            var isChek = this.dataCategoryService.CreateCategory(category).Result;
            if (!isChek)
            {

                return  BadRequest($"Name { category.Name} is already in use.");
            }
            return RedirectToAction("Index");
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
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}