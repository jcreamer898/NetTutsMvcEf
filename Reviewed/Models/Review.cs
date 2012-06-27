using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reviewed.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        
        public int CategoryId { get; set; }
        public string Topic { get; set; }
        public string Email { get; set; }
        public bool IsAnonymous { get; set; }
        
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}