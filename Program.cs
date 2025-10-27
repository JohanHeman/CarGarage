using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace CarGarage
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Road road = new Road(3, 10);
            Garrage garrage = new Garrage(3, 5);

            double spotsAvalible = garrage.SizeX * garrage.SizeY;

            while(spotsAvalible > 0)
            {
                Console.Clear();
                
                CreateVehicle.GenerateRandomVehicle(road);
                Vehicle veh = road.RoadVehicles.Peek();

                garrage.DrawGarrage(garrage);
                road.DrawRoad(road);

                
                
                //garrage.CheckIn(veh, garrage);
                Vehicle.DriveIn(road, veh, garrage);

                
                Console.WriteLine("The vehicle is driving in the garrage");
                Thread.Sleep(1000);
            }



 
            // får det inte plats så får det åka iväg 
            // sen kommer ett nytt och kollar 
            // fixa utskrift av road 


        }
    }
}
