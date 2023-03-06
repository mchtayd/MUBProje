using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class IscilikDestekTabloArac
    {
        int id; string plaka, kullanildigiBolum, siparisNo;

        public int Id { get => id; set => id = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public string KullanildigiBolum { get => kullanildigiBolum; set => kullanildigiBolum = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }

        public IscilikDestekTabloArac(int id, string plaka, string kullanildigiBolum, string siparisNo)
        {
            this.id = id;
            this.plaka = plaka;
            this.kullanildigiBolum = kullanildigiBolum;
            this.siparisNo = siparisNo;
        }

        public IscilikDestekTabloArac(string plaka, string kullanildigiBolum, string siparisNo)
        {
            this.plaka = plaka;
            this.kullanildigiBolum = kullanildigiBolum;
            this.siparisNo = siparisNo;
        }
    }
}
