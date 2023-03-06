using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class AracBakim
    {
        int id, isAkisNo; string plaka,marka, modelYili, motorNo, saseNo, mulkiyetBilgileri, siparisNo; DateTime projeTahsisTarihi; string kullanildigiBolum, zimmetliPersonel; int km; string bakimNedeni; DateTime talepTarihi; string bakYapanFirma, arizaAciklamasi; DateTime tamamlanmaTarih; string sonucAciklama; double tutar; string dosyaYolu, sayfa, teslimPersonel, teslimPersonelBolum; string gecenSure;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public string Marka { get => marka; set => marka = value; }
        public string ModelYili { get => modelYili; set => modelYili = value; }
        public string MotorNo { get => motorNo; set => motorNo = value; }
        public string SaseNo { get => saseNo; set => saseNo = value; }
        public string MulkiyetBilgileri { get => mulkiyetBilgileri; set => mulkiyetBilgileri = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public DateTime ProjeTahsisTarihi { get => projeTahsisTarihi; set => projeTahsisTarihi = value; }
        public string KullanildigiBolum { get => kullanildigiBolum; set => kullanildigiBolum = value; }
        public string ZimmetliPersonel { get => zimmetliPersonel; set => zimmetliPersonel = value; }
        public int Km { get => km; set => km = value; }
        public string BakimNedeni { get => bakimNedeni; set => bakimNedeni = value; }
        public DateTime TalepTarihi { get => talepTarihi; set => talepTarihi = value; }
        public string BakYapanFirma { get => bakYapanFirma; set => bakYapanFirma = value; }
        public string ArizaAciklamasi { get => arizaAciklamasi; set => arizaAciklamasi = value; }
        public DateTime TamamlanmaTarih { get => tamamlanmaTarih; set => tamamlanmaTarih = value; }
        public string SonucAciklama { get => sonucAciklama; set => sonucAciklama = value; }
        public double Tutar { get => tutar; set => tutar = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }
        public string TeslimPersonel { get => teslimPersonel; set => teslimPersonel = value; }
        public string TeslimPersonelBolum { get => teslimPersonelBolum; set => teslimPersonelBolum = value; }
        public string GecenSure { get => gecenSure; set => gecenSure = value; }

        // LİST
        public AracBakim(int id, int isAkisNo, string plaka, string marka, string modelYili, string motorNo, string saseNo, string mulkiyetBilgileri, string siparisNo, DateTime projeTahsisTarihi, string kullanildigiBolum, string zimmetliPersonel, int km, string bakimNedeni, DateTime talepTarihi, string bakYapanFirma, string arizaAciklamasi, DateTime tamamlanmaTarih, string sonucAciklama, double tutar, string dosyaYolu,string sayfa,string teslimPersonel,string teslimPersonelBolum)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.plaka = plaka;
            this.marka = marka;
            this.modelYili = modelYili;
            this.motorNo = motorNo;
            this.saseNo = saseNo;
            this.mulkiyetBilgileri = mulkiyetBilgileri;
            this.siparisNo = siparisNo;
            this.projeTahsisTarihi = projeTahsisTarihi;
            this.kullanildigiBolum = kullanildigiBolum;
            this.zimmetliPersonel = zimmetliPersonel;
            this.km = km;
            this.bakimNedeni = bakimNedeni;
            this.talepTarihi = talepTarihi;
            this.bakYapanFirma = bakYapanFirma;
            this.arizaAciklamasi = arizaAciklamasi;
            this.tamamlanmaTarih = tamamlanmaTarih;
            this.sonucAciklama = sonucAciklama;
            this.tutar = tutar;
            this.dosyaYolu = dosyaYolu;
            this.sayfa = sayfa;
            this.teslimPersonel = teslimPersonel;
            this.teslimPersonelBolum = teslimPersonelBolum;
        }
        // KAYIT KAPAT
        public AracBakim(string bakYapanFirma, DateTime tamamlanmaTarih, string sonucAciklama, double tutar)
        {
            this.bakYapanFirma = bakYapanFirma;
            this.tamamlanmaTarih = tamamlanmaTarih;
            this.sonucAciklama = sonucAciklama;
            this.tutar = tutar;
        }
        // KAYDET
        public AracBakim(int isAkisNo, string plaka,string marka, string modelYili, string motorNo, string saseNo, string mulkiyetBilgileri, string siparisNo, DateTime projeTahsisTarihi, string kullanildigiBolum, string zimmetliPersonel, int km, string bakimNedeni, DateTime talepTarihi, string arizaAciklamasi, string dosyaYolu, string teslimPersonel, string teslimPersonelBolum)
        {
            this.IsAkisNo = isAkisNo;
            this.plaka = plaka;
            this.Marka = marka;
            this.ModelYili = modelYili;
            this.MotorNo = motorNo;
            this.SaseNo = saseNo;
            this.MulkiyetBilgileri = mulkiyetBilgileri;
            this.SiparisNo = siparisNo;
            this.ProjeTahsisTarihi = projeTahsisTarihi;
            this.KullanildigiBolum = kullanildigiBolum;
            this.ZimmetliPersonel = zimmetliPersonel;
            this.Km = km;
            this.BakimNedeni = bakimNedeni;
            this.TalepTarihi = talepTarihi;
            this.ArizaAciklamasi = arizaAciklamasi;
            this.DosyaYolu = dosyaYolu;
            this.teslimPersonel = teslimPersonel;
            this.teslimPersonelBolum = teslimPersonelBolum;
        }
        // GÜNCELLE VE ESKİ KAYIT
        public AracBakim(int isAkisNo, string plaka, string marka, string modelYili, string motorNo, string saseNo, string mulkiyetBilgileri, string siparisNo, DateTime projeTahsisTarihi, string kullanildigiBolum, string zimmetliPersonel, int km, string bakimNedeni, DateTime talepTarihi, string bakYapanFirma, string arizaAciklamasi, DateTime tamamlanmaTarih, string sonucAciklama, double tutar, string dosyaYolu, string teslimPersonel, string teslimPersonelBolum)
        {
            this.IsAkisNo = isAkisNo;
            this.plaka = plaka;
            this.marka = marka;
            this.modelYili = modelYili;
            this.motorNo = motorNo;
            this.saseNo = saseNo;
            this.mulkiyetBilgileri = mulkiyetBilgileri;
            this.siparisNo = siparisNo;
            this.projeTahsisTarihi = projeTahsisTarihi;
            this.kullanildigiBolum = kullanildigiBolum;
            this.zimmetliPersonel = zimmetliPersonel;
            this.km = km;
            this.bakimNedeni = bakimNedeni;
            this.talepTarihi = talepTarihi;
            this.bakYapanFirma = bakYapanFirma;
            this.arizaAciklamasi = arizaAciklamasi;
            this.tamamlanmaTarih = tamamlanmaTarih;
            this.sonucAciklama = sonucAciklama;
            this.tutar = tutar;
            this.dosyaYolu = dosyaYolu;
            this.teslimPersonel = teslimPersonel;
            this.teslimPersonelBolum = teslimPersonelBolum;
        }

        public AracBakim(string plaka, string marka, string bakimNedeni, string arizaAciklamasi, DateTime talepTarihi, string gecenSure)
        {
            this.plaka = plaka;
            this.marka = marka;
            this.bakimNedeni = bakimNedeni;
            this.arizaAciklamasi = arizaAciklamasi;
            this.talepTarihi = talepTarihi;
            this.gecenSure = gecenSure;
        }
    }
}
