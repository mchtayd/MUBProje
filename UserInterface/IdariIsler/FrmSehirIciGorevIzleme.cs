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
    public partial class FrmSehirIciGorevIzleme : Form
    {
        int outValue = 0;
        string sayfatamamlanan; int idtamamlanan;
        SehiriciGorevManager sehirIciGorevManager;
        IdariIslerLogManager logManager;
        List<SehiriciGorev> sehiriciGorevs;
        List<SehiriciGorev> sehiriciGorevsTamamlanan;
        List<SehiriciGorev> sehiriciGorevsTamamlananFiltired;
        List<SehiriciGorev> sehiriciGorevsFiltired;

        public object[] infos;

        public FrmSehirIciGorevIzleme()
        {
            InitializeComponent();
            sehirIciGorevManager = SehiriciGorevManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }

        private void FrmSehirIciGorevIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
            if (infos[0].ConInt() != 84)
            {
                if (infos[0].ConInt() != 25)
                {
                    if (infos[0].ConInt() != 30)
                    {
                        tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage2"]);
                    }
                }
                
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSehirIzleme"]);

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
            if (infos[0].ConInt()== 84 || infos[0].ConInt() == 25)
            {
                DtgLog.DataSource = "";
                sehiriciGorevs = sehirIciGorevManager.DevamEdenler();
            }
            else
            {
                DtgLog.DataSource = "";
                sehiriciGorevs = sehirIciGorevManager.DevamEdenler(infos[0].ConInt());
            }

            
            sehiriciGorevsFiltired = sehiriciGorevs;
            dataBinder.DataSource = sehiriciGorevs.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Gidilecekyer"].HeaderText = "GİDİLECEK YER";
            DtgList.Columns["Gorevinkonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgList.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgList.Columns["Bitistarihi"].Visible = false;
            DtgList.Columns["Toplamsure"].Visible = false;
            DtgList.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgList.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgList.Columns["Masrafyerno"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgList.Columns["Proje"].HeaderText = "PROJE";
            DtgList.Columns["Islemadimi"].HeaderText = "DURUM";
            //DtgList.Columns["Islemadimi"].Visible = false;
            DtgList.Columns["Gecensure"].Visible = false;
            DtgList.Columns["Personelid"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Isakisno"].DisplayIndex = 0;
            DtgList.Columns["Adsoyad"].DisplayIndex = 1;
            DtgList.Columns["Siparisno"].DisplayIndex = 2;
            DtgList.Columns["Unvani"].DisplayIndex = 3;
            DtgList.Columns["Masrafyerno"].DisplayIndex = 4;
            DtgList.Columns["Masrafyeri"].DisplayIndex = 5;
            DtgList.Columns["Proje"].DisplayIndex = 6;
            DtgList.Columns["Baslamatarihi"].DisplayIndex = 7;
            DtgList.Columns["Gidilecekyer"].DisplayIndex = 8;
            DtgList.Columns["Gorevinkonusu"].DisplayIndex = 9;
            DtgList.Columns["Islemadimi"].DisplayIndex = 10;




            sehiriciGorevsTamamlanan = sehirIciGorevManager.GetList();
            sehiriciGorevsTamamlananFiltired = sehiriciGorevsTamamlanan;
            dataBinder2.DataSource = sehiriciGorevsTamamlanan.ToDataTable();
            DtgTamamlanan.DataSource = dataBinder2;

            DtgTamamlanan.Columns["Id"].Visible = false;
            DtgTamamlanan.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgTamamlanan.Columns["Gidilecekyer"].HeaderText = "GİDİLECEK YER";
            DtgTamamlanan.Columns["Gorevinkonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgTamamlanan.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ/SAATİ";
            DtgTamamlanan.Columns["Bitistarihi"].HeaderText = "BİTİŞ TARİHİ/SAATİ";
            DtgTamamlanan.Columns["Toplamsure"].HeaderText = "TOPLAM SÜRE";
            DtgTamamlanan.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgTamamlanan.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgTamamlanan.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgTamamlanan.Columns["Unvani"].DisplayIndex = 11;
            DtgTamamlanan.Columns["Masrafyerno"].HeaderText = "MASRAF YERİ NO";
            DtgTamamlanan.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgTamamlanan.Columns["Proje"].HeaderText = "PROJE";
            DtgTamamlanan.Columns["Islemadimi"].HeaderText = "DURUM";
            DtgTamamlanan.Columns["Gecensure"].Visible = false;
            DtgTamamlanan.Columns["Personelid"].Visible = false;
            DtgTamamlanan.Columns["Sayfa"].Visible = false;
            TopKayit.Text = DtgTamamlanan.RowCount.ToString();
        }

        private void TxtAdSoyad_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtAdSoyad.Text;
            if (string.IsNullOrEmpty(isim))
            {
                sehiriciGorevsFiltired = sehiriciGorevs;
                dataBinder.DataSource = sehiriciGorevs.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtAdSoyad.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = sehiriciGorevsFiltired.Where(x => x.Adsoyad.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            sehiriciGorevsFiltired = sehiriciGorevs;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void TxtAdSoyadTamamlanan_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtAdSoyadTamamlanan.Text;
            if (string.IsNullOrEmpty(isim))
            {
                sehiriciGorevsTamamlananFiltired = sehiriciGorevsTamamlanan;
                dataBinder2.DataSource = sehiriciGorevsTamamlanan.ToDataTable();
                DtgTamamlanan.DataSource = dataBinder2;
                //TxtTop2.Text = DtgTamamlanan.RowCount.ToString();
                return;
            }
            if (TxtAdSoyadTamamlanan.Text.Length < 3)
            {
                return;
            }
            dataBinder2.DataSource = sehiriciGorevsTamamlananFiltired.Where(x => x.Adsoyad.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgTamamlanan.DataSource = dataBinder2;
            sehiriciGorevsTamamlananFiltired = sehiriciGorevsTamamlanan;
            //TxtTop2.Text = DtgTamamlanan.RowCount.ToString();
        }

        private void TxtAkısNo_TextChanged(object sender, EventArgs e)
        {
            int isno = 0;
            if (string.IsNullOrEmpty(TxtAkısNo.Text))
            {
                sehiriciGorevsFiltired = sehiriciGorevs;
                dataBinder.DataSource = sehiriciGorevs.ToDataTable();
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
            dataBinder.DataSource = sehiriciGorevsFiltired.Where(x => x.Isakisno.ToString().Contains(isno.ToString())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            sehiriciGorevsFiltired = sehiriciGorevs;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void TxtIsAkisNoTamamlanan_TextChanged(object sender, EventArgs e)
        {
            int isno = 0;
            if (string.IsNullOrEmpty(TxtIsAkisNoTamamlanan.Text))
            {
                sehiriciGorevsTamamlananFiltired = sehiriciGorevsTamamlanan;
                dataBinder2.DataSource = sehiriciGorevsTamamlanan.ToDataTable();
                DtgTamamlanan.DataSource = dataBinder2;
                //TxtTop2.Text = DtgTamamlanan.RowCount.ToString();
                return;
            }
            if (TxtIsAkisNoTamamlanan.Text.Length < 3)
            {
                return;
            }
            if (!int.TryParse(TxtIsAkisNoTamamlanan.Text, out outValue))
            {
                MessageBox.Show("Rakamsal Değer Giriniz");
                return;
            }
            isno = TxtIsAkisNoTamamlanan.Text.ConInt();
            dataBinder2.DataSource = sehiriciGorevsTamamlananFiltired.Where(x => x.Isakisno.ToString().Contains(isno.ToString())).ToList().ToDataTable();
            DtgTamamlanan.DataSource = dataBinder2;
            sehiriciGorevsTamamlananFiltired = sehiriciGorevsTamamlanan;
            //TxtTop2.Text = DtgTamamlanan.RowCount.ToString();
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

        private void DtgTamamlanan_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Filter = DtgTamamlanan.FilterString;
            TopKayit.Text = DtgTamamlanan.RowCount.ToString();
        }

        private void DtgTamamlanan_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Sort = DtgTamamlanan.SortString;
        }
        string sayfa;
        int id;
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            sayfa = DtgList.CurrentRow.Cells["Sayfa"].Value.ToString();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            IslemAdimlariDisplay();
        }
        void IslemAdimlariDisplay()
        {
            DtgLog.DataSource = logManager.GetList(sayfa, id);
            DtgLog.Columns["Id"].Visible = false;
            DtgLog.Columns["Sayfa"].Visible = false;
            DtgLog.Columns["Benzersizid"].Visible = false;
            DtgLog.Columns["Islem"].HeaderText = "YAPILAN İŞLEM";
            DtgLog.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgLog.Columns["Tarih"].HeaderText = "TARİH";
            /*DtgLog.Columns["Tarih"].Width = 100;
            DtgLog.Columns["Islemyapan"].Width = 135;
            DtgLog.Columns["Islem"].Width = 400;*/
        }
        void IslemAdimlariDisplayTamamlanan()
        {
            DtgLogTamamlanan.DataSource = logManager.GetList(sayfatamamlanan, idtamamlanan);
            DtgLogTamamlanan.Columns["Id"].Visible = false;
            DtgLogTamamlanan.Columns["Sayfa"].Visible = false;
            DtgLogTamamlanan.Columns["Benzersizid"].Visible = false;
            DtgLogTamamlanan.Columns["Islem"].HeaderText = "YAPILAN İŞLEM";
            DtgLogTamamlanan.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgLogTamamlanan.Columns["Tarih"].HeaderText = "TARİH";
            /*DtgLog.Columns["Tarih"].Width = 100;
            DtgLog.Columns["Islemyapan"].Width = 135;
            DtgLog.Columns["Islem"].Width = 400;*/
        }
        
        private void DtgTamamlanan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgTamamlanan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            sayfatamamlanan = DtgTamamlanan.CurrentRow.Cells["Sayfa"].Value.ToString();
            idtamamlanan = DtgTamamlanan.CurrentRow.Cells["Id"].Value.ConInt();
            IslemAdimlariDisplayTamamlanan();
        }
    }
}
