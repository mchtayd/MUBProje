using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using LiveCharts;
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
using System.Windows.Forms.DataVisualization.Charting;
using SeriesCollection = LiveCharts.SeriesCollection;

namespace UserInterface.Butce
{
    public partial class FrmGenelButceGrafik : Form
    {
        public double gelir, gider, kalan = 0;
        List<double> veriler = new List<double>();
        public FrmGenelButceGrafik()
        {
            InitializeComponent();
        }

        Func<ChartPoint, string> func = x => string.Format("{0}\n{1:P}", x.Y.ToString("C2"), x.Participation);


        private void FrmGenelButceGrafik_Load(object sender, EventArgs e)
        {
            SeriesCollection seriesCollection = new SeriesCollection();

            veriler.Add(gelir);
            veriler.Add(gider);
            veriler.Add(kalan);

            for (int i = 0; i < 3; i++)
            {
                if (i==0)
                {
                    seriesCollection.Add(new PieSeries() { Title = "GELİR", Values = new ChartValues<double> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize=20 });
                    chart1.Series = seriesCollection;
                }
                if (i == 1)
                {
                    seriesCollection.Add(new PieSeries() { Title = "GİDER", Values = new ChartValues<double> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 20 });
                    chart1.Series = seriesCollection;
                }
                if (i == 2)
                {
                    seriesCollection.Add(new PieSeries() { Title = "KALAN", Values = new ChartValues<double> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 20 });
                    chart1.Series = seriesCollection;
                }
            }

        }


    }
}
