using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Yerleskeler
{
    public class Personel
    {
        int personelId; string sicilNo, personelAd; int yetkiId;

        public int PersonelId { get => personelId; set => personelId = value; }
        public string SicilNo { get => sicilNo; set => sicilNo = value; }
        public string PersonelAd { get => personelAd; set => personelAd = value; }
        public int YetkiId { get => yetkiId; set => yetkiId = value; }

        public Personel(int personelId, string sicilNo, string personelAd, int yetkiId)
        {
            this.personelId = personelId;
            this.sicilNo = sicilNo;
            this.personelAd = personelAd;
            this.yetkiId = yetkiId;
        }
    }
}
