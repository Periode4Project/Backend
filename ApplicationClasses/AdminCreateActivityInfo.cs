using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.ApplicationClasses
{
    /// <summary>
    /// Create Activity Info
    /// </summary>
    public class AdminCreateActivityInfo
    {
        /// <summary>
        /// Activity
        /// </summary>
        public Activity SubmittedLocation { get; set; }
        /// <summary>
        /// User Credentials
        /// </summary>
        public LoginUserCredentials LoginUserCredentials { get; set; }
    }
}
