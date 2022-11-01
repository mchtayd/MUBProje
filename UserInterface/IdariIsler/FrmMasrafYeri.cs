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
using UserInterface.IdariIşler;

namespace UserInterface.IdariIsler
{
    public partial class FrmMasrafYeri : Form
    {
        MasrafYeriManager masrafYeriManager;
        PersonelKayitManager personelKayit;
        int id;
        public FrmMasrafYeri()
        {
            InitializeComponent();
            masrafYeriManager = MasrafYeriManager.GetInstance();
            personelKayit = PersonelKayitManager.GetInstance();
        }

        private void FrmMasrafYeri_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        void DataDisplay()
        {
            DtgIcerik.DataSource = masrafYeriManager.GetList();
            DtgIcerik.Columns["Id"].Visible = false;
            DtgIcerik.Columns["MasrafYeriNo"].HeaderText = "MASRAF YERİ NO";
            DtgIcerik.Columns["MasrafYeriBilgi"].HeaderText = "MASRAF YERİ";
            TxtTop.Text = DtgIcerik.RowCount.ToString();
        }

        private void DtgIcerik_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgIcerik.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = DtgIcerik.CurrentRow.Cells["Id"].Value.ConInt();
            TxtMasrafYeriNo.Text = DtgIcerik.CurrentRow.Cells["MasrafYeriNo"].Value.ToString();
            TxtMasrafYeri.Text = DtgIcerik.CurrentRow.Cells["MasrafYeriBilgi"].Value.ToString();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(TxtMasrafYeriNo.Text + " Nolu Masraf Yeri Bilgisini Eklemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in DtgIcerik.Rows)
                {
                    if (item.Cells["MasrafYeriNo"].Value.ToString() == TxtMasrafYeriNo.Text || item.Cells["MasrafYeriBilgi"].Value.ToString() == TxtMasrafYeri.Text)
                    {
                        MessageBox.Show("Aynı İçerik Zaten Mevcut İkinci Kez Ekleyemezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MasrafYeri masrafYeri = new MasrafYeri(TxtMasrafYeriNo.Text, TxtMasrafYeri.Text);
                string mesaj = masrafYeriManager.Add(masrafYeri);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataDisplay();
                TxtMasrafYeri.Clear();
                TxtMasrafYeriNo.Clear();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Güncellemek İstediğiniz İçeriği Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(TxtMasrafYeriNo.Text + " Nolu Masraf Yerini Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                MasrafYeri masrafYeri = new MasrafYeri(id, TxtMasrafYeriNo.Text, TxtMasrafYeri.Text);
                string mesaj = masrafYeriManager.Update(masrafYeri);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataDisplay();
                TxtMasrafYeri.Clear();
                TxtMasrafYeriNo.Clear();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz İçeriği Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(TxtMasrafYeriNo.Text + " Nolu Masraf Yerini Silmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = masrafYeriManager.Delete(id);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataDisplay();
                TxtMasrafYeri.Clear();
                TxtMasrafYeriNo.Clear();
            }
        }

        private void FrmMasrafYeri_FormClosing(object sender, FormClosingEventArgs e)
        {
            var form = (FrmPersonelKayit)Application.OpenForms["FrmPersonelKayit"];
            if (form != null)
            {
                form.MasrafYeri();
                form.MasrafYeriBilgi();
                form.MasrafYeriGuncel();
                form.MasrafYeriBilgiGuncel();
            }
        }
    }
}
