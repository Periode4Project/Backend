using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.ApplicationClasses
{
    /// <summary>
    /// Activity Application-side
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Activity ID
        /// </summary>
        public int ActivityId { get; set; }
        /// <summary>
        /// Activity Image URL
        /// </summary>
        public string ActivityImage { get; set; }
        /// <summary>
        /// Activity Name
        /// </summary>
        public string ActivityName { get; set; }
        /// <summary>
        /// Actvity Description
        /// </summary>
        public string ActivityDesc { get; set; }
        /// <summary>
        /// Activity Type
        /// </summary>
        public string ActivityType { get; set; }
        /// <summary>
        /// Activity Place
        /// </summary>
        public Place ActivityPlace { get; set; }
        /// <summary>
        /// Entrance Fee
        /// </summary>
        public double EntranceFee { get; set; }
    }
    /// <summary>
    /// Place Type
    /// </summary>
    public class Place
    {
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Location
        /// </summary>
        public Location Location { get; set; }
    }

    /// <summary>
    /// Location Type
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Latitude
        /// </summary>
        public double lat { get; set; }
        /// <summary>
        /// Longtitude
        /// </summary>
        public double lng { get; set; }
    }
}
