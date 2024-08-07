﻿using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
using Entity.BakimOnarim;
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

namespace UserInterface.BakımOnarım
{
    public partial class FrmBolgeKayitIzleme : Form
    {
        List<Bolge> bolges = new List<Bolge>();
        List<BolgeKayit> bolgeKayits = new List<BolgeKayit>();
        BolgeManager bolgeManager;
        BolgeKayitManager bolgeKayitManager;
        BolgeGarantiManager bolgeGarantiManager;
        BolgeNotManager bolgeNotManager;
        BolgeEnvanterManager bolgeEnvanterManager;

        int id;
        string siparisNo, dosyaYolu;
        public FrmBolgeKayitIzleme()
        {
            InitializeComponent();
            bolgeManager = BolgeManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            bolgeGarantiManager = BolgeGarantiManager.GetInstance();
            bolgeNotManager = BolgeNotManager.GetInstance();
            bolgeEnvanterManager = BolgeEnvanterManager.GetInstance();
        }

        private void FrmBolgeKayitIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
            
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageBolgeKayitIzleme"]);

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
            bolgeKayits = bolgeKayitManager.GetList();
            dataBinder.DataSource = bolgeKayits.ToDataTable();
            DtgBolgeler.DataSource = dataBinder;
            TxtTop.Text = DtgBolgeler.RowCount.ToString();

            DtgBolgeler.Columns["Id"].Visible = false;
            DtgBolgeler.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgBolgeler.Columns["KodAdi"].HeaderText = "KOD ADI";
            DtgBolgeler.Columns["UsBolgesiStok"].HeaderText = "ÜST BÖLGESİ STOK NO";
            DtgBolgeler.Columns["KabulTarihi"].HeaderText = "KABUL TARİHİ";
            DtgBolgeler.Columns["GuvenlikYazilimi"].HeaderText = "GÜVENLİK YAZILIMI";
            DtgBolgeler.Columns["KesifGozetlemeTuru"].HeaderText = "KEŞİF GÖZETMELE TÜRÜ";
            DtgBolgeler.Columns["YasamAlani"].HeaderText = "YAŞAM ALANI";
            DtgBolgeler.Columns["Tabur"].HeaderText = "BAĞLI OLDUĞU TABUR";
            DtgBolgeler.Columns["Tugay"].HeaderText = "BAĞLI OLDUĞU TUGAY";
            DtgBolgeler.Columns["Il"].HeaderText = "İL";
            DtgBolgeler.Columns["Ilce"].HeaderText = "İLÇE";
            DtgBolgeler.Columns["BirlikAdresi"].HeaderText = "BİRLİK ADRESİ";
            DtgBolgeler.Columns["GarantiBaslama"].HeaderText = "GARANTİ BAŞLAMA TARİHİ";
            DtgBolgeler.Columns["GarantiBitis"].HeaderText = "GARANTİ BİTİŞ TARİHİ";
            DtgBolgeler.Columns["BolgeSorumlusu"].HeaderText = "SEKTÖR SORUMLUSU";
            DtgBolgeler.Columns["Depo"].HeaderText = "BAĞLI OLDUĞU DEPO";
            DtgBolgeler.Columns["SiparisNo"].Visible = false;
            DtgBolgeler.Columns["DosyaYolu"].Visible = false;
            DtgBolgeler.Columns["PypNo"].HeaderText = "PYP NO";
            DtgBolgeler.Columns["Proje"].HeaderText = "PROJE";
            DtgBolgeler.Columns["TepeSorumlusu"].HeaderText = "ÜS BÖLGESİ SORUMLUSU";
            DtgBolgeler.Columns["ProjeSistem"].HeaderText = "PROJE SİSTEM";
            DtgBolgeler.Columns["Musteri"].HeaderText = "MÜŞTERİ";

            DtgBolgeler.Columns["Id"].Visible = false;
            DtgBolgeler.Columns["BolgeAdi"].DisplayIndex = 0;
            DtgBolgeler.Columns["KodAdi"].DisplayIndex = 1;
            DtgBolgeler.Columns["UsBolgesiStok"].DisplayIndex = 2;
            DtgBolgeler.Columns["KabulTarihi"].DisplayIndex = 3;
            DtgBolgeler.Columns["GuvenlikYazilimi"].DisplayIndex = 4;

            DtgBolgeler.Columns["KesifGozetlemeTuru"].DisplayIndex = 5;
            DtgBolgeler.Columns["YasamAlani"].DisplayIndex = 6;
            
            DtgBolgeler.Columns["GarantiBaslama"].DisplayIndex = 7;
            DtgBolgeler.Columns["GarantiBitis"].DisplayIndex = 8;
            DtgBolgeler.Columns["BolgeSorumlusu"].DisplayIndex = 9;
            DtgBolgeler.Columns["Depo"].DisplayIndex = 10;
            DtgBolgeler.Columns["PypNo"].DisplayIndex = 11;
            DtgBolgeler.Columns["Proje"].DisplayIndex = 12;
            DtgBolgeler.Columns["TepeSorumlusu"].DisplayIndex = 13;
            DtgBolgeler.Columns["ProjeSistem"].DisplayIndex = 14;
            DtgBolgeler.Columns["Musteri"].DisplayIndex = 15;

            DtgBolgeler.Columns["Tabur"].DisplayIndex = 16;
            DtgBolgeler.Columns["Tugay"].DisplayIndex = 17;
            DtgBolgeler.Columns["Il"].DisplayIndex = 18;
            DtgBolgeler.Columns["Ilce"].DisplayIndex = 19;
            DtgBolgeler.Columns["BirlikAdresi"].DisplayIndex = 20;
        }

        private void DtgBolgeler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgBolgeler.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            id = DtgBolgeler.CurrentRow.Cells["Id"].Value.ConInt();
            siparisNo = DtgBolgeler.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyaYolu = DtgBolgeler.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            List<BolgeNot> bolgeNots = new List<BolgeNot>();
            bolgeNots = bolgeNotManager.GetList(id);

            DtgList.DataSource = bolgeNots;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["BenzerisizId"].Visible = false;
            DtgList.Columns["Tarih"].HeaderText = "TARİH";
            DtgList.Columns["KayitYapan"].HeaderText = "KAYIT YAPAN";
            DtgList.Columns["Not"].HeaderText = "NOT";

            GarantiPaketleriDisplay(siparisNo);
            FillData();
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }

        }

        void FillData()
        {
            DtgEnvanterList.DataSource = null;
            List<BolgeEnvanter> bolgeEnvanters = new List<BolgeEnvanter>();
            bolgeEnvanters = bolgeEnvanterManager.GetList(id);
            dataBinderEkipman.DataSource = bolgeEnvanters.ToDataTable();
            DtgEnvanterList.DataSource = dataBinderEkipman;
            LblEkipman.Text = DtgEnvanterList.RowCount.ToString();

            DtgEnvanterList.Columns["Id"].Visible = false;
            DtgEnvanterList.Columns["BolgeId"].Visible = false;
            DtgEnvanterList.Columns["Kategori"].HeaderText = "KATEGORİ";
            DtgEnvanterList.Columns["Donanim"].HeaderText = "DONANIM";
            DtgEnvanterList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgEnvanterList.Columns["Tanim"].HeaderText = "TANIM";
            DtgEnvanterList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgEnvanterList.Columns["Birim"].HeaderText = "BİRİM";
            DtgEnvanterList.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgEnvanterList.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgEnvanterList.Columns["Nsn"].HeaderText = "NATO STOK NO";
            DtgEnvanterList.Columns["GuncellemeTarihi"].HeaderText = "SON GÜNCELLEME TARİHİ";
            DtgEnvanterList.Columns["MubBilgisi"].Visible = false;

        }

        private void DtgBolgeler_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgBolgeler.FilterString;
            TxtTop.Text = DtgBolgeler.RowCount.ToString();
        }

        private void DtgBolgeler_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgBolgeler.SortString;
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void DtgEnvanterList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderEkipman.Filter = DtgEnvanterList.FilterString;
            LblEkipman.Text = DtgEnvanterList.RowCount.ToString();

        }

        private void DtgEnvanterList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderEkipman.Sort = DtgEnvanterList.SortString;
        }

        void GarantiPaketleriDisplay(string siparisNo)
        {
            DtgGarantiPaketi.DataSource = bolgeGarantiManager.GetListTumu(siparisNo);

            DtgGarantiPaketi.Columns["Id"].Visible = false;
            DtgGarantiPaketi.Columns["GarantiPaketi"].HeaderText = "GARANTİ PAKETİ";
            DtgGarantiPaketi.Columns["GarantiBaslama"].HeaderText = "GARANTİ BAŞLAMA TARİHİ";
            DtgGarantiPaketi.Columns["GarantiBitis"].HeaderText = "GARANTİ BİTİŞ TARİHİ";
            DtgGarantiPaketi.Columns["ToplamSure"].HeaderText = "TOPLAM SÜRE";
            DtgGarantiPaketi.Columns["SiparisNo"].Visible = false;

        }
    }
}
