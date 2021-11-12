using Business;
using Business.Concreate.IdarıIsler;
using ClosedXML.Excel;
using DataAccess.Concreate;
using DataAccess.Concreate.IdariIsler;
using Entity;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.EgitimDok
{
    public partial class DuranVarlik : Form
    {
        IsAkisNoManager isAkisNoManager;
        DVKayitManager kayitManager;
        IdariIslerLogManager logManager;
        DvNoManager dvNoManager;
        List<string> fileNames = new List<string>();
        public object[] infos;
        string kaynakdosyaismi, alinandosya, fotoyolu, kaynakdosyaismi1, alinandosya1, yeniad, dosyaYoluGun, fotoYoluGun, fotoyoluGun, kaynakdosyaismiGun, alinandosyaGun, yeniadGun;
        public string dosyaYolu="";
        bool dosyaControl = false, fotoControl = false;
        int id;
        public bool kaydet = false, coklu = false, tekli = false, ilkGelis = true;
        public DuranVarlik()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            kayitManager = DVKayitManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
            dvNoManager = DvNoManager.GetInstance();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtEtiketNoGun.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Duran Varlik No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DuranVarlikKayit duranVarlikKayit = new DuranVarlikKayit(TxtEtiketNoGun.Text.ConInt(), CmbDvSahibiGun.Text, CmbButceKoduGun.Text, TxtIsAkisNo.Text, CmbDvGrubuGun.Text, CmbDvTanimGun.Text, TxtMiktarGun.Text, TxtMarkaGun.Text, TxtModelGun.Text, TxtSeriNoGun.Text, CmbKalGerekGun.Text, CmbSatNoGun.Text, CmbSaticiFirmaGun.Text, DtFaturaTarihiGun.Text, TxtFaturaNoGun.Text, TxtFiyatGun.Text.ConDouble(), TxtAciklamaGun.Text, CmbDurumuGun.Text, dosyaYoluGun, fotoyoluGun);

                string mesaj = kayitManager.Update(duranVarlikKayit, id);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLogGun();
                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGun();
            }

        }
        void CreateLogGun()
        {
            string sayfa = "DV KAYIT";
            DuranVarlikKayit yakit = kayitManager.Get(TxtEtiketNoGun.Text);
            int benzersizid = yakit.Id;
            string islem = "DURAN VARLIK KAYIDI GÜNCELLEMİŞTİR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }
        int adet;
        private void BtnCoklu_Click(object sender, EventArgs e)
        {
            if (tekli==true)
            {
                MessageBox.Show("Çoklu Bilgisini Seçtiniz Tekli İşlemleriniz İptal Ediliyor!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Temizle();
                dvNoManager.UpdateAzalt();
                TxtAdet.Text = "0";
                tekli = false;
                TxtAdet.Visible = true;
                LblAdet.Visible = true;
                coklu = true;
                ilkGelis = true;
                TxtAdet.Text = "0";
                return;
            }
            TxtAdet.Visible = true;
            LblAdet.Visible = true;
            coklu = true;
            TxtAdet.Text="0";
        }

        private void BtnTekli_Click(object sender, EventArgs e)
        {
            if (coklu==true)
            {
                MessageBox.Show("Tekli Bilgisine Tıkladız İşlemleriniz İptal Ediliyor!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Temizle();
                dvNoManager.UpdateAzalt();
                TxtAdet.Text = "0";
                TxtAdet.Visible = false;
                LblAdet.Visible = false;
                coklu = false;
                ilkGelis = true;
                return;
            }
            if (kaydet==true)
            {
                TxtAdet.Visible = false;
                LblAdet.Visible = false;
                LblAdet.Text = "";
                //kayitManager.DvNoArttir();
                DvNoArttir();
                kaydet = false;
                return;
            }
            if (tekli == true)
            {
                MessageBox.Show("Lütfen Öncelikle Kaydı Tamamlayınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TxtAdet.Visible = false;
            LblAdet.Visible = false;
            LblAdet.Text = "";
            //kayitManager.DvNoArttir();
            DvNoArttir();
            kaydet = false;
            tekli = true;
            /*if (kaydet == false)
            {
                MessageBox.Show("Lütfen Öncelikle Bilgileri Kaydı Tamamlayınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

        }
        void DvNoArttir()
        {
            dvNoManager.Update();
            DvNo dvNo = dvNoManager.Get();
            LblIsAkisNo.Text = dvNo.DvNoGoster.ToString();
        }
        private void TxtAdet_TextChanged(object sender, EventArgs e)
        {
            if (TxtAdet.Text=="0")
            {
                return;
            }
            DvNoArttir();
            adet = TxtAdet.Text.ConInt();
        }
        string isim;

        private void TxtFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        int sonhaneler;
        private void BtnNoAl_Click(object sender, EventArgs e)
        {
            
            if (CmbDvSahibi.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle DURAN VARLIK Sahibi Bilgisini Giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (CmbDvSahibi.Text== "ASELSAN")
            {
                isim = "AS-PE-";
            }
            if (CmbDvSahibi.Text == "BAŞARAN")
            {
                isim = "BM-PE-";
            }
            if (kaydet==false)
            {
                if (ilkGelis==false)
                {
                    MessageBox.Show("DV Etiket Numarası Zaten Verildİ.Kaydı Tamamlayarak Yeni Dv Etiket Numarası Alabilirsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ilkGelis = false;
            }
            if (coklu == true)
            {
                /*if (adet == 1 || adet == 0)
                {
                    MessageBox.Show("Lütfen Tekli Girişleriniz İçin Tekli Butonuna Tıklayınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dvNoManager.UpdateAzalt();
                    TxtAdet.Clear();
                    coklu = false;
                    return;
                }*/
                adet--;

                if (adet == 0)
                {
                    DvNoArttir();
                    TxtAdet.Visible = false;
                    LblAdet.Visible = false;
                    LblAdet.Text = "";
                }
                int sonhane = LblIsAkisNo.Text.ConInt();
                sonhane = sonhane % 100000;

                TxtDvEtiketNo.Text = isim + "0" + sonhane;
            }
            if (coklu==false)
            {
                sonhaneler = LblIsAkisNo.Text.ConInt();
                sonhaneler = sonhaneler % 100000;
                TxtDvEtiketNo.Text = isim +"0"+ sonhaneler;
            }
        }

        private void TxtAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            /*IXLWorkbook workbook = new XLWorkbook(@"C:\Users\MAYıldırım\Desktop\MÜB PROJE DİREKTÖRLÜĞÜ DEMİRBAŞ & ENVANTER LİSTESİ.xlsx");
            IXLWorksheets sheets = workbook.Worksheets;
            IXLWorksheet worksheet = workbook.Worksheet("DEMİRBAŞ LİSTESİ");
            var rows = worksheet.Rows(2, 2349);
            DateTime outDate = DateTime.Now;
            //double outDouble = 0;
            foreach (IXLRow item in rows)
            {
                DuranVarlikKayit yakits = new DuranVarlikKayit(
                    item.Cell("A").Value.ConInt(), // İŞ AKIŞ NO
                    "BAŞARAN", // DV SAHİBİ
                    item.Cell("S").Value.ToString(), // BÜTÇE KODU
                    item.Cell("E").Value.ToString(), // DV ETİKET NO
                    item.Cell("B").Value.ToString(), // DV GRUBU
                    item.Cell("F").Value.ToString(), // TANIM
                    item.Cell("G").Value.ToString(), // MİKTAR
                    item.Cell("H").Value.ToString(), // MARKA
                    item.Cell("I").Value.ToString(), // MODEL
                    item.Cell("J").Value.ToString(), // SERİ NO
                    item.Cell("K").Value.ToString(), // KALİBRASYON GEREKİYOR MU
                    item.Cell("R").Value.ToString(), // SAT NO
                    item.Cell("U").Value.ToString(), // SATICI FİRMA
                    item.Cell("V").Value.ToString(), // FATURA TARİHİ
                    item.Cell("W").Value.ToString(), // FATURA NO
                    item.Cell("X").Value.ConDouble(), // FİYAT
                    "",// AÇIKLAMA
                    item.Cell("AB").Value.ToString(),// DURUMU
                    "", // DOSYA YOLU
                    ""); // FOTO YOLU
                kayitManager.Add(yakits);
            }*/
            #region KAYDET
            if (LblIsAkisNo.Text=="")
            {
                MessageBox.Show("Lütfen Tüm Bilgileri Eksiksiz Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtDvEtiketNo.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Bilgileri Eksiksiz Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dosyaControl == false)
            {
                MessageBox.Show("Duran Varlık Kayıt işlemini Gerçekleştirmeden Önce Lütfen Dosya Ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (fotoControl == false)
            {
                MessageBox.Show("Duran Varlık Kayıt işlemini Gerçekleştirmeden Önce Lütfen Fotoğraf Ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int isakisno = LblIsAkisNo.Text.ConInt();
                DuranVarlikKayit duranVarlik = new DuranVarlikKayit(isakisno, CmbDvSahibi.Text, CmbButceKodu.Text, TxtDvEtiketNo.Text, CmbDvGrubu.Text, CmbDvTanim.Text, TxtMiktar.Text, TxtMarka.Text, TxtModel.Text, TxtSeriNo.Text, CmbKalGerek.Text, CmbSatNo.Text, CmbSaticiFirma.Text, DtFaturaTarihi.Text, TxtFaturaNo.Text, TxtFiyat.Text.ConDouble(), TxtAciklama.Text, CmbDurumu.Text, dosyaYolu, fotoyolu);
                string mesaj = kayitManager.Add(duranVarlik);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CreateLog();
                fotoControl = false;
                dosyaControl = false;
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string dvNoTut = LblIsAkisNo.Text;
                Temizle();
                IsAkisNo();
                if (coklu==true)
                {
                    if (adet==0)
                    {
                        //DvNoArttir();
                        TxtAdet.Visible = false;
                        LblAdet.Visible = false;
                        LblAdet.Text = "";
                        CmbDvSahibi.Text = "";
                        Temizle();
                        coklu = false;
                        kaydet = true;
                        return;
                    }
                    sonhaneler = LblIsAkisNo.Text.ConInt();
                    sonhaneler = sonhaneler % 100000;
                    TxtDvEtiketNo.Text = isim + "0" + sonhaneler + "/" + adet.ToString();
                    LblIsAkisNo.Text = dvNoTut;
                    adet--;
                }
                else
                {
                    Temizle();
                    kaydet = true;
                    tekli = false;
                }
            }
            #endregion
        }
        void Temizle()
        {
            CmbDvSahibi.Text = ""; CmbButceKodu.Text = ""; TxtDvEtiketNo.Clear(); CmbDvGrubu.Text = "";
            CmbDvTanim.Text = ""; TxtMiktar.Clear(); TxtMarka.Clear(); TxtModel.Clear(); TxtSeriNo.Clear(); CmbKalGerek.Text = ""; CmbSatNo.Text = "";
            CmbSaticiFirma.Text = ""; TxtFaturaNo.Clear(); TxtFiyat.Clear(); TxtAciklama.Clear(); webBrowser1.Navigate(""); PctBox.ImageLocation = "";
            CmbDurumu.Text = ""; LblIsAkisNo.Clear(); kaydet = false;
        }

        private void BtnDosyaEkleGun_Click(object sender, EventArgs e)
        {
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
            if (!Directory.Exists(dosyaYoluGun))
            {
                Directory.CreateDirectory(dosyaYoluGun);
            }
            if (File.Exists(dosyaYoluGun + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYoluGun + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                webBrowser2.Navigate(dosyaYoluGun);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog3.ShowDialog();
            if (dr == DialogResult.OK)
            {
                fotoyoluGun = openFileDialog3.FileName;
                kaynakdosyaismiGun = openFileDialog3.SafeFileName.ToString();
                alinandosyaGun = openFileDialog3.FileName.ToString();

                if (Path.GetExtension(fotoyoluGun) == ".jpg" || Path.GetExtension(fotoyoluGun) == ".png")
                {
                    PctBoxGun.ImageLocation = fotoyoluGun;
                    Properties.Settings.Default.FotoYolu = fotoyoluGun;
                    Properties.Settings.Default.Save();

                    yeniadGun = TxtEtiketNoGun.Text + ".jpg";
                    if (!Directory.Exists(dosyaYoluGun + "\\" + yeniadGun))
                    {
                        string silinecek = dosyaYoluGun + "\\" + yeniadGun;
                        File.Delete(silinecek);
                    }
                    File.Copy(fotoyoluGun, dosyaYoluGun + "\\" + yeniadGun);
                }
                else
                {
                    MessageBox.Show("Lütfen JPEG veya PNG formatında olan bir dosyayı seçiniz.");
                }
            }
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtEtiketNoGun.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İş Akış Numarası Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DuranVarlikKayit duranVarlik = kayitManager.Get(TxtEtiketNoGun.Text);
            if (duranVarlik == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGun();
                return;
            }
            id = duranVarlik.Id;
            CmbDvSahibiGun.Text = duranVarlik.DvSahibi;
            CmbButceKoduGun.Text = duranVarlik.ButceKodu;
            TxtIsAkisNo.Text = duranVarlik.DvEtiketNo;
            CmbDvGrubuGun.Text = duranVarlik.DvGrubu;
            CmbDvTanimGun.Text = duranVarlik.DvTanim;
            TxtMiktarGun.Text = duranVarlik.Miktar.ToString();
            TxtMarkaGun.Text = duranVarlik.Marka;
            TxtModelGun.Text = duranVarlik.Model;
            TxtSeriNoGun.Text = duranVarlik.SeriNo;
            CmbKalGerekGun.Text = duranVarlik.KalGerek;
            CmbSatNoGun.Text = duranVarlik.SatNo;
            CmbSaticiFirmaGun.Text = duranVarlik.SaticiFirma;
            DtFaturaTarihiGun.Text = duranVarlik.Tarih;
            TxtFaturaNoGun.Text = duranVarlik.FaturaNo;
            TxtFiyatGun.Text = duranVarlik.Fiyat.ToString();
            TxtAciklamaGun.Text = duranVarlik.Aciklama;
            dosyaYoluGun = duranVarlik.DosyaYolu;
            fotoYoluGun = duranVarlik.FotoYolu;
            PctBoxGun.ImageLocation = fotoYoluGun;
            webBrowser2.Navigate(dosyaYoluGun);
        }
        void TemizleGun()
        {
            TxtEtiketNoGun.Clear(); CmbDvSahibiGun.Text = ""; CmbButceKoduGun.Text = ""; TxtIsAkisNo.Clear(); CmbDvGrubuGun.Text = ""; CmbDvTuruGun.Text = "";
            CmbDvTanimGun.Text = ""; TxtMiktarGun.Clear(); TxtMarkaGun.Clear(); TxtModelGun.Clear(); TxtSeriNoGun.Clear(); CmbKalGerekGun.Text = ""; CmbSatNoGun.Text = "";
            CmbSaticiFirmaGun.Text = ""; TxtFaturaNoGun.Clear(); TxtFiyatGun.Clear(); TxtAciklamaGun.Clear(); webBrowser2.Navigate(""); PctBoxGun.ImageLocation = ""; CmbDurumuGun.Text = "";
        }

        void CreateLog()
        {
            string sayfa = "DV KAYIT";
            DuranVarlikKayit yakit = kayitManager.Get(TxtDvEtiketNo.Text);
            int benzersizid = yakit.Id;
            string islem = "DURAN VARLIK KAYIT İŞLEMİ GERÇEKLEMİŞTİR.";
            string islemyapan = infos[1].ToString();
            IdariIslerLog log = new IdariIslerLog(sayfa, benzersizid, islem, islemyapan, DateTime.Now);
            logManager.Add(log);
        }

        private void TxtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void BtnFotoEkle_Click(object sender, EventArgs e)
        {
            if (dosyaYolu == "")
            {
                MessageBox.Show("Lütfen Öncelikle Dosya Ekleyiniz Daha Sonra Fotoğraf Ekleme İşlemini Gerçekleştiriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dosyaControl==false)
            {
                MessageBox.Show("Lütfen Öncelikle Dosya Ekleyiniz Daha Sonra Fotoğraf Ekleme İşlemini Gerçekleştiriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = openFileDialog2.ShowDialog();
            if (dr == DialogResult.OK)
            {
                fotoyolu = openFileDialog2.FileName;
                kaynakdosyaismi1 = openFileDialog2.SafeFileName.ToString();
                alinandosya1 = openFileDialog2.FileName.ToString();

                if (Path.GetExtension(fotoyolu) == ".jpg" || Path.GetExtension(fotoyolu) == ".png")
                {
                    PctBox.ImageLocation = fotoyolu;
                    Properties.Settings.Default.FotoYolu = fotoyolu;
                    Properties.Settings.Default.Save();

                    yeniad = TxtDvEtiketNo.Text + ".jpg";
                    if (!Directory.Exists(dosyaYolu + "\\" + yeniad))
                    {
                        string silinecek = dosyaYolu + "\\" + yeniad;
                        File.Delete(silinecek);
                    }
                    File.Copy(fotoyolu, dosyaYolu + "\\" + yeniad);
                    fotoControl = true;
                }
                else
                {
                    MessageBox.Show("Lütfen JPEG veya PNG formatında olan bir dosyayı seçiniz.");
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (kaydet==false)
            {
                dvNoManager.UpdateAzalt();
                if (dosyaYolu!="")
                {
                    Directory.Delete(dosyaYolu, true);
                }
            }

            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDuranVarlik"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void DuranVarlik_Load(object sender, EventArgs e)
        {
            //IsAkisNo();
        }
        public void IsAkisNo()
        {
            /*isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();*/
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\";
            string anadosya = @"Z:\DTS\İDARİ İŞLER\DURAN VARLIK\";
            /*string root = @"D:\DTS";
            string subdir = @"D:\DTS\İDARİ İŞLER\";
            string anadosya = @"D:\DTS\İDARİ İŞLER\DV KAYIT\";*/
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
            dosyaYolu = anadosya + TxtDvEtiketNo.Text + "\\";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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
            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                webBrowser1.Navigate(dosyaYolu);
                dosyaControl = true;
            }
        }
    }
}
