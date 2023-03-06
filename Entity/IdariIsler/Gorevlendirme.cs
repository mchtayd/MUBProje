using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class Gorevlendirme
    {
        int id, isAkisNo; string adSoyad, unvani; string tc; string il, ilce, tugay, plaka, gorevlendirmeNedeni; DateTime basTarihi, bitTarihi; string dosyaYolu, durum, kalanSure;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public string AdSoyad { get => adSoyad; set => adSoyad = value; }
        public string Unvani { get => unvani; set => unvani = value; }
        public string Tc { get => tc; set => tc = value; }
        public string Il { get => il; set => il = value; }
        public string Ilce { get => ilce; set => ilce = value; }
        public string Tugay { get => tugay; set => tugay = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public string GorevlendirmeNedeni { get => gorevlendirmeNedeni; set => gorevlendirmeNedeni = value; }
        public DateTime BasTarihi { get => basTarihi; set => basTarihi = value; }
        public DateTime BitTarihi { get => bitTarihi; set => bitTarihi = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string Durum { get => durum; set => durum = value; }
        public string KalanSure { get => kalanSure; set => kalanSure = value; }

        public Gorevlendirme(int id, int isAkisNo, string adSoyad, string unvani, string tc, string il, string ilce, string tugay, string plaka, string gorevlendirmeNedeni, DateTime basTarihi, DateTime bitTarihi, string dosyaYolu, string durum, string kalansure)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.adSoyad = adSoyad;
            this.unvani = unvani;
            this.tc = tc;
            this.il = il;
            this.ilce = ilce;
            this.tugay = tugay;
            this.plaka = plaka;
            this.gorevlendirmeNedeni = gorevlendirmeNedeni;
            this.basTarihi = basTarihi;
            this.bitTarihi = bitTarihi;
            this.dosyaYolu = dosyaYolu;
            this.durum = durum;
            this.kalanSure = kalansure;
        }

        public Gorevlendirme(int isAkisNo, string adSoyad, string unvani, string tc, string il, string ilce, string tugay, string plaka, string gorevlendirmeNedeni, DateTime basTarihi, DateTime bitTarihi, string dosyaYolu, string durum)
        {
            this.isAkisNo = isAkisNo;
            this.adSoyad = adSoyad;
            this.unvani = unvani;
            this.tc = tc;
            this.il = il;
            this.ilce = ilce;
            this.tugay = tugay;
            this.plaka = plaka;
            this.gorevlendirmeNedeni = gorevlendirmeNedeni;
            this.basTarihi = basTarihi;
            this.bitTarihi = bitTarihi;
            this.dosyaYolu = dosyaYolu;
            this.durum = durum;
        }
    }
}
