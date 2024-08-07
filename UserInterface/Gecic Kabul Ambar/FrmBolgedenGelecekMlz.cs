﻿using Business.Concreate.BakimOnarim;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Presentation;
using Entity.BakimOnarim;
using Entity.Gecic_Kabul_Ambar;
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

namespace UserInterface.Gecic_Kabul_Ambar
{
    
    public partial class FrmBolgedenGelecekMlz : Form
    {

        AbfMalzemeManager abfMalzemeManager;

        List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
        public object[] infos;
        public FrmBolgedenGelecekMlz()
        {
            InitializeComponent();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
        }

        private void FrmBolgedenGelecekMlz_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageGelecekMalzeme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        void DataDisplay()
        {
            abfMalzemes = abfMalzemeManager.DepoyaTeslimEdilecekMalzemeList("TÜMÜ");
            dataBinder.DataSource = abfMalzemes.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["BenzersizId"].Visible = false;
            DtgList.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgList.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgList.Columns["SokulenSeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgList.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgList.Columns["SokulenCalismaSaati"].Visible = false;
            DtgList.Columns["SokulenRevizyon"].HeaderText = "REVİZYON";
            DtgList.Columns["CalismaDurumu"].Visible = false;
            DtgList.Columns["FizikselDurum"].Visible = false;
            DtgList.Columns["TakilanStokNo"].Visible = false;
            //DtgList.Columns["Malzemekul"].HeaderText = "MALZEMENİN KULLANILDIĞI ÜST TAKIM STOK NO";
            DtgList.Columns["TakilanTanim"].Visible = false;
            DtgList.Columns["TakilanSeriNo"].Visible = false;
            DtgList.Columns["TakilanMiktar"].Visible = false;
            DtgList.Columns["TakilanBirim"].Visible = false;
            DtgList.Columns["TakilanCalismaSaati"].Visible = false;
            DtgList.Columns["TakilanRevizyon"].Visible = false;
            DtgList.Columns["TeminDurumu"].Visible = false;
            DtgList.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgList.Columns["AbTarihSaat"].Visible = false;
            DtgList.Columns["TemineAtilamTarihi"].Visible = false;
            DtgList.Columns["MalzemeDurumu"].Visible = false;
            DtgList.Columns["MalzemeIslemAdimi"].Visible = false;
            DtgList.Columns["SokulenTeslimDurum"].HeaderText = "MALZEME TESLİM DURUMU";
            DtgList.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgList.Columns["BolgeSorumlusu"].HeaderText = "BÖLGE SORUMLUSU";
            DtgList.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgList.Columns["YerineMalzemeTakilma"].HeaderText = "YERİNE MALZEME TAKILDI MI?";


            DtgList.Columns["AbfNo"].DisplayIndex = 0;
            DtgList.Columns["SokulenStokNo"].DisplayIndex = 1;
            DtgList.Columns["SokulenTanim"].DisplayIndex = 2;
            DtgList.Columns["SokulenSeriNo"].DisplayIndex = 3;
            DtgList.Columns["SokulenMiktar"].DisplayIndex = 4;
            DtgList.Columns["SokulenBirim"].DisplayIndex = 5;
            DtgList.Columns["SokulenRevizyon"].DisplayIndex = 6;
            DtgList.Columns["BolgeAdi"].DisplayIndex = 7;
            DtgList.Columns["BolgeSorumlusu"].DisplayIndex = 8;
            DtgList.Columns["SokulenTeslimDurum"].DisplayIndex = 9;
            DtgList.Columns["YapilacakIslem"].DisplayIndex = 10;

            TxtTop.Text= DtgList.RowCount.ToString();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort= DtgList.SortString;
        }
    }
}
