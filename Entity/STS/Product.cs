using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class Product
    {
        string stokNo, tanim;
        byte[] image;

        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public byte[] Image { get => image; set => image = value; }

        public Product(string stokNo, string tanim, byte[] image)
        {
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.image = image;
        }
    }
}
