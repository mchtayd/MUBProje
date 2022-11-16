using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class BolgeKayit
    {
        int id; string bolgeAdi, kodAdi, usBolgesiStok, proje; DateTime kabulTarihi; string guvenlikYazilimi, kesifGozetlemeTuru, yasamAlani, tabur, tugay, il, ilce, birlikAdresi; DateTime garantiBaslama, garantiBitis; string bolgeSorumlusu, depo, pypNo, siparisNo, dosyaYolu;

        public int Id { get => id; set => id = value; }
        public string BolgeAdi { get => bolgeAdi; set => bolgeAdi = value; }
        public string KodAdi { get => kodAdi; set => kodAdi = value; }
        public string UsBolgesiStok { get => usBolgesiStok; set => usBolgesiStok = value; }
        public DateTime KabulTarihi { get => kabulTarihi; set => kabulTarihi = value; }
        public string GuvenlikYazilimi { get => guvenlikYazilimi; set => guvenlikYazilimi = value; }
        public string KesifGozetlemeTuru { get => kesifGozetlemeTuru; set => kesifGozetlemeTuru = value; }
        public string YasamAlani { get => yasamAlani; set => yasamAlani = value; }
        public string Tabur { get => tabur; set => tabur = value; }
        public string Tugay { get => tugay; set => tugay = value; }
        public string Il { get => il; set => il = value; }
        public string Ilce { get => ilce; set => ilce = value; }
        public string BirlikAdresi { get => birlikAdresi; set => birlikAdresi = value; }
        public DateTime GarantiBaslama { get => garantiBaslama; set => garantiBaslama = value; }
        public DateTime GarantiBitis { get => garantiBitis; set => garantiBitis = value; }
        public string BolgeSorumlusu { get => bolgeSorumlusu; set => bolgeSorumlusu = value; }
        public string Depo { get => depo; set => depo = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string PypNo { get => pypNo; set => pypNo = value; }
        public string Proje { get => proje; set => proje = value; }

        public BolgeKayit(int id, string bolgeAdi, string kodAdi, string proje, string usBolgesiStok, DateTime kabulTarihi, string guvenlikYazilimi, string kesifGozetlemeTuru, string yasamAlani, string tabur, string tugay, string il, string ilce, string birlikAdresi, DateTime garantiBaslama, DateTime garantiBitis, string bolgeSorumlusu, string depo, string pypNo, string siparisNo, string dosyaYolu)
        {
            this.id = id;
            this.bolgeAdi = bolgeAdi;
            this.kodAdi = kodAdi;
            this.usBolgesiStok = usBolgesiStok;
            this.kabulTarihi = kabulTarihi;
            this.guvenlikYazilimi = guvenlikYazilimi;
            this.kesifGozetlemeTuru = kesifGozetlemeTuru;
            this.yasamAlani = yasamAlani;
            this.tabur = tabur;
            this.tugay = tugay;
            this.il = il;
            this.ilce = ilce;
            this.birlikAdresi = birlikAdresi;
            this.garantiBaslama = garantiBaslama;
            this.garantiBitis = garantiBitis;
            this.bolgeSorumlusu = bolgeSorumlusu;
            this.depo = depo;
            this.siparisNo = siparisNo;
            this.dosyaYolu = dosyaYolu;
            this.pypNo = pypNo;
            this.proje = proje;
        }

        public BolgeKayit(string bolgeAdi, string kodAdi, string proje, string usBolgesiStok, DateTime kabulTarihi, string guvenlikYazilimi, string kesifGozetlemeTuru, string yasamAlani, string tabur, string tugay, string il, string ilce, string birlikAdresi, DateTime garantiBaslama, DateTime garantiBitis, string bolgeSorumlusu, string depo, string pypNo, string siparisNo, string dosyaYolu)
        {
            this.bolgeAdi = bolgeAdi;
            this.kodAdi = kodAdi;
            this.usBolgesiStok = usBolgesiStok;
            this.kabulTarihi = kabulTarihi;
            this.guvenlikYazilimi = guvenlikYazilimi;
            this.kesifGozetlemeTuru = kesifGozetlemeTuru;
            this.yasamAlani = yasamAlani;
            this.tabur = tabur;
            this.tugay = tugay;
            this.il = il;
            this.ilce = ilce;
            this.birlikAdresi = birlikAdresi;
            this.garantiBaslama = garantiBaslama;
            this.garantiBitis = garantiBitis;
            this.bolgeSorumlusu = bolgeSorumlusu;
            this.depo = depo;
            this.siparisNo = siparisNo;
            this.dosyaYolu = dosyaYolu;
            this.pypNo = pypNo;
            this.proje = proje;
        }

        public BolgeKayit(int id, string bolgeAdi, string kodAdi, string proje, string usBolgesiStok, DateTime kabulTarihi, string guvenlikYazilimi, string kesifGozetlemeTuru, string yasamAlani, string tabur, string tugay, string il, string ilce, string birlikAdresi, string bolgeSorumlusu, string depo, string pypNo)
        {
            this.id = id;
            this.bolgeAdi = bolgeAdi;
            this.kodAdi = kodAdi;
            this.usBolgesiStok = usBolgesiStok;
            this.kabulTarihi = kabulTarihi;
            this.guvenlikYazilimi = guvenlikYazilimi;
            this.kesifGozetlemeTuru = kesifGozetlemeTuru;
            this.yasamAlani = yasamAlani;
            this.tabur = tabur;
            this.tugay = tugay;
            this.il = il;
            this.ilce = ilce;
            this.birlikAdresi = birlikAdresi;
            this.bolgeSorumlusu = bolgeSorumlusu;
            this.depo = depo;
            this.pypNo = pypNo;
            this.proje = proje;
        }
    }
}
