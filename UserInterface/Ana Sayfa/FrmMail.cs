using Business.Concreate;
using Business.Concreate.STS;
using Entity;
using Entity.STS;
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
    public partial class FrmMail : Form
    {
        public List<SatMail> satMailList;
        SatDataGridview1Manager satDataGridview1Manager;
        int rowIndex;
        bool isComplete = false;

        public FrmMail()
        {
            InitializeComponent();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
        }

        private void FrmMail_Load(object sender, EventArgs e)
        {
            rowIndex = 0;
            satMailList = SatMailManager.GetInstance().GetList();
            if (satMailList.Count == 0)
            {
                MessageBox.Show("Listede SAT Verisi Bulunmadığı için Mail İçeriği Oluşturulamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblFrom.Text = "mehmetsenol@mubvan.net";
            txtSubject.Text = "SAT ONAYLARI";
            txtTo.Text = "mehmetsenol@mubvan.net";
            txtCc.Text = "mehmetsenol@mubvan.net";
            SetDatagrid(satMailList);
            webContent.DocumentText = Html_Content(DtgForHtml, satMailList);
        }

        private void BtnMailGonder_Click(object sender, EventArgs e)
        {
            List<string> alicilar = txtTo.Text.Split(',').ToList();
            List<string> bilgi = txtCc.Text.Split(',').ToList();

            MailSendHtml(txtSubject.Text, webContent.DocumentText,
                alicilar, // Alıcı
                bilgi); // Bilgi

            foreach (DataGridViewRow item in DtgForHtml.Rows)
            {
                string siparisNo = item.Cells["SiparisNo"].Value.ToString();
                string mesaj = satDataGridview1Manager.MailDurumuGuncelle(siparisNo);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            /*MailSendHtml(txtSubject.Text,
                 webContent.DocumentText,
                alicilar, // Alıcı
                bilgi); // Bilgi*/
        }

        public void MailSendHtml(string subject, string body, List<string> receivers, List<string> bilgiAlicilar = null, List<string> attachments = null)
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
                //client.Credentials = new System.Net.NetworkCredential("gulsahotaci@basaranteknoloji.net", "Gulsah_123");
                client.Credentials = new System.Net.NetworkCredential("dts@mubvan.net", "123456");
                //client.Credentials = new System.Net.NetworkCredential("mucahitaydemir@basaranteknoloji.net", "Aydemir_123");
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("dts@mubvan.net", "DTS Bilgilendirme");
                mailMessage.SubjectEncoding = Encoding.UTF8;
                mailMessage.Subject = subject; //E-posta Konu Kısmı
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = body; // E-posta'nın Gövde Metni
                foreach (string item in receivers)
                {
                    mailMessage.To.Add(item);
                }
                foreach (string bilgi in bilgiAlicilar)
                {
                    mailMessage.CC.Add(bilgi);
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
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        void SetDatagrid(List<SatMail> satMails)
        {
            if (satMails == null)
            {
                MessageBox.Show("Hata");
            }
            if (satMails.Count == 0)
            {
                MessageBox.Show("Hata");
            }

            DtgForHtml.DataSource = satMails;
            DtgForHtml.Columns["UsBolgesi"].Visible = false;
            DtgForHtml.Columns["Gerekce"].Visible = false;

            if (satMails[0].Firma2.Length == 0)
            {
                DtgForHtml.Columns["Ibf"].Visible = false;
                DtgForHtml.Columns["Itf"].Visible = false;
                DtgForHtml.Columns["Firma2"].Visible = false;
            }
            if (satMails[0].Firma3.Length == 0)
            {
                DtgForHtml.Columns["Ubf"].Visible = false;
                DtgForHtml.Columns["Utf"].Visible = false;
                DtgForHtml.Columns["Firma3"].Visible = false;
            }
            DtgForHtml.Columns["Siparisno"].Visible = false;
            DtgForHtml.Columns["Bbf"].HeaderText = "1-B.Fiyat";
            DtgForHtml.Columns["Btf"].HeaderText = "1-T.Fiyat";
            DtgForHtml.Columns["Ibf"].HeaderText = "2-B.Fiyat";
            DtgForHtml.Columns["Itf"].HeaderText = "2-T.Fiyat";
            DtgForHtml.Columns["Ubf"].HeaderText = "3-B.Fiyat";
            DtgForHtml.Columns["Utf"].HeaderText = "3-T.Fiyat";
            DtgForHtml.Columns["Firma1"].HeaderText = "Birinci Firma";
            DtgForHtml.Columns["Firma2"].HeaderText = "İkinci Firma";
            DtgForHtml.Columns["Firma3"].HeaderText = "Üçüncü Firma";
            DtgForHtml.Columns["StokNo"].HeaderText = "Stok No";
            DtgForHtml.Columns["Tanim"].HeaderText = "Tanım";
            DtgForHtml.Columns["SatNo"].HeaderText = "SAT NO";

            DtgForHtml.Columns["StokNo"].DisplayIndex = 1;
            DtgForHtml.Columns["Tanim"].DisplayIndex = 2;
            DtgForHtml.Columns["Miktar"].DisplayIndex = 3;
            DtgForHtml.Columns["Birim"].DisplayIndex = 4;
            DtgForHtml.Columns["Firma1"].DisplayIndex = 5;
            DtgForHtml.Columns["Bbf"].DisplayIndex = 6;
            DtgForHtml.Columns["Btf"].DisplayIndex = 7;
            DtgForHtml.Columns["Firma2"].DisplayIndex = 8;
            DtgForHtml.Columns["Ibf"].DisplayIndex = 9;
            DtgForHtml.Columns["Itf"].DisplayIndex = 10;
            DtgForHtml.Columns["Firma3"].DisplayIndex = 11;
            DtgForHtml.Columns["Ubf"].DisplayIndex = 12;
            DtgForHtml.Columns["Utf"].DisplayIndex = 13;
            DtgForHtml.Columns["SatNo"].DisplayIndex = 14;
        }

        public string Html_Content(DataGridView dg, List<SatMail> satMails)
        {
            StringBuilder strB = new StringBuilder();
            //create html & table
            strB.AppendLine("<html><head><meta charset=utf-8><style>table{padding:10px;} th,td{padding:8px;}</style></head><body>");
            strB.AppendLine(
            "<p>Erkan Bey Merhaba, <br><br> Aşağıda bilgileri verilen arızalar için fiyat teklifi alınmıştır.Bir sonraki ayda tarafınıza fatura edilecektir.Alım yapmak için onayınızı rica ediyorum. <br><br> İyi Çalışmalar.<br><br>");

            for (int i = 0; i < satMails.Count; i++)
            {
                strB.AppendLine(
                  "<b>Üs Bölgesi :</b> " + satMails[i].UsBolgesi + "<br><br>" +
                  "<b>Gerekçe    :</b> " + satMails[i].Gerekce + "<br><br></p>");

                strB.AppendLine("<center><table border='1' cellpadding='0' cellspacing='0'>");
                strB.AppendLine("<tr>");
                //create table header
                for (int i1 = 0; i1 < dg.Columns.Count; i1++) { if (dg.Columns[i1].Visible == true) { strB.AppendLine("<th align='center' valign='middle'>" + dg.Columns[i1].HeaderText + "</th>"); } }
                //create table body
                strB.AppendLine("</tr>");
                for (int i2 = rowIndex; i2 < dg.Rows.Count; i2++)
                {

                    strB.AppendLine("<tr>");
                    foreach (DataGridViewCell dgvc in dg.Rows[i2].Cells)
                    {
                        if (dgvc.OwningColumn.Visible == true)
                        {
                            strB.AppendLine("<td align='center' valign='middle'>" + dgvc.Value.ToString() + "</td>");
                        }
                    }
                    strB.AppendLine("</tr>");

                    if (rowIndex == satMails.Count - 1) { isComplete = true; break; }

                    if (rowIndex < satMails.Count)
                    {
                        if (satMails[i].Siparisno == satMails[i + 1].Siparisno)
                        {
                            rowIndex++;
                            i++;
                            continue;
                        }
                        rowIndex++;
                        break;
                    }
                }
                //table footer & end of html file
                strB.AppendLine("</table></center>");
                if (isComplete)
                {
                    break;
                }
                strB.AppendLine("<br><br>");
            }
            strB.AppendLine("</body></html>");
            return strB.ToString();
        }
    }
}
