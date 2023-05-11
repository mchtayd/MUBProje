using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Gecic_Kabul_Ambar
{
    public class UstTakim
    {
        int id; string stokNo, tanim, ilgiliFirma;

        public int Id { get => id; set => id = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string IlgiliFirma { get => ilgiliFirma; set => ilgiliFirma = value; }

        public UstTakim(int id, string stokNo, string tanim, string ilgiliFirma)
        {
            this.id = id;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.ilgiliFirma = ilgiliFirma;
        }

        public UstTakim(string stokNo, string tanim, string ilgiliFirma)
        {
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.ilgiliFirma = ilgiliFirma;
        }
    }
}
