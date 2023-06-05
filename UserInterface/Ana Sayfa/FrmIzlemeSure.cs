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

        int ocakToplam, subatToplam, martToplam, nisanToplam, mayisToplam, haziranToplam, temmuzToplam, agustosToplam, eylulToplam, ekimToplam, kasimToplam, araliikToplam, genelToplam;
        int sirnakOcak, sirnakSubat, sirnakMart, sirnakNisan, sirnakMayis, sirnakHaziran, sirnakTemmuz, sirnakAgustos, sirnakEylul, sirnakEkim, sirnakKasim, sirnakAralik, sirnakToplam;

        private void FrmIzlemeSure_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimerSaat.Stop();
            timer1.Stop();
        }

        int dBolgesikOcak, dBolgesiSubat, dBolgesiMart, dBolgesiNisan, dBolgesiMayis, dBolgesiHaziran, dBolgesiTemmuz, dBolgesiAgustos, dBolgesiEylul, dBolgesiEkim, dBolgesiKasim, dBolgesiAralik, dBolgesiToplam;
        int cukurcaOcak, cukurcaSubat, cukurcaMart, cukurcaNisan, cukurcaMayis, cukurcaHaziran, cukurcaTemmuz, cukurcaAgustos, cukurcaEylul, cukurcaEkim, cukurcaKasim, cukurcaAralik, cukurcaToplam;
        int derecikOcak, derecikSubat, derecikMart, derecikNisan, derecikMayis, derecikHaziran, derecikTemmuz, derecikAgustos, derecikEylul, derecikEkim, derecikKasim, derecikAralik, derecikToplam;
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
            timer1.Start();
        }

        
        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = DateTime.Now.ToString("HH:mm:ss");
            LblTarih.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataDisplay();
        }
        void DataDisplay()
        {
            iller.Clear();
            ilce.Clear();
            iller = arizaAyManager.GetListArizaIlList();

            ocakToplam= subatToplam= martToplam= nisanToplam= mayisToplam= haziranToplam= temmuzToplam= agustosToplam= eylulToplam= ekimToplam= kasimToplam= araliikToplam= genelToplam = 0;
            sirnakOcak= sirnakSubat= sirnakMart= sirnakNisan= sirnakMayis= sirnakHaziran= sirnakTemmuz= sirnakAgustos= sirnakEylul= sirnakEkim= sirnakKasim= sirnakAralik= sirnakToplam = 0;

            dBolgesikOcak = dBolgesiSubat = dBolgesiMart = dBolgesiNisan = dBolgesiMayis = dBolgesiHaziran = dBolgesiTemmuz = dBolgesiAgustos = dBolgesiEylul = dBolgesiEkim = dBolgesiKasim = dBolgesiAralik = dBolgesiToplam = 0;
            cukurcaOcak = cukurcaSubat = cukurcaMart = cukurcaNisan = cukurcaMayis = cukurcaHaziran = cukurcaTemmuz = cukurcaAgustos = cukurcaEylul = cukurcaEkim = cukurcaKasim = cukurcaAralik = cukurcaToplam = 0;
            derecikOcak = derecikSubat = derecikMart = derecikNisan = derecikMayis = derecikHaziran = derecikTemmuz = derecikAgustos = derecikEylul = derecikEkim = derecikKasim = derecikAralik = derecikToplam = 0;
            semdinliOcak = semdinliSubat = semdinliMart = semdinliNisan = semdinliMayis = semdinliHaziran = semdinliTemmuz = semdinliAgustos = semdinliEylul = semdinliEkim = semdinliKasim = semdinliAralik = semdinliToplam = 0;
            yuksekovaOcak = yuksekovaSubat = yuksekovaMart = yuksekovaNisan = yuksekovaMayis = yuksekovaHaziran = yuksekovaTemmuz = yuksekovaAgustos = yuksekovaEylul = yuksekovaEkim = yuksekovaKasim = yuksekovaAralik = yuksekovaToplam = 0;

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
                        if (item2 == "DERECİK" || item2 == "MERKEZ")
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

            ocakToplam = sirnakOcak + cukurcaOcak + yuksekovaOcak + semdinliOcak + derecikOcak + dBolgesikOcak;
            subatToplam = sirnakSubat + cukurcaSubat + yuksekovaSubat + semdinliSubat + derecikSubat + dBolgesiSubat;
            martToplam = sirnakMart + cukurcaMart + yuksekovaMart + semdinliMart + derecikMart + dBolgesiMart;
            nisanToplam = sirnakNisan + cukurcaNisan + yuksekovaNisan + semdinliNisan + derecikNisan + dBolgesiNisan;
            mayisToplam = sirnakMayis + cukurcaMayis + yuksekovaMayis + semdinliMayis + derecikMayis + dBolgesiMayis;
            haziranToplam = sirnakHaziran + cukurcaHaziran + yuksekovaHaziran + semdinliHaziran + derecikHaziran + dBolgesiHaziran;
            temmuzToplam = sirnakTemmuz + cukurcaTemmuz + yuksekovaTemmuz + semdinliTemmuz + derecikTemmuz + dBolgesiTemmuz;
            agustosToplam = sirnakAgustos + cukurcaAgustos + yuksekovaAgustos + semdinliAgustos + derecikAgustos + dBolgesiAgustos;
            eylulToplam = sirnakEylul + cukurcaEylul + yuksekovaEylul + semdinliEylul + derecikEylul + dBolgesiEylul;
            ekimToplam = sirnakEkim + cukurcaEkim + yuksekovaEkim + semdinliEkim + derecikEkim + dBolgesiEkim;
            kasimToplam = sirnakKasim + cukurcaKasim + yuksekovaKasim + semdinliKasim + derecikKasim + dBolgesiKasim;
            araliikToplam = sirnakAralik + cukurcaAralik + yuksekovaAralik + semdinliAralik + derecikAralik + dBolgesiAralik;

            SeriesCollection = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Title = "ŞIRNAK",
                    Values = new ChartValues<double> { sirnakOcak, sirnakSubat , sirnakMart, sirnakNisan, sirnakMayis, sirnakHaziran, sirnakTemmuz, sirnakAgustos, sirnakEylul, sirnakEkim, sirnakKasim, sirnakAralik},
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "ÇUKURCA",
                    Values = new ChartValues<double> { cukurcaOcak, cukurcaSubat, cukurcaMart, cukurcaNisan, cukurcaMayis, cukurcaHaziran, cukurcaTemmuz, cukurcaAgustos, cukurcaEylul, cukurcaEkim, cukurcaKasim, cukurcaAralik},
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "YÜKSEKOVA",
                    Values = new ChartValues<double> { yuksekovaOcak, yuksekovaSubat, yuksekovaMart, yuksekovaNisan, yuksekovaMayis, yuksekovaHaziran, yuksekovaTemmuz, yuksekovaAgustos, yuksekovaEylul, yuksekovaEkim, yuksekovaKasim, yuksekovaAralik},
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "ŞEMDİNLİ",
                    Values = new ChartValues<double> { semdinliOcak, semdinliSubat, semdinliMart, semdinliNisan, semdinliMayis, semdinliHaziran, semdinliTemmuz, semdinliAgustos, semdinliEylul, semdinliEkim, semdinliKasim, semdinliAralik },
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "DERECİK",
                    Values = new ChartValues<double> { derecikOcak, derecikSubat, derecikMart, derecikNisan, derecikMayis, derecikHaziran, derecikTemmuz, derecikAgustos, derecikEylul, derecikEkim, derecikKasim, derecikAralik},
                    StackMode = StackMode.Values,
                    DataLabels = true,
                    FontSize= 25,
                },
                new StackedColumnSeries
                {
                    Title = "D BÖLGESİ",
                    Values = new ChartValues<double> { dBolgesikOcak, dBolgesiSubat, dBolgesiMart, dBolgesiNisan, dBolgesiMayis, dBolgesiHaziran, dBolgesiTemmuz, dBolgesiAgustos, dBolgesiEylul, dBolgesiEkim, dBolgesiKasim, dBolgesiAralik },
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

            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                FontSize = 25,
            });

            Labels = new[] { "OCAK\n" + "( " + ocakToplam.ToString() + " )", "ŞUBAT\n" + "( " + subatToplam.ToString() + " )", "MART\n" + "( " + martToplam.ToString() + " )", "NİSAN\n" + "( " + nisanToplam.ToString() + " )", "MAYIS\n" + "( " + mayisToplam.ToString() + " )", "HAZİRAN\n" + "( " + haziranToplam.ToString() + " )", "TEMMUZ\n" + "( " + temmuzToplam.ToString() + " )", "AĞUSTOS\n" + "( " + agustosToplam.ToString() + " )", "EYLÜL\n" + "( " + eylulToplam.ToString() + " )", "EKİM\n" + "( " + ekimToplam.ToString() + " )", "KASIM\n" + "( " + kasimToplam.ToString() + " )", "ARALIK\n" + "( " + araliikToplam.ToString() + " )" };

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

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Values { get; set; }

    }

}
