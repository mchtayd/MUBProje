using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class Teklifler
    {
        int id, bf1, bt1, if2, it2, uf3, ut3, onaylananbirim, onaylanantoplam; string siparisNo;

        public int Id { get => id; set => id = value; }
        public int Bf1 { get => bf1; set => bf1 = value; }
        public int Bt1 { get => bt1; set => bt1 = value; }
        public int If2 { get => if2; set => if2 = value; }
        public int It2 { get => it2; set => it2 = value; }
        public int Uf3 { get => uf3; set => uf3 = value; }
        public int Ut3 { get => ut3; set => ut3 = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public int Onaylananbirim { get => onaylananbirim; set => onaylananbirim = value; }
        public int Onaylanantoplam { get => onaylanantoplam; set => onaylanantoplam = value; }

        public Teklifler(int id, int bf1, int bt1, int if2, int it2, int uf3, int ut3)
        {
            this.id = id;
            this.bf1 = bf1;
            this.bt1 = bt1;
            this.if2 = if2;
            this.it2 = it2;
            this.uf3 = uf3;
            this.ut3 = ut3;
        }

        public Teklifler(int bf1, int bt1, int if2, int it2, int uf3, int ut3, string siparisNo)
        {
            this.bf1 = bf1;
            this.bt1 = bt1;
            this.if2 = if2;
            this.it2 = it2;
            this.uf3 = uf3;
            this.ut3 = ut3;
            this.siparisNo = siparisNo;
        }
    }
}
