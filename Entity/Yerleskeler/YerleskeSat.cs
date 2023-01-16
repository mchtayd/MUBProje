using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Yerleskeler
{
    public class YerleskeSat
    {
        int id, isAkisNo, satNo; string yerleskeAdi, giderTuru, yerleskeAdresi, kurum, aboneTesisatNo; DateTime istenenTarih; string donem; double tutar; string dosyaYolu, siparisNo;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public int SatNo { get => satNo; set => satNo = value; }
        public string YerleskeAdi { get => yerleskeAdi; set => yerleskeAdi = value; }
        public string GiderTuru { get => giderTuru; set => giderTuru = value; }
        public string YerleskeAdresi { get => yerleskeAdresi; set => yerleskeAdresi = value; }
        public string Kurum { get => kurum; set => kurum = value; }
        public string AboneTesisatNo { get => aboneTesisatNo; set => aboneTesisatNo = value; }
        public DateTime IstenenTarih { get => istenenTarih; set => istenenTarih = value; }
        public string Donem { get => donem; set => donem = value; }
        public double Tutar { get => tutar; set => tutar = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }

        public YerleskeSat(int id, int isAkisNo, int satNo, string yerleskeAdi, string giderTuru, string yerleskeAdresi, string kurum, string aboneTesisatNo, DateTime istenenTarih, string donem, double tutar, string dosyaYolu, string siparisNo)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.satNo = satNo;
            this.yerleskeAdi = yerleskeAdi;
            this.giderTuru = giderTuru;
            this.yerleskeAdresi = yerleskeAdresi;
            this.kurum = kurum;
            this.aboneTesisatNo = aboneTesisatNo;
            this.istenenTarih = istenenTarih;
            this.donem = donem;
            this.tutar = tutar;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
        }

        public YerleskeSat(int isAkisNo, int satNo, string yerleskeAdi, string giderTuru, string yerleskeAdresi, string kurum, string aboneTesisatNo, DateTime istenenTarih, string donem, double tutar, string dosyaYolu, string siparisNo)
        {
            this.isAkisNo = isAkisNo;
            this.satNo = satNo;
            this.yerleskeAdi = yerleskeAdi;
            this.giderTuru = giderTuru;
            this.yerleskeAdresi = yerleskeAdresi;
            this.kurum = kurum;
            this.aboneTesisatNo = aboneTesisatNo;
            this.istenenTarih = istenenTarih;
            this.donem = donem;
            this.tutar = tutar;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
        }
    }
}
