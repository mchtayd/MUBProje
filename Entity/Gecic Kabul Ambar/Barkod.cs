using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Gecic_Kabul_Ambar
{
    public class Barkod
    {
        int id; string stokNo, tanim, seriNo, revizyon, barkodOlusturan; DateTime barkodOlusturmaTarihi, sonCiktiTarihi; int tekrarAdeti; bool kayitDurumu; string sonCiktiAlan;

        public int Id { get => id; set => id = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string SeriNo { get => seriNo; set => seriNo = value; }
        public string Revizyon { get => revizyon; set => revizyon = value; }
        public string BarkodOlusturan { get => barkodOlusturan; set => barkodOlusturan = value; }
        public DateTime BarkodOlusturmaTarihi { get => barkodOlusturmaTarihi; set => barkodOlusturmaTarihi = value; }
        public DateTime SonCiktiTarihi { get => sonCiktiTarihi; set => sonCiktiTarihi = value; }
        public int TekrarAdeti { get => tekrarAdeti; set => tekrarAdeti = value; }
        public bool KayitDurumu { get => kayitDurumu; set => kayitDurumu = value; }
        public string SonCiktiAlan { get => sonCiktiAlan; set => sonCiktiAlan = value; }

        public Barkod(int id, string stokNo, string tanim, string seriNo, string revizyon, string barkodOlusturan, DateTime barkodOlusturmaTarihi, DateTime sonCiktiTarihi, int tekrarAdeti,string sonCiktiAlan)
        {
            this.id = id;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.seriNo = seriNo;
            this.revizyon = revizyon;
            this.barkodOlusturan = barkodOlusturan;
            this.barkodOlusturmaTarihi = barkodOlusturmaTarihi;
            this.sonCiktiTarihi = sonCiktiTarihi;
            this.tekrarAdeti = tekrarAdeti;
            this.sonCiktiAlan = sonCiktiAlan;
        }

        public Barkod(int id, string stokNo, string tanim, string seriNo, string revizyon, string barkodOlusturan, DateTime sonCiktiTarihi, bool kayitDurumu, string sonCiktiAlan)
        {
            this.id = id;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.seriNo = seriNo;
            this.revizyon = revizyon;
            this.barkodOlusturan = barkodOlusturan;
            this.sonCiktiTarihi = sonCiktiTarihi;
            this.kayitDurumu = kayitDurumu;
            this.sonCiktiAlan = sonCiktiAlan;
        }

        public Barkod(int id, DateTime sonCiktiTarihi,string sonCiktiAlan)
        {
            this.id = id;
            this.sonCiktiTarihi = sonCiktiTarihi;
            this.sonCiktiAlan = sonCiktiAlan;
        }
    }
}
