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


        public virtual void AddVehicleToRoad(Car car)
        {
            RoadVehicles.Enqueue(car);
        }


        public void DrawRoad(Road road)
        {
            int[,] draw = new int[road.SizeX, road.SizeY];

            Console.SetCursorPosition(0, 5);

            for (int x = 0; x < road.SizeX; x++)
            {
                for (int y = 0; y < road.SizeY; y++)
                {
                    if(x % 2 == 0)
                    {
                        Console.Write("---");
                    } else
                    {
                        Console.Write("-  ");
                    }

                }
                Console.WriteLine();
            }

        }
    }
}
