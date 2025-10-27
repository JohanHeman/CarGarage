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

            Vehicle veh = road.RoadVehicles.Dequeue();
            garrage.CheckIn(veh, garrage);
            veh = road.RoadVehicles.Dequeue();
            garrage.CheckIn(veh, garrage);


            garrage.PlaceVehicle(veh, garrage);

            garrage.DrawGarrage(garrage);
            road.DrawRoad(road);


            // Prio är att fixa buss

            

        }
    }
}
