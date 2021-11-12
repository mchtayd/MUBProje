using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class DvNo
    {
        int dvNoGoster;

        public int DvNoGoster { get => dvNoGoster; set => dvNoGoster = value; }

        public DvNo(int dvNoGoster)
        {
            this.dvNoGoster = dvNoGoster;
        }
    }
}
