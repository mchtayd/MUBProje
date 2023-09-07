using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class AbfMalzemeIslemKayit
    {
        int id, benzersizId; string islem; DateTime tarih; string islemYapan; int gecenSure; string malzemeDurumu, stokNo, seriNo, revizyon;

        public int Id { get => id; set => id = value; }
        public int BenzersizId { get => benzersizId; set => benzersizId = value; }
        public string Islem { get => islem; set => islem = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string IslemYapan { get => islemYapan; set => islemYapan = value; }
        public int GecenSure { get => gecenSure; set => gecenSure = value; }
        public string MalzemeDurumu { get => malzemeDurumu; set => malzemeDurumu = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public string SeriNo { get => seriNo; set => seriNo = value; }
        public string Revizyon { get => revizyon; set => revizyon = value; }

        public AbfMalzemeIslemKayit(int id, int benzersizId, string islem, DateTime tarih, string islemYapan, int gecenSure, string malzemeDurumu, string stokNo, string seriNo, string revizyon)
        {
            this.id = id;
            this.benzersizId = benzersizId;
            this.islem = islem;
            this.tarih = tarih;
            this.islemYapan = islemYapan;
            this.gecenSure = gecenSure;
            this.malzemeDurumu = malzemeDurumu;
            this.stokNo = stokNo;
            this.seriNo = seriNo;
            this.revizyon = revizyon;
        }

        public AbfMalzemeIslemKayit(int benzersizId, string islem, DateTime tarih, string islemYapan, int gecenSure, string malzemeDurumu, string stokNo, string seriNo, string revizyon)
        {
            this.benzersizId = benzersizId;
            this.islem = islem;
            this.tarih = tarih;
            this.islemYapan = islemYapan;
            this.gecenSure = gecenSure;
            this.malzemeDurumu = malzemeDurumu;
            this.stokNo = stokNo;
            this.seriNo = seriNo;
            this.revizyon= revizyon;
        }
    }
}
