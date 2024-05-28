using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AmbarVeri
    {
        int fabrikaBO, malzemeTeminAselsan, malzemeTeminSat, malzemeHazirlama, depoStokControl, bolgeSevkiyat, genelTop, uges, mgeo, sst, rehis, bakimOnarim, geciciKabul, kaliteTest, hurda, imes, tekjen, tescom, inform, mgm, bd, dBolgesi, atolye, bd2, sarp, bd3, geciciKullanim, ankaraSevkiyat, sevkiyat1, sevkiyat2;

        public int FabrikaBO { get => fabrikaBO; set => fabrikaBO = value; }
        public int MalzemeTeminAselsan { get => malzemeTeminAselsan; set => malzemeTeminAselsan = value; }
        public int MalzemeTeminSat { get => malzemeTeminSat; set => malzemeTeminSat = value; }
        public int MalzemeHazirlama { get => malzemeHazirlama; set => malzemeHazirlama = value; }
        public int DepoStokControl { get => depoStokControl; set => depoStokControl = value; }
        public int BolgeSevkiyat { get => bolgeSevkiyat; set => bolgeSevkiyat = value; }
        public int GenelTop { get => genelTop; set => genelTop = value; }
        public int Uges { get => uges; set => uges = value; }
        public int Mgeo { get => mgeo; set => mgeo = value; }
        public int Sst { get => sst; set => sst = value; }
        public int Rehis { get => rehis; set => rehis = value; }
        public int BakimOnarim { get => bakimOnarim; set => bakimOnarim = value; }
        public int GeciciKabul { get => geciciKabul; set => geciciKabul = value; }
        public int KaliteTest { get => kaliteTest; set => kaliteTest = value; }
        public int Hurda { get => hurda; set => hurda = value; }
        public int Imes { get => imes; set => imes = value; }
        public int Tekjen { get => tekjen; set => tekjen = value; }
        public int Tescom { get => tescom; set => tescom = value; }
        public int Inform { get => inform; set => inform = value; }
        public int Mgm { get => mgm; set => mgm = value; }
        public int Bd { get => bd; set => bd = value; }
        public int DBolgesi { get => dBolgesi; set => dBolgesi = value; }
        public int Atolye { get => atolye; set => atolye = value; }
        public int Bd2 { get => bd2; set => bd2 = value; }
        public int Sarp { get => sarp; set => sarp = value; }
        public int Bd3 { get => bd3; set => bd3 = value; }
        public int GeciciKullanim { get => geciciKullanim; set => geciciKullanim = value; }
        public int AnkaraSevkiyat { get => ankaraSevkiyat; set => ankaraSevkiyat = value; }
        public int Sevkiyat1 { get => sevkiyat1; set => sevkiyat1 = value; }
        public int Sevkiyat2 { get => sevkiyat2; set => sevkiyat2 = value; }

        public AmbarVeri(int fabrikaBO, int malzemeTeminAselsan, int malzemeTeminSat, int malzemeHazirlama, int depoStokControl, int bolgeSevkiyat, int ankaraSevkiyat, int genelTop, int sevkiyat1, int sevkiyat2)
        {
            this.fabrikaBO = fabrikaBO;
            this.malzemeTeminAselsan = malzemeTeminAselsan;
            this.malzemeTeminSat = malzemeTeminSat;
            this.malzemeHazirlama = malzemeHazirlama;
            this.depoStokControl = depoStokControl;
            this.bolgeSevkiyat = bolgeSevkiyat;
            this.ankaraSevkiyat=ankaraSevkiyat;
            this.genelTop = genelTop;
            this.sevkiyat1 = sevkiyat1;
            this.sevkiyat2 = sevkiyat2;
        }

        public AmbarVeri(int uges, int mgeo, int sst, int rehis, int bakimOnarim, int geciciKabul, int kaliteTest, int hurda, int imes, int tekjen, int tescom, int inform, int mgm, int bd, int dBolgesi, int atolye, int bd2, int sarp, int bd3, int geciciKullanim)
        {
            this.uges = uges;
            this.mgeo = mgeo;
            this.sst = sst;
            this.rehis = rehis;
            this.bakimOnarim = bakimOnarim;
            this.geciciKabul = geciciKabul;
            this.kaliteTest = kaliteTest;
            this.hurda = hurda;
            this.imes = imes;
            this.tekjen= tekjen;
            this.tescom = tescom;
            this.inform= inform;
            this.mgm = mgm;
            this.bd = bd;
            this.dBolgesi=dBolgesi;
            this.atolye = atolye;
            this.bd2 = bd2;
            this.sarp= sarp;
            this.bd3 = bd3;
            this.geciciKullanim = geciciKullanim;
        }
    }
}
