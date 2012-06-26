using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Reviewed.Models.Abstract
{
    public interface ICategoriesRepository
    {
        Category Get(int id);
        IEnumerable<Category> GetAll();
        Category Add(Category category);
        Category Update(Category review);
        void Delete(int reviewId);
        Category GetByName(string category);
    }

    public class CategoriesRepository : ICategoriesRepository
    {
        private ReviewedContext _db { get; set; }

        public CategoriesRepository()
            :this(new ReviewedContext())
        {
            
        }

        public CategoriesRepository(ReviewedContext db)
        {
            _db = db;
        }

        public Category Get(int id)
        {
            return _db.Categories.SingleOrDefault(c => c.CategoryId == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Categories;
        }

        public Category Add(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return category;
        }

        public Category Update(Category category)
        {
            _db.Entry(category).State = EntityState.Modified;
            _db.SaveChanges();
            return category;
        }

        public void Delete(int categoryId)
        {
            var category = _db.Categories.Single(c => c.CategoryId == categoryId);
            _db.Categories.Remove(category);
        }

        public Category GetByName(string category)
        {
            return _db.Categories.SingleOrDefault(c => c.Name == category);
        }
    }
}