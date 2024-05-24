using Microsoft.AspNetCore.Mvc;
using Onion_Todolist_Unknownnn.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore; // Add this namespace for DbContext

namespace Onion_Todolist_Unknownnn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _db; // Change 'Database' to 'DatabaseContext'

        // Modify the constructor to inject the Database context
        public HomeController(ILogger<HomeController> logger, DatabaseContext db)
        {
            _logger = logger;
            _db = db; // Assign the injected Database context to the private field
        }

        public IActionResult Index()
        {
            try
            {
                List<Todolist> todolists = _db.TodoList.ToList(); // Use the injected Database context

                ViewBag.Todolist = todolists;
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving todolists");
                return RedirectToAction(nameof(Error));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Index(Todolist todolist)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Add(todolist);
                    _db.SaveChanges();

                    // Refresh the list of tasks after adding the new task
                    var updatedTodolist = _db.TodoList.ToList();
                    ViewBag.Todolist = updatedTodolist;

                    return View();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error adding todolist");
                    return RedirectToAction(nameof(Error));
                }
            }
            else
            {
                // Handle validation errors
                // For example, you can return the same view with validation errors
                return View(todolist);
            }
        }

        [HttpPost]
        public IActionResult UpdateAction(int id)
        {
            try
            {
                var task = _db.TodoList.Find(id);
                if (task != null)
                {
                    task.Action = "Completed";
                    _db.SaveChanges();
                }

                // Redirect to the Index action to refresh the list of tasks
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating todolist");
                return RedirectToAction(nameof(Error));
            }
        }
    }
}
