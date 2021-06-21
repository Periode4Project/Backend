using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.ApplicationClasses
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string ReviewTitle { get; set; }
        public double Rating { get; set; }
        public string ReviewDESC { get; set; }
        public int ReviewWriter { get; set; }
        public string ReviewWriterName { get; set; }
        public int Activity { get; set; }
    }
}
