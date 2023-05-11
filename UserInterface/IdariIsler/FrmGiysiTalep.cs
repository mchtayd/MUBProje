using Business;
using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.Depo;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DataAccess.Concreate.Depo;
using Entity;
using Entity.AnaSayfa;
using Entity.Depo;
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
using UserInterface.Ana_Sayfa;
using UserInterface.Depo;
using UserInterface.STS;

namespace UserInterface.IdariIsler
{
    public partial class FrmGiysiTalep : Form
    {
        PersonelKayitManager personelKayitManager;
        ComboManager comboManager;
        AmbarManager ambarManager;
        CayOcagiManager cayOcagiManager;
        DestekDepoMalzemeKayitManager depoMalzemeKayitManager;
        ElAletleriManager elAletleriManager;
        IsGiysiManager isGiysiManager;
        KirtasiyeManager kirtasiyeManager;
        KKDManager kKDManager;
        TemizlikUrunleriManager temizlikUrunleriManager;
        MalzemeTalepManager malzemeTalepManager;
        BildirimYetkiManager bildirimYetkiManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;

        public object[] infos;
        bool start = true;
        bool start2 = false;
        string mail = "";
        public FrmGiysiTalep()
        {
            InitializeComponent();
            personelKayitManager = PersonelKayitManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            ambarManager = AmbarManager.GetInstance();
            cayOcagiManager = CayOcagiManager.GetInstance();
            depoMalzemeKayitManager = DestekDepoMalzemeKayitManager.GetInstance();
            elAletleriManager = ElAletleriManager.GetInstance();
            isGiysiManager = IsGiysiManager.GetInstance();
            kirtasiyeManager = KirtasiyeManager.GetInstance();
            kKDManager = KKDManager.GetInstance();
            temizlikUrunleriManager = TemizlikUrunleriManager.GetInstance();
            malzemeTalepManager = MalzemeTalepManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
        }

        private void FrmGiysiTalep_Load(object sender, EventArgs e)
        {
            TalepEden();
            Personeller();
            LblKisiAdet.Text = CmbTalepEdenPersonel.Items.Count.ToString();
            MalzemeKtegorisi();
            start = false;

            if (infos[1].ToString() == "ABDULMÜTTALİP TEKİN")
            {
                BtnKaydet.Location = new Point(763, 433);
            }
            
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageTalep"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void TalepEden()
        {
            LblAdSoyad.Text = infos[1].ToString();
            LblSiparisNo.Text = infos[9].ToString();
            LblUnvani.Text = infos[10].ToString();
            LblMasrafYeriNo.Text = infos[4].ToString();
            LblMasrafYeri.Text = infos[2].ToString();
        }
        void Personeller()
        {
            List<PersonelKayit> personelKayits = new List<PersonelKayit>();
            personelKayits = personelKayitManager.GetMasrafYeriSorumlusuPer(LblAdSoyad.Text);
            PersonelKayit personelKayit = new PersonelKayit(infos[0].ConInt(), infos[1].ToString(), infos[9].ToString(), infos[4].ToString(), infos[8].ToString(), infos[7].ToString(), infos[10].ToString(), infos[2].ToString(), infos[3].ToString());
            personelKayits.Add(personelKayit);

            CmbTalepEdenPersonel.DataSource = personelKayits;
            CmbTalepEdenPersonel.ValueMember = "Id";
            CmbTalepEdenPersonel.DisplayMember = "Adsoyad";
            CmbTalepEdenPersonel.SelectedValue= -1;

            //CmbTalepEdenPersonel.DataSource = personelKayitManager.GetMasrafYeriSorumlusuPer(LblAdSoyad.Text);
            //CmbTalepEdenPersonel.ValueMember = "Id";
            //CmbTalepEdenPersonel.DisplayMember = "Adsoyad";
            //CmbTalepEdenPersonel.SelectedValue = -1;
        }
        public void MalzemeKtegorisi()
        {
            CmbMalzemeKategorisi.DataSource = comboManager.GetList("MALZEME_KATEGORISI");
            CmbMalzemeKategorisi.ValueMember = "Id";
            CmbMalzemeKategorisi.DisplayMember = "Baslik";
            CmbMalzemeKategorisi.SelectedValue = 0;
        }

        private void CmbMalzemeKategorisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbMalzemeKategorisi.Text == "AMBAR" && start == false)
            {
                CmbTanim.DataSource = ambarManager.GetList();
                CmbTanim.ValueMember = "Id";
                CmbTanim.DisplayMember = "Tanim";
                CmbTanim.SelectedValue = 0;
            }
            if (CmbMalzemeKategorisi.Text == "ÇAY OCAĞI" && start == false)
            {
                CmbTanim.DataSource = cayOcagiManager.GetList();
                CmbTanim.ValueMember = "Id";
                CmbTanim.DisplayMember = "Tanim";
                CmbTanim.SelectedValue = 0;
            }
            if (CmbMalzemeKategorisi.Text == "EL ALETLERİ" && start == false)
            {
                CmbTanim.DataSource = elAletleriManager.GetList();
                CmbTanim.ValueMember = "Id";
                CmbTanim.DisplayMember = "Tanim";
                CmbTanim.SelectedValue = 0;
            }
            if (CmbMalzemeKategorisi.Text == "İŞ GİYSİ" && start == false)
            {
                CmbTanim.DataSource = isGiysiManager.GetList();
                CmbTanim.ValueMember = "Id";
                CmbTanim.DisplayMember = "Tanim";
                CmbTanim.SelectedValue = 0;
            }
            if (CmbMalzemeKategorisi.Text == "KIRTASİYE" && start == false)
            {
                CmbTanim.DataSource = kirtasiyeManager.GetList();
                CmbTanim.ValueMember = "Id";
                CmbTanim.DisplayMember = "Tanim";
                CmbTanim.SelectedValue = 0;
            }
            if (CmbMalzemeKategorisi.Text == "KKD" && start == false)
            {
                CmbTanim.DataSource = kKDManager.GetList();
                CmbTanim.ValueMember = "Id";
                CmbTanim.DisplayMember = "Tanim";
                CmbTanim.SelectedValue = 0;
            }
            if (CmbMalzemeKategorisi.Text == "TEMİZLİK ÜRÜNLERİ" && start == false)
            {
                CmbTanim.DataSource = temizlikUrunleriManager.GetList();
                CmbTanim.ValueMember = "Id";
                CmbTanim.DisplayMember = "Tanim";
                CmbTanim.SelectedValue = 0;
            }
            //if (CmbMalzemeKategorisi.Text == "SARF MALZEME (DEPO)" && start == false)
            //{
            //    CmbTanim.DataSource = null;

            //}
            CmbTanim.SelectedIndex = -1;
            TxtMiktar.Clear();
            TxtStok.Clear();
            start2 = true;
        }
        string birim = "";
        private void CmbTanim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start2 == false)
            {
                return;
            }
            Picture.ImageLocation = "";
            int id = CmbMalzemeKategorisi.SelectedIndex;
            if (CmbMalzemeKategorisi.Text == "AMBAR")
            {
                DestekDepoAmbar ambar = ambarManager.GetTanim(CmbTanim.Text);
                TxtStok.Text = ambar.Stokno;
                Picture.ImageLocation = ambar.DosyaYolu;
                //TxtMiktar.Text = ambar.Birim;
                birim = ambar.Birim;
            }
            if (CmbMalzemeKategorisi.Text == "ÇAY OCAĞI")
            {
                DestekDepoCayOcagi cayOcagi = cayOcagiManager.GetTanim(CmbTanim.Text);
                TxtStok.Text = cayOcagi.Stokno;
                Picture.ImageLocation = cayOcagi.DosyaYolu;
                //TxtMiktar.Text = cayOcagi.Birim;
                birim = cayOcagi.Birim;
            }
            if (CmbMalzemeKategorisi.Text == "EL ALETLERİ")
            {
                DestekDepoElAletleri elAletleri = elAletleriManager.GetTanim(CmbTanim.Text);
                TxtStok.Text = elAletleri.Stokno;
                Picture.ImageLocation = elAletleri.DosyaYolu;
                //TxtMiktar.Text = elAletleri.Birim;
                birim = elAletleri.Birim;
            }
            if (CmbMalzemeKategorisi.Text == "İŞ GİYSİ")
            {
                DestekDepoIsGiysi depoIsGiysi = isGiysiManager.GetTanim(CmbTanim.Text);
                TxtStok.Text = depoIsGiysi.Stokno;
                Picture.ImageLocation = depoIsGiysi.DosyaYolu;
                //TxtMiktar.Text = depoIsGiysi.Birim;
                birim = depoIsGiysi.Birim;
            }
            if (CmbMalzemeKategorisi.Text == "KIRTASİYE")
            {
                DestekDepoKirtasiye kirtasiye = kirtasiyeManager.GetTanim(CmbTanim.Text);
                TxtStok.Text = kirtasiye.Stokno;
                Picture.ImageLocation = kirtasiye.DosyaYolu;
                //TxtMiktar.Text = kirtasiye.Birim;
                birim = kirtasiye.Birim;
            }
            if (CmbMalzemeKategorisi.Text == "KKD")
            {
                DestekDepoKKD kkd = kKDManager.GetTanim(CmbTanim.Text);
                TxtStok.Text = kkd.Stokno;
                Picture.ImageLocation = kkd.DosyaYolu;
                //TxtMiktar.Text = kkd.Birim;
                birim = kkd.Birim;
            }
            if (CmbMalzemeKategorisi.Text == "TEMİZLİK ÜRÜNLERİ")
            {
                DestekDepoTemizlikUrunleri temizlikUrunleri = temizlikUrunleriManager.GetTanim(CmbTanim.Text);
                TxtStok.Text = temizlikUrunleri.Stokno;
                Picture.ImageLocation = temizlikUrunleri.DosyaYolu;
                //TxtMiktar.Text = temizlikUrunleri.Birim;
                birim = temizlikUrunleri.Birim;
            }
            if (CmbMalzemeKategorisi.Text == "SARF MALZEME (DEPO)")
            {
                //CmbStokNo.DataSource = temizlikUrunleriManager.GetList();
                //CmbStokNo.ValueMember = "Id";
                //CmbStokNo.DisplayMember = "Stokno";
                //CmbStokNo.SelectedValue = 0;
                //start = false;
            }
        }
        void Temizle()
        {
            Picture.ImageLocation = "";
            CmbTalepEdenPersonel.SelectedIndex = -1;
            CmbTanim.SelectedIndex = -1;
            TxtStok.Clear();
            TxtMiktar.Clear();
        }
        string Control()
        {
            if (CmbTalepEdenPersonel.Text=="")
            {
                return "Lütfen öncelikle Talep Edilen Personel bilgisini seçiniz!";
            }
            if (CmbTanim.Text=="")
            {
                return "Lütfen öncelikle Tanım bilgisini seçiniz!";
            }
            if (TxtMiktar.Text == "" || TxtMiktar.Text=="0")
            {
                return "Lütfen öncelikle Miktar bilgisini doldurunuz!";
            }
            return "OK";
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            string kontrol = Control();
            if (kontrol!="OK")
            {
                MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgList.Rows.Add();
            int sonSatir = DtgList.RowCount - 1;

            DtgList.Rows[sonSatir].Cells["MalzemeKategorisi"].Value = CmbMalzemeKategorisi.Text;
            DtgList.Rows[sonSatir].Cells["TalepEdenPersonel"].Value = CmbTalepEdenPersonel.Text;
            DtgList.Rows[sonSatir].Cells["MalzemeTanimi"].Value = CmbTanim.Text;
            DtgList.Rows[sonSatir].Cells["StokNo"].Value = TxtStok.Text;
            DtgList.Rows[sonSatir].Cells["TalepEdenMiktar"].Value = TxtMiktar.Text;
            DtgList.Rows[sonSatir].Cells["Birimm"].Value = birim;

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;

            Temizle();
        }
        int talepId = 0;
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (DtgList.Rows.Count==0)
            {
                MessageBox.Show("Lütfen öncelikle listeye kayıt ekleyiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    MalzemeTalep malzemeTalep = new MalzemeTalep(item.Cells["MalzemeKategorisi"].Value.ToString(), item.Cells["TalepEdenPersonel"].Value.ToString(), item.Cells["MalzemeTanimi"].Value.ToString(), item.Cells["StokNo"].Value.ToString(), item.Cells["TalepEdenMiktar"].Value.ConInt(), item.Cells["Birimm"].Value.ToString(), LblAdSoyad.Text, LblMasrafYeri.Text, LblMasrafYeriNo.Text);

                    malzemeTalepManager.Add(malzemeTalep);
                    MalzemeTalep malzemeTalep1 =  malzemeTalepManager.Get();

                    talepId = malzemeTalep1.Id;
                    GorevAtama();
                }

                //PersonelMail();
                //MailSendMetotPersonel();
                //string mesaj = BildirimKayit();
                //if (mesaj!="OK")
                //{
                //    MessageBox.Show(mesaj, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                DtgList.Rows.Clear();
            }
        }
        string GorevAtama()
        {
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(talepId, "MİF", "RESUL GÜNEŞ", "MİF ONAYI", DateTime.Now, "", DateTime.Now.Date);
            string kontrol = gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            if (kontrol != "OK")
            {
                return kontrol;
            }
            return "OK";
        }

        string BildirimKayit()
        {
            string[] array = new string[8];

            array[0] = "MİF Personel Kayıt"; // Bildirim Başlık
            array[1] = LblAdSoyad.Text; // Bildirim Sahibi Personel
            array[2] = "isimli personel"; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "Malzeme isteğinde bulunmuştur."; // Bildirim türü
            array[4] = ""; // İÇERİK
            array[5] = "";
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

        private void DtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgList.Rows.RemoveAt(e.RowIndex);
            }
        }
        void PersonelMail()
        {
            PersonelKayit personelKayit = personelKayitManager.PersonelMailWeb("MÜCAHİT AYDEMİR");
            mail = personelKayit.Oficemail;
        }

        void MailSendMetotPersonel()
        {
            string kaydiOlusturan = infos[1].ToString();
            MailSend("MALZEME İSTEK FORMU", "Merhaba " + "MÜCAHİT AYDEMİR," + "\n\n"+ kaydiOlusturan  + " tarafından malzeme isteğinde bulunulmuştur." + "\n\nİyi Çalışmalar.", new List<string>() { mail });
        }

        public void MailSend(string subject, string body, List<string> receivers, List<string> attachments = null)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                //client.Host = "smtp-relay.gmail.com";
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
                mailMessage.From = new MailAddress("dts@mubvan.net", "123456");
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

        private void Picture_DoubleClick(object sender, EventArgs e)
        {
            FrmPhotoFullScreen frmPhotoFullScreen = new FrmPhotoFullScreen();
            frmPhotoFullScreen.imageLocation = Picture.ImageLocation;
            frmPhotoFullScreen.ShowDialog();

        }

    }
}
