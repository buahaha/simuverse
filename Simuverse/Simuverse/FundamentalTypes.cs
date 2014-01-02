using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuverseLib
{
    public class FundamentalTypes : IDisposable 
    {
        public List<FundamentalType> ListOfTypes = new List<FundamentalType>();

        public FundamentalTypes(int howManyFundamentalParticles)
        {
            for (int i = 0; i < howManyFundamentalParticles; i++)
            {
                ListOfTypes.Add(new FundamentalType());
            }
        }

        /// <summary>
        /// Frees memory before GC.
        /// </summary>
        public void Dispose()
        {
            ListOfTypes = null;
        }
    }
}
