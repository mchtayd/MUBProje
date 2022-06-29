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
    public partial class FrmIzinlerim : Form
    {
        List<Izin> ızins;
        IzinManager İzinManager;
        public object[] infos;
        public FrmIzinlerim()
        {
            InitializeComponent();
            İzinManager = IzinManager.GetInstance();
        }

        private void FrmIzinlerim_Load(object sender, EventArgs e)
        {
            DtgIzinList();
        }

        public void DtgIzinList()
        {
            ızins = İzinManager.GetListIzinlerim(infos[1].ToString());
            dataBinder.DataSource = ızins.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Izinkategori"].HeaderText = "İZİN KATEGORİ";
            DtgList.Columns["Izinturu"].HeaderText = "İZİN TÜRÜ";
            DtgList.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgList.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["Bolum"].HeaderText = "BÖLÜMÜ";
            DtgList.Columns["Izınnedeni"].HeaderText = "İZİN NEDENİ";
            DtgList.Columns["Bastarihi"].HeaderText = "İZİN BAŞLAMA TARİHİ";
            DtgList.Columns["Bittarihi"].HeaderText = "İZİN BİTİŞ TARİHİ";
            DtgList.Columns["Izindurumu"].HeaderText = "İZİN DURUMU";
            DtgList.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgList.Columns["Toplamsure"].HeaderText = "TOPLAM SÜRE";
            DtgList.Columns["KalanSure"].Visible = false;
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;

            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                string izinsuresi = DtgList.Rows[i].Cells[13].Value.ToString();
                string[] array = izinsuresi.Split(' ');
                toplam += Convert.ToDouble(array[0].ConInt());
            }
            LblGenelTop.Text = toplam.ToString() + " Gün";
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }
    }
}
