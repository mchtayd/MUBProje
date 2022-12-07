using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AnaSayfa
{
    public class Log
    {
        int id; string baslik, icerik; DateTime tarih; string kullainici, sorumluId;

        public int Id { get => id; set => id = value; }
        public string Baslik { get => baslik; set => baslik = value; }
        public string Icerik { get => icerik; set => icerik = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string Kullainici { get => kullainici; set => kullainici = value; }
        public string SorumluId { get => sorumluId; set => sorumluId = value; }

        public Log(int id, string baslik, string icerik, DateTime tarih, string kullainici, string sorumluId)
        {
            this.id = id;
            this.baslik = baslik;
            this.icerik = icerik;
            this.tarih = tarih;
            this.kullainici = kullainici;
            this.sorumluId = sorumluId;
        }

        public Log(string baslik, string icerik, DateTime tarih, string kullainici, string sorumluId)
        {
            this.baslik = baslik;
            this.icerik = icerik;
            this.tarih = tarih;
            this.kullainici = kullainici;
            this.sorumluId = sorumluId;
        }
    }
}
