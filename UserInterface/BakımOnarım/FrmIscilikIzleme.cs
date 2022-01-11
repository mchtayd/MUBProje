using Business.Concreate.BakimOnarim;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarim;
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

namespace UserInterface.BakımOnarım
{
    public partial class FrmIscilikIzleme : Form
    {
        PersonelKayitManager personelKayitManager;
        IscilikDesteIscilikManager ıscilikDesteIscilikManager;
        AracZimmetiManager aracZimmetiManager;
        IscilikPerformansManager performansManager;

        List<IscilikDestekTablo> destekTablosPersonel;
        List<IscilikDestekTabloArac> destekTablosArac;
        List<IscilikDestekIscilik> destekIsciliks;
        List<IscilikPerformans> ıscilikPerformans;
        List<AracZimmeti> aracZimmetis;
        string siparisNo = "";
        bool start = false;

        public FrmIscilikIzleme()
        {
            InitializeComponent();
            personelKayitManager = PersonelKayitManager.GetInstance();
            ıscilikDesteIscilikManager = IscilikDesteIscilikManager.GetInstance();
            aracZimmetiManager = AracZimmetiManager.GetInstance();
            performansManager = IscilikPerformansManager.GetInstance();
        }

        private void FrmIscilikIzleme_Load(object sender, EventArgs e)
        {
            Personeller();
            Personeller2();
            Personeller3();
            Plakalar();
            DataDisplayDestekIscilik();
            start = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageIscilikIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void Personeller()
        {
            CmbPersoneller.DataSource = personelKayitManager.PersonelAdSoyad();
            CmbPersoneller.ValueMember = "Id";
            CmbPersoneller.DisplayMember = "Adsoyad";
            CmbPersoneller.SelectedValue = -1;
        }
        void Personeller2()
        {
            CmbPersoneller2.DataSource = personelKayitManager.PersonelAdSoyad();
            CmbPersoneller2.ValueMember = "Id";
            CmbPersoneller2.DisplayMember = "Adsoyad";
            CmbPersoneller2.SelectedValue = -1;
        }
        void Personeller3()
        {
            CmbPersoneller3.DataSource = personelKayitManager.PersonelAdSoyad();
            CmbPersoneller3.ValueMember = "Id";
            CmbPersoneller3.DisplayMember = "Adsoyad";
            CmbPersoneller3.SelectedValue = -1;
        }
        void Plakalar()
        {
            aracZimmetis = aracZimmetiManager.GetList();
            CmbPlaka.DataSource = aracZimmetis;
            CmbPlaka.ValueMember = "Id";
            CmbPlaka.DisplayMember = "Plaka";
            CmbPlaka.SelectedValue = -1;
        }
        void DataDisplayDestekIscilik()
        {
            destekIsciliks = ıscilikDesteIscilikManager.GetList();
            dataBinderDestek.DataSource = destekIsciliks.ToDataTable();
            DtgDestekIscilik.DataSource = dataBinderDestek;
            TxtTopDestek.Text = DtgDestekIscilik.RowCount.ToString();
            DestekIscilikDisplay();


        }
        void DestekIscilikDisplay()
        {
            DtgDestekIscilik.Columns["Id"].Visible = false;
            DtgDestekIscilik.Columns["IscilikTuru"].HeaderText = "İŞÇİLİK TÜRÜ";
            DtgDestekIscilik.Columns["DestekTuru"].HeaderText = "DESTEK TÜRÜ";
            DtgDestekIscilik.Columns["DestekNedeniPersonel"].HeaderText = "DESTEK NEDENİ (PERSONEL)";
            DtgDestekIscilik.Columns["BaslamaTarihiPersonel"].HeaderText = "BAŞLAMA TARİHİ (PERSONEL)";
            DtgDestekIscilik.Columns["BitisTarihiPersonel"].HeaderText = "BİTİŞ TARİHİ (PERSONEL)";
            DtgDestekIscilik.Columns["ToplamSurePersonel"].HeaderText = "TOPLAM SÜRE (PERSONEL)";
            DtgDestekIscilik.Columns["DestekNedeniArac"].HeaderText = "DESTEK NEDENİ (ARAÇ)";
            DtgDestekIscilik.Columns["BaslamaTarihiArac"].HeaderText = "BAŞLAMA TARİHİ (ARAÇ)";
            DtgDestekIscilik.Columns["BitisTarihiArac"].HeaderText = "BİTİŞ TARİHİ (ARAÇ)";
            DtgDestekIscilik.Columns["ToplamSureArac"].HeaderText = "TOPLAM SÜRE (ARAÇ)";
            DtgDestekIscilik.Columns["SiparisNo"].Visible = false;
        }

        private void DtgDestekIscilik_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgDestekIscilik.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DtgDestekIscilikPersonel.DataSource = "";
            DtgDestekIscilikArac.DataSource = "";
            siparisNo = DtgDestekIscilik.CurrentRow.Cells["SiparisNo"].Value.ToString();

            destekTablosPersonel = ıscilikDesteIscilikManager.GetListCellClickPersonel(siparisNo);
            destekTablosArac = ıscilikDesteIscilikManager.GetListCellClickArac(siparisNo);

            if (destekTablosPersonel.Count!=0)
            {
                DestekIscilikPersonelDisplay();
            }
            if (destekTablosArac.Count != 0)
            {
                DestekIscilikAracDisplay();
            }

        }
        void DestekIscilikPersonelDisplay()
        {
            DtgDestekIscilikPersonel.DataSource = destekTablosPersonel;
            LblIscilikPersonel.Text = DtgDestekIscilikPersonel.RowCount.ToString();

            DtgDestekIscilikPersonel.Columns["Id"].Visible = false;
            DtgDestekIscilikPersonel.Columns["AdSoyad"].HeaderText = "ADI SOYADI";
            DtgDestekIscilikPersonel.Columns["Gorevi"].HeaderText = "GÖREVİ";
            DtgDestekIscilikPersonel.Columns["PersonelBolum"].HeaderText = "BÖLÜMÜ";
            DtgDestekIscilikPersonel.Columns["SiparisNo"].Visible = false;


        }
        void DestekIscilikAracDisplay()
        {
            DtgDestekIscilikArac.DataSource = destekTablosArac;

            DtgDestekIscilikArac.Columns["Id"].Visible = false;
            DtgDestekIscilikArac.Columns["Plaka"].HeaderText = "PLAKA";
            DtgDestekIscilikArac.Columns["KullanildigiBolum"].HeaderText = "KULLANILDIĞI BÖLÜM";
            DtgDestekIscilikArac.Columns["SiparisNo"].Visible = false;
        }

        private void CmbPersoneller3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==false)
            {
                return;
            }
            if (CmbPersoneller3.Text!="")
            {
                CmbPlaka.SelectedValue = "";
            }
            string adSoyad = CmbPersoneller3.Text;
            destekIsciliks = ıscilikDesteIscilikManager.GetList(adSoyad);
            dataBinderDestek.DataSource = destekIsciliks.ToDataTable();
            DtgDestekIscilik.DataSource = dataBinderDestek;
            TxtTopDestek.Text = DtgDestekIscilik.RowCount.ToString();
            DestekIscilikDisplay();
        }

        private void CmbPlaka_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (CmbPlaka.Text!="")
            {
                CmbPersoneller3.SelectedValue = "";
            }
            string plaka = CmbPlaka.Text;
            destekIsciliks = ıscilikDesteIscilikManager.GetList("",plaka);
            dataBinderDestek.DataSource = destekIsciliks.ToDataTable();
            DtgDestekIscilik.DataSource = dataBinderDestek;
            TxtTopDestek.Text = DtgDestekIscilik.RowCount.ToString();
            DestekIscilikDisplay();
            
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            CmbPersoneller3.SelectedValue = ""; CmbPlaka.SelectedValue = "";
            DtgDestekIscilikPersonel.DataSource = "";
            DtgDestekIscilikArac.DataSource = "";
            DataDisplayDestekIscilik();
        }

        private void CmbPersoneller2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==false)
            {
                return;
            }

            ıscilikPerformans = performansManager.GetList(CmbPersoneller2.Text);
            if (ıscilikPerformans==null)
            {
                return;
            }

            dataBinderPerformans.DataSource = ıscilikPerformans.ToDataTable();
            DtgPerformans.DataSource = dataBinderPerformans;

            DtgPerformans.Columns["Id"].Visible = false;
            DtgPerformans.Columns["IscilikTuru"].HeaderText = "İŞÇİLİK TÜRÜ";
            DtgPerformans.Columns["Personel"].HeaderText = "PERSONEL";
            DtgPerformans.Columns["MevcutDuragi"].HeaderText = "MEVCUT DURAĞI";
            DtgPerformans.Columns["IstikametDuragi"].HeaderText = "İSTİKAMET DURAĞI";
            DtgPerformans.Columns["CikisTarihiSaati"].HeaderText = "ÇIKIŞ TARİHİ SAATİ";
            DtgPerformans.Columns["CikisDuragi"].HeaderText = "ÇIKIŞ DURAĞI";
            DtgPerformans.Columns["CikisSebebi"].HeaderText = "ÇIKIŞ SEBEBİ";
            DtgPerformans.Columns["VarisDurag"].HeaderText = "VARIŞ DURAĞI";
            DtgPerformans.Columns["VarisTarihiSaat"].HeaderText = "VARIŞ TARİHİ SAATİ";
            DtgPerformans.Columns["Sonuc"].HeaderText = "SONUÇ";

            LblTop.Text = DtgPerformans.RowCount.ToString();
        }

        private void DtgPerformans_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderPerformans.Sort = DtgPerformans.SortString;
        }

        private void DtgPerformans_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderPerformans.Filter = DtgPerformans.FilterString;
            LblTop.Text = DtgPerformans.RowCount.ToString();
        }
    }
}
