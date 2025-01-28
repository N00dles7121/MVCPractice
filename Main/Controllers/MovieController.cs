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
        private MovieCategoryVM _movieCategoryVM;

        public MovieController(MovieRepo movieRepo, CategoryRepo categoryRepo)
        {
            _movieCategoryVM = new MovieCategoryVM();
            _movieRepo = movieRepo;
            _categoryRepo = categoryRepo;
        }

        // GET: MovieController
        public async Task<IActionResult> Index()
        {
            try
            {
                _movieCategoryVM.Movies = (List<Movie>)await _movieRepo.GetAll();

                foreach (var movie in _movieCategoryVM.Movies)
                {
                    movie.Category = await _categoryRepo.GetById(movie.CategoryId);
                }

                return View(_movieCategoryVM);
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

            _movieCategoryVM.Categories = categories.ToList();
            return View(_movieCategoryVM);
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
                _movieCategoryVM.Movie = movieCategoryVM.Movie;
                await _movieRepo.Add(_movieCategoryVM.Movie);
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
