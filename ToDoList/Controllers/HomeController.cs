namespace ToDoList.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> CategoryList()
        {
            var categories = await context.Categories.ToListAsync();
          return RedirectToAction("Index");
        }

        [HttpPost]

        public  IActionResult CreateCategory( Category category )
        {
            var isChek = this.dataCategoryService.CreateCategory(category);
            if (!isChek)
            {

                return  BadRequest($"Name { category.Name} is already in use.");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Models.DataAccess.Dal.Entites.Category  category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(category);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExist(category.Id))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

              return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await context.Categories.FindAsync(id);
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private bool CategoryExist(int id)
        {
            return context.Categories.Any(e => e.Id == id);
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