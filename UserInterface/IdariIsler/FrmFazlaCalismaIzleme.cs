using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.EMMA;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.IdariIsler
{
    public partial class FrmFazlaCalismaIzleme : Form
    {
        FazlaCalismaManager fazlaCalismaManager;
        List<FazlaCalisma> fazlaCalismas = new List<FazlaCalisma>();
        int id = 0;
        public object[] infos;
        public FrmFazlaCalismaIzleme()
        {
            InitializeComponent();
            fazlaCalismaManager = FazlaCalismaManager.GetInstance();
        }

        private void FrmFazlaCalismaIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageFazlaCalismaIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        public void DataDisplay()
        {
            fazlaCalismas = fazlaCalismaManager.GetList();
            dataBinder.DataSource = fazlaCalismas.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["PersonelAd"].HeaderText = "PERSONEL ADI";
            DtgList.Columns["PersonelBolum"].HeaderText = "BÖLÜM";
            DtgList.Columns["FazlaCalismaNedeni"].HeaderText = "FAZLA ÇALIŞMA NEDENİ";
            DtgList.Columns["MesaiBasTarihi"].HeaderText = "MESAİ BAŞLANGIÇ TAİHİ";
            DtgList.Columns["MesaiBitTarihi"].HeaderText = "MESAİ BİTİŞ TARİHİ";
            DtgList.Columns["ToplamMesaiSaati"].HeaderText = "TOPLAM MESAİ SAATİ";
            DtgList.Columns["ToplamHakEdilenIzin"].HeaderText = "TOPLAM HAK EDİLEN İZİN";
            DtgList.Columns["OnayDurumu"].HeaderText = "ONAY DURUMU";
            DtgList.Columns["OnayVeren"].HeaderText = "ONAY VEREN";
            DtgList.Columns["Donem"].HeaderText = "DÖNEM";
            DtgList.Columns["FazlaCalismaTuru"].HeaderText = "FAZLA ÇALIŞMA TÜRÜ";

            DtgList.Columns["Id"].DisplayIndex = 0;
            DtgList.Columns["PersonelAd"].DisplayIndex = 1;
            DtgList.Columns["PersonelBolum"].DisplayIndex = 2;
            DtgList.Columns["Donem"].DisplayIndex = 3;
            DtgList.Columns["FazlaCalismaTuru"].DisplayIndex = 4;
            DtgList.Columns["MesaiBasTarihi"].DisplayIndex = 5;
            DtgList.Columns["MesaiBitTarihi"].DisplayIndex = 6;
            DtgList.Columns["FazlaCalismaNedeni"].DisplayIndex = 7;
            DtgList.Columns["ToplamMesaiSaati"].DisplayIndex = 8;
            DtgList.Columns["ToplamHakEdilenIzin"].DisplayIndex = 9;
            DtgList.Columns["OnayDurumu"].DisplayIndex = 10;
            DtgList.Columns["OnayVeren"].DisplayIndex = 11;

            ToplamlarMesai();
            ToplamlarIzin();
        }
        
        void ToplamlarMesai()
        {
            double toplam = 0;
            double dakikaTop = 0;
            double dakikaSaat = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                string izinsuresi = DtgList.Rows[i].Cells["ToplamMesaiSaati"].Value.ToString();
                string[] array = izinsuresi.Split(' ');
                toplam += Convert.ToDouble(array[0].ConDouble());
                if (array.Length > 2)
                {
                    double dk = array[0].ConDouble() * 60;
                    dakikaTop += array[2].ConDouble() + dk;
                }
                else
                {
                    if (array[1]=="Saat")
                    {
                        double dk = array[0].ConDouble() * 60;
                        dakikaTop += dk;
                    }
                    else
                    {
                        dakikaTop += array[0].ConDouble();
                    }
                }
            }
            if (dakikaTop != 0)
            {
                dakikaSaat = dakikaTop / 60;
                string[] saat = dakikaSaat.ToString().Split(',');
                dakikaTop = dakikaTop % 60;
                dakikaSaat = saat[0].ConDouble();
                LblFazlaCalisma.Text = dakikaSaat.ToString() + " Saat " + dakikaTop.ToString() + " Dakika";
            }
            else
            {
                LblFazlaCalisma.Text = toplam.ToString() + " Saat";
            }
        }

        void ToplamlarIzin()
        {
            double dakikaTop = 0;
            double dakikaSaat = 0;
            string[] toplamFazlaCalisma = LblFazlaCalisma.Text.Split(' ');
            dakikaTop = toplamFazlaCalisma[0].ConDouble() * 60;
            dakikaTop += toplamFazlaCalisma[2].ConDouble();

            dakikaTop = dakikaTop * 1.5;

            dakikaSaat = dakikaTop / 60;
            string[] saat = dakikaSaat.ToString().Split(',');
            dakikaTop = dakikaTop % 60;
            dakikaSaat = saat[0].ConDouble();

            LblIzin.Text = dakikaSaat.ToString() + " Saat " + dakikaTop.ToString() + " Dakika";

        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
            ToplamlarMesai();
            ToplamlarIzin();

        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmFazlaCalisma Go = new FrmFazlaCalisma();
            Go.id = id;
            Go.infos = infos;
            Go.ShowDialog();
            id = 0;
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
        }
    }
}
