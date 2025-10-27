using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGarage
{
    internal class CreateVehicle
    {


        


        public static Vehicle RandomVehicle()
        {

            Random rnd = new Random();
            Vehicle unknown = new(null, null);


           
            int num = rnd.Next(1, 3);


            switch (num)
            {
                case 1:
                    return new Car("unknown", "unknown", false);
                    break;
                case 2:
                    return new Bus("unknown", "unknown", 0);
                    break;
                //case 3:
                //    return new Motorcycle("unknown", "unknown", "unknown");
                //    break;
                default:
                    return new Vehicle("unknown", "unknown");
                
            
            }
        }

        public static void GenereateVehicles(Road road)
        {
            for(int i = 0; i < 15; i++)
            {
                road.RoadVehicles.Enqueue(RandomVehicle());
            }
        }

    }
}
