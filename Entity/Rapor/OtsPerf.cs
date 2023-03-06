using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Rapor
{
    public class OtsPerf
    {
        int formNo; string bildirimNo, bolgeAdi; DateTime mudehaleTarihi, onarimTamamlanmaTarihi; string toplamSureGun, sure100, sure200, sure300, sure400, sure500, sure525, sure550, sure600, sure700, sure800, sure900, sure1000, sure1100, sure1200, sure1300, sure1400, sure1500, sure1600, sure1700; int adimSureDk; string islemAdimi, ilce, bolgeSorumlusu, kategori, proje;

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
        public string Sure525 { get => sure525; set => sure525 = value; }
        public string Sure550 { get => sure550; set => sure550 = value; }
        public string Sure1400 { get => sure1400; set => sure1400 = value; }
        public string Sure1500 { get => sure1500; set => sure1500 = value; }
        public string Sure1600 { get => sure1600; set => sure1600 = value; }
        public string Sure100 { get => sure100; set => sure100 = value; }
        public string Sure200 { get => sure200; set => sure200 = value; }
        public string Sure300 { get => sure300; set => sure300 = value; }
        public string Sure400 { get => sure400; set => sure400 = value; }
        public string Sure1700 { get => sure1700; set => sure1700 = value; }
        public string Ilce { get => ilce; set => ilce = value; }
        public string BolgeSorumlusu { get => bolgeSorumlusu; set => bolgeSorumlusu = value; }
        public string Kategori { get => kategori; set => kategori = value; }
        public string Proje { get => proje; set => proje = value; }

        public OtsPerf(int formNo, string bildirimNo, string bolgeAdi, DateTime mudehaleTarihi, DateTime onarimTamamlanmaTarihi, string toplamSureGun, string ilce,string bolgeSorumlusu,string kategori,string proje)
        {
            this.formNo = formNo;
            this.bildirimNo = bildirimNo;
            this.bolgeAdi = bolgeAdi;
            this.mudehaleTarihi = mudehaleTarihi;
            this.onarimTamamlanmaTarihi = onarimTamamlanmaTarihi;
            this.toplamSureGun = toplamSureGun;
            this.ilce= ilce;
            this.bolgeSorumlusu=bolgeSorumlusu;
            this.kategori = kategori;
            this.proje=proje;
        }

        public OtsPerf(int formNo, string bildirimNo, string bolgeAdi, DateTime mudehaleTarihi, DateTime onarimTamamlanmaTarihi, string toplamSureGun, string sure100,string sure200,string sure300,string sure400,string sure500, string sure525, string sure550,string sure600, string sure700, string sure800, string sure900, string sure1000, string sure1100, string sure1200, string sure1300, string sure1400,string sure1500,string sure1600, string sure1700,string ilce, string bolgeSorumlusu, string kategori, string proje) : this(formNo, bildirimNo, bolgeAdi, mudehaleTarihi, onarimTamamlanmaTarihi, toplamSureGun, ilce, bolgeSorumlusu, kategori,proje)
        {
            this.sure100= sure100;
            this.sure200= sure200;
            this.sure300= sure300;
            this.sure400= sure400;
            this.sure500 = sure500;
            this.sure600 = sure600;
            this.sure700 = sure700;
            this.sure800 = sure800;
            this.sure900 = sure900;
            this.sure1000 = sure1000;
            this.sure1100 = sure1100;
            this.sure1200 = sure1200;
            this.sure1300 = sure1300;
            this.sure525 = sure525;
            this.sure550 = sure550;
            this.sure1400=sure1400;
            this.sure1500 = sure1500;
            this.sure1600 = sure1600;
            this.Sure1700 = sure1700;
            this.ilce= ilce;
            this.bolgeSorumlusu=bolgeSorumlusu;
            this.kategori= kategori;
            this.proje= proje;
        }

        public OtsPerf(int formNo, string islemAdimi, int adimSureDk)
        {
            this.formNo = formNo;
            this.adimSureDk = adimSureDk;
            this.islemAdimi = islemAdimi;
        }
    }
}
