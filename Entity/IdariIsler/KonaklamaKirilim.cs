using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class KonaklamaKirilim
    {
        int isAkisNo, gun, gunTl, toplam;

        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public int Gun { get => gun; set => gun = value; }
        public int GunTl { get => gunTl; set => gunTl = value; }
        public int Toplam { get => toplam; set => toplam = value; }

        public KonaklamaKirilim(int isAkisNo, int gun, int gunTl, int toplam)
        {
            this.isAkisNo = isAkisNo;
            this.gun = gun;
            this.gunTl = gunTl;
            this.toplam = toplam;
        }
    }
}
