using System.Collections.Generic;

namespace Reviewed.Models.Abstract
{
    public interface ICommentsRepository
    {
        Comment Get(int id);
        IEnumerable<Comment> GetAll();
        Comment Add(Comment Comment);
        Comment Update(Comment comment);
        void Delete(int commentId);
    }
}