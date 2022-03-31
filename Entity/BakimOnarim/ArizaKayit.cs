﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class ArizaKayit
    {
        int id, isAkisNo, abfFormNo; string proje, bolgeAdi, bolukKomutani, telefonNo, birlikAdresi, il, ilce, bildirilenAriza, arizaiBildirenPersonel, abRutbesi, abGorevi, abTelefon; DateTime abTarihSaat; string aBAlanPersonel, bildirimKanali, arizaAciklama, gorevAtanacakPersonel, islemAdimi, dosyaYolu, garantiDurumu, lojistikSorumluPersonel, lojRutbesi, lojGorevi, lojTarihi, tespitEdilenAriza, acmaOnayiVeren, csSiparisNo, bildirimNo, crmNo, bildirimMailTarihi, siparisNo,
            stokNo, tanim, seriNo, kategori, ilgiliFirma, bildirimTuru, pypNo, sorumluPersonel, islemTuru, hesaplama;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public int AbfFormNo { get => abfFormNo; set => abfFormNo = value; }
        public string Proje { get => proje; set => proje = value; }
        public string BolgeAdi { get => bolgeAdi; set => bolgeAdi = value; }
        public string BolukKomutani { get => bolukKomutani; set => bolukKomutani = value; }
        public string TelefonNo { get => telefonNo; set => telefonNo = value; }
        public string BirlikAdresi { get => birlikAdresi; set => birlikAdresi = value; }
        public string Il { get => il; set => il = value; }
        public string Ilce { get => ilce; set => ilce = value; }
        public string BildirilenAriza { get => bildirilenAriza; set => bildirilenAriza = value; }
        public string ArizaiBildirenPersonel { get => arizaiBildirenPersonel; set => arizaiBildirenPersonel = value; }
        public string AbRutbesi { get => abRutbesi; set => abRutbesi = value; }
        public string AbGorevi { get => abGorevi; set => abGorevi = value; }
        public string AbTelefon { get => abTelefon; set => abTelefon = value; }
        public DateTime AbTarihSaat { get => abTarihSaat; set => abTarihSaat = value; }
        public string ABAlanPersonel { get => aBAlanPersonel; set => aBAlanPersonel = value; }
        public string BildirimKanali { get => bildirimKanali; set => bildirimKanali = value; }
        public string ArizaAciklama { get => arizaAciklama; set => arizaAciklama = value; }
        public string GorevAtanacakPersonel { get => gorevAtanacakPersonel; set => gorevAtanacakPersonel = value; }
        public string IslemAdimi { get => islemAdimi; set => islemAdimi = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string GarantiDurumu { get => garantiDurumu; set => garantiDurumu = value; }
        public string LojistikSorumluPersonel { get => lojistikSorumluPersonel; set => lojistikSorumluPersonel = value; }
        public string LojRutbesi { get => lojRutbesi; set => lojRutbesi = value; }
        public string LojGorevi { get => lojGorevi; set => lojGorevi = value; }
        public string LojTarihi { get => lojTarihi; set => lojTarihi = value; }
        public string TespitEdilenAriza { get => tespitEdilenAriza; set => tespitEdilenAriza = value; }
        public string AcmaOnayiVeren { get => acmaOnayiVeren; set => acmaOnayiVeren = value; }
        public string CsSiparisNo { get => csSiparisNo; set => csSiparisNo = value; }
        public string BildirimNo { get => bildirimNo; set => bildirimNo = value; }
        public string CrmNo { get => crmNo; set => crmNo = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public string BildirimMailTarihi { get => bildirimMailTarihi; set => bildirimMailTarihi = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string SeriNo { get => seriNo; set => seriNo = value; }
        public string Kategori { get => kategori; set => kategori = value; }
        public string IlgiliFirma { get => ilgiliFirma; set => ilgiliFirma = value; }
        public string BildirimTuru { get => bildirimTuru; set => bildirimTuru = value; }
        public string PypNo { get => pypNo; set => pypNo = value; }
        public string SorumluPersonel { get => sorumluPersonel; set => sorumluPersonel = value; }
        public string IslemTuru { get => islemTuru; set => islemTuru = value; }
        public string Hesaplama { get => hesaplama; set => hesaplama = value; }

        public ArizaKayit(int isAkisNo, int abfFormNo, string proje, string bolgeAdi, string bolukKomutani, string telefonNo, string birlikAdresi, string il, string ilce, string bildirilenAriza, string arizaiBildirenPersonel, string abRutbesi, string abGorevi, string abTelefon, DateTime abTarihSaat, string aBAlanPersonel, string bildirimKanali, string arizaAciklama, string gorevAtanacakPersonel, string islemAdimi, string dosyaYolu,string siparisNo)
        {
            this.isAkisNo = isAkisNo;
            this.abfFormNo = abfFormNo;
            this.proje = proje;
            this.bolgeAdi = bolgeAdi;
            this.bolukKomutani = bolukKomutani;
            this.telefonNo = telefonNo;
            this.birlikAdresi = birlikAdresi;
            this.il = il;
            this.ilce = ilce;
            this.bildirilenAriza = bildirilenAriza;
            this.arizaiBildirenPersonel = arizaiBildirenPersonel;
            this.abRutbesi = abRutbesi;
            this.abGorevi = abGorevi;
            this.abTelefon = abTelefon;
            this.abTarihSaat = abTarihSaat;
            this.aBAlanPersonel = aBAlanPersonel;
            this.bildirimKanali = bildirimKanali;
            this.arizaAciklama = arizaAciklama;
            this.gorevAtanacakPersonel = gorevAtanacakPersonel;
            this.islemAdimi = islemAdimi;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
        }

        public ArizaKayit(int id, int isAkisNo, int abfFormNo, string proje, string bolgeAdi, string bolukKomutani, string telefonNo, string birlikAdresi, string il, string ilce, string bildirilenAriza, string arizaiBildirenPersonel, string abRutbesi, string abGorevi, string abTelefon, DateTime abTarihSaat, string aBAlanPersonel, string bildirimKanali, string arizaAciklama, string gorevAtanacakPersonel, string islemAdimi, string dosyaYolu, string garantiDurumu, string lojistikSorumluPersonel, string lojRutbesi, string lojGorevi, string lojTarihi, string tespitEdilenAriza, string acmaOnayiVeren, string csSiparisNo, string bildirimNo, string crmNo, string bildirimMailTarihi, string siparisNo, string stokNo, string tanim, string seriNo, string kategori, string ilgiliFirma, string bildirimTuru, string pypNo, string sorumluPersonel, string islemTuru, string hesaplama)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.abfFormNo = abfFormNo;
            this.proje = proje;
            this.bolgeAdi = bolgeAdi;
            this.bolukKomutani = bolukKomutani;
            this.telefonNo = telefonNo;
            this.birlikAdresi = birlikAdresi;
            this.il = il;
            this.ilce = ilce;
            this.bildirilenAriza = bildirilenAriza;
            this.arizaiBildirenPersonel = arizaiBildirenPersonel;
            this.abRutbesi = abRutbesi;
            this.abGorevi = abGorevi;
            this.abTelefon = abTelefon;
            this.abTarihSaat = abTarihSaat;
            this.aBAlanPersonel = aBAlanPersonel;
            this.bildirimKanali = bildirimKanali;
            this.arizaAciklama = arizaAciklama;
            this.gorevAtanacakPersonel = gorevAtanacakPersonel;
            this.islemAdimi = islemAdimi;
            this.dosyaYolu = dosyaYolu;
            this.garantiDurumu = garantiDurumu;
            this.lojistikSorumluPersonel = lojistikSorumluPersonel;
            this.lojRutbesi = lojRutbesi;
            this.lojGorevi = lojGorevi;
            this.lojTarihi = lojTarihi;
            this.tespitEdilenAriza = tespitEdilenAriza;
            this.acmaOnayiVeren = acmaOnayiVeren;
            this.csSiparisNo = csSiparisNo;
            this.bildirimNo = bildirimNo;
            this.crmNo = crmNo;
            this.bildirimMailTarihi = bildirimMailTarihi;
            this.siparisNo = siparisNo;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.seriNo = seriNo;
            this.kategori = kategori;
            this.ilgiliFirma = ilgiliFirma;
            this.bildirimTuru = bildirimTuru;
            this.pypNo = pypNo;
            this.sorumluPersonel = sorumluPersonel;
            this.islemTuru = islemTuru;
            this.hesaplama = hesaplama;
        }

        public ArizaKayit(int id, string garantiDurumu,string lojistikSorumluPersonel, string lojRutbesi, string lojGorevi, string lojTarihi, string tespitEdilenAriza, string acmaOnayiVeren)
        {
            this.id = id;
            this.garantiDurumu = garantiDurumu;
            this.lojistikSorumluPersonel = lojistikSorumluPersonel;
            this.lojRutbesi = lojRutbesi;
            this.lojGorevi = lojGorevi;
            this.lojTarihi = lojTarihi;
            this.tespitEdilenAriza = tespitEdilenAriza;
            this.acmaOnayiVeren = acmaOnayiVeren;
        }

        public ArizaKayit(int id, string csSiparisNo, string bildirimNo, string crmNo, string bildirimMailTarihi)
        {
            this.id = id;
            this.csSiparisNo = csSiparisNo;
            this.bildirimNo = bildirimNo;
            this.crmNo = crmNo;
            this.bildirimMailTarihi = bildirimMailTarihi;
        }

        public ArizaKayit(int id, string stokNo, string tanim, string seriNo, string kategori, string ilgiliFirma, string bildirimTuru, string pypNo, string sorumluPersonel, string islemTuru, string hesaplama)
        {
            this.id = id;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.seriNo = seriNo;
            this.kategori = kategori;
            this.ilgiliFirma = ilgiliFirma;
            this.bildirimTuru = bildirimTuru;
            this.pypNo = pypNo;
            this.sorumluPersonel = sorumluPersonel;
            this.islemTuru = islemTuru;
            this.hesaplama = hesaplama;
        }
    }
}
