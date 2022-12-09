using Business.Concreate.AnaSayfa;
using Business.Concreate.DokumanYonetim;
using DataAccess.Concreate;
using Entity.AnaSayfa;
using Entity.DokumanYonetim;
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
using UserInterface.Ana_Sayfa;
using UserInterface.STS;

namespace UserInterface.DokumanYonetim
{
    public partial class FrmStandartFormEkle : Form
    {
        FormDocumentManager dokumanManager;
        FormDocument dokuman;
        BildirimYetkiManager bildirimYetkiManager;

        List<FormDocument> dokumens;
        List<FormDocument> dokumensFiltered;
        List<string> fileNames = new List<string>();
        FormDocument dokumen;
        int index, index1,formid;
        bool isAdd = true;
        string dosya;
        public object[] infos;
        string benzersiz, benzersizG, root, subdir, dosyaadi = "", kaynakdosyaismi, alinandosya, yeniad, dosyayolutam, klasoradi, personel, formadi;

        //string dosyayolu = @"C:\DTS\STANDART FORMLAR\";
        string dosyayolu = @"Z:\DTS\EĞİTİM DOKÜMANTASYON\STANDART FORMLAR\";

        public FrmStandartFormEkle()
        {
            InitializeComponent();
            dokumanManager = FormDocumentManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageFormEkle"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmStandartFormEkle_Load(object sender, EventArgs e)
        {
            BtnKaydet.Enabled = false;
            webBrowser3.Visible = false;
            Personel();
            webBrowser3.Visible = true;
            //webBrowser2.Visible = false;
            WebBrowserGeri();
            DtgDoldur();
        }
        void Personel()
        {
            personel = infos[1].ToString();
        }

        public void DtgDoldur()
        {
            dokumens = dokumanManager.GetList();
            dokumensFiltered = dokumens;
            dataBinder.DataSource = dokumens.ToDataTable();
            DtgDokumanListesi.DataSource = dataBinder;
            DataDisplay();
        }

        void Temizle()
        {
            CmbTur.Text = ""; TxtNumarası.Clear(); TxtTanimi.Clear(); TxtRev.Clear(); CmbK.Text = "";
        }

        private void FillTools()
        {
            Temizle();

            if (dokumensFiltered == null)
            {
                return;
            }
            if (dokumensFiltered.Count == 0)
            {
                return;
            }
            if (dokumensFiltered.Count > 0)
            {

                FormDocument item = dokumensFiltered[0];

                CmbTur.Text = item.Tur;
                TxtNumarası.Text = item.Numarasi;
                TxtTanimi.Text = item.Tanimi;
                TxtRev.Text = item.Revizyon;
                DtgYayin.Value = item.Yayintarihi;
                DtgOnay.Value = item.Onaytarihi;

                dokumensFiltered = dokumens;
            }
        }

        void DataDisplay()
        {
            DtgDokumanListesi.Columns["Id"].Visible = false;
            DtgDokumanListesi.Columns["Tur"].HeaderText = "DOKÜMAN TÜRÜ";
            DtgDokumanListesi.Columns["Numarasi"].HeaderText = "DOKÜMAN NUMARASI";
            DtgDokumanListesi.Columns["Tanimi"].HeaderText = "DOKÜMAN TANIMI";
            DtgDokumanListesi.Columns["Revizyon"].HeaderText = "DOKÜMAN REVİZYONU";
            DtgDokumanListesi.Columns["OnayTarihi"].HeaderText = "DOKÜMAN ONAY TARİHİ";
            DtgDokumanListesi.Columns["YayinTarihi"].HeaderText = "DOKÜMAN YAYIN TARİHİ";
            DtgDokumanListesi.Columns["Benzersiz"].Visible = false;
            DtgDokumanListesi.Columns["Dosyayolu"].Visible = false;
        }

        private void DtgDokumanListesi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgDokumanListesi.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosya = DtgDokumanListesi.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            benzersizG = DtgDokumanListesi.CurrentRow.Cells["Benzersiz"].Value.ToString();
            dokumensFiltered = dokumens.Where(x => x.Benzersiz == benzersizG).ToList();
            formadi = DtgDokumanListesi.CurrentRow.Cells["Tanimi"].Value.ToString();
            formid = DtgDokumanListesi.CurrentRow.Cells["Id"].Value.ConInt();
            WebBrowser();
            FillTools();
        }

        private void WebBrowser()
        {
            webBrowser2.Navigate(dosya);
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            if (CmbDokumanTur.Text == "")
            {
                MessageBox.Show("Lütfen Döküman Türünü Giriniz.");
            }
            if (TxtDokumanNumarasi.Text == "")
            {
                MessageBox.Show("Lütfen Döküman Numarasını Giriniz.");
            }
            if (TxtDokumanTanim.Text == "")
            {
                MessageBox.Show("Lütfen Döküman Tanımını Giriniz.");
            }
            if (TxtRevizyon.Text == "")
            {
                MessageBox.Show("Lütfen Döküman Revizyonunu Giriniz.");
            }

            dosyaadi = "MP-" + CmbT.Text + "-" + TxtDokumanNumarasi.Text + " " + TxtDokumanTanim.Text + " REV " + "(" + TxtRevizyon.Text + ")";
            klasoradi = dosyaadi;
            if (dosyaadi == "")
            {
                MessageBox.Show("Lütfen Tüm Bilgileri Girdiğinizden Emin Olunuz.");
                return;
            }
            root = @"Z:\DTS";
            subdir = @"Z:\DTS\EĞİTİM DOKÜMANTASYON\STANDART FORMLAR\";
            /*root = @"C:\DTS";
            subdir = @"C:\DTS\STANDART FORMLAR\";*/
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(subdir + klasoradi))
            {
                Directory.CreateDirectory(subdir + klasoradi);
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi = dosyaadi;
                alinandosya = openFileDialog1.FileName.ToString();

                if (Path.GetExtension(alinandosya) == ".doc" || Path.GetExtension(alinandosya) == ".pdf" || Path.GetExtension(alinandosya) == ".docx" || 
                    Path.GetExtension(alinandosya) == ".xls" || Path.GetExtension(alinandosya) == ".xlsx")
                {
                    if (Path.GetExtension(alinandosya) == ".doc")
                    {
                        yeniad = dosyaadi + ".doc";
                    }
                    if (Path.GetExtension(alinandosya) == ".pdf")
                    {
                        yeniad = dosyaadi + ".pdf";
                    }
                    if (Path.GetExtension(alinandosya) == ".docx")
                    {
                        yeniad = dosyaadi + ".docx";
                    }
                    if (Path.GetExtension(alinandosya) == ".xls")
                    {
                        yeniad = dosyaadi + ".xls";
                    }
                    if (Path.GetExtension(alinandosya) == ".xlsx")
                    {
                        yeniad = dosyaadi + ".xlsx";
                    }

                    if (!Directory.Exists(subdir + klasoradi + "\\" + yeniad))
                    {
                        string silinecek = subdir + klasoradi + "\\" + yeniad;
                        File.Delete(silinecek);
                        // EĞER FARKLI Bİ YERE KOPLAYANACAKSA
                    }
                    File.Copy(alinandosya, subdir + klasoradi + "\\" + yeniad);
                    dosyayolutam = subdir + klasoradi + "\\" + yeniad;
                }
                else
                {
                    MessageBox.Show("Lütfen .doc, .pdf, .docx, .xls, .xlsx  formatında olan bir dosyayı seçiniz.");
                }
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            WebBrowser1();
            BtnKaydet.Enabled = true;
        }

        private void DtgDosyaGuncelle_Click(object sender, EventArgs e)
        {
            if (CmbTur.Text == "")
            {
                MessageBox.Show("Lütfen Döküman Türünü Giriniz.");
            }
            if (TxtNumarası.Text == "")
            {
                MessageBox.Show("Lütfen Döküman Numarasını Giriniz.");
            }
            if (TxtTanimi.Text == "")
            {
                MessageBox.Show("Lütfen Döküman Tanımını Giriniz.");
            }
            if (TxtRev.Text == "")
            {
                MessageBox.Show("Lütfen Döküman Revizyonunu Giriniz.");
            }
            dosyaadi = "MP" + CmbT.Text + "-" + TxtNumarası.Text + "-" + TxtTanimi.Text + "-REV" + "(" + TxtRev.Text + ")";
            klasoradi = dosyaadi;
            if (dosyaadi == "")
            {
                MessageBox.Show("Lütfen Tüm Bilgileri Girdiğinizden Emin Olunuz.");
                return;
            }
            root = @"Z:\DTS";
            subdir = @"Z:\DTS\EĞİTİM DOKÜMANTASYON\STANDART FORMLAR\";
            /*root = @"C:\DTS";
            subdir = @"C:\DTS\STANDART FORMLAR\";*/
            if (!Directory.Exists(root))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.");
                return;
            }
            if (!Directory.Exists(subdir))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.");
                return;
            }
            if (!Directory.Exists(dosya))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.");
                return;
            }
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi = dosyaadi;
                alinandosya = openFileDialog2.FileName.ToString();

                if (Path.GetExtension(alinandosya) == ".doc" || Path.GetExtension(alinandosya) == ".pdf" || (Path.GetExtension(alinandosya) == ".docx"))
                {
                    if (Path.GetExtension(alinandosya) == ".doc")
                    {
                        yeniad = dosyaadi + ".doc";
                    }
                    if (Path.GetExtension(alinandosya) == ".pdf")
                    {
                        yeniad = dosyaadi + ".pdf";
                    }
                    if (Path.GetExtension(alinandosya) == ".docx")
                    {
                        yeniad = dosyaadi + ".docx";
                    }

                    if (!Directory.Exists(subdir + klasoradi + "\\" + yeniad))
                    {
                        string silinecek = subdir + klasoradi + "\\" + yeniad;
                        File.Delete(silinecek);
                        // EĞER FARKLI Bİ YERE KOPLAYANACAKSA
                    }
                    File.Copy(alinandosya, subdir + klasoradi + "\\" + yeniad);
                    dosyayolutam = subdir + klasoradi + "\\" + yeniad;
                }
                else
                {
                    MessageBox.Show("Lütfen .doc,.docx veya .pdf formatında olan bir dosyayı seçiniz.");
                }
                WebBrowser();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void TxtDocumentNo_TextChanged(object sender, EventArgs e)
        {
            string documentNo = TxtDocumentNo.Text;

            if (string.IsNullOrEmpty(documentNo))
            {
                dokumensFiltered = dokumens;
                dataBinder.DataSource = dokumens.ToDataTable();
                DtgDokumanListesi.DataSource = dataBinder;
                return;
            }

            dataBinder.DataSource = dokumensFiltered.Where(x => x.Numarasi.ToLower().Contains(documentNo.ToLower())).ToList().ToDataTable();
            DtgDokumanListesi.DataSource = dataBinder;
            dokumensFiltered = dokumens;
        }
        private void TxtDocumentName_TextChanged(object sender, EventArgs e)
        {
            string documentname = TxtDocumentName.Text;

            if (string.IsNullOrEmpty(documentname))
            {
                dokumensFiltered = dokumens;
                dataBinder.DataSource = dokumens.ToDataTable();
                DtgDokumanListesi.DataSource = dataBinder;
                return;
            }
            dataBinder.DataSource = dokumensFiltered.Where(x => x.Tanimi.ToLower().Contains(documentname.ToLower())).ToList().ToDataTable();
            DtgDokumanListesi.DataSource = dataBinder;
            dokumensFiltered = dokumens;
        }
        private void DtgDokumanListesi_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgDokumanListesi.SortString;
        }
        private void DtgDokumanListesi_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgDokumanListesi.FilterString;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            isAdd = false;
            if (fileNames.Count == 0)
            {
                return;
            }
            webBrowser3.Navigate(fileNames[fileNames.Count - 1]);
            fileNames.Remove(fileNames[fileNames.Count - 1]);
        }

        private void webBrowser3_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (webBrowser3.Url != null)
            {
                if (isAdd)
                {
                    fileNames.Add(webBrowser3.Url.LocalPath);
                }
                isAdd = true;
            }
        }

        private void BtnFormSil_Click(object sender, EventArgs e)
        {
            if (benzersizG == "")
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir Form Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(formadi + " İsimli Formu Silmek İstediğinize Emin Misiniz?\nBu İşlem Geri Alınamaz!", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = dokumanManager.Delete(formid);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Directory.Delete(dosya, true);
                MessageBox.Show("Silme İşlemi Başarıyla Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }
        }
        void TemizleGuncelle()
        {
            CmbTur.Text = ""; CmbK.Text = ""; TxtNumarası.Clear(); TxtTanimi.Clear(); TxtRev.Clear(); webBrowser2.Navigate("");
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            dokumen = null;
            dokumen = new FormDocument(CmbTur.Text, TxtNumarası.Text, TxtTanimi.Text, TxtRev.Text, DtgOnay.Value, DtgYayin.Value, dosya, benzersizG);
            DialogResult dr = MessageBox.Show("Formu Güncellemek İstediğinize Emin Misiinz?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (dokumen == null)
                {
                    MessageBox.Show("Lütfen Tüm Bilgileri Girdiğinizden Emin Olunuz!");
                    return;
                }
                MessageBox.Show(dokumanManager.Update(dokumen));
                Task.Factory.StartNew(() => MailSendMetotG());
            }
            DtgDoldur();
            Temizle();
        }
        private void CmbDokumanTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbDokumanTur.SelectedIndex;
            CmbT.SelectedIndex = index;
        }
        private void CmbTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            index1 = CmbTur.SelectedIndex;
            CmbK.SelectedIndex = index1;
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            benzersiz = Guid.NewGuid().ToString();
            dokuman = null;
            dokuman = new FormDocument(CmbDokumanTur.Text, TxtDokumanNumarasi.Text, TxtDokumanTanim.Text, TxtRevizyon.Text, DtOnayTarihi.Value, DtYayinTarihi.Value, subdir + klasoradi, benzersiz);
            string messege = dokumanManager.Add(dokuman);
            MessageBox.Show(messege);
            WebBrowserLogin();
            string mesaj = BildirimKayit();
            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Task.Factory.StartNew(() => MailSendMetot());
            TemizleKaydet();
        }
        string BildirimKayit()
        {
            string[] array = new string[8];

            array[0] = "Standart Form Ekleme"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = TxtDokumanTanim.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "tanımlı standart formu"; // Bildirim türü
            array[4] = DtYayinTarihi.Text + " tarihinden itibaren"; // İÇERİK
            array[5] = "Standart formlara kaydetmiştir!";
            array[6] = "";

            BildirimYetki bildirimYetki = bildirimYetkiManager.Get(infos[1].ToString());
            if (bildirimYetki == null)
            {
                array[7] = infos[0].ToString();
            }
            else
            {
                array[7] = bildirimYetki.SorumluId + infos[0].ToString();
            }

            string mesaj = FrmHelper.BildirimGonder(array, array[7]);
            return mesaj;
        }
        void TemizleKaydet()
        {
            CmbDokumanTur.Text = ""; CmbT.Text = ""; TxtDokumanNumarasi.Clear(); TxtDokumanTanim.Clear(); TxtRevizyon.Clear();
            webBrowser3.Navigate("");
        }
        private void WebBrowser1()
        {
            webBrowser3.Navigate(dosyayolu);
        }
        private void WebBrowserLogin()
        {
            webBrowser3.Navigate(dosyayolu);
        }
        private void WebBrowserGeri()
        {
            webBrowser3.Navigate(dosyayolu);
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
        void MailSendMetot()
        {
            MailSend("(DOKÜMAN YÖNETİM SİSTEMİ) DOKÜMAN EKLEME", "Merhaba; \n\n" + dosyaadi + " Adlı doküman, onaylanarak DÖKÜMAN YÖNETİM SİSTEM'ine eklenmiştir. " +
                "\nDökümanı bu sistem üzerinden izleyebilirsiniz." + "\n\nİyi Çalışmalar.", new List<string>() { "resulgunes@mubvan.net",
                    "emelayhan@mubvan.net",
                    "kadirkoc@mubvan.net",
                    "ahmetfatihdemirol@mubvan.net",
                    "burakayargil@mubvan.net",
                    "cetinmurat@mubvan.net",
                    "ebubekirkeles@mubvan.net",
                    "gulsahotaci@mubvan.net",
                    "mehmetyildirim@mubvan.net",
                    "mucahitaydemir@mubvan.net",
                    "muhammetpolat@mubvan.net",
                    "muratdemirtas@mubvan.net",
                    "mustafauzun@mubvan.net",
                    "muzaffermutlu@mubvan.net",
                    "ridvankoc@mubvan.net",
                    "sametatacan@mubvan.net",
                    "serifenurgunes@mubvan.net",
                    "mehmetsenol@mubvan.net" });
        }
        void MailSendMetotG()
        {
            MailSend("(DOKÜMAN YÖNETİM SİSTEMİ) DOKÜMAN GÜNCELLEME", "Merhaba; \n\n" + dosyaadi + " Adlı doküman, onaylanarak DÖKÜMAN YÖNETİM SİSTEM'ine Güncellenmiştir. " +
                "\nDökümanı bu sistem üzerinden izleyebilirsiniz." + "\n\nİyi Çalışmalar.", new List<string>() { "resulgunes@mubvan.net",
                    "emelayhan@mubvan.net",
                    "kadirkoc@mubvan.net",
                    "ahmetfatihdemirol@mubvan.net",
                    "burakayargil@mubvan.net",
                    "cetinmurat@mubvan.net",
                    "ebubekirkeles@mubvan.net",
                    "gulsahotaci@mubvan.net",
                    "mehmetyildirim@mubvan.net",
                    "mucahitaydemir@mubvan.net",
                    "muhammetpolat@mubvan.net",
                    "muratdemirtas@mubvan.net",
                    "mustafauzun@mubvan.net",
                    "muzaffermutlu@mubvan.net",
                    "ridvankoc@mubvan.net",
                    "sametatacan@mubvan.net",
                    "serifenurgunes@mubvan.net",
                    "mehmetsenol@mubvan.net" });
        }
    }
}
