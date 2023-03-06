using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Gecic_Kabul_Ambar
{
    public class DepoMiktar
    {
        bool secim; int id; string stokNo, tanim, seriNo, lotNo, revizyon; DateTime sonIslemTarihi; string sonIslemYapan, depoNo, depoAdresi, depoLokasyon; int miktar; string aciklama, rezerveDurumu; int rezerveId;

        public int Id { get => id; set => id = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public DateTime SonIslemTarihi { get => sonIslemTarihi; set => sonIslemTarihi = value; }
        public string SonIslemYapan { get => sonIslemYapan; set => sonIslemYapan = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public string DepoNo { get => depoNo; set => depoNo = value; }
        public string DepoAdresi { get => depoAdresi; set => depoAdresi = value; }
        public string SeriNo { get => seriNo; set => seriNo = value; }
        public string LotNo { get => lotNo; set => lotNo = value; }
        public string Revizyon { get => revizyon; set => revizyon = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public string DepoLokasyon { get => depoLokasyon; set => depoLokasyon = value; }
        public bool Secim { get => secim; set => secim = value; }
        public string RezerveDurumu { get => rezerveDurumu; set => rezerveDurumu = value; }
        public int RezerveId { get => rezerveId; set => rezerveId = value; }

        public DepoMiktar(int id, string stokNo, string tanim, string seriNo, string lotNo, string revizyon, DateTime sonIslemTarihi, string sonIslemYapan, string depoNo, string depoAdresi, string depoLokasyon, int miktar, string aciklama,string rezerveDurumu, int rezerveId)
        {
            this.id = id;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.sonIslemTarihi = sonIslemTarihi;
            this.sonIslemYapan = sonIslemYapan;
            this.miktar = miktar;
            this.depoNo = depoNo;
            this.depoAdresi = depoAdresi;
            this.depoLokasyon = depoLokasyon;
            this.seriNo = seriNo;
            this.lotNo = lotNo;
            this.revizyon = revizyon;
            this.aciklama = aciklama;
            this.rezerveDurumu = rezerveDurumu;
            this.rezerveId = rezerveId;
        }

        public DepoMiktar(bool secim, int id, string stokNo, string tanim, string seriNo, string lotNo, string revizyon, DateTime sonIslemTarihi, string sonIslemYapan, string depoNo, string depoAdresi, string depoLokasyon, int miktar, string aciklama,string rezerveDurumu,int rezerveId)
        {
            this.secim = secim;
            this.id = id;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.seriNo = seriNo;
            this.lotNo = lotNo;
            this.revizyon = revizyon;
            this.sonIslemTarihi = sonIslemTarihi;
            this.sonIslemYapan = sonIslemYapan;
            this.depoNo = depoNo;
            this.depoAdresi = depoAdresi;
            this.depoLokasyon = depoLokasyon;
            this.miktar = miktar;
            this.aciklama = aciklama;
            this.rezerveDurumu = rezerveDurumu;
            this.rezerveId = rezerveId;
        }

        public DepoMiktar(string stokNo, string tanim, string seriNo, string lotNo, string revizyon, DateTime sonIslemTarihi, string sonIslemYapan, string depoNo,string depoAdresi, string depoLokasyon, int miktar,string aciklama)
        {
            this.stokNo = stokNo;
            this.seriNo = seriNo;
            this.lotNo = lotNo;
            this.revizyon = revizyon;
            this.tanim = tanim;
            this.sonIslemTarihi = sonIslemTarihi;
            this.sonIslemYapan = sonIslemYapan;
            this.miktar = miktar;
            this.depoNo = depoNo;
            this.depoAdresi = depoAdresi;
            this.aciklama = aciklama;
            this.depoLokasyon = depoLokasyon;
        }

        public DepoMiktar(string stokNo, string depoNo, string depoLokasyon ,string seriNo, string lotNo,string revizyon, DateTime sonIslemTarihi, string sonIslemYapan, int miktar)
        {
            this.stokNo = stokNo;
            this.depoNo = depoNo;
            this.seriNo = seriNo;
            this.lotNo = lotNo;
            this.revizyon = revizyon;
            this.sonIslemTarihi = sonIslemTarihi;
            this.sonIslemYapan = sonIslemYapan;
            this.miktar = miktar;
            this.depoLokasyon = depoLokasyon;

        }

        public DepoMiktar(int id, string sonIslemYapan, string aciklama, int rezerveId)
        {
            this.id = id;
            this.sonIslemYapan = sonIslemYapan;
            this.aciklama = aciklama;
            this.rezerveId = rezerveId;
        }
    }
}
