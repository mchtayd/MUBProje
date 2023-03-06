using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarimAtolye
{
    public class AtolyeAltMalzeme
    {
        int id; string stokNo, tanim, sokulenSeriNo, takilanSeriNo; double miktar; string birim, malzemeyeYapilanIslem, siparisNo;

        public int Id { get => id; set => id = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string SokulenSeriNo { get => sokulenSeriNo; set => sokulenSeriNo = value; }
        public string TakilanSeriNo { get => takilanSeriNo; set => takilanSeriNo = value; }
        public double Miktar { get => miktar; set => miktar = value; }
        public string Birim { get => birim; set => birim = value; }
        public string MalzemeyeYapilanIslem { get => malzemeyeYapilanIslem; set => malzemeyeYapilanIslem = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }

        public AtolyeAltMalzeme(int id, string stokNo, string tanim, string sokulenSeriNo, string takilanSeriNo, double miktar, string birim, string malzemeyeYapilanIslem, string siparisNo)
        {
            this.id = id;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.sokulenSeriNo = sokulenSeriNo;
            this.takilanSeriNo = takilanSeriNo;
            this.miktar = miktar;
            this.birim = birim;
            this.malzemeyeYapilanIslem = malzemeyeYapilanIslem;
            this.siparisNo = siparisNo;
        }

        public AtolyeAltMalzeme(string stokNo, string tanim, string sokulenSeriNo, string takilanSeriNo, double miktar, string birim, string malzemeyeYapilanIslem, string siparisNo)
        {
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.sokulenSeriNo = sokulenSeriNo;
            this.takilanSeriNo = takilanSeriNo;
            this.miktar = miktar;
            this.birim = birim;
            this.malzemeyeYapilanIslem = malzemeyeYapilanIslem;
            this.siparisNo = siparisNo;
        }
    }
}
