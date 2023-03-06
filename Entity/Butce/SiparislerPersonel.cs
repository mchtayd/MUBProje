using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Butce
{
    public class SiparislerPersonel
    {
        int id; string personelAdi, unvani, masrafYeriSorumlusu, bolumu, durumu, siparis; DateTime tarih;

        public int Id { get => id; set => id = value; }
        public string PersonelAdi { get => personelAdi; set => personelAdi = value; }
        public string Unvani { get => unvani; set => unvani = value; }
        public string Bolumu { get => bolumu; set => bolumu = value; }
        public string MasrafYeriSorumlusu { get => masrafYeriSorumlusu; set => masrafYeriSorumlusu = value; }
        public string Durumu { get => durumu; set => durumu = value; }
        public string Siparis { get => siparis; set => siparis = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }

        public SiparislerPersonel(int id, string personelAdi, string unvani, string masrafYeriSorumlusu, string bolumu,  string durumu, string siparis, DateTime tarih)
        {
            this.id = id;
            this.personelAdi = personelAdi;
            this.unvani = unvani;
            this.bolumu = bolumu;
            this.masrafYeriSorumlusu = masrafYeriSorumlusu;
            this.durumu = durumu;
            this.siparis = siparis;
            this.tarih = tarih;
        }

        public SiparislerPersonel(string personelAdi, string unvani, string masrafYeriSorumlusu, string bolumu,  string durumu, string siparis, DateTime tarih)
        {
            this.personelAdi = personelAdi;
            this.unvani = unvani;
            this.bolumu = bolumu;
            this.masrafYeriSorumlusu = masrafYeriSorumlusu;
            this.durumu = durumu;
            this.siparis = siparis;
            this.tarih = tarih;
        }
    }
}
