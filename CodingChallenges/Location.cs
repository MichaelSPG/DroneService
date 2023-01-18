using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServices
{
    /// <summary>
    /// Describes the location
    /// </summary>
    internal class Location
    {
        /// <summary>
        /// location Name
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// The package's weight
        /// </summary>
        public long? PackageWeight { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Location name</param>
        /// <param name="packageWeight">Location's Package Weight</param>
        public Location(string? name, long? packageWeight)
        {
            Name = name;
            PackageWeight = packageWeight;
        }
    }
}
