using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class YolDurum
    {
        int id; string bolgeAdi; DateTime tarih; string donem, yolDurumu, aciklama, kayitYapan;

        public int Id { get => id; set => id = value; }
        public string BolgeAdi { get => bolgeAdi; set => bolgeAdi = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string Donem { get => donem; set => donem = value; }
        public string YolDurumu { get => yolDurumu; set => yolDurumu = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public string KayitYapan { get => kayitYapan; set => kayitYapan = value; }

        public YolDurum(int id, string bolgeAdi, DateTime tarih, string donem, string yolDurumu, string aciklama, string kayitYapan)
        {
            this.id = id;
            this.bolgeAdi = bolgeAdi;
            this.tarih = tarih;
            this.donem = donem;
            this.yolDurumu = yolDurumu;
            this.aciklama = aciklama;
            this.kayitYapan = kayitYapan;
        }

        public YolDurum(string bolgeAdi, DateTime tarih, string donem, string yolDurumu, string aciklama, string kayitYapan)
        {
            this.bolgeAdi = bolgeAdi;
            this.tarih = tarih;
            this.donem = donem;
            this.yolDurumu = yolDurumu;
            this.aciklama = aciklama;
            this.kayitYapan = kayitYapan;
        }
    }
}
