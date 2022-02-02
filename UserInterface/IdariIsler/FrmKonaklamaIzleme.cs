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
    public partial class FrmKonaklamaIzleme : Form
    {
        KonaklamaManager konaklamaManager;
        KonaklamaGecmisManager konaklamaGecmis;
        IdariIslerLogManager logManager;
        List<Konaklama> konaklamas = new List<Konaklama>();
        List<KonaklamaGecmis> konaklamasGecmis = new List<KonaklamaGecmis>();
        string dosyayolu, sayfa;
        int id;
        public FrmKonaklamaIzleme()
        {
            InitializeComponent();
            konaklamaManager = KonaklamaManager.GetInstance();
            konaklamaGecmis = KonaklamaGecmisManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }

        private void FrmKonaklamaIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageKonaklamaIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
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
        public void DataDisplay()
        {
            konaklamas = konaklamaManager.GetList();
            dataBinder.DataSource = konaklamas.ToDataTable();
            DtgList.DataSource = dataBinder;
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Talepturu"].HeaderText = "TALEP TÜRÜ";
            DtgList.Columns["Formno"].HeaderText = "GÖREV FORM NO";
            DtgList.Columns["Butcekodu"].HeaderText = "BÜTÇE KODU/TANIMI";
            DtgList.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgList.Columns["Gorevi"].HeaderText = "GÖREVİ";
            DtgList.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgList.Columns["Tc"].HeaderText = "TC KİMLİK NO";
            DtgList.Columns["Hes"].HeaderText = "HES KODU";
            DtgList.Columns["Email"].HeaderText = "E-MAIL";
            DtgList.Columns["Kisakod"].HeaderText = "ŞİRKET NO/KISA KOD";
            DtgList.Columns["Otelsehir"].HeaderText = "OTELİN BULUNDUĞU ŞEHİR";
            DtgList.Columns["Otelad"].HeaderText = "OTELİN ADI";
            DtgList.Columns["Giristarihi"].HeaderText = "GİRİŞ TARİHİ";
            DtgList.Columns["Cikistarihi"].HeaderText = "ÇIKIŞ TARİHİ";
            DtgList.Columns["Konaklamasuresi"].HeaderText = "KONAKLAMA SÜRESİ";
            DtgList.Columns["Gunukucret"].HeaderText = "GÜNLÜK KONAKLAMA TUTARI";
            DtgList.Columns["Toplamucret"].HeaderText = "TOPLAM KONAKLAMA TUTARI";
            DtgList.Columns["Onay"].HeaderText = "ONAY DURUMU";
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Isakisno"].DisplayIndex = 0;
            DtgList.Columns["Dosyayolu"].Visible = false; 
            DtgList.Columns["Sayfa"].Visible = false;
            DtgList.Columns["SatNo"].Visible = false;
            DtgList.Columns["Donem"].HeaderText = "DÖNEM";
            DtgList.Columns["Gerekce"].HeaderText = "GEREKÇE";
            TxtToplam.Text = DtgList.RowCount.ToString();
            Toplamlar();
        }
        

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtToplam.Text = DtgList.RowCount.ToString();
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
