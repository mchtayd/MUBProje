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

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmSehirIciGorevlerim : Form
    {

        SehiriciGorevManager sehirIciGorevManager;
        List<SehiriciGorev> sehiriciGorevs;
        public object[] infos;
        public FrmSehirIciGorevlerim()
        {
            InitializeComponent();
            sehirIciGorevManager = SehiriciGorevManager.GetInstance();
        }

        private void FrmSehirIciGorevlerim_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        void DataDisplay()
        {
            sehiriciGorevs = sehirIciGorevManager.SehirIciGorevlerim(infos[1].ToString());
            dataBinder.DataSource = sehiriciGorevs.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Gidilecekyer"].HeaderText = "GİDİLECEK YER";
            DtgList.Columns["Gorevinkonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgList.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgList.Columns["Bitistarihi"].HeaderText = "BİİŞ TARİHİ";
            DtgList.Columns["Toplamsure"].HeaderText = "TOPLAM SÜRE";
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
            DtgList.Columns["Bitistarihi"].DisplayIndex = 8;
            DtgList.Columns["Toplamsure"].DisplayIndex = 9;
            DtgList.Columns["Gidilecekyer"].DisplayIndex = 10;
            DtgList.Columns["Gorevinkonusu"].DisplayIndex = 11;
            DtgList.Columns["Islemadimi"].DisplayIndex = 12;
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
