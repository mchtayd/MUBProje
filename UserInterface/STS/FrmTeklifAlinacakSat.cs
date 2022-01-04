using Business.Concreate;
using Business.Concreate.STS;
using DataAccess.Concreate;
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
using UserInterface.Ana_Sayfa;

namespace UserInterface.STS
{
    public partial class FrmTeklifAlinacakSat : Form
    {
        SatinAlinacakMalManager satinAlinacakMalManager;
        SatDataGridview1Manager satDataGridview1Manager;
        SatIslemAdimlariManager satIslemAdimlarimanager;
        SatNoManager satNoManager;
        TeklifFirmalarManager teklifFirmalarManager;
        FiyatTeklifiAl teklifiAl;
        FiyatTeklifiAlManager fiyatTeklifiAlManager;
        SatRenkliiTabloManager satRenkliTabloManager;
        TedarikciFirmaManager tedarikciManager;
        TeklifiAlinanManager teklifiAlinanManager;
        List<SatDataGridview1> satDatas;
        List<SatDataGridview1> satListWaiting;
        List<SatDataGridview1> mailGonderilecekler;
        List<SatDataGridview1> mailGonderilenler;
        List<FiyatTeklifiAl> teklifiAls;
        List<FiyatTeklifiAl> teklifler;
        List<FiyatTeklifiAl> tekliflerMail;
        List<FiyatTeklifiAl> tekliflerMailGonderilenler;
        List<TedarikciFirma> suppliers;
        List<string> fileNames = new List<string>();
        public object[] infos;
        public object[] infos1;
        public object[] infos2;
        int malzemesayisi = 0, ucteklif = 1;
        List<SatinAlinacakMalzemeler> satinAlinacakMalzemelers;
        List<SatNo> satNos;
        List<string> mailedSuppliers = new List<string>();
        List<string> supplierNames;
        //string dosyayolu = @"Z:\MUB OTOMASYON\SATIN ALMA\";
        string formNo;
        string yapilanislem, islemyapan, islem;
        string siparisNo="", kaynakdosyaismi1, kaynakdosyaismi2, kaynakdosyaismi3, alinandosya1, alinandosya2, alinandosya3, masrafyerino, control, firmaAdi, idler, messege, yeniyol1, yeniyol2, yeniyol3, dosya, directoryPath = null;
        bool start = false, refreshTeklifAlMalzemeList = false;
        string companyName, topfiyat;
        double outValue = 0, sonuc = 0, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, y1, y2, y3, y4, y5, y6, y7, y8, y9, y10, z1, z2, z3, z4, z5, z6, z7, z8, z9, z10 = 0;


        public FrmTeklifAlinacakSat()
        {
            InitializeComponent();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            satIslemAdimlarimanager = SatIslemAdimlariManager.GetInstance();
            teklifFirmalarManager = TeklifFirmalarManager.GetInstance();
            fiyatTeklifiAlManager = FiyatTeklifiAlManager.GetInstance();
            satRenkliTabloManager = SatRenkliiTabloManager.GetInstance();
            tedarikciManager = TedarikciFirmaManager.GetInstance();
            teklifiAlinanManager = TeklifiAlinanManager.GetInstance();
        }
        private void FrmTeklifAlinacakSat_Load(object sender, EventArgs e)
        {
            FillInfos();
            SatDataGrid1();
            CmbFirmalarLoad();
            TeklifAlMalzemeList();
            DataDisplay();
            SatListLoad();
            MailGonderilecekler();
            MailGonderilenler();
            TxtTop.Text = DtgTeklifAl.RowCount.ToString();
            TxtFiyatTeklifi.Text = DtgTeklifMalzemeList.RowCount.ToString();
            TxtTeklİfSatSayisi.Text = DtgSatList.RowCount.ToString();
            //TedarikciFirmaName();


            /*Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(@"D:\testdoc1.docx");
            object missing = System.Reflection.Missing.Value;
            //doc.Content.Text += "Test Veri 2";
            string content = doc.Content.Text;

            List<string> list = content.Split(' ').ToList();
           
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i]=="Soyadı:")
                {
                    list.Insert(i, "Mehmet");
                }
            }
            
            app.Visible = true;    //Optional
            doc.Save();
            doc.Close();*/
            start = true;
            refreshTeklifAlMalzemeList = true;
        }
        public void YenilecekVeri()
        {
            start = false;
            refreshTeklifAlMalzemeList = false;
            FillInfos();
            SatDataGrid1();
            CmbFirmalarLoad();
            TeklifAlMalzemeList();
            DataDisplay();
            SatListLoad();
            MailGonderilecekler();
            MailGonderilenler();
            TxtTop.Text = DtgTeklifAl.RowCount.ToString();
            TxtFiyatTeklifi.Text = DtgTeklifMalzemeList.RowCount.ToString();
            TxtTeklİfSatSayisi.Text = DtgSatList.RowCount.ToString();
            start = true;
            refreshTeklifAlMalzemeList = true;
        }
        void MailGonderilecekler()
        {
            mailGonderilecekler = satDataGridview1Manager.MailList("Gönderilmedi");
            dataBinder2.DataSource = mailGonderilecekler.ToDataTable();
            DtgMailList.DataSource = dataBinder2;

            DtgMailList.Columns["Id"].Visible = false;
            DtgMailList.Columns["Satno"].HeaderText = "SAT NO";
            DtgMailList.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgMailList.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgMailList.Columns["Talepeden"].HeaderText = "İSTEKTE BULUNAN";
            DtgMailList.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgMailList.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgMailList.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgMailList.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgMailList.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgMailList.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgMailList.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgMailList.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgMailList.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgMailList.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgMailList.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgMailList.Columns["Uctekilf"].Visible = false;
            DtgMailList.Columns["SiparisNo"].Visible = false;
            DtgMailList.Columns["DosyaYolu"].Visible = false;
            DtgMailList.Columns["PersonelId"].Visible = false;
            DtgMailList.Columns["FirmaBilgisi"].Visible = false;
            DtgMailList.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgMailList.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgMailList.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgMailList.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgMailList.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgMailList.Columns["BelgeTuru"].Visible = false;
            DtgMailList.Columns["BelgeNumarasi"].Visible = false;
            DtgMailList.Columns["BelgeTarihi"].Visible = false;
            DtgMailList.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgMailList.Columns["Donem"].HeaderText = "DÖNEM";
            DtgMailList.Columns["SatOlusturmaTuru"].Visible = false;
            DtgMailList.Columns["RedNedeni"].Visible = false;
            DtgMailList.Columns["TeklifDurumu"].Visible = false;
            DtgMailList.Columns["Proje"].Visible = false;
            DtgMailList.Columns["Durum"].Visible = false;

            TxtMailListCount.Text = DtgMailList.RowCount.ToString();
        }
        void MailGonderilenler()
        {
            mailGonderilenler = satDataGridview1Manager.MailList("Gönderildi");
            dataBinder3.DataSource = mailGonderilenler.ToDataTable();
            DtgGelenMail.DataSource = dataBinder3;

            DtgGelenMail.Columns["Id"].Visible = false;
            DtgGelenMail.Columns["Satno"].HeaderText = "SAT NO";
            DtgGelenMail.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgGelenMail.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgGelenMail.Columns["Talepeden"].HeaderText = "İSTEKTE BULUNAN";
            DtgGelenMail.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgGelenMail.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgGelenMail.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgGelenMail.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgGelenMail.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgGelenMail.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgGelenMail.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgGelenMail.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgGelenMail.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgGelenMail.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgGelenMail.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgGelenMail.Columns["Uctekilf"].Visible = false;
            DtgGelenMail.Columns["SiparisNo"].Visible = false;
            DtgGelenMail.Columns["DosyaYolu"].Visible = false;
            DtgGelenMail.Columns["PersonelId"].Visible = false;
            DtgGelenMail.Columns["FirmaBilgisi"].Visible = false;
            DtgGelenMail.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgGelenMail.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgGelenMail.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgGelenMail.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgGelenMail.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgGelenMail.Columns["BelgeTuru"].Visible = false;
            DtgGelenMail.Columns["BelgeNumarasi"].Visible = false;
            DtgGelenMail.Columns["BelgeTarihi"].Visible = false;
            DtgGelenMail.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgGelenMail.Columns["Donem"].HeaderText = "DÖNEM";
            DtgGelenMail.Columns["SatOlusturmaTuru"].Visible = false;
            DtgGelenMail.Columns["RedNedeni"].Visible = false;
            DtgGelenMail.Columns["TeklifDurumu"].Visible = false;
            DtgGelenMail.Columns["Proje"].Visible = false;
            DtgGelenMail.Columns["Durum"].Visible = false;

            TxtGelenMail.Text = DtgGelenMail.RowCount.ToString();
        }
        private string FirmaControl()
        {
            if (malzemesayisi == 0)
            {
                return messege = "Malzeme Bulunamadı.";
            }
            if (malzemesayisi > 0)
            {
                if (BF1.Text == IF1.Text || BF1.Text == UF1.Text || IF1.Text == UF1.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 1)
            {
                if (BF2.Text == IF2.Text || BF2.Text == UF2.Text || IF2.Text == UF2.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 2)
            {
                if (BF3.Text == IF3.Text || BF3.Text == UF3.Text || IF3.Text == UF3.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 3)
            {
                if (BF4.Text == IF4.Text || BF4.Text == UF4.Text || IF4.Text == UF4.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 4)
            {
                if (BF4.Text == IF4.Text || BF4.Text == UF4.Text || IF4.Text == UF4.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 5)
            {
                if (BF5.Text == IF5.Text || BF5.Text == UF5.Text || IF5.Text == UF5.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 6)
            {
                if (BF6.Text == IF6.Text || BF6.Text == UF6.Text || IF6.Text == UF6.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 7)
            {
                if (BF7.Text == IF7.Text || BF7.Text == UF7.Text || IF7.Text == UF7.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 8)
            {
                if (BF8.Text == IF8.Text || BF8.Text == UF8.Text || IF8.Text == UF8.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 9)
            {
                if (BF9.Text == IF9.Text || BF9.Text == UF9.Text || IF9.Text == UF9.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            if (malzemesayisi > 10)
            {
                if (BF10.Text == IF10.Text || BF10.Text == UF10.Text || IF10.Text == UF10.Text)
                {
                    return messege = "Teklif Alınacak Firmalar Aynı Olamaz.";
                }
            }
            return messege = "OK";
        }

        void CmbClearDataSource(params ComboBox[] cmbArray)
        {
            foreach (ComboBox item in cmbArray)
            {
                item.DataSource = null;
            }
        }
        void CmbDuzenle(params ComboBox[] cmbArray)
        {
            foreach (ComboBox item in cmbArray)
            {
                item.DataSource = supplierNames.Select(x => x).ToList();
                item.SelectedIndex = -1;
            }
        }
        void CmbFirmalarLoad()
        {
            CmbFirmalar.DataSource = teklifFirmalarManager.TedarikciFirmalar(true);

            CmbFirmalar.ValueMember = "Id";
            CmbFirmalar.DisplayMember = "Firmaname";
            CmbFirmalar.SelectedValue = -1;
        }
        void TedarikciFirmaName()
        {
            List<TeklifFirmalar> supplierList = teklifFirmalarManager.TedarikciFirmalar(false);
            supplierNames = supplierList.Select(x => x.Firmaname).ToList();

            CmbClearDataSource(BF1, BF2, BF3, BF4, BF5, BF6, BF7, BF8, BF9, BF10, IF1, IF2, IF3, IF4, IF5, IF6, IF7, IF8, IF9, IF10, UF1, UF2, UF3, UF4, UF5, UF6, UF7, UF8, UF9, UF10);

            if (malzemesayisi > 0)
            {
                CmbDuzenle(BF1, IF1, UF1);
            }
            if (malzemesayisi > 1)
            {
                CmbDuzenle(BF2, IF2, UF2);
            }
            if (malzemesayisi > 2)
            {
                CmbDuzenle(BF3, IF3, UF3);
            }
            if (malzemesayisi > 3)
            {
                CmbDuzenle(BF4, IF4, UF4);
            }
            if (malzemesayisi > 4)
            {
                CmbDuzenle(BF5, IF5, UF5);
            }
            if (malzemesayisi > 5)
            {
                CmbDuzenle(BF6, IF6, UF6);
            }
            if (malzemesayisi > 6)
            {
                CmbDuzenle(BF7, IF7, UF7);
            }
            if (malzemesayisi > 7)
            {
                CmbDuzenle(BF8, IF8, UF8);
            }
            if (malzemesayisi > 8)
            {
                CmbDuzenle(BF9, IF9, UF9);
            }
            if (malzemesayisi > 9)
            {
                CmbDuzenle(BF10, IF10, UF10);
            }
        }
        private void BtnDosyaEkle1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(yol))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.");
                return;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi1 = openFileDialog1.SafeFileName.ToString();
                alinandosya1 = openFileDialog1.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string dosyaismi = " 1. Teklif " + kaynakdosyaismi1;
            yeniyol1 = yol + "\\" + dosyaismi;


            if (File.Exists(yeniyol1))
            {
                MessageBox.Show("Belirtilen Klasörde " + dosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya1, yeniyol1);
                BtnDosyaEkle1.BackColor = Color.LightGreen;
            }
            WebBrowser2(yol);
        }
        private void BtnDosyaEkle2_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(yol))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.");
                return;
            }
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi2 = openFileDialog2.SafeFileName.ToString();
                alinandosya2 = openFileDialog2.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string dosyaismi = " 2. Teklif " + kaynakdosyaismi2;
            yeniyol2 = yol + "\\" + dosyaismi;


            if (File.Exists(yeniyol2))
            {
                MessageBox.Show("Belirtilen Klasörde " + dosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya2, yeniyol2);
                BtnDosyaEkle2.BackColor = Color.LightGreen;
            }
            WebBrowser2(yol);
        }
        private void BtnDosyaEkle3_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(yol))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı.");
                return;
            }
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi3 = openFileDialog3.SafeFileName.ToString();
                alinandosya3 = openFileDialog3.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string dosyaismi = " 3. Teklif " + kaynakdosyaismi3;
            yeniyol3 = yol + "\\" + dosyaismi;


            if (File.Exists(yeniyol3))
            {
                MessageBox.Show("Belirtilen Klasörde " + dosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya3, yeniyol3);
                BtnDosyaEkle3.BackColor = Color.LightGreen;
            }
            WebBrowser2(yol);
        }
        string oku = "OK";
        void CreateOnayMail(List<TeklifAlinan> list)
        {

            MailSendHtml(formNo + " Nolu SAT Onayı",
                ControlMalzemeler(list),
                new List<string>() { "gulsahotaci@mubvan.net", "mehmetsenol@mubvan.net" });
        }
        string ControlMalzemeler(List<TeklifAlinan> teklifler)
        {
            if (teklifler == null)
            {
                return "";
            }
            if (teklifler.Count == 0)
            {
                return "";
            }

            DtgForHtml.DataSource = teklifler;
            if (teklifler[0].Firma2.Length == 0)
            {
                DtgForHtml.Columns["Ibf"].Visible = false;
                DtgForHtml.Columns["Itf"].Visible = false;
                DtgForHtml.Columns["Firma2"].Visible = false;
            }
            if (teklifler[0].Firma3.Length == 0)
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

            return Html_Out(DtgForHtml);

            /*string body = "";
            foreach (TeklifAlinan item in teklifler)
            {
                body += item;
            }
            return body;*/
            //malzemesayisi
        }
        public string Html_Out(DataGridView dg)
        {
            StringBuilder strB = new StringBuilder();
            //create html & table
            strB.AppendLine("<html><head><meta charset=utf-8><style>table{padding:10px;} th,td{padding:8px;}</style></head><body>");
            strB.AppendLine(
            "<p>Erkan Bey Merhaba, <br><br> Aşağıda bilgileri verilen arıza için fiyat teklifi alınmıştır.Bir sonraki ayda tarafınıza fatura edilecektir.Alım yapmak için onayınızı rica ediyorum. <br><br> İyi Çalışmalar.<br><br>" +
               "<b>Üs Bölgesi :</b> " + usBolgesi + "<br><br>" +
               "<b>Gerekçe    :</b> " + gerekce + "<br><br></p>");

            strB.AppendLine("<center><table border='1' cellpadding='0' cellspacing='0'>");
            strB.AppendLine("<tr>");
            //create table header
            for (int i = 0; i < dg.Columns.Count; i++) { if (dg.Columns[i].Visible == true) { strB.AppendLine("<th align='center' valign='middle'>" + dg.Columns[i].HeaderText + "</th>"); } }
            //create table body
            strB.AppendLine("</tr>");
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                if (dg.Rows[i].Visible)
                {
                    strB.AppendLine("<tr>");
                    foreach (DataGridViewCell dgvc in dg.Rows[i].Cells)
                    {
                        if (dgvc.OwningColumn.Visible == true) { strB.AppendLine("<td align='center' valign='middle'>" + dgvc.Value.ToString() + "</td>"); }
                    }
                    strB.AppendLine("</tr>");
                }
            }
            //table footer & end of html file
            strB.AppendLine("</table></center>");
            strB.AppendLine("</body></html>");
            return strB.ToString();
        }
        List<TeklifAlinan> teklifAlinanListe;
        private void BtnTeklifKaydet_Click(object sender, EventArgs e)
        {
            if (satOlusturmaTuru == "")
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (satbirim == "PRJ.DİR.SATIN ALMA")
                {
                    oku = KayıtKontrol();
                    BtnDosyaEkle1.BackColor = Color.Transparent;
                    BtnDosyaEkle2.BackColor = Color.Transparent;
                    BtnDosyaEkle3.BackColor = Color.Transparent;
                }
                if (oku == "OK")
                {
                    BtnDosyaEkle1.BackColor = Color.Transparent;
                    BtnDosyaEkle2.BackColor = Color.Transparent;
                    BtnDosyaEkle3.BackColor = Color.Transparent;

                    teklifAlinanListe = new List<TeklifAlinan>();

                    if (stn1.Text != "")
                    {
                        TeklifAlinan teklifAlinan = new TeklifAlinan(stn1.Text, t1.Text, m1.Text.ConInt(), b1.Text, F1_1.Text, BBF1.Text.ConDouble(),
                            BT1.Text.ConDouble(), F2_1.Text, IBF1.Text.ConDouble(), IT1.Text.ConDouble(), F3_1.Text, UBF1.Text.ConDouble(), UT1.Text.ConDouble(), siparisNo);
                        teklifAlinanListe.Add(teklifAlinan);
                    }
                    if (stn2.Text != "")
                    {
                        TeklifAlinan teklifAlinan = new TeklifAlinan(stn2.Text, t2.Text, m2.Text.ConInt(), b2.Text, F1_2.Text, BBF2.Text.ConDouble(),
                            BT2.Text.ConDouble(), F2_2.Text, IBF2.Text.ConDouble(), IT2.Text.ConDouble(), F3_2.Text, UBF2.Text.ConDouble(), UT2.Text.ConDouble(), siparisNo);
                        teklifAlinanListe.Add(teklifAlinan);
                    }
                    if (stn3.Text != "")
                    {
                        TeklifAlinan teklifAlinan = new TeklifAlinan(stn3.Text, t3.Text, m3.Text.ConInt(), b3.Text, F1_3.Text, BBF3.Text.ConDouble(),
                            BT3.Text.ConDouble(), F2_3.Text, IBF3.Text.ConDouble(), IT3.Text.ConDouble(), F3_3.Text, UBF3.Text.ConDouble(), UT3.Text.ConDouble(), siparisNo);
                        teklifAlinanListe.Add(teklifAlinan);
                    }
                    if (stn4.Text != "")
                    {
                        TeklifAlinan teklifAlinan = new TeklifAlinan(stn4.Text, t4.Text, m4.Text.ConInt(), b4.Text, F1_4.Text, BBF4.Text.ConDouble(),
                            BT4.Text.ConDouble(), F2_4.Text, IBF4.Text.ConDouble(), IT4.Text.ConDouble(), F3_4.Text, UBF4.Text.ConDouble(), UT4.Text.ConDouble(), siparisNo);
                        teklifAlinanListe.Add(teklifAlinan);
                    }
                    if (stn5.Text != "")
                    {
                        TeklifAlinan teklifAlinan = new TeklifAlinan(stn5.Text, t5.Text, m5.Text.ConInt(), b5.Text, F1_5.Text, BBF5.Text.ConDouble(),
                            BT5.Text.ConDouble(), F2_5.Text, IBF5.Text.ConDouble(), IT5.Text.ConDouble(), F3_5.Text, UBF5.Text.ConDouble(), UT5.Text.ConDouble(), siparisNo);
                        teklifAlinanListe.Add(teklifAlinan);
                    }
                    if (stn6.Text != "")
                    {
                        TeklifAlinan teklifAlinan = new TeklifAlinan(stn6.Text, t6.Text, m6.Text.ConInt(), b6.Text, F1_6.Text, BBF6.Text.ConDouble(),
                            BT6.Text.ConDouble(), F2_6.Text, IBF6.Text.ConDouble(), IT6.Text.ConDouble(), F3_6.Text, UBF6.Text.ConDouble(), UT6.Text.ConDouble(), siparisNo);
                        teklifAlinanListe.Add(teklifAlinan);
                    }
                    if (stn7.Text != "")
                    {
                        TeklifAlinan teklifAlinan = new TeklifAlinan(stn7.Text, t7.Text, m7.Text.ConInt(), b7.Text, F1_7.Text, BBF7.Text.ConDouble(),
                            BT7.Text.ConDouble(), F2_7.Text, IBF7.Text.ConDouble(), IT7.Text.ConDouble(), F3_7.Text, UBF7.Text.ConDouble(), UT7.Text.ConDouble(), siparisNo);
                        teklifAlinanListe.Add(teklifAlinan);
                    }
                    if (stn8.Text != "")
                    {
                        TeklifAlinan teklifAlinan = new TeklifAlinan(stn8.Text, t8.Text, m8.Text.ConInt(), b8.Text, F1_8.Text, BBF8.Text.ConDouble(),
                            BT8.Text.ConDouble(), F2_8.Text, IBF8.Text.ConDouble(), IT8.Text.ConDouble(), F3_8.Text, UBF8.Text.ConDouble(), UT8.Text.ConDouble(), siparisNo);
                        teklifAlinanListe.Add(teklifAlinan);
                    }
                    if (stn9.Text != "")
                    {
                        TeklifAlinan teklifAlinan = new TeklifAlinan(stn9.Text, t9.Text, m9.Text.ConInt(), b9.Text, F1_9.Text, BBF9.Text.ConDouble(),
                            BT9.Text.ConDouble(), F2_9.Text, IBF9.Text.ConDouble(), IT9.Text.ConDouble(), F3_9.Text, UBF9.Text.ConDouble(), UT9.Text.ConDouble(), siparisNo);
                        teklifAlinanListe.Add(teklifAlinan);
                    }
                    if (stn10.Text != "")
                    {
                        TeklifAlinan teklifAlinan = new TeklifAlinan(stn10.Text, t10.Text, m10.Text.ConInt(), b10.Text, F1_10.Text, BBF10.Text.ConDouble(), BT10.Text.ConDouble(), F2_10.Text, IBF10.Text.ConDouble(), IT10.Text.ConDouble(), F3_10.Text, UBF10.Text.ConDouble(), UT10.Text.ConDouble(), siparisNo);
                        teklifAlinanListe.Add(teklifAlinan);
                    }

                    if (teklifAlinanListe.Count == 0)
                    {
                        MessageBox.Show("Eleman Bulunamadı");
                        return;
                    }
                    // TO DO


                    //Task.Factory.StartNew(() => CreateOnayMail(teklifAlinanListe));


                    //CreateOnayMail(list);
                    //return;
                    //
                    string mesaj = teklifiAlinanManager.Delete(siparisNo);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (TeklifAlinan item in teklifAlinanListe)
                    {
                        teklifiAlinanManager.Add(item);
                    }
                    /*if (satbirim == "BSRN GN.MDL.SATIN ALMA")
                    {
                        foreach (TeklifAlinan item in list)
                        {
                            teklifiAlinanManager.Add(item);
                        }
                    }*/
                    /*if (satbirim != "BSRN GN.MDL.SATIN ALMA")
                    {
                        foreach (TeklifAlinan item in list)
                        {
                            teklifiAlinanManager.Update(item);
                        }
                    }*/

                    satDataGridview1Manager.TeklifDurum(siparisNo);

                    yapilanislem = "FİRMALARIN FİYAT TEKLİFLERİ KAYDEDİLDİ.";

                    SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, islemyapan, DateTime.Now);
                    satIslemAdimlarimanager.Add(satIslemAdimlari);

                    //Task.Factory.StartNew(() => MailSendMetot());

                    MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SatListLoad();
                    TxtTeklİfSatSayisi.Text = DtgSatList.RowCount.ToString();
                    TekilfleriTemizle();
                }
            }
        }
        string KayıtKontrol()
        {
            if (GT1.Text == "0.00 ₺")
            {
                MessageBox.Show("Lütfen 1. Teklif Bilgisini Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            if (BtnDosyaEkle1.BackColor != Color.LightGreen)
            {
                MessageBox.Show("Lütfen 1. Teklif İçin Dosya Ekleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            if (malzemesayisi > 1)
            {
                if (BBF2.Text == "" || IBF2.Text == "" || UBF2.Text == "")
                {
                    MessageBox.Show("Lütfen 2. Birim Fiyat Bilgilerini Eksiksiz Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            if (satbirim == "BSRN GN.MDL.SATIN ALMA")
            {
                return "OK";
            }
            if (GT2.Text == "0.00 ₺")
            {
                MessageBox.Show("Lütfen 2. Teklif Bilgisini Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            if (GT3.Text == "0.00 ₺")
            {
                MessageBox.Show("Lütfen 3. Teklif Bilgisini Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }


            if (BtnDosyaEkle2.BackColor != Color.LightGreen)
            {
                MessageBox.Show("Lütfen 2. Teklif İçin Dosya Ekleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            if (BtnDosyaEkle3.BackColor != Color.LightGreen)
            {
                MessageBox.Show("Lütfen 3. Teklif İçin Dosya Ekleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            if (malzemesayisi == 0)
            {
                MessageBox.Show("Eleman Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            if (malzemesayisi > 0)
            {
                if (BBF1.Text == "" || IBF1.Text == "" || UBF1.Text == "")
                {
                    MessageBox.Show("Lütfen 1. Birim Fiyat Bilgilerini Eksiksiz Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            if (malzemesayisi > 1)
            {
                if (BBF2.Text == "" || IBF2.Text == "" || UBF2.Text == "")
                {
                    MessageBox.Show("Lütfen 2. Birim Fiyat Bilgilerini Eksiksiz Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            if (malzemesayisi > 2)
            {
                if (BBF3.Text == "" || IBF3.Text == "" || UBF3.Text == "")
                {
                    MessageBox.Show("Lütfen 3. Birim Fiyat Bilgilerini Eksiksiz Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            if (malzemesayisi > 3)
            {
                if (BBF4.Text == "" || IBF4.Text == "" || UBF4.Text == "")
                {
                    MessageBox.Show("Lütfen 4. Birim Fiyat Bilgilerini Eksiksiz Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            if (malzemesayisi > 4)
            {
                if (BBF5.Text == "" || IBF5.Text == "" || UBF5.Text == "")
                {
                    MessageBox.Show("Lütfen 5. Birim Fiyat Bilgilerini Eksiksiz Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            if (malzemesayisi > 5)
            {
                if (BBF6.Text == "" || IBF6.Text == "" || UBF6.Text == "")
                {
                    MessageBox.Show("Lütfen 6. Birim Fiyat Bilgilerini Eksiksiz Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            if (malzemesayisi > 6)
            {
                if (BBF7.Text == "" || IBF7.Text == "" || UBF7.Text == "")
                {
                    MessageBox.Show("Lütfen 7. Birim Fiyat Bilgilerini Eksiksiz Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            if (malzemesayisi > 7)
            {
                if (BBF8.Text == "" || IBF8.Text == "" || UBF8.Text == "")
                {
                    MessageBox.Show("Lütfen 8. Birim Fiyat Bilgilerini Eksiksiz Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            if (malzemesayisi > 8)
            {
                if (BBF9.Text == "" || IBF9.Text == "" || UBF9.Text == "")
                {
                    MessageBox.Show("Lütfen 9. Birim Fiyat Bilgilerini Eksiksiz Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            if (malzemesayisi > 9)
            {
                if (BBF10.Text == "" || IBF10.Text == "" || UBF10.Text == "")
                {
                    MessageBox.Show("Lütfen 10. Birim Fiyat Bilgilerini Eksiksiz Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            return "OK";

        }
        private void WebBrowser()
        {
            webBrowser3.Navigate(dosya);
        }
        void FillInfos()
        {
            islemyapan = infos[1].ToString();
        }
        void SatDataGrid1()
        {
            satDatas = satDataGridview1Manager.TekifDurumListele("Alınmadı", "Onaylandı", ucteklif, "BELIRLENMEDI");
            binderSetRequest.DataSource = satDatas.ToDataTable();
            DtgTeklifAl.DataSource = binderSetRequest;
        }
        void TeklifAlMalzemeList()
        {
            teklifiAls = fiyatTeklifiAlManager.GetList("Beklemede");
            binderGetRequest.DataSource = teklifiAls.ToDataTable();
            DtgTeklifMalzemeList.DataSource = binderGetRequest;
            MalzemelistDüzenle();
            Renklendir();
        }
        void SatListLoad()//Sayfa 3 Soldaki Datagrid
        {
            satListWaiting = satDataGridview1Manager.TekifDurumListele("Gönderildi", "Onaylandı", ucteklif, "BELIRTILDI");
            binderSatWaiting.DataSource = satListWaiting.ToDataTable();
            DtgSatList.DataSource = binderSatWaiting;
            DataDisplayDtgSatList();

        }
        void DataDisplayDtgSatList()
        {
            DtgSatList.Columns["Id"].Visible = false;
            DtgSatList.Columns["Satno"].HeaderText = "SAT NO";
            DtgSatList.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgSatList.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgSatList.Columns["Talepeden"].HeaderText = "İSTEKTE BULUNAN";
            DtgSatList.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgSatList.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgSatList.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgSatList.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgSatList.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgSatList.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgSatList.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgSatList.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgSatList.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgSatList.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgSatList.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgSatList.Columns["Uctekilf"].Visible = false;
            DtgSatList.Columns["SiparisNo"].Visible = false;
            DtgSatList.Columns["DosyaYolu"].Visible = false;
            DtgSatList.Columns["PersonelId"].Visible = false;
            DtgSatList.Columns["FirmaBilgisi"].Visible = false;
            DtgSatList.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgSatList.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgSatList.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgSatList.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgSatList.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgSatList.Columns["BelgeTuru"].Visible = false;
            DtgSatList.Columns["BelgeNumarasi"].Visible = false;
            DtgSatList.Columns["BelgeTarihi"].Visible = false;
            DtgSatList.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
        }

        void SatMalzemeListLoad(string siparisNo)//Sayfa 3 Sağdaki Datagrid
        {
            teklifler = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
            malzemesayisi = teklifler.Count;

            FiyatTeklifiAl item = null;
            if (teklifler == null)
            {
                return;
            }

            if (teklifler.Count == 0)
            {
                return;
            }

            if (teklifler.Count > 0)
            {
                item = teklifler[0];
                stn1.Text = item.Stokno;
                t1.Text = item.Tanim;
                m1.Text = item.Miktar.ToString();
                b1.Text = item.Birim;
                F1_1.Text = item.Firma1;
                F2_1.Text = item.Firma2;
                F3_1.Text = item.Firma3;
            }

            if (teklifler.Count > 1)
            {
                item = teklifler[1];
                stn2.Text = item.Stokno;
                t2.Text = item.Tanim;
                m2.Text = item.Miktar.ToString();
                b2.Text = item.Birim;
                F1_2.Text = item.Firma1;
                F2_2.Text = item.Firma2;
                F3_2.Text = item.Firma3;
            }

            if (teklifler.Count > 2)
            {
                item = teklifler[2];
                stn3.Text = item.Stokno;
                t3.Text = item.Tanim;
                m3.Text = item.Miktar.ToString();
                b3.Text = item.Birim;
                F1_3.Text = item.Firma1;
                F2_3.Text = item.Firma2;
                F3_3.Text = item.Firma3;
            }

            if (teklifler.Count > 3)
            {
                item = teklifler[3];
                stn4.Text = item.Stokno;
                t4.Text = item.Tanim;
                m4.Text = item.Miktar.ToString();
                b4.Text = item.Birim;
                F1_4.Text = item.Firma1;
                F2_4.Text = item.Firma2;
                F3_4.Text = item.Firma3;
            }

            if (teklifler.Count > 4)
            {
                item = teklifler[4];
                stn5.Text = item.Stokno;
                t5.Text = item.Tanim;
                m5.Text = item.Miktar.ToString();
                b5.Text = item.Birim;
                F1_5.Text = item.Firma1;
                F2_5.Text = item.Firma2;
                F3_5.Text = item.Firma3;
            }

            if (teklifler.Count > 5)
            {
                item = teklifler[5];
                stn6.Text = item.Stokno;
                t6.Text = item.Tanim;
                m6.Text = item.Miktar.ToString();
                b6.Text = item.Birim;
                F1_6.Text = item.Firma1;
                F2_6.Text = item.Firma2;
                F3_6.Text = item.Firma3;
            }

            if (teklifler.Count > 6)
            {
                item = teklifler[6];
                stn7.Text = item.Stokno;
                t7.Text = item.Tanim;
                m7.Text = item.Miktar.ToString();
                b7.Text = item.Birim;
                F1_7.Text = item.Firma1;
                F2_7.Text = item.Firma2;
                F3_7.Text = item.Firma3;
            }

            if (teklifler.Count > 7)
            {

                item = teklifler[7];
                stn8.Text = item.Stokno;
                t8.Text = item.Tanim;
                m8.Text = item.Miktar.ToString();
                b8.Text = item.Birim;
                F1_8.Text = item.Firma1;
                F2_8.Text = item.Firma2;
                F3_8.Text = item.Firma3;
            }

            if (teklifler.Count > 8)
            {
                item = teklifler[8];
                stn9.Text = item.Stokno;
                t9.Text = item.Tanim;
                m9.Text = item.Miktar.ToString();
                b9.Text = item.Birim;
                F1_9.Text = item.Firma1;
                F2_9.Text = item.Firma2;
                F3_9.Text = item.Firma3;
            }

            if (teklifler.Count > 9)
            {
                item = teklifler[9];
                stn10.Text = item.Stokno;
                t10.Text = item.Tanim;
                m10.Text = item.Miktar.ToString();
                b10.Text = item.Birim;
                F1_10.Text = item.Firma1;
                F2_10.Text = item.Firma2;
                F3_10.Text = item.Firma3;
            }
        }
        void DataDisplay()
        {
            DtgTeklifAl.Columns["Id"].Visible = false;
            DtgTeklifAl.Columns["Satno"].HeaderText = "SAT NO";
            DtgTeklifAl.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgTeklifAl.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgTeklifAl.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgTeklifAl.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgTeklifAl.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgTeklifAl.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgTeklifAl.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgTeklifAl.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgTeklifAl.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgTeklifAl.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgTeklifAl.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgTeklifAl.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgTeklifAl.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgTeklifAl.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgTeklifAl.Columns["Uctekilf"].Visible = false;
            DtgTeklifAl.Columns["SiparisNo"].Visible = false;
            DtgTeklifAl.Columns["DosyaYolu"].Visible = false;
            DtgTeklifAl.Columns["PersonelId"].Visible = false;
            DtgTeklifAl.Columns["FirmaBilgisi"].Visible = false;
            DtgTeklifAl.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgTeklifAl.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgTeklifAl.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgTeklifAl.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgTeklifAl.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgTeklifAl.Columns["BelgeTuru"].Visible = false;
            DtgTeklifAl.Columns["BelgeNumarasi"].Visible = false;
            DtgTeklifAl.Columns["BelgeTarihi"].Visible = false;
            DtgTeklifAl.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
        }

        void IslemAdimlari()
        {
            DtgSatIslemAdimlari.DataSource = satIslemAdimlarimanager.GetList();

            DtgSatIslemAdimlari.Columns["Id"].Visible = false;
            DtgSatIslemAdimlari.Columns["Siparisno"].Visible = false;
            DtgSatIslemAdimlari.Columns["Islem"].HeaderText = "İŞLEM ADIMI";
            DtgSatIslemAdimlari.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgSatIslemAdimlari.Columns["Tarih"].HeaderText = "TARİH";
            DtgSatIslemAdimlari.Columns["Tarih"].Width = 40;
            DtgSatIslemAdimlari.Columns["Islemyapan"].Width = 120;
            DtgSatIslemAdimlari.Columns["Islem"].Width = 320;
        }
        void IslemAdimlari2()
        {
            dataGridView1.DataSource = satIslemAdimlarimanager.GetList(siparisNo);

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Siparisno"].Visible = false;
            dataGridView1.Columns["Islem"].HeaderText = "İŞLEM ADIMI";
            dataGridView1.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            dataGridView1.Columns["Tarih"].HeaderText = "TARİH";
            dataGridView1.Columns["Tarih"].Width = 40;
            dataGridView1.Columns["Islemyapan"].Width = 120;
            dataGridView1.Columns["Islem"].Width = 320;
        }
        void MalzemelistDüzenle()
        {
            DtgTeklifMalzemeList.Columns["Id"].Visible = false;
            DtgTeklifMalzemeList.Columns["Siparisno"].Visible = false;
            DtgTeklifMalzemeList.Columns["Stokno"].HeaderText = "STOK NO";
            DtgTeklifMalzemeList.Columns["Tanim"].HeaderText = "TANIM";
            DtgTeklifMalzemeList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgTeklifMalzemeList.Columns["Firma1"].HeaderText = "BİRİNCİ FİRMA";
            DtgTeklifMalzemeList.Columns["Firma2"].HeaderText = "İKİNCİ FİRMA";
            DtgTeklifMalzemeList.Columns["Firma3"].HeaderText = "ÜÇÜNCÜ FİRMA";
            DtgTeklifMalzemeList.Columns["Birim"].HeaderText = "BİRİM";
            //DtgTeklifMalzemeList.Columns[""].HeaderText = "BİRİM";
            DtgTeklifMalzemeList.Columns["Teklifdurumu"].Visible = false;
            DtgTeklifMalzemeList.Columns["Bbf"].Visible = false;
            DtgTeklifMalzemeList.Columns["Btf"].Visible = false;
            DtgTeklifMalzemeList.Columns["Ibf"].Visible = false;
            DtgTeklifMalzemeList.Columns["Itf"].Visible = false;
            DtgTeklifMalzemeList.Columns["Ubf"].Visible = false;
            DtgTeklifMalzemeList.Columns["Utf"].Visible = false;
            DtgTeklifMalzemeList.Columns["Onaylananteklif"].Visible = false;
        }

        private void Temizle()
        {
            s1.Clear(); tt1.Clear(); mm1.Clear(); bb1.Clear(); s2.Clear(); tt2.Clear(); mm2.Clear(); bb2.Clear();
            s3.Clear(); tt3.Clear(); mm3.Clear(); bb3.Clear(); s4.Clear(); tt4.Clear(); mm4.Clear(); bb4.Clear();
            s5.Clear(); tt5.Clear(); mm5.Clear(); bb5.Clear(); s6.Clear(); tt6.Clear(); mm6.Clear(); bb6.Clear();
            s7.Clear(); tt7.Clear(); mm7.Clear(); bb7.Clear(); s8.Clear(); tt8.Clear(); mm8.Clear(); bb8.Clear();
            s9.Clear(); tt9.Clear(); mm9.Clear(); bb9.Clear(); s10.Clear(); tt10.Clear(); mm10.Clear(); bb10.Clear();
        }
        private void TekilfleriTemizle()
        {
            stn1.Clear(); t1.Clear(); m1.Clear(); b1.Clear(); stn2.Clear(); t2.Clear(); m2.Clear(); b2.Clear();
            stn3.Clear(); t3.Clear(); m3.Clear(); b3.Clear(); stn4.Clear(); t4.Clear(); m4.Clear(); b4.Clear();
            stn5.Clear(); t5.Clear(); m5.Clear(); b5.Clear(); stn6.Clear(); t6.Clear(); m6.Clear(); b6.Clear();
            stn7.Clear(); t7.Clear(); m7.Clear(); b7.Clear(); stn8.Clear(); t8.Clear(); m8.Clear(); b8.Clear();
            stn9.Clear(); t9.Clear(); m9.Clear(); b9.Clear(); stn10.Clear(); t10.Clear(); m10.Clear(); b10.Clear();

            F1_1.Clear(); F1_2.Clear(); F1_3.Clear(); F1_4.Clear(); F1_5.Clear(); F1_6.Clear(); F1_7.Clear(); F1_8.Clear(); F1_9.Clear(); F1_10.Clear();
            F2_1.Clear(); F2_2.Clear(); F2_3.Clear(); F2_4.Clear(); F2_5.Clear(); F2_6.Clear(); F2_7.Clear(); F2_8.Clear(); F2_9.Clear(); F2_10.Clear();
            F3_1.Clear(); F3_2.Clear(); F3_3.Clear(); F3_4.Clear(); F3_5.Clear(); F3_6.Clear(); F3_7.Clear(); F3_8.Clear(); F3_9.Clear(); F3_10.Clear();

            BBF1.Clear(); BBF2.Clear(); BBF3.Clear(); BBF4.Clear(); BBF5.Clear(); BBF6.Clear(); BBF7.Clear(); BBF8.Clear(); BBF9.Clear(); BBF10.Clear();
            IBF1.Clear(); IBF2.Clear(); IBF3.Clear(); IBF4.Clear(); IBF5.Clear(); IBF6.Clear(); IBF7.Clear(); IBF8.Clear(); IBF9.Clear(); IBF10.Clear();
            UBF1.Clear(); UBF2.Clear(); UBF3.Clear(); UBF4.Clear(); UBF5.Clear(); UBF6.Clear(); UBF7.Clear(); UBF8.Clear(); UBF9.Clear(); UBF10.Clear();

            BT1.Clear(); BT2.Clear(); BT3.Clear(); BT4.Clear(); BT5.Clear(); BT6.Clear(); BT7.Clear(); BT8.Clear(); BT9.Clear(); BT10.Clear();
            IT1.Clear(); IT2.Clear(); IT3.Clear(); IT4.Clear(); IT5.Clear(); IT6.Clear(); IT7.Clear(); IT8.Clear(); IT9.Clear(); IT10.Clear();
            UT1.Clear(); UT2.Clear(); UT3.Clear(); UT4.Clear(); UT5.Clear(); UT6.Clear(); UT7.Clear(); UT8.Clear(); UT9.Clear(); UT10.Clear();

        }
        private void FillTools()
        {
            Temizle();

            if (satinAlinacakMalzemelers == null)

            {
                return;
            }

            if (satinAlinacakMalzemelers.Count == 0)
            {
                return;
            }

            if (satinAlinacakMalzemelers.Count > 0)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[0];
                s1.Text = item.Stn1;
                tt1.Text = item.T1;
                mm1.Text = item.M1.ToString();
                bb1.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 1)
            {
                SatinAlinacakMalzemeler item3 = satinAlinacakMalzemelers[1];
                s2.Text = item3.Stn1;
                tt2.Text = item3.T1;
                mm2.Text = item3.M1.ToString();
                bb2.Text = item3.B1;
            }

            if (satinAlinacakMalzemelers.Count > 2)
            {
                SatinAlinacakMalzemeler item3 = satinAlinacakMalzemelers[2];
                s3.Text = item3.Stn1;
                tt3.Text = item3.T1;
                mm3.Text = item3.M1.ToString();
                bb3.Text = item3.B1;
            }

            if (satinAlinacakMalzemelers.Count > 3)
            {
                SatinAlinacakMalzemeler item4 = satinAlinacakMalzemelers[3];
                s4.Text = item4.Stn1;
                tt4.Text = item4.T1;
                mm4.Text = item4.M1.ToString();
                bb4.Text = item4.B1;
            }

            if (satinAlinacakMalzemelers.Count > 4)
            {
                SatinAlinacakMalzemeler item5 = satinAlinacakMalzemelers[4];
                s5.Text = item5.Stn1;
                tt5.Text = item5.T1;
                mm5.Text = item5.M1.ToString();
                bb5.Text = item5.B1;
            }

            if (satinAlinacakMalzemelers.Count > 5)
            {


                SatinAlinacakMalzemeler item6 = satinAlinacakMalzemelers[5];
                s6.Text = item6.Stn1;
                tt6.Text = item6.T1;
                mm6.Text = item6.M1.ToString();
                bb6.Text = item6.B1;
            }

            if (satinAlinacakMalzemelers.Count > 6)
            {
                SatinAlinacakMalzemeler item7 = satinAlinacakMalzemelers[6];
                s7.Text = item7.Stn1;
                tt7.Text = item7.T1;
                mm7.Text = item7.M1.ToString();
                bb7.Text = item7.B1;
            }

            if (satinAlinacakMalzemelers.Count > 7)
            {

                SatinAlinacakMalzemeler item8 = satinAlinacakMalzemelers[7];
                s8.Text = item8.Stn1;
                tt8.Text = item8.T1;
                mm8.Text = item8.M1.ToString();
                bb8.Text = item8.B1;
            }

            if (satinAlinacakMalzemelers.Count > 8)
            {
                SatinAlinacakMalzemeler item9 = satinAlinacakMalzemelers[8];
                s9.Text = item9.Stn1;
                tt9.Text = item9.T1;
                mm9.Text = item9.M1.ToString();
                bb9.Text = item9.B1;
            }

            if (satinAlinacakMalzemelers.Count > 9)
            {
                SatinAlinacakMalzemeler item10 = satinAlinacakMalzemelers[9];
                s10.Text = item10.Stn1;
                tt10.Text = item10.T1;
                mm10.Text = item10.M1.ToString();
                bb10.Text = item10.B1;
            }

            WebBrowser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageTeklifAlinacak"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        void SendMailToSupplier(string supplierName, List<string> receivers)
        {
            if (cmbFirmaText == "HEPSİ")
            {
                string control = mailedSuppliers.FirstOrDefault(x => x == supplierName);
                if (!string.IsNullOrEmpty(control))
                {
                    return;
                }
                /* foreach (string item in mailedSuppliers)
                 {
                     if (item == supplierName)
                     {
                         return;
                     }
                 }*/
                mailedSuppliers.Add(supplierName);
                filteredList = teklifiAls.Where(x => x.Firma1.ToLower().Contains(supplierName.ToLower()) || x.Firma2.ToLower().Contains(supplierName.ToLower()) || x.Firma3.ToLower().Contains(supplierName.ToLower())).ToList();
                DtgTeklifMalzemeList.Invoke((MethodInvoker)(() => binderGetRequest.DataSource = filteredList));
                TxtFiyatTeklifi.Invoke((MethodInvoker)(() => TxtFiyatTeklifi.Text = DtgTeklifMalzemeList.RowCount.ToString()));
            }

            List<string> idler = new List<string>();
            string ids = "";

            foreach (var item in filteredList)
            {
                string id = item.Id.ToString();
                idler.Add(id);
                ids = string.Join(";", idler);
            }
            string durum = "BEKLIYOR";
            string fileName = supplierName;

            if (string.IsNullOrEmpty(directoryPath))
            {
                directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "Satın Alma Excel Çıktısı\\" + DateTime.Today.ToShortDateString();
            }

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = directoryPath + "\\" + fileName + " " + DateTime.Now.ToString("ddMMyyyy-HHmmss") + ".xlsx";


            var list = FrmHelper.GetRequestList(DtgTeklifMalzemeList, supplierName).Select(x => new
            {
                Tanim = x.Tanim,
                Miktar = x.Miktar,
                Birim = x.Birim,
                Birim_Fiyat = ""

            }).ToList();

            ExportDataGrid.Invoke((MethodInvoker)(() => ExportDataGrid.DataSource = list));

            FrmHelper.ExportTable(ExportDataGrid, fileName, filePath);

            SatRenkliTablo renkliTablo = new SatRenkliTablo(supplierName, DateTime.Now, ids, durum, filePath);

            satRenkliTabloManager.Add(renkliTablo);

            if (cmbFirmaText == "HEPSİ")
            {
                MailSend(supplierName + " Fiyat Teklifleri", "Merhaba Sayın Yetkili,\n\nEk Dosyada Bulunan Siparişimiz İçin Fiyat Tekliflerinizi Rica Ediyorum \n\nİyi Çalışmalar.", receivers, new List<string>() { filePath });
            }
            else
            {
                Task.Factory.StartNew(() => MailSend(supplierName + " Fiyat Teklifleri", "Merhaba Sayın Yetkili,\n\nEk Dosyada Bulunan Siparişimiz İçin Fiyat Tekliflerinizi Rica Ediyorum \n\nİyi Çalışmalar.", receivers, new List<string>() { filePath }));
            }
        }
        static string cmbFirmaText;
        private async void button3_Click(object sender, EventArgs e)//BTNEXPORT and Send Mail
        {

            if (string.IsNullOrEmpty(CmbFirmalar.Text))
            {
                MessageBox.Show("Firma Bilgisi Seçiniz");
                return;
            }
            if (DtgTeklifMalzemeList.RowCount == 0)
            {
                MessageBox.Show("Öge Bulunmuyor");
                return;
            }
            suppliers = tedarikciManager.SuppliersNameMail();

            DialogResult dr = MessageBox.Show("Tablo Çıkartılsın Mı?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                yapilanislem = "FİRMALARA MAİL GÖNDERİLDİ.";

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, islemyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);

                refreshTeklifAlMalzemeList = true;
                string firmaAdi = CmbFirmalar.Text;
                cmbFirmaText = CmbFirmalar.Text;

                if (firmaAdi == "HEPSİ")
                {
                    lblState.Visible = true;
                    lblCount.Visible = true;
                    lblCount.Text = "";
                    lblProcess.Visible = true;
                    CmbFirmalar.Enabled = false;
                    BtnTumFirma.Enabled = false;
                    BtnExport.Enabled = false;
                    BtnCancel.Enabled = false;
                    DtgTeklifMalzemeList.Enabled = false;
                    Task task = new Task(SendMailAllSuppliers);
                    //Task task2 = new Task(()=>SendMailAllSuppliers("parametre"));
                    task.Start();
                    await task;
                    lblState.Text = "";
                    lblCount.Visible = false;
                    lblProcess.Visible = false;
                    CmbFirmalar.Enabled = true;
                    BtnTumFirma.Enabled = true;
                    BtnExport.Enabled = true;
                    BtnCancel.Enabled = true;
                    DtgTeklifMalzemeList.Enabled = true;
                    mailedSuppliers.Clear();
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    firmaAdi = firmaAdi.ToLower();
                    filteredList = teklifiAls.Where(x => x.Firma1.ToLower().Contains(firmaAdi) || x.Firma2.ToLower().Contains(firmaAdi) || x.Firma3.ToLower().Contains(firmaAdi)).ToList();

                    binderGetRequest.DataSource = filteredList;
                    string firmaMail = suppliers.Where(x => x.Firmaadi.ToLower().Contains(firmaAdi)).Select(x => x.Mail).FirstOrDefault();
                    if (!string.IsNullOrEmpty(firmaMail))
                    {
                        SendMailToSupplier(CmbFirmalar.Text, new List<string>() { firmaMail });
                    }
                }

                //siparisNo = Guid.NewGuid().ToString();


                TeklifAlMalzemeList();
                TxtFiyatTeklifi.Text = DtgTeklifMalzemeList.RowCount.ToString();
                SatListLoad();
            }
        }
        void SendMailAllSuppliers()
        {
            TedarikciFirma tedarikci = null;
            List<SatRenkliTablo> tumRenkler = null;
            int mailCount = 0;
            foreach (FiyatTeklifiAl item in teklifiAls)
            {
                tumRenkler = SatRenkliiTabloManager.GetInstance().GetList("", "BEKLIYOR");

                tedarikci = suppliers.Where(x => x.Firmaadi.ToLower().Contains(item.Firma1.ToString().ToLower())).FirstOrDefault();
                if (FrmHelper.CanSendMailByList(item, tumRenkler, tedarikci.Firmaadi))
                {
                    lblState.Invoke((MethodInvoker)(() => lblState.Text = tedarikci.Firmaadi + " Firmasına Mail Gönderiliyor"));
                    SendMailToSupplier(tedarikci.Firmaadi, new List<string>() { tedarikci.Mail });
                    lblCount.Invoke((MethodInvoker)(() => lblCount.Text = ++mailCount + " Adet Firmaya Mail Gönderildi"));
                }

                tedarikci = suppliers.Where(x => x.Firmaadi.ToLower().Contains(item.Firma2.ToString().ToLower())).FirstOrDefault();
                if (FrmHelper.CanSendMailByList(item, tumRenkler, tedarikci.Firmaadi))
                {
                    lblState.Invoke((MethodInvoker)(() => lblState.Text = tedarikci.Firmaadi + " Firmasına Mail Gönderiliyor"));
                    SendMailToSupplier(tedarikci.Firmaadi, new List<string>() { tedarikci.Mail });
                    lblCount.Invoke((MethodInvoker)(() => lblCount.Text = ++mailCount + " Adet Firmaya Mail Gönderildi"));
                }

                tedarikci = suppliers.Where(x => x.Firmaadi.ToLower().Contains(item.Firma3.ToString().ToLower())).FirstOrDefault();
                if (FrmHelper.CanSendMailByList(item, tumRenkler, tedarikci.Firmaadi))
                {
                    lblState.Invoke((MethodInvoker)(() => lblState.Text = tedarikci.Firmaadi + " Firmasına Mail Gönderiliyor"));
                    SendMailToSupplier(tedarikci.Firmaadi, new List<string>() { tedarikci.Mail });
                    lblCount.Invoke((MethodInvoker)(() => lblCount.Text = ++mailCount + " Adet Firmaya Mail Gönderildi"));
                }
            }
            mailCount = 0;
        }

        private void DtgTeklifMalzemeList_FilterStringChanged_1(object sender, EventArgs e)
        {
            binderGetRequest.Filter = DtgTeklifMalzemeList.FilterString;
            TxtFiyatTeklifi.Text = DtgTeklifMalzemeList.RowCount.ToString();
        }

        private void DtgTeklifMalzemeList_SortStringChanged_1(object sender, EventArgs e)
        {
            binderGetRequest.Sort = DtgTeklifMalzemeList.SortString;
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillInfos();
            SatDataGrid1();
            CmbFirmalarLoad();
            TeklifAlMalzemeList();
            DataDisplay();
            SatListLoad();
            MailGonderilecekler();
            MailGonderilenler();
            DtgMalzemeFirma.DataSource = null;
            DtgMalzemelerMail.DataSource = null;
            webBrowser4.Navigate("");
            TxtTop.Text = DtgTeklifAl.RowCount.ToString();
            TxtFiyatTeklifi.Text = DtgTeklifMalzemeList.RowCount.ToString();
            TxtTeklİfSatSayisi.Text = DtgSatList.RowCount.ToString();
        }
        List<FiyatTeklifiAl> filteredList;
        private void CmbFirmalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            firmaAdi = CmbFirmalar.Text.ToLower();
            if (firmaAdi == "hepsi")
            {
                firmaAdi = "";
            }
            filteredList = teklifiAls.Where(x => x.Firma1.ToLower().Contains(firmaAdi) || x.Firma2.ToLower().Contains(firmaAdi) || x.Firma3.ToLower().Contains(firmaAdi)).ToList();
            binderGetRequest.DataSource = filteredList;
            TxtFiyatTeklifi.Text = DtgTeklifMalzemeList.RowCount.ToString();
            firmaAdi = CmbFirmalar.Text;
            Renklendir();
            //filteredList
            return;
        }

        private void BBF1_TextChanged(object sender, EventArgs e)
        {
            BT1.Text = TopFiyatHesapla(BBF1.Text, m1.Text);
        }

        private void BBF2_TextChanged(object sender, EventArgs e)
        {
            BT2.Text = TopFiyatHesapla(BBF2.Text, m2.Text);
        }

        private void BBF3_TextChanged(object sender, EventArgs e)
        {
            BT3.Text = TopFiyatHesapla(BBF3.Text, m3.Text);
        }

        private void BBF4_TextChanged(object sender, EventArgs e)
        {
            BT4.Text = TopFiyatHesapla(BBF4.Text, m4.Text);
        }

        private void BBF5_TextChanged(object sender, EventArgs e)
        {
            BT5.Text = TopFiyatHesapla(BBF5.Text, m5.Text);
        }

        private void BBF6_TextChanged(object sender, EventArgs e)
        {
            BT6.Text = TopFiyatHesapla(BBF6.Text, m6.Text);
        }

        private void BBF7_TextChanged(object sender, EventArgs e)
        {
            BT7.Text = TopFiyatHesapla(BBF7.Text, m7.Text);
        }

        private void BBF8_TextChanged(object sender, EventArgs e)
        {
            BT8.Text = TopFiyatHesapla(BBF8.Text, m8.Text);
        }

        private void BBF9_TextChanged(object sender, EventArgs e)
        {
            BT9.Text = TopFiyatHesapla(BBF9.Text, m9.Text);
        }

        private void BBF10_TextChanged(object sender, EventArgs e)
        {
            BT10.Text = TopFiyatHesapla(BBF10.Text, m10.Text);
        }


        private void IBF1_TextChanged(object sender, EventArgs e)
        {
            IT1.Text = TopFiyatHesapla(IBF1.Text, m1.Text);
        }

        private void IBF2_TextChanged(object sender, EventArgs e)
        {
            IT2.Text = TopFiyatHesapla(IBF2.Text, m2.Text);
        }

        private void IBF3_TextChanged(object sender, EventArgs e)
        {
            IT3.Text = TopFiyatHesapla(IBF3.Text, m3.Text);
        }

        private void IBF4_TextChanged(object sender, EventArgs e)
        {
            IT4.Text = TopFiyatHesapla(IBF4.Text, m4.Text);
        }

        private void IBF5_TextChanged(object sender, EventArgs e)
        {
            IT5.Text = TopFiyatHesapla(IBF5.Text, m5.Text);
        }

        private void IBF6_TextChanged(object sender, EventArgs e)
        {
            IT6.Text = TopFiyatHesapla(IBF6.Text, m6.Text);
        }

        private void IBF7_TextChanged(object sender, EventArgs e)
        {
            IT7.Text = TopFiyatHesapla(IBF7.Text, m7.Text);
        }

        private void IBF8_TextChanged(object sender, EventArgs e)
        {
            IT8.Text = TopFiyatHesapla(IBF8.Text, m8.Text);
        }

        private void IBF9_TextChanged(object sender, EventArgs e)
        {
            IT9.Text = TopFiyatHesapla(IBF9.Text, m9.Text);
        }

        private void IBF10_TextChanged(object sender, EventArgs e)
        {
            IT10.Text = TopFiyatHesapla(IBF10.Text, m10.Text);
        }

        private void UBF1_TextChanged(object sender, EventArgs e)
        {
            UT1.Text = TopFiyatHesapla(UBF1.Text, m1.Text);
        }

        private void UBF2_TextChanged(object sender, EventArgs e)
        {
            UT2.Text = TopFiyatHesapla(UBF2.Text, m2.Text);
        }

        private void UBF3_TextChanged(object sender, EventArgs e)
        {
            UT3.Text = TopFiyatHesapla(UBF3.Text, m3.Text);
        }

        private void UBF4_TextChanged(object sender, EventArgs e)
        {
            UT4.Text = TopFiyatHesapla(UBF4.Text, m4.Text);
        }

        private void UBF5_TextChanged(object sender, EventArgs e)
        {
            UT5.Text = TopFiyatHesapla(UBF5.Text, m5.Text);
        }

        private void UBF6_TextChanged(object sender, EventArgs e)
        {
            UT6.Text = TopFiyatHesapla(UBF6.Text, m6.Text);
        }

        private void UBF7_TextChanged(object sender, EventArgs e)
        {
            UT7.Text = TopFiyatHesapla(UBF7.Text, m7.Text);
        }

        private void UBF8_TextChanged(object sender, EventArgs e)
        {
            UT8.Text = TopFiyatHesapla(UBF8.Text, m8.Text);
        }

        private void UBF9_TextChanged(object sender, EventArgs e)
        {
            UT9.Text = TopFiyatHesapla(UBF9.Text, m9.Text);
        }

        private void UBF10_TextChanged(object sender, EventArgs e)
        {
            UT10.Text = TopFiyatHesapla(UBF10.Text, m10.Text);
        }

        private void BBF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void BBF10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void IBF10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void UBF10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }



        private void IT1_TextChanged(object sender, EventArgs e)
        {
            if (IT1.Text == "")
            {
                y1 = 0;
                GenelToplam2();
                return;
            }
            y1 = IT1.Text.ConDouble();
            GenelToplam2();
        }

        private void IT2_TextChanged(object sender, EventArgs e)
        {
            if (IT2.Text == "")
            {
                y2 = 0;
                GenelToplam2();
                return;
            }
            y2 = IT2.Text.ConDouble();
            GenelToplam2();
        }

        private void IT3_TextChanged(object sender, EventArgs e)
        {
            if (IT3.Text == "")
            {
                y3 = 0;
                GenelToplam2();
                return;
            }
            y3 = IT3.Text.ConDouble();
            GenelToplam2();
        }

        private void IT4_TextChanged(object sender, EventArgs e)
        {
            if (IT4.Text == "")
            {
                y4 = 0;
                GenelToplam2();
                return;
            }
            y4 = IT4.Text.ConDouble();
            GenelToplam2();
        }

        private void IT5_TextChanged(object sender, EventArgs e)
        {
            if (IT5.Text == "")
            {
                y5 = 0;
                GenelToplam2();
                return;
            }
            y5 = IT5.Text.ConDouble();
            GenelToplam2();
        }

        private void IT6_TextChanged(object sender, EventArgs e)
        {
            if (IT6.Text == "")
            {
                y6 = 0;
                GenelToplam2();
                return;
            }
            y6 = IT6.Text.ConDouble();
            GenelToplam2();
        }

        private void IT7_TextChanged(object sender, EventArgs e)
        {
            if (IT7.Text == "")
            {
                y7 = 0;
                GenelToplam2();
                return;
            }
            y7 = IT7.Text.ConDouble();
            GenelToplam2();
        }

        private void IT8_TextChanged(object sender, EventArgs e)
        {
            if (IT8.Text == "")
            {
                y8 = 0;
                GenelToplam2();
                return;
            }
            y8 = IT8.Text.ConDouble();
            GenelToplam2();
        }

        private void IT9_TextChanged(object sender, EventArgs e)
        {
            if (IT9.Text == "")
            {
                y9 = 0;
                GenelToplam2();
                return;
            }
            y9 = IT9.Text.ConDouble();
            GenelToplam2();
        }

        private void IT10_TextChanged(object sender, EventArgs e)
        {
            if (IT10.Text == "")
            {
                y10 = 0;
                GenelToplam2();
                return;
            }
            y10 = IT10.Text.ConDouble();
            GenelToplam2();
        }

        private void UT1_TextChanged(object sender, EventArgs e)
        {
            if (UT1.Text == "")
            {
                z1 = 0;
                GenelToplam3();
                return;
            }
            z1 = UT1.Text.ConDouble();
            GenelToplam3();
        }

        private void IT5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT2_TextChanged(object sender, EventArgs e)
        {
            if (UT2.Text == "")
            {
                z2 = 0;
                GenelToplam3();
                return;
            }
            z2 = UT2.Text.ConDouble();
            GenelToplam3();
        }

        private void UT3_TextChanged(object sender, EventArgs e)
        {
            if (UT3.Text == "")
            {
                z3 = 0;
                GenelToplam3();
                return;
            }
            z3 = UT3.Text.ConDouble();
            GenelToplam3();
        }

        private void UT4_TextChanged(object sender, EventArgs e)
        {
            if (UT4.Text == "")
            {
                z4 = 0;
                GenelToplam3();
                return;
            }
            z4 = UT4.Text.ConDouble();
            GenelToplam3();
        }

        private void UT5_TextChanged(object sender, EventArgs e)
        {
            if (UT5.Text == "")
            {
                z5 = 0;
                GenelToplam3();
                return;
            }
            z5 = UT5.Text.ConDouble();
            GenelToplam3();
        }

        private void UT6_TextChanged(object sender, EventArgs e)
        {
            if (UT6.Text == "")
            {
                z6 = 0;
                GenelToplam3();
                return;
            }
            z6 = UT6.Text.ConDouble();
            GenelToplam3();
        }

        private void UT7_TextChanged(object sender, EventArgs e)
        {
            if (UT7.Text == "")
            {
                z7 = 0;
                GenelToplam3();
                return;
            }
            z7 = UT7.Text.ConDouble();
            GenelToplam3();
        }

        private void UT8_TextChanged(object sender, EventArgs e)
        {
            if (UT8.Text == "")
            {
                z8 = 0;
                GenelToplam3();
                return;
            }
            z8 = UT8.Text.ConDouble();
            GenelToplam3();
        }

        private void UT9_TextChanged(object sender, EventArgs e)
        {
            if (UT9.Text == "")
            {
                z9 = 0;
                GenelToplam3();
                return;
            }
            z9 = UT9.Text.ConDouble();
            GenelToplam3();
        }

        private void UT10_TextChanged(object sender, EventArgs e)
        {
            if (UT10.Text == "")
            {
                z10 = 0;
                GenelToplam3();
                return;
            }
            z10 = UT10.Text.ConDouble();
            GenelToplam3();
        }

        private void IT6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void UT10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT1_TextChanged(object sender, EventArgs e)
        {
            if (BT1.Text == "")
            {
                x1 = 0;
                GenelToplam1();
                return;
            }
            x1 = BT1.Text.ConDouble();
            GenelToplam1();
        }

        private void GT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT2_TextChanged(object sender, EventArgs e)
        {
            if (BT2.Text == "")
            {
                x2 = 0;
                GenelToplam1();
                return;
            }
            x2 = BT2.Text.ConDouble();
            GenelToplam1();
        }

        private void BT3_TextChanged(object sender, EventArgs e)
        {
            if (BT3.Text == "")
            {
                x3 = 0;
                GenelToplam1();
                return;
            }
            x3 = BT3.Text.ConDouble();
            GenelToplam1();
        }

        private void BT4_TextChanged(object sender, EventArgs e)
        {
            if (BT4.Text == "")
            {
                x4 = 0;
                GenelToplam1();
                return;
            }
            x4 = BT4.Text.ConDouble();
            GenelToplam1();
        }

        private void BT5_TextChanged(object sender, EventArgs e)
        {
            if (BT5.Text == "")
            {
                x5 = 0;
                GenelToplam1();
                return;
            }
            x5 = BT5.Text.ConDouble();
            GenelToplam1();
        }

        private void BT6_TextChanged(object sender, EventArgs e)
        {
            if (BT6.Text == "")
            {
                x6 = 0;
                GenelToplam1();
                return;
            }
            x6 = BT6.Text.ConDouble();
            GenelToplam1();
        }

        private void BT7_TextChanged(object sender, EventArgs e)
        {
            if (BT7.Text == "")
            {
                x7 = 0;
                GenelToplam1();
                return;
            }
            x7 = BT7.Text.ConDouble();
            GenelToplam1();
        }

        private void BT8_TextChanged(object sender, EventArgs e)
        {
            if (BT8.Text == "")
            {
                x8 = 0;
                GenelToplam1();
                return;
            }
            x8 = BT8.Text.ConDouble();
            GenelToplam1();
        }

        private void BT9_TextChanged(object sender, EventArgs e)
        {
            if (BT9.Text == "")
            {
                x9 = 0;
                GenelToplam1();
                return;
            }
            x9 = BT9.Text.ConDouble();
            GenelToplam1();
        }

        private void BT10_TextChanged(object sender, EventArgs e)
        {
            if (BT10.Text == "")
            {
                x10 = 0;
                GenelToplam1();
                return;
            }
            x10 = BT10.Text.ConDouble();
            GenelToplam1();
        }

        private void GT2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void GT3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        int[] cellIndexs = new int[3] { 5, 6, 7 };//Renklendirme işlemindeki hücre index numaraları
        void Renklendir()
        {
            List<SatRenkliTablo> renkler = null;
            string renkFirmaAd = "";
            if (CmbFirmalar.Text == "" || CmbFirmalar.Text == "HEPSİ")
            {
                renkFirmaAd = "";
            }
            else
            {
                renkFirmaAd = CmbFirmalar.Text;
            }
            string durum = "BEKLIYOR";
            renkler = satRenkliTabloManager.GetList(renkFirmaAd, durum);
            foreach (SatRenkliTablo tabloItem in renkler)
            {
                idler = tabloItem.Siparisid;
                companyName = tabloItem.Firmaadi;
                if (idler != null)
                {
                    string[] array = idler.Split(';');
                    foreach (string item in array)
                    {
                        foreach (DataGridViewRow row in DtgTeklifMalzemeList.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == item)
                            {
                                foreach (int number in cellIndexs)
                                {
                                    if (row.Cells[number].Value.ToString() == companyName)
                                    {
                                        row.Cells[number].Style.BackColor = Color.LightGreen;
                                        row.Cells[number].Style.SelectionBackColor = Color.LightGreen;
                                        row.Cells[number].Style.SelectionForeColor = Color.Black;
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            KontrolEt();
        }

        void KontrolEt()
        {
            int id = 0;
            foreach (DataGridViewRow row in DtgTeklifMalzemeList.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells[5].Value.ToString()) && !string.IsNullOrEmpty(row.Cells[6].Value.ToString()) && !string.IsNullOrEmpty(row.Cells[7].Value.ToString()))
                {
                    if (row.Cells[5].Style.BackColor == Color.LightGreen && row.Cells[6].Style.BackColor == Color.LightGreen && row.Cells[7].Style.BackColor == Color.LightGreen)
                    {
                        refreshTeklifAlMalzemeList = true;
                        id = row.Cells[0].Value.ConInt();
                        fiyatTeklifiAlManager.DurumGuncelle(id);
                    }
                }
                else if (!string.IsNullOrEmpty(row.Cells[5].Value.ToString()) && !string.IsNullOrEmpty(row.Cells[6].Value.ToString()))
                {
                    if (row.Cells[5].Style.BackColor == Color.LightGreen && row.Cells[6].Style.BackColor == Color.LightGreen)
                    {
                        refreshTeklifAlMalzemeList = true;
                        id = row.Cells[0].Value.ConInt();
                        fiyatTeklifiAlManager.DurumGuncelle(id);
                    }
                }
                else if (!string.IsNullOrEmpty(row.Cells[5].Value.ToString()))
                {
                    if (row.Cells[5].Style.BackColor == Color.LightGreen)
                    {
                        refreshTeklifAlMalzemeList = true;
                        id = row.Cells[0].Value.ConInt();
                        fiyatTeklifiAlManager.DurumGuncelle(id);
                    }
                }
            }

            if (refreshTeklifAlMalzemeList)
            {
                refreshTeklifAlMalzemeList = false;
                TeklifAlMalzemeList();
            }
        }

        private void BtnTumFirma_Click(object sender, EventArgs e)
        {
            CmbFirmalar.SelectedValue = "";
            TeklifAlMalzemeList();
            TxtFiyatTeklifi.Text = DtgTeklifMalzemeList.RowCount.ToString();
            SatListLoad();
        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Teklifleri Kaydetmek İsitediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                FirmaControl();
                if (messege != "OK")
                {
                    MessageBox.Show(messege, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<FiyatTeklifiAl> list = new List<FiyatTeklifiAl>();
                if (s1.Text != "")
                {
                    teklifiAl = new FiyatTeklifiAl(s1.Text, tt1.Text, mm1.Text.ConInt(), bb1.Text, BF1.Text, IF1.Text, UF1.Text, siparisNo);
                    list.Add(teklifiAl);
                }
                if (s2.Text != "")
                {
                    teklifiAl = new FiyatTeklifiAl(s2.Text, tt2.Text, mm2.Text.ConInt(), bb2.Text, BF2.Text, IF2.Text, UF2.Text, siparisNo);
                    list.Add(teklifiAl);
                }
                if (s3.Text != "")
                {
                    teklifiAl = new FiyatTeklifiAl(s3.Text, tt3.Text, mm3.Text.ConInt(), bb3.Text, BF3.Text, IF3.Text, UF3.Text, siparisNo);
                    list.Add(teklifiAl);
                }
                if (s4.Text != "")
                {
                    teklifiAl = new FiyatTeklifiAl(s4.Text, tt4.Text, mm4.Text.ConInt(), bb4.Text, BF4.Text, IF4.Text, UF4.Text, siparisNo);
                    list.Add(teklifiAl);
                }
                if (s5.Text != "")
                {
                    teklifiAl = new FiyatTeklifiAl(s5.Text, tt5.Text, mm5.Text.ConInt(), bb5.Text, BF5.Text, IF5.Text, UF5.Text, siparisNo);
                    list.Add(teklifiAl);
                }
                if (s6.Text != "")
                {
                    teklifiAl = new FiyatTeklifiAl(s6.Text, tt6.Text, mm6.Text.ConInt(), bb6.Text, BF6.Text, IF6.Text, UF6.Text, siparisNo);
                    list.Add(teklifiAl);
                }
                if (s7.Text != "")
                {
                    teklifiAl = new FiyatTeklifiAl(s7.Text, tt7.Text, mm7.Text.ConInt(), bb7.Text, BF7.Text, IF7.Text, UF7.Text, siparisNo);
                    list.Add(teklifiAl);
                }
                if (s8.Text != "")
                {
                    teklifiAl = new FiyatTeklifiAl(s8.Text, tt8.Text, mm8.Text.ConInt(), bb8.Text, BF8.Text, IF8.Text, UF8.Text, siparisNo);
                    list.Add(teklifiAl);
                }
                if (s9.Text != "")
                {
                    teklifiAl = new FiyatTeklifiAl(s9.Text, tt9.Text, mm9.Text.ConInt(), bb3.Text, BF3.Text, IF3.Text, UF3.Text, siparisNo);
                    list.Add(teklifiAl);
                }
                if (s10.Text != "")
                {
                    teklifiAl = new FiyatTeklifiAl(s10.Text, tt10.Text, mm10.Text.ConInt(), bb10.Text, BF10.Text, IF10.Text, UF10.Text, siparisNo);
                    list.Add(teklifiAl);
                }

                if (list.Count == 0)
                {
                    MessageBox.Show("Lütfen Bir SAT Kaydı Seçiniz.");
                    return;
                }

                foreach (FiyatTeklifiAl item in list)
                {
                    control = fiyatTeklifiAlManager.Add(item);
                }

                if (control != "OK")
                {
                    MessageBox.Show(control);
                    return;
                }


                fiyatTeklifiAlManager.UpdateTekifDurum(siparisNo);
                satDataGridview1Manager.SatFirmaBilgisiGuncelle(siparisNo);

                MessageBox.Show("Bilgileri Başarıyla Kaydedildi.");

                islem = "SAT İÇİN ÜÇ FİRMA BELİRLENDİ.";
                islemyapan = infos[1].ToString();
                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, islem, islemyapan, DateTime.Now);
                satIslemAdimlarimanager.Add(satIslem);

                TeklifAlMalzemeList();
                TxtFiyatTeklifi.Text = DtgTeklifMalzemeList.RowCount.ToString();
                Task.Factory.StartNew(() => MailSendMetotFirmalar());
                Temizle();
                SatDataGrid1();
                malzemesayisi = 0;
                TedarikciFirmaName();
                TxtTop.Text = DtgTeklifAl.RowCount.ToString();
            }
        }


        private void DtgTeklifAl_FilterStringChanged(object sender, EventArgs e)
        {
            binderSetRequest.Filter = DtgTeklifAl.FilterString;
            string name = FrmHelper.GetFilteredStringValue(DtgTeklifAl.FilterString);

        }

        private void DtgTeklifAl_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            IslemAdimlari();
            if (DtgTeklifAl.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosya = DtgTeklifAl.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgTeklifAl.CurrentRow.Cells["SiparisNo"].Value.ToString();
            satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
            malzemesayisi = satinAlinacakMalzemelers.Count; // DAHA SONRA KULLANICAKSIN MALZEME SAYISINA GÖRE FİRMA ADETLERİNİ GÖSTER
            satNos = satNoManager.GetList(siparisNo);

            /*object[] infos2 = satNoManager.Deneme(siparisNo);
            kaynakdosya = infos2[0].ToString();*/

            DtgSatIslemAdimlari.DataSource = satIslemAdimlarimanager.GetList(siparisNo);

            masrafyerino = DtgTeklifAl.CurrentRow.Cells["Masrafyeri"].Value.ToString();
            formNo = DtgTeklifAl.CurrentRow.Cells["Satno"].Value.ToString();

            FillTools();
            TedarikciFirmaName();
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
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }
        public void MailSendHtml(string subject, string body, List<string> receivers, List<string> attachments = null)
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
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }
        void MailSendMetot()
        {
            MailSend("SAT Teklif İşlemi ", "Merhaba; \n\n" + formNo + " Numaralı SAT kaydına, " + islemyapan +
                " tarafından teklif alınmıştır. Sat Onay Aşamasında beklemektedir" + "\n\nİyi Çalışmalar.", new List<string>() { "resulgunes@mubvan.net" });
        }
        void MailSendMetotFirmalar()
        {
            MailSend("SAT Teklif İşlemi ", "Merhaba; \n\n" + formNo + " Numaralı SAT kaydına, " + islemyapan +
                " tarafından Teklif Alınacak Firmalar Belirlenmiştir. \n\nFiyat Teklifi Alınma Aşamasında beklemektedir." + "\n\nİyi Çalışmalar.", new List<string>() { "resulgunes@mubvan.net" });
        }
        void MailSendMetotFirmaTeklif()
        {
            MailSend("SAT Teklif İşlemi ", "Merhaba; \n\n" + formNo + " Numaralı SAT kaydına, " + islemyapan +
                " tarafından İlgili Firmalara Mail Olarak İletilmiştir." + "\n\nİyi Çalışmalar.", new List<string>() { "resulgunes@mubvan.net" });
        }

        string yol, satbirim, satOlusturmaTuru, usBolgesi, gerekce;
        private void DtgSatList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgSatList.CurrentRow == null)
            {
                return;
            }
            siparisNo = DtgSatList.CurrentRow.Cells["SiparisNo"].Value.ToString();
            formNo = DtgSatList.CurrentRow.Cells["Satno"].Value.ToString();
            yol = DtgSatList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            satbirim = DtgSatList.CurrentRow.Cells["Satbirim"].Value.ToString();
            satOlusturmaTuru = DtgSatList.CurrentRow.Cells["SatOlusturmaTuru"].Value.ToString();
            usBolgesi = DtgSatList.CurrentRow.Cells["Usbolgesi"].Value.ToString();
            gerekce = DtgSatList.CurrentRow.Cells["Gerekce"].Value.ToString();
            TekilfleriTemizle();
            SatMalzemeListLoad(siparisNo);
            WebBrowser2(yol);
            IslemAdimlari2();

            BtnDosyaEkle1.BackColor = Color.Transparent;
            BtnDosyaEkle2.BackColor = Color.Transparent;
            BtnDosyaEkle3.BackColor = Color.Transparent;

            if (satbirim == "BSRN GN.MDL.SATIN ALMA")
            {
                satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
                malzemesayisi = satinAlinacakMalzemelers.Count;
                Filtools();
            }
        }
        void Filtools()
        {
            if (satinAlinacakMalzemelers == null)

            {
                return;
            }

            if (satinAlinacakMalzemelers.Count == 0)
            {
                return;
            }

            if (satinAlinacakMalzemelers.Count > 0)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[0];
                stn1.Text = item.Stn1;
                t1.Text = item.T1;
                m1.Text = item.M1.ToString();
                b1.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 1)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[1];
                stn2.Text = item.Stn1;
                t2.Text = item.T1;
                m2.Text = item.M1.ToString();
                b2.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 2)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[2];
                stn3.Text = item.Stn1;
                t3.Text = item.T1;
                m3.Text = item.M1.ToString();
                b3.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 3)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[3];
                stn4.Text = item.Stn1;
                t4.Text = item.T1;
                m4.Text = item.M1.ToString();
                b4.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 4)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[4];
                stn5.Text = item.Stn1;
                t5.Text = item.T1;
                m5.Text = item.M1.ToString();
                b5.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 5)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[5];
                stn6.Text = item.Stn1;
                t6.Text = item.T1;
                m6.Text = item.M1.ToString();
                b6.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 6)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[6];
                stn7.Text = item.Stn1;
                t7.Text = item.T1;
                m7.Text = item.M1.ToString();
                b7.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 7)
            {

                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[7];
                stn8.Text = item.Stn1;
                t8.Text = item.T1;
                m8.Text = item.M1.ToString();
                b8.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 8)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[8];
                stn9.Text = item.Stn1;
                t9.Text = item.T1;
                m9.Text = item.M1.ToString();
                b9.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 9)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[9];
                stn10.Text = item.Stn1;
                t10.Text = item.T1;
                m10.Text = item.M1.ToString();
                b10.Text = item.B1;
            }


        }
        void WebBrowser2(string yol)
        {
            try
            {
                webBrowser1.Navigate(yol);
            }
            catch (Exception)
            {
                return;
            }
            
        }

        private void DtgSatList_FilterStringChanged(object sender, EventArgs e)
        {
            binderSatWaiting.Filter = DtgSatList.FilterString;
            TxtTeklİfSatSayisi.Text = DtgSatList.RowCount.ToString();
        }

        private void DtgSatList_SortStringChanged(object sender, EventArgs e)
        {
            binderSatWaiting.Sort = DtgSatList.SortString;

        }
        string TopFiyatHesapla(string a, string b)
        {
            double x, y = 0;

            if (a == "" || b == "")
            {
                sonuc = 0;
                topfiyat = sonuc.ToString("0.00");
                return topfiyat;
            }
            x = double.TryParse(a, out outValue) ? Convert.ToDouble(a) : 0;
            y = double.TryParse(b, out outValue) ? Convert.ToDouble(b) : 0;
            sonuc = x * y;
            topfiyat = sonuc.ToString("0.00");
            return topfiyat;
        }
        double geneltop1 = 0;
        double geneltop2 = 0;
        double geneltop3 = 0;
        void GenelToplam1()
        {
            geneltop1 = x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 + x10;

            GT1.Text = geneltop1.ToString("0.00") + " ₺";
        }
        void GenelToplam2()
        {
            geneltop2 = y1 + y2 + y3 + y4 + y5 + y6 + y7 + y8 + y9 + y10;

            GT2.Text = geneltop2.ToString("0.00") + " ₺";
        }
        void GenelToplam3()
        {
            geneltop3 = z1 + z2 + z3 + z4 + z5 + z6 + z7 + z8 + z9 + z10;

            GT3.Text = geneltop3.ToString("0.00") + " ₺";
        }
        #region KeyPress
        private void s1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void s10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tt10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mm10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F2_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F2_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F2_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F2_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F2_5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F2_6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F2_7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F2_8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F2_9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F2_10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F3_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F3_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F3_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F3_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F3_5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F3_6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F3_7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F3_8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F3_9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void F3_10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void bb9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void DtgMailList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgMailList.CurrentRow == null)
            {
                return;
            }
            siparisNo = DtgMailList.CurrentRow.Cells["SiparisNo"].Value.ToString();
            tekliflerMail = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
            DtgMalzemeFirma.DataSource = tekliflerMail;
            MalzemeTablosuDuzenle();

            //SatMalzemeListLoadMail(siparisNo);
        }
        void MalzemeTablosuDuzenle()
        {
            DtgMalzemeFirma.Columns["Id"].Visible = false;
            DtgMalzemeFirma.Columns["Stokno"].HeaderText = "STOK NO";
            DtgMalzemeFirma.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeFirma.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzemeFirma.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzemeFirma.Columns["Firma1"].HeaderText = "1. FİRMA";
            DtgMalzemeFirma.Columns["Firma2"].HeaderText = "2. FİRMA";
            DtgMalzemeFirma.Columns["Firma3"].HeaderText = "3. FİRMA";
            DtgMalzemeFirma.Columns["Siparisno"].Visible = false;
            DtgMalzemeFirma.Columns["Teklifdurumu"].Visible = false;
            DtgMalzemeFirma.Columns["Bbf"].HeaderText = "1. FİRMA BİRİM FİYATI";
            DtgMalzemeFirma.Columns["Btf"].HeaderText = "1. FİRMA TOPLAM FİYAT";
            DtgMalzemeFirma.Columns["Ibf"].HeaderText = "2. FİRMA BİRİM FİYATI";
            DtgMalzemeFirma.Columns["Itf"].HeaderText = "2. FİRMA TOPLAM FİYAT";
            DtgMalzemeFirma.Columns["Ubf"].HeaderText = "3. FİRMA BİRİM FİYATI";
            DtgMalzemeFirma.Columns["Utf"].HeaderText = "3. FİRMA TOPLAM FİYAT";
            DtgMalzemeFirma.Columns["Onaylananteklif"].Visible = false;
            TxtMalzemeSayisi.Text = DtgMalzemeFirma.RowCount.ToString();
        }
        void MalzemeTablosuDuzenleMail()
        {
            DtgMalzemelerMail.Columns["Id"].Visible = false;
            DtgMalzemelerMail.Columns["Stokno"].HeaderText = "STOK NO";
            DtgMalzemelerMail.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemelerMail.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzemelerMail.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzemelerMail.Columns["Firma1"].HeaderText = "1. FİRMA";
            DtgMalzemelerMail.Columns["Firma2"].HeaderText = "2. FİRMA";
            DtgMalzemelerMail.Columns["Firma3"].HeaderText = "3. FİRMA";
            DtgMalzemelerMail.Columns["Siparisno"].Visible = false;
            DtgMalzemelerMail.Columns["Teklifdurumu"].Visible = false;
            DtgMalzemelerMail.Columns["Bbf"].HeaderText = "1. FİRMA BİRİM FİYATI";
            DtgMalzemelerMail.Columns["Btf"].HeaderText = "1. FİRMA TOPLAM FİYAT";
            DtgMalzemelerMail.Columns["Ibf"].HeaderText = "2. FİRMA BİRİM FİYATI";
            DtgMalzemelerMail.Columns["Itf"].HeaderText = "2. FİRMA TOPLAM FİYAT";
            DtgMalzemelerMail.Columns["Ubf"].HeaderText = "3. FİRMA BİRİM FİYATI";
            DtgMalzemelerMail.Columns["Utf"].HeaderText = "3. FİRMA TOPLAM FİYAT";
            DtgMalzemelerMail.Columns["Onaylananteklif"].Visible = false;
            TxtMal.Text = DtgMalzemelerMail.RowCount.ToString();
        }

        private void BtnMailOlustur_Click(object sender, EventArgs e)
        {
            FrmMail frmMail = new FrmMail();           
            frmMail.ShowDialog();
        }

        private void DtgGelenMail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgGelenMail.CurrentRow == null)
            {
                return;
            }
            siparisNo = DtgGelenMail.CurrentRow.Cells["SiparisNo"].Value.ToString();
            yol = DtgGelenMail.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            try
            {
                webBrowser4.Navigate(yol);
            }
            catch (Exception)
            {
                return;
            }

            tekliflerMailGonderilenler = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
            DtgMalzemelerMail.DataSource = tekliflerMailGonderilenler;
            MalzemeTablosuDuzenleMail();
        }
        string kaynakdosyaismi, alinandosya;

        private void BtnMailKaydet_Click(object sender, EventArgs e)
        {
            if (siparisNo=="")
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir Kayıt Seçiniz","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Onay Mailini Eke Eklediğinizden ve İşlemi Tamamlamak İstediğinizden Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = satDataGridview1Manager.MailDurumuKaydedildi(siparisNo);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string yapilanIslem = "SAT KAYDINA ONAY MAİLİ EKLENDİ.";
                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanIslem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);
                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                webBrowser4.Navigate("");
                DtgMalzemelerMail.DataSource = null;
                MailGonderilecekler();
                MailGonderilenler();
            }

            /*DialogResult dr = MessageBox.Show("Onay Maillerini Tüm SAT Dosyalarının İçerisine Eklediğinizden Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in DtgGelenMail.Rows)
                {
                    string siparisNo = item.Cells["SiparisNo"].Value.ToString();
                    string mesaj = satDataGridview1Manager.MailDurumuKaydedildi(siparisNo);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string yapilanIslem = "SAT KAYDINA ONAY MAİLİ EKLENDİ.";
                    SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanIslem, infos[1].ToString(), DateTime.Now);
                    satIslemAdimlarimanager.Add(satIslemAdimlari);
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                webBrowser4.Navigate("");
                DtgMalzemelerMail.DataSource = null;
                MailGonderilecekler();
                MailGonderilenler();
            }*/
        }

        private void webBrowser4_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void DtgMailList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Filter = DtgMailList.FilterString;
            TxtMailListCount.Text = DtgMailList.RowCount.ToString();
        }

        private void DtgMailList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Sort = DtgMailList.SortString;
        }

        private void DtgGelenMail_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder3.Sort = DtgGelenMail.SortString;
        }

        private void DtgGelenMail_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder3.Filter = DtgMailList.FilterString;
            TxtGelenMail.Text = DtgMailList.RowCount.ToString();
        }

        private void BtnDosyaMailEkle_Click(object sender, EventArgs e)
        {
            if (yol == null)
            {
                MessageBox.Show("SAT Dosyası Bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (File.Exists(yol + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, yol + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
            }


        }

        private void bb10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion
        #region KeyPress
        private void DtgTeklifAl_SortStringChanged(object sender, EventArgs e)
        {
            binderSetRequest.Sort = DtgTeklifAl.SortString;
        }

        private void stn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void m1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BT10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void IT4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion
    }
}
