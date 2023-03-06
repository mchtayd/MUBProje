using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class SatMail : TeklifAlinan
    {
        string gerekce, usBolgesi; int satNo; string stokNo, tanim; int miktar; string birim;

        public string Gerekce { get => gerekce; set => gerekce = value; }
        public string UsBolgesi { get => usBolgesi; set => usBolgesi = value; }
        public int SatNo { get => satNo; set => satNo = value; }
        public string StokNo1 { get => stokNo; set => stokNo = value; }
        public string Tanim1 { get => tanim; set => tanim = value; }
        public int Miktar1 { get => miktar; set => miktar = value; }
        public string Birim1 { get => birim; set => birim = value; }

        public SatMail(string stokNo, string tanim, int miktar, string birim, string firma1, double bbf, double btf, string firma2, double ibf, double itf, string firma3, double ubf, double utf, string siparisno, string gerekce, string usBolgesi, int satNo) : base(stokNo, tanim, miktar, birim, firma1, bbf, btf, firma2, ibf, itf, firma3, ubf, utf, siparisno)
        {
            this.gerekce = gerekce;
            this.usBolgesi = usBolgesi;
            this.satNo = satNo;
        }

        public SatMail(string usBolgesi, string gerekce, int satNo, string stokNo, string tanim, int miktar, string birim) :base(stokNo,tanim,miktar,birim,"")
        {
            this.usBolgesi = usBolgesi;
            this.gerekce = gerekce;
            this.satNo = satNo;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
        }

        public SatMail(string usBolgesi, string gerekce, int satNo, string stokNo, string tanim, int miktar, string birim, string firma, double bbf, double btf) : base(stokNo, tanim, miktar, birim, bbf,btf, firma)
        {
            this.usBolgesi = usBolgesi;
            this.gerekce = gerekce;
            this.satNo = satNo;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.Firma1 = firma;
            this.Bbf = bbf;
            this.Btf = btf;
        }
    }
}
