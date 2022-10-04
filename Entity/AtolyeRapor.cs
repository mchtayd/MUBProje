using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AtolyeRapor
    {
        int a400, a500, a600, a700, a800, a900, a1000, a1100, a1200;

        public int A400 { get => a400; set => a400 = value; }
        public int A500 { get => a500; set => a500 = value; }
        public int A600 { get => a600; set => a600 = value; }
        public int A700 { get => a700; set => a700 = value; }
        public int A800 { get => a800; set => a800 = value; }
        public int A900 { get => a900; set => a900 = value; }
        public int A1000 { get => a1000; set => a1000 = value; }
        public int A1100 { get => a1100; set => a1100 = value; }
        public int A1200 { get => a1200; set => a1200 = value; }

        public AtolyeRapor(int a400, int a500, int a600, int a700, int a800, int a900, int a1000, int a1100, int a1200)
        {
            this.a400 = a400;
            this.a500 = a500;
            this.a600 = a600;
            this.a700 = a700;
            this.a800 = a800;
            this.a900 = a900;
            this.a1000 = a1000;
            this.a1100 = a1100;
            this.a1200 = a1200;
        }
    }
}
