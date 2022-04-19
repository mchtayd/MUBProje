using Business;
using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarim;
using Entity.Gecic_Kabul_Ambar;
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

        List<MalzemeKayit> malzemeKayits = new List<MalzemeKayit>();
        List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();

        bool start = true;
        int id, comboId, abfForm, gun, saat, dakika;
        DateTime birOncekiTarih;
        string sure, dosyaYolu, isAkisNo;


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
        }

        private void FrmArizaDurumGuncelle_Load(object sender, EventArgs e)
        {
            IslemAdimlari();
            Personeller();
            CmbStokNoSokulen();
            StokNoTakilan();
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

        private void BtnBul_Click(object sender, EventArgs e)
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

            LblMevcutIslemAdimi.Text = arizaKayit.IslemAdimi;

            GrbMalzemeBilgileri.Visible = false;
            BtnKaydet.Location = new Point(161, 520);
            if (LblMevcutIslemAdimi.Text == "200_ARIZA TESPİTİ (FI/FD) (SAHA)")
            {
                GrbMalzemeBilgileri.Visible = true;
                BtnKaydet.Location = new Point(15, 876);
            }
            if (LblMevcutIslemAdimi.Text == "2000_ARIZA KAPATMA (DTS)")
            {
                GrbMalzemeBilgileri.Visible = true;
                BtnKaydet.Location = new Point(15, 876);
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
        void CmbStokNoSokulen()
        {

            malzemeKayits = malzemeKayitManager.GetList();
            CmbSokulenStokNo.DataSource = malzemeKayits;
            CmbSokulenStokNo.ValueMember = "Id";
            CmbSokulenStokNo.DisplayMember = "Stokno";
            CmbSokulenStokNo.SelectedValue = 0;
        }
        void StokNoTakilan()
        {
            CmbStokNoTakilan.DataSource = malzemeKayitManager.GetList();
            CmbStokNoTakilan.ValueMember = "Id";
            CmbStokNoTakilan.DisplayMember = "Stokno";
            CmbStokNoTakilan.SelectedValue = 0;
        }

        private void CmbSokulenStokNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            comboId = CmbSokulenStokNo.SelectedValue.ConInt();
            MalzemeKayit malzemeKayit = malzemeKayitManager.Get(comboId);
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
                foreach (MalzemeKayit item in malzemeKayits)
                {
                    if (CmbSokulenStokNo.Text == item.Stokno)
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
                foreach (MalzemeKayit item in malzemeKayits)
                {
                    if (CmbStokNoTakilan.Text == item.Stokno)
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
            comboId = CmbStokNoTakilan.SelectedValue.ConInt();
            MalzemeKayit malzemeKayit = malzemeKayitManager.Get(comboId);
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
                File.Copy(alinandosya1, dosyaYolu);
            }
            webBrowser1.Navigate(dosyaYolu);
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

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string kayitKontrol = KayitKontrol();
            if (kayitKontrol != "")
            {
                MessageBox.Show(kayitKontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            abfMalzemes = abfMalzemeManager.GetList(id);
            if (abfMalzemes==null)
            {
                MessageBox.Show("Arızaya Ait Sökülen Malzeme Bulunamamıştır!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            string mesaj = arizaKayitManager.IslemAdimiGuncelle(id, CmbIslemAdimi.Text, CmbGorevAtanacakPersonel.Text);
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LblMevcutIslemAdimi.Text == "200_ARIZA TESPİTİ (FI/FD) (SAHA)")
            {
                foreach (DataGridViewRow item in DtgSokulen.Rows)
                {
                    AbfMalzeme abfMalzemeSokulen = new AbfMalzeme(id, item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(), item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(),
                        item.Cells["SokulenBirim"].Value.ToString(), item.Cells["CalismaSaatiSokulen"].Value.ConDouble(), item.Cells["RevizyonSokulen"].Value.ToString(), item.Cells["CalısmaDurumu"].Value.ToString(), item.Cells["FizikselDurumu"].Value.ToString(), item.Cells["MalzemeYapilacakIslem"].Value.ToString());

                    abfMalzemeManager.AddSokulen(abfMalzemeSokulen);
                }
            }

            if (LblMevcutIslemAdimi.Text == "1500_BAKIM ONARIM (SAHA)")
            {
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

                /*foreach (AbfMalzeme sokulen in abfMalzemes)
                {
                    int idSokulen = sokulen.Id;
                    string sokulenStokNo = sokulen.SokulenStokNo;
                    string sokulenSeriNo = sokulen.SokulenSeriNo;

                    foreach (DataGridViewRow takilan in DtgTakilan.Rows)
                    {
                        if (sokulenStokNo == takilan.Cells["TakilanStokNo"].Value.ToString() &&
                            sokulenSeriNo == takilan.Cells["TakilanSeriNo"].Value.ToString())
                        {
                            AbfMalzeme abfMalzeme = new AbfMalzeme(takilan.Cells["TakilanStokNo"].Value.ToString(), takilan.Cells["TakilanTanim"].Value.ToString(), takilan.Cells["TakilanSeriNo"].Value.ToString(), takilan.Cells["TakilanMiktar"].Value.ConInt(), takilan.Cells["TakilanBirim"].Value.ToString(), takilan.Cells["TakilanCalismaSaati"].Value.ConDouble(), takilan.Cells["TakilanRevizyon"].Value.ToString());

                            abfMalzemeManager.UpdateTakilan(abfMalzeme, idSokulen);
                        }
                        else
                        {
                            AbfMalzeme abfMalzemeTakilan = new AbfMalzeme(takilan.Cells["TakilanStokNo"].Value.ToString(), takilan.Cells["TakilanTanim"].Value.ToString(), takilan.Cells["TakilanSeriNo"].Value.ToString(), takilan.Cells["TakilanMiktar"].Value.ConInt(), takilan.Cells["TakilanBirim"].Value.ToString(), takilan.Cells["TakilanCalismaSaati"].Value.ConDouble(), takilan.Cells["TakilanRevizyon"].Value.ToString());

                            abfMalzemeManager.AddTakilan(abfMalzemeTakilan, id);
                        }
                    }
                }*/
            }
            string messege = GorevAtama();

            if (messege!="OK")
            {
                MessageBox.Show(messege,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Temizle();
        }
        string GorevAtama()
        {
            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "BAKIM ONARIM", LblMevcutIslemAdimi.Text, sure, DtIscilikSaati.Value);
            string kontrol2 = gorevAtamaPersonelManager.Update(gorevAtama, TxtYapilanIslemler.Text);
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
        }
    }
}
