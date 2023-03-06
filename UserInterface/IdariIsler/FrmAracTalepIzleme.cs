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
    public partial class FrmAracTalepIzleme : Form
    {
        AracTalepManager aracTalepManager;

        List<AracTalep> aracTaleps;
        List<AracTalep> aracTalepsTamamlananlar;

        string dosyayolu;
        public FrmAracTalepIzleme()
        {
            InitializeComponent();
            aracTalepManager = AracTalepManager.GetInstance();
        }

        private void FrmAracTalepIzleme_Load(object sender, EventArgs e)
        {
            DataDisplayDevamEden();
            DataDisplayTamamlananlar();
        }
        public void Yenilenecekler()
        {
            DataDisplayDevamEden();
            DataDisplayTamamlananlar();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageAracTalepIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void DataDisplayDevamEden()
        {
            aracTaleps = aracTalepManager.GetListDevam("DEVAM EDEN");
            dataBinder.DataSource = aracTaleps.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["GorevEmriNo"].HeaderText = "GÖREV EMRİ NO";
            DtgList.Columns["ButceKoduTanimi"].HeaderText = "BÜTÇE KODU/TANIMI";
            DtgList.Columns["AracTalepNedeni"].HeaderText = "TALEP NEDENİ";
            DtgList.Columns["GidilecekYer"].HeaderText = "GİDİLECEK YER";
            DtgList.Columns["BaslamaTarihiSaati"].HeaderText = "BAŞLAMA TARİHİ/SAATİ";
            DtgList.Columns["BitisTarihiSaati"].Visible = false;
            DtgList.Columns["ToplamSure"].HeaderText = "TOPLAM SÜRE";
            DtgList.Columns["PersonelAd"].HeaderText = "PERSONEL ADI";
            DtgList.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgList.Columns["Unvani"].HeaderText = "UNVANİ";
            DtgList.Columns["PersonelMasYeriNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgList.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgList.Columns["MasrafYeriSorumlusu"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgList.Columns["Plaka"].HeaderText = "PLAKA";
            DtgList.Columns["AracSiparis"].HeaderText = "ARAÇ SİPARİŞ NO";
            DtgList.Columns["CikisKm"].HeaderText = "ÇIKIŞ KM";
            DtgList.Columns["DonusKm"].Visible = false;
            DtgList.Columns["AracZimmetliPersonel"].HeaderText = "ARAÇ ZİMMETLİ PERSONEL";
            DtgList.Columns["DosyaYolu"].Visible = false;
        }
        void DataDisplayTamamlananlar()
        {
            aracTalepsTamamlananlar = aracTalepManager.GetListDevam("TAMAMLANANLAR");
            dataBinderTamamlanan.DataSource = aracTalepsTamamlananlar.ToDataTable();
            DtgListTamamlananlar.DataSource = dataBinderTamamlanan;
            TxtTopTamamlanan.Text = DtgListTamamlananlar.RowCount.ToString();

            DtgListTamamlananlar.Columns["Id"].Visible = false;
            DtgListTamamlananlar.Columns["GorevEmriNo"].HeaderText = "GÖREV EMRİ NO";
            DtgListTamamlananlar.Columns["ButceKoduTanimi"].HeaderText = "BÜTÇE KODU/TANIMI";
            DtgListTamamlananlar.Columns["AracTalepNedeni"].HeaderText = "TALEP NEDENİ";
            DtgListTamamlananlar.Columns["GidilecekYer"].HeaderText = "GİDİLECEK YER";
            DtgListTamamlananlar.Columns["BaslamaTarihiSaati"].HeaderText = "BAŞLAMA TARİHİ/SAATİ";
            DtgListTamamlananlar.Columns["BitisTarihiSaati"].HeaderText = "BİTİŞ TARİHİ/SAATİ";
            DtgListTamamlananlar.Columns["ToplamSure"].HeaderText = "TOPLAM SÜRE";
            DtgListTamamlananlar.Columns["PersonelAd"].HeaderText = "PERSONEL ADI";
            DtgListTamamlananlar.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgListTamamlananlar.Columns["Unvani"].HeaderText = "UNVANİ";
            DtgListTamamlananlar.Columns["PersonelMasYeriNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgListTamamlananlar.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgListTamamlananlar.Columns["MasrafYeriSorumlusu"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgListTamamlananlar.Columns["Plaka"].HeaderText = "PLAKA";
            DtgListTamamlananlar.Columns["AracSiparis"].HeaderText = "ARAÇ SİPARİŞ NO";
            DtgListTamamlananlar.Columns["CikisKm"].HeaderText = "ÇIKIŞ KM";
            DtgListTamamlananlar.Columns["DonusKm"].HeaderText = "DÖNÜŞ KM";
            DtgListTamamlananlar.Columns["AracZimmetliPersonel"].HeaderText = "ARAÇ ZİMMETLİ PERSONEL";
            DtgListTamamlananlar.Columns["DosyaYolu"].Visible = false;
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyayolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            try
            {
                webBrowser1.Navigate(dosyayolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void DtgListTamamlananlar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListTamamlananlar.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyayolu = DtgListTamamlananlar.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            try
            {
                webBrowser2.Navigate(dosyayolu);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
