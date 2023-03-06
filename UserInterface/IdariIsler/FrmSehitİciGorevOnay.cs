using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
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

namespace UserInterface.IdariIsler
{
    public partial class FrmSehitİciGorevOnay : Form
    {

        SehiriciGorevManager sehiriciGorevManager;
        IdariIslerLogManager logManager;

        List<SehiriciGorev> sehiriciGorevs;

        public object[] infos;
        int id, isakisnoamir;
        public FrmSehitİciGorevOnay()
        {
            InitializeComponent();
            sehiriciGorevManager = SehiriciGorevManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
        }

        private void FrmSehitİciGorevOnay_Load(object sender, EventArgs e)
        {
            SehirIciGorevAmir();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSehitIciGorevOnay"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void SehirIciGorevAmir()
        {
            sehiriciGorevs = sehiriciGorevManager.AmirOnay(infos[0].ConInt(), "2.ADIM:GÖREV PERSONEL TARAFINDAN ONAYLANDI.");
            dataBinder.DataSource = sehiriciGorevs.ToDataTable();
            DtgSehirIciAmir.DataSource = dataBinder;

            DtgSehirIciAmir.Columns["Id"].Visible = false;
            DtgSehirIciAmir.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgSehirIciAmir.Columns["Proje"].HeaderText = "PROJE";
            DtgSehirIciAmir.Columns["Gidilecekyer"].HeaderText = "GİDİLECEK YER";
            DtgSehirIciAmir.Columns["Gorevinkonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgSehirIciAmir.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgSehirIciAmir.Columns["Bitistarihi"].Visible = false;
            DtgSehirIciAmir.Columns["Toplamsure"].Visible = false;
            DtgSehirIciAmir.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgSehirIciAmir.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgSehirIciAmir.Columns["Masrafyerno"].HeaderText = "MASRAF YERİ NO";
            DtgSehirIciAmir.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgSehirIciAmir.Columns["Islemadimi"].HeaderText = "İŞLEM ADIMI";
            DtgSehirIciAmir.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgSehirIciAmir.Columns["Personelid"].Visible = false;
            DtgSehirIciAmir.Columns["Sayfa"].Visible = false;
            DtgSehirIciAmir.Columns["Gecensure"].Visible = false;
            TxtTopAmir.Text = DtgSehirIciAmir.RowCount.ToString();
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Görev Kaydı Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Görevi Onaylamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string sehiricigorev = "3.ADIM:GÖREV AMİR TARAFINDAN ONAYLANDI";
                sehiriciGorevManager.GorevOnay(sehiricigorev, id);
                MessageBox.Show("İşlem Başarıyla Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Task.Factory.StartNew(() => MailSendMetotOnay());
                CreateLogAmirOnay();
                SehirIciGorevAmir();
                id = 0;
            }
            void CreateLogAmirOnay()
            {
                string sayfa = "ŞEHİR İÇİ GÖREV";
                SehiriciGorev gorev = sehiriciGorevManager.Get(isakisnoamir);
                int benzersizid = gorev.Id;
                string islem = "ŞEHİR İÇİ GÖREV AMİR TARAFINDAN ONAYLANDI.";
                string islemyapan = infos[1].ToString();
                IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
                logManager.Add(log);
            }
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
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
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
        void MailSendMetotOnay()
        {
            MailSend("ŞEHİR İÇİ GÖREV", "Merhaba; \n\n" + isakisnoamir + " İş Akış Numaralı Görev Başarıyla Onaylanmıştır." + "\n\nİyi Çalışmalar.", new List<string>() { infos[7].ToString() });
        }

        private void BtnTumunuOnayla_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Görüntülenen tüm kayıtları toplu olarak onaylamak isteiğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in DtgSehirIciAmir.Rows)
                {
                    string sehiricigorev = "3.ADIM:GÖREV AMİR TARAFINDAN ONAYLANDI";
                    sehiriciGorevManager.GorevOnay(sehiricigorev, item.Cells["Id"].Value.ConInt());
                    CreateLogAmirOnay(item.Cells["Isakisno"].Value.ConInt());
                }
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SehirIciGorevAmir();
            }
        }
        void CreateLogAmirOnay(int isAkisNo)
        {
            string sayfa = "ŞEHİR İÇİ GÖREV";
            SehiriciGorev gorev = sehiriciGorevManager.Get(isAkisNo);
            int benzersizid = gorev.Id;
            string islem = "ŞEHİR İÇİ GÖREV AMİR TARAFINDAN ONAYLANDI.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }

        private void BtnReddet_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Görev Kaydı Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isakisnoamir + " Nolu Görevi Reddetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string sehiricigorev = "GÖREV " + infos[1].ToString() + " TARAFINDAN REDDEDİLDİ";
                SehiriciGorev sehiriciGorev = new SehiriciGorev(isakisnoamir, DateTime.Now, "0 Saat");
                sehiriciGorevManager.GorevTamamla(sehiriciGorev, isakisnoamir);
                sehiriciGorevManager.GorevOnay(sehiricigorev, id);
                MessageBox.Show("İşlem Başarıyla Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SehirIciGorevAmir();
                CreateLogAmirRed();
                Task.Factory.StartNew(() => MailSendMetotRetAmir());
                id = 0;
            }
        }

        void MailSendMetotRetAmir()
        {
            MailSend("ŞEHİR İÇİ GÖREV", "Merhaba; \n\n" + isakisnoamir + " İş Akış Numaralı Görev Reddedilmiştir." + "\n\nİyi Çalışmalar.", new List<string>() { infos[7].ToString() });
        }

        void CreateLogAmirRed()
        {
            string sayfa = "ŞEHİR İÇİ GÖREV";
            SehiriciGorev gorev = sehiriciGorevManager.Get(isakisnoamir);
            int benzersizid = gorev.Id;
            string islem = "ŞEHİR İÇİ GÖREV AMİR TARAFINDAN REDDEDİLDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }

        private void DtgSehirIciAmir_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgSehirIciAmir.FilterString;
            TxtTopAmir.Text = DtgSehirIciAmir.RowCount.ToString();
        }

        private void DtgSehirIciAmir_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgSehirIciAmir.SortString;
        }

        private void DtgSehirIciAmir_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgSehirIciAmir.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            id = DtgSehirIciAmir.CurrentRow.Cells["Id"].Value.ConInt();
            isakisnoamir = DtgSehirIciAmir.CurrentRow.Cells["Isakisno"].Value.ConInt();
        }
    }
}
