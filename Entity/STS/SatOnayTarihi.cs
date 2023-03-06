using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class SatOnayTarihi
    {
        string siparisNo; DateTime olusturmaTarihi, baslamaTarihi, onayTarihi;

        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public DateTime OlusturmaTarihi { get => olusturmaTarihi; set => olusturmaTarihi = value; }
        public DateTime BaslamaTarihi { get => baslamaTarihi; set => baslamaTarihi = value; }
        public DateTime OnayTarihi { get => onayTarihi; set => onayTarihi = value; }

        public SatOnayTarihi(string siparisNo, DateTime olusturmaTarihi, DateTime baslamaTarihi, DateTime onayTarihi)
        {
            this.siparisNo = siparisNo;
            this.olusturmaTarihi = olusturmaTarihi;
            this.baslamaTarihi = baslamaTarihi;
            this.onayTarihi = onayTarihi;
        }

        public SatOnayTarihi(string siparisNo)
        {
            this.siparisNo = siparisNo;
        }
    }
}
