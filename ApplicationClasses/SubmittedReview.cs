using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.ApplicationClasses
{
    public class SubmittedReview
    {
        public Review Review { get; set; }
        public LoginUserCredentials LoginUserCredentials { get; set; }
    }
}
