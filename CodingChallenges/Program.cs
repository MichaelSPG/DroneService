using System.Collections.Generic;


namespace DroneServices
{
    public class Program
    {       
        /// <summary>
        /// Application's entry point
        /// </summary>
        /// <param name="args">the file path</param>
        public static void Main(string[] args)
        {
            // check at least 1 parameter
            if (args.Length < 1)
            {
                Console.WriteLine("No arguments...Press enter to exit");
                Console.Read();
                return;
            }
            // Starts the 'service'
            new DroneDeliveryService().Start(args[0]);
        }        
    }
}