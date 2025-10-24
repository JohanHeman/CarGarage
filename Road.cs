using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGarage
{
    internal class Road : Garrage
    {

        public Queue<Vehicle> RoadVehicles { get; set; }


        public Road(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            RoadVehicles = new Queue<Vehicle>();
        }

    }
}
