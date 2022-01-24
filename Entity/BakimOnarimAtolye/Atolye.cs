using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarimAtolye
{
    public class Atolye
    {
        int id, abfNo; string stokNoUst, tanimUst, seriNoUst, garantiDurumu, bildirimNo, crmNo, kategori, bolgeAdi, proje, bildirilenAriza, icSiparisNo; DateTime cekildigiTarih, siparisAcmaTarihi; string modifikasyonlar, notlar, islemAdimi, siparisNo;

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

        public Atolye(int id, int abfNo, string stokNoUst, string tanimUst, string seriNoUst, string garantiDurumu, string bildirimNo, string crmNo, string kategori, string bolgeAdi, string proje, string bildirilenAriza, string icSiparisNo, DateTime cekildigiTarih, DateTime siparisAcmaTarihi, string modifikasyonlar, string notlar, string islemAdimi, string siparisNo)
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
        }

        public Atolye(int abfNo, string stokNoUst, string tanimUst, string seriNoUst, string garantiDurumu, string bildirimNo, string crmNo, string kategori, string bolgeAdi, string proje, string bildirilenAriza, string icSiparisNo, DateTime cekildigiTarih, DateTime siparisAcmaTarihi, string modifikasyonlar, string notlar, string islemAdimi, string siparisNo)
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
        }

        public Atolye(string stokNoUst, string tanimUst, string seriNoUst, string garantiDurumu, string bildirimNo, string crmNo, string kategori, string bolgeAdi, string proje, string bildirilenAriza)
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
        }

    }
}
