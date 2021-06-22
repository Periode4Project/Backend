using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.DatabaseRepositories
{
    public static class ReviewRepository
    {
		public static List<ApplicationClasses.Review> GetReviewsForActivity(int Activity)
		{
			List<ApplicationClasses.Review> reviews = new List<ApplicationClasses.Review> { };
			using var connection = DatabaseConnectionRepository.Connect();
			try
			{
				reviews = (List<ApplicationClasses.Review>)connection.Query<ApplicationClasses.Review>
				(
					sql: "SELECT * FROM Reviews WHERE Activity=@Activity",
					param: new
					{
						@Activity = Activity
					}
				);
				foreach (ApplicationClasses.Review review in reviews)
                {
					review.ReviewWriterName = LoginRepository.GetUserFullName(review.ReviewWriter);
                }
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			return reviews;
		}
		public static bool IsAddReviewSuccessful(ApplicationClasses.SubmittedReview submittedReview)
        {
            if (LoginRepository.GetLoginInformation(submittedReview.LoginUserCredentials.Email, submittedReview.LoginUserCredentials.Password).Email != null)
            {
				int userid = LoginRepository.GetUserId(submittedReview.LoginUserCredentials.Email);
				if (userid < 0)
					return false;
				if (submittedReview.Review.Rating < 1 || submittedReview.Review.Rating > 10)
					return false;
				bool isSuccess = false;
                using var connection = DatabaseConnectionRepository.Connect();
                try
                {
                    int rowsEffected = connection.Execute(
						sql:
						@"INSERT INTO Reviews
						(
							ReviewTitle,
							Rating,
							ReviewDESC,
							ReviewWriter,
							Activity
						) 
						VALUES 
						(
							@ReviewTitle,
							@Rating,
							@ReviewDESC,
							@ReviewWriter,
							@Activity
						)",

						param: new
						{
                            @ReviewTitle = submittedReview.Review.ReviewTitle,
							@Rating = submittedReview.Review.Rating,
							@ReviewDESC = submittedReview.Review.ReviewDESC,
							@ReviewWriter = userid,
							@Activity = submittedReview.Review.Activity
						});
					if (rowsEffected == 1)
						isSuccess = true;
					return isSuccess;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
            return false;
        }

		public static List<ApplicationClasses.Review> GetAllReviews()
		{
			List<ApplicationClasses.Review> reviews = new List<ApplicationClasses.Review> { };
			using var connection = DatabaseConnectionRepository.Connect();
			try
			{
				reviews = (List<ApplicationClasses.Review>)connection.Query<ApplicationClasses.Review>
				(
					sql: "SELECT * FROM Reviews"
				);
				foreach (ApplicationClasses.Review review in reviews)
				{
					review.ReviewWriterName = LoginRepository.GetUserFullName(review.ReviewWriter);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			return reviews;
		}
	}
}
