using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Reviewed.Models;
using Reviewed.Models.Abstract;
using Reviewed.Models.Repos;

namespace Reviewed.Controllers
{
    public class ReviewsController : ApiController
    {
        private ICategoriesRepository _categoriesRepository { get; set; }
        private IReviewRepository _reviewRepository { get; set; }

        public ReviewsController(IReviewRepository reviewRepository, ICategoriesRepository categoriesRepository)
        {
            _reviewRepository = reviewRepository;
            _categoriesRepository = categoriesRepository;
        }

        // GET api/review
        public IEnumerable<Review> Get()
        {
            var reviews = _reviewRepository.GetAll();
            return reviews;
        }

        // GET api/review/5
        public HttpResponseMessage Get(int id)
        {
            var review = _reviewRepository.Get(id);
            if (review == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, review);
        }

        // POST api/review
        public HttpResponseMessage Post(Review review)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, review);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("reviews/{0}", review.Id));
            _reviewRepository.Add(review);
            return response;
        }

        // PUT api/review/5
        public void Put(Review review)
        {
            _reviewRepository.Update(review);
        }

        // DELETE api/review/5
        public HttpResponseMessage Delete(int id)
        {
            _reviewRepository.Delete(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // GET api/reviews/categories/{category}
        public HttpResponseMessage GetByCategory(string category)
        {

            var findCategory = _categoriesRepository.GetByName(category);
            if (findCategory == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK,_reviewRepository.GetByCategory(findCategory));
        }

        // GET api/reviews/comments/{id}
        [HttpGet]
        public IEnumerable<Comment> Comments(int id)
        {

            var reviewComments = _reviewRepository.GetReviewComments(id);

            return reviewComments;
        }
    }
}
