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
    public partial class FrmAracBakimKayitIzleme : Form
    {
        List<AracBakim> aracBakims;
        List<AracBakim> aracBakimsFiltired;
        List<AracBakim> aracBakimsTamamlanan;
        List<AracBakim> aracBakimsFiltiredTamamlanan;
        AracBakimManager aracBakimManager;
        IdariIslerLogManager logManager;
        string dosyayolu, sayfa, dosyayoluTamamlanan, sayfaTamamlanan;
        int id, idTamamlanan;
        public FrmAracBakimKayitIzleme()
        {
            InitializeComponent();
            aracBakimManager = AracBakimManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }

        private void AracBakimKayitIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
            DataDisplayTamamlanan();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageBakimKayitIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void Yenilenecekler()
        {
            DataDisplay();
            DataDisplayTamamlanan();
        }
        void DataDisplay()
        {
            aracBakims = aracBakimManager.GetList();
            aracBakimsFiltired = aracBakims;
            dataBinder.DataSource = aracBakims.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Plaka"].HeaderText = "ARAÇ PLAKASI";
            DtgList.Columns["Marka"].HeaderText = "MARKASI";
            DtgList.Columns["ModelYili"].HeaderText = "MODEL YILI";
            DtgList.Columns["MotorNo"].HeaderText = "MOTOR NO";
            DtgList.Columns["SaseNo"].HeaderText = "ŞASE NO";
            DtgList.Columns["KullanildigiBolum"].HeaderText = "KULLANILDIĞI BÖLÜM";
            DtgList.Columns["ProjeTahsisTarihi"].HeaderText = "PROJE TAHSİS TARİHİ";
            DtgList.Columns["MulkiyetBilgileri"].HeaderText = "PROJE TAHSİS TARİHİ";
            DtgList.Columns["SiparisNo"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["ZimmetliPersonel"].HeaderText = "ZİMMETLİ PERSONEL";
            DtgList.Columns["Km"].HeaderText = "KİLOMETRE";
            DtgList.Columns["BakimNedeni"].HeaderText = "BAKIM NEDENİ";
            DtgList.Columns["TalepTarihi"].HeaderText = "TALEP TARİHİ";
            DtgList.Columns["BakYapanFirma"].Visible = false;
            DtgList.Columns["ArizaAciklamasi"].HeaderText = "ARIZA AÇIKLAMASI";
            DtgList.Columns["TamamlanmaTarih"].Visible = false;
            DtgList.Columns["SonucAciklama"].Visible = false;
            DtgList.Columns["Tutar"].Visible = false;
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;
        }
        void DataDisplayTamamlanan()
        {
            aracBakimsTamamlanan = aracBakimManager.AracBakimKayitListKapatilmis();
            aracBakimsFiltiredTamamlanan = aracBakimsTamamlanan;
            dataBinder2.DataSource = aracBakimsTamamlanan.ToDataTable();
            DtgListDis.DataSource = dataBinder2;
            TxtTopDis.Text = DtgListDis.RowCount.ToString();

            DtgListDis.Columns["Id"].Visible = false;
            DtgListDis.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgListDis.Columns["Plaka"].HeaderText = "ARAÇ PLAKASI";
            DtgListDis.Columns["Marka"].HeaderText = "MARKASI";
            DtgListDis.Columns["ModelYili"].HeaderText = "MODEL YILI";
            DtgListDis.Columns["MotorNo"].HeaderText = "MOTOR NO";
            DtgListDis.Columns["SaseNo"].HeaderText = "ŞASE NO";
            DtgListDis.Columns["KullanildigiBolum"].HeaderText = "KULLANILDIĞI BÖLÜM";
            DtgListDis.Columns["ProjeTahsisTarihi"].HeaderText = "PROJE TAHSİS TARİHİ";
            DtgListDis.Columns["SiparisNo"].HeaderText = "SİPARİŞ NO";
            DtgListDis.Columns["ZimmetliPersonel"].HeaderText = "ZİMMETLİ PERSONEL";
            DtgListDis.Columns["Km"].HeaderText = "KİLOMETRE";
            DtgListDis.Columns["BakimNedeni"].HeaderText = "BAKIM NEDENİ";
            DtgListDis.Columns["TalepTarihi"].HeaderText = "TALEP TARİHİ";
            DtgListDis.Columns["BakYapanFirma"].HeaderText = "BAKIM YAPAN FİRMA";
            DtgListDis.Columns["ArizaAciklamasi"].HeaderText = "ARIZA AÇIKLAMASI";
            DtgListDis.Columns["TamamlanmaTarih"].HeaderText = "TAMAMLANMA TARİHİ";
            DtgListDis.Columns["SonucAciklama"].HeaderText = "SONUÇ/AÇIKLAMA";
            DtgListDis.Columns["Tutar"].HeaderText = "TUTAR";
            DtgListDis.Columns["DosyaYolu"].Visible = false;
            DtgListDis.Columns["Sayfa"].Visible = false;
            Toplamlar();
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgListDis.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgListDis.Rows[i].Cells[19].Value);
            }
            LblGenelTop.Text = toplam.ToString("C2");
        }

        private void TxtPlakaD_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtPlakaD.Text;
            if (string.IsNullOrEmpty(isim))
            {
                aracBakimsFiltiredTamamlanan = aracBakimsTamamlanan;
                dataBinder2.DataSource = aracBakimsTamamlanan.ToDataTable();
                DtgListDis.DataSource = dataBinder2;
                TxtTopDis.Text = DtgListDis.RowCount.ToString();
                return;
            }
            if (TxtPlakaD.Text.Length < 3)
            {
                return;
            }
            dataBinder2.DataSource = aracBakimsFiltiredTamamlanan.Where(x => x.Plaka.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgListDis.DataSource = dataBinder2;
            aracBakimsFiltiredTamamlanan = aracBakimsTamamlanan;
            TxtTopDis.Text = DtgListDis.RowCount.ToString();
        }

        private void TxtPlaka_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtPlaka.Text;
            if (string.IsNullOrEmpty(isim))
            {
                aracBakimsFiltired = aracBakims;
                dataBinder.DataSource = aracBakims.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtPlaka.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = aracBakimsFiltired.Where(x => x.Plaka.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            aracBakimsFiltired = aracBakims;
            TxtTop.Text = DtgList.RowCount.ToString();
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

        private void DtgListDis_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Filter = DtgListDis.FilterString;
            TxtTopDis.Text = DtgListDis.RowCount.ToString();
            Toplamlar();
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyayolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            sayfa = DtgList.CurrentRow.Cells["Sayfa"].Value.ToString();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            webBrowser1.Navigate(dosyayolu);
            IslemAdimlariDisplay();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay();
            DataDisplayTamamlanan();
        }

        private void DtgListDis_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Sort = DtgListDis.SortString;
        }
        
        private void DtgListDis_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListDis.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyayoluTamamlanan = DtgListDis.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            sayfaTamamlanan = DtgListDis.CurrentRow.Cells["Sayfa"].Value.ToString();
            idTamamlanan = DtgListDis.CurrentRow.Cells["Id"].Value.ConInt();
            webBrowser2.Navigate(dosyayoluTamamlanan);
            IslemAdimlariDisplayTamamlanan();
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
        void IslemAdimlariDisplayTamamlanan()
        {
            DtgIslemAdimlariDis.DataSource = logManager.GetList(sayfaTamamlanan, idTamamlanan);
            DtgIslemAdimlariDis.Columns["Id"].Visible = false;
            DtgIslemAdimlariDis.Columns["Sayfa"].Visible = false;
            DtgIslemAdimlariDis.Columns["Benzersizid"].Visible = false;
            DtgIslemAdimlariDis.Columns["Islem"].HeaderText = "YAPILAN İŞLEM";
            DtgIslemAdimlariDis.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgIslemAdimlariDis.Columns["Tarih"].HeaderText = "TARİH";
            DtgIslemAdimlariDis.Columns["Tarih"].Width = 100;
            DtgIslemAdimlariDis.Columns["Islemyapan"].Width = 135;
            DtgIslemAdimlariDis.Columns["Islem"].Width = 400;
        }
    }
}
