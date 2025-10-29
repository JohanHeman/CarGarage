using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGarage
{
    internal class CreateVehicle
    {


        


        public static void GenerateRandomVehicle(Road road)
        {

            Random rnd = new Random();
            Vehicle vehicle = new Vehicle("unknopwn", "unknown");
           
            int num = rnd.Next(3, 4);

            switch (num)
            {
                case 1:
                    vehicle = new Car("unknown", "unknown", false);
                    break;
                case 2:
                    vehicle = new Bus("unknown", "unknown", 0);
                    break;
                case 3:
                    vehicle = new Motorcycle("unknown", "unknown", "unknown");
                    break;
                default:
                    vehicle = new Vehicle("unknown", "unknown");
                    break;
            }
            vehicle.PosX = 1;
            vehicle.PosY = 9;
            road.RoadVehicles.Enqueue(vehicle);
        }

    }
}
