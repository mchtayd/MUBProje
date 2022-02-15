using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
using Entity.BakimOnarim;
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

namespace UserInterface.BakımOnarım
{
    public partial class FrmServisTalepleriIzleme : Form
    {
        ServisFormuManager servisFormuManager;
        SFYedekParcaManager sFYedekParcaManager;

        List<ServisFormu> servisFormus = new List<ServisFormu>();
        List<SFYedekPaca> sFYedekPacas = new List<SFYedekPaca>();

        int id;
        string siparisNo, dosyaYolu = "";
        public FrmServisTalepleriIzleme()
        {
            InitializeComponent();
            servisFormuManager = ServisFormuManager.GetInstance();
            sFYedekParcaManager = SFYedekParcaManager.GetInstance();

        }

        private void FrmServisTalepleriIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageServisFormuİzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void DataDisplay()
        {
            servisFormus = servisFormuManager.GetList();
            dataBinder.DataSource = servisFormus.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Firma"].HeaderText = "FİRMA";
            DtgList.Columns["UsBolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgList.Columns["ServisFormNo"].HeaderText = "SERVİS FORM NO";
            DtgList.Columns["MudehaleTuru"].HeaderText = "MÜDEHALE TÜRÜ";
            DtgList.Columns["ServisTarihi"].HeaderText = "SERVİS TARİHİ";
            DtgList.Columns["JenaratorCalismaSaati"].HeaderText = "JENARATÖR ÇALIŞMA SAATİ";
            DtgList.Columns["IsBaslamaTarihi"].HeaderText = "İŞE BAŞLAMA TARİHİ";
            DtgList.Columns["IsBitisTarihi"].HeaderText = "İŞE BİTİŞ TARİHİ";
            DtgList.Columns["Marka"].HeaderText = "MARKA";
            DtgList.Columns["Model"].HeaderText = "MODEL";
            DtgList.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["Guc"].HeaderText = "GÜÇ (KVA)";
            DtgList.Columns["ServisRaporu"].Visible = false;
            DtgList.Columns["ServisYetkilisi"].HeaderText = "SERVİS YETKİLİSİ";
            DtgList.Columns["Musteri"].HeaderText = "MÜŞTERİ";
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["SiparisNo"].Visible = false;
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            TxtServisRaporu.Text = DtgList.CurrentRow.Cells["ServisRaporu"].Value.ToString();
            siparisNo = DtgList.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyaYolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            webBrowser1.Navigate(dosyaYolu);
            MalzemeList();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        void MalzemeList()
        {
            sFYedekPacas = sFYedekParcaManager.GetList(siparisNo);
            DtgMalzemeler.DataSource = sFYedekPacas;

            DtgMalzemeler.Columns["Id"].Visible = false;
            DtgMalzemeler.Columns["ParcaKodu"].HeaderText = "PARÇA KODU";
            DtgMalzemeler.Columns["KullanilanMalzeme"].HeaderText = "KULLANILAN MALZEME";
            DtgMalzemeler.Columns["Adet"].HeaderText = "ADET";
            DtgMalzemeler.Columns["SiparisNo"].Visible = false;
        }
    }
}
