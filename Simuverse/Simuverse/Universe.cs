using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuverseLib
{
    public class Universe : IDisposable
    {
        /// <summary>
        /// List of all particles in universe.
        /// </summary>
        public List<Particle> Particles = new List<Particle>();

        /// <summary>
        /// Number of fundamental particles found in specific universe
        /// </summary>
        public int FundamentalParticles { get; set; }

        public FundamentalTypes ListOfTypes;

        /// <summary>
        /// Default constuctor setting fundamental types to be 49
        /// </summary>
        public Universe()
        {
            //sets number of fundamental particles found in the universe
            FundamentalParticles = 49;
            ListOfTypes = new FundamentalTypes(FundamentalParticles);
        }

        /// <summary>
        /// This method is used to add first particle(s?) to the universe.
        /// </summary>
        public void AddParticle()
        {
            Particles.Add(new Particle(ListOfTypes));
        }

        /// <summary>
        /// Decides what happens at each universe cycle.
        /// Assumes that particle can only be added to existing handle
        /// and adding to handle adds 1 to added particle handle.
        /// </summary>
        public void Cycle()
        {
            //temoprary list of particles to be added to universe
            List<Particle> temp = new List<Particle>();

            //for all aprticles currently in universe
            foreach (var particle in Particles)
            {
                //do cycle
                particle.Cycle();

                //if particle is productive add new particle to temporary list
                if (particle.Productive)
                {
                    temp.Add(new Particle(ListOfTypes));
                    particle.Productive = false;
                }
            }

            //try to randomly add particle to handles if fails forget that paricle
            foreach (var particle in temp)
            {
                int randIndex = Randomize.Rand(Particles.Count);
                foreach (var handle in Particles[randIndex].BasicHandles)
                {
                    if (handle.CanAccept())
                    {
                        handle.AcceptNew(particle);
                        Particles.Add(particle);
                        //Randomly attach new particle's ReverseHandle to old particle
                        //to which the new particle is attached
                        Particles[randIndex].ReverseHandles[
                            Randomize.Rand(
                            Particles[randIndex].ReverseHandles.Count - 1)].
                            AcceptNew(handle.Owner);
                        break;
                    }
                }
            }
        }

        public void Dispose()
        {
            Particles = null;
        }
    }
}
