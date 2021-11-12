using Business.Concreate.DokumanYonetim;
using DataAccess.Concreate;
using Entity.DokumanYonetim;
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

namespace UserInterface.DokumanYonetim
{
    public partial class FrmDokumanSorgula : Form
    {
        DokumanManager dokumanManager;
        string dosya;
        List<Dokuman> dokumens;
        List<Dokuman> dokumensFiltered;
        string benzersizG;
        public FrmDokumanSorgula()
        {
            InitializeComponent();
            dokumanManager = DokumanManager.GetInstance();
        }

        private void FrmDokumanSorgula_Load(object sender, EventArgs e)
        {
            DtgDoldur();
            //DtgDokumanListesi.DataSource = dokumanManager.GetList();
            
            //timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDokumanSorgula"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        public void DtgDoldur()
        {
            dokumens = dokumanManager.GetList();
            dokumensFiltered = dokumens;
            dataBinder.DataSource = dokumens.ToDataTable();
            DtgDokumanListesi.DataSource = dataBinder;
            //DtgDokumanListesi.DataSource = dokumanManager.GetList();
            DataDisplay();
            TxtTop.Text = DtgDokumanListesi.RowCount.ToString();
        }
        void DataDisplay()
        {
            DtgDokumanListesi.Columns["Id"].Visible = false;
            DtgDokumanListesi.Columns["Tur"].HeaderText = "DOKÜMAN TÜRÜ";
            DtgDokumanListesi.Columns["Numarasi"].HeaderText = "DOKÜMAN NUMARASI";
            DtgDokumanListesi.Columns["Tanimi"].HeaderText = "DOKÜMAN TANIMI";
            DtgDokumanListesi.Columns["Revizyon"].HeaderText = "DOKÜMAN REVİZYONU";
            DtgDokumanListesi.Columns["OnayTarihi"].HeaderText = "DOKÜMAN ONAY TARİHİ";
            DtgDokumanListesi.Columns["YayinTarihi"].HeaderText = "DOKÜMAN YAYIN TARİHİ";
            DtgDokumanListesi.Columns["Benzersiz"].Visible = false;
            DtgDokumanListesi.Columns["Dosyayolu"].Visible = false;
            DtgDokumanListesi.Columns["Tanimi"].Width = 400;
        }

        private void DtgDokumanListesi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgDokumanListesi.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            benzersizG = DtgDokumanListesi.CurrentRow.Cells["Benzersiz"].Value.ToString();
            dokumensFiltered = dokumens.Where(x => x.Benzersiz == benzersizG).ToList();
            if (DtgDokumanListesi.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosya = DtgDokumanListesi.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            WebBrowser1();
        }
        private void WebBrowser1()
        {
            webBrowser1.Navigate(dosya);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string documentNo = TxtDocumentNo.Text;

            if (string.IsNullOrEmpty(documentNo))
            {
                dokumensFiltered = dokumens;
                dataBinder.DataSource = dokumens.ToDataTable();
                DtgDokumanListesi.DataSource = dataBinder;
                return;
            }

            dataBinder.DataSource = dokumensFiltered.Where(x => x.Numarasi.ToLower().Contains(documentNo.ToLower())).ToList().ToDataTable();
            DtgDokumanListesi.DataSource = dataBinder;
            dokumensFiltered = dokumens;
        }

        private void DtgDokumanListesi_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgDokumanListesi.SortString;
        }

        private void DtgDokumanListesi_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgDokumanListesi.FilterString;
            TxtTop.Text = DtgDokumanListesi.RowCount.ToString();
        }

        private void TxtDocumentName_TextChanged(object sender, EventArgs e)
        {
            string documentname = TxtDocumentName.Text;

            if (string.IsNullOrEmpty(documentname))
            {
                dokumensFiltered = dokumens;
                dataBinder.DataSource = dokumens.ToDataTable();
                DtgDokumanListesi.DataSource = dataBinder;
                return;
            }
            dataBinder.DataSource = dokumensFiltered.Where(x => x.Tanimi.ToLower().Contains(documentname.ToLower())).ToList().ToDataTable();
            DtgDokumanListesi.DataSource = dataBinder;
            dokumensFiltered = dokumens;
        }

        private void DtgDokumanListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (DtgDokumanListesi.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            benzersizG = DtgDokumanListesi.CurrentRow.Cells["Benzersiz"].Value.ToString();
            dokumensFiltered = dokumens.Where(x => x.Benzersiz == benzersizG).ToList();
            if (DtgDokumanListesi.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosya = DtgDokumanListesi.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            WebBrowser1();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DtgDoldur();
        }
    }
}
