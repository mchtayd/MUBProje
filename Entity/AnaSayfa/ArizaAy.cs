using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AnaSayfa
{
    public class ArizaAy
    {
        int ocak, subat, mart, nisan, mayis, haziran, temmuz, agustos, eylus, ekim, kasim, aralik, toplam;

        public int Ocak { get => ocak; set => ocak = value; }
        public int Subat { get => subat; set => subat = value; }
        public int Mart { get => mart; set => mart = value; }
        public int Nisan { get => nisan; set => nisan = value; }
        public int Mayis { get => mayis; set => mayis = value; }
        public int Haziran { get => haziran; set => haziran = value; }
        public int Temmuz { get => temmuz; set => temmuz = value; }
        public int Agustos { get => agustos; set => agustos = value; }
        public int Eylus { get => eylus; set => eylus = value; }
        public int Ekim { get => ekim; set => ekim = value; }
        public int Kasim { get => kasim; set => kasim = value; }
        public int Aralik { get => aralik; set => aralik = value; }
        public int Toplam { get => toplam; set => toplam = value; }

        public ArizaAy(int ocak, int subat, int mart, int nisan, int mayis, int haziran, int temmuz, int agustos, int eylus, int ekim, int kasim, int aralik, int toplam)
        {
            this.ocak = ocak;
            this.subat = subat;
            this.mart = mart;
            this.nisan = nisan;
            this.mayis = mayis;
            this.haziran = haziran;
            this.temmuz = temmuz;
            this.agustos = agustos;
            this.eylus = eylus;
            this.ekim = ekim;
            this.kasim = kasim;
            this.aralik = aralik;
            this.toplam = toplam;
        }
    }
}
