using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class SicilNo
    {
        int sicilno; string siparisno;

        public int Sicilno { get => sicilno; set => sicilno = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }

        public SicilNo(int sicilno, string siparisno)
        {
            this.sicilno = sicilno;
            this.siparisno = siparisno;
        }

        public SicilNo(string siparisno)
        {
            this.siparisno = siparisno;
        }
    }
}
