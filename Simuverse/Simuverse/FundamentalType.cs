using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuverseLib
{
    public class FundamentalType
    {
        public int NumberOfAttachedHandles { get; set; }

        /// <summary>
        /// Number of maximum possible attached handles to any fundamental type
        /// </summary>
        public static int maxHandles = 6; //* 360;

        public FundamentalType()
        {
            //randomly set number of attached handles
            NumberOfAttachedHandles = Randomize.Rand(maxHandles + 1);
        }
    }
}
