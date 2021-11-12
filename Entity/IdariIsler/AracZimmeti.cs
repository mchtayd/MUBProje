using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class AracZimmeti
    {
        int id, isAkisNo; string plaka, marka, model, motorNo, saseNo, mulkiyetBilgileri, siparisNo;DateTime projeTahsisTarihi; string personelAd, sicilNo, masrafYeriNo, masrafYeri, masYerSor, bolum;DateTime aktarimTarihi; string gerekce, dosyYolu;int km;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public string MotorNo { get => motorNo; set => motorNo = value; }
        public string SaseNo { get => saseNo; set => saseNo = value; }
        public string MulkiyetBilgileri { get => mulkiyetBilgileri; set => mulkiyetBilgileri = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public DateTime ProjeTahsisTarihi { get => projeTahsisTarihi; set => projeTahsisTarihi = value; }
        public string PersonelAd { get => personelAd; set => personelAd = value; }
        public string SicilNo { get => sicilNo; set => sicilNo = value; }
        public string MasrafYeriNo { get => masrafYeriNo; set => masrafYeriNo = value; }
        public string MasrafYeri { get => masrafYeri; set => masrafYeri = value; }
        public string MasYerSor { get => masYerSor; set => masYerSor = value; }
        public string Bolum { get => bolum; set => bolum = value; }
        public DateTime AktarimTarihi { get => aktarimTarihi; set => aktarimTarihi = value; }
        public string Gerekce { get => gerekce; set => gerekce = value; }
        public string DosyYolu { get => dosyYolu; set => dosyYolu = value; }
        public int Km { get => km; set => km = value; }

        public AracZimmeti(int id, int isAkisNo, string plaka, string marka, string model, string motorNo, string saseNo, string mulkiyetBilgileri, string siparisNo, DateTime projeTahsisTarihi, string personelAd, string sicilNo, string masrafYeriNo, string masrafYeri, string masYerSor, string bolum, DateTime aktarimTarihi, string gerekce, string dosyYolu,int km)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.plaka = plaka;
            this.marka = marka;
            this.model = model;
            this.motorNo = motorNo;
            this.saseNo = saseNo;
            this.mulkiyetBilgileri = mulkiyetBilgileri;
            this.siparisNo = siparisNo;
            this.projeTahsisTarihi = projeTahsisTarihi;
            this.personelAd = personelAd;
            this.sicilNo = sicilNo;
            this.masrafYeriNo = masrafYeriNo;
            this.masrafYeri = masrafYeri;
            this.masYerSor = masYerSor;
            this.bolum = bolum;
            this.aktarimTarihi = aktarimTarihi;
            this.gerekce = gerekce;
            this.dosyYolu = dosyYolu;
            this.km = km;
        }

        public AracZimmeti(int isAkisNo, string plaka, string marka, string model, string motorNo, string saseNo, string mulkiyetBilgileri, string siparisNo, DateTime projeTahsisTarihi, string personelAd, string sicilNo, string masrafYeriNo, string masrafYeri, string masYerSor, string bolum, DateTime aktarimTarihi, string gerekce, string dosyYolu, int km)
        {
            this.isAkisNo = isAkisNo;
            this.plaka = plaka;
            this.marka = marka;
            this.model = model;
            this.motorNo = motorNo;
            this.saseNo = saseNo;
            this.mulkiyetBilgileri = mulkiyetBilgileri;
            this.siparisNo = siparisNo;
            this.projeTahsisTarihi = projeTahsisTarihi;
            this.personelAd = personelAd;
            this.sicilNo = sicilNo;
            this.masrafYeriNo = masrafYeriNo;
            this.masrafYeri = masrafYeri;
            this.masYerSor = masYerSor;
            this.bolum = bolum;
            this.aktarimTarihi = aktarimTarihi;
            this.gerekce = gerekce;
            this.dosyYolu = dosyYolu;
            this.km = km;
        }
    }
}
