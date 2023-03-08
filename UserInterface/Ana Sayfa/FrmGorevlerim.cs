using Business;
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
        GorevAtamaManager gorevAtamaManager;
        IsAkisNoManager isAkisNoManager;

        string pageText1 = "", pageText3 = "", pageText2 = "", mail = "", dosyaYolu = "", kaynakdosyaismi = "", alinandosya = "", tamyol = "", isAkisNo = "";
        int id;
        public object[] infos;
        public FrmGorevlerim()
        {
            InitializeComponent();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            gorevAtamaManager = GorevAtamaManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
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
            contextMenuStrip2.Show();
        }

        private void FrmGorevlerim_Load(object sender, EventArgs e)
        {
            DataDisplayAriza();
            DataDisplayYoneticiGorevlerim();
            DataDisplayIsAkis();

            pageText1 = "AÇIK ARIZA GÖREVLERİM " + "( " + TxtTop.Text + " )";
            pageText2 = "YÖNETİCİ GÖREVLERİM" + "(" + TxtGenelTop.Text + " )";
            pageText3 = "İŞ AKIŞI GÖREVLERİM " + "( " + TxtTop3.Text + " )";


            tabPage1.Text = pageText1;
            tabPage2.Text = pageText2;
            tabPage3.Text = pageText3;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen Geçerli Bir Kayıt Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            string kontrol = Kontrol();

            if (kontrol!="OK")
            {
                MessageBox.Show(kontrol,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                MailBul();
                TimeSpan SonucGun = DateTime.Now - bitisTarihi;
                TimeSpan SonucSaat = DateTime.Now - bitisTarihi;
                int gun = SonucGun.TotalDays.ConInt();
                int saat = SonucSaat.TotalHours.ConInt();

                int topsaat = (gun * 24) + saat;
                if (topsaat==0)
                {
                    topsaat = 1;
                }


                GorevAtama gorevAtama = new GorevAtama(id,DateTime.Now, TxtAciklama.Text, topsaat.ToString(), dosyaYolu);

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
            if (TxtAciklama.Text=="")
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

        private void DtgGorevlerim_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderAriza.Sort = DtgGorevlerim.SortString;
        }

        private void DtgIsAkisGorev_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinderAtolye.Filter = DtgIsAkisGorev.FilterString;
            TxtTop3.Text = DtgIsAkisGorev.RowCount.ToString();
        }

        private void DtgIsAkisGorev_SortStringChanged(object sender, EventArgs e)
        {
            dataBinderAtolye.Sort = DtgIsAkisGorev.SortString;
        }

        string goreviAtayan;

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            if (dosyaYolu=="")
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
            DtgGorevlerim.Columns["AbfNo"].HeaderText = "ABF NO";

            //DtgGorevlerim.Columns["DosyaYolu"].Visible = false;
            //DtgGorevlerim.Columns["IscilikSuresi"].HeaderText = "İŞÇİLİK SÜRESİ";

            TxtTop.Text = DtgGorevlerim.RowCount.ToString();

            /*Toplamlar();
            ToplamlarIslemAdimSureleri();*/
        }
        void DataDisplayIsAkis()
        {
            IsAkisgorevAtamaPersonels = gorevAtamaPersonelManager.IsAkisGorevlerimiGor(infos[1].ToString(), "");
            dataBinderAtolye.DataSource = IsAkisgorevAtamaPersonels.ToDataTable();
            DtgIsAkisGorev.DataSource = dataBinderAtolye;

            DtgIsAkisGorev.Columns["Id"].Visible = false;
            DtgIsAkisGorev.Columns["BenzersizId"].Visible = false;
            DtgIsAkisGorev.Columns["Departman"].HeaderText = "DEPARTMAN";
            DtgIsAkisGorev.Columns["GorevAtanacakPersonel"].HeaderText = "GÖREV ATANAN PERSONEL";
            DtgIsAkisGorev.Columns["IslemAdimi"].HeaderText = "İŞLEM ADIMI";
            DtgIsAkisGorev.Columns["Tarih"].HeaderText = "TARİH";
            DtgIsAkisGorev.Columns["Sure"].HeaderText = "DURUM";
            DtgIsAkisGorev.Columns["YapilanIslem"].Visible = false;
            DtgIsAkisGorev.Columns["CalismaSuresi"].Visible = false;
            DtgIsAkisGorev.Columns["AbfNo"].HeaderText = "KİMLİK";
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
        void MailSendMetot()
        {
            MailSend("YÖNETİCİ GÖREVLERİ", "Merhaba; \n\n" + infos[1].ToString() +" adlı personel atadığınız görevi tamamlayarak DTS ye kaydetmiştir."+ "\n\nİyi Çalışmalar.", new List<string>() { mail });
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
