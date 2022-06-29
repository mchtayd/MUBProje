using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class Bolge
    {
        int id; string bolgeAdi, ilgiliPersonel, birlikAdresi, telefon, faturaAdresi, pypNo, sorumluSicil, il, ilce, proje, garantiBaslama, garantiBitis, ssPersonel, ssRutbe, sspGorev, depo;

        public int Id { get => id; set => id = value; }
        public string BolgeAdi { get => bolgeAdi; set => bolgeAdi = value; }
        public string IlgiliPersonel { get => ilgiliPersonel; set => ilgiliPersonel = value; }
        public string BirlikAdresi { get => birlikAdresi; set => birlikAdresi = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string FaturaAdresi { get => faturaAdresi; set => faturaAdresi = value; }
        public string PypNo { get => pypNo; set => pypNo = value; }
        public string SorumluSicil { get => sorumluSicil; set => sorumluSicil = value; }
        public string Il { get => il; set => il = value; }
        public string Ilce { get => ilce; set => ilce = value; }
        public string Proje { get => proje; set => proje = value; }
        public string GarantiBaslama { get => garantiBaslama; set => garantiBaslama = value; }
        public string GarantiBitis { get => garantiBitis; set => garantiBitis = value; }
        public string SsPersonel { get => ssPersonel; set => ssPersonel = value; }
        public string SspGorev { get => sspGorev; set => sspGorev = value; }
        public string Depo { get => depo; set => depo = value; }
        public string SsRutbe { get => ssRutbe; set => ssRutbe = value; }

        public Bolge(int id, string bolgeAdi, string ilgiliPersonel, string birlikAdresi, string telefon, string faturaAdresi, string pypNo, string sorumluSicil, string il, string ilce, string proje, string garantiBaslama, string garantiBitis, string ssPersonel, string sspGorev,string ssRutbe, string depo)
        {
            this.id = id;
            this.bolgeAdi = bolgeAdi;
            this.ilgiliPersonel = ilgiliPersonel;
            this.birlikAdresi = birlikAdresi;
            this.telefon = telefon;
            this.faturaAdresi = faturaAdresi;
            this.pypNo = pypNo;
            this.sorumluSicil = sorumluSicil;
            this.il = il;
            this.ilce = ilce;
            this.proje = proje;
            this.garantiBaslama = garantiBaslama;
            this.garantiBitis = garantiBitis;
            this.ssPersonel = ssPersonel;
            this.sspGorev = sspGorev;
            this.SsRutbe = ssRutbe;
            this.depo = depo;
        }

        public Bolge(string bolgeAdi, string ilgiliPersonel, string birlikAdresi, string telefon, string faturaAdresi, string pypNo, string sorumluSicil, string il, string ilce, string proje, string garantiBaslama, string garantiBitis, string ssPersonel, string sspGorev, string ssRutbe, string depo)
        {
            this.bolgeAdi = bolgeAdi;
            this.ilgiliPersonel = ilgiliPersonel;
            this.birlikAdresi = birlikAdresi;
            this.telefon = telefon;
            this.faturaAdresi = faturaAdresi;
            this.pypNo = pypNo;
            this.sorumluSicil = sorumluSicil;
            this.il = il;
            this.ilce = ilce;
            this.proje = proje;
            this.garantiBaslama = garantiBaslama;
            this.garantiBitis = garantiBitis;
            this.ssPersonel = ssPersonel;
            this.sspGorev = sspGorev;
            this.SsRutbe = ssRutbe;
            this.depo = depo;
        }

        public Bolge(string proje)
        {
            this.proje = proje;
        }
    }
}
