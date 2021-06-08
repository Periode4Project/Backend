using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.DatabaseClasses
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public string ActivityImage { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDesc { get; set; }
        public string ActivityType { get; set; }
        public double EntranceFee { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
