using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Butce
{
    public class KasaDurum
    {
        int id; double kasaGelir, kasaGider, kasaKalan;

        public int Id { get => id; set => id = value; }
        public double KasaGelir { get => kasaGelir; set => kasaGelir = value; }
        public double KasaGider { get => kasaGider; set => kasaGider = value; }
        public double KasaKalan { get => kasaKalan; set => kasaKalan = value; }

        public KasaDurum(int id, double kasaGelir, double kasaGider, double kasaKalan)
        {
            this.id = id;
            this.kasaGelir = kasaGelir;
            this.kasaGider = kasaGider;
            this.kasaKalan = kasaKalan;
        }

    }
}
