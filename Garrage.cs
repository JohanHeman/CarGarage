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
        public Dictionary<double, Vehicle> ParkedVehicles { get; set; }
        public Dictionary<int, double> EmptySpots { get; set; }
        
        

        public Garrage( int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            ParkedVehicles = new Dictionary<double, Vehicle>();
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
            

                    
        }


        public void ParkCar(Vehicle car, Garrage garrage)
        {

        }

    







    }
}
