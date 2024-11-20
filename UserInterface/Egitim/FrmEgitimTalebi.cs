using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
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

namespace UserInterface.Egitim
{
    public partial class FrmEgitimTalebi : Form
    {
        BolgeKayitManager bolgeKayitManager;
        public object[] infos;
        public FrmEgitimTalebi()
        {
            InitializeComponent();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
        }

        private void FrmEgitimTalebi_Load(object sender, EventArgs e)
        {
            UsBolgeleri();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageEgitimTalebi"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        void UsBolgeleri()
        {
            if (infos[0].ConInt() == 25 || infos[0].ConInt() == 30 || infos[0].ConInt() == 84 || infos[0].ConInt() == 39 || infos[0].ConInt() == 1140 || infos[0].ConInt() == 1139 || infos[0].ConInt() == 54 || infos[0].ConInt() == 47 || infos[0].ConInt() == 57 || infos[0].ConInt() == 65 || infos[0].ConInt() == 1121)
            {
                CmbBolgeAdi.DataSource = bolgeKayitManager.GetList();
            }
            else
            {
                CmbBolgeAdi.DataSource = bolgeKayitManager.GetList(infos[1].ToString());
            }

            CmbBolgeAdi.ValueMember = "Id";
            CmbBolgeAdi.DisplayMember = "BolgeAdi";
            CmbBolgeAdi.SelectedValue = "";
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtName.Text=="")
            {
                MessageBox.Show("Lütfen öncelikle kursiyer adını yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtRutbe.Text=="")
            {
                MessageBox.Show("Lütfen öncelikle kursiyer rütbesini yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgList.Rows.Add();
            int sonSatir = DtgList.RowCount - 1;
            DtgList.Rows[sonSatir].Cells["Name"].Value = TxtName.Text;
            DtgList.Rows[sonSatir].Cells["Unvan"].Value = TxtRutbe.Text;
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;

        }

        private void DtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgList.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (CmbBolgeAdi.Text=="")
            {
                MessageBox.Show("Lütfen bölge adını seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbEgitimTuru.Text=="")
            {
                MessageBox.Show("Lütfen eğitim türünü seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtKisiSayisi.Text=="")
            {
                MessageBox.Show("Lütfen kişi sayısını belirtiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DtgList.RowCount==0)
            {
                MessageBox.Show("Lütfen kursiyer bilgilerini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DtgList.RowCount!= TxtKisiSayisi.Text.ConInt())
            {
                MessageBox.Show("Belirtilen kursiyer sayısı ile tabloya girilen kursiyer sayısı uyuşmamaktadır!\nGirilen Kursiyer sayısı: " + DtgList.RowCount.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {

            }
        }

        private void TxtKisiSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }
    }
}
