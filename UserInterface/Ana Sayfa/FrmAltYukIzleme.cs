using Business;
using DataAccess.Concreate;
using Entity;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmAltYukIzleme : Form
    {
        ArizaIslemAdimiManager arizaIslemAdimiManager;
        List<int> veriler = new List<int>();

        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> Values { get; set; }

        public FrmAltYukIzleme()
        {
            InitializeComponent();
            arizaIslemAdimiManager = ArizaIslemAdimiManager.GetInstance();
        }

        private void FrmAltYukIzleme_Load(object sender, EventArgs e)
        {
            TimerSaat.Start();
            DataDisplay();
            timer1.Start();
            
        }

        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = DateTime.Now.ToString("HH:mm:ss");
            LblTarih.Text = DateTime.Now.ToLongDateString();
        }

        void DataDisplay()
        {
            ArizaIslemAdimi arizaIslemAdimi700 = arizaIslemAdimiManager.Get("700_OKF HAZIRLAMA");
            Lbl700Sirnak.Text = arizaIslemAdimi700.Sirnak.ToString();
            Lbl700Cukurca.Text = arizaIslemAdimi700.Cukurca.ToString();
            Lbl700Yukseova.Text = arizaIslemAdimi700.Yukseova.ToString();
            Lbl700Semdinli.Text = arizaIslemAdimi700.Semdinli.ToString();
            Lbl700Derecik.Text = (arizaIslemAdimi700.Derecik + arizaIslemAdimi700.Merkez).ToString();
            Lbl700DBolgesi.Text = arizaIslemAdimi700.DBolgesi.ToString();
            Lbl700Toplam.Text = arizaIslemAdimi700.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi750 = arizaIslemAdimiManager.Get("750_OKF HAZIRLAMA (ASELSAN)");
            Lbl750Sirnak.Text = arizaIslemAdimi750.Sirnak.ToString();
            Lbl750Cukurca.Text = arizaIslemAdimi750.Cukurca.ToString();
            Lbl750Yukseova.Text = arizaIslemAdimi750.Yukseova.ToString();
            Lbl750Semdinli.Text = arizaIslemAdimi750.Semdinli.ToString();
            Lbl750Derecik.Text = (arizaIslemAdimi750.Derecik + arizaIslemAdimi750.Merkez).ToString();
            Lbl750DBolgesi.Text = arizaIslemAdimi750.DBolgesi.ToString();
            Lbl750Toplam.Text = arizaIslemAdimi750.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi800 = arizaIslemAdimiManager.Get("800_MÜŞTERİ ONAYI");
            Lbl800Sirnak.Text = arizaIslemAdimi800.Sirnak.ToString();
            Lbl800Cukurca.Text = arizaIslemAdimi800.Cukurca.ToString();
            Lbl800Yukseova.Text = arizaIslemAdimi800.Yukseova.ToString();
            Lbl800Semdinli.Text = arizaIslemAdimi800.Semdinli.ToString();
            Lbl800Derecik.Text = (arizaIslemAdimi800.Derecik + arizaIslemAdimi800.Merkez).ToString();
            Lbl800DBolgesi.Text = arizaIslemAdimi800.DBolgesi.ToString();
            Lbl800Toplam.Text = arizaIslemAdimi800.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi200 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM SERVİS PLANLAMA");
            LblServisPSirnak.Text = arizaIslemAdimi200.Sirnak.ToString();
            LblLblServisPCukurca.Text = arizaIslemAdimi200.Cukurca.ToString();
            LblLblServisPYukseova.Text = arizaIslemAdimi200.Yukseova.ToString();
            LblLblServisPSemdinli.Text = arizaIslemAdimi200.Semdinli.ToString();
            LblLblServisPDerecik.Text = (arizaIslemAdimi200.Derecik + arizaIslemAdimi200.Merkez).ToString();
            LblLblServisPDBolgesi.Text = arizaIslemAdimi200.DBolgesi.ToString();
            LblServisPToplam.Text = arizaIslemAdimi200.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi300 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (ASELSAN NET)");
            LblAselsanSirnak.Text = arizaIslemAdimi300.Sirnak.ToString();
            LblAselsanCukurca.Text = arizaIslemAdimi300.Cukurca.ToString();
            LblAselsanYukseova.Text = arizaIslemAdimi300.Yukseova.ToString();
            LblAselsanSemdinli.Text = arizaIslemAdimi300.Semdinli.ToString();
            LblAselsanDerecik.Text = (arizaIslemAdimi300.Derecik + arizaIslemAdimi300.Merkez).ToString();
            LblAselsanDBolgesi.Text = arizaIslemAdimi300.DBolgesi.ToString();
            LblAselsanToplam.Text = arizaIslemAdimi300.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi400 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (TEKJEN)");
            LblTekjenSirnak.Text = arizaIslemAdimi400.Sirnak.ToString();
            LblTekjenCukurca.Text = arizaIslemAdimi400.Cukurca.ToString();
            LblTekjenYukseova.Text = arizaIslemAdimi400.Yukseova.ToString();
            LblTekjenSemdinli.Text = arizaIslemAdimi400.Semdinli.ToString();
            LblTekjenDerecik.Text = (arizaIslemAdimi400.Derecik + arizaIslemAdimi400.Merkez).ToString();
            LblTekjenDBolgesi.Text = arizaIslemAdimi400.DBolgesi.ToString();
            LblTekjenToplam.Text = arizaIslemAdimi400.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi500 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (TESKOM)");
            LblTescomSirnak.Text = arizaIslemAdimi500.Sirnak.ToString();
            LblTescomCukurca.Text = arizaIslemAdimi500.Cukurca.ToString();
            LblTescomYukseova.Text = arizaIslemAdimi500.Yukseova.ToString();
            LblTescomSemdinli.Text = arizaIslemAdimi500.Semdinli.ToString();
            LblTescomDerecik.Text = (arizaIslemAdimi500.Derecik + arizaIslemAdimi500.Merkez).ToString();
            LblTescomDBolgesi.Text = arizaIslemAdimi500.DBolgesi.ToString();
            LblTescomToplam.Text = arizaIslemAdimi500.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi600 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (İŞBİR)");
            LblIsbirSirnak.Text = arizaIslemAdimi600.Sirnak.ToString();
            LblIsbirCukurca.Text = arizaIslemAdimi600.Cukurca.ToString();
            LblIsbirYukseova.Text = arizaIslemAdimi600.Yukseova.ToString();
            LblIsbirSemdinli.Text = arizaIslemAdimi600.Semdinli.ToString();
            LblIsbirDerecik.Text = (arizaIslemAdimi600.Derecik + arizaIslemAdimi600.Merkez).ToString();
            LblIsbirDBolgesi.Text = arizaIslemAdimi600.DBolgesi.ToString();
            LblIsbirToplam.Text = arizaIslemAdimi600.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi00 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (VAN TECH)");
            LblVanTechSirnak.Text = arizaIslemAdimi00.Sirnak.ToString();
            LblVanTechCukurca.Text = arizaIslemAdimi00.Cukurca.ToString();
            LblVanTechYukseova.Text = arizaIslemAdimi00.Yukseova.ToString();
            LblVanTechSemdinli.Text = arizaIslemAdimi00.Semdinli.ToString();
            LblVanTechDerecik.Text = (arizaIslemAdimi00.Derecik + arizaIslemAdimi00.Merkez).ToString();
            LblVanTechDBolgesi.Text = arizaIslemAdimi00.DBolgesi.ToString();
            LblVanTechToplam.Text = arizaIslemAdimi00.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi0 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (ŞARK UPS)");
            LblSarkUpsSirnak.Text = arizaIslemAdimi0.Sirnak.ToString();
            LblSarkUpsCukurca.Text = arizaIslemAdimi0.Cukurca.ToString();
            LblSarkUpsYukseova.Text = arizaIslemAdimi0.Yukseova.ToString();
            LblSarkUpsSemdinli.Text = arizaIslemAdimi0.Semdinli.ToString();
            LblSarkUpsDerecik.Text = (arizaIslemAdimi0.Derecik + arizaIslemAdimi0.Merkez).ToString();
            LblSarkUpsDBolgesi.Text = arizaIslemAdimi0.DBolgesi.ToString();
            LblSarkUpsToplam.Text = arizaIslemAdimi0.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1000 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (MAKSELSAN)");
            LblMakelsanSirnak.Text = arizaIslemAdimi1000.Sirnak.ToString();
            LblMakelsanCukurca.Text = arizaIslemAdimi1000.Cukurca.ToString();
            LblMakelsanYukseova.Text = arizaIslemAdimi1000.Yukseova.ToString();
            LblMakelsanSemdinli.Text = arizaIslemAdimi1000.Semdinli.ToString();
            LblMakelsanDerecik.Text = (arizaIslemAdimi1000.Derecik + arizaIslemAdimi1000.Merkez).ToString();
            LblMakelsanDBolgesi.Text = arizaIslemAdimi1000.DBolgesi.ToString();
            LblMakelsanToplam.Text = arizaIslemAdimi1000.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1100 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (KELEŞ İNŞ)");
            LblKelesSirnak.Text = arizaIslemAdimi1100.Sirnak.ToString();
            LblKelesCukurca.Text = arizaIslemAdimi1100.Cukurca.ToString();
            LblKelesYukseova.Text = arizaIslemAdimi1100.Yukseova.ToString();
            LblKelesSemdinli.Text = arizaIslemAdimi1100.Semdinli.ToString();
            LblKelesDerecik.Text = (arizaIslemAdimi1100.Derecik + arizaIslemAdimi1100.Merkez).ToString();
            LblKelesDBolgesi.Text = arizaIslemAdimi1100.DBolgesi.ToString();
            LblKelesToplam.Text = arizaIslemAdimi1100.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1200 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (DORÇE)");
            LblDorceSirnak.Text = arizaIslemAdimi1200.Sirnak.ToString();
            LblDorceCukurca.Text = arizaIslemAdimi1200.Cukurca.ToString();
            LblDorceYukseova.Text = arizaIslemAdimi1200.Yukseova.ToString();
            LblDorceSemdinli.Text = arizaIslemAdimi1200.Semdinli.ToString();
            LblDorceDerecik.Text = (arizaIslemAdimi1200.Derecik + arizaIslemAdimi1200.Merkez).ToString();
            LblDorceDBolgesi.Text = arizaIslemAdimi1200.DBolgesi.ToString();
            LblDorceToplam.Text = arizaIslemAdimi1200.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1300 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (İNFORM)");
            LblInformSirnak.Text = arizaIslemAdimi1300.Sirnak.ToString();
            LblInformCukurca.Text = arizaIslemAdimi1300.Cukurca.ToString();
            LblInformYukseova.Text = arizaIslemAdimi1300.Yukseova.ToString();
            LblInformSemdinli.Text = arizaIslemAdimi1300.Semdinli.ToString();
            LblInformDerecik.Text = (arizaIslemAdimi1300.Derecik + arizaIslemAdimi1300.Merkez).ToString();
            LblInformDBolgesi.Text = arizaIslemAdimi1300.DBolgesi.ToString();
            LblInformToplam.Text = arizaIslemAdimi1300.Toplam.ToString();
            

            LblToplamSirnak.Text = (LblServisPSirnak.Text.ConInt() + LblAselsanSirnak.Text.ConInt() + LblTekjenSirnak.Text.ConInt() + LblTescomSirnak.Text.ConInt() + LblIsbirSirnak.Text.ConInt() + LblVanTechSirnak.Text.ConInt() + LblSarkUpsSirnak.Text.ConInt()+ LblMakelsanSirnak.Text.ConInt() + LblKelesSirnak.Text.ConInt() + LblDorceSirnak.Text.ConInt() + LblInformSirnak.Text.ConInt() + Lbl700Sirnak.Text.ConInt() + Lbl750Sirnak.Text.ConInt()+ Lbl800Sirnak.Text.ConInt()).ToString();

            LblToplamCukurca.Text = (LblLblServisPCukurca.Text.ConInt() + LblAselsanCukurca.Text.ConInt() + LblTekjenCukurca.Text.ConInt() + LblTescomCukurca.Text.ConInt() + LblIsbirCukurca.Text.ConInt() + LblVanTechCukurca.Text.ConInt() + LblSarkUpsCukurca.Text.ConInt() + LblMakelsanCukurca.Text.ConInt() + LblKelesCukurca.Text.ConInt() + LblDorceCukurca.Text.ConInt() + LblInformCukurca.Text.ConInt() + Lbl700Cukurca.Text.ConInt() + Lbl750Cukurca.Text.ConInt() + Lbl800Cukurca.Text.ConInt()).ToString();

            LblToplamYukseova.Text = (LblLblServisPYukseova.Text.ConInt() + LblAselsanYukseova.Text.ConInt() + LblTekjenYukseova.Text.ConInt() + LblTescomYukseova.Text.ConInt() + LblIsbirYukseova.Text.ConInt() + LblVanTechYukseova.Text.ConInt() + LblSarkUpsYukseova.Text.ConInt() + LblMakelsanYukseova.Text.ConInt() + LblKelesYukseova.Text.ConInt() + LblDorceYukseova.Text.ConInt() + LblInformYukseova.Text.ConInt() + Lbl700Yukseova.Text.ConInt() + Lbl750Yukseova.Text.ConInt() + Lbl800Yukseova.Text.ConInt()).ToString();

            LblToplamSemdinli.Text = (LblLblServisPSemdinli.Text.ConInt() + LblAselsanSemdinli.Text.ConInt() + LblTekjenSemdinli.Text.ConInt() + LblTescomSemdinli.Text.ConInt() + LblIsbirSemdinli.Text.ConInt() + LblVanTechSemdinli.Text.ConInt() + LblSarkUpsSemdinli.Text.ConInt() + LblMakelsanSemdinli.Text.ConInt() + LblKelesSemdinli.Text.ConInt() + LblDorceSemdinli.Text.ConInt() + LblInformSemdinli.Text.ConInt() + Lbl700Semdinli.Text.ConInt() + Lbl750Semdinli.Text.ConInt() + Lbl800Semdinli.Text.ConInt()).ToString();

            LblToplamDerecik.Text = (LblLblServisPDerecik.Text.ConInt() + LblAselsanDerecik.Text.ConInt() + LblTekjenDerecik.Text.ConInt() + LblTescomDerecik.Text.ConInt() + LblIsbirDerecik.Text.ConInt() + LblVanTechDerecik.Text.ConInt() + LblSarkUpsDerecik.Text.ConInt() + LblMakelsanDerecik.Text.ConInt() + LblKelesDerecik.Text.ConInt() + LblDorceDerecik.Text.ConInt() + LblInformDerecik.Text.ConInt() + Lbl700Derecik.Text.ConInt() + Lbl750Derecik.Text.ConInt() + Lbl800Derecik.Text.ConInt()).ToString();

            LblToplamDBolgesi.Text = (LblLblServisPDBolgesi.Text.ConInt() + LblAselsanDBolgesi.Text.ConInt() + LblTekjenDBolgesi.Text.ConInt() + LblTescomDBolgesi.Text.ConInt() + LblIsbirDBolgesi.Text.ConInt() + LblVanTechDBolgesi.Text.ConInt() + LblSarkUpsDBolgesi.Text.ConInt() + LblSarkUpsDBolgesi.Text.ConInt() + LblMakelsanDBolgesi.Text.ConInt() + LblKelesDBolgesi.Text.ConInt() + LblDorceDBolgesi.Text.ConInt() + LblInformDBolgesi.Text.ConInt() + Lbl700DBolgesi.Text.ConInt() + Lbl750DBolgesi.Text.ConInt() + Lbl800DBolgesi.Text.ConInt()).ToString();

            LblGenelToplam.Text = (LblServisPToplam.Text.ConInt() + LblAselsanToplam.Text.ConInt() + LblTekjenToplam.Text.ConInt() + LblTescomToplam.Text.ConInt() + LblIsbirToplam.Text.ConInt() + LblVanTechToplam.Text.ConInt() + LblSarkUpsToplam.Text.ConInt() + LblMakelsanToplam.Text.ConInt() + LblKelesToplam.Text.ConInt() + LblDorceToplam.Text.ConInt() + LblInformToplam.Text.ConInt() + Lbl700Toplam.Text.ConInt() + Lbl750Toplam.Text.ConInt() + Lbl800Toplam.Text.ConInt()).ToString();

            LblTop.Text = LblGenelToplam.Text;

            LblUcTop.Text = (Lbl700Toplam.Text.ConInt() + Lbl750Toplam.Text.ConInt() + Lbl800Toplam.Text.ConInt()).ToString();

            GrafikFill();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void FrmAltYukIzleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            TimerSaat.Stop();
            FrmAnaSayfa anaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnaSayfa"];
            anaSayfa.timerIzlemeChc.Stop();
        }

        void GrafikFill()
        {
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "TOPLAM= ",
                    Values = new ChartValues<double> { Lbl700Toplam.Text.ConDouble(), Lbl750Toplam.Text.ConDouble(), Lbl800Toplam.Text.ConDouble(), LblServisPToplam.Text.ConDouble(), LblAselsanToplam.Text.ConDouble(), LblTekjenToplam.Text.ConDouble(), LblTescomToplam.Text.ConDouble(), LblIsbirToplam.Text.ConDouble(), LblVanTechToplam.Text.ConDouble(), LblSarkUpsToplam.Text.ConDouble(), LblMakelsanToplam.Text.ConDouble(), LblKelesToplam.Text.ConDouble(), LblDorceToplam.Text.ConDouble(), LblInformToplam.Text.ConDouble() },
                    DataLabels = true,
                    FontSize= 15,
                }
            };

            Axis axisX = new Axis()
            {
                Separator = new Separator() { Step = 1, IsEnabled = false },
                Labels = new List<string>()
            };

            Values = value => value.ToString("C2");

            ChrtIslemAdimlari.Series.Clear();
            ChrtIslemAdimlari.Series.Add(SeriesCollection[0]);

            axisX.Labels.Add("700");
            axisX.Labels.Add("750");
            axisX.Labels.Add("800");
            axisX.Labels.Add("SERVİS\nTALEBİ");
            axisX.Labels.Add("ASELSANNET");
            axisX.Labels.Add("TEKJEN");
            axisX.Labels.Add("TESCOM");
            axisX.Labels.Add("İŞBİR");
            axisX.Labels.Add("VAN TECH");
            axisX.Labels.Add("ŞARK UPS");
            axisX.Labels.Add("MAKELSAN");
            axisX.Labels.Add("KELEŞ İNŞ");
            axisX.Labels.Add("DORCE");
            axisX.Labels.Add("İNFORM");

            ChrtIslemAdimlari.AxisX.Clear();
            ChrtIslemAdimlari.AxisX.Add(axisX);

            axisX.FontSize = 14;


            SeriesCollection seriesCollection = new SeriesCollection();

            veriler.Add(Lbl700Toplam.Text.ConInt());
            veriler.Add(Lbl750Toplam.Text.ConInt());
            veriler.Add(Lbl800Toplam.Text.ConInt());

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    Func<ChartPoint, string> func = x => string.Format("{0}\n{1:P}", "OKF HAZIRLAMA", x.Participation);
                    seriesCollection.Add(new PieSeries() { Title = "700_OKF HAZIRLAMA", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 12 });
                    chart1.Series = seriesCollection;
                }

                if (i == 1)
                {
                    Func<ChartPoint, string> func = x => string.Format("{0}\n{1:P}", "OKF HAZIRLAMA(ASL)", x.Participation);
                    seriesCollection.Add(new PieSeries() { Title = "750_OKF HAZIRLAMA (ASELSAN)", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 12 });
                    chart1.Series = seriesCollection;
                }

                if (i == 2)
                {
                    Func<ChartPoint, string> func = x => string.Format("{0}\n{1:P}", "MÜŞTERİ ONAYI", x.Participation);
                    seriesCollection.Add(new PieSeries() { Title = "800_MÜŞTERİ ONAYI", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 12 });
                    chart1.Series = seriesCollection;
                }
            }

        }

    }
}
