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

        public ActionResult Review()
        {
            return View();
        }

        public ActionResult Reviews(string id)
        {
            List<Review> reviews = new List<Review>();
            if (!string.IsNullOrWhiteSpace(id))
            {
                reviews =_reviewRepository.GetByCategory(_categoriesRepository.GetByName(id)).ToList();
            }
            else
            {
                reviews = _reviewRepository.GetAll().ToList();
            }

            foreach (var review in reviews)
            {
                var comments = _reviewRepository.GetReviewComments(review.Id);
                review.Comments = comments.ToList();
            }
            return View(reviews);
        }

        public JsonResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var resp = new ReviewsController(_reviewRepository, _categoriesRepository).Comments(1);
            return Json(resp, JsonRequestBehavior.AllowGet);
        }
    }
}
