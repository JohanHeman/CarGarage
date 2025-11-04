using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGarage
{
    internal class Motorcycle : Vehicle
    {

        public string Brand { get; set; }

        public bool IsParked { get; set; } = false;


        public Motorcycle(string plate, string collor, string brand) : base(plate, collor)
        {
            Brand = brand;
            Name = "M";
        }


        public override double Size()
        {
            return 0.5;
        }

        public override string GetInfo(double spot)
        {
            return $"spot {spot + 1}   {Collor}   Motorcycle   {Plate}   {Brand}";
        }


        public override void Park(Garage gar)
        {
            int total = gar.SizeY * gar.SizeX;

            for (int i = 0; i < total; i++)
            {
                double firstHalf = i;
                double secondHalf = i + 0.5;

                if (!gar.ParkedVehicles.ContainsKey(firstHalf))
                {
                    gar.ParkedVehicles.Add(firstHalf, this);
                    gar.SpotsAvalible -= this.Size();
                    return;

                }

                if (gar.ParkedVehicles[firstHalf] is Motorcycle)
                {
                    if (!gar.ParkedVehicles.ContainsKey(secondHalf))
                    {
                        gar.ParkedVehicles.Add(secondHalf, this);
                        gar.SpotsAvalible -= this.Size();
                        return;
                    }
                }

            }

            Console.WriteLine("No spots left for the mc!");
        }

    }
}
