using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class AbfMalzemeIslemKayit
    {
        int id, benzersizId; string islem; DateTime tarih; string islemYapan; int gecenSure;

        public int Id { get => id; set => id = value; }
        public int BenzersizId { get => benzersizId; set => benzersizId = value; }
        public string Islem { get => islem; set => islem = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string IslemYapan { get => islemYapan; set => islemYapan = value; }
        public int GecenSure { get => gecenSure; set => gecenSure = value; }

        public AbfMalzemeIslemKayit(int id, int benzersizId, string islem, DateTime tarih, string islemYapan, int gecenSure)
        {
            this.id = id;
            this.benzersizId = benzersizId;
            this.islem = islem;
            this.tarih = tarih;
            this.islemYapan = islemYapan;
            this.gecenSure = gecenSure;
        }

        public AbfMalzemeIslemKayit(int benzersizId, string islem, DateTime tarih, string islemYapan, int gecenSure)
        {
            this.benzersizId = benzersizId;
            this.islem = islem;
            this.tarih = tarih;
            this.islemYapan = islemYapan;
            this.gecenSure = gecenSure;
        }
    }
}
