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
    public partial class FrmUcakOtobusBiletiIzleme : Form
    {
        List<UcakOtobus> ucakotobus;
        UcakOtobusManager ucakOtobusManager;
        IdariIslerLogManager logManager;
        string dosyayolu, sayfa;
        int id;
        public FrmUcakOtobusBiletiIzleme()
        {
            InitializeComponent();
            ucakOtobusManager = UcakOtobusManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }

        private void FrmUcakOtobusBiletiIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageUcakOtobusIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells[24].Value);
            }
            LblGenelTop.Text = toplam.ToString("C2");
        }
        public void DataDisplay()
        {
            ucakotobus = ucakOtobusManager.GetList();
            dataBinder.DataSource = ucakotobus.ToDataTable();
            DtgList.DataSource = dataBinder;
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Talepturu"].HeaderText = "TALEP TÜRÜ";
            DtgList.Columns["Gorevformno"].HeaderText = "GÖREV FORM NO";
            DtgList.Columns["Izinformno"].HeaderText = "İZİN FORM NO";
            DtgList.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgList.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["Masrafyeri"].HeaderText = "BÖLÜMÜ";
            DtgList.Columns["Gorevi"].HeaderText = "GÖREVİ";
            DtgList.Columns["Tc"].HeaderText = "TC KİMLİK NO";
            DtgList.Columns["Hes"].HeaderText = "HES KODU";
            DtgList.Columns["Email"].HeaderText = "E-MAIL";
            DtgList.Columns["Kisakod"].HeaderText = "ŞİRKET NO/KISA KOD";
            DtgList.Columns["Biletturu"].HeaderText = "BİLET TÜRÜ";
            DtgList.Columns["Gidisfirma"].HeaderText = "GİDİŞ FİRMA İSMİ";
            DtgList.Columns["Gidistarihi"].HeaderText = "GİRİŞ TARİHİ/SAATİ";
            DtgList.Columns["Gidisnereden"].HeaderText = "GİDİŞ NEREDEN";
            DtgList.Columns["Gidisnereye"].HeaderText = "GİDİŞ NEREYE";
            DtgList.Columns["Donusfirma"].HeaderText = "DÖNÜŞ FİRMA İSMİ";
            DtgList.Columns["Donustarihi"].HeaderText = "DÖNÜŞ TARİHİ";
            DtgList.Columns["Donusnereden"].HeaderText = "DÖNÜŞ NEREDEN";
            DtgList.Columns["Donusnereye"].HeaderText = "DÖNÜŞ NEREYE";
            DtgList.Columns["Islemadimi"].HeaderText = "İŞLEM ADIMI";
            DtgList.Columns["Butcekodu"].HeaderText = "BÜTÇE KODU/KALEMİ";
            DtgList.Columns["ToplamMaliyet"].HeaderText = "TOPLAM MALİYET";
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;

            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
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

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
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
