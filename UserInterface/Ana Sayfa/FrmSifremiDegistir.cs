using Business;
using Business.Concreate;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonelManager = Business.Concreate.PersonelManager;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmSifremiDegistir : Form
    {
        public object[] infos;
        PersonelIslemleri personel;
        PersonelIslemleriManager personelIslemleriManager;
        PersonelManager personelManager;
        public FrmSifremiDegistir()
        {
            InitializeComponent();
            personelIslemleriManager = PersonelIslemleriManager.GetInstance();
            personelManager = PersonelManager.GetInstance();
        }

        private void FrmSifremiDegistir_Load(object sender, EventArgs e)
        {
            FillInfos();
        }
        void FillInfos()
        {
            LblAdsoyad.Text = infos[1].ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtEskiSifre.Text.Trim() == "" || TxtSifre.Text.Trim() == "" || TxtSifreTekrar.Text.Trim() == "" || TxtSicil.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen Tüm Bilgileri Eksiksiz Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            object[] kontrol = personelManager.Login(TxtSicil.Text, TxtEskiSifre.Text);

            if (kontrol == null)
            {
                MessageBox.Show("Hatalı Sicil Numarası Veya Şifre Girdiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (TxtSifre.Text!=TxtSifreTekrar.Text)
            {
                MessageBox.Show("Yeni Şifre Ve Yeni Şifre Tekrarı Uyuşmamaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (TxtEskiSifre.Text == TxtSifre.Text)
            {
                MessageBox.Show("Lütfen Eski Şifrenizden Farklı Bir Şifre Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Şifreniz Değiştirildikten Sonra DTS Uygulamanız Kapanacaktır.\nDevam Etmek İstiyor Musunuz?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                personel = null;
                personel = new PersonelIslemleri(TxtSicil.Text, TxtSifre.Text);
                MessageBox.Show(personelIslemleriManager.Update(personel));
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtEskiSifre.UseSystemPasswordChar == true)
            {
                TxtEskiSifre.UseSystemPasswordChar = false;
                return;
            }
            if (TxtEskiSifre.UseSystemPasswordChar == false)
            {
                TxtEskiSifre.UseSystemPasswordChar = true;
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TxtSifre.UseSystemPasswordChar == true)
            {
                TxtSifre.UseSystemPasswordChar = false;
                return;
            }
            if (TxtSifre.UseSystemPasswordChar == false)
            {
                TxtSifre.UseSystemPasswordChar = true;
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TxtSifreTekrar.UseSystemPasswordChar == true)
            {
                TxtSifreTekrar.UseSystemPasswordChar = false;
                return;
            }
            if (TxtSifreTekrar.UseSystemPasswordChar == false)
            {
                TxtSifreTekrar.UseSystemPasswordChar = true;
                return;
            }
        }
    }
}
