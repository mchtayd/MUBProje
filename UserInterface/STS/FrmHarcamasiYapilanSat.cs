using Business;
using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using DataAccess.Concreate.STS;
using Entity;
using Entity.AnaSayfa;
using Entity.IdariIsler;
using Entity.STS;
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
using UserInterface.IdariIsler;

namespace UserInterface.STS
{
    public partial class FrmHarcamasiYapilanSat : Form
    {
        ButceKoduKalemiManager butceKoduKalemiManager;
        IsAkisNoManager isAkisNoManager;
        PersonelKayitManager kayitManager;
        SatDataGridview1Manager satDataGridview1Manager;
        TeklifsizSatManager teklifsizSatManager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        SatNoManager satNoManager;
        BildirimYetkiManager bildirimYetkiManager;
        ComboManager comboManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;

        public object[] infos;
        int index, satNo, comboId;
        string isAkisNoBasaran, dosyaYoluTemsili, kaynakdosyaismi, alinandosya, siparisNo, isleAdimi, islem, comboAd;
        bool start, dosyaEkleTemsili = false;
        public FrmHarcamasiYapilanSat()
        {
            InitializeComponent();
            butceKoduKalemiManager = ButceKoduKalemiManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            teklifsizSatManager = TeklifsizSatManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageHarcamasıYapilan"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void FrmHarcamasiYapilanSat_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            ButceKoduKalemi();
            Personeller();
            ButceTanim();
            MaliyetTuru();
            LblSatTarihi.Text = DateTime.Now.ToString("d");
            start = true;
        }
        public void ButceKoduKalemi()
        {
            Entity.IdariIsler.ButceKodu butceKodu = butceKoduKalemiManager.ButceKoduComboBilgiList("HARCAMASI YAPILAN SAT");
            comboId = butceKodu.Id;
            List<Entity.IdariIsler.ButceKodu> butceKodus = new List<Entity.IdariIsler.ButceKodu>();
            List<Entity.IdariIsler.ButceKodu> butceKodus2 = new List<Entity.IdariIsler.ButceKodu>();
            butceKodus = butceKoduKalemiManager.GetList();
            foreach (Entity.IdariIsler.ButceKodu item in butceKodus)
            {
                string[] comboIdler = item.ComboId.Split(';');
                if (comboIdler.Length==0 || comboIdler.Length == 1)
                {
                    continue;
                }
                foreach (string item2 in comboIdler)
                {
                    if (item2.ConInt() == comboId)
                    {
                        butceKodus2.Add(item);
                    }
                }
            }

            CmbButceKodu.DataSource = butceKodus2;
            CmbButceKodu.ValueMember = "Id";
            CmbButceKodu.DisplayMember = "ButceKoduKalemi";
            CmbButceKodu.SelectedValue = 0;
        }

        public void ButceTanim()
        {
            CmbButceTanimi.DataSource = comboManager.GetList("BUTCE_TANIM");
            CmbButceTanimi.ValueMember = "Id";
            CmbButceTanimi.DisplayMember = "Baslik";
            CmbButceTanimi.SelectedValue = 0;
        }
        public void MaliyetTuru()
        {
            CmbMaliyetTuru.DataSource = comboManager.GetList("MALİYET_TURU");
            CmbMaliyetTuru.ValueMember = "Id";
            CmbMaliyetTuru.DisplayMember = "Baslik";
            CmbMaliyetTuru.SelectedValue = 0;
        }


        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            FrmButceKoduKalemi frmButceKoduKalemi = new FrmButceKoduKalemi();
            frmButceKoduKalemi.Show();
        }

        private void TxtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void CmbFaturaFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbFaturaFirma.SelectedIndex;
            CmbIlgiliKisi.SelectedIndex = index;
            CmbMasYeri.SelectedIndex = index;
        }

        private void BtnMaliyetEkle_Click(object sender, EventArgs e)
        {
            comboAd = "MALİYET_TURU";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void CmbButceTanimi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbButceTanimi.Text == "DEĞİŞKEN GİDER")
            {
                CmbMaliyetTuru.Text = "PROJE MALİYET";
            }
            if (CmbButceTanimi.Text == "HAKEDİŞ")
            {
                CmbMaliyetTuru.Text = "FİNANSMAN GİDERİ";
            }
            if (CmbButceTanimi.Text == "SABİT GİDER")
            {
                CmbMaliyetTuru.Text = "SAT GİDERİ";
            }
            if (CmbButceTanimi.Text=="")
            {
                CmbMaliyetTuru.Text = "";
            }
        }

        private void CmbButceKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbButceKodu.Text== "BM25/PERSONEL MAAŞ GİDERLERİ")
            {
                CmbButceTanimi.Text = "SABİT GİDER";
            }
            if (CmbButceKodu.Text == "BM45/PERSONEL MAAŞ YANSIMASI")
            {
                CmbButceTanimi.Text = "SABİT GİDER";
            }
            if (CmbButceKodu.Text == "PERSONEL SAHA TAZMİNAT GİDERLERİ")
            {
                CmbButceTanimi.Text = "SABİT GİDER";
            }
            if (CmbButceKodu.Text == "BM47/PERSONEL KIDEM GİDERLERİ")
            {
                CmbButceTanimi.Text = "SABİT GİDER";
            }
            if (CmbButceKodu.Text == "BM21/PERSONEL İAŞE GİDERLERİ")
            {
                CmbButceTanimi.Text = "SABİT GİDER";
            }
            if (CmbButceKodu.Text == "BM24/PERSONEL İLETİŞİM GİDERLERİ")
            {
                CmbButceTanimi.Text = "SABİT GİDER";
            }
            if (CmbButceKodu.Text == "BM23/PERSONEL ÖZEL SİGRT. GİDERLERİ")
            {
                CmbButceTanimi.Text = "SABİT GİDER";
            }
            if (CmbButceKodu.Text == "BM26/ARAÇ TAHSİS GİDERLERİ")
            {
                CmbButceTanimi.Text = "SABİT GİDER";
            }
            if (CmbButceKodu.Text == "BM30/AKARYAKIT, ANLAŞMALI PETROL")
            {
                CmbButceTanimi.Text = "SABİT GİDER";
            }
            if (CmbButceKodu.Text == "BM13/AKARYAKIT, TAŞIT TANIMA")
            {
                CmbButceTanimi.Text = "SABİT GİDER";
            }
            if (CmbButceKodu.Text == "BM32/AKARYAKIT, NAKİT")
            {
                CmbButceTanimi.Text = "SABİT GİDER";
            }
            if (CmbButceKodu.Text == "BM32/AKARYAKIT, NAKİT")
            {
                CmbButceTanimi.Text = "SABİT GİDER";
            }
            if (CmbButceKodu.Text == "BM32/AKARYAKIT, NAKİT")
            {
                CmbButceTanimi.Text = "SABİT GİDER";
            }

            if (CmbButceKodu.Text == "BM08/KONAKLAMA")
            {
                CmbButceTanimi.Text = "HAKEDİŞ";
            }
            if (CmbButceKodu.Text == "BM09/TEMSİL AĞIRLAMA (ASL)")
            {
                CmbButceTanimi.Text = "HAKEDİŞ";
            }
            if (CmbButceKodu.Text == "BM10/ARAÇ, VİNÇ VB. KİRALAMA")
            {
                CmbButceTanimi.Text = "HAKEDİŞ";
            }
            if (CmbButceKodu.Text == "BM11/YAKIT, DİĞER")
            {
                CmbButceTanimi.Text = "HAKEDİŞ";
            }
            if (CmbButceKodu.Text == "BM15/YURT İÇİ SEYAHAT")
            {
                CmbButceTanimi.Text = "HAKEDİŞ";
            }
            if (CmbButceKodu.Text == "BM19/KARGO TAŞIMACILIK")
            {
                CmbButceTanimi.Text = "HAKEDİŞ";
            }
            if (CmbButceKodu.Text == "BM28/İŞ AVANSLARI")
            {
                CmbButceTanimi.Text = "HAKEDİŞ";
            }
            if (CmbButceKodu.Text == "BM39/YURT DIŞI SEYEHAT")
            {
                CmbButceTanimi.Text = "HAKEDİŞ";
            }
            if (CmbButceKodu.Text == "BM40/PROJE DIŞI DESTEK ÇALIŞMALARI")
            {
                CmbButceTanimi.Text = "HAKEDİŞ";
            }
            if (CmbButceKodu.Text == "BM40/PROJE DIŞI DESTEK ÇALIŞMALARI")
            {
                CmbButceTanimi.Text = "HAKEDİŞ";
            }

            if (CmbButceKodu.Text == "BM16/TEMSİL AĞIRLAMA (BSRN)")
            {
                CmbButceTanimi.Text = "DEĞİŞKEN GİDER";
            }

            if (CmbButceKodu.Text == "")
            {
                CmbButceTanimi.Text = "";
            }
        }

        private void detayGörToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmButceKoduKalemi frmButceKoduKalemi = new FrmButceKoduKalemi();
            frmButceKoduKalemi.Show();
        }

        private void BtnButceDuzenle_Click(object sender, EventArgs e)
        {
            FrmButceKoduKalemiDuzenle frmButceKoduKalemi = new FrmButceKoduKalemiDuzenle();
            frmButceKoduKalemi.PnlKayit.Enabled = false;
            frmButceKoduKalemi.BtnCancel.Visible = false;
            frmButceKoduKalemi.BtnKaydet.Enabled = false;
            frmButceKoduKalemi.BtnSil.Enabled = false;
            frmButceKoduKalemi.BtnTemizle.Enabled = false;
            frmButceKoduKalemi.comboId = comboId;
            frmButceKoduKalemi.ShowDialog();
        }

        private void BtnButceTanimEkle_Click(object sender, EventArgs e)
        {
            comboAd = "BUTCE_TANIM";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (dosyaEkleTemsili == false)
            {
                MessageBox.Show("Lütfen Öncekle Dosya Ekleme İşlemini Gerçekleştiriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string kontrol = Control();
            if (kontrol!="OK")
            {
                MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }
            IsAkisNo();
            siparisNo = Guid.NewGuid().ToString();
            isleAdimi = "SAT ONAY";
            string donem = CmbDonemBasaran.Text + " " + CmbDonemBasaranYil.Text;
            satNo = satNoManager.Add(new SatNo(siparisNo));
            SatDataGridview1 sat = new SatDataGridview1(satNo, LblIsAkisNo.Text.ConInt(), LblMasrafYeriNo.Text, CmbAdSoyad.Text, LblMasrafYeri.Text, "YOK", "0", LblSatTarihi.Text.ConDate(), TxtAciklama.Text, siparisNo, CmbAdSoyad.Text, LblSiparisNo.Text, LblUnvani.Text, LblMasrafYeriNo.Text, LblMasrafYeri.Text,
                  string.IsNullOrEmpty(dosyaYoluTemsili) ? "" : dosyaYoluTemsili, infos[0].ConInt(), isleAdimi, donem, "HARCAMASI YAPILAN", LblProje.Text, TxtSatinAlinanFirma.Text, CmbButceTanimi.Text, CmbMaliyetTuru.Text);
            string mesaj = satDataGridview1Manager.Add(sat);
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SatDataGridview1 satData = new SatDataGridview1(CmbButceKodu.Text, CmbSatBirim.Text, CmbHarcamaTuru.Text, CmbFaturaFirma.Text, CmbIlgiliKisi.Text, CmbMasYeri.Text, siparisNo, 0, CmbBelgeTuru.Text, TxtBelgeNumarasi.Text, DtBelgeTarihi.Value, isleAdimi, donem);

            string mesaj2 = satDataGridview1Manager.TemsiliAgirlama(satData);

            if (mesaj2 != "OK")
            {
                MessageBox.Show(mesaj2, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            satDataGridview1Manager.TeklifDurum(siparisNo, string.IsNullOrEmpty(dosyaYoluTemsili) ? "" : dosyaYoluTemsili, "SAT ONAY BAŞARAN"); // ALINDI
            satDataGridview1Manager.DurumGuncelleOnay(siparisNo); // SAT BAŞLATMA ONAYI ONAYLANDI

            TeklifsizSat teklifsizSat = new TeklifsizSat("", "", 0, "", TxtTutar.Text.ConDouble(), siparisNo);
            string mesaj3 = teklifsizSatManager.Add(teklifsizSat);

            if (mesaj3 != "OK")
            {
                MessageBox.Show(mesaj3, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            islem = "SATIN ALMA TALEBİ OLUŞTURULDU.";
            SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, islem, infos[1].ToString(), DateTime.Now);
            satIslemAdimlariManager.Add(satIslem);

            //string bildirim = BildirimKayit();
            //if (bildirim != "OK")
            //{
            //    MessageBox.Show(bildirim, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            SatDataGridview1 satDataGridview1 = satDataGridview1Manager.Get(LblIsAkisNo.Text);
            satId = satDataGridview1.Id;
            GorevAtama();
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            IsAkisNo();
            Temizle();
            satId = 0;
        }
        int satId = 0;
        string GorevAtama()
        {
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(satId, "SATIN ALMA", "RESUL GÜNEŞ", "SAT ONAYI", DateTime.Now, "", DateTime.Now.Date);
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

            array[0] = "Sat Talebi"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = LblIsAkisNo.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "iş akış numaralı Harcaması Yapılan"; // Bildirim türü
            array[4] = "Sat Kaydını oluşturmuştur!"; // İÇERİK
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
        void Temizle()
        {
            CmbButceKodu.SelectedIndex = -1; TxtTutar.Clear(); CmbBelgeTuru.SelectedIndex = -1; TxtBelgeNumarasi.Clear(); TxtSatinAlinanFirma.Clear();
            CmbSatBirim.SelectedIndex = -1; CmbHarcamaTuru.SelectedIndex = -1; CmbFaturaFirma.SelectedIndex = -1; TxtAciklama.Clear(); webBrowser2.Navigate("");
            CmbAdSoyad.SelectedIndex = -1; LblSatTarihi.Text = DateTime.Now.ToString("d"); CmbDonemBasaran.SelectedIndex = -1; 
            CmbDonemBasaranYil.SelectedIndex = -1; CmbButceTanimi.SelectedIndex = -1; CmbMaliyetTuru.SelectedIndex = -1;
        }

        private void CmbAdSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            PersonelKayit siparis = kayitManager.Get(0, CmbAdSoyad.Text);
            if (siparis != null)
            {
                LblSiparisNo.Text = siparis.Siparis;
                LblMasrafYeriNo.Text = siparis.Masyerino;
                LblMasrafYeri.Text = siparis.Masrafyeri;
                LblUnvani.Text = siparis.Isunvani;
                LblProje.Text = siparis.ProjeKodu;
            }
            else
            {
                LblSiparisNo.Text = "00";
                LblMasrafYeriNo.Text = "00";
                LblMasrafYeri.Text = "00";
                LblUnvani.Text = "00";
                LblProje.Text = "00";
            }

        }

        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            IsAkisNo();
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            isAkisNoBasaran = LblIsAkisNo.Text;

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYoluTemsili = subdir + isAkisNoBasaran;
            Directory.CreateDirectory(dosyaYoluTemsili);

            Directory.CreateDirectory(dosyaYoluTemsili);
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

            if (File.Exists(dosyaYoluTemsili + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYoluTemsili + "\\" + kaynakdosyaismi);
                webBrowser2.Navigate(dosyaYoluTemsili);
                dosyaEkleTemsili = true;
            }
        }

        void Personeller()
        {
            CmbAdSoyad.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Adsoyad";
            CmbAdSoyad.SelectedValue = -1;
        }
        string Control()
        {
            if (CmbButceKodu.Text=="")
            {
                return "Lütfen öncelikle Bütçe Kodu bilgisini doldurunuz!";
            }
            if (TxtTutar.Text=="")
            {
                return "Lütfen öncelikle Harcanan Tutar bilgisini doldurunuz!";
            }
            if (CmbBelgeTuru.Text == "")
            {
                return "Lütfen öncelikle Belge Türü bilgisini doldurunuz!";
            }
            if (TxtBelgeNumarasi.Text == "")
            {
                return "Lütfen öncelikle Belge Numarası bilgisini doldurunuz!";
            }
            if (CmbSatBirim.Text == "")
            {
                return "Lütfen öncelikle Satın Alma Yapacak Birim bilgisini doldurunuz!";
            }
            if (CmbHarcamaTuru.Text == "")
            {
                return "Lütfen öncelikle Harcama Türü bilgisini doldurunuz!";
            }
            if (CmbFaturaFirma.Text == "")
            {
                return "Lütfen öncelikle Fatura Edilecek Firma bilgisini doldurunuz!";
            }
            if (CmbAdSoyad.Text == "")
            {
                return "Lütfen öncelikle Talep Eden Personel bilgisini doldurunuz!";
            }
            return "OK";
        }
    }
}
