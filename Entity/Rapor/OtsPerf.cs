using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Rapor
{
    public class OtsPerf
    {
        int formNo; string bildirimNo, bolgeAdi; DateTime mudehaleTarihi, onarimTamamlanmaTarihi; string toplamSureGun, sure500, sure600, sure700, sure800, sure900, sure1000, sure1100, sure1200, sure1300; int adimSureDk; string islemAdimi;

        public int FormNo { get => formNo; set => formNo = value; }
        public string BildirimNo { get => bildirimNo; set => bildirimNo = value; }
        public string BolgeAdi { get => bolgeAdi; set => bolgeAdi = value; }
        public DateTime MudehaleTarihi { get => mudehaleTarihi; set => mudehaleTarihi = value; }
        public DateTime OnarimTamamlanmaTarihi { get => onarimTamamlanmaTarihi; set => onarimTamamlanmaTarihi = value; }
        public string ToplamSureGun { get => toplamSureGun; set => toplamSureGun = value; }
        public string Sure500 { get => sure500; set => sure500 = value; }
        public string Sure600 { get => sure600; set => sure600 = value; }
        public string Sure700 { get => sure700; set => sure700 = value; }
        public string Sure800 { get => sure800; set => sure800 = value; }
        public string Sure900 { get => sure900; set => sure900 = value; }
        public string Sure1000 { get => sure1000; set => sure1000 = value; }
        public string Sure1100 { get => sure1100; set => sure1100 = value; }
        public string Sure1200 { get => sure1200; set => sure1200 = value; }
        public string Sure1300 { get => sure1300; set => sure1300 = value; }
        public int AdimSureDk { get => adimSureDk; set => adimSureDk = value; }
        public string IslemAdimi { get => islemAdimi; set => islemAdimi = value; }

        public OtsPerf(int formNo, string bildirimNo, string bolgeAdi, DateTime mudehaleTarihi, DateTime onarimTamamlanmaTarihi, string toplamSureGun)
        {
            this.formNo = formNo;
            this.bildirimNo = bildirimNo;
            this.bolgeAdi = bolgeAdi;
            this.mudehaleTarihi = mudehaleTarihi;
            this.onarimTamamlanmaTarihi = onarimTamamlanmaTarihi;
            this.toplamSureGun = toplamSureGun;
        }

        public OtsPerf(int formNo, string bildirimNo, string bolgeAdi, DateTime mudehaleTarihi, DateTime onarimTamamlanmaTarihi, string toplamSureGun, string sure500, string sure600, string sure700, string sure800, string sure900, string sure1000, string sure1100, string sure1200, string sure1300) : this(formNo, bildirimNo, bolgeAdi, mudehaleTarihi, onarimTamamlanmaTarihi, toplamSureGun)
        {
            this.sure500 = sure500;
            this.sure600 = sure600;
            this.sure700 = sure700;
            this.sure800 = sure800;
            this.sure900 = sure900;
            this.sure1000 = sure1000;
            this.sure1100 = sure1100;
            this.sure1200 = sure1200;
            this.sure1300 = sure1300;
        }

        public OtsPerf(int formNo, string islemAdimi, int adimSureDk)
        {
            this.formNo = formNo;
            this.adimSureDk = adimSureDk;
            this.islemAdimi = islemAdimi;
        }
    }
}
