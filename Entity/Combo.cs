using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Combo
    {
        int id; string baslik, sayfa, comboAd;

        public int Id { get => id; set => id = value; }
        public string Baslik { get => baslik; set => baslik = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }
        public string ComboAd { get => comboAd; set => comboAd = value; }

        public Combo(int id, string baslik, string sayfa, string comboAd)
        {
            this.id = id;
            this.baslik = baslik;
            this.sayfa = sayfa;
            this.comboAd = comboAd;
        }

        public Combo(string baslik, string sayfa, string comboAd)
        {
            this.baslik = baslik;
            this.sayfa = sayfa;
            this.comboAd = comboAd;
        }

        public Combo(string baslik)
        {
            this.baslik = baslik;
        }
    }
}
