using System.Collections;

namespace CarGarage
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Road road = new Road(3, 10);
            Garrage garrage = new Garrage(3, 5);

            CreateVehicle.GenereateVehicles(road);

            foreach(var car in road.RoadVehicles)
            {
                Console.WriteLine(car);
            }

            garrage.DrawGarrage(garrage);
            road.DrawRoad(road);

            // prio nu är att fixa funktioner för att skapa random fordon 
            // placera dom på vägen 
            // och köra in fordonen i garaget och placera dom med checkin och place vehicle
        }
    }
}
