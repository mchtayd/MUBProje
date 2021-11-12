using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SatTalebiDoldur
    {
        int id; string usbolgesi, proje; int abfNo;

        public int Id { get => id; set => id = value; }
        public string Usbolgesi { get => usbolgesi; set => usbolgesi = value; }
        public int AbfNo { get => abfNo; set => abfNo = value; }
        public string Proje { get => proje; set => proje = value; }

        public SatTalebiDoldur(string usbolgesi)
        {
            this.usbolgesi = usbolgesi;
        }

        public SatTalebiDoldur(string usbolgesi, int abfNo) : this(usbolgesi)
        {
            this.abfNo = abfNo;
        }

        public SatTalebiDoldur(string usbolgesi, string proje) : this(usbolgesi)
        {
            this.proje = proje;
        }
    }
}
