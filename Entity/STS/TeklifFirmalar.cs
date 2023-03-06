using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class TeklifFirmalar
    {
        int id, t1, t2, t3; string fa1, fa2, fa3, fi1, fi2, fi3, fn1, fn2, fn3, siparisno,firmaname;

        public int Id { get => id; set => id = value; }
        public int T1 { get => t1; set => t1 = value; }
        public int T2 { get => t2; set => t2 = value; }
        public int T3 { get => t3; set => t3 = value; }
        public string Fa1 { get => fa1; set => fa1 = value; }
        public string Fa2 { get => fa2; set => fa2 = value; }
        public string Fa3 { get => fa3; set => fa3 = value; }
        public string Fi1 { get => fi1; set => fi1 = value; }
        public string Fi2 { get => fi2; set => fi2 = value; }
        public string Fi3 { get => fi3; set => fi3 = value; }
        public string Fn1 { get => fn1; set => fn1 = value; }
        public string Fn2 { get => fn2; set => fn2 = value; }
        public string Fn3 { get => fn3; set => fn3 = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }
        public string Firmaname { get => firmaname; set => firmaname = value; }

        public TeklifFirmalar(int id, int t1, int t2, int t3, string fa1, string fa2, string fa3, string fi1, string fi2, string fi3, string fn1, string fn2, string fn3, string siparisno)
        {
            this.id = id;
            this.t1 = t1;
            this.t2 = t2;
            this.t3 = t3;
            this.fa1 = fa1;
            this.fa2 = fa2;
            this.fa3 = fa3;
            this.fi1 = fi1;
            this.fi2 = fi2;
            this.fi3 = fi3;
            this.fn1 = fn1;
            this.fn2 = fn2;
            this.fn3 = fn3;
            this.siparisno = siparisno;
        }

        public TeklifFirmalar(int t1, int t2, int t3, string fa1, string fa2, string fa3, string fi1, string fi2, string fi3, string fn1, string fn2, string fn3, string siparisno)
        {
            this.t1 = t1;
            this.t2 = t2;
            this.t3 = t3;
            this.fa1 = fa1;
            this.fa2 = fa2;
            this.fa3 = fa3;
            this.fi1 = fi1;
            this.fi2 = fi2;
            this.fi3 = fi3;
            this.fn1 = fn1;
            this.fn2 = fn2;
            this.fn3 = fn3;
            this.siparisno = siparisno;
        }

        public TeklifFirmalar(string firmaname)
        {
            this.firmaname = firmaname;
        }
    }
}
