using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Depo
{
    public class DestekDepoKKD
    {
        int id;string stokno, tanim, birim, dosyaYolu;

        public int Id { get => id; set => id = value; }
        public string Stokno { get => stokno; set => stokno = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string Birim { get => birim; set => birim = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }

        public DestekDepoKKD(int id, string stokno, string tanim, string birim, string dosyaYolu)
        {
            this.id = id;
            this.stokno = stokno;
            this.tanim = tanim;
            this.birim = birim;
            this.dosyaYolu = dosyaYolu;
        }

        public DestekDepoKKD(string stokno, string tanim, string birim,string dosyaYolu)
        {
            this.stokno = stokno;
            this.tanim = tanim;
            this.birim = birim;
            this.dosyaYolu = dosyaYolu;
        }
    }
}
