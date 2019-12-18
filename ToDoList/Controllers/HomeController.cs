using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Models.Business.Entites;
using ToDoList.Models.Business.Service.Interface;
using ToDoList.Models.DataAccess.Data;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataToDoListContext _context;
        private readonly ICategoryService _dataCategoryService;

        public HomeController(DataToDoListContext context, ICategoryService categoryService)
        {
            _context = context;
            _dataCategoryService = categoryService;
        }

        [Authorize(Roles = "Admin,User")]

        public IActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public  JsonResult CategoryList() =>
                     Json(_dataCategoryService.Categories());
        

        [HttpPost]
        public  IActionResult CreateCategory( Category category )
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
               return  BadRequest($"Name { category.Name} is already in use.");
            }
            return RedirectToAction("Index");
        }
//
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }
//
//            var category = await context.Categories.FindAsync(id);
//            if (category == null)
//            {
//                return NotFound();
//            }
//            return RedirectToAction("Index");
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Models.DataAccess.Dal.Entites.Category  category)
//        {
//            if (id != category.Id)
//            {
//                return NotFound();
//            }
//
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    context.Update(category);
//                    await context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!CategoryExist(category.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction("Index");
//            }
//            return RedirectToAction("Index");
//        }
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }
//
//            var category = await context.Categories
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (category == null)
//            {
//                return NotFound();
//            }
//            return RedirectToAction("Index");
////        }
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var category = await context.Categories.FindAsync(id);
//            context.Categories.Remove(category);
//            await context.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }
//        private bool CategoryExist(int id)
//        {
//            return context.Categories.Any(e => e.Id == id);
//        }
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