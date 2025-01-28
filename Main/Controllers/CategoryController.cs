using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MVCPractice.Controllers;
public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;

    private readonly CategoryRepo _categoryRepo;

    public CategoryController(ILogger<CategoryController> logger, CategoryRepo categoryRepo)
    {
        _logger = logger;
        _categoryRepo = categoryRepo;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var categories = await _categoryRepo.GetAll();
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
            await _categoryRepo.Add(category);
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
        try
        {
            var category = await _categoryRepo.GetById(id);
            return View(category);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching the category.");
            TempData["ErrorMessage"] = "An error occurred while fetching the category. Please try again.";
            return View("Index");
        }
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
            await _categoryRepo.Update(category);
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
        try
        {
            var category = await _categoryRepo.GetById(id);
            return View(category);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching the category.");
            TempData["ErrorMessage"] = "An error occurred while fetching the category. Please try again.";
            return View("Index");
        }
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeletePOST(int id)
    {
        try
        {
            await _categoryRepo.Delete(id);
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