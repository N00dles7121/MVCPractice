using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            try
            {
                var categories = await _context.Categories.ToListAsync();
                return View(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the categories.");
                TempData["ErrorMessage"] = "An error occurred while fetching the categories. Please try again.";
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "Name and Display Order cannot be the same.");
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Category created successfully!";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the category.");
                TempData["ErrorMessage"] = "An error occurred while creating the category. Please try again.";
                return View("Index");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            try
            {
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Category updated successfully!";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the category.");
                TempData["ErrorMessage"] = "An error occurred while updating the category. Please try again.";
                return View("Index");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePOST(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            try
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Category deleted successfully!";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the category.");
                TempData["ErrorMessage"] = "An error occurred while deleting the category. Please try again.";
                return View("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}