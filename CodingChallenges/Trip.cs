using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServices
{
    /// <summary>
    /// Contains the locations to visit in a trip
    /// </summary>
    internal class Trip
    {
        /// <summary>
        /// The list of locations in a trip
        /// </summary>
        public List<Location> Locations{ get; set; }
        /// <summary>
        /// The total weight of a trip
        /// </summary>
        public long? TripWeight{ get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public Trip()
        {
            Locations = new List<Location>();
        }
    }
}
