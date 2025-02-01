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

            _movieCategoryVM.Categories = _categoryRepo.GetAll().ToList();
        }

        // GET: MovieController
        public async Task<IActionResult> Index()
        {
            try
            {
                _movieCategoryVM.Movies = (List<Movie>)await _movieRepo.GetAllAsync();

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

        public IActionResult Create()
        {
            return View(_movieCategoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieCategoryVM movieCategoryVM)
        {
            if (!ModelState.IsValid)
            {
                _movieCategoryVM.Movie = movieCategoryVM.Movie;

                return View(_movieCategoryVM);
            }

            try
            {
                _movieCategoryVM.Movie = movieCategoryVM.Movie;

                Movie movie = _movieCategoryVM.Movie.ToModel();
                await _movieRepo.Add(movie);

                TempData["SuccessMessage"] = "Movie created successfully!";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ErrorMessage"] = "An error occurred while creating the movie. Please try again.";
                return View(_movieCategoryVM);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var movie = await _movieRepo.GetById(id);
                _movieCategoryVM.Movie = movie.ToDto();

                return View(_movieCategoryVM);
            }
            catch
            {
                TempData["ErrorMessage"] = "An error occurred while fetching the movie. Please try again.";
                return View("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieCategoryVM movieCategoryVM, int id)
        {

            if (!ModelState.IsValid)
            {
                _movieCategoryVM.Movie = movieCategoryVM.Movie;

                return View(_movieCategoryVM);
            }

            try
            {
                await _movieRepo.ExecuteUpdateAsync(movieCategoryVM.Movie, id);
                TempData["SuccessMessage"] = "Movie created successfully!";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ErrorMessage"] = "An error occurred while editing the movie. Please try again.";
                return View(_movieCategoryVM);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Movie movie = await _movieRepo.GetById(id);
                _movieCategoryVM.Movie = movie.ToDto();

                _movieCategoryVM.Movie.CategoryName = _movieCategoryVM.Categories
                                                    .First(c => c.Id == movie.CategoryId).Name;

                return View(_movieCategoryVM.Movie);
            }
            catch
            {
                TempData["ErrorMessage"] = "An error occurred while deleteing the movie. Please try again.";
                return View("Index");
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePOST(int id)
        {
            try
            {
                await _movieRepo.Delete(id);
                TempData["SuccessMessage"] = "Movie deleted successfully!";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the movie. Please try again.";
                return View("Index");
            }
        }
    }
}
