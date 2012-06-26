using System.Data.Entity;

namespace Reviewed.Models
{
    public class ReviewedContextInitializer : DropCreateDatabaseIfModelChanges<ReviewedContext>
    {
        protected override void Seed(ReviewedContext context)
        {
            var categoryId = context.Categories.Add(new Category
                {
                    Name = "Doctors"
                }).CategoryId;
            context.Categories.Add(new Category
                {
                    Name = "Dentists"
                });
            context.SaveChanges();

            var reviewId = context.Reviews.Add(new Review
                {
                    CategoryId = categoryId,
                    Email = "matrixhasyou2k4@gmail.com",
                    IsAnonymous = false,
                    Content = "A great deal.",
                    Topic = "Dr. Brewer"
                }).ReviewId;
            context.SaveChanges();

            context.Comments.Add(new Comment
                {
                    ReviewId = reviewId,
                    Email = "matrixhasyou2k4@gmail.com",
                    IsAnonymous = false,
                    Content = "Yup, I agree..."
                });
            context.SaveChanges();
        }
    }
}