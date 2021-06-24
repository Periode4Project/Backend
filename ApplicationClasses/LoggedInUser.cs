using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.ApplicationClasses
{
    /// <summary>
    /// Logged in user information
    /// </summary>
    public class LoggedInUser
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Fullname
        /// </summary>
        public string Fullname { get; set; }
        /// <summary>
        /// Is Admin
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}
