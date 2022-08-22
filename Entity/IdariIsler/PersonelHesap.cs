using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class PersonelHesap
    {
        int id; string sicilNo, sifre, adSoyad; int yetkiId; string fotoYolu, yetkiModu;

        public int Id { get => id; set => id = value; }
        public string SicilNo { get => sicilNo; set => sicilNo = value; }
        public string Sifre { get => sifre; set => sifre = value; }
        public string AdSoyad { get => adSoyad; set => adSoyad = value; }
        public int YetkiId { get => yetkiId; set => yetkiId = value; }
        public string FotoYolu { get => fotoYolu; set => fotoYolu = value; }
        public string YetkiModu { get => yetkiModu; set => yetkiModu = value; }

        public PersonelHesap(int id, string sicilNo, string sifre, string adSoyad, int yetkiId, string fotoYolu, string yetkiModu)
        {
            this.id = id;
            this.sicilNo = sicilNo;
            this.sifre = sifre;
            this.adSoyad = adSoyad;
            this.yetkiId = yetkiId;
            this.fotoYolu = fotoYolu;
            this.yetkiModu = yetkiModu;
        }

        public PersonelHesap(string sicilNo, string sifre, string adSoyad, int yetkiId)
        {
            this.sicilNo = sicilNo;
            this.sifre = sifre;
            this.adSoyad = adSoyad;
            this.yetkiId = yetkiId;
        }
    }
}
