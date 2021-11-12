using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class YurtIciGorev
    {
        int id, isakisno; string gorevemrino, gorevinkonusu, proje, gidilecekyer; DateTime baslamatarihi, bitistarihi; string toplamsure, butcekodu, siparisno, adsoyad, unvani, masrafyerino, masrafyeri, ulasimgidis, ulasimgorevyeri, ulasimdonus; int konaklamagun; double konaklamaguntl, konaklamatoplam; int kiralamagun; double kiralamaguntl, kiralamayakit, kiralamatoplam; int seyahatavansgun; double seyahatguntl, seyahattoplam, ucakbileti, otobusbileti; string plaka; double cikiskm, donuskm, toplamkm; double geneltoplam; string islemadimi, dosyayolu, sayfa, kalanSure,konaklamaTuru;

        public int Id { get => id; set => id = value; }
        public int Isakisno { get => isakisno; set => isakisno = value; }
        public string Gorevemrino { get => gorevemrino; set => gorevemrino = value; }
        public string Gorevinkonusu { get => gorevinkonusu; set => gorevinkonusu = value; }
        public string Proje { get => proje; set => proje = value; }
        public string Gidilecekyer { get => gidilecekyer; set => gidilecekyer = value; }
        public DateTime Baslamatarihi { get => baslamatarihi; set => baslamatarihi = value; }
        public DateTime Bitistarihi { get => bitistarihi; set => bitistarihi = value; }
        public string Toplamsure { get => toplamsure; set => toplamsure = value; }
        public string Butcekodu { get => butcekodu; set => butcekodu = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }
        public string Adsoyad { get => adsoyad; set => adsoyad = value; }
        public string Masrafyerino { get => masrafyerino; set => masrafyerino = value; }
        public string Masrafyeri { get => masrafyeri; set => masrafyeri = value; }
        public string Ulasimgidis { get => ulasimgidis; set => ulasimgidis = value; }
        public string Ulasimgorevyeri { get => ulasimgorevyeri; set => ulasimgorevyeri = value; }
        public string Ulasimdonus { get => ulasimdonus; set => ulasimdonus = value; }
        public int Konaklamagun { get => konaklamagun; set => konaklamagun = value; }
        public double Konaklamaguntl { get => konaklamaguntl; set => konaklamaguntl = value; }
        public double Konaklamatoplam { get => konaklamatoplam; set => konaklamatoplam = value; }
        public int Kiralamagun { get => kiralamagun; set => kiralamagun = value; }
        public double Kiralamaguntl { get => kiralamaguntl; set => kiralamaguntl = value; }
        public double Kiralamayakit { get => kiralamayakit; set => kiralamayakit = value; }
        public double Kiralamatoplam { get => kiralamatoplam; set => kiralamatoplam = value; }
        public int Seyahatavansgun { get => seyahatavansgun; set => seyahatavansgun = value; }
        public double Seyahatguntl { get => seyahatguntl; set => seyahatguntl = value; }
        public double Seyahattoplam { get => seyahattoplam; set => seyahattoplam = value; }
        public double Ucakbileti { get => ucakbileti; set => ucakbileti = value; }
        public double Otobusbileti { get => otobusbileti; set => otobusbileti = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public double Cikiskm { get => cikiskm; set => cikiskm = value; }
        public double Donuskm { get => donuskm; set => donuskm = value; }
        public double Toplamkm { get => toplamkm; set => toplamkm = value; }
        public double Geneltoplam { get => geneltoplam; set => geneltoplam = value; }
        public string Islemadimi { get => islemadimi; set => islemadimi = value; }
        public string Dosyayolu { get => dosyayolu; set => dosyayolu = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }
        public string Unvani { get => unvani; set => unvani = value; }
        public string KalanSure { get => kalanSure; set => kalanSure = value; }
        public string KonaklamaTuru { get => konaklamaTuru; set => konaklamaTuru = value; }


        //kaydet
        public YurtIciGorev(int isakisno, string gorevemrino, string gorevinkonusu, string proje, string gidilecekyer, DateTime baslamatarihi, DateTime bitistarihi, string toplamsure, string butcekodu, string siparisno, string adsoyad, string unvani, string masrafyerino, string masrafyeri, string ulasimgidis, string ulasimgorevyeri, string ulasimdonus, int konaklamagun, double konaklamaguntl, double konaklamatoplam, int kiralamagun, double kiralamaguntl, double kiralamatoplam, int seyahatavansgun, double seyahatguntl, double seyahattoplam, double ucakbileti, double otobusbileti, double geneltoplam, string plaka, double cikiskm, string islemadimi, string dosyayolu,string konaklamaTuru)
        {
            this.isakisno = isakisno;
            this.gorevemrino = gorevemrino;
            this.gorevinkonusu = gorevinkonusu;
            this.proje = proje;
            this.gidilecekyer = gidilecekyer;
            this.baslamatarihi = baslamatarihi;
            this.bitistarihi = bitistarihi;
            this.toplamsure = toplamsure;
            this.butcekodu = butcekodu;
            this.siparisno = siparisno;
            this.adsoyad = adsoyad;
            this.masrafyerino = masrafyerino;
            this.masrafyeri = masrafyeri;
            this.ulasimgidis = ulasimgidis;
            this.ulasimgorevyeri = ulasimgorevyeri;
            this.ulasimdonus = ulasimdonus;
            this.konaklamagun = konaklamagun;
            this.konaklamaguntl = konaklamaguntl;
            this.konaklamatoplam = konaklamatoplam;
            this.kiralamagun = kiralamagun;
            this.kiralamaguntl = kiralamaguntl;
            this.kiralamatoplam = kiralamatoplam;
            this.seyahatavansgun = seyahatavansgun;
            this.seyahatguntl = seyahatguntl;
            this.seyahattoplam = seyahattoplam;
            this.ucakbileti = ucakbileti;
            this.otobusbileti = otobusbileti;
            this.geneltoplam = geneltoplam;
            this.plaka = plaka;
            this.cikiskm = cikiskm;
            this.islemadimi = islemadimi;
            this.dosyayolu = dosyayolu;
            this.unvani = unvani;
            this.konaklamaTuru = konaklamaTuru;
        }
        //güncelleme
        public YurtIciGorev(int isakisno, string gorevemrino, string gorevinkonusu, string proje, string gidilecekyer, DateTime baslamatarihi, DateTime bitistarihi, string toplamsure, string butcekodu, string siparisno, string adsoyad, string unvani, string masrafyerino, string masrafyeri, string ulasimgidis, string ulasimgorevyeri, string ulasimdonus, int konaklamagun, double konaklamaguntl, double konaklamatoplam, int kiralamagun, double kiralamaguntl, double kiralamayakit, double kiralamatoplam, int seyahatavansgun, double seyahatguntl, double seyahattoplam, double ucakbileti, double otobusbileti, string plaka, double cikiskm, double donuskm, double toplamkm, double geneltoplam, string islemadimi, string dosyayolu,string konaklamaTuru)
        {
            this.isakisno = isakisno;
            this.gorevemrino = gorevemrino;
            this.gorevinkonusu = gorevinkonusu;
            this.proje = proje;
            this.gidilecekyer = gidilecekyer;
            this.baslamatarihi = baslamatarihi;
            this.bitistarihi = bitistarihi;
            this.toplamsure = toplamsure;
            this.butcekodu = butcekodu;
            this.siparisno = siparisno;
            this.adsoyad = adsoyad;
            this.masrafyerino = masrafyerino;
            this.masrafyeri = masrafyeri;
            this.ulasimgidis = ulasimgidis;
            this.ulasimgorevyeri = ulasimgorevyeri;
            this.ulasimdonus = ulasimdonus;
            this.konaklamagun = konaklamagun;
            this.konaklamaguntl = konaklamaguntl;
            this.konaklamatoplam = konaklamatoplam;
            this.kiralamagun = kiralamagun;
            this.kiralamaguntl = kiralamaguntl;
            this.kiralamayakit = kiralamayakit;
            this.kiralamatoplam = kiralamatoplam;
            this.seyahatavansgun = seyahatavansgun;
            this.seyahatguntl = seyahatguntl;
            this.seyahattoplam = seyahattoplam;
            this.ucakbileti = ucakbileti;
            this.otobusbileti = otobusbileti;
            this.plaka = plaka;
            this.cikiskm = cikiskm;
            this.donuskm = donuskm;
            this.toplamkm = toplamkm;
            this.geneltoplam = geneltoplam;
            this.islemadimi = islemadimi;
            this.dosyayolu = dosyayolu;
            this.unvani = unvani;
            this.konaklamaTuru = konaklamaTuru;
        }
        //List
        public YurtIciGorev(int id, int isakisno, string gorevemrino, string gorevinkonusu, string proje, string gidilecekyer, DateTime baslamatarihi, DateTime bitistarihi, string toplamsure, string butcekodu, string siparisno, string adsoyad, string unvani, string masrafyerino, string masrafyeri, string ulasimgidis, string ulasimgorevyeri, string ulasimdonus, int konaklamagun, double konaklamaguntl, double konaklamatoplam, int kiralamagun, double kiralamaguntl, double kiralamayakit, double kiralamatoplam, int seyahatavansgun, double seyahatguntl, double seyahattoplam, double ucakbileti, double otobusbileti, string plaka, double cikiskm, double donuskm, double toplamkm, double geneltoplam, string islemadimi, string dosyayolu, string sayfa,string konaklamaTuru)
        {
            this.id = id;
            this.isakisno = isakisno;
            this.gorevemrino = gorevemrino;
            this.gorevinkonusu = gorevinkonusu;
            this.proje = proje;
            this.gidilecekyer = gidilecekyer;
            this.baslamatarihi = baslamatarihi;
            this.bitistarihi = bitistarihi;
            this.toplamsure = toplamsure;
            this.butcekodu = butcekodu;
            this.siparisno = siparisno;
            this.adsoyad = adsoyad;
            this.masrafyerino = masrafyerino;
            this.masrafyeri = masrafyeri;
            this.ulasimgidis = ulasimgidis;
            this.ulasimgorevyeri = ulasimgorevyeri;
            this.ulasimdonus = ulasimdonus;
            this.konaklamagun = konaklamagun;
            this.konaklamaguntl = konaklamaguntl;
            this.konaklamatoplam = konaklamatoplam;
            this.kiralamagun = kiralamagun;
            this.kiralamaguntl = kiralamaguntl;
            this.kiralamayakit = kiralamayakit;
            this.kiralamatoplam = kiralamatoplam;
            this.seyahatavansgun = seyahatavansgun;
            this.seyahatguntl = seyahatguntl;
            this.seyahattoplam = seyahattoplam;
            this.ucakbileti = ucakbileti;
            this.otobusbileti = otobusbileti;
            this.plaka = plaka;
            this.cikiskm = cikiskm;
            this.donuskm = donuskm;
            this.toplamkm = toplamkm;
            this.geneltoplam = geneltoplam;
            this.islemadimi = islemadimi;
            this.dosyayolu = dosyayolu;
            this.sayfa = sayfa;
            this.unvani = unvani;
            this.konaklamaTuru = konaklamaTuru;
        }

        public YurtIciGorev(string adsoyad, string unvani, DateTime baslamatarihi, DateTime bitistarihi, string toplamsure, string kalanSure)
        {
            this.adsoyad = adsoyad;
            this.unvani = unvani;
            this.baslamatarihi = baslamatarihi;
            this.bitistarihi = bitistarihi;
            this.toplamsure = toplamsure;
            this.kalanSure = kalanSure;
        }

        public YurtIciGorev(int isakisno, string gorevemrino, string gorevinkonusu, string proje, string gidilecekyer, DateTime baslamatarihi, DateTime bitistarihi, string toplamsure, string butcekodu, string siparisno, string adsoyad, string unvani, string masrafyerino, string masrafyeri, string ulasimgidis, string ulasimgorevyeri, string ulasimdonus, int konaklamagun, double konaklamaguntl, double konaklamatoplam, int kiralamagun, double kiralamaguntl, double kiralamayakit, double kiralamatoplam, int seyahatavansgun, double seyahatguntl, double seyahattoplam, double ucakbileti, double otobusbileti, string plaka, double cikiskm, double donuskm, double toplamkm, double geneltoplam)
        {
            this.isakisno = isakisno;
            this.gorevemrino = gorevemrino;
            this.gorevinkonusu = gorevinkonusu;
            this.proje = proje;
            this.gidilecekyer = gidilecekyer;
            this.baslamatarihi = baslamatarihi;
            this.bitistarihi = bitistarihi;
            this.toplamsure = toplamsure;
            this.butcekodu = butcekodu;
            this.siparisno = siparisno;
            this.adsoyad = adsoyad;
            this.unvani = unvani;
            this.masrafyerino = masrafyerino;
            this.masrafyeri = masrafyeri;
            this.ulasimgidis = ulasimgidis;
            this.ulasimgorevyeri = ulasimgorevyeri;
            this.ulasimdonus = ulasimdonus;
            this.konaklamagun = konaklamagun;
            this.konaklamaguntl = konaklamaguntl;
            this.konaklamatoplam = konaklamatoplam;
            this.kiralamagun = kiralamagun;
            this.kiralamaguntl = kiralamaguntl;
            this.kiralamayakit = kiralamayakit;
            this.kiralamatoplam = kiralamatoplam;
            this.seyahatavansgun = seyahatavansgun;
            this.seyahatguntl = seyahatguntl;
            this.seyahattoplam = seyahattoplam;
            this.ucakbileti = ucakbileti;
            this.otobusbileti = otobusbileti;
            this.plaka = plaka;
            this.cikiskm = cikiskm;
            this.donuskm = donuskm;
            this.toplamkm = toplamkm;
            this.geneltoplam = geneltoplam;
        }
    }
}
