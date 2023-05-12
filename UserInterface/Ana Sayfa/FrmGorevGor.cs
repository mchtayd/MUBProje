using Business.Concreate.IdarıIsler;
using DocumentFormat.OpenXml.Office.CoverPageProps;
using DocumentFormat.OpenXml.Presentation;
using Entity;
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
    public partial class FrmGorevGor : Form
    {
        IzinManager ızinManager;
        public string gorevAdi, departman = "";
        public int benzersizId = 0;

        public FrmGorevGor()
        {
            InitializeComponent();
            ızinManager = IzinManager.GetInstance();
        }

        private void FrmGorevGor_Load(object sender, EventArgs e)
        {
            LblGorevAdi.Text= gorevAdi;
            LblDepartman.Text= departman;
            Gorev();
        }

        void Gorev()
        {
            if (LblDepartman.Text == "İZİN")
            {
                Izin ızin = ızinManager.GetId(benzersizId);
                List<Izin> ızins = new List<Izin>();
                ızins.Add(ızin);

                DtgDevamEden.DataSource = ızins;
                DtgDevamEden.Columns["Id"].Visible = false;
                DtgDevamEden.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
                DtgDevamEden.Columns["Izinkategori"].HeaderText = "İZİN KATEGORİ";
                DtgDevamEden.Columns["Izinturu"].HeaderText = "İZİN TÜRÜ";
                DtgDevamEden.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
                DtgDevamEden.Columns["Adsoyad"].HeaderText = "AD SOYAD";
                DtgDevamEden.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
                DtgDevamEden.Columns["Bolum"].HeaderText = "BÖLÜMÜ";
                DtgDevamEden.Columns["Izınnedeni"].HeaderText = "İZİN NEDENİ";
                DtgDevamEden.Columns["Bastarihi"].HeaderText = "İZİN BAŞLAMA TARİHİ";
                DtgDevamEden.Columns["Bittarihi"].HeaderText = "İZİN BİTİŞ TARİHİ";
                DtgDevamEden.Columns["Izindurumu"].HeaderText = "İZİN DURUMU";
                DtgDevamEden.Columns["Unvani"].HeaderText = "ÜNVANI";
                DtgDevamEden.Columns["Toplamsure"].HeaderText = "TOPLAM SÜRE";
                DtgDevamEden.Columns["KalanSure"].Visible = false;
                DtgDevamEden.Columns["Dosyayolu"].Visible = false;
                DtgDevamEden.Columns["Sayfa"].Visible = false;
                DtgDevamEden.Columns["Siparis"].Visible = false;
                DtgDevamEden.Columns["OnayDurum"].HeaderText = "ONAY DURUMU";
                DtgDevamEden.Columns["Siparis"].Visible = false;
            }
        }
    }
}
