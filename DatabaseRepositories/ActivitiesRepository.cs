using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SailingBackend.DatabaseRepositories
{
    public class ActivitiesRepository
    {
		public IEnumerable<ApplicationClasses.Activity> GetAllActivities()
		{
			using var connection = DatabaseConnectionRepository.Connect();
			try
			{
				IEnumerable<DatabaseClasses.Activity> vStorage = connection.Query<DatabaseClasses.Activity>("SELECT * FROM Activities");
				List<ApplicationClasses.Activity> activities = new List<ApplicationClasses.Activity>();
				foreach (DatabaseClasses.Activity activity in vStorage)
                {
					activities.Add(new ApplicationClasses.Activity 
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
                        }
					});
                }
				return activities;
			}
			catch (NullReferenceException)
			{
				return new List<ApplicationClasses.Activity> { };
			}
		}
	}
}
