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
using Entity.IdariIsler;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.STS;
using Entity.BakimOnarimAtolye;

namespace UserInterface.BakımOnarım
{
    public partial class FrmArizaAcmaCalisma : Form
    {
        ComboManager comboManager;
        SatTalebiDoldurManager satTalebiDoldurManager;
        BolgeManager bolgeManager;
        PersonelKayitManager kayitManager;
        IsAkisNoManager isAkisNoManager;
        ArizaKayitManager arizaKayitManager;
        AbfFormNoManager abfFormNoManager;
        MalzemeKayitManager malzemeKayitManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        IslemAdimlariManager islemAdimlariManager;
        PypManager pypManager;
        AbfMalzemeManager abfMalzemeManager;
        IscilikIscilikManager ıscilikIscilikManager;
        AtolyeManager atolyeManager;
        StokGirisCikisManager stokGirisCikisManager;

        bool start = true, dosyaKontrol = false, kayitKontrol = false;
        public object[] infos;
        string isAkisNo, dosyaYolu = "", kaynakdosyaismi, alinandosya, proje, siparisNo, comboAd, personelGorevi, personelBolumu, sure;
        List<string> fileNames = new List<string>();
        List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
        List<StokGirisCıkıs> stokGirisCıkıs;
        List<GorevAtamaPersonel> gorevAtamaPersonels;
        List<Atolye> atolyes;
        List<ArizaKayit> arizaKayits;
        int abfForm, abf, gun, saat, dakika;
        DateTime birOncekiTarih;
        public int id;
        string lojTarihi, dosya;


        public FrmArizaAcmaCalisma()
        {
            InitializeComponent();
            comboManager = ComboManager.GetInstance();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
            bolgeManager = BolgeManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            abfFormNoManager = AbfFormNoManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            pypManager = PypManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            islemAdimlariManager = IslemAdimlariManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            ıscilikIscilikManager = IscilikIscilikManager.GetInstance();
            atolyeManager = AtolyeManager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
        }

        private void FrmArizaAcmaCalisma_Load(object sender, EventArgs e)
        {
            CmbProj();
            UsBolgeleri();
            Personeller();
            Personeller2();
            IsAkisNo();
            CmbStokNo();
            Kategori();
            Pyp();
            IlgiliFirma();
            BildirimTuru();
            Personeller3();
            IslemAdimlari();
            Personeller4();
            Personeller5();
            CrmIslemAdimlari();
            Personeller7();
            HasarKodu();
            NedenKodu();
            NesneTanimi();
            EksikEvrakList();
            start = false;
            LblArizaBildirimiAlan.Text = infos[1].ToString();
        }
        public void Yenilenecekler()
        {
            start = true;
            CmbProj();
            UsBolgeleri();
            Personeller();
            Personeller2();
            IsAkisNo();
            CmbStokNo();
            Kategori();
            Pyp();
            IlgiliFirma();
            BildirimTuru();
            Personeller3();
            IslemAdimlari();
            Personeller4();
            Personeller5();
            Personeller7();
            CrmIslemAdimlari();
            HasarKodu();
            NedenKodu();
            NesneTanimi();
            EksikEvrakList();
            start = false;
        }
        int AbfFormNo()
        {
            abfFormNoManager.Update();
            AbfFormNo abfFormNo = abfFormNoManager.Get();
            return abfFormNo.FormNo;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (kayitKontrol == false)
            {
                if (dosyaKontrol == true)
                {
                    Directory.Delete(dosyaYolu, true);
                }
            }

            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageArizaAc"]);
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
            CmbParcaNo.DataSource = malzemeKayitManager.UstTakimGetList();
            CmbParcaNo.ValueMember = "Id";
            CmbParcaNo.DisplayMember = "Tanim";
            CmbParcaNo.SelectedValue = 0;
        }
        void IlgiliFirma()
        {
            CmbIlgiliFirma.DataSource = comboManager.GetList("ONARIM_YERI");
            CmbIlgiliFirma.ValueMember = "Id";
            CmbIlgiliFirma.DisplayMember = "Baslik";
            CmbIlgiliFirma.SelectedValue = 0;
        }
        public void BildirimTuru()
        {
            CmbBildirimTuru.DataSource = comboManager.GetList("BILDIRIM TURU");
            CmbBildirimTuru.ValueMember = "Id";
            CmbBildirimTuru.DisplayMember = "Baslik";
            CmbBildirimTuru.SelectedValue = 0;
        }
        public void HasarKodu()
        {
            CmbHasarKodu.DataSource = comboManager.GetList("HASAR_KODU");
            CmbHasarKodu.ValueMember = "Id";
            CmbHasarKodu.DisplayMember = "Baslik";
            CmbHasarKodu.SelectedValue = 0;
        }
        public void NedenKodu()
        {
            CmbNedenKodu.DataSource = comboManager.GetList("NEDEN_KODU");
            CmbNedenKodu.ValueMember = "Id";
            CmbNedenKodu.DisplayMember = "Baslik";
            CmbNedenKodu.SelectedValue = 0;
        }
        public void NesneTanimi()
        {
            CmbNesneTanimi.DataSource = comboManager.GetList("NESNE_TANIMI");
            CmbNesneTanimi.ValueMember = "Id";
            CmbNesneTanimi.DisplayMember = "Baslik";
            CmbNesneTanimi.SelectedValue = 0;
        }
        void Pyp()
        {
            CmbPypNo.DataSource = pypManager.GetList();
            CmbPypNo.ValueMember = "Id";
            CmbPypNo.DisplayMember = "PypNo";
            CmbPypNo.SelectedValue = 0;
        }

        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        void Kategori()
        {
            CmbKategori.DataSource = comboManager.GetList("ABF KATEGORİ");
            CmbKategori.ValueMember = "Id";
            CmbKategori.DisplayMember = "Baslik";
            CmbKategori.SelectedValue = 0;
        }

        void Personeller()
        {
            CmbGorevAtanacakPersonel.DataSource = kayitManager.PersonelAdSoyad();
            CmbGorevAtanacakPersonel.ValueMember = "Id";
            CmbGorevAtanacakPersonel.DisplayMember = "Adsoyad";
            CmbGorevAtanacakPersonel.SelectedValue = -1;
        }
        void Personeller2()
        {
            CmbPersoneller.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersoneller.ValueMember = "Id";
            CmbPersoneller.DisplayMember = "Adsoyad";
            CmbPersoneller.SelectedValue = -1;
        }
        void Personeller3()
        {
            CmbArizaAcmaOnayiVeren.DataSource = kayitManager.PersonelAdSoyad();
            CmbArizaAcmaOnayiVeren.ValueMember = "Id";
            CmbArizaAcmaOnayiVeren.DisplayMember = "Adsoyad";
            CmbArizaAcmaOnayiVeren.SelectedValue = -1;
        }
        
        void Personeller4()
        {
            CmbGorevAtanacak.DataSource = kayitManager.PersonelAdSoyad();
            CmbGorevAtanacak.ValueMember = "Id";
            CmbGorevAtanacak.DisplayMember = "Adsoyad";
            CmbGorevAtanacak.SelectedValue = -1;
        }
        void Personeller5()
        {
            CmbCrmGorevAtanacakPer.DataSource = kayitManager.PersonelAdSoyad();
            CmbCrmGorevAtanacakPer.ValueMember = "Id";
            CmbCrmGorevAtanacakPer.DisplayMember = "Adsoyad";
            CmbCrmGorevAtanacakPer.SelectedValue = -1;
        }
        void Personeller7()
        {
            CmbTeslimEden.DataSource = kayitManager.PersonelAdSoyad();
            CmbTeslimEden.ValueMember = "Id";
            CmbTeslimEden.DisplayMember = "Adsoyad";
            CmbTeslimEden.SelectedValue = -1;
        }
        void CmbProj()
        {
            CmbProje.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProje.ValueMember = "Id";
            CmbProje.DisplayMember = "Baslik";
            CmbProje.SelectedValue = 0;
        }
        void IslemAdimlari()
        {
            CmbIslemAdimi.DataSource = islemAdimlariManager.GetList("BAKIM ONARIM");
            CmbIslemAdimi.ValueMember = "Id";
            CmbIslemAdimi.DisplayMember = "IslemaAdimi";
            CmbIslemAdimi.SelectedValue = -1;
        }

        void CrmIslemAdimlari()
        {
            CmbCrmIslemAdimlari.DataSource = islemAdimlariManager.GetList("BAKIM ONARIM");
            CmbCrmIslemAdimlari.ValueMember = "Id";
            CmbCrmIslemAdimlari.DisplayMember = "IslemaAdimi";
            CmbCrmIslemAdimlari.SelectedValue = -1;
        }


        void SureBul()
        {
            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "BAKIM ONARIM");

            birOncekiTarih = gorevAtamaPersonel.Tarih;

            TimeSpan sonuc = DateTime.Now - birOncekiTarih;

            gun = sonuc.Days.ConInt();
            saat = sonuc.Hours.ConInt();
            if (sonuc.Hours < 1)
            {
                saat = 0;
            }

            dakika = sonuc.Seconds.ConInt() % 60;

            sure = gun.ToString() + " Gün " + saat.ToString() + " Saat " + dakika.ToString() + " Dakika";
        }
        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtAbfFormNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle ABF NO Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ArizaKayit arizaKayit = arizaKayitManager.Get(TxtAbfFormNo.Text.ConInt());
            if (arizaKayit == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz ABF Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleSiparisOlustur();
                return;
            }
            LblBolgeAdi.Text = arizaKayit.BolgeAdi;
            TxtBildirilenArizaSiparis.Text = arizaKayit.BildirilenAriza;
            TxtArizaBildirenSiparis.Text = arizaKayit.ArizaiBildirenPersonel;
            TxtArizaBildirenRutbesi.Text = arizaKayit.AbRutbesi;
            TxtArizaBildirenGorevi.Text = arizaKayit.AbGorevi;
            TxtArizaBildirenTarih.Value = arizaKayit.AbTarihSaat;
            TxtArizaBildirenSaat.Value = arizaKayit.AbTarihSaat;
            abf = arizaKayit.AbfFormNo;
            id = arizaKayit.Id;

            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "BAKIM ONARIM");
            if (gorevAtamaPersonel == null)
            {
                LblMevcutIslemAdimi.Text = "";
            }
            else
            {
                LblMevcutIslemAdimi.Text = gorevAtamaPersonel.IslemAdimi;
            }


            Bolge bolge = bolgeManager.Get(LblBolgeAdi.Text);
            if (bolge == null)
            {
                LblProje.Text = "";
                GrnBasTarihi.Text = "";
                GrnBitTarihi.Text = "";
            }
            else
            {
                LblProje.Text = bolge.Proje;
                GrnBasTarihi.Text = bolge.GarantiBaslama;
                GrnBitTarihi.Text = bolge.GarantiBitis;
            }
            if (GrnBitTarihi.Text.ConDate() < DateTime.Now)
            {
                GrnBitTarihi.BackColor = Color.Red;
            }
            else
            {
                GrnBitTarihi.BackColor = Color.WhiteSmoke;
            }
            SureBul();

            FillTools();

        }
        public void FillTools()
        {
            //MalzemeTemizle();

            abfMalzemes.Clear();
            abfMalzemes = abfMalzemeManager.GetList(id);
            DtgMalzemeList.DataSource = null;
            DtgMalzemeList.DataSource = abfMalzemes;

            DtgMalzemeList.Columns["Id"].Visible = false;
            DtgMalzemeList.Columns["BenzersizId"].Visible = false;
            DtgMalzemeList.Columns["SokulenStokNo"].HeaderText = "SÖKÜLEN STOK NO";
            DtgMalzemeList.Columns["SokulenTanim"].HeaderText = "SÖKÜLEN TANIM";
            DtgMalzemeList.Columns["SokulenSeriNo"].HeaderText = "SÖKÜLEN SERİ NO";
            DtgMalzemeList.Columns["SokulenMiktar"].HeaderText = "SÖKÜLEN MİKTAR";
            DtgMalzemeList.Columns["SokulenBirim"].HeaderText = "SÖKÜLEN BİRİM";
            DtgMalzemeList.Columns["SokulenCalismaSaati"].HeaderText = "SÖKÜLEN ÇALIŞMA SAATİ";
            DtgMalzemeList.Columns["SokulenRevizyon"].HeaderText = "SÖKÜLEN REVİZYON";
            DtgMalzemeList.Columns["CalismaDurumu"].HeaderText = "ÇALIŞMA DURUMU";
            DtgMalzemeList.Columns["FizikselDurum"].HeaderText = "FİZİKSEL DURUM";
            DtgMalzemeList.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgMalzemeList.Columns["TakilanStokNo"].HeaderText = "TAKILAN STOK NO";
            DtgMalzemeList.Columns["TakilanTanim"].HeaderText = "TAKILAN TANIM";
            DtgMalzemeList.Columns["TakilanMiktar"].HeaderText = "TAKILAN MİKTAR";
            DtgMalzemeList.Columns["TakilanBirim"].HeaderText = "TAKILAN BİRİM";
            DtgMalzemeList.Columns["TakilanSeriNo"].HeaderText = "TAKILAN SERİ NO";
            DtgMalzemeList.Columns["TakilanCalismaSaati"].HeaderText = "TAKILAN ÇALIŞMA SAATİ";
            DtgMalzemeList.Columns["TakilanRevizyon"].HeaderText = "TAKILAN REVİZYON";

            #region FilTools

            /*

            if (abfMalzemes==null)
            {
                return;
            }
            if (abfMalzemes.Count==0)
            {
                return;
            }
            if (abfMalzemes.Count>0)
            {
                AbfMalzeme abfMalzeme = abfMalzemes[0];
                if (abfMalzeme.SokulenStokNo!=null)
                {
                    StokNo1.Text = abfMalzeme.SokulenStokNo;
                    t1.Text = abfMalzeme.SokulenTanim;
                    TxtMiktar1.Text = abfMalzeme.SokulenMiktar.ToString();
                    b1.Text = abfMalzeme.SokulenBirim;
                    Sayac1.Text = abfMalzeme.SokulenCalismaSaati.ToString();
                    Revizyon1.Text = abfMalzeme.SokulenRevizyon;
                }
                else
                {
                    StokNo1.Text = abfMalzeme.TakilanStokNo;
                    t1.Text = abfMalzeme.TakilanTanim;
                    TxtMiktar1.Text = abfMalzeme.TakilanMiktar.ToString();
                    b1.Text = abfMalzeme.TakilanBirim;
                    Sayac1.Text = abfMalzeme.TakilanCalismaSaati.ToString();
                    Revizyon1.Text = abfMalzeme.TakilanRevizyon;
                }
                SokulenSeri1.Text = abfMalzeme.SokulenSeriNo;
                TakilanSeri1.Text = abfMalzeme.TakilanSeriNo;
                YapilacakIslem1.Text = abfMalzeme.YapilacakIslem;
            }

            if (abfMalzemes.Count > 1)
            {
                AbfMalzeme abfMalzeme = abfMalzemes[1];
                if (abfMalzeme.SokulenStokNo != null)
                {
                    StokNo2.Text = abfMalzeme.SokulenStokNo;
                    t2.Text = abfMalzeme.SokulenTanim;
                    TxtMiktar2.Text = abfMalzeme.SokulenMiktar.ToString();
                    b2.Text = abfMalzeme.SokulenBirim;
                    Sayac2.Text = abfMalzeme.SokulenCalismaSaati.ToString();
                    Revizyon2.Text = abfMalzeme.SokulenRevizyon;
                }
                else
                {
                    StokNo2.Text = abfMalzeme.TakilanStokNo;
                    t2.Text = abfMalzeme.TakilanTanim;
                    TxtMiktar2.Text = abfMalzeme.TakilanMiktar.ToString();
                    b2.Text = abfMalzeme.TakilanBirim;
                    Sayac2.Text = abfMalzeme.TakilanCalismaSaati.ToString();
                    Revizyon2.Text = abfMalzeme.TakilanRevizyon;
                }
                SokulenSeri2.Text = abfMalzeme.SokulenSeriNo;
                TakilanSeri2.Text = abfMalzeme.TakilanSeriNo;
                YapilacakIslem2.Text = abfMalzeme.YapilacakIslem;
            }

            if (abfMalzemes.Count > 2)
            {
                AbfMalzeme abfMalzeme = abfMalzemes[2];
                if (abfMalzeme.SokulenStokNo != null)
                {
                    StokNo3.Text = abfMalzeme.SokulenStokNo;
                    t3.Text = abfMalzeme.SokulenTanim;
                    TxtMiktar3.Text = abfMalzeme.SokulenMiktar.ToString();
                    b3.Text = abfMalzeme.SokulenBirim;
                    Sayac3.Text = abfMalzeme.SokulenCalismaSaati.ToString();
                    Revizyon3.Text = abfMalzeme.SokulenRevizyon;
                }
                else
                {
                    StokNo3.Text = abfMalzeme.TakilanStokNo;
                    t3.Text = abfMalzeme.TakilanTanim;
                    TxtMiktar3.Text = abfMalzeme.TakilanMiktar.ToString();
                    b3.Text = abfMalzeme.TakilanBirim;
                    Sayac3.Text = abfMalzeme.TakilanCalismaSaati.ToString();
                    Revizyon3.Text = abfMalzeme.TakilanRevizyon;
                }
                SokulenSeri3.Text = abfMalzeme.SokulenSeriNo;
                TakilanSeri3.Text = abfMalzeme.TakilanSeriNo;
                YapilacakIslem3.Text = abfMalzeme.YapilacakIslem;
            }

            if (abfMalzemes.Count > 3)
            {
                AbfMalzeme abfMalzeme = abfMalzemes[3];
                if (abfMalzeme.SokulenStokNo != null)
                {
                    StokNo4.Text = abfMalzeme.SokulenStokNo;
                    t4.Text = abfMalzeme.SokulenTanim;
                    TxtMiktar4.Text = abfMalzeme.SokulenMiktar.ToString();
                    b4.Text = abfMalzeme.SokulenBirim;
                    Sayac4.Text = abfMalzeme.SokulenCalismaSaati.ToString();
                    Revizyon4.Text = abfMalzeme.SokulenRevizyon;
                }
                else
                {
                    StokNo4.Text = abfMalzeme.TakilanStokNo;
                    t4.Text = abfMalzeme.TakilanTanim;
                    TxtMiktar4.Text = abfMalzeme.TakilanMiktar.ToString();
                    b4.Text = abfMalzeme.TakilanBirim;
                    Sayac4.Text = abfMalzeme.TakilanCalismaSaati.ToString();
                    Revizyon4.Text = abfMalzeme.TakilanRevizyon;
                }
                SokulenSeri4.Text = abfMalzeme.SokulenSeriNo;
                TakilanSeri4.Text = abfMalzeme.TakilanSeriNo;
                YapilacakIslem4.Text = abfMalzeme.YapilacakIslem;
            }

            if (abfMalzemes.Count > 4)
            {
                AbfMalzeme abfMalzeme = abfMalzemes[4];
                if (abfMalzeme.SokulenStokNo != null)
                {
                    StokNo5.Text = abfMalzeme.SokulenStokNo;
                    t5.Text = abfMalzeme.SokulenTanim;
                    TxtMiktar4.Text = abfMalzeme.SokulenMiktar.ToString();
                    b5.Text = abfMalzeme.SokulenBirim;
                    Sayac5.Text = abfMalzeme.SokulenCalismaSaati.ToString();
                    Revizyon5.Text = abfMalzeme.SokulenRevizyon;
                }
                else
                {
                    StokNo5.Text = abfMalzeme.TakilanStokNo;
                    t5.Text = abfMalzeme.TakilanTanim;
                    TxtMiktar5.Text = abfMalzeme.TakilanMiktar.ToString();
                    b5.Text = abfMalzeme.TakilanBirim;
                    Sayac5.Text = abfMalzeme.TakilanCalismaSaati.ToString();
                    Revizyon5.Text = abfMalzeme.TakilanRevizyon;
                }
                SokulenSeri5.Text = abfMalzeme.SokulenSeriNo;
                TakilanSeri5.Text = abfMalzeme.TakilanSeriNo;
                YapilacakIslem5.Text = abfMalzeme.YapilacakIslem;
            }

            if (abfMalzemes.Count > 5)
            {
                AbfMalzeme abfMalzeme = abfMalzemes[5];
                if (abfMalzeme.SokulenStokNo != null)
                {
                    StokNo6.Text = abfMalzeme.SokulenStokNo;
                    t6.Text = abfMalzeme.SokulenTanim;
                    TxtMiktar6.Text = abfMalzeme.SokulenMiktar.ToString();
                    b6.Text = abfMalzeme.SokulenBirim;
                    Sayac6.Text = abfMalzeme.SokulenCalismaSaati.ToString();
                    Revizyon6.Text = abfMalzeme.SokulenRevizyon;
                }
                else
                {
                    StokNo6.Text = abfMalzeme.TakilanStokNo;
                    t6.Text = abfMalzeme.TakilanTanim;
                    TxtMiktar6.Text = abfMalzeme.TakilanMiktar.ToString();
                    b6.Text = abfMalzeme.TakilanBirim;
                    Sayac6.Text = abfMalzeme.TakilanCalismaSaati.ToString();
                    Revizyon6.Text = abfMalzeme.TakilanRevizyon;
                }
                SokulenSeri6.Text = abfMalzeme.SokulenSeriNo;
                TakilanSeri6.Text = abfMalzeme.TakilanSeriNo;
                YapilacakIslem6.Text = abfMalzeme.YapilacakIslem;
            }

            if (abfMalzemes.Count > 6)
            {
                AbfMalzeme abfMalzeme = abfMalzemes[6];
                if (abfMalzeme.SokulenStokNo != null)
                {
                    StokNo7.Text = abfMalzeme.SokulenStokNo;
                    t7.Text = abfMalzeme.SokulenTanim;
                    TxtMiktar7.Text = abfMalzeme.SokulenMiktar.ToString();
                    b7.Text = abfMalzeme.SokulenBirim;
                    Sayac7.Text = abfMalzeme.SokulenCalismaSaati.ToString();
                    Revizyon7.Text = abfMalzeme.SokulenRevizyon;
                }
                else
                {
                    StokNo7.Text = abfMalzeme.TakilanStokNo;
                    t7.Text = abfMalzeme.TakilanTanim;
                    TxtMiktar7.Text = abfMalzeme.TakilanMiktar.ToString();
                    b7.Text = abfMalzeme.TakilanBirim;
                    Sayac7.Text = abfMalzeme.TakilanCalismaSaati.ToString();
                    Revizyon7.Text = abfMalzeme.TakilanRevizyon;
                }
                SokulenSeri7.Text = abfMalzeme.SokulenSeriNo;
                TakilanSeri7.Text = abfMalzeme.TakilanSeriNo;
                YapilacakIslem7.Text = abfMalzeme.YapilacakIslem;
            }

            if (abfMalzemes.Count > 7)
            {
                AbfMalzeme abfMalzeme = abfMalzemes[7];
                if (abfMalzeme.SokulenStokNo != null)
                {
                    StokNo8.Text = abfMalzeme.SokulenStokNo;
                    t8.Text = abfMalzeme.SokulenTanim;
                    TxtMiktar8.Text = abfMalzeme.SokulenMiktar.ToString();
                    b8.Text = abfMalzeme.SokulenBirim;
                    Sayac8.Text = abfMalzeme.SokulenCalismaSaati.ToString();
                    Revizyon8.Text = abfMalzeme.SokulenRevizyon;
                }
                else
                {
                    StokNo8.Text = abfMalzeme.TakilanStokNo;
                    t8.Text = abfMalzeme.TakilanTanim;
                    TxtMiktar8.Text = abfMalzeme.TakilanMiktar.ToString();
                    b8.Text = abfMalzeme.TakilanBirim;
                    Sayac8.Text = abfMalzeme.TakilanCalismaSaati.ToString();
                    Revizyon8.Text = abfMalzeme.TakilanRevizyon;
                }
                SokulenSeri8.Text = abfMalzeme.SokulenSeriNo;
                TakilanSeri8.Text = abfMalzeme.TakilanSeriNo;
                YapilacakIslem8.Text = abfMalzeme.YapilacakIslem;
            }

            if (abfMalzemes.Count > 8)
            {
                AbfMalzeme abfMalzeme = abfMalzemes[8];
                if (abfMalzeme.SokulenStokNo != null)
                {
                    StokNo9.Text = abfMalzeme.SokulenStokNo;
                    t9.Text = abfMalzeme.SokulenTanim;
                    TxtMiktar9.Text = abfMalzeme.SokulenMiktar.ToString();
                    b9.Text = abfMalzeme.SokulenBirim;
                    Sayac9.Text = abfMalzeme.SokulenCalismaSaati.ToString();
                    Revizyon9.Text = abfMalzeme.SokulenRevizyon;
                }
                else
                {
                    StokNo9.Text = abfMalzeme.TakilanStokNo;
                    t9.Text = abfMalzeme.TakilanTanim;
                    TxtMiktar9.Text = abfMalzeme.TakilanMiktar.ToString();
                    b9.Text = abfMalzeme.TakilanBirim;
                    Sayac9.Text = abfMalzeme.TakilanCalismaSaati.ToString();
                    Revizyon9.Text = abfMalzeme.TakilanRevizyon;
                }
                SokulenSeri9.Text = abfMalzeme.SokulenSeriNo;
                TakilanSeri9.Text = abfMalzeme.TakilanSeriNo;
                YapilacakIslem9.Text = abfMalzeme.YapilacakIslem;
            }

            if (abfMalzemes.Count > 9)
            {
                AbfMalzeme abfMalzeme = abfMalzemes[9];
                if (abfMalzeme.SokulenStokNo != null)
                {
                    StokNo10.Text = abfMalzeme.SokulenStokNo;
                    t10.Text = abfMalzeme.SokulenTanim;
                    TxtMiktar10.Text = abfMalzeme.SokulenMiktar.ToString();
                    b10.Text = abfMalzeme.SokulenBirim;
                    Sayac10.Text = abfMalzeme.SokulenCalismaSaati.ToString();
                    Revizyon10.Text = abfMalzeme.SokulenRevizyon;
                }
                else
                {
                    StokNo10.Text = abfMalzeme.TakilanStokNo;
                    t10.Text = abfMalzeme.TakilanTanim;
                    TxtMiktar10.Text = abfMalzeme.TakilanMiktar.ToString();
                    b10.Text = abfMalzeme.TakilanBirim;
                    Sayac10.Text = abfMalzeme.TakilanCalismaSaati.ToString();
                    Revizyon10.Text = abfMalzeme.TakilanRevizyon;
                }
                SokulenSeri10.Text = abfMalzeme.SokulenSeriNo;
                TakilanSeri10.Text = abfMalzeme.TakilanSeriNo;
                YapilacakIslem10.Text = abfMalzeme.YapilacakIslem;
            }*/
            #endregion
        }
        private void DtgMalzemeList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        
        void TemizleSiparisOlustur()
        {
            TxtAbfFormNo.Clear(); LblBolgeAdi.Text = "-"; TxtBildirilenArizaSiparis.Clear(); CmbGarantiDurumu.SelectedIndex = -1;
            TxtArizaBildirenSiparis.Clear(); TxtArizaBildirenRutbesi.Clear(); TxtArizaBildirenGorevi.Clear();
            TxtLojistikSorumlusu.Clear(); TxtLojistikSorRutbesi.Clear(); TxtLojistikSorGorevi.Clear();
        }


        private void CmbPypNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            Pyp pyp = pypManager.Get(CmbPypNo.SelectedIndex);
            TxtSorumluPersonel.Text = pyp.SorumluPersonel;
            //TxtSiparisTuru.Text = pyp.SiparisTuru;
            TxtIslemTuru.Text = pyp.IslemTuru;
            TxtHesaplama.Text = pyp.HesaplamaNedeni;

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void BtnIlgiliFirmaEkle_Click(object sender, EventArgs e)
        {
            comboAd = "ONARIM_YERI";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void CmbBildirimTuruEkle_Click(object sender, EventArgs e)
        {
            comboAd = "BILDIRIM TURU";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnPersonelEkle_Click_1(object sender, EventArgs e)
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

        private void BtnCrmNoKaydet_Click(object sender, EventArgs e)
        {
            string mesaj = CrmNoKontrol();
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                ArizaKayit arizaKayit = new ArizaKayit(id, TxtCsSiparisNo.Text, TxtBildirimNo.Text, TxtCrmNo.Text, DtgMailTarihi.Text, TxtEkipmanNo.Text);
                mesaj = arizaKayitManager.CrmNoTanimla(arizaKayit);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                arizaKayitManager.IslemAdimiGuncelle(id, CmbCrmIslemAdimlari.Text, CmbCrmGorevAtanacakPer.Text);
                GorevAtamCrm();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                CrmTemizle();
            }
        }
        void CrmTemizle()
        {
            TxtCrmFormNo.Clear(); DtgFormBilgileri.Rows.Clear(); TxtCsSiparisNo.Clear(); TxtBildirimNo.Clear(); TxtCrmNo.Clear();
            LblCrmMevcutIslemAdimi.Text = "00"; CmbCrmGorevAtanacakPer.SelectedIndex = -1; CmbCrmIslemAdimlari.SelectedIndex = -1;

        }
        string CrmNoKontrol()
        {
            if (DtgFormBilgileri.RowCount==0)
            {
                return "Lütfen Öncelikle Geçerli Bir Abf No Yazarak Bul Butonuna Basınız!";
            }
            if (TxtCsSiparisNo.Text=="")
            {
                return "Lütfen CS Sipariş No Bilgisini Yazınız!";
            }
            if (TxtBildirimNo.Text == "")
            {
                return "Lütfen Bildirim No Bilgisini Yazınız!";
            }
            if (TxtCrmNo.Text == "")
            {
                return "Lütfen Crm No Bilgisini Yazınız!";
            }
            if (CmbCrmGorevAtanacakPer.Text=="")
            {
                return "Lütfen Görev Atanacak Personel Bilgisini Seçiniz!";
            }
            if (CmbCrmIslemAdimlari.Text == "")
            {
                return "Lütfen Bir Sonraki İşlem Adımı Bilgisini Seçiniz!";
            }
            return "OK";
        }

        private void BtnBulCrm_Click(object sender, EventArgs e)
        {
            if (TxtCrmFormNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle ABF Form No Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgFormBilgileri.Rows.Clear();
            ArizaKayit arizaKayit = arizaKayitManager.Get(TxtCrmFormNo.Text.ConInt());

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
            LblCrmMevcutIslemAdimi.Text = arizaKayit.IslemAdimi;
            abf = arizaKayit.AbfFormNo;

            LblMevcutIslemAdimi.Text = arizaKayit.IslemAdimi;
            abfForm = arizaKayit.AbfFormNo;
            id = arizaKayit.Id;

            CrmSureBul();
        }

        private void AdvPersonel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                AdvPersonel.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void BtnMalzemeDuzenle_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle bir ABF No Yazarak Bul butonuna basınız!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            FrmMalzemeDuzenle frmMalzemeDuzenle = new FrmMalzemeDuzenle();
            frmMalzemeDuzenle.benzersizId = id;
            frmMalzemeDuzenle.ShowDialog();
        }

        private void BtnSiparisKaydet_Click(object sender, EventArgs e)
        {
            string mesaj = SiparisOlusturKontrol();
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                ArizaKayit arizaKayit2 = arizaKayitManager.Get(abf);
                id = arizaKayit2.Id;

                DateTime lojTarih = new DateTime(DtLojistikTarih.Value.Year, DtLojistikTarih.Value.Month, DtLojistikTarih.Value.Day, DtLojistikSaat.Value.Hour, DtLojistikSaat.Value.Minute, DtLojistikSaat.Value.Second);

                mesaj = PersonelIscilikleriEkle();
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (CmbGarantiDurumu.Text=="İÇİ")
                {
                    lojTarihi = "";
                }
                else
                {
                    lojTarihi = lojTarih.ToString();
                }

                ArizaKayit arizaKayit = new ArizaKayit(id, CmbGarantiDurumu.Text, TxtLojistikSorumlusu.Text, TxtLojistikSorRutbesi.Text, TxtLojistikSorGorevi.Text, lojTarihi, TxtTespitEdilenAriza.Text, CmbArizaAcmaOnayiVeren.Text);

                string mesaj2 = arizaKayitManager.ArizaSiparisOlustur(arizaKayit);
                if (mesaj2 != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                arizaKayitManager.IslemAdimiGuncelle(id, CmbIslemAdimi.Text, CmbGorevAtanacakPersonel.Text);
                
                SistemCihazBilgileriKayit();
                mesaj2 = GorevAtamaSiparisOlustur();
                
                if (mesaj2 != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleSiparisOlustur();
                SiparisTemizle();
            }
        }
        void SiparisTemizle()
        {
            CmbPersoneller.SelectedIndex = -1; DtIscilikSaati.Text = "00:00"; AdvPersonel.Rows.Clear(); DtgMudehaleSaati.Text = "00:00"; CmbArizaAcmaOnayiVeren.SelectedValue = ""; DtgMalzemeList.DataSource = null;
        }
        void SistemCihazBilgileriKayit()
        {

            ArizaKayit arizaKayit = new ArizaKayit(id, LbStokNo.Text, CmbParcaNo.Text, TxtSeriNo.Text, CmbKategori.Text, CmbIlgiliFirma.Text, CmbBildirimTuru.Text, CmbPypNo.Text, TxtSorumluPersonel.Text, TxtSiparisTuru.Text, TxtHesaplama.Text);

            arizaKayitManager.SistemCihazBilgileri(arizaKayit);
        }

        string PersonelIscilikleriEkle()
        {
            foreach (DataGridViewRow item in AdvPersonel.Rows)
            {
                IscilikIscilik ıscilikIscilik = new IscilikIscilik(id, item.Cells["AdiSoyadi"].Value.ToString(), item.Cells["Gorevi"].Value.ToString(), item.Cells["Bolumu"].Value.ToString(), "İŞÇİLİK", abf.ToString(), DateTime.Now, DtIscilikSaati.Value.Date);

                ıscilikIscilikManager.Add(ıscilikIscilik);
            }
            return "OK";
        }

        private void BtnBulKapat_Click(object sender, EventArgs e)
        {
            if (TxtAbfKapat.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle ABF Form No Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgFormBilgileriKapat.Rows.Clear();
            ArizaKayit arizaKayit = arizaKayitManager.Get(TxtAbfKapat.Text.ConInt());

            if (arizaKayit == null)
            {
                MessageBox.Show("Girmiş Olduğunuz ABF No Ya Ait Bir Kayıt Bulunamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgFormBilgileriKapat.Rows.Add();
            int sonSatir = DtgFormBilgileriKapat.RowCount - 1;

            DtgFormBilgileriKapat.Rows[sonSatir].Cells["FormNoK"].Value = arizaKayit.AbfFormNo.ToString();
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["CsSiparisNoK"].Value = arizaKayit.CsSiparisNo;
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["BildirimNoK"].Value = arizaKayit.BildirimNo;
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["CrmHizmetNoK"].Value = arizaKayit.CrmNo;
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["BolgeAdiK"].Value = arizaKayit.BolgeAdi;
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["StokNoK"].Value = arizaKayit.StokNo;
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["TanimK"].Value = arizaKayit.Tanim;
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["SeriNoK"].Value = arizaKayit.SeriNo;
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["ArizaBildirimTarihiK"].Value = arizaKayit.AbTarihSaat.ToString();
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["BolgeSorumlusuK"].Value = arizaKayit.AcmaOnayiVeren;

            LblPyp.Text = arizaKayit.PypNo;
            LblSorumluPersonel.Text = arizaKayit.SorumluPersonel;
            LblSiparisTuru.Text = arizaKayit.CsSiparisNo;
            LblIslemTuru.Text = arizaKayit.IslemTuru;
            LblHesaplama.Text = arizaKayit.Hesaplama;
            string bolgeAd = arizaKayit.BolgeAdi;

            abf = arizaKayit.AbfFormNo;
            abfForm = arizaKayit.AbfFormNo;
            id = arizaKayit.Id;

            Bolge bolge = bolgeManager.Get(bolgeAd);
            if (bolge == null)
            {
                LblProjeKapat.Text = "";
                LblGarantiBasKapat.Text = "";
                LblGrantiBitKapat.Text = "";
            }
            else
            {
                LblProjeKapat.Text = bolge.Proje;
                LblGarantiBasKapat.Text = bolge.GarantiBaslama;
                LblGrantiBitKapat.Text = bolge.GarantiBitis;
            }
            string dosya = arizaKayit.DosyaYolu;
            AtolyeKayitlari();
            MalzemeListesi();
            DepoHareketleri();
            IslemAdimlariSureleri();

            try
            {
                webBrowser2.Navigate(dosya);
            }
            catch (Exception)
            {
                return;
            }

        }

        private void BtnNesneKoduEkle_Click(object sender, EventArgs e)
        {
            comboAd = "NESNE_TANIMI";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void CmbTeslimEden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==true)
            {
                return;
            }
            if (CmbTeslimEden.SelectedIndex==-1)
            {
                return;
            }
            PersonelKayit personelKayit = kayitManager.Get(0, CmbTeslimEden.Text);
            TxtSicil.Text = personelKayit.Sicil;

        }

        private void BtnHasarKoduEkle_Click(object sender, EventArgs e)
        {
            comboAd = "HASAR_KODU";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnNedenKoduEkle_Click(object sender, EventArgs e)
        {
            comboAd = "NEDEN_KODU";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        string SiparisOlusturKontrol()
        {
            if (TxtBildirilenArizaSiparis.Text == "")
            {
                return "Lütfen Geçerli Bir Arıza Kaydı Giriniz!";
            }
            if (CmbGarantiDurumu.Text == "")
            {
                return "Lütfen Garanti Durumu Bilgisini Seçiniz!";
            }
            if (CmbGarantiDurumu.Text == "")
            {
                return "Lütfen Garanti Durumu Bilgisini Seçiniz!";
            }
            if (CmbGarantiDurumu.Text == "DIŞI")
            {
                if (TxtLojistikSorumlusu.Text == "")
                {
                    return "Lütfen Lojistik Sorumlusu Bilgisini Doldurunuz!";
                }
            }
            if (AdvPersonel.RowCount == 0)
            {
                return "Lütfen Personel İşçilik ve Süresi Bilgilerini Doldurunuz!";
            }
            if (DtIscilikSaati.Text == "00:00")
            {
                return "Lütfen Personel İşçilik Saati Bilgilerini Yazınız!";
            }
            if (DtgMudehaleSaati.Text == "00:00")
            {
                return "Lütfen Müdehale Saati Bilgilerini Yazınız!";
            }
            if (CmbArizaAcmaOnayiVeren.Text == "")
            {
                return "Lütfen Arıza Açma Onayı Veren Sorumlu Personel Seçiniz!";
            }
            if (CmbParcaNo.Text == "")
            {
                return "Lütfen Parça Tanımı Bilgisini Seçiniz!";
            }
            if (TxtSeriNo.Text == "")
            {
                return "Lütfen Seri No Bilgisini Doldurunuz!";
            }
            if (CmbKategori.Text == "")
            {
                return "Lütfen Kategori Bilgisini Doldurunuz!";
            }
            if (CmbIlgiliFirma.Text == "")
            {
                return "Lütfen İlgili Firma Bilgisini Doldurunuz!";
            }
            if (CmbBildirimTuru.Text == "")
            {
                return "Lütfen Bildirim Türü Bilgisini Doldurunuz!";
            }
            if (CmbPypNo.Text == "")
            {
                return "Lütfen Pyp No Bilgisini Doldurunuz!";
            }
            if (TxtSiparisTuru.Text == "")
            {
                return "Lütfen Sipariş Türü Bilgisini Doldurunuz!";
            }
            if (CmbGorevAtanacak.Text == "")
            {
                return "Lütfen Görev Atanacak Personel Bilgisini Seçiniz!";
            }
            if (CmbIslemAdimi.Text == "")
            {
                return "Lütfen Bir Sonra ki İşlem Adımı Bilgisini Seçiniz!";
            }

            return "OK";
        }

        private void BtnCombo_Click(object sender, EventArgs e)
        {
            comboAd = "ABF KATEGORİ";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void CmbPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbPersoneller.SelectedIndex==-1)
            {
                return;
            }
            PersonelKayit personelKayit = kayitManager.Get(0, CmbPersoneller.Text);
            personelGorevi = personelKayit.Isunvani;
            personelBolumu = personelKayit.Sirketbolum;
        }

        private void CmbParcaNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = CmbParcaNo.SelectedValue.ConInt();
            MalzemeKayit malzemeKayit = malzemeKayitManager.Get(id);
            if (malzemeKayit == null)
            {
                LbStokNo.Text = "";
                return;
            }
            LbStokNo.Text = malzemeKayit.Stokno;
            CmbIlgiliFirma.Text = malzemeKayit.Malzemeonarımyeri;
        }

        void UsBolgeleri()
        {
            CmbBolgeAdi.DataSource = satTalebiDoldurManager.GetList();
            CmbBolgeAdi.ValueMember = "Id";
            CmbBolgeAdi.DisplayMember = "Usbolgesi";
            CmbBolgeAdi.SelectedValue = "";
        }

        private void BtnBolgeEkle_Click(object sender, EventArgs e)
        {
            FrmBolgeler frmBolgeler = new FrmBolgeler();
            frmBolgeler.ShowDialog();
        }

        private void BtnKaydetKapat_Click(object sender, EventArgs e)
        {
            string mesaj = KayitKapatKontrol();
            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                DateTime teslimTarihi = new DateTime(DtTeslimTarihiKapat.Value.Year, DtTeslimTarihiKapat.Value.Month, DtTeslimTarihiKapat.Value.Day, DtTeslimSaati.Value.Hour, DtTeslimSaati.Value.Minute, DtTeslimSaati.Value.Second);

                int eksikEvrak = 0;
                if (ChkEksikEvrak.Checked==true)
                {
                    eksikEvrak = 1;
                }
                ArizaKayit arizaKayit = new ArizaKayit(id, TxtArizaOnarimNotu.Text, CmbTeslimEden.Text, LblTeslimAlanPersonel.Text, teslimTarihi, CmbNesneTanimi.Text, CmbHasarKodu.Text, CmbNedenKodu.Text, eksikEvrak);

                string message = arizaKayitManager.KapatKayit(arizaKayit);
                if (message !="OK")
                {
                    MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                arizaKayitManager.AbfKapat(id);
                TemizleKapat();
            }
            
        }
        void TemizleKapat()
        {
            TxtAbfKapat.Clear(); DtgFormBilgileriKapat.Rows.Clear(); LblPyp.Text = "00"; LblSorumluPersonel.Text = "00"; LblSiparisTuru.Text = "00"; LblIslemTuru.Text = "00"; LblHesaplama.Text = "00"; LblProjeKapat.Text = "00"; LblGarantiBasKapat.Text = "00"; LblGrantiBitKapat.Text = "00"; DtgAtolyeIslemKayitlari.DataSource = null; DtgDepoHareketleriSaha.DataSource = null; DtgMalzemeBilgileriSokulenTakilan.DataSource = null;
            DtgIslemKayitlari.DataSource = null; webBrowser2.Navigate(""); TxtArizaOnarimNotu.Clear(); CmbTeslimEden.SelectedIndex = -1; TxtSicil.Clear();
            CmbNesneTanimi.SelectedIndex = -1; CmbHasarKodu.SelectedIndex = -1; CmbNedenKodu.SelectedIndex = -1; CmbSonuc.Text = ""; ChkEksikEvrak.Checked = false;
        }
        string KayitKapatKontrol()
        {
            if (TxtArizaOnarimNotu.Text=="")
            {
                return "Lütfen Öncelikle Ariza Onarım Notu Bilgisini Doldurunuz!";
            }
            if (CmbTeslimEden.Text=="")
            {
                return "Lütfen Öncelikle Teslim Eden Personel Bilgisini Doldurunuz!";
            }
            if (CmbNesneTanimi.Text=="")
            {
                return "Lütfen Öncelikle Nesne Tanımı Bilgisini Doldurunuz!";
            }
            if (CmbHasarKodu.Text=="")
            {
                return "Lütfen Öncelikle Hasar Kodu Bilgisini Doldurunuz!";
            }
            if (CmbNedenKodu.Text=="")
            {
                return "Lütfen Öncelikle Neden Kodu Bilgisini Doldurunuz!";
            }
            if (CmbSonuc.Text=="")
            {
                return "Lütfen Sonuç Bilgisini Doldurunuz!";
            }
            return "OK";
        }

        private void CmbBolgeAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            string bolgeAdi = CmbBolgeAdi.Text;
            Bolge bolge = bolgeManager.Get(bolgeAdi);

            proje = bolge.Proje;
            LblBolukKomutanı.Text = bolge.IlgiliPersonel;
            LblTelefon.Text = bolge.Telefon;
            LblBirlilkAdresi.Text = bolge.BirlikAdresi;
            LblIl.Text = bolge.Il;
            LblIlce.Text = bolge.Ilce;
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }
        string kaynakdosyaismi1, alinandosya1;

        private void BtnEksikEvrakKaydet_Click(object sender, EventArgs e)
        {
            if (eksikEvrakId==0)
            {
                MessageBox.Show("Lütfen Öncelike Geçerli Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                arizaKayitManager.BOEksikEvrakList(eksikEvrakId);
            }
            eksikEvrakId = 0;
            EksikEvrakList();
        }

        private void BtnEksikEvrakEkle_Click(object sender, EventArgs e)
        {
            if (eksikEvrakId == 0)
            {
                MessageBox.Show("Lütfen öncelikle geçerli bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(dosya))
            {
                IsAkisNo();
                string root = @"Z:\DTS";
                string subdir = @"Z:\DTS\BAKIM ONARIM\ARIZA";

                isAkisNo = LblIsAkisNo.Text;

                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                if (!Directory.Exists(subdir))
                {
                    Directory.CreateDirectory(subdir);
                }
                dosya = subdir + isAkisNo;
                Directory.CreateDirectory(dosya);
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

            if (File.Exists(dosya))
            {
                MessageBox.Show("Belirtilen Klasörde " + dosya + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya1, dosya);
            }
            webBrowser3.Navigate(dosya);
        }
        int eksikEvrakId;
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosya = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            eksikEvrakId = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            try
            {
                webBrowser3.Navigate(dosya);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void CmbGarantiDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = CmbGarantiDurumu.SelectedIndex;
            if (index == 0)
            {
                LblLojistik.Visible = false;
                TxtLojistikSorumlusu.Visible = false;
                TxtLojistikSorRutbesi.Visible = false;
                TxtLojistikSorGorevi.Visible = false;
                DtLojistikTarih.Visible = false;
                DtLojistikSaat.Visible = false;
            }
            if (index == 1)
            {
                LblLojistik.Visible = true;
                TxtLojistikSorumlusu.Visible = true;
                TxtLojistikSorRutbesi.Visible = true;
                TxtLojistikSorGorevi.Visible = true;
                DtLojistikTarih.Visible = true;
                DtLojistikSaat.Visible = true;
            }

        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
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
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtBildirilenAriza.Text=="")
            {
                MessageBox.Show("Lütfen öncelikle gerekli tüm bilgileri doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                siparisNo = Guid.NewGuid().ToString();

                abfForm = AbfFormNo();

                ArizaKayit arizaKayit = new ArizaKayit(LblIsAkisNo.Text.ConInt(), abfForm, proje, CmbBolgeAdi.Text, LblBolukKomutanı.Text, LblTelefon.Text, LblBirlilkAdresi.Text, LblIl.Text, LblIlce.Text, TxtBildirilenAriza.Text, TxtBirlikPersoneli.Text, TxtBirlikPerRutbesi.Text, TxtBirlikPerGorevi.Text, TxtABTelefon.Text, DateTime.Now, LblArizaBildirimiAlan.Text, CmbBildirimKanali.Text, TxtArizaAciklama.Text, CmbGorevAtanacakPersonel.Text, LblIslemAdimi.Text, dosyaYolu, siparisNo);

                string mesaj = arizaKayitManager.Add(arizaKayit);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GorevAtama();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAkisNo();
                Temizle();
                kayitKontrol = true;
            }
        }
        void GorevAtama()
        {
            ArizaKayit arizaKayit = arizaKayitManager.Get(abfForm);
            id = arizaKayit.Id;

            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM", infos[1].ToString(), "100_ARIZANIN BİLDİRİLMESİ (MÜŞTERİ)", DateTime.Now, TxtBildirilenAriza.Text, "00:05:00".ConOnlyTime());
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            string sure = "0 Gün " + "0 Saat " + "0 Dakika";

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "BAKIM ONARIM", "100_ARIZANIN BİLDİRİLMESİ (MÜŞTERİ)", sure, DateTime.Now.Date);
            gorevAtamaPersonelManager.Update(gorevAtama);

            GorevAtamaPersonel gorevAtamaPersonel4 = new GorevAtamaPersonel(id, "BAKIM ONARIM", CmbGorevAtanacakPersonel.Text, LblIslemAdimi.Text, DateTime.Now, "", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel4);

        }
        string GorevAtamaSiparisOlustur()
        {
            ArizaKayit arizaKayit = arizaKayitManager.Get(abf);
            id = arizaKayit.Id;

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "BAKIM ONARIM", LblMevcutIslemAdimi.Text, sure, "00:05:00".ConOnlyTime());
            string kontrol2 = gorevAtamaPersonelManager.Update(gorevAtama, TxtTespitEdilenAriza.Text);
            if (kontrol2 != "OK")
            {
                return kontrol2;
            }
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM", CmbGorevAtanacak.Text, CmbIslemAdimi.Text, DateTime.Now, "", DateTime.Now.Date);
            string kontrol = gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            if (kontrol != "OK")
            {
                return kontrol;
            }
            return "OK";

        }
        void Temizle()
        {
            CmbProje.SelectedValue = ""; CmbBolgeAdi.SelectedValue = ""; LblBolukKomutanı.Text = "-"; LblTelefon.Text = "-";
            LblBirlilkAdresi.Text = "-"; LblIl.Text = "-"; LblIlce.Text = "-"; TxtBildirilenAriza.Clear(); TxtBirlikPersoneli.Clear();
            TxtBirlikPerRutbesi.Clear(); TxtBirlikPerGorevi.Clear(); TxtABTelefon.Clear(); CmbBildirimKanali.Text = "";
            TxtArizaAciklama.Clear(); webBrowser1.Navigate("");

        }
        string GorevAtamCrm()
        {
            ArizaKayit arizaKayit = arizaKayitManager.Get(abf);
            id = arizaKayit.Id;

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "BAKIM ONARIM", LblCrmMevcutIslemAdimi.Text, sure, "00:05:00".ConOnlyTime());
            string kontrol2 = gorevAtamaPersonelManager.Update(gorevAtama, "ASELSAN BİLDİRİMİ YAPILDI.");
            if (kontrol2 != "OK")
            {
                return kontrol2;
            }
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM", CmbCrmGorevAtanacakPer.Text, CmbCrmIslemAdimlari.Text, DateTime.Now, "", DateTime.Now.Date);
            string kontrol = gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            if (kontrol != "OK")
            {
                return kontrol;
            }
            return "OK";

        }
        void CrmSureBul()
        {
            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "BAKIM ONARIM");

            birOncekiTarih = gorevAtamaPersonel.Tarih;

            TimeSpan sonuc = DateTime.Now - birOncekiTarih;

            gun = sonuc.Days.ConInt();
            saat = sonuc.Hours.ConInt();
            if (sonuc.Hours < 1)
            {
                saat = 0;
            }

            dakika = sonuc.Seconds.ConInt() % 60;

            sure = gun.ToString() + " Gün " + saat.ToString() + " Saat " + dakika.ToString() + " Dakika";
        }

        void AtolyeKayitlari()
        {
            atolyes = atolyeManager.AtolyeAbf(abf.ToString());
            DtgAtolyeIslemKayitlari.DataSource = atolyes;

            DtgAtolyeIslemKayitlari.Columns["Id"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["AbfNo"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["StokNoUst"].HeaderText = "STOK NO";
            DtgAtolyeIslemKayitlari.Columns["TanimUst"].HeaderText = "TANIM";
            DtgAtolyeIslemKayitlari.Columns["SeriNoUst"].HeaderText = "SERİ NO";
            DtgAtolyeIslemKayitlari.Columns["GarantiDurumu"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["CrmNo"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["Kategori"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["BolgeAdi"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["Proje"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["BildirilenAriza"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["IcSiparisNo"].HeaderText = "İÇ SİPARİŞ NO";
            DtgAtolyeIslemKayitlari.Columns["SiparisAcmaTarihi"].HeaderText = "KAYIT TARİH";
            DtgAtolyeIslemKayitlari.Columns["Modifikasyonlar"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["Notlar"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["BulunduguIslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgAtolyeIslemKayitlari.Columns["SiparisNo"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["IslemAdimi"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["ArizaDurum"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["Gecensure"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["KapatmaTarihi"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["DosyaYolu"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["BildirimNo"].Visible = false;
            DtgAtolyeIslemKayitlari.Columns["CekildigiTarih"].Visible = false;

        }
        void MalzemeListesi()
        {
            abfMalzemes = abfMalzemeManager.GetList(id);
            DtgMalzemeBilgileriSokulenTakilan.DataSource = abfMalzemes;

            DtgMalzemeBilgileriSokulenTakilan.Columns["Id"].Visible = false;
            DtgMalzemeBilgileriSokulenTakilan.Columns["BenzersizId"].Visible = false;
            DtgMalzemeBilgileriSokulenTakilan.Columns["SokulenStokNo"].HeaderText = "SÖKÜLEN STOK NO";
            DtgMalzemeBilgileriSokulenTakilan.Columns["SokulenTanim"].HeaderText = "SÖKÜLEN TANIM";
            DtgMalzemeBilgileriSokulenTakilan.Columns["SokulenSeriNo"].HeaderText = "SÖKÜLEN SERİ NO";
            DtgMalzemeBilgileriSokulenTakilan.Columns["SokulenMiktar"].HeaderText = "SÖKÜLEN MİKTAR";
            DtgMalzemeBilgileriSokulenTakilan.Columns["SokulenBirim"].HeaderText = "SÖKÜLEN BİRİM";
            DtgMalzemeBilgileriSokulenTakilan.Columns["SokulenCalismaSaati"].HeaderText = "SÖKÜLEN ÇALIŞMA SAATİ";
            DtgMalzemeBilgileriSokulenTakilan.Columns["SokulenRevizyon"].HeaderText = "SÖKÜLEN REVİZYON";
            DtgMalzemeBilgileriSokulenTakilan.Columns["CalismaDurumu"].HeaderText = "ÇALIŞMA DURUMU";
            DtgMalzemeBilgileriSokulenTakilan.Columns["FizikselDurum"].HeaderText = "FİSİZKSEL DURUM";
            DtgMalzemeBilgileriSokulenTakilan.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgMalzemeBilgileriSokulenTakilan.Columns["TakilanStokNo"].HeaderText = "TAKILAN STOK NO";
            DtgMalzemeBilgileriSokulenTakilan.Columns["TakilanTanim"].HeaderText = "TAKILAN TANIM";
            DtgMalzemeBilgileriSokulenTakilan.Columns["TakilanSeriNo"].HeaderText = "TAKILAN SERİ NO";
            DtgMalzemeBilgileriSokulenTakilan.Columns["TakilanMiktar"].HeaderText = "TAKILAN MİKTAR";
            DtgMalzemeBilgileriSokulenTakilan.Columns["TakilanBirim"].HeaderText = "TAKILAN BİRİM";
            DtgMalzemeBilgileriSokulenTakilan.Columns["TakilanCalismaSaati"].HeaderText = "TAKILAN ÇALIŞMA SAATİ";
            DtgMalzemeBilgileriSokulenTakilan.Columns["TakilanRevizyon"].HeaderText = "TAKILAN REVİZYON";

        }
        void DepoHareketleri()
        {
            stokGirisCıkıs = stokGirisCikisManager.AtolyeDepoHareketleri(abf.ToString());
            DtgDepoHareketleriSaha.DataSource = stokGirisCıkıs;

            DtgDepoHareketleriSaha.Columns["Id"].Visible = false;
            DtgDepoHareketleriSaha.Columns["Islemturu"].HeaderText = "İŞLEM TÜRÜ";
            DtgDepoHareketleriSaha.Columns["IslemTarihi"].HeaderText = "İŞLEM TARİHİ";
            DtgDepoHareketleriSaha.Columns["Stokno"].HeaderText = "STOK NO";
            DtgDepoHareketleriSaha.Columns["Tanim"].HeaderText = "TANIM";
            DtgDepoHareketleriSaha.Columns["Serino"].HeaderText = "SERİ NO";
            DtgDepoHareketleriSaha.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgDepoHareketleriSaha.Columns["DusulenMiktar"].HeaderText = "DÜŞÜLEN MİKTAR";
            DtgDepoHareketleriSaha.Columns["Birim"].HeaderText = "BİRİM";
            DtgDepoHareketleriSaha.Columns["Lotno"].HeaderText = "LOT NO";
            DtgDepoHareketleriSaha.Columns["CekilenDepoNo"].HeaderText = "ÇEKİLEN DEPO NO/YER";
            DtgDepoHareketleriSaha.Columns["CekilenDepoAdresi"].HeaderText = "ÇEKİLEN DEPO ADRESİ";
            DtgDepoHareketleriSaha.Columns["CekilenMalzemeYeri"].HeaderText = "ÇEKİLEN MALZEME YERİ";
            DtgDepoHareketleriSaha.Columns["DusulenDepoNo"].HeaderText = "DÜŞÜLEN DEPO NO/YER";
            DtgDepoHareketleriSaha.Columns["DusulenDepoAdresi"].HeaderText = "DÜŞÜLEN DEPO ADRESİ";
            DtgDepoHareketleriSaha.Columns["DusulenMalzemeYeri"].HeaderText = "DÜŞÜLEN MALZEME YERİ";
            DtgDepoHareketleriSaha.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgDepoHareketleriSaha.Columns["Aciklama"].HeaderText = "AÇIKLAMA";


            DtgDepoHareketleriSaha.Columns["Id"].DisplayIndex = 0;
            DtgDepoHareketleriSaha.Columns["Islemturu"].DisplayIndex = 1;
            DtgDepoHareketleriSaha.Columns["IslemTarihi"].DisplayIndex = 2;
            DtgDepoHareketleriSaha.Columns["Stokno"].DisplayIndex = 3;
            DtgDepoHareketleriSaha.Columns["Tanim"].DisplayIndex = 4;
            DtgDepoHareketleriSaha.Columns["Serino"].DisplayIndex = 5;
            DtgDepoHareketleriSaha.Columns["Revizyon"].DisplayIndex = 6;
            DtgDepoHareketleriSaha.Columns["DusulenMiktar"].DisplayIndex = 7;
            DtgDepoHareketleriSaha.Columns["Birim"].DisplayIndex = 8;
            DtgDepoHareketleriSaha.Columns["Lotno"].DisplayIndex = 9;
            DtgDepoHareketleriSaha.Columns["CekilenDepoNo"].DisplayIndex = 10;
            DtgDepoHareketleriSaha.Columns["CekilenDepoAdresi"].DisplayIndex = 11;
            DtgDepoHareketleriSaha.Columns["CekilenMalzemeYeri"].DisplayIndex = 12;
            DtgDepoHareketleriSaha.Columns["DusulenDepoNo"].DisplayIndex = 13;
            DtgDepoHareketleriSaha.Columns["DusulenDepoAdresi"].DisplayIndex = 14;
            DtgDepoHareketleriSaha.Columns["DusulenMalzemeYeri"].DisplayIndex = 15;
            DtgDepoHareketleriSaha.Columns["TalepEdenPersonel"].DisplayIndex = 16;
            DtgDepoHareketleriSaha.Columns["Aciklama"].DisplayIndex = 17;

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

            DtgIslemKayitlari.Columns["CalismaSuresi"].DefaultCellStyle.Format = @"HH:mm:ss";

            foreach (DataGridViewRow row in DtgIslemKayitlari.Rows)
            {
                string value = row.Cells["CalismaSuresi"].Value.ToString();
                row.Cells["CalismaSuresi"].Value = value.Substring(value.IndexOf(' ') + 1);
            }
            webBrowser1.Navigate(dosyaYolu);
            Toplamlar();
            ToplamlarIslemAdimSureleri();
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
        void EksikEvrakList()
        {
            arizaKayits = arizaKayitManager.BOEksikEvrekList();
            dataBinder.DataSource = arizaKayits.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["IsAkisNo"].Visible = false;
            DtgList.Columns["AbfFormNo"].HeaderText = "ABF FORM NO";
            DtgList.Columns["Proje"].HeaderText = "PROJE";
            DtgList.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgList.Columns["BolukKomutani"].Visible = false;
            DtgList.Columns["BirlikAdresi"].Visible = false;
            DtgList.Columns["Il"].Visible = false;
            DtgList.Columns["Ilce"].Visible = false;
            DtgList.Columns["BildirilenAriza"].Visible = false;
            DtgList.Columns["ArizaiBildirenPersonel"].Visible = false;
            DtgList.Columns["AbRutbesi"].Visible = false;
            DtgList.Columns["AbGorevi"].Visible = false;
            DtgList.Columns["AbTelefon"].Visible = false;
            DtgList.Columns["AbTarihSaat"].HeaderText = "ARIZA BİLDİRİM TARİHİ/SAATİ";
            DtgList.Columns["ABAlanPersonel"].Visible = false;
            DtgList.Columns["BildirimKanali"].Visible = false;
            DtgList.Columns["ArizaAciklama"].HeaderText = "ARIZA AÇIKLAMA";
            DtgList.Columns["GorevAtanacakPersonel"].HeaderText = "İŞLEM ADIMI SORUMLUSU";
            DtgList.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgList.Columns["LojistikSorumluPersonel"].Visible = false;
            DtgList.Columns["LojRutbesi"].Visible = false;
            DtgList.Columns["LojGorevi"].Visible = false;
            DtgList.Columns["LojTarihi"].Visible = false;
            DtgList.Columns["TespitEdilenAriza"].Visible = false;
            DtgList.Columns["AcmaOnayiVeren"].Visible = false;
            DtgList.Columns["CsSiparisNo"].HeaderText = "CS SİPARİŞ NO";
            DtgList.Columns["BildirimNo"].HeaderText = "BİLDİRİM NO";
            DtgList.Columns["CrmNo"].HeaderText = "CRM HİZMET NO";
            DtgList.Columns["SiparisNo"].Visible = false;
            DtgList.Columns["BildirimMailTarihi"].Visible = false;
            DtgList.Columns["TelefonNo"].Visible = false;
            DtgList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["Kategori"].HeaderText = "KATEGORİ";
            DtgList.Columns["IlgiliFirma"].Visible = false;
            DtgList.Columns["BildirimTuru"].HeaderText = "BİLDİRİM TÜRÜ";
            DtgList.Columns["PypNo"].Visible = false;
            DtgList.Columns["SorumluPersonel"].Visible = false;
            DtgList.Columns["IslemTuru"].Visible = false;
            DtgList.Columns["Hesaplama"].Visible = false;
            DtgList.Columns["Durum"].Visible = false;
            DtgList.Columns["OnarimNotu"].HeaderText = "ONARIM NOTU";
            DtgList.Columns["TeslimEdenPersonel"].HeaderText = "TESLİM EDEN PERSONEL";
            DtgList.Columns["TeslimAlanPersonel"].HeaderText = "TESLİM ALAN PERSONEL";
            DtgList.Columns["TeslimTarihi"].HeaderText = "TESLİM TARİHİ";
            DtgList.Columns["NesneTanimi"].HeaderText = "NESNE TANIMI";
            DtgList.Columns["HasarKodu"].HeaderText = "HASAR KODU";
            DtgList.Columns["NedenKodu"].HeaderText = "NEDEN KODU";
            DtgList.Columns["EksikEvrak"].Visible = false;


            DtgList.Columns["AbfFormNo"].DisplayIndex = 0;
            DtgList.Columns["Proje"].DisplayIndex = 1;
            DtgList.Columns["BolgeAdi"].DisplayIndex = 2;
            DtgList.Columns["AbTarihSaat"].DisplayIndex = 3;
            DtgList.Columns["BildirimTuru"].DisplayIndex = 4;
            DtgList.Columns["Kategori"].DisplayIndex = 5;
            DtgList.Columns["CsSiparisNo"].DisplayIndex = 6;
            DtgList.Columns["BildirimNo"].DisplayIndex = 7;
            DtgList.Columns["CrmNo"].DisplayIndex = 8;
            DtgList.Columns["StokNo"].DisplayIndex = 9;
            DtgList.Columns["Tanim"].DisplayIndex = 10;
            DtgList.Columns["SeriNo"].DisplayIndex = 11;
            DtgList.Columns["GarantiDurumu"].DisplayIndex = 13;
            DtgList.Columns["IslemAdimi"].DisplayIndex = 14;
            DtgList.Columns["GorevAtanacakPersonel"].DisplayIndex = 15;
        }

    }
}
