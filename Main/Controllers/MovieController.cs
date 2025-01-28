using System.Threading.Tasks;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels;

namespace Main.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieRepo _movieRepo;
        private readonly CategoryRepo _categoryRepo;

        public MovieController(MovieRepo movieRepo, CategoryRepo categoryRepo)
        {
            _movieRepo = movieRepo;
            _categoryRepo = categoryRepo;
        }

        // GET: MovieController
        public async Task<IActionResult> Index()
        {
            try
            {
                var movies = await _movieRepo.GetAll();
                return View(movies);
            }
            catch
            {
                TempData["ErrorMessage"] = "An error occurred while fetching the movies. Please try again.";
                return View();
            }
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryRepo.GetAll();

            MovieCategoryVM movieCategoryVM = new MovieCategoryVM
            {
                Categories = categories.ToList()
            };
            return View(movieCategoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieCategoryVM movieCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View(movieCategoryVM);
            }

            try
            {
                movieCategoryVM.Movie.Category = await _categoryRepo.GetById(movieCategoryVM.Movie.CategoryId);
                await _movieRepo.Add(movieCategoryVM.Movie);
                TempData["SuccessMessage"] = "Movie created successfully!";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ErrorMessage"] = "An error occurred while creating the movie. Please try again.";
                return View(movieCategoryVM.Movie);
            }
        }
    }
}
