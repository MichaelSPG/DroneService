# DroneService
Challenge-Drone delievering service project
developed by Michael Patino - michael.mspg@gmail.com
 Application's algorythm:

    Check input
        ->Read Drones data
        ->Read Locations Data
    Compute Drone trips 
        if(DroneCurrentLoad + LocationWeight <= DroneMaxWeight)
             -Add location to current trip
             -remove location from pendind assignation list
        Check if there are pending locations to be assigend to a trip, if yes call again 'Compute drone trips'
    Print drones and their trips with locations
 


IMPORTANT!!: To compile use Microsoft Visual Studio with .Net 6, to run in an environment with no VS2022 install .Net 6 runtime on https://dotnet.microsoft.com/en-us/download/dotnet/6.0

 ####################################################################################################################################################################################
 The intention is create a legit and more readable code separating each class and create it according to the project requirements,
 by first reading the input file and processing it to read  dorne data and location data, after that iterate the drones in order 
 to check the locations available to be assigned to a drone's trip after add the trip to a dron and the print the final result
 -- Drone.cs
 -- InputReader.cs
 -- Location.cs
 -- Trip.cs
 -- Program.cs
 -- DroneDeliveryService.cs
 ####################################################################################################################################################################################