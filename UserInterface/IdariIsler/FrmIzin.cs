using Business;
using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity;
using Entity.AnaSayfa;
using Entity.IdariIsler;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;
using Color = System.Drawing.Color;

namespace UserInterface.IdariIsler
{
    public partial class FrmIzin : Form
    {
        SiparislerManager siparislerManager;
        SiparisPersonelManager siparisPersonelManager;
        IzinManager izinManager;
        IdariIslerLogManager logManager;
        IsAkisNoManager isAkisNoManager;
        PersonelKayitManager kayitManager;
        BildirimYetkiManager bildirimYetkiManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;

        List<string> fileNames = new List<string>();
        List<string> fileNamesGun = new List<string>();
        bool start = true, start2 = true, start3 = true, start4 = true;
        string siparis, satno, dosya, dosyagun, kaynakdosyaismi, alinandosya, siparisNo;
        int sayi, index, sonucGun, sonucSaat, toplamsaat, kalansaat, kalangun;
        string toplamSure, taslakYolu = "";
        string kaynak = @"Z:\DTS\İDARİ İŞLER\WordTaslak\";
        string yol = @"C:\DTS\Taslak\";
        public object[] infos;
        int gun, izinId = 0;
        public FrmIzin()
        {
            InitializeComponent();
            siparislerManager = SiparislerManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            izinManager = IzinManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageIzin"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmIzin_Load(object sender, EventArgs e)
        {
            //Siparisler();
            //Siparis();
            IsAkisNo();
            Personeller1();
            Personeller2();
            BtnGuncelle.TabPages.Remove(BtnGuncelle.TabPages["tabPage2"]);
            start = false;
            start2 = false;
            start3 = false;
            start4 = false;
        }
        public void YenilenecekVeri()
        {
            //Siparisler();
            //Siparis();
            Personeller1();
            Personeller2();
            IsAkisNo();
        }
        void Personeller1()
        {
            CmbPersonel.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersonel.ValueMember = "Id";
            CmbPersonel.DisplayMember = "Adsoyad";
            CmbPersonel.SelectedValue = -1;
        }
        void Personeller2()
        {
            CmbAd.DataSource = kayitManager.PersonelAdSoyad();
            CmbAd.ValueMember = "Id";
            CmbAd.DisplayMember = "Adsoyad";
            CmbAd.SelectedValue = -1;
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        
        
        void SiparisIsimlerDoldurGuncelle()
        {
            CmbAd.DataSource = siparisPersonelManager.GetList(siparis);
            CmbAd.ValueMember = "Id";
            CmbAd.DisplayMember = "Personel";
            CmbAd.SelectedValue = 0;
            start2 = true;
        }


        private void CmbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbPersonel.SelectedIndex==-1)
            {
                LblSiparisNo.Text = "00";
                LblMasrafYeriNo.Text = "00";
                LblBolum.Text = "00";
                LblUnvani.Text = "00";
            }
            else
            {
                SiparisPersonel siparis = siparisPersonelManager.Get("", CmbPersonel.Text);
                LblSiparisNo.Text = siparis.Siparis;
                LblMasrafYeriNo.Text = siparis.Masrafyerino;
                LblBolum.Text = siparis.Masrafyeri;
                LblUnvani.Text = siparis.Gorevi;
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            /*if (CmbDokumanTuru.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İZİN DOKÜMAN TÜRÜ Bilgisini Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            if (BtnDosyaEkle.BackColor != Color.LightGreen)
            {
                MessageBox.Show("İzin Formunun Taratılmış Halini Eklemediniz! Lütfen Dosya Ekleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNo();
                DateTime basTarihi = new DateTime(DtBasTarihi.Value.Year, DtBasTarihi.Value.Month, DtBasTarihi.Value.Day, DtBasSaati.Value.Hour, DtBasSaati.Value.Minute, DtBasSaati.Value.Second);
                DateTime bitTarihi = new DateTime(DtBitTarihi.Value.Year, DtBitTarihi.Value.Month, DtBitTarihi.Value.Day, DtBitSaati.Value.Hour, DtBitSaati.Value.Minute, DtBitSaati.Value.Second);

                TimeSpan SonucGun = bitTarihi - basTarihi;

                IzinSuresi();
                //CreateDirectory();
                Izin ızin = new Izin(LblIsAkisNo.Text.ConInt(), CmbIzınKategori.Text, CmbIzınTuru.Text, LblSiparisNo.Text, CmbPersonel.Text, LblUnvani.Text, LblMasrafYeriNo.Text, LblBolum.Text, TxtIzinNedeni.Text, basTarihi, bitTarihi, izinsuresi, dosya, "");
                string mesaj = izinManager.Add(ızin);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLog();
                mesaj = BildirimKayit();
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                BtnDosyaEkle.BackColor = Color.Transparent;
            }

        }

        string BildirimKayit()
        {
            string[] array = new string[8];

            array[0] = "Personel İzin"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = LblIsAkisNo.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "iş akış numaralı"; // Bildirim türü
            array[4] = CmbPersonel.Text + " isimli personel için"; // İÇERİK
            array[5] = DtBasTarihi.Value.ToString("d") + " tarihinden " + DtBitTarihi.Value.ToString("d") + " tarihine kadar";
            array[6] = CmbIzınTuru.Text + " kaydı oluşturmuştur!";

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
        string BildirimKayitGuncelle()
        {
            string[] array = new string[8];

            array[0] = "Personel İzin Güncelleme"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = TxtIzinGuncelle.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "iş akış numaralı"; // Bildirim türü
            array[4] = CmbAd.Text + " isimli personel için"; // İÇERİK
            array[5] = DtTarihBaslama.Value.ToString("d") + " tarihinden " + DtTarihBitis.Value.ToString("d") + " tarihine kadar olan";
            array[6] = CmbTuru.Text + " kaydı güncelledi!";

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

       
        void CreateLog()
        {
            string sayfa = "İZİN";
            Izin gorev = izinManager.Get(LblIsAkisNo.Text.ConInt());
            if (gorev!=null)
            {
                int benzersizid = gorev.Id;
                string islem = "İZİN KAYDI OLUŞTURULDU.";
                string islemyapan = infos[1].ToString();
                IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
                logManager.Add(log);
            }
        }

        object filePath;
        string izinsuresi;
        void CreateWord()
        {

            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            if (index == 0)
            {
                filePath = "C:\\Users\\MAYıldırım\\Desktop\\WordTaslak\\GÜNLÜK İZİN- MGÜB.docx"; // taslak yolu
                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["AdSoyad"].Range.Text = CmbPersonel.Text;
                wBookmarks["Departman"].Range.Text = "MÜB PROJE DİREKTÖRLÜĞÜ";
                wBookmarks["Unvani"].Range.Text = LblUnvani.Text;
                wBookmarks["CikisTarihi"].Range.Text = DtBasTarihi.Value.ToString("dd/MM/yyyy");
                wBookmarks["DonusTarihi"].Range.Text = DtBitTarihi.Value.ToString("dd/MM/yyyy");
                wBookmarks["IzinSuresi"].Range.Text = izinsuresi;
                wBookmarks["Adsoyad2"].Range.Text = CmbPersonel.Text;

                wDoc.SaveAs2(dosya + LblIsAkisNo.Text + ".docx");
                wDoc.Close();
                wApp.Quit(false);
            }
            if (index == 1)
            {
                filePath = "C:\\Users\\MAYıldırım\\Desktop\\WordTaslak\\GÜNLÜK İZİN- MGÜB.docx"; // taslak yolu
                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["AdSoyad"].Range.Text = CmbPersonel.Text;
                wBookmarks["Departman"].Range.Text = "MÜB PROJE DİREKTÖRLÜĞÜ";
                wBookmarks["Unvani"].Range.Text = LblUnvani.Text;
                wBookmarks["CikisTarihi"].Range.Text = DtBasTarihi.Value.ToString("dd/MM/yyyy");
                wBookmarks["DonusTarihi"].Range.Text = DtBitTarihi.Value.ToString("dd/MM/yyyy");
                wBookmarks["IzinSuresi"].Range.Text = izinsuresi;
                wBookmarks["Adsoyad2"].Range.Text = CmbPersonel.Text;

                wDoc.SaveAs2(dosya + LblIsAkisNo.Text + ".docx");
                wDoc.Close();
                wApp.Quit(false);
            }
            /*if (index == 2)
            {

            }*/
        }

        private void BtnDosyaEkleGun_Click(object sender, EventArgs e)
        {
            if (dosyagun == "")
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi = openFileDialog2.SafeFileName.ToString();
                alinandosya = openFileDialog2.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            File.Copy(alinandosya, dosyagun + "\\" + kaynakdosyaismi);
            fileNamesGun.Add(alinandosya);
            BtnDosyaEkleGun.BackColor = Color.LightGreen;
            webBrowser2.Navigate(dosyagun);
        }
        int haftasonu = 0;
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            string kontrol = Control();
            if (kontrol != "OK")
            {
                MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TimeSpan toplamSureGun = DtBitTarihi.Value - DtBasTarihi.Value;
            TimeSpan toplamSureSaat = DtBitSaati.Value - DtBasSaati.Value;

            int saat = toplamSureSaat.Hours;
            int gunSaat = toplamSureGun.Hours;
            int gun = toplamSureGun.Days;
            int dakika = toplamSureSaat.Minutes;

            if (gun == 0)
            {
                toplamSure = saat + " Saat";
            }
            if (saat == 0)
            {
                toplamSure = gun + " Gün";
            }
            if (saat != 0 && gun != 0)
            {
                toplamSure = gun + " Gün" + saat + " Saat";
            }

            if (saat == 0 && gun == 0)
            {
                if (gunSaat == 23)
                {
                    toplamSure = "1 Gün";
                }
                if (dakika == 59)
                {
                    toplamSure = "1 Saat";
                }
                if (gunSaat == 23 && dakika == 59)
                {
                    toplamSure = "1 Gün 1 Saat";
                }
                if (toplamSure == "")
                {
                    MessageBox.Show("Girilen tarih aralığı hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (toplamSure == "0 Gün")
            {
                toplamSure = "1 Gün";
            }


            DtgList.Rows.Add();
            int sonSatir = DtgList.RowCount - 1;
            DtgList.Rows[sonSatir].Cells["IzinKategori"].Value = CmbIzınKategori.Text;
            DtgList.Rows[sonSatir].Cells["IzinTuru"].Value = CmbIzınTuru.Text;
            DtgList.Rows[sonSatir].Cells["AdiSoyadi"].Value = CmbPersonel.Text;
            DtgList.Rows[sonSatir].Cells["PersonelSiparis"].Value = LblSiparisNo.Text;
            DtgList.Rows[sonSatir].Cells["Unvani"].Value = LblUnvani.Text;
            DtgList.Rows[sonSatir].Cells["MasYeriNo"].Value = LblMasrafYeriNo.Text;
            DtgList.Rows[sonSatir].Cells["Bolumu"].Value = LblBolum.Text;
            DtgList.Rows[sonSatir].Cells["IzinNedeni"].Value = TxtIzinNedeni.Text.ToUpper();
            DtgList.Rows[sonSatir].Cells["BaslamaTarihi"].Value = DtBasTarihi.Value.ToString("d");
            DtgList.Rows[sonSatir].Cells["BaslamaSaati"].Value = DtBasSaati.Value.ToString("t");
            DtgList.Rows[sonSatir].Cells["BitisTarihi"].Value = DtBitTarihi.Value.ToString("d");
            DtgList.Rows[sonSatir].Cells["BitisSaati"].Value = DtBitSaati.Value.ToString("t");
            DtgList.Rows[sonSatir].Cells["TSure"].Value = toplamSure;

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;

            //CmbIzınKategori.SelectedIndex = -1;
            CmbPersonel.SelectedIndex = -1;
            TxtIzinNedeni.Clear();
            //DtBasTarihi.Value = DateTime.Now;
            //DtBitTarihi.Value = DateTime.Now;
            //DtBasSaati.Value = DateTime.Now;
            //DtBitSaati.Value =DateTime.Now;
            toplamSure = "";
            haftasonu = 0;
            dosyaControl = false;
        }
        bool dosyaControl = false;

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void DtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgList.Rows.RemoveAt(e.RowIndex);
            }
        }
        void TaslakKopyala()
        {
            string root = @"C:\DTS";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(yol))
            {
                Directory.CreateDirectory(yol);
            }
            if (CmbIzınTuru.Text == "HAFTALIK İZİN")
            {
                File.Copy(kaynak + "MP-FR-166 HAFTA SONU PERSONEL İZİN FORMU REV (00).docx", yol + "MP-FR-166 HAFTA SONU PERSONEL İZİN FORMU REV (00).docx");
                taslakYolu = yol + "MP-FR-166 HAFTA SONU PERSONEL İZİN FORMU REV (00).docx";
            }

            if (CmbIzınTuru.Text == "MAZERET İZNİ" || CmbIzınTuru.Text == "DOĞUM İZNİ" || CmbIzınTuru.Text == "EVLİLİK İZNİ" || CmbIzınTuru.Text == "ÖLÜM İZNİ" ||
                CmbIzınTuru.Text == "GÜNLÜK İZİN")
            {
                File.Copy(kaynak + "GÜNLÜK İZİN- MGÜB.docx", yol + "GÜNLÜK İZİN- MGÜB.docx");
                taslakYolu = yol + "GÜNLÜK İZİN- MGÜB.docx";
            }

            if (CmbIzınTuru.Text == "YILLIK İZİN")
            {
                File.Copy(kaynak + "YILLIK İZİN - MGÜB.docx", yol + "YILLIK İZİN - MGÜB.docx");
                taslakYolu = yol + "YILLIK İZİN - MGÜB.docx";
            }
        }
        DateTime haftasonuControl;

        void CreateWordFile()
        {
            List<Izin> ızins = new List<Izin>();

            if (CmbIzınTuru.Text== "HAFTALIK İZİN")
            {
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    Izin ızin = new Izin(item.Cells["AdiSoyadi"].Value.ToString(), item.Cells["IzinNedeni"].Value.ToString(), item.Cells["BitisTarihi"].Value.ConDate(), item.Cells["BaslamaTarihi"].Value.ConDate());

                    ızins.Add(ızin);
                }

                Application wApp = new Application();
                Documents wDocs = wApp.Documents;
                object filePath = taslakYolu;
                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false);
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["IsAkisNo"].Range.Text = LblIsAkisNo.Text;
                wBookmarks["DuzenlenmeTarihi"].Range.Text = DateTime.Now.ToString("d");
                wBookmarks["Bolum"].Range.Text = infos[3].ToString();

                if (ızins.Count > 0)
                {
                    wBookmarks["Personel1"].Range.Text = ızins[0].Adsoyad;
                    wBookmarks["BasTarihi1"].Range.Text = ızins[0].Bastarihi.ToString("d");
                    wBookmarks["BitTarihi1"].Range.Text = ızins[0].Bittarihi.ToString("d");
                    wBookmarks["Aciklama1"].Range.Text = ızins[0].Izınnedeni;
                }
                if (ızins.Count > 1)
                {
                    wBookmarks["Personel2"].Range.Text = ızins[1].Adsoyad;
                    wBookmarks["BasTarihi2"].Range.Text = ızins[1].Bastarihi.ToString("d");
                    wBookmarks["BitTarihi2"].Range.Text = ızins[1].Bittarihi.ToString("d");
                    wBookmarks["Aciklama2"].Range.Text = ızins[1].Izınnedeni;
                }
                if (ızins.Count > 2)
                {
                    wBookmarks["Personel3"].Range.Text = ızins[2].Adsoyad;
                    wBookmarks["BasTarihi3"].Range.Text = ızins[2].Bastarihi.ToString("d");
                    wBookmarks["BitTarihi3"].Range.Text = ızins[2].Bittarihi.ToString("d");
                    wBookmarks["Aciklama3"].Range.Text = ızins[2].Izınnedeni;
                }
                if (ızins.Count > 3)
                {
                    wBookmarks["Personel4"].Range.Text = ızins[3].Adsoyad;
                    wBookmarks["BasTarihi4"].Range.Text = ızins[3].Bastarihi.ToString("d");
                    wBookmarks["BitTarihi4"].Range.Text = ızins[3].Bittarihi.ToString("d");
                    wBookmarks["Aciklama4"].Range.Text = ızins[3].Izınnedeni;
                }

                if (ızins.Count > 4)
                {
                    wBookmarks["Personel5"].Range.Text = ızins[4].Adsoyad;
                    wBookmarks["BasTarihi5"].Range.Text = ızins[4].Bastarihi.ToString("d");
                    wBookmarks["BitTarihi5"].Range.Text = ızins[4].Bittarihi.ToString("d");
                    wBookmarks["Aciklama5"].Range.Text = ızins[4].Izınnedeni;
                }
                if (ızins.Count > 5)
                {
                    wBookmarks["Personel6"].Range.Text = ızins[5].Adsoyad;
                    wBookmarks["BasTarihi6"].Range.Text = ızins[5].Bastarihi.ToString("d");
                    wBookmarks["BitTarihi6"].Range.Text = ızins[5].Bittarihi.ToString("d");
                    wBookmarks["Aciklama6"].Range.Text = ızins[5].Izınnedeni;
                }
                if (ızins.Count > 6)
                {
                    wBookmarks["Personel7"].Range.Text = ızins[6].Adsoyad;
                    wBookmarks["BasTarihi7"].Range.Text = ızins[6].Bastarihi.ToString("d");
                    wBookmarks["BitTarihi7"].Range.Text = ızins[6].Bittarihi.ToString("d");
                    wBookmarks["Aciklama7"].Range.Text = ızins[6].Izınnedeni;
                }
                
                wBookmarks["SorumluPersonel"].Range.Text = infos[1].ToString();
                wBookmarks["SorumluTarih"].Range.Text = DateTime.Now.ToString("d");
                wBookmarks["SorumluGorevi"].Range.Text = infos[10].ToString();

                wDoc.SaveAs2(dosya + LblIsAkisNo.Text + ".docx");
                wDoc.Close();
                wApp.Quit(false);

                ızins.Clear();
            }

            if (CmbIzınTuru.Text == "MAZERET İZNİ" || CmbIzınTuru.Text == "DOĞUM İZNİ" || CmbIzınTuru.Text == "EVLİLİK İZNİ" || CmbIzınTuru.Text == "ÖLÜM İZNİ" || 
                CmbIzınTuru.Text == "GÜNLÜK İZİN")
            {
                Application wApp = new Application();
                Documents wDocs = wApp.Documents;
                object filePath = taslakYolu;
                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false);
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["AdSoyad"].Range.Text = CmbPersonel.Text;
                wBookmarks["Departman"].Range.Text =  "MUB " + LblBolum.Text;
                wBookmarks["Unvan"].Range.Text = LblUnvani.Text;

                TimeSpan toplamSureGun = DtBitTarihi.Value - DtBasTarihi.Value;
                TimeSpan toplamSureSaat = DtBitSaati.Value - DtBasSaati.Value;

                int saat = toplamSureSaat.Hours;
                int gunSaat = toplamSureGun.Hours;
                if (gunSaat == 23)
                {
                    gun = toplamSureGun.Days + 1;
                }
                else
                {
                    gun = toplamSureGun.Days;
                }
                int dakika = toplamSureSaat.Minutes;

                if (gun == 0)
                {
                    toplamSure = saat + " Saat";
                }
                if (saat == 0)
                {
                    toplamSure = gun + " Gün";
                }
                if (saat != 0 && gun != 0)
                {
                    toplamSure = gun + " Gün " + saat + " Saat";
                }

                if (saat == 0 && gun == 0)
                {
                    if (gunSaat == 23)
                    {
                        toplamSure = "1 Gün";
                    }
                    if (dakika == 59)
                    {
                        toplamSure = "1 Saat";
                    }
                    if (gunSaat == 23 && dakika == 59)
                    {
                        toplamSure = "1 Gün 1 Saat";
                    }
                    if (toplamSure == "")
                    {
                        MessageBox.Show("Girilen tarih aralığı hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                DateTime basTarihi = new DateTime(DtBasTarihi.Value.Year, DtBasTarihi.Value.Month, DtBasTarihi.Value.Day, DtBasSaati.Value.Hour, DtBasSaati.Value.Minute, DtBasSaati.Value.Second);
                DateTime bitTarihi = new DateTime(DtBitTarihi.Value.Year, DtBitTarihi.Value.Month, DtBitTarihi.Value.Day, DtBitSaati.Value.Hour, DtBitSaati.Value.Minute, DtBitSaati.Value.Second);


                if (DtBitTarihi.Value.Day < DtBasTarihi.Value.Day)
                {
                    haftasonuControl = DtBasTarihi.Value;

                    while (DtBitTarihi.Value.Month > haftasonuControl.Month)
                    {
                        string haftaninGunu = haftasonuControl.ToString("dddd");
                        if (haftaninGunu == "Cumartesi" || haftaninGunu == "Pazar")
                        {
                            haftasonu++;
                        }
                        haftasonuControl = haftasonuControl.AddDays(1);
                    }
                }
                else
                {
                    haftasonuControl = DtBasTarihi.Value;

                    while (DtBitTarihi.Value.Day > haftasonuControl.Day)
                    {
                        string haftaninGunu = haftasonuControl.ToString("dddd");
                        if (haftaninGunu == "Cumartesi" || haftaninGunu == "Pazar")
                        {
                            haftasonu++;
                        }
                        haftasonuControl = haftasonuControl.AddDays(1);
                    }
                }


                string[] sure = toplamSure.Split(' ');
                if (haftasonu != 0)
                {
                    int sureGun = sure[0].ConInt() - haftasonu;
                    toplamSure = sureGun + " Gün";
                }

                haftasonu = 0;


                wBookmarks["İzinCikisTarihi"].Range.Text = basTarihi.ToString("g");
                wBookmarks["İzinDonusTarihi"].Range.Text = bitTarihi.ToString("g");
                wBookmarks["IzinSuresi"].Range.Text = toplamSure;
                wBookmarks["Aciklama"].Range.Text = TxtIzinNedeni.Text;
                wBookmarks["PersonelAd"].Range.Text = CmbPersonel.Text;
                if (CmbIzınTuru.Text == "DOĞUM İZNİ")
                {
                    wBookmarks["Dogum"].Range.Text = "X";
                }
                if (CmbIzınTuru.Text == "EVLİLİK İZNİ")
                {
                    wBookmarks["Evlilik"].Range.Text = "X";
                }
                if (CmbIzınTuru.Text == "GÜNLÜK İZİN")
                {
                    wBookmarks["Gunluk"].Range.Text = "X";
                }
                if (CmbIzınTuru.Text == "ÖLÜM İZNİ")
                {
                    wBookmarks["Olum"].Range.Text = "X";
                }
                if (CmbIzınKategori.Text == "ÜCRETLİ İZİN")
                {
                    wBookmarks["Ucretli"].Range.Text = "X";
                }
                if (CmbIzınKategori.Text == "ÜCRETSİZ İZİN")
                {
                    wBookmarks["Ucretsiz"].Range.Text = "X";
                }

                wDoc.SaveAs2(dosya + LblIsAkisNo.Text + ".docx");
                wDoc.Close();
                wApp.Quit(false);
            }

            if (CmbIzınTuru.Text == "YILLIK İZİN")
            {
                TimeSpan toplamSureGun = DtBitTarihi.Value - DtBasTarihi.Value;
                TimeSpan toplamSureSaat = DtBitSaati.Value - DtBasSaati.Value;
                
                int saat = toplamSureSaat.Hours;
                int gunSaat = toplamSureGun.Hours;

                if (gunSaat==23)
                {
                    gun = toplamSureGun.Days + 1;
                }
                else
                {
                    gun = toplamSureGun.Days;
                }
                
                int dakika = toplamSureSaat.Minutes;

                if (gun == 0)
                {
                    toplamSure = saat + " Saat";
                }
                if (saat == 0)
                {
                    toplamSure = gun + " Gün";
                }
                if (saat != 0 && gun != 0)
                {
                    toplamSure = gun + " Gün " + saat + " Saat";
                }

                if (saat == 0 && gun == 0)
                {
                    if (gunSaat == 23)
                    {
                        toplamSure = "1 Gün";
                    }
                    if (dakika == 59)
                    {
                        toplamSure = "1 Saat";
                    }
                    if (gunSaat == 23 && dakika == 59)
                    {
                        toplamSure = "1 Gün 1 Saat";
                    }
                    if (toplamSure == "")
                    {
                        MessageBox.Show("Girilen tarih aralığı hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                if (DtBitTarihi.Value.Day < DtBasTarihi.Value.Day)
                {
                    haftasonuControl = DtBasTarihi.Value;

                    while (DtBitTarihi.Value.Month > haftasonuControl.Month)
                    {
                        string haftaninGunu = haftasonuControl.ToString("dddd");
                        if (haftaninGunu == "Cumartesi" || haftaninGunu == "Pazar")
                        {
                            haftasonu++;
                        }
                        haftasonuControl = haftasonuControl.AddDays(1);
                    }
                }
                else
                {
                    haftasonuControl = DtBasTarihi.Value;

                    while (DtBitTarihi.Value.Day > haftasonuControl.Day)
                    {
                        string haftaninGunu = haftasonuControl.ToString("dddd");
                        if (haftaninGunu == "Cumartesi" || haftaninGunu == "Pazar")
                        {
                            haftasonu++;
                        }
                        haftasonuControl = haftasonuControl.AddDays(1);
                    }
                }

                string[] sure = toplamSure.Split(' ');
                if (haftasonu != 0)
                {
                    int sureGun = sure[0].ConInt() - haftasonu;
                    toplamSure = sureGun + " Gün";
                }
                haftasonu = 0;

                PersonelKayit personelKayit = kayitManager.Get(0, CmbPersonel.Text);
                Application wApp = new Application();
                Documents wDocs = wApp.Documents;
                object filePath = taslakYolu;
                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false);
                wDoc.Activate();
                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["Tarih"].Range.Text = DateTime.Now.ToString("d");
                wBookmarks["Tc"].Range.Text = personelKayit.Tc;
                wBookmarks["Bolum"].Range.Text = LblBolum.Text;
                wBookmarks["Yil"].Range.Text = DateTime.Now.ToString("yyyy");
                wBookmarks["TarihBaslangic"].Range.Text = DtBasTarihi.Value.ToString("d");
                wBookmarks["TarihBitis"].Range.Text = DtBitTarihi.Value.ToString("d");
                wBookmarks["AdSoyad"].Range.Text = CmbPersonel.Text;
                wBookmarks["Unvan"].Range.Text = LblUnvani.Text;
                wBookmarks["IseGirisTarihi"].Range.Text = personelKayit.Isegiristarihi.ToString("dd.MM") + "." + DateTime.Now.ToString("yyyy");
                wBookmarks["IzinBasTarihi"].Range.Text = DtBasTarihi.Value.ToString("d");
                wBookmarks["IzinBitTarihi"].Range.Text = DtBitTarihi.Value.ToString("d");
                DateTime isBasiTarih = DtBitTarihi.Value;
                string isBasiGun = isBasiTarih.ToString("dddd");
                DateTime isBasi = isBasiTarih;
                if (isBasiGun=="Cumartesi")
                {
                    isBasi = isBasiTarih.AddDays(2);
                }
                if (isBasiGun == "Pazar")
                {
                    isBasi = isBasiTarih.AddDays(1);
                }

                wBookmarks["IsBasiYapacagiTarih"].Range.Text = isBasi.ToString("d");
                wBookmarks["IzınSuresi"].Range.Text = toplamSure;
                wBookmarks["YolIzni"].Range.Text = " ";
                wBookmarks["IzinAdres"].Range.Text = personelKayit.Dogumyeri;
                wBookmarks["Telefon"].Range.Text = personelKayit.Sirketcep;
                wBookmarks["Aciklama"].Range.Text = TxtIzinNedeni.Text;

                wDoc.SaveAs2(dosya + LblIsAkisNo.Text + ".docx");
                wDoc.Close();
                wApp.Quit(false);
            }
            

            try
            {
                Directory.Delete(yol, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                File.Delete(taslakYolu);
            }

        }
        void CreateDirectory()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\İZİN\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            if (!Directory.Exists(anadosya))
            {
                Directory.CreateDirectory(anadosya);
            }

            dosya = anadosya + LblIsAkisNo.Text + "\\";
            Directory.CreateDirectory(dosya);
        }

        private void CmbIzınTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DtgList.RowCount != 0)
            {
                if (DtgList.CurrentRow.Cells["IzinTuru"].Value.ToString() != CmbIzınTuru.Text)
                {
                    MessageBox.Show("Lütfen ilgili izin türünün kayıtlarını tamamladıktan sonra farklı bir izin türü seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbIzınTuru.Text = DtgList.CurrentRow.Cells["IzinTuru"].Value.ToString();
                }
            }
        }
        

        private void BtnKaydet_Click_2(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr!=DialogResult.Yes)
            {
                return;
            }
            //if (DtgList.RowCount==0)
            //{
            //    MessageBox.Show("Lütfen öncelikle tabloya veri ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (CmbIzınTuru.Text=="RAPOR")
            {
                if (dosyaControl == false)
                {
                    MessageBox.Show("Lütfen öncelikle Raporu taratarak ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime basTarihi = new DateTime(DtBasTarihi.Value.Year, DtBasTarihi.Value.Month, DtBasTarihi.Value.Day, DtBasSaati.Value.Hour, DtBasSaati.Value.Minute, DtBasSaati.Value.Second);
                DateTime bitTarihi = new DateTime(DtBitTarihi.Value.Year, DtBitTarihi.Value.Month, DtBitTarihi.Value.Day, DtBitSaati.Value.Hour, DtBitSaati.Value.Minute, DtBitSaati.Value.Second);

                TimeSpan toplamSureGun = DtBitTarihi.Value - DtBasTarihi.Value;
                TimeSpan toplamSureSaat = DtBitSaati.Value - DtBasSaati.Value;

                int saat = toplamSureSaat.Hours;
                int gunSaat = toplamSureGun.Hours;
                int gun = toplamSureGun.Days;
                int dakika = toplamSureSaat.Minutes;

                if (gun == 0)
                {
                    toplamSure = saat + " Saat";
                }
                if (saat == 0)
                {
                    toplamSure = gun + " Gün";
                }
                if (saat != 0 && gun != 0)
                {
                    toplamSure = gun + " Gün" + saat + " Saat";
                }

                if (saat == 0 && gun == 0)
                {
                    if (gunSaat == 23)
                    {
                        toplamSure = "1 Gün";
                    }
                    if (dakika == 59)
                    {
                        toplamSure = "1 Saat";
                    }
                    if (gunSaat == 23 && dakika == 59)
                    {
                        toplamSure = "1 Gün 1 Saat";
                    }
                    if (toplamSure == "")
                    {
                        MessageBox.Show("Girilen tarih aralığı hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (toplamSure == "0 Gün")
                {
                    toplamSure = "1 Gün";
                }

                Izin ızin = new Izin(LblIsAkisNo.Text.ConInt(), CmbIzınKategori.Text, CmbIzınTuru.Text, LblSiparisNo.Text, CmbPersonel.Text, LblUnvani.Text, LblMasrafYeriNo.Text, LblBolum.Text, TxtIzinNedeni.Text, basTarihi, bitTarihi, toplamSure, dosya, "");
                string mesaj = izinManager.Add(ızin);

                if (mesaj == "OK")
                {
                    CreateLog();
                }
                else
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Izin ızin1 = izinManager.Get(LblIsAkisNo.Text.ConInt());
                izinId = ızin1.Id;
                if (ızin1 != null)
                {
                    GorevAtama();
                }

                isAkisNoManager.UpdateKontrolsuz();
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                DtgList.Rows.Clear();
                CmbIzınTuru.SelectedIndex = -1;
                CmbIzınKategori.SelectedIndex = -1;
                CmbPersonel.SelectedIndex = -1;
                haftasonu = 0;
                return;

            }

            IsAkisNo();
            TaslakKopyala();
            CreateDirectory();
            CreateWordFile();

            if (CmbIzınTuru.Text == "HAFTALIK İZİN")
            {

                siparisNo = Guid.NewGuid().ToString();
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    Izin ızin = new Izin(LblIsAkisNo.Text.ConInt(), item.Cells["IzinKategori"].Value.ToString(), item.Cells["IzinTuru"].Value.ToString(), item.Cells["PersonelSiparis"].Value.ToString(), item.Cells["AdiSoyadi"].Value.ToString(), item.Cells["Unvani"].Value.ToString(), item.Cells["MasYeriNo"].Value.ToString(), item.Cells["Bolumu"].Value.ToString(), item.Cells["IzinNedeni"].Value.ToString(), item.Cells["BaslamaTarihi"].Value.ConDate(), item.Cells["BitisTarihi"].Value.ConDate(), item.Cells["TSure"].Value.ToString(), dosya, siparisNo);

                    izinManager.Add(ızin);

                    Izin ızin1 = izinManager.Get(LblIsAkisNo.Text.ConInt());
                    izinId = ızin1.Id;
                    CreateLog();
                    if (ızin1 != null)
                    {
                        GorevAtama();
                    }
                }
            }
            else
            {
                DateTime basTarihi = new DateTime(DtBasTarihi.Value.Year, DtBasTarihi.Value.Month, DtBasTarihi.Value.Day, DtBasSaati.Value.Hour, DtBasSaati.Value.Minute, DtBasSaati.Value.Second);
                DateTime bitTarihi = new DateTime(DtBitTarihi.Value.Year, DtBitTarihi.Value.Month, DtBitTarihi.Value.Day, DtBitSaati.Value.Hour, DtBitSaati.Value.Minute, DtBitSaati.Value.Second);

                Izin ızin = new Izin(LblIsAkisNo.Text.ConInt(), CmbIzınKategori.Text, CmbIzınTuru.Text, LblSiparisNo.Text, CmbPersonel.Text, LblUnvani.Text, LblMasrafYeriNo.Text, LblBolum.Text, TxtIzinNedeni.Text, basTarihi, bitTarihi, toplamSure, dosya, "");
                string mesaj = izinManager.Add(ızin);

                if (mesaj=="OK")
                {
                    CreateLog();
                }
                else
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Izin ızin1 = izinManager.Get(LblIsAkisNo.Text.ConInt());
                izinId = ızin1.Id;
                if (ızin1 != null)
                {
                    GorevAtama();
                }

            }

            isAkisNoManager.UpdateKontrolsuz();
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            DtgList.Rows.Clear();
            CmbIzınTuru.SelectedIndex = -1;
            CmbIzınKategori.SelectedIndex = -1;
            CmbPersonel.SelectedIndex = -1;
            haftasonu = 0;
        }
        string GorevAtama()
        {   
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(izinId, "İZİN", "RESUL GÜNEŞ", "İZİN ONAYI", DateTime.Now, "", DateTime.Now.Date);
            string kontrol = gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            if (kontrol != "OK")
            {
                return kontrol;
            }
            return "OK";
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\İZİN\";

            /*string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\İZİN\";*/
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(anadosya))
            {
                Directory.CreateDirectory(anadosya);
            }
            dosya = anadosya + LblIsAkisNo.Text + "\\";
            if (!Directory.Exists(dosya))
            {
                Directory.CreateDirectory(dosya);
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
            if (File.Exists(dosya + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosya + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                webBrowser1.Navigate(dosya);
                dosyaControl = true;
            }
        }


        string Control()
        {
            if (CmbIzınTuru.Text== "YILLIK İZİN")
            {
                return "Yıllık izin toplu olarak girilemez!\nTüm bilgiler doğru seçildiyse tabloya eklemeden kaydedebilirsiniz.";
            }
            if (CmbIzınTuru.Text == "MAZERET İZNİ" || CmbIzınTuru.Text == "DOĞUM İZNİ" || CmbIzınTuru.Text == "EVLİLİK İZNİ" || CmbIzınTuru.Text == "ÖLÜM İZNİ" ||
                CmbIzınTuru.Text == "GÜNLÜK İZİN")
            {
                return CmbIzınTuru.Text + " toplu olarak girilemez!\nTüm bilgiler doğru seçildiyse tabloya eklemeden kaydedebilirsiniz.";
            }
            if (CmbIzınTuru.Text == "RAPOR")
            {
                return "Rapor izin toplu olarak girilemez!\nTüm bilgiler doğru seçildiyse tabloya eklemeden kaydedebilirsiniz.";
            }
            
            if (CmbIzınKategori.Text=="")
            {
                return "Lütfen öncelikle İzin Kategori bilgisini doldurunuz!";
            }
            if (CmbIzınTuru.Text=="")
            {
                return "Lütfen öncelikle İzin Türü bilgisini doldurunuz!";
            }
            if (CmbIzınTuru.Text == "")
            {
                return "Lütfen öncelikle İzin Türü bilgisini doldurunuz!";
            }
            if (CmbPersonel.Text == "")
            {
                return "Lütfen öncelikle Personel bilgisini doldurunuz!";
            }
            if (TxtIzinNedeni.Text == "")
            {
                return "Lütfen öncelikle İzin Nedeni bilgisini doldurunuz!";
            }
            if (DtgList.RowCount!=0)
            {
                if (DtgList.CurrentRow.Cells["IzinTuru"].Value.ToString() != CmbIzınTuru.Text)
                {
                    return "Lütfen "+ CmbIzınTuru.Text + " izin türünün kayıtlarını tamamladıktan sonra farklı bir izin türü seçiniz!";
                }
            }
            
            return "OK";
        }


        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtIzinGuncelle.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Bir İş Akış Numarası Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(TxtIzinGuncelle.Text + " Nolu Personel İzin Kaydını Silmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = izinManager.Delete(id);
                Directory.Delete(dosyagun, true);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Silme İşlemi Başarıyla Gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }
        }

        void IzinSuresi()
        {
            DateTime bTarih = DtBasTarihi.Value;
            DateTime kTarih = DtBitTarihi.Value;
            TimeSpan SonucGun = kTarih - bTarih;

            DateTime bSaat = DtBasSaati.Value;
            DateTime kSaat = DtBitSaati.Value;
            TimeSpan SonucSaat = kSaat - bSaat;

            sonucGun = SonucGun.TotalDays.ConInt();
            sonucSaat = SonucSaat.TotalHours.ConInt();
            if (sonucGun > 0)
            {
                toplamsaat = sonucGun * 24;
            }
            toplamsaat += sonucSaat;
            if (toplamsaat < 24)
            {
                izinsuresi = toplamsaat.ToString() + " Saat";
            }
            else
            {
                kalansaat = (toplamsaat % 24).ConInt();
                kalangun = (toplamsaat - kalansaat) / 24;
                if (kalansaat == 0)
                {
                    izinsuresi = kalangun.ToString() + " Gün";
                    return;
                }

                izinsuresi = kalangun.ToString() + " Gün, " + kalansaat.ToString() + " Saat";
            }

            /*DateTime bTarih = DtBasTarihi.Value;
            DateTime kTarih = DtBitTarihi.Value;
            TimeSpan Sonuc = kTarih - bTarih;
            int gun = Sonuc.TotalDays.ConInt();
            izinSuresi = gun.ToString() + " Gün";*/
        }
        int id;
        private void BtnBul_Click(object sender, EventArgs e)
        {

            if (TxtIzinGuncelle.MaskFull) // true false dondurur şu an true ise ife giricek false ise girmicek.
            {

                Izin ızin = izinManager.Get(TxtIzinGuncelle.Text.ConInt());
                if (ızin == null)
                {
                    MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TemizleGuncelle();
                    return;
                }
                id = ızin.Id;
                dosyagun = ızin.Dosyayolu;
                CmbKategori.Text = ızin.Izinkategori;
                CmbTuru.Text = ızin.Izinturu;
                CmbSiparis.Text = ızin.Siparisno;
                CmbAd.Text = ızin.Adsoyad;
                TxtMasrafyeri.Text = ızin.Masrafyerino;
                TxtBolumu.Text = ızin.Bolum;
                TxtNedeni.Text = ızin.Izınnedeni;
                DtTarihBaslama.Value = ızin.Bastarihi;
                DtTarihBitis.Value = ızin.Bittarihi;
                webBrowser2.Navigate(dosyagun);
                BtnDosyaEkleGun.BackColor = Color.Transparent;
                return;
            }
            MessageBox.Show("Lütfen 9 haneli İş Akiş Numarasını Eksiksiz Girinz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            TemizleGuncelle();
        }

        void Temizle()
        {
            IsAkisNo(); CmbIzınKategori.Text = ""; CmbIzınTuru.Text = ""; LblSiparisNo.Text = "00"; CmbPersonel.Text = ""; LblMasrafYeriNo.Text = "00";
            LblBolum.Text = "00"; TxtIzinNedeni.Clear(); LblUnvani.Text = "00"; webBrowser1.Navigate("");
        }
        void TemizleGuncelle()
        {
            TxtIzinGuncelle.Clear(); CmbKategori.Text = ""; CmbTuru.Text = ""; CmbSiparis.Text = ""; CmbAd.Text = ""; TxtMasrafyeri.Text = ""; TxtBolumu.Text = "";
            TxtNedeni.Text = ""; TxtGoreviGun.Clear(); webBrowser2.Navigate(""); 
        }

        private void CmbDokumanTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbDokumanTuru.SelectedIndex.ConInt();
        }


        private void Sil_Click(object sender, EventArgs e)
        {
            TemizleGuncelle();
        }

        private void CmbAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start3 == true)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAd.Text);
            CmbSiparis.Text = siparis.Siparis;
            TxtMasrafyeri.Text = siparis.Masrafyerino;
            TxtBolumu.Text = siparis.Bolum;
            TxtGoreviGun.Text = siparis.Gorevi;
        }

        private void CmbSiparis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start3)
            {
                if (start4 == true)
                {
                    return;
                }
            }
            siparis = CmbSiparis.Text;
            SiparisIsimlerDoldurGuncelle();
            TxtGoreviGun.Clear();
            TxtMasrafyeri.Clear();
            TxtBolumu.Clear();
            start3 = true;
        }

        private void Guncelle_Click(object sender, EventArgs e)
        {
            if (TxtIzinGuncelle.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İş Akış Numarası Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IzinSuresiGuncelle();
                Izin ızin = new Izin(TxtIzinGuncelle.Text.ConInt(), CmbKategori.Text, CmbTuru.Text, CmbSiparis.Text, CmbAd.Text, TxtGoreviGun.Text, TxtMasrafyeri.Text, TxtBolumu.Text, TxtNedeni.Text, DtTarihBaslama.Value, DtTarihBitis.Value, izinsuresi, dosyagun, "");
                string mesaj = izinManager.Update(ızin, TxtIzinGuncelle.Text.ConInt());
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLogGuncelle();
                mesaj = BildirimKayitGuncelle();
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
                BtnDosyaEkleGun.BackColor = Color.Transparent;
            }

        }
        void CreateLogGuncelle()
        {
            string sayfa = "İZİN";
            Izin gorev = izinManager.Get(TxtIzinGuncelle.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "İZİN BİLGİLERİ GÜNCELLENDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void IzinSuresiGuncelle()
        {
            DateTime bTarih = DtTarihBaslama.Value;
            DateTime kTarih = DtTarihBitis.Value;
            TimeSpan SonucGun = kTarih - bTarih;

            DateTime bSaat = DtBaslamaSaati.Value;
            DateTime kSaat = DtBitisSaati.Value;
            TimeSpan SonucSaat = kSaat - bSaat;

            sonucGun = SonucGun.TotalDays.ConInt();
            sonucSaat = SonucSaat.TotalHours.ConInt();
            if (sonucGun > 0)
            {
                toplamsaat = sonucGun * 24;
            }
            toplamsaat += sonucSaat;
            if (toplamsaat < 24)
            {
                izinsuresi = toplamsaat.ToString() + " Saat";
            }
            else
            {
                kalansaat = (toplamsaat % 24).ConInt();
                kalangun = (toplamsaat - kalansaat) / 24;
                if (kalansaat == 0)
                {
                    izinsuresi = kalangun.ToString() + " Gün";
                    return;
                }
                izinsuresi = kalangun.ToString() + " Gün, " + kalansaat.ToString() + " Saat";
            }

            /*DateTime bTarih = DtTarihBaslama.Value;
            DateTime kTarih = DtTarihBitis.Value;
            TimeSpan Sonuc = kTarih - bTarih;
            int gun = Sonuc.TotalDays.ConInt();
            izinSuresiGun = gun.ToString() + " Gün";*/
        }
    }
}
