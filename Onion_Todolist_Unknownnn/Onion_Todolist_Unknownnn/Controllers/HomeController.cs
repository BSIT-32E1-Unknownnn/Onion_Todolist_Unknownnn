using Microsoft.AspNetCore.Mvc;
using Onion_Todolist_Unknownnn.Models;
using System.Diagnostics;

namespace Onion_Todolist_Unknownnn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Todolist> todolists = new List<Todolist>();
            using (var db = new Database())
            {
                todolists = db.TodoList.ToList();
            }

            ViewBag.Todolist = todolists;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Index(Todolist todolist)
        {
            using (var db = new Database())
                if (ModelState.IsValid)
                {
                    db.Add(todolist);
                    db.SaveChanges();

                    // Refresh the list of tasks after adding the new task
                    var updatedTodolist = db.TodoList.ToList();
                    ViewBag.Todolist = updatedTodolist;

                    return View();
                }
                else
                {
                    // Handle validation errors
                    // For example, you can return the same view with validation errors
                    return View(todolist);
                }
        }
    }
}
