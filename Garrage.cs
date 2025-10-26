using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarGarage
{
    internal class Garrage
    {

        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public Dictionary<Double, List<Vehicle>> ParkedVehicles { get; set; }
        public List<Vehicle> ParkedVheicles { get; set; }

        

        public Garrage( int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            ParkedVehicles = new Dictionary<double, List<Vehicle>>();
        }

        public void CheckIn(Vehicle vehicle)
        {

            // input collor and unique property 

            Console.WriteLine("What collor is the vehicle? ");
            vehicle.Collor = Console.ReadLine();
            Console.Clear();
            if(vehicle is Car)
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
                        Console.WriteLine("Wrong input please enter a valid answer");
                        break;
                }
            }
            else if(vehicle is Motorcycle)
            {
                Console.WriteLine("What brand is the motorcycle? ");
                ((Motorcycle)vehicle).Brand = Console.ReadLine();
            }
            else if(vehicle is Buss)
            {
                Console.WriteLine("How many seats is it on the buss? ");
                bool Succes = int.TryParse(Console.ReadLine(), out int seats);

                if (Succes)
                {
                    ((Buss)vehicle).Passangers = seats;
                } else
                {
                    Console.WriteLine("Please enter a number of passangers: ");
                }
            }
        }


        public void DrawGarrage(Garrage garrage)
        {
            int[,] draw = new int[garrage.SizeX, garrage.SizeY];

            for(int x = 0; x < garrage.SizeX; x++)
            {
                for(int y = 0; y < garrage.SizeY; y++)
                {
                    
                }
                Console.WriteLine();
            }

        }


        public void PlaceVehicle(Vehicle vehicle, Garrage garrage)
        {
            double sizeOfParking = 0;

            double avalibleSpots = (garrage.SizeX * garrage.SizeY) - garrage.ParkedVehicles.Count(); // should calculate avalible spots

            

            if(vehicle is Car)
            {
                sizeOfParking = 1;
                garrage.ParkedVehicles.Add(1, vehicle); // hitta ett sätt att skapa nyckel på ett bra sätt 
               
                
            }

            else if(vehicle is Motorcycle)
            {
                sizeOfParking = 0.5;
                garrage.ParkedVehicles.Add(0.5, vehicle);
            }

            else if( vehicle is Buss)
            {
                sizeOfParking = 2;

                garrage.ParkedVehicles.Add(2, vehicle);
            }




        }

    







    }
}
