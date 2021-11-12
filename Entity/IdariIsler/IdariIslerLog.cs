using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class IdariIslerLog
    {
        int id; string sayfa; int benzersizid; string islem, islemyapan; DateTime tarih;

        public int Id { get => id; set => id = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }
        public int Benzersizid { get => benzersizid; set => benzersizid = value; }
        public string Islem { get => islem; set => islem = value; }
        public string Islemyapan { get => islemyapan; set => islemyapan = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }

        public IdariIslerLog(string sayfa, int benzersizid, string islem, string islemyapan, DateTime tarih)
        {
            this.sayfa = sayfa;
            this.benzersizid = benzersizid;
            this.islem = islem;
            this.islemyapan = islemyapan;
            this.tarih = tarih;
        }

        public IdariIslerLog(int id, string sayfa, int benzersizid, string islem, string islemyapan, DateTime tarih)
        {
            this.id = id;
            this.sayfa = sayfa;
            this.benzersizid = benzersizid;
            this.islem = islem;
            this.islemyapan = islemyapan;
            this.tarih = tarih;
        }
    }
}
