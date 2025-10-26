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

            // jag är på dictionarry grejen 
            // frsök förstå hur du ska lägga till keys som deras parkeringsplats till det vehicle som parkerar


        }
    }
}
