using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVDLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ILogicService _logicService;


        #region Constructors
        public HomeController(ILogicService logicservice)
        {
            _logicService = logicservice;
        }

        public HomeController()
        {
            _logicService = new LogicService();
        }
        #endregion

        public ActionResult Index()
        {
            //ViewBag.Movies = MoviesMaster;
            ViewBag.Movies = _logicService.GetMovies();
            return View();
        }

        public ActionResult Detail()
        {
            ViewBag.Message = "Lending History";
            //ViewBag.Borrows = BorrowsMaster;
            ViewBag.Borrows = _logicService.GetBorrows();
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public PartialViewResult Movie(Movie movie)
        {
            return PartialView(movie);
        }
        
        [HttpPost]
        public ActionResult Add(Movie movie)
        {
            _logicService.Create(movie);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteMovie(int ID)
        {
            _logicService.Delete(ID);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateMovie(Movie movie)
        {
            _logicService.Create(movie);
            return View("Index");
        }

        //public ActionResult Search()
        //{
        //    ViewBag.Movies = _logicService.GetMovies();
        //    return View();
        //}

        public ActionResult Search(string searchString)
        {
            List<Movie> movies = _logicService.SearchDB(searchString);
            ViewBag.Movies = movies;
            return View();
        }


    }
}