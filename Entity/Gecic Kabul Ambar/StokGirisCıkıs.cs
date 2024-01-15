using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Gecic_Kabul_Ambar
{
    public class StokGirisCıkıs
    {
        int id; string islemturu, stokno, tanim; string birim; DateTime islemTarihi; string cekilenDepoNo, cekilenDepoAdresi, cekilenMalzemeYeri, dusulenDepoNo, dusulenDepoAdresi, dusulenMalzemeYeri; int dusulenMiktar; string talepEdenPersonel, aciklama, serino, lotno, revizyon, sayimYili;

        public int Id { get => id; set => id = value; }
        public string Islemturu { get => islemturu; set => islemturu = value; }
        public string Stokno { get => stokno; set => stokno = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string Birim { get => birim; set => birim = value; }
        public DateTime IslemTarihi { get => islemTarihi; set => islemTarihi = value; }
        public string CekilenDepoNo { get => cekilenDepoNo; set => cekilenDepoNo = value; }
        public string CekilenDepoAdresi { get => cekilenDepoAdresi; set => cekilenDepoAdresi = value; }
        public string CekilenMalzemeYeri { get => cekilenMalzemeYeri; set => cekilenMalzemeYeri = value; }
        public string DusulenDepoNo { get => dusulenDepoNo; set => dusulenDepoNo = value; }
        public string DusulenDepoAdresi { get => dusulenDepoAdresi; set => dusulenDepoAdresi = value; }
        public string DusulenMalzemeYeri { get => dusulenMalzemeYeri; set => dusulenMalzemeYeri = value; }
        public int DusulenMiktar { get => dusulenMiktar; set => dusulenMiktar = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public string Serino { get => serino; set => serino = value; }
        public string Lotno { get => lotno; set => lotno = value; }
        public string Revizyon { get => revizyon; set => revizyon = value; }
        public string TalepEdenPersonel { get => talepEdenPersonel; set => talepEdenPersonel = value; }
        public string SayimYili { get => sayimYili; set => sayimYili = value; }

        public StokGirisCıkıs(int id, string islemturu, string stokno, string tanim, string birim, DateTime islemTarihi, string cekilenDepoNo, string cekilenDepoAdresi, string cekilenMalzemeYeri, string dusulenDepoNo, string dusulenDepoAdresi, string dusulenMalzemeYeri, int dusulenMiktar, string talepEdenPersonel, string aciklama, string serino, string lotno, string revizyon,string sayimYili="")
        {
            this.id = id;
            this.islemturu = islemturu;
            this.stokno = stokno;
            this.tanim = tanim;
            //this.mevcutMiktar = mevcutMiktar;
            this.birim = birim;
            this.islemTarihi = islemTarihi;
            this.cekilenDepoNo = cekilenDepoNo;
            this.cekilenDepoAdresi = cekilenDepoAdresi;
            this.cekilenMalzemeYeri = cekilenMalzemeYeri;
            this.dusulenDepoNo = dusulenDepoNo;
            this.dusulenMalzemeYeri = dusulenMalzemeYeri;
            this.dusulenDepoAdresi = dusulenDepoAdresi;
            this.dusulenMiktar = dusulenMiktar;
            this.aciklama = aciklama;
            this.serino = serino;
            this.lotno = lotno;
            this.talepEdenPersonel = talepEdenPersonel;
            this.revizyon = revizyon;
            this.sayimYili=sayimYili;
        }

        public StokGirisCıkıs(string islemturu, string stokno, string tanim, string birim, DateTime islemTarihi, string cekilenDepoNo, string cekilenDepoAdresi, string cekilenMalzemeYeri, string dusulenDepoNo, string dusulenDepoAdresi, string dusulenMalzemeYeri, int dusulenMiktar, string talepEdenPersonel, string aciklama, string serino, string lotno, string revizyon, string sayimYili="")
        {
            this.islemturu = islemturu;
            this.stokno = stokno;
            this.tanim = tanim;
            //this.mevcutMiktar = mevcutMiktar;
            this.birim = birim;
            this.islemTarihi = islemTarihi;
            this.cekilenDepoNo = cekilenDepoNo;
            this.cekilenDepoAdresi = cekilenDepoAdresi;
            this.cekilenMalzemeYeri = cekilenMalzemeYeri;
            this.dusulenDepoNo = dusulenDepoNo;
            this.dusulenDepoAdresi = dusulenDepoAdresi;
            this.dusulenMalzemeYeri = dusulenMalzemeYeri;
            this.dusulenMiktar = dusulenMiktar;
            this.aciklama = aciklama;
            this.serino = serino;
            this.lotno = lotno;
            this.revizyon = revizyon;
            this.talepEdenPersonel = talepEdenPersonel;
            this.sayimYili = sayimYili;
        }

        public StokGirisCıkıs(string stokno, string dusulenDepoNo, string serino, string lotno, string revizyon)
        {
            this.stokno = stokno;
            this.dusulenDepoNo = dusulenDepoNo;
            this.serino = serino;
            this.lotno = lotno;
            this.revizyon = revizyon;
        }

        public StokGirisCıkıs(int id,string stokno, DateTime islemTarihi, string dusulenDepoNo, string dusulenDepoAdresi, string dusulenMalzemeYeri, int dusulenMiktar, string aciklama, string serino, string lotno, string revizyon)
        {
            this.id=id;
            this.stokno = stokno;
            this.islemTarihi = islemTarihi;
            this.dusulenDepoNo = dusulenDepoNo;
            this.dusulenDepoAdresi = dusulenDepoAdresi;
            this.dusulenMalzemeYeri = dusulenMalzemeYeri;
            this.dusulenMiktar = dusulenMiktar;
            this.aciklama = aciklama;
            this.serino = serino;
            this.lotno = lotno;
            this.revizyon = revizyon;
        }
    }
}
