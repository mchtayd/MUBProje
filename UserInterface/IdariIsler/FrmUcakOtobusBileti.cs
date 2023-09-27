using Business;
using Business.Concreate;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using ClosedXML.Excel;
using DataAccess.Concreate;
using DataAccess.Concreate.STS;
using Entity;
using Entity.IdariIsler;
using Entity.STS;
using Microsoft.Office.Interop.Word;
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
using Application = Microsoft.Office.Interop.Word.Application;

namespace UserInterface.IdariIsler
{
    public partial class FrmUcakOtobusBileti : Form
    {
        SiparislerManager siparislerManager;
        TedarikciFirmaManager tedarikciFirmaManager;
        SiparisPersonelManager siparisPersonelManager;
        UstAmirManager ustAmirManager;
        UcakOtobusManager ucakOtobusManager;
        IdariIslerLogManager logManager;
        IsAkisNoManager isAkisNoManager;
        PersonelKayitManager kayitManager;
        SatNoManager satNoManager;
        SatDataGridview1Manager satDataGridview1Manager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        StokManager stokManager;
        TeklifsizSatManager teklifsizSatManager;
        List<UstAmirMail> ustAmirMails;
        List<UcakOtobus> ucakotobus;
        public object[] infos;
        bool start = true, start2 = true, start3 = true, start4 = true;
        string siparis, usamirbolum, usamirisim, siparisotobus, yapilanislem, dosya, islemadimigun, dosyayolugun, islemadimiOtobus, dosyayoluOtobus, onaydurum, formno, personelAd, personelSiparis, personeUnvani, personeMasYerNo, personeMasYeri, butceKodu, biletTuru, satinAlinanFirma;
        int id, idgun, onayid, isakisno, idUcak;
        double a, b, toplam;
        public FrmUcakOtobusBileti()
        {
            InitializeComponent();
            siparislerManager = SiparislerManager.GetInstance();
            tedarikciFirmaManager = TedarikciFirmaManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            ustAmirManager = UstAmirManager.GetInstance();
            ucakOtobusManager = UcakOtobusManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            stokManager = StokManager.GetInstance();
            teklifsizSatManager = TeklifsizSatManager.GetInstance();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageUcakOtobus"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void FrmUcakOtobusBileti_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            Personeller1();
            Personeller2();
            //Siparisler();
            //SiparislerGun();
            CmbIlYükle();
            CmbIlYükle2();
            CmbIlYükle3();
            CmbIlYükle4();
            CmbIlYükle5();
            CmbIlYükle6();
            CmbIlYükle7();
            CmbIlYükle8();
            DataDisplayOnay();
            start = false;
            start2 = false;
            start3 = false;
            start4 = false;
            CmbIslemTuruUcak.SelectedIndex = 0;
            CmbIslemTuruOtobus.SelectedIndex = 0;
            //TabControl.TabPages.Remove(TabControl.TabPages["tabPage3"]);
            /*if (infos[0].ConInt() != 84)
            {
                if (infos[0].ConInt() != 25)
                {
                    TabControl.TabPages.Remove(TabControl.TabPages["tabPage3"]);
                }
                return;
            }*/
        }
        public void YenilenecekVeri()
        {
            IsAkisNo();
            //Siparisler();
            //SiparislerGun();
            CmbIlYükle();
            CmbIlYükle2();
            CmbIlYükle3();
            CmbIlYükle4();
            CmbIlYükle5();
            CmbIlYükle6();
            CmbIlYükle7();
            CmbIlYükle8();
            DataDisplayOnay();
            //Personeller1();
            //Personeller2();
        }
        void Personeller1()
        {
            CmbAdSoyad.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Adsoyad";
            CmbAdSoyad.SelectedValue = -1;
        }
        void Personeller2()
        {
            CmbAdSoyadOtobus.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdSoyadOtobus.ValueMember = "Id";
            CmbAdSoyadOtobus.DisplayMember = "Adsoyad";
            CmbAdSoyadOtobus.SelectedValue = -1;
        }
        /*void IsAkisNo()
        {
            satno = "";
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                sayi = random.Next(0, 9);
                satno = satno + sayi.ToString();
            }
            LblIsAkisNo.Text = satno;
        }*/
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
            LblIsAkisNoOtobus.Text = LblIsAkisNo.Text;
        }
        /*void IsAkisNoOtobus()
        {
            satnoOtobus = "";
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                sayiOtobus = random.Next(0, 9);
                satnoOtobus = satnoOtobus + sayiOtobus.ToString();
            }
            LblIsAkisNoOtobus.Text = satnoOtobus;
        }*/
        public void DataDisplayOnay()
        {
            ucakotobus = ucakOtobusManager.OnayList("Onaylandı");
            dataBinder.DataSource = ucakotobus.ToDataTable();
            DtgList.DataSource = dataBinder;
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Talepturu"].HeaderText = "TALEP TÜRÜ";
            DtgList.Columns["Gorevformno"].HeaderText = "GÖREV FORM NO";
            DtgList.Columns["Izinformno"].HeaderText = "İZİN FORM NO";
            DtgList.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgList.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["Masrafyeri"].HeaderText = "BÖLÜMÜ";
            DtgList.Columns["Gorevi"].HeaderText = "GÖREVİ";
            DtgList.Columns["Tc"].HeaderText = "TC KİMLİK NO";
            DtgList.Columns["Hes"].HeaderText = "HES KODU";
            DtgList.Columns["Email"].HeaderText = "E-MAIL";
            DtgList.Columns["Kisakod"].HeaderText = "ŞİRKET NO/KISA KOD";
            DtgList.Columns["Biletturu"].HeaderText = "BİLET TÜRÜ";
            DtgList.Columns["Gidisfirma"].HeaderText = "GİDİŞ FİRMA İSMİ";
            DtgList.Columns["Gidistarihi"].HeaderText = "GİRİŞ TARİHİ/SAATİ";
            DtgList.Columns["Gidisnereden"].HeaderText = "GİDİŞ NEREDEN";
            DtgList.Columns["Gidisnereye"].HeaderText = "GİDİŞ NEREYE";
            DtgList.Columns["Donusfirma"].HeaderText = "DÖNÜŞ FİRMA İSMİ";
            DtgList.Columns["Donustarihi"].HeaderText = "DÖNÜŞ TARİHİ";
            DtgList.Columns["Donusnereden"].HeaderText = "DÖNÜŞ NEREDEN";
            DtgList.Columns["Donusnereye"].HeaderText = "DÖNÜŞ NEREYE";
            DtgList.Columns["Butcekodu"].HeaderText = "BÜTÇE KODU/KALEMİ";
            DtgList.Columns["ToplamMaliyet"].HeaderText = "TOPLAM MALİYET";
            DtgList.Columns["Islemadimi"].Visible = false;
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;

            TxtTop.Text = DtgList.RowCount.ToString();
        }
        private void CmbSiparisNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start)
            {
                if (start2 == true)
                {
                    return;
                }
            }
            siparis = CmbSiparisNo.Text;
            SiparisIsimlerDoldur();
            start = true;
            TxtMasrafyeriNo.Clear();
            TxtMasrafYeri.Clear();
            TxtTc.Clear();
            TxtHes.Clear();
            TxtMail.Clear();
            TxtKisaKod.Clear();
        }
        void SiparisIsimlerDoldur()
        {
            CmbAdSoyad.DataSource = siparisPersonelManager.GetList(siparis);
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Personel";
            CmbAdSoyad.SelectedValue = 0;
        }

        private void CmbAdSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdSoyad.Text);
            CmbSiparisNo.Text = siparis.Siparis;
            TxtMasrafyeriNo.Text = siparis.Masrafyerino;
            TxtMasrafYeri.Text = siparis.Masrafyeri;
            id = siparis.Id;
            TxtTc.Text = siparis.Tc;
            TxtHes.Text = siparis.Hes;
            TxtMail.Text = siparis.Mail;
            TxtKisaKod.Text = siparis.Kisakod;
            TxtGorevi.Text = siparis.Gorevi;
            TxtGoreviOtobus.Text = siparis.Gorevi;
            ustAmirMails = ustAmirManager.GetList(id);
            if (ustAmirMails.Count > 0)
            {
                usamirbolum = ustAmirMails[0].Bolum;
                usamirisim = ustAmirMails[0].Adsoyad;
            }
            start2 = false;
        }

        /*void Siparisler()
        {
            CmbSiparisNo.DataSource = siparislerManager.GetList();
            CmbSiparisNo.ValueMember = "Id";
            CmbSiparisNo.DisplayMember = "Siparisno";
            CmbSiparisNo.SelectedValue = 0;
        }*/

        private void CmbSiparisNoOtobus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start3)
            {
                if (start4 == true)
                {
                    return;
                }
            }
            siparisotobus = CmbSiparisNoOtobus.Text;
            SiparisIsimlerDoldurOtobus();
            start3 = true;
            TxtMasrafyeriNoOtobus.Clear();
            TxtMasrafYeriOtobus.Clear();
            TxtTcOtobus.Clear();
            TxtHesOtobus.Clear();
            TxtMailOtobus.Clear();
            TxtKisaKodOtobus.Clear();
            TxtGorevi.Clear();
            TxtGoreviOtobus.Clear();
        }

        private void BtnKaydetUcak_Click(object sender, EventArgs e)
        {
            /*IXLWorkbook workbook = new XLWorkbook(@"C:\Users\MAYıldırım\Desktop\PERSONEL ULAŞIM BİLGİLERİ 2021.xlsx");
            IXLWorksheets sheets = workbook.Worksheets;
            IXLWorksheet worksheet = workbook.Worksheet("Ağustos");
            var rows = worksheet.Rows(2, 11);
            DateTime outDate = DateTime.Now;
            //double outDouble = 0;
            foreach (IXLRow item in rows)
            {
                UcakOtobus ucakOtobus = new UcakOtobus(
                    0, // İŞ AKIŞ NO
                    "", // TALEP TÜRÜ
                    "", // GÖREV FORM NO
                    "", // İZİN FORM NO
                    item.Cell("I").Value.ToString(), // BÜTÇE KODU/KALEMİ
                    "", // SİPARİŞ NO
                    item.Cell("B").Value.ToString(), // ADSOYAD
                    "", // MASRAF YERİ NO
                    "", // MASRAF YERİ
                    "", // GÖREVİ 
                    "", // TC
                    "", // HES
                    "", // E MAİL
                    "", // KISAKOD
                    item.Cell("F").Value.ToString(), // BİLET TÜRÜ
                    item.Cell("D").Value.ToString(), // GİDİŞ FİRMA
                    item.Cell("A").Value.ConTime(), // GİDİŞ TARİHİ
                    item.Cell("C").Value.ToString(), // GİDİŞ NEREDEN
                    item.Cell("C").Value.ToString(), // GİDİŞ NEREYE
                    item.Cell("D").Value.ToString(), // DÖNÜŞ FİRMA
                    item.Cell("A").Value.ConTime(), // DÖNÜŞ TARİHİ
                    item.Cell("C").Value.ToString(), // DÖNÜŞ NEREDEN
                    item.Cell("C").Value.ToString(), // DÖNÜŞ NEREYE
                    item.Cell("E").Value.ConDouble(), // TOPLAM MALİYET
                    "ONAYLANDI", // İŞLEM ADIMI
                    "" // DOSYAYOLU
                    );
                ucakOtobusManager.Add(ucakOtobus);
            }*/
            #region KAYDET
            if (TxtBiletSayisi.Text=="")
            {
                MessageBox.Show("Lütfen ALINAN BİLET SAYISI Bilgisini Doldurunuz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Uçak Bileti Talebinizi Kaydetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNo();
                DateTime gidistarihiSaati = new DateTime(DtSeyahatTarihiGidis.Value.Year, DtSeyahatTarihiGidis.Value.Month, DtSeyahatTarihiGidis.Value.Day, DtSeyahatSaatiDonus.Value.Hour, DtSeyahatSaatiDonus.Value.Minute, DtSeyahatSaatiDonus.Value.Second);
                DateTime donustarihiSaati = new DateTime(DtUcakDonusTarih.Value.Year, DtUcakDonusTarih.Value.Month, DtUcakDonusTarih.Value.Day, DtUcakDonusSaat.Value.Hour, DtUcakDonusSaat.Value.Minute, DtUcakDonusSaat.Value.Second);
                string biletturu = "UÇAK BİLETİ";
                string islemadimi = "ONAY AŞAMASINDA";
                CreateDirectory();
                UcakOtobus ucakOtobus = new UcakOtobus(LblIsAkisNo.Text.ConInt(), CmbTalepTuru.Text, TxtGorevFormNo.Text, TxtIzinFormNo.Text, CmbButceKoduUcak.Text, CmbSiparisNo.Text, CmbAdSoyad.Text, TxtMasrafyeriNo.Text, TxtMasrafYeri.Text, TxtGorevi.Text, TxtTc.Text, TxtHes.Text, TxtMail.Text, TxtKisaKod.Text, biletturu, TxtSeyahatFirmasiGidis.Text, gidistarihiSaati, CmbUcakGidisNereden.Text, CmbUcakGidisNereye.Text, TxtSeyahatFirmasDonus.Text, donustarihiSaati, CmbUcakDonusNereden.Text, CmbUcakNereyeNereye.Text, TxtToplamMaliyetUcak.Text.ConDouble(), islemadimi, dosya, TxtBiletSayisi.Text.ConInt(),0);
                string mesaj = ucakOtobusManager.Add(ucakOtobus);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateWordUcak();
                CreateLogUcak();
                //System.Threading.Tasks.Task.Factory.StartNew(() => MailSendMetotUcak());
                /*DialogResult dialogResult = MessageBox.Show("SAT Kaydı Oluşturmak İster Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    SatOlusturUcak();
                }*/
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleUcak();
                IsAkisNo();
                DataDisplayOnay();
            }
            #endregion
        }
        string siparisNo, gerekce, donem, harcamaturu, faturafirma, ilgilikisi, masrafyeri;
        int satNo;
        double miktar;
        void SatOlustur()
        {
            siparisNo = Guid.NewGuid().ToString();
            satNo = satNoManager.Add(new SatNo(siparisNo));
            if (biletTuru== "UÇAK BİLETİ")
            {
                HarcamaUcak();
            }
            if (biletTuru == "OTOBÜS BİLETİ")
            {
                HarcamaOtobus();
            }

            SatDataGridview1 satDataGridview1 = new SatDataGridview1(satNo, isakisno, infos[4].ToString(), infos[1].ToString(),
                infos[2].ToString(), "YOK", "YOK", DateTime.Now, gerekce, siparisNo, personelAd, personelSiparis, personeUnvani, personeMasYerNo, personeMasYeri, dosya, infos[0].ConInt(), "SAT ONAY", donem, "BAŞARAN", proje, satinAlinanFirma, "", "", "");

            string mesaj = satDataGridview1Manager.Add(satDataGridview1);
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SatDataGridview1 dataGridview1 = new SatDataGridview1(satNo, butceKodu, "BSRN GN.MDL.SATIN ALMA", harcamaturu, faturafirma, ilgilikisi, masrafyeri, siparisNo, 0, dosya, "SAT ONAY");
            mesaj = satDataGridview1Manager.Update(dataGridview1);
            if (mesaj != " SAT Ön Onay İşlemi Başarıyla Tamamlandı.")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            satDataGridview1Manager.TeklifDurum(siparisNo, dosya, "SAT ONAY BAŞARAN");
            satDataGridview1Manager.DurumGuncelleOnay(siparisNo);
            if (biletTuru == "UÇAK BİLETİ")
            {
                yapilanislem = LblIsAkisNo.Text + " Nolu Uçak Bileti Kaydı İçin SAT Oluşturuldu.";
            }
            if (biletTuru == "OTOBÜS BİLETİ")
            {
                yapilanislem = LblIsAkisNoOtobus.Text + " Nolu Otobüs Bileti Kaydı İçin SAT Oluşturuldu.";
            }
            SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
            satIslemAdimlariManager.Add(satIslemAdimlari);
        }
        string proje = "";
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            /*onayid = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            islemadimi = DtgList.CurrentRow.Cells["Islemadimi"].Value.ToString();
            isakisno = DtgList.CurrentRow.Cells["Isakisno"].Value.ConInt();*/

            onayid = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            formno = DtgList.CurrentRow.Cells["Gorevformno"].Value.ToString();
            isakisno = DtgList.CurrentRow.Cells["Isakisno"].Value.ConInt();
            personelAd = DtgList.CurrentRow.Cells["Adsoyad"].Value.ToString();
            personelSiparis = DtgList.CurrentRow.Cells["Siparisno"].Value.ToString();
            personeUnvani = DtgList.CurrentRow.Cells["Gorevi"].Value.ToString();
            personeMasYerNo = DtgList.CurrentRow.Cells["Masrafyerino"].Value.ToString();
            personeMasYeri = DtgList.CurrentRow.Cells["Masrafyeri"].Value.ToString();
            butceKodu = DtgList.CurrentRow.Cells["Butcekodu"].Value.ToString();
            dosya = DtgList.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            satNo = DtgList.CurrentRow.Cells["SatNo"].Value.ConInt();
            miktar = DtgList.CurrentRow.Cells["BiletSayisi"].Value.ConDouble();
            toplam = DtgList.CurrentRow.Cells["ToplamMaliyet"].Value.ConDouble();
            biletTuru = DtgList.CurrentRow.Cells["Biletturu"].Value.ToString();
            satinAlinanFirma= DtgList.CurrentRow.Cells["Gidisfirma"].Value.ToString() + "/" +DtgList.CurrentRow.Cells["Donusfirma"].Value.ToString();

            SiparisPersonel siparis = siparisPersonelManager.Get("", personelAd);
            proje = siparis.Projekodu;
        }
        void HarcamaUcak()
        {
            MessageBox.Show("Lütfen Öncelikle Satın Alma Talebinin Oluşturulabilmesi İçin Eksik Olan Bilgileri Tamamlayınız!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Properties.Settings.Default.SiparisNo = siparisNo;
            Properties.Settings.Default.YurtIciDosyaYolu = dosya;
            Properties.Settings.Default.YurtIciYeniAd = isakisno.ToString();
            Properties.Settings.Default.YurtIciIsAkisNo = isakisno;
            Properties.Settings.Default.Save();

            FrmYurtIciGorevSAT frmYurtIciGorevSAT = new FrmYurtIciGorevSAT();
            frmYurtIciGorevSAT.ShowDialog();

            gerekce = Properties.Settings.Default.Gerekce.ToString();
            harcamaturu = Properties.Settings.Default.HarcamaTuru.ToString();
            faturafirma = Properties.Settings.Default.FaturaFirma.ToString();
            ilgilikisi = Properties.Settings.Default.IlgiliKisi.ToString();
            masrafyeri = Properties.Settings.Default.MasrafYeri.ToString();
            donem = Properties.Settings.Default.YurtIciGorevDonem.ToString();
            dosya= Properties.Settings.Default.DosyaYolu.ToString();
            string stokno, tanim, birim;
            Stok stok = stokManager.Get("UÇAK BİLETİ");
            stokno = stok.Stokno;
            tanim = stok.Tanim;
            birim = stok.Birim;
            //miktar = TxtBiletSayisi.Text.ConDouble();
            //toplam = TxtToplamMaliyetUcak.Text.ConDouble();
            TeklifsizSat satinAlinacakMalzeme = new TeklifsizSat(stokno, tanim, miktar, birim, toplam, siparisNo);
            teklifsizSatManager.Add(satinAlinacakMalzeme);

        }
        void HarcamaOtobus()
        {
            MessageBox.Show("Lütfen Öncelikle Satın Alma Talebinin Oluşturulabilmesi İçin Eksik Olan Bilgileri Tamamlayınız!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Properties.Settings.Default.SiparisNo = siparisNo;
            Properties.Settings.Default.YurtIciDosyaYolu = dosya;
            Properties.Settings.Default.YurtIciYeniAd = isakisno.ToString();
            Properties.Settings.Default.YurtIciIsAkisNo = isakisno;
            Properties.Settings.Default.Save();

            FrmYurtIciGorevSAT frmYurtIciGorevSAT = new FrmYurtIciGorevSAT();
            frmYurtIciGorevSAT.ShowDialog();

            gerekce = Properties.Settings.Default.Gerekce.ToString();
            harcamaturu = Properties.Settings.Default.HarcamaTuru.ToString();
            faturafirma = Properties.Settings.Default.FaturaFirma.ToString();
            ilgilikisi = Properties.Settings.Default.IlgiliKisi.ToString();
            masrafyeri = Properties.Settings.Default.MasrafYeri.ToString();
            donem = Properties.Settings.Default.YurtIciGorevDonem.ToString();
            dosya = Properties.Settings.Default.DosyaYolu.ToString();
            string stokno, tanim, birim;
            Stok stok = stokManager.Get("OTOBÜS BİLETİ");
            stokno = stok.Stokno;
            tanim = stok.Tanim;
            birim = stok.Birim;
            //miktar = TxtBiletSayisiOtobus.Text.ConDouble();
            //toplam = TxtToplamMaliyetOtobus.Text.ConDouble();
            TeklifsizSat satinAlinacakMalzeme = new TeklifsizSat(stokno, tanim, miktar, birim, toplam, siparisNo);
            teklifsizSatManager.Add(satinAlinacakMalzeme);

        }
        void MailSendMetotUcak()
        {
            MailSend("UÇAK OTOBÜS BİLETİ ONAY", "Merhaba; \n\n" + LblIsAkisNo.Text + " İş Akış Nolu Uçak Bileti Talebi Onayınıza Sunulmuştur.\n\nİyi Çalışmalar.",
                new List<string>() { "resulgunes@mubvan.net" });
        }
        void MailSendMetotOtobus()
        {
            MailSend("UÇAK OTOBÜS BİLETİ ONAY", "Merhaba; \n\n" + LblIsAkisNoOtobus.Text + " İş Akış Nolu Otobüs Bileti Talebi Onayınıza Sunulmuştur.\n\nİyi Çalışmalar.",
                new List<string>() { "resulgunes@mubvan.net" });
        }
        void MailSendMetotOnay()
        {
            MailSend("UÇAK OTOBÜS BİLETİ ONAY", "Merhaba; \n\n" + isakisno + " İş Akış Nolu Otobüs Bileti Talebi Onaylanmıştır.\n\nİyi Çalışmalar.",
                new List<string>() { "emelayhan@mubvan.net" });
        }
        void MailSendMetotRed()
        {
            MailSend("UÇAK OTOBÜS BİLETİ ONAY", "Merhaba; \n\n" + isakisno + " İş Akış Nolu Otobüs Bileti Talebi Reddedilmiştir.\n\nİyi Çalışmalar.",
                new List<string>() { "emelayhan@mubvan.net" });
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
        void CreateWordUcak()
        {
            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\WordTaslak\\DTS_Uçak Bileti Talep Formu.docx"; // taslak yolu
            object filePath = "Z:\\DTS\\İDARİ İŞLER\\WordTaslak\\DTS_Uçak Bileti Talep Formu1.docx";
            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            //wBookmarks["BiletTuru"].Range.Text = "Uçak";
            wBookmarks["TalepTuru"].Range.Text = CmbTalepTuru.Text;
            wBookmarks["GorevFormNo"].Range.Text = TxtGorevFormNo.Text;
            wBookmarks["IzinFormNo"].Range.Text = TxtIzinFormNo.Text;
            wBookmarks["ButceKodu"].Range.Text = CmbButceKoduUcak.Text;
            wBookmarks["SiparisNo"].Range.Text = CmbSiparisNo.Text;
            wBookmarks["AdSoyad"].Range.Text = CmbAdSoyad.Text;
            wBookmarks["Unvani"].Range.Text = TxtGorevi.Text;
            wBookmarks["MasrafYeriNo"].Range.Text = TxtMasrafyeriNo.Text;
            wBookmarks["Bolumu"].Range.Text = TxtMasrafYeri.Text;
            wBookmarks["Tc"].Range.Text = TxtTc.Text;
            wBookmarks["Hes"].Range.Text = TxtHes.Text;
            wBookmarks["Email"].Range.Text = TxtMail.Text;
            wBookmarks["SirketNo"].Range.Text = TxtKisaKod.Text;
            wBookmarks["GidisFirma"].Range.Text = TxtSeyahatFirmasiGidis.Text;
            wBookmarks["GidisTarihi"].Range.Text = DtSeyahatTarihiGidis.Value.ToString("dd/MM/yyyy");
            wBookmarks["GidisSaat"].Range.Text = DtSeyahatSaatiDonus.Value.ToString("HH/mm");
            wBookmarks["GidisNereden"].Range.Text = CmbUcakGidisNereden.Text;
            wBookmarks["GidisNereye"].Range.Text = CmbUcakGidisNereye.Text;
            wBookmarks["DonusFirma"].Range.Text = TxtSeyahatFirmasDonus.Text;
            wBookmarks["DonusTarih"].Range.Text = DtUcakDonusTarih.Value.ToString("dd/MM/yyyy");
            wBookmarks["UcakTarih"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy H/mm/ss");
            wBookmarks["UcakOlustur"].Range.Text = "DTS Modülünde Uçak Talebi Kayıt Oluşturuldu.";
            wBookmarks["DonusSaati"].Range.Text = DtUcakDonusSaat.Value.ToString("HH/mm");
            wBookmarks["DonusNereden"].Range.Text = CmbUcakDonusNereden.Text;
            wBookmarks["DonusNereye"].Range.Text = CmbUcakNereyeNereye.Text;

            wDoc.SaveAs2(dosya + LblIsAkisNo.Text + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }
        void CreateWordUcakGun()
        {
            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = "Z:\\DTS\\İDARİ İŞLER\\WordTaslak\\DTS_Uçak Bileti Talep Formu1.docx"; // taslak yolu
            //object filePath = dosyayolugun + TxtIsAkisNoUcak.Text + ".docx";
            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["TalepTuru"].Range.Text = CmbTalepTuru.Text;
            wBookmarks["GorevFormNo"].Range.Text = TxtGorevFormNo.Text;
            wBookmarks["IzinFormNo"].Range.Text = TxtIzinFormNo.Text;
            wBookmarks["ButceKodu"].Range.Text = CmbButceKoduUcak.Text;
            wBookmarks["SiparisNo"].Range.Text = CmbSiparisNo.Text;
            wBookmarks["AdSoyad"].Range.Text = CmbAdSoyad.Text;
            wBookmarks["Unvani"].Range.Text = TxtGorevi.Text;
            wBookmarks["MasrafYeriNo"].Range.Text = TxtMasrafyeriNo.Text;
            wBookmarks["Bolumu"].Range.Text = TxtMasrafYeri.Text;
            wBookmarks["Tc"].Range.Text = TxtTc.Text;
            wBookmarks["Hes"].Range.Text = TxtHes.Text;
            wBookmarks["Email"].Range.Text = TxtMail.Text;
            wBookmarks["SirketNo"].Range.Text = TxtKisaKod.Text;
            wBookmarks["GidisFirma"].Range.Text = TxtSeyahatFirmasiGidis.Text;
            wBookmarks["GidisTarihi"].Range.Text = DtSeyahatTarihiGidis.Value.ToString("dd/MM/yyyy");
            wBookmarks["GidisSaat"].Range.Text = DtSeyahatSaatiDonus.Value.ToString("HH/mm");
            wBookmarks["GidisNereden"].Range.Text = CmbUcakGidisNereden.Text;
            wBookmarks["GidisNereye"].Range.Text = CmbUcakGidisNereye.Text;
            wBookmarks["DonusFirma"].Range.Text = TxtSeyahatFirmasDonus.Text;
            wBookmarks["DonusTarih"].Range.Text = DtUcakDonusTarih.Value.ToString("dd/MM/yyyy");
            wBookmarks["UcakTarih"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy H/mm/ss");
            wBookmarks["UcakOlustur"].Range.Text = "DTS Modülünde Uçak Talebi Kayıt Oluşturuldu.";
            wBookmarks["DonusSaati"].Range.Text = DtUcakDonusSaat.Value.ToString("HH/mm");
            wBookmarks["DonusNereden"].Range.Text = CmbUcakDonusNereden.Text;
            wBookmarks["DonusNereye"].Range.Text = CmbUcakNereyeNereye.Text;


            wDoc.SaveAs2(dosyayolugun + TxtIsAkisNoUcak.Text + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }

        void CreateDirectory()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\UÇAK OTOBÜS BİLETİ\";

            /*string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\UÇAK OTOBÜS BİLETİ\";*/
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
        void CreateDirectoryUcakGun()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\UÇAK OTOBÜS BİLETİ\";

            /*string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\UÇAK OTOBÜS BİLETİ\";*/
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
            dosyayolugun = anadosya + TxtIsAkisNoUcak.Text + "\\";
            Directory.CreateDirectory(dosyayolugun);
        }
        void CreateDirectoryOtobus()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\UÇAK OTOBÜS BİLETİ\";

            /*string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\UÇAK OTOBÜS BİLETİ\";*/
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
            dosya = anadosya + LblIsAkisNoOtobus.Text + "\\";
            Directory.CreateDirectory(dosya);
        }
        void CreateDirectoryOtobusGuncelle()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\UÇAK OTOBÜS BİLETİ\";

            /*string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\UÇAK OTOBÜS BİLETİ\";*/
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
            dosyayoluOtobus = anadosya + TxtIsAkisNoOtobus.Text + "\\";
            Directory.CreateDirectory(dosyayoluOtobus);
        }

        private void BtnKaydetOtobus_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Otobüs Bileti Talebinizi Kaydetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNo();
                DateTime gidistarihiSaati = new DateTime(DtSeyahatTarihiGidisOtobus.Value.Year, DtSeyahatTarihiGidisOtobus.Value.Month, DtSeyahatTarihiGidisOtobus.Value.Day, DtSeyahatSaatiDonusOtobus.Value.Hour, DtSeyahatSaatiDonusOtobus.Value.Minute, DtSeyahatSaatiDonusOtobus.Value.Second);
                DateTime donustarihiSaati = new DateTime(DtOtobusonusTarih.Value.Year, DtOtobusonusTarih.Value.Month, DtOtobusonusTarih.Value.Day, DtOtobusDonusTarih.Value.Hour, DtOtobusDonusTarih.Value.Minute, DtOtobusDonusTarih.Value.Second);
                string biletturu = "OTOBÜS BİLETİ";
                string islemadimi = "ONAY AŞAMASINDA";
                CreateDirectoryOtobus();
                UcakOtobus ucakOtobus = new UcakOtobus(LblIsAkisNoOtobus.Text.ConInt(), CmbTalepTuruOtobus.Text, TxtGorevFormNoOtobus.Text, TxtIzinFormNoOtobus.Text, CmbButceKoduOtobus.Text, CmbSiparisNoOtobus.Text, CmbAdSoyadOtobus.Text, TxtMasrafyeriNoOtobus.Text, TxtMasrafYeriOtobus.Text, TxtGoreviOtobus.Text, TxtTcOtobus.Text, TxtHesOtobus.Text, TxtMailOtobus.Text, TxtKisaKodOtobus.Text, biletturu, TxtSeyahatFirmasiOtobus.Text, gidistarihiSaati, CmbOtobusGidisNereden.Text, CmbNereyeGidisNereye.Text, TxtSeyahatFirmasDonusOtobus.Text, donustarihiSaati, CmbOtobusDonusNereden.Text, CmbOtobusDonusNereye.Text, TxtToplamMaliyetOtobus.Text.ConDouble(), islemadimi, dosya, TxtBiletSayisiOtobus.Text.ConInt(),0);
                string mesaj = ucakOtobusManager.Add(ucakOtobus);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateWordOtobus();
                CreateLogOtobus();
                System.Threading.Tasks.Task.Factory.StartNew(() => MailSendMetotOtobus());
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleOtobus();
                IsAkisNo();
                DataDisplayOnay();
            }
        }
        void CreateWordOtobus()
        {
            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\Formlar\\DTS_Otobüs Bileti Talep Formu.docx"; // taslak yolu
            object filePath = "Z:\\DTS\\İDARİ İŞLER\\WordTaslak\\DTS_Otobüs Bileti Talep Formu.docx";
            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            //wBookmarks["BiletTuru"].Range.Text = "Otobüs";
            wBookmarks["TalepTuru"].Range.Text = CmbTalepTuruOtobus.Text;
            wBookmarks["GorevFormNo"].Range.Text = TxtGorevFormNoOtobus.Text;
            wBookmarks["IzinFormNo"].Range.Text = TxtIzinFormNoOtobus.Text;
            wBookmarks["ButceKodu"].Range.Text = CmbButceKoduOtobus.Text;
            wBookmarks["SiparisNo"].Range.Text = CmbSiparisNoOtobus.Text;
            wBookmarks["AdSoyad"].Range.Text = CmbAdSoyadOtobus.Text;
            wBookmarks["Unvani"].Range.Text = TxtGoreviOtobus.Text;
            wBookmarks["MasrafYeriNo"].Range.Text = TxtMasrafyeriNoOtobus.Text;
            wBookmarks["Bolumu"].Range.Text = TxtMasrafYeriOtobus.Text;
            wBookmarks["Tc"].Range.Text = TxtTcOtobus.Text;
            wBookmarks["Hes"].Range.Text = TxtHesOtobus.Text;
            wBookmarks["Email"].Range.Text = TxtMailOtobus.Text;
            wBookmarks["SirketNo"].Range.Text = TxtKisaKodOtobus.Text;
            wBookmarks["GidisFirma"].Range.Text = TxtSeyahatFirmasiOtobus.Text;
            wBookmarks["GidisTarihi"].Range.Text = DtSeyahatTarihiGidisOtobus.Value.ToString("dd/MM/yyyy");
            wBookmarks["GidisSaat"].Range.Text = DtSeyahatSaatiDonusOtobus.Value.ToString("HH/mm");
            wBookmarks["GidisNereden"].Range.Text = CmbOtobusGidisNereden.Text;
            wBookmarks["GidisNereye"].Range.Text = CmbNereyeGidisNereye.Text;
            wBookmarks["DonusFirma"].Range.Text = TxtSeyahatFirmasDonusOtobus.Text;
            wBookmarks["OtobusTarih"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy H/mm/ss");
            wBookmarks["OtobusKayit"].Range.Text = "DTS Modülünde Otobüs Bileti Kayıt Oluşturuldu.";
            wBookmarks["DonusTarih"].Range.Text = DtOtobusonusTarih.Value.ToString("dd/MM/yyyy");
            wBookmarks["DonusSaati"].Range.Text = DtOtobusDonusTarih.Value.ToString("HH/mm");
            wBookmarks["DonusNereden"].Range.Text = CmbOtobusDonusNereden.Text;
            wBookmarks["DonusNereye"].Range.Text = CmbOtobusDonusNereye.Text;

            wDoc.SaveAs2(dosya + LblIsAkisNoOtobus.Text + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }
        void CreateWordOtobusGun()
        {
            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            //object filePath = "C:\\Users\\MAYıldırım\\Desktop\\WordTaslak\\DTS_Otobüs bileti talep Formu.docx"; // taslak yolu
            object filePath = "Z:\\DTS\\İDARİ İŞLER\\WordTaslak\\DTS_Otobüs Bileti Talep Formu.docx";
            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["TalepTuru"].Range.Text = CmbTalepTuruOtobus.Text;
            wBookmarks["GorevFormNo"].Range.Text = TxtGorevFormNoOtobus.Text;
            wBookmarks["IzinFormNo"].Range.Text = TxtIzinFormNoOtobus.Text;
            wBookmarks["ButceKodu"].Range.Text = CmbButceKoduOtobus.Text;
            wBookmarks["SiparisNo"].Range.Text = CmbSiparisNoOtobus.Text;
            wBookmarks["AdSoyad"].Range.Text = CmbAdSoyadOtobus.Text;
            wBookmarks["Unvani"].Range.Text = TxtGoreviOtobus.Text;
            wBookmarks["MasrafYeriNo"].Range.Text = TxtMasrafyeriNoOtobus.Text;
            wBookmarks["Bolumu"].Range.Text = TxtMasrafYeriOtobus.Text;
            wBookmarks["Tc"].Range.Text = TxtTcOtobus.Text;
            wBookmarks["Hes"].Range.Text = TxtHesOtobus.Text;
            wBookmarks["Email"].Range.Text = TxtMailOtobus.Text;
            wBookmarks["SirketNo"].Range.Text = TxtKisaKodOtobus.Text;
            wBookmarks["GidisFirma"].Range.Text = TxtSeyahatFirmasiOtobus.Text;
            wBookmarks["GidisTarihi"].Range.Text = DtSeyahatTarihiGidisOtobus.Value.ToString("dd/MM/yyyy");
            wBookmarks["GidisSaat"].Range.Text = DtSeyahatSaatiDonusOtobus.Value.ToString("HH/mm");
            wBookmarks["GidisNereden"].Range.Text = CmbOtobusGidisNereden.Text;
            wBookmarks["GidisNereye"].Range.Text = CmbNereyeGidisNereye.Text;
            wBookmarks["DonusFirma"].Range.Text = TxtSeyahatFirmasDonusOtobus.Text;
            wBookmarks["OtobusTarih"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy H/mm/ss");
            wBookmarks["OtobusKayit"].Range.Text = "DTS Modülünde Otobüs Bileti Kayıt Oluşturuldu.";
            wBookmarks["DonusTarih"].Range.Text = DtOtobusonusTarih.Value.ToString("dd/MM/yyyy");
            wBookmarks["DonusSaati"].Range.Text = DtOtobusDonusTarih.Value.ToString("HH/mm");
            wBookmarks["DonusNereden"].Range.Text = CmbOtobusDonusNereden.Text;
            wBookmarks["DonusNereye"].Range.Text = CmbOtobusDonusNereye.Text;

            wDoc.SaveAs2(dosyayoluOtobus + TxtIsAkisNoOtobus.Text + ".docx");
            wDoc.Close();
            wApp.Quit(false);
        }
        void CreateLogUcak()
        {
            string sayfa = "UÇAK OTOBÜS";
            UcakOtobus gorev = ucakOtobusManager.Get(LblIsAkisNo.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "UÇAK TALEBİ KAYIT OLUŞTURULDU.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogOtobus()
        {
            string sayfa = "UÇAK OTOBÜS";
            UcakOtobus gorev = ucakOtobusManager.Get(LblIsAkisNoOtobus.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "OTOBÜS TALEBİ KAYIT OLUŞTURULDU.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogOtobusGun()
        {
            string sayfa = "UÇAK OTOBÜS";
            UcakOtobus gorev = ucakOtobusManager.Get(TxtIsAkisNoOtobus.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "OTOBÜS BİLETİ TALEBİ GÜNCELLENDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogUcakGun()
        {
            string sayfa = "UÇAK OTOBÜS";
            UcakOtobus gorev = ucakOtobusManager.Get(TxtIsAkisNoUcak.Text.ConInt());
            int benzersizid = gorev.Id;
            string islem = "UÇAK BİLETİ TALEBİ GÜNCELLENDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogOnay()
        {
            string sayfa = "OTOBÜS OTOBÜS";
            UcakOtobus gorev = ucakOtobusManager.Get(isakisno);
            int benzersizid = gorev.Id;
            string islem = "BİLET KAYDI ONAYLANDI.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void CreateLogRed()
        {
            string sayfa = "OTOBÜS OTOBÜS";
            UcakOtobus gorev = ucakOtobusManager.Get(isakisno);
            int benzersizid = gorev.Id;
            string islem = "BİLET KAYDI REDDEDİLDİ.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        void TemizleUcak()
        {
            CmbTalepTuru.Text = ""; TxtGorevFormNo.Clear(); TxtIzinFormNo.Clear(); CmbSiparisNo.Text = ""; CmbAdSoyad.Text = "";
            TxtMasrafyeriNo.Clear(); TxtMasrafYeri.Clear(); TxtTc.Clear(); TxtHes.Clear(); TxtMail.Clear(); TxtKisaKod.Clear();
            TxtSeyahatFirmasiGidis.Clear(); CmbUcakGidisNereden.Text = ""; CmbUcakGidisNereye.Text = ""; TxtSeyahatFirmasDonus.Clear();
            CmbUcakDonusNereden.Text = ""; CmbUcakNereyeNereye.Text = ""; TxtGorevi.Clear(); CmbButceKoduUcak.Text = ""; TxtToplamMaliyetUcak.Clear();
        }
        void TemizleOtobus()
        {
            CmbTalepTuruOtobus.Text = ""; TxtGorevFormNoOtobus.Clear(); TxtIzinFormNoOtobus.Clear(); CmbSiparisNoOtobus.Text = ""; CmbAdSoyadOtobus.Text = "";
            TxtMasrafyeriNoOtobus.Clear(); TxtMasrafYeriOtobus.Clear(); TxtTcOtobus.Clear(); TxtHesOtobus.Clear(); TxtMailOtobus.Clear(); TxtKisaKodOtobus.Clear();
            TxtSeyahatFirmasiOtobus.Clear(); CmbOtobusGidisNereden.Text = ""; CmbNereyeGidisNereye.Text = ""; TxtSeyahatFirmasDonusOtobus.Clear();
            CmbOtobusDonusNereden.Text = ""; CmbOtobusDonusNereye.Text = ""; TxtGoreviOtobus.Clear(); CmbButceKoduOtobus.Text = ""; TxtToplamMaliyetOtobus.Clear();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {

            TemizleUcak();
        }

        private void TxtBiletSayisiOtobus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void BtnReddet_Click(object sender, EventArgs e)
        {
            if (onayid == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Görev Kaydı Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(isakisno + " Nolu Görevi Reddetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string onay = "REDDEDİLDİ";
                UcakOtobus ucakOtobus = new UcakOtobus(onay);
                string mesaj = ucakOtobusManager.OnayGuncelle(ucakOtobus, onayid);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(isakisno + "Nolu Bilet Talebi Reddedilmiştir.");
                CreateLogRed();
                System.Threading.Tasks.Task.Factory.StartNew(() => MailSendMetotRed());
            }
        }

        private void TxtToplamMaliyetUcak_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtToplamMaliyetOtobus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        int index;
        private void CmbIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbIslemTuruUcak.SelectedIndex.ConInt();
            if (index == 1)
            {
                BtnBulUcak.Visible = true;
                TxtIsAkisNoUcak.Visible = true;
                BtnGuncelle.Visible = true;
                LblIsAkisNo.Visible = false;
                TemizleUcak();
            }
            else
            {
                BtnBulUcak.Visible = false;
                TxtIsAkisNoUcak.Visible = false;
                BtnGuncelle.Visible = false;
                LblIsAkisNo.Visible = true;
                TemizleUcak();
            }
        }
        int indexOtobus;
        int idOtobus;

        private void TxtBiletSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        int satNoOtobus;
        private void BtnBulOtobus_Click(object sender, EventArgs e)
        {
            UcakOtobus ucakOtobus = ucakOtobusManager.Get(TxtIsAkisNoOtobus.Text.ConInt());
            if (ucakOtobus == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleOtobus();
                return;
            }
            idOtobus = ucakOtobus.Id;
            islemadimiOtobus = ucakOtobus.Islemadimi;
            dosyayoluOtobus = ucakOtobus.Dosyayolu;
            CmbTalepTuruOtobus.Text = ucakOtobus.Talepturu;
            TxtGorevFormNoOtobus.Text = ucakOtobus.Gorevformno;
            TxtIzinFormNoOtobus.Text = ucakOtobus.Izinformno;
            CmbButceKoduOtobus.Text = ucakOtobus.Butcekodu;
            CmbSiparisNoOtobus.Text = ucakOtobus.Siparisno;
            CmbAdSoyadOtobus.Text = ucakOtobus.Adsoyad;
            TxtMasrafyeriNoOtobus.Text = ucakOtobus.Masrafyerino;
            TxtMasrafYeriOtobus.Text = ucakOtobus.Masrafyeri;
            TxtGoreviOtobus.Text = ucakOtobus.Gorevi;
            TxtTcOtobus.Text = ucakOtobus.Tc;
            TxtHesOtobus.Text = ucakOtobus.Hes;
            TxtMailOtobus.Text = ucakOtobus.Email;
            TxtKisaKodOtobus.Text = ucakOtobus.Kisakod;
            TxtSeyahatFirmasiOtobus.Text = ucakOtobus.Gidisfirma;
            DtSeyahatTarihiGidisOtobus.Value = ucakOtobus.Gidistarihi;
            DtSeyahatSaatiDonusOtobus.Value = ucakOtobus.Gidistarihi;
            CmbOtobusGidisNereden.Text = ucakOtobus.Gidisnereden;
            CmbNereyeGidisNereye.Text = ucakOtobus.Gidisnereye;
            TxtSeyahatFirmasDonusOtobus.Text = ucakOtobus.Donusfirma;
            DtOtobusonusTarih.Value = ucakOtobus.Donustarihi;
            DtOtobusDonusTarih.Value = ucakOtobus.Donustarihi;
            CmbOtobusDonusNereden.Text = ucakOtobus.Donusnereden;
            CmbOtobusDonusNereye.Text = ucakOtobus.Donusnereye;
            TxtToplamMaliyetOtobus.Text = ucakOtobus.ToplamMaliyet.ToString();
            TxtBiletSayisiOtobus.Text = ucakOtobus.BiletSayisi.ToString();
            satNoOtobus = ucakOtobus.SatNo;
        }

        private void CmbIslemTuruOtobus_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexOtobus = CmbIslemTuruOtobus.SelectedIndex.ConInt();
            if (indexOtobus == 1)
            {
                BtnBulOtobus.Visible = true;
                TxtIsAkisNoOtobus.Visible = true;
                BtnGuncelleOtobus.Visible = true;
                LblIsAkisNo.Visible = false;
                TemizleOtobus();
            }
            else
            {
                BtnBulOtobus.Visible = false;
                TxtIsAkisNoOtobus.Visible = false;
                BtnGuncelleOtobus.Visible = false;
                LblIsAkisNo.Visible = true;
                TemizleOtobus();
            }
        }
        string OtobusToplamMaliyet(string gidis,string donus)
        {
            if (gidis=="")
            {
                a = 0;
            }
            else
            {
                a = gidis.ConDouble();
            }
            if (donus == "")
            {
                b = 0;
            }
            else
            {
                b = donus.ConDouble();
            }
            toplam = a + b;
            return toplam.ToString();
        }
        private void TxtGidisUcret_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtGidisUcret_TextChanged(object sender, EventArgs e)
        {
            TxtToplamMaliyetOtobus.Text = OtobusToplamMaliyet(TxtGidisUcret.Text, TxtDonusUcret.Text);
        }

        private void TxtDonusUcret_TextChanged(object sender, EventArgs e)
        {
            TxtToplamMaliyetOtobus.Text = OtobusToplamMaliyet(TxtGidisUcret.Text, TxtDonusUcret.Text);
        }

        private void TxtDonusUcret_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNoUcak.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İş Akış No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string bilet = "UÇAK BİLETİ";
                DateTime gidistarihiSaati = new DateTime(DtSeyahatTarihiGidis.Value.Year, DtSeyahatTarihiGidis.Value.Month, DtSeyahatTarihiGidis.Value.Day, DtSeyahatSaatiDonus.Value.Hour, DtSeyahatSaatiDonus.Value.Minute, DtSeyahatSaatiDonus.Value.Second);
                DateTime donustarihiSaati = new DateTime(DtUcakDonusTarih.Value.Year, DtUcakDonusTarih.Value.Month, DtUcakDonusTarih.Value.Day, DtUcakDonusSaat.Value.Hour, DtUcakDonusSaat.Value.Minute, DtUcakDonusSaat.Value.Second);
                UcakOtobus ucakOtobus = new UcakOtobus(TxtIsAkisNoUcak.Text.ConInt(), CmbTalepTuru.Text, TxtGorevFormNo.Text, TxtIzinFormNo.Text, CmbButceKoduUcak.Text, CmbSiparisNo.Text, CmbAdSoyad.Text, TxtMasrafyeriNo.Text, TxtMasrafYeri.Text, TxtGorevi.Text, TxtTc.Text, TxtHes.Text, TxtMail.Text, TxtKisaKod.Text, bilet, TxtSeyahatFirmasiGidis.Text, gidistarihiSaati, CmbUcakGidisNereden.Text, CmbUcakGidisNereye.Text, TxtSeyahatFirmasDonus.Text, donustarihiSaati, CmbUcakDonusNereden.Text, CmbUcakNereyeNereye.Text, TxtToplamMaliyetUcak.Text.ConDouble(), islemadimigun, dosyayolugun, TxtBiletSayisi.Text.ConInt(), satNoUcak);

                string mesaj = ucakOtobusManager.Update(ucakOtobus, idUcak);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string onay = "ONAY AŞAMASINDA";
                UcakOtobus ucak = new UcakOtobus(onay);
                string messege = ucakOtobusManager.OnayGuncelle(ucak, idUcak);
                if (messege != "OK")
                {
                    MessageBox.Show(messege, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Directory.Delete(dosyayolugun, true);
                CreateDirectoryUcakGun();
                CreateLogUcakGun();
                CreateWordUcakGun();
                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleUcak();
            }
        }

        private void BtnGuncelleOtobus_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNoOtobus.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İş Akış No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string biletTuru = "OTOBÜS BİLETİ";
                DateTime gidistarihiSaati = new DateTime(DtSeyahatTarihiGidisOtobus.Value.Year, DtSeyahatTarihiGidisOtobus.Value.Month, DtSeyahatTarihiGidisOtobus.Value.Day, DtSeyahatSaatiDonusOtobus.Value.Hour, DtSeyahatSaatiDonusOtobus.Value.Minute, DtSeyahatSaatiDonusOtobus.Value.Second);
                DateTime donustarihiSaati = new DateTime(DtOtobusonusTarih.Value.Year, DtOtobusonusTarih.Value.Month, DtOtobusonusTarih.Value.Day, DtOtobusDonusTarih.Value.Hour, DtOtobusDonusTarih.Value.Minute, DtOtobusDonusTarih.Value.Second);
                UcakOtobus ucakOtobus = new UcakOtobus(TxtIsAkisNoOtobus.Text.ConInt(), CmbTalepTuruOtobus.Text, TxtGorevFormNoOtobus.Text, TxtIzinFormNoOtobus.Text, CmbButceKoduOtobus.Text, CmbSiparisNoOtobus.Text, CmbAdSoyadOtobus.Text, TxtMasrafyeriNoOtobus.Text, TxtMasrafYeriOtobus.Text, TxtGoreviOtobus.Text, TxtTcOtobus.Text, TxtHesOtobus.Text, TxtMailOtobus.Text, TxtKisaKodOtobus.Text, biletTuru, TxtSeyahatFirmasiOtobus.Text, gidistarihiSaati, CmbOtobusGidisNereden.Text, CmbNereyeGidisNereye.Text, TxtSeyahatFirmasDonusOtobus.Text, donustarihiSaati, CmbOtobusDonusNereden.Text, CmbOtobusDonusNereye.Text, TxtToplamMaliyetOtobus.Text.ConDouble(), islemadimiOtobus, dosyayoluOtobus, TxtBiletSayisiOtobus.Text.ConInt(), satNoOtobus);
                
                string mesaj = ucakOtobusManager.Update(ucakOtobus, idOtobus);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string onay2 = "ONAY AŞAMASINDA";
                UcakOtobus otobus = new UcakOtobus(onay2);
                string messege = ucakOtobusManager.OnayGuncelle(otobus, idOtobus);
                if (messege != "OK")
                {
                    MessageBox.Show(messege, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Directory.Delete(dosyayoluOtobus, true);
                CreateDirectoryOtobusGuncelle();
                CreateWordOtobusGun();
                CreateLogOtobusGun();
                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleUcak();
            }
        }
        int satNoUcak;
        private void BtnBulUcak_Click(object sender, EventArgs e)
        {
            UcakOtobus ucakOtobus = ucakOtobusManager.Get(TxtIsAkisNoUcak.Text.ConInt());
            if (ucakOtobus == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleUcak();
                return;
            }
            idUcak = ucakOtobus.Id;
            islemadimigun = ucakOtobus.Islemadimi;
            dosyayolugun = ucakOtobus.Dosyayolu;
            CmbTalepTuru.Text = ucakOtobus.Talepturu;
            TxtGorevFormNo.Text = ucakOtobus.Gorevformno;
            TxtIzinFormNo.Text = ucakOtobus.Izinformno;
            CmbButceKoduUcak.Text = ucakOtobus.Butcekodu;
            CmbSiparisNo.Text = ucakOtobus.Siparisno;
            CmbAdSoyad.Text = ucakOtobus.Adsoyad;
            TxtMasrafyeriNo.Text = ucakOtobus.Masrafyerino;
            TxtMasrafYeri.Text = ucakOtobus.Masrafyeri;
            TxtGorevi.Text = ucakOtobus.Gorevi;
            TxtTc.Text = ucakOtobus.Tc;
            TxtHes.Text = ucakOtobus.Hes;
            TxtMail.Text = ucakOtobus.Email;
            TxtKisaKod.Text = ucakOtobus.Kisakod;
            TxtSeyahatFirmasiGidis.Text = ucakOtobus.Gidisfirma;
            DtSeyahatTarihiGidis.Value = ucakOtobus.Gidistarihi;
            DtSeyahatSaatiDonus.Value = ucakOtobus.Gidistarihi;
            CmbUcakGidisNereden.Text = ucakOtobus.Gidisnereden;
            CmbUcakGidisNereye.Text = ucakOtobus.Gidisnereye;
            TxtSeyahatFirmasDonus.Text = ucakOtobus.Donusfirma;
            DtUcakDonusTarih.Value = ucakOtobus.Donustarihi;
            DtUcakDonusSaat.Value = ucakOtobus.Donustarihi;
            CmbUcakDonusNereden.Text = ucakOtobus.Donusnereden;
            CmbUcakNereyeNereye.Text = ucakOtobus.Donusnereye;
            TxtToplamMaliyetUcak.Text = ucakOtobus.ToplamMaliyet.ToString();
            TxtBiletSayisi.Text = ucakOtobus.BiletSayisi.ToString();
            satNoUcak = ucakOtobus.SatNo;
        }

        private void BrnTemizleOtobus_Click(object sender, EventArgs e)
        {
            TemizleOtobus();
        }

        private void CmbAdSoyadOtobus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start3 == true)
            {
                return;
            }
            SiparisPersonel siparis = siparisPersonelManager.Get("", CmbAdSoyadOtobus.Text);
            CmbSiparisNoOtobus.Text = siparis.Siparis;
            TxtMasrafyeriNoOtobus.Text = siparis.Masrafyerino;
            TxtMasrafYeriOtobus.Text = siparis.Masrafyeri;
            idgun = siparis.Id;
            TxtTcOtobus.Text = siparis.Tc;
            TxtHesOtobus.Text = siparis.Hes;
            TxtMailOtobus.Text = siparis.Mail;
            TxtKisaKodOtobus.Text = siparis.Kisakod;
            TxtGoreviOtobus.Text = siparis.Gorevi;
            ustAmirMails = ustAmirManager.GetList(idgun);
            if (ustAmirMails.Count > 0)
            {
                usamirbolum = ustAmirMails[0].Bolum;
                usamirisim = ustAmirMails[0].Adsoyad;
            }
            start4 = false;
        }

        void SiparisIsimlerDoldurOtobus()
        {
            CmbAdSoyadOtobus.DataSource = siparisPersonelManager.GetList(siparisotobus);
            CmbAdSoyadOtobus.ValueMember = "Id";
            CmbAdSoyadOtobus.DisplayMember = "Personel";
            CmbAdSoyadOtobus.SelectedValue = 0;
        }
        /*void SiparislerGun()
        {
            CmbSiparisNoOtobus.DataSource = siparislerManager.GetList();
            CmbSiparisNoOtobus.ValueMember = "Id";
            CmbSiparisNoOtobus.DisplayMember = "Siparisno";
            CmbSiparisNoOtobus.SelectedValue = 0;
        }*/
        void CmbIlYükle()
        {
            CmbUcakGidisNereden.DataSource = tedarikciFirmaManager.Iller();
            CmbUcakGidisNereden.SelectedIndex = -1;
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplayOnay();
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("SAT Kaydı Oluşturmak İster Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SatOlustur();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("İşlem İptal Edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            /*if (onayid == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Bilet Talebi Seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilet Talebini Onaylamak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string onay = "ONAYLANDI";
                UcakOtobus ucakOtobus = new UcakOtobus(onay);
                string mesaj = ucakOtobusManager.OnayGuncelle(ucakOtobus, onayid);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLogOnay();
                System.Threading.Tasks.Task.Factory.StartNew(() => MailSendMetotOnay());
                MessageBox.Show(isakisno + "Nolu Bilet Talebi Başarıyla Onaylanmıştır.");
                DataDisplayOnay();
            }*/
        }

        

        void CmbIlYükle2()
        {
            CmbUcakGidisNereye.DataSource = tedarikciFirmaManager.Iller();
            CmbUcakGidisNereye.SelectedIndex = -1;
        }
        void CmbIlYükle3()
        {
            CmbUcakDonusNereden.DataSource = tedarikciFirmaManager.Iller();
            CmbUcakDonusNereden.SelectedIndex = -1;
        }
        void CmbIlYükle4()
        {
            CmbUcakNereyeNereye.DataSource = tedarikciFirmaManager.Iller();
            CmbUcakNereyeNereye.SelectedIndex = -1;
        }
        void CmbIlYükle5()
        {
            CmbOtobusGidisNereden.DataSource = tedarikciFirmaManager.Iller();
            CmbOtobusGidisNereden.SelectedIndex = -1;
        }
        void CmbIlYükle6()
        {
            CmbNereyeGidisNereye.DataSource = tedarikciFirmaManager.Iller();
            CmbNereyeGidisNereye.SelectedIndex = -1;
        }
        void CmbIlYükle7()
        {
            CmbOtobusDonusNereden.DataSource = tedarikciFirmaManager.Iller();
            CmbOtobusDonusNereden.SelectedIndex = -1;
        }
        void CmbIlYükle8()
        {
            CmbOtobusDonusNereye.DataSource = tedarikciFirmaManager.Iller();
            CmbOtobusDonusNereye.SelectedIndex = -1;
        }
    }
}
