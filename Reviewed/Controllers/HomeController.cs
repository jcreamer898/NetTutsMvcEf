using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reviewed.Models;
using Reviewed.Models.Abstract;
using Reviewed.Models.Repos;

namespace Reviewed.Controllers
{
    public class HomeController : Controller
    {
        private ICategoriesRepository _categoriesRepository { get; set; }
        private IReviewRepository _reviewRepository { get; set; }

        public HomeController(ICategoriesRepository categoriesRepository, IReviewRepository reviewRepository)
        {
            _categoriesRepository = categoriesRepository;
            _reviewRepository = reviewRepository;
        }
        
        public ActionResult Index()
        {
            var categories = _categoriesRepository.GetAll();
            return View(categories);
        }

        public ActionResult Reviews(string id)
        {
            var reviews = _reviewRepository.GetByCategory(_categoriesRepository.GetByName(id));

            return View(reviews);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
