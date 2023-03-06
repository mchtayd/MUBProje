using Business.Concreate.Depo;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Drawing.Charts;
using Entity.Rapor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UserInterface.STS;

namespace UserInterface.RAPORLAMALAR
{
    
    public partial class OTSBOPerformans : Form
    {

        OtsPerfManager otsPerfManager;
        List<OtsPerf> otsPerves;
        List<OtsPerf> otsPervesAdimlar;
        List<OtsPerf> otsPervesData;

        bool start = true;
        int toplamGun=0;
        public OTSBOPerformans()
        {
            InitializeComponent();
            otsPerfManager = OtsPerfManager.GetInstance();
        }

        private void OTSBOPerformans_Load(object sender, EventArgs e)
        {
            Yillar();
            DataDisplay();
            start = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageBOPerformans"]);
            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void Yillar()
        {
            CmbYillar.DataSource = otsPerfManager.Yillar();
            int index = CmbYillar.Items.Count.ConInt() - 1;
            CmbYillar.SelectedIndex = index;
        }

        int sure100, sure200, sure300, sure400, sure500, sure525, sure550, sure600, sure700, sure800, sure900, sure1000, sure1100, sure1200, sure1300, sure1400, sure1500, sure1600, sure1700 = 0;

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
            toplamGun = 0;
            foreach (DataGridViewRow item in DtgList.Rows)
            {
                string[] toplamSure = item.Cells["ToplamSureGun"].Value.ToString().Split(' ');
                toplamGun += toplamSure[0].ConInt();
            }

            LblOrtalama.Text = (toplamGun / TxtTop.Text.ConInt()).ToString();
        }

        private void ChkTumunuGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTumunuGoster.Checked == true)
            {
                CmbYillar.SelectedIndex = -1;
                DataDisplay();
            }
            else
            {
                Yillar();
                DataDisplay();
            }
        }

        private void CmbYillar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbYillar.SelectedIndex == -1)
            {
                return;
            }
            DataDisplay();
        }

        void DataDisplay()
        {
            otsPervesData = new List<OtsPerf>();
            otsPerves = new List<OtsPerf>();
            DtgList.DataSource = null;
            DtgList.ClearFilter();
            toplamGun = 0;
            if (ChkTumunuGoster.Checked == true)
            {
                otsPerves = otsPerfManager.GetList(0);
            }
            else
            {
                otsPerves = otsPerfManager.GetList(CmbYillar.Text.ConInt());
            }

            foreach (OtsPerf item in otsPerves)
            {
                otsPervesAdimlar = otsPerfManager.GetListAdimlar(item.FormNo);

                if (otsPervesAdimlar.Count==0)
                {
                    continue;
                }
                else
                {
                    foreach (OtsPerf item2 in otsPervesAdimlar)
                    {
                        if (item2.IslemAdimi.StartsWith("500"))
                        {
                            sure500 += item2.AdimSureDk.ConInt();
                        }

                        if (item2.IslemAdimi.StartsWith("525"))
                        {
                            sure525 += item2.AdimSureDk.ConInt();
                        }

                        if (item2.IslemAdimi.StartsWith("550"))
                        {
                            sure550 += item2.AdimSureDk.ConInt();
                        }

                        if (item2.IslemAdimi.StartsWith("600"))
                        {
                            sure600 += item2.AdimSureDk.ConInt();
                        }

                        if (item2.IslemAdimi.StartsWith("700"))
                        {
                            sure700 += item2.AdimSureDk.ConInt();
                        }

                        if (item2.IslemAdimi.StartsWith("800"))
                        {
                            sure800 += item2.AdimSureDk.ConInt();
                        }

                        if (item2.IslemAdimi.StartsWith("900"))
                        {
                            sure900 += item2.AdimSureDk.ConInt();
                        }

                        if (item2.IslemAdimi.StartsWith("1000"))
                        {
                            sure1000 += item2.AdimSureDk.ConInt();
                        }

                        if (item2.IslemAdimi.StartsWith("1100"))
                        {
                            sure1100 += item2.AdimSureDk.ConInt();
                        }
                        if (item2.IslemAdimi.StartsWith("1200"))
                        {
                            sure1200 += item2.AdimSureDk.ConInt();
                        }
                        if (item2.IslemAdimi.StartsWith("1300"))
                        {
                            sure1300 += item2.AdimSureDk.ConInt();
                        }
                        if (item2.IslemAdimi.StartsWith("1400"))
                        {
                            sure1400 += item2.AdimSureDk.ConInt();
                        }
                        if (item2.IslemAdimi.StartsWith("1500"))
                        {
                            sure1500 += item2.AdimSureDk.ConInt();
                        }
                        if (item2.IslemAdimi.StartsWith("1600"))
                        {
                            sure1600 += item2.AdimSureDk.ConInt();
                        }
                        if (item2.IslemAdimi.StartsWith("1700"))
                        {
                            sure1700 += item2.AdimSureDk.ConInt();
                        }
                    }

                    string personeAd = otsPerfManager.PersonelSicil(item.BolgeSorumlusu);

                    OtsPerf otsPerf = new OtsPerf(item.FormNo.ConInt(), item.BildirimNo.ToString(), item.BolgeAdi.ToString(), item.MudehaleTarihi.ConDate(), item.OnarimTamamlanmaTarihi.ConDate(), item.ToplamSureGun.ToString(), sure100.ToString(), sure200.ToString(), sure300.ToString(), sure400.ToString(), sure500.ToString(), sure525.ToString(), sure550.ToString(), sure600.ToString(), sure700.ToString(), sure800.ToString(), sure900.ToString(), sure1000.ToString(), sure1100.ToString(), sure1200.ToString(), sure1300.ToString(), sure1400.ToString(), sure1500.ToString(), sure1600.ToString(), sure1700.ToString(), item.Ilce.ToString(), personeAd, item.Kategori, item.Proje);

                    otsPervesData.Add(otsPerf);

                    string[] toplamSure = item.ToplamSureGun.Split(' ');

                    toplamGun += toplamSure[0].ConInt();

                    sure100 = 0; sure200 = 0; sure300 = 0; sure400 = 0; sure500 = 0; sure525 = 0; sure550 = 0; sure600 = 0; sure700 = 0; sure800 = 0; sure900 = 0; sure1000 = 0; sure1100 = 0; sure1200 = 0; sure1300 = 0; sure1400 = 0; sure1500 = 0; sure1600 = 0; sure1700 = 0;
                }
            }

            dataBinder.DataSource = otsPervesData.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();
            DataEdit();

        }

        void DataEdit()
        {
            DtgList.Columns["FormNo"].HeaderText = "FORM NO";
            DtgList.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";
            DtgList.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgList.Columns["MudehaleTarihi"].HeaderText = "MÜDEHALE TARİHİ";
            DtgList.Columns["OnarimTamamlanmaTarihi"].HeaderText = "ONARIM TAMAMLANMA TARİHİ";
            DtgList.Columns["ToplamSureGun"].HeaderText = "TOPLAM SÜRE (GÜN)";
            DtgList.Columns["Sure100"].HeaderText = "100_ARIZANIN BİLDİRİLMESİ";
            DtgList.Columns["Sure200"].HeaderText = "200_ARIZA TESPİT (FI/FD)";
            DtgList.Columns["Sure300"].HeaderText = "300_SİPARİŞ OLUŞTURMA (OTS)";
            DtgList.Columns["Sure400"].HeaderText = "400_ARIZA BİLDİRİMİ (ASL)";
            DtgList.Columns["Sure500"].HeaderText = "500_BİLDİRİM ONAYI";
            DtgList.Columns["Sure525"].HeaderText = "525_OKF HAZIRLAMA";
            DtgList.Columns["Sure550"].HeaderText = "550_MÜŞTERİ ONAYI";
            DtgList.Columns["Sure600"].HeaderText = "600_SERVİS TALEBİ";
            DtgList.Columns["Sure700"].HeaderText = "700_FABRİKA B/O (ASELSAN)";
            DtgList.Columns["Sure800"].HeaderText = "800_MALZ.TEMİNİ (ASELSAN)";
            DtgList.Columns["Sure900"].HeaderText = "900_MALZ.TEMİNİ (SATIN ALMA)";
            DtgList.Columns["Sure1000"].HeaderText = "1000_MALZEME HAZIRLAMA (AMBAR)";
            DtgList.Columns["Sure1100"].HeaderText = "1100_MALZEME PAKETLEME";
            DtgList.Columns["Sure1200"].HeaderText = "1200_BÖLGE SEVKİYAT";
            DtgList.Columns["Sure1300"].HeaderText = "1300_SAHA B/O (BAŞARAN)";
            DtgList.Columns["Sure1400"].HeaderText = "1400";
            DtgList.Columns["Sure1500"].HeaderText = "1500_FONKSİYONEL TEST";
            DtgList.Columns["Sure1600"].HeaderText = "1600_MÜŞTERİ TESLİMATI";
            DtgList.Columns["Sure1700"].HeaderText = "1700_ARIZA KAPATMA (OTS)";
            DtgList.Columns["Ilce"].HeaderText = "İLÇE";
            DtgList.Columns["BolgeSorumlusu"].HeaderText = "SORUMLU PERSONEL";
            DtgList.Columns["AdimSureDk"].Visible = false;
            DtgList.Columns["IslemAdimi"].Visible = false;
            DtgList.Columns["Kategori"].HeaderText = "KATEGORİ";
            DtgList.Columns["Proje"].HeaderText = "PROJE";

            DtgList.Columns["FormNo"].DisplayIndex = 0;
            DtgList.Columns["BildirimNo"].DisplayIndex = 1;
            DtgList.Columns["BolgeAdi"].DisplayIndex = 2;
            DtgList.Columns["MudehaleTarihi"].DisplayIndex = 5;
            DtgList.Columns["OnarimTamamlanmaTarihi"].DisplayIndex = 6;
            DtgList.Columns["ToplamSureGun"].DisplayIndex = 7;
            DtgList.Columns["Sure100"].DisplayIndex = 8;
            DtgList.Columns["Sure200"].DisplayIndex = 9;
            DtgList.Columns["Sure300"].DisplayIndex = 10;
            DtgList.Columns["Sure400"].DisplayIndex = 11;
            DtgList.Columns["Sure500"].DisplayIndex = 12;
            DtgList.Columns["Sure525"].DisplayIndex = 13;
            DtgList.Columns["Sure550"].DisplayIndex = 14;
            DtgList.Columns["Sure600"].DisplayIndex = 15;
            DtgList.Columns["Sure700"].DisplayIndex = 16;
            DtgList.Columns["Sure800"].DisplayIndex = 17;
            DtgList.Columns["Sure900"].DisplayIndex = 18;
            DtgList.Columns["Sure1000"].DisplayIndex = 19;
            DtgList.Columns["Sure1100"].DisplayIndex = 20;
            DtgList.Columns["Sure1200"].DisplayIndex = 21;
            DtgList.Columns["Sure1300"].DisplayIndex = 22;
            DtgList.Columns["Sure1400"].DisplayIndex = 23;
            DtgList.Columns["Sure1500"].DisplayIndex = 24;
            DtgList.Columns["Sure1600"].DisplayIndex = 25;
            DtgList.Columns["Sure1700"].DisplayIndex = 26;
            DtgList.Columns["Ilce"].DisplayIndex = 3;
            DtgList.Columns["BolgeSorumlusu"].DisplayIndex = 4;
            DtgList.Columns["AdimSureDk"].Visible = false;
            DtgList.Columns["IslemAdimi"].Visible = false;

            Ortalama();
        }

        void Ortalama()
        {
            LblOrtalama.Text = (toplamGun / TxtTop.Text.ConInt()).ToString() + " Gün";
        }
    }
}
