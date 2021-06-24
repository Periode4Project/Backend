using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SailingBackend.ApplicationClasses
{
    /// <summary>
    /// Review
    /// </summary>
    public class Review
    {
        /// <summary>
        /// ReviewID
        /// </summary>
        public int ReviewID { get; set; }
        /// <summary>
        /// ReviewTitle
        /// </summary>
        public string ReviewTitle { get; set; }
        /// <summary>
        /// Rating
        /// </summary>
        public double Rating { get; set; }
        /// <summary>
        /// Review Description
        /// </summary>
        public string ReviewDESC { get; set; }
        /// <summary>
        /// Review Writer ID
        /// </summary>
        public int ReviewWriter { get; set; }
        /// <summary>
        /// Review Writer Name
        /// </summary>
        public string ReviewWriterName { get; set; }
        /// <summary>
        /// Activity ID
        /// </summary>
        public int Activity { get; set; }
    }
}
