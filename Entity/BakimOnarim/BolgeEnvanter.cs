using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class BolgeEnvanter
    {
        int id, bolgeId; string kategori, donanim, stokNo, tanim; int miktar; string birim, seriNo, revizyon, nsn; DateTime guncellemeTarihi; string mubBilgisi;

        public int Id { get => id; set => id = value; }
        public int BolgeId { get => bolgeId; set => bolgeId = value; }
        public string Kategori { get => kategori; set => kategori = value; }
        public string Donanim { get => donanim; set => donanim = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public string Birim { get => birim; set => birim = value; }
        public string SeriNo { get => seriNo; set => seriNo = value; }
        public string Revizyon { get => revizyon; set => revizyon = value; }
        public string Nsn { get => nsn; set => nsn = value; }
        public DateTime GuncellemeTarihi { get => guncellemeTarihi; set => guncellemeTarihi = value; }
        public string MubBilgisi { get => mubBilgisi; set => mubBilgisi = value; }

        public BolgeEnvanter(int id, int bolgeId, string kategori, string donanim, string stokNo, string tanim, int miktar, string birim, string seriNo, string revizyon, string nsn, DateTime guncellemeTarihi, string mubBilgisi)
        {
            this.id = id;
            this.bolgeId = bolgeId;
            this.kategori = kategori;
            this.donanim = donanim;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.seriNo = seriNo;
            this.revizyon = revizyon;
            this.nsn = nsn;
            this.guncellemeTarihi = guncellemeTarihi;
            this.mubBilgisi = mubBilgisi;
        }

        public BolgeEnvanter(int bolgeId, string kategori, string donanim, string stokNo, string tanim, int miktar, string birim, string seriNo, string revizyon, string nsn, DateTime guncellemeTarihi, string mubBilgisi)
        {
            this.bolgeId = bolgeId;
            this.kategori = kategori;
            this.donanim = donanim;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.seriNo = seriNo;
            this.revizyon = revizyon;
            this.nsn = nsn;
            this.guncellemeTarihi = guncellemeTarihi;
            this.mubBilgisi = mubBilgisi;
        }
    }
}
