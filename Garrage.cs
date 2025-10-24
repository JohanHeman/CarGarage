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
        public List<Vehicle> ParkedVehicles { get; set; }

        public Garrage( int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            ParkedVehicles = new List<Vehicle>();
        }

        public void CheckIn(Vehicle vehicle)
        {

            // input collor and unique property 

            Console.WriteLine("What collor is the vehicle? ");
            vehicle.Collor = Console.ReadLine();
            Console.Clear();
            if(vehicle is Car car)
            {
                Console.WriteLine("Is the car an electric car? \n" +
                    "1: Electric\n" +
                    "2: Not Electric");
                var key = Console.ReadKey(true);

                switch (key.KeyChar)
                {
                    case '1':
                        car.IsElectric = true;
                        break;
                    case '2':
                        car.IsElectric = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input please enter a valid answer");
                        break;
                }
            }
            else if(vehicle is Motorcycle motorcycle)
            {
                Console.WriteLine("What brand is the motorcycle? ");
                motorcycle.Brand = Console.ReadLine();
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




    }
}
