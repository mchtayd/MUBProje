using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Yerleskeler
{
    public class Yerleske
    {
        int id; string yerleskeAdi, mulkiyetBilgileri, yerleskeAdresi, aboneTuru, hizmetAlinanKurum, aboneTesisatNo; DateTime aboneTarihi; string abonelikDurumu, dosyaYolu, siparisNo;

        public int Id { get => id; set => id = value; }
        public string YerleskeAdi { get => yerleskeAdi; set => yerleskeAdi = value; }
        public string MulkiyetBilgileri { get => mulkiyetBilgileri; set => mulkiyetBilgileri = value; }
        public string YerleskeAdresi { get => yerleskeAdresi; set => yerleskeAdresi = value; }
        public string AboneTuru { get => aboneTuru; set => aboneTuru = value; }
        public string HizmetAlinanKurum { get => hizmetAlinanKurum; set => hizmetAlinanKurum = value; }
        public string AboneTesisatNo { get => aboneTesisatNo; set => aboneTesisatNo = value; }
        public DateTime AboneTarihi { get => aboneTarihi; set => aboneTarihi = value; }
        public string AbonelikDurumu { get => abonelikDurumu; set => abonelikDurumu = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }

        public Yerleske(int id, string yerleskeAdi, string mulkiyetBilgileri, string yerleskeAdresi, string aboneTuru, string hizmetAlinanKurum, string aboneTesisatNo, DateTime aboneTarihi, string abonelikDurumu, string dosyaYolu, string siparisNo)
        {
            this.id = id;
            this.yerleskeAdi = yerleskeAdi;
            this.mulkiyetBilgileri = mulkiyetBilgileri;
            this.yerleskeAdresi = yerleskeAdresi;
            this.aboneTuru = aboneTuru;
            this.hizmetAlinanKurum = hizmetAlinanKurum;
            this.aboneTesisatNo = aboneTesisatNo;
            this.aboneTarihi = aboneTarihi;
            this.abonelikDurumu = abonelikDurumu;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
        }

        public Yerleske(string yerleskeAdi, string mulkiyetBilgileri, string yerleskeAdresi, string aboneTuru, string hizmetAlinanKurum, string aboneTesisatNo, DateTime aboneTarihi, string abonelikDurumu, string dosyaYolu, string siparisNo)
        {
            this.yerleskeAdi = yerleskeAdi;
            this.mulkiyetBilgileri = mulkiyetBilgileri;
            this.yerleskeAdresi = yerleskeAdresi;
            this.aboneTuru = aboneTuru;
            this.hizmetAlinanKurum = hizmetAlinanKurum;
            this.aboneTesisatNo = aboneTesisatNo;
            this.aboneTarihi = aboneTarihi;
            this.abonelikDurumu = abonelikDurumu;
            this.dosyaYolu = dosyaYolu;
            this.siparisNo = siparisNo;
        }
    }
}
