using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class YakitDokum
    {
        int id, isAkisNo; string firma, donem; DateTime tarih; string defterNo, siraNo, fisNo, personel, plaka, aracSiparisNo; double litreFiyati, verilenLitre, toplamTutar; string dosyaYolu, siparisNo, alimTuru;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public string Firma { get => firma; set => firma = value; }
        public string Donem { get => donem; set => donem = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string DefterNo { get => defterNo; set => defterNo = value; }
        public string SiraNo { get => siraNo; set => siraNo = value; }
        public string FisNo { get => fisNo; set => fisNo = value; }
        public string Personel { get => personel; set => personel = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public string AracSiparisNo { get => aracSiparisNo; set => aracSiparisNo = value; }
        public double LitreFiyati { get => litreFiyati; set => litreFiyati = value; }
        public double VerilenLitre { get => verilenLitre; set => verilenLitre = value; }
        public double ToplamTutar { get => toplamTutar; set => toplamTutar = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public string AlimTuru { get => alimTuru; set => alimTuru = value; }

        public YakitDokum()
        {

        }
        public YakitDokum(int id, int isAkisNo, string firma, string donem, DateTime tarih, string defterNo, string siraNo, string fisNo, string personel, string plaka, string aracSiparisNo, double litreFiyati, double verilenLitre, double toplamTutar, string dosyaYolu, string siparisNo)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.firma = firma;
            this.donem = donem;
            this.tarih = tarih;
            this.defterNo = defterNo;
            this.siraNo = siraNo;
            this.fisNo = fisNo;
            this.personel = personel;
            this.plaka = plaka;
            this.aracSiparisNo = aracSiparisNo;
            this.litreFiyati = litreFiyati;
            this.verilenLitre = verilenLitre;
            this.toplamTutar = toplamTutar;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
        }

        public YakitDokum(int isAkisNo, string firma, string donem, DateTime tarih, string defterNo, string siraNo, string fisNo, string personel, string plaka, string aracSiparisNo, double litreFiyati, double verilenLitre, double toplamTutar, string dosyaYolu, string siparisNo)
        {
            this.isAkisNo = isAkisNo;
            this.firma = firma;
            this.donem = donem;
            this.tarih = tarih;
            this.defterNo = defterNo;
            this.siraNo = siraNo;
            this.fisNo = fisNo;
            this.personel = personel;
            this.plaka = plaka;
            this.aracSiparisNo = aracSiparisNo;
            this.litreFiyati = litreFiyati;
            this.verilenLitre = verilenLitre;
            this.toplamTutar = toplamTutar;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
        }

        public YakitDokum(int id, int isAkisNo, string firma, string donem, double verilenLitre, double toplamTutar, string dosyaYolu, string siparisNo, string alimTuru)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.firma = firma;
            this.donem = donem;
            this.verilenLitre = verilenLitre;
            this.toplamTutar = toplamTutar;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
            this.alimTuru = alimTuru;
        }
        public YakitDokum(int isAkisNo, string firma, string donem, double verilenLitre, double toplamTutar, string dosyaYolu, string siparisNo, string alimTuru)
        {
            this.isAkisNo = isAkisNo;
            this.firma = firma;
            this.donem = donem;
            this.verilenLitre = verilenLitre;
            this.toplamTutar = toplamTutar;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
            this.alimTuru = alimTuru;
        }

        public YakitDokum(int isAkisNo, string firma, string donem, DateTime tarih, string plaka, string aracSiparisNo, double toplamTutar, string dosyaYolu, string siparisNo)
        {
            this.isAkisNo = isAkisNo;
            this.firma = firma;
            this.donem = donem;
            this.tarih = tarih;
            this.plaka = plaka;
            this.aracSiparisNo = aracSiparisNo;
            this.toplamTutar = toplamTutar;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
        }

        public YakitDokum(int isAkisNo, string firma, string donem, double toplamTutar, string dosyaYolu, string siparisNo, string alimTuru)
        {
            this.isAkisNo = isAkisNo;
            this.firma = firma;
            this.donem = donem;
            this.toplamTutar = toplamTutar;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
            this.alimTuru = alimTuru;
        }

        public YakitDokum(int isAkisNo, string firma, string donem, DateTime tarih, string plaka, string aracSiparisNo, double verilenLitre, double toplamTutar, string dosyaYolu,string personel)
        {
            this.isAkisNo = isAkisNo;
            this.firma = firma;
            this.donem = donem;
            this.tarih = tarih;
            this.plaka = plaka;
            this.aracSiparisNo = aracSiparisNo;
            this.verilenLitre = verilenLitre;
            this.toplamTutar = toplamTutar;
            this.dosyaYolu = dosyaYolu;
            this.personel = personel;
        }
        public YakitDokum(int id, int isAkisNo, string firma, string donem, DateTime tarih, string plaka, string aracSiparisNo, double verilenLitre, double toplamTutar, string dosyaYolu,string personelAd)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.firma = firma;
            this.donem = donem;
            this.tarih = tarih;
            this.plaka = plaka;
            this.aracSiparisNo = aracSiparisNo;
            this.verilenLitre = verilenLitre;
            this.toplamTutar = toplamTutar;
            this.dosyaYolu = dosyaYolu;
            this.personel = personelAd;
        }
    }
}
