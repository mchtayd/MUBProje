using Business;
using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity.AnaSayfa;
using Entity.IdariIsler;
using Entity.STS;
using Entity.Yerleskeler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmHesapOlustur : Form
    {
        PersonelKayitManager kayitManager;
        PersonelHesapManager personelHesapManager;
        MenuManager menuManager;
        YetkilerManager yetkilerManager;
        PersonelManager personelManager;
        LoginManager loginManager;

        List<MenuBaslik> menuBasliks;
        List<string> idler = new List<string>();

        bool start = false;
        bool kayitliPersonel = false;
        string dosyaYolu = "";
        public FrmHesapOlustur()
        {
            InitializeComponent();
            kayitManager = PersonelKayitManager.GetInstance();
            personelHesapManager = PersonelHesapManager.GetInstance();
            menuManager = MenuManager.GetInstance();
            yetkilerManager = YetkilerManager.GetInstance();
            personelManager = PersonelManager.GetInstance();
            loginManager = LoginManager.GetInstance();
        }

        private void FrmHesapOlustur_Load(object sender, EventArgs e)
        {
            Personeller();
            MenuBasliklar();
            start = true;
        }
        void MenuBasliklar()
        {
            menuBasliks = menuManager.GetList();
            foreach (MenuBaslik item in menuBasliks)
            {
                ChcListBoxYetkiler.Items.Add(item.Baslik);
            }

        }
        void Personeller()
        {
            CmbPersonel.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersonel.ValueMember = "Id";
            CmbPersonel.DisplayMember = "Adsoyad";
            CmbPersonel.SelectedValue = 0;
        }
        int yetkiId, personelId = 0;
        string sicil;
        private void CmbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }

            PersonelHesap personelHesap = personelHesapManager.Get(CmbPersonel.Text);
            if (personelHesap != null)
            {
                TxtSicilNo.Text = personelHesap.SicilNo;
                TxtSifre.Text = personelHesap.Sifre;
                PctBox.ImageLocation = personelHesap.FotoYolu + "//" + CmbPersonel.Text + ".jpg";
                kayitliPersonel = true;
                CmbYetkiModu.Text = personelHesap.YetkiModu;
                yetkiId = personelHesap.YetkiId;
                personelId = personelHesap.Id;
            }
            else
            {
                PersonelKayit personelKayit = kayitManager.Get(0, CmbPersonel.Text);
                if (personelKayit != null)
                {
                    TxtSifre.Clear();
                    PctBox.ImageLocation = personelKayit.Fotoyolu + "//" + CmbPersonel.Text + ".jpg";
                    sicil = personelKayit.Sicil;
                    personelId = personelKayit.Id;
                    kayitliPersonel = false;
                    CmbYetkiModu.SelectedIndex = -1;
                    if (sicil.Length != 4)
                    {
                        while (sicil.Length != 4)
                        {
                            sicil = "0" + sicil;
                        }

                        TxtSicilNo.Text = sicil;
                    }
                    else
                    {
                        TxtSicilNo.Text = sicil;
                    }
                }

            }

        }

        private void BtnSee_Click(object sender, EventArgs e)
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

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string sifre = "";
            if (kayitliPersonel == true)
            {
                if (TxtSifre.Text == "")
                {
                    MessageBox.Show("Şifre kısmını boş bıraktığınız için 123456 standart şifresi tanımlanacaktır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sifre = "123456";
                }
                //int index = 0;

                PersonelKayit personelKayit = kayitManager.Get(0, CmbPersonel.Text);
                if (personelKayit == null)
                {

                    PersonelKayit personelKayit2 = new PersonelKayit(CmbPersonel.Text, "", "", "", "", "", "", "", DateTime.Now, "", "", "", "", "", "", "", "", "", "", "", TxtSicilNo.Text, "", "", "", "", "", "", "", "", "", "", DateTime.Now, "", "", "", "", "", "", "", "", "", "","", "", "", "", "", DateTime.Now, CmbYetkiModu.Text);

                    string message = kayitManager.Add(personelKayit2, "OTO");
                    if (message != "OK")
                    {
                        MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string izinIdleri = "";
                foreach (string item in ChcListBoxYetkiler.CheckedItems)
                {
                    string header = item.Trim();

                    foreach (MenuBaslik item2 in menuBasliks)
                    {
                        if (item2.Baslik == header)
                        {
                            idler.Add(item2.Id.ToString());
                            break;
                        }
                    }
                }

                izinIdleri = string.Join(";", idler);
                Yetki yetki = new Yetki(yetkiId, izinIdleri);
                yetkilerManager.Update(yetki, yetkiId);
                MessageBox.Show("Bilgiler başarıyla kadedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();

            }
            else
            {
                if (CmbPersonel.Text == "")
                {
                    MessageBox.Show("Lütfen öncelikle kayıtlı bir personel seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Personel için DTS hesabı oluşturulacak onaylıyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        PersonelKayit personelKayit = kayitManager.Get(0, CmbPersonel.Text);
                        if (personelKayit == null)
                        {
                            string root = @"Z:\DTS";
                            string subdir = @"Z:\DTS\İDARİ İŞLER\PERSONELLER\";
                            //root = @"C:\STS";
                            //subdir = @"C:\STS\Personel Dosyaları\";
                            if (!Directory.Exists(root))
                            {
                                Directory.CreateDirectory(root);
                            }
                            if (!Directory.Exists(subdir))
                            {
                                Directory.CreateDirectory(subdir);
                            }
                            if (!Directory.Exists(subdir + CmbPersonel.Text))
                            {
                                Directory.CreateDirectory(subdir + CmbPersonel.Text);
                            }

                            dosyaYolu = subdir + CmbPersonel.Text;

                            string yeniad = CmbPersonel.Text + ".jpg";
                            if (!Directory.Exists(dosyaYolu + "\\" + yeniad))
                            {
                                string silinecek = dosyaYolu + "\\" + yeniad;
                                File.Delete(silinecek);
                            }

                            File.Copy("Z:\\DTS\\İDARİ İŞLER\\PERSONELLER\\Guest.png", dosyaYolu + "\\" + yeniad);


                            PersonelKayit personelKayit2 = new PersonelKayit(CmbPersonel.Text, "", "", "", "", "", "", "", DateTime.Now, "", "", "", "", "", "", "", "", "", "", "", TxtSicilNo.Text, "", "", "", "", "", "", "", "", "", "", DateTime.Now, "", "", "", "", "", "", "", "", "", "", "", dosyaYolu, dosyaYolu, "", "", DateTime.Now, CmbYetkiModu.Text);

                            string message = kayitManager.Add(personelKayit2, "OTO");
                            if (message != "OK")
                            {
                                MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        string izinIdleri = "";
                        foreach (string item in ChcListBoxYetkiler.CheckedItems)
                        {
                            string header = item.Trim();

                            foreach (MenuBaslik item2 in menuBasliks)
                            {
                                if (item2.Baslik == header)
                                {
                                    idler.Add(item2.Id.ToString());
                                    break;
                                }
                            }
                        }
                        izinIdleri = string.Join(";", idler);
                        Yetki yetki = new Yetki(0, CmbPersonel.Text, izinIdleri);
                        string mesaj = yetkilerManager.Add(yetki);

                        if (mesaj != "OK")
                        {
                            MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        yetki = yetkilerManager.Get(CmbPersonel.Text);

                        yetkiId = yetki.Id;

                        PersonelKayit personelKayit3 = kayitManager.Get(0, CmbPersonel.Text);
                        personelId = personelKayit3.Id;
                        Personel personel = new Personel(personelId, TxtSicilNo.Text, CmbPersonel.Text, yetkiId);

                        mesaj = personelManager.Add(personel);
                        if (mesaj != "OK")
                        {
                            MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        Entity.Login login = new Entity.Login(personelId, TxtSicilNo.Text, TxtSifre.Text);
                        mesaj = loginManager.Add(login);

                        if (mesaj != "OK")
                        {
                            MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        MessageBox.Show(CmbPersonel.Text + " adlı personel için DTS hesabı başarıyla oluşturulmuştur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Temizle();

                    }
                }

            }


        }
        void Temizle()
        {
            CmbPersonel.SelectedIndex = -1; TxtSicilNo.Clear(); TxtSifre.Clear(); CmbYetkiModu.SelectedIndex = -1; PctBox.ImageLocation = "";
            CmbPersonel.Text = "";
            for (int i = 0; i < menuBasliks.Count; i++)
            {
                ChcListBoxYetkiler.SetItemChecked(i, false);
            }
            btnTumYetki = false;

        }
        void SetChcListItemChecked(string header, int startIndex, int lastIndex, bool isChecked)
        {
            if (ChcListBoxYetkiler.SelectedItem.ToString().Trim() == header)
            {
                for (int i = startIndex; i <= lastIndex; i++)
                {
                    ChcListBoxYetkiler.SetItemChecked(i, isChecked);
                }
            }
        }
        private void ChcListBoxYetkiler_ItemCheck(object sender, ItemCheckEventArgs e)
        {



            /*
            if (start2 == true)
            {
                return;
            }
            if (e.NewValue == CheckState.Checked)
            {
                int id = ChcListBoxYetkiler.SelectedIndex.ConInt() + 1;
                start2 = true;
                int sayac = 1;
                if (id == 1)
                {
                    foreach (MenuBaslik item in menuBasliks)
                    {
                        if (item.BaslikId + 1 == id)
                        {
                            ChcListBoxYetkiler.SetItemChecked(sayac, true);
                        }
                        sayac++;
                    }
                }
                if (id == 87)
                {

                }

                foreach (MenuBaslik item in menuBasliks)
                {
                    if (item.BaslikId == id)
                    {

                    }
                }
            }
            */

        }

        bool btnTumYetki = false;

        private void BtnTumetki_Click(object sender, EventArgs e)
        {
            if (btnTumYetki == false)
            {
                for (int i = 0; i < menuBasliks.Count; i++)
                {
                    ChcListBoxYetkiler.SetItemChecked(i, true);
                }
                btnTumYetki = true;
            }
            else
            {
                for (int i = 0; i < menuBasliks.Count; i++)
                {
                    ChcListBoxYetkiler.SetItemChecked(i, false);
                }
                btnTumYetki = false;
            }


        }

        private void CmbYetkiModu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbYetkiModu.Text == "MİSAFİR")
            {
                CmbPersonel.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                CmbPersonel.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void BtnSifirla_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < menuBasliks.Count; i++)
            {
                ChcListBoxYetkiler.SetItemChecked(i, false);
            }
            btnTumYetki = false;
        }
    }
}
