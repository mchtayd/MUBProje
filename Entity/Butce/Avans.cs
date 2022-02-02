using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Butce
{
    public class Avans
    {
        int id, isAkisNo; string donem; DateTime istemeTarihi, havaleTarihi; string gonderen, hesapNo, ibanNo, hesapSahibi; double tutar; string dosyaYolu;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public string Donem { get => donem; set => donem = value; }
        public DateTime IstemeTarihi { get => istemeTarihi; set => istemeTarihi = value; }
        public DateTime HavaleTarihi { get => havaleTarihi; set => havaleTarihi = value; }
        public string Gonderen { get => gonderen; set => gonderen = value; }
        public string HesapNo { get => hesapNo; set => hesapNo = value; }
        public string IbanNo { get => ibanNo; set => ibanNo = value; }
        public string HesapSahibi { get => hesapSahibi; set => hesapSahibi = value; }
        public double Tutar { get => tutar; set => tutar = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }

        public Avans(int id, int isAkisNo, string donem, DateTime istemeTarihi, DateTime havaleTarihi, string gonderen, string hesapNo, string ibanNo, string hesapSahibi, double tutar, string dosyaYolu)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.donem = donem;
            this.istemeTarihi = istemeTarihi;
            this.havaleTarihi = havaleTarihi;
            this.gonderen = gonderen;
            this.hesapNo = hesapNo;
            this.ibanNo = ibanNo;
            this.hesapSahibi = hesapSahibi;
            this.tutar = tutar;
            this.dosyaYolu = dosyaYolu;
        }

        public Avans(int isAkisNo, string donem, DateTime istemeTarihi, DateTime havaleTarihi, string gonderen, string hesapNo, string ibanNo, string hesapSahibi, double tutar, string dosyaYolu)
        {
            this.isAkisNo = isAkisNo;
            this.donem = donem;
            this.istemeTarihi = istemeTarihi;
            this.havaleTarihi = havaleTarihi;
            this.gonderen = gonderen;
            this.hesapNo = hesapNo;
            this.ibanNo = ibanNo;
            this.hesapSahibi = hesapSahibi;
            this.tutar = tutar;
            this.dosyaYolu = dosyaYolu;
        }
    }
}
