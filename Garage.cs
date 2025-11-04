using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarGarage
{
    internal class Garage
    {

        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public Dictionary<double, Vehicle> ParkedVehicles { get; set; }

        public SortedList<double, double> EmptySpots { get; set; }
        public double SpotsAvalible { get; set; }

        public double costPerMinute = 1.5;


        public Garage(int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            ParkedVehicles = new Dictionary<double, Vehicle>();

            SpotsAvalible = sizeY * sizeX;
        }

        public void CheckIn(Vehicle vehicle, Garage gar)
        {
            int inputLine = 15;

            Console.WriteLine("Spots avalible: " + gar.SpotsAvalible);
            Console.Write("What collor is the " + vehicle.GetType().Name + " ?:");
            vehicle.Collor = Console.ReadLine();
            Console.WriteLine("What plate is on the " + vehicle.GetType().Name + " ?:");
            Console.WriteLine("Please enter in this format XXX XXX");
            vehicle.Plate = Console.ReadLine().ToUpper();
            while(vehicle.Plate.Length != 7)
            {
                Console.WriteLine("vehicle Plate must be 6 characters long.");
                Console.Write("What plate is on the " + vehicle.GetType().Name + " ?:");
                vehicle.Plate = Console.ReadLine().ToUpper();
            }

            if (vehicle is Car)
            {
                Console.WriteLine("Is the car an electric car? \n" +
                    "1: Electric\n" +
                    "2: Not Electric");
                var key = Console.ReadKey(true);

                while(key.KeyChar != '1' && key.KeyChar != '2') { 
                switch (key.KeyChar)
                {
                    case '1':
                        ((Car)vehicle).IsElectric = true;
                        break;
                    case '2':
                        ((Car)vehicle).IsElectric = false;
                        break;
                    default:
                        Console.Write("Wrong input please enter a valid answer");
                        Console.WriteLine("Not a valid option please enter '1' for electric and '2' for not");
                            key = Console.ReadKey(true);
                        break;
                    }
                }
                vehicle.Park(gar);
                

            }
            else if (vehicle is Motorcycle)
            {
                Console.Write("What brand is the motorcycle? ");
                ((Motorcycle)vehicle).Brand = Console.ReadLine();
                vehicle.Park(gar);
            }
            else if (vehicle is Bus)
            {

                Console.WriteLine("How many seats is it on the bus? ");
                bool Succes = int.TryParse(Console.ReadLine(), out int seats);

                while (!Succes)
                {
                    Console.WriteLine("Please enter a number of passangers: ");
                    Succes = int.TryParse(Console.ReadLine(), out seats);
                }

                if (Succes)
                {
                    ((Bus)vehicle).Passangers = seats;
                }
   

                vehicle.Park(gar);
                
            }
            
        }


        public void ShowList(Garage garage)
        {
            Console.WriteLine("Loading vehicles... ");
            Thread.Sleep(1000);

            Console.WriteLine("\nParked vehicles :");
            bool skipNext = false;
            foreach (var v in garage.ParkedVehicles)
            {

                if (skipNext)
                {
                    skipNext = false;
                    continue;
                }

                Console.WriteLine(v.Value.GetInfo(v.Key));

                if(v.Value is Bus)
                {
                    skipNext = true;
                }

            }
        }

        public void CheckOut(Vehicle vehicle, Road road, Garage garage)
        {

            Console.WriteLine("What is the plate of the vehicle you want to checkout?: ");
            Console.WriteLine("Parked vehicles :");
            int i = 0;
            bool skipNext = false;

            foreach (var v in garage.ParkedVehicles)
            {

                if (skipNext)
                {
                    skipNext = false;
                    continue;
                }

                Console.WriteLine(v.Value.GetInfo(v.Key));

                if (v.Value is Bus)
                {
                    skipNext = true;
                }

                i++;

            }

            string checkPlate = Console.ReadLine();

            var kvp = garage.ParkedVehicles.FirstOrDefault(v => v.Value.Plate == checkPlate.ToUpper());

            if (kvp.Value == null)
            {
                Console.WriteLine("No vehicle with that plate was found in the garage. Going Back to main menu now. ");
                Console.ReadKey();
                return;
            }

            kvp.Value.parkingBill = kvp.Value.parkingMinutes * garage.costPerMinute;

            if (kvp.Value is Bus)
            {
                Console.WriteLine("Thank you for parking! that will be: " + (kvp.Value.parkingBill / 2) + "Kr");
            }
            else
            {
                Console.WriteLine("Thank you for parking! that will be: " + kvp.Value.parkingBill + "Kr");
            }

            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("$Paying....");
            Thread.Sleep(3000);

            if (kvp.Value != null)
            {

                Console.WriteLine("The vehicle is driving away.. ");

                if (kvp.Value is Bus)
                {

                    garage.ParkedVehicles.Remove(kvp.Key);
                    garage.ParkedVehicles.Remove(kvp.Key + 1);
                }

                garage.ParkedVehicles.Remove(kvp.Key);

                garage.SpotsAvalible += kvp.Value.Size();

                road.RoadVehicles.Enqueue(kvp.Value);

                kvp.Value.DriveAway(road, garage);

            }
        }

        public void DrawGarrage(Garage garrage)
        {
            for (int x = 0; x < garrage.SizeX; x++)
            {
                for (int y = 0; y < garrage.SizeY; y++)
                {
                    int spotNumber = x * garrage.SizeY + y; // creates a unique parkingspot for each row
                    double halfSpot = spotNumber + 0.5;

                    if (garrage.ParkedVehicles.ContainsKey(spotNumber) && garrage.ParkedVehicles.ContainsKey(halfSpot))
                    {
                        var mc1 = garrage.ParkedVehicles[spotNumber];
                        var mc2 = garrage.ParkedVehicles[halfSpot];
                        Console.Write(mc1.Name + ": " + mc1.Plate + " | " + mc2.Name + ": " + mc2.Plate + "\t");

                    }
                    else if(garrage.ParkedVehicles.ContainsKey(spotNumber))
                    {
                        Console.Write(garrage.ParkedVehicles[spotNumber].Name + " " + garrage.ParkedVehicles[spotNumber].Plate + "\t");
                    }
                    else
                    {
                        Console.Write(". \t");
                    }

                }
                Console.WriteLine();
            }
        }


    }
}