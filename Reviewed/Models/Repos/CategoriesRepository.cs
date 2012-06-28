using System.Collections.Generic;
using System.Data;
using System.Linq;
using Reviewed.Models.Abstract;

namespace Reviewed.Models.Repos
{
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
            return _db.Categories.SingleOrDefault(c => c.Id == id);
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
            var category = _db.Categories.Single(c => c.Id == categoryId);
            _db.Categories.Remove(category);
        }

        public Category GetByName(string category)
        {
            return _db.Categories.SingleOrDefault(c => c.Name == category);
        }
    }
}