using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
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

namespace UserInterface.IdariIsler
{
    public partial class FrmYurtIciGorevlerim : Form
    {
        YurtIciGorevManager yurtIciGorevManager;
        public object[] infos;
        List<YurtIciGorev> yurtIciGorevs;
        int id;
        public FrmYurtIciGorevlerim()
        {
            InitializeComponent();
            yurtIciGorevManager = YurtIciGorevManager.GetInstance();
        }

        private void FrmYurtIciGorevlerim_Load(object sender, EventArgs e)
        {
            DataDisplayTamamlanan();
        }
        void DataDisplayTamamlanan()
        {
            yurtIciGorevs = yurtIciGorevManager.YurtIciGorevlerim(infos[1].ToString());
            dataBinder.DataSource = yurtIciGorevs.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Gorevemrino"].HeaderText = "GÖREV EMRİ NO";
            DtgList.Columns["Gorevinkonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgList.Columns["Proje"].HeaderText = "PROJE";
            DtgList.Columns["Gidilecekyer"].HeaderText = "GİDİLECEK YER";
            DtgList.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgList.Columns["Bitistarihi"].HeaderText = "BİTİŞ TARİHİ";
            DtgList.Columns["Toplamsure"].HeaderText = "TOPLAM SÜRE";
            DtgList.Columns["Butcekodu"].HeaderText = "BÜTÇE KODU";
            DtgList.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgList.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgList.Columns["Ulasimgidis"].HeaderText = "ULAŞIM GİDİŞ";
            DtgList.Columns["Ulasimgorevyeri"].HeaderText = "GÖREV YERİ";
            DtgList.Columns["Ulasimdonus"].HeaderText = "ULAŞIM DÖNÜŞ";
            DtgList.Columns["Konaklamagun"].HeaderText = "KONAKLAMA GÜN";
            DtgList.Columns["Konaklamaguntl"].HeaderText = "KONAKLAMA GÜN/TL";
            DtgList.Columns["Konaklamatoplam"].HeaderText = "KONAKLAMA TOPLAM";
            DtgList.Columns["Kiralamagun"].HeaderText = "ARAÇ KİRALAMA GÜN";
            DtgList.Columns["Kiralamaguntl"].HeaderText = "ARAÇ KİRALAMA GÜN/TL";
            DtgList.Columns["Kiralamayakit"].HeaderText = "ARAÇ KİRALAMA YAKIT";
            DtgList.Columns["Kiralamatoplam"].HeaderText = "ARAÇ KİRALAMA TOPLAM";
            DtgList.Columns["Seyahatavansgun"].HeaderText = "SEYAHAT İŞ AVANSI GÜN";
            DtgList.Columns["Seyahatguntl"].HeaderText = "SEYAHAT İŞ AVANSI GÜN/TL";
            DtgList.Columns["Seyahattoplam"].HeaderText = "SEYAHAT İŞ AVANSI TOPLAM";
            DtgList.Columns["Ucakbileti"].HeaderText = "UÇAK BİLETİ";
            DtgList.Columns["Otobusbileti"].HeaderText = "OTOBÜS BİLETİ";
            DtgList.Columns["Geneltoplam"].HeaderText = "GENEL TOPLAM";
            DtgList.Columns["Plaka"].HeaderText = "PLAKA";
            DtgList.Columns["Cikiskm"].HeaderText = "ÇIKIŞ KİLOMETRESİ";
            DtgList.Columns["Donuskm"].HeaderText = "DÖNÜŞ KİLOMETRESİ";
            DtgList.Columns["Toplamkm"].HeaderText = "TOPLAM KM";
            DtgList.Columns["Geneltoplam"].HeaderText = "GENEL TOPLAM";
            DtgList.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgList.Columns["Islemadimi"].Visible = false;
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["KalanSure"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;
            DtgList.Columns["KonaklamaTuru"].Visible = false;
            DtgList.Columns["HarcirahGun"].Visible = false;
            DtgList.Columns["HarcirahGunTl"].Visible = false;
            DtgList.Columns["HarcirahToplam"].Visible = false;
            DtgList.Columns["IaseGun"].Visible = false;
            DtgList.Columns["IaseGunTl"].Visible = false;
            DtgList.Columns["IaseToplam"].Visible = false;
            DtgList.Columns["OnayDurum"].HeaderText = "ONAY DURUM";
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
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            string dosyaYolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }

        }
    }
}
