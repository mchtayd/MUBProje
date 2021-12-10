using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class IscilikIscilik
    {
        int id; string adSoyad, gorevi, bolum, iscilikTuru, abfNo; DateTime tarih; string iscilikSuresi;

        public int Id { get => id; set => id = value; }
        public string AdSoyad { get => adSoyad; set => adSoyad = value; }
        public string Gorevi { get => gorevi; set => gorevi = value; }
        public string Bolum { get => bolum; set => bolum = value; }
        public string IscilikTuru { get => iscilikTuru; set => iscilikTuru = value; }
        public string AbfNo { get => abfNo; set => abfNo = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string IscilikSuresi { get => iscilikSuresi; set => iscilikSuresi = value; }

        public IscilikIscilik(int id, string adSoyad, string gorevi, string bolum, string iscilikTuru, string abfNo, DateTime tarih, string iscilikSuresi)
        {
            this.id = id;
            this.adSoyad = adSoyad;
            this.gorevi = gorevi;
            this.bolum = bolum;
            this.iscilikTuru = iscilikTuru;
            this.abfNo = abfNo;
            this.tarih = tarih;
            this.iscilikSuresi = iscilikSuresi;
        }

        public IscilikIscilik(string adSoyad, string gorevi, string bolum, string iscilikTuru, string abfNo, DateTime tarih, string iscilikSuresi)
        {
            this.adSoyad = adSoyad;
            this.gorevi = gorevi;
            this.bolum = bolum;
            this.iscilikTuru = iscilikTuru;
            this.abfNo = abfNo;
            this.tarih = tarih;
            this.iscilikSuresi = iscilikSuresi;
        }
    }
}
