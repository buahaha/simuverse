using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuverseLib
{
    /// <summary>
    /// This handle stays forever the same as it is created,
    /// it's main purpose is to indicate which newer particles
    /// were attached to older particle.
    /// </summary>
    public class BasicHandle
    {
        public Particle Owner { get; set; }
        public Particle Attached { get; set; }

        public virtual bool CanAccept()
        {
            if (Attached == null)
                return true;
            else
                return false;
        }

        public virtual void AcceptNew(Particle particle)
        {
            if (CanAccept())
                Attached = particle;
        }
    }
}
