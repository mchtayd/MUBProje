using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class TeklifiAlinanReddedilen
    {
        string stokNo, tanim; int miktar; string birim; double bbf, btf; string firma1; double ibf, itf; string firma2; double ubf, utf; string firma3, siparisno;

        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public string Birim { get => birim; set => birim = value; }
        public double Bbf { get => bbf; set => bbf = value; }
        public double Btf { get => btf; set => btf = value; }
        public string Firma1 { get => firma1; set => firma1 = value; }
        public double Ibf { get => ibf; set => ibf = value; }
        public double Itf { get => itf; set => itf = value; }
        public string Firma2 { get => firma2; set => firma2 = value; }
        public double Ubf { get => ubf; set => ubf = value; }
        public double Utf { get => utf; set => utf = value; }
        public string Firma3 { get => firma3; set => firma3 = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }

        public TeklifiAlinanReddedilen(string stokNo, string tanim, int miktar, string birim, double bbf, double btf, string firma1, double ibf, double itf, string firma2, double ubf, double utf, string firma3, string siparisno)
        {
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.bbf = bbf;
            this.btf = btf;
            this.firma1 = firma1;
            this.ibf = ibf;
            this.itf = itf;
            this.firma2 = firma2;
            this.ubf = ubf;
            this.utf = utf;
            this.firma3 = firma3;
            this.siparisno = siparisno;
        }
    }
}
