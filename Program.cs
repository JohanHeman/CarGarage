using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace CarGarage
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Road road = new Road(3, 10);
            Garage garage = new Garage(3, 5);

            double spotsAvalible = garage.SizeX * garage.SizeY;

            while(spotsAvalible > 0)
            {
                Console.Clear();
                
                CreateVehicle.GenerateRandomVehicle(road);
                Vehicle veh = road.RoadVehicles.Peek();

                garage.DrawGarrage(garage);
                road.DrawRoad(road);

                
                
                //garrage.CheckIn(veh, garrage);
                Vehicle.DriveIn(road, veh, garage);

                
                Console.WriteLine("The vehicle is driving in the garrage");
                Thread.Sleep(1000);
            }




            // att prioriter!! 
            // kolla checkput metoden
            // move vehicle ska funka åt båda hållen
            // driveaway()
            // motorcykel ska in 
            // får det inte plats så får det åka iväg 
            // sen kommer ett nytt och kollar 
            // check out funktionen ska kalla på diveaway 
            // kolla igenom Uppgiften pdf och skriv vad som saknas 


        }
    }
}
