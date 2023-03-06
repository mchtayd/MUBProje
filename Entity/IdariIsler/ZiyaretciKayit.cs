using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class ZiyaretciKayit
    {
        int id, isAkisNo; string ziyaretciAd, tc, firmaAdi; DateTime geldigiTarihSaat; string ziyaretNedeni, ziyaretEdilenAd, ziyaretEdilenUnvani, ziyaretEdilenMasYeriNo, ziyaretEdilenMasYeri, refakatciAd, refakatciUnvani, refakatciMasYeriNo, refakatciMasYeri;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public string ZiyaretciAd { get => ziyaretciAd; set => ziyaretciAd = value; }
        public string Tc { get => tc; set => tc = value; }
        public string FirmaAdi { get => firmaAdi; set => firmaAdi = value; }
        public DateTime GeldigiTarihSaat { get => geldigiTarihSaat; set => geldigiTarihSaat = value; }
        public string ZiyaretNedeni { get => ziyaretNedeni; set => ziyaretNedeni = value; }
        public string ZiyaretEdilenAd { get => ziyaretEdilenAd; set => ziyaretEdilenAd = value; }
        public string ZiyaretEdilenUnvani { get => ziyaretEdilenUnvani; set => ziyaretEdilenUnvani = value; }
        public string ZiyaretEdilenMasYeriNo { get => ziyaretEdilenMasYeriNo; set => ziyaretEdilenMasYeriNo = value; }
        public string ZiyaretEdilenMasYeri { get => ziyaretEdilenMasYeri; set => ziyaretEdilenMasYeri = value; }
        public string RefakatciAd { get => refakatciAd; set => refakatciAd = value; }
        public string RefakatciUnvani { get => refakatciUnvani; set => refakatciUnvani = value; }
        public string RefakatciMasYeriNo { get => refakatciMasYeriNo; set => refakatciMasYeriNo = value; }
        public string RefakatciMasYeri { get => refakatciMasYeri; set => refakatciMasYeri = value; }

        public ZiyaretciKayit(int id, int isAkisNo, string ziyaretciAd, string tc, string firmaAdi, DateTime geldigiTarihSaat, string ziyaretNedeni, string ziyaretEdilenAd, string ziyaretEdilenUnvani, string ziyaretEdilenMasYeriNo, string ziyaretEdilenMasYeri, string refakatciAd, string refakatciUnvani, string refakatciMasYeriNo, string refakatciMasYeri)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.ziyaretciAd = ziyaretciAd;
            this.tc = tc;
            this.firmaAdi = firmaAdi;
            this.geldigiTarihSaat = geldigiTarihSaat;
            this.ziyaretNedeni = ziyaretNedeni;
            this.ziyaretEdilenAd = ziyaretEdilenAd;
            this.ziyaretEdilenUnvani = ziyaretEdilenUnvani;
            this.ziyaretEdilenMasYeriNo = ziyaretEdilenMasYeriNo;
            this.ziyaretEdilenMasYeri = ziyaretEdilenMasYeri;
            this.refakatciAd = refakatciAd;
            this.refakatciUnvani = refakatciUnvani;
            this.refakatciMasYeriNo = refakatciMasYeriNo;
            this.refakatciMasYeri = refakatciMasYeri;
        }

        public ZiyaretciKayit(int isAkisNo, string ziyaretciAd, string tc, string firmaAdi, DateTime geldigiTarihSaat, string ziyaretNedeni, string ziyaretEdilenAd, string ziyaretEdilenUnvani, string ziyaretEdilenMasYeriNo, string ziyaretEdilenMasYeri, string refakatciAd, string refakatciUnvani, string refakatciMasYeriNo, string refakatciMasYeri)
        {
            this.isAkisNo = isAkisNo;
            this.ziyaretciAd = ziyaretciAd;
            this.tc = tc;
            this.firmaAdi = firmaAdi;
            this.geldigiTarihSaat = geldigiTarihSaat;
            this.ziyaretNedeni = ziyaretNedeni;
            this.ziyaretEdilenAd = ziyaretEdilenAd;
            this.ziyaretEdilenUnvani = ziyaretEdilenUnvani;
            this.ziyaretEdilenMasYeriNo = ziyaretEdilenMasYeriNo;
            this.ziyaretEdilenMasYeri = ziyaretEdilenMasYeri;
            this.refakatciAd = refakatciAd;
            this.refakatciUnvani = refakatciUnvani;
            this.refakatciMasYeriNo = refakatciMasYeriNo;
            this.refakatciMasYeri = refakatciMasYeri;
        }
    }
}
