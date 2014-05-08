using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimuverseLib;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            Universe univ = new Universe();
            univ.AddParticle();
            Console.Write("Cycle: ");
            for (long i = 0; i < 100; i++)
            {
                univ.Cycle();
                Console.Write(i + " ");
            }
            Console.WriteLine();
            foreach (var part in univ.Particles)
            {
                Console.WriteLine("\nParticle #{0}", part.IndexNumber);
                int handlez = 0;
                foreach (var handle in part.BasicHandles)
                {

                    if (handle.Attached != null)
                    {
                        handlez++;
                        Console.Write("Attached Particle:" + handle.Attached.IndexNumber + " ");
                    }
                }
                Console.WriteLine("\nAge {0}, Bound Handles {1}/{2}", 
                    part.Age, handlez, part.Type.NumberOfBasicHandles);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
