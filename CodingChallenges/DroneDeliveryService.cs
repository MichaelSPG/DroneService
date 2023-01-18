using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneServices
{
    internal class DroneDeliveryService
    {
        const int MAX_DRONES_IN_SQUAD = 100;
        /// <summary>
        /// Starts the 'drone delivery service' by reading the input file and processing all the content
        /// </summary>
        /// <param name="filePath">path of the input file</param>
        public void Start(string filePath)
        {
            List<Location> Locations = new List<Location>();
            List<Drone> Drones = new List<Drone>();
            try
            {
                #region LOADING_DATA
                bool readDrones = false;
                //Read the file with the given path 
                foreach (string line in System.IO.File.ReadLines(filePath))
                {
                    // first line is the drones data
                    if (!readDrones)
                    {
                        Drones = InputReader.ReadDrones(line).Take(MAX_DRONES_IN_SQUAD).ToList();
                        readDrones = true;
                    }
                    // Rest of lines are locations
                    else
                    {
                        Locations.Add(InputReader.ReadLocations(line));
                    }
                }
                #endregion
                // Compute each drone trip until location list is empty
                ComputeDronesTrips(Drones, Locations);
                foreach (var drone in Drones)
                {
                    Console.WriteLine(drone.Name);
                    drone.Trips.ForEach(trip => { Console.WriteLine($"Trip #{drone.Trips.IndexOf(trip) + 1}"); Console.WriteLine(string.Join(", ", trip.Locations.Select(x => x.Name))); });
                    Console.WriteLine();
                }
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: '{ex.Message}'");
            }
        }
        /// <summary>
        /// Computes all the drones trips
        /// </summary>
        /// <param name="drones">drones list</param>
        /// <param name="locations">locations list</param>
        static void ComputeDronesTrips(List<Drone> drones, List<Location> locations)
        {
            drones.OrderBy(x => x.MaximumWeight).ToList().ForEach(drone =>
            {
                var trip = ComputeTripForDrone(drone, ref locations);
                if (trip != null && trip.Locations.Count > 0)
                {
                    trip.Locations = trip.Locations.OrderBy(x => x.Name).ToList();
                    drone.Trips.Add(trip);
                }
            });
            if (locations.Count > 0)
            {
                ComputeDronesTrips(drones, locations);
            }
        }
        /// <summary>
        /// Computes the drone trip with adding locations by checking the drone maximum weight
        /// </summary>
        /// <param name="drone">the dron for computing a trip</param>
        /// <param name="locations">the current list of pending locations to be assigned</param>
        /// <returns></returns>
        static Trip ComputeTripForDrone(Drone drone, ref List<Location> locations)
        {
            Trip trip = new Trip();
            locations = locations.OrderBy(x => x.PackageWeight).ToList();
            int idx = 0;
            long? currentLoad = 0;
            while (idx < locations.Count)
            {
                // Check if we can add a package to the current drone load
                if (currentLoad + locations[idx].PackageWeight <= drone.MaximumWeight)
                {
                    #region Add location to a trip
                    currentLoad += locations[idx].PackageWeight;
                    trip.Locations.Add(locations[idx]);
                    trip.TripWeight = currentLoad;
                    // remove the location from pending list
                    locations.Remove(locations[idx]);
                    #endregion
                }
                idx++;
            }
            return trip;
        }
    }
}
