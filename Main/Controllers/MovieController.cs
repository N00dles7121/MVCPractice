using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Main.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieRepo _movieRepo;

        public MovieController(MovieRepo movieRepo)
        {
            _movieRepo = movieRepo;
        }

        // GET: MovieController
        public ActionResult Index()
        {
            return View();
        }

    }
}
