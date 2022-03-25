using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class IscilikIscilik
    {
        int id, benzersizId; string adSoyad, gorevi, bolum, iscilikTuru, abfSiparis; DateTime tarih; DateTime iscilikSuresi;

        public int Id { get => id; set => id = value; }
        public int BenzersizId { get => benzersizId; set => benzersizId = value; }
        public string AdSoyad { get => adSoyad; set => adSoyad = value; }
        public string Gorevi { get => gorevi; set => gorevi = value; }
        public string Bolum { get => bolum; set => bolum = value; }
        public string IscilikTuru { get => iscilikTuru; set => iscilikTuru = value; }
        public string AbfSiparis { get => abfSiparis; set => abfSiparis = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public DateTime IscilikSuresi { get => iscilikSuresi; set => iscilikSuresi = value; }

        public IscilikIscilik(int id, int benzersizId, string adSoyad, string gorevi, string bolum, string iscilikTuru, string abfSiparis, DateTime tarih, DateTime iscilikSuresi)
        {
            this.id = id;
            this.benzersizId = benzersizId;
            this.adSoyad = adSoyad;
            this.gorevi = gorevi;
            this.bolum = bolum;
            this.iscilikTuru = iscilikTuru;
            this.abfSiparis = abfSiparis;
            this.tarih = tarih;
            this.iscilikSuresi = iscilikSuresi;
        }

        public IscilikIscilik(int benzersizId, string adSoyad, string gorevi, string bolum, string iscilikTuru, string abfSiparis, DateTime tarih, DateTime iscilikSuresi)
        {
            this.benzersizId = benzersizId;
            this.adSoyad = adSoyad;
            this.gorevi = gorevi;
            this.bolum = bolum;
            this.iscilikTuru = iscilikTuru;
            this.abfSiparis = abfSiparis;
            this.tarih = tarih;
            this.iscilikSuresi = iscilikSuresi;
        }
    }
}
