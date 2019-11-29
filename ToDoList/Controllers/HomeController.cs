namespace ToDoList.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Data;
    using Models;

    public class HomeController : Controller
    {
        public HomeController(DbToDoListContext context)
        {
            _context = context;
        }
        private readonly DbToDoListContext _context;

       
   
        public IActionResult Index()
        {
            return View();
        }


        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Birthday,Email,Phone,Password,ConfirmPassword,Id")]User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // Regitr
        public IActionResult Privacy()
        {
            return View();
        }
 
        public IActionResult Registration()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}