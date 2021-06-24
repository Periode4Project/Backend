using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.ApplicationClasses
{
    /// <summary>
    /// Class to hold Review and login Details
    /// </summary>
    public class SubmittedReview
    {
        /// <summary>
        /// Review
        /// </summary>
        public Review Review { get; set; }
        /// <summary>
        /// Login credentials
        /// </summary>
        public LoginUserCredentials LoginUserCredentials { get; set; }
    }
}
