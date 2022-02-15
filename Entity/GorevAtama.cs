using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GorevAtama
    {
        int id, isAkisNo; string gorevAtananPersonel; DateTime bitisTarihi; string gorevinKonusu; DateTime gorevAtamaTarihi; string goreviAtayanPersonel; DateTime gorevinTamamlandigiTarih; string yapilanIslem, toplamSure, gecenSure, dosyaYolu;

        public int Id { get => id; set => id = value; }
        public string GorevAtananPersonel { get => gorevAtananPersonel; set => gorevAtananPersonel = value; }
        public DateTime BitisTarihi { get => bitisTarihi; set => bitisTarihi = value; }
        public string GorevinKonusu { get => gorevinKonusu; set => gorevinKonusu = value; }
        public DateTime GorevAtamaTarihi { get => gorevAtamaTarihi; set => gorevAtamaTarihi = value; }
        public string GoreviAtayanPersonel { get => goreviAtayanPersonel; set => goreviAtayanPersonel = value; }
        public DateTime GorevinTamamlandigiTarih { get => gorevinTamamlandigiTarih; set => gorevinTamamlandigiTarih = value; }
        public string YapilanIslem { get => yapilanIslem; set => yapilanIslem = value; }
        public string ToplamSure { get => toplamSure; set => toplamSure = value; }
        public string GecenSure { get => gecenSure; set => gecenSure = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }

        public GorevAtama(int id, int isAkisNo,string gorevAtananPersonel, DateTime bitisTarihi, string gorevinKonusu, DateTime gorevAtamaTarihi, string goreviAtayanPersonel, DateTime gorevinTamamlandigiTarih, string yapilanIslem, string toplamSure,string gecenSure, string dosyaYolu)
        {
            this.id = id;
            this.gorevAtananPersonel = gorevAtananPersonel;
            this.bitisTarihi = bitisTarihi;
            this.gorevinKonusu = gorevinKonusu;
            this.gorevAtamaTarihi = gorevAtamaTarihi;
            this.goreviAtayanPersonel = goreviAtayanPersonel;
            this.gorevinTamamlandigiTarih = gorevinTamamlandigiTarih;
            this.yapilanIslem = yapilanIslem;
            this.toplamSure = toplamSure;
            this.gecenSure = gecenSure;
            this.dosyaYolu = dosyaYolu;
            this.isAkisNo = isAkisNo;
        }
        public GorevAtama(int id,int isAkisNo,string gorevAtananPersonel, DateTime bitisTarihi, string gorevinKonusu, DateTime gorevAtamaTarihi, string goreviAtayanPersonel, DateTime gorevinTamamlandigiTarih, string yapilanIslem, string toplamSure,string dosyaYolu)
        {
            this.id = id;
            this.gorevAtananPersonel = gorevAtananPersonel;
            this.bitisTarihi = bitisTarihi;
            this.gorevinKonusu = gorevinKonusu;
            this.gorevAtamaTarihi = gorevAtamaTarihi;
            this.goreviAtayanPersonel = goreviAtayanPersonel;
            this.gorevinTamamlandigiTarih = gorevinTamamlandigiTarih;
            this.yapilanIslem = yapilanIslem;
            this.toplamSure = toplamSure;
            this.dosyaYolu = dosyaYolu;
            this.isAkisNo = isAkisNo;
        }

        public GorevAtama(int id,int isAkisNo,DateTime bitisTarihi, string gorevinKonusu, DateTime gorevAtamaTarihi, string goreviAtayanPersonel, string gecenSure, string dosyaYolu)
        {
            this.id = id;
            this.bitisTarihi = bitisTarihi;
            this.gorevinKonusu = gorevinKonusu;
            this.gorevAtamaTarihi = gorevAtamaTarihi;
            this.goreviAtayanPersonel = goreviAtayanPersonel;
            this.gecenSure = gecenSure;
            this.dosyaYolu = dosyaYolu;
            this.isAkisNo = isAkisNo;
        }

        public GorevAtama(int isAkisNo,string gorevAtananPersonel, DateTime bitisTarihi, string gorevinKonusu, DateTime gorevAtamaTarihi, string goreviAtayanPersonel, string dosyaYolu)
        {
            this.gorevAtananPersonel = gorevAtananPersonel;
            this.bitisTarihi = bitisTarihi;
            this.gorevinKonusu = gorevinKonusu;
            this.gorevAtamaTarihi = gorevAtamaTarihi;
            this.goreviAtayanPersonel = goreviAtayanPersonel;
            this.dosyaYolu = dosyaYolu;
            this.isAkisNo = isAkisNo;
        }

        public GorevAtama(int id, DateTime gorevinTamamlandigiTarih, string yapilanIslem, string toplamSure, string dosyaYolu)
        {
            this.id = id;
            this.gorevinTamamlandigiTarih = gorevinTamamlandigiTarih;
            this.yapilanIslem = yapilanIslem;
            this.toplamSure = toplamSure;
            this.dosyaYolu = dosyaYolu;
        }
    }
}
