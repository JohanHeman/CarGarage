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
        }


        public override double Size()
        {
            return 0.5;
        }

    }
}
