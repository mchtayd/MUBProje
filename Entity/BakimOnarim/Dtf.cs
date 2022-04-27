using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class Dtf
    {
        int id, isAkisNo; string adiSoyadi; DateTime kayitTarihi; string donem, butceKodu, abfNo, usBolgesi, projeKodu, garantiDurumu, isKategorisi, isTanimi, stokNo, tanim, seriNo, onarimYeri, altYukleniciFirma, firmaSorumlusu; DateTime isinVerildigiTarih, isBaslamaTarihi, isBitisTarihi; string yapilanIslemler, dosyaYolu;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public string AdiSoyadi { get => adiSoyadi; set => adiSoyadi = value; }
        public DateTime KayitTarihi { get => kayitTarihi; set => kayitTarihi = value; }
        public string Donem { get => donem; set => donem = value; }
        public string ButceKodu { get => butceKodu; set => butceKodu = value; }
        public string AbfNo { get => abfNo; set => abfNo = value; }
        public string UsBolgesi { get => usBolgesi; set => usBolgesi = value; }
        public string ProjeKodu { get => projeKodu; set => projeKodu = value; }
        public string GarantiDurumu { get => garantiDurumu; set => garantiDurumu = value; }
        public string IsKategorisi { get => isKategorisi; set => isKategorisi = value; }
        public string IsTanimi { get => isTanimi; set => isTanimi = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string OnarimYeri { get => onarimYeri; set => onarimYeri = value; }
        public string AltYukleniciFirma { get => altYukleniciFirma; set => altYukleniciFirma = value; }
        public string FirmaSorumlusu { get => firmaSorumlusu; set => firmaSorumlusu = value; }
        public DateTime IsinVerildigiTarih { get => isinVerildigiTarih; set => isinVerildigiTarih = value; }
        public DateTime IsBaslamaTarihi { get => isBaslamaTarihi; set => isBaslamaTarihi = value; }
        public DateTime IsBitisTarihi { get => isBitisTarihi; set => isBitisTarihi = value; }
        public string YapilanIslemler { get => yapilanIslemler; set => yapilanIslemler = value; }
        public string SeriNo { get => seriNo; set => seriNo = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }

        public Dtf(int id, int isAkisNo, string adiSoyadi, DateTime kayitTarihi, string donem, string butceKodu, string abfNo, string usBolgesi, string projeKodu, string garantiDurumu, string isKategorisi, string isTanimi, string stokNo, string tanim, string seriNo, string onarimYeri, string altYukleniciFirma, string firmaSorumlusu, DateTime isinVerildigiTarih, DateTime isBaslamaTarihi, DateTime isBitisTarihi, string yapilanIslemler,string dosyaYolu)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.adiSoyadi = adiSoyadi;
            this.kayitTarihi = kayitTarihi;
            this.donem = donem;
            this.butceKodu = butceKodu;
            this.abfNo = abfNo;
            this.usBolgesi = usBolgesi;
            this.projeKodu = projeKodu;
            this.garantiDurumu = garantiDurumu;
            this.isKategorisi = isKategorisi;
            this.isTanimi = isTanimi;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.onarimYeri = onarimYeri;
            this.altYukleniciFirma = altYukleniciFirma;
            this.firmaSorumlusu = firmaSorumlusu;
            this.isinVerildigiTarih = isinVerildigiTarih;
            this.isBaslamaTarihi = isBaslamaTarihi;
            this.isBitisTarihi = isBitisTarihi;
            this.yapilanIslemler = yapilanIslemler;
            this.seriNo = seriNo;
            this.dosyaYolu = dosyaYolu;
        }

        public Dtf(int isAkisNo, string adiSoyadi, DateTime kayitTarihi, string donem, string butceKodu, string abfNo, string usBolgesi, string projeKodu, string garantiDurumu, string isKategorisi, string isTanimi, string stokNo, string tanim, string seriNo, string onarimYeri, string altYukleniciFirma, string firmaSorumlusu, DateTime isinVerildigiTarih,string dosyaYolu)
        {
            this.isAkisNo = isAkisNo;
            this.adiSoyadi = adiSoyadi;
            this.kayitTarihi = kayitTarihi;
            this.donem = donem;
            this.butceKodu = butceKodu;
            this.abfNo = abfNo;
            this.usBolgesi = usBolgesi;
            this.projeKodu = projeKodu;
            this.garantiDurumu = garantiDurumu;
            this.isKategorisi = isKategorisi;
            this.isTanimi = isTanimi;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.onarimYeri = onarimYeri;
            this.altYukleniciFirma = altYukleniciFirma;
            this.firmaSorumlusu = firmaSorumlusu;
            this.isinVerildigiTarih = isinVerildigiTarih;
            this.seriNo = seriNo;
            this.dosyaYolu = dosyaYolu;
        }

        public Dtf(int id, DateTime isBaslamaTarihi, DateTime isBitisTarihi, string yapilanIslemler)
        {
            this.id = id;
            this.isBaslamaTarihi = isBaslamaTarihi;
            this.isBitisTarihi = isBitisTarihi;
            this.yapilanIslemler = yapilanIslemler;
        }
    }
}
