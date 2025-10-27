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

            CreateVehicle.GenereateVehicles(road);

            double spotsAvalible = garrage.SizeX * garrage.SizeY;


            while(spotsAvalible > 0)
            {

                garrage.DrawGarrage(garrage);
                road.DrawRoad(road);

                Vehicle veh = road.RoadVehicles.Dequeue();
                garrage.CheckIn(veh, garrage);
                Console.Clear();
                Console.WriteLine("The vehicle is driving in the garrage");
                Thread.Sleep(1000);
            }





            //static void SpotCheck(Garrage gar, Vehicle veh)
            //{
            //    double spotsAvalible = gar.ParkedVehicles.Count;

            //    if(veh is Car)
            //    {
            //        spotsAvalible--;
            //    } 
            //    else if(veh is Bus)
            //    {
            //        spotsAvalible -= ((Bus)veh).Size();
            //    }
            //    else
            //    {
            //        spotsAvalible -= ((Motorcycle)veh).Size();
            //    }

            //}


            //garrage.DrawGarrage(garrage);
            //road.DrawRoad(road);

            //Vehicle veh = road.RoadVehicles.Dequeue();
            //garrage.CheckIn(veh, garrage);
            //Console.Clear();
            //Console.WriteLine("The vehicle is driving in the garrage");
            //Thread.Sleep(1000);
            //garrage.DrawGarrage(garrage);
            //road.DrawRoad(road);

            //veh = road.RoadVehicles.Dequeue();
            //garrage.CheckIn(veh, garrage);
            //Console.WriteLine("The vehicle is driving in the garrage");
            //Thread.Sleep(1000);
            //Console.Clear();
            //garrage.DrawGarrage(garrage);
            //road.DrawRoad(road);
            

            //veh = road.RoadVehicles.Dequeue();
            //garrage.CheckIn(veh, garrage);
            //Console.WriteLine("The vehicle is driving in the garrage");
            //Thread.Sleep(1000);
            //Console.Clear();
            //garrage.DrawGarrage(garrage);
            //road.DrawRoad(road);

            //veh = road.RoadVehicles.Dequeue();
            //garrage.CheckIn(veh, garrage);
            //Console.WriteLine("The vehicle is driving in the garrage");
            //Thread.Sleep(1000);
            //Console.Clear();
            //garrage.DrawGarrage(garrage);
            //road.DrawRoad(road);



        }
    }
}
