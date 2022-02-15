using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class AracKm
    {
        int id; string plaka, siparisNo; DateTime tarih; string donem; int baslangicKm; string personelAd, personelSiparis, personelUnvani, perMasYeriNo, perMasYeri, persMasYerSorumlusu, aracMulkiyet; DateTime kmBitisTarihi; int bitisKm, toplamYapilanKm, sabitKm, fark;

        public int Id { get => id; set => id = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string Donem { get => donem; set => donem = value; }
        public int BaslangicKm { get => baslangicKm; set => baslangicKm = value; }
        public string PersonelAd { get => personelAd; set => personelAd = value; }
        public string PersonelSiparis { get => personelSiparis; set => personelSiparis = value; }
        public string PersonelUnvani { get => personelUnvani; set => personelUnvani = value; }
        public string PerMasYeriNo { get => perMasYeriNo; set => perMasYeriNo = value; }
        public string PerMasYeri { get => perMasYeri; set => perMasYeri = value; }
        public string PersMasYerSorumlusu { get => persMasYerSorumlusu; set => persMasYerSorumlusu = value; }
        public string AracMulkiyet { get => aracMulkiyet; set => aracMulkiyet = value; }
        public DateTime KmBitisTarihi { get => kmBitisTarihi; set => kmBitisTarihi = value; }
        public int BitisKm { get => bitisKm; set => bitisKm = value; }
        public int ToplamYapilanKm { get => toplamYapilanKm; set => toplamYapilanKm = value; }
        public int SabitKm { get => sabitKm; set => sabitKm = value; }
        public int Fark { get => fark; set => fark = value; }

        public AracKm(int id, string plaka, string siparisNo, DateTime tarih, string donem, int baslangicKm, string personelAd, string personelSiparis, string personelUnvani, string perMasYeriNo, string perMasYeri, string persMasYerSorumlusu, string aracMulkiyet, DateTime kmBitisTarihi, int bitisKm, int toplamYapilanKm,int sabitKm, int fark)
        {
            this.id = id;
            this.plaka = plaka;
            this.siparisNo = siparisNo;
            this.tarih = tarih;
            this.donem = donem;
            this.baslangicKm = baslangicKm;
            this.personelAd = personelAd;
            this.personelSiparis = personelSiparis;
            this.personelUnvani = personelUnvani;
            this.perMasYeriNo = perMasYeriNo;
            this.perMasYeri = perMasYeri;
            this.persMasYerSorumlusu = persMasYerSorumlusu;
            this.aracMulkiyet = aracMulkiyet;
            this.kmBitisTarihi = kmBitisTarihi;
            this.bitisKm = bitisKm;
            this.toplamYapilanKm = toplamYapilanKm;
            this.sabitKm = sabitKm;
            this.fark = fark;
        }

        public AracKm(string plaka, string siparisNo, DateTime tarih, string donem, int baslangicKm, string personelAd, string personelSiparis, string personelUnvani, string perMasYeriNo, string perMasYeri, string persMasYerSorumlusu, string aracMulkiyet, DateTime kmBitisTarihi, int bitisKm, int toplamYapilanKm, int sabitKm, int fark)
        {
            this.plaka = plaka;
            this.siparisNo = siparisNo;
            this.tarih = tarih;
            this.donem = donem;
            this.baslangicKm = baslangicKm;
            this.personelAd = personelAd;
            this.personelSiparis = personelSiparis;
            this.personelUnvani = personelUnvani;
            this.perMasYeriNo = perMasYeriNo;
            this.perMasYeri = perMasYeri;
            this.persMasYerSorumlusu = persMasYerSorumlusu;
            this.aracMulkiyet = aracMulkiyet;
            this.kmBitisTarihi = kmBitisTarihi;
            this.bitisKm = bitisKm;
            this.toplamYapilanKm = toplamYapilanKm;
            this.sabitKm = sabitKm;
            this.fark = fark;
        }
    }
}
