using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AnaSayfa
{
    public class Sohbet
    {
        int id; string gonderen, alan; DateTime gondermeZaman, almaZaman; string mesaj, sohbetEden, sohbetEdilen; DateTime tarih; string sohbetDurum;

        public int Id { get => id; set => id = value; }
        public string Gonderen { get => gonderen; set => gonderen = value; }
        public string Alan { get => alan; set => alan = value; }
        public DateTime GondermeZaman { get => gondermeZaman; set => gondermeZaman = value; }
        public DateTime AlmaZaman { get => almaZaman; set => almaZaman = value; }
        public string Mesaj { get => mesaj; set => mesaj = value; }
        public string SohbetEden { get => sohbetEden; set => sohbetEden = value; }
        public string SohbetEdilen { get => sohbetEdilen; set => sohbetEdilen = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string SohbetDurum { get => sohbetDurum; set => sohbetDurum = value; }

        public Sohbet(int id, string gonderen, string alan, DateTime gondermeZaman, DateTime almaZaman, string mesaj, string sohbetDurum)
        {
            this.id = id;
            this.gonderen = gonderen;
            this.alan = alan;
            this.gondermeZaman = gondermeZaman;
            this.almaZaman = almaZaman;
            this.mesaj = mesaj;
            this.sohbetDurum = sohbetDurum;
        }

        public Sohbet(string gonderen, string alan, DateTime gondermeZaman, string mesaj)
        {
            this.gonderen = gonderen;
            this.alan = alan;
            this.gondermeZaman = gondermeZaman;
            this.mesaj = mesaj;
        }

        public Sohbet(int id, string sohbetEden, string sohbetEdilen, DateTime tarih, string sohbetDurum)
        {
            this.id = id;
            this.sohbetEden = sohbetEden;
            this.sohbetEdilen = sohbetEdilen;
            this.tarih = tarih;
            this.sohbetDurum = sohbetDurum;
        }

        //public Sohbet(string sohbetEden, string sohbetEdilen, DateTime tarih, string sohbetDurum)
        //{
        //    this.sohbetEden = sohbetEden;
        //    this.sohbetEdilen = sohbetEdilen;
        //    this.tarih = tarih;
        //    this.sohbetDurum = sohbetDurum;
        //}
    }
}
