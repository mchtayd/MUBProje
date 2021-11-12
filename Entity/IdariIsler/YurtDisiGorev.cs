using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class YurtDisiGorev
    {
        int id; string adsoyad, unvani; DateTime bastarihi, bittarihi; string toplamsure, kalansure;

        public int Id { get => id; set => id = value; }
        public string Adsoyad { get => adsoyad; set => adsoyad = value; }
        public string Unvani { get => unvani; set => unvani = value; }
        public DateTime Bastarihi { get => bastarihi; set => bastarihi = value; }
        public DateTime Bittarihi { get => bittarihi; set => bittarihi = value; }
        public string Toplamsure { get => toplamsure; set => toplamsure = value; }
        public string Kalansure { get => kalansure; set => kalansure = value; }

        public YurtDisiGorev(int id, string adsoyad, string unvani, DateTime bastarihi, DateTime bittarihi, string toplamsure, string kalansure)
        {
            this.id = id;
            this.adsoyad = adsoyad;
            this.unvani = unvani;
            this.bastarihi = bastarihi;
            this.bittarihi = bittarihi;
            this.toplamsure = toplamsure;
            this.kalansure = kalansure;
        }

        public YurtDisiGorev(string adsoyad, string unvani, DateTime bastarihi, DateTime bittarihi, string toplamsure, string kalansure)
        {
            this.adsoyad = adsoyad;
            this.unvani = unvani;
            this.bastarihi = bastarihi;
            this.bittarihi = bittarihi;
            this.toplamsure = toplamsure;
            this.kalansure = kalansure;
        }
    }
}
