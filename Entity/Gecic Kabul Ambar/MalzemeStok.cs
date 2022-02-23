using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Gecic_Kabul_Ambar
{
    public class MalzemeStok
    {
        int id; string stokNo, tanim, malzemeninKulYer, malzemeUstTakim, dosyaYolu;

        public int Id { get => id; set => id = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string MalzemeninKulYer { get => malzemeninKulYer; set => malzemeninKulYer = value; }
        public string MalzemeUstTakim { get => malzemeUstTakim; set => malzemeUstTakim = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }

        public MalzemeStok(int id, string stokNo, string tanim, string malzemeninKulYer, string malzemeUstTakim, string dosyaYolu)
        {
            this.id = id;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.malzemeninKulYer = malzemeninKulYer;
            this.malzemeUstTakim = malzemeUstTakim;
            this.dosyaYolu = dosyaYolu;
        }

        public MalzemeStok(string stokNo, string tanim, string malzemeninKulYer, string malzemeUstTakim, string dosyaYolu)
        {
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.malzemeninKulYer = malzemeninKulYer;
            this.malzemeUstTakim = malzemeUstTakim;
            this.dosyaYolu = dosyaYolu;
        }
    }
}
