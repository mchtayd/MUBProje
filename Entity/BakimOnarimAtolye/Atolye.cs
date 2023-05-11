using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarimAtolye
{
    public class Atolye
    {
        int id, abfNo; string stokNoUst, tanimUst, seriNoUst, garantiDurumu, bildirimNo, crmNo, kategori, bolgeAdi, proje, bildirilenAriza, icSiparisNo; DateTime cekildigiTarih, siparisAcmaTarihi; string modifikasyonlar, notlar, islemAdimi, siparisNo, bulunduguIslemAdimi; int arizaDurum; string gecensure; DateTime kapatmaTarihi; string dosyaYolu, atolyeKategori, islemAdimiSorumlusu;

        public int Id { get => id; set => id = value; }
        public int AbfNo { get => abfNo; set => abfNo = value; }
        public string StokNoUst { get => stokNoUst; set => stokNoUst = value; }
        public string TanimUst { get => tanimUst; set => tanimUst = value; }
        public string SeriNoUst { get => seriNoUst; set => seriNoUst = value; }
        public string GarantiDurumu { get => garantiDurumu; set => garantiDurumu = value; }
        public string BildirimNo { get => bildirimNo; set => bildirimNo = value; }
        public string CrmNo { get => crmNo; set => crmNo = value; }
        public string Kategori { get => kategori; set => kategori = value; }
        public string BolgeAdi { get => bolgeAdi; set => bolgeAdi = value; }
        public string Proje { get => proje; set => proje = value; }
        public string BildirilenAriza { get => bildirilenAriza; set => bildirilenAriza = value; }
        public string IcSiparisNo { get => icSiparisNo; set => icSiparisNo = value; }
        public DateTime CekildigiTarih { get => cekildigiTarih; set => cekildigiTarih = value; }
        public DateTime SiparisAcmaTarihi { get => siparisAcmaTarihi; set => siparisAcmaTarihi = value; }
        public string Modifikasyonlar { get => modifikasyonlar; set => modifikasyonlar = value; }
        public string Notlar { get => notlar; set => notlar = value; }
        public string IslemAdimi { get => islemAdimi; set => islemAdimi = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public string BulunduguIslemAdimi { get => bulunduguIslemAdimi; set => bulunduguIslemAdimi = value; }
        public int ArizaDurum { get => arizaDurum; set => arizaDurum = value; }
        public string Gecensure { get => gecensure; set => gecensure = value; }
        public DateTime KapatmaTarihi { get => kapatmaTarihi; set => kapatmaTarihi = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string AtolyeKategori { get => atolyeKategori; set => atolyeKategori = value; }
        public string IslemAdimiSorumlusu { get => islemAdimiSorumlusu; set => islemAdimiSorumlusu = value; }

        public Atolye(int id, int abfNo, string stokNoUst, string tanimUst, string seriNoUst, string garantiDurumu, string bildirimNo, string crmNo, string kategori, string bolgeAdi, string proje, string bildirilenAriza, string icSiparisNo, DateTime cekildigiTarih, DateTime siparisAcmaTarihi, string modifikasyonlar, string notlar, string islemAdimi, string siparisNo, string gecensure,DateTime kapatmaTarihi,string dosyaYolu,string atolyeKategori, string islemAdimiSorumlusu)
        {
            this.id = id;
            this.abfNo = abfNo;
            this.stokNoUst = stokNoUst;
            this.tanimUst = tanimUst;
            this.seriNoUst = seriNoUst;
            this.garantiDurumu = garantiDurumu;
            this.bildirimNo = bildirimNo;
            this.crmNo = crmNo;
            this.kategori = kategori;
            this.bolgeAdi = bolgeAdi;
            this.proje = proje;
            this.bildirilenAriza = bildirilenAriza;
            this.icSiparisNo = icSiparisNo;
            this.cekildigiTarih = cekildigiTarih;
            this.siparisAcmaTarihi = siparisAcmaTarihi;
            this.modifikasyonlar = modifikasyonlar;
            this.notlar = notlar;
            this.islemAdimi = islemAdimi;
            this.siparisNo = siparisNo;
            this.gecensure = gecensure;
            this.kapatmaTarihi = kapatmaTarihi;
            this.dosyaYolu = dosyaYolu;
            this.atolyeKategori = atolyeKategori;
            this.islemAdimiSorumlusu = islemAdimiSorumlusu;
            //this.
        }

        public Atolye(int abfNo, string stokNoUst, string tanimUst, string seriNoUst, string garantiDurumu, string bildirimNo, string crmNo, string kategori, string bolgeAdi, string proje, string bildirilenAriza, string icSiparisNo, DateTime cekildigiTarih, DateTime siparisAcmaTarihi, string modifikasyonlar, string notlar, string islemAdimi, string siparisNo,string dosyaYolu,string atolyeKategori)
        {
            this.abfNo = abfNo;
            this.stokNoUst = stokNoUst;
            this.tanimUst = tanimUst;
            this.seriNoUst = seriNoUst;
            this.garantiDurumu = garantiDurumu;
            this.bildirimNo = bildirimNo;
            this.crmNo = crmNo;
            this.kategori = kategori;
            this.bolgeAdi = bolgeAdi;
            this.proje = proje;
            this.bildirilenAriza = bildirilenAriza;
            this.icSiparisNo = icSiparisNo;
            this.cekildigiTarih = cekildigiTarih;
            this.siparisAcmaTarihi = siparisAcmaTarihi;
            this.modifikasyonlar = modifikasyonlar;
            this.notlar = notlar;
            this.islemAdimi = islemAdimi;
            this.siparisNo = siparisNo;
            this.dosyaYolu = dosyaYolu;
            this.atolyeKategori = atolyeKategori;
        }

        public Atolye(string stokNoUst, string tanimUst, string seriNoUst, string garantiDurumu, string bildirimNo, string crmNo, string kategori, string bolgeAdi, string proje, string bildirilenAriza,string bulunduguIslemAdimi,int arizaDurumu)
        {
            this.stokNoUst = stokNoUst;
            this.tanimUst = tanimUst;
            this.seriNoUst = seriNoUst;
            this.garantiDurumu = garantiDurumu;
            this.bildirimNo = bildirimNo;
            this.crmNo = crmNo;
            this.kategori = kategori;
            this.bolgeAdi = bolgeAdi;
            this.proje = proje;
            this.bildirilenAriza = bildirilenAriza;
            this.bulunduguIslemAdimi = bulunduguIslemAdimi;
            this.arizaDurum = arizaDurumu;
            
        }

        public Atolye(string atolyeKategori)
        {
            this.atolyeKategori = atolyeKategori;
        }
    }
}
