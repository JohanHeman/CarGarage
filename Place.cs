using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGarage
{
    internal class Place
    {

        public string Name { get; set; }
        public int SizeX { get; set; }

        public int SizeY { get; set; }

        public List<Vehicle> Vehicles { get; set; }


        public Place(string name, int sizeX, int sizeY, List<Vehicle> vehicles)
        {
            Name = name;
            SizeX = sizeX;
            SizeY = sizeY;
            Vehicles = vehicles;
        }



        static void DrawPlace(Place place)
        {
            for(int x = 0; x < place.SizeX; x++)
            {
                for (int y = 0; y < place.SizeY; y++)
                {
                   if(place is garage)
                    {
                        Console.WriteLine("ParkingSpot");
                        // logic for writing out cars
                    }
                   if(place is Road)
                    {
                        Console.SetCursorPosition(5, 5);
                        Console.WriteLine("------------");
                        Console.SetCursorPosition(10, 5);
                        Console.WriteLine("-   -   -   -");
                        Console.SetCursorPosition(15, 5);
                        Console.WriteLine("------------");
                    }
                }


                Console.WriteLine();
            }

        }

    }
}
