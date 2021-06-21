using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.DatabaseRepositories
{
    public static class AdminRepository
    {
        public static bool IsAddActivitySuccessful(DatabaseClasses.Activity activity)
        {
            bool isSuccess = false;
            using var connection = DatabaseConnectionRepository.Connect();
			try
			{
				int rowsEffected = connection.Execute(
					sql: 
					@"
					INSERT INTO Activities 
					(
						ActivityImage, 
						ActivityName, 
						ActivityDesc, 
						ActivityType, 
						EntranceFee, 
						City, 
						Address, 
						Lat, 
						Lng
					) 
					VALUES 
					(
						@ActivityImage, 
						@ActivityName, 
						@ActivityDesc, 
						@ActivityType, 
						@EntranceFee, 
						@City, 
						@Address, 
						@Lat, 
						@Lng
					)
					",

					param: new
					{
						@ActivityImage = activity.ActivityImage,
						@ActivityName = activity.ActivityName,
						@ActivityDesc = activity.ActivityDesc,
						@ActivityType = activity.ActivityType,
						@EntranceFee = activity.EntranceFee,
						@City = activity.City,
						@Address = activity.Address,
						@Lat = activity.Lat,
						@Lng = activity.Lng
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

		public static bool IsDeleteReviewSuccessful(int ReviewId)
        {
			bool isSuccess = false;
			using var connection = DatabaseConnectionRepository.Connect();
			try
			{
				int rowsEffected = connection.Execute(
					sql:
					@"
					DELETE FROM Reviews
					WHERE
					ReviewID=@REVIEW
					",

					param: new
					{
						@REVIEW = ReviewId
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

		public static bool IsDeleteActivitySuccessful(int activityId)
		{
			bool isSuccess = false;
			using var connection = DatabaseConnectionRepository.Connect();
			try
			{
				int rowsEffected = connection.Execute(
					sql:
					@"
					DELETE FROM Activities
					WHERE
					ActivityID=@ACTIVITY
					",

					param: new
					{
						@ACTIVITY = activityId
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
	}
}
