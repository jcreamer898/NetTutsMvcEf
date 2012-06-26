using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Reviewed.Models;
using Reviewed.Models.Abstract;

namespace Reviewed.Controllers
{
    public class CategoriesController : ApiController
    {
        public ICategoriesRepository _categoriesRepository { get; set; }

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        // GET api/categories
        public IEnumerable<Category> Get()
        {
            return _categoriesRepository.GetAll();
        }

        // GET api/categories/5
        public HttpResponseMessage Get(int id)
        {
            var category = _categoriesRepository.Get(id);

            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, category);
        }

        // POST api/categories
        public HttpResponseMessage Post(Category category)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, category);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("categories/{0}", category.CategoryId));
            _categoriesRepository.Add(category);
            return response;
        }

        // PUT api/categories/5
        public void Put(int id, Category category)
        {
            _categoriesRepository.Update(category);
        }

        // DELETE api/categories/5
        public HttpResponseMessage Delete(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            _categoriesRepository.Delete(id);
            return response;
        }
    }
}
