using System.Data.Entity;
using System.Linq;

namespace Reviewed.Models
{
    public class ReviewedContextInitializer : DropCreateDatabaseIfModelChanges<ReviewedContext>
    {
        protected override void Seed(ReviewedContext context)
        {
            var categoryId = context.Categories.Add(new Category
                {
                    Name = "Doctors"
                });
            context.Categories.Add(new Category
                {
                    Name = "Dentists"
                });
            context.SaveChanges();

            context.Reviews.Add(new Review
                {
                    CategoryId = context.Categories.First().Id,
                    Email = "matrixhasyou2k4@gmail.com",
                    IsAnonymous = false,
                    Content = "A great deal.",
                    Topic = "Dr. Brewer"
                });
            context.SaveChanges();

            context.Comments.Add(new Comment
                {
                    ReviewId = context.Reviews.Single().Id,
                    Email = "matrixhasyou2k4@gmail.com",
                    IsAnonymous = false,
                    Content = "Yup, I agree..."
                });
            context.SaveChanges();
        }
    }
}