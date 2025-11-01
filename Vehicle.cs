using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGarage
{
    internal class Vehicle
    {

        public string Plate { get; set; }
        public string Collor { get; set; }

        public string Name { get; set; }

        public int PosX { get; set; }
        public int PosY { get; set; }

        public double parkingBill { get; set; } = 0;

        public double parkingMinutes { get; set; } = 0;

        

        public Vehicle(string plate, string collor)
        {
            Plate = plate;
            Collor = collor;
            PosX = -1;
            PosY = -1;
        }

        public virtual double Size()
        {
            return 0;
        }

        public void DriveAway(Road road, Garage garage)
        {
            
            while(road.RoadVehicles.Count > 0)
            {
                var vehicle = road.RoadVehicles.Peek();

                if (vehicle.PosY >= road.SizeY - 1)
                {
                    road.RoadVehicles.Dequeue();
                    continue;
                }

                while (vehicle.PosY < road.SizeY - 1)
                {
                    vehicle.PosY++;
                    Console.SetCursorPosition(0, 10);
                    road.DrawRoad(road);
                    Thread.Sleep(100);

                    if(vehicle.PosY >= road.SizeY - 1)
                    {
                        road.RoadVehicles.Dequeue();
                        
                        break;
                    }
                }
            }

        }

        public static void DriveIn(Road road, Vehicle veh, Garage gar)
        {
            
            while(veh.PosY > 0)
            {
                veh.PosY--;
                Console.SetCursorPosition(0, 10);
                road.DrawRoad(road);
                Thread.Sleep(100);
            

            if(veh.PosY == 0)
            {
                gar.CheckIn(veh, gar);
                road.RoadVehicles.Dequeue();
                break;

            }
            }

        }

        public virtual string GetInfo(double spot)
        {
            return $"spot {spot + 1} {Collor} vehicle {Plate}";
        }



    }


}