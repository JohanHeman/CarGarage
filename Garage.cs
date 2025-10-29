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
            Console.WriteLine("What collor is the " + vehicle.GetType().Name + " ?:");
            vehicle.Collor = Console.ReadLine();
            Console.WriteLine("What plate is on the " + vehicle.GetType().Name + " ?:");
            vehicle.Plate = Console.ReadLine();

            if (vehicle is Car)
            {
                Console.WriteLine("Is the car an electric car? \n" +
                    "1: Electric\n" +
                    "2: Not Electric");
                var key = Console.ReadKey(true);

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
                        break;
                }
                
                PlaceVehicle(((Car) vehicle), gar);
            
            }
            else if (vehicle is Motorcycle)
            {
                Console.Write("What brand is the motorcycle? ");
                ((Motorcycle)vehicle).Brand = Console.ReadLine();
                PlaceVehicle(((Motorcycle)vehicle), gar);
            }
            else if (vehicle is Bus)
            {

                Console.WriteLine("How many seats is it on the bus? ");
                bool Succes = int.TryParse(Console.ReadLine(), out int seats);

                if (Succes)
                {
                    ((Bus)vehicle).Passangers = seats;
                }
                else
                {
                    Console.WriteLine("Please enter a number of passangers: ");
                }
               
                PlaceVehicle(((Bus)vehicle), gar);
                
            }
            
        }


        public void ShowList(Garage garage)
        {
            Console.WriteLine("\nParked vehicles :");
            int i = 0;
            bool skipNext = false;
            foreach (var v in garage.ParkedVehicles)
            {

                if (skipNext)
                {
                    skipNext = false;
                    continue;
                }

                i++;
                if (v.Value.Name == "C")
                {
                    Console.WriteLine(i + " :The " + v.Value.Collor + "Car " + "with plate: " + v.Value.Plate + " on spot " + v.Key);
                }
                else if (v.Value.Name == "B")
                {
                    Console.WriteLine(i + " :The " + v.Value.Collor + " Buss " + "with plate: " + v.Value.Plate + " that takes two spots " + v.Key + " and " + (v.Key + 1));
                    skipNext = true;
                }
                else
                {
                    Console.WriteLine(i + " :The " + v.Value.Collor + "Motorcycle " + "with plate: " + v.Value.Plate + " on spot " + v.Key);
                }

            }
        }

        public void CheckOut(Vehicle vehicle, Road road, Garage garage)
        {

            Console.WriteLine("What is the plate of the vehicle you want to checkout?: ");
            Console.WriteLine("Parked vehicles :");
            int i = 0;
            bool skipNext = false;

            foreach(var v in garage.ParkedVehicles)
            {

                if (skipNext)
                {
                    skipNext = false;
                    continue;
                }

                i++;
                if(v.Value.Name == "C")
                {
                    Console.WriteLine(i + " :The " + v.Value.Collor + "Car " + "with plate: " + v.Value.Plate + " on spot " + v.Key);
                } 
                else if(v.Value.Name == "B")
                {
                    Console.WriteLine(i + " :The " + v.Value.Collor + " Buss " + "with plate: " + v.Value.Plate + " that takes two spots " + v.Key + " and " + (v.Key + 1));
                    skipNext = true;
                }
                else
                {
                    Console.WriteLine(i + " :The " + v.Value.Collor + "Motorcycle " + "with plate: " + v.Value.Plate + " on spot " + v.Key);
                }
                
            }

            string checkPlate = Console.ReadLine();

            

            var kvp = garage.ParkedVehicles.FirstOrDefault(v => v.Value.Plate == checkPlate);

            kvp.Value.parkingBill = kvp.Value.parkingMinutes * garage.costPerMinute;
            Console.WriteLine("Thank you for parking! that will be: " + kvp.Value.parkingBill + "Kr");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("$Paying....");
            Thread.Sleep(3000);
            if (kvp.Value != null)
            {
                //Vehicle foundVehicle = kvp.Value;
                Console.WriteLine("The vehicle is driving away.. ");

                if(kvp.Value is Bus)
                {

                    garage.ParkedVehicles.Remove(kvp.Key);
                    garage.ParkedVehicles.Remove(kvp.Key + 1);
                }
                else 
                {
                    garage.ParkedVehicles.Remove(kvp.Key);
                }

                    garage.SpotsAvalible += kvp.Value.Size();

                road.RoadVehicles.Dequeue();
                road.RoadVehicles.Enqueue(kvp.Value);
                kvp.Value.DriveAway(road, garage);
            }
            else
            {
                Console.WriteLine("No vehicle with that plate was found in the garage.");
            }

        }

        public void DrawGarrage(Garage garrage)
        {
            for (int x = 0; x < garrage.SizeX; x++)
            {
                for (int y = 0; y < garrage.SizeY; y++)
                {
                    int spotNumber = x * garrage.SizeY + y;
                    double halfSpot = spotNumber + 0.5;

                    if (garrage.ParkedVehicles.ContainsKey(spotNumber) && garrage.ParkedVehicles.ContainsKey(halfSpot))
                    {
                        var mc1 = garrage.ParkedVehicles[spotNumber];
                        var mc2 = garrage.ParkedVehicles[halfSpot];
                        Console.Write(mc1.Name + ": " + mc1.Plate + " | " + mc2.Name + ": " + mc2.Plate);

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

        public void PlaceVehicle(Vehicle vehicle, Garage garage)
        {
            if (vehicle is Car)
            {
                // check for good spot to park before parking 
                garage.ParkCar((Car)vehicle, garage);
            }

            else if (vehicle is Bus)
            {
                garage.Parkbus((Bus)vehicle, garage);
            }
            else 
            {
                garage.ParkMotorcycle((Motorcycle)vehicle, garage);
            }

        }

        // logic for parking 

        // look for two empty spots : park bus there" 
        // look for allready parked motorcycle  or one empty spot: park motorcycle
        // park car at first empty spot found 


        public void ParkCar(Car car, Garage gar)
        {

            int total = gar.SizeY * gar.SizeX;

            for (int spot = 0; spot <= total; spot++)
            {
                if (!gar.ParkedVehicles.ContainsKey(spot))
                {
                    gar.ParkedVehicles.Add(spot, car);
                    gar.SpotsAvalible -= car.Size();
                    return; // stop once parked
                }
            }
        }

        public void Parkbus(Bus bus, Garage gar)
        {

            if (gar.ParkedVehicles.ContainsValue(bus)) return;

            int total = gar.SizeY * gar.SizeX;

            bool parked = false;

            for (int i = 0; i < total - 1; i++)
            {

                if (!gar.ParkedVehicles.ContainsKey(i) && !gar.ParkedVehicles.ContainsKey(i + 1))
                {
                    if(i == gar.SizeY - 1) {
                        continue;
                    }
                    else
                    {
                        gar.ParkedVehicles.Add((i), bus);
                        gar.ParkedVehicles.Add((i + 1), bus);
                        gar.SpotsAvalible -= bus.Size();
                        parked = true;
                        return;
                    }

                }
            }
            if (!parked)
            {
                Console.WriteLine("No spots left for the bus! ");
            }
        }


        public void ParkMotorcycle(Motorcycle motorcycle, Garage gar)
        {
            int total = gar.SizeY * gar.SizeX;

            for (int i = 0; i < total; i++)
            {
                double firstHalf = i;
                double secondHalf = i + 0.5;

                if (!gar.ParkedVehicles.ContainsKey(firstHalf))
                {
                    gar.ParkedVehicles.Add(firstHalf, motorcycle);
                    gar.SpotsAvalible -= motorcycle.Size();
                    return;

                }

                if (gar.ParkedVehicles[firstHalf] is Motorcycle)
                {
                    if (!gar.ParkedVehicles.ContainsKey(secondHalf))
                    {
                        gar.ParkedVehicles.Add(secondHalf, motorcycle);
                        gar.SpotsAvalible -= motorcycle.Size();
                        return;
                    }
                }

            }

            Console.WriteLine("No spots left for the mc!");

        }

    }
}