using Business.Concreate.BakimOnarim;
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
    public partial class FrmArizaKayitlarics : Form
    {
        ArizaKayitManager arizaKayitManager;
        List<ArizaKayit> arizaKayits = new List<ArizaKayit>();
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
        void ArizaKayitlari()
        {
            arizaKayits = arizaKayitManager.GetList();
            dataBinder.DataSource = arizaKayits.ToDataTable();
            DtgArizaKayitlari.DataSource = dataBinder;
            TxtTop.Text = DtgArizaKayitlari.RowCount.ToString();

            DtgArizaKayitlari.Columns["Id"].Visible = false;
            DtgArizaKayitlari.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgArizaKayitlari.Columns["AbfFormNo"].HeaderText = "ABF FORM NO";
            DtgArizaKayitlari.Columns["Proje"].HeaderText = "PROJE";
            DtgArizaKayitlari.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgArizaKayitlari.Columns["BolukKomutani"].Visible = false;
            DtgArizaKayitlari.Columns["BirlikAdresi"].Visible = false;
            DtgArizaKayitlari.Columns["Il"].Visible = false;
            DtgArizaKayitlari.Columns["Ilce"].Visible = false;
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

        }
    }
}
