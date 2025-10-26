using System.Collections;

namespace CarGarage
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Road road = new Road(3, 10);
            Garrage garrage = new Garrage(3, 5);




            garrage.DrawGarrage(garrage);
            road.DrawRoad(road);

            // prio nu är att fixa funktioner för att skapa random fordon 
            // placera dom på vägen 
            // och köra in fordonen i garaget och placera dom med checkin och place vehicle
        }
    }
}
