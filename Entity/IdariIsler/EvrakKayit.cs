using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class EvrakKayit
    {
        int id, isAkisNo; string yaziTuru, cinsi, neredenGeldigi, sayino; DateTime tarih;string konu, ekSayisi, geregi, bilgi1, bilgi2, bilgi3, bilgi4, bilgi5, dosyayolu,sayfa;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public string YaziTuru { get => yaziTuru; set => yaziTuru = value; }
        public string Cinsi { get => cinsi; set => cinsi = value; }
        public string NeredenGeldigi { get => neredenGeldigi; set => neredenGeldigi = value; }
        public string Sayino { get => sayino; set => sayino = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string Konu { get => konu; set => konu = value; }
        public string EkSayisi { get => ekSayisi; set => ekSayisi = value; }
        public string Geregi { get => geregi; set => geregi = value; }
        public string Bilgi1 { get => bilgi1; set => bilgi1 = value; }
        public string Bilgi2 { get => bilgi2; set => bilgi2 = value; }
        public string Bilgi3 { get => bilgi3; set => bilgi3 = value; }
        public string Bilgi4 { get => bilgi4; set => bilgi4 = value; }
        public string Bilgi5 { get => bilgi5; set => bilgi5 = value; }
        public string Dosyayolu { get => dosyayolu; set => dosyayolu = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }

        public EvrakKayit(int id, int isAkisNo, string yaziTuru, string cinsi, string neredenGeldigi, string sayino, DateTime tarih, string konu, string ekSayisi, string geregi, string bilgi1, string bilgi2, string bilgi3, string bilgi4, string bilgi5, string dosyayolu,string sayfa)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.yaziTuru = yaziTuru;
            this.cinsi = cinsi;
            this.neredenGeldigi = neredenGeldigi;
            this.sayino = sayino;
            this.tarih = tarih;
            this.konu = konu;
            this.ekSayisi = ekSayisi;
            this.geregi = geregi;
            this.bilgi1 = bilgi1;
            this.bilgi2 = bilgi2;
            this.bilgi3 = bilgi3;
            this.bilgi4 = bilgi4;
            this.bilgi5 = bilgi5;
            this.dosyayolu = dosyayolu;
            this.sayfa = sayfa;
        }

        public EvrakKayit(int isAkisNo, string yaziTuru, string cinsi, string neredenGeldigi, string sayino, DateTime tarih, string konu, string ekSayisi, string geregi, string bilgi1, string bilgi2, string bilgi3, string bilgi4, string bilgi5, string dosyayolu)
        {
            this.isAkisNo = isAkisNo;
            this.yaziTuru = yaziTuru;
            this.cinsi = cinsi;
            this.neredenGeldigi = neredenGeldigi;
            this.sayino = sayino;
            this.tarih = tarih;
            this.konu = konu;
            this.ekSayisi = ekSayisi;
            this.geregi = geregi;
            this.bilgi1 = bilgi1;
            this.bilgi2 = bilgi2;
            this.bilgi3 = bilgi3;
            this.bilgi4 = bilgi4;
            this.bilgi5 = bilgi5;
            this.dosyayolu = dosyayolu;
        }
    }
}
