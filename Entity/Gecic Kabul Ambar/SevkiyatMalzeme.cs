using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Gecic_Kabul_Ambar
{
    public class SevkiyatMalzeme
    {
        int id, benzersizId; string stokNo, tanim, seriLotNo, revizyon; int miktar; string birim, abfNo; DateTime tarih;

        public int Id { get => id; set => id = value; }
        public int BenzersizId { get => benzersizId; set => benzersizId = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string SeriLotNo { get => seriLotNo; set => seriLotNo = value; }
        public string Revizyon { get => revizyon; set => revizyon = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public string Birim { get => birim; set => birim = value; }
        public string AbfNo { get => abfNo; set => abfNo = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }

        public SevkiyatMalzeme(int id, int benzersizId, string stokNo, string tanim, string seriLotNo, string revizyon, int miktar, string birim, string abfNo, DateTime tarih)
        {
            this.id = id;
            this.benzersizId = benzersizId;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.seriLotNo = seriLotNo;
            this.revizyon = revizyon;
            this.miktar = miktar;
            this.birim = birim;
            this.abfNo = abfNo;
            this.tarih = tarih;
        }

        public SevkiyatMalzeme(int benzersizId, string stokNo, string tanim, string seriLotNo, string revizyon, int miktar, string birim, string abfNo, DateTime tarih)
        {
            this.benzersizId = benzersizId;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.seriLotNo = seriLotNo;
            this.revizyon = revizyon;
            this.miktar = miktar;
            this.birim = birim;
            this.abfNo = abfNo;
            this.tarih = tarih;
        }
    }
}
