using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SatinAlinacakMalzemeler
    {
        int id, m1; string stn1, t1, b1, firma; double birimFiyat, toplamFiyat; bool secim = true; 
        private string siparisNo;

        public int Id { get => id; set => id = value; }
        public string Stn1 { get => stn1; set => stn1 = value; }
        public string T1 { get => t1; set => t1 = value; }
        public int M1 { get => m1; set => m1 = value; }
        public string B1 { get => b1; set => b1 = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public string Firma { get => firma; set => firma = value; }
        public double BirimFiyat { get => birimFiyat; set => birimFiyat = value; }
        public double ToplamFiyat { get => toplamFiyat; set => toplamFiyat = value; }
        public bool Secim { get => secim; set => secim = value; }

        public SatinAlinacakMalzemeler(string stn1, string t1, int m1, string b1, string siparisNo)
        {
            this.stn1 = stn1; this.t1 = t1; this.m1 = m1; this.b1 = b1;
            this.siparisNo = siparisNo;
        }

        public SatinAlinacakMalzemeler(int id, string stn1, string t1, int m1, string b1)
        {
            this.id = id; this.stn1 = stn1; this.t1 = t1; this.m1 = m1; this.b1 = b1;
        }

        public SatinAlinacakMalzemeler(int m1, string stn1, string t1, string b1, string firma, double birimFiyat, double toplamFiyat, bool secim)
        {
            this.m1 = m1;
            this.stn1 = stn1;
            this.t1 = t1;
            this.b1 = b1;
            this.firma = firma;
            this.birimFiyat = birimFiyat;
            this.toplamFiyat = toplamFiyat;
            this.secim = secim;
        }
    }
}
