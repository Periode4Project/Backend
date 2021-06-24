using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SailingBackend.ApplicationClasses;

namespace SailingBackend.DatabaseRepositories
{
	/// <summary>
	/// Contains database logic for reviews
	/// </summary>
    public static class ReviewRepository
    {
		/// <summary>
		/// Get all reviews for an activity
		/// </summary>
		/// <param name="Activity"> int activity </param>
		/// <returns> List of type Review </returns>
		public static List<Review> GetReviewsForActivity(int Activity)
		{
			List<Review> reviews = new List<Review> { };
			using var connection = DatabaseConnectionRepository.Connect();
			try
			{
				reviews = (List<Review>)connection.Query<Review>
				(
					sql: "SELECT * FROM Reviews WHERE Activity=@Activity",
					param: new
					{
						@Activity = Activity
					}
				);
				foreach (Review review in reviews)
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

		/// <summary>
		/// Add review
		/// </summary>
		/// <param name="submittedReview"> Object of type SubmittedReview </param>
		/// <returns> bool success </returns>
		public static bool IsAddReviewSuccessful(SubmittedReview submittedReview)
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

		/// <summary>
		/// Get all reviews
		/// </summary>
		/// <returns> List of type Review </returns>
		public static List<Review> GetAllReviews()
		{
			List<Review> reviews = new List<Review> { };
			using var connection = DatabaseConnectionRepository.Connect();
			try
			{
				reviews = (List<Review>)connection.Query<Review>
				(
					sql: "SELECT * FROM Reviews"
				);
				foreach (Review review in reviews)
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
