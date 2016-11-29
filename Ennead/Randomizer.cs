using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Troschuetz.Random;

namespace Ennead
{
    public class Randomizer
    {
        private TRandom tRandom;

        public static Randomizer Instance = new Randomizer();

        private Randomizer()
        {
            tRandom = new TRandom();
        }
        
        public T Choose<T>(IEnumerable<T> items)
        {
            return tRandom.Choice(items.ToList());
        }
    }
}
