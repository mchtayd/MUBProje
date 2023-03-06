using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AmbarVeri
    {
        int fabrikaBO, malzemeTeminAselsan, malzemeTeminSat, malzemeHazirlama, malzemePaketleme, bolgeSevkiyat, genelTop, uges, mgeo, sst, rehis, bakimOnarim, geciciKabul, kaliteTest;

        public int FabrikaBO { get => fabrikaBO; set => fabrikaBO = value; }
        public int MalzemeTeminAselsan { get => malzemeTeminAselsan; set => malzemeTeminAselsan = value; }
        public int MalzemeTeminSat { get => malzemeTeminSat; set => malzemeTeminSat = value; }
        public int MalzemeHazirlama { get => malzemeHazirlama; set => malzemeHazirlama = value; }
        public int MalzemePaketleme { get => malzemePaketleme; set => malzemePaketleme = value; }
        public int BolgeSevkiyat { get => bolgeSevkiyat; set => bolgeSevkiyat = value; }
        public int GenelTop { get => genelTop; set => genelTop = value; }
        public int Uges { get => uges; set => uges = value; }
        public int Mgeo { get => mgeo; set => mgeo = value; }
        public int Sst { get => sst; set => sst = value; }
        public int Rehis { get => rehis; set => rehis = value; }
        public int BakimOnarim { get => bakimOnarim; set => bakimOnarim = value; }
        public int GeciciKabul { get => geciciKabul; set => geciciKabul = value; }
        public int KaliteTest { get => kaliteTest; set => kaliteTest = value; }

        public AmbarVeri(int fabrikaBO, int malzemeTeminAselsan, int malzemeTeminSat, int malzemeHazirlama, int malzemePaketleme, int bolgeSevkiyat, int genelTop)
        {
            this.fabrikaBO = fabrikaBO;
            this.malzemeTeminAselsan = malzemeTeminAselsan;
            this.malzemeTeminSat = malzemeTeminSat;
            this.malzemeHazirlama = malzemeHazirlama;
            this.malzemePaketleme = malzemePaketleme;
            this.bolgeSevkiyat = bolgeSevkiyat;
            this.genelTop = genelTop;
        }

        public AmbarVeri(int uges, int mgeo, int sst, int rehis, int bakimOnarim, int geciciKabul, int kaliteTest, int fabrikaNO)
        {
            this.uges = uges;
            this.mgeo = mgeo;
            this.sst = sst;
            this.rehis = rehis;
            this.bakimOnarim = bakimOnarim;
            this.geciciKabul = geciciKabul;
            this.kaliteTest = kaliteTest;
        }
    }
}
