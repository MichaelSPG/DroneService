using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DroneServices
{
    internal class InputReader
    {
        /// <summary>
        /// Reads the drones data and creates the list with the objects
        /// </summary>
        /// <param name="line"> string containing the drones data</param>
        /// <returns>the drone object list</returns>
        public static List<Drone> ReadDrones(string line)
        {
            List<Drone> drones = new List<Drone>();
            List<string> lineParameters = new List<string>();
            if(string.IsNullOrEmpty(line))
            {
                return new List<Drone>();
            }
            if (line.Contains(","))
                lineParameters = line.Split(',').ToList();
            for (int i = 0; i < lineParameters.Count; i+=2)
            {
                drones.Add(new Drone(ReadValue(lineParameters[i+1]), lineParameters[i].Trim()));
            }
            return drones;
        }
        /// <summary>
        /// Reads a location with suplied data
        /// </summary>
        /// <param name="line"> string containing the location data</param>
        /// <returns>the location object</returns>
        public static Location ReadLocations(string line)
        {
            List<string> lineParameters = new List<string>();
            if (string.IsNullOrEmpty(line))
            {
                return null;
            }
            if (line.Contains(","))
                lineParameters = line.Split(',').ToList();
            return new Location(lineParameters[0].Trim(), ReadValue(lineParameters[1]));
            
        }
        /// <summary>
        /// Extracts a portion of string from other string i.e "[name]" -> "name"
        /// </summary>
        /// <param name="value">the value to extract from</param>
        /// <returns></returns>
        public static long ReadValue(string value)
        {
            string regex = "\\[(.*?)\\]";
            var match = Regex.Matches(value, regex);
            return long.Parse(match[0].Groups[1].Value);
        }
    }
}
