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

            

            garrage.DrawGarrage(garrage);
            road.DrawRoad(road);

            // placera vehicles
        }
    }
}
