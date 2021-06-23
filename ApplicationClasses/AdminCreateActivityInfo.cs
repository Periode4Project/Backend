using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.ApplicationClasses
{
    public class AdminCreateActivityInfo
    {
        public Activity SubmittedLocation { get; set; }
        public LoginUserCredentials LoginUserCredentials { get; set; }
    }
}
