using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class StokNoTanim
    {
        int id; string stokno, tanim;

        public int Id { get => id; set => id = value; }
        public string Stokno { get => stokno; set => stokno = value; }
        public string Tanim { get => tanim; set => tanim = value; }

        public StokNoTanim(int id, string stokno, string tanim)
        {
            this.id = id;
            this.stokno = stokno;
            this.tanim = tanim;
        }

        public StokNoTanim(string stokno, string tanim)
        {
            this.stokno = stokno;
            this.tanim = tanim;
        }
    }
}
