using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarimAtolye
{
    public class AtolyeMalzeme
    {
        int id, formNo; string stokNo, tanim, seriNo, durum, revizyon; double miktar; DateTime talepTarihi; string siparisNo; bool sec = true; string teslimDurumu;

        public int Id { get => id; set => id = value; }
        public int FormNo { get => formNo; set => formNo = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string SeriNo { get => seriNo; set => seriNo = value; }
        public string Durum { get => durum; set => durum = value; }
        public string Revizyon { get => revizyon; set => revizyon = value; }
        public double Miktar { get => miktar; set => miktar = value; }
        public DateTime TalepTarihi { get => talepTarihi; set => talepTarihi = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public bool Sec { get => sec; set => sec = value; }
        public string TeslimDurumu { get => teslimDurumu; set => teslimDurumu = value; }

        public AtolyeMalzeme(int id, int formNo, string stokNo, string tanim, string seriNo, string durum, string revizyon, double miktar, DateTime talepTarihi, string siparisNo, string teslimDurumu)
        {
            this.id = id;
            this.formNo = formNo;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.seriNo = seriNo;
            this.durum = durum;
            this.revizyon = revizyon;
            this.miktar = miktar;
            this.talepTarihi = talepTarihi;
            this.siparisNo = siparisNo;
            this.teslimDurumu = teslimDurumu;
        }

        public AtolyeMalzeme(int formNo, string stokNo, string tanim, string seriNo, string durum, string revizyon, double miktar, DateTime talepTarihi, string siparisNo)
        {
            this.formNo = formNo;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.seriNo = seriNo;
            this.durum = durum;
            this.revizyon = revizyon;
            this.miktar = miktar;
            this.talepTarihi = talepTarihi;
            this.siparisNo = siparisNo;
        }
    }
}
