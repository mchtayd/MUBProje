using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
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
    public partial class FrmYakitBeyaniIzleme : Form
    {
        List<Yakit> yakits;
        List<Yakit> yakitsFiltired;
        IdariIslerLogManager logManager;
        YakitManager yakitManager;
        int outValue = 0, id;
        string dosyayolu, sayfa;
        public FrmYakitBeyaniIzleme()
        {
            InitializeComponent();
            yakitManager = YakitManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYakitIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void FrmYakitBeyaniIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        public void DataDisplay()
        {
            yakits = yakitManager.GetList();
            yakitsFiltired = yakits;
            dataBinder.DataSource = yakits.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Plaka"].HeaderText = "PLAKA";
            DtgList.Columns["YakitAlinanDonem"].HeaderText = "YAKIT ALINAN DÖNEM";
            DtgList.Columns["Tarih"].HeaderText = "TARİH";
            DtgList.Columns["Km"].HeaderText = "YAKIT ALINAN KİLOMETRE";
            DtgList.Columns["AlinanLitre"].HeaderText = "ALINAN LİTRE";
            DtgList.Columns["YakitTuru"].HeaderText = "YAKIT TÜRÜ";
            DtgList.Columns["LitreFiyati"].HeaderText = "LİTRE FİYATI";
            DtgList.Columns["ToplamFiyat"].HeaderText = "TOPLAM FİYAT";
            DtgList.Columns["Personel"].HeaderText = "PERSONEL";
            DtgList.Columns["AlinanFirma"].HeaderText = "ALINAN FİRMA";
            DtgList.Columns["BelgeTuru"].HeaderText = "BELGE TÜRÜ";
            DtgList.Columns["BelgeNumarasi"].HeaderText = "BELGE NUMARASI";
            DtgList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;
            Toplamlar();
        }

        private void TxtAkısNo_TextChanged(object sender, EventArgs e)
        {
            int isno = 0;
            if (string.IsNullOrEmpty(TxtAkısNo.Text))
            {
                yakitsFiltired = yakits;
                dataBinder.DataSource = yakits.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtAkısNo.Text.Length < 3)
            {
                return;
            }
            if (!int.TryParse(TxtAkısNo.Text, out outValue))
            {
                MessageBox.Show("Rakamsal Değer Giriniz");
                return;
            }
            isno = TxtAkısNo.Text.ConInt();
            dataBinder.DataSource = yakitsFiltired.Where(x => x.Isakisno.ToString().Contains(isno.ToString())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            yakitsFiltired = yakits;
            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
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

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay();
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
        double sonucUcluk;
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells[9].Value);
                
            }
            LblGenelTop.Text = toplam.ToString("C2");
        }
    }
}
