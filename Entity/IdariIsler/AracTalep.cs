using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class AracTalep
    {
        int id; string gorevEmriNo, butceKoduTanimi, aracTalepNedeni, gidilecekYer; DateTime baslamaTarihiSaati, bitisTarihiSaati; string toplamSure, personelAd, personelSiparis, unvani, personelMasYeriNo, personelMasYeri, masrafYeriSorumlusu, plaka, aracSiparis; int cikisKm, donusKm; string aracZimmetliPersonel, dosyaYolu;

        public int Id { get => id; set => id = value; }
        public string GorevEmriNo { get => gorevEmriNo; set => gorevEmriNo = value; }
        public string ButceKoduTanimi { get => butceKoduTanimi; set => butceKoduTanimi = value; }
        public string AracTalepNedeni { get => aracTalepNedeni; set => aracTalepNedeni = value; }
        public string GidilecekYer { get => gidilecekYer; set => gidilecekYer = value; }
        public DateTime BaslamaTarihiSaati { get => baslamaTarihiSaati; set => baslamaTarihiSaati = value; }
        public DateTime BitisTarihiSaati { get => bitisTarihiSaati; set => bitisTarihiSaati = value; }
        public string ToplamSure { get => toplamSure; set => toplamSure = value; }
        public string PersonelAd { get => personelAd; set => personelAd = value; }
        public string PersonelSiparis { get => personelSiparis; set => personelSiparis = value; }
        public string Unvani { get => unvani; set => unvani = value; }
        public string PersonelMasYeriNo { get => personelMasYeriNo; set => personelMasYeriNo = value; }
        public string PersonelMasYeri { get => personelMasYeri; set => personelMasYeri = value; }
        public string MasrafYeriSorumlusu { get => masrafYeriSorumlusu; set => masrafYeriSorumlusu = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public string AracSiparis { get => aracSiparis; set => aracSiparis = value; }
        public int CikisKm { get => cikisKm; set => cikisKm = value; }
        public int DonusKm { get => donusKm; set => donusKm = value; }
        public string AracZimmetliPersonel { get => aracZimmetliPersonel; set => aracZimmetliPersonel = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }

        public AracTalep(int id, string gorevEmriNo, string butceKoduTanimi, string aracTalepNedeni, string gidilecekYer, DateTime baslamaTarihiSaati, DateTime bitisTarihiSaati, string toplamSure, string personelAd, string personelSiparis, string unvani, string personelMasYeriNo, string personelMasYeri, string masrafYeriSorumlusu, string plaka, string aracSiparis, int cikisKm, int donusKm, string aracZimmetliPersonel, string dosyaYolu)
        {
            this.id = id;
            this.gorevEmriNo = gorevEmriNo;
            this.butceKoduTanimi = butceKoduTanimi;
            this.aracTalepNedeni = aracTalepNedeni;
            this.gidilecekYer = gidilecekYer;
            this.baslamaTarihiSaati = baslamaTarihiSaati;
            this.bitisTarihiSaati = bitisTarihiSaati;
            this.toplamSure = toplamSure;
            this.personelAd = personelAd;
            this.personelSiparis = personelSiparis;
            this.unvani = unvani;
            this.personelMasYeriNo = personelMasYeriNo;
            this.personelMasYeri = personelMasYeri;
            this.masrafYeriSorumlusu = masrafYeriSorumlusu;
            this.plaka = plaka;
            this.aracSiparis = aracSiparis;
            this.cikisKm = cikisKm;
            this.donusKm = donusKm;
            this.aracZimmetliPersonel = aracZimmetliPersonel;
            this.dosyaYolu = dosyaYolu;
        }

        public AracTalep(string gorevEmriNo, string butceKoduTanimi, string aracTalepNedeni, string gidilecekYer, DateTime baslamaTarihiSaati, DateTime bitisTarihiSaati, string toplamSure, string personelAd, string personelSiparis, string unvani, string personelMasYeriNo, string personelMasYeri, string masrafYeriSorumlusu, string plaka, string aracSiparis, int cikisKm, int donusKm, string aracZimmetliPersonel, string dosyaYolu)
        {
            this.gorevEmriNo = gorevEmriNo;
            this.butceKoduTanimi = butceKoduTanimi;
            this.aracTalepNedeni = aracTalepNedeni;
            this.gidilecekYer = gidilecekYer;
            this.baslamaTarihiSaati = baslamaTarihiSaati;
            this.bitisTarihiSaati = bitisTarihiSaati;
            this.toplamSure = toplamSure;
            this.personelAd = personelAd;
            this.personelSiparis = personelSiparis;
            this.unvani = unvani;
            this.personelMasYeriNo = personelMasYeriNo;
            this.personelMasYeri = personelMasYeri;
            this.masrafYeriSorumlusu = masrafYeriSorumlusu;
            this.plaka = plaka;
            this.aracSiparis = aracSiparis;
            this.cikisKm = cikisKm;
            this.donusKm = donusKm;
            this.aracZimmetliPersonel = aracZimmetliPersonel;
            this.dosyaYolu = dosyaYolu;
        }
    }
}
