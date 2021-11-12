using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class Arac
    {
        int id; string plaka; DateTime ilkTescilTarihi, tescilTarihi; string markasi, tipi, ticariAdi, modelYili, aracSinifi, cinsi, rengi, motorNo, saseNo, yakitCinsi, mulkiyetBilgileri, proje, siparisno, tasitTanima, arventoid; DateTime projeTahsisTarihi; int kmGiris, kmCikis; string projeCikisTarihi, projeCikisNedeni, dosyaYolu, sayfa, aciklama;

        public int Id { get => id; set => id = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public DateTime IlkTescilTarihi { get => ilkTescilTarihi; set => ilkTescilTarihi = value; }
        public DateTime TescilTarihi { get => tescilTarihi; set => tescilTarihi = value; }
        public string Markasi { get => markasi; set => markasi = value; }
        public string Tipi { get => tipi; set => tipi = value; }
        public string TicariAdi { get => ticariAdi; set => ticariAdi = value; }
        public string ModelYili { get => modelYili; set => modelYili = value; }
        public string AracSinifi { get => aracSinifi; set => aracSinifi = value; }
        public string Cinsi { get => cinsi; set => cinsi = value; }
        public string Rengi { get => rengi; set => rengi = value; }
        public string MotorNo { get => motorNo; set => motorNo = value; }
        public string SaseNo { get => saseNo; set => saseNo = value; }
        public string YakitCinsi { get => yakitCinsi; set => yakitCinsi = value; }
        public string MulkiyetBilgileri { get => mulkiyetBilgileri; set => mulkiyetBilgileri = value; }
        public string Proje { get => proje; set => proje = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }
        public string TasitTanima { get => tasitTanima; set => tasitTanima = value; }
        public string Arventoid { get => arventoid; set => arventoid = value; }
        public DateTime ProjeTahsisTarihi { get => projeTahsisTarihi; set => projeTahsisTarihi = value; }
        public string ProjeCikisTarihi { get => projeCikisTarihi; set => projeCikisTarihi = value; }
        public string ProjeCikisNedeni { get => projeCikisNedeni; set => projeCikisNedeni = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public int KmGiris { get => kmGiris; set => kmGiris = value; }
        public int KmCikis { get => kmCikis; set => kmCikis = value; }

        //list
        public Arac(int id, string plaka, DateTime ilkTescilTarihi, DateTime tescilTarihi, string markasi, string tipi, string ticariAdi, string modelYili, string aracSinifi, string cinsi, string rengi, string motorNo, string saseNo, string yakitCinsi, string mulkiyetBilgileri, string proje, string siparisno, string tasitTanima, string arventoid, DateTime projeTahsisTarihi, int kmGiris, int kmCikis, string projeCikisTarihi, string projeCikisNedeni, string dosyaYolu,string sayfa,string aciklama)
        {
            this.id = id;
            this.plaka = plaka;
            this.ilkTescilTarihi = ilkTescilTarihi;
            this.tescilTarihi = tescilTarihi;
            this.markasi = markasi;
            this.tipi = tipi;
            this.ticariAdi = ticariAdi;
            this.modelYili = modelYili;
            this.aracSinifi = aracSinifi;
            this.cinsi = cinsi;
            this.rengi = rengi;
            this.motorNo = motorNo;
            this.saseNo = saseNo;
            this.yakitCinsi = yakitCinsi;
            this.mulkiyetBilgileri = mulkiyetBilgileri;
            this.proje = proje;
            this.siparisno = siparisno;
            this.tasitTanima = tasitTanima;
            this.arventoid = arventoid;
            this.projeTahsisTarihi = projeTahsisTarihi;
            this.projeCikisTarihi = projeCikisTarihi;
            this.projeCikisNedeni = projeCikisNedeni;
            this.dosyaYolu = dosyaYolu;
            this.sayfa = sayfa;
            this.aciklama = aciklama;
            this.kmGiris = kmGiris;
            this.kmCikis = kmCikis;
        }
        // Kaydet
        public Arac(string plaka, DateTime ilkTescilTarihi, DateTime tescilTarihi, string markasi, string tipi, string ticariAdi, string modelYili, string aracSinifi, string cinsi, string rengi, string motorNo, string saseNo, string yakitCinsi, string mulkiyetBilgileri, string proje, string siparisno, string tasitTanima, string arventoid, DateTime projeTahsisTarihi, int kmGiris, string dosyaYolu,string aciklama)
        {
            this.plaka = plaka;
            this.ilkTescilTarihi = ilkTescilTarihi;
            this.tescilTarihi = tescilTarihi;
            this.markasi = markasi;
            this.tipi = tipi;
            this.ticariAdi = ticariAdi;
            this.modelYili = modelYili;
            this.aracSinifi = aracSinifi;
            this.cinsi = cinsi;
            this.rengi = rengi;
            this.motorNo = motorNo;
            this.saseNo = saseNo;
            this.yakitCinsi = yakitCinsi;
            this.mulkiyetBilgileri = mulkiyetBilgileri;
            this.proje = proje;
            this.siparisno = siparisno;
            this.tasitTanima = tasitTanima;
            this.arventoid = arventoid;
            this.projeTahsisTarihi = projeTahsisTarihi;
            this.dosyaYolu = dosyaYolu;
            this.aciklama = aciklama;
            this.kmGiris = kmGiris;
        }
        // güncelle
        public Arac(string plaka, DateTime ilkTescilTarihi, DateTime tescilTarihi, string markasi, string tipi, string ticariAdi, string modelYili, string aracSinifi, string cinsi, string rengi, string motorNo, string saseNo, string yakitCinsi, string mulkiyetBilgileri, string proje, string siparisno, string tasitTanima, string arventoid, DateTime projeTahsisTarihi, int kmGiris,int kmCikis,string projeCikisTarihi, string projeCikisNedeni, string dosyaYolu,string aciklama)
        {
            this.plaka = plaka;
            this.ilkTescilTarihi = ilkTescilTarihi;
            this.tescilTarihi = tescilTarihi;
            this.markasi = markasi;
            this.tipi = tipi;
            this.ticariAdi = ticariAdi;
            this.modelYili = modelYili;
            this.aracSinifi = aracSinifi;
            this.cinsi = cinsi;
            this.rengi = rengi;
            this.motorNo = motorNo;
            this.saseNo = saseNo;
            this.yakitCinsi = yakitCinsi;
            this.mulkiyetBilgileri = mulkiyetBilgileri;
            this.proje = proje;
            this.siparisno = siparisno;
            this.tasitTanima = tasitTanima;
            this.arventoid = arventoid;
            this.projeTahsisTarihi = projeTahsisTarihi;
            this.projeCikisTarihi = projeCikisTarihi;
            this.projeCikisNedeni = projeCikisNedeni;
            this.dosyaYolu = dosyaYolu;
            this.aciklama = aciklama;
            this.kmGiris = kmGiris;
            this.kmCikis = kmCikis;
        }

        public Arac(string projeCikisTarihi, string projeCikisNedeni,int kmCikis)
        {
            this.projeCikisTarihi = projeCikisTarihi;
            this.projeCikisNedeni = projeCikisNedeni;
            this.kmCikis = kmCikis;
        }
    }
}
