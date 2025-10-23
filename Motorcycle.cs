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


        public Motorcycle(string plate, string collor, string brand) : base(plate, collor)
        {
            Brand = brand;
        }


    }
}
