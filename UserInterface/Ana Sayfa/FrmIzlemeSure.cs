using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using Entity.AnaSayfa;
using Entity.BakimOnarim;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Separator = LiveCharts.Wpf.Separator;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmIzlemeSure : Form
    {

        ArizaAyManager arizaAyManager;
        ArizaKayitManager arizaKayitManager;
        List<ArizaKayit> arizaKayits = new List<ArizaKayit>();
        List<string> iller = new List<string>();
        List<string> ilce = new List<string>();

        int sirnakOcak, sirnakSubat, sirnakMart, sirnakNisan, sirnakMayis, sirnakHaziran, sirnakTemmuz, sirnakAgustos, sirnakEylul, sirnakEkim, sirnakKasim, sirnakAralik, sirnakToplam;
        int dBolgesikOcak, dBolgesiSubat, dBolgesiMart, dBolgesiNisan, dBolgesiMayis, dBolgesiHaziran, dBolgesiTemmuz, dBolgesiAgustos, dBolgesiEylul, dBolgesiEkim, dBolgesiKasim, dBolgesiAralik, dBolgesiToplam;

        

        int cukurcaOcak, cukurcaSubat, cukurcaMart, cukurcaNisan, cukurcaMayis, cukurcaHaziran, cukurcaTemmuz, cukurcaAgustos, cukurcaEylul, cukurcaEkim, cukurcaKasim, cukurcaAralik, cukurcaToplam;
        int derecikOcak, derecikSubat, derecikMart, derecikNisan, derecikMayis, derecikHaziran, derecikTemmuz, derecikAgustos, derecikEylul, derecikEkim, derecikKasim, derecikAralik, derecikToplam;
        int merkezOcak, merkezSubat, merkezMart, merkezNisan, merkezMayis, merkezHaziran, merkezTemmuz, merkezAgustos, merkezEylul, merkezEkim, merkezKasim, merkezAralik, merkezToplam;
        int semdinliOcak, semdinliSubat, semdinliMart, semdinliNisan, semdinliMayis, semdinliHaziran, semdinliTemmuz, semdinliAgustos, semdinliEylul, semdinliEkim, semdinliKasim, semdinliAralik, semdinliToplam;
        int yuksekovaOcak, yuksekovaSubat, yuksekovaMart, yuksekovaNisan, yuksekovaMayis, yuksekovaHaziran, yuksekovaTemmuz, yuksekovaAgustos, yuksekovaEylul, yuksekovaEkim, yuksekovaKasim, yuksekovaAralik, yuksekovaToplam;

        public FrmIzlemeSure()
        {
            InitializeComponent();
            arizaAyManager = ArizaAyManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
        }

        private void FrmIzlemeSure_Load(object sender, EventArgs e)
        {
            TimerSaat.Start();
            DataDisplay();
        }

        
        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = DateTime.Now.ToString("HH:mm:ss");
            LblTarih.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //DataDisplay();
        }
        void DataDisplay()
        {
            iller = arizaAyManager.GetListArizaIlList();

            foreach (string item in iller)
            {
                if (item == "ŞIRNAK")
                {
                    // ŞIRNAK
                    ArizaAy arizaAy = arizaAyManager.Get("2023", item, item);
                    sirnakOcak += arizaAy.Ocak;
                    sirnakSubat += arizaAy.Subat;
                    sirnakMart += arizaAy.Mart;
                    sirnakNisan += arizaAy.Nisan;
                    sirnakMayis += arizaAy.Mayis;
                    sirnakHaziran += arizaAy.Haziran;
                    sirnakTemmuz += arizaAy.Temmuz;
                    sirnakAgustos += arizaAy.Agustos;
                    sirnakEylul += arizaAy.Eylus;
                    sirnakEkim += arizaAy.Ekim;
                    sirnakKasim += arizaAy.Kasim;
                    sirnakAralik += arizaAy.Aralik;
                    sirnakToplam += arizaAy.Toplam;
                    continue;
                }
                if (item != "ŞIRNAK" && item != "HAKKÂRİ")
                {
                    // D BÖLGESİ
                    ArizaAy arizaAy = arizaAyManager.Get("2023", item, item);
                    dBolgesikOcak += arizaAy.Ocak;
                    dBolgesiSubat += arizaAy.Subat;
                    dBolgesiMart += arizaAy.Mart;
                    dBolgesiNisan += arizaAy.Nisan;
                    dBolgesiMayis += arizaAy.Mayis;
                    dBolgesiHaziran += arizaAy.Haziran;
                    dBolgesiTemmuz += arizaAy.Temmuz;
                    dBolgesiAgustos += arizaAy.Agustos;
                    dBolgesiEylul += arizaAy.Eylus;
                    dBolgesiEkim += arizaAy.Ekim;
                    dBolgesiKasim += arizaAy.Kasim;
                    dBolgesiAralik += arizaAy.Aralik;
                    dBolgesiToplam += arizaAy.Toplam;
                    continue;
                }
                if (item == "HAKKÂRİ")
                {
                    // HAKKARİ SEKTÖRLERİ
                    ilce = arizaAyManager.GetListArizaIlcelerList();
                    foreach (string item2 in ilce)
                    {
                        if (item2 == "ÇUKURCA")
                        {
                            ArizaAy arizaAy = arizaAyManager.Get("2023", item2, item);
                            cukurcaOcak += arizaAy.Ocak;
                            cukurcaSubat += arizaAy.Subat;
                            cukurcaMart += arizaAy.Mart;
                            cukurcaNisan += arizaAy.Nisan;
                            cukurcaMayis += arizaAy.Mayis;
                            cukurcaHaziran += arizaAy.Haziran;
                            cukurcaTemmuz += arizaAy.Temmuz;
                            cukurcaAgustos += arizaAy.Agustos;
                            cukurcaEylul += arizaAy.Eylus;
                            cukurcaEkim += arizaAy.Ekim;
                            cukurcaKasim += arizaAy.Kasim;
                            cukurcaAralik += arizaAy.Aralik;
                            cukurcaToplam += arizaAy.Toplam;
                            continue;
                        }
                        if (item2 == "DERECİK")
                        {
                            ArizaAy arizaAy = arizaAyManager.Get("2023", item2, item);
                            derecikOcak += arizaAy.Ocak;
                            derecikSubat += arizaAy.Subat;
                            derecikMart += arizaAy.Mart;
                            derecikNisan += arizaAy.Nisan;
                            derecikMayis += arizaAy.Mayis;
                            derecikHaziran += arizaAy.Haziran;
                            derecikTemmuz += arizaAy.Temmuz;
                            derecikAgustos += arizaAy.Agustos;
                            derecikEylul += arizaAy.Eylus;
                            derecikEkim += arizaAy.Ekim;
                            derecikKasim += arizaAy.Kasim;
                            derecikAralik += arizaAy.Aralik;
                            derecikToplam += arizaAy.Toplam;
                            continue;
                        }
                        if (item2 == "MERKEZ")
                        {
                            ArizaAy arizaAy = arizaAyManager.Get("2023", item2, item);
                            merkezOcak += arizaAy.Ocak;
                            merkezSubat += arizaAy.Subat;
                            merkezMart += arizaAy.Mart;
                            merkezNisan += arizaAy.Nisan;
                            merkezMayis += arizaAy.Mayis;
                            merkezHaziran += arizaAy.Haziran;
                            merkezTemmuz += arizaAy.Temmuz;
                            merkezAgustos += arizaAy.Agustos;
                            merkezEylul += arizaAy.Eylus;
                            merkezEkim += arizaAy.Ekim;
                            merkezKasim += arizaAy.Kasim;
                            merkezAralik += arizaAy.Aralik;
                            merkezToplam += arizaAy.Toplam;
                            continue;
                        }
                        if (item2 == "ŞEMDİNLİ")
                        {
                            ArizaAy arizaAy = arizaAyManager.Get("2023", item2, item);
                            semdinliOcak += arizaAy.Ocak;
                            semdinliSubat += arizaAy.Subat;
                            semdinliMart += arizaAy.Mart;
                            semdinliNisan += arizaAy.Nisan;
                            semdinliMayis += arizaAy.Mayis;
                            semdinliHaziran += arizaAy.Haziran;
                            semdinliTemmuz += arizaAy.Temmuz;
                            semdinliAgustos += arizaAy.Agustos;
                            semdinliEylul += arizaAy.Eylus;
                            semdinliEkim += arizaAy.Ekim;
                            semdinliKasim += arizaAy.Kasim;
                            semdinliAralik += arizaAy.Aralik;
                            semdinliToplam += arizaAy.Toplam;
                            continue;
                        }
                        if (item2 == "YÜKSEKOVA")
                        {
                            ArizaAy arizaAy = arizaAyManager.Get("2023", item2, item);
                            yuksekovaOcak += arizaAy.Ocak;
                            yuksekovaSubat += arizaAy.Subat;
                            yuksekovaMart += arizaAy.Mart;
                            yuksekovaNisan += arizaAy.Nisan;
                            yuksekovaMayis += arizaAy.Mayis;
                            yuksekovaHaziran += arizaAy.Haziran;
                            yuksekovaTemmuz += arizaAy.Temmuz;
                            yuksekovaAgustos += arizaAy.Agustos;
                            yuksekovaEylul += arizaAy.Eylus;
                            yuksekovaEkim += arizaAy.Ekim;
                            yuksekovaKasim += arizaAy.Kasim;
                            yuksekovaAralik += arizaAy.Aralik;
                            yuksekovaToplam += arizaAy.Toplam;
                            continue;
                        }
                    }

                }
            }

            SeriesCollection = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "OCAK",
                    Values = new ChartValues<double> { sirnakOcak, cukurcaOcak , yuksekovaOcak, semdinliOcak, derecikOcak , merkezOcak, dBolgesikOcak},
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "ŞUBAT",
                    Values = new ChartValues<double> { sirnakSubat, cukurcaSubat, yuksekovaSubat, semdinliSubat, derecikSubat, merkezSubat, dBolgesiSubat},
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "MART",
                    Values = new ChartValues<double> { sirnakMart, cukurcaMart, yuksekovaMart, semdinliMart, derecikMart, merkezMart, dBolgesiMart},
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "NİSAN",
                    Values = new ChartValues<double> { sirnakNisan, cukurcaNisan, yuksekovaNisan, semdinliNisan, derecikNisan, merkezNisan, dBolgesiNisan },
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "MAYIS",
                    Values = new ChartValues<double> { sirnakMayis, cukurcaMayis, yuksekovaMayis, semdinliMayis, derecikMayis, merkezMayis, dBolgesiMayis},
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "HAZİRAN",
                    Values = new ChartValues<double> { sirnakHaziran, cukurcaHaziran, yuksekovaHaziran, semdinliHaziran, derecikHaziran, merkezHaziran, dBolgesiHaziran },
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "TEMMUZ",
                    Values = new ChartValues<double> { sirnakTemmuz, cukurcaTemmuz, yuksekovaTemmuz, semdinliTemmuz, derecikTemmuz, merkezTemmuz, dBolgesiTemmuz },
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "AĞUSTOS",
                    Values = new ChartValues<double> { sirnakAgustos, cukurcaAgustos, yuksekovaAgustos, semdinliAgustos, derecikAgustos, merkezAgustos, dBolgesiAgustos },
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "EYLÜL",
                    Values = new ChartValues<double> { sirnakEylul, cukurcaEylul, yuksekovaEylul, semdinliEylul, derecikEylul, merkezEylul, merkezEylul, dBolgesiEylul },
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "EKİM",
                    Values = new ChartValues<double> { sirnakEkim, cukurcaEkim, yuksekovaEkim, semdinliEkim, derecikEkim, merkezEkim, dBolgesiEkim  },
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "KASIM",
                    Values = new ChartValues<double> { sirnakKasim, cukurcaKasim, yuksekovaKasim, semdinliKasim, derecikKasim, merkezKasim, dBolgesiKasim },
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "ARALIK",
                    Values = new ChartValues<double> { sirnakAralik, cukurcaAralik, yuksekovaAralik, semdinliAralik, derecikAralik, merkezAralik, dBolgesiAralik },
                    StackMode = StackMode.Values,
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

            cartesianChart1.AxisY.Add(new Axis
            {
                FontSize = 25,
            });

            Labels = new[] { "ŞIRNAK\n" + "( " + sirnakToplam.ToString() + " )", "ÇUKURCA\n" + "( " + cukurcaToplam.ToString() + " )", "YÜKSEKOVA\n" + "( " + yuksekovaToplam.ToString() + " )", "ŞEMDİNLİ\n" + "( " + semdinliToplam.ToString() + " )", "DERECİK\n" + "( " + derecikToplam.ToString() + " )", "HAKKARİ/ MERKEZ\n" + "( " + merkezToplam.ToString() + " )", "D BÖLGESİ\n" + "( " + dBolgesiToplam.ToString() + " )" };


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
