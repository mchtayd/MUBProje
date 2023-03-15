using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
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

namespace UserInterface.IdariIsler
{
    public partial class FrmAracKmIzleme : Form
    {
        AracKmManager aracKmManager;

        List<AracKm> aracKms = new List<AracKm>();
        List<AracKm> aracKmsFiltired = new List<AracKm>();

        string siparisNo = "";
        public FrmAracKmIzleme()
        {
            InitializeComponent();
            aracKmManager = AracKmManager.GetInstance();
        }

        private void FrmAracKmIzleme_Load(object sender, EventArgs e)
        {
            DataDisplay();
            ToplamlarKm();
            ToplamlarSabit();
            ToplamlarFark();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageAracKmIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void Yenilenecekler()
        {
            DataDisplay();
            ToplamlarKm();
            ToplamlarSabit();
            ToplamlarFark();
        }
        public void DataDisplay()
        {
            aracKms = aracKmManager.GetList();
            aracKmsFiltired = aracKms;
            dataBinder.DataSource = aracKms.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();


            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Plaka"].HeaderText = "PLAKA";
            DtgList.Columns["SiparisNo"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Donem"].HeaderText = "DÖNEM";
            DtgList.Columns["Tarih"].HeaderText = "KM BAŞLANGIÇ TARİHİ";
            DtgList.Columns["BaslangicKm"].HeaderText = "BAŞLANGIÇ KM";
            DtgList.Columns["KmBitisTarihi"].HeaderText = "KM BİTİŞ TARİHİ";
            DtgList.Columns["BitisKm"].HeaderText = "BİTİŞ KM";
            DtgList.Columns["ToplamYapilanKm"].HeaderText = "TOPLAM YAPILAN KM";
            DtgList.Columns["SabitKm"].HeaderText = "SABİT KM";
            DtgList.Columns["Fark"].HeaderText = "FARK";


            // KM BİTİŞ TARİHİ
            // BİTİŞ KM
            // TOPLAM YAPILAN KM
            // SABİT KM=3500
            // FARK = YAPILAN KM - 3500


            DtgList.Columns["PersonelAd"].Visible = false;
            DtgList.Columns["PersonelSiparis"].Visible = false;
            DtgList.Columns["PersonelUnvani"].Visible = false;
            DtgList.Columns["PerMasYeriNo"].Visible = false;
            DtgList.Columns["PerMasYeri"].Visible = false;
            DtgList.Columns["PersMasYerSorumlusu"].Visible = false;
            DtgList.Columns["AracMulkiyet"].Visible = false;
            DtgList.Columns["Siparis"].Visible = false;

            foreach (DataGridViewRow item in DtgList.Rows)
            {
                
                if (item.Cells["Siparis"].Value.ToString() != "")
                {
                    item.DefaultCellStyle.BackColor = Color.Red;
                    DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Detay"];
                    c.Text = "DENEME";
                }
            }


            //foreach (AracKm item in aracKms)
            //{
            //    if (item.Siparis!="")
            //    {
            //        DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Detay"];
            //        c.FlatStyle = FlatStyle.Popup;
            //        c.DefaultCellStyle.ForeColor = Color.Red;
            //        c.DefaultCellStyle.BackColor = Color.Red;
            //    }
            //    else
            //    {
            //        DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Detay"];
            //        c.FlatStyle = FlatStyle.Popup;
            //        c.DefaultCellStyle.ForeColor = Color.Red;
            //        c.DefaultCellStyle.BackColor = Color.White;
            //    }
            //}

        }
        void ToplamlarKm()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells["ToplamYapilanKm"].Value);
            }
            TxtKm.Text = toplam.ToString();
        }
        void ToplamlarSabit()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells["SabitKm"].Value);
            }
            LblSabitToplam.Text = toplam.ToString();
        }
        void ToplamlarFark()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells["Fark"].Value);
            }
            LblFark.Text = toplam.ToString();
        }

        private void TxtPlaka_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtPlaka.Text;
            if (string.IsNullOrEmpty(isim))
            {
                aracKmsFiltired = aracKms;
                dataBinder.DataSource = aracKms.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtPlaka.Text.Length < 5)
            {
                return;
            }
            dataBinder.DataSource = aracKmsFiltired.Where(x => x.Plaka.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            aracKmsFiltired = aracKms;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
            ToplamlarKm();
            ToplamlarSabit();
            ToplamlarFark();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void DtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                FrmCokluArac frmCokluKm = new FrmCokluArac();
                frmCokluKm.siparisNo = siparisNo;
                frmCokluKm.ShowDialog();
            }
        }
        int id= 0;
        string plaka = "";
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            siparisNo = DtgList.CurrentRow.Cells["Siparis"].Value.ToString();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            plaka = DtgList.CurrentRow.Cells["Plaka"].Value.ToString();
            foreach (DataGridViewRow item in DtgList.Rows)
            {

                if (item.Cells["Siparis"].Value.ToString() != "")
                {
                    item.DefaultCellStyle.BackColor = Color.Red;
                    DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Detay"];
                    c.Text = "DENEME";
                }
            }

        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen geçerli bir kayıt seçtikten sonra sağ tıklayarak işlem yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmAracKmGuncelle frmAracKmGuncelle = new FrmAracKmGuncelle();
            frmAracKmGuncelle.id=id;
            frmAracKmGuncelle.siparisNo = siparisNo;
            frmAracKmGuncelle.plaka= plaka;
            frmAracKmGuncelle.ShowDialog();
        }
    }
}
