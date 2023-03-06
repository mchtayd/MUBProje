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

namespace UserInterface.IdariIsler
{
    public partial class FrmYurtIciGorevlerim : Form
    {
        YurtIciGorevManager yurtIciGorevManager;
        public object[] infos;
        List<YurtIciGorev> yurtIciGorevs;
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
            DtgList.Columns["Konaklamagun"].Visible = false;
            DtgList.Columns["Konaklamaguntl"].Visible = false;
            DtgList.Columns["Konaklamatoplam"].Visible = false;
            DtgList.Columns["Kiralamagun"].Visible = false;
            DtgList.Columns["Kiralamaguntl"].Visible = false;
            DtgList.Columns["Kiralamayakit"].Visible = false;
            DtgList.Columns["Kiralamatoplam"].Visible = false;
            DtgList.Columns["Seyahatavansgun"].Visible = false;
            DtgList.Columns["Seyahatguntl"].Visible = false;
            DtgList.Columns["Seyahattoplam"].Visible = false;
            DtgList.Columns["Ucakbileti"].Visible = false;
            DtgList.Columns["Otobusbileti"].Visible = false;
            DtgList.Columns["Geneltoplam"].Visible = false;
            DtgList.Columns["Plaka"].HeaderText = "PLAKA";
            DtgList.Columns["Cikiskm"].HeaderText = "ÇIKIŞ KİLOMETRESİ";
            DtgList.Columns["Donuskm"].HeaderText = "DÖNÜŞ KİLOMETRESİ";
            DtgList.Columns["Toplamkm"].HeaderText = "TOPLAM KİLOMETRE";
            DtgList.Columns["Geneltoplam"].HeaderText = "GENEL TOPLAM";
            DtgList.Columns["Islemadimi"].Visible = false;
            DtgList.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgList.Columns["KonaklamaTuru"].HeaderText = "KONAKLAMA TÜRÜ";
            DtgList.Columns["KonaklamaTuru"].DisplayIndex = 20;
            DtgList.Columns["Unvani"].DisplayIndex = 13;
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["KalanSure"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;
            DtgList.Columns["HarcirahGun"].Visible = false;
            DtgList.Columns["HarcirahGunTl"].Visible = false;
            DtgList.Columns["HarcirahToplam"].Visible = false;
            DtgList.Columns["IaseGun"].Visible = false;
            DtgList.Columns["IaseGunTl"].Visible = false;
            DtgList.Columns["IaseToplam"].Visible = false;
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
    }
}
