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

        public override void Park(Garage gar)
        {

            if (gar.ParkedVehicles.ContainsValue(this)) return;

            int total = gar.SizeY * gar.SizeX;

            bool parked = false;

            for (int i = 0; i < total - 1; i++)
            {

                if (!gar.ParkedVehicles.ContainsKey(i) && !gar.ParkedVehicles.ContainsKey(i + 1))
                {
                    if (i == gar.SizeY - 1)
                    {
                        continue;
                    }
                    else
                    {
                        gar.ParkedVehicles.Add((i), this);
                        gar.ParkedVehicles.Add((i + 1), this);
                        gar.SpotsAvalible -= this.Size();
                        parked = true;
                        return;
                    }

                }
            }
            if (!parked)
            {
                Console.WriteLine("No spots left for the bus! ");
            }
        }


    }
}
