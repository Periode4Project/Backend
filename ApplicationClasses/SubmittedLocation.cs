using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.ApplicationClasses
{
    public class SubmittedLocation
    {
        public string ActivityName { get; set; }
        public string ActivityType { get; set; }
        public string ActivityImg { get; set; }
        public string ActivityDesc { get; set; }
        public double Entrancefee { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
