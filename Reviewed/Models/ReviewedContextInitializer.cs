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
            context.Categories.Add(new Category
            {
                Name = "Restaurants"
            });
            context.Categories.Add(new Category
            {
                Name = "Veterinarian"
            });
            context.Categories.Add(new Category
            {
                Name = "Roofers"
            });
            context.SaveChanges();

            context.Reviews.Add(new Review
                {
                    CategoryId = context.Categories.First().Id,
                    Email = "matrixhasyou2k4@gmail.com",
                    IsAnonymous = false,
                    Content = @"Normally, both your asses would be dead as fucking fried chicken, but you happen to pull this shit while I'm in a transitional period so I don't wanna kill you, I wanna help you. But I can't give you this case, it don't belong to me. Besides, I've already been through too much shit this morning over this case to hand it over to your dumb ass.

The path of the righteous man is beset on all sides by the iniquities of the selfish and the tyranny of evil men. Blessed is he who, in the name of charity and good will, shepherds the weak through the valley of darkness, for he is truly his brother's keeper and the finder of lost children. And I will strike down upon thee with great vengeance and furious anger those who would attempt to poison and destroy My brothers. And you will know My name is the Lord when I lay My vengeance upon thee.

Your bones don't break, mine do. That's clear. Your cells react to bacteria and viruses differently than mine. You don't get sick, I do. That's also clear. But for some reason, you and I react the exact same way to water. We swallow it too fast, we choke. We get some in our lungs, we drown. However unreal it may seem, we are connected, you and I. We're on the same curve, just on opposite ends.
",
                    Topic = "Dr Brewer"
                });
            context.Reviews.Add(new Review
            {
                CategoryId = context.Categories.First().Id,
                Email = "matrixhasyou2k4@gmail.com",
                IsAnonymous = false,
                Content = @"Look, just because I don't be givin' no man a foot massage don't make it right for Marsellus to throw Antwone into a glass motherfuckin' house, fuckin' up the way the nigger talks. Motherfucker do that shit to me, he better paralyze my ass, 'cause I'll kill the motherfucker, know what I'm sayin'?

You think water moves fast? You should see ice. It moves like it has a mind. Like it knows it killed the world once and got a taste for murder. After the avalanche, it took us a week to climb out. Now, I don't know exactly when we turned on each other, but I know that seven of us survived the slide... and only five made it out. Now we took an oath, that I'm breaking now. We said we'd say it was the snow that killed the other two, but it wasn't. Nature is lethal but it doesn't hold a candle to man.

My money's in that office, right? If she start giving me some bullshit about it ain't there, and we got to go someplace else and get it, I'm gonna shoot you in the head then and there. Then I'm gonna shoot that bitch in the kneecaps, find out where my goddamn money is. She gonna tell me too. Hey, look at me when I'm talking to you, motherfucker. You listen: we go in there, and that nigga Winston or anybody else is in there, you the first motherfucker to get shot. You understand?",
                Topic = "Dr Brewer"
            });
            context.Reviews.Add(new Review
                {
                    CategoryId = context.Categories.First().Id,
                    Email = "matrixhasyou2k4@gmail.com",
                    IsAnonymous = false,
                    Content = @"Look, just because I don't be givin' no man a foot massage don't make it right for Marsellus to throw Antwone into a glass motherfuckin' house, fuckin' up the way the nigger talks. Motherfucker do that shit to me, he better paralyze my ass, 'cause I'll kill the motherfucker, know what I'm sayin'?

Now that we know who you are, I know who I am. I'm not a mistake! It all makes sense! In a comic, you know how you can tell who the arch-villain's going to be? He's the exact opposite of the hero. And most times they're friends, like you and me! I should've known way back when... You know why, David? Because of the kids. They called me Mr Glass.

You think water moves fast? You should see ice. It moves like it has a mind. Like it knows it killed the world once and got a taste for murder. After the avalanche, it took us a week to climb out. Now, I don't know exactly when we turned on each other, but I know that seven of us survived the slide... and only five made it out. Now we took an oath, that I'm breaking now. We said we'd say it was the snow that killed the other two, but it wasn't. Nature is lethal but it doesn't hold a candle to man.",
                    Topic = "Dr Job"
                });

            context.Reviews.Add(new Review
                {
                    CategoryId = context.Categories.Last().Id,
                    Email = "another@email.com",
                    IsAnonymous = false,
                    Content =
                        @"Normally, both your asses would be dead as fucking fried chicken, but you happen to pull this shit while I'm in a transitional period so I don't wanna kill you, I wanna help you. But I can't give you this case, it don't belong to me. Besides, I've already been through too much shit this morning over this case to hand it over to your dumb ass.

The path of the righteous man is beset on all sides by the iniquities of the selfish and the tyranny of evil men. Blessed is he who, in the name of charity and good will, shepherds the weak through the valley of darkness, for he is truly his brother's keeper and the finder of lost children. And I will strike down upon thee with great vengeance and furious anger those who would attempt to poison and destroy My brothers. And you will know My name is the Lord when I lay My vengeance upon thee.

Well, the way they make shows is, they make one show. That show's called a pilot. Then they show that show to the people who make shows, and on the strength of that one show they decide if they're going to make more shows. Some pilots get picked and become television programs. Some don't, become nothing. She starred in one of the ones that became nothing."
                });
            context.SaveChanges();

            var review = context.Reviews.First();
            var reviewId = review.Id;

            context.Comments.Add(new Comment
                {
                    ReviewId = reviewId,
                    Email = "blah@gmail.com",
                    IsAnonymous = false,
                    Content = "Yup, I agree..."
                });
            context.Comments.Add(new Comment
            {
                ReviewId = reviewId,
                Email = "foo@gmail.com",
                IsAnonymous = false,
                Content = "me 2"
            });
            context.Comments.Add(new Comment
            {
                ReviewId = reviewId,
                Email = "bar@gmail.com",
                IsAnonymous = false,
                Content = "This guys crazy!"
            });
            context.Comments.Add(new Comment
            {
                ReviewId = reviewId,
                Email = "bam@gmail.com",
                IsAnonymous = false,
                Content = "uhhhh..."
            }); context.Comments.Add(new Comment
            {
                ReviewId = reviewId,
                Email = "badabing@gmail.com",
                IsAnonymous = false,
                Content = "yea yea yea"
            });
            context.SaveChanges();
        }
    }
}