using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SatNo
    {
        int satisNo; string siparisno;

        public int SatisNo { get => satisNo; set => satisNo = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }

        public SatNo(int satisNo, string siparisno)
        {
            this.SatisNo = satisNo;
            this.siparisno = siparisno;
        }

        public SatNo(string siparisno)
        {
            this.siparisno = siparisno;
        }
    }
}
