using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class TamamlananMalzeme
    {
        int id; string stokno, tanim; int miktar; string birim, firma; double birimfiyat, toplamfiyat; string siparisno;

        public int Id { get => id; set => id = value; }
        public string Stokno { get => stokno; set => stokno = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public string Birim { get => birim; set => birim = value; }
        public string Firma { get => firma; set => firma = value; }
        public double Birimfiyat { get => birimfiyat; set => birimfiyat = value; }
        public double Toplamfiyat { get => toplamfiyat; set => toplamfiyat = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }

        public TamamlananMalzeme(int id, string stokno, string tanim, int miktar, string birim, string firma, double birimfiyat, double toplamfiyat, string siparisno)
        {
            this.id = id;
            this.stokno = stokno;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.firma = firma;
            this.birimfiyat = birimfiyat;
            this.toplamfiyat = toplamfiyat;
            this.siparisno = siparisno;
        }

        public TamamlananMalzeme(string stokno, string tanim, int miktar, string birim, string firma, double birimfiyat, double toplamfiyat, string siparisno)
        {
            this.stokno = stokno;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.firma = firma;
            this.birimfiyat = birimfiyat;
            this.toplamfiyat = toplamfiyat;
            this.siparisno = siparisno;
        }

        /*public TamamlananMalzeme(string stokno, double birimfiyat, double toplamfiyat, string siparisno)
        {
            this.stokno = stokno;
            this.birimfiyat = birimfiyat;
            this.toplamfiyat = toplamfiyat;
            this.siparisno = siparisno;
        }*/
    }
}
