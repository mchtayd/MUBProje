using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.IdariIsler
{
    public class DuranVarlikKayit
    {
        int id, isAkisNo; string dvSahibi, butceKodu, dvEtiketNo, dvGrubu, dvTanim, miktar; string marka, model, seriNo, kalGerek, satNo, saticiFirma, tarih; string faturaNo; double fiyat; string aciklama,durumu; string dosyaYolu, fotoYolu, sayfa;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public string DvSahibi { get => dvSahibi; set => dvSahibi = value; }
        public string ButceKodu { get => butceKodu; set => butceKodu = value; }
        public string DvEtiketNo { get => dvEtiketNo; set => dvEtiketNo = value; }
        public string DvGrubu { get => dvGrubu; set => dvGrubu = value; }
        public string DvTanim { get => dvTanim; set => dvTanim = value; }
        public string Miktar { get => miktar; set => miktar = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public string SeriNo { get => seriNo; set => seriNo = value; }
        public string KalGerek { get => kalGerek; set => kalGerek = value; }
        public string SatNo { get => satNo; set => satNo = value; }
        public string SaticiFirma { get => saticiFirma; set => saticiFirma = value; }
        public string Tarih { get => tarih; set => tarih = value; }
        public string FaturaNo { get => faturaNo; set => faturaNo = value; }
        public double Fiyat { get => fiyat; set => fiyat = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string FotoYolu { get => fotoYolu; set => fotoYolu = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }
        public string Durumu { get => durumu; set => durumu = value; }

        public DuranVarlikKayit(int id, int isAkisNo, string dvSahibi, string butceKodu, string dvEtiketNo, string dvGrubu, string dvTanim, string miktar, string marka, string model, string seriNo, string kalGerek, string satNo, string saticiFirma, string tarih, string faturaNo, double fiyat, string aciklama, string durumu,string dosyaYolu, string fotoYolu, string sayfa)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.dvSahibi = dvSahibi;
            this.butceKodu = butceKodu;
            this.dvEtiketNo = dvEtiketNo;
            this.dvGrubu = dvGrubu;
            this.dvTanim = dvTanim;
            this.miktar = miktar;
            this.marka = marka;
            this.model = model;
            this.seriNo = seriNo;
            this.kalGerek = kalGerek;
            this.satNo = satNo;
            this.saticiFirma = saticiFirma;
            this.tarih = tarih;
            this.faturaNo = faturaNo;
            this.fiyat = fiyat;
            this.aciklama = aciklama;
            this.durumu = durumu;
            this.dosyaYolu = dosyaYolu;
            this.fotoYolu = fotoYolu;
            this.sayfa = sayfa;
        }

        public DuranVarlikKayit(int isAkisNo, string dvSahibi, string butceKodu, string dvEtiketNo, string dvGrubu, string dvTanim, string miktar, string marka, string model, string seriNo, string kalGerek, string satNo, string saticiFirma, string tarih, string faturaNo, double fiyat, string aciklama, string durumu,string dosyaYolu, string fotoYolu)
        {
            this.isAkisNo = isAkisNo;
            this.dvSahibi = dvSahibi;
            this.butceKodu = butceKodu;
            this.dvEtiketNo = dvEtiketNo;
            this.dvGrubu = dvGrubu;
            this.dvTanim = dvTanim;
            this.miktar = miktar;
            this.marka = marka;
            this.model = model;
            this.seriNo = seriNo;
            this.kalGerek = kalGerek;
            this.satNo = satNo;
            this.saticiFirma = saticiFirma;
            this.tarih = tarih;
            this.faturaNo = faturaNo;
            this.fiyat = fiyat;
            this.aciklama = aciklama;
            this.durumu = durumu;
            this.dosyaYolu = dosyaYolu;
            this.fotoYolu = fotoYolu;
        }

    }

}
