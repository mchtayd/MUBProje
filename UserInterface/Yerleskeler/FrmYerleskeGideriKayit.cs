using Business;
using Business.Concreate;
using Business.Concreate.STS;
using Business.Concreate.Yerleskeler;
using DataAccess.Concreate;
using DataAccess.Concreate.STS;
using DocumentFormat.OpenXml.Drawing;
using Entity;
using Entity.STS;
using Entity.Yerleskeler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.Yerleskeler
{
    public partial class FrmYerleskeGideriKayit : Form
    {
        bool dosyaKontrol;
        string isAkisNo, dosyaYolu, kaynakdosyaismi, alinandosya, siparisNo, isleAdimi, islem;
        int satNo, index, satId;
        public object[] infos;
        List<string> fileNames = new List<string>();

        KiraManager kiraManager;
        YerleskeManager yerleskeManager;
        IsAkisNoManager isAkisNoManager;
        SatDataGridview1Manager satDataGridview1Manager;
        ComboManager comboManager;
        SatNoManager satNoManager;
        TeklifsizSatManager teklifsizSatManager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        YerleskeSatManager yerleskeSatManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        public FrmYerleskeGideriKayit()
        {
            InitializeComponent();
            kiraManager = KiraManager.GetInstance();
            yerleskeManager = YerleskeManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            comboManager = ComboManager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            teklifsizSatManager = TeklifsizSatManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            yerleskeSatManager = YerleskeSatManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
        }

        private void FrmYerleskeGideriKayit_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            YerleskeAdlari();
            ComboProje();
            ButceTanim();
            MaliyetTuru();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYerleskeGideriKayit"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
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

        public void ComboProje()
        {
            CmbProjeKodu.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProjeKodu.ValueMember = "Id";
            CmbProjeKodu.DisplayMember = "Baslik";
            CmbProjeKodu.SelectedValue = 0;
        }

        private void TxtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
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
            if (CmbButceTanimi.Text == "")
            {
                CmbMaliyetTuru.Text = "";
            }
        }

        private void CmbFaturaFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFaturaFirma.SelectedIndex==-1)
            {
                CmbIlgiliKisi.SelectedIndex = -1;
                CmbMasYeri.SelectedIndex = -1;
            }
            else
            {
                index = CmbFaturaFirma.SelectedIndex;
                CmbIlgiliKisi.SelectedIndex = index;
                CmbMasYeri.SelectedIndex = index;
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (CmbYerleskeAdi.SelectedIndex==-1)
            {
                return;
            }
            if (dosyaKontrol == false)
            {
                MessageBox.Show("Lütfen Öncekle Dosya Ekleme İşlemini Gerçekleştiriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string kontrol = Control();
            if (kontrol != "OK")
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
            string donem = CmbDonemAy.Text + " " + CmbDonemYil.Text;
            satNo = satNoManager.Add(new SatNo(siparisNo));
            string aciklama = TxtAciklama.Text;
            SatDataGridview1 sat = new SatDataGridview1(satNo, LblIsAkisNo.Text.ConInt(), infos[4].ToString(), infos[1].ToString(),
                        infos[2].ToString(), "YOK", "0", DtgTarih.Text.ConDate(), aciklama, siparisNo, "", "", "", "", "",
                  string.IsNullOrEmpty(dosyaYolu) ? "" : dosyaYolu, infos[0].ConInt(), isleAdimi, donem, "YERLEŞKE GİDERİ", CmbProjeKodu.Text, TxtHizmetAlinanKurum.Text, CmbButceTanimi.Text, CmbMaliyetTuru.Text);
            string mesaj = satDataGridview1Manager.Add(sat);
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SatDataGridview1 satData = new SatDataGridview1("BM12/YERLEŞKE GİDERLERİ", CmbSatBirim.Text, CmbHarcamaTuru.Text, CmbFaturaFirma.Text, CmbIlgiliKisi.Text, CmbMasYeri.Text, siparisNo, 0, "FATURA", TxtTesisatNo.Text, DtgTarih.Value, isleAdimi, donem);

            string mesaj2 = satDataGridview1Manager.TemsiliAgirlama(satData);

            if (mesaj2 != "OK")
            {
                MessageBox.Show(mesaj2, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            satDataGridview1Manager.TeklifDurum(siparisNo, string.IsNullOrEmpty(dosyaYolu) ? "" : dosyaYolu, "SAT ONAY BAŞARAN"); // ALINDI
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

            YerleskeSat yerleskeSat = new YerleskeSat(LblIsAkisNo.Text.ConInt(), satNo, CmbYerleskeAdi.Text, CmbGiderTuru.Text, TxtAdres.Text, TxtHizmetAlinanKurum.Text, TxtTesisatNo.Text, DtgTarih.Value, donem, TxtTutar.Text.ConDouble(), dosyaYolu, siparisNo);

            mesaj = yerleskeSatManager.Add(yerleskeSat);
            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SatDataGridview1 satDataGridview1 = satDataGridview1Manager.Get(LblIsAkisNo.Text);
            satId = satDataGridview1.Id;
            GorevAtama();
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            IsAkisNo();
            Temizle();
            dosyaKontrol = false;
        }
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

        private void BtnDosya_Click(object sender, EventArgs e)
        {
            IsAkisNo();
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            isAkisNo = LblIsAkisNo.Text;

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYolu = subdir + isAkisNo;
            Directory.CreateDirectory(subdir + isAkisNo);

            //Directory.CreateDirectory(subdir + isAkisNo);
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
                dosyaKontrol = true;
            }
        }

        void YerleskeAdlari()
        {
            CmbYerleskeAdi.DataSource = kiraManager.GetList();
            CmbYerleskeAdi.ValueMember = "Id";
            CmbYerleskeAdi.DisplayMember = "YerleskeAdi";
            CmbYerleskeAdi.SelectedValue = 0;
        }


        private void CmbGiderTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbYerleskeAdi.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Yerleşke Adı Bilgisini Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            TxtAdres.Clear(); TxtHizmetAlinanKurum.Clear(); TxtTesisatNo.Clear();
            Yerleske yerleske = yerleskeManager.YerleskeBiigiCek(CmbYerleskeAdi.Text, CmbGiderTuru.Text);

            if (yerleske == null)
            {
                Yerleske yerleske2 = yerleskeManager.YerleskeBiigiCek(CmbYerleskeAdi.Text);
                TxtAdres.Text = yerleske2.YerleskeAdresi;
            }
            else
            {
                TxtAdres.Text = yerleske.YerleskeAdresi;
                TxtHizmetAlinanKurum.Text = yerleske.HizmetAlinanKurum;
                TxtTesisatNo.Text = yerleske.AboneTesisatNo;
            }
            
        }
        string Control()
        {
            if (CmbYerleskeAdi.Text=="")
            {
                return "Lütfen Yerleşke Adı bilgisini doldurunuz!";
            }
            if (CmbGiderTuru.Text == "")
            {
                return "Lütfen Gider Türü bilgisini doldurunuz!";
            }
            if (CmbDonemAy.Text == "")
            {
                return "Lütfen Dönem bilgisini doldurunuz!";
            }
            if (CmbDonemYil.Text == "")
            {
                return "Lütfen Dönem bilgisini doldurunuz!";
            }
            if (TxtTutar.Text == "")
            {
                return "Lütfen Tutar bilgisini doldurunuz!";
            }
            return "OK";
        }
        void Temizle()
        {
            CmbYerleskeAdi.SelectedIndex = -1;
            CmbGiderTuru.SelectedIndex = -1;
            TxtAdres.Clear(); TxtHizmetAlinanKurum.Clear(); TxtTesisatNo.Clear(); CmbDonemAy.SelectedIndex= -1; CmbDonemYil.SelectedIndex = -1;
            CmbButceTanimi.SelectedIndex = -1; CmbMaliyetTuru.SelectedIndex= -1; CmbSatBirim.SelectedIndex = -1; CmbHarcamaTuru.SelectedIndex = -1;
            CmbFaturaFirma.SelectedIndex = -1; CmbProjeKodu.SelectedIndex= -1; TxtTutar.Clear(); webBrowser1.Navigate("");
        }
    }
}
