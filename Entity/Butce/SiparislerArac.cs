using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Butce
{
    public class SiparislerArac
    {
        int id; string plaka, mulkiyetBilgileri, bolumu, zimmetliPersonel, masYerSorumlusu, durum, siparis; DateTime tarih;

        public int Id { get => id; set => id = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public string MulkiyetBilgileri { get => mulkiyetBilgileri; set => mulkiyetBilgileri = value; }
        public string Bolumu { get => bolumu; set => bolumu = value; }
        public string ZimmetliPersonel { get => zimmetliPersonel; set => zimmetliPersonel = value; }
        public string MasYerSorumlusu { get => masYerSorumlusu; set => masYerSorumlusu = value; }
        public string Durum { get => durum; set => durum = value; }
        public string Siparis { get => siparis; set => siparis = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }

        public SiparislerArac(int id, string plaka, string mulkiyetBilgileri, string bolumu, string zimmetliPersonel, string masYerSorumlusu, string durum, string siparis, DateTime tarih)
        {
            this.id = id;
            this.plaka = plaka;
            this.mulkiyetBilgileri = mulkiyetBilgileri;
            this.bolumu = bolumu;
            this.zimmetliPersonel = zimmetliPersonel;
            this.masYerSorumlusu = masYerSorumlusu;
            this.durum = durum;
            this.siparis = siparis;
            this.tarih = tarih;
        }

        public SiparislerArac(string plaka, string mulkiyetBilgileri, string bolumu, string zimmetliPersonel, string masYerSorumlusu, string durum, string siparis, DateTime tarih)
        {
            this.plaka = plaka;
            this.mulkiyetBilgileri = mulkiyetBilgileri;
            this.bolumu = bolumu;
            this.zimmetliPersonel = zimmetliPersonel;
            this.masYerSorumlusu = masYerSorumlusu;
            this.durum = durum;
            this.siparis = siparis;
            this.tarih = tarih;
        }
    }
}
