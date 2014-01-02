using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuverseLib
{
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
