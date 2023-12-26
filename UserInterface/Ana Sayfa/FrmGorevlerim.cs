﻿using Business;
using Business.Concreate;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmGorevlerim : Form
    {
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        PersonelKayitManager kayitManager;
        List<GorevAtamaPersonel> gorevAtamaPersonels;
        List<GorevAtamaPersonel> IsAkisgorevAtamaPersonels;
        List<GorevAtamaPersonel> IsAkisgorevAtamaSatinAlma;
        List<GorevAtamaPersonel> arizaGorevAtamaAtolyePersonels;
        List<GorevAtamaPersonel> mifPersonels;
        List<SirketBolum> sirketBolums;
        GorevAtamaManager gorevAtamaManager;
        IsAkisNoManager isAkisNoManager;
        SirketBolumManager sirketBolumManager;

        string pageText1 = "", pageText3 = "", pageText2 = "", pageText4 = "", mail = "", dosyaYolu = "", kaynakdosyaismi = "", alinandosya = "", tamyol = "", isAkisNo = "", departman;
        int id;
        public object[] infos;
        int benzersizId;
        public int seciliTabId = -1;
        public FrmGorevlerim()
        {
            InitializeComponent();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            gorevAtamaManager = GorevAtamaManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            sirketBolumManager = SirketBolumManager.GetInstance();
        }

        private void advancedDataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgYoneticiGorevlerim.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            id = DtgYoneticiGorevlerim.CurrentRow.Cells["Id"].Value.ConInt();
            TxtIstenenGorev.Text = DtgYoneticiGorevlerim.CurrentRow.Cells["GorevinKonusu"].Value.ToString();
            dosyaYolu = DtgYoneticiGorevlerim.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            goreviAtayan = DtgYoneticiGorevlerim.CurrentRow.Cells["GoreviAtayanPersonel"].Value.ToString();
            isAkisNo = DtgYoneticiGorevlerim.CurrentRow.Cells["IsAkisNo"].Value.ToString();
            bitisTarihi = DtgYoneticiGorevlerim.CurrentRow.Cells["BitisTarihi"].Value.ConDate();
            
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }

        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //contextMenuStrip2.Show();
        }

        private void FrmGorevlerim_Load(object sender, EventArgs e)
        {
            DataDisplayAriza();
            DataDisplayYoneticiGorevlerim();
            DataDisplayIsAkis();
            BolumGorevlerim();

            pageText1 = "AÇIK ARIZA GÖREVLERİM " + "( " + TxtTop.Text + " )";
            pageText2 = "YÖNETİCİ GÖREVLERİM" + "(" + TxtGenelTop.Text + " )";
            pageText3 = "İŞ AKIŞI GÖREVLERİM " + "( " + TxtTop3.Text + " )";
            pageText4 = "BÖLÜM GÖREVLERİM " + "( " + LblBolumGorevleriTop.Text + " )";


            tabPage1.Text = pageText1;
            tabPage2.Text = pageText2;
            tabPage3.Text = pageText3;
            tabPage4.Text = pageText4;

            if (seciliTabId > -1)
            {
                if (seciliTabId == 0)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
                }
                if (seciliTabId == 1)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
                }
                if (seciliTabId == 2)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage3"];
                }
                if (seciliTabId == 3)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage4"];
                }

            }

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Geçerli Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string kontrol = Kontrol();

            if (kontrol != "OK")
            {
                MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                MailBul();
                TimeSpan SonucGun = DateTime.Now - bitisTarihi;
                TimeSpan SonucSaat = DateTime.Now - bitisTarihi;
                int gun = SonucGun.TotalDays.ConInt();
                int saat = SonucSaat.TotalHours.ConInt();

                int topsaat = (gun * 24) + saat;
                if (topsaat == 0)
                {
                    topsaat = 1;
                }


                GorevAtama gorevAtama = new GorevAtama(id, DateTime.Now, TxtAciklama.Text, topsaat.ToString(), dosyaYolu);

                gorevAtamaManager.Update(gorevAtama);

                Task.Factory.StartNew(() => MailSendMetot());
                MessageBox.Show("Bilgileri Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id = 0;
                TxtAciklama.Clear();
                webBrowser1.Navigate("");
                DataDisplayYoneticiGorevlerim();
            }

        }

        void MailBul()
        {
            PersonelKayit personelKayit = kayitManager.Get(0, goreviAtayan);
            mail = personelKayit.Oficemail;
        }
        string Kontrol()
        {
            if (TxtAciklama.Text == "")
            {
                return "Lütfen Yapılan İşlem Sonuç Kısmını Doldurunuz!";
            }
            return "OK";
        }
        DateTime bitisTarihi;

        private void DtgYoneticiGorevlerim_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgYoneticiGorevlerim.FilterString;
            TxtGenelTop.Text = DtgYoneticiGorevlerim.RowCount.ToString();
        }

        private void DtgYoneticiGorevlerim_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgYoneticiGorevlerim.SortString;
        }


        private void DtgGorevlerim_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderAriza.Filter = DtgGorevlerim.FilterString;
            TxtTop.Text = DtgGorevlerim.RowCount.ToString();
        }

        private void DtgIsAkisGorev_FilterStringChanged_1(object sender, EventArgs e)
        {
            dataBinderIsAkis.Filter = DtgIsAkisGorev.FilterString;
            TxtTop3.Text = DtgIsAkisGorev.RowCount.ToString();
        }

        private void DtgIsAkisGorev_SortStringChanged_1(object sender, EventArgs e)
        {
            dataBinderIsAkis.Sort = DtgIsAkisGorev.SortString;
        }

        private void DtgIsAkisGorev_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgIsAkisGorev.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            benzersizId = DtgIsAkisGorev.CurrentRow.Cells["BenzersizId"].Value.ConInt();
            departman = DtgIsAkisGorev.CurrentRow.Cells["Departman"].Value.ToString();
            int isAkis = DtgIsAkisGorev.CurrentRow.Cells["AbfNo"].Value.ConInt();
            string islemAdimi = DtgIsAkisGorev.CurrentRow.Cells["IslemAdimi"].Value.ToString();
            FrmGorevGor frmGorevGor = new FrmGorevGor();
            frmGorevGor.gorevAdi = islemAdimi;
            frmGorevGor.departman = departman;
            frmGorevGor.benzersizId = benzersizId;
            frmGorevGor.isAkisNo = isAkis;
            frmGorevGor.ShowDialog();
        }

        private void DtgGorevlerim_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderAriza.Sort = DtgGorevlerim.SortString;
        }

        string goreviAtayan;



        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            if (dosyaYolu == "")
            {

                string root = @"Z:\DTS";
                string subdir = @"Z:\DTS\ATANAN GÖREVLER\";


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
                    webBrowser1.Navigate(dosyaYolu);
                }

            }
            else
            {
                if (!Directory.Exists(dosyaYolu))
                {
                    MessageBox.Show("Dosya Yolu Bulunamadı.");
                    return;
                }
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
                string dosyaismi = kaynakdosyaismi;
                tamyol = dosyaYolu + "\\" + dosyaismi;
                if (File.Exists(dosyaismi))
                {
                    MessageBox.Show("Belirtilen Klasörde " + dosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!File.Exists(tamyol))
                    {
                        File.Copy(alinandosya, tamyol);
                    }
                    //BtnDosyaEkle.BackColor = Color.LightGreen;
                }
                webBrowser1.Navigate(dosyaYolu);
            }

        }

        void DataDisplayAriza()
        {
            gorevAtamaPersonels = gorevAtamaPersonelManager.IsAkisGorevlerimiGor(infos[1].ToString(), "BAKIM ONARIM");
            arizaGorevAtamaAtolyePersonels = gorevAtamaPersonelManager.IsAkisGorevlerimiGor(infos[1].ToString(), "BAKIM ONARIM ATÖLYE");
            foreach (GorevAtamaPersonel item in arizaGorevAtamaAtolyePersonels)
            {
                gorevAtamaPersonels.Add(item);
            }
            dataBinderAriza.DataSource = gorevAtamaPersonels.ToDataTable();
            DtgGorevlerim.DataSource = dataBinderAriza;

            DtgGorevlerim.Columns["Id"].Visible = false;
            DtgGorevlerim.Columns["BenzersizId"].Visible = false;
            DtgGorevlerim.Columns["Departman"].Visible = false;
            DtgGorevlerim.Columns["GorevAtanacakPersonel"].HeaderText = "GÖREV ATANAN PERSONEL";
            DtgGorevlerim.Columns["IslemAdimi"].HeaderText = "İŞLEM ADIMI";
            DtgGorevlerim.Columns["Tarih"].HeaderText = "TARİH";
            DtgGorevlerim.Columns["Sure"].HeaderText = "DURUM";
            DtgGorevlerim.Columns["YapilanIslem"].Visible = false;
            DtgGorevlerim.Columns["CalismaSuresi"].Visible = false;
            DtgGorevlerim.Columns["AbfNo"].HeaderText = "ABF NO / KİMLİK";
            DtgGorevlerim.Columns["DevamEdenGorev"].Visible = false;
            DtgGorevlerim.Columns["TamamlananGorev"].Visible = false;
            DtgGorevlerim.Columns["BeklemeSuresi"].Visible = false;

            DtgGorevlerim.Columns["SirketBolum"].Visible = false;
            DtgGorevlerim.Columns["ToplamGorevSayisi"].Visible = false;
            DtgGorevlerim.Columns["DevamEdenSureOrtGun"].Visible = false;
            DtgGorevlerim.Columns["TamamlananGorevOrtSure"].Visible = false;

            //DtgGorevlerim.Columns["DosyaYolu"].Visible = false;
            //DtgGorevlerim.Columns["IscilikSuresi"].HeaderText = "İŞÇİLİK SÜRESİ";

            TxtTop.Text = DtgGorevlerim.RowCount.ToString();

            /*Toplamlar();
            ToplamlarIslemAdimSureleri();*/
        }
        void DataDisplayIsAkis()
        {
            IsAkisgorevAtamaPersonels = gorevAtamaPersonelManager.IsAkisGorevlerimiGor(infos[1].ToString(), "İZİN");
            IsAkisgorevAtamaSatinAlma = gorevAtamaPersonelManager.IsAkisGorevlerimiGor(infos[1].ToString(), "SATIN ALMA");
            mifPersonels = gorevAtamaPersonelManager.IsAkisGorevlerimiGor(infos[1].ToString(), "MİF");

            foreach (GorevAtamaPersonel item in IsAkisgorevAtamaSatinAlma)
            {
                IsAkisgorevAtamaPersonels.Add(item);
            }

            foreach (GorevAtamaPersonel item in mifPersonels)
            {
                IsAkisgorevAtamaPersonels.Add(item);
            }

            dataBinderIsAkis.DataSource = IsAkisgorevAtamaPersonels.ToDataTable();
            DtgIsAkisGorev.DataSource = dataBinderIsAkis;

            DtgIsAkisGorev.Columns["Id"].Visible = false;
            DtgIsAkisGorev.Columns["BenzersizId"].Visible = false;
            DtgIsAkisGorev.Columns["Departman"].HeaderText = "DEPARTMAN";
            DtgIsAkisGorev.Columns["GorevAtanacakPersonel"].HeaderText = "GÖREV ATANAN PERSONEL";
            DtgIsAkisGorev.Columns["IslemAdimi"].HeaderText = "İŞLEM ADIMI";
            DtgIsAkisGorev.Columns["Tarih"].HeaderText = "TARİH";
            DtgIsAkisGorev.Columns["Sure"].HeaderText = "DURUM";
            DtgIsAkisGorev.Columns["YapilanIslem"].Visible = false;
            DtgIsAkisGorev.Columns["CalismaSuresi"].Visible = false;
            DtgIsAkisGorev.Columns["AbfNo"].HeaderText = "İŞ AKIŞ NO / ID";
            DtgIsAkisGorev.Columns["DevamEdenGorev"].Visible = false;
            DtgIsAkisGorev.Columns["TamamlananGorev"].Visible = false;
            DtgIsAkisGorev.Columns["BeklemeSuresi"].Visible = false;

            DtgIsAkisGorev.Columns["SirketBolum"].Visible = false;
            DtgIsAkisGorev.Columns["ToplamGorevSayisi"].Visible = false;
            DtgIsAkisGorev.Columns["DevamEdenSureOrtGun"].Visible = false;
            DtgIsAkisGorev.Columns["TamamlananGorevOrtSure"].Visible = false;

            //DtgGorevlerim.Columns["DosyaYolu"].Visible = false;
            //DtgGorevlerim.Columns["IscilikSuresi"].HeaderText = "İŞÇİLİK SÜRESİ";
            TxtTop3.Text = DtgIsAkisGorev.RowCount.ToString();

            /*Toplamlar();
            ToplamlarIslemAdimSureleri();*/
        }
        void DataDisplayYoneticiGorevlerim()
        {
            dataBinder.DataSource = gorevAtamaManager.GetListGorevlerim(infos[1].ToString());
            DtgYoneticiGorevlerim.DataSource = dataBinder;


            DtgYoneticiGorevlerim.Columns["Id"].Visible = false;
            DtgYoneticiGorevlerim.Columns["GorevAtananPersonel"].Visible = false;
            DtgYoneticiGorevlerim.Columns["BitisTarihi"].HeaderText = "GÖREVİN TAMAMLANMASI İSTENDİĞİ TARİH";
            DtgYoneticiGorevlerim.Columns["GorevinKonusu"].Visible = false;
            DtgYoneticiGorevlerim.Columns["GorevAtamaTarihi"].Visible = false;
            DtgYoneticiGorevlerim.Columns["GoreviAtayanPersonel"].HeaderText = "GÖREVİ ATAYAN PERSONEL";
            DtgYoneticiGorevlerim.Columns["GorevinTamamlandigiTarih"].Visible = false;
            DtgYoneticiGorevlerim.Columns["YapilanIslem"].Visible = false;
            DtgYoneticiGorevlerim.Columns["ToplamSure"].Visible = false;
            DtgYoneticiGorevlerim.Columns["Gecensure"].HeaderText = "GÖREVİN BEKLEDİĞİ SÜRE";
            DtgYoneticiGorevlerim.Columns["DosyaYolu"].Visible = false;
            DtgYoneticiGorevlerim.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";

            DtgYoneticiGorevlerim.Columns["GoreviAtayanPersonel"].DisplayIndex = 0;
            DtgYoneticiGorevlerim.Columns["GorevinKonusu"].DisplayIndex = 1;
            DtgYoneticiGorevlerim.Columns["GorevAtamaTarihi"].DisplayIndex = 2;
            DtgYoneticiGorevlerim.Columns["Gecensure"].DisplayIndex = 3;

            TxtGenelTop.Text = DtgYoneticiGorevlerim.RowCount.ToString();
            pageText2 = "YÖNETİCİ GÖREVLERİM" + "(" + TxtGenelTop.Text + " )";
            tabPage2.Text = pageText2;
        }
        void BolumGorevlerim()
        {
            List<string> personeller = new List<string>();
            List<GorevAtamaPersonel> genelList = new List<GorevAtamaPersonel>();
            List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
            List<GorevAtamaPersonel> IsAkisgorevAtamaPersonels = new List<GorevAtamaPersonel>();
            List<GorevAtamaPersonel> IsAkisgorevAtamaSatinAlma = new List<GorevAtamaPersonel>();
            List<GorevAtama> yoneticiGorevleri = new List<GorevAtama>();
            List<GorevAtamaPersonel> mifPersonels = new List<GorevAtamaPersonel>();
            List<GorevAtamaPersonel> arizaGorevAtamaAtolyePersonels = new List<GorevAtamaPersonel>();
            //MUB Prj.Dir./Loj.Dest.ve Pln./Veri Kayıt

            string[] bolum = infos[2].ToString().Split('/');
            if (bolum.Count() >= 2)
            {
                personeller = gorevAtamaPersonelManager.BolumeBagliPersoneller(bolum[1].ToString());
            }
            else
            {
                personeller = gorevAtamaPersonelManager.BolumeBagliPersoneller(bolum[0].ToString());
            }

            foreach (string item in personeller)
            {
                gorevAtamaPersonels = gorevAtamaPersonelManager.IsAkisGorevlerimiGor(item, "BAKIM ONARIM");
                arizaGorevAtamaAtolyePersonels = gorevAtamaPersonelManager.IsAkisGorevlerimiGor(item, "BAKIM ONARIM ATÖLYE");
                foreach (GorevAtamaPersonel gorevAtamaPersonel in arizaGorevAtamaAtolyePersonels)
                {
                    gorevAtamaPersonels.Add(gorevAtamaPersonel);
                }


                IsAkisgorevAtamaPersonels = gorevAtamaPersonelManager.IsAkisGorevlerimiGor(item, "İZİN");
                IsAkisgorevAtamaSatinAlma = gorevAtamaPersonelManager.IsAkisGorevlerimiGor(item, "SATIN ALMA");
                mifPersonels = gorevAtamaPersonelManager.IsAkisGorevlerimiGor(item, "MİF");

                foreach (GorevAtamaPersonel item2 in IsAkisgorevAtamaSatinAlma)
                {
                    IsAkisgorevAtamaPersonels.Add(item2);
                }

                foreach (GorevAtamaPersonel item3 in mifPersonels)
                {
                    IsAkisgorevAtamaPersonels.Add(item3);
                }

                foreach (GorevAtamaPersonel item4 in IsAkisgorevAtamaPersonels)
                {
                    gorevAtamaPersonels.Add(item4);
                }

                foreach (GorevAtamaPersonel item5 in gorevAtamaPersonels)
                {
                    genelList.Add(item5);
                }
            }

            dataBinderAtolye.DataSource = genelList.ToDataTable();
            DtgBolumGorevleri.DataSource = dataBinderAtolye;

            DtgBolumGorevleri.Columns["Id"].Visible = false;
            DtgBolumGorevleri.Columns["BenzersizId"].Visible = false;
            DtgBolumGorevleri.Columns["Departman"].HeaderText = "DEPARTMAN";
            DtgBolumGorevleri.Columns["GorevAtanacakPersonel"].HeaderText = "GÖREV ATANAN PERSONEL";
            DtgBolumGorevleri.Columns["IslemAdimi"].HeaderText = "İŞLEM ADIMI";
            DtgBolumGorevleri.Columns["Tarih"].HeaderText = "TARİH";
            DtgBolumGorevleri.Columns["Sure"].HeaderText = "DURUM";
            DtgBolumGorevleri.Columns["YapilanIslem"].Visible = false;
            DtgBolumGorevleri.Columns["CalismaSuresi"].Visible = false;
            DtgBolumGorevleri.Columns["AbfNo"].HeaderText = "İŞ AKIŞ NO / ID";
            DtgBolumGorevleri.Columns["DevamEdenGorev"].Visible = false;
            DtgBolumGorevleri.Columns["TamamlananGorev"].Visible = false;
            DtgBolumGorevleri.Columns["BeklemeSuresi"].Visible = false;

            DtgBolumGorevleri.Columns["SirketBolum"].Visible = false;
            DtgBolumGorevleri.Columns["ToplamGorevSayisi"].Visible = false;
            DtgBolumGorevleri.Columns["DevamEdenSureOrtGun"].Visible = false;
            DtgBolumGorevleri.Columns["TamamlananGorevOrtSure"].Visible = false;

            LblBolumGorevleriTop.Text = DtgBolumGorevleri.RowCount.ToString();


        }
        void MailSendMetot()
        {
            MailSend("YÖNETİCİ GÖREVLERİ", "Merhaba; \n\n" + infos[1].ToString() + " adlı personel atadığınız görevi tamamlayarak DTS ye kaydetmiştir." + "\n\nİyi Çalışmalar.", new List<string>() { mail });
        }
        public void MailSend(string subject, string body, List<string> receivers, List<string> attachments = null)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                //client.Host = "smtp.gmail.com";
                client.Host = "192.168.23.10";
                //client.Host = "smtp-mail.outlook.com ";
                client.EnableSsl = false;
                client.Timeout = 11000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //client.Credentials = new System.Net.NetworkCredential("mubotomasyon@gmail.com", "MCHT44aa:");
                client.Credentials = new System.Net.NetworkCredential("dts@mubvan.net", "123456");
                //client.Credentials = new System.Net.NetworkCredential("mucahitaydemir@basaranteknoloji.net", "Aydemir_123");
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("dts@mubvan.net", "DTS Bilgilendirme");
                mailMessage.SubjectEncoding = Encoding.UTF8;
                mailMessage.Subject = subject; //E-posta Konu Kısmı
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.Body = body; // E-posta'nın Gövde Metni
                foreach (string item in receivers)
                {
                    mailMessage.To.Add(item);
                }
                mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                if (attachments != null)
                {
                    if (attachments.Count > 0)
                    {
                        foreach (string filePath in attachments)
                        {
                            if (File.Exists(filePath))
                            {
                                Attachment attachment = new Attachment(filePath);
                                mailMessage.Attachments.Add(attachment);
                            }
                        }
                    }
                }
                client.Send(mailMessage);
            }
            catch (Exception)
            {
                //  MessageBox.Show(ex.Message);
            }
        }

    }
}