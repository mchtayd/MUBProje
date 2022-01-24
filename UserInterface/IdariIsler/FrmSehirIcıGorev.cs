using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
using System.IO;
using Entity.STS;
using System.Reflection;
using System.Net.Mail;
using MailMessage = System.Net.Mail.MailMessage;
using Task = System.Threading.Tasks.Task;
using Business;
using Entity;

namespace UserInterface.IdariIsler
{
    public partial class FrmSehirIcıGorev : Form
    {
        string satno, siparis, usamirbolum, usamirisim, islemadimi, islemadimiamir, control, islemadimiguncelle, mail, amirmail;
        int sayi, id, onayid, onayamirid, isakisnoamir, tamamlamaid;
        bool start = true, start2 = true, start3 = true, start4 = true;
        public object[] infos;
        SiparislerManager siparislerManager;
        SiparisPersonelManager siparisPersonelManager;
        ButceKoduManager butceKoduManager;
        SehiriciGorevManager sehiriciGorevManager;
        UstAmirManager ustAmirManager;
        IdariIslerLogManager logManager;
        PersonelKayitManager personelKayitManager;
        IsAkisNoManager isAkisNoManager;
        ComboManager comboManager;
        List<UstAmirMail> ustAmirMails;
        List<SehiriciGorev> sehiriciGorevs;
        public FrmSehirIcıGorev()
        {
            InitializeComponent();
            siparislerManager = SiparislerManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            butceKoduManager = ButceKoduManager.GetInstance();
            sehiriciGorevManager = SehiriciGorevManager.GetInstance();
            ustAmirManager = UstAmirManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            comboManager = ComboManager.GetInstance();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSehirIcıGorev"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmSehirIcıGorev_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            ComboProje();
            ComboProje2();
            //Siparisler();
            //Siparis();
            Personeller1();
            Personeller2();
            DataDisplayPersonel();
            DataDisplayAmir();
            //ButceKoduKalemi();
            //ButceKoduKalemi2();
            start = false;
            start2 = false;
            start3 = false;
            start4 = false;
            //UstAmirMail();
            if (infos[0].ConInt()!=30)
            {
                if (infos[0].ConInt() != 84)
                {
                    if (infos[0].ConInt() != 25)
                    {
                        TabControl.TabPages.Remove(TabControl.TabPages["tabPage3"]);
                        //TabControl.TabPages.Remove(TabControl.TabPages["tabPage2"]);
                    }
                    return;
                }
                return;
            }
        }
        public void YenilenecekVeri()
        {
            IsAkisNo();
            //Siparisler();
            //Siparis();
            Personeller1();
            Personeller2();
            DataDisplayPersonel();
            DataDisplayAmir();
            ComboProje();
            ComboProje2();
        }
        void ComboProje()
        {
            CmbProje.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProje.ValueMember = "Id";
            CmbProje.DisplayMember = "Baslik";
            CmbProje.SelectedValue = 0;
        }
        void ComboProje2()
        {
            CmbProjeGuncelle.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProjeGuncelle.ValueMember = "Id";
            CmbProjeGuncelle.DisplayMember = "Baslik";
            CmbProjeGuncelle.SelectedValue = 0;
        }
        void UstAmirMail()
        {
            UstAmirMail ustAmirMail = ustAmirManager.Get(personeladsoyad);
            id = ustAmirMail.Personelid;
            ustAmirMails = ustAmirManager.GetList(id);
            if (ustAmirMails.Count > 0)
            {
                amirmail = ustAmirMails[0].Oficemail; // HATA YOK
            }
        }
        void Personeller1()
        {
            LblAdSoyad.Text = infos[1].ToString();
            LblSiparisNo.Text = infos[9].ToString();
            LblUnvani.Text = infos[10].ToString();
            LblMasrafYeriNo.Text = infos[4].ToString();
            LblMasrafYeri.Text = infos[2].ToString();
        }
        void Personeller2()
        {
            CmbAdSoyadGun.DataSource = personelKayitManager.PersonelAdSoyad();
            CmbAdSoyadGun.ValueMember = "Id";
            CmbAdSoyadGun.DisplayMember = "Adsoyad";
            CmbAdSoyadGun.SelectedValue = -1;
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        void DataDisplayPersonel()
        {
            sehiriciGorevs = sehiriciGorevManager.PersonelOnay(infos[0].ConInt(), "1.ADIM: GÖREV OLUŞTURULDU.");
            dataBinder.DataSource = sehiriciGorevs.ToDataTable();
            DtgList.DataSource = dataBinder;
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Proje"].HeaderText = "PROJE";
            DtgList.Columns["Gidilecekyer"].HeaderText = "GİDİLECEK YER";
            DtgList.Columns["Gorevinkonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgList.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgList.Columns["Bitistarihi"].Visible = false;
            DtgList.Columns["Toplamsure"].Visible = false;
            DtgList.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgList.Columns["Masrafyerno"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgList.Columns["Islemadimi"].HeaderText = "İŞLEM ADIMI";
            DtgList.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgList.Columns["Personelid"].Visible = false;
            DtgList.Columns["Gecensure"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;
            TxtTop.Text = DtgList.RowCount.ToString();
        }
        void DataDisplayAmir()
        {
            sehiriciGorevs = sehiriciGorevManager.AmirOnay(infos[0].ConInt(), "2.ADIM:GÖREV PERSONEL TARAFINDAN ONAYLANDI.");
            dataBinder2.DataSource = sehiriciGorevs.ToDataTable();
            DtgListAmir.DataSource = dataBinder2;
            DtgListAmir.Columns["Id"].Visible = false;
            DtgListAmir.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgListAmir.Columns["Proje"].HeaderText = "PROJE";
            DtgListAmir.Columns["Gidilecekyer"].HeaderText = "GİDİLECEK YER";
            DtgListAmir.Columns["Gorevinkonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgListAmir.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgListAmir.Columns["Bitistarihi"].Visible = false;
            DtgListAmir.Columns["Toplamsure"].Visible = false;
            DtgListAmir.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgListAmir.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgListAmir.Columns["Masrafyerno"].HeaderText = "MASRAF YERİ NO";
            DtgListAmir.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgListAmir.Columns["Islemadimi"].HeaderText = "İŞLEM ADIMI";
            DtgListAmir.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgListAmir.Columns["Personelid"].Visible = false;
            DtgListAmir.Columns["Sayfa"].Visible = false;
            DtgListAmir.Columns["Gecensure"].Visible = false;
            TxtTopAmir.Text = DtgListAmir.RowCount.ToString();
        }
        /*void ButceKoduKalemi()
        {
            CmbButceKodu.DataSource = butceKoduManager.GetList();
            CmbButceKodu.ValueMember = "Id";
            CmbButceKodu.DisplayMember = "Butcekodu";
            CmbButceKodu.SelectedValue = 0;
        }
        void ButceKoduKalemi2()
        {
            CmbButceKoduGun.DataSource = butceKoduManager.GetList();
            CmbButceKoduGun.ValueMember = "Id";
            CmbButceKoduGun.DisplayMember = "Butcekodu";
            CmbButceKoduGun.SelectedValue = 0;
        }*/

        /*void Siparisler()
        {
            CmbSiparisNo.DataSource = siparislerManager.GetList();
            CmbSiparisNo.ValueMember = "Id";
            CmbSiparisNo.DisplayMember = "Siparisno";
            CmbSiparisNo.SelectedValue = 0;
        }*/
        /*void Siparis()
        {
            CmbSiparsGun.DataSource = siparislerManager.GetList();
            CmbSiparsGun.ValueMember = "Id";
            CmbSiparsGun.DisplayMember = "Siparisno";
            CmbSiparsGun.SelectedValue = 0;
        }*/

        private void CmbSiparsGun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start3)
            {
                if (start4 == true)
                {
                    return;
                }
            }
            siparis = CmbSiparsGun.Text;
            SiparisIsimlerDoldurGuncelle();
            TxtUnvani.Clear();
            TxtMasrafYeriNoGun.Clear();
            TxtMasrafYeriGun.Clear();
            start3 = true;
        }
        /*if (start == true)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdSoyad.Text);
        CmbSiparisNo.Text = siparis.Siparis;
            TxtMasrafyeriNo.Text = siparis.Masrafyerino;
            TxtMasrafYeri.Text = siparis.Masrafyeri;
            id = siparis.Id;
            TxtGoreviGun.Text = siparis.Gorevi;
            ustAmirMails = ustAmirManager.GetList(id);
            if (ustAmirMails.Count > 0)
            {
                usamirbolum = ustAmirMails[0].Bolum;
                usamirisim = ustAmirMails[0].Adsoyad;
            }
        */
    
        private void CmbAdSoyadGun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start3 == true)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdSoyadGun.Text);
            CmbSiparsGun.Text = siparis.Siparis;
            TxtMasrafYeriNoGun.Text = siparis.Masrafyerino;
            TxtMasrafYeriGun.Text = siparis.Masrafyeri;
            TxtUnvani.Text = siparis.Gorevi;
        }
        void SiparisIsimlerDoldurGuncelle()
        {
            CmbAdSoyadGun.DataSource = siparisPersonelManager.GetList(siparis);
            CmbAdSoyadGun.ValueMember = "Id";
            CmbAdSoyadGun.DisplayMember = "Personel";
            CmbAdSoyadGun.SelectedValue = 0;
        }
        void CreateWord()
        {
            DateTime basTarihi = new DateTime(DtBasTarihiTamamlama.Value.Year, DtBasTarihiTamamlama.Value.Month, DtBasTarihiTamamlama.Value.Day, DtBasSaatiTamamlama.Value.Hour, DtBasSaatiTamamlama.Value.Minute, DtBasSaatiTamamlama.Value.Second);
            DateTime bitTarihi = new DateTime(DtBitTarihi.Value.Year, DtBitTarihi.Value.Month, DtBitTarihi.Value.Day, DtBitSaati.Value.Hour, DtBitSaati.Value.Minute, DtBitSaati.Value.Second);

            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = "C:\\Users\\MAYıldırım\\Desktop\\WordTaslak\\SehirIciGorevFormu.docx"; // taslak yolu

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["AkisNo"].Range.Text = TxtIsAkisNoTamamla.Text;
            wBookmarks["GorevinKonusu"].Range.Text = TxtGorevKonusuT.Text;
            wBookmarks["GidilecekYer"].Range.Text = TxtGidilecekYerT.Text;
            wBookmarks["BaslamaTarihi"].Range.Text = basTarihi.ToString();
            wBookmarks["BitisTarihi"].Range.Text = bitTarihi.ToString();
            wBookmarks["Suresi"].Range.Text = TxtToplamSure.Text;
            wBookmarks["SiparisNo"].Range.Text = TxtSiparisNoT.Text;
            wBookmarks["AdSoyad"].Range.Text = TxtAdSoyadT.Text;
            wBookmarks["MasrafYeriNo"].Range.Text = TxtMasrafYeriNoT.Text;
            wBookmarks["Bolumu"].Range.Text = TxtMasrafYeriT.Text;
            wBookmarks["Isim1"].Range.Text = TxtAdSoyadT.Text;
            wBookmarks["Tarih1"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
            wBookmarks["isim2"].Range.Text = usamirisim;
            wBookmarks["Bolumu2"].Range.Text = usamirbolum;
            wBookmarks["Tarih2"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");

            //wDoc.SaveAs2(yol + "\\" + TxtIsAkisNoTamamla.Text + ".docx"); // farklı kaydet
            wDoc.SaveAs2("C:\\Users\\MAYıldırım\\Desktop\\RESUL ABİ\\" + LblIsAkisNo.Text + ".docx");
            wDoc.Close();
            wApp.Quit(false);

            /*Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = "C:\\Users\\MAYıldırım\\Desktop\\RESUL ABİ\\test2.docx"; // taslak yolu
            
            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahel açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["isAkisNo"].Range.Text = LblIsAkisNo.Text;
            wBookmarks["gorevinKonusu"].Range.Text = TxtGorevKonusu.Text + "\n";

            wDoc.SaveAs2("C:\\Users\\MAYıldırım\\Desktop\\RESUL ABİ\\" + LblIsAkisNo.Text + ".docx"); // farklı kaydet
            wDoc.Close();
            wApp.Quit(false);
            MessageBox.Show("bitti");*/
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DateTime basTarihi = new DateTime(DtBasTarihi.Value.Year, DtBasTarihi.Value.Month, DtBasTarihi.Value.Day, DtBasSaati.Value.Hour, DtBasSaati.Value.Minute, DtBasSaati.Value.Second);
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNo();
                string islemadimi = "1.ADIM: GÖREV OLUŞTURULDU.";
                SehiriciGorev sehiriciGorev = new SehiriciGorev(LblIsAkisNo.Text.ConInt(), CmbProje.Text, TxtGidilecekYer.Text, TxtGorevKonusu.Text,
                    basTarihi, LblSiparisNo.Text, LblAdSoyad.Text, LblUnvani.Text, LblMasrafYeriNo.Text, LblMasrafYeri.Text, islemadimi, id);
                string mesaj = sehiriciGorevManager.Add(sehiriciGorev);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLog();
                PersonelMail();
                Task.Factory.StartNew(() => MailSendMetotPersonel());

                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                DataDisplayPersonel();
                DataDisplayAmir();

            }
        }
        void PersonelMail()
        {
            PersonelKayit personelKayit = personelKayitManager.PersonelMail(LblAdSoyad.Text);
            mail = personelKayit.Oficemail;
        }
        void CreateLog()
        {
            string sayfa = "ŞEHİR İÇİ GÖREV";
            SehiriciGorev gorev = sehiriciGorevManager.Get(LblIsAkisNo.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "ŞEHİR İÇİ GÖREV OLUŞTURULDU.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void Temizle()
        {
            IsAkisNo(); CmbProje.SelectedValue = -1; TxtGidilecekYer.Clear(); TxtGorevKonusu.Clear();
            DtBasTarihi.Value = DateTime.Now;
        }
        void MailSendMetotPersonel()
        {
            MailSend("ŞEHİR İÇİ GÖREV", "Merhaba; \n\n" + LblIsAkisNo.Text + " İş Akış Numaralı, Göreviniz oluşturulmuştur. Onaylarayarak üst amirinizi bilgilendirebilirsiniz." + "\n\nİyi Çalışmalar.", new List<string>() { mail });
        }
        void MailSendMetotTamamlama()
        {
            MailSend("ŞEHİR İÇİ GÖREV", "Merhaba; \n\n" + TxtIsAkisNoTamamla.Text + " İş Akış Numaralı, Görev Başarıyla Tamamlanmıştır." + "\n\nİyi Çalışmalar.", new List<string>() { "emelayhan@mubvan.net","resulgunes@mubvan.net" });
        }
        void MailSendMetotOnay()
        {
            MailSend("ŞEHİR İÇİ GÖREV", "Merhaba; \n\n" + isakisnoamir + " İş Akış Numaralı Görev Başarıyla Onaylanmıştır." + "\n\nİyi Çalışmalar.", new List<string>() { infos[7].ToString() });
        }
        void MailSendMetotAmir()
        {
            MailSend("ŞEHİR İÇİ GÖREV", "Merhaba; \n\n" + isakisno + " İş Akış Numaralı Görev, Onayınıza Sunulmuştur." + "\n\nİyi Çalışmalar.", new List<string>() { amirmail });
        }
        void MailSendMetotPersonelOnay()
        {
            MailSend("ŞEHİR İÇİ GÖREV", "Merhaba; \n\n" + isakisno + " İş Akış Numaralı Görev, Başarıyla Onaylanmıştır." + "\n\nİyi Çalışmalar.", new List<string>() { infos[7].ToString() });
        }
        void MailSendMetotRet()
        {
            MailSend("ŞEHİR İÇİ GÖREV", "Merhaba; \n\n" + isakisno + " İş Akış Numaralı Görev Reddedilmiştir." + "\n\nİyi Çalışmalar.", new List<string>() { infos[7].ToString() });
        }
        void MailSendMetotRetAmir()
        {
            MailSend("ŞEHİR İÇİ GÖREV", "Merhaba; \n\n" + isakisnoamir + " İş Akış Numaralı Görev Reddedilmiştir." + "\n\nİyi Çalışmalar.", new List<string>() { infos[7].ToString() });
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DateTime basTarihi = new DateTime(DtBasGun.Value.Year, DtBasGun.Value.Month, DtBasGun.Value.Day, DtBasSaatiGun.Value.Hour, DtBasSaatiGun.Value.Minute, DtBasSaatiGun.Value.Second);
                DateTime bitTarihi = new DateTime(DtBitGun.Value.Year, DtBitGun.Value.Month, DtBitGun.Value.Day, DtBitSaatiGun.Value.Hour, DtBitSaatiGun.Value.Minute, DtBitSaatiGun.Value.Second);

                SehiriciGorev sehiriciGorev = new SehiriciGorev(CmbProjeGuncelle.Text, CmbGidilecekYerGun.Text, TxtGorevKonusuGun.Text, basTarihi, bitTarihi, TxtTopSureGun.Text, CmbSiparsGun.Text, CmbAdSoyadGun.Text, TxtUnvani.Text, TxtMasrafYeriNoGun.Text, TxtMasrafYeriGun.Text, islemadimiguncelle);
                string mesaj = sehiriciGorevManager.Update(sehiriciGorev, TxtIsAkisNo.Text.ConInt());
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLogGuncelle();
                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }
        }
        void CreateLogGuncelle()
        {
            string sayfa = "ŞEHİR İÇİ GÖREV";
            SehiriciGorev gorev = sehiriciGorevManager.Get(TxtIsAkisNo.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "ŞEHİR İÇİ GÖREV GÜNCELLENDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNo.MaskFull) // true false dondurur şu an true ise ife giricek false ise girmicek.
            {

                SehiriciGorev sehirici = sehiriciGorevManager.Get(TxtIsAkisNo.Text.ConInt());
                if (sehirici == null)
                {
                    MessageBox.Show(TxtIsAkisNo.Text + " İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TemizleGuncelle();
                    return;
                }
                CmbProjeGuncelle.Text = sehirici.Proje;
                CmbGidilecekYerGun.Text = sehirici.Gidilecekyer;
                TxtGorevKonusuGun.Text = sehirici.Gorevinkonusu;
                DtBasGun.Value = sehirici.Baslamatarihi.ConTime();
                DtBitGun.Value = sehirici.Bitistarihi.ConTime();
                TxtTopSureGun.Text = sehirici.Toplamsure;
                CmbSiparsGun.Text = sehirici.Siparisno;
                CmbAdSoyadGun.Text = sehirici.Adsoyad;
                TxtMasrafYeriNoGun.Text = sehirici.Masrafyerno;
                TxtMasrafYeriGun.Text = sehirici.Masrafyeri;
                DtBitSaatiGun.Value = sehirici.Bitistarihi.ConTime();
                DtBasSaatiGun.Value = sehirici.Baslamatarihi.ConTime();
                islemadimiguncelle = sehirici.Islemadimi;
                TxtUnvani.Text = sehirici.Unvani;
                return;
            }
            MessageBox.Show("Lütfen 9 haneli İş Akiş Numarasını Eksiksiz Girinz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            TemizleGuncelle();
        }
        void TemizleGuncelle()
        {
            CmbProjeGuncelle.SelectedValue = -1; TxtIsAkisNo.Clear(); CmbGidilecekYerGun.Clear(); TxtGorevKonusuGun.Clear(); TxtTopSureGun.Clear();
            CmbSiparsGun.Text = ""; CmbAdSoyadGun.Text = ""; TxtMasrafYeriNoGun.Text = ""; TxtMasrafYeriGun.Clear();
            DtBasGun.Value = DateTime.Now; DtBitGun.Value = DateTime.Now; TxtUnvani.Clear();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnTemizleGun_Click(object sender, EventArgs e)
        {
            TemizleGuncelle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (!TxtIsAkisNo.MaskFull)
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Görevin İş Akış Numarasını Giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (TxtTopSureGun.Text != "Görev Devam Ediyor")
            {
                MessageBox.Show("Tamamlanmış Bir Görevin Kaydını Silemezsiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(TxtIsAkisNo.Text + " Nolu Görevi Tamamen Silmek İstediğinize Emin Misiniz? Bu İşlem Geri Alınamaz.", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                sehiriciGorevManager.Delete(TxtIsAkisNo.Text.ConInt());
                MessageBox.Show(TxtIsAkisNo.Text + " Nolu Kayıt Başarıyla Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }
        }

        string Control()
        {
            if (TxtIsAkisNoTamamla.Text == "")
            {
                return "Lütfen Öncelikle İş Akış No Bilgisini Doldurarak BUL Butonuna Tıklayınız.";
            }
            if (TxtToplamSure.Text == "Görev Devam Ediyor")
            {
                return "Lütfen Toplam Süre Bilgisini Hesaplamak İçin Süre Hesapla Butonuna Tıklayınız.";
            }
            return "OK";
        }

        private void BtnDokumanOlustur_Click(object sender, EventArgs e)
        {
            if (control== "4.ADIM:GÖREV TAMAMLANMIŞTIR.")
            {
                MessageBox.Show("Bu Görev Zaten Tamamlanmıştır.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Görevi Tamamlamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = Control();
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DateTime bitTarihi = new DateTime(DtBitTarihi.Value.Year, DtBitTarihi.Value.Month, DtBitTarihi.Value.Day, DtBitSaati.Value.Hour, DtBitSaati.Value.Minute, DtBitSaati.Value.Second);
                SehiriciGorev sehiriciGorev = new SehiriciGorev(TxtIsAkisNoTamamla.Text.ConInt(), bitTarihi, TxtToplamSure.Text);
                sehiriciGorevManager.GorevTamamla(sehiriciGorev, TxtIsAkisNoTamamla.Text.ConInt());
                string sehiricigorev = "4.ADIM:GÖREV TAMAMLANMIŞTIR.";
                SehiriciGorev sehirici = new SehiriciGorev(sehiricigorev);
                sehiriciGorevManager.GorevOnay(sehirici, tamamlamaid);
                CreateLogTamamla();
                Task.Factory.StartNew(() => MailSendMetotTamamlama());
                //CreateWord();s
                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleTamamla();
            }
        }
        void CreateLogTamamla()
        {
            string sayfa = "ŞEHİR İÇİ GÖREV";
            SehiriciGorev gorev = sehiriciGorevManager.Get(TxtIsAkisNoTamamla.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "ŞEHİR İÇİ GÖREV TAMAMLANDI.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplayPersonel();
            DataDisplayAmir();
        }

        void TemizleTamamla()
        {
            TxtIsAkisNoTamamla.Clear(); TxtProjeT.Clear(); TxtGidilecekYerT.Clear(); TxtGorevKonusuT.Clear(); TxtToplamSure.Clear(); TxtSiparisNoT.Clear(); TxtAdSoyadT.Clear(); TxtMasrafYeriNoT.Clear(); TxtMasrafYeriT.Clear(); TxtGoreviGunGun.Clear();
        }
        void CreateLogPersonelRed()
        {
            string sayfa = "ŞEHİR İÇİ GÖREV";
            SehiriciGorev gorev = sehiriciGorevManager.Get(isakisno);
            int benzersizid = gorev.Id;
            string islem = "ŞEHİR İÇİ GÖREV PERSONEL TARAFINDAN REDDEDİLDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        private void BtnGorevReddet_Click(object sender, EventArgs e)
        {
            if (onayid == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Görev Kaydı Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isakisno + " Nolu Görevi Reddetmek İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string sehiricigorev = "GÖREV "+infos[1].ToString()+" TARAFINDAN REDDEDİLDİ";
                SehiriciGorev sehiriciGorev = new SehiriciGorev(isakisno, DateTime.Now, "0 Saat");
                sehiriciGorevManager.GorevTamamla(sehiriciGorev, isakisno);
                SehiriciGorev sehirici = new SehiriciGorev(sehiricigorev);
                sehiriciGorevManager.GorevOnay(sehirici, onayid);
                MessageBox.Show("İşlem Başarıyla Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Task.Factory.StartNew(() => MailSendMetotRet());
                DataDisplayPersonel();
                CreateLogPersonelRed();
            }
        }

        private void BtnGorevReddetAmir_Click(object sender, EventArgs e)
        {
            if (onayamirid == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Görev Kaydı Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isakisnoamir + " Nolu Görevi Reddetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string sehiricigorev = "GÖREV "+infos[1].ToString() +" TARAFINDAN REDDEDİLDİ";
                SehiriciGorev sehiriciGorev = new SehiriciGorev(isakisnoamir, DateTime.Now, "0 Saat");
                sehiriciGorevManager.GorevTamamla(sehiriciGorev, isakisnoamir);
                SehiriciGorev sehirici = new SehiriciGorev(sehiricigorev);
                sehiriciGorevManager.GorevOnay(sehirici, onayamirid);
                MessageBox.Show("İşlem Başarıyla Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataDisplayAmir();
                CreateLogAmirRed();
                Task.Factory.StartNew(() => MailSendMetotRetAmir());
            }
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgListAmir_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Filter = DtgListAmir.FilterString;
            TxtTopAmir.Text = DtgListAmir.RowCount.ToString();
        }

        private void DtgListAmir_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Sort = DtgListAmir.SortString;
        }

        private void BtnBulT_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNoTamamla.MaskFull) // true false dondurur şu an true ise ife giricek false ise girmicek.
            {
                SiparisPersonel siparis = siparisPersonelManager.Get(TxtSiparisNoT.Text, TxtAdSoyadT.Text);
                id = siparis.Id;
                ustAmirMails = ustAmirManager.GetList(id);
                if (ustAmirMails.Count > 0)
                {
                    usamirbolum = ustAmirMails[0].Bolum;
                    usamirisim = ustAmirMails[0].Adsoyad;
                }

                SehiriciGorev sehirici = sehiriciGorevManager.Get(TxtIsAkisNoTamamla.Text.ConInt());
                if (sehirici == null)
                {
                    MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TemizleGuncelle();
                    return;
                }
                TxtProjeT.Text = sehirici.Proje;
                TxtGidilecekYerT.Text = sehirici.Gidilecekyer;
                TxtGorevKonusuT.Text = sehirici.Gorevinkonusu;
                DtBasTarihiTamamlama.Value = sehirici.Baslamatarihi.ConTime();
                DtBasSaatiTamamlama.Value = sehirici.Baslamatarihi.ConTime();
                /*DtBitTarihi.Value = sehirici.Bitistarihi.ConTime();
                DtBitSaati.Value = sehirici.Bitistarihi.ConTime();*/
                TxtToplamSure.Text = sehirici.Toplamsure;
                TxtSiparisNoT.Text = sehirici.Siparisno;
                TxtAdSoyadT.Text = sehirici.Adsoyad;
                TxtMasrafYeriNoT.Text = sehirici.Masrafyerno;
                TxtMasrafYeriT.Text = sehirici.Masrafyeri;
                tamamlamaid = sehirici.Id;
                control = sehirici.Islemadimi;
                TxtGoreviGunGun.Text = sehirici.Unvani;
                return;
            }
            MessageBox.Show("Lütfen 9 haneli İş Akiş Numarasını Eksiksiz Girinz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnSureHesapla_Click(object sender, EventArgs e)
        {
            DateTime bTarih = DtBasTarihiTamamlama.Value;
            DateTime kTarih = DtBitTarihi.Value;
            DateTime bSaat = DtBasSaatiTamamlama.Value;
            DateTime kSaat = DtBitSaati.Value;
            TimeSpan SonucGun = kTarih - bTarih;
            TimeSpan SonucSaat = kSaat - bSaat;
            int gun = SonucGun.TotalDays.ConInt();
            int saat = SonucSaat.TotalHours.ConInt();

            int topsaat = (gun * 24) + saat;
            TxtToplamSure.Text = topsaat.ToString() + " Saat";
        }

        private void BtnGorevOnaylaAmir_Click(object sender, EventArgs e)
        {
            if (onayamirid == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Görev Kaydı Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Görevi Onaylamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string sehiricigorev = "3.ADIM:GÖREV AMİR TARAFINDAN ONAYLANDI";
                SehiriciGorev sehiriciGorev = new SehiriciGorev(sehiricigorev);
                sehiriciGorevManager.GorevOnay(sehiriciGorev, onayamirid);
                MessageBox.Show("İşlem Başarıyla Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Task.Factory.StartNew(() => MailSendMetotOnay());
                DataDisplayAmir();
                CreateLogAmirOnay();
            }
        }
        
        private void DtgListAmir_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgListAmir.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            onayamirid = DtgListAmir.CurrentRow.Cells["Id"].Value.ConInt();
            islemadimiamir = DtgListAmir.CurrentRow.Cells["Islemadimi"].Value.ToString();
            isakisnoamir =  DtgListAmir.CurrentRow.Cells["Isakisno"].Value.ConInt();
        }

        private void BtnGorevOnayla_Click(object sender, EventArgs e)
        {
            if (onayid==0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Görev Kaydı Seçiniz.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (islemadimi != "1.ADIM: GÖREV OLUŞTURULDU.")
            {
                MessageBox.Show(isakisno + " Nolu Kayıt Zaten Tarafınızca Onaylanmıştır.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Görevi Onaylamak İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string sehiricigorev = "2.ADIM:GÖREV PERSONEL TARAFINDAN ONAYLANDI.";
                SehiriciGorev sehiriciGorev = new SehiriciGorev(sehiricigorev);
                sehiriciGorevManager.GorevOnay(sehiriciGorev, onayid);
                MessageBox.Show("İşlem Başarıyla Gerçekleşmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                UstAmirMail();

                Task.Factory.StartNew(() => MailSendMetotPersonelOnay());
                Task.Factory.StartNew(() => MailSendMetotAmir());

                DataDisplayPersonel();
                CreateLogPersonelOnay();
            }
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
        void CreateLogPersonelOnay()
        {
            string sayfa = "ŞEHİR İÇİ GÖREV";
            SehiriciGorev gorev = sehiriciGorevManager.Get(isakisno);
            int benzersizid = gorev.Id;
            string islem = "ŞEHİR İÇİ GÖREV PERSONEL TARAFINDAN ONAYLANDI.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        int isakisno;
        string personeladsoyad;
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            onayid = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            islemadimi = DtgList.CurrentRow.Cells["Islemadimi"].Value.ToString();
            isakisno = DtgList.CurrentRow.Cells["Isakisno"].Value.ConInt();
            personeladsoyad = DtgList.CurrentRow.Cells["Adsoyad"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime bTarih = DtBasGun.Value;
            DateTime kTarih = DtBitGun.Value;
            DateTime bSaat = DtBasSaatiGun.Value;
            DateTime kSaat = DtBitSaatiGun.Value;
            TimeSpan SonucGun = kTarih - bTarih;
            TimeSpan SonucSaat = kSaat - bSaat;
            int gun = SonucGun.TotalDays.ConInt();
            int saat = SonucSaat.TotalHours.ConInt();

            int topsaat = (gun * 24) + saat;
            TxtTopSureGun.Text = topsaat.ToString() + " Saat";
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

        public void MailSend2(string subject, string body, List<string> receivers, List<string> attachments = null)
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
                mailMessage.IsBodyHtml = true;
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
