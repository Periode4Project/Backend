using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SailingBackend.ApplicationClasses;

namespace SailingBackend.DatabaseRepositories
{
	/// <summary>
	/// Contains database logic relating to Activities
	/// </summary>
    public static class ActivitiesRepository
    {
		/// <summary>
		/// Get all activities from database
		/// </summary>
		/// <returns> IEnumerable of type Activity </returns>
		public static IEnumerable<Activity> GetAllActivities()
		{
			using var connection = DatabaseConnectionRepository.Connect();
			try
			{
				IEnumerable<DatabaseClasses.Activity> vStorage = connection.Query<DatabaseClasses.Activity>("SELECT * FROM Activities");
				List<Activity> activities = new List<Activity>();
				foreach (DatabaseClasses.Activity activity in vStorage)
                {
					activities.Add(new Activity 
					{ 
						ActivityId = activity.ActivityID,
						ActivityImage = activity.ActivityImage,
						ActivityName = activity.ActivityName,
						ActivityDesc = activity.ActivityDesc,
						ActivityType = activity.ActivityType,
						ActivityPlace = new ApplicationClasses.Place
                        {
							City = activity.City,
							Address = activity.Address,
							Location = new ApplicationClasses.Location
                            {
								lat = activity.Lat,
								lng = activity.Lng
                            }
                        },
						EntranceFee = activity.EntranceFee
					});
                }
				return activities;
			}
			catch (NullReferenceException)
			{
				return new List<Activity> { };
			}
		}
	}
}
