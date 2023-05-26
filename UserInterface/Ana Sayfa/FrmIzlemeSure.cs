using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Separator = LiveCharts.Wpf.Separator;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmIzlemeSure : Form
    {
        public FrmIzlemeSure()
        {
            InitializeComponent();

        }

        private void FrmIzlemeSure_Load(object sender, EventArgs e)
        {
            SeriesCollection = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "ŞIRNAK",
                    Values = new ChartValues<double> { 6, 4, 7, 9 },
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "ÇUKURCA",
                    Values = new ChartValues<double> { 4, 5, 6, 8 },
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "YÜKSEKOVA",
                    Values = new ChartValues<double> { 2, 5, 6, 7 },
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "ŞEMDİNLİ",
                    Values = new ChartValues<double> { 2, 9, 11, 3 },
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "DERECİK",
                    Values = new ChartValues<double> { 2, 9, 11, 3 },
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "D BÖLGESİ",
                    Values = new ChartValues<double> { 2, 9, 11, 3 },
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                }
            };

            Axis axisX = new Axis()
            {
                Separator = new Separator() { Step = 1, IsEnabled = false },
                Labels = new List<string>(),
                FontSize= 30,
            };

            cartesianChart1.AxisY.Add(new Axis
            {
                FontSize = 25,
            });

            Labels = new[] { "OCAK", "ŞUBAT", "MART", "NİSAN", "MAYIS", "HAZİRAN", "TEMMUZ", "AĞUSTOS", "EYLÜL", "EKİM", "KASIM", "ARALIK" };


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

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Values { get; set; }

    }

}
