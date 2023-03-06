using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class Okf
    {
        int id, isAkisNo; string kayitYapan; DateTime kayitTarihi; string abfNo; DateTime arizaTarihi; string usBolgesi, projeKodu, garantiDurumu, ubKomutani, komutanTel, birlikAdresi, il, ilce, ustStok, ustTanim, ustSeriNo, bildirilenAriza, arizaDurum, arizaNedeni, genelOneriler; double toplamTutar; string dosyaYolu, yapilacakIslemler, bildirimNo;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public string KayitYapan { get => kayitYapan; set => kayitYapan = value; }
        public DateTime KayitTarihi { get => kayitTarihi; set => kayitTarihi = value; }
        public string AbfNo { get => abfNo; set => abfNo = value; }
        public DateTime ArizaTarihi { get => arizaTarihi; set => arizaTarihi = value; }
        public string UsBolgesi { get => usBolgesi; set => usBolgesi = value; }
        public string ProjeKodu { get => projeKodu; set => projeKodu = value; }
        public string GarantiDurumu { get => garantiDurumu; set => garantiDurumu = value; }
        public string UbKomutani { get => ubKomutani; set => ubKomutani = value; }
        public string KomutanTel { get => komutanTel; set => komutanTel = value; }
        public string BirlikAdresi { get => birlikAdresi; set => birlikAdresi = value; }
        public string Il { get => il; set => il = value; }
        public string Ilce { get => ilce; set => ilce = value; }
        public string UstStok { get => ustStok; set => ustStok = value; }
        public string UstTanim { get => ustTanim; set => ustTanim = value; }
        public string UstSeriNo { get => ustSeriNo; set => ustSeriNo = value; }
        public string BildirilenAriza { get => bildirilenAriza; set => bildirilenAriza = value; }
        public string ArizaDurum { get => arizaDurum; set => arizaDurum = value; }
        public string ArizaNedeni { get => arizaNedeni; set => arizaNedeni = value; }
        public string GenelOneriler { get => genelOneriler; set => genelOneriler = value; }
        public double ToplamTutar { get => toplamTutar; set => toplamTutar = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string YapilacakIslemler { get => yapilacakIslemler; set => yapilacakIslemler = value; }
        public string BildirimNo { get => bildirimNo; set => bildirimNo = value; }

        public Okf(int id, int isAkisNo, string kayitYapan, DateTime kayitTarihi, string abfNo, DateTime arizaTarihi, string usBolgesi, string projeKodu, string garantiDurumu, string ubKomutani, string komutanTel, string birlikAdresi, string il, string ilce, string ustStok, string ustTanim, string ustSeriNo, string bildirilenAriza, string arizaDurum, string arizaNedeni, string genelOneriler, double toplamTutar, string dosyaYolu, string bildirimNo)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.kayitYapan = kayitYapan;
            this.kayitTarihi = kayitTarihi;
            this.abfNo = abfNo;
            this.arizaTarihi = arizaTarihi;
            this.usBolgesi = usBolgesi;
            this.projeKodu = projeKodu;
            this.garantiDurumu = garantiDurumu;
            this.ubKomutani = ubKomutani;
            this.komutanTel = komutanTel;
            this.birlikAdresi = birlikAdresi;
            this.il = il;
            this.ilce = ilce;
            this.ustStok = ustStok;
            this.ustTanim = ustTanim;
            this.ustSeriNo = ustSeriNo;
            this.bildirilenAriza = bildirilenAriza;
            this.arizaDurum = arizaDurum;
            this.arizaNedeni = arizaNedeni;
            this.genelOneriler = genelOneriler;
            this.toplamTutar = toplamTutar;
            this.dosyaYolu = dosyaYolu;
            this.bildirimNo = bildirimNo;
        }

        public Okf(int isAkisNo, string kayitYapan, DateTime kayitTarihi, string abfNo, DateTime arizaTarihi, string usBolgesi, string projeKodu, string garantiDurumu, string ubKomutani, string komutanTel, string birlikAdresi, string il, string ilce, string ustStok, string ustTanim, string ustSeriNo, string bildirilenAriza, string arizaDurum, string arizaNedeni, string genelOneriler, double toplamTutar, string dosyaYolu, string bildirimNo)
        {
            this.isAkisNo = isAkisNo;
            this.kayitYapan = kayitYapan;
            this.kayitTarihi = kayitTarihi;
            this.abfNo = abfNo;
            this.arizaTarihi = arizaTarihi;
            this.usBolgesi = usBolgesi;
            this.projeKodu = projeKodu;
            this.garantiDurumu = garantiDurumu;
            this.ubKomutani = ubKomutani;
            this.komutanTel = komutanTel;
            this.birlikAdresi = birlikAdresi;
            this.il = il;
            this.ilce = ilce;
            this.ustStok = ustStok;
            this.ustTanim = ustTanim;
            this.ustSeriNo = ustSeriNo;
            this.bildirilenAriza = bildirilenAriza;
            this.arizaDurum = arizaDurum;
            this.arizaNedeni = arizaNedeni;
            this.genelOneriler = genelOneriler;
            this.toplamTutar = toplamTutar;
            this.dosyaYolu = dosyaYolu;
            this.bildirimNo = bildirimNo;
        }

        public Okf(int id, DateTime arizaTarihi, string usBolgesi, string projeKodu, string ubKomutani, string komutanTel, string birlikAdresi, string il, string ilce, string ustStok, string ustTanim, string ustSeriNo, string bildirilenAriza, string bildirimNo)
        {
            this.id = id;
            this.arizaTarihi = arizaTarihi;
            this.usBolgesi = usBolgesi;
            this.projeKodu = projeKodu;
            this.ubKomutani = ubKomutani;
            this.komutanTel = komutanTel;
            this.birlikAdresi = birlikAdresi;
            this.il = il;
            this.ilce = ilce;
            this.ustStok = ustStok;
            this.ustTanim = ustTanim;
            this.ustSeriNo = ustSeriNo;
            this.bildirilenAriza = bildirilenAriza;
            this.bildirimNo = bildirimNo;
        }

        public Okf(int id, string yapilacakIslemler)
        {
            this.id = id;
            this.yapilacakIslemler = yapilacakIslemler;
        }
    }
}
