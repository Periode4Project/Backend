using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.DatabaseClasses
{
    /// <summary>
    /// Activity in database
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Activity ID
        /// </summary>
        public int ActivityID { get; set; }
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
        /// Entrance fee
        /// </summary>
        public double EntranceFee { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Latitude
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// Longtitude
        /// </summary>
        public double Lng { get; set; }
    }
}
