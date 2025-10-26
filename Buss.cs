using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGarage
{
    internal class Buss : Vehicle
    {

        public int Passangers { get; set; }

        public Buss(string plate, string collor, int passangers) : base(plate, collor)
        {

            Passangers = passangers;

        }

        public override double Size()
        {
            return 2;
        }

    }
}
