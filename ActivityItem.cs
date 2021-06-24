using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend
{
    /// <summary>
    /// Activity Item Class
    /// </summary>
    public class ActivityItem
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
        /// Activity name
        /// </summary>
        public string ActivityName { get; set; }
        /// <summary>
        /// Activity Description
        /// </summary>
        public string ActivityDesc { get; set; }
        /// <summary>
        /// Activity Type
        /// </summary>
        public string ActivityType { get; set; }
        /// <summary>
        /// Place
        /// </summary>
        public Place ActivityPlace { get; set; }
        /// <summary>
        /// Entrance fee
        /// </summary>
        public float EntranceFee { get; set; }
    }
    /// <summary>
    /// Place
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
    /// Location
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Latitude
        /// </summary>
        public float lat { get; set; }
        /// <summary>
        /// Longtitude
        /// </summary>
        public float lng { get; set; }
    }
}
