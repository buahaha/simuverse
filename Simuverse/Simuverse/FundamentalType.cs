using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuverseLib
{
    public class FundamentalType
    {
        public int NumberOfBasicHandles { get; set; }
        public int NumberOfReverseHandles { get; set; }

        /// <summary>
        /// Number of maximum possible attached handles to any fundamental type
        /// </summary>
        public static int maxHandles = 6; //* 360;

        public FundamentalType()
        {
            //randomly set number of attached handles
            NumberOfBasicHandles = Randomize.Rand(maxHandles + 1);
            NumberOfReverseHandles = Randomize.Rand(maxHandles + 1);
            if (NumberOfReverseHandles == 0) NumberOfReverseHandles = 1;
        }
    }
}
