using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Gecic_Kabul_Ambar
{
    public class Sevkiyat
    {
        int id; string sevkiyatTuru; DateTime tarih; string donem, dosyaYolu;

        public int Id { get => id; set => id = value; }
        public string SevkiyatTuru { get => sevkiyatTuru; set => sevkiyatTuru = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string Donem { get => donem; set => donem = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }

        public Sevkiyat(int id, string sevkiyatTuru, DateTime tarih, string donem, string dosyaYolu)
        {
            this.id = id;
            this.sevkiyatTuru = sevkiyatTuru;
            this.tarih = tarih;
            this.donem = donem;
            this.dosyaYolu = dosyaYolu;
        }

        public Sevkiyat(string sevkiyatTuru, DateTime tarih, string donem, string dosyaYolu)
        {
            this.sevkiyatTuru = sevkiyatTuru;
            this.tarih = tarih;
            this.donem = donem;
            this.dosyaYolu = dosyaYolu;
        }
    }
}
