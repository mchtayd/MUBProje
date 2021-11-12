using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SatMalList
    {
        int id, miktar, stoknoid, tanimid; string stokno, tanim,  birim;

        public int Id { get => id; set => id = value; }
        public int Stoknoid { get => stoknoid; set => stoknoid = value; }
        public int Tanimid { get => tanimid; set => tanimid = value; }
        public string Stokno { get => stokno; set => stokno = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public string Birim { get => birim; set => birim = value; }

        public SatMalList(int id, int stoknoid, int tanimid, string stokno, string tanim, int miktar, string birim)
        {
            this.id = id;
            this.stoknoid = stoknoid;
            this.stokno = stokno;
            this.tanimid = tanimid;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
        }

        public SatMalList(int stoknoid, string stokno, int tanimid,  string tanim,  int miktar, string birim)
        {
            this.stoknoid = stoknoid;
            this.stokno = stokno;
            this.tanimid = tanimid;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
        }
    }
}
