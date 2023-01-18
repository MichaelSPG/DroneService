using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServices
{
    /// <summary>
    /// the drone properties
    /// </summary>
    internal class Drone
    {
        /// <summary>
        /// Maximum weight a drone can carry
        /// </summary>
        public long? MaximumWeight { get; set; }
        /// <summary>
        /// Drone name
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// List of the trips for a drone
        /// </summary>
        public List<Trip> Trips{ get; set; }        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxWeight">drone max weight</param>
        /// <param name="name">Drone name</param>
        public Drone(long? maxWeight, string? name)
        {
            MaximumWeight = maxWeight;
            Name = name;
            Trips = new List<Trip>();
        }
        /// <summary>
        /// Non-parameter constructor
        /// </summary>
        public Drone()
        {
            MaximumWeight = 0;
            Name = "";
            Trips = new List<Trip>();
        }
    }
}
