using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AnaSayfa
{
    public class YolDurumuGirmeyen
    {
        int id; string personel, gorulmeDurumu; DateTime tarih;

        public int Id { get => id; set => id = value; }
        public string Personel { get => personel; set => personel = value; }
        public string GorulmeDurumu { get => gorulmeDurumu; set => gorulmeDurumu = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }

        public YolDurumuGirmeyen(int id, string personel, string gorulmeDurumu, DateTime tarih)
        {
            this.id = id;
            this.personel = personel;
            this.gorulmeDurumu = gorulmeDurumu;
            this.tarih = tarih;
        }

        public YolDurumuGirmeyen(int id, string personel, string gorulmeDurumu)
        {
            this.id = id;
            this.personel = personel;
            this.gorulmeDurumu = gorulmeDurumu;
        }

        public YolDurumuGirmeyen(string personel)
        {
            this.personel = personel;
        }
    }
}
