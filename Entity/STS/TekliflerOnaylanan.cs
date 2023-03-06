using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class TekliflerOnaylanan
    {
        int id,brf1, btf1, brf2, btf2, brf3, btf3, onaylananbirim,onaylanantoplam;

        public int Id { get => id; set => id = value; }
        public int Brf1 { get => brf1; set => brf1 = value; }
        public int Btf1 { get => btf1; set => btf1 = value; }
        public int Brf2 { get => brf2; set => brf2 = value; }
        public int Btf2 { get => btf2; set => btf2 = value; }
        public int Brf3 { get => brf3; set => brf3 = value; }
        public int Btf3 { get => btf3; set => btf3 = value; }
        public int Onaylananbirim { get => onaylananbirim; set => onaylananbirim = value; }
        public int Onaylanantoplam { get => onaylanantoplam; set => onaylanantoplam = value; }

        public TekliflerOnaylanan(int id, int brf1, int btf1, int brf2, int btf2, int brf3, int btf3, int onaylananbirim, int onaylanantoplam)
        {
            this.id = id;
            this.brf1 = brf1;
            this.btf1 = btf1;
            this.brf2 = brf2;
            this.btf2 = btf2;
            this.brf3 = brf3;
            this.btf3 = btf3;
            this.onaylananbirim = onaylananbirim;
            this.onaylanantoplam = onaylanantoplam;
        }

        public TekliflerOnaylanan(int brf1, int btf1, int brf2, int btf2, int brf3, int btf3, int onaylananbirim, int onaylanantoplam)
        {
            this.brf1 = brf1;
            this.btf1 = btf1;
            this.brf2 = brf2;
            this.btf2 = btf2;
            this.brf3 = brf3;
            this.btf3 = btf3;
            this.onaylananbirim = onaylananbirim;
            this.onaylanantoplam = onaylanantoplam;
        }
    }
}
