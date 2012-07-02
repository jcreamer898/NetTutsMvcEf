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
    public class CommentsController : ApiController
    {
        private ICommentsRepository _commentsRepository { get; set; }

        public CommentsController(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        // GET api/comments
        public IEnumerable<Comment> Get()
        {
            return _commentsRepository.GetAll();
        }

        // GET api/comments/5
        public HttpResponseMessage Get(int id)
        {
            var comment = _commentsRepository.Get(id);
            if (comment == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, comment);
        }

        // POST api/review
        public HttpResponseMessage Post(Comment comment)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created, comment);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("reviews/{0}", comment.Id));
            _commentsRepository.Add(comment);
            return response;
        }

        // PUT api/review/5
        public void Put(Comment comment)
        {
            _commentsRepository.Update(comment);
        }

        // DELETE api/review/5
        public HttpResponseMessage Delete(int id)
        {
            _commentsRepository.Delete(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        
    }
}
