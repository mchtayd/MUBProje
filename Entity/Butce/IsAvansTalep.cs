using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Butce
{
    public class IsAvansTalep
    {
        int id, isAkisNo; DateTime tarih; string adiSoyadi, siparisNo, unvani, masrafYeriNo, masrafYeri, talepNedeni; double miktar; string aciklamalar, dosyaYolu;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string AdiSoyadi { get => adiSoyadi; set => adiSoyadi = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public string Unvani { get => unvani; set => unvani = value; }
        public string MasrafYeriNo { get => masrafYeriNo; set => masrafYeriNo = value; }
        public string MasrafYeri { get => masrafYeri; set => masrafYeri = value; }
        public string TalepNedeni { get => talepNedeni; set => talepNedeni = value; }
        public double Miktar { get => miktar; set => miktar = value; }
        public string Aciklamalar { get => aciklamalar; set => aciklamalar = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }

        public IsAvansTalep(int id, int isAkisNo, DateTime tarih, string adiSoyadi, string siparisNo, string unvani, string masrafYeriNo, string masrafYeri, string talepNedeni, double miktar, string aciklamalar, string dosyaYolu)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.tarih = tarih;
            this.adiSoyadi = adiSoyadi;
            this.siparisNo = siparisNo;
            this.unvani = unvani;
            this.masrafYeriNo = masrafYeriNo;
            this.masrafYeri = masrafYeri;
            this.talepNedeni = talepNedeni;
            this.miktar = miktar;
            this.aciklamalar = aciklamalar;
            this.dosyaYolu = dosyaYolu;
        }

        public IsAvansTalep(int isAkisNo, DateTime tarih, string adiSoyadi, string siparisNo, string unvani, string masrafYeriNo, string masrafYeri, string talepNedeni, double miktar, string aciklamalar, string dosyaYolu)
        {
            this.isAkisNo = isAkisNo;
            this.tarih = tarih;
            this.adiSoyadi = adiSoyadi;
            this.siparisNo = siparisNo;
            this.unvani = unvani;
            this.masrafYeriNo = masrafYeriNo;
            this.masrafYeri = masrafYeri;
            this.talepNedeni = talepNedeni;
            this.miktar = miktar;
            this.aciklamalar = aciklamalar;
            this.dosyaYolu = dosyaYolu;
        }
    }
}
