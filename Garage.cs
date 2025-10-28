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
                gar.SpotsAvalible -= vehicle.Size();
                
            
            }
            else if (vehicle is Motorcycle)
            {
                Console.Write("What brand is the motorcycle? ");
                ((Motorcycle)vehicle).Brand = Console.ReadLine();
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
                gar.SpotsAvalible -= vehicle.Size();
                
            }
            
        }


        public void CheckOut(Vehicle vehicle, Road road, Garage garage)
        {

            Console.WriteLine("What is the plate of the vehicle you want to checkout?: ");
            Console.WriteLine("Parked vehicles :");
            foreach(var v in garage.ParkedVehicles)
            {
                int i = 1;
                Console.WriteLine(i + ": " + "vehicle: " + v.Value.Name + "with plate: " + v.Value.Plate);
                i++;
            }

            string checkPlate = Console.ReadLine();

            var kvp = garage.ParkedVehicles.FirstOrDefault(v => v.Value.Plate == checkPlate);

            if(kvp.Value != null)
            {
                //Vehicle foundVehicle = kvp.Value;
                Console.WriteLine("The vehicle is driving away.. ");


                garage.ParkedVehicles.Remove(kvp.Key);
                garage.ParkedVehicles.Remove(kvp.Key + 1);

                garage.SpotsAvalible += kvp.Value.Size();

                road.RoadVehicles.Dequeue();
                road.RoadVehicles.Enqueue(kvp.Value);
                kvp.Value.DriveAway(road);
            }
            else
            {
                Console.WriteLine("No vehicle with that plate was found in the garage.");
            }
        }

        public void PrintList(Garage gar)
        {
            foreach(var kvp in gar.ParkedVehicles)
            {
                Console.WriteLine("spot "+ kvp.Key + kvp.Value.GetType().Name);
            }
        }

        public void DrawGarrage(Garage garrage)
        {

            for (int x = 0; x < garrage.SizeX; x++)
            {
                for (int y = 0; y < garrage.SizeY; y++)
                {
                    int spotNumber = x * garrage.SizeY + y;

                    if (!garrage.ParkedVehicles.ContainsKey(spotNumber))
                    {
                        Console.Write(". \t");
                    } else
                    {
                        Console.Write(garrage.ParkedVehicles[spotNumber].Name +  " " + garrage.ParkedVehicles[spotNumber].Plate + "\t");
                    }
                    
                }
                Console.WriteLine();
            }
        }

        public void PlaceVehicle(Vehicle vehicle, Garage garrage)
        {
            if (vehicle is Car)
            {
                // check for good spot to park before parking 
                garrage.ParkCar((Car)vehicle, garrage);
            }

            else if(vehicle is Bus)
            {
                garrage.Parkbus((Bus)vehicle, garrage);
            }

        }

        // logic for parking 

        // look for two empty spots : park bus there" 
        // look for allready parked motorcycle  or one empty spot: park motorcycle
        // park car at first empty spot found 


        public void ParkCar(Car car, Garage garrage)
        {

            int total = garrage.SizeY * garrage.SizeX;

            for (int spot = 0; spot <= total; spot++)
            {
                if (!garrage.ParkedVehicles.ContainsKey(spot))
                {
                    garrage.ParkedVehicles.Add(spot, car);
                    return; // stop once parked
                }
            }
        }

        public void Parkbus(Bus bus, Garage gar)
        {

            if (gar.ParkedVehicles.ContainsValue(bus)) return;

            double SpotsNeeded = bus.Size();
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
    }
}