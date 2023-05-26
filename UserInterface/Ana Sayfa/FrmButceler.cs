using Business.Concreate.Butce;
using Business.Concreate.STS;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Spreadsheet;
using Entity.Butce;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Office.Interop.Word;
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
using UserInterface.STS;
using Application = System.Windows.Forms.Application;
using Axis = LiveCharts.Wpf.Axis;
using Separator = LiveCharts.Wpf.Separator;
using SeriesCollection = LiveCharts.SeriesCollection;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmButceler : Form
    {
        ButceManager butceManager;

        double gelir, giderTutar, kalan = 0;

        List<ButceKayit> butceKayits = new List<ButceKayit>();
        List<double> gelirs = new List<double>();
        List<double> giders = new List<double>();
        List<double> kalans = new List<double>();
        public FrmButceler()
        {
            InitializeComponent();
            butceManager = ButceManager.GetInstance();


        }
        void Data()
        {
            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            gelirs.Clear();
            giders.Clear();
            kalans.Clear();
            butceKayits.Clear();

            gelir = 0; giderTutar = 0; kalan = 0;

            if (CmbButceDonem.Text != "TÜM YIL")
            {
                butceKayits = butceManager.GetList(CmbButceYil.Text, CmbButceDonem.Text);
            }
            else
            {
                butceKayits = butceManager.GetList(CmbButceYil.Text);
            }

            if (butceKayits.Count==0)
            {
                MessageBox.Show("Veri bulunamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ButceKayit[] butceKayits2 = new ButceKayit[butceKayits.Count];

            if (CmbButceDonem.Text == "TÜM YIL")
            {
                for (int i = 0; i < butceKayits.Count; i++)
                {
                    if (butceKayits[i].ButceTanim == "BM25/PERS. MAAŞ GİDERLERİ")
                    {
                        butceKayits2[0] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM45/PERSONEL MAAŞ YANSIMASI")
                    {
                        butceKayits2[1] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM21/İAŞE")
                    {
                        butceKayits2[2] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM24/PERS. İLETİŞİM GİDERLERİ")
                    {
                        butceKayits2[3] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM23/ÖZEL SİGRT. GİDERLERİ")
                    {
                        butceKayits2[4] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM26/ARAÇ TAHSİS GİDERLERİ")
                    {
                        butceKayits2[5] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM46/ARAÇ YAKIT GİDERLERİ")
                    {
                        butceKayits2[6] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM12/YERLEŞKE GİDERLERİ")
                    {
                        butceKayits2[7] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM25/PERS. MAAŞ GİDERLERİ")
                    {
                        butceKayits2[8] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM45/PERSONEL MAAŞ YANSIMASI")
                    {
                        butceKayits2[9] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM21/İAŞE")
                    {
                        butceKayits2[10] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM24/PERS. İLETİŞİM GİDERLERİ")
                    {
                        butceKayits2[11] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM23/ÖZEL SİGRT. GİDERLERİ")
                    {
                        butceKayits2[12] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM26/ARAÇ TAHSİS GİDERLERİ")
                    {
                        butceKayits2[13] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM46/ARAÇ YAKIT GİDERLERİ")
                    {
                        butceKayits2[14] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM12/YERLEŞKE GİDERLERİ")
                    {
                        butceKayits2[15] = butceKayits[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < butceKayits.Count; i++)
                {
                    if (butceKayits[i].ButceTanim == "BM25/PERS. MAAŞ GİDERLERİ")
                    {
                        butceKayits2[0] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM45/PERSONEL MAAŞ YANSIMASI")
                    {
                        butceKayits2[1] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM21/İAŞE")
                    {
                        butceKayits2[2] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM24/PERS. İLETİŞİM GİDERLERİ")
                    {
                        butceKayits2[3] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM23/ÖZEL SİGRT. GİDERLERİ")
                    {
                        butceKayits2[4] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM26/ARAÇ TAHSİS GİDERLERİ")
                    {
                        butceKayits2[5] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM46/ARAÇ YAKIT GİDERLERİ")
                    {
                        butceKayits2[6] = butceKayits[i];
                    }
                    if (butceKayits[i].ButceTanim == "BM12/YERLEŞKE GİDERLERİ")
                    {
                        butceKayits2[7] = butceKayits[i];
                    }
                }
            }
            

            if (CmbButceDonem.Text == "TÜM YIL")
            {
                for (int i = 0; i < butceKayits2.Length; i++)
                {
                    string[] gelirTutar = butceKayits2[i].ButceTutariYillik.ToString().Split('?');
                    string[] butceKalemi = butceKayits2[i].ButceTanim.ToString().Split('/');



                    if (butceKalemi[0].ToString() == "BM46")
                    {
                        giderTutar = butceManager.SatButceHarcamaBM46(butceKalemi[0].ToString(), CmbButceYil.Text);
                    }
                    else
                    {
                        giderTutar = butceManager.SatButceHarcama(butceKalemi[0].ToString(), CmbButceYil.Text);
                    }

                    gelir = gelirTutar[1].ConDouble() * 2;

                    kalan = gelir - giderTutar;

                    gelirs.Add(gelir);
                    giders.Add(giderTutar);
                    kalans.Add(kalan);

                }
            }
            else
            {
                for (int i = 0; i < butceKayits.Count; i++)
                {
                    string[] gelirTutar = butceKayits2[i].ButceTutariYillik.ToString().Split('?');
                    gelir = gelirTutar[1].ConDouble();

                    string[] butceKalemi = butceKayits2[i].ButceTanim.ToString().Split('/');

                    if (butceKalemi[0].ToString() == "BM46")
                    {
                        giderTutar = butceManager.SatButceHarcamaBM46(butceKalemi[0].ToString(), CmbButceYil.Text, CmbButceDonem.Text);
                    }
                    else
                    {
                        giderTutar = butceManager.SatButceHarcama(butceKalemi[0].ToString(), CmbButceYil.Text, CmbButceDonem.Text);
                    }

                    kalan = gelir - giderTutar;

                    gelirs.Add(gelir);
                    giders.Add(giderTutar);
                    kalans.Add(kalan);

                }
            }

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "GELİR",
                    Values = new ChartValues<double> { gelirs[0], gelirs[1], gelirs[2], gelirs[3], gelirs[4], gelirs[5], gelirs[6], gelirs[7] }
                },
                new ColumnSeries
                {
                    Title = "GİDER",
                    Values = new ChartValues<double> { giders[0], giders[1], giders[2], giders[3], giders[4], giders[5], giders[6], giders[7] }
                },
                new ColumnSeries
                {
                    Title = "KALAN",
                    Values = new ChartValues<double> { kalans[0], kalans[1], kalans[2], kalans[3], kalans[4], kalans[5], kalans[6], kalans[7] }
                }
            };

            Axis axisX = new Axis()
            {
                Separator = new Separator() { Step = 1, IsEnabled = false},
                Labels = new List<string>()
                //Labels = new[] { "Bütçe Kodu1", "Bütçe Kodu2", "Bütçe Kodu3", "Bütçe Kodu4" }

            };

            Values = value => value.ToString("C2");

            cartesianChart1.Series.Add(SeriesCollection[0]);
            cartesianChart1.Series.Add(SeriesCollection[1]);
            cartesianChart1.Series.Add(SeriesCollection[2]);

            axisX.Labels.Add(butceKayits2[0].ButceTanim.ToString());
            axisX.Labels.Add(butceKayits2[1].ButceTanim.ToString());
            axisX.Labels.Add(butceKayits2[2].ButceTanim.ToString());
            axisX.Labels.Add(butceKayits2[3].ButceTanim.ToString());
            axisX.Labels.Add(butceKayits2[4].ButceTanim.ToString());
            axisX.Labels.Add(butceKayits2[5].ButceTanim.ToString());
            axisX.Labels.Add(butceKayits2[6].ButceTanim.ToString());
            axisX.Labels.Add(butceKayits2[7].ButceTanim.ToString());

            cartesianChart1.AxisX.Add(axisX);

            axisX.FontSize= 12;

            //BoldFont fontStyle = new BoldFont();

        }

        private void FrmButceler_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageButceIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        
        void GrafikCiz()
        {

            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            gelir = 0; giderTutar = 0; kalan = 0;

            if (CmbButceDonem.Text != "TÜM YIL")
            {
                butceKayits = butceManager.GetList(CmbButceYil.Text, CmbButceDonem.Text);
            }
            else
            {
                butceKayits = butceManager.GetList(CmbButceYil.Text);
            }

            ButceKayit[] butceKayits2 = new ButceKayit[butceKayits.Count];

            for (int i = 0; i < butceKayits.Count; i++)
            {
                if (butceKayits[i].ButceTanim == "BM25/PERS. MAAŞ GİDERLERİ")
                {
                    butceKayits2[0] = butceKayits[i];
                }
                if (butceKayits[i].ButceTanim == "BM45/PERSONEL MAAŞ YANSIMASI")
                {
                    butceKayits2[1] = butceKayits[i];
                }
                if (butceKayits[i].ButceTanim == "BM21/İAŞE")
                {
                    butceKayits2[2] = butceKayits[i];
                }
                if (butceKayits[i].ButceTanim == "BM24/PERS. İLETİŞİM GİDERLERİ")
                {
                    butceKayits2[3] = butceKayits[i];
                }
                if (butceKayits[i].ButceTanim == "BM23/ÖZEL SİGRT. GİDERLERİ")
                {
                    butceKayits2[4] = butceKayits[i];
                }
                if (butceKayits[i].ButceTanim == "BM26/ARAÇ TAHSİS GİDERLERİ")
                {
                    butceKayits2[5] = butceKayits[i];
                }
                if (butceKayits[i].ButceTanim == "BM46/ARAÇ YAKIT GİDERLERİ")
                {
                    butceKayits2[6] = butceKayits[i];
                }
                if (butceKayits[i].ButceTanim == "BM12/YERLEŞKE GİDERLERİ")
                {
                    butceKayits2[7] = butceKayits[i];
                }
            }



            if (CmbButceDonem.Text == "TÜM YIL")
            {
                for (int i = 0; i < butceKayits2.Length; i++)
                {
                    string[] gelirTutar = butceKayits2[i].ButceTutariYillik.ToString().Split('?');
                    string[] butceKalemi = butceKayits2[i].ButceTanim.ToString().Split('/');



                    if (butceKalemi[0].ToString() == "BM46")
                    {
                        giderTutar = butceManager.SatButceHarcamaBM46(butceKalemi[0].ToString(), CmbButceYil.Text);
                    }
                    else
                    {
                        giderTutar = butceManager.SatButceHarcama(butceKalemi[0].ToString(), CmbButceYil.Text);
                    }

                    gelir = gelirTutar[1].ConDouble() * 2;

                    kalan = gelir - giderTutar;



                }
            }
            else
            {
                for (int i = 0; i < butceKayits.Count; i++)
                {
                    string[] gelirTutar = butceKayits2[i].ButceTutariYillik.ToString().Split('?');
                    gelir = gelirTutar[1].ConDouble();

                    string[] butceKalemi = butceKayits2[i].ButceTanim.ToString().Split('/');

                    if (butceKalemi[0].ToString() == "BM46")
                    {
                        giderTutar = butceManager.SatButceHarcamaBM46(butceKalemi[0].ToString(), CmbButceYil.Text, CmbButceDonem.Text);
                    }
                    else
                    {
                        giderTutar = butceManager.SatButceHarcama(butceKalemi[0].ToString(), CmbButceYil.Text, CmbButceDonem.Text);
                    }

                    kalan = gelir - giderTutar;

                }
            }

            #region eskikod1
            //ColumnSeries columnSeries = new ColumnSeries()
            //{
            //    DataLabels = true,
            //    Values = new ChartValues<double>(),
            //    LabelPoint = point => point.Y.ToString("C2")
            //};
            //Axis axisX = new Axis()
            //{
            //    Separator = new Separator() { Step = 1, IsEnabled = false },
            //    Labels = new List<string>()
            //};
            //Axis axisY = new Axis()
            //{
            //    LabelFormatter = y => y.ToString(),
            //    Separator = new Separator()
            //};

            //cartesianChart1.Series.Add(columnSeries);
            //cartesianChart1.AxisX.Add(axisX);
            //cartesianChart1.AxisY.Add(axisY);
            //columnSeries.Values.Add(gelir);
            //axisX.Labels.Add(butceKayits2[i].ButceTanim);

            #endregion

            #region eskikod2
            //if (i == 0)
            //{
            //    for (int j = 0; j < butceKayits2.Length; j++)
            //    {
            //        columnSeries.Values.Add(gelir);

            //    }
            //}
            //if (i == 1)
            //{
            //    for (int j = 0; j < butceKayits2.Length; j++)
            //    {
            //        columnSeries.Values.Add(giderTutar);
            //    }
            //}
            //if (i == 2)
            //{
            //    for (int j = 0; j < butceKayits2.Length; j++)
            //    {
            //        columnSeries.Values.Add(kalan);
            //    }
            //}



            //chart1.Titles.Clear();
            //chart1.Series["Gelir"].Points.Clear();
            //chart1.Series["Gider"].Points.Clear();
            //chart1.Series["Kalan"].Points.Clear();
            //double giderTutar = 0;

            //List<ButceKayit> butceKayits1 = new List<ButceKayit>();

            //if (CmbButceDonem.Text!="TÜM YIL")
            //{
            //    butceKayits = butceManager.GetList(CmbButceYil.Text, CmbButceDonem.Text);
            //}
            //else
            //{
            //    butceKayits = butceManager.GetList(CmbButceYil.Text);
            //}

            //ButceKayit[] butceKayits2 = new ButceKayit[butceKayits.Count];

            //for (int i = 0; i < butceKayits.Count; i++)
            //{
            //    if (butceKayits[i].ButceTanim== "BM25/PERS. MAAŞ GİDERLERİ")
            //    {
            //        butceKayits2[0] = butceKayits[i];
            //    }
            //    if (butceKayits[i].ButceTanim == "BM45/PERSONEL MAAŞ YANSIMASI")
            //    {
            //        butceKayits2[1] = butceKayits[i];
            //    }
            //    if (butceKayits[i].ButceTanim == "BM21/İAŞE")
            //    {
            //        butceKayits2[2] = butceKayits[i];
            //    }
            //    if (butceKayits[i].ButceTanim == "BM24/PERS. İLETİŞİM GİDERLERİ")
            //    {
            //        butceKayits2[3] = butceKayits[i];
            //    }
            //    if (butceKayits[i].ButceTanim == "BM23/ÖZEL SİGRT. GİDERLERİ")
            //    {
            //        butceKayits2[4] = butceKayits[i];
            //    }
            //    if (butceKayits[i].ButceTanim == "BM26/ARAÇ TAHSİS GİDERLERİ")
            //    {
            //        butceKayits2[5] = butceKayits[i];
            //    }
            //    if (butceKayits[i].ButceTanim == "BM46/ARAÇ YAKIT GİDERLERİ")
            //    {
            //        butceKayits2[6] = butceKayits[i];
            //    }
            //    if (butceKayits[i].ButceTanim == "BM12/YERLEŞKE GİDERLERİ")
            //    {
            //        butceKayits2[7] = butceKayits[i];
            //    }
            //}


            //Title title = chart1.Titles.Add("BÜTÇE GELİR/GİDER GRAFİĞİ " + CmbButceDonem.Text);
            //title.Font = new Font("Arial", 13, FontStyle.Bold);

            //if (CmbButceDonem.Text=="TÜM YIL")
            //{
            //    for (int i = 0; i < butceKayits2.Length; i++)
            //    {
            //        string[] gelirTutar = butceKayits2[i].ButceTutariYillik.ToString().Split('?');
            //        string[] butceKalemi = butceKayits2[i].ButceTanim.ToString().Split('/');

            //        if (butceKalemi[0].ToString()=="BM46")
            //        {
            //            giderTutar = butceManager.SatButceHarcamaBM46(butceKalemi[0].ToString(), CmbButceYil.Text);
            //        }
            //        else
            //        {
            //            giderTutar = butceManager.SatButceHarcama(butceKalemi[0].ToString(), CmbButceYil.Text);
            //        }

            //        double yillikButceToplamGelir = gelirTutar[1].ConDouble() * 2;

            //        double kalan = yillikButceToplamGelir - giderTutar;


            //        chart1.Series["Gelir"].Points.AddXY(butceKayits2[i].ButceTanim.ToString(), yillikButceToplamGelir);
            //        chart1.Series["Gider"].Points.AddXY(butceKayits2[i].ButceTanim.ToString(), giderTutar);
            //        chart1.Series["Kalan"].Points.AddXY(butceKayits2[i].ButceTanim.ToString(), kalan);

            //        chart1.Series["Gelir"].Points[i].Label = yillikButceToplamGelir.ToString("C2");
            //        chart1.Series["Gider"].Points[i].Label = giderTutar.ToString("C2");
            //        chart1.Series["Kalan"].Points[i].Label = kalan.ToString("C2");

            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < butceKayits.Count; i++)
            //    {
            //        string[] gelirTutar = butceKayits2[i].ButceTutariYillik.ToString().Split('?');
            //        double donemButceToplamGelir = gelirTutar[1].ConDouble();

            //        string[] butceKalemi = butceKayits2[i].ButceTanim.ToString().Split('/');

            //        if (butceKalemi[0].ToString() == "BM46")
            //        {
            //            giderTutar = butceManager.SatButceHarcamaBM46(butceKalemi[0].ToString(), CmbButceYil.Text, CmbButceDonem.Text);
            //        }
            //        else
            //        {
            //            giderTutar = butceManager.SatButceHarcama(butceKalemi[0].ToString(), CmbButceYil.Text, CmbButceDonem.Text);
            //        }

            //        double kalan = donemButceToplamGelir - giderTutar;

            //        chart1.Series["Gelir"].Points.AddXY(butceKayits2[i].ButceTanim.ToString(), donemButceToplamGelir);
            //        chart1.Series["Gider"].Points.AddXY(butceKayits2[i].ButceTanim.ToString(), giderTutar);
            //        chart1.Series["Kalan"].Points.AddXY(butceKayits2[i].ButceTanim.ToString(), kalan);

            //        chart1.Series["Gelir"].Points[i].Label = donemButceToplamGelir.ToString("C2");
            //        chart1.Series["Gider"].Points[i].Label = giderTutar.ToString("C2");
            //        chart1.Series["Kalan"].Points[i].Label = kalan.ToString("C2");

            //    }
            //}

            //chart1.Series["Gelir"].Color = Color.CornflowerBlue;
            //chart1.Series["Gider"].Color = Color.Red;
            //chart1.Series["Kalan"].Color = Color.Khaki;

            #endregion
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            if (CmbButceYil.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Bütçe Yıl bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbButceDonem.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Bütçe Dönem bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //chart1.Visible = true;
            Data();
        }

        public SeriesCollection SeriesCollection { get; set; }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        public string[] Labels { get; set; }
        public Func<double, string> Values { get; set; }

    }
}
