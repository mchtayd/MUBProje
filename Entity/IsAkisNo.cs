using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class IsAkisNo
    {
        int id; string tabloAd;

        public int Id { get => id; set => id = value; }
        public string TabloAd { get => tabloAd; set => tabloAd = value; }

        public IsAkisNo(int id)
        {
            this.id = id;
        }

        public IsAkisNo(int id, string tabloAd)
        {
            this.id = id;
            this.tabloAd = tabloAd;
        }
    }
}
