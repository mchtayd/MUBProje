using Business.Concreate.Yerleskeler;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Presentation;
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
    public partial class FrmYerleskeGiderKayitIzleme : Form
    {
        KiraManager kiraManager;
        YerleskeSatManager yerleskeManager;

        List<Kira> kiras;
        List<YerleskeSat> yerleskeSats;

        string siparisNo, yerleskeAdi;
        public FrmYerleskeGiderKayitIzleme()
        {
            InitializeComponent();
            kiraManager = KiraManager.GetInstance();
            yerleskeManager = YerleskeSatManager.GetInstance();
        }

        private void FrmYerleskeGiderKayitIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageGiderKayitIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void DataDisplay()
        {
            kiras = kiraManager.GetList();
            dataBinder.DataSource = kiras.ToDataTable();
            DtgYerkeskeler.DataSource = dataBinder;

            DtgYerkeskeler.Columns["Id"].Visible = false;
            DtgYerkeskeler.Columns["YerleskeAdi"].HeaderText = "YERLEŞKE ADI";
            DtgYerkeskeler.Columns["YerleskeAdresi"].HeaderText = "YERLEŞKE ADRESİ";
            DtgYerkeskeler.Columns["MulkiyetBilgileri"].HeaderText = "MÜLKİYET BİLGİLERİ";
            DtgYerkeskeler.Columns["AdiSoyadi"].HeaderText = "K.V ADI SOYADI";
            DtgYerkeskeler.Columns["Tc"].Visible = false;
            DtgYerkeskeler.Columns["Ikametgah"].Visible = false;
            DtgYerkeskeler.Columns["Telefon"].HeaderText = "K.V TELEFON";
            DtgYerkeskeler.Columns["BankaSubesi"].HeaderText = "K.V BANKA ŞUBESİ";
            DtgYerkeskeler.Columns["IbanNo"].HeaderText = "K.V IBAN";
            DtgYerkeskeler.Columns["KiraBaslangicTarihi"].Visible = false;
            DtgYerkeskeler.Columns["KiraTutar"].Visible = false;
            DtgYerkeskeler.Columns["Depozito"].Visible = false;
            DtgYerkeskeler.Columns["DosyaYolu"].Visible = false;
            DtgYerkeskeler.Columns["SiparisNo"].Visible = false;
        }

        private void DtgYerkeskeler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgYerkeskeler.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            yerleskeSats = new List<YerleskeSat>();
            DtgYerleskeSat.Rows.Clear();
            siparisNo = DtgYerkeskeler.CurrentRow.Cells["SiparisNo"].Value.ToString();
            yerleskeAdi = DtgYerkeskeler.CurrentRow.Cells["YerleskeAdi"].Value.ToString();

            yerleskeSats = yerleskeManager.GetList(yerleskeAdi);

            foreach (YerleskeSat item in yerleskeSats)
            {
                DtgYerleskeSat.Rows.Add();
                int sonSatir = DtgYerleskeSat.RowCount - 1;
                DtgYerleskeSat.Rows[sonSatir].Cells["GiderTuru"].Value = item.GiderTuru;
                DtgYerleskeSat.Rows[sonSatir].Cells["Donem"].Value = item.Donem;
                DtgYerleskeSat.Rows[sonSatir].Cells["Tutar"].Value = item.Tutar;
            }
            Toplamlar();
            LblToplamKayit.Text = DtgYerleskeSat.RowCount.ToString();
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgYerleskeSat.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgYerleskeSat.Rows[i].Cells["Tutar"].Value);
            }
            LblTop.Text = toplam.ToString("C2");
        }
    }
}
