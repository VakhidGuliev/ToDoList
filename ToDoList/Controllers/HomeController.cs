using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Edit(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var category =  _context.Categories.Find(name);
            if (category == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(string name,[Bind("Name")] Models.DataAccess.Dal.Entites.Category category)
        {
            if (name != category.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExist(category.Name))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var category =  _context.Categories
        //        .FirstOrDefault(m => m.Id == id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return RedirectToAction("Index");
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    var category =  _context.Categories.Find(id);
        //    _context.Categories.Remove(category);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
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