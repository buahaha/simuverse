using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuverseLib
{
    public class Particle : IDisposable
    {
        /// <summary>
        /// Age of particle measured in cycles.
        /// </summary>
        public ulong Age { get; private set; }

        /// <summary>
        /// Particle index number starting at 1.
        /// </summary>
        public int IndexNumber { get; private set; }

        /// <summary>
        /// Instance counter.
        /// </summary>
        private static int instances = 0;

        /// <summary>
        /// List of handles to by which new particle could be attached.
        /// </summary>
        public List<BasicHandle> BasicHandles = new List<BasicHandle>();

        /// <summary>
        /// List of handles by which the partcile is atteched
        /// to existing, not new, particles.
        /// They are used by particles to float around.
        /// </summary>
        public List<ReverseHandle> ReverseHandles = new List<ReverseHandle>();

        /// <summary>
        /// Type of particle (49 elementary particles?).
        /// </summary>
        public FundamentalType Type { get; private set; }
       
        /// <summary>
        /// Indicate when particle is able to produce another particle (0 means it's ready).
        /// Starting point is maximal index of every particle.
        /// </summary>
        private int fertility;

        /// <summary>
        /// True if particle is ready to handle another particle.
        /// </summary>
        public bool Productive {get; set;}

        /// <summary>
        /// Constructor setting all initial values.
        /// Randomly sets type.
        /// </summary>
        /// <param name="ListCount"></param>
        public Particle(FundamentalTypes Types)
        {
            Age = 0L;
            IndexNumber = ++instances;
            fertility = instances;
            Productive = false;
            Type = Types.ListOfTypes[Randomize.Rand(Types.ListOfTypes.Count)];
            AddHandles(Type);
        }

        private void AddHandles(FundamentalType type)
        {
            for (int i = 0; i < type.NumberOfBasicHandles; i++)
            {
                BasicHandles.Add(new BasicHandle());
            }
            for (int i = 0; i < type.NumberOfReverseHandles; i++)
            {
                ReverseHandles.Add(new ReverseHandle());
            }
        }

        /// <summary>
        /// Destructor. Decrements instance counter.
        /// </summary>
        ~Particle()
        {
            instances--;
        }

        /// <summary>
        /// What happens each cycle of particle life.
        /// </summary>
        /// <param name="ListCount"></param>
        public void Cycle()
        {
            Age += 1L;
            if (fertility > 0 && Productive != true)
                fertility -= 1;
            else if (fertility <= 0 && Productive == false)
            {
                Productive = true;
                fertility = instances;
            }
        }

        /// <summary>
        /// Frees memory before GC.
        /// </summary>
        public void Dispose()
        {
            BasicHandles = null;
        }
    }
}
