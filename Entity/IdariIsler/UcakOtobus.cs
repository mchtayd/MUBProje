using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class UcakOtobus
    {
        int id, isakisno; string talepturu, gorevformno, izinformno, butcekodu, siparisno, adsoyad, masrafyerino, masrafyeri, gorevi, tc, hes, email, kisakod, biletturu, gidisfirma; DateTime gidistarihi; string gidisnereden, gidisnereye, donusfirma; DateTime donustarihi; string donusnereden, donusnereye; double toplamMaliyet; string islemadimi, dosyayolu, sayfa; int biletSayisi, satNo;

        public int Id { get => id; set => id = value; }
        public int Isakisno { get => isakisno; set => isakisno = value; }
        public string Talepturu { get => talepturu; set => talepturu = value; }
        public string Gorevformno { get => gorevformno; set => gorevformno = value; }
        public string Izinformno { get => izinformno; set => izinformno = value; }
        public string Butcekodu { get => butcekodu; set => butcekodu = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }
        public string Adsoyad { get => adsoyad; set => adsoyad = value; }
        public string Masrafyerino { get => masrafyerino; set => masrafyerino = value; }
        public string Masrafyeri { get => masrafyeri; set => masrafyeri = value; }
        public string Gorevi { get => gorevi; set => gorevi = value; }
        public string Tc { get => tc; set => tc = value; }
        public string Hes { get => hes; set => hes = value; }
        public string Email { get => email; set => email = value; }
        public string Kisakod { get => kisakod; set => kisakod = value; }
        public string Biletturu { get => biletturu; set => biletturu = value; }
        public string Gidisfirma { get => gidisfirma; set => gidisfirma = value; }
        public DateTime Gidistarihi { get => gidistarihi; set => gidistarihi = value; }
        public string Gidisnereden { get => gidisnereden; set => gidisnereden = value; }
        public string Gidisnereye { get => gidisnereye; set => gidisnereye = value; }
        public string Donusfirma { get => donusfirma; set => donusfirma = value; }
        public DateTime Donustarihi { get => donustarihi; set => donustarihi = value; }
        public string Donusnereden { get => donusnereden; set => donusnereden = value; }
        public string Donusnereye { get => donusnereye; set => donusnereye = value; }
        public double ToplamMaliyet { get => toplamMaliyet; set => toplamMaliyet = value; }
        public string Islemadimi { get => islemadimi; set => islemadimi = value; }
        public string Dosyayolu { get => dosyayolu; set => dosyayolu = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }
        public int BiletSayisi { get => biletSayisi; set => biletSayisi = value; }
        public int SatNo { get => satNo; set => satNo = value; }

        public UcakOtobus(int isakisno, string talepturu, string gorevformno, string izinformno, string butcekodu, string siparisno, string adsoyad, string masrafyerino, string masrafyeri, string gorevi, string tc, string hes, string email, string kisakod, string biletturu, string gidisfirma, DateTime gidistarihi, string gidisnereden, string gidisnereye, string donusfirma, DateTime donustarihi, string donusnereden, string donusnereye, double toplamMaliyet, string islemadimi,string dosyayolu,int biletSayisi,int satNo)
        {
            this.Talepturu = talepturu;
            this.Gorevformno = gorevformno;
            this.Izinformno = izinformno;
            this.Siparisno = siparisno;
            this.Adsoyad = adsoyad;
            this.Masrafyerino = masrafyerino;
            this.Masrafyeri = masrafyeri;
            this.Gorevi = gorevi;
            this.Tc = tc;
            this.Hes = hes;
            this.Email = email;
            this.Kisakod = kisakod;
            this.Biletturu = biletturu;
            this.Gidisfirma = gidisfirma;
            this.Gidistarihi = gidistarihi;
            this.Gidisnereden = gidisnereden;
            this.Gidisnereye = gidisnereye;
            this.Donusfirma = donusfirma;
            this.Donustarihi = donustarihi;
            this.Donusnereden = donusnereden;
            this.Donusnereye = donusnereye;
            this.Islemadimi = islemadimi;
            this.Isakisno = isakisno;
            this.Dosyayolu = dosyayolu;
            this.butcekodu = butcekodu;
            this.toplamMaliyet = toplamMaliyet;
            this.biletSayisi = biletSayisi;
            this.satNo = satNo;
        }

        public UcakOtobus(int id, int isakisno, string talepturu, string gorevformno, string izinformno, string butcekodu,string siparisno, string adsoyad, string masrafyerino, string masrafyeri, string gorevi, string tc, string hes, string email, string kisakod, string biletturu, string gidisfirma, DateTime gidistarihi, string gidisnereden, string gidisnereye, string donusfirma, DateTime donustarihi, string donusnereden, string donusnereye, double toplamMaliyet,string islemadimi,string dosyayolu,string sayfa, int biletSayisi,int satNo)
        {
            this.Id = id;
            this.Isakisno = isakisno;
            this.Talepturu = talepturu;
            this.Gorevformno = gorevformno;
            this.Izinformno = izinformno;
            this.Siparisno = siparisno;
            this.Adsoyad = adsoyad;
            this.Masrafyerino = masrafyerino;
            this.Masrafyeri = masrafyeri;
            this.Gorevi = gorevi;
            this.Tc = tc;
            this.Hes = hes;
            this.Email = email;
            this.Kisakod = kisakod;
            this.Biletturu = biletturu;
            this.Gidisfirma = gidisfirma;
            this.Gidistarihi = gidistarihi;
            this.Gidisnereden = gidisnereden;
            this.Gidisnereye = gidisnereye;
            this.Donusfirma = donusfirma;
            this.Donustarihi = donustarihi;
            this.Donusnereden = donusnereden;
            this.Donusnereye = donusnereye;
            this.Islemadimi = islemadimi;
            this.Dosyayolu = dosyayolu;
            this.Sayfa = sayfa;
            this.butcekodu = butcekodu;
            this.toplamMaliyet = toplamMaliyet;
            this.biletSayisi = biletSayisi;
            this.satNo = satNo;
        }

        public UcakOtobus(string islemadimi)
        {
            this.Islemadimi = islemadimi;
        }
    }
}
