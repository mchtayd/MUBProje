using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class CokluArac
    {
        int id; string siparisNo, plaka; int baslangicKm, bitisKm, toplamKm; string aciklama; DateTime baslangicTarihi, bitisTarihi;

        public int Id { get => id; set => id = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public string Plaka { get => plaka; set => plaka = value; }
        public int BaslangicKm { get => baslangicKm; set => baslangicKm = value; }
        public int BitisKm { get => bitisKm; set => bitisKm = value; }
        public int ToplamKm { get => toplamKm; set => toplamKm = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public DateTime BaslangicTarihi { get => baslangicTarihi; set => baslangicTarihi = value; }
        public DateTime BitisTarihi { get => bitisTarihi; set => bitisTarihi = value; }

        public CokluArac(int id, string siparisNo, string plaka, int baslangicKm, int bitisKm, int toplamKm, string aciklama, DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            this.id = id;
            this.siparisNo = siparisNo;
            this.plaka = plaka;
            this.baslangicKm = baslangicKm;
            this.bitisKm = bitisKm;
            this.toplamKm = toplamKm;
            this.aciklama = aciklama;
            this.baslangicTarihi = baslangicTarihi;
            this.bitisTarihi = bitisTarihi;
        }

        public CokluArac(string siparisNo, string plaka, int baslangicKm, int bitisKm, int toplamKm, string aciklama, DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            this.siparisNo = siparisNo;
            this.plaka = plaka;
            this.baslangicKm = baslangicKm;
            this.bitisKm = bitisKm;
            this.toplamKm = toplamKm;
            this.aciklama = aciklama;
            this.baslangicTarihi = baslangicTarihi;
            this.bitisTarihi = bitisTarihi;
        }
    }
}
