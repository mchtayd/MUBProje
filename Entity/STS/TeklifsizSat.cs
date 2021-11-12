using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.STS
{
    public class TeklifsizSat
    {
        int id; string stokno, tanim; double miktar; string birim; double tutar; string siparisno;

        public int Id { get => id; set => id = value; }
        public string Stokno { get => stokno; set => stokno = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public double Miktar { get => miktar; set => miktar = value; }
        public string Birim { get => birim; set => birim = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }
        public double Tutar { get => tutar; set => tutar = value; }

        public TeklifsizSat(int id, string stokno, string tanim, double miktar, string birim, double tutar ,string siparisno)
        {
            this.id = id;
            this.stokno = stokno;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.siparisno = siparisno;
            this.tutar = tutar;
        }

        public TeklifsizSat(string stokno, string tanim, double miktar, string birim, double tutar, string siparisno)
        {
            this.stokno = stokno;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.siparisno = siparisno;
            this.tutar = tutar;
        }

        public TeklifsizSat(string stokno, double tutar)
        {
            this.stokno = stokno;
            this.tutar = tutar;
        }
    }
}
