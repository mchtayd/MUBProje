using Business;
using Business.Concreate.BakimOnarimAtolye;
using Entity;
using Entity.BakimOnarim;
using Entity.Butce;
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
using DataAccess.Concreate;
using LiveCharts.Defaults;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmAcikArizaGrafikleri : Form
    {
        ArizaIslemAdimiManager arizaIslemAdimiManager;
        IslemAdimlariManager islemAdimlariManager;
        List<IslemAdimlari> ıslemAdimlaris = new List<IslemAdimlari>();

        List<int> veriler = new List<int>();
        List<int> veriler2 = new List<int>();

        int sirnakArizaToplam, cukurcaToplam, yukseovaToplam, semdinliToplam, derecikToplam, merkez, dBolgesiToplam = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            GrafikSektor();
            DataDisplay();
        }

        private void FrmAcikArizaGrafikleri_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimerSaat.Stop();
            timer1.Stop();
        }

        int i200, i300, i400, i500, i600, i700, i750, i800, i900, i950, i1000, i1100, i1200, i1300, i1400, i1450, i1500, i1600, i1700, i1800, i1900, i2000, i2100, mavi, yesil, gri = 0;

        public FrmAcikArizaGrafikleri()
        {
            InitializeComponent();
            arizaIslemAdimiManager = ArizaIslemAdimiManager.GetInstance();
            islemAdimlariManager = IslemAdimlariManager.GetInstance();
        }

        private void FrmAcikArizaGrafikleri_Load(object sender, EventArgs e)
        {
            TimerSaat.Start();
            GrafikSektor();
            DataDisplay();
            timer1.Start();

        }
        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = DateTime.Now.ToString("HH:mm:ss");
            LblTarih.Text = DateTime.Now.ToLongDateString();
        }

        void GrafikSektor()
        {
            sirnakArizaToplam = cukurcaToplam = yukseovaToplam = semdinliToplam = derecikToplam = merkez = dBolgesiToplam = 0;

            ıslemAdimlaris = islemAdimlariManager.GetList("BAKIM ONARIM");
            foreach (IslemAdimlari item in ıslemAdimlaris)
            {
                ArizaIslemAdimi arizaIslemAdimi = arizaIslemAdimiManager.Get(item.IslemaAdimi);
                sirnakArizaToplam += arizaIslemAdimi.Sirnak;
                cukurcaToplam += arizaIslemAdimi.Cukurca;
                yukseovaToplam += arizaIslemAdimi.Yukseova;
                semdinliToplam += arizaIslemAdimi.Semdinli;
                derecikToplam += arizaIslemAdimi.Derecik;
                dBolgesiToplam += arizaIslemAdimi.DBolgesi;
                merkez += arizaIslemAdimi.Merkez;
            }

            LblSektorArizaTop.Text = (sirnakArizaToplam + cukurcaToplam + yukseovaToplam + semdinliToplam + derecikToplam + dBolgesiToplam + merkez).ToString();

            SeriesCollection seriesCollection = new SeriesCollection();

            veriler.Add(sirnakArizaToplam);
            veriler.Add(cukurcaToplam);
            veriler.Add(yukseovaToplam);
            veriler.Add(semdinliToplam);
            veriler.Add(derecikToplam + merkez);
            veriler.Add(dBolgesiToplam);

            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    Func<ChartPoint, string> func = x => string.Format("{0}\n{1:P}", "ŞIRNAK" + " (" + x.Y.ToString() + ")", x.Participation );
                    seriesCollection.Add(new PieSeries() { Title = "ŞIRNAK", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 20 });
                    chart1.Series = seriesCollection;
                }

                if (i == 1)
                {
                    Func<ChartPoint, string> func = x => string.Format("{0}\n{1:P}", "ÇUKURCA" + " (" + x.Y.ToString() + ")", x.Participation);
                    seriesCollection.Add(new PieSeries() { Title = "ÇUKURCA", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 20 });
                    chart1.Series = seriesCollection;
                }
                
                if (i == 2)
                {
                    Func<ChartPoint, string> func = x => string.Format("{0}\n{1:P}", "YÜKSEKOVA" + " (" + x.Y.ToString() + ")", x.Participation);
                    seriesCollection.Add(new PieSeries() { Title = "YÜKSEKOVA", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 20 });
                    chart1.Series = seriesCollection;
                }
                if (i == 3)
                {
                    Func<ChartPoint, string> func = x => string.Format("{0}\n{1:P}", "ŞEMDİNLİ" + " (" + x.Y.ToString() + ")", x.Participation);
                    seriesCollection.Add(new PieSeries() { Title = "ŞEMDİNLİ", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 20 });
                    chart1.Series = seriesCollection;
                }
                if (i == 4)
                {
                    Func<ChartPoint, string> func = x => string.Format("{0}\n{1:P}", "DERECİK" + " (" + x.Y.ToString() + ")", x.Participation);
                    seriesCollection.Add(new PieSeries() { Title = "DERECİK", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 20 });
                    chart1.Series = seriesCollection;
                }
                if (i == 5)
                {
                    Func<ChartPoint, string> func = x => string.Format("{0}\n{1:P}", "D BÖLGESİ" + " (" + x.Y.ToString() + ")", x.Participation);
                    seriesCollection.Add(new PieSeries() { Title = "D BÖLGESİ", Values = new ChartValues<int> { veriler[i] }, DataLabels = true, LabelPoint = func, FontSize = 20 });
                    chart1.Series = seriesCollection;
                }
            }

        }

        void DataDisplay()
        {
            i200 = i300 = i400 = i500 = i600 = i700 = i750 = i800 = i900 = i950 = i1000 = i1100 = i1200 = i1300 = i1400 = i1450 = i1500 = i1600 = i1700 = i1800 = i1900 = i2000 = i2100 = mavi = yesil = gri = 0;

            ArizaIslemAdimi arizaIslemAdimi200 = arizaIslemAdimiManager.Get("200_ARIZA TESPİTİ (FI/FD) (SAHA)");
            i200 = arizaIslemAdimi200.Toplam;

            ArizaIslemAdimi arizaIslemAdimi300 = arizaIslemAdimiManager.Get("300_ONARIM SONRASI ARIZA TESPİTİ (SAHA)");
            i300 = arizaIslemAdimi300.Toplam;

            ArizaIslemAdimi arizaIslemAdimi400 = arizaIslemAdimiManager.Get("400_SİPARİŞ OLUŞTURMA (DTS)");
            i400 = arizaIslemAdimi400.Toplam;

            ArizaIslemAdimi arizaIslemAdimi500 = arizaIslemAdimiManager.Get("500_ARIZA BİLDİRİMİ (ASELSAN)");
            i500 = arizaIslemAdimi500.Toplam;

            ArizaIslemAdimi arizaIslemAdimi600 = arizaIslemAdimiManager.Get("600_BİLDİRİM ONAYI (YÖNETİCİ)");
            i600 = arizaIslemAdimi600.Toplam;

            ArizaIslemAdimi arizaIslemAdimi700 = arizaIslemAdimiManager.Get("700_OKF HAZIRLAMA");
            i700 = arizaIslemAdimi700.Toplam;

            ArizaIslemAdimi arizaIslemAdimi750 = arizaIslemAdimiManager.Get("750_OKF HAZIRLAMA (ASELSAN)");
            i750 = arizaIslemAdimi750.Toplam;

            ArizaIslemAdimi arizaIslemAdimi800 = arizaIslemAdimiManager.Get("800_MÜŞTERİ ONAYI");
            i800 = arizaIslemAdimi800.Toplam;

            ArizaIslemAdimi arizaIslemAdimi900 = arizaIslemAdimiManager.Get("900_FABRİKA BAKIM ONARIM (ASELSAN)");
            i900 = arizaIslemAdimi900.Toplam;

            ArizaIslemAdimi arizaIslemAdimi950 = arizaIslemAdimiManager.Get("950_ATÖLYE BAKIM ONARIM (VAN)");
            i950 = arizaIslemAdimi950.Toplam;

            ArizaIslemAdimi arizaIslemAdimi1000 = arizaIslemAdimiManager.Get("1000_DEPO STOK KONTROL");
            i1000 = arizaIslemAdimi1000.Toplam;

            ArizaIslemAdimi arizaIslemAdimi1100 = arizaIslemAdimiManager.Get("1100_MALZEME TEMİNİ (SATIN ALMA)");
            i1100 = arizaIslemAdimi1100.Toplam;

            ArizaIslemAdimi arizaIslemAdimi1200 = arizaIslemAdimiManager.Get("1200_MALZEME TEMİNİ (ASELSAN)");
            i1200 = arizaIslemAdimi1200.Toplam;

            ArizaIslemAdimi arizaIslemAdimi1300 = arizaIslemAdimiManager.Get("1300_MALZEME HAZIRLAMA AMBAR");
            i1300 = arizaIslemAdimi1300.Toplam;

            ArizaIslemAdimi arizaIslemAdimi1400 = arizaIslemAdimiManager.Get("1400_SEVKİYAT (ANKARA)");
            i1400 = arizaIslemAdimi1400.Toplam;

            ArizaIslemAdimi arizaIslemAdimi1400B = arizaIslemAdimiManager.Get("1450_SEVKİYAT (BÖLGE)");
            i1450 = arizaIslemAdimi1400B.Toplam;

            ArizaIslemAdimi arizaIslemAdimi1500 = arizaIslemAdimiManager.Get("1500_BAKIM ONARIM (SAHA)");
            i1500 = arizaIslemAdimi1500.Toplam;

            ArizaIslemAdimi arizaIslemAdimi1600 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (SERVİS)");
            i1600 = arizaIslemAdimi1600.Toplam;

            ArizaIslemAdimi arizaIslemAdimi1700 = arizaIslemAdimiManager.Get("1700_FONKSİYONEL TEST");
            i1700 = arizaIslemAdimi1700.Toplam;

            ArizaIslemAdimi arizaIslemAdimi1800 = arizaIslemAdimiManager.Get("1800_DENETİM");
            i1800 = arizaIslemAdimi1800.Toplam;

            ArizaIslemAdimi arizaIslemAdimi1900 = arizaIslemAdimiManager.Get("1900_MÜŞTERİ TESLİMATI");
            i1900 = arizaIslemAdimi1900.Toplam;

            ArizaIslemAdimi arizaIslemAdimi2000 = arizaIslemAdimiManager.Get("2000_ARIZA KAPATMA (DTS)");
            i2000 = arizaIslemAdimi2000.Toplam;

            ArizaIslemAdimi arizaIslemAdimi2100 = arizaIslemAdimiManager.Get("2100_ARIZA KAPATMA BİLDİRİMİ (ASELSAN)");
            i2100 = arizaIslemAdimi2100.Toplam;


            mavi = i400.ConInt() + i500.ConInt() + i600.ConInt() + i900.ConInt() + i950.ConInt() + i1000.ConInt() + i1100.ConInt() + i1200.ConInt() + i1300.ConInt() + i1400.ConInt() + i1450.ConInt() + i2000.ConInt() + i2100.ConInt();

            yesil = i200.ConInt() + i300.ConInt() + i1700.ConInt() + i1800.ConInt() + i1900.ConInt() + i1500.ConInt();

            gri = i700.ConInt() + i750.ConInt() + i800.ConInt() + i1600.ConInt();


            SeriesCollection seriesCollection = new SeriesCollection();

            veriler2.Add(mavi.ConInt());
            veriler2.Add(yesil.ConInt());
            veriler2.Add(gri.ConInt());

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    Func<ChartPoint, string> func = x => string.Format("{0}\n{1:P}", "LOJİSTİK DESTEK ve PLANLAMA" + " (" + x.Y.ToString() + ")", x.Participation);
                    seriesCollection.Add(new PieSeries() { Title = "LOJİSTİK DESTEK ve PLANLAMA", Values = new ChartValues<int> { veriler2[i] }, DataLabels = true, LabelPoint = func, FontSize = 20 });
                    pieChart1.Series = seriesCollection;
                }
                if (i == 1)
                {
                    Func<ChartPoint, string> func = x => string.Format("{0}\n{1:P}", "SAHA BAKIM ONARIM" + " (" + x.Y.ToString() + ")", x.Participation);
                    seriesCollection.Add(new PieSeries() { Title = "SAHA BAKIM ONARIM", Values = new ChartValues<int> { veriler2[i] }, DataLabels = true, LabelPoint = func, FontSize = 20 });
                    pieChart1.Series = seriesCollection;
                }
                if (i == 2)
                {
                    Func<ChartPoint, string> func = x => string.Format("{0}\n{1:P}", "ALT YÜK. KONT. KORD." + " (" + x.Y.ToString() + ")", x.Participation);
                    seriesCollection.Add(new PieSeries() { Title = "ALT YÜK. KONT. KORD.", Values = new ChartValues<int> { veriler2[i] }, DataLabels = true, LabelPoint = func, FontSize = 20 });
                    pieChart1.Series = seriesCollection;
                }
            }


        }


    }
}
