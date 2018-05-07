using cardgame_war;
using System;
using System.Collections.Generic;
using System.Linq;

namespace core
{
    public static class Shuffler
    {
        public static void Shuffle(IList<ICard> c)
        {
            foreach (int index in Enumerable.Range(1, 5))
            { 
                int n = c.Count;
                Random rnd = new Random();
                while (n > 1)
                {
                    int k = (rnd.Next(0, n) % n);
                    n--;
                    ICard value = c[k];
                    c[k] = c[n];
                    c[n] = value;
                }
            }
        }
    }
}
