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

namespace UserInterface.BakımOnarım
{
    public partial class FrmPyp : Form
    {
        PypManager pypManager;
        List<Pyp> pyps = new List<Pyp>();
        int id;
        public FrmPyp()
        {
            InitializeComponent();
            pypManager = PypManager.GetInstance();
        }

        private void FrmPyp_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        void DataDisplay()
        {
            pyps = pypManager.GetList();
            dataBinder.DataSource = pyps.ToDataTable();
            DtgPYP.DataSource = dataBinder;
            TxtTop.Text = DtgPYP.RowCount.ToString();

            DtgPYP.Columns["Id"].Visible = false;
            DtgPYP.Columns["PypNo"].HeaderText = "PYP NO";
            DtgPYP.Columns["SorumluPersonel"].HeaderText = "SORUMLU PERSONEL";
            DtgPYP.Columns["SiparisTuru"].HeaderText = "SİPARİŞ TÜRÜ";
            DtgPYP.Columns["IslemTuru"].HeaderText = "İŞLEM TÜRÜ";
            DtgPYP.Columns["HesaplamaNedeni"].HeaderText = "HESAPLAMA NEDENİ";
        }

        private void DtgPYP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DtgPYP.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            id = DtgPYP.CurrentRow.Cells["Id"].Value.ConInt();
            TxtPypNo.Text = DtgPYP.CurrentRow.Cells["PypNo"].Value.ToString();
            TxtSorumluPersonel.Text= DtgPYP.CurrentRow.Cells["SorumluPersonel"].Value.ToString();
            CmbSiparisTuru.Text= DtgPYP.CurrentRow.Cells["SiparisTuru"].Value.ToString();
            CmbIslemTuru.Text = DtgPYP.CurrentRow.Cells["IslemTuru"].Value.ToString();
            CmbHesaplamaNedeni.Text= DtgPYP.CurrentRow.Cells["HesaplamaNedeni"].Value.ToString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        void Temizle()
        {
            TxtPypNo.Clear(); TxtSorumluPersonel.Clear(); CmbSiparisTuru.Text = ""; CmbIslemTuru.Text = ""; CmbHesaplamaNedeni.Text = "";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr ==DialogResult.Yes)
            {
                Pyp pyp = new Pyp(TxtPypNo.Text, TxtSorumluPersonel.Text, CmbSiparisTuru.Text, CmbIslemTuru.Text, CmbHesaplamaNedeni.Text);
                string mesaj = pypManager.Add(pyp);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                DataDisplay();
                Temizle();
                FrmBolgeler frmBolgeler = new FrmBolgeler();
                frmBolgeler.ComboPypNo();

            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Pyp pyp = new Pyp(id,TxtPypNo.Text, TxtSorumluPersonel.Text, CmbSiparisTuru.Text, CmbIslemTuru.Text, CmbHesaplamaNedeni.Text);
                string mesaj = pypManager.Update(pyp);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataDisplay();
                Temizle();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = pypManager.Delete(id);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Silme İşlemi Başarıyla Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataDisplay();
                Temizle();
            }
        }
    }
}
