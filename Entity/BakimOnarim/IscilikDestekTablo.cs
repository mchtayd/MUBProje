using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class IscilikDestekTablo
    {
        int id; string adSoyad, gorevi, personelBolum, siparisNo;

        public int Id { get => id; set => id = value; }
        public string AdSoyad { get => adSoyad; set => adSoyad = value; }
        public string Gorevi { get => gorevi; set => gorevi = value; }
        public string PersonelBolum { get => personelBolum; set => personelBolum = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }

        public IscilikDestekTablo(int id, string adSoyad, string gorevi, string personelBolum, string siparisNo)
        {
            this.id = id;
            this.adSoyad = adSoyad;
            this.gorevi = gorevi;
            this.personelBolum = personelBolum;
            this.siparisNo = siparisNo;
        }

        public IscilikDestekTablo(string adSoyad, string gorevi, string personelBolum, string siparisNo)
        {
            this.adSoyad = adSoyad;
            this.gorevi = gorevi;
            this.personelBolum = personelBolum;
            this.siparisNo = siparisNo;
        }
    }
}
