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

namespace UserInterface.STS
{
    public partial class FrmAltYukleniciFirma : Form
    {
        AltYukleniciManager yukleniciManager;
        TedarikciFirmaManager tedarikciFirmaManager;
        List<AltYuklenici> altYuklenicis;
        string il = "";
        int id;
        bool start = true;
        public FrmAltYukleniciFirma()
        {
            InitializeComponent();
            yukleniciManager = AltYukleniciManager.GetInstance();
            tedarikciFirmaManager = TedarikciFirmaManager.GetInstance();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageAltYüklenici"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void FrmAltYukleniciFirma_Load(object sender, EventArgs e)
        {
            DtgAltYukleniciDisplay();
            TxtTop.Text = DtgAltYuklenici.RowCount.ToString();
            CmbIlYükle();
            start = false;
        }
        public void YenilecekVeri()
        {
            start = true;
            DtgAltYukleniciDisplay();
            TxtTop.Text = DtgAltYuklenici.RowCount.ToString();
            CmbIlYükle();
            start = false;
        }
        void DtgAltYukleniciDisplay()
        {
            altYuklenicis = yukleniciManager.GetList(id);
            dataBinder.DataSource = altYuklenicis.ToDataTable();
            DtgAltYuklenici.DataSource = dataBinder;

            DtgAltYuklenici.Columns["Id"].Visible = false;
            DtgAltYuklenici.Columns["Firmaadi"].HeaderText = "FİRMA ADI";
            DtgAltYuklenici.Columns["Firmaadresi"].HeaderText = "FİRMA ADRESİ";
            DtgAltYuklenici.Columns["Il"].HeaderText = "İL";
            DtgAltYuklenici.Columns["Ilçe"].HeaderText = "İLÇE";
            DtgAltYuklenici.Columns["Telefon"].HeaderText = "FİRMA TELEFONU";
            DtgAltYuklenici.Columns["Faliyatalani"].HeaderText = "FAALİYET ALANI";
            DtgAltYuklenici.Columns["Personeladi"].HeaderText = "PERSONELİN ADI SOYADI";
            DtgAltYuklenici.Columns["Personeltelefon"].HeaderText = "PERSONELİN NUMARASI";
            DtgAltYuklenici.Columns["Mail"].HeaderText = "MAİL";
        }


        private void BtnYeniKayit_Click(object sender, EventArgs e)
        {
            
            DialogResult dr = MessageBox.Show("Firmayı Kaydetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                AltYuklenici altYuklenici = new AltYuklenici(TxtFirmaAdi.Text, TxtFirmaAdres.Text,CmbIl.Text,CmbIlce.Text,TxtTelefon.Text, TxtAlanı.Text, TxtAdSoyad.Text,
                    TxtPersTel.Text, TxtMail.Text);
                string mesaj = yukleniciManager.Add(altYuklenici);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(TxtFirmaAdi.Text + " Firması Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DtgAltYukleniciDisplay();
                Temizle();
            }
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (DtgAltYuklenici.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DialogResult dr = MessageBox.Show("Firmayı Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                AltYuklenici altYuklenici = new AltYuklenici(TxtFirmaAdi.Text, TxtFirmaAdres.Text, CmbIl.Text, CmbIlce.Text, TxtTelefon.Text, TxtAlanı.Text, TxtAdSoyad.Text,
                    TxtPersTel.Text, TxtMail.Text);
                string mesaj = yukleniciManager.Update(altYuklenici,id);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DtgAltYukleniciDisplay();
                Temizle();
            }
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (DtgAltYuklenici.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            string control = yukleniciManager.Delete(id);
            if (control != "OK")
            {
                MessageBox.Show(control);
                return;
            }
            MessageBox.Show(TxtFirmaAdi.Text + " Firması Başarıyla Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DtgAltYukleniciDisplay();
            Temizle();
        }

        private void DtgAltYuklenici_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            id = DtgAltYuklenici.CurrentRow.Cells["Id"].Value.ConInt();
            TxtFirmaAdi.Text = DtgAltYuklenici.CurrentRow.Cells["Firmaadi"].Value.ToString();
            TxtFirmaAdres.Text = DtgAltYuklenici.CurrentRow.Cells["Firmaadresi"].Value.ToString();
            CmbIl.Text = DtgAltYuklenici.CurrentRow.Cells["Il"].Value.ToString();
            CmbIlce.Text = DtgAltYuklenici.CurrentRow.Cells["Ilçe"].Value.ToString();
            TxtTelefon.Text = DtgAltYuklenici.CurrentRow.Cells["Telefon"].Value.ToString();
            TxtAlanı.Text = DtgAltYuklenici.CurrentRow.Cells["Faliyatalani"].Value.ToString();
            TxtAdSoyad.Text = DtgAltYuklenici.CurrentRow.Cells["Personeladi"].Value.ToString();
            TxtPersTel.Text = DtgAltYuklenici.CurrentRow.Cells["Personeltelefon"].Value.ToString();
            TxtMail.Text = DtgAltYuklenici.CurrentRow.Cells["Mail"].Value.ToString();

        }
        void Temizle()
        {
            TxtFirmaAdi.Clear(); TxtFirmaAdres.Clear(); CmbIl.Text = ""; CmbIlce.Text = ""; TxtTelefon.Clear(); TxtAlanı.Clear(); TxtAdSoyad.Clear();
            TxtPersTel.Clear(); TxtMail.Clear();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void DtgAltYuklenici_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgAltYuklenici.FilterString;
            TxtTop.Text = DtgAltYuklenici.RowCount.ToString();
        }

        private void DtgAltYuklenici_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgAltYuklenici.SortString;
        }
        void CmbIlYükle()
        {
            CmbIl.DataSource = tedarikciFirmaManager.Iller();
            CmbIl.SelectedIndex = -1;

            il = CmbIl.Text;
        }

        private void CmbIl_SelectedValueChanged(object sender, EventArgs e)
        {
            il = CmbIl.Text;
            CmbIlceYükle();
        }
        void CmbIlceYükle()
        {
            if (start)
            {
                return;
            }
            CmbIlce.DataSource = tedarikciFirmaManager.Ilceler(il);
        }
    }
}
