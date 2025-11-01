using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGarage
{
    internal class Car : Vehicle
    {

        public bool IsElectric { get; set; }
        

        public Car(string plate, string collor, bool isElectric) : base(plate, collor)
        {
            isElectric = isElectric;
            Name = "C";
        }

        public override double Size()
        {
            return 1;

        }

        public override string GetInfo(double spot)
        {
            string electricOrNot = IsElectric ? "Electric" : "Not electric";

            return $"spot {spot + 1}   {Collor}   Car   {Plate}   {electricOrNot}";
        }

    }


}
