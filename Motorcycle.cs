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


    }
}
