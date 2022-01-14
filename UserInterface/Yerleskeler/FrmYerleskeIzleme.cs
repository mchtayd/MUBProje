using Business.Concreate.Yerleskeler;
using DataAccess.Concreate;
using Entity.Yerleskeler;
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

namespace UserInterface.Yerleskeler
{
    public partial class FrmYerleskeIzleme : Form
    {
        string siparisNo = "", dosyaYolu;

        KiraManager kiraManager;
        YerleskeManager yerleskeManager;
        List<Kira> kiras = new List<Kira>();
        List<Yerleske> yerleskes = new List<Yerleske>();

        public FrmYerleskeIzleme()
        {
            InitializeComponent();
            kiraManager = KiraManager.GetInstance();
            yerleskeManager = YerleskeManager.GetInstance();
        }

        private void FrmYerleskeIzleme_Load(object sender, EventArgs e)
        {
            DataDisplayYerleskeBilgi();


        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYerleskeIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void DataDisplayYerleskeBilgi()
        {
            kiras = kiraManager.GetList();
            dataBinder.DataSource = kiras.ToDataTable();
            DtgAbonelikler.DataSource = dataBinder;
            TxtTopAbonelikler.Text = DtgAbonelikler.RowCount.ToString();

            DtgAbonelikler.Columns["Id"].Visible = false;
            DtgAbonelikler.Columns["YerleskeAdi"].HeaderText = "YERLEŞKE ADI";
            DtgAbonelikler.Columns["MulkiyetBilgileri"].HeaderText = "MÜLKİYET BİLGİLERİ";
            DtgAbonelikler.Columns["YerleskeAdresi"].HeaderText = "YERLEŞKE ADRESİ";
            DtgAbonelikler.Columns["AdiSoyadi"].HeaderText = "KİRAYA VERENİN ADI SOYADI";
            DtgAbonelikler.Columns["Tc"].HeaderText = "K.V TC";
            DtgAbonelikler.Columns["Ikametgah"].HeaderText = "K.V İKAMETGAH";
            DtgAbonelikler.Columns["Telefon"].HeaderText = "K.V TELEFON";
            DtgAbonelikler.Columns["BankaSubesi"].HeaderText = "K.V BANKA ŞUBESİ";
            DtgAbonelikler.Columns["IbanNo"].HeaderText = "K.V IBAN NO";
            DtgAbonelikler.Columns["KiraBaslangicTarihi"].HeaderText = "KİRA BAŞLANGIÇ TARİHİ";
            DtgAbonelikler.Columns["KiraTutar"].HeaderText = "KİRA TUTARI";
            DtgAbonelikler.Columns["Depozito"].HeaderText = "KİRA DEPOZİTO";
            DtgAbonelikler.Columns["DosyaYolu"].Visible = false;
            DtgAbonelikler.Columns["SiparisNo"].Visible = false;


            

        }
        void DataDisplayAbonelikBilgi()
        {
            yerleskes = yerleskeManager.GetList(siparisNo);
            dataBinder2.DataSource = yerleskes.ToDataTable();
            DtgYerleskeler.DataSource = dataBinder2;
            TxtTop.Text = DtgYerleskeler.RowCount.ToString();

            DtgYerleskeler.Columns["Id"].Visible = false;
            DtgYerleskeler.Columns["YerleskeAdi"].Visible = false;
            DtgYerleskeler.Columns["MulkiyetBilgileri"].Visible = false;
            DtgYerleskeler.Columns["YerleskeAdresi"].Visible = false;
            DtgYerleskeler.Columns["AboneTuru"].HeaderText = "ABONELİK TÜRÜ";
            DtgYerleskeler.Columns["HizmetAlinanKurum"].HeaderText = "HİZMET ALINAN KURUM";
            DtgYerleskeler.Columns["AboneTesisatNo"].HeaderText = "ABONE TESİSAT NO";
            DtgYerleskeler.Columns["AboneTarihi"].HeaderText = "ABONELİK TARİHİ";
            DtgYerleskeler.Columns["AbonelikDurumu"].HeaderText = "ABONELİK DURUMU";
            DtgYerleskeler.Columns["DosyaYolu"].Visible = false;
            DtgYerleskeler.Columns["SiparisNo"].Visible = false;


        }

        private void DtgAbonelikler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgAbonelikler.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            siparisNo = DtgAbonelikler.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosyaYolu = DtgAbonelikler.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            DataDisplayAbonelikBilgi();
            try
            {
                webBrowser2.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void DtgYerleskeler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            
        }
    }
}
