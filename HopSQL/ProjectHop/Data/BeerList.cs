using Mods;
using System.Collections.Generic;
namespace Data
{
    public class BeerList
    {
        private static List<Beer> beers = new List<Beer>();



        public static void Add(Beer beer)
        {
            beers.Add(beer);
        }

        public static List<Beer> GetBeers()
        {
            return beers;
        }

        


    }
}