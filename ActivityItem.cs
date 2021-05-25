using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend
{
    public class ActivityItem
    {
        public string ActivityImage { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDesc { get; set; }
        public string ActivityType { get; set; }
        public string ActivityLocation { get; set; }
        public float EntranceFee { get; set; }
    }
}
