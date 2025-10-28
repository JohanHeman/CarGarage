using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace CarGarage
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Road road = new Road(3, 10);
            Garage garage = new Garage(3, 5);

            double spotsAvalible = garage.SizeX * garage.SizeY;

            while(spotsAvalible > 0)
            {

                Console.Clear();
                
                CreateVehicle.GenerateRandomVehicle(road);
                Vehicle veh = road.RoadVehicles.Peek();


                Console.Write("Do you want to acces the menu? y/n :");
                ConsoleKeyInfo answer = Console.ReadKey();

                switch (answer.KeyChar)
                {
                    case 'y':
                        Menu(garage, veh, road);
                        break;
                    case 'n':
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Not a valid option please try again ");
                        break;

                }

                garage.DrawGarrage(garage);
                road.DrawRoad(road);

                
                
                //garrage.CheckIn(veh, garrage);
                Vehicle.DriveIn(road, veh, garage);

                
                Console.WriteLine("The vehicle is driving in the garrage");
                Thread.Sleep(1000);
            }




            // att prioriter!! 
            // efter en checkout syns inte nästa fordon på vägen 
            // move vehicle ska funka åt båda hållen
            // driveaway()
            // motorcykel ska in 
            // får det inte plats så får det åka iväg 
            // sen kommer ett nytt och kollar 
            // check out funktionen ska kalla på diveaway 
            // kolla igenom Uppgiften pdf och skriv vad som saknas 


        }



        public static void Menu(Garage garage, Vehicle vehicle, Road road)
        {
            Console.WriteLine("----Menu----");
            Console.WriteLine("Option 1: Checkout and pay: ");
            Console.WriteLine("Option 2: Show list of vehicles: ");

            ConsoleKeyInfo answer = Console.ReadKey();

            switch (answer.KeyChar)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("Checkin out your vehicle....");
                    Thread.Sleep(1000);
                    // print money 
                    garage.CheckOut(vehicle, road, garage);
                    break;
                case '2':
                    Console.Clear();
                    //show list
                    break;
                    
            }
        }
    }
}
