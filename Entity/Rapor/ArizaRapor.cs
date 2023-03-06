using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Rapor
{
    public class ArizaRapor
    {
        string bildirimTuru, bildirimNo, projeNo, projeTanim, ustStokNo,ustTanim,arizaliMalzeme, malzemeTanim, miktar, bildirimTarihi, mudehaleTarihi, kapanisTarihi, formNo, bolgeAdi;

        public string BildirimTuru { get => bildirimTuru; set => bildirimTuru = value; }
        public string BildirimNo { get => bildirimNo; set => bildirimNo = value; }
        public string ProjeNo { get => projeNo; set => projeNo = value; }
        public string ProjeTanim { get => projeTanim; set => projeTanim = value; }
        public string ArizaliMalzeme { get => arizaliMalzeme; set => arizaliMalzeme = value; }
        public string MalzemeTanim { get => malzemeTanim; set => malzemeTanim = value; }
        public string BildirimTarihi { get => bildirimTarihi; set => bildirimTarihi = value; }
        public string MudehaleTarihi { get => mudehaleTarihi; set => mudehaleTarihi = value; }
        public string KapanisTarihi { get => kapanisTarihi; set => kapanisTarihi = value; }
        public string FormNo { get => formNo; set => formNo = value; }
        public string BolgeAdi { get => bolgeAdi; set => bolgeAdi = value; }
        public string UstStokNo { get => ustStokNo; set => ustStokNo = value; }
        public string UstTanim { get => ustTanim; set => ustTanim = value; }
        public string Miktar { get => miktar; set => miktar = value; }

        public ArizaRapor(string bildirimTuru, string bildirimNo, string projeNo, string projeTanim, string arizaliMalzeme, string malzemeTanim, string bildirimTarihi, string mudehaleTarihi, string kapanisTarihi,string bolgeAdi,string ustStok,string ustTanim,string miktar)
        {
            this.bildirimTuru = bildirimTuru;
            this.bildirimNo = bildirimNo;
            this.projeNo = projeNo;
            this.projeTanim = projeTanim;
            this.arizaliMalzeme = arizaliMalzeme;
            this.malzemeTanim = malzemeTanim;
            this.bildirimTarihi = bildirimTarihi;
            this.mudehaleTarihi = mudehaleTarihi;
            this.kapanisTarihi = kapanisTarihi;
            this.bolgeAdi = bolgeAdi;
            this.ustStokNo = ustStok;
            this.ustTanim = ustTanim;
            this.miktar = miktar;
        }

        public ArizaRapor(string formNo)
        {
            this.formNo = formNo;
        }
    }
}
