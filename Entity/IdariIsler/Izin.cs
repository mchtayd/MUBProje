using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class Izin
    {
        int id,isakisno; string izinkategori, izinturu, siparisno, adsoyad, unvani,masrafyerino, bolum, ızınnedeni; DateTime bastarihi, bittarihi; string izindurumu, toplamsure, kalanSure, dosyayolu, sayfa, siparis, onayDurum;

        public int Id { get => id; set => id = value; }
        public int Isakisno { get => isakisno; set => isakisno = value; }
        public string Izinkategori { get => izinkategori; set => izinkategori = value; }
        public string Izinturu { get => izinturu; set => izinturu = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }
        public string Adsoyad { get => adsoyad; set => adsoyad = value; }
        public string Masrafyerino { get => masrafyerino; set => masrafyerino = value; }
        public string Bolum { get => bolum; set => bolum = value; }
        public string Izınnedeni { get => ızınnedeni; set => ızınnedeni = value; }
        public DateTime Bastarihi { get => bastarihi; set => bastarihi = value; }
        public DateTime Bittarihi { get => bittarihi; set => bittarihi = value; }
        public string Izindurumu { get => izindurumu; set => izindurumu = value; }
        public string Unvani { get => unvani; set => unvani = value; }
        public string Toplamsure { get => toplamsure; set => toplamsure = value; }
        public string KalanSure { get => kalanSure; set => kalanSure = value; }
        public string Dosyayolu { get => dosyayolu; set => dosyayolu = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }
        public string Siparis { get => siparis; set => siparis = value; }
        public string OnayDurum { get => onayDurum; set => onayDurum = value; }

        public Izin(int id, int isakisno, string izinkategori, string izinturu, string siparisno, string adsoyad, string unvani,string masrafyerino, string bolum, string ızınnedeni, DateTime bastarihi, DateTime bittarihi,string izindurumu,string toplamsure,
            string dosyayolu,string sayfa, string siparis, string onayDurum)
        {
            this.id = id;
            this.isakisno = isakisno;
            this.izinkategori = izinkategori;
            this.izinturu = izinturu;
            this.siparisno = siparisno;
            this.adsoyad = adsoyad;
            this.masrafyerino = masrafyerino;
            this.bolum = bolum;
            this.ızınnedeni = ızınnedeni;
            this.bastarihi = bastarihi;
            this.bittarihi = bittarihi;
            this.izindurumu = izindurumu;
            this.unvani = unvani;
            this.toplamsure = toplamsure;
            this.dosyayolu = dosyayolu;
            this.sayfa = sayfa;
            this.siparis = siparis;
            this.onayDurum = onayDurum;
        }

        public Izin(int isakisno, string izinkategori, string izinturu, string siparisno, string adsoyad, string unvani,string masrafyerino, string bolum, string ızınnedeni, DateTime bastarihi, DateTime bittarihi,string toplamsure,string dosyayolu, string siparis)
        {
            this.isakisno = isakisno;
            this.izinkategori = izinkategori;
            this.izinturu = izinturu;
            this.siparisno = siparisno;
            this.adsoyad = adsoyad;
            this.masrafyerino = masrafyerino;
            this.bolum = bolum;
            this.ızınnedeni = ızınnedeni;
            this.bastarihi = bastarihi;
            this.bittarihi = bittarihi;
            this.unvani = unvani;
            this.toplamsure = toplamsure;
            this.dosyayolu = dosyayolu;
            this.siparis = siparis;
        }

        public Izin(string izinturu, string adsoyad, string unvani, DateTime bastarihi, DateTime bittarihi, string toplamsure, string kalanSure)
        {
            this.izinturu = izinturu;
            this.adsoyad = adsoyad;
            this.unvani = unvani;
            this.bastarihi = bastarihi;
            this.bittarihi = bittarihi;
            this.toplamsure = toplamsure;
            this.KalanSure = kalanSure;
        }

        public Izin(string adsoyad, string ızınnedeni, DateTime bastarihi, DateTime bittarihi)
        {
            this.adsoyad = adsoyad;
            this.ızınnedeni = ızınnedeni;
            this.bastarihi = bastarihi;
            this.bittarihi = bittarihi;
        }

        public Izin(int id, string adsoyad, string ızınnedeni, DateTime bastarihi, DateTime bittarihi, string toplamsure)
        {
            this.id = id;
            this.adsoyad = adsoyad;
            this.ızınnedeni = ızınnedeni;
            this.bastarihi = bastarihi;
            this.bittarihi = bittarihi;
            this.toplamsure=toplamsure;
        }
    }
}
