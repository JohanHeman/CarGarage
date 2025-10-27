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

    }
}
