using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGarage
{
    internal class Vehicle
    {

        public string Plate { get; set; }
        public string Collor { get; set; }

        public Vehicle(string plate, string collor)
        {
            Plate = plate;
            Collor = collor;
        }

        public virtual double Size()
        {
            return 0;

        }


    }




}
