using Microsoft.AspNetCore.Mvc;
using MVCPractice.Data;
using MVCPractice.Models;

namespace MVCPractice.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ProgramContext _context;

        public CategoryController(ILogger<CategoryController> logger, ProgramContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(category.Name == category.DisplayOrder.ToString()){
                ModelState.AddModelError("", "Name and Display Order cannot be the same.");
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the category.");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the category. Please try again.");
                return View(category);
            }
        }

        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            try
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the category.");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the category. Please try again.");
                return View(category);
            }
        }

        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            var category = _context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }

            try
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the category.");
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the category. Please try again.");
                return View(category);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}