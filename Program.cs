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
                        Console.Clear();
                        continue;
                    case 'n':
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Not a valid option please try again ");
                        break;

                }

                garage.DrawGarrage(garage);
                road.DrawRoad(road);
                



                Vehicle.DriveIn(road, veh, garage);

                foreach (var parkedV in garage.ParkedVehicles)
                {
                    if (parkedV.Value != null)
                    {
                        parkedV.Value.parkingMinutes+= 1;
                        parkedV.Value.parkingBill = parkedV.Value.parkingMinutes * garage.costPerMinute;
                    }
                }


                Console.WriteLine("The vehicle is driving in the garrage");
                Thread.Sleep(1000);
            }

            // att prioriter!! 
            // motorcykel körde iväg inte bussen vid checkout kanske ? 
            // pris ska finnas också 
            // får det inte plats så får det åka iväg kör checkout då 
            // 



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
                    Console.WriteLine("Loading vehicles....");
                    Thread.Sleep(1000);
                    
                    // print money 
                    // pris ska visas och vara 1,5 kr per minut 
                    garage.CheckOut(vehicle, road, garage);
                   // Console.WriteLine("Thank you for parking! that will be: " + vehicle.ParkingCost + "Kr");

                    break;
                case '2':
                    Console.Clear();
                    if (garage.ParkedVehicles.Count == 0)
                    {
                        Console.WriteLine("No vehicles parked yet.");
                    }

                    garage.ShowList(garage);
                    Console.WriteLine("Press any key to return to the menu ");
                    Console.ReadKey();
                    break;
                    
            }
        }
    }
}
