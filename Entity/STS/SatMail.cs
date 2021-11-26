using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class SatMail : TeklifAlinan
    {
        string gerekce, usBolgesi; int satNo;

        public string Gerekce { get => gerekce; set => gerekce = value; }
        public string UsBolgesi { get => usBolgesi; set => usBolgesi = value; }
        public int SatNo { get => satNo; set => satNo = value; }

        public SatMail(string stokNo, string tanim, int miktar, string birim, string firma1, double bbf, double btf, string firma2, double ibf, double itf, string firma3, double ubf, double utf, string siparisno, string gerekce, string usBolgesi, int satNo) : base(stokNo, tanim, miktar, birim, firma1, bbf, btf, firma2, ibf, itf, firma3, ubf, utf, siparisno)
        {
            this.gerekce = gerekce;
            this.usBolgesi = usBolgesi;
            this.satNo = satNo;
        }
    }
}
