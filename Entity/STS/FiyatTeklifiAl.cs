using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class FiyatTeklifiAl
    {
        int id; string stokno, tanim; int miktar; string birim, firma1; double bbf, btf; string firma2; double ibf, itf; string firma3; double ubf, utf; string siparisno, teklifdurumu;
        int onaylananteklif;

        public int Id { get => id; set => id = value; }
        public string Stokno { get => stokno; set => stokno = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public string Birim { get => birim; set => birim = value; }
        public string Firma1 { get => firma1; set => firma1 = value; }
        public string Firma2 { get => firma2; set => firma2 = value; }
        public string Firma3 { get => firma3; set => firma3 = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }
        public string Teklifdurumu { get => teklifdurumu; set => teklifdurumu = value; }
        public double Bbf { get => bbf; set => bbf = value; }
        public double Btf { get => btf; set => btf = value; }
        public double Ibf { get => ibf; set => ibf = value; }
        public double Itf { get => itf; set => itf = value; }
        public double Ubf { get => ubf; set => ubf = value; }
        public double Utf { get => utf; set => utf = value; }
        public int Onaylananteklif { get => onaylananteklif; set => onaylananteklif = value; }

        public FiyatTeklifiAl(int id, string stokno, string tanim, int miktar, string birim, string ffirma1, double bbf, double btf, string firma2, double ibf, double itf, string firma3, double ubf, double utf, string siparisno, string teklifdurumu, int onaylananteklif)
        {
            this.id = id;
            this.stokno = stokno;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.firma1 = ffirma1;
            this.firma2 = firma2;
            this.firma3 = firma3;
            this.siparisno = siparisno;
            this.teklifdurumu = teklifdurumu;
            this.bbf = bbf;
            this.ibf = ibf;
            this.ubf = ubf;
            this.btf = btf;
            this.itf = itf;
            this.utf = utf;
            this.onaylananteklif = onaylananteklif;
        }

        public FiyatTeklifiAl(string stokno, string tanim, int miktar, string birim, string firma1, string firma2, string firma3, string siparisno)
        {
            this.stokno = stokno;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.firma1 = firma1;
            this.firma2 = firma2;
            this.firma3 = firma3;
            this.siparisno = siparisno;
        }

        public FiyatTeklifiAl()
        {
        }

        public FiyatTeklifiAl(int id, string stokno, string tanim, int miktar, string birim, string firma1, string firma2, string firma3)
        {
            this.id = id;
            this.stokno = stokno;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.firma1 = firma1;
            this.firma2 = firma2;
            this.firma3 = firma3;
        }

        public FiyatTeklifiAl(int id, string stokno, string tanim, int miktar, string birim, string firma1, double bbf, double btf)
        {
            this.id = id;
            this.stokno = stokno;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.firma1 = firma1;
            this.bbf = bbf;
            this.btf = btf;
        }
    }
}
