using Business;
using Business.Concreate.BakimOnarimAtolye;
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
using SeriesCollection = LiveCharts.SeriesCollection;
using Business.Concreate.AnaSayfa;
using Entity.AnaSayfa;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmIslemAdimlariGrafik : Form
    {
        ArizaIslemAdimiManager arizaIslemAdimiManager;
        ArizaAyManager arizaAyManager;

        int tamamlananOcakToplam, tamamlananSubatToplam, tamamlananMartToplam, tamamlananNisanToplam, tamamlananMayisToplam, tamamlananHaziranToplam, tamamlananTemmuzToplam, tamamlananAgustosToplam, tamamlananEylulToplam, tamamlananEkimToplam, tamamlananKasimToplam, tamamlananAraliikToplam, tamamlananGenelToplam;

        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = DateTime.Now.ToString("HH:mm:ss");
            LblTarih.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataDisplay();
        }

        int devamEdenOcakToplam, devamEdenSubatToplam, devamEdenMartToplam, devamEdenNisanToplam, devamEdenMayisToplam, devamEdenHaziranToplam, devamEdenTemmuzToplam, devamEdenAgustosToplam, devamEdenEylulToplam, devamEdenEkimToplam, devamEdenKasimToplam, devamEdenAraliikToplam, devamEdenGenelToplam;

        public SeriesCollection SeriesCollection { get; set; }

        public string[] Labels { get; set; }
        public Func<double, string> Values { get; set; }

        public FrmIslemAdimlariGrafik()
        {
            InitializeComponent();
            arizaIslemAdimiManager = ArizaIslemAdimiManager.GetInstance();
            arizaAyManager = ArizaAyManager.GetInstance();
        }

        private void FrmIslemAdimlariGrafik_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimerSaat.Stop();
            timer1.Stop();
        }

        private void FrmIslemAdimlariGrafik_Load(object sender, EventArgs e)
        {
            TimerSaat.Start();
            DataDisplay();
            timer1.Start();
        }
        void DataDisplay()
        {
            tamamlananOcakToplam = tamamlananSubatToplam = tamamlananMartToplam = tamamlananNisanToplam = tamamlananMayisToplam = tamamlananHaziranToplam = tamamlananTemmuzToplam = tamamlananAgustosToplam = tamamlananEylulToplam = tamamlananEkimToplam = tamamlananKasimToplam = tamamlananAraliikToplam = tamamlananGenelToplam = 0;

            devamEdenOcakToplam = devamEdenSubatToplam = devamEdenMartToplam = devamEdenNisanToplam = devamEdenMayisToplam = devamEdenHaziranToplam = devamEdenTemmuzToplam = devamEdenAgustosToplam = devamEdenEylulToplam = devamEdenEkimToplam = devamEdenKasimToplam = devamEdenAraliikToplam = devamEdenGenelToplam = 0;


            ArizaAy arizaAy = arizaAyManager.GetTumTamamlananlar("2023");
            ArizaAy arizaAyDevamEden = arizaAyManager.GetTumDevamEden("2023");

            tamamlananOcakToplam = arizaAy.Ocak;
            tamamlananSubatToplam = arizaAy.Subat;
            tamamlananMartToplam = arizaAy.Mart;
            tamamlananNisanToplam = arizaAy.Nisan;
            tamamlananMayisToplam = arizaAy.Mayis;
            tamamlananHaziranToplam = arizaAy.Haziran;
            tamamlananTemmuzToplam = arizaAy.Temmuz;
            tamamlananAgustosToplam = arizaAy.Agustos;
            tamamlananEylulToplam = arizaAy.Eylus;
            tamamlananEkimToplam = arizaAy.Ekim;
            tamamlananKasimToplam = arizaAy.Kasim;
            tamamlananAraliikToplam = arizaAy.Aralik;
            tamamlananGenelToplam = arizaAy.Toplam;

            devamEdenOcakToplam = arizaAyDevamEden.Ocak;
            devamEdenSubatToplam = arizaAyDevamEden.Subat;
            devamEdenMartToplam = arizaAyDevamEden.Mart;
            devamEdenNisanToplam = arizaAyDevamEden.Nisan;
            devamEdenMayisToplam = arizaAyDevamEden.Mayis;
            devamEdenHaziranToplam = arizaAyDevamEden.Haziran;
            devamEdenTemmuzToplam = arizaAyDevamEden.Temmuz;
            devamEdenAgustosToplam = arizaAyDevamEden.Agustos;
            devamEdenEylulToplam = arizaAyDevamEden.Eylus;
            devamEdenEkimToplam = arizaAyDevamEden.Ekim;
            devamEdenKasimToplam = arizaAyDevamEden.Kasim;
            devamEdenAraliikToplam = arizaAyDevamEden.Aralik;
            devamEdenGenelToplam = arizaAyDevamEden.Toplam;

            SeriesCollection = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "TAMAMLANAMLAR",
                    Values = new ChartValues<double> { tamamlananOcakToplam, tamamlananSubatToplam, tamamlananMartToplam, tamamlananNisanToplam, tamamlananMayisToplam, tamamlananHaziranToplam, tamamlananTemmuzToplam, tamamlananAgustosToplam, tamamlananEylulToplam, tamamlananEkimToplam, tamamlananKasimToplam, tamamlananAraliikToplam },
                    DataLabels = true,
                    FontSize= 25,
                },

                new StackedColumnSeries
                {
                    Title = "DEVAM EDENLER",
                    Values = new ChartValues<double> { devamEdenOcakToplam, devamEdenSubatToplam, devamEdenMartToplam, devamEdenNisanToplam, devamEdenMayisToplam, devamEdenHaziranToplam, devamEdenTemmuzToplam, devamEdenAgustosToplam, devamEdenEylulToplam, devamEdenEkimToplam, devamEdenKasimToplam, devamEdenAraliikToplam },
                    DataLabels = true,
                    FontSize= 25,
                }
            };

            Axis axisX = new Axis()
            {
                Separator = new Separator() { Step = 1, IsEnabled = false },
                Labels = new List<string>(),
                FontSize = 30,
            };

            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                FontSize = 25,
            });

            Labels = new[] { "OCAK\n" + "( " + (tamamlananOcakToplam + devamEdenOcakToplam).ToString() + " )", "ŞUBAT\n" + "( " + (tamamlananSubatToplam + devamEdenSubatToplam).ToString() + " )", "MART\n" + "( " + (tamamlananMartToplam + devamEdenMartToplam).ToString() + " )", "NİSAN\n" + "( " + (tamamlananNisanToplam + devamEdenNisanToplam).ToString() + " )", "MAYIS\n" + "( " + (tamamlananMayisToplam + devamEdenMayisToplam).ToString() + " )", "HAZİRAN\n" + "( " + (tamamlananHaziranToplam + devamEdenHaziranToplam).ToString() + " )", "TEMMUZ\n" + "( " + (tamamlananTemmuzToplam + devamEdenTemmuzToplam).ToString() + " )", "AĞUSTOS\n" + "( " + (tamamlananAgustosToplam + devamEdenAgustosToplam).ToString() + " )", "EYLÜL\n" + "( " + (tamamlananEylulToplam + devamEdenEylulToplam).ToString() + " )", "EKİM\n" + "( " + (tamamlananEkimToplam + devamEdenEkimToplam).ToString() + " )", "KASIM\n" + "( " + (tamamlananKasimToplam + devamEdenKasimToplam).ToString() + " )", "ARALIK\n" + "( " + (tamamlananAraliikToplam + devamEdenAraliikToplam).ToString() + " )" };

            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();

            for (int i = 0; i < SeriesCollection.Count; i++)
            {
                cartesianChart1.Series.Add(SeriesCollection[i]);
            }

            for (int i = 0; i < Labels.Length; i++)
            {
                axisX.Labels.Add(Labels[i].ToString());
            }

            cartesianChart1.AxisX.Add(axisX);
        }
        
    }
}
