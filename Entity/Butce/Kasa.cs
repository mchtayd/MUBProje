using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Butce
{
    public class Kasa
    {
        int id; string hesapSahibi, musteriNumarasi, dovizCinsi, subeAdi, hesapNumarasi, iban;

        public int Id { get => id; set => id = value; }
        public string HesapSahibi { get => hesapSahibi; set => hesapSahibi = value; }
        public string MusteriNumarasi { get => musteriNumarasi; set => musteriNumarasi = value; }
        public string DovizCinsi { get => dovizCinsi; set => dovizCinsi = value; }
        public string SubeAdi { get => subeAdi; set => subeAdi = value; }
        public string HesapNumarasi { get => hesapNumarasi; set => hesapNumarasi = value; }
        public string Iban { get => iban; set => iban = value; }

        public Kasa(int id, string hesapSahibi, string musteriNumarasi, string dovizCinsi, string subeAdi, string hesapNumarasi, string iban)
        {
            this.id = id;
            this.hesapSahibi = hesapSahibi;
            this.musteriNumarasi = musteriNumarasi;
            this.dovizCinsi = dovizCinsi;
            this.subeAdi = subeAdi;
            this.hesapNumarasi = hesapNumarasi;
            this.iban = iban;
        }

        public Kasa(string hesapSahibi, string musteriNumarasi, string dovizCinsi, string subeAdi, string hesapNumarasi, string iban)
        {
            this.hesapSahibi = hesapSahibi;
            this.musteriNumarasi = musteriNumarasi;
            this.dovizCinsi = dovizCinsi;
            this.subeAdi = subeAdi;
            this.hesapNumarasi = hesapNumarasi;
            this.iban = iban;
        }
    }
}
