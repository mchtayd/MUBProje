using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Depo
{
    public class DestekDepoKirtasiye
    {
        int id;string stokno, tanim, birim;

        public int Id { get => id; set => id = value; }
        public string Stokno { get => stokno; set => stokno = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string Birim { get => birim; set => birim = value; }

        public DestekDepoKirtasiye(int id, string stokno, string tanim, string birim)
        {
            this.id = id;
            this.stokno = stokno;
            this.tanim = tanim;
            this.birim = birim;
        }

        public DestekDepoKirtasiye(string stokno, string tanim, string birim)
        {
            this.stokno = stokno;
            this.tanim = tanim;
            this.birim = birim;
        }
    }
}
