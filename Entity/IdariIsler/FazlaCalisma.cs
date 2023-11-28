using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class FazlaCalisma
    {
        int id; string personelAd, personelBolum, fazlaCalismaNedeni; DateTime mesaiBasTarihi, mesaiBitTarihi; string toplamMesaiSaati, toplamHakEdilenIzin, onayDurumu, onayVeren, donem, fazlaCalismaTuru;


        public int Id { get => id; set => id = value; }
        public string PersonelAd { get => personelAd; set => personelAd = value; }
        public string PersonelBolum { get => personelBolum; set => personelBolum = value; }
        public string FazlaCalismaNedeni { get => fazlaCalismaNedeni; set => fazlaCalismaNedeni = value; }
        public DateTime MesaiBasTarihi { get => mesaiBasTarihi; set => mesaiBasTarihi = value; }
        public DateTime MesaiBitTarihi { get => mesaiBitTarihi; set => mesaiBitTarihi = value; }
        public string ToplamMesaiSaati { get => toplamMesaiSaati; set => toplamMesaiSaati = value; }
        public string ToplamHakEdilenIzin { get => toplamHakEdilenIzin; set => toplamHakEdilenIzin = value; }
        public string OnayDurumu { get => onayDurumu; set => onayDurumu = value; }
        public string OnayVeren { get => onayVeren; set => onayVeren = value; }
        public string Donem { get => donem; set => donem = value; }
        public string FazlaCalismaTuru { get => fazlaCalismaTuru; set => fazlaCalismaTuru = value; }

        public FazlaCalisma(int id, string personelAd, string personelBolum, string fazlaCalismaNedeni, DateTime mesaiBasTarihi, DateTime mesaiBitTarihi, string toplamMesaiSaati, string toplamHakEdilenIzin, string onayDurumu, string onayVeren,string donem, string fazlaCalismaTuru)
        {
            this.id = id;
            this.personelAd = personelAd;
            this.personelBolum = personelBolum;
            this.fazlaCalismaNedeni = fazlaCalismaNedeni;
            this.mesaiBasTarihi = mesaiBasTarihi;
            this.mesaiBitTarihi = mesaiBitTarihi;
            this.toplamMesaiSaati = toplamMesaiSaati;
            this.toplamHakEdilenIzin = toplamHakEdilenIzin;
            this.onayDurumu = onayDurumu;
            this.onayVeren = onayVeren;
            this.donem = donem;
            this.fazlaCalismaTuru = fazlaCalismaTuru;
        }

        public FazlaCalisma(string personelAd, string personelBolum, string fazlaCalismaNedeni, DateTime mesaiBasTarihi, DateTime mesaiBitTarihi, string toplamMesaiSaati, string toplamHakEdilenIzin, string donem, string fazlaCalismaTuru)
        {
            this.personelAd = personelAd;
            this.personelBolum = personelBolum;
            this.fazlaCalismaNedeni = fazlaCalismaNedeni;
            this.mesaiBasTarihi = mesaiBasTarihi;
            this.mesaiBitTarihi = mesaiBitTarihi;
            this.toplamMesaiSaati = toplamMesaiSaati;
            this.toplamHakEdilenIzin = toplamHakEdilenIzin;
            this.donem = donem;
            this.fazlaCalismaTuru = fazlaCalismaTuru;
        }
    }
}
