﻿using Business;
using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DataAccess.Concreate.BakimOnarim;
using Entity;
using Entity.AnaSayfa;
using Entity.BakimOnarim;
using Entity.BakimOnarimAtolye;
using Entity.Gecic_Kabul_Ambar;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UserInterface.Gecic_Kabul_Ambar;
using UserInterface.STS;
using Application = System.Windows.Forms.Application;
using Color = System.Drawing.Color;

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
        AbfMalzemeIslemKayitManager abfMalzemeIslemKayitManager;
        StokGirisCikisManager stokGirisCikisManager;
        AtolyeManager atolyeManager;
        DtsLogManager dtsLogManager;

        List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
        List<MalzemeKayit> malzemeKayits = new List<MalzemeKayit>();
        List<Malzeme> malzemes = new List<Malzeme>();
        List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
        List<StokGirisCıkıs> stokGirisCikis = new List<StokGirisCıkıs>();
        List<Atolye> atolyes = new List<Atolye>();

        bool start = true;
        public bool rightControl = false;
        int id, comboId, abfForm, gun, saat, dakika, idParca, controlId, atolyeId;
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
            ustTakimManager = UstTakimManager.GetInstance();
            abfMalzemeIslemKayitManager = AbfMalzemeIslemKayitManager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
            atolyeManager = AtolyeManager.GetInstance();
            dtsLogManager = DtsLogManager.GetInstance();
        }

        private void FrmArizaDurumGuncelle_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

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
            if (LblMevcutIslemAdimi.Text != "200_ARIZA TESPİTİ (FI/FD) (SAHA)")
            {
                if (LblMevcutIslemAdimi.Text != "1500_BAKIM ONARIM (SAHA)")
                {
                    if (LblMevcutIslemAdimi.Text != "300_ONARIM SONRASI ARIZA TESPİTİ (SAHA)")
                    {
                        GrbMalzemeBilgileri.Visible = false;
                        BtnKaydet.Location = new System.Drawing.Point(161, 405);
                        GrbMalzemeBilgileri.Location = new System.Drawing.Point(118, 460);
                        GrbVeriGecmisi.Visible = true;
                        start = false;
                    }
                    else
                    {
                        GrbVeriGecmisi.Visible = false;
                    }
                }
                else
                {
                    GrbVeriGecmisi.Visible = false;
                }
            }
            else
            {
                GrbVeriGecmisi.Visible = false;
            }
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
        string bolgeAdi, abf = "";
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
            abf = arizaKayit.AbfFormNo.ToString();
            DtgFormBilgileri.Rows[sonSatir].Cells["FormNo"].Value = abf;
            bolgeAdi = arizaKayit.BolgeAdi;
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

            abfForm = arizaKayit.AbfFormNo;
            id = arizaKayit.Id;
            GrbVeriGecmisi.Visible = true;
            if (LblMevcutIslemAdimi.Text == "200_ARIZA TESPİTİ (FI/FD) (SAHA)")
            {
                GrbMalzemeBilgileri.Visible = true;
                BtnKaydet.Location = new System.Drawing.Point(29, 831);
                GrbMalzemeBilgileri.Location = new System.Drawing.Point(18, 415);
                GrbVeriGecmisi.Visible = false;
                BtnSokulenEkle.Enabled = true;
                BtnEkle.Enabled = false;
                //tabControl1.TabPages[0].remo
            }
            if (LblMevcutIslemAdimi.Text == "1500_BAKIM ONARIM (SAHA)")
            {
                GrbMalzemeBilgileri.Visible = true;
                BtnKaydet.Location = new System.Drawing.Point(29, 831);
                GrbMalzemeBilgileri.Location = new System.Drawing.Point(18, 415);
                GrbVeriGecmisi.Visible = false;
                BtnSokulenEkle.Enabled = false;
                BtnEkle.Enabled = true;
                List<AbfMalzeme> abfMalzemes = abfMalzemeManager.GetList(id);
                DtgTakilan.Rows.Clear();
                foreach (AbfMalzeme item in abfMalzemes)
                {
                    if (item.TakilanStokNo != "")
                    {
                        DtgTakilan.Rows.Add();
                        int sonSatirr = DtgTakilan.RowCount - 1;
                        DtgTakilan.Rows[sonSatirr].Cells["TakilanId"].Value = item.Id;
                        DtgTakilan.Rows[sonSatirr].Cells["TakilanTeslimDurum"].Value = item.TakilanTeslimDurum;
                        DtgTakilan.Rows[sonSatirr].Cells["TakilanStokNo"].Value = item.TakilanStokNo;
                        DtgTakilan.Rows[sonSatirr].Cells["TakilanTanim"].Value = item.TakilanTanim;
                        DtgTakilan.Rows[sonSatirr].Cells["TakilanSeriNo"].Value = item.TakilanSeriNo;
                        DtgTakilan.Rows[sonSatirr].Cells["TakilanMiktar"].Value = item.TakilanMiktar;
                        DtgTakilan.Rows[sonSatirr].Cells["TakilanBirim"].Value = item.TakilanBirim;
                        DtgTakilan.Rows[sonSatirr].Cells["TakilanCalismaSaati"].Value = item.TakilanCalismaSaati;
                        DtgTakilan.Rows[sonSatirr].Cells["TakilanRevizyon"].Value = item.TakilanRevizyon;
                        DtgTakilan.Rows[sonSatirr].Cells["TakilanTeslimDurum"].Value = item.TakilanTeslimDurum;

                        DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgTakilan.Columns["Delete"];
                        c.FlatStyle = FlatStyle.Popup;
                        c.DefaultCellStyle.ForeColor = Color.Red;
                        c.DefaultCellStyle.BackColor = Color.Gainsboro;

                    }

                }
            }


            if (LblMevcutIslemAdimi.Text == "300_ONARIM SONRASI ARIZA TESPİTİ (SAHA)")
            {
                GrbMalzemeBilgileri.Visible = true;
                BtnKaydet.Location = new System.Drawing.Point(29, 831);
                GrbMalzemeBilgileri.Location = new System.Drawing.Point(18, 415);
                GrbVeriGecmisi.Visible = false;
                BtnSokulenEkle.Enabled = true;
                BtnEkle.Enabled = false;

                //tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage2"]);
            }

            IslemAdimlariSureleri();
            DepoHareketleri();
            AtolyeKayitlari();
            MalzemeListesi();
            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "BAKIM ONARIM");
            if (gorevAtamaPersonel == null)
            {
                MessageBox.Show("Malzeme Veri Geçmişine ulaşılamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            if (arizaKayit.IslemAdimi == "2100_ARIZA KAPATMA BİLDİRİMİ (ASELSAN)")
            {
                ChkKapat.Visible = true;
            }
            else
            {
                ChkKapat.Visible = false;
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

        void DepoHareketleri()
        {
            stokGirisCikis = stokGirisCikisManager.AtolyeDepoHareketleri(abfForm.ToString());
            DtgDepoHareketleri.DataSource = stokGirisCikis;

            DtgDepoHareketleri.Columns["Id"].Visible = false;
            DtgDepoHareketleri.Columns["Islemturu"].HeaderText = "İŞLEM TÜRÜ";
            DtgDepoHareketleri.Columns["IslemTarihi"].HeaderText = "İŞLEM TARİHİ";
            DtgDepoHareketleri.Columns["Stokno"].HeaderText = "STOK NO";
            DtgDepoHareketleri.Columns["Tanim"].HeaderText = "TANIM";
            DtgDepoHareketleri.Columns["Serino"].HeaderText = "SERİ NO";
            DtgDepoHareketleri.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgDepoHareketleri.Columns["DusulenMiktar"].HeaderText = "DÜŞÜLEN MİKTAR";
            DtgDepoHareketleri.Columns["Birim"].HeaderText = "BİRİM";
            DtgDepoHareketleri.Columns["Lotno"].HeaderText = "LOT NO";
            DtgDepoHareketleri.Columns["CekilenDepoNo"].HeaderText = "ÇEKİLEN DEPO NO/YER";
            DtgDepoHareketleri.Columns["CekilenDepoAdresi"].HeaderText = "ÇEKİLEN DEPO ADRESİ";
            DtgDepoHareketleri.Columns["CekilenMalzemeYeri"].HeaderText = "ÇEKİLEN MALZEME YERİ";
            DtgDepoHareketleri.Columns["DusulenDepoNo"].HeaderText = "DÜŞÜLEN DEPO NO/YER";
            DtgDepoHareketleri.Columns["DusulenDepoAdresi"].HeaderText = "DÜŞÜLEN DEPO ADRESİ";
            DtgDepoHareketleri.Columns["DusulenMalzemeYeri"].HeaderText = "DÜŞÜLEN MALZEME YERİ";
            DtgDepoHareketleri.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgDepoHareketleri.Columns["Aciklama"].HeaderText = "AÇIKLAMA";


            DtgDepoHareketleri.Columns["Id"].DisplayIndex = 0;
            DtgDepoHareketleri.Columns["Islemturu"].DisplayIndex = 1;
            DtgDepoHareketleri.Columns["IslemTarihi"].DisplayIndex = 2;
            DtgDepoHareketleri.Columns["Stokno"].DisplayIndex = 3;
            DtgDepoHareketleri.Columns["Tanim"].DisplayIndex = 4;
            DtgDepoHareketleri.Columns["Serino"].DisplayIndex = 5;
            DtgDepoHareketleri.Columns["Revizyon"].DisplayIndex = 6;
            DtgDepoHareketleri.Columns["DusulenMiktar"].DisplayIndex = 7;
            DtgDepoHareketleri.Columns["Birim"].DisplayIndex = 8;
            DtgDepoHareketleri.Columns["Lotno"].DisplayIndex = 9;
            DtgDepoHareketleri.Columns["CekilenDepoNo"].DisplayIndex = 10;
            DtgDepoHareketleri.Columns["CekilenDepoAdresi"].DisplayIndex = 11;
            DtgDepoHareketleri.Columns["CekilenMalzemeYeri"].DisplayIndex = 12;
            DtgDepoHareketleri.Columns["DusulenDepoNo"].DisplayIndex = 13;
            DtgDepoHareketleri.Columns["DusulenDepoAdresi"].DisplayIndex = 14;
            DtgDepoHareketleri.Columns["DusulenMalzemeYeri"].DisplayIndex = 15;
            DtgDepoHareketleri.Columns["TalepEdenPersonel"].DisplayIndex = 16;
            DtgDepoHareketleri.Columns["Aciklama"].DisplayIndex = 17;

        }
        void AtolyeKayitlari()
        {
            atolyes = atolyeManager.AtolyeAbf(abfForm.ToString());
            DtgAtolye.DataSource = atolyes;

            DtgAtolye.Columns["Id"].Visible = false;
            DtgAtolye.Columns["AbfNo"].Visible = false;
            DtgAtolye.Columns["StokNoUst"].HeaderText = "STOK NO";
            DtgAtolye.Columns["TanimUst"].HeaderText = "TANIM";
            DtgAtolye.Columns["SeriNoUst"].HeaderText = "SERİ NO";
            DtgAtolye.Columns["GarantiDurumu"].Visible = false;
            DtgAtolye.Columns["CrmNo"].Visible = false;
            DtgAtolye.Columns["Kategori"].Visible = false;
            DtgAtolye.Columns["BolgeAdi"].Visible = false;
            DtgAtolye.Columns["Proje"].Visible = false;
            DtgAtolye.Columns["BildirilenAriza"].Visible = false;
            DtgAtolye.Columns["IcSiparisNo"].HeaderText = "İÇ SİPARİŞ NO";
            DtgAtolye.Columns["SiparisAcmaTarihi"].HeaderText = "KAYIT TARİH";
            DtgAtolye.Columns["Modifikasyonlar"].Visible = false;
            DtgAtolye.Columns["Notlar"].Visible = false;
            DtgAtolye.Columns["BulunduguIslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgAtolye.Columns["SiparisNo"].Visible = false;
            DtgAtolye.Columns["IslemAdimi"].Visible = false;
            DtgAtolye.Columns["ArizaDurum"].Visible = false;
            DtgAtolye.Columns["Gecensure"].Visible = false;
            DtgAtolye.Columns["KapatmaTarihi"].Visible = false;
            DtgAtolye.Columns["DosyaYolu"].Visible = false;
            DtgAtolye.Columns["BildirimNo"].Visible = false;
            DtgAtolye.Columns["CekildigiTarih"].Visible = false;
            DtgAtolye.Columns["MalzemeId"].Visible = false;
            DtgAtolye.Columns["IslemAdimiSorumlusu"].Visible = false;
            DtgAtolye.Columns["AtolyeKategori"].Visible = false;
        }

        void IslemAdimlariSureleri()
        {
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetList(id, "BAKIM ONARIM");
            DtgIslemKayitlari.DataSource = gorevAtamaPersonels;

            DtgIslemKayitlari.Columns["Id"].Visible = false;
            DtgIslemKayitlari.Columns["BenzersizId"].Visible = false;
            DtgIslemKayitlari.Columns["Departman"].Visible = false;
            DtgIslemKayitlari.Columns["GorevAtanacakPersonel"].HeaderText = "GÖREV ATANAN PERSONEL";
            DtgIslemKayitlari.Columns["IslemAdimi"].HeaderText = "İŞLEM ADIMI";
            DtgIslemKayitlari.Columns["Tarih"].HeaderText = "TARİH";
            DtgIslemKayitlari.Columns["Sure"].HeaderText = "İŞLEM ADIMI SÜRELERİ";
            DtgIslemKayitlari.Columns["YapilanIslem"].HeaderText = "YAPILAN İŞLEM";
            DtgIslemKayitlari.Columns["CalismaSuresi"].HeaderText = "ÇALIŞMA SÜRESİ";
            DtgIslemKayitlari.Columns["AbfNo"].Visible = false;

            DtgIslemKayitlari.Columns["SirketBolum"].Visible = false;
            DtgIslemKayitlari.Columns["ToplamGorevSayisi"].Visible = false;
            DtgIslemKayitlari.Columns["DevamEdenSureOrtGun"].Visible = false;
            DtgIslemKayitlari.Columns["TamamlananGorevOrtSure"].Visible = false;

            DtgIslemKayitlari.Columns["CalismaSuresi"].DefaultCellStyle.Format = @"HH:mm:ss";

            foreach (DataGridViewRow row in DtgIslemKayitlari.Rows)
            {
                string value = row.Cells["CalismaSuresi"].Value.ToString();
                row.Cells["CalismaSuresi"].Value = value.Substring(value.IndexOf(' ') + 1);
            }
            Toplamlar();
            ToplamlarIslemAdimSureleri();

            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }
        void ToplamlarIslemAdimSureleri()
        {
            int toplamDakika = 0;
            int toplamSaat = 0;
            int toplamGun = 0;

            foreach (DataGridViewRow item in DtgIslemKayitlari.Rows)
            {
                string sure = item.Cells["Sure"].Value.ToString();
                if (sure == "Devam Ediyor")
                {
                    LblIslemAdimSureleri.Text = toplamGun + " Gün " + toplamSaat + " Saat " + toplamDakika + " Dakika";
                    return;
                }

                string[] array = sure.Split(' ');
                int mevcutDakika = array[4].ConInt();
                int mevcutSaat = array[2].ConInt();
                int mevcutGun = array[0].ConInt();

                toplamDakika = toplamDakika + mevcutDakika;

                if (toplamDakika >= 60)
                {
                    toplamSaat = toplamSaat + (toplamDakika / 60);
                    toplamDakika = toplamDakika % 60;
                }

                toplamSaat = toplamSaat + mevcutSaat;

                if (toplamSaat >= 24)
                {
                    toplamGun = toplamGun + (toplamSaat / 24);
                    toplamSaat = toplamSaat % 24;
                }

                toplamGun = toplamGun + mevcutGun;
            }
        }
        void Toplamlar()
        {
            DateTime toplam = DateTime.Now.Date;
            for (int i = 0; i < DtgIslemKayitlari.Rows.Count; ++i)
            {
                string value = DtgIslemKayitlari.Rows[i].Cells["CalismaSuresi"].Value.ToString();
                if (DateTime.TryParse(value, out _))
                {
                    toplam = toplam.AddSeconds(value.ConDate().Minute * 60);
                    toplam = toplam.AddSeconds(value.ConDate().Hour * 3660);
                }
                //toplam += Convert.ToDouble(DtgIslemKayitlari.Rows[i].Cells["IscilikSuresi"].Value);

            }
            LblGenelTop.Text = $"{toplam.Hour}:{toplam.Minute}:{toplam.Second}";
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
            GrbVeriGecmisi.Visible = true;
            //tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage3"]);
            GrbMalzemeBilgileri.Visible = false;
            BtnKaydet.Location = new System.Drawing.Point(161, 405);
            GrbMalzemeBilgileri.Location = new System.Drawing.Point(118, 460);
            if (LblMevcutIslemAdimi.Text == "200_ARIZA TESPİTİ (FI/FD) (SAHA)")
            {
                GrbMalzemeBilgileri.Visible = true;
                BtnKaydet.Location = new System.Drawing.Point(29, 831);
                GrbMalzemeBilgileri.Location = new System.Drawing.Point(18, 415);
                GrbVeriGecmisi.Visible = false;
                //ChkKapat.Text = "SADECE AÇIKLAMA EKLE";
                //ChkKapat.Visible = true;
                //tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage2"]);
            }
            if (LblMevcutIslemAdimi.Text == "1500_BAKIM ONARIM (SAHA)")
            {
                GrbMalzemeBilgileri.Visible = true;
                BtnKaydet.Location = new System.Drawing.Point(29, 831);
                GrbMalzemeBilgileri.Location = new System.Drawing.Point(18, 415);
                GrbVeriGecmisi.Visible = false;
                //ChkKapat.Text = "SADECE AÇIKLAMA EKLE";
                //ChkKapat.Visible = true;
                //tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage1"]);
            }

            if (LblMevcutIslemAdimi.Text == "300_ONARIM SONRASI ARIZA TESPİTİ (SAHA)")
            {
                GrbMalzemeBilgileri.Visible = true;
                BtnKaydet.Location = new System.Drawing.Point(29, 831);
                GrbMalzemeBilgileri.Location = new System.Drawing.Point(18, 415);
                GrbVeriGecmisi.Visible = false;
                //ChkKapat.Text = "SADECE AÇIKLAMA EKLE";
                //ChkKapat.Visible = true;
                //tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage2"]);
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
            bolgeAdi = arizaKayit.BolgeAdi;
            abf = abfForm.ToString();
            IslemAdimlariSureleri();
            DepoHareketleri();
            AtolyeKayitlari();
            MalzemeListesi();
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
        void MalzemeListesi()
        {
            abfMalzemes = abfMalzemeManager.GetList(id);
            DtgMalzemeListesi.DataSource = abfMalzemes;

            DtgMalzemeListesi.Columns["Id"].Visible = false;
            DtgMalzemeListesi.Columns["BenzersizId"].Visible = false;
            DtgMalzemeListesi.Columns["SokulenStokNo"].HeaderText = "SÖKÜLEN STOK NO";
            DtgMalzemeListesi.Columns["SokulenTanim"].HeaderText = "SÖKÜLEN TANIM";
            DtgMalzemeListesi.Columns["SokulenSeriNo"].HeaderText = "SÖKÜLEN SERİ NO";
            DtgMalzemeListesi.Columns["SokulenMiktar"].HeaderText = "SÖKÜLEN MİKTAR";
            DtgMalzemeListesi.Columns["SokulenBirim"].HeaderText = "SÖKÜLEN BİRİM";
            DtgMalzemeListesi.Columns["SokulenCalismaSaati"].HeaderText = "SÖKÜLEN ÇALIŞMA SAATİ";
            DtgMalzemeListesi.Columns["SokulenRevizyon"].HeaderText = "SÖKÜLEN REVİZYON";
            DtgMalzemeListesi.Columns["CalismaDurumu"].HeaderText = "ÇALIŞMA DURUMU";
            DtgMalzemeListesi.Columns["FizikselDurum"].HeaderText = "FİSİZKSEL DURUM";
            DtgMalzemeListesi.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgMalzemeListesi.Columns["TakilanStokNo"].HeaderText = "TAKILAN STOK NO";
            DtgMalzemeListesi.Columns["TakilanTanim"].HeaderText = "TAKILAN TANIM";
            DtgMalzemeListesi.Columns["TakilanSeriNo"].HeaderText = "TAKILAN SERİ NO";
            DtgMalzemeListesi.Columns["TakilanMiktar"].HeaderText = "TAKILAN MİKTAR";
            DtgMalzemeListesi.Columns["TakilanBirim"].HeaderText = "TAKILAN BİRİM";
            DtgMalzemeListesi.Columns["TakilanCalismaSaati"].HeaderText = "TAKILAN ÇALIŞMA SAATİ";
            DtgMalzemeListesi.Columns["TakilanRevizyon"].HeaderText = "TAKILAN REVİZYON";
            DtgMalzemeListesi.Columns["TeminDurumu"].HeaderText = "MALZEME DURUMU";
            DtgMalzemeListesi.Columns["AbfNo"].Visible = false;
            DtgMalzemeListesi.Columns["AbTarihSaat"].Visible = false;
            DtgMalzemeListesi.Columns["TemineAtilamTarihi"].Visible = false;
            DtgMalzemeListesi.Columns["MalzemeDurumu"].Visible = false;
            DtgMalzemeListesi.Columns["MalzemeIslemAdimi"].HeaderText = "İŞLEM DURUMU";
            DtgMalzemeListesi.Columns["SokulenTeslimDurum"].HeaderText = "SÖKÜLEN MALZEME TESLİMİ";
            DtgMalzemeListesi.Columns["BolgeAdi"].Visible = false;
            DtgMalzemeListesi.Columns["BolgeSorumlusu"].Visible = false;
            DtgMalzemeListesi.Columns["YerineMalzemeTakilma"].HeaderText = "YERİNE MALZEME TAKILDI MI?";
            DtgMalzemeListesi.Columns["DosyaYolu"].Visible = false;
            DtgMalzemeListesi.Columns["AltYukleniciKayit"].HeaderText = "ALT YÜKLENİCİ FİRMA";
            DtgMalzemeListesi.Columns["TakilanTeslimDurum"].HeaderText = "TAKILAN MALZEME TESLİMİ";

            DtgMalzemeListesi.Columns["TakilanTeslimDurum"].DisplayIndex = 26;

        }

        private void CmbIslemAdimi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbIslemAdimi.Text == "400_SİPARİŞ OLUŞTURMA (DTS)")
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
            if (rightControl == true)
            {
                BulClick();
                rightControl = false;

            }
        }

        private void TxtSokulenTanim_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
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

        private void DtgTakilan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgTakilan.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void DtgAtolye_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgAtolye.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            atolyeId = DtgAtolye.CurrentRow.Cells["Id"].Value.ConInt();
            AtolyeIslemAdimlariSureleri();
        }
        void AtolyeIslemAdimlariSureleri()
        {
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetList(atolyeId, "BAKIM ONARIM ATOLYE");
            DtgAtolyeIslemler.DataSource = gorevAtamaPersonels;

            DtgAtolyeIslemler.Columns["Id"].Visible = false;
            DtgAtolyeIslemler.Columns["BenzersizId"].Visible = false;
            DtgAtolyeIslemler.Columns["Departman"].Visible = false;
            DtgAtolyeIslemler.Columns["GorevAtanacakPersonel"].HeaderText = "GÖREV ATANAN PERSONEL";
            DtgAtolyeIslemler.Columns["IslemAdimi"].HeaderText = "İŞLEM ADIMI";
            DtgAtolyeIslemler.Columns["Tarih"].HeaderText = "TARİH";
            DtgAtolyeIslemler.Columns["Sure"].HeaderText = "İŞLEM ADIMI SÜRELERİ";
            DtgAtolyeIslemler.Columns["YapilanIslem"].HeaderText = "YAPILAN İŞLEM";
            DtgAtolyeIslemler.Columns["CalismaSuresi"].HeaderText = "ÇALIŞMA SÜRESİ";
            DtgAtolyeIslemler.Columns["CalismaSuresi"].DefaultCellStyle.Format = @"HH:mm:ss";

            foreach (DataGridViewRow row in DtgIslemKayitlari.Rows)
            {
                string value = row.Cells["CalismaSuresi"].Value.ToString();
                row.Cells["CalismaSuresi"].Value = value.Substring(value.IndexOf(' ') + 1);
            }

            AtolyeToplamlar();
            AtolyeToplamlarIslemAdimSureleri();
        }
        void AtolyeToplamlarIslemAdimSureleri()
        {
            int toplamDakika = 0;
            int toplamSaat = 0;
            int toplamGun = 0;

            foreach (DataGridViewRow item in DtgAtolyeIslemler.Rows)
            {
                string sure = item.Cells["Sure"].Value.ToString();
                if (sure == "Devam Ediyor")
                {
                    LblAtolyeIslemAdimiTop.Text = toplamGun + " Gün " + toplamSaat + " Saat " + toplamDakika + " Dakika";
                    return;
                }

                string[] array = sure.Split(' ');
                int mevcutDakika = array[4].ConInt();
                int mevcutSaat = array[2].ConInt();
                int mevcutGun = array[0].ConInt();

                toplamDakika = toplamDakika + mevcutDakika;

                if (toplamDakika >= 60)
                {
                    toplamSaat = toplamSaat + (toplamDakika / 60);
                    toplamDakika = toplamDakika % 60;
                }

                toplamSaat = toplamSaat + mevcutSaat;

                if (toplamSaat >= 24)
                {
                    toplamGun = toplamGun + (toplamSaat / 24);
                    toplamSaat = toplamSaat % 24;
                }

                toplamGun = toplamGun + mevcutGun;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (malzemeId == 0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmMalzemeVeriGecmisi frmMalzemeVeriGecmisi = new FrmMalzemeVeriGecmisi();
            frmMalzemeVeriGecmisi.benzersizId = malzemeId;
            frmMalzemeVeriGecmisi.sokulenstok = stok;
            frmMalzemeVeriGecmisi.sokulentanim = tanim;
            frmMalzemeVeriGecmisi.sokulenmiktar = miktar;
            frmMalzemeVeriGecmisi.sokulenbirim = birim;
            frmMalzemeVeriGecmisi.sokulenSeriNo = sokulenSeriLotNo;
            frmMalzemeVeriGecmisi.sokulenRevizyon = sokulenRevizyon;
            frmMalzemeVeriGecmisi.takilanstok = takilanStokNo;
            frmMalzemeVeriGecmisi.takilanSeriNo = takilanSeriNo;
            frmMalzemeVeriGecmisi.takilanbirim = takilanBirim;
            frmMalzemeVeriGecmisi.takilanRevizyon = takilanRevizyon;
            frmMalzemeVeriGecmisi.takilantanim = takilanTanim;
            frmMalzemeVeriGecmisi.takilanmiktar = takilanMiktar.ConInt();
            frmMalzemeVeriGecmisi.infos = infos;
            frmMalzemeVeriGecmisi.ShowDialog();
            malzemeId = 0;
        }
        string stok, tanim, sokulenSeriLotNo, sokulenRevizyon, takilanStokNo, takilanSeriNo, takilanRevizyon, takilanTanim, takilanBirim, miktar, birim; int takilanMiktar, malzemeId;
        private void DtgMalzemeListesi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgMalzemeListesi.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            malzemeId = DtgMalzemeListesi.CurrentRow.Cells["Id"].Value.ConInt();
            stok = DtgMalzemeListesi.CurrentRow.Cells["SokulenStokNo"].Value.ToString();
            tanim = DtgMalzemeListesi.CurrentRow.Cells["SokulenTanim"].Value.ToString();
            miktar = DtgMalzemeListesi.CurrentRow.Cells["SokulenMiktar"].Value.ToString();
            birim = DtgMalzemeListesi.CurrentRow.Cells["SokulenBirim"].Value.ToString();
            sokulenSeriLotNo = DtgMalzemeListesi.CurrentRow.Cells["SokulenSeriNo"].Value.ToString();
            sokulenRevizyon = DtgMalzemeListesi.CurrentRow.Cells["SokulenRevizyon"].Value.ToString();
            takilanStokNo = DtgMalzemeListesi.CurrentRow.Cells["TakilanStokNo"].Value.ToString();
            takilanTanim = DtgMalzemeListesi.CurrentRow.Cells["TakilanTanim"].Value.ToString();
            takilanBirim = DtgMalzemeListesi.CurrentRow.Cells["TakilanBirim"].Value.ToString();
            takilanMiktar = DtgMalzemeListesi.CurrentRow.Cells["TakilanMiktar"].Value.ConInt();
            takilanSeriNo = DtgMalzemeListesi.CurrentRow.Cells["TakilanSeriNo"].Value.ToString();
            takilanRevizyon = DtgMalzemeListesi.CurrentRow.Cells["TakilanRevizyon"].Value.ToString();
        }

        void AtolyeToplamlar()
        {
            DateTime toplam = DateTime.Now.Date;
            for (int i = 0; i < DtgAtolyeIslemler.Rows.Count; ++i)
            {
                string value = DtgAtolyeIslemler.Rows[i].Cells["CalismaSuresi"].Value.ToString();
                if (DateTime.TryParse(value, out _))
                {
                    toplam = toplam.AddSeconds(value.ConDate().Minute * 60);
                    toplam = toplam.AddSeconds(value.ConDate().Hour * 3660);
                }
                //toplam += Convert.ToDouble(DtgIslemKayitlari.Rows[i].Cells["IscilikSuresi"].Value);

            }
            LblToplamIsclikAtolye.Text = $"{toplam.Hour}:{toplam.Minute}:{toplam.Second}";
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
            DtgTakilan.Rows[sonSatir].Cells["TakilanTeslimDurum"].Value = "";
            TakilanTemizle();
        }
        string KayitKontrol()
        {
            if (CmbIslemAdimi.Text == "")
            {
                return "Lütfen İşlem adımı bilgisini seçiniz!";
            }
            if (CmbGorevAtanacakPersonel.Text == "")
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
                //if (DtgSokulen.RowCount == 0)
                //{
                //    return "Lütfen Öncelikle SÖKÜLEN MALZEMELER Bilgisini Doldurunuz!";
                //}
                //if (CmbGarantiDurumu.Text == "")
                //{
                //    return "Lütfen GARANTİ DURUMU bilgisini doldurunuz!";
                //}
                //if (CmbGarantiDurumu.Text == "DIŞI" || CmbGarantiDurumu.Text == "PDL-5 OPSİYONEL")
                //{
                //    if (TxtLojistikSorumlusu.Text == "")
                //    {
                //        return "Lütfen LOJİSTİK SORUMLUSU bilgisini doldurunuz!";
                //    }
                //    if (TxtLojistikSorRutbesi.Text == "")
                //    {
                //        return "Lütfen LOJİSTİK SORUMLUSU RÜTBE bilgisini doldurunuz!";
                //    }
                //    if (TxtLojistikSorGorevi.Text == "")
                //    {
                //        return "Lütfen LOJİSTİK SORUMLUSU GÖREVİ bilgisini doldurunuz!";
                //    }
                //}
                //if (CmbParcaNo.Text == "")
                //{
                //    return "Lütfen ÜST TAKIM bilgilerini eksiksiz doldurunuz!";
                //}
                //if (TxtSeriNo.Text == "")
                //{
                //    return "Lütfen ÜST TAKIM SERİ NO bilgisini eksiksiz doldurunuz!\nBilinmiyor ise N/A yazabilirsiniz.";
                //}

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

                if (item.Cells["FizikselDurumu"].Value.ToString() == "SÖKÜLDÜ")
                {
                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(id, "ARA DEPO (İADE)", DateTime.Now, infos[1].ToString(), 0, "SÖKÜLEN", item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["RevizyonSokulen"].Value.ToString());
                    abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);
                }
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

        bool tekrarliIslemAdimi = false;

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (infos[1].ToString() != "RESUL GÜNEŞ")
            {
                if (infos[11].ToString() != "MİSAFİR")
                {
                    if (AdvPersonel.RowCount == 0)
                    {
                        MessageBox.Show("Lütfen işlem adımı için geçerli olan işçilik bilgilerini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
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
                tekrarliIslemAdimi = false;
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                gorevAtamaPersonels = gorevAtamaPersonelManager.GetList(id, "BAKIM ONARIM");
                foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
                {
                    if (item.IslemAdimi == LblMevcutIslemAdimi.Text && item.Sure != "Devam Ediyor")
                    {
                        tekrarliIslemAdimi = true;
                        break;
                    }
                }

                if (tekrarliIslemAdimi != true)
                {
                    if (DtgSokulen.RowCount == 0)
                    {
                        MessageBox.Show("Lütfen sökülen malzeme bilgilerini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (CmbGarantiDurumu.Text == "")
                    {
                        MessageBox.Show("Lütfen Garanti Durumu Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }

            if (LblMevcutIslemAdimi.Text == "300_ONARIM SONRASI ARIZA TESPİTİ (SAHA)")
            {
                tekrarliIslemAdimi = false;
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                gorevAtamaPersonels = gorevAtamaPersonelManager.GetList(id, "BAKIM ONARIM");
                foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
                {
                    if (item.IslemAdimi == LblMevcutIslemAdimi.Text && item.Sure != "Devam Ediyor")
                    {
                        tekrarliIslemAdimi = true;
                        break;
                    }
                }

                if (tekrarliIslemAdimi != true)
                {
                    if (DtgSokulen.RowCount == 0)
                    {
                        MessageBox.Show("Lütfen sökülen malzeme bilgilerini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (CmbGarantiDurumu.Text == "")
                    {
                        MessageBox.Show("Lütfen Garanti Durumu Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }

            if (LblMevcutIslemAdimi.Text == "1500_BAKIM ONARIM (SAHA)")
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                gorevAtamaPersonels = gorevAtamaPersonelManager.GetList(id, "BAKIM ONARIM");
                foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
                {
                    if (item.IslemAdimi == LblMevcutIslemAdimi.Text && item.Sure != "Devam Ediyor")
                    {
                        tekrarliIslemAdimi = true;
                        break;
                    }
                }


                string[] islemadimi = CmbIslemAdimi.Text.Split('_');

                if (tekrarliIslemAdimi != true)
                {
                    if (islemadimi[0].ConInt() > 1500 && islemadimi[0].ConInt() != 300)
                    {
                        if (CmbIslemAdimi.Text != "1500_BAKIM ONARIM (SAHA)")
                        {
                            if (CmbIslemAdimi.Text != "1000_DEPO STOK KONTROL")
                            {
                                abfMalzemes = abfMalzemeManager.GetList(id);
                                if (abfMalzemes == null)
                                {
                                    MessageBox.Show("Arızaya Ait Sökülen Malzeme Bulunamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                foreach (DataGridViewRow item in DtgTakilan.Rows)
                                {
                                    if (abfMalzemes.Any(x => x.SokulenStokNo.Equals(item.Cells["TakilanStokNo"].Value.ToString()) && x.FizikselDurum == "SÖKÜLMEDİ"))
                                    {
                                        MessageBox.Show("Arızalı malzemeyi sökmeden yerine malzeme takamazsınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }

                                if (DtgTakilan.RowCount == 0)
                                {
                                    MessageBox.Show("Lütfen takılan malzeme bilgilerini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                            }

                        }
                    }
                }

            }
            if (LblMevcutIslemAdimi.Text == "300_ONARIM SONRASI ARIZA TESPİTİ (SAHA)")
            {
                if (DtgSokulen.RowCount == 0)
                {
                    MessageBox.Show("Lütfen sökülen malzeme bilgilerini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
            if (infos[1].ToString() != "RESUL GÜNEŞ")
            {
                if (infos[11].ToString() != "MİSAFİR")
                {
                    string kontrol = PersonelIscilikleriEkle();
                    if (kontrol != "OK")
                    {
                        MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }

            if (CmbIslemAdimi.Text == "2000_ARIZA KAPATMA (DTS)")
            {
                arizaKayitManager.ArizaDurumUpdate(id, 0);
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
                    arizaKayitManager.ArizaDurumUpdate(id, 1);
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
                if (tekrarliIslemAdimi == false)
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

                        AbfMalzeme abfMalzeme = abfMalzemeManager.GetBul(id, item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["RevizyonSokulen"].Value.ToString());

                        if (item.Cells["FizikselDurumu"].Value.ToString() == "SÖKÜLDÜ")
                        {
                            AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(abfMalzeme.Id, "ARA DEPO (İADE)", DateTime.Now, infos[1].ToString(), 0, "SÖKÜLEN", item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["RevizyonSokulen"].Value.ToString());
                            abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);
                        }
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

            }

            if (LblMevcutIslemAdimi.Text == "300_ONARIM SONRASI ARIZA TESPİTİ (SAHA)")
            {
                //bool control = false;
                //abfMalzemes = abfMalzemeManager.GetList(id);
                //int index = 0;

                //if (abfMalzemes.Any(x => x.SokulenStokNo.Equals(x.TakilanStokNo)))
                //{
                //    if (abfMalzemes[index].TakilanTeslimDurum == "BÖLGE SORUMLUSU TARAFINDAN TESLİM ALINDI")
                //    {
                //        control = true;
                //    }
                //    else
                //    {
                //        control = false;
                //        index++;
                //    }
                //}
                //if (control == false)
                //{
                //    MessageBox.Show("Lütfen öncelikle sökülen olarak gireceğiniz malzemeyi teslim/tesellüm üzerinden teslim alınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                foreach (DataGridViewRow item in DtgSokulen.Rows)
                {
                    AbfMalzeme abfMalzemeSokulen = new AbfMalzeme(id, item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(), item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(),
                        item.Cells["SokulenBirim"].Value.ToString(), item.Cells["CalismaSaatiSokulen"].Value.ConDouble(), item.Cells["RevizyonSokulen"].Value.ToString(), item.Cells["CalısmaDurumu"].Value.ToString(), item.Cells["FizikselDurumu"].Value.ToString(), item.Cells["MalzemeYapilacakIslem"].Value.ToString());

                    abfMalzemeManager.AddSokulen(abfMalzemeSokulen);

                    AbfMalzeme abfMalzeme = abfMalzemeManager.GetBul(id, item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["RevizyonSokulen"].Value.ToString());

                    if (item.Cells["FizikselDurumu"].Value.ToString() == "SÖKÜLDÜ")
                    {
                        AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(abfMalzeme.Id, "ARA DEPO (İADE)", DateTime.Now, infos[1].ToString(), 0, "SÖKÜLEN", item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["RevizyonSokulen"].Value.ToString());
                        abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);
                    }

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
                if (tekrarliIslemAdimi == false) // KONTROL EDİLECEK
                {
                    if (CmbIslemAdimi.Text != "1500_BAKIM ONARIM (SAHA)")
                    {
                        if (CmbIslemAdimi.Text != "1000_STOK KONTROL (DEPO)")
                        {
                            abfMalzemes = abfMalzemeManager.GetList(id);

                            var addItems = new HashSet<AbfMalzeme>();
                            var updateItems = new HashSet<AbfMalzeme>();

                            foreach (DataGridViewRow takilan in DtgTakilan.Rows)
                            {
                                AbfMalzeme abfMalzeme = new AbfMalzeme(takilan.Cells["TakilanStokNo"].Value.ToString(), takilan.Cells["TakilanTanim"].Value.ToString(), takilan.Cells["TakilanSeriNo"].Value.ToString(), takilan.Cells["TakilanMiktar"].Value.ConInt(), takilan.Cells["TakilanBirim"].Value.ToString(), takilan.Cells["TakilanCalismaSaati"].Value.ConDouble(), takilan.Cells["TakilanRevizyon"].Value.ToString());

                                if (abfMalzemes.Any(x => x.SokulenStokNo.Equals(takilan.Cells["TakilanStokNo"].Value.ToString())))
                                {
                                    if (!abfMalzemes.Any(x => x.TakilanStokNo.Equals(takilan.Cells["TakilanStokNo"].Value.ToString())))
                                    {
                                        updateItems.Add(abfMalzeme);
                                    }

                                    if (takilan.Cells["TakilanTeslimDurum"].Value.ToString() != "BÖLGE SORUMLUSU TARAFINDAN TESLİM ALINDI")
                                    {
                                        AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(takilan.Cells["TakilanId"].Value.ConInt(), "SEVKİYAT ARACI (VAN - ARA DEPO)", takilan.Cells["TakilanStokNo"].Value.ToString(), takilan.Cells["TakilanSeriNo"].Value.ToString(), takilan.Cells["TakilanRevizyon"].Value.ToString(), "TAKILAN");

                                        if (abfMalzemeIslemKayit1 == null)
                                        {
                                            AbfMalzemeIslemKayit abfMalzemeIslemKayit2 = abfMalzemeIslemKayitManager.Get(takilan.Cells["TakilanId"].Value.ConInt(), "BÖLGEYE SEVKİYAT BEKLEYEN", takilan.Cells["TakilanStokNo"].Value.ToString(), takilan.Cells["TakilanSeriNo"].Value.ToString(), takilan.Cells["TakilanRevizyon"].Value.ToString(), "TAKILAN");
                                            if (abfMalzemeIslemKayit2 == null)
                                            {
                                                AbfMalzemeIslemKayit abfMalzemeIslemKayit3 = new AbfMalzemeIslemKayit(takilan.Cells["TakilanId"].Value.ConInt(), "BÖLGEYE SEVKİYAT BEKLEYEN", DateTime.Now, infos[1].ToString(), 1, "TAKILAN", takilan.Cells["TakilanStokNo"].Value.ToString(), takilan.Cells["TakilanSeriNo"].Value.ToString(), takilan.Cells["TakilanRevizyon"].Value.ToString());
                                                abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit3);
                                            }

                                            AbfMalzemeIslemKayit abfMalzemeIslemKayit4 = new AbfMalzemeIslemKayit(takilan.Cells["TakilanId"].Value.ConInt(), "SEVKİYAT ARACI (VAN - ARA DEPO)", DateTime.Now, infos[1].ToString(), 0, "TAKILAN", takilan.Cells["TakilanStokNo"].Value.ToString(), takilan.Cells["TakilanSeriNo"].Value.ToString(), takilan.Cells["TakilanRevizyon"].Value.ToString());
                                            abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit4);

                                            abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(takilan.Cells["TakilanId"].Value.ConInt(), "SEVKİYAT ARACI (VAN - ARA DEPO)", takilan.Cells["TakilanStokNo"].Value.ToString(), takilan.Cells["TakilanSeriNo"].Value.ToString(), takilan.Cells["TakilanRevizyon"].Value.ToString(), "TAKILAN");
                                        }

                                        if (abfMalzemeIslemKayit1.MalzemeDurumu == "SÖKÜLEN")
                                        {
                                            abfMalzemeManager.MalzemeTeslimBilgisiUpdate(takilan.Cells["TakilanId"].Value.ConInt(), "BÖLGE SORUMLUSU TARAFINDAN TESLİM ALINDI");
                                        }
                                        else
                                        {
                                            abfMalzemeManager.TakilanMalzemeTeslimBilgisiUpdate(takilan.Cells["TakilanId"].Value.ConInt(), "BÖLGE SORUMLUSU TARAFINDAN TESLİM ALINDI");
                                        }

                                        AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(takilan.Cells["TakilanId"].Value.ConInt(), "BÖLGE SORUMLUSU TARAFINDAN TESLİM ALINDI", DateTime.Now, infos[1].ToString(), 0, abfMalzemeIslemKayit1.MalzemeDurumu, takilan.Cells["TakilanStokNo"].Value.ToString(), takilan.Cells["TakilanSeriNo"].Value.ToString(), takilan.Cells["TakilanRevizyon"].Value.ToString());
                                        abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit);

                                        if (abfMalzemeIslemKayit1 != null)
                                        {
                                            TimeSpan gecenSure = DateTime.Now - abfMalzemeIslemKayit1.Tarih;
                                            if (gecenSure.TotalMinutes.ConInt() > 0)
                                            {
                                                abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, gecenSure.TotalMinutes.ConInt());
                                            }
                                            else
                                            {
                                                abfMalzemeIslemKayitManager.Update(abfMalzemeIslemKayit1.Id, 1);
                                            }
                                        }
                                    }

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
                                abfMalzemeManager.YerineMalzemeTakilma(sokulenId);


                                index++;
                            }
                            foreach (AbfMalzeme item in addItems)
                            {
                                abfMalzemeManager.AddTakilan(item, id);

                                AbfMalzemeIslemKayit abfMalzemeIslemKayit3 = new AbfMalzemeIslemKayit(item.Id, "BÖLGEYE SEVKİYAT BEKLEYEN", DateTime.Now, infos[1].ToString(), 1, "TAKILAN", item.TakilanStokNo, item.TakilanSeriNo, item.TakilanRevizyon);
                                abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit3);

                                AbfMalzemeIslemKayit abfMalzemeIslemKayit4 = new AbfMalzemeIslemKayit(item.Id, "SEVKİYAT ARACI (VAN - ARA DEPO)", DateTime.Now, infos[1].ToString(), 1, "TAKILAN", item.TakilanStokNo, item.TakilanSeriNo, item.TakilanRevizyon);
                                abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit4);

                                AbfMalzemeIslemKayit abfMalzemeIslemKayit5 = new AbfMalzemeIslemKayit(item.Id, "BÖLGE SORUMLUSU TARAFINDAN TESLİM ALINDI", DateTime.Now, infos[1].ToString(), 1, "TAKILAN", item.TakilanStokNo, item.TakilanSeriNo, item.TakilanRevizyon);
                                abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit5);
                            }
                        }
                    }
                }
            }

            if (CmbIslemAdimi.Text == "2000_ARIZA KAPATMA (DTS)")
            {
                arizaKayitManager.ArizaDurumUpdate(id, 0);
                KapatmaKontrol();
            }

            string messege = GorevAtama();

            if (messege != "OK")
            {
                MessageBox.Show(messege, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtsLogKayit();
            MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            ChkKapat.Checked = false;
            tekrarliIslemAdimi = false;
        }

        void KapatmaKontrol()
        {
            List<AbfMalzeme> abfMalzemes1 = new List<AbfMalzeme>();
            abfMalzemes1 = abfMalzemeManager.GetList(id);
            bool[] dusumControls = new bool[abfMalzemes1.Count];
            bool[] iadeControls = new bool[abfMalzemes1.Count];

            // SÖKÜLEN VE TAKILAN GİRİLMİŞMİ KONTROLÜ
            for (int i = 0; i < abfMalzemes1.Count; i++)
            {
                if ((abfMalzemes1[i].SokulenStokNo == abfMalzemes1[i].TakilanStokNo) || (abfMalzemes1[i].SokulenTanim == abfMalzemes1[i].TakilanTanim))
                {
                    dusumControls[i] = true;
                }
                else
                {
                    if (i + 1 < abfMalzemes1.Count)
                    {
                        if (abfMalzemes1[i].SokulenTanim == abfMalzemes1[i + 1].TakilanTanim)
                        {
                            dusumControls[i] = true;
                        }
                        else
                        {
                            dusumControls[i] = false;
                        }
                    }
                    else
                    {
                        dusumControls[i] = false;
                    }
                }

                List<StokGirisCıkıs> stokGirisCıkıs2 = new List<StokGirisCıkıs>();
                List<MalzemeKayit> malzemeKayits = new List<MalzemeKayit>();
                Malzeme malzeme = malzemeManager.MalzemeBul(abfMalzemes1[i].SokulenStokNo);
                if (malzeme.TakipDurumu=="SERİ NO")
                {
                    if (abfMalzemes1[i].SokulenSeriNo != "N/A")
                    {
                        stokGirisCıkıs2 = stokGirisCikisManager.ArizaIadeControlList(abf, abfMalzemes1[i].SokulenStokNo, abfMalzemes1[i].SokulenSeriNo, "N/A", abfMalzemes1[i].SokulenRevizyon);
                    }
                }
                else
                {
                    stokGirisCıkıs2 = stokGirisCikisManager.ArizaIadeControlList(abf, abfMalzemes1[i].SokulenStokNo, "", "", "");
                }
                if (stokGirisCıkıs2.Count > 0)
                {
                    iadeControls[i] = true;
                }
                else
                {
                    iadeControls[i] = false;
                }

            }
            bool control = true;
            for (int i = 0; i < dusumControls.Length; i++)
            {
                if (dusumControls[i] == false || iadeControls[i] == false)
                {
                    control = false;
                    break;
                }
            }

            if (control == true)
            {
                arizaKayitManager.BakimOnarimKapatmaDurumu(id, "HAZIR");
            }

            //201-BİLDİRİMDEN DEPOYA İADE
        }


        void DtsLogKayit()
        {
            string islem = bolgeAdi + " bölgesinin " + abf + " ABF Numaralı arıza kaydı " + LblMevcutIslemAdimi.Text + " adımından " + CmbIslemAdimi.Text + " adımına, " + CmbGorevAtanacakPersonel.Text + " kişisine görev atanarak güncellenmiştir.";
            DtsLog dtsLog = new DtsLog(infos[1].ToString(), DateTime.Now, "BİLDİRİM DURUM GÜNCELLE", islem);
            dtsLogManager.Add(dtsLog);
        }

        string GorevAtama()
        {
            int guncellenecekId = 0;
            List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(id, "BAKIM ONARIM");

            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == LblMevcutIslemAdimi.Text)
                {
                    guncellenecekId = item.Id;
                }
            }

            if (LblMevcutIslemAdimi.Text == CmbIslemAdimi.Text)
            {
                sure = 0 + " Gün " + 0 + " Saat " + 0 + " Dakika";
            }

            if (LblMevcutIslemAdimi.Text == "2100_ARIZA KAPATMA BİLDİRİMİ (ASELSAN)" && ChkKapat.Checked == true)
            {
                GorevAtamaPersonel gorevAtama2 = new GorevAtamaPersonel(guncellenecekId, id, "BAKIM ONARIM", LblMevcutIslemAdimi.Text, sure, DtIscilikSaati.Value, infos[1].ToString());
                string kontrol3 = gorevAtamaPersonelManager.Update(gorevAtama2, TxtYapilanIslemler.Text.ToUpper());
                if (kontrol3 != "OK")
                {
                    return kontrol3;
                }
                return "OK";
            }

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(guncellenecekId, id, "BAKIM ONARIM", LblMevcutIslemAdimi.Text, sure, DtIscilikSaati.Value, infos[1].ToString());
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
            DtgIslemKayitlari.DataSource = null;
            DtgMalzemeListesi.DataSource = null;
            DtgDepoHareketleri.DataSource = null;
            DtgAtolye.DataSource = null;
            DtgAtolyeIslemler.DataSource = null;
        }
    }
}
