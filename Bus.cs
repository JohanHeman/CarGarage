using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGarage
{
    internal class Bus : Vehicle
    {

        public int Passangers { get; set; }
        

        public Bus(string plate, string collor, int passangers) : base(plate, collor)
        {

            Passangers = passangers;
            Name = "B";

        }

        public override double Size()
        {
            return 2;
        }

        public override string GetInfo(double spot)
        {
            return $"spot {spot + 1}-{spot + 2}   {Collor}   Bus   {Plate}   {Passangers}";
        }


    }
}
