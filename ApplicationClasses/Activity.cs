using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.ApplicationClasses
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityImage { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDesc { get; set; }
        public string ActivityType { get; set; }
        public Place ActivityPlace { get; set; }
        public double EntranceFee { get; set; }
    }
    public class Place
    {
        public string City { get; set; }
        public string Address { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
