using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class KonaklamaGecmis
    {
        int id; DateTime restarihi; string personel, konaklamail, oteladi; double guntutar, toptutar;int konaklamagun;DateTime giristarihi, cikistarihi;string proje, aciklama, butcekodu,ay;

        public int Id { get => id; set => id = value; }
        public DateTime Restarihi { get => restarihi; set => restarihi = value; }
        public string Personel { get => personel; set => personel = value; }
        public string Konaklamail { get => konaklamail; set => konaklamail = value; }
        public string Oteladi { get => oteladi; set => oteladi = value; }
        public double Guntutar { get => guntutar; set => guntutar = value; }
        public double Toptutar { get => toptutar; set => toptutar = value; }
        public int Konaklamagun { get => konaklamagun; set => konaklamagun = value; }
        public DateTime Giristarihi { get => giristarihi; set => giristarihi = value; }
        public DateTime Cikistarihi { get => cikistarihi; set => cikistarihi = value; }
        public string Proje { get => proje; set => proje = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public string Butcekodu { get => butcekodu; set => butcekodu = value; }
        public string Ay { get => ay; set => ay = value; }

        public KonaklamaGecmis(int id, DateTime restarihi, string personel, string konaklamail, string oteladi, double guntutar, double toptutar, int konaklamagun, DateTime giristarihi, DateTime cikistarihi, string proje, string aciklama, string butcekodu,string ay)
        {
            this.id = id;
            this.restarihi = restarihi;
            this.personel = personel;
            this.konaklamail = konaklamail;
            this.oteladi = oteladi;
            this.guntutar = guntutar;
            this.toptutar = toptutar;
            this.konaklamagun = konaklamagun;
            this.giristarihi = giristarihi;
            this.cikistarihi = cikistarihi;
            this.proje = proje;
            this.aciklama = aciklama;
            this.butcekodu = butcekodu;
            this.ay = ay;
        }

        public KonaklamaGecmis(DateTime restarihi, string personel, string konaklamail, string oteladi, double guntutar, double toptutar, int konaklamagun, DateTime giristarihi, DateTime cikistarihi, string proje, string aciklama, string butcekodu, string ay)
        {
            this.restarihi = restarihi;
            this.personel = personel;
            this.konaklamail = konaklamail;
            this.oteladi = oteladi;
            this.guntutar = guntutar;
            this.toptutar = toptutar;
            this.konaklamagun = konaklamagun;
            this.giristarihi = giristarihi;
            this.cikistarihi = cikistarihi;
            this.proje = proje;
            this.aciklama = aciklama;
            this.butcekodu = butcekodu;
            this.ay = ay;
        }
    }

}
