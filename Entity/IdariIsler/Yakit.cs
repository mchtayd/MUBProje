using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class Yakit
    {
        int id, isakisno; string plaka, yakitAlinanDonem; DateTime tarih; int km; double alinanLitre; string yakitTuru; double litreFiyati, toplamFiyat; string alimTuru, personel, alinanFirma, belgeTuru, belgeNumarasi, dosyaYolu, sayfa, aciklama;

        public int Id { get => id; set => id = value; }
        public int Isakisno { get => isakisno; set => isakisno = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public string YakitAlinanDonem { get => yakitAlinanDonem; set => yakitAlinanDonem = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public int Km { get => km; set => km = value; }
        public double AlinanLitre { get => alinanLitre; set => alinanLitre = value; }
        public string YakitTuru { get => yakitTuru; set => yakitTuru = value; }
        public double LitreFiyati { get => litreFiyati; set => litreFiyati = value; }
        public double ToplamFiyat { get => toplamFiyat; set => toplamFiyat = value; }
        public string AlimTuru { get => alimTuru; set => alimTuru = value; }
        public string Personel { get => personel; set => personel = value; }
        public string AlinanFirma { get => alinanFirma; set => alinanFirma = value; }
        public string BelgeTuru { get => belgeTuru; set => belgeTuru = value; }
        public string BelgeNumarasi { get => belgeNumarasi; set => belgeNumarasi = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }

        public Yakit(int id, int isakisno, string plaka, string yakitAlinanDonem, DateTime tarih, int km, double alinanLitre, string yakitTuru, double litreFiyati, double toplamFiyat, string alimTuru, string personel, string alinanFirma, string belgeTuru, string belgeNumarasi,string dosyaYolu,string sayfa,string aciklama)
        {
            this.id = id;
            this.isakisno = isakisno;
            this.plaka = plaka;
            this.yakitAlinanDonem = yakitAlinanDonem;
            this.tarih = tarih;
            this.km = km;
            this.alinanLitre = alinanLitre;
            this.yakitTuru = yakitTuru;
            this.litreFiyati = litreFiyati;
            this.toplamFiyat = toplamFiyat;
            this.alimTuru = alimTuru;
            this.personel = personel;
            this.alinanFirma = alinanFirma;
            this.belgeTuru = belgeTuru;
            this.belgeNumarasi = belgeNumarasi;
            this.dosyaYolu = dosyaYolu;
            this.sayfa = sayfa;
            this.aciklama = aciklama;
        }

        public Yakit(int isakisno, string plaka, string yakitAlinanDonem, DateTime tarih, int km, double alinanLitre, string yakitTuru, double litreFiyati, double toplamFiyat, string alimTuru, string personel, string alinanFirma, string belgeTuru, string belgeNumarasi, string dosyaYolu,string aciklama)
        {
            this.isakisno = isakisno;
            this.plaka = plaka;
            this.yakitAlinanDonem = yakitAlinanDonem;
            this.tarih = tarih;
            this.km = km;
            this.alinanLitre = alinanLitre;
            this.yakitTuru = yakitTuru;
            this.litreFiyati = litreFiyati;
            this.toplamFiyat = toplamFiyat;
            this.alimTuru = alimTuru;
            this.personel = personel;
            this.alinanFirma = alinanFirma;
            this.belgeTuru = belgeTuru;
            this.belgeNumarasi = belgeNumarasi;
            this.dosyaYolu = dosyaYolu;
            this.aciklama = aciklama;
        }
    }
}
