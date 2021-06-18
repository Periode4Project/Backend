using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.ApplicationClasses
{
    public class MapQuestResponse
    {
        public List<Result> results { get; set; }
    }

    public class Result
    {
        public List<MapQuestLocation> locations { get; set; }
    }

    public class MapQuestLocation
    {
        public LatLong latLng { get; set; }
    }

    public class LatLong
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
