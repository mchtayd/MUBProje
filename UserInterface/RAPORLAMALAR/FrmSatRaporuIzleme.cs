using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity.STS;
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

namespace UserInterface.RAPORLAMALAR
{
    public partial class FrmSatRaporuIzleme : Form
    {
        SatRaporLogManager satRaporLogManager;
        List<SatRaporLog> satRaporLogs;
        string dosyayolu;
        public FrmSatRaporuIzleme()
        {
            InitializeComponent();
            satRaporLogManager = SatRaporLogManager.GetInstance();
        }

        private void FrmSatRaporuIzleme_Load(object sender, EventArgs e)
        {
            SatRaporu();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatRaporuIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void SatRaporu()
        {
            satRaporLogs = satRaporLogManager.GetList();
            dataBinder.DataSource = satRaporLogs.ToDataTable();
            DtgRaporList.DataSource = dataBinder;
            TxtTop.Text = DtgRaporList.RowCount.ToString();
            Toplamlar();
            DataDisplay();
        }
        void DataDisplay()
        {
            DtgRaporList.Columns["Id"].Visible = false;
            DtgRaporList.Columns["FirmaBilgisi"].HeaderText = "FİRMA BİLGİSİ";
            DtgRaporList.Columns["Donem"].HeaderText = "DÖNEM";
            DtgRaporList.Columns["Yil"].HeaderText = "YIL";
            DtgRaporList.Columns["IslemYapan"].HeaderText = "YIL";
            DtgRaporList.Columns["DosyaYolu"].Visible = false;
            DtgRaporList.Columns["Tarih"].HeaderText = "TARİH";
            DtgRaporList.Columns["ToplamTutar"].HeaderText = "TOPLAM_TUTAR";
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgRaporList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgRaporList.Rows[i].Cells[7].Value);
            }
            ToplamTutar.Text = toplam.ToString("C2");
        }
        private void DtgRaporList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgRaporList.FilterString;
            TxtTop.Text = DtgRaporList.RowCount.ToString();
            Toplamlar();
        }

        private void DtgRaporList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgRaporList.SortString;
        }

        private void DtgRaporList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgRaporList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyayolu = DtgRaporList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            webBrowser2.Navigate(dosyayolu);
        }
    }
}
