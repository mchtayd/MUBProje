using Business;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.BakımOnarım;
using UserInterface.Gecic_Kabul_Ambar;
using UserInterface.IdariIsler;
using UserInterface.STS;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmUstTakim : Form
    {
        ComboManager comboManager;
        UstTakimManager ustTakimManager;

        List<UstTakim> ustTakims = new List<UstTakim>();

        int id;
        public FrmUstTakim()
        {
            InitializeComponent();
            comboManager = ComboManager.GetInstance();
            ustTakimManager = UstTakimManager.GetInstance();
        }

        private void FrmUstTakim_Load(object sender, EventArgs e)
        {
            IlgiliFirma();
            DataDisplay();
        }
        void IlgiliFirma()
        {
            CmbIlgiliFirma.DataSource = comboManager.GetList("ONARIM_YERI");
            CmbIlgiliFirma.ValueMember = "Id";
            CmbIlgiliFirma.DisplayMember = "Baslik";
            CmbIlgiliFirma.SelectedValue = 0;
        }
        void DataDisplay()
        {
            ustTakims = ustTakimManager.GetList();
            dataBinder.DataSource = ustTakims.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["IlgiliFirma"].HeaderText = "İLGİLİ FİRMA";

            TxtTop.Text = DtgList.RowCount.ToString();
        }
        string Control()
        {
            if (TxtStokNo.Text=="")
            {
                return "Lütfen bir Stok yazınız!";
            }
            if (TxtTanim.Text=="")
            {
                return "Lütfen bir Tanım yazınız!";
            }
            if (CmbIlgiliFirma.SelectedIndex == -1)
            {
                return "Lütfen İlgili Firma bilgisini yazınız!";
            }
            return "OK";
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string control = Control();
            if (control!="OK")
            {
                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                UstTakim ustTakim = new UstTakim(TxtStokNo.Text, TxtTanim.Text, CmbIlgiliFirma.Text);
                string mesaj = ustTakimManager.Add(ustTakim);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataDisplay();
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtStokNo.Clear();
                TxtTanim.Clear();
                CmbIlgiliFirma.SelectedIndex = -1;

            }
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            TxtStokNo.Text= DtgList.CurrentRow.Cells["StokNo"].Value.ToString();
            TxtTanim.Text = DtgList.CurrentRow.Cells["Tanim"].Value.ToString();
            CmbIlgiliFirma.Text= DtgList.CurrentRow.Cells["IlgiliFirma"].Value.ToString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtStokNo.Clear(); TxtTanim.Clear(); CmbIlgiliFirma.SelectedIndex= -1;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            string control = Control();
            if (control != "OK")
            {
                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bilgileri güncellemek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                UstTakim ustTakim = new UstTakim(id, TxtStokNo.Text, TxtTanim.Text, CmbIlgiliFirma.Text);
                string mesaj = ustTakimManager.Update(ustTakim);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                id = 0;
                DataDisplay();
                MessageBox.Show("Bilgiler başarıyla güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtStokNo.Clear();
                TxtTanim.Clear();
                CmbIlgiliFirma.SelectedIndex = -1;
            }
        }

        private void BtnKayitSil_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen geçerli bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = ustTakimManager.Delete(id);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                id = 0;
                DataDisplay();
                MessageBox.Show("Bilgiler başarıyla silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtStokNo.Clear();
                TxtTanim.Clear();
                CmbIlgiliFirma.SelectedIndex = -1;
            }
        }

        private void FrmUstTakim_FormClosing(object sender, FormClosingEventArgs e)
        {
            var form = (FrmArizaAcmaCalisma)Application.OpenForms["FrmArizaAcmaCalisma"];
            if (form != null)
            {
                form.CmbStokNo();
            }
            var form2 = (FrmMalzemeKayit)Application.OpenForms["FrmMalzemeKayit"];
            if (form2 != null)
            {
                form2.CmbStokNoUst();
                form2.CmbStokNoUst2();
            }

        }
    }
}
