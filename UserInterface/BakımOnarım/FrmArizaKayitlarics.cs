using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Presentation;
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
    public partial class FrmArizaKayitlarics : Form
    {
        ArizaKayitManager arizaKayitManager;
        List<ArizaKayit> arizaKayits = new List<ArizaKayit>();

        string dosyaYolu;
        public FrmArizaKayitlarics()
        {
            InitializeComponent();
            arizaKayitManager = ArizaKayitManager.GetInstance();
        }

        private void FrmArizaKayitlarics_Load(object sender, EventArgs e)
        {
            ArizaKayitlari();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageArizaKayitlari"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void ArizaKayitlari()
        {
            arizaKayits = arizaKayitManager.GetList();
            dataBinder.DataSource = arizaKayits.ToDataTable();
            DtgArizaKayitlari.DataSource = dataBinder;
            TxtTop.Text = DtgArizaKayitlari.RowCount.ToString();

            DtgArizaKayitlari.Columns["Id"].Visible = false;
            DtgArizaKayitlari.Columns["IsAkisNo"].Visible = false;
            DtgArizaKayitlari.Columns["AbfFormNo"].HeaderText = "ABF FORM NO";
            DtgArizaKayitlari.Columns["Proje"].HeaderText = "PROJE";
            DtgArizaKayitlari.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgArizaKayitlari.Columns["BolukKomutani"].Visible = false;
            DtgArizaKayitlari.Columns["BirlikAdresi"].Visible = false;
            DtgArizaKayitlari.Columns["Il"].HeaderText = "İL";
            DtgArizaKayitlari.Columns["Ilce"].HeaderText = "İLÇE";
            DtgArizaKayitlari.Columns["BildirilenAriza"].HeaderText = "BİLDİRİLEN ARIZA";
            DtgArizaKayitlari.Columns["ArizaiBildirenPersonel"].HeaderText = "ARIZAYI BİLDİREN BİRLİK PERSONELİ";
            DtgArizaKayitlari.Columns["AbRutbesi"].HeaderText = "ARIZAYI BİLDİREN RÜTBESİ";
            DtgArizaKayitlari.Columns["AbGorevi"].HeaderText = "ARIZAYI BİLDİREN GÖREVİ";
            DtgArizaKayitlari.Columns["AbTelefon"].HeaderText = "ARIZAYI BİLDİREN TELEFON";
            DtgArizaKayitlari.Columns["AbTarihSaat"].HeaderText = "ARIZA BİLDİRİM TARİHİ/SAATİ";
            DtgArizaKayitlari.Columns["ABAlanPersonel"].HeaderText = "ARIZA BİLDİRİMİNİ ALAN PERSONEL";
            DtgArizaKayitlari.Columns["BildirimKanali"].HeaderText = "BİLDİRİM KANALI";
            DtgArizaKayitlari.Columns["ArizaAciklama"].HeaderText = "ARIZA AÇIKLAMA";
            DtgArizaKayitlari.Columns["GorevAtanacakPersonel"].HeaderText = "GÖREV ATANAN PERSONEL";
            DtgArizaKayitlari.Columns["IslemAdimi"].HeaderText = "İŞLEM ADIMI";
            DtgArizaKayitlari.Columns["DosyaYolu"].Visible = false;
            DtgArizaKayitlari.Columns["SiparisTuru"].Visible = false;
            DtgArizaKayitlari.Columns["SiparisNo"].Visible = false;
            DtgArizaKayitlari.Columns["GarantiDurumu"].Visible = false;
            DtgArizaKayitlari.Columns["LojistikSorumluPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["LojRutbesi"].Visible = false;
            DtgArizaKayitlari.Columns["LojGorevi"].Visible = false;
            DtgArizaKayitlari.Columns["LojTarihi"].Visible = false;
            DtgArizaKayitlari.Columns["LojTarihi"].Visible = false;
            DtgArizaKayitlari.Columns["TespitEdilenAriza"].Visible = false;
            DtgArizaKayitlari.Columns["AcmaOnayiVeren"].Visible = false;
            DtgArizaKayitlari.Columns["CsSiparisNo"].Visible = false;
            DtgArizaKayitlari.Columns["BildirimNo"].Visible = false;
            DtgArizaKayitlari.Columns["CrmNo"].Visible = false;
            DtgArizaKayitlari.Columns["SiparisNo"].Visible = false;
            DtgArizaKayitlari.Columns["TelefonNo"].Visible = false;
            DtgArizaKayitlari.Columns["StokNo"].Visible = false;
            DtgArizaKayitlari.Columns["Tanim"].Visible = false;
            DtgArizaKayitlari.Columns["SeriNo"].Visible = false;
            DtgArizaKayitlari.Columns["IlgiliFirma"].Visible = false;
            DtgArizaKayitlari.Columns["BildirimTuru"].Visible = false;
            DtgArizaKayitlari.Columns["PypNo"].Visible = false;
            DtgArizaKayitlari.Columns["SorumluPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["IslemTuru"].Visible = false;
            DtgArizaKayitlari.Columns["Hesaplama"].Visible = false;
            DtgArizaKayitlari.Columns["BildirimMailTarihi"].Visible = false;
            DtgArizaKayitlari.Columns["Kategori"].Visible = false;
            DtgArizaKayitlari.Columns["IlgiliFirma"].Visible = false;
            DtgArizaKayitlari.Columns["BildirimTuru"].HeaderText = "BİLDİRİM TÜRÜ";
            DtgArizaKayitlari.Columns["PypNo"].Visible = false;
            DtgArizaKayitlari.Columns["SorumluPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["IslemTuru"].Visible = false;
            DtgArizaKayitlari.Columns["Hesaplama"].Visible = false;
            DtgArizaKayitlari.Columns["Durum"].Visible = false;
            DtgArizaKayitlari.Columns["OnarimNotu"].Visible = false;
            DtgArizaKayitlari.Columns["TeslimEdenPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["TeslimAlanPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["TeslimTarihi"].Visible = false;
            DtgArizaKayitlari.Columns["NesneTanimi"].Visible = false;
            DtgArizaKayitlari.Columns["HasarKodu"].Visible = false;
            DtgArizaKayitlari.Columns["NedenKodu"].Visible = false;
            DtgArizaKayitlari.Columns["EksikEvrak"].Visible = false;
            DtgArizaKayitlari.Columns["EkipmanNo"].Visible = false;
            DtgArizaKayitlari.Columns["GecenSure"].HeaderText = "GEÇEN SÜRE";
            DtgArizaKayitlari.Columns["MalzemeDurum"].Visible = false;

            DtgArizaKayitlari.Columns["BildirimTuru"].DisplayIndex = 0;
            DtgArizaKayitlari.Columns["GecenSure"].DisplayIndex = 1;
            DtgArizaKayitlari.Columns["AbfFormNo"].DisplayIndex = 2;
            DtgArizaKayitlari.Columns["IsAkisNo"].DisplayIndex=3;
            DtgArizaKayitlari.Columns["BildirimNo"].DisplayIndex = 4;
            DtgArizaKayitlari.Columns["Kategori"].DisplayIndex = 5;
            DtgArizaKayitlari.Columns["BolgeAdi"].DisplayIndex = 6;
            DtgArizaKayitlari.Columns["Il"].DisplayIndex = 7;
            DtgArizaKayitlari.Columns["Ilce"].DisplayIndex = 8;
            DtgArizaKayitlari.Columns["IslemAdimi"].DisplayIndex = 9;
            DtgArizaKayitlari.Columns["Proje"].DisplayIndex = 10;
            DtgArizaKayitlari.Columns["StokNo"].DisplayIndex = 11;
            DtgArizaKayitlari.Columns["Tanim"].DisplayIndex = 12;
            DtgArizaKayitlari.Columns["SeriNo"].DisplayIndex = 13;
            DtgArizaKayitlari.Columns["GorevAtanacakPersonel"].DisplayIndex = 14;
            DtgArizaKayitlari.Columns["TespitEdilenAriza"].DisplayIndex = 15;
            DtgArizaKayitlari.Columns["GarantiDurumu"].DisplayIndex = 16;
            DtgArizaKayitlari.Columns["IlgiliFirma"].DisplayIndex = 17;
            DtgArizaKayitlari.Columns["BildirimMailTarihi"].DisplayIndex = 18;
            DtgArizaKayitlari.Columns["BildirilenAriza"].DisplayIndex = 19;
            DtgArizaKayitlari.Columns["ArizaiBildirenPersonel"].DisplayIndex = 20;
            DtgArizaKayitlari.Columns["AbRutbesi"].DisplayIndex = 21;
            DtgArizaKayitlari.Columns["AbGorevi"].DisplayIndex = 22;
            DtgArizaKayitlari.Columns["AbTelefon"].DisplayIndex = 23;
            DtgArizaKayitlari.Columns["AbTarihSaat"].DisplayIndex = 24;
            DtgArizaKayitlari.Columns["ABAlanPersonel"].DisplayIndex = 25;
            DtgArizaKayitlari.Columns["BildirimKanali"].DisplayIndex = 26;
            DtgArizaKayitlari.Columns["LojistikSorumluPersonel"].DisplayIndex = 27;
            DtgArizaKayitlari.Columns["LojRutbesi"].DisplayIndex = 28;
            DtgArizaKayitlari.Columns["LojGorevi"].DisplayIndex = 29;
            DtgArizaKayitlari.Columns["LojTarihi"].DisplayIndex = 30;
            DtgArizaKayitlari.Columns["AcmaOnayiVeren"].DisplayIndex = 31;
            DtgArizaKayitlari.Columns["PypNo"].DisplayIndex = 32;
            DtgArizaKayitlari.Columns["MalzemeDurum"].DisplayIndex = 33;


        }

        private void DtgArizaKayitlari_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgArizaKayitlari.FilterString;
        }

        private void DtgArizaKayitlari_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgArizaKayitlari.SortString;
        }

        private void DtgArizaKayitlari_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgArizaKayitlari.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyaYolu = DtgArizaKayitlari.CurrentRow.Cells["DosyaYolu"].Value.ToString();
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
