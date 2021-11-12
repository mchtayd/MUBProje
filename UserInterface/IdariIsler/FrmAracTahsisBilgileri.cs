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
    public partial class FrmAracTahsisBilgileri : Form
    {
        List<Arac> aracs;
        List<Arac> aracsFiltired;
        List<Arac> aracsDis;
        List<Arac> aracsFiltiredDis;
        AracManager aracManager;
        IdariIslerLogManager logManager;
        string dosyayolu, sayfa;
        int id;
        public FrmAracTahsisBilgileri()
        {
            InitializeComponent();
            aracManager = AracManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }

        private void FrmAracTahsisBilgileri_Load(object sender, EventArgs e)
        {
            DataDisplay();
            DataDisplayProjeDisi();
        }
        public void YenilenecekVeri()
        {
            DataDisplay();
            DataDisplayProjeDisi();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageAracTahsisBilgileri"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void DataDisplay()
        {
            aracs = aracManager.GetList();
            aracsFiltired = aracs;
            dataBinder.DataSource = aracs.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Plaka"].HeaderText = "ARAÇ PLAKASI";
            DtgList.Columns["IlkTescilTarihi"].HeaderText = "ARAÇ PLAKASI";
            DtgList.Columns["TescilTarihi"].HeaderText = "TECİL TARİHİ";
            DtgList.Columns["Markasi"].HeaderText = "MARKASI";
            DtgList.Columns["Tipi"].HeaderText = "TİPİ";
            DtgList.Columns["TicariAdi"].HeaderText = "TİCARİ ADI";
            DtgList.Columns["ModelYili"].HeaderText = "MODEL YILI";
            DtgList.Columns["AracSinifi"].HeaderText = "ARAÇ SINIFI";
            DtgList.Columns["Cinsi"].HeaderText = "CİNSİ";
            DtgList.Columns["Rengi"].HeaderText = "RENGİ";
            DtgList.Columns["MotorNo"].HeaderText = "MOTOR NO";
            DtgList.Columns["SaseNo"].HeaderText = "ŞASE NO";
            DtgList.Columns["YakitCinsi"].HeaderText = "YAKIT CİNSİ";
            DtgList.Columns["MulkiyetBilgileri"].HeaderText = "MÜLKİYET BİLGİLERİ";
            DtgList.Columns["Proje"].HeaderText = "KULLANILDIĞI PROJE";
            DtgList.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["TasitTanima"].HeaderText = "TAŞIT TANIMA";
            DtgList.Columns["Arventoid"].HeaderText = "ARVENTO ID";
            DtgList.Columns["ProjeTahsisTarihi"].HeaderText = "PROJEYE TAHSİS TARİHİ";
            DtgList.Columns["ProjeCikisTarihi"].HeaderText = "PROJE ÇIKIŞ TARİHİ";
            DtgList.Columns["ProjeCikisNedeni"].HeaderText = "PROJE ÇIKIŞ NEDENİ";
            DtgList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgList.Columns["KmGiris"].HeaderText = "PROJEYE GİRİŞ KM";
            DtgList.Columns["KmCikis"].HeaderText = "PROJEDEN ÇIKIŞ KM";
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;
        }
        void DataDisplayProjeDisi()
        {
            aracsDis = aracManager.ProjeDisiList();
            aracsFiltiredDis = aracsDis;
            dataBinder2.DataSource = aracsDis.ToDataTable();
            DtgListDis.DataSource = dataBinder2;
            TxtTopDis.Text = DtgListDis.RowCount.ToString();

            DtgListDis.Columns["Id"].Visible = false;
            DtgListDis.Columns["Plaka"].HeaderText = "ARAÇ PLAKASI";
            DtgListDis.Columns["IlkTescilTarihi"].HeaderText = "ARAÇ PLAKASI";
            DtgListDis.Columns["TescilTarihi"].HeaderText = "TECİL TARİHİ";
            DtgListDis.Columns["Markasi"].HeaderText = "MARKASI";
            DtgListDis.Columns["Tipi"].HeaderText = "TİPİ";
            DtgListDis.Columns["TicariAdi"].HeaderText = "TİCARİ ADI";
            DtgListDis.Columns["ModelYili"].HeaderText = "MODEL YILI";
            DtgListDis.Columns["AracSinifi"].HeaderText = "ARAÇ SINIFI";
            DtgListDis.Columns["Cinsi"].HeaderText = "CİNSİ";
            DtgListDis.Columns["Rengi"].HeaderText = "RENGİ";
            DtgListDis.Columns["MotorNo"].HeaderText = "MOTOR NO";
            DtgListDis.Columns["SaseNo"].HeaderText = "ŞASE NO";
            DtgListDis.Columns["YakitCinsi"].HeaderText = "YAKIT CİNSİ";
            DtgListDis.Columns["MulkiyetBilgileri"].HeaderText = "MÜLKİYET BİLGİLERİ";
            DtgListDis.Columns["Proje"].HeaderText = "KULLANILDIĞI PROJE";
            DtgListDis.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgListDis.Columns["TasitTanima"].HeaderText = "TAŞIT TANIMA";
            DtgListDis.Columns["Arventoid"].HeaderText = "ARVENTO ID";
            DtgListDis.Columns["ProjeTahsisTarihi"].HeaderText = "PROJEYE TAHSİS TARİHİ";
            DtgListDis.Columns["ProjeCikisTarihi"].HeaderText = "PROJE ÇIKIŞ TARİHİ";
            DtgListDis.Columns["ProjeCikisNedeni"].HeaderText = "PROJE ÇIKIŞ NEDENİ";
            DtgListDis.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgListDis.Columns["DosyaYolu"].Visible = false;
            DtgListDis.Columns["Sayfa"].Visible = false;

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

        private void TxtPlaka_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtPlaka.Text;
            if (string.IsNullOrEmpty(isim))
            {
                aracsFiltired = aracs;
                dataBinder.DataSource = aracs.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtPlaka.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = aracsFiltired.Where(x => x.Plaka.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            aracsFiltired = aracs;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay();
            DataDisplayProjeDisi();
        }

        private void TxtPlakaD_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtPlakaD.Text;
            if (string.IsNullOrEmpty(isim))
            {
                aracsFiltiredDis = aracsDis;
                dataBinder2.DataSource = aracsDis.ToDataTable();
                DtgListDis.DataSource = dataBinder2;
                TxtTopDis.Text = DtgListDis.RowCount.ToString();
                return;
            }
            if (TxtPlakaD.Text.Length < 3)
            {
                return;
            }
            dataBinder2.DataSource = aracsFiltiredDis.Where(x => x.Plaka.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgListDis.DataSource = dataBinder2;
            aracsFiltiredDis = aracsDis;
            TxtTopDis.Text = DtgListDis.RowCount.ToString();
        }

        private void DtgListDis_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Filter = DtgListDis.FilterString;
            TxtTopDis.Text = DtgListDis.RowCount.ToString();
        }

        private void DtgListDis_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Sort = DtgListDis.SortString;
        }
        string dosyayoluDis, sayfaDis;int idDis;
        private void DtgListDis_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListDis.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyayoluDis = DtgListDis.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            sayfaDis = DtgListDis.CurrentRow.Cells["Sayfa"].Value.ToString();
            idDis = DtgListDis.CurrentRow.Cells["Id"].Value.ConInt();
            webBrowser2.Navigate(dosyayoluDis);
            IslemAdimlariDisplayDis();
        }

        private void DtgList_KeyDown(object sender, KeyEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyayolu = DtgList.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            sayfa = DtgList.CurrentRow.Cells["Sayfa"].Value.ToString();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            try
            {
                webBrowser1.Navigate(dosyayolu);
            }
            catch (Exception)
            {
                return;
            }
            IslemAdimlariDisplay();
        }

        private void DtgListDis_KeyDown(object sender, KeyEventArgs e)
        {
            if (DtgListDis.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyayoluDis = DtgListDis.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            sayfaDis = DtgListDis.CurrentRow.Cells["Sayfa"].Value.ToString();
            idDis = DtgListDis.CurrentRow.Cells["Id"].Value.ConInt();
            webBrowser2.Navigate(dosyayoluDis);
            IslemAdimlariDisplayDis();
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
        void IslemAdimlariDisplayDis()
        {
            DtgIslemAdimlariDis.DataSource = logManager.GetList(sayfaDis, idDis);
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
