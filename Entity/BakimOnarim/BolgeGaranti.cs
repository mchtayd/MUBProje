using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class BolgeGaranti
    {
        int id; string garantiPaketi; DateTime garantiBaslama, garantiBitis; string toplamSure, siparisNo;

        public int Id { get => id; set => id = value; }
        public string GarantiPaketi { get => garantiPaketi; set => garantiPaketi = value; }
        public DateTime GarantiBaslama { get => garantiBaslama; set => garantiBaslama = value; }
        public DateTime GarantiBitis { get => garantiBitis; set => garantiBitis = value; }
        public string ToplamSure { get => toplamSure; set => toplamSure = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }

        public BolgeGaranti(int id, string garantiPaketi, DateTime garantiBaslama, DateTime garantiBitis, string toplamSure, string siparisNo)
        {
            this.id = id;
            this.garantiPaketi = garantiPaketi;
            this.garantiBaslama = garantiBaslama;
            this.garantiBitis = garantiBitis;
            this.toplamSure = toplamSure;
            this.siparisNo = siparisNo;
        }

        public BolgeGaranti(string garantiPaketi, DateTime garantiBaslama, DateTime garantiBitis, string toplamSure, string siparisNo)
        {
            this.garantiPaketi = garantiPaketi;
            this.garantiBaslama = garantiBaslama;
            this.garantiBitis = garantiBitis;
            this.toplamSure = toplamSure;
            this.siparisNo = siparisNo;
        }
    }
}
