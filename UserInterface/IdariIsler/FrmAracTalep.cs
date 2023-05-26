using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity.AnaSayfa;
using Entity.IdariIsler;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;

namespace UserInterface.IdariIsler
{
    public partial class FrmAracTalep : Form
    {
        AracTalepManager aracTalepManager;
        YurtIciGorevManager yurtIciGorevManager;
        SiparisPersonelManager siparisPersonelManager;
        PersonelKayitManager kayitManager;
        AracZimmetiManager aracZimmetiManager;
        SehiriciGorevManager sehiriciGorevManager;
        ButceKoduManager butceKoduManager;
        BildirimYetkiManager bildirimYetkiManager;

        List<AracZimmeti> aracZimmetis;
        List<AracTalep> aracTaleps;
        bool start;
        public object[] infos;
        string dosyaYolu, taslakYolu, isAkisNo;
        string yol = @"C:\DTS\Taslak\";
        string kaynak = @"Z:\DTS\İDARİ İŞLER\WordTaslak\";

        int id;

        public FrmAracTalep()
        {
            InitializeComponent();
            aracTalepManager = AracTalepManager.GetInstance();
            yurtIciGorevManager = YurtIciGorevManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            aracZimmetiManager = AracZimmetiManager.GetInstance();
            sehiriciGorevManager = SehiriciGorevManager.GetInstance();
            butceKoduManager = ButceKoduManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
        }

        private void FrmAracTalep_Load(object sender, EventArgs e)
        {
            Personeller();
            Plakalar();
            DataDisplay();
            ButceKoduKalemi();
            start = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageAracTalep"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void ButceKoduKalemi()
        {
            CmbButceKodu.DataSource = butceKoduManager.GetList();
            CmbButceKodu.ValueMember = "Id";
            CmbButceKodu.DisplayMember = "Butcekodu";
            CmbButceKodu.SelectedValue = 0;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (LblPersonelSiparisNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir Görev Emri No Yazıp BUL Butonuna basınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DateTime baslamaTarihi = new DateTime(DtBaslamaTarihi.Value.Year, DtBaslamaTarihi.Value.Month, DtBaslamaTarihi.Value.Day, DtgBaslamaSaati.Value.Hour, DtgBaslamaSaati.Value.Minute, DtgBaslamaSaati.Value.Second);

                DateTime bitisTarihi = new DateTime(DtBitisTarihi.Value.Year, DtBitisTarihi.Value.Month, DtBitisTarihi.Value.Day, DtgBitisSaati.Value.Hour, DtgBitisSaati.Value.Minute, DtgBitisSaati.Value.Second);

                string geciciDosya = @"Z:\DTS\İDARİ İŞLER\ARAÇ TALEP\" + TxtIsAkisNo.Text + "\\";


                AracTalep aracTalep = new AracTalep(TxtIsAkisNo.Text, CmbButceKodu.Text, TxtTalepNedeni.Text, TxtGidilecekYer.Text, baslamaTarihi, bitisTarihi, TxtToplamSure.Text, CmbTalepEdenAd.Text, LblPersonelSiparisNo.Text, LblUnvani.Text, LblMasrafYeriNo.Text, LblMasrafYeri.Text, LblMasrafYeriSorumlusu.Text, CmbPlaka.Text, LblAracSiparisNo.Text, TxtCikisKm.Text.ConInt(), LblZimmetliPersonel.Text, geciciDosya);


                string mesaj = aracTalepManager.Add(aracTalep);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                TaslakKopyala();
                CreateWord();

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string messege = BildirimKayit();
                if (messege!="OK")
                {
                    MessageBox.Show(messege, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Temizle();
                DataDisplay();
            }

        }

        string BildirimKayit()
        {
            string[] array = new string[8];

            array[0] = "Araç Talep"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = TxtIsAkisNo.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "iş akış numaralı"; // Bildirim türü
            array[4] = CmbTalepEdenAd.Text + " personel için"; // İÇERİK
            array[5] = TxtGidilecekYer.Text + "istikametine gitmek üzere";
            array[6] = CmbPlaka.Text+ " Plakalı araç için araç talep kaydı oluşturmuştur!";

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
        string BildirimKayitKapat()
        {
            string[] array = new string[8];

            array[0] = "Araç Talep"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = LblIsAkisNo.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "iş akış numaralı"; // Bildirim türü
            array[4] = personelAd + " personel için"; // İÇERİK
            array[5] = gidilecekYer + "istikametine gitmek üzere";
            array[6] = CmbPlaka.Text + " Plakalı araç için oluşturulan kaydı kapatmıştır!";

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

            File.Copy(kaynak + "MP-FR-091 ARAÇ TALEP FORMU REV (01).docx", yol + "MP-FR-091 ARAÇ TALEP FORMU REV (01).docx");

            taslakYolu = yol + "MP-FR-091 ARAÇ TALEP FORMU REV (01).docx";
        }
        //static int outValue = 0;
        void CreateWord()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\ARAÇ TALEP\";

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

            dosyaYolu = anadosya + isAkisNo + "\\";
            Directory.CreateDirectory(dosyaYolu);

            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = taslakYolu;

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["TalepEdenBolum"].Range.Text = LblMasrafYeri.Text;
            wBookmarks["Tarih"].Range.Text = DateTime.Now.ToString("dd.MM.yyyy");
            wBookmarks["AracTalepNedeni"].Range.Text = TxtTalepNedeni.Text;
            wBookmarks["TalepEdenPersonel"].Range.Text = CmbTalepEdenAd.Text;
            wBookmarks["GidilecekYer"].Range.Text = TxtGidilecekYer.Text;
            wBookmarks["GidilecekKurum"].Range.Text = TxtGidilecekKurum.Text;
            wBookmarks["GorevCikisTarihi"].Range.Text = DtBaslamaTarihi.Value.ToString("dd.MM.yyyy");
            wBookmarks["GorevDonusTarihi"].Range.Text = DtBitisTarihi.Value.ToString("dd.MM.yyyy");
            wBookmarks["CikisSaati"].Range.Text = DtgBaslamaSaati.Value.ToString("t");
            wBookmarks["DonusSaati"].Range.Text = DtgBitisSaati.Value.ToString("t");
            wBookmarks["MasrafYeriSor"].Range.Text = LblMasrafYeriSorumlusu.Text;
            wBookmarks["GoreveGidenPersonel"].Range.Text = CmbTalepEdenAd.Text;
            wBookmarks["CikisKm"].Range.Text = TxtCikisKm.Text;
            wBookmarks["AracTeslimEden"].Range.Text = infos[1].ToString();
            wBookmarks["AracTeslimAlan"].Range.Text = CmbTalepEdenAd.Text;
            wBookmarks["DonusKm"].Range.Text = "";
            wBookmarks["Plaka"].Range.Text = CmbPlaka.Text;
            wBookmarks["TarihOnay"].Range.Text = DateTime.Now.ToString("dd.MM.yyyy");


            wDoc.SaveAs2(dosyaYolu + isAkisNo + ".docx");
            wDoc.Close();
            wApp.Quit(false);

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
        void Personeller()
        {
            CmbTalepEdenAd.DataSource = kayitManager.PersonelAdSoyad();
            CmbTalepEdenAd.ValueMember = "Id";
            CmbTalepEdenAd.DisplayMember = "Adsoyad";
            CmbTalepEdenAd.SelectedValue = -1;
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir Görev Emri No Yazıp BUL Butonuna basınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            YurtIciGorev yurtIciGorev = yurtIciGorevManager.AracTalepGet(TxtIsAkisNo.Text);
            if (yurtIciGorev != null)
            {
                CmbButceKodu.Text = yurtIciGorev.Butcekodu;
                TxtTalepNedeni.Text = yurtIciGorev.Gorevinkonusu;
                TxtGidilecekYer.Text = yurtIciGorev.Gidilecekyer;
                DtBaslamaTarihi.Value = yurtIciGorev.Baslamatarihi;
                DtBitisTarihi.Value = yurtIciGorev.Bitistarihi;
                CmbTalepEdenAd.Text = yurtIciGorev.Adsoyad;
                CmbPlaka.Text = yurtIciGorev.Plaka;
                TxtCikisKm.Text = yurtIciGorev.Cikiskm.ToString();
                isAkisNo = yurtIciGorev.Isakisno.ToString();

                DateTime bTarih = DtBaslamaTarihi.Value;
                DateTime kTarih = DtBitisTarihi.Value;
                TimeSpan Sonuc = kTarih - bTarih;
                int gun = Sonuc.TotalDays.ConInt();
                if (gun == 0)
                {
                    TxtToplamSure.Text = "1 Gün";
                }
                else
                {
                    TxtToplamSure.Text = gun.ToString() + " Gün";
                }
                return;
            }

            SehiriciGorev sehiriciGorev = sehiriciGorevManager.Get(TxtIsAkisNo.Text.ConInt());
            if (sehiriciGorev != null)
            {
                TxtGidilecekYer.Text = sehiriciGorev.Gidilecekyer;
                DtBaslamaTarihi.Value = sehiriciGorev.Baslamatarihi;
                DtgBaslamaSaati.Value = sehiriciGorev.Baslamatarihi;
                CmbTalepEdenAd.Text = sehiriciGorev.Adsoyad;
                isAkisNo = sehiriciGorev.Isakisno.ToString();
                return;
            }

            MessageBox.Show("Girmiş olduğunuz İş Akış Numarasına göre bir kayıt bulunamamıştır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        private void BtnSureHesapla_Click(object sender, EventArgs e)
        {
            DateTime bTarih = DtBaslamaTarihi.Value;
            DateTime kTarih = DtBitisTarihi.Value;
            TimeSpan Sonuc = kTarih - bTarih;
            int gun = Sonuc.TotalDays.ConInt() + 1;
            if (gun == 0)
            {
                TxtToplamSure.Text = "1 Gün";
            }
            else
            {
                TxtToplamSure.Text = gun.ToString() + " Gün";
            }
        }

        private void CmbTalepEdenAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (CmbTalepEdenAd.SelectedIndex == -1)
            {
                LblPersonelSiparisNo.Text = "00";
                LblUnvani.Text = "00";
                LblMasrafYeriNo.Text = "00";
                LblMasrafYeri.Text = "00";
                LblMasrafYeriSorumlusu.Text = "00";
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbTalepEdenAd.Text);
            if (siparis == null)
            {
                MessageBox.Show("Personel Bulunamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LblMasrafYeriNo.Text = siparis.Masrafyerino;
            LblMasrafYeri.Text = siparis.Masrafyeri;
            LblUnvani.Text = siparis.Gorevi;
            LblPersonelSiparisNo.Text = siparis.Siparis;
            LblMasrafYeriSorumlusu.Text = siparis.MasrafYeriSorumlusu;

        }

        private void CmbPlaka_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (CmbPlaka.Text == "")
            {
                LblAracSiparisNo.Text = "00";
                LblZimmetliPersonel.Text = "00";
                return;
            }
            AracZimmeti aracZimmeti = aracZimmetiManager.Get(CmbPlaka.Text);
            LblAracSiparisNo.Text = aracZimmeti.SiparisNo;
            LblZimmetliPersonel.Text = aracZimmeti.PersonelAd;
        }
        void Plakalar()
        {
            aracZimmetis = aracZimmetiManager.GetList();
            CmbPlaka.DataSource = aracZimmetis;
            CmbPlaka.ValueMember = "Id";
            CmbPlaka.DisplayMember = "Plaka";
            CmbPlaka.SelectedValue = -1;
        }
        
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        string personelAd, plaka, gidilecekYer;
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            isAkisNo = DtgList.CurrentRow.Cells["GorevEmriNo"].Value.ToString();
            LblIsAkisNo.Text = DtgList.CurrentRow.Cells["GorevEmriNo"].Value.ToString();
            DtDonusTarihi.Value = DtgList.CurrentRow.Cells["BitisTarihiSaati"].Value.ConDate();
            DtDonusSaati.Value = DtgList.CurrentRow.Cells["BitisTarihiSaati"].Value.ConDate();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            dosyaYolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            personelAd = DtgList.CurrentRow.Cells["PersonelAd"].Value.ToString();
            plaka = DtgList.CurrentRow.Cells["Plaka"].Value.ToString();
            gidilecekYer = DtgList.CurrentRow.Cells["GidilecekYer"].Value.ToString();
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle geçerli bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtDonusKm.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle dönüş kilometresini eksiksiz giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtDonusKm.Text == "0")
            {
                MessageBox.Show("Lütfen öncelikle dönüş kilometresini eksiksiz giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DateTime donusTarihiSaati = new DateTime(DtDonusTarihi.Value.Year, DtDonusTarihi.Value.Month, DtDonusTarihi.Value.Day, DtDonusSaati.Value.Hour, DtDonusSaati.Value.Minute, DtDonusSaati.Value.Second);

                string mesaj = aracTalepManager.KayitKapat(donusTarihiSaati, TxtDonusKm.Text.ConInt(), id);

                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //TaslakKopyala();
                CreateWordKapat();
                MessageBox.Show("Bilgiler Başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string messege = BildirimKayitKapat();
                if (messege != "OK")
                {
                    MessageBox.Show(messege, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                id = 0;
                DataDisplay();
                TxtDonusKm.Clear();
            }
        }


        void CreateWordKapat()
        {
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }

            string[] array = dosyaYolu.Split('\\');
            //string dosyaAdi = array[3].ToString();

            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = dosyaYolu + isAkisNo + ".docx";

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;

            wBookmarks["GorevDonusTarihi"].Range.Text = "";
            wBookmarks["GorevDonusTarihi"].Range.Text = DtDonusTarihi.Value.ToString("dd.MM.yyyy");
            wBookmarks["DonusSaati"].Range.Text = DtDonusSaati.Text;
            wBookmarks["DonusKm"].Range.Text = TxtDonusKm.Text;

            wDoc.SaveAs2(dosyaYolu + isAkisNo + "_" + DateTime.Now.ToString("ss") + ".docx");
            wDoc.Close();
            wApp.Quit(false);

        }

        void Temizle()
        {
            TxtIsAkisNo.Clear(); CmbButceKodu.Text = ""; TxtTalepNedeni.Clear(); TxtGidilecekYer.Clear(); TxtToplamSure.Clear(); CmbTalepEdenAd.SelectedIndex = -1;
            CmbPlaka.Text = ""; TxtCikisKm.Clear(); TxtGidilecekKurum.Clear(); LblAracSiparisNo.Text = "00"; LblZimmetliPersonel.Text = "00";
        }

        private void TxtDonusKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        void DataDisplay()
        {
            aracTaleps = aracTalepManager.GetListDevam("DEVAM EDEN");
            dataBinder.DataSource = aracTaleps.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["GorevEmriNo"].HeaderText = "GÖREV EMRİ NO";
            DtgList.Columns["ButceKoduTanimi"].HeaderText = "BÜTÇE KODU/TANIMI";
            DtgList.Columns["AracTalepNedeni"].HeaderText = "TALEP NEDENİ";
            DtgList.Columns["GidilecekYer"].HeaderText = "GİDİLECEK YER";
            DtgList.Columns["BaslamaTarihiSaati"].HeaderText = "BAŞLAMA TARİHİ/SAATİ";
            DtgList.Columns["BitisTarihiSaati"].HeaderText = "BİTİŞ TARİHİ/SAATİ";
            DtgList.Columns["ToplamSure"].HeaderText = "TOPLAM SÜRE";
            DtgList.Columns["PersonelAd"].HeaderText = "PERSONEL ADI";
            DtgList.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgList.Columns["Unvani"].HeaderText = "UNVANİ";
            DtgList.Columns["PersonelMasYeriNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgList.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgList.Columns["MasrafYeriSorumlusu"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgList.Columns["Plaka"].HeaderText = "PLAKA";
            DtgList.Columns["AracSiparis"].HeaderText = "ARAÇ SİPARİŞ NO";
            DtgList.Columns["CikisKm"].HeaderText = "ÇIKIŞ KM";
            DtgList.Columns["DonusKm"].HeaderText = "DÖNÜŞ KM";
            DtgList.Columns["AracZimmetliPersonel"].HeaderText = "ARAÇ ZİMMETLİ PERSONEL";
            DtgList.Columns["DosyaYolu"].Visible = false;
        }
    }
}
