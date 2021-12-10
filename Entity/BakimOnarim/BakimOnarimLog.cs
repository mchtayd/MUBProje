using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class BakimOnarimLog
    {
        int id; string sayfa; int benzersiz; string islem, islemYapan; DateTime tarih;

        public int Id { get => id; set => id = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }
        public int Benzersiz { get => benzersiz; set => benzersiz = value; }
        public string Islem { get => islem; set => islem = value; }
        public string IslemYapan { get => islemYapan; set => islemYapan = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }

        public BakimOnarimLog(int id, string sayfa, int benzersiz, string islem, string islemYapan, DateTime tarih)
        {
            this.id = id;
            this.sayfa = sayfa;
            this.benzersiz = benzersiz;
            this.islem = islem;
            this.islemYapan = islemYapan;
            this.tarih = tarih;
        }

        public BakimOnarimLog(string sayfa, int benzersiz, string islem, string islemYapan, DateTime tarih)
        {
            this.sayfa = sayfa;
            this.benzersiz = benzersiz;
            this.islem = islem;
            this.islemYapan = islemYapan;
            this.tarih = tarih;
        }
    }
}
