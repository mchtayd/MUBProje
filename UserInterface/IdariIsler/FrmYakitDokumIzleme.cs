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
    public partial class FrmYakitDokumIzleme : Form
    {
        YakitDokumManager yakitDokumManager;
        List<YakitDokum> yakitDokums;
        List<YakitDokum> yakitDokumsMalzemeler;
        List<YakitDokum> yakitDokumsTasit;
        string siparisNo="", dosyaYolu="";
        public FrmYakitDokumIzleme()
        {
            InitializeComponent();
            yakitDokumManager = YakitDokumManager.GetInstance();
        }

        private void FrmYakitDokumIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
            DataDisplayTasima();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYakitDokumIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void YenilenecekVeri()
        {
            DataDisplay();
            DataDisplayTasima();
        }
        void DataDisplay()
        {
            yakitDokums = yakitDokumManager.GetListAna("ANLAŞMALI PETROL");
            dataBinder.DataSource = yakitDokums.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
            Toplamlar2();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["IsAkisNo"].Visible = false;
            DtgList.Columns["Firma"].HeaderText = "FİRMA";
            DtgList.Columns["Donem"].HeaderText = "DÖNEM";
            DtgList.Columns["Tarih"].Visible = false;
            DtgList.Columns["DefterNo"].Visible = false;
            DtgList.Columns["SiraNo"].Visible = false;
            DtgList.Columns["FisNo"].Visible = false;
            DtgList.Columns["Personel"].Visible = false;
            DtgList.Columns["Plaka"].Visible = false;
            DtgList.Columns["AracSiparisNo"].Visible = false;
            DtgList.Columns["LitreFiyati"].Visible = false;
            DtgList.Columns["VerilenLitre"].HeaderText = "ALINAN LİTRE TOPLAMI";
            DtgList.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["SiparisNo"].Visible = false;
            DtgList.Columns["AlimTuru"].HeaderText = "ALIM TÜRÜ";
        }
        void DataDisplayTasima()
        {
            yakitDokumsTasit = yakitDokumManager.GetListTT();
            dataBinder3.DataSource = yakitDokumsTasit.ToDataTable();
            DtgListTasit.DataSource = dataBinder3;
            TxtTopTasit.Text = DtgListTasit.RowCount.ToString();
            ToplamlarTasit();

            DtgListTasit.Columns["Id"].Visible = false;
            DtgListTasit.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgListTasit.Columns["Firma"].HeaderText = "FİRMA";
            DtgListTasit.Columns["Donem"].HeaderText = "DÖNEM";
            DtgListTasit.Columns["Tarih"].HeaderText = "TARİH";
            DtgListTasit.Columns["DefterNo"].Visible = false;
            DtgListTasit.Columns["SiraNo"].Visible = false;
            DtgListTasit.Columns["FisNo"].Visible = false;
            DtgListTasit.Columns["Personel"].Visible = false;
            DtgListTasit.Columns["Plaka"].HeaderText = "PLAKA";
            DtgListTasit.Columns["AracSiparisNo"].HeaderText = "ARAÇ SİPARİŞ NO";
            DtgListTasit.Columns["LitreFiyati"].Visible = false;
            DtgListTasit.Columns["VerilenLitre"].HeaderText = "VERİLEN LİTRE";
            DtgListTasit.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            DtgListTasit.Columns["DosyaYolu"].Visible = false;
            DtgListTasit.Columns["SiparisNo"].Visible = false;
            DtgListTasit.Columns["AlimTuru"].Visible = false;
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            siparisNo = DtgList.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyaYolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            yakitDokumsMalzemeler = yakitDokumManager.GetList(siparisNo);
            dataBinder2.DataSource = yakitDokumsMalzemeler;
            DtgKalemler.DataSource = dataBinder2;
            Display2();
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        void Display2()
        {
            DtgKalemler.Columns["Id"].Visible = false;
            DtgKalemler.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgKalemler.Columns["Firma"].HeaderText = "FİRMA";
            DtgKalemler.Columns["Donem"].HeaderText = "DÖNEM";
            DtgKalemler.Columns["Tarih"].HeaderText = "TARİH";
            DtgKalemler.Columns["DefterNo"].HeaderText = "DEFTER NO";
            DtgKalemler.Columns["SiraNo"].HeaderText = "SIRA NO";
            DtgKalemler.Columns["FisNo"].HeaderText = "FİŞ NO";
            DtgKalemler.Columns["Personel"].HeaderText = "YAKIT ALAN PERSONEL";
            DtgKalemler.Columns["Plaka"].HeaderText = "PLAKA";
            DtgKalemler.Columns["AracSiparisNo"].HeaderText = "ARAÇ SİPARİ NO";
            DtgKalemler.Columns["LitreFiyati"].HeaderText = "LİTRE FİYATI";
            DtgKalemler.Columns["VerilenLitre"].HeaderText = "ALINAN LİTRE TOPLAMI";
            DtgKalemler.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            DtgKalemler.Columns["DosyaYolu"].Visible = false;
            DtgKalemler.Columns["SiparisNo"].Visible = false;
            DtgKalemler.Columns["AlimTuru"].Visible = false;
            TxtTop2.Text = DtgKalemler.RowCount.ToString();
            Toplamlar3();
            Toplamlar4();
        }
        void Display2Tasit()
        {
            DtgKalemlerTasit.Columns["Id"].Visible = false;
            DtgKalemlerTasit.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgKalemlerTasit.Columns["Firma"].HeaderText = "FİRMA";
            DtgKalemlerTasit.Columns["Donem"].HeaderText = "DÖNEM";
            DtgKalemlerTasit.Columns["Tarih"].HeaderText = "TARİH";
            DtgKalemlerTasit.Columns["DefterNo"].Visible = false;
            DtgKalemlerTasit.Columns["SiraNo"].Visible = false;
            DtgKalemlerTasit.Columns["FisNo"].Visible = false;
            DtgKalemlerTasit.Columns["Personel"].Visible = false;
            DtgKalemlerTasit.Columns["Plaka"].HeaderText = "PLAKA";
            DtgKalemlerTasit.Columns["AracSiparisNo"].HeaderText = "ARAÇ SİPARİ NO";
            DtgKalemlerTasit.Columns["LitreFiyati"].Visible = false;
            DtgKalemlerTasit.Columns["VerilenLitre"].Visible = false;
            DtgKalemlerTasit.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            DtgKalemlerTasit.Columns["DosyaYolu"].Visible = false;
            DtgKalemlerTasit.Columns["SiparisNo"].Visible = false;
            DtgKalemlerTasit.Columns["AlimTuru"].Visible = false;
            TxtTop2.Text = DtgKalemlerTasit.RowCount.ToString();
            Toplamlar3Tasit();
            Toplamlar4Tasit();
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells[12].Value);
            }
            ToplamLitre.Text = toplam.ToString();
        }
        void ToplamlarTasit()
        {
            double toplam = 0;
            for (int i = 0; i < DtgListTasit.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgListTasit.Rows[i].Cells[13].Value);
            }
            LblGenelTopTasima.Text = toplam.ToString("C2");
        }
        void ToplamlarTasitKalemler()
        {
            double toplam = 0;
            for (int i = 0; i < DtgKalemlerTasit.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgKalemlerTasit.Rows[i].Cells[13].Value);
            }
            LblGenelTopTasimaKalemler.Text = toplam.ToString();
        }
        void Toplamlar2()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells[13].Value);
            }
            LblGenelTop.Text = toplam.ToString("C2");
        }
        void Toplamlar3()
        {
            double toplam = 0;
            for (int i = 0; i < DtgKalemler.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgKalemler.Rows[i].Cells[13].Value);
            }
            LblGenelToplam2.Text = toplam.ToString("C2");
        }
        void Toplamlar3Tasit()
        {
            double toplam = 0;
            for (int i = 0; i < DtgKalemlerTasit.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgKalemlerTasit.Rows[i].Cells[13].Value);
            }
            label13.Text = toplam.ToString();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
            Toplamlar2();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void DtgKalemler_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Filter = DtgKalemler.FilterString;
            TxtTop2.Text = DtgKalemler.RowCount.ToString();
            Toplamlar3();
            Toplamlar4();
        }

        private void DtgKalemler_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Sort = DtgKalemler.SortString;
        }

        private void DtgListTasit_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListTasit.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            siparisNo = DtgListTasit.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyaYolu = DtgListTasit.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            yakitDokumsMalzemeler = yakitDokumManager.GetList(siparisNo);
            dataBinder4.DataSource = yakitDokumsMalzemeler;
            DtgKalemlerTasit.DataSource = dataBinder4;
            Display2Tasit();
            try
            {
                webBrowser2.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private void DtgListTasit_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder3.Filter = DtgListTasit.FilterString;
            TxtTopTasit.Text = DtgListTasit.RowCount.ToString();
            ToplamlarTasit();
        }

        private void DtgListTasit_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder3.Sort = DtgListTasit.SortString;
        }

        void Toplamlar4()
        {
            double toplam = 0;
            for (int i = 0; i < DtgKalemler.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgKalemler.Rows[i].Cells[12].Value);
            }
            LblAlinanLitre2.Text = toplam.ToString();
        }
        void Toplamlar4Tasit()
        {
            double toplam = 0;
            for (int i = 0; i < DtgKalemlerTasit.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgKalemlerTasit.Rows[i].Cells[12].Value);
            }
            LblGenelTopTasimaKalemler.Text = toplam.ToString("C2");
        }
    }
}
