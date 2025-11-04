using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGarage
{
    internal class Road
    {

        public Queue<Vehicle> RoadVehicles { get; set; }

        public int SizeX { get; set; }
        public int SizeY { get; set; }


        public Road(int sizeX, int sizeY)
        {
            RoadVehicles = new Queue<Vehicle>();
            SizeX = sizeX;
            SizeY = sizeY;
        }


        public virtual void AddVehicleToRoad(Car car)
        {
            RoadVehicles.Enqueue(car);
        }

        public void DrawRoad(Road road)
        {
            int[,] draw = new int[road.SizeX, road.SizeY];

            Console.SetCursorPosition(0, 10);

            for (int x = 0; x < road.SizeX; x++)
            {

                for (int y = 0; y < road.SizeY; y++)
                {

                    bool vehiclePos = false;


                    foreach(var vehicle in road.RoadVehicles)
                    {
                        if(vehicle.PosX == x && vehicle.PosY == y)
                        {
                            Console.Write(vehicle.Name.PadRight(3));
                            vehiclePos = true;
                            break;
                        }
                    }

                    if (!vehiclePos) { 

                        if (x % 2 == 0)
                        {
                            Console.Write("---");

                        }
                        else
                        {
                            Console.Write("-  ");
                        }
                    }
                }
              
                Console.WriteLine();
            }
        }
   
    }
}
