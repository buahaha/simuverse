using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuverseLib
{
    static class Randomize
    {
        static Random r = new Random();
        public static int Rand(int maxValue)
        {
            return r.Next(maxValue);
        }
    }
}
