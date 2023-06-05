using Business;
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

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmSektorIslemAdimlari : Form
    {
        ArizaIslemAdimiManager arizaIslemAdimiManager;
        bool ilk = true;
        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> Values { get; set; }

        public FrmSektorIslemAdimlari()
        {
            InitializeComponent();
            arizaIslemAdimiManager = ArizaIslemAdimiManager.GetInstance();
        }

        private void FrmSektorIslemAdimlari_Load(object sender, EventArgs e)
        {
            DataDisplay();
            timer1.Start();

        }
        void DataDisplay()
        {
            int sirnak200, sirnak300, sirnak400, sirnak500, sirnak600, sirnak700, sirnak750, sirnak800, sirnak900, sirnak950, sirnak1000, sirnak1100, sirnak1200, sirnak1300, sirnak1400, sirnak1450, sirnak1500, sirnak1600, sirnak1700, sirnak1800, sirnak1900, sirnak2000, sirnak2100;

            int cukurca200, cukurca300, cukurca400, cukurca500, cukurca600, cukurca700, cukurca750, cukurca800, cukurca900, cukurca950, cukurca1000, cukurca1100, cukurca1200, cukurca1300, cukurca1400, cukurca1450, cukurca1500, cukurca1600, cukurca1700, cukurca1800, cukurca1900, cukurca2000, cukurca2100;

            int yukseova200, yukseova300, yukseova400, yukseova500, yukseova600, yukseova700, yukseova750, yukseova800, yukseova900, yukseova950, yukseova1000, yukseova1100, yukseova1200, yukseova1300, yukseova1400, yukseova1450, yukseova1500, yukseova1600, yukseova1700, yukseova1800, yukseova1900, yukseova2000, yukseova2100;

            int semdinli200, semdinli300, semdinli400, semdinli500, semdinli600, semdinli700, semdinli750, semdinli800, semdinli900, semdinli950, semdinli1000, semdinli1100, semdinli1200, semdinli1300, semdinli1400, semdinli1450, semdinli1500, semdinli1600, semdinli1700, semdinli1800, semdinli1900, semdinli2000, semdinli2100;

            int derecik200, derecik300, derecik400, derecik500, derecik600, derecik700, derecik750, derecik800, derecik900, derecik950, derecik1000, derecik1100, derecik1200, derecik1300, derecik1400, derecik1450, derecik1500, derecik1600, derecik1700, derecik1800, derecik1900, derecik2000, derecik2100;

            int dBolgesi200, dBolgesi300, dBolgesi400, dBolgesi500, dBolgesi600, dBolgesi700, dBolgesi750, dBolgesi800, dBolgesi900, dBolgesi950, dBolgesi1000, dBolgesi1100, dBolgesi1200, dBolgesi1300, dBolgesi1400, dBolgesi1450, dBolgesi1500, dBolgesi1600, dBolgesi1700, dBolgesi1800, dBolgesi1900, dBolgesi2000, dBolgesi2100;

            ArizaIslemAdimi arizaIslemAdimi200 = arizaIslemAdimiManager.Get("200_ARIZA TESPİTİ (FI/FD) (SAHA)");
            sirnak200 = arizaIslemAdimi200.Sirnak;
            cukurca200 = arizaIslemAdimi200.Cukurca;
            yukseova200 = arizaIslemAdimi200.Yukseova;
            semdinli200 = arizaIslemAdimi200.Semdinli;
            derecik200 = (arizaIslemAdimi200.Derecik + arizaIslemAdimi200.Merkez);
            dBolgesi200 = arizaIslemAdimi200.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi300 = arizaIslemAdimiManager.Get("300_ONARIM SONRASI ARIZA TESPİTİ (SAHA)");
            sirnak300 = arizaIslemAdimi300.Sirnak;
            cukurca300 = arizaIslemAdimi300.Cukurca;
            yukseova300 = arizaIslemAdimi300.Yukseova;
            semdinli300 = arizaIslemAdimi300.Semdinli;
            derecik300 = (arizaIslemAdimi300.Derecik + arizaIslemAdimi300.Merkez);
            dBolgesi300 = arizaIslemAdimi300.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi400 = arizaIslemAdimiManager.Get("400_SİPARİŞ OLUŞTURMA (DTS)");
            sirnak400 = arizaIslemAdimi400.Sirnak;
            cukurca400 = arizaIslemAdimi400.Cukurca;
            yukseova400 = arizaIslemAdimi400.Yukseova;
            semdinli400 = arizaIslemAdimi400.Semdinli;
            derecik400 = (arizaIslemAdimi400.Derecik + arizaIslemAdimi400.Merkez);
            dBolgesi400 = arizaIslemAdimi400.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi500 = arizaIslemAdimiManager.Get("500_ARIZA BİLDİRİMİ (ASELSAN)");
            sirnak500 = arizaIslemAdimi500.Sirnak;
            cukurca500 = arizaIslemAdimi500.Cukurca;
            yukseova500 = arizaIslemAdimi500.Yukseova;
            semdinli500 = arizaIslemAdimi500.Semdinli;
            derecik500 = (arizaIslemAdimi500.Derecik + arizaIslemAdimi500.Merkez);
            dBolgesi500 = arizaIslemAdimi500.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi600 = arizaIslemAdimiManager.Get("600_BİLDİRİM ONAYI (MÜHENDİS)");
            sirnak600 = arizaIslemAdimi600.Sirnak;
            cukurca600 = arizaIslemAdimi600.Cukurca;
            yukseova600 = arizaIslemAdimi600.Yukseova;
            semdinli600 = arizaIslemAdimi600.Semdinli;
            derecik600 = (arizaIslemAdimi600.Derecik + arizaIslemAdimi600.Merkez);
            dBolgesi600 = arizaIslemAdimi600.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi700 = arizaIslemAdimiManager.Get("700_OKF HAZIRLAMA");
            sirnak700 = arizaIslemAdimi700.Sirnak;
            cukurca700 = arizaIslemAdimi700.Cukurca;
            yukseova700 = arizaIslemAdimi700.Yukseova;
            semdinli700 = arizaIslemAdimi700.Semdinli;
            derecik700 = (arizaIslemAdimi700.Derecik + arizaIslemAdimi700.Merkez);
            dBolgesi700 = arizaIslemAdimi700.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi750 = arizaIslemAdimiManager.Get("750_OKF HAZIRLAMA (ASELSAN)");
            sirnak750 = arizaIslemAdimi750.Sirnak;
            cukurca750 = arizaIslemAdimi750.Cukurca;
            yukseova750 = arizaIslemAdimi750.Yukseova;
            semdinli750 = arizaIslemAdimi750.Semdinli;
            derecik750 = (arizaIslemAdimi750.Derecik + arizaIslemAdimi750.Merkez);
            dBolgesi750 = arizaIslemAdimi750.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi800 = arizaIslemAdimiManager.Get("800_MÜŞTERİ ONAYI");
            sirnak800 = arizaIslemAdimi800.Sirnak;
            cukurca800 = arizaIslemAdimi800.Cukurca;
            yukseova800 = arizaIslemAdimi800.Yukseova;
            semdinli800 = arizaIslemAdimi800.Semdinli;
            derecik800 = (arizaIslemAdimi800.Derecik + arizaIslemAdimi800.Merkez);
            dBolgesi800 = arizaIslemAdimi800.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi900 = arizaIslemAdimiManager.Get("900_FABRİKA BAKIM ONARIM (ASELSAN)");
            sirnak900 = arizaIslemAdimi900.Sirnak;
            cukurca900 = arizaIslemAdimi900.Cukurca;
            yukseova900 = arizaIslemAdimi900.Yukseova;
            semdinli900 = arizaIslemAdimi900.Semdinli;
            derecik900 = (arizaIslemAdimi900.Derecik + arizaIslemAdimi900.Merkez);
            dBolgesi900 = arizaIslemAdimi900.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi950 = arizaIslemAdimiManager.Get("950_ATÖLYE BAKIM ONARIM (VAN)");
            sirnak950 = arizaIslemAdimi950.Sirnak;
            cukurca950 = arizaIslemAdimi950.Cukurca;
            yukseova950 = arizaIslemAdimi950.Yukseova;
            semdinli950 = arizaIslemAdimi950.Semdinli;
            derecik950 = (arizaIslemAdimi950.Derecik + arizaIslemAdimi950.Merkez);
            dBolgesi950 = arizaIslemAdimi950.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi1000 = arizaIslemAdimiManager.Get("1000_DEPO STOK KONTROL");
            sirnak1000 = arizaIslemAdimi1000.Sirnak;
            cukurca1000 = arizaIslemAdimi1000.Cukurca;
            yukseova1000 = arizaIslemAdimi1000.Yukseova;
            semdinli1000 = arizaIslemAdimi1000.Semdinli;
            derecik1000 = (arizaIslemAdimi1000.Derecik + arizaIslemAdimi1000.Merkez);
            dBolgesi1000 = arizaIslemAdimi1000.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi1100 = arizaIslemAdimiManager.Get("1100_MALZEME TEMİNİ (SATIN ALMA)");
            sirnak1100 = arizaIslemAdimi1100.Sirnak;
            cukurca1100 = arizaIslemAdimi1100.Cukurca;
            yukseova1100 = arizaIslemAdimi1100.Yukseova;
            semdinli1100 = arizaIslemAdimi1100.Semdinli;
            derecik1100 = (arizaIslemAdimi1100.Derecik + arizaIslemAdimi1100.Merkez);
            dBolgesi1100 = arizaIslemAdimi1100.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi1200 = arizaIslemAdimiManager.Get("1200_MALZEME TEMİNİ (ASELSAN)");
            sirnak1200 = arizaIslemAdimi1200.Sirnak;
            cukurca1200 = arizaIslemAdimi1200.Cukurca;
            yukseova1200 = arizaIslemAdimi1200.Yukseova;
            semdinli1200 = arizaIslemAdimi1200.Semdinli;
            derecik1200 = (arizaIslemAdimi1200.Derecik + arizaIslemAdimi1200.Merkez);
            dBolgesi1200 = arizaIslemAdimi1200.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi1300 = arizaIslemAdimiManager.Get("1300_MALZEME HAZIRLAMA AMBAR");
            sirnak1300 = arizaIslemAdimi1300.Sirnak;
            cukurca1300 = arizaIslemAdimi1300.Cukurca;
            yukseova1300 = arizaIslemAdimi1300.Yukseova;
            semdinli1300 = arizaIslemAdimi1300.Semdinli;
            derecik1300 = (arizaIslemAdimi1300.Derecik + arizaIslemAdimi1300.Merkez);
            dBolgesi1300 = arizaIslemAdimi1300.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi1400 = arizaIslemAdimiManager.Get("1400_SEVKİYAT (ANKARA)");
            sirnak1400 = arizaIslemAdimi1400.Sirnak;
            cukurca1400 = arizaIslemAdimi1400.Cukurca;
            yukseova1400 = arizaIslemAdimi1400.Yukseova;
            semdinli1400 = arizaIslemAdimi1400.Semdinli;
            derecik1400 = (arizaIslemAdimi1400.Derecik + arizaIslemAdimi1400.Merkez);
            dBolgesi1400 = arizaIslemAdimi1400.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi1400B = arizaIslemAdimiManager.Get("1450_SEVKİYAT (BÖLGE)");
            sirnak1450 = arizaIslemAdimi1400B.Sirnak;
            cukurca1450 = arizaIslemAdimi1400B.Cukurca;
            yukseova1450 = arizaIslemAdimi1400B.Yukseova;
            semdinli1450 = arizaIslemAdimi1400B.Semdinli;
            derecik1450 = (arizaIslemAdimi1400B.Derecik + arizaIslemAdimi1400B.Merkez);
            dBolgesi1450 = arizaIslemAdimi1400B.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi1500 = arizaIslemAdimiManager.Get("1500_BAKIM ONARIM (SAHA)");
            sirnak1500 = arizaIslemAdimi1500.Sirnak;
            cukurca1500 = arizaIslemAdimi1500.Cukurca;
            yukseova1500 = arizaIslemAdimi1500.Yukseova;
            semdinli1500 = arizaIslemAdimi1500.Semdinli;
            derecik1500 = (arizaIslemAdimi1500.Derecik + arizaIslemAdimi1500.Merkez);
            dBolgesi1500 = arizaIslemAdimi1500.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi1600 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (SERVİS)");
            sirnak1600 = arizaIslemAdimi1600.Sirnak;
            cukurca1600 = arizaIslemAdimi1600.Cukurca;
            yukseova1600 = arizaIslemAdimi1600.Yukseova;
            semdinli1600 = arizaIslemAdimi1600.Semdinli;
            derecik1600 = (arizaIslemAdimi1600.Derecik + arizaIslemAdimi1600.Merkez);
            dBolgesi1600 = arizaIslemAdimi1600.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi1700 = arizaIslemAdimiManager.Get("1700_FONKSİYONEL TEST");
            sirnak1700 = arizaIslemAdimi1700.Sirnak;
            cukurca1700 = arizaIslemAdimi1700.Cukurca;
            yukseova1700 = arizaIslemAdimi1700.Yukseova;
            semdinli1700 = arizaIslemAdimi1700.Semdinli;
            derecik1700 = (arizaIslemAdimi1700.Derecik + arizaIslemAdimi1700.Merkez);
            dBolgesi1700 = arizaIslemAdimi1700.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi1800 = arizaIslemAdimiManager.Get("1800_DENETİM");
            sirnak1800 = arizaIslemAdimi1800.Sirnak;
            cukurca1800 = arizaIslemAdimi1800.Cukurca;
            yukseova1800 = arizaIslemAdimi1800.Yukseova;
            semdinli1800 = arizaIslemAdimi1800.Semdinli;
            derecik1800 = (arizaIslemAdimi1800.Derecik + arizaIslemAdimi1800.Merkez);
            dBolgesi1800 = arizaIslemAdimi1800.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi1900 = arizaIslemAdimiManager.Get("1900_MÜŞTERİ TESLİMATI");
            sirnak1900 = arizaIslemAdimi1900.Sirnak;
            cukurca1900 = arizaIslemAdimi1900.Cukurca;
            yukseova1900 = arizaIslemAdimi1900.Yukseova;
            semdinli1900 = arizaIslemAdimi1900.Semdinli;
            derecik1900 = (arizaIslemAdimi1900.Derecik + arizaIslemAdimi1900.Merkez);
            dBolgesi1900 = arizaIslemAdimi1900.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi2000 = arizaIslemAdimiManager.Get("2000_ARIZA KAPATMA (DTS)");
            sirnak2000 = arizaIslemAdimi2000.Sirnak;
            cukurca2000 = arizaIslemAdimi2000.Cukurca;
            yukseova2000 = arizaIslemAdimi2000.Yukseova;
            semdinli2000 = arizaIslemAdimi2000.Semdinli;
            derecik2000 = (arizaIslemAdimi2000.Derecik + arizaIslemAdimi2000.Merkez);
            dBolgesi2000 = arizaIslemAdimi2000.DBolgesi;

            ArizaIslemAdimi arizaIslemAdimi2100 = arizaIslemAdimiManager.Get("2100_ARIZA KAPATMA BİLDİRİMİ (ASELSAN)");
            sirnak2100 = arizaIslemAdimi2100.Sirnak;
            cukurca2100 = arizaIslemAdimi2100.Cukurca;
            yukseova2100 = arizaIslemAdimi2100.Yukseova;
            semdinli2100 = arizaIslemAdimi2100.Semdinli;
            derecik2100 = (arizaIslemAdimi2100.Derecik + arizaIslemAdimi2100.Merkez);
            dBolgesi2100 = arizaIslemAdimi2100.DBolgesi;

            
            if (ilk == false)
            {
                LblSirnak.Text = "ŞIRNAK";
            }

            int sirnakToplam = sirnak200 + sirnak300 + sirnak400 + sirnak500 + sirnak600 + sirnak700 + sirnak750 + sirnak800 + sirnak900 + sirnak950 + sirnak1000 + sirnak1100 + sirnak1200 + sirnak1300 + sirnak1400 + sirnak1450 + sirnak1500 + sirnak1600 + sirnak1700 + sirnak1800 + sirnak1900 + sirnak2000 + sirnak2100;

            LblSirnak.Text = LblSirnak.Text + " = " + sirnakToplam;

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "ŞIRNAK",
                    Values = new ChartValues<double> { sirnak200, sirnak300, sirnak400, sirnak500, sirnak600, sirnak700, sirnak750, sirnak800, sirnak900, sirnak950, sirnak1000, sirnak1100, sirnak1200, sirnak1300, sirnak1400, sirnak1450, sirnak1500, sirnak1600, sirnak1700, sirnak1800, sirnak1900, sirnak2000, sirnak2100 },
                    DataLabels = true,
                    FontSize= 15,
                }
            };

            Axis axisX = new Axis()
            {
                Separator = new Separator() { Step = 1, IsEnabled = false },
                Labels = new List<string>()
            };

            Values = value => value.ToString();

            ChrSirnak.Series.Clear();
            ChrSirnak.Series.Add(SeriesCollection[0]);

            ChrSirnak.AxisX.Clear();

            axisX.Labels.Add("200");
            axisX.Labels.Add("300");
            axisX.Labels.Add("400");
            axisX.Labels.Add("500");
            axisX.Labels.Add("600");
            axisX.Labels.Add("700");
            axisX.Labels.Add("750");
            axisX.Labels.Add("800");
            axisX.Labels.Add("900");
            axisX.Labels.Add("950");
            axisX.Labels.Add("1000");
            axisX.Labels.Add("1100");
            axisX.Labels.Add("1200");
            axisX.Labels.Add("1300");
            axisX.Labels.Add("1400");
            axisX.Labels.Add("1450");
            axisX.Labels.Add("1500");
            axisX.Labels.Add("1600");
            axisX.Labels.Add("1700");
            axisX.Labels.Add("1800");
            axisX.Labels.Add("1900");
            axisX.Labels.Add("2000");
            axisX.Labels.Add("2100");

            ChrSirnak.AxisX.Add(axisX);

            axisX.FontSize = 14;



            int cukurcaToplam = cukurca200 + cukurca300 + cukurca400 + cukurca500 + cukurca600 + cukurca700 + cukurca750 + cukurca800 + cukurca900 + cukurca950 + cukurca1000 + cukurca1100 + cukurca1200 + cukurca1300 + cukurca1400 + cukurca1450 + cukurca1500 + cukurca1600 + cukurca1700 + cukurca1800 + cukurca1900 + cukurca2000 + cukurca2100;

            if (ilk == false)
            {
                LblCukurca.Text = "ÇUKURCA";
            }
            LblCukurca.Text = LblCukurca.Text + " = " + cukurcaToplam;

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "ÇUKURCA",
                    Values = new ChartValues<double> { cukurca200, cukurca300, cukurca400, cukurca500, cukurca600, cukurca700, cukurca750, cukurca800, cukurca900, cukurca950, cukurca1000, cukurca1100, cukurca1200, cukurca1300, cukurca1400, cukurca1450, cukurca1500, cukurca1600, cukurca1700, cukurca1800, cukurca1900, cukurca2000, cukurca2100 },
                    DataLabels = true,
                    FontSize= 15,
                }
            };

            Axis axisX2 = new Axis()
            {
                Separator = new Separator() { Step = 1, IsEnabled = false },
                Labels = new List<string>()
            };


            Values = value => value.ToString();

            ChrCukurca.Series.Clear();
            ChrCukurca.Series.Add(SeriesCollection[0]);

            ChrCukurca.AxisX.Clear();

            axisX2.Labels.Add("200");
            axisX2.Labels.Add("300");
            axisX2.Labels.Add("400");
            axisX2.Labels.Add("500");
            axisX2.Labels.Add("600");
            axisX2.Labels.Add("700");
            axisX2.Labels.Add("750");
            axisX2.Labels.Add("800");
            axisX2.Labels.Add("900");
            axisX2.Labels.Add("950");
            axisX2.Labels.Add("1000");
            axisX2.Labels.Add("1100");
            axisX2.Labels.Add("1200");
            axisX2.Labels.Add("1300");
            axisX2.Labels.Add("1400");
            axisX2.Labels.Add("1450");
            axisX2.Labels.Add("1500");
            axisX2.Labels.Add("1600");
            axisX2.Labels.Add("1700");
            axisX2.Labels.Add("1800");
            axisX2.Labels.Add("1900");
            axisX2.Labels.Add("2000");
            axisX2.Labels.Add("2100");

            ChrCukurca.AxisX.Add(axisX2);
            axisX2.FontSize = 14;


            int yukseovaToplam = yukseova200 + yukseova300 + yukseova400 + yukseova500 + yukseova600 + yukseova700 + yukseova750 + yukseova800 + yukseova900 + yukseova950 + yukseova1000 + yukseova1100 + yukseova1200 + yukseova1300 + yukseova1400 + yukseova1450 + yukseova1500 + yukseova1600 + yukseova1700 + yukseova1800 + yukseova1900 + yukseova2000 + yukseova2100;

            if (ilk == false)
            {
                LblYuksekova.Text = "YÜKSEKOVA";
            }
            LblYuksekova.Text = LblYuksekova.Text + " = " + yukseovaToplam;

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "YÜKSEKOVA",
                    Values = new ChartValues<double> { yukseova200, yukseova300, yukseova400, yukseova500, yukseova600, yukseova700, yukseova750, yukseova800, yukseova900, yukseova950, yukseova1000, yukseova1100, yukseova1200, yukseova1300, yukseova1400, yukseova1450, yukseova1500, yukseova1600, yukseova1700, yukseova1800, yukseova1900, yukseova2000, yukseova2100 },
                    DataLabels = true,
                    FontSize= 15,
                }
            };

            Axis axisX3 = new Axis()
            {
                Separator = new Separator() { Step = 1, IsEnabled = false },
                Labels = new List<string>()
            };


            Values = value => value.ToString();

            ChrYuksekova.Series.Clear();
            ChrYuksekova.Series.Add(SeriesCollection[0]);

            ChrYuksekova.AxisX.Clear();

            axisX3.Labels.Add("200");
            axisX3.Labels.Add("300");
            axisX3.Labels.Add("400");
            axisX3.Labels.Add("500");
            axisX3.Labels.Add("600");
            axisX3.Labels.Add("700");
            axisX3.Labels.Add("750");
            axisX3.Labels.Add("800");
            axisX3.Labels.Add("900");
            axisX3.Labels.Add("950");
            axisX3.Labels.Add("1000");
            axisX3.Labels.Add("1100");
            axisX3.Labels.Add("1200");
            axisX3.Labels.Add("1300");
            axisX3.Labels.Add("1400");
            axisX3.Labels.Add("1450");
            axisX3.Labels.Add("1500");
            axisX3.Labels.Add("1600");
            axisX3.Labels.Add("1700");
            axisX3.Labels.Add("1800");
            axisX3.Labels.Add("1900");
            axisX3.Labels.Add("2000");
            axisX3.Labels.Add("2100");

            ChrYuksekova.AxisX.Add(axisX3);
            axisX3.FontSize = 14;

            int semdinliToplam = semdinli200 + semdinli300 + semdinli400 + semdinli500 + semdinli600 + semdinli700 + semdinli750 + semdinli800 + semdinli900 + semdinli950 + semdinli1000 + semdinli1100 + semdinli1200 + semdinli1300 + semdinli1400 + semdinli1450 + semdinli1500 + semdinli1600 + semdinli1700 + semdinli1800 + semdinli1900 + semdinli2000 + semdinli2100;

            if (ilk == false)
            {
                LblSemdinli.Text = "ŞEMDİNLİ";
            }

            LblSemdinli.Text = LblSemdinli.Text + " = " + semdinliToplam;

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "ŞEMDİNLİ",
                    Values = new ChartValues<double> { semdinli200, semdinli300, semdinli400, semdinli500, semdinli600, semdinli700, semdinli750, semdinli800, semdinli900, semdinli950, semdinli1000, semdinli1100, semdinli1200, semdinli1300, semdinli1400, semdinli1450, semdinli1500, semdinli1600, semdinli1700, semdinli1800, semdinli1900, semdinli2000, semdinli2100 },
                    DataLabels = true,
                    FontSize= 15,
                }
            };

            Axis axisX4 = new Axis()
            {
                Separator = new Separator() { Step = 1, IsEnabled = false },
                Labels = new List<string>()
            };


            Values = value => value.ToString();

            ChrSemdinli.Series.Clear();
            ChrSemdinli.Series.Add(SeriesCollection[0]);

            ChrSemdinli.AxisX.Clear();

            axisX4.Labels.Add("200");
            axisX4.Labels.Add("300");
            axisX4.Labels.Add("400");
            axisX4.Labels.Add("500");
            axisX4.Labels.Add("600");
            axisX4.Labels.Add("700");
            axisX4.Labels.Add("750");
            axisX4.Labels.Add("800");
            axisX4.Labels.Add("900");
            axisX4.Labels.Add("950");
            axisX4.Labels.Add("1000");
            axisX4.Labels.Add("1100");
            axisX4.Labels.Add("1200");
            axisX4.Labels.Add("1300");
            axisX4.Labels.Add("1400");
            axisX4.Labels.Add("1450");
            axisX4.Labels.Add("1500");
            axisX4.Labels.Add("1600");
            axisX4.Labels.Add("1700");
            axisX4.Labels.Add("1800");
            axisX4.Labels.Add("1900");
            axisX4.Labels.Add("2000");
            axisX4.Labels.Add("2100");

            ChrSemdinli.AxisX.Add(axisX4);
            axisX4.FontSize = 14;


            int derecikToplam = derecik200 + derecik300 + derecik400 + derecik500 + derecik600 + derecik700 + derecik750 + derecik800 + derecik900 + derecik950 + derecik1000 + derecik1100 + derecik1200 + derecik1300 + derecik1400 + derecik1450 + derecik1500 + derecik1600 + derecik1700 + derecik1800 + derecik1900 + derecik2000 + derecik2100;

            if (ilk == false)
            {
                LblDerecik.Text = "DERECİK";
            }
            LblDerecik.Text = LblDerecik.Text + " = " + derecikToplam;

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "DERECİK",
                    Values = new ChartValues<double> { derecik200, derecik300, derecik400, derecik500, derecik600, derecik700, derecik750, derecik800, derecik900, derecik950, derecik1000, derecik1100, derecik1200, derecik1300, derecik1400, derecik1450, derecik1500, derecik1600, derecik1700, derecik1800, derecik1900, derecik2000, derecik2100 },
                    DataLabels = true,
                    FontSize= 15,
                }
            };

            Axis axisX5 = new Axis()
            {
                Separator = new Separator() { Step = 1, IsEnabled = false },
                Labels = new List<string>()
            };


            Values = value => value.ToString();

            ChrDerecik.Series.Clear();
            ChrDerecik.Series.Add(SeriesCollection[0]);

            ChrDerecik.AxisX.Clear();

            axisX5.Labels.Add("200");
            axisX5.Labels.Add("300");
            axisX5.Labels.Add("400");
            axisX5.Labels.Add("500");
            axisX5.Labels.Add("600");
            axisX5.Labels.Add("700");
            axisX5.Labels.Add("750");
            axisX5.Labels.Add("800");
            axisX5.Labels.Add("900");
            axisX5.Labels.Add("950");
            axisX5.Labels.Add("1000");
            axisX5.Labels.Add("1100");
            axisX5.Labels.Add("1200");
            axisX5.Labels.Add("1300");
            axisX5.Labels.Add("1400");
            axisX5.Labels.Add("1450");
            axisX5.Labels.Add("1500");
            axisX5.Labels.Add("1600");
            axisX5.Labels.Add("1700");
            axisX5.Labels.Add("1800");
            axisX5.Labels.Add("1900");
            axisX5.Labels.Add("2000");
            axisX5.Labels.Add("2100");

            ChrDerecik.AxisX.Add(axisX5);
            axisX5.FontSize = 14;


            int dBolgesiToplam = dBolgesi200 + dBolgesi300 + dBolgesi400 + dBolgesi500 + dBolgesi600 + dBolgesi700 + dBolgesi750 + dBolgesi800 + dBolgesi900 + dBolgesi950 + dBolgesi1000 + dBolgesi1100 + dBolgesi1200 + dBolgesi1300 + dBolgesi1400 + dBolgesi1450 + dBolgesi1500 + dBolgesi1600 + dBolgesi1700 + dBolgesi1800 + dBolgesi1900 + dBolgesi2000 + dBolgesi2100;

            if (ilk == false)
            {
                LblDBolgesi.Text = "D BÖLGESİ";
            }
            LblDBolgesi.Text = LblDBolgesi.Text + " = " + dBolgesiToplam;

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "D BÖLGESİ",
                    Values = new ChartValues<double> { dBolgesi200, dBolgesi300, dBolgesi400, dBolgesi500, dBolgesi600, dBolgesi700, dBolgesi750, dBolgesi800, dBolgesi900, dBolgesi950, dBolgesi1000, dBolgesi1100, dBolgesi1200, dBolgesi1300, dBolgesi1400, dBolgesi1450, dBolgesi1500, dBolgesi1600, dBolgesi1700, dBolgesi1800, dBolgesi1900, dBolgesi2000, dBolgesi2100 },
                    DataLabels = true,
                    FontSize= 15,
                }
            };

            Axis axisX6 = new Axis()
            {
                Separator = new Separator() { Step = 1, IsEnabled = false },
                Labels = new List<string>()
            };


            Values = value => value.ToString();

            ChrDBolgesi.Series.Clear();
            ChrDBolgesi.Series.Add(SeriesCollection[0]);

            ChrDBolgesi.AxisX.Clear();

            axisX6.Labels.Add("200");
            axisX6.Labels.Add("300");
            axisX6.Labels.Add("400");
            axisX6.Labels.Add("500");
            axisX6.Labels.Add("600");
            axisX6.Labels.Add("700");
            axisX6.Labels.Add("750");
            axisX6.Labels.Add("800");
            axisX6.Labels.Add("900");
            axisX6.Labels.Add("950");
            axisX6.Labels.Add("1000");
            axisX6.Labels.Add("1100");
            axisX6.Labels.Add("1200");
            axisX6.Labels.Add("1300");
            axisX6.Labels.Add("1400");
            axisX6.Labels.Add("1450");
            axisX6.Labels.Add("1500");
            axisX6.Labels.Add("1600");
            axisX6.Labels.Add("1700");
            axisX6.Labels.Add("1800");
            axisX6.Labels.Add("1900");
            axisX6.Labels.Add("2000");
            axisX6.Labels.Add("2100");

            ChrDBolgesi.AxisX.Add(axisX6);
            axisX6.FontSize = 14;

            ilk = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void FrmSektorIslemAdimlari_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
    }
}
