using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Reviewed.Models.Abstract;

namespace Reviewed.Models.Repos
{
    public class ReviewRepository : IReviewRepository
    {
        private ReviewedContext _db { get; set; }

        public ReviewRepository()
            :this (new ReviewedContext())
        {
            
        }

        public ReviewRepository(ReviewedContext db)
        {
            _db = db;
        }

        public Review Get(int id)
        {
            return _db.Reviews.SingleOrDefault(r => r.Id == id);
        }

        public IQueryable<Review> GetAll()
        {
            return _db.Reviews;
        }

        public Review Add(Review review)
        {
            _db.Reviews.Add(review);
            _db.SaveChanges();
            return review;
        }

        public Review Update(Review review)
        {
            _db.Entry(review).State = EntityState.Modified;
            _db.SaveChanges();
            return review;
        }

        public void Delete(int reviewId)
        {
            var review = Get(reviewId);
            _db.Reviews.Remove(review);
        }

        public IEnumerable<Review> GetByCategory(Category category)
        {
            return _db.Reviews.Where(r => r.CategoryId == category.Id);
        }

        public IEnumerable<Comment> GetReviewComments(int id)
        {
            return _db.Comments.Where(c => c.ReviewId == id);
        }

        public IEnumerable<string> Autocomplete(string topic)
        {
            var reviews = _db.Reviews.Where(r => r.Topic.StartsWith(topic) || r.Topic.EndsWith(topic))
                .Select(r => r.Topic)
                .Distinct();
            return reviews;
        }
    }
}