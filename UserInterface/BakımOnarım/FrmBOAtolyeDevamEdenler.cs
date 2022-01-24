using Business.Concreate.BakimOnarimAtolye;
using DataAccess.Concreate;
using Entity.BakimOnarimAtolye;
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
    public partial class FrmBOAtolyeDevamEdenler : Form
    {
        AtolyeManager atolyeManager;
        AtolyeMalzemeManager atolyeMalzemeManager;
        List<Atolye> atolyes;

        string siparisNo;
        int abfNo;
        public FrmBOAtolyeDevamEdenler()
        {
            InitializeComponent();
            atolyeManager = AtolyeManager.GetInstance();
            atolyeMalzemeManager = AtolyeMalzemeManager.GetInstance();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageBODevamEdenler"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        private void FrmBOAtolyeDevamEdenler_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        void DataDisplay()
        {
            atolyes = atolyeManager.GetList();
            dataBinder.DataSource = atolyes.ToDataTable();
            DtgDevamEden.DataSource = dataBinder;

            DtgDevamEden.Columns["Id"].Visible = false;
            DtgDevamEden.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgDevamEden.Columns["StokNoUst"].HeaderText = "STOK NO";
            DtgDevamEden.Columns["TanimUst"].HeaderText = "TANIM";
            DtgDevamEden.Columns["SeriNoUst"].HeaderText = "SERİ NO";
            DtgDevamEden.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgDevamEden.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";
            DtgDevamEden.Columns["CrmNo"].HeaderText = "CRM NO";
            DtgDevamEden.Columns["Kategori"].HeaderText = "KATEGORİ";
            DtgDevamEden.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgDevamEden.Columns["Proje"].HeaderText = "PROJE";
            DtgDevamEden.Columns["BildirilenAriza"].HeaderText = "BİLDİRİLEN ARIZA";
            DtgDevamEden.Columns["IcSiparisNo"].HeaderText = "İÇ SİPARİŞ NO";
            DtgDevamEden.Columns["CekildigiTarih"].HeaderText = "MALZEMENİN ÇEKİLDİĞİ TARİH";
            DtgDevamEden.Columns["SiparisAcmaTarihi"].HeaderText = "SİPARİŞ AÇMA TARİHİ";
            DtgDevamEden.Columns["Modifikasyonlar"].HeaderText = "MODİFİKASYONLAR";
            DtgDevamEden.Columns["Notlar"].HeaderText = "NOTLAR";
            DtgDevamEden.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgDevamEden.Columns["SiparisNo"].Visible = false;

            TxtTop.Text = DtgDevamEden.RowCount.ToString();
        }

        private void DtgDevamEden_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgDevamEden.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            siparisNo = DtgDevamEden.CurrentRow.Cells["SiparisNo"].Value.ToString();
            abfNo = DtgDevamEden.CurrentRow.Cells["AbfNo"].Value.ConInt();
            MalzemeCek();


        }
        void MalzemeCek()
        {
            DtgMalzemeler.DataSource = atolyeMalzemeManager.GetList(abfNo);

            DtgMalzemeler.Columns["Id"].Visible = false;
            DtgMalzemeler.Columns["FormNo"].Visible = false;
            DtgMalzemeler.Columns["StokNo"].HeaderText = "STOK NO";
            DtgMalzemeler.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeler.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgMalzemeler.Columns["Durum"].HeaderText = "DURUM";
            DtgMalzemeler.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgMalzemeler.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzemeler.Columns["TalepTarihi"].HeaderText = "TALEP TARİHİ";
            DtgMalzemeler.Columns["SiparisNo"].Visible = false;

        }
    }
}
