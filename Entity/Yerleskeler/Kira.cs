using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Yerleskeler
{
    public class Kira
    {
        int id; string yerleskeAdi,yerleskeAdresi,mulkiyetBilgileri, adiSoyadi, tc, ikametgah, telefon, bankaSubesi, ibanNo; DateTime kiraBaslangicTarihi; double kiraTutar, depozito; string dosyaYolu, siparisNo;

        public int Id { get => id; set => id = value; }
        public string YerleskeAdi { get => yerleskeAdi; set => yerleskeAdi = value; }
        public string YerleskeAdresi { get => yerleskeAdresi; set => yerleskeAdresi = value; }
        public string MulkiyetBilgileri { get => mulkiyetBilgileri; set => mulkiyetBilgileri = value; }
        public string AdiSoyadi { get => adiSoyadi; set => adiSoyadi = value; }
        public string Tc { get => tc; set => tc = value; }
        public string Ikametgah { get => ikametgah; set => ikametgah = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string BankaSubesi { get => bankaSubesi; set => bankaSubesi = value; }
        public string IbanNo { get => ibanNo; set => ibanNo = value; }
        public DateTime KiraBaslangicTarihi { get => kiraBaslangicTarihi; set => kiraBaslangicTarihi = value; }
        public double KiraTutar { get => kiraTutar; set => kiraTutar = value; }
        public double Depozito { get => depozito; set => depozito = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }

        public Kira(int id, string yerleskeAdi, string yerleskeAdresi, string mulkiyetBilgileri, string adiSoyadi, string tc, string ikametgah, string telefon, string bankaSubesi, string ibanNo, DateTime kiraBaslangicTarihi, double kiraTutar, double depozito, string dosyaYolu, string siparisNo)
        {
            this.id = id;
            this.yerleskeAdi = yerleskeAdi;
            this.yerleskeAdresi = yerleskeAdresi;
            this.mulkiyetBilgileri = mulkiyetBilgileri;
            this.adiSoyadi = adiSoyadi;
            this.tc = tc;
            this.ikametgah = ikametgah;
            this.telefon = telefon;
            this.bankaSubesi = bankaSubesi;
            this.ibanNo = ibanNo;
            this.kiraBaslangicTarihi = kiraBaslangicTarihi;
            this.kiraTutar = kiraTutar;
            this.depozito = depozito;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
        }

        public Kira(string yerleskeAdi, string yerleskeAdresi, string mulkiyetBilgileri, string adiSoyadi, string tc, string ikametgah, string telefon, string bankaSubesi, string ibanNo, DateTime kiraBaslangicTarihi, double kiraTutar, double depozito, string dosyaYolu, string siparisNo)
        {
            this.yerleskeAdi = yerleskeAdi;
            this.yerleskeAdresi = yerleskeAdresi;
            this.mulkiyetBilgileri = mulkiyetBilgileri;
            this.adiSoyadi = adiSoyadi;
            this.tc = tc;
            this.ikametgah = ikametgah;
            this.telefon = telefon;
            this.bankaSubesi = bankaSubesi;
            this.ibanNo = ibanNo;
            this.kiraBaslangicTarihi = kiraBaslangicTarihi;
            this.kiraTutar = kiraTutar;
            this.depozito = depozito;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
        }
    }
}
