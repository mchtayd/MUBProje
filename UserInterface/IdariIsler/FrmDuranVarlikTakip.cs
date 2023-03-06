using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DataAccess.Concreate.IdariIsler;
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
    public partial class FrmDuranVarlikTakip : Form
    {
        List<DuranVarlikKayit> durans;
        List<DuranVarlikKayit> duransFiltired;
        IdariIslerLogManager logManager;
        DVKayitManager kayitManager;
        int outValue = 0, id;
        string dosyayolu, sayfa;
        public FrmDuranVarlikTakip()
        {
            InitializeComponent();
            logManager = IdariIslerLogManager.GetInstance();
            kayitManager = DVKayitManager.GetInstance();
        }

        private void FrmDuranVarlikTakip_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDuranVarlikTakip"]);

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
            durans = kayitManager.GetList();
            duransFiltired = durans;
            dataBinder.DataSource = durans.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["DvSahibi"].HeaderText = "DV SAHİBİ";
            DtgList.Columns["ButceKodu"].HeaderText = "BÜTÇE KODU";
            DtgList.Columns["DvEtiketNo"].HeaderText = "DV ETİKET NO";
            DtgList.Columns["DvGrubu"].HeaderText = "DV GRUBU";
            DtgList.Columns["DvTanim"].HeaderText = "DV TANIM";
            DtgList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgList.Columns["Marka"].HeaderText = "MARKA";
            DtgList.Columns["Model"].HeaderText = "MODEL";
            DtgList.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["KalGerek"].HeaderText = "DV KALİBRASYON GEREKİYOR MU";
            DtgList.Columns["SatNo"].HeaderText = "SAT NO";
            DtgList.Columns["SaticiFirma"].HeaderText = "SATICI FİRMA";
            DtgList.Columns["Tarih"].HeaderText = "FATURA TARİHİ";
            DtgList.Columns["FaturaNo"].HeaderText = "FATURA NO";
            DtgList.Columns["Fiyat"].HeaderText = "FİYAT";
            DtgList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgList.Columns["Durumu"].HeaderText = "DURUMU";
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["FotoYolu"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;
            Toplamlar();
        }

        private void TxtIsAkisNo_TextChanged(object sender, EventArgs e)
        {
            int isno = 0;
            if (string.IsNullOrEmpty(TxtIsAkisNo.Text))
            {
                duransFiltired = durans;
                dataBinder.DataSource = durans.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtIsAkisNo.Text.Length < 3)
            {
                return;
            }
            if (!int.TryParse(TxtIsAkisNo.Text, out outValue))
            {
                MessageBox.Show("Rakamsal Değer Giriniz");
                return;
            }
            isno = TxtIsAkisNo.Text.ConInt();
            dataBinder.DataSource = duransFiltired.Where(x => x.IsAkisNo.ToString().Contains(isno.ToString())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            duransFiltired = durans;
            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells[16].Value);
            }
            LblGenelTop.Text = toplam.ToString("C2");
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyayolu = DtgList.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            sayfa = DtgList.CurrentRow.Cells["Sayfa"].Value.ToString();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            webBrowser1.Navigate(dosyayolu);
            IslemAdimlariDisplay();
        }
        void IslemAdimlariDisplay()
        {
            DtgIslemAdimlari.DataSource = logManager.GetList(sayfa, id);
            DtgIslemAdimlari.Columns["Id"].Visible = false;
            DtgIslemAdimlari.Columns["Sayfa"].Visible = false;
            DtgIslemAdimlari.Columns["Benzersizid"].Visible = false;
            DtgIslemAdimlari.Columns["Islem"].HeaderText = "YAPILAN İŞLEM";
            DtgIslemAdimlari.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgIslemAdimlari.Columns["Tarih"].HeaderText = "TARİH";
            DtgIslemAdimlari.Columns["Tarih"].Width = 100;
            DtgIslemAdimlari.Columns["Islemyapan"].Width = 135;
            DtgIslemAdimlari.Columns["Islem"].Width = 400;
        }
    }
}
