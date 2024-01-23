using Business;
using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity;
using Entity.AnaSayfa;
using Entity.BakimOnarim;
using Entity.IdariIsler;
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
using UserInterface.Ana_Sayfa;
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmArizaKayitOlusturSaha : Form
    {
        IsAkisNoManager isAkisNoManager;
        ComboManager comboManager;
        SatTalebiDoldurManager satTalebiDoldurManager;
        BolgeManager bolgeManager;
        AbfFormNoManager abfFormNoManager;
        ArizaKayitManager arizaKayitManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        PersonelKayitManager kayitManager;
        BolgeKayitManager bolgeKayitManager;
        BolgeGarantiManager bolgeGarantiManager;
        DtsLogManager dtsLogManager;

        List<string> fileNames = new List<string>();
        List<PersonelKayit> personelKayits;

        string proje, isAkisNo, dosyaYolu, kaynakdosyaismi, alinandosya, siparisNo, projeTanim, muster;
        bool start = true, kayitKontrol = false, dosyaKontrol = false;
        
        public object[] infos;
        int abfForm, id;
        public FrmArizaKayitOlusturSaha()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            bolgeManager = BolgeManager.GetInstance();
            abfFormNoManager = AbfFormNoManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            bolgeGarantiManager = BolgeGarantiManager.GetInstance();
            dtsLogManager = DtsLogManager.GetInstance();

        }

        private void FrmArizaKayitOlusturSaha_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            UsBolgeleri();
            Personeller();
            LblArizaBildirimiAlan.Text = infos[1].ToString();
            start = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (kayitKontrol == false)
            {
                if (dosyaKontrol == true)
                {
                    Directory.Delete(dosyaYolu, true);
                }
            }

            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageArizaKaydiOlusturSaha"]);
            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtBildirilenAriza.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle gerekli tüm bilgileri doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dosyaYolu==null)
            {
                MessageBox.Show("Lütfen öncelikle bir dosya ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNo();

                siparisNo = Guid.NewGuid().ToString();

                abfForm = AbfFormNo();

                ArizaKayit arizaKayit = new ArizaKayit(LblIsAkisNo.Text.ConInt(), abfForm, LblPdl.Text, CmbBolgeAdi.Text, "", "", LblBirlilkAdresi.Text, LblIl.Text, LblIlce.Text, TxtBildirilenAriza.Text, TxtBirlikPersoneli.Text, TxtBirlikPerRutbesi.Text, TxtBirlikPerGorevi.Text, TxtABTelefon.Text, DateTime.Now, LblArizaBildirimiAlan.Text, CmbBildirimKanali.Text, TxtArizaAciklama.Text, CmbGorevAtanacakPersonel.Text, LblIslemAdimi.Text, dosyaYolu, siparisNo, projeTanim, muster);

                string mesaj = arizaKayitManager.Add(arizaKayit);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                GorevAtama();
                DtsLogKayit();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAkisNo();
                Temizle();
                kayitKontrol = true;
            }
        }

        void DtsLogKayit()
        {
            string islem = "ARIZA KAYIT" + CmbBolgeAdi.Text + " bölgesi için " + abfForm + " ABF Numaralı arıza kaydı oluşturulmuştur.";
            DtsLog dtsLog = new DtsLog(infos[1].ToString(), DateTime.Now, "ARIZA KAYIT", islem);
            dtsLogManager.Add(dtsLog);
        }

        void MailGonder()
        {
            FrmMail frmMail = new FrmMail();
            frmMail.mailbilgi = "Saha Ariza Bildirim";
            frmMail.usBolgesi = CmbBolgeAdi.Text;
            frmMail.infos = infos;
            frmMail.dosyaYolu = dosyaYolu;
            frmMail.ShowDialog();

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        string DosyaControl()
        {
            if (CmbBolgeAdi.Text=="")
            {
                return "Lütfen dosya eklemden önce Bölge Adı bilgisini doldurunuz!";
            }
            if (TxtBildirilenAriza.Text=="")
            {
                return "Lütfen dosya eklemden önce Bildirilen Arıza bilgisini doldurunuz!";
            }
            if (TxtBirlikPersoneli.Text=="")
            {
                return "Lütfen dosya eklemden önce Birlik Personeli bilgilerini doldurunuz!";
            }
            if (TxtBirlikPerRutbesi.Text == "")
            {
                return "Lütfen dosya eklemden önce Birlik Personeli bilgilerini doldurunuz!";
            }
            if (TxtBirlikPerGorevi.Text == "")
            {
                return "Lütfen dosya eklemden önce Birlik Personeli bilgilerini doldurunuz!";
            }
            if (CmbBildirimKanali.Text == "")
            {
                return "Lütfen dosya eklemden önce Bildirim Kanalı bilgisini doldurunuz!";
            }
            return "OK";
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            if (DosyaControl() != "OK")
            {
                MessageBox.Show(DosyaControl(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IsAkisNo();
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\BAKIM ONARIM\ARIZA\";

            isAkisNo = LblIsAkisNo.Text;

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYolu = subdir + isAkisNo;
            Directory.CreateDirectory(subdir + isAkisNo);

            //Directory.CreateDirectory(subdir + isAkisNo);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi = openFileDialog1.SafeFileName.ToString();
                alinandosya = openFileDialog1.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                webBrowser1.Navigate(dosyaYolu);
                dosyaKontrol = true;

            }
        }

        void Personeller()
        {
            if (infos[0].ConInt() == 25 || infos[0].ConInt() == 84)
            {
                personelKayits = kayitManager.PersonelAdSoyad();
            }
            else
            {
                personelKayits = kayitManager.PersonelAdSoyad(infos[1].ToString());
                PersonelKayit personelKayit = new PersonelKayit(infos[0].ConInt(), infos[1].ToString(), infos[9].ToString(), infos[4].ToString(), infos[8].ToString(), infos[7].ToString(), infos[10].ToString(), infos[2].ToString(), infos[3].ToString());
                personelKayits.Add(personelKayit);
            }

            CmbGorevAtanacakPersonel.DataSource = personelKayits;
            CmbGorevAtanacakPersonel.ValueMember = "Id";
            CmbGorevAtanacakPersonel.DisplayMember = "Adsoyad";
            CmbGorevAtanacakPersonel.SelectedValue = -1;
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        int AbfFormNo()
        {
            abfFormNoManager.Update();
            AbfFormNo abfFormNo = abfFormNoManager.Get();
            return abfFormNo.FormNo;
        }

        void Temizle()
        {
            LblProje.Text = "00"; CmbBolgeAdi.SelectedValue = "";
            LblBirlilkAdresi.Text = "-"; LblIl.Text = "-"; LblIlce.Text = "-"; TxtBildirilenAriza.Clear(); TxtBirlikPersoneli.Clear();
            TxtBirlikPerRutbesi.Clear(); TxtBirlikPerGorevi.Clear(); TxtABTelefon.Clear(); CmbBildirimKanali.Text = "";
            TxtArizaAciklama.Clear(); webBrowser1.Navigate(""); LblProje.Text = "00"; LblPdl.Text = "00";

        }
        void GorevAtama()
        {
            ArizaKayit arizaKayit = arizaKayitManager.Get(abfForm);
            id = arizaKayit.Id;

            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM", infos[1].ToString(), "100_ARIZANIN BİLDİRİLMESİ (MÜŞTERİ)", DateTime.Now, TxtBildirilenAriza.Text, "00:05:00".ConOnlyTime());
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            string sure = "0 Gün " + "0 Saat " + "0 Dakika";

            int guncellenecekId = 0;
            List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(id, "BAKIM ONARIM");

            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == "100_ARIZANIN BİLDİRİLMESİ (MÜŞTERİ)")
                {
                    guncellenecekId = item.Id;
                }
            }

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(guncellenecekId, id, "BAKIM ONARIM", "100_ARIZANIN BİLDİRİLMESİ (MÜŞTERİ)", sure, DateTime.Now.Date, infos[1].ToString());
            gorevAtamaPersonelManager.Update(gorevAtama);

            GorevAtamaPersonel gorevAtamaPersonel4 = new GorevAtamaPersonel(id, "BAKIM ONARIM", CmbGorevAtanacakPersonel.Text, LblIslemAdimi.Text, DateTime.Now, "", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel4);
            
        }

        //void CmbProj()
        //{
        //    CmbProje.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
        //    CmbProje.ValueMember = "Id";
        //    CmbProje.DisplayMember = "Baslik";
        //    CmbProje.SelectedValue = 0;
        //}

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

        private void CmbBolgeAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            int id = CmbBolgeAdi.SelectedValue.ConInt();
            BolgeKayit bolge = bolgeKayitManager.Get(id);
            projeTanim = bolge.ProjeSistem;
            muster = bolge.Musteri;
            proje = bolge.Proje;
            LblProje.Text = proje;
            LblBirlilkAdresi.Text = bolge.BirlikAdresi;
            LblIl.Text = bolge.Il;
            LblIlce.Text = bolge.Ilce;

            BolgeGaranti bolgeGaranti = bolgeGarantiManager.Get(bolge.SiparisNo);
            if (bolgeGaranti != null)
            {
                LblPdl.Text = bolgeGaranti.GarantiPaketi;
            }
            else
            {
                LblPdl.Text  = bolge.Proje;
            }
        }
    }
}
