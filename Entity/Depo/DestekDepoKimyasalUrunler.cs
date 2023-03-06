using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Depo
{
    public class DestekDepoKimyasalUrunler
    {
        int id; string stokNo, tanim, birim;

        public int Id { get => id; set => id = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string Birim { get => birim; set => birim = value; }

        public DestekDepoKimyasalUrunler(int id, string stokNo, string tanim, string birim)
        {
            this.id = id;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.birim = birim;
        }

        public DestekDepoKimyasalUrunler(string stokNo, string tanim, string birim)
        {
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.birim = birim;
        }
    }
}
