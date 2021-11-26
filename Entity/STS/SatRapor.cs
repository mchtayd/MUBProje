using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class SatRapor
    {
        string kategori, butceKodu, butceKalemi; DateTime faturaTarihi; string belgeNo,belgeTuru,faturaAlindigiYer; double tutar; string proje, bolge; int bildirimNo; string aciklamalar, harcamaYapan;

        public string Kategori { get => kategori; set => kategori = value; }
        public string ButceKodu { get => butceKodu; set => butceKodu = value; }
        public string ButceKalemi { get => butceKalemi; set => butceKalemi = value; }
        public DateTime FaturaTarihi { get => faturaTarihi; set => faturaTarihi = value; }
        public string FaturaAlindigiYer { get => faturaAlindigiYer; set => faturaAlindigiYer = value; }
        public double Tutar { get => tutar; set => tutar = value; }
        public string Proje { get => proje; set => proje = value; }
        public string Bolge { get => bolge; set => bolge = value; }
        public int BildirimNo { get => bildirimNo; set => bildirimNo = value; }
        public string Aciklamalar { get => aciklamalar; set => aciklamalar = value; }
        public string BelgeNo { get => belgeNo; set => belgeNo = value; }
        public string BelgeTuru { get => belgeTuru; set => belgeTuru = value; }
        public string HarcamaYapan { get => harcamaYapan; set => harcamaYapan = value; }

        public SatRapor(string kategori, string butceKodu, string butceKalemi, DateTime faturaTarihi, string faturaAlindigiYer, double tutar, string proje, string bolge, int bildirimNo, string aciklamalar)
        {
            this.kategori = kategori;
            this.butceKodu = butceKodu;
            this.butceKalemi = butceKalemi;
            this.faturaTarihi = faturaTarihi;
            this.faturaAlindigiYer = faturaAlindigiYer;
            this.tutar = tutar;
            this.proje = proje;
            this.bolge = bolge;
            this.bildirimNo = bildirimNo;
            this.aciklamalar = aciklamalar;
        }

        public SatRapor(string butceKodu, string butceKalemi, DateTime faturaTarihi, string belgeNo, string belgeTuru, string faturaAlindigiYer, double tutar, string harcamaYapan)
        {
            this.butceKodu = butceKodu;
            this.butceKalemi = butceKalemi;
            this.faturaTarihi = faturaTarihi;
            this.belgeNo = belgeNo;
            this.belgeTuru = belgeTuru;
            this.faturaAlindigiYer = faturaAlindigiYer;
            this.tutar = tutar;
            this.harcamaYapan = harcamaYapan;
        }
    }
}
