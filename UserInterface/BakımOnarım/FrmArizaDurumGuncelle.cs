using Business;
using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Drawing;
using Entity;
using Entity.BakimOnarim;
using Entity.Gecic_Kabul_Ambar;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmArizaDurumGuncelle : Form
    {
        IslemAdimlariManager islemAdimlariManager;
        PersonelKayitManager kayitManager;
        ArizaKayitManager arizaKayitManager;
        MalzemeKayitManager malzemeKayitManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        AbfMalzemeManager abfMalzemeManager;
        IsAkisNoManager isAkisNoManager;
        IscilikIscilikManager ıscilikIscilikManager;
        MalzemeManager malzemeManager;
        UstTakimManager ustTakimManager;

        List<MalzemeKayit> malzemeKayits = new List<MalzemeKayit>();
        List<Malzeme> malzemes = new List<Malzeme>();
        List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();

        bool start = true;
        public bool rightControl = false;
        int id, comboId, abfForm, gun, saat, dakika, idParca, controlId;
        DateTime birOncekiTarih;
        string sure, dosyaYolu, isAkisNo;
        string personelGorevi, personelBolumu, lojTarihi;
        public object[] infos;
        string control = "OK";
        public FrmArizaDurumGuncelle()
        {
            InitializeComponent();
            islemAdimlariManager = IslemAdimlariManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            ıscilikIscilikManager = IscilikIscilikManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
            ustTakimManager= UstTakimManager.GetInstance();
        }

        private void FrmArizaDurumGuncelle_Load(object sender, EventArgs e)
        {
            IslemAdimlari();
            Personeller();
            CmbStokNoSokulen();
            StokNoTakilan();
            PersonellerIscilik();
            CmbStokNo();
            if (TxtAbfNo.Text != "")
            {
                BulClick();
            }
            GrbMalzemeBilgileri.Visible = false;
            BtnKaydet.Location = new System.Drawing.Point(161, 405);
            GrbMalzemeBilgileri.Location = new System.Drawing.Point(118, 460);
            start = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageArizaDurumGuncelle"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void CmbStokNo()
        {
            CmbParcaNo.DataSource = ustTakimManager.GetList();
            CmbParcaNo.ValueMember = "Id";
            CmbParcaNo.DisplayMember = "Tanim";
            CmbParcaNo.SelectedValue = 0;
        }
        void IslemAdimlari()
        {
            CmbIslemAdimi.DataSource = islemAdimlariManager.GetList("BAKIM ONARIM");
            CmbIslemAdimi.ValueMember = "Id";
            CmbIslemAdimi.DisplayMember = "IslemaAdimi";
            CmbIslemAdimi.SelectedValue = -1;
        }

        void Personeller()
        {
            CmbGorevAtanacakPersonel.DataSource = kayitManager.PersonelAdSoyad();
            CmbGorevAtanacakPersonel.ValueMember = "Id";
            CmbGorevAtanacakPersonel.DisplayMember = "Adsoyad";
            CmbGorevAtanacakPersonel.SelectedValue = -1;
        }
        void PersonellerIscilik()
        {
            CmbPersoneller.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersoneller.ValueMember = "Id";
            CmbPersoneller.DisplayMember = "Adsoyad";
            CmbPersoneller.SelectedValue = -1;
        }
        private void BtnBul_Click(object sender, EventArgs e)
        {
            BulClick();
        }
        void BulClick()
        {
            if (TxtAbfNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle ABF Form No Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgFormBilgileri.Rows.Clear();
            ArizaKayit arizaKayit = arizaKayitManager.Get(TxtAbfNo.Text.ConInt());
            if (arizaKayit == null)
            {
                MessageBox.Show("Girmiş Olduğunuz ABF No Ya Ait Bir Kayıt Bulunamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgFormBilgileri.Rows.Add();
            int sonSatir = DtgFormBilgileri.RowCount - 1;

            DtgFormBilgileri.Rows[sonSatir].Cells["FormNo"].Value = arizaKayit.AbfFormNo.ToString();
            DtgFormBilgileri.Rows[sonSatir].Cells["BolgeAdi"].Value = arizaKayit.BolgeAdi;
            DtgFormBilgileri.Rows[sonSatir].Cells["BildirimTarihi"].Value = arizaKayit.AbTarihSaat.ToString();
            DtgFormBilgileri.Rows[sonSatir].Cells["BolgeSorumlusu"].Value = arizaKayit.AcmaOnayiVeren;
            DtgFormBilgileri.Rows[sonSatir].Cells["StokNo"].Value = arizaKayit.StokNo;
            DtgFormBilgileri.Rows[sonSatir].Cells["Tanim"].Value = arizaKayit.Tanim;
            DtgFormBilgileri.Rows[sonSatir].Cells["SeriNo"].Value = arizaKayit.SeriNo;
            DtgFormBilgileri.Rows[sonSatir].Cells["BildirimNo"].Value = arizaKayit.BildirimNo;
            DtgFormBilgileri.Rows[sonSatir].Cells["TespitEdilenAriza"].Value = arizaKayit.TespitEdilenAriza;
            DtgFormBilgileri.Rows[sonSatir].Cells["OkfBildirimNo"].Value = arizaKayit.OkfBildirimNo;

            controlId = arizaKayit.Id;
            LblMevcutIslemAdimi.Text = arizaKayit.IslemAdimi;

            //tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage3"]);
            GrbMalzemeBilgileri.Visible = false;
            BtnKaydet.Location = new System.Drawing.Point(161, 405);
            GrbMalzemeBilgileri.Location = new System.Drawing.Point(118, 460);
            if (LblMevcutIslemAdimi.Text == "200_ARIZA TESPİTİ (FI/FD) (SAHA)")
            {
                GrbMalzemeBilgileri.Visible = true;
                BtnKaydet.Location = new System.Drawing.Point(29, 831);
                GrbMalzemeBilgileri.Location = new System.Drawing.Point(18, 415);

                //tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage2"]);
            }
            if (LblMevcutIslemAdimi.Text == "1500_BAKIM ONARIM (SAHA)")
            {
                GrbMalzemeBilgileri.Visible = true;
                BtnKaydet.Location = new System.Drawing.Point(29, 831);
                GrbMalzemeBilgileri.Location = new System.Drawing.Point(18, 415);

                //tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage1"]);
            }

            abfForm = arizaKayit.AbfFormNo;
            id = arizaKayit.Id;

            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "BAKIM ONARIM");

            //bulunduguIslemAdimi = gorevAtamaPersonel.IslemAdimi;
            birOncekiTarih = gorevAtamaPersonel.Tarih;
            //LblMevcutIslemAdimi.Text = bulunduguIslemAdimi;

            TimeSpan sonuc = DateTime.Now - birOncekiTarih;

            gun = sonuc.Days.ConInt();
            saat = sonuc.Hours.ConInt();
            if (sonuc.Hours < 1)
            {
                saat = 0;
            }

            dakika = sonuc.Seconds.ConInt() % 60;

            sure = gun.ToString() + " Gün " + saat.ToString() + " Saat " + dakika.ToString() + " Dakika";

            dosyaYolu = arizaKayit.DosyaYolu;

            if (arizaKayit.IslemAdimi== "2100_ARIZA KAPATMA BİLDİRİMİ (ASELSAN)")
            {
                ChkKapat.Visible = true;
            }
            else
            {
                ChkKapat.Visible=false;
            }
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }
        void CmbStokNoSokulen()
        {
            malzemes = malzemeManager.GetList();
            CmbSokulenStokNo.DataSource = malzemes;
            CmbSokulenStokNo.ValueMember = "Id";
            CmbSokulenStokNo.DisplayMember = "StokNo";
            CmbSokulenStokNo.SelectedValue = 0;
        }
        void StokNoTakilan()
        {
            CmbStokNoTakilan.DataSource = malzemes;
            CmbStokNoTakilan.ValueMember = "Id";
            CmbStokNoTakilan.DisplayMember = "StokNo";
            CmbStokNoTakilan.SelectedValue = 0;
        }

        private void CmbSokulenStokNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }

            //comboId = CmbSokulenStokNo.SelectedValue.ConInt();

            Malzeme malzemeKayit = malzemeManager.Get(CmbSokulenStokNo.Text);

            if (malzemeKayit == null)
            {
                TxtSokulenTanim.Text = "";
                return;
            }
            TxtSokulenTanim.Text = malzemeKayit.Tanim;
        }

        private void CmbSokulenStokNo_TextChanged(object sender, EventArgs e)
        {
            if (CmbSokulenStokNo.Text == "")
            {
                TxtSokulenTanim.Clear();
            }
            else
            {
                foreach (Malzeme item in malzemes)
                {
                    if (CmbSokulenStokNo.Text == item.StokNo)
                    {
                        TxtSokulenTanim.Text = item.Tanim;
                    }
                }
            }
        }

        private void TxtSokulenTanim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        string SokulenKontrol()
        {
            if (CmbSokulenStokNo.Text == "")
            {
                return "Lütfen Öncelikle Sökülen Stok No Bilgisini Doldurunuz!";
            }
            if (TxtSokulenTanim.Text == "")
            {
                return "Lütfen Öncelikle Sökülen Tanım Bilgisini Doldurunuz!";
            }
            if (TxtSokulenSeriNo.Text == "")
            {
                return "Lütfen Öncelikle Sökülen Seri No Bilgisini Doldurunuz!";
            }
            if (TxtSokulenMiktar.Text == "")
            {
                return "Lütfen Öncelikle Sökülen Miktar Bilgisini Doldurunuz!";
            }
            if (CmbSokulenBirim.Text == "")
            {
                return "Lütfen Öncelikle Sökülen Birim Bilgisini Doldurunuz!";
            }
            if (TxtCalismaSaatiSokulen.Text == "")
            {
                return "Lütfen Öncelikle Sökülen Çalışma Saati Bilgisini Doldurunuz!";
            }
            if (TxtSokulenRevizyon.Text == "")
            {
                return "Lütfen Öncelikle Sökülen Revizyon Bilgisini Doldurunuz!";
            }
            if (CmbCalismaDurumu.Text == "")
            {
                return "Lütfen Öncelikle Sökülen Çalışma Durumu Bilgisini Doldurunuz!";
            }
            if (CmbFizikselDurumu.Text == "")
            {
                return "Lütfen Öncelikle Sökülen Fiziksel Durumu Bilgisini Doldurunuz!";
            }
            if (CmbYapilanIslem.Text == "")
            {
                return "Lütfen Öncelikle Sökülen Yapılacak İşlemler Bilgisini Doldurunuz!";
            }

            return "OK";
        }
        string TakilanKontrol()
        {
            if (CmbStokNoTakilan.Text == "")
            {
                return "Lütfen Öncelikle Takılan Stok No Bilgisini Doldurunuz!";
            }
            if (TxtTakilanTanim.Text == "")
            {
                return "Lütfen Öncelikle Takılan Tanım Bilgisini Doldurunuz!";
            }
            if (TxtTakilanSeriNo.Text == "")
            {
                return "Lütfen Öncelikle Takılan Seri No Bilgisini Doldurunuz!";
            }
            if (TxtTakilanMiktar.Text == "")
            {
                return "Lütfen Öncelikle Takılan Miktar Bilgisini Doldurunuz!";
            }
            if (CmbTakilanBirim.Text == "")
            {
                return "Lütfen Öncelikle Takılan Birim Bilgisini Doldurunuz!";
            }
            if (TxtTakilanCalismaSaati.Text == "")
            {
                return "Lütfen Öncelikle Takılan Çalışma Saati Bilgisini Doldurunuz!";
            }
            if (TxtTakilanRevizyon.Text == "")
            {
                return "Lütfen Öncelikle Takılan Revizyon Bilgisini Doldurunuz!";
            }

            return "OK";
        }
        private void BtnSokulenEkle_Click(object sender, EventArgs e)
        {
            string mesaj = SokulenKontrol();
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgSokulen.Rows.Add();
            int sonSatir = DtgSokulen.RowCount - 1;

            DtgSokulen.Rows[sonSatir].Cells["SokulenStokNo"].Value = CmbSokulenStokNo.Text;
            DtgSokulen.Rows[sonSatir].Cells["SokulenTanim"].Value = TxtSokulenTanim.Text;
            DtgSokulen.Rows[sonSatir].Cells["SokulenSeriNo"].Value = TxtSokulenSeriNo.Text;
            DtgSokulen.Rows[sonSatir].Cells["SokulenMiktar"].Value = TxtSokulenMiktar.Text;
            DtgSokulen.Rows[sonSatir].Cells["SokulenBirim"].Value = CmbSokulenBirim.Text;
            DtgSokulen.Rows[sonSatir].Cells["CalismaSaatiSokulen"].Value = TxtCalismaSaatiSokulen.Text;
            DtgSokulen.Rows[sonSatir].Cells["RevizyonSokulen"].Value = TxtSokulenRevizyon.Text;
            DtgSokulen.Rows[sonSatir].Cells["CalısmaDurumu"].Value = CmbCalismaDurumu.Text;
            DtgSokulen.Rows[sonSatir].Cells["FizikselDurumu"].Value = CmbFizikselDurumu.Text;
            DtgSokulen.Rows[sonSatir].Cells["MalzemeYapilacakIslem"].Value = CmbYapilanIslem.Text;

            SokelenTemizle();
        }
        void SokelenTemizle()
        {
            CmbSokulenStokNo.Text = ""; TxtSokulenSeriNo.Clear(); TxtSokulenMiktar.Clear(); CmbSokulenBirim.Text = ""; TxtCalismaSaatiSokulen.Clear();
            TxtSokulenRevizyon.Clear(); CmbCalismaDurumu.SelectedIndex = -1; CmbFizikselDurumu.SelectedIndex = -1; CmbYapilanIslem.SelectedIndex = -1;
        }
        void TakilanTemizle()
        {
            CmbStokNoTakilan.Text = ""; TxtTakilanSeriNo.Clear(); TxtTakilanMiktar.Clear(); CmbTakilanBirim.Text = "";
            TxtTakilanCalismaSaati.Clear(); TxtTakilanRevizyon.Clear();
        }

        private void CmbStokNoTakilan_TextChanged(object sender, EventArgs e)
        {
            if (CmbStokNoTakilan.Text == "")
            {
                TxtTakilanTanim.Clear();
            }
            else
            {
                foreach (Malzeme item in malzemes)
                {
                    if (CmbStokNoTakilan.Text == item.StokNo)
                    {
                        TxtTakilanTanim.Text = item.Tanim;
                    }
                }
            }
        }

        private void CmbStokNoTakilan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }

            //comboId = CmbStokNoTakilan.SelectedValue.ConInt();

            Malzeme malzemeKayit = malzemeManager.Get(CmbStokNoTakilan.Text);
            if (malzemeKayit == null)
            {
                TxtTakilanTanim.Text = "";
                return;
            }
            TxtTakilanTanim.Text = malzemeKayit.Tanim;
        }

        private void TxtSokulenMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtCalismaSaatiSokulen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtTakilanMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        string kaynakdosyaismi1, alinandosya1;

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle geçerli bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(dosyaYolu))
            {
                IsAkisNo();
                string root = @"Z:\DTS";
                string subdir = @"Z:\DTS\BAKIM ONARIM\ARIZA\";

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
                Directory.CreateDirectory(dosyaYolu);
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

            if (File.Exists(dosyaYolu))
            {
                MessageBox.Show("Belirtilen Klasörde " + dosyaYolu + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    File.Copy(alinandosya1, dosyaYolu);
                }
                catch (Exception)
                {
                    webBrowser1.Navigate(dosyaYolu);
                }

            }

            webBrowser1.Navigate(dosyaYolu);
        }

        private void BtnPersonelEkle_Click(object sender, EventArgs e)
        {
            AdvPersonel.Rows.Add();
            int sonSatir = AdvPersonel.RowCount - 1;
            AdvPersonel.Rows[sonSatir].Cells["AdiSoyadi"].Value = CmbPersoneller.Text;
            AdvPersonel.Rows[sonSatir].Cells["Gorevi"].Value = personelGorevi;
            AdvPersonel.Rows[sonSatir].Cells["Bolumu"].Value = personelBolumu;

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)AdvPersonel.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
        }

        private void AdvPersonel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                AdvPersonel.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void CmbParcaNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            idParca = CmbParcaNo.SelectedValue.ConInt();
            UstTakim malzemeKayit = ustTakimManager.Get(idParca);
            if (malzemeKayit == null)
            {
                LbStokNo.Text = "";

                return;
            }
            LbStokNo.Text = malzemeKayit.StokNo;
            //CmbIlgiliFirma.Text = malzemeKayit.Malzemeonarımyeri;
        }

        private void CmbGarantiDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = CmbGarantiDurumu.SelectedIndex;
            if (index == 0 || index == 2)
            {
                LblLojistik.Visible = false;
                TxtLojistikSorumlusu.Visible = false;
                TxtLojistikSorRutbesi.Visible = false;
                TxtLojistikSorGorevi.Visible = false;
                DtLojistikTarih.Visible = false;
                DtLojistikSaat.Visible = false;
                LblAd.Visible = false;
                LblRutbe.Visible = false;
                LblGorevi.Visible = false;
                LblTarih.Visible = false;
                LblSaat.Visible = false;
            }
            if (index == 1 || index == 3)
            {
                LblLojistik.Visible = true;
                TxtLojistikSorumlusu.Visible = true;
                TxtLojistikSorRutbesi.Visible = true;
                TxtLojistikSorGorevi.Visible = true;
                DtLojistikTarih.Visible = true;
                DtLojistikSaat.Visible = true;
                LblAd.Visible = true;
                LblRutbe.Visible = true;
                LblGorevi.Visible = true;
                LblTarih.Visible = true;
                LblSaat.Visible = true;
            }
        }

        private void BtnBulBildirim_Click(object sender, EventArgs e)
        {
            if (TxtBildirimNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Bildirim No Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgFormBilgileri.Rows.Clear();
            ArizaKayit arizaKayit = arizaKayitManager.GetBildirimNo(TxtBildirimNo.Text);
            if (arizaKayit == null)
            {
                MessageBox.Show("Girmiş Olduğunuz ABF No Ya Ait Bir Kayıt Bulunamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgFormBilgileri.Rows.Add();
            int sonSatir = DtgFormBilgileri.RowCount - 1;

            DtgFormBilgileri.Rows[sonSatir].Cells["FormNo"].Value = arizaKayit.AbfFormNo.ToString();
            DtgFormBilgileri.Rows[sonSatir].Cells["BolgeAdi"].Value = arizaKayit.BolgeAdi;
            DtgFormBilgileri.Rows[sonSatir].Cells["BildirimTarihi"].Value = arizaKayit.AbTarihSaat.ToString();
            DtgFormBilgileri.Rows[sonSatir].Cells["BolgeSorumlusu"].Value = arizaKayit.AcmaOnayiVeren;
            DtgFormBilgileri.Rows[sonSatir].Cells["StokNo"].Value = arizaKayit.StokNo;
            DtgFormBilgileri.Rows[sonSatir].Cells["Tanim"].Value = arizaKayit.Tanim;
            DtgFormBilgileri.Rows[sonSatir].Cells["SeriNo"].Value = arizaKayit.SeriNo;
            DtgFormBilgileri.Rows[sonSatir].Cells["BildirimNo"].Value = arizaKayit.BildirimNo;
            DtgFormBilgileri.Rows[sonSatir].Cells["TespitEdilenAriza"].Value = arizaKayit.TespitEdilenAriza;
            DtgFormBilgileri.Rows[sonSatir].Cells["OkfBildirimNo"].Value = arizaKayit.OkfBildirimNo;

            controlId = arizaKayit.Id;
            LblMevcutIslemAdimi.Text = arizaKayit.IslemAdimi;

            //tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage3"]);
            GrbMalzemeBilgileri.Visible = false;
            BtnKaydet.Location = new System.Drawing.Point(161, 405);
            GrbMalzemeBilgileri.Location = new System.Drawing.Point(118, 460);
            if (LblMevcutIslemAdimi.Text == "200_ARIZA TESPİTİ (FI/FD) (SAHA)")
            {
                GrbMalzemeBilgileri.Visible = true;
                BtnKaydet.Location = new System.Drawing.Point(29, 831);
                GrbMalzemeBilgileri.Location = new System.Drawing.Point(18, 415);

                //tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage2"]);
            }
            if (LblMevcutIslemAdimi.Text == "1500_BAKIM ONARIM (SAHA)")
            {
                GrbMalzemeBilgileri.Visible = true;
                BtnKaydet.Location = new System.Drawing.Point(29, 831);
                GrbMalzemeBilgileri.Location = new System.Drawing.Point(18, 415);

                //tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage1"]);
            }

            if (arizaKayit.IslemAdimi == "2100_ARIZA KAPATMA BİLDİRİMİ (ASELSAN)")
            {
                ChkKapat.Visible = true;
            }
            else
            {
                ChkKapat.Visible = false;
            }

            abfForm = arizaKayit.AbfFormNo;
            id = arizaKayit.Id;

            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "BAKIM ONARIM");

            //bulunduguIslemAdimi = gorevAtamaPersonel.IslemAdimi;
            birOncekiTarih = gorevAtamaPersonel.Tarih;
            //LblMevcutIslemAdimi.Text = bulunduguIslemAdimi;

            TimeSpan sonuc = DateTime.Now - birOncekiTarih;

            gun = sonuc.Days.ConInt();
            saat = sonuc.Hours.ConInt();
            if (sonuc.Hours < 1)
            {
                saat = 0;
            }

            dakika = sonuc.Seconds.ConInt() % 60;

            sure = gun.ToString() + " Gün " + saat.ToString() + " Saat " + dakika.ToString() + " Dakika";

            dosyaYolu = arizaKayit.DosyaYolu;
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void CmbIslemAdimi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbIslemAdimi.Text== "400_SİPARİŞ OLUŞTURMA (DTS)")
            {
                CmbGorevAtanacakPersonel.Text = "EMEL AYHAN";
            }
            if (CmbIslemAdimi.Text == "2000_ARIZA KAPATMA (DTS)")
            {
                CmbGorevAtanacakPersonel.Text = "EMEL AYHAN";
            }
        }

        private void TxtAbfNo_TextChanged(object sender, EventArgs e)
        {
            if (rightControl==true)
            {
                BulClick();
                rightControl = false;

            }
        }

        private void CmbPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbPersoneller.SelectedIndex == -1)
            {
                return;
            }
            PersonelKayit personelKayit = kayitManager.Get(0, CmbPersoneller.Text);
            personelGorevi = personelKayit.Isunvani;
            personelBolumu = personelKayit.Sirketbolum;
        }

        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }

        private void TxtTakilanCalismaSaati_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            string mesaj = TakilanKontrol();
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DtgTakilan.Rows.Add();
            int sonSatir = DtgTakilan.RowCount - 1;

            DtgTakilan.Rows[sonSatir].Cells["TakilanStokNo"].Value = CmbStokNoTakilan.Text;
            DtgTakilan.Rows[sonSatir].Cells["TakilanTanim"].Value = TxtTakilanTanim.Text;
            DtgTakilan.Rows[sonSatir].Cells["TakilanSeriNo"].Value = TxtTakilanSeriNo.Text;
            DtgTakilan.Rows[sonSatir].Cells["TakilanMiktar"].Value = TxtTakilanMiktar.Text;
            DtgTakilan.Rows[sonSatir].Cells["TakilanBirim"].Value = CmbTakilanBirim.Text;
            DtgTakilan.Rows[sonSatir].Cells["TakilanCalismaSaati"].Value = TxtTakilanCalismaSaati.Text;
            DtgTakilan.Rows[sonSatir].Cells["TakilanRevizyon"].Value = TxtTakilanRevizyon.Text;

            TakilanTemizle();
        }
        string KayitKontrol()
        {
            if (CmbIslemAdimi.Text=="")
            {
                return "Lütfen İşlem adımı bilgisini seçiniz!";
            }
            if (CmbGorevAtanacakPersonel.Text=="")
            {
                return "Lütfen Görev atanacak personel bilgisini seçiniz!";
            }
            if (DtgFormBilgileri.RowCount == 0)
            {
                return "Lütfen Öncelikle Geçerli Bir ABF Form Numarası Yazınız!";
            }
            if (TxtYapilanIslemler.Text == "")
            {
                return "Lütfen Öncelikle Yapılacak/Yapılan İşlemler/ Açıklamalar Bilgisini Yazınız!";
            }
            if (CmbIslemAdimi.Text == "")
            {
                return "Lütfen Öncelikle Bir Sonraki İşlem Adımını Seçiniz!";
            }
            if (DtIscilikSaati.Value.ToString() == "00:00")
            {
                return "Lütfen Öncelikle İşçilik Sürenizi Yazınız!";
            }
            if (CmbGorevAtanacakPersonel.Text == "")
            {
                return "Lütfen Öncelikle Görev Atanacak Personel Bilgisini Seçiniz!";
            }
            if (LblMevcutIslemAdimi.Text == "200_ARIZA TESPİTİ (FI/FD) (SAHA)")
            {
                if (DtgSokulen.RowCount == 0)
                {
                    return "Lütfen Öncelikle SÖKÜLEN MALZEMELER Bilgisini Doldurunuz!";
                }
                //if (CmbGarantiDurumu.Text == "")
                //{
                //    return "Lütfen GARANTİ DURUMU bilgisini doldurunuz!";
                //}
                if (CmbGarantiDurumu.Text == "DIŞI" || CmbGarantiDurumu.Text == "PDL-5 OPSİYONEL")
                {
                    if (TxtLojistikSorumlusu.Text == "")
                    {
                        return "Lütfen LOJİSTİK SORUMLUSU bilgisini doldurunuz!";
                    }
                    if (TxtLojistikSorRutbesi.Text == "")
                    {
                        return "Lütfen LOJİSTİK SORUMLUSU RÜTBE bilgisini doldurunuz!";
                    }
                    if (TxtLojistikSorGorevi.Text == "")
                    {
                        return "Lütfen LOJİSTİK SORUMLUSU GÖREVİ bilgisini doldurunuz!";
                    }
                }
                if (CmbParcaNo.Text == "")
                {
                    return "Lütfen ÜST TAKIM bilgilerini eksiksiz doldurunuz!";
                }
                if (TxtSeriNo.Text == "")
                {
                    return "Lütfen ÜST TAKIM SERİ NO bilgisini eksiksiz doldurunuz!\nBilinmiyor ise N/A yazabilirsiniz.";
                }

            }
            if (LblMevcutIslemAdimi.Text == "1500_BAKIM ONARIM (SAHA)")
            {
                if (DtgTakilan.RowCount == 0)
                {
                    return "Lütfen Öncelikle TAKILAN MALZEMELER Bilgisini Doldurunuz!";
                }
            }

            return "";
        }
        void MalzemeKaydetAK()
        {
            ArizaKayit arizaKayit2 = arizaKayitManager.Get(abfForm);
            id = arizaKayit2.Id;

            List<AbfMalzeme> eklenecekler = new List<AbfMalzeme>();
            List<AbfMalzeme> guncellenecekler = new List<AbfMalzeme>();

            foreach (DataGridViewRow item in DtgSokulen.Rows)
            {
                AbfMalzeme abfMalzemeSokulen = new AbfMalzeme(id, item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(), item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(),
                    item.Cells["SokulenBirim"].Value.ToString(), item.Cells["CalismaSaatiSokulen"].Value.ConDouble(), item.Cells["RevizyonSokulen"].Value.ToString(), item.Cells["CalısmaDurumu"].Value.ToString(), item.Cells["FizikselDurumu"].Value.ToString(), item.Cells["MalzemeYapilacakIslem"].Value.ToString());

                abfMalzemeManager.AddSokulen(abfMalzemeSokulen);
            }

            abfMalzemes = abfMalzemeManager.GetList(id);


            var addItems = new HashSet<AbfMalzeme>();
            var updateItems = new HashSet<AbfMalzeme>();


            foreach (DataGridViewRow takilan in DtgTakilan.Rows)
            {
                AbfMalzeme abfMalzeme = new AbfMalzeme(takilan.Cells["TakilanStokNo"].Value.ToString(), takilan.Cells["TakilanTanim"].Value.ToString(), takilan.Cells["TakilanSeriNo"].Value.ToString(), takilan.Cells["TakilanMiktar"].Value.ConInt(), takilan.Cells["TakilanBirim"].Value.ToString(), takilan.Cells["TakilanCalismaSaati"].Value.ConDouble(), takilan.Cells["TakilanRevizyon"].Value.ToString());

                if (abfMalzemes.Any(x => x.SokulenSeriNo.Equals(takilan.Cells["TakilanSeriNo"].Value.ToString())
                            && x.SokulenStokNo.Equals(takilan.Cells["TakilanStokNo"].Value.ToString())))
                {
                    updateItems.Add(abfMalzeme);
                }
                else
                {
                    addItems.Add(abfMalzeme);
                }
            }

            int index = 0;
            foreach (AbfMalzeme item in updateItems)
            {
                int sokulenId = abfMalzemes[index].Id;
                abfMalzemeManager.UpdateTakilan(item, sokulenId);
                index++;
            }
            foreach (AbfMalzeme item in addItems)
            {
                abfMalzemeManager.AddTakilan(item, id);
            }
        }
        string PersonelIscilikleriEkle()
        {
            foreach (DataGridViewRow item in AdvPersonel.Rows)
            {
                IscilikIscilik ıscilikIscilik = new IscilikIscilik(id, item.Cells["AdiSoyadi"].Value.ToString(), item.Cells["Gorevi"].Value.ToString(), item.Cells["Bolumu"].Value.ToString(), "İŞÇİLİK", abfForm.ToString(), DateTime.Now, DtIscilikSaati.Value.Date);

                ıscilikIscilikManager.Add(ıscilikIscilik);
            }
            return "OK";
        }

        void SistemCihazBilgileriKayit()
        {

            ArizaKayit arizaKayit = new ArizaKayit(id, LbStokNo.Text, CmbParcaNo.Text, TxtSeriNo.Text);

            arizaKayitManager.SistemCihazBilgileri2(arizaKayit);
        }
        string DepoIslemleriKontrol()
        {
            //List<AbfMalzeme> abfMalzemesKontrol = new List<AbfMalzeme>();
            //abfMalzemesKontrol = abfMalzemeManager.GetList(controlId);

            //foreach (AbfMalzeme item in abfMalzemesKontrol)
            //{
            //    if (item.TeminDurumu != "ARIZAYA GÖNDERİLDİ" && item.SokulenStokNo != "")
            //    {
            //        if (item.TeminDurumu != "REZERVE EDİLDİ" && item.SokulenStokNo != "")
            //        {
            //            return "Arıza için gerekli olan tüm malzemelerin hazırlanma işlemleri tamamlanmamıştır!\nLütfen öncelikle malzeme hazırlama işlemlerini tamamlayınız!";
            //        }

            //    }
            //}

            return "OK";
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (AdvPersonel.RowCount == 0)
            {
                MessageBox.Show("Lütfen işlem adımı için geçerli olan işçilik bilgilerini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LblMevcutIslemAdimi.Text != "2100_ARIZA KAPATMA BİLDİRİMİ (ASELSAN)")
            {
                string kayitKontrol = KayitKontrol();
                if (kayitKontrol != "")
                {
                    MessageBox.Show(kayitKontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (LblMevcutIslemAdimi.Text == "1000_DEPO STOK KONTROL")
            {
                if (CmbIslemAdimi.Text != "1100_MALZEME TEMİNİ (SATIN ALMA)")
                {
                    if (CmbIslemAdimi.Text != "1200_MALZEME TEMİNİ (ASELSAN)")
                    {
                        if (CmbIslemAdimi.Text != "1300_MALZEME HAZIRLAMA AMBAR")
                        {
                            control = DepoIslemleriKontrol();
                            if (control != "OK")
                            {
                                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
            }
            if (LblMevcutIslemAdimi.Text == "1100_MALZEME TEMİNİ (SATIN ALMA)")
            {
                if (CmbIslemAdimi.Text != "1000_DEPO STOK KONTROL")
                {
                    if (CmbIslemAdimi.Text != "1200_MALZEME TEMİNİ (ASELSAN)")
                    {
                        if (CmbIslemAdimi.Text != "1300_MALZEME HAZIRLAMA AMBAR")
                        {
                            control = DepoIslemleriKontrol();
                            if (control != "OK")
                            {
                                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
            }
            if (LblMevcutIslemAdimi.Text == "1200_MALZEME TEMİNİ (ASELSAN)")
            {
                if (CmbIslemAdimi.Text != "1000_DEPO STOK KONTROL")
                {
                    if (CmbIslemAdimi.Text != "1100_MALZEME TEMİNİ (SATIN ALMA)")
                    {
                        if (CmbIslemAdimi.Text != "1300_MALZEME HAZIRLAMA AMBAR")
                        {
                            control = DepoIslemleriKontrol();
                            if (control != "OK")
                            {
                                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
            }
            if (LblMevcutIslemAdimi.Text == "1300_MALZEME HAZIRLAMA AMBAR")
            {
                if (CmbIslemAdimi.Text != "1000_DEPO STOK KONTROL")
                {
                    if (CmbIslemAdimi.Text != "1100_MALZEME TEMİNİ (SATIN ALMA)")
                    {
                        if (CmbIslemAdimi.Text != "1200_MALZEME TEMİNİ (ASELSAN)")
                        {
                            control = DepoIslemleriKontrol();
                            if (control != "OK")
                            {
                                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
            }

            if (LblMevcutIslemAdimi.Text == "200_ARIZA TESPİTİ (FI/FD) (SAHA)")
            {
                if (DtgSokulen.RowCount==0)
                {
                    MessageBox.Show("Lütfen sökülen malzeme bilgilerini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (CmbGarantiDurumu.Text=="")
                {
                    MessageBox.Show("Lütfen Garanti Durumu Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (LblMevcutIslemAdimi.Text == "1500_BAKIM ONARIM (SAHA)")
            {
                if (CmbIslemAdimi.Text!= "1500_BAKIM ONARIM (SAHA)" || CmbIslemAdimi.Text != "1000_DEPO STOK KONTROL")
                {
                    if (DtgTakilan.RowCount == 0)
                    {
                        MessageBox.Show("Lütfen takılan malzeme bilgilerini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
            }

            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }
            abfMalzemes = abfMalzemeManager.GetList(id);
            if (abfMalzemes == null)
            {
                MessageBox.Show("Arızaya Ait Sökülen Malzeme Bulunamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string kontrol = PersonelIscilikleriEkle();
            if (kontrol != "OK")
            {
                MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LblMevcutIslemAdimi.Text == "2100_ARIZA KAPATMA BİLDİRİMİ (ASELSAN)")
            {
                if (ChkKapat.Checked == true)
                {
                    string mesaj = arizaKayitManager.IslemAdimiGuncelle(id, "ONARIMI TAMAMLANDI", "");
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    string mesaj = arizaKayitManager.IslemAdimiGuncelle(id, CmbIslemAdimi.Text, CmbGorevAtanacakPersonel.Text);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
            }
            else
            {
                string mesaj = arizaKayitManager.IslemAdimiGuncelle(id, CmbIslemAdimi.Text, CmbGorevAtanacakPersonel.Text);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (LblMevcutIslemAdimi.Text == "200_ARIZA TESPİTİ (FI/FD) (SAHA)")
            {
                abfMalzemes = abfMalzemeManager.GetList(id);

                if (abfMalzemes.Count != 0)
                {
                    abfMalzemeManager.Delete(id);
                }

                foreach (DataGridViewRow item in DtgSokulen.Rows)
                {
                    AbfMalzeme abfMalzemeSokulen = new AbfMalzeme(id, item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(), item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(),
                        item.Cells["SokulenBirim"].Value.ToString(), item.Cells["CalismaSaatiSokulen"].Value.ConDouble(), item.Cells["RevizyonSokulen"].Value.ToString(), item.Cells["CalısmaDurumu"].Value.ToString(), item.Cells["FizikselDurumu"].Value.ToString(), item.Cells["MalzemeYapilacakIslem"].Value.ToString());

                    abfMalzemeManager.AddSokulen(abfMalzemeSokulen);
                }

                SistemCihazBilgileriKayit();

                DateTime lojTarih = new DateTime(DtLojistikTarih.Value.Year, DtLojistikTarih.Value.Month, DtLojistikTarih.Value.Day, DtLojistikSaat.Value.Hour, DtLojistikSaat.Value.Minute, DtLojistikSaat.Value.Second);

                if (CmbGarantiDurumu.Text == "İÇİ")
                {
                    lojTarihi = "";
                }
                else
                {
                    lojTarihi = lojTarih.ToString();
                }

                ArizaKayit arizaKayit = new ArizaKayit(id, CmbGarantiDurumu.Text, TxtLojistikSorumlusu.Text, TxtLojistikSorRutbesi.Text, TxtLojistikSorGorevi.Text, lojTarihi, TxtYapilanIslemler.Text.ToUpper(), infos[1].ToString());

                string mesaj2 = arizaKayitManager.ArizaSiparisOlustur(arizaKayit);

            }

            if (LblMevcutIslemAdimi.Text == "1500_BAKIM ONARIM (SAHA)")
            {
                if (CmbIslemAdimi.Text!= "1500_BAKIM ONARIM (SAHA)" || CmbIslemAdimi.Text != "1000_DEPO STOK KONTROL")
                {
                    abfMalzemes = abfMalzemeManager.GetList(id);

                    var addItems = new HashSet<AbfMalzeme>();
                    var updateItems = new HashSet<AbfMalzeme>();


                    foreach (DataGridViewRow takilan in DtgTakilan.Rows)
                    {
                        AbfMalzeme abfMalzeme = new AbfMalzeme(takilan.Cells["TakilanStokNo"].Value.ToString(), takilan.Cells["TakilanTanim"].Value.ToString(), takilan.Cells["TakilanSeriNo"].Value.ToString(), takilan.Cells["TakilanMiktar"].Value.ConInt(), takilan.Cells["TakilanBirim"].Value.ToString(), takilan.Cells["TakilanCalismaSaati"].Value.ConDouble(), takilan.Cells["TakilanRevizyon"].Value.ToString());

                        if (abfMalzemes.Any(x => x.SokulenStokNo.Equals(takilan.Cells["TakilanStokNo"].Value.ToString())))
                        {
                            updateItems.Add(abfMalzeme);
                        }
                        else
                        {
                            addItems.Add(abfMalzeme);
                        }
                    }

                    int index = 0;
                    foreach (AbfMalzeme item in updateItems)
                    {
                        int sokulenId = abfMalzemes[index].Id;
                        abfMalzemeManager.UpdateTakilan(item, sokulenId);
                        index++;
                    }
                    foreach (AbfMalzeme item in addItems)
                    {
                        abfMalzemeManager.AddTakilan(item, id);
                    }
                }
            }

            string messege = GorevAtama();

            if (messege != "OK")
            {
                MessageBox.Show(messege, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            ChkKapat.Checked = false;
        }
        string GorevAtama()
        {
            if (LblMevcutIslemAdimi.Text == "2100_ARIZA KAPATMA BİLDİRİMİ (ASELSAN)" && ChkKapat.Checked==true)
            {
                GorevAtamaPersonel gorevAtama2 = new GorevAtamaPersonel(id, "BAKIM ONARIM", LblMevcutIslemAdimi.Text, sure, DtIscilikSaati.Value);
                string kontrol3 = gorevAtamaPersonelManager.Update(gorevAtama2, TxtYapilanIslemler.Text.ToUpper());
                if (kontrol3 != "OK")
                {
                    return kontrol3;
                }
                return "OK";
            }

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "BAKIM ONARIM", LblMevcutIslemAdimi.Text, sure, DtIscilikSaati.Value);
            string kontrol2 = gorevAtamaPersonelManager.Update(gorevAtama, TxtYapilanIslemler.Text.ToUpper());
            if (kontrol2 != "OK")
            {
                return kontrol2;
            }
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM", CmbGorevAtanacakPersonel.Text, CmbIslemAdimi.Text, DateTime.Now, "", DateTime.Now.Date);
            string kontrol = gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            if (kontrol != "OK")
            {
                return kontrol;
            }
            return "OK";
        }
        void Temizle()
        {
            DtgFormBilgileri.DataSource = null; TxtAbfNo.Clear(); LblMevcutIslemAdimi.Text = "00"; TxtYapilanIslemler.Clear(); webBrowser1.Navigate(""); CmbIslemAdimi.SelectedIndex = -1; DtIscilikSaati.Text = "00:00"; CmbGorevAtanacakPersonel.SelectedIndex = -1;
            SokelenTemizle();
            TakilanTemizle();
            DtgSokulen.Rows.Clear();
            DtgTakilan.Rows.Clear();
            webBrowser1.Navigate("");
            DtgFormBilgileri.Rows.Clear();
            AdvPersonel.Rows.Clear();
            CmbPersoneller.SelectedIndex = -1;
            DtIscilikSaati.Text = "00:00";
            CmbParcaNo.SelectedIndex = -1;
            LbStokNo.Text = "00";
            TxtSeriNo.Clear();
            TxtLojistikSorumlusu.Clear();
            TxtLojistikSorRutbesi.Clear();
            TxtLojistikSorRutbesi.Clear();
            CmbGarantiDurumu.SelectedIndex = -1;
            GrbMalzemeBilgileri.Visible = false;
            BtnKaydet.Location = new System.Drawing.Point(161, 405);
            GrbMalzemeBilgileri.Location = new System.Drawing.Point(118, 460);
        }
    }
}
