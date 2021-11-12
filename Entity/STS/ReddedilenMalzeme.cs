using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class ReddedilenMalzeme
    {
        int id; string stokno, tanim; int miktar; string birim, siparisno;

        public int Id { get => id; set => id = value; }
        public string Stokno { get => stokno; set => stokno = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public string Birim { get => birim; set => birim = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }

        public ReddedilenMalzeme(int id, string stokno, string tanim, int miktar, string birim, string siparisno)
        {
            this.id = id;
            this.stokno = stokno;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.siparisno = siparisno;
        }

        public ReddedilenMalzeme(string stokno, string tanim, int miktar, string birim, string siparisno)
        {
            this.stokno = stokno;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.siparisno = siparisno;
        }
    }
}
