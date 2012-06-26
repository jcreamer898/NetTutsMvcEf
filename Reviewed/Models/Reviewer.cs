namespace Reviewed.Models
{
    public class Reviewer
    {
        public int ReviewerId { get; set; }
        
        
        public int ReviewId { get; set; }

        public virtual Review Review { get; set; }
    }
}