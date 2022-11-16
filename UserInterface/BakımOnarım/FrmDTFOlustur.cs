using Business;
using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarim;
using Entity.Gecic_Kabul_Ambar;
using Entity.STS;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;

namespace UserInterface.BakımOnarım
{
    public partial class FrmDTFOlustur : Form
    {
        SatTalebiDoldurManager satTalebiDoldurManager;
        ComboManager comboManager;
        AltYukleniciManager altYukleniciManager;
        MalzemeKayitManager malzemeKayitManager;
        IsAkisNoManager isAkisNoManager;
        DtfManager dtfManager;
        DtfMaliyetManager dtfMaliyetManager;

        List<MalzemeKayit> malzemeKayits;
        List<DtfMaliyet> dtfMaliyets;

        public object[] infos;
        int id, idGun, comboId, isAkisNo;
        bool start;
        string donem, dosyaYolu, taslakYolu, topfiyat;
        public string comboAd;
        string yol = @"C:\DTS\Taslak\";
        string kaynak = @"Z:\DTS\BAKIM ONARIM\TASLAKLAR\";
        double toplam, x1, x2, x3, x4, x5, x6, x7, outValue, sonuc = 0;
        public FrmDTFOlustur()
        {
            InitializeComponent();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            altYukleniciManager = AltYukleniciManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            dtfManager = DtfManager.GetInstance();
            dtfMaliyetManager = DtfMaliyetManager.GetInstance();
        }

        private void FrmDTFOlustur_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            TalebiOlusturan();
            UsBolgeleri();
            UsBolgeleriGuncelle();
            ProjeKodu();
            ProjeKoduGuncelle();
            IsKategorisi();
            IsKategorisiGuncelle();
            AltYukleniciFirma();
            AltYukleniciFirmaGuncelle();
            Tanim();
            TanimGuncelle();
            start = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDTFOlusturma"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void TalebiOlusturan()
        {
            TalepEden.Text = infos[1].ToString();
            LblKayitTarihi.Text = DateTime.Now.ToString("dd.MM.yyyy");
            donem = FrmHelper.DonemControl(DateTime.Now);

            string[] array = donem.Split(' ');

            CmbDonemAy.Text = array[0].ToString();
            CmbDonemYil.Text = array[1].ToString();
        }
        public void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }

        void UsBolgeleri()
        {
            CmbBolgeAdi.DataSource = satTalebiDoldurManager.GetList();
            CmbBolgeAdi.ValueMember = "Id";
            CmbBolgeAdi.DisplayMember = "Usbolgesi";
            CmbBolgeAdi.SelectedValue = "";
        }
        void UsBolgeleriGuncelle()
        {
            CmbBolgeAdiGun.DataSource = satTalebiDoldurManager.GetList();
            CmbBolgeAdiGun.ValueMember = "Id";
            CmbBolgeAdiGun.DisplayMember = "Usbolgesi";
            CmbBolgeAdiGun.SelectedValue = "";
        }
        public void ProjeKodu()
        {
            CmbProjeKodu.DataSource = comboManager.GetList("PROJE_KODU");
            CmbProjeKodu.ValueMember = "Id";
            CmbProjeKodu.DisplayMember = "Baslik";
            CmbProjeKodu.SelectedValue = 0;
        }
        public void ProjeKoduGuncelle()
        {
            CmbProjeKoduGun.DataSource = comboManager.GetList("PROJE_KODU");
            CmbProjeKoduGun.ValueMember = "Id";
            CmbProjeKoduGun.DisplayMember = "Baslik";
            CmbProjeKoduGun.SelectedValue = 0;
        }
        public void IsKategorisi()
        {
            CmbIsKategorisi.DataSource = comboManager.GetList("IS_KATEGORISI");
            CmbIsKategorisi.ValueMember = "Id";
            CmbIsKategorisi.DisplayMember = "Baslik";
            CmbIsKategorisi.SelectedValue = 0;
        }
        public void IsKategorisiGuncelle()
        {
            CmbIsKategorisiGun.DataSource = comboManager.GetList("IS_KATEGORISI");
            CmbIsKategorisiGun.ValueMember = "Id";
            CmbIsKategorisiGun.DisplayMember = "Baslik";
            CmbIsKategorisiGun.SelectedValue = 0;
        }
        void AltYukleniciFirma()
        {
            CmbAltYukleniciFirma.DataSource = altYukleniciManager.GetList(0);
            CmbAltYukleniciFirma.ValueMember = "Id";
            CmbAltYukleniciFirma.DisplayMember = "Firmaadi";
            CmbAltYukleniciFirma.SelectedValue = 0;
        }
        void AltYukleniciFirmaGuncelle()
        {
            CmbAltYukleniciFirmaGun.DataSource = altYukleniciManager.GetList(0);
            CmbAltYukleniciFirmaGun.ValueMember = "Id";
            CmbAltYukleniciFirmaGun.DisplayMember = "Firmaadi";
            CmbAltYukleniciFirmaGun.SelectedValue = 0;
        }
        void Tanim()
        {
            malzemeKayits = malzemeKayitManager.GetListMalzemeKayit();
            CmbTanim.DataSource = malzemeKayits;
            CmbTanim.ValueMember = "Id";
            CmbTanim.DisplayMember = "Tanim";
            CmbTanim.SelectedValue = 0;
        }
        void TanimGuncelle()
        {
            malzemeKayits = malzemeKayitManager.GetListMalzemeKayit();
            CmbTanimGun.DataSource = malzemeKayits;
            CmbTanimGun.ValueMember = "Id";
            CmbTanimGun.DisplayMember = "Tanim";
            CmbTanimGun.SelectedValue = 0;
        }

        private void CmbAltYukleniciFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (CmbAltYukleniciFirma.SelectedIndex == -1)
            {
                LblFirmaSorumlusu.Text = "00";
                return;
            }
            id = CmbAltYukleniciFirma.SelectedValue.ConInt();
            AltYuklenici altYukleniciFirma = altYukleniciManager.Get(id);
            LblFirmaSorumlusu.Text = altYukleniciFirma.Personeladi;
        }

        private void CmbTanim_TextChanged(object sender, EventArgs e)
        {
            if (CmbTanim.Text == "")
            {
                LblStokNo.Text = "00";
            }
            else
            {
                foreach (MalzemeKayit item in malzemeKayits)
                {
                    if (CmbTanim.Text == item.Tanim)
                    {
                        LblStokNo.Text = item.Stokno;
                    }
                }
            }
        }
        private void CmbTanim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (CmbTanim.SelectedIndex == -1)
            {
                LblStokNo.Text = "00";
                return;
            }
            comboId = CmbTanim.SelectedValue.ConInt();
            MalzemeKayit malzemeKayit = malzemeKayitManager.Get(comboId);
            if (malzemeKayit == null)
            {
                LblStokNo.Text = "00";
                return;
            }
            LblStokNo.Text = malzemeKayit.Stokno;
        }
        void CreateWord()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\BAKIM ONARIM\";
            string anadosya = @"Z:\DTS\BAKIM ONARIM\DTF\";

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
            dosyaYolu = anadosya + LblIsAkisNo.Text + "\\";
            Directory.CreateDirectory(dosyaYolu);

            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = taslakYolu;

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["IsAkisNo"].Range.Text = LblIsAkisNo.Text;
            wBookmarks["AbfNo"].Range.Text = TxtAbfNo.Text;
            wBookmarks["BolgeAdi"].Range.Text = CmbBolgeAdi.Text;
            wBookmarks["ProjeKodu"].Range.Text = CmbProjeKodu.Text;
            wBookmarks["AltYukleniciFirma"].Range.Text = CmbAltYukleniciFirma.Text;
            wBookmarks["GarantiDurumu"].Range.Text = CmbGarantiDurumu.Text;
            wBookmarks["FirmaSorumlusu"].Range.Text = LblFirmaSorumlusu.Text;
            wBookmarks["StokNo"].Range.Text = LblStokNo.Text;
            wBookmarks["Tanim"].Range.Text = CmbTanim.Text;
            wBookmarks["ButceKodu"].Range.Text = CmbButceKodu.Text;
            wBookmarks["SeriNo"].Range.Text = TxtSeriNo.Text;
            if (CmbOnarimYeri.Text== "YERİNDE ONARIM")
            {
                wBookmarks["YerindeOnarim"].Range.Text = "X";
            }
            else
            {
                wBookmarks["FirmadaOnarim"].Range.Text = "X";
            }
            wBookmarks["IsinTanimi"].Range.Text = TxtIsinTanimi.Text;
            wBookmarks["TalebiOlusturan"].Range.Text = TalepEden.Text;
            wBookmarks["IsinVerildigiTarih"].Range.Text = DtgIsinVerildigiTarih.Value.ToString("dd/MM/yyyy");
            wBookmarks["Tarih"].Range.Text = DtgIsinVerildigiTarih.Value.ToString("dd/MM/yyyy");
            wBookmarks["Tarih2"].Range.Text = DtgIsinVerildigiTarih.Value.ToString("dd/MM/yyyy");

            wDoc.SaveAs2(dosyaYolu + LblIsAkisNo.Text + ".docx");
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

        private void BtnProjeEkle_Click(object sender, EventArgs e)
        {
            comboAd = "PROJE_KODU";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnAltYukFirmaEkle_Click(object sender, EventArgs e)
        {
            FrmAltYukleniciFirma frmBolgeler = new FrmAltYukleniciFirma();
            frmBolgeler.button5.Visible = false;
            frmBolgeler.ShowDialog();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnIsinTanimiEkle_Click(object sender, EventArgs e)
        {
            comboAd = "IS_KATEGORISI";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
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

            File.Copy(kaynak + "MP-FR-019 DOĞRUDAN TEMİN FORMU REV (00).docx", yol + "MP-FR-019 DOĞRUDAN TEMİN FORMU REV (00).docx");

            taslakYolu = yol + "MP-FR-019 DOĞRUDAN TEMİN FORMU REV (00).docx";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                IsAkisNo();

                string anadosya = @"Z:\DTS\BAKIM ONARIM\DTF\";
                dosyaYolu = anadosya + LblIsAkisNo.Text + "\\";
                Dtf dtf = new Dtf(LblIsAkisNo.Text.ConInt(), TalepEden.Text, LblKayitTarihi.Value, donem, CmbButceKodu.Text, TxtAbfNo.Text, CmbBolgeAdi.Text, CmbProjeKodu.Text, CmbGarantiDurumu.Text, CmbIsKategorisi.Text, TxtIsinTanimi.Text.ToUpper(), LblStokNo.Text, CmbTanim.Text, TxtSeriNo.Text, CmbOnarimYeri.Text, CmbAltYukleniciFirma.Text, LblFirmaSorumlusu.Text, DtgIsinVerildigiTarih.Value, dosyaYolu);

                string mesaj = dtfManager.Add(dtf);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                TaslakKopyala();
                CreateWord();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAkisNo();
                Temizle();
            }
        }
        void Hesapla(string birim)
        {
            toplam = x1 + x2 + x3 + x4 + x5 + x6 + x7;
            if (birim == "")
            {
                TxtGenelTop.Text = toplam.ToString("0.00") + " ₺";
            }
            if (birim == "TL")
            {
                TxtGenelTop.Text = toplam.ToString("0.00") + " ₺";
            }
            if (birim == "USD")
            {
                TxtGenelTop.Text = toplam.ToString("0.00") + " $";
            }
            if (birim == "EURO")
            {
                TxtGenelTop.Text = toplam.ToString("0.00") + " €";
            }

        }
        void HesaplaGuncelle(string birim)
        {
            toplam = x1 + x2 + x3 + x4 + x5 + x6 + x7;
            if (birim == "")
            {
                TxtGenelTopGun.Text = toplam.ToString("0.00") + " ₺";
            }
            if (birim == "TL")
            {
                TxtGenelTopGun.Text = toplam.ToString("0.00") + " ₺";
            }
            if (birim == "USD")
            {
                TxtGenelTopGun.Text = toplam.ToString("0.00") + " $";
            }
            if (birim == "EURO")
            {
                TxtGenelTopGun.Text = toplam.ToString("0.00") + " €";
            }

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

        void Temizle()
        {
            CmbButceKodu.SelectedIndex = -1; TxtAbfNo.Clear(); CmbBolgeAdi.SelectedIndex = -1; CmbProjeKodu.SelectedIndex = -1; CmbGarantiDurumu.SelectedIndex = -1;
            CmbIsKategorisi.SelectedIndex = -1; TxtIsinTanimi.Clear(); CmbTanim.Text = ""; TxtSeriNo.Clear(); CmbOnarimYeri.Text = "";
            CmbAltYukleniciFirma.SelectedIndex = -1;
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İŞ AKIŞ NO Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Dtf dtf = dtfManager.Get(TxtIsAkisNo.Text.ConInt());
            if (dtf == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz ABF Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleKO();
                return;
            }
            id = dtf.Id;
            LblKayitTarihiKO.Text = dtf.KayitTarihi.ToString("dd.MM.yyyy");
            LblDonemKO.Text = dtf.Donem;
            LblHarcamaKoduKO.Text = dtf.ButceKodu;
            LblAbfNoKO.Text = dtf.AbfNo;
            LblUsBolgesiKO.Text = dtf.UsBolgesi;
            LblProjeKoduKO.Text = dtf.ProjeKodu;
            LblGarantiDurumuKO.Text = dtf.ProjeKodu;
            LblIsKategorisiKO.Text = dtf.GarantiDurumu;
            LblTanimKO.Text = dtf.Tanim;
            LblStokNoKO.Text = dtf.StokNo;
            LblSeriNoKO.Text = dtf.SeriNo;
            LblOnarimYeriKO.Text = dtf.OnarimYeri;
            LblAltYukFirmaKO.Text = dtf.AltYukleniciFirma;
            LblFirmaSorumlusuKO.Text = dtf.FirmaSorumlusu;
            TxtIsinTanimiKO.Text = dtf.IsTanimi;
            dosyaYolu = dtf.DosyaYolu;
            isAkisNo = dtf.IsAkisNo;

        }
        void TemizleKO()
        {
            LblKayitTarihiKO.Text = "00"; LblDonemKO.Text = "00"; LblHarcamaKoduKO.Text = "00"; LblAbfNoKO.Text = "00"; LblUsBolgesiKO.Text = "00"; 
            LblProjeKoduKO.Text = "00"; LblGarantiDurumuKO.Text = "00"; LblIsKategorisiKO.Text = "00"; LblTanimKO.Text = "00"; LblStokNoKO.Text = "00"; 
            LblSeriNoKO.Text = "00"; LblOnarimYeriKO.Text = "00"; LblAltYukFirmaKO.Text = "00"; LblFirmaSorumlusuKO.Text = "00"; TxtIsinTanimiKO.Clear();
            IsTanimi1.Clear(); IsTanimi2.Clear(); IsTanimi3.Clear(); IsTanimi4.Clear(); IsTanimi5.Clear(); IsTanimi6.Clear(); IsTanimi7.Clear();
            m1.Clear(); m2.Clear(); m3.Clear(); m4.Clear(); m5.Clear(); m6.Clear(); m7.Clear(); b1.Text = ""; b2.Text = ""; b3.Text = ""; b4.Text = "";
            b5.Text = ""; b6.Text = ""; b7.Text = ""; Pb1.SelectedIndex = -1; Pb2.SelectedIndex = -1; Pb3.SelectedIndex = -1; Pb4.SelectedIndex = -1;
            Pb5.SelectedIndex = -1; Pb6.SelectedIndex = -1; Pb7.SelectedIndex = -1; BTutar1.Clear(); BTutar2.Clear(); BTutar3.Clear(); BTutar4.Clear();
            BTutar5.Clear(); BTutar6.Clear(); BTutar7.Clear(); TTutar1.Clear(); TTutar2.Clear(); TTutar3.Clear(); TTutar4.Clear(); TTutar5.Clear();
            TTutar6.Clear(); TTutar7.Clear(); TxtGenelTop.Text = "0";
            TxtYapilanIslemler.Clear(); TxtIsAkisNo.Clear();
        }
        void TemizleGun()
        {
            
        }

        private void TTutar1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TTutar2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TTutar3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TTutar4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BTutar2_TextChanged(object sender, EventArgs e)
        {
            TTutar2.Text = TopFiyatHesapla(BTutar2.Text, m2.Text);
        }

        private void BTutar3_TextChanged(object sender, EventArgs e)
        {
            TTutar3.Text = TopFiyatHesapla(BTutar3.Text, m3.Text);
        }

        private void BTutar6_TextChanged(object sender, EventArgs e)
        {
            TTutar6.Text = TopFiyatHesapla(BTutar6.Text, m6.Text);
        }

        private void BTutar7_TextChanged(object sender, EventArgs e)
        {
            TTutar7.Text = TopFiyatHesapla(BTutar7.Text, m7.Text);
        }

        private void TTutar1_TextChanged(object sender, EventArgs e)
        {
            if (TTutar1.Text == "")
            {
                x1 = 0;
                Hesapla(Pb1.Text);
                return;
            }
            x1 = TTutar1.Text.ConDouble();
            Hesapla(Pb1.Text);
        }

        private void TTutar2_TextChanged(object sender, EventArgs e)
        {
            if (TTutar2.Text == "")
            {
                x2 = 0;
                Hesapla(Pb2.Text);
                return;
            }
            x2 = TTutar2.Text.ConDouble();
            Hesapla(Pb2.Text);
        }

        private void TTutar3_TextChanged(object sender, EventArgs e)
        {
            if (TTutar3.Text == "")
            {
                x3 = 0;
                Hesapla(Pb3.Text);
                return;
            }
            x3 = TTutar3.Text.ConDouble();
            Hesapla(Pb3.Text);
        }

        private void TTutar4_TextChanged(object sender, EventArgs e)
        {
            if (TTutar4.Text == "")
            {
                x4 = 0;
                Hesapla(Pb4.Text);
                return;
            }
            x4 = TTutar4.Text.ConDouble();
            Hesapla(Pb4.Text);
        }

        private void TTutar5_TextChanged(object sender, EventArgs e)
        {
            if (TTutar5.Text == "")
            {
                x5 = 0;
                Hesapla(Pb5.Text);
                return;
            }
            x5 = TTutar5.Text.ConDouble();
            Hesapla(Pb5.Text);
        }

        private void TTutar6_TextChanged(object sender, EventArgs e)
        {
            if (TTutar6.Text == "")
            {
                x6 = 0;
                Hesapla(Pb6.Text);
                return;
            }
            x6 = TTutar6.Text.ConDouble();
            Hesapla(Pb6.Text);
        }

        private void TTutar7_TextChanged(object sender, EventArgs e)
        {
            if (TTutar7.Text == "")
            {
                x7 = 0;
                Hesapla(Pb7.Text);
                return;
            }
            x7 = TTutar7.Text.ConDouble();
            Hesapla(Pb7.Text);
        }

        private void m1_TextChanged(object sender, EventArgs e)
        {
            TTutar1.Text = TopFiyatHesapla(BTutar1.Text, m1.Text);
        }

        private void m2_TextChanged(object sender, EventArgs e)
        {
            TTutar2.Text = TopFiyatHesapla(BTutar2.Text, m2.Text);
        }

        private void m3_TextChanged(object sender, EventArgs e)
        {
            TTutar3.Text = TopFiyatHesapla(BTutar3.Text, m3.Text);
        }

        private void m4_TextChanged(object sender, EventArgs e)
        {
            TTutar4.Text = TopFiyatHesapla(BTutar4.Text, m4.Text);
        }

        private void m5_TextChanged(object sender, EventArgs e)
        {
            TTutar5.Text = TopFiyatHesapla(BTutar5.Text, m5.Text);
        }

        private void m6_TextChanged(object sender, EventArgs e)
        {
            TTutar6.Text = TopFiyatHesapla(BTutar6.Text, m6.Text);
        }

        private void m7_TextChanged(object sender, EventArgs e)
        {
            TTutar7.Text = TopFiyatHesapla(BTutar7.Text, m7.Text);
        }

        private void Pb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TTutar1.Text == "")
            {
                x1 = 0;
                Hesapla(Pb1.Text);
                return;
            }
            x1 = TTutar1.Text.ConDouble();
            Hesapla(Pb1.Text);
        }

        private void Pb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TTutar2.Text == "")
            {
                x2 = 0;
                Hesapla(Pb2.Text);
                return;
            }
            x2 = TTutar2.Text.ConDouble();
            Hesapla(Pb2.Text);
        }

        private void Pb3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TTutar3.Text == "")
            {
                x3 = 0;
                Hesapla(Pb3.Text);
                return;
            }
            x3 = TTutar3.Text.ConDouble();
            Hesapla(Pb3.Text);
        }

        private void Pb4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TTutar4.Text == "")
            {
                x4 = 0;
                Hesapla(Pb4.Text);
                return;
            }
            x4 = TTutar4.Text.ConDouble();
            Hesapla(Pb4.Text);
        }

        private void Pb5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TTutar5.Text == "")
            {
                x5 = 0;
                Hesapla(Pb5.Text);
                return;
            }
            x5 = TTutar5.Text.ConDouble();
            Hesapla(Pb5.Text);
        }

        private void Pb6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TTutar6.Text == "")
            {
                x6 = 0;
                Hesapla(Pb6.Text);
                return;
            }
            x6 = TTutar6.Text.ConDouble();
            Hesapla(Pb6.Text);
        }

        private void Pb7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TTutar7.Text == "")
            {
                x7 = 0;
                Hesapla(Pb7.Text);
                return;
            }
            x7 = TTutar7.Text.ConDouble();
            Hesapla(Pb7.Text);
        }

        private void BTutar4_TextChanged(object sender, EventArgs e)
        {
            TTutar4.Text = TopFiyatHesapla(BTutar4.Text, m4.Text);
        }

        private void BTutar5_TextChanged(object sender, EventArgs e)
        {
            TTutar5.Text = TopFiyatHesapla(BTutar5.Text, m5.Text);
        }

        private void BTutar1_TextChanged(object sender, EventArgs e)
        {
            TTutar1.Text = TopFiyatHesapla(BTutar1.Text, m1.Text);
        }

        private void BtnBulGun_Click(object sender, EventArgs e)
        {
            if (TxtIsAkisNoGun.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İŞ AKIŞ NO Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Dtf dtf = dtfManager.Get(TxtIsAkisNoGun.Text.ConInt());
            if (dtf == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz ABF Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGun();
                return;
            }
            idGun = dtf.Id;
            LblIsAkisNoGun.Text = dtf.IsAkisNo.ToString();
            LblAdSoyadGun.Text = dtf.AdiSoyadi;
            LblKayitTarihiGun.Text = dtf.KayitTarihi.ToString("dd.MM.yyyy");
            donem = dtf.Donem;
            string[] array = donem.Split(' ');
            CmbDonemAyGun.Text = array[0].ToString();
            CmbDonemYilGun.Text = array[1].ToString();
            CmbHarcamaKoduGun.Text = dtf.ButceKodu;
            TxtAbfNoGun.Text = dtf.AbfNo;
            CmbBolgeAdiGun.Text = dtf.UsBolgesi;
            CmbProjeKoduGun.Text = dtf.ProjeKodu;
            CmbGarantiDurumuGun.Text = dtf.GarantiDurumu;
            CmbIsKategorisiGun.Text = dtf.IsKategorisi;
            CmbTanimGun.Text = dtf.Tanim;
            LblStokNoGun.Text = dtf.StokNo;
            TxtSeriNoGun.Text = dtf.SeriNo;
            CmbOnarimYeriGun.Text = dtf.OnarimYeri;
            CmbAltYukleniciFirmaGun.Text = dtf.AltYukleniciFirma;
            LblFirmaSorumlusuGun.Text = dtf.FirmaSorumlusu;
            TxtIsinTanimiGun.Text = dtf.IsTanimi;
            dosyaYolu = dtf.DosyaYolu;
            DtIsBaslamaTarihiGun.Value = dtf.IsBaslamaTarihi;
            DtIsBitisTarihiGun.Value = dtf.IsBitisTarihi;
            TxtYapilanIslemlerGun.Text = dtf.YapilanIslemler;
            FillTools();

        }

        private void CmbTanimGun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (CmbTanimGun.SelectedIndex == -1)
            {
                LblStokNoGun.Text = "00";
                return;
            }
            comboId = CmbTanimGun.SelectedValue.ConInt();
            MalzemeKayit malzemeKayit = malzemeKayitManager.Get(comboId);
            if (malzemeKayit == null)
            {
                LblStokNoGun.Text = "00";
                return;
            }
            LblStokNoGun.Text = malzemeKayit.Stokno;
        }

        private void CmbTanimGun_TextChanged(object sender, EventArgs e)
        {
            if (CmbTanimGun.Text == "")
            {
                LblStokNoGun.Text = "00";
            }
            else
            {
                foreach (MalzemeKayit item in malzemeKayits)
                {
                    if (CmbTanimGun.Text == item.Tanim)
                    {
                        LblStokNoGun.Text = item.Stokno;
                    }
                }
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri güncellemek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
               string mesaj = MaliyetKontrolGuncelle();
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                TaslakKopyala();
                string donem = CmbDonemAyGun.Text + " " + CmbDonemYilGun.Text;
                Dtf dtf = new Dtf(idGun, LblIsAkisNoGun.Text.ConInt(), LblAdSoyadGun.Text, LblKayitTarihiGun.Text.ConDate(), donem, CmbHarcamaKoduGun.Text, TxtAbfNoGun.Text, CmbBolgeAdiGun.Text, CmbProjeKoduGun.Text, CmbGarantiDurumuGun.Text, CmbIsKategorisiGun.Text, TxtIsinTanimiGun.Text, LblStokNoGun.Text, CmbTanimGun.Text, TxtSeriNoGun.Text, CmbOnarimYeriGun.Text, CmbAltYukleniciFirmaGun.Text, LblFirmaSorumlusuGun.Text, DtgIsinVerildigiTarihGun.Value, DtIsBaslamaTarihiGun.Value, DtIsBitisTarihiGun.Value, TxtYapilanIslemlerGun.Text, dosyaYolu);

                mesaj = dtfManager.Update(dtf);

                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                YaklasikMaliyetKayitGuncelle();
                CreateWordGuncelle();
                MessageBox.Show("Bilgiler başarıyla güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleGuncelle();
            }
        }
        
        void TemizleGuncelle()
        {
            LblIsAkisNoGun.Text = "00"; LblAdSoyadGun.Text = "00"; LblKayitTarihiGun.Text = "00"; CmbDonemAyGun.SelectedIndex = -1; CmbDonemYilGun.SelectedIndex = -1;
            CmbHarcamaKoduGun.SelectedIndex=-1; TxtAbfNoGun.Clear(); CmbBolgeAdiGun.SelectedIndex = -1; CmbProjeKoduGun.SelectedIndex = -1;
            CmbGarantiDurumuGun.SelectedIndex = -1; CmbIsKategorisiGun.SelectedIndex = -1; TxtIsinTanimiGun.Clear(); CmbTanimGun.Text = ""; LblStokNoGun.Text = "00";
            TxtSeriNoGun.Clear(); CmbOnarimYeriGun.SelectedIndex = -1; CmbAltYukleniciFirmaGun.SelectedIndex = -1; LblFirmaSorumlusuGun.Text = "00";
            TxtYapilanIslemlerGun.Clear(); IsTanimiGun1.Clear(); IsTanimiGun2.Clear(); IsTanimiGun3.Clear(); IsTanimiGun4.Clear(); IsTanimiGun5.Clear();
            IsTanimiGun6.Clear(); IsTanimiGun7.Clear(); mGun1.Clear(); mGun2.Clear(); mGun3.Clear(); mGun4.Clear(); mGun5.Clear(); mGun6.Clear(); mGun7.Clear();
            bGun1.Text = ""; bGun2.Text = ""; bGun3.Text = ""; bGun4.Text = ""; bGun5.Text = ""; bGun6.Text = ""; bGun7.Text = ""; PbGun1.SelectedIndex = -1;
            PbGun2.SelectedIndex = -1; PbGun3.SelectedIndex = -1; PbGun4.SelectedIndex = -1; PbGun5.SelectedIndex = -1; PbGun6.SelectedIndex = -1;
            PbGun7.SelectedIndex = -1; BTutarGun1.Clear(); BTutarGun2.Clear(); BTutarGun3.Clear(); BTutarGun4.Clear(); BTutarGun5.Clear(); BTutarGun6.Clear();
            BTutarGun7.Clear(); TTutarGun1.Clear(); TTutarGun2.Clear(); TTutarGun3.Clear(); TTutarGun4.Clear(); TTutarGun5.Clear(); TTutarGun6.Clear();
            TTutarGun7.Clear();
        }
        string mesaj;
        void YaklasikMaliyetKayitGuncelle()
        {
            foreach (DtfMaliyet item in dtfMaliyets)
            {
                mesaj = dtfMaliyetManager.Delete(item.Id);
            }
            
            if (mesaj=="OK")
            {
                List<DtfMaliyet> dtfMaliyets = new List<DtfMaliyet>();
                if (IsTanimiGun1.Text != "")
                {
                    DtfMaliyet dtfMaliyet = new DtfMaliyet(idGun, IsTanimiGun1.Text, mGun1.Text.ConInt(), bGun1.Text, PbGun1.Text, BTutarGun1.Text.ConDouble(), TTutarGun1.Text.ConDouble());
                    dtfMaliyets.Add(dtfMaliyet);
                }
                if (IsTanimiGun2.Text != "")
                {
                    DtfMaliyet dtfMaliyet = new DtfMaliyet(idGun, IsTanimiGun2.Text, mGun2.Text.ConInt(), bGun2.Text, PbGun2.Text, BTutarGun2.Text.ConDouble(), TTutarGun2.Text.ConDouble());
                    dtfMaliyets.Add(dtfMaliyet);
                }
                if (IsTanimiGun3.Text != "")
                {
                    DtfMaliyet dtfMaliyet = new DtfMaliyet(idGun, IsTanimiGun3.Text, mGun3.Text.ConInt(), bGun3.Text, PbGun3.Text, BTutarGun3.Text.ConDouble(), TTutarGun3.Text.ConDouble());
                    dtfMaliyets.Add(dtfMaliyet);
                }
                if (IsTanimiGun4.Text != "")
                {
                    DtfMaliyet dtfMaliyet = new DtfMaliyet(idGun, IsTanimiGun4.Text, mGun4.Text.ConInt(), bGun4.Text, PbGun4.Text, BTutarGun4.Text.ConDouble(), TTutarGun4.Text.ConDouble());
                    dtfMaliyets.Add(dtfMaliyet);
                }
                if (IsTanimiGun5.Text != "")
                {
                    DtfMaliyet dtfMaliyet = new DtfMaliyet(idGun, IsTanimiGun5.Text, mGun5.Text.ConInt(), bGun5.Text, PbGun5.Text, BTutarGun5.Text.ConDouble(), TTutarGun5.Text.ConDouble());
                    dtfMaliyets.Add(dtfMaliyet);
                }
                if (IsTanimiGun6.Text != "")
                {
                    DtfMaliyet dtfMaliyet = new DtfMaliyet(idGun, IsTanimiGun6.Text, mGun6.Text.ConInt(), bGun6.Text, PbGun6.Text, BTutarGun6.Text.ConDouble(), TTutarGun6.Text.ConDouble());
                    dtfMaliyets.Add(dtfMaliyet);
                }
                if (IsTanimiGun7.Text != "")
                {
                    DtfMaliyet dtfMaliyet = new DtfMaliyet(idGun, IsTanimiGun7.Text, mGun7.Text.ConInt(), bGun7.Text, PbGun7.Text, BTutarGun7.Text.ConDouble(), TTutarGun7.Text.ConDouble());
                    dtfMaliyets.Add(dtfMaliyet);
                }

                foreach (DtfMaliyet item in dtfMaliyets)
                {
                    dtfMaliyetManager.Add(item);
                }
            }
        }
        void CreateWordGuncelle()
        {
            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = taslakYolu;

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false);
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;

            wBookmarks["IsAkisNo"].Range.Text = LblIsAkisNoGun.Text;
            wBookmarks["AbfNo"].Range.Text = TxtAbfNoGun.Text;
            wBookmarks["BolgeAdi"].Range.Text = CmbBolgeAdiGun.Text;
            wBookmarks["ProjeKodu"].Range.Text = CmbProjeKoduGun.Text;
            wBookmarks["AltYukleniciFirma"].Range.Text = CmbAltYukleniciFirmaGun.Text;
            wBookmarks["GarantiDurumu"].Range.Text = CmbGarantiDurumuGun.Text;
            wBookmarks["FirmaSorumlusu"].Range.Text = LblFirmaSorumlusuGun.Text;
            wBookmarks["StokNo"].Range.Text = LblStokNoGun.Text;
            wBookmarks["Tanim"].Range.Text = CmbTanimGun.Text;
            wBookmarks["ButceKodu"].Range.Text = CmbHarcamaKoduGun.Text;
            wBookmarks["SeriNo"].Range.Text = TxtSeriNoGun.Text;
            if (CmbOnarimYeriGun.Text == "YERİNDE ONARIM")
            {
                wBookmarks["YerindeOnarim"].Range.Text = "X";
            }
            else
            {
                wBookmarks["FirmadaOnarim"].Range.Text = "X";
            }
            wBookmarks["IsinTanimi"].Range.Text = TxtIsinTanimiGun.Text;
            wBookmarks["TalebiOlusturan"].Range.Text = LblAdSoyadGun.Text;
            wBookmarks["IsinVerildigiTarih"].Range.Text = DtgIsinVerildigiTarihGun.Value.ToString("dd/MM/yyyy");
            wBookmarks["Tarih"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
            wBookmarks["Tarih2"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");

            if (IsTanimiGun1.Text != "")
            {
                wBookmarks["S1"].Range.Text = "1";
                wBookmarks["IsTanim1"].Range.Text = IsTanimiGun1.Text;
                wBookmarks["Miktar1"].Range.Text = mGun1.Text;
                wBookmarks["Birim1"].Range.Text = bGun1.Text;
                wBookmarks["BT1"].Range.Text = BTutarGun1.Text;
                wBookmarks["TT1"].Range.Text = TTutarGun1.Text;
            }
            if (IsTanimiGun2.Text != "")
            {
                wBookmarks["S2"].Range.Text = "2";
                wBookmarks["IsTanim2"].Range.Text = IsTanimiGun2.Text;
                wBookmarks["Miktar2"].Range.Text = mGun2.Text;
                wBookmarks["Birim2"].Range.Text = bGun2.Text;
                wBookmarks["BT2"].Range.Text = BTutarGun2.Text;
                wBookmarks["TT2"].Range.Text = TTutarGun2.Text;
            }
            if (IsTanimiGun3.Text != "")
            {
                wBookmarks["S3"].Range.Text = "3";
                wBookmarks["IsTanim3"].Range.Text = IsTanimiGun3.Text;
                wBookmarks["Miktar3"].Range.Text = mGun3.Text;
                wBookmarks["Birim3"].Range.Text = bGun3.Text;
                wBookmarks["BT3"].Range.Text = BTutarGun3.Text;
                wBookmarks["TT3"].Range.Text = TTutarGun3.Text;
            }
            if (IsTanimiGun4.Text != "")
            {
                wBookmarks["S4"].Range.Text = "4";
                wBookmarks["IsTanim4"].Range.Text = IsTanimiGun4.Text;
                wBookmarks["Miktar4"].Range.Text = mGun4.Text;
                wBookmarks["Birim4"].Range.Text = bGun4.Text;
                wBookmarks["BT4"].Range.Text = BTutarGun4.Text;
                wBookmarks["TT4"].Range.Text = TTutarGun4.Text;
            }
            if (IsTanimiGun5.Text != "")
            {
                wBookmarks["S5"].Range.Text = "5";
                wBookmarks["IsTanim5"].Range.Text = IsTanimiGun5.Text;
                wBookmarks["Miktar5"].Range.Text = mGun5.Text;
                wBookmarks["Birim5"].Range.Text = bGun5.Text;
                wBookmarks["BT5"].Range.Text = BTutarGun5.Text;
                wBookmarks["TT5"].Range.Text = TTutarGun5.Text;
            }
            if (IsTanimiGun6.Text != "")
            {
                wBookmarks["S6"].Range.Text = "6";
                wBookmarks["IsTanim6"].Range.Text = IsTanimiGun6.Text;
                wBookmarks["Miktar6"].Range.Text = mGun6.Text;
                wBookmarks["Birim6"].Range.Text = bGun6.Text;
                wBookmarks["BT6"].Range.Text = BTutarGun6.Text;
                wBookmarks["TT6"].Range.Text = TTutarGun6.Text;
            }
            if (IsTanimiGun7.Text != "")
            {
                wBookmarks["S7"].Range.Text = "7";
                wBookmarks["IsTanim7"].Range.Text = IsTanimiGun7.Text;
                wBookmarks["Miktar7"].Range.Text = mGun7.Text;
                wBookmarks["Birim7"].Range.Text = bGun7.Text;
                wBookmarks["BT7"].Range.Text = BTutarGun7.Text;
                wBookmarks["TT7"].Range.Text = TTutarGun7.Text;
            }

            wBookmarks["GenelToplam"].Range.Text = TxtGenelTopGun.Text;
            wBookmarks["IseBaslamaTarihi"].Range.Text = DtIsBaslamaTarihiGun.Value.ToString("dd.MM.yyyy");
            wBookmarks["IsBitisTarihi"].Range.Text = DtIsBitisTarihiGun.Value.ToString("dd.MM.yyyy");
            wBookmarks["YapilanIslemler"].Range.Text = TxtYapilanIslemlerGun.Text;

            wDoc.SaveAs2(dosyaYolu + LblIsAkisNoGun.Text + "_" + DateTime.Now.ToString("ss")+ "Up" + ".docx");
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
        private void TTutarGun1_TextChanged(object sender, EventArgs e)
        {
            if (TTutarGun1.Text == "")
            {
                x1 = 0;
                HesaplaGuncelle(PbGun1.Text);
                return;
            }
            x1 = TTutarGun1.Text.ConDouble();
            HesaplaGuncelle(PbGun1.Text);
        }

        private void TTutarGun2_TextChanged(object sender, EventArgs e)
        {
            if (TTutarGun2.Text == "")
            {
                x2 = 0;
                HesaplaGuncelle(PbGun2.Text);
                return;
            }
            x2 = TTutarGun2.Text.ConDouble();
            HesaplaGuncelle(PbGun2.Text);
        }

        private void TTutarGun3_TextChanged(object sender, EventArgs e)
        {
            if (TTutarGun3.Text == "")
            {
                x3 = 0;
                HesaplaGuncelle(PbGun3.Text);
                return;
            }
            x3 = TTutarGun3.Text.ConDouble();
            HesaplaGuncelle(PbGun3.Text);
        }

        private void TTutarGun4_TextChanged(object sender, EventArgs e)
        {
            if (TTutarGun4.Text == "")
            {
                x4 = 0;
                HesaplaGuncelle(PbGun4.Text);
                return;
            }
            x4 = TTutarGun4.Text.ConDouble();
            HesaplaGuncelle(PbGun4.Text);
        }

        private void TTutarGun5_TextChanged(object sender, EventArgs e)
        {
            if (TTutarGun5.Text == "")
            {
                x5 = 0;
                HesaplaGuncelle(PbGun5.Text);
                return;
            }
            x5 = TTutarGun5.Text.ConDouble();
            HesaplaGuncelle(PbGun5.Text);
        }

        private void TTutarGun6_TextChanged(object sender, EventArgs e)
        {
            if (TTutarGun6.Text == "")
            {
                x6 = 0;
                HesaplaGuncelle(PbGun6.Text);
                return;
            }
            x6 = TTutarGun6.Text.ConDouble();
            HesaplaGuncelle(PbGun6.Text);
        }

        private void TTutarGun7_TextChanged(object sender, EventArgs e)
        {
            if (TTutarGun7.Text == "")
            {
                x7 = 0;
                HesaplaGuncelle(PbGun7.Text);
                return;
            }
            x7 = TTutarGun7.Text.ConDouble();
            HesaplaGuncelle(PbGun7.Text);
        }

        void FillTools()
        {
            dtfMaliyets = dtfMaliyetManager.GetList(idGun);
            if (dtfMaliyets == null)
            {
                return;
            }
            if (dtfMaliyets.Count == 0)
            {
                return;
            }
            if (dtfMaliyets.Count > 0)
            {
                IsTanimiGun1.Text = dtfMaliyets[0].IsTanimi;
                mGun1.Text = dtfMaliyets[0].Miktar.ToString();
                bGun1.Text = dtfMaliyets[0].Birim;
                PbGun1.Text = dtfMaliyets[0].PBirimi;
                BTutarGun1.Text = dtfMaliyets[0].BirimTutar.ToString();
                TTutarGun1.Text = dtfMaliyets[0].ToplamTutar.ToString();
            }
            if (dtfMaliyets.Count > 1)
            {
                IsTanimiGun2.Text = dtfMaliyets[1].IsTanimi;
                mGun2.Text = dtfMaliyets[1].Miktar.ToString();
                bGun2.Text = dtfMaliyets[1].Birim;
                PbGun2.Text = dtfMaliyets[1].PBirimi;
                BTutarGun2.Text = dtfMaliyets[1].BirimTutar.ToString();
                TTutarGun2.Text = dtfMaliyets[1].ToplamTutar.ToString();
            }
            if (dtfMaliyets.Count > 2)
            {
                IsTanimiGun3.Text = dtfMaliyets[2].IsTanimi;
                mGun3.Text = dtfMaliyets[2].Miktar.ToString();
                bGun3.Text = dtfMaliyets[2].Birim;
                PbGun3.Text = dtfMaliyets[2].PBirimi;
                BTutarGun3.Text = dtfMaliyets[2].BirimTutar.ToString();
                TTutarGun3.Text = dtfMaliyets[2].ToplamTutar.ToString();
            }
            if (dtfMaliyets.Count > 3)
            {
                IsTanimiGun4.Text = dtfMaliyets[3].IsTanimi;
                mGun4.Text = dtfMaliyets[3].Miktar.ToString();
                bGun4.Text = dtfMaliyets[3].Birim;
                PbGun4.Text = dtfMaliyets[3].PBirimi;
                BTutarGun4.Text = dtfMaliyets[3].BirimTutar.ToString();
                TTutarGun4.Text = dtfMaliyets[3].ToplamTutar.ToString();
            }
            if (dtfMaliyets.Count > 4)
            {
                IsTanimiGun5.Text = dtfMaliyets[4].IsTanimi;
                mGun5.Text = dtfMaliyets[4].Miktar.ToString();
                bGun5.Text = dtfMaliyets[4].Birim;
                PbGun5.Text = dtfMaliyets[4].PBirimi;
                BTutarGun5.Text = dtfMaliyets[4].BirimTutar.ToString();
                TTutarGun5.Text = dtfMaliyets[4].ToplamTutar.ToString();
            }
            if (dtfMaliyets.Count > 5)
            {
                IsTanimiGun6.Text = dtfMaliyets[5].IsTanimi;
                mGun6.Text = dtfMaliyets[5].Miktar.ToString();
                bGun6.Text = dtfMaliyets[5].Birim;
                PbGun6.Text = dtfMaliyets[5].PBirimi;
                BTutarGun6.Text = dtfMaliyets[5].BirimTutar.ToString();
                TTutarGun6.Text = dtfMaliyets[5].ToplamTutar.ToString();
            }
            if (dtfMaliyets.Count > 6)
            {
                IsTanimiGun7.Text = dtfMaliyets[6].IsTanimi;
                mGun7.Text = dtfMaliyets[6].Miktar.ToString();
                bGun7.Text = dtfMaliyets[6].Birim;
                PbGun7.Text = dtfMaliyets[6].PBirimi;
                BTutarGun7.Text = dtfMaliyets[6].BirimTutar.ToString();
                TTutarGun7.Text = dtfMaliyets[6].ToplamTutar.ToString();
            }
        }

        private void BTutarGun1_TextChanged(object sender, EventArgs e)
        {
            TTutarGun1.Text = TopFiyatHesapla(BTutarGun1.Text, mGun1.Text);
        }

        private void BTutarGun2_TextChanged(object sender, EventArgs e)
        {
            TTutarGun2.Text = TopFiyatHesapla(BTutarGun2.Text, mGun2.Text);
        }

        private void BTutarGun3_TextChanged(object sender, EventArgs e)
        {
            TTutarGun3.Text = TopFiyatHesapla(BTutarGun3.Text, mGun3.Text);
        }

        private void BTutarGun4_TextChanged(object sender, EventArgs e)
        {
            TTutarGun4.Text = TopFiyatHesapla(BTutarGun4.Text, mGun4.Text);
        }

        private void BTutarGun5_TextChanged(object sender, EventArgs e)
        {
            TTutarGun5.Text = TopFiyatHesapla(BTutarGun5.Text, mGun5.Text);
        }

        private void BTutarGun6_TextChanged(object sender, EventArgs e)
        {
            TTutarGun6.Text = TopFiyatHesapla(BTutarGun6.Text, mGun6.Text);
        }

        private void BTutarGun7_TextChanged(object sender, EventArgs e)
        {
            TTutarGun7.Text = TopFiyatHesapla(BTutarGun7.Text, mGun7.Text);
        }

        private void mGun1_TextChanged(object sender, EventArgs e)
        {
            BTutarGun1.Text = TopFiyatHesapla(BTutarGun1.Text, mGun1.Text);
        }

        private void mGun2_TextChanged(object sender, EventArgs e)
        {
            BTutarGun2.Text = TopFiyatHesapla(BTutarGun2.Text, mGun2.Text);
        }

        private void mGun3_TextChanged(object sender, EventArgs e)
        {
            BTutarGun3.Text = TopFiyatHesapla(BTutarGun3.Text, mGun3.Text);
        }

        private void mGun4_TextChanged(object sender, EventArgs e)
        {
            BTutarGun4.Text = TopFiyatHesapla(BTutarGun4.Text, mGun4.Text);
        }

        private void mGun5_TextChanged(object sender, EventArgs e)
        {
            BTutarGun5.Text = TopFiyatHesapla(BTutarGun5.Text, mGun5.Text);
        }

        private void mGun6_TextChanged(object sender, EventArgs e)
        {
            BTutarGun6.Text = TopFiyatHesapla(BTutarGun6.Text, mGun6.Text);
        }

        private void mGun7_TextChanged(object sender, EventArgs e)
        {
            BTutarGun7.Text = TopFiyatHesapla(BTutarGun7.Text, mGun7.Text);
        }
        
        private void TxtAbfNo_TextChanged(object sender, EventArgs e)
        {
            if (TxtAbfNo.Text.Length >= 6)
            {
                Dtf dtf = dtfManager.DtfArizaBilgileri(TxtAbfNo.Text.ConInt());
                if (dtf!=null)
                {
                    CmbBolgeAdi.Text = dtf.UsBolgesi;
                    CmbProjeKodu.Text = dtf.ProjeKodu;
                    CmbGarantiDurumu.Text = dtf.GarantiDurumu;
                    CmbIsKategorisi.Text = dtf.IsKategorisi;
                    CmbTanim.Text = dtf.Tanim;
                    TxtSeriNo.Text = dtf.SeriNo;
                    TxtIsinTanimi.Text = dtf.IsTanimi.ToUpper();
                }
            }
        }

        private void TTutar5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TTutar6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TTutar7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void BtnKaydetKO_Click(object sender, EventArgs e)
        {
            string mesaj = MaliyetKontrol();
            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Dtf dtf = new Dtf(id, DtIsBaslamaTarihi.Value, DtIsBitisTarihi.Value, TxtYapilanIslemler.Text);
            mesaj = dtfManager.KontrolOnayGuncelle(dtf);

            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            YaklasikMaliyetKayit();
            CreateWordKO();
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TemizleKO();
        }
        void CreateWordKO()
        {
            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = dosyaYolu + isAkisNo + ".docx";

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false);
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            if (IsTanimi1.Text!="")
            {
                wBookmarks["S1"].Range.Text = "1";
                wBookmarks["IsTanim1"].Range.Text = IsTanimi1.Text;
                wBookmarks["Miktar1"].Range.Text = m1.Text;
                wBookmarks["Birim1"].Range.Text = b1.Text;
                wBookmarks["BT1"].Range.Text = BTutar1.Text;
                wBookmarks["TT1"].Range.Text = TTutar1.Text;
            }
            if (IsTanimi2.Text != "")
            {
                wBookmarks["S2"].Range.Text = "2";
                wBookmarks["IsTanim2"].Range.Text = IsTanimi2.Text;
                wBookmarks["Miktar2"].Range.Text = m2.Text;
                wBookmarks["Birim2"].Range.Text = b2.Text;
                wBookmarks["BT2"].Range.Text = BTutar2.Text;
                wBookmarks["TT2"].Range.Text = TTutar2.Text;
            }
            if (IsTanimi3.Text != "")
            {
                wBookmarks["S3"].Range.Text = "3";
                wBookmarks["IsTanim3"].Range.Text = IsTanimi3.Text;
                wBookmarks["Miktar3"].Range.Text = m3.Text;
                wBookmarks["Birim3"].Range.Text = b3.Text;
                wBookmarks["BT3"].Range.Text = BTutar3.Text;
                wBookmarks["TT3"].Range.Text = TTutar3.Text;
            }
            if (IsTanimi4.Text != "")
            {
                wBookmarks["S4"].Range.Text = "4";
                wBookmarks["IsTanim4"].Range.Text = IsTanimi4.Text;
                wBookmarks["Miktar4"].Range.Text = m4.Text;
                wBookmarks["Birim4"].Range.Text = b4.Text;
                wBookmarks["BT4"].Range.Text = BTutar4.Text;
                wBookmarks["TT4"].Range.Text = TTutar4.Text;
            }
            if (IsTanimi5.Text != "")
            {
                wBookmarks["S5"].Range.Text = "5";
                wBookmarks["IsTanim5"].Range.Text = IsTanimi5.Text;
                wBookmarks["Miktar5"].Range.Text = m5.Text;
                wBookmarks["Birim5"].Range.Text = b5.Text;
                wBookmarks["BT5"].Range.Text = BTutar5.Text;
                wBookmarks["TT5"].Range.Text = TTutar5.Text;
            }
            if (IsTanimi6.Text != "")
            {
                wBookmarks["S6"].Range.Text = "6";
                wBookmarks["IsTanim6"].Range.Text = IsTanimi6.Text;
                wBookmarks["Miktar6"].Range.Text = m6.Text;
                wBookmarks["Birim6"].Range.Text = b6.Text;
                wBookmarks["BT6"].Range.Text = BTutar6.Text;
                wBookmarks["TT6"].Range.Text = TTutar6.Text;
            }
            if (IsTanimi7.Text != "")
            {
                wBookmarks["S7"].Range.Text = "7";
                wBookmarks["IsTanim7"].Range.Text = IsTanimi7.Text;
                wBookmarks["Miktar7"].Range.Text = m7.Text;
                wBookmarks["Birim7"].Range.Text = b7.Text;
                wBookmarks["BT7"].Range.Text = BTutar7.Text;
                wBookmarks["TT7"].Range.Text = TTutar7.Text;
            }

            wBookmarks["GenelToplam"].Range.Text = TxtGenelTop.Text;
            wBookmarks["IseBaslamaTarihi"].Range.Text = DtIsBaslamaTarihi.Value.ToString("dd.MM.yyyy");
            wBookmarks["IsBitisTarihi"].Range.Text = DtIsBitisTarihi.Value.ToString("dd.MM.yyyy");
            wBookmarks["YapilanIslemler"].Range.Text = TxtYapilanIslemler.Text;

            wDoc.SaveAs2(dosyaYolu + isAkisNo.ToString() + "_" + DateTime.Now.ToString("dd") + ".docx");
            wDoc.Close();
            wApp.Quit(false);

        }
        void YaklasikMaliyetKayit()
        {
            List<DtfMaliyet> dtfMaliyets = new List<DtfMaliyet>();
            if (IsTanimi1.Text!="")
            {
                DtfMaliyet dtfMaliyet = new DtfMaliyet(id, IsTanimi1.Text, m1.Text.ConInt(), b1.Text, Pb1.Text, BTutar1.Text.ConDouble(), TTutar1.Text.ConDouble());
                dtfMaliyets.Add(dtfMaliyet);
            }
            if (IsTanimi2.Text != "")
            {
                DtfMaliyet dtfMaliyet = new DtfMaliyet(id, IsTanimi2.Text, m2.Text.ConInt(), b2.Text, Pb2.Text, BTutar2.Text.ConDouble(), TTutar2.Text.ConDouble());
                dtfMaliyets.Add(dtfMaliyet);
            }
            if (IsTanimi3.Text != "")
            {
                DtfMaliyet dtfMaliyet = new DtfMaliyet(id, IsTanimi3.Text, m3.Text.ConInt(), b3.Text, Pb3.Text, BTutar3.Text.ConDouble(), TTutar3.Text.ConDouble());
                dtfMaliyets.Add(dtfMaliyet);
            }
            if (IsTanimi4.Text != "")
            {
                DtfMaliyet dtfMaliyet = new DtfMaliyet(id, IsTanimi4.Text, m4.Text.ConInt(), b4.Text, Pb4.Text, BTutar4.Text.ConDouble(), TTutar4.Text.ConDouble());
                dtfMaliyets.Add(dtfMaliyet);
            }
            if (IsTanimi5.Text != "")
            {
                DtfMaliyet dtfMaliyet = new DtfMaliyet(id, IsTanimi5.Text, m5.Text.ConInt(), b5.Text, Pb5.Text, BTutar5.Text.ConDouble(), TTutar5.Text.ConDouble());
                dtfMaliyets.Add(dtfMaliyet);
            }
            if (IsTanimi6.Text != "")
            {
                DtfMaliyet dtfMaliyet = new DtfMaliyet(id, IsTanimi6.Text, m6.Text.ConInt(), b6.Text, Pb6.Text, BTutar6.Text.ConDouble(), TTutar6.Text.ConDouble());
                dtfMaliyets.Add(dtfMaliyet);
            }
            if (IsTanimi7.Text != "")
            {
                DtfMaliyet dtfMaliyet = new DtfMaliyet(id, IsTanimi7.Text, m7.Text.ConInt(), b7.Text, Pb7.Text, BTutar7.Text.ConDouble(), TTutar7.Text.ConDouble());
                dtfMaliyets.Add(dtfMaliyet);
            }
            foreach (DtfMaliyet item in dtfMaliyets)
            {
                dtfMaliyetManager.Add(item);
            }
        }

        string MaliyetKontrol()
        {
            if (LblKayitTarihiKO.Text == "00")
            {
                return "Lütfen Geçerli Bir İş Akış No Yazarak Bul Butonuna basınız!";
            }
            if (IsTanimi1.Text=="")
            {
                return "Lütfen en az bir tane Yaklaşık Maliyet Bilgisini eksiksiz doldurunuz!";
            }
            if (m1.Text=="")
            {
                return "Lütfen en az bir tane Yaklaşık Maliyet Bilgisini eksiksiz doldurunuz!";
            }
            if (b1.Text=="")
            {
                return "Lütfen en az bir tane Yaklaşık Maliyet Bilgisini eksiksiz doldurunuz!";
            }
            if (Pb1.Text == "")
            {
                return "Lütfen en az bir tane Yaklaşık Maliyet Bilgisini eksiksiz doldurunuz!";
            }
            if (BTutar1.Text == "")
            {
                return "Lütfen en az bir tane Yaklaşık Maliyet Bilgisini eksiksiz doldurunuz!";
            }
            if (IsTanimi2.Text!="" || m2.Text!="")
            {
                if (m2.Text=="")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 2. verinin Miktar bilgisini doldurunuz!";
                }
                if (Pb2.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 2. verinin Para Birimi bilgisini doldurunuz!";
                }
                if (BTutar2.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 2. verinin Birim Tutar bilgisini doldurunuz!";
                }
            }
            if (IsTanimi3.Text != "" || m3.Text != "")
            {
                if (m3.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 3. verinin Miktar bilgisini doldurunuz!";
                }
                if (Pb3.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 3. verinin Para Birimi bilgisini doldurunuz!";
                }
                if (BTutar3.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 3. verinin Birim Tutar bilgisini doldurunuz!";
                }
            }
            if (IsTanimi4.Text != "" || m4.Text != "")
            {
                if (m4.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 4. verinin Miktar bilgisini doldurunuz!";
                }
                if (Pb4.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 4. verinin Para Birimi bilgisini doldurunuz!";
                }
                if (BTutar4.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 4. verinin Birim Tutar bilgisini doldurunuz!";
                }
            }
            if (IsTanimi5.Text != "" || m5.Text != "")
            {
                if (m5.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 5. verinin Miktar bilgisini doldurunuz!";
                }
                if (Pb5.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 5. verinin Para Birimi bilgisini doldurunuz!";
                }
                if (BTutar5.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 5. verinin Birim Tutar bilgisini doldurunuz!";
                }
            }
            if (IsTanimi6.Text != "" || m6.Text != "")
            {
                if (m6.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 6. verinin Miktar bilgisini doldurunuz!";
                }
                if (Pb6.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 6. verinin Para Birimi bilgisini doldurunuz!";
                }
                if (BTutar6.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 6. verinin Birim Tutar bilgisini doldurunuz!";
                }
            }
            if (IsTanimi7.Text != "" || m7.Text != "")
            {
                if (m7.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 7. verinin Miktar bilgisini doldurunuz!";
                }
                if (Pb7.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 7. verinin Para Birimi bilgisini doldurunuz!";
                }
                if (BTutar7.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 7. verinin Birim Tutar bilgisini doldurunuz!";
                }
            }
            if (TxtYapilanIslemler.Text=="")
            {
                return "Lütfen Yapılan İşlemler bilgisini doldurunuz!";
            }
            
            return "OK";
        }
        string MaliyetKontrolGuncelle()
        {
            if (LblKayitTarihiGun.Text == "00")
            {
                return "Lütfen Geçerli Bir İş Akış No Yazarak Bul Butonuna basınız!";
            }
            if (IsTanimiGun1.Text == "")
            {
                return "Lütfen en az bir tane Yaklaşık Maliyet Bilgisini eksiksiz doldurunuz!";
            }
            if (mGun1.Text == "")
            {
                return "Lütfen en az bir tane Yaklaşık Maliyet Bilgisini eksiksiz doldurunuz!";
            }
            if (bGun1.Text == "")
            {
                return "Lütfen en az bir tane Yaklaşık Maliyet Bilgisini eksiksiz doldurunuz!";
            }
            if (PbGun1.Text == "")
            {
                return "Lütfen en az bir tane Yaklaşık Maliyet Bilgisini eksiksiz doldurunuz!";
            }
            if (BTutarGun1.Text == "")
            {
                return "Lütfen en az bir tane Yaklaşık Maliyet Bilgisini eksiksiz doldurunuz!";
            }
            if (IsTanimiGun2.Text != "" || mGun2.Text != "")
            {
                if (mGun2.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 2. verinin Miktar bilgisini doldurunuz!";
                }
                if (PbGun2.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 2. verinin Para Birimi bilgisini doldurunuz!";
                }
                if (BTutarGun2.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 2. verinin Birim Tutar bilgisini doldurunuz!";
                }
            }
            if (IsTanimiGun3.Text != "" || mGun3.Text != "")
            {
                if (mGun3.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 3. verinin Miktar bilgisini doldurunuz!";
                }
                if (PbGun3.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 3. verinin Para Birimi bilgisini doldurunuz!";
                }
                if (BTutarGun3.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 3. verinin Birim Tutar bilgisini doldurunuz!";
                }
            }
            if (IsTanimiGun4.Text != "" || mGun4.Text != "")
            {
                if (mGun4.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 4. verinin Miktar bilgisini doldurunuz!";
                }
                if (PbGun4.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 4. verinin Para Birimi bilgisini doldurunuz!";
                }
                if (BTutarGun4.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 4. verinin Birim Tutar bilgisini doldurunuz!";
                }
            }
            if (IsTanimiGun5.Text != "" || mGun5.Text != "")
            {
                if (mGun5.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 5. verinin Miktar bilgisini doldurunuz!";
                }
                if (PbGun5.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 5. verinin Para Birimi bilgisini doldurunuz!";
                }
                if (BTutarGun5.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 5. verinin Birim Tutar bilgisini doldurunuz!";
                }
            }
            if (IsTanimiGun6.Text != "" || mGun6.Text != "")
            {
                if (mGun6.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 6. verinin Miktar bilgisini doldurunuz!";
                }
                if (PbGun6.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 6. verinin Para Birimi bilgisini doldurunuz!";
                }
                if (BTutarGun6.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 6. verinin Birim Tutar bilgisini doldurunuz!";
                }
            }
            if (IsTanimiGun7.Text != "" || mGun7.Text != "")
            {
                if (mGun7.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 7. verinin Miktar bilgisini doldurunuz!";
                }
                if (PbGun7.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 7. verinin Para Birimi bilgisini doldurunuz!";
                }
                if (BTutarGun7.Text == "")
                {
                    return "Lütfen Yaklaşık Maliyet Tablosunda ki 7. verinin Birim Tutar bilgisini doldurunuz!";
                }
            }

            return "OK";
        }

    }
}
