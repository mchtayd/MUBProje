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

        int sure500, sure600, sure700, sure800, sure900, sure1000, sure1100, sure1200, sure1300 = 0;

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
            //if (CmbYillar.Text == "2021")
            //{
            //    otsPerves = otsPerfManager.GetList(1990);
            //}
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
                        if (item2.IslemAdimi.StartsWith("500") || item2.IslemAdimi.StartsWith("525") || item2.IslemAdimi.StartsWith("550"))
                        {
                            sure500 += item2.AdimSureDk.ConInt();
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
                    }

                    OtsPerf otsPerf = new OtsPerf(item.FormNo.ConInt(), item.BildirimNo.ToString(), item.BolgeAdi.ToString(), item.MudehaleTarihi.ConDate(), item.OnarimTamamlanmaTarihi.ConDate(), item.ToplamSureGun.ToString(), sure500.ToString(), sure600.ToString(), sure700.ToString(), sure800.ToString(), sure900.ToString(), sure1000.ToString(), sure1100.ToString(), sure1200.ToString(), sure1300.ToString());

                    otsPervesData.Add(otsPerf);

                    string[] toplamSure = item.ToplamSureGun.Split(' ');

                    toplamGun += toplamSure[0].ConInt();

                    sure500 = 0; sure600 = 0; sure700 = 0; sure800 = 0; sure900 = 0; sure1000 = 0; sure1100 = 0; sure1200 = 0; sure1300 = 0;
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
            DtgList.Columns["Sure500"].HeaderText = "500_BİLDİRİM ONAYI";
            DtgList.Columns["Sure600"].HeaderText = "600_SERVİS TALEBİ";
            DtgList.Columns["Sure700"].HeaderText = "700_FABRİKA B/O (ASELSAN)";
            DtgList.Columns["Sure800"].HeaderText = "800_MALZ.TEMİNİ (ASELSAN)";
            DtgList.Columns["Sure900"].HeaderText = "900_MALZ.TEMİNİ (SATIN ALMA)";
            DtgList.Columns["Sure1000"].HeaderText = "1000_MALZEME HAZIRLAMA (AMBAR)";
            DtgList.Columns["Sure1100"].HeaderText = "1100_MALZEME PAKETLEME";
            DtgList.Columns["Sure1200"].HeaderText = "1200_BÖLGE SEVKİYAT";
            DtgList.Columns["Sure1300"].HeaderText = "1300_SAHA B/O (BAŞARAN)";
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
