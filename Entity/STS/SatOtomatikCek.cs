using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SatOtomatikCek
    {
        int id; string isim, departman, bolum, birim, projekodu;

        public int Id { get => id; set => id = value; }
        public string Isim { get => isim; set => isim = value; }
        public string Departman { get => departman; set => departman = value; }
        public string Bolum { get => bolum; set => bolum = value; }
        public string Birim { get => birim; set => birim = value; }
        public string Projekodu { get => projekodu; set => projekodu = value; }

        public SatOtomatikCek(int id, string isim, string departman, string bolum, string birim, string projekodu)
        {
            this.id = id;
            this.isim = isim;
            this.departman = departman;
            this.bolum = bolum;
            this.birim = birim;
            this.projekodu = projekodu;
        }

        public SatOtomatikCek(string isim, string departman, string bolum, string birim, string projekodu)
        {
            this.isim = isim;
            this.departman = departman;
            this.bolum = bolum;
            this.birim = birim;
            this.projekodu = projekodu;
        }
    }
}
