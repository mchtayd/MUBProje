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
using UserInterface.STS;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmGorevAta : Form
    {
        PersonelKayitManager kayitManager;
        GorevAtamaManager gorevAtamaManager;
        IsAkisNoManager isAkisNoManager;

        List<GorevAtama> gorevAtamas = new List<GorevAtama>();
        List<GorevAtama> gorevAtamasTamamlananlar = new List<GorevAtama>();

        public string gorevinTanimi, islemAdimi, sayfa, dosyaYolu = "", alinandosya;
        public object[] infos;

        bool dosyaEkle = false;
        string isAkisNo, kaynakdosyaismi;
        int id;

        public FrmGorevAta()
        {
            InitializeComponent();
            kayitManager = PersonelKayitManager.GetInstance();
            gorevAtamaManager = GorevAtamaManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
        }

        private void FrmGorevAta_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            Personeller();
            DataDisplay();
            DataDisplayTamamlananlar();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string mesaj = Kontrol();
            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Görev Atama İşlemini Tamamlamak İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            
            if (dr==DialogResult.Yes)
            {
                MailBul();

                if (dosyaEkle == false)
                {
                    DialogResult dialogResult = MessageBox.Show("Herhangi Bir Dosya Eklemediniz!\nYinede Devam Etmek İstiyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (dialogResult==DialogResult.No)
                    {
                        return;
                    }
                }

                GorevAtama gorevAtama = new GorevAtama(isAkisNo.ConInt(), CmbPersoneller.Text, DtgBitis.Value, TxtAciklama.Text, DateTime.Now, infos[1].ToString(), dosyaYolu);

                string control = gorevAtamaManager.Add(gorevAtama);
                if (control!="OK")
                {
                    MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Task.Factory.StartNew(() => MailSendMetot());
                IsAkisNo();
                dosyaEkle = false;
                MessageBox.Show("Bilgiler BAşarıyla Kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataDisplay();
                Temizle();
                return;
            }

        }
        string mail = "";
        void MailBul()
        {
            PersonelKayit personelKayit = kayitManager.Get(0, CmbPersoneller.Text);
            mail = personelKayit.Oficemail;
        }
        void Temizle()
        {
            CmbPersoneller.SelectedValue = ""; TxtAciklama.Clear();
            TxtGorevinKonusu.Clear(); TxtYapilanIslem.Clear();
            webBrowser1.Navigate("");
        }

        void Personeller()
        {
            CmbPersoneller.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersoneller.ValueMember = "Id";
            CmbPersoneller.DisplayMember = "Adsoyad";
            CmbPersoneller.SelectedValue = -1;
        }
        string Kontrol()
        {
            if (CmbPersoneller.Text=="")
            {
                return "Lütfen Görev Atanacak Personel Bilgisini Doldurunuz!";
            }
            if (TxtAciklama.Text=="")
            {
                return "Lütfen Görevin Konusu Bilgisini Doldurunuz!";
            }
            return "OK";
        }
        void DataDisplay()
        {
            gorevAtamas = gorevAtamaManager.GetList("DEVAM EDENLER", infos[1].ToString());
            dataBinder.DataSource = gorevAtamas.ToDataTable();
            DtgList.DataSource = dataBinder;


            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["GorevAtananPersonel"].HeaderText = "GÖREV ATANAN PERSONEL";
            DtgList.Columns["BitisTarihi"].HeaderText = "GÖREVİN TAMAMLANMASINI İSTEDİĞİ TARİH";
            DtgList.Columns["GorevinKonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgList.Columns["GorevAtamaTarihi"].HeaderText = "GÖREV ATAMA TARİHİ";
            DtgList.Columns["GoreviAtayanPersonel"].Visible = false;
            DtgList.Columns["GorevinTamamlandigiTarih"].Visible = false;
            DtgList.Columns["YapilanIslem"].Visible = false;
            DtgList.Columns["ToplamSure"].Visible = false;
            DtgList.Columns["Gecensure"].HeaderText = "GÖREVİN BEKLEDİĞİ SÜRE";
            DtgList.Columns["DosyaYolu"].Visible = false;

            DtgList.Columns["GorevAtananPersonel"].DisplayIndex = 0;
            DtgList.Columns["GorevinKonusu"].DisplayIndex = 1;
            DtgList.Columns["GorevAtamaTarihi"].DisplayIndex = 2;
            DtgList.Columns["Gecensure"].DisplayIndex = 3;

            LblTop.Text = DtgList.RowCount.ToString();
        }
        void DataDisplayTamamlananlar()
        {

            gorevAtamasTamamlananlar = gorevAtamaManager.GetListTamamlananlar(infos[1].ToString());
            dataBinder2.DataSource = gorevAtamasTamamlananlar.ToDataTable();
            DtgListTamamlananlar.DataSource = dataBinder2;

            DtgListTamamlananlar.Columns["Id"].Visible = false;
            DtgListTamamlananlar.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgListTamamlananlar.Columns["GorevAtananPersonel"].HeaderText = "GÖREV ATANAN PERSONEL";
            DtgListTamamlananlar.Columns["BitisTarihi"].HeaderText = "TAMAMLANMASI İSTENEN TARİH";
            DtgListTamamlananlar.Columns["GorevinKonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgListTamamlananlar.Columns["GorevAtamaTarihi"].HeaderText = "GÖREV ATAMA TARİHİ";
            DtgListTamamlananlar.Columns["GoreviAtayanPersonel"].HeaderText = "GÖREVİ ATAYAN PERSONEL";
            DtgListTamamlananlar.Columns["GorevinTamamlandigiTarih"].HeaderText = "GÖREVİN TAMAMLANDIĞI TARİH";
            DtgListTamamlananlar.Columns["YapilanIslem"].HeaderText = "YAPILAN İŞLEM";
            DtgListTamamlananlar.Columns["ToplamSure"].HeaderText = "TOPLAM SÜRE SAAT";
            DtgListTamamlananlar.Columns["Gecensure"].Visible = false;
            DtgListTamamlananlar.Columns["DosyaYolu"].Visible = false;

            /*DtgListTamamlananlar.Columns["GorevAtananPersonel"].DisplayIndex = 0;
            DtgListTamamlananlar.Columns["GorevinKonusu"].DisplayIndex = 1;
            DtgListTamamlananlar.Columns["GorevAtamaTarihi"].DisplayIndex = 2;
            DtgListTamamlananlar.Columns["Gecensure"].DisplayIndex = 3;*/

            LblTop2.Text = DtgListTamamlananlar.RowCount.ToString();
        }

        private void DtgListTamamlananlar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListTamamlananlar.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            TxtGorevinKonusu.Text = DtgListTamamlananlar.CurrentRow.Cells["GorevinKonusu"].Value.ToString();
            TxtYapilanIslem.Text = DtgListTamamlananlar.CurrentRow.Cells["YapilanIslem"].Value.ToString();
            dosyaYolu = DtgListTamamlananlar.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtGorevinKonusu.Clear(); TxtYapilanIslem.Clear();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            LblTop.Text = DtgList.RowCount.ToString();

        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void DtgListTamamlananlar_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Filter = DtgListTamamlananlar.FilterString;
            LblTop2.Text = DtgListTamamlananlar.RowCount.ToString();
        }

        private void DtgListTamamlananlar_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Sort = DtgListTamamlananlar.SortString;
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            TxtGorevinKonusu.Clear(); TxtYapilanIslem.Clear();
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            TxtGorevinKonusu.Text = DtgList.CurrentRow.Cells["GorevinKonusu"].Value.ToString();
            dosyaYolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();

            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            isAkisNo = isAkis.Id.ToString();
        }
        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            if (CmbPersoneller.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Görev Atanacak Personel Bilgisini Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (TxtAciklama.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Görevin Konusu Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IsAkisNo();
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
                dosyaEkle = true;
            }
        }

        void MailSendMetot()
        {
            MailSend("YÖNETİCİ GÖREVLERİ", "Merhaba; \n\n" + infos[1].ToString() + " tarafından yönetici görev ataması yapılmıştır.Süreci DTS üzerinden takip edebilirsiniz." + "\n\nİyi Çalışmalar.", new List<string>() { mail });
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
