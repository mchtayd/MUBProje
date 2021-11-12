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
    public partial class FrmTedarikciFirmaBilgileri : Form
    {
        TedarikciFirmaManager tedarikciFirmaManager;
        List<TedarikciFirma> firmalar;
        TedarikciFirma tedarikciFirma;
        string benzersiz = "", control = "", il = "";
        int id;
        bool start = true;

        public FrmTedarikciFirmaBilgileri()
        {
            InitializeComponent();
            tedarikciFirmaManager = TedarikciFirmaManager.GetInstance();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageTedarikciFirma"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        private void FrmTedarikciFirmaBilgileri_Load(object sender, EventArgs e)
        {
            DataDisplay();
            CmbIlYükle();
            start = false;
            TxtTop.Text = DtgTeklifAl.RowCount.ToString();
        }
        public void YenilecekVeri()
        {
            start = true;
            DataDisplay();
            CmbIlYükle();
            start = false;
            TxtTop.Text = DtgTeklifAl.RowCount.ToString();
        }
        void DataDisplay()
        {
            firmalar = tedarikciFirmaManager.GetList(benzersiz);
            dataBinder.DataSource = firmalar.ToDataTable();
            DtgTeklifAl.DataSource = dataBinder;

            DtgTeklifAl.Columns["Id"].Visible = false;
            DtgTeklifAl.Columns["Firmaadi"].HeaderText = "FİRMA ADI";
            DtgTeklifAl.Columns["Firmaadresi"].HeaderText = "FİRMA ADRESİ";
            DtgTeklifAl.Columns["Firmail"].HeaderText = "İL";
            DtgTeklifAl.Columns["Firmailce"].HeaderText = "İLÇE";
            DtgTeklifAl.Columns["Telefon"].HeaderText = "FİRMA TELEFONU";
            DtgTeklifAl.Columns["Faliyetalani"].HeaderText = "FAALİYET ALANI";
            DtgTeklifAl.Columns["Personelad"].HeaderText = "PERSONELİN ADI SOYADI";
            DtgTeklifAl.Columns["Personeltelefon"].HeaderText = "PERSONELİN NUMARASI";
            DtgTeklifAl.Columns["Mail"].HeaderText = "MAİL";
            DtgTeklifAl.Columns["Benzersiz"].Visible = false;
        }
        void Yenile()
        {
            benzersiz = "";
            firmalar = tedarikciFirmaManager.GetList(benzersiz);
            dataBinder.DataSource = firmalar.ToDataTable();
            DtgTeklifAl.DataSource = dataBinder;

            DtgTeklifAl.Columns["Id"].Visible = false;
            DtgTeklifAl.Columns["Firmaadi"].HeaderText = "FİRMA ADI";
            DtgTeklifAl.Columns["Firmaadresi"].HeaderText = "FİRMA ADRESİ";
            DtgTeklifAl.Columns["Firmail"].HeaderText = "İL";
            DtgTeklifAl.Columns["Firmailce"].HeaderText = "İLÇE";
            DtgTeklifAl.Columns["Telefon"].HeaderText = "FİRMA TELEFONU";
            DtgTeklifAl.Columns["Faliyetalani"].HeaderText = "FAALİYET ALANI";
            DtgTeklifAl.Columns["Personelad"].HeaderText = "PERSONELİN ADI SOYADI";
            DtgTeklifAl.Columns["Personeltelefon"].HeaderText = "PERSONELİN NUMARASI";
            DtgTeklifAl.Columns["Mail"].HeaderText = "MAİL";
            DtgTeklifAl.Columns["Benzersiz"].Visible = false;
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

        void Temizle()
        {
            TxtFirmaAdi.Clear(); TxtFirmaAdres.Clear(); CmbIl.Text = ""; CmbIlce.Text = ""; TxtTelefon.Clear(); TxtAlanı.Clear(); TxtAdSoyad.Clear(); TxtPersTel.Clear();
            TxtMail.Clear();
        }

        private void DtgTeklifAl_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgTeklifAl.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            id = DtgTeklifAl.CurrentRow.Cells["Id"].Value.ConInt();
            benzersiz = DtgTeklifAl.CurrentRow.Cells["Benzersiz"].Value.ToString();
            TxtFirmaAdi.Text = DtgTeklifAl.CurrentRow.Cells["Firmaadi"].Value.ToString();
            TxtFirmaAdres.Text = DtgTeklifAl.CurrentRow.Cells["Firmaadresi"].Value.ToString();
            CmbIl.Text = DtgTeklifAl.CurrentRow.Cells["Firmail"].Value.ToString();
            CmbIlce.Text = DtgTeklifAl.CurrentRow.Cells["Firmailce"].Value.ToString();
            TxtTelefon.Text = DtgTeklifAl.CurrentRow.Cells["Telefon"].Value.ToString();
            TxtAlanı.Text = DtgTeklifAl.CurrentRow.Cells["Faliyetalani"].Value.ToString();
            TxtAdSoyad.Text = DtgTeklifAl.CurrentRow.Cells["Personelad"].Value.ToString();
            TxtPersTel.Text = DtgTeklifAl.CurrentRow.Cells["Personeltelefon"].Value.ToString();
            TxtMail.Text = DtgTeklifAl.CurrentRow.Cells["Mail"].Value.ToString();
        }

        private void BtnYeniKayit_Click(object sender, EventArgs e)
        {
            if (DtgTeklifAl.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DialogResult dr = MessageBox.Show("Firmayı Kaydetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                benzersiz = Guid.NewGuid().ToString();

                tedarikciFirma = new TedarikciFirma(TxtFirmaAdi.Text, TxtFirmaAdres.Text, CmbIl.Text, CmbIlce.Text, TxtTelefon.Text, TxtAlanı.Text, TxtAdSoyad.Text, TxtPersTel.Text,
                TxtMail.Text, benzersiz);
                control = tedarikciFirmaManager.Add(tedarikciFirma);
                if (control != "OK")
                {
                    MessageBox.Show(control);
                    return;
                }
                MessageBox.Show(TxtFirmaAdi.Text + " Firması Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                Temizle();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Firmayı Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                tedarikciFirma = new TedarikciFirma(TxtFirmaAdi.Text, TxtFirmaAdres.Text, CmbIl.Text, CmbIlce.Text, TxtTelefon.Text, TxtAlanı.Text, TxtAdSoyad.Text, TxtPersTel.Text,
                TxtMail.Text, benzersiz);
                control = tedarikciFirmaManager.Update(tedarikciFirma);

                if (control != "OK")
                {
                    MessageBox.Show(control);
                    return;
                }
                MessageBox.Show(TxtFirmaAdi.Text + " Firması Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                Temizle();
            }
        }

        private void DtgTeklifAl_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgTeklifAl.FilterString;
            TxtTop.Text = DtgTeklifAl.RowCount.ToString();
        }

        private void DtgTeklifAl_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgTeklifAl.SortString;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Firmayı Silmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (id==1)
                {
                    MessageBox.Show("Bu İşlem Gerçekleşemez.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                control = tedarikciFirmaManager.Delete(id);
                if (control != "OK")
                {
                    MessageBox.Show(control);
                    return;
                }
                MessageBox.Show(TxtFirmaAdi.Text + " Firması Başarıyla Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                Temizle();
            }
        }
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
