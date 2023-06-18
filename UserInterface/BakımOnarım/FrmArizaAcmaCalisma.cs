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
using ClosedXML.Excel;
using UserInterface.Gecic_Kabul_Ambar;

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
        MalzemeManager malzemeManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        IslemAdimlariManager islemAdimlariManager;
        PypManager pypManager;
        AbfMalzemeManager abfMalzemeManager;
        IscilikIscilikManager ıscilikIscilikManager;
        AtolyeManager atolyeManager;
        StokGirisCikisManager stokGirisCikisManager;
        BolgeKayitManager bolgeKayitManager;
        UstTakimManager ustTakimManager;
        BolgeGarantiManager bolgeGarantiManager;
        AbfMalzemeIslemKayitManager abfMalzemeIslemKayitManager;

        bool start = true, dosyaKontrol = false, kayitKontrol = false;
        public object[] infos;
        string isAkisNo, dosyaYolu = "", kaynakdosyaismi, alinandosya, proje, siparisNo, comboAd, personelGorevi, personelBolumu, sure;
        List<string> fileNames = new List<string>();
        List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
        List<StokGirisCıkıs> stokGirisCıkıs;
        List<GorevAtamaPersonel> gorevAtamaPersonels;
        //List<MalzemeKayit> malzemeKayits;
        List<Malzeme> malzemes;
        List<Atolye> atolyes;
        List<ArizaKayit> arizaKayits;
        int abfForm, abf, gun, saat, dakika;
        DateTime birOncekiTarih;
        public int id;
        string lojTarihi, dosya, bolukKomutani, telefon, birlikAdresi, il, ilce, taslakYolu = "", yetkiModu;
        string yol = @"C:\DTS\Taslak\";
        string kaynak = @"Z:\DTS\BAKIM ONARIM\TASLAKLAR\";

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
            malzemeManager = MalzemeManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            ustTakimManager = UstTakimManager.GetInstance();
            bolgeGarantiManager = BolgeGarantiManager.GetInstance();
            abfMalzemeIslemKayitManager = AbfMalzemeIslemKayitManager.GetInstance();
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
            CmbProjAK();
            UsBolgeleriAK();
            ParcaTanimiAK();
            KategoriAK();
            IlgiliFirmaAK();
            BildirimTuruAK();
            PypAK();
            CmbStokNoSokulen();
            StokNoTakilan();
            PersonellerAK();
            PersonellerAK2();
            PersonellerAK3();
            NesneTanimiAK();
            HasarKoduAK();
            NedenKoduAK();
            IsAkisNoAK();
            IslemTuru();
            IslemTuruKapatma();
            start = false;
            LblArizaBildirimiAlan.Text = infos[1].ToString();
            yetkiModu = infos[11].ToString();
            tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage1"]);
            tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage13"]);
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
            CmbProjAK();
            UsBolgeleriAK();
            ParcaTanimiAK();
            KategoriAK();
            IlgiliFirmaAK();
            BildirimTuruAK();
            PypAK();
            IsAkisNoAK();
            IslemTuru();
            IslemTuruKapatma();
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
        public void CmbStokNo()
        {
            List<UstTakim> ustTakims = new List<UstTakim>();

            ustTakims = ustTakimManager.GetList();
            CmbParcaNo.DataSource = ustTakims;
            CmbParcaNo.ValueMember = "Id";
            CmbParcaNo.DisplayMember = "Tanim";
            CmbParcaNo.SelectedValue = 0;

            CmbParcaTanim.DataSource = ustTakims;
            CmbParcaTanim.ValueMember = "Id";
            CmbParcaTanim.DisplayMember = "Tanim";
            CmbParcaTanim.SelectedValue = 0;

        }
        void ParcaTanimiAK()
        {
            //CmbParcaTanimiAK.DataSource = malzemeManager.MalzemeUstTakimList();
            //CmbParcaTanimiAK.ValueMember = "Id";
            //CmbParcaTanimiAK.DisplayMember = "Tanim";
            //CmbParcaTanimiAK.SelectedValue = 0;
        }
        void IlgiliFirma()
        {
            CmbIlgiliFirma.DataSource = comboManager.GetList("ONARIM_YERI");
            CmbIlgiliFirma.ValueMember = "Id";
            CmbIlgiliFirma.DisplayMember = "Baslik";
            CmbIlgiliFirma.SelectedValue = 0;
        }
        void IlgiliFirmaAK()
        {
            CmbIlgiliFirmaK.DataSource = comboManager.GetList("ONARIM_YERI");
            CmbIlgiliFirmaK.ValueMember = "Id";
            CmbIlgiliFirmaK.DisplayMember = "Baslik";
            CmbIlgiliFirmaK.SelectedValue = 0;
        }
        public void BildirimTuru()
        {
            CmbBildirimTuru.DataSource = comboManager.GetList("BILDIRIM TURU");
            CmbBildirimTuru.ValueMember = "Id";
            CmbBildirimTuru.DisplayMember = "Baslik";
            CmbBildirimTuru.SelectedValue = 0;
        }
        public void BildirimTuruAK()
        {
            CmbBildirimTuruK.DataSource = comboManager.GetList("BILDIRIM TURU");
            CmbBildirimTuruK.ValueMember = "Id";
            CmbBildirimTuruK.DisplayMember = "Baslik";
            CmbBildirimTuruK.SelectedValue = 0;
        }
        void PersonellerAK()
        {
            CmbTespitEdenPersonelAK.DataSource = kayitManager.PersonelAdSoyad();
            CmbTespitEdenPersonelAK.ValueMember = "Id";
            CmbTespitEdenPersonelAK.DisplayMember = "Adsoyad";
            CmbTespitEdenPersonelAK.SelectedValue = -1;
        }
        public void HasarKodu()
        {
            CmbHasarKodu.DataSource = comboManager.GetList("HASAR_KODU");
            CmbHasarKodu.ValueMember = "Id";
            CmbHasarKodu.DisplayMember = "Baslik";
            CmbHasarKodu.SelectedValue = 0;
        }
        public void HasarKoduAK()
        {
            CmbHasarKoduAK.DataSource = comboManager.GetList("HASAR_KODU");
            CmbHasarKoduAK.ValueMember = "Id";
            CmbHasarKoduAK.DisplayMember = "Baslik";
            CmbHasarKoduAK.SelectedValue = 0;
        }
        public void NedenKodu()
        {
            CmbNedenKodu.DataSource = comboManager.GetList("NEDEN_KODU");
            CmbNedenKodu.ValueMember = "Id";
            CmbNedenKodu.DisplayMember = "Baslik";
            CmbNedenKodu.SelectedValue = 0;
        }
        public void NedenKoduAK()
        {
            CmbNedenKoduAK.DataSource = comboManager.GetList("NEDEN_KODU");
            CmbNedenKoduAK.ValueMember = "Id";
            CmbNedenKoduAK.DisplayMember = "Baslik";
            CmbNedenKoduAK.SelectedValue = 0;
        }
        public void NesneTanimi()
        {
            CmbNesneTanimi.DataSource = comboManager.GetList("NESNE_TANIMI");
            CmbNesneTanimi.ValueMember = "Id";
            CmbNesneTanimi.DisplayMember = "Baslik";
            CmbNesneTanimi.SelectedValue = 0;
        }
        public void NesneTanimiAK()
        {
            CmbNesneTanimiAK.DataSource = comboManager.GetList("NESNE_TANIMI");
            CmbNesneTanimiAK.ValueMember = "Id";
            CmbNesneTanimiAK.DisplayMember = "Baslik";
            CmbNesneTanimiAK.SelectedValue = 0;
        }
        void Pyp()
        {
            CmbPypNo.DataSource = pypManager.GetList();
            CmbPypNo.ValueMember = "Id";
            CmbPypNo.DisplayMember = "PypNo";
            CmbPypNo.SelectedValue = 0;
        }
        void PypAK()
        {
            CmbPyp.DataSource = pypManager.GetList();
            CmbPyp.ValueMember = "Id";
            CmbPyp.DisplayMember = "PypNo";
            CmbPyp.SelectedValue = 0;
        }

        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        void IsAkisNoSiparisOlustur()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            isAkisNo = isAkis.Id.ToString();
        }

        void IsAkisNoAK()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNoAK.Text = isAkis.Id.ToString();
        }
        void Kategori()
        {
            CmbKategori.DataSource = comboManager.GetList("ABF KATEGORİ");
            CmbKategori.ValueMember = "Id";
            CmbKategori.DisplayMember = "Baslik";
            CmbKategori.SelectedValue = 0;
        }
        void IslemTuru()
        {
            CmbIslem.DataSource = comboManager.GetList("ISLEM_TURU");
            CmbIslem.ValueMember = "Id";
            CmbIslem.DisplayMember = "Baslik";
            CmbIslem.SelectedValue = 0;
        }
        void IslemTuruKapatma()
        {
            CmbIslemTuruKapatma.DataSource = comboManager.GetList("ISLEM_TURU");
            CmbIslemTuruKapatma.ValueMember = "Id";
            CmbIslemTuruKapatma.DisplayMember = "Baslik";
            CmbIslemTuruKapatma.SelectedValue = 0;
        }
        void KategoriAK()
        {
            CmbKategoriK.DataSource = comboManager.GetList("ABF KATEGORİ");
            CmbKategoriK.ValueMember = "Id";
            CmbKategoriK.DisplayMember = "Baslik";
            CmbKategoriK.SelectedValue = 0;
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
        void PersonellerAK2()
        {
            CmbAcmaOnayiVerenAK.DataSource = kayitManager.PersonelAdSoyad();
            CmbAcmaOnayiVerenAK.ValueMember = "Id";
            CmbAcmaOnayiVerenAK.DisplayMember = "Adsoyad";
            CmbAcmaOnayiVerenAK.SelectedValue = -1;
        }
        void PersonellerAK3()
        {
            CmbTeslimEdenAK.DataSource = kayitManager.PersonelAdSoyad();
            CmbTeslimEdenAK.ValueMember = "Id";
            CmbTeslimEdenAK.DisplayMember = "Adsoyad";
            CmbTeslimEdenAK.SelectedValue = -1;
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
        void CmbProjAK()
        {
            CmbProjeAK.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProjeAK.ValueMember = "Id";
            CmbProjeAK.DisplayMember = "Baslik";
            CmbProjeAK.SelectedValue = 0;
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
            if (arizaKayit.IslemAdimi!= "400_SİPARİŞ OLUŞTURMA (DTS)")
            {
                MessageBox.Show("Bu arıza " + arizaKayit.IslemAdimi + " adımındadır. Bu ekrendan işlem yapabilmek için arızanın 400_SİPARİŞ OLUŞTURMA (DTS) işelm adımında olması gerekmektedir!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CmbIslemAdimi.Text = "500_ARIZA BİLDİRİMİ (ASELSAN)";
            CmbGorevAtanacak.Text = "ŞERİFE NUR GÜNEŞ";

            abfNo = TxtAbfFormNo.Text;
            LblBolgeAdi.Text = arizaKayit.BolgeAdi;
            isAkisNo = arizaKayit.IsAkisNo.ToString();
            TxtBildirilenArizaSiparis.Text = arizaKayit.BildirilenAriza;
            TxtArizaBildirenSiparis.Text = arizaKayit.ArizaiBildirenPersonel;
            TxtArizaBildirenRutbesi.Text = arizaKayit.AbRutbesi;
            TxtArizaBildirenGorevi.Text = arizaKayit.AbGorevi;
            TxtArizaBildirenTarih.Value = arizaKayit.AbTarihSaat;
            TxtArizaBildirenSaat.Value = arizaKayit.AbTarihSaat;
            CmbGarantiDurumu.Text = arizaKayit.GarantiDurumu;
            CmbPersoneller.Text = arizaKayit.ABAlanPersonel;
            DtgMailGeldigiTarih.Value = arizaKayit.AbTarihSaat;

            if (CmbGarantiDurumu.Text == "DIŞI")
            {
                TxtLojistikSorumlusu.Text = arizaKayit.LojistikSorumluPersonel;
                TxtLojistikSorRutbesi.Text = arizaKayit.LojRutbesi;
                TxtLojistikSorGorevi.Text = arizaKayit.LojGorevi;
                DtLojistikTarih.Value = arizaKayit.LojTarihi.ConDate();
                DtLojistikSaat.Value = arizaKayit.LojTarihi.ConDate();
            }
            else
            {
                TxtLojistikSorumlusu.Text = "";
                TxtLojistikSorRutbesi.Text = "";
                TxtLojistikSorGorevi.Text = "";

            }
            CmbParcaNo.Text = arizaKayit.Tanim;
            TxtSeriNo.Text = arizaKayit.SeriNo;
            abf = arizaKayit.AbfFormNo;
            id = arizaKayit.Id;
            dosyaYolu = arizaKayit.DosyaYolu;
            LblTespit.Text = arizaKayit.TespitEdilenAriza;


            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "BAKIM ONARIM");
            if (gorevAtamaPersonel == null)
            {
                LblMevcutIslemAdimi.Text = "";
            }
            else
            {
                LblMevcutIslemAdimi.Text = gorevAtamaPersonel.IslemAdimi;
            }

            BolgeKayit bolgeKayit = bolgeKayitManager.Get(0, LblBolgeAdi.Text);
            BolgeGaranti bolgeGaranti = bolgeGarantiManager.Get(bolgeKayit.SiparisNo);
            if (bolgeKayit == null)
            {
                LblProje.Text = "";
                GrnBasTarihi.Text = "";
                GrnBitTarihi.Text = "";
            }
            else
            {
                if (bolgeGaranti==null)
                {
                    LblProje.Text = bolgeKayit.Proje;
                    GrnBasTarihi.Text = bolgeKayit.GarantiBaslama.ToString("d");
                    GrnBitTarihi.Text = bolgeKayit.GarantiBitis.ToString("d");
                }
                else
                {
                    LblProje.Text = bolgeGaranti.GarantiPaketi;
                    GrnBasTarihi.Text = bolgeGaranti.GarantiBaslama.ToString("d");
                    GrnBitTarihi.Text = bolgeGaranti.GarantiBitis.ToString("d");
                }
                
                sorumluPersonel = bolgeKayit.BolgeSorumlusu;
                bolgeBirlikAdresi = bolgeKayit.BirlikAdresi;
                bolgeIl = bolgeKayit.Il;
                bolgeIlce = bolgeKayit.Ilce;
                faturaAdresi = "";
                bolgeTelefon = arizaKayit.TelefonNo;
                CmbPypNo.Text = bolgeKayit.PypNo;
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
        string sorumluPersonel, bolgeBirlikAdresi, bolgeIl, bolgeIlce, faturaAdresi, bolgeTelefon, abfNo;
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
            DtgMalzemeList.Columns["MalzemeIslemAdimi"].Visible = false;
            DtgMalzemeList.Columns["MalzemeDurumu"].Visible = false;
            DtgMalzemeList.Columns["TemineAtilamTarihi"].Visible = false;
            DtgMalzemeList.Columns["AbTarihSaat"].Visible = false;
            DtgMalzemeList.Columns["AbfNo"].Visible = false;
            DtgMalzemeList.Columns["TeminDurumu"].Visible = false;
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
            LblProje.Text = "00"; GrnBasTarihi.Text = "00"; GrnBitTarihi.Text = "00"; CmbParcaNo.SelectedIndex = -1; LbStokNo.Text = "00"; TxtSeriNo.Clear();
            CmbKategori.SelectedIndex = -1; CmbIlgiliFirma.SelectedIndex = -1; CmbBildirimTuru.SelectedIndex = -1; CmbPypNo.SelectedIndex = -1;
            TxtSorumluPersonel.Clear(); TxtSiparisTuru.SelectedIndex = -1; CmbIslem.SelectedIndex=-1; TxtHesaplama.Clear(); LblMevcutIslemAdimi.Text = "00";
            CmbGorevAtanacak.SelectedIndex = -1; CmbIslemAdimi.SelectedIndex = -1;
        }


        private void CmbPypNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            Pyp pyp = pypManager.Get(CmbPypNo.SelectedIndex);
            if (pyp==null)
            {
                return;
            }
            TxtSorumluPersonel.Text = pyp.SorumluPersonel;
            TxtSiparisTuru.Text = pyp.SiparisTuru;
            TxtHesaplama.Text = pyp.HesaplamaNedeni;

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

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
            CmbStokNoTakilan.DataSource = malzemeManager.GetList();
            CmbStokNoTakilan.ValueMember = "Id";
            CmbStokNoTakilan.DisplayMember = "StokNo";
            CmbStokNoTakilan.SelectedValue = 0;
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

            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ArizaKayit arizaKayit = new ArizaKayit(id, TxtCsSiparisNo.Text, TxtBildirimNo.Text.Trim(), TxtCrmNo.Text, DtgMailTarihi.Text, TxtEkipmanNo.Text, TxtOkfBildirimNo.Text.Trim());
                mesaj = arizaKayitManager.CrmNoTanimla(arizaKayit);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                arizaKayitManager.IslemAdimiGuncelle(id, CmbCrmIslemAdimlari.Text, CmbCrmGorevAtanacakPer.Text);
                GorevAtamCrm();
                mesaj = ExcelDoldurCrmNo();
                //if (mesaj != "OK")
                //{
                //    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    IsAkisNo();
                //    return;
                //}
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAkisNo();
                IsAkisNoAK();
                CrmTemizle();
            }
        }

        private string ExcelDoldurCrmNo()
        {
            string excelFilePath = Path.Combine(dosyaYolu + "\\" + isAkisNo + " " + bolgeAdi + " " + abfForm + ".xlsx");
            bool exists = File.Exists(excelFilePath);
            if (exists == false)
            {
                return "Excel Dosyası Bulunamadı!";
            }
            IXLWorkbook xLWorkbook = new XLWorkbook(excelFilePath, XLEventTracking.Disabled);
            IXLWorksheet worksheet = xLWorkbook.Worksheet("Sayfa1");

            var range = worksheet.RangeUsed();
            worksheet.Cell("I9").Value = TxtBildirimNo.Text.Trim(); // BİLDİRİM NO
            worksheet.Cell("O9").Value = TxtCsSiparisNo.Text.Trim(); // SİPARİŞ NO
            if (TxtCrmNo.Text != "")
            {
                worksheet.Cell("O9").Value = "CRM:" + TxtCrmNo.Text; // CRM NO
            }
            worksheet.Cell("I18").Value = TxtEkipmanNo.Text; // EKİPMAN NO

            if (dosyaYolu != "")
            {
                xLWorkbook.SaveAs(dosyaYolu + "\\" + isAkisNo + " " + bolgeAdi + " " + abfForm + ".xlsx");
            }

            return "OK";
        }

        void CrmTemizle()
        {
            TxtCrmFormNo.Clear(); DtgFormBilgileri.Rows.Clear(); TxtCsSiparisNo.Clear(); TxtBildirimNo.Clear(); TxtCrmNo.Clear();
            LblCrmMevcutIslemAdimi.Text = "00"; CmbCrmGorevAtanacakPer.SelectedIndex = -1; CmbCrmIslemAdimlari.SelectedIndex = -1; TxtOkfBildirimNo.Clear();
        }
        string CrmNoKontrol()
        {
            if (DtgFormBilgileri.RowCount == 0)
            {
                return "Lütfen Öncelikle Geçerli Bir Abf No Yazarak Bul Butonuna Basınız!";
            }
            //if (TxtCsSiparisNo.Text == "")
            //{
            //    return "Lütfen CS Sipariş No Bilgisini Yazınız!";
            //}
            //if (TxtBildirimNo.Text == "")
            //{
            //    return "Lütfen Bildirim No Bilgisini Yazınız!";
            //}
            //if (TxtCrmNo.Text == "")
            //{
            //    return "Lütfen Crm No Bilgisini Yazınız!";
            //}
            if (CmbCrmGorevAtanacakPer.Text == "")
            {
                return "Lütfen Görev Atanacak Personel Bilgisini Seçiniz!";
            }
            if (CmbCrmIslemAdimlari.Text == "")
            {
                return "Lütfen Bir Sonraki İşlem Adımı Bilgisini Seçiniz!";
            }

            if (TxtBildirimNo.Text != "")
            {
                List<ArizaKayit> arizaKayits = new List<ArizaKayit>();
                arizaKayits = arizaKayitManager.GetList();
                foreach (ArizaKayit item in arizaKayits)
                {
                    if (item.BildirimNo == TxtBildirimNo.Text)
                    {
                        return "Bu bildirim numarası " + item.AbfFormNo + " numaralı arıza için kullanılmıştır!";
                    }
                }
            }
            
            return "OK";
        }
        string bolgeAdi = "";
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
            if (arizaKayit.IslemAdimi != "500_ARIZA BİLDİRİMİ (ASELSAN)")
            {
                MessageBox.Show("Bu arıza " + arizaKayit.IslemAdimi + " adımındadır. Bu ekrendan işlem yapabilmek için arızanın 500_ARIZA BİLDİRİMİ (ASELSAN) adımında olması gerekmektedir!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            isAkisNo = arizaKayit.IsAkisNo.ToString();
            id = arizaKayit.Id;
            dosyaYolu = arizaKayit.DosyaYolu;
            bolgeAdi = arizaKayit.BolgeAdi;

            CmbCrmIslemAdimlari.Text = "600_BİLDİRİM ONAYI (MÜHENDİS)";
            CmbCrmGorevAtanacakPer.Text = "ŞERİFE NUR GÜNEŞ";

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
                MessageBox.Show("Lütfen öncelikle bir ABF No Yazarak Bul butonuna basınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string personel = "";
                personel = CmbGorevAtanacak.Text;
                if (personel=="")
                {
                    MessageBox.Show("Lütfen görev atanacak personel bilgisini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ArizaKayit arizaKayit2 = arizaKayitManager.Get(abf);
                id = arizaKayit2.Id;

                DateTime lojTarih = new DateTime(DtLojistikTarih.Value.Year, DtLojistikTarih.Value.Month, DtLojistikTarih.Value.Day, DtLojistikSaat.Value.Hour, DtLojistikSaat.Value.Minute, DtLojistikSaat.Value.Second);

                //mesaj = PersonelIscilikleriEkle();
                //if (mesaj != "OK")
                //{
                //    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                if (CmbGarantiDurumu.Text == "İÇİ")
                {
                    lojTarihi = "";
                }
                else
                {
                    lojTarihi = lojTarih.ToString();
                }

                ArizaKayit arizaKayit = new ArizaKayit(id, CmbGarantiDurumu.Text, TxtLojistikSorumlusu.Text, TxtLojistikSorRutbesi.Text, TxtLojistikSorGorevi.Text, lojTarihi, LblTespit.Text.ToUpper(), CmbPersoneller.Text);

                string mesaj2 = arizaKayitManager.ArizaSiparisOlustur(arizaKayit);
                if (mesaj2 != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                arizaKayitManager.IslemAdimiGuncelle(id, CmbIslemAdimi.Text, personel);

                SistemCihazBilgileriKayit();
                mesaj2 = GorevAtamaSiparisOlustur();

                if (mesaj2 != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                TaslakKopyala();
                bool kontrol = SetExcelInfoArizaKayitOlustur();
                if (kontrol == false)
                {
                    MessageBox.Show("Excel Oluşturulurken hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                personel = "";
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAkisNo();
                IsAkisNoAK();
                TemizleSiparisOlustur();
                SiparisTemizle();
            }
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

            File.Copy(kaynak + "abf.xlsx", yol + "abf.xlsx");

            taslakYolu = yol + "abf.xlsx";
        }
        void SiparisTemizle()
        {
            CmbPersoneller.SelectedIndex = -1; DtIscilikSaati.Text = "00:00"; AdvPersonel.Rows.Clear(); DtgMudehaleSaati.Text = "00:00"; CmbArizaAcmaOnayiVeren.SelectedValue = ""; DtgMalzemeList.DataSource = null; LblTespit.Clear(); LblBolgeAdi.Text = "-"; TxtBildirilenArizaSiparis.Clear(); CmbGarantiDurumu.SelectedIndex = -1;
            TxtArizaBildirenSiparis.Clear();
        }
        void SistemCihazBilgileriKayit()
        {
            ArizaKayit arizaKayit = new ArizaKayit(id, LbStokNo.Text, CmbParcaNo.Text, TxtSeriNo.Text, CmbKategori.Text, CmbIlgiliFirma.Text, CmbBildirimTuru.Text, CmbPypNo.Text, TxtSorumluPersonel.Text, TxtSiparisTuru.Text, CmbIslem.Text, TxtHesaplama.Text);

            arizaKayitManager.SistemCihazBilgileri(arizaKayit);
        }
        void SistemCihazBilgileriKayitAK()
        {
            ArizaKayit arizaKayit = new ArizaKayit(id, LblStokNoAK.Text, CmbParcaTanimiAK.Text, TxtSeriNoAK.Text, CmbKategoriAK.Text, CmbIlgliFirmaAK.Text, CmbBildirimTuruAK.Text, CmbPypNoAK.Text, TxtSorumluPersonelAK.Text, CmbSiparisTuruAK.Text, TxtIslemTuruAK.Text, TxtHesaplamaAK.Text);

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
        string PersonelIscilikleriEkleAK()
        {
            foreach (DataGridViewRow item in AdvPersonelAK.Rows)
            {
                IscilikIscilik ıscilikIscilik = new IscilikIscilik(id, item.Cells["AdiSoyadiAK"].Value.ToString(), item.Cells["GoreviAK"].Value.ToString(), item.Cells["BolumuAK"].Value.ToString(), "İŞÇİLİK", abfForm.ToString(), DateTime.Now, DtgIscilikSuresiAK.Value.Date);

                ıscilikIscilikManager.Add(ıscilikIscilik);
            }
            return "OK";
        }
        string arizaStok;
        int arizaId = 0;
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
            if (arizaKayit.IslemAdimi!= "2000_ARIZA KAPATMA (DTS)")
            {
                MessageBox.Show("Bu arıza " + arizaKayit.IslemAdimi + " işlem adımındadır. Bu ekrandan işlem yapabilmek için arıza 2000_ARIZA KAPATMA (DTS) adımında olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DtgFormBilgileriKapat.Rows.Add();
            int sonSatir = DtgFormBilgileriKapat.RowCount - 1;

            DtgFormBilgileriKapat.Rows[sonSatir].Cells["FormNoK"].Value = arizaKayit.AbfFormNo.ToString();
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["BildirimNoK"].Value = arizaKayit.BildirimNo;
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["BolgeAdiK"].Value = arizaKayit.BolgeAdi;
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["StokNoK"].Value = arizaKayit.StokNo;
            arizaStok = arizaKayit.StokNo;
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["TanimK"].Value = arizaKayit.Tanim;
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["SeriNoK"].Value = arizaKayit.SeriNo;
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["ArizaBildirimTarihiK"].Value = arizaKayit.AbTarihSaat.ToString();
            DtgFormBilgileriKapat.Rows[sonSatir].Cells["BolgeSorumlusuK"].Value = arizaKayit.AcmaOnayiVeren;

            CmbParcaTanim.Text = arizaKayit.Tanim;
            TxtUstSeriNo.Text = arizaKayit.SeriNo;
            CmbKategoriK.Text = arizaKayit.Kategori;
            CmbIlgiliFirmaK.Text = arizaKayit.IlgiliFirma;
            CmbPyp.Text = arizaKayit.PypNo;

            if (CmbPyp.Text=="")
            {
                BolgeKayit bolgeKayit = bolgeKayitManager.Get(0, arizaKayit.BolgeAdi);
                if (bolgeKayit==null)
                {
                    CmbPyp.Text = "";
                }
                else
                {
                    CmbPyp.Text = bolgeKayit.PypNo;
                }
            }
            CmbBildirimTuruK.Text = arizaKayit.BildirimTuru;
            CmbSorumluPersonel.Text = arizaKayit.SorumluPersonel;
            //LblSorumluPersonel.Text = arizaKayit.SorumluPersonel;
            CmbSiparisTuru.Text = arizaKayit.SiparisTuru;
            CmbIslemTuruKapatma.Text = arizaKayit.IslemTuru;
            CmbHesaplama.Text = arizaKayit.Hesaplama;
            bolgeAdi = arizaKayit.BolgeAdi;
            TxtBildirimNoK.Text = arizaKayit.BildirimNo;
            DtAselsanMail.Value = arizaKayit.BildirimMailTarihi.ConDate();
            abf = arizaKayit.AbfFormNo;
            abfForm = arizaKayit.AbfFormNo;
            arizaId = arizaKayit.Id;
            bolgeAdi = arizaKayit.BolgeAdi;

            BolgeKayit bolge = bolgeKayitManager.Get(0, bolgeAdi);
            if (bolge == null)
            {
                LblGarantiPaketi.Text = "00";
                LblGarantiBas.Text = "00";
                LblGarantiBit.Text = "00";
            }
            else
            {
                siparisNo = bolge.SiparisNo;
                BolgeGaranti bolgeGaranti = bolgeGarantiManager.Get(siparisNo);
                if (bolgeGaranti==null)
                {
                    BolgeKayit bolgeKayit = bolgeKayitManager.Get(0, arizaKayit.BolgeAdi);
                    LblGarantiPaketi.Text = bolgeKayit.Proje;
                    LblGarantiBas.Text = bolgeKayit.GarantiBaslama.ToString("d");
                    LblGarantiBit.Text = bolgeKayit.GarantiBitis.ToString("d");
                }
                else
                {
                    LblGarantiPaketi.Text = bolgeGaranti.GarantiPaketi;
                    LblGarantiBas.Text = bolgeGaranti.GarantiBaslama.ToString("d");
                    LblGarantiBit.Text = bolgeGaranti.GarantiBitis.ToString("d");
                }
                
            }
            string dosya = arizaKayit.DosyaYolu;
            dosyaYolu = dosya;
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
            if (start == true)
            {
                return;
            }
            if (CmbTeslimEden.SelectedIndex == -1)
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
            //if (CmbGarantiDurumu.Text == "")
            //{
            //    return "Lütfen Garanti Durumu Bilgisini Seçiniz!";
            //}
            //if (CmbGarantiDurumu.Text == "")
            //{
            //    return "Lütfen Garanti Durumu Bilgisini Seçiniz!";
            //}
            if (CmbGarantiDurumu.Text == "DIŞI")
            {
                if (TxtLojistikSorumlusu.Text == "")
                {
                    return "Lütfen Lojistik Sorumlusu Bilgisini Doldurunuz!";
                }
            }

            //if (AdvPersonel.RowCount == 0)
            //{
            //    return "Lütfen Personel İşçilik ve Süresi Bilgilerini Doldurunuz!";
            //}
            //if (DtIscilikSaati.Text == "00:00")
            //{
            //    return "Lütfen Personel İşçilik Saati Bilgilerini Yazınız!";
            //}
            //if (DtgMudehaleSaati.Text == "00:00")
            //{
            //    return "Lütfen Müdehale Saati Bilgilerini Yazınız!";
            //}
            //if (CmbArizaAcmaOnayiVeren.Text == "")
            //{
            //    return "Lütfen Arıza Açma Onayı Veren Sorumlu Personel Seçiniz!";
            //}

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
            if (CmbPersoneller.SelectedIndex == -1)
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
            UstTakim ustTakim = ustTakimManager.Get(id);
            if (ustTakim == null)
            {
                LbStokNo.Text = "";

                return;
            }
            LbStokNo.Text = ustTakim.StokNo;
            CmbIlgiliFirma.Text = ustTakim.IlgiliFirma;
        }

        void UsBolgeleri()
        {
            CmbBolgeAdi.DataSource = bolgeKayitManager.GetList();
            CmbBolgeAdi.ValueMember = "Id";
            CmbBolgeAdi.DisplayMember = "BolgeAdi";
            CmbBolgeAdi.SelectedValue = "";
        }
        void UsBolgeleriAK()
        {
            CmbBolgeAdiAK.DataSource = bolgeKayitManager.GetList();
            CmbBolgeAdiAK.ValueMember = "Id";
            CmbBolgeAdiAK.DisplayMember = "BolgeAdi";
            CmbBolgeAdiAK.SelectedValue = "";
        }

        private void BtnBolgeEkle_Click(object sender, EventArgs e)
        {
            FrmBolgeler frmBolgeler = new FrmBolgeler();
            frmBolgeler.ShowDialog();
        }

        private void BtnKaydetKapat_Click(object sender, EventArgs e)
        {
            string mesaj = KayitKapatKontrol();
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DateTime teslimTarihi = new DateTime(DtTeslimTarihiKapat.Value.Year, DtTeslimTarihiKapat.Value.Month, DtTeslimTarihiKapat.Value.Day, DtTeslimSaati.Value.Hour, DtTeslimSaati.Value.Minute, DtTeslimSaati.Value.Second);
                
                int eksikEvrak = 0;
                if (ChkEksikEvrak.Checked == true)
                {
                    eksikEvrak = 1;
                }

                ArizaKayit arizaKayit = new ArizaKayit(arizaId, TxtArizaOnarimNotu.Text, CmbTeslimEden.Text, LblTeslimAlanPersonel.Text, teslimTarihi, CmbNesneTanimi.Text, CmbHasarKodu.Text, CmbNedenKodu.Text, eksikEvrak, CmbParcaTanim.Text, LblUstStok.Text, TxtUstSeriNo.Text, CmbKategoriK.Text, CmbIlgiliFirmaK.Text, CmbBildirimTuruK.Text, CmbPyp.Text, CmbSorumluPersonel.Text, CmbSiparisTuru.Text, CmbIslemTuruKapatma.Text, CmbHesaplama.Text, TxtBildirimNoK.Text.Trim(), DtAselsanMail.Value.ToString("d"));

                string message = arizaKayitManager.KapatKayit(arizaKayit);
                if (message != "OK")
                {
                    MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                arizaKayitManager.AbfKapat(arizaId);
                message = ExcelDolduArizaKapat();
                //if (message != "OK")
                //{
                //    MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    IsAkisNo();
                //    return;
                //}
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAkisNo();
                IsAkisNoAK();
                EksikEvrakList();
                TemizleKapat();
            }

        }
        private string ExcelDolduArizaKapat()
        {
            string excelFilePath = Path.Combine(dosyaYolu + "\\" + isAkisNo + " " + bolgeAdi + " " + abf + ".xlsx");
            bool exists = File.Exists(excelFilePath);
            if (exists == false)
            {
                return "Excel Dosyası Bulunamadı!";
            }

            IXLWorkbook xLWorkbook = new XLWorkbook(excelFilePath, XLEventTracking.Disabled);
            IXLWorksheet worksheet = xLWorkbook.Worksheet("Sayfa1");

            var range = worksheet.RangeUsed();
            worksheet.Cell("I65").Value = TxtArizaOnarimNotu.Text; // ARIZAYA YAPILAN İŞLEM
            worksheet.Cell("I74").Value = CmbTeslimEden.Text; // TESLİM EDEN
            worksheet.Cell("I75").Value = DtTeslimTarihiKapat.Value.ToString("dd.MM.yyyy"); // TARİH
            worksheet.Cell("AF74").Value = LblTeslimAlanPersonel.Text; // TESLİM ALAN
            worksheet.Cell("AF75").Value = DtTeslimTarihi.Text; // TESLİMAT TARİHİ
            worksheet.Cell("B99").Value = arizaStok; // STOK NO
            worksheet.Cell("J99").Value = CmbNesneTanimi.Text; // NESNE TANIMI
            worksheet.Cell("R99").Value = CmbHasarKodu.Text; // HASAR KODU
            worksheet.Cell("Z99").Value = CmbNedenKodu.Text; // NEDEN KODU
            worksheet.Cell("AH99").Value = TxtArizaOnarimNotu.Text; // AÇIKLAMA

            if (dosyaYolu != "")
            {
                xLWorkbook.SaveAs(dosyaYolu + bolgeAdi + " " + abfForm + ".xlsx");
            }

            return "OK";
        }

        void TemizleKapat()
        {
            TxtAbfKapat.Clear(); DtgFormBilgileriKapat.Rows.Clear(); CmbPyp.SelectedIndex = -1; CmbSorumluPersonel.Clear(); CmbSiparisTuru.SelectedIndex = -1; ; CmbIslemTuruKapatma.SelectedIndex=-1; CmbHesaplama.Clear(); TxtBildirimNoK.Clear(); LblGarantiPaketi.Text = "00"; LblGarantiBas.Text = "00"; LblGarantiBit.Text = "00"; DtgAtolyeIslemKayitlari.DataSource = null; DtgDepoHareketleriSaha.DataSource = null; DtgMalzemeBilgileriSokulenTakilan.DataSource = null;
            DtgIslemKayitlari.DataSource = null; webBrowser2.Navigate(""); TxtArizaOnarimNotu.Clear(); CmbTeslimEden.SelectedIndex = -1; TxtSicil.Clear();
            CmbNesneTanimi.SelectedIndex = -1; CmbHasarKodu.SelectedIndex = -1; CmbNedenKodu.SelectedIndex = -1; CmbSonuc.Text = ""; ChkEksikEvrak.Checked = false;
            CmbKategoriK.SelectedIndex = -1; CmbParcaTanim.SelectedIndex = -1; LblUstStok.Text = "00"; TxtUstSeriNo.Clear(); CmbIlgiliFirmaK.SelectedIndex = -1; CmbBildirimTuruK.SelectedIndex = -1; CmbPyp.SelectedIndex = -1; DtAselsanMail.Value = DateTime.Now; LblIslemAdimSureleri.Text = "00"; LblGenelTop.Text = "00";
        }
        string KayitKapatKontrol()
        {
            if (DtgFormBilgileriKapat.RowCount==0)
            {
                return "Lütfen Öncelikle Bir ABF No yazarak nul butonuna basınız!";
            }
            if (TxtArizaOnarimNotu.Text == "")
            {
                return "Lütfen Öncelikle Ariza Onarım Notu Bilgisini Doldurunuz!";
            }
            if (CmbTeslimEden.Text == "")
            {
                return "Lütfen Öncelikle Teslim Eden Personel Bilgisini Doldurunuz!";
            }
            if (CmbNesneTanimi.Text == "")
            {
                return "Lütfen Öncelikle Nesne Tanımı Bilgisini Doldurunuz!";
            }
            if (CmbHasarKodu.Text == "")
            {
                return "Lütfen Öncelikle Hasar Kodu Bilgisini Doldurunuz!";
            }
            if (CmbNedenKodu.Text == "")
            {
                return "Lütfen Öncelikle Neden Kodu Bilgisini Doldurunuz!";
            }
            if (CmbSonuc.Text == "")
            {
                return "Lütfen Sonuç Bilgisini Doldurunuz!";
            }
            if (CmbParcaTanim.Text=="")
            {
                return "Lütfen Üst Takım Tanım Bilgisini Doldurunuz!";
            }
            if (TxtUstSeriNo.Text == "")
            {
                return "Lütfen Üst Takım Seri No Bilgisini Doldurunuz!";
            }
            if (CmbKategoriK.Text=="")
            {
                return "Lütfen Kategoori Bilgisini Doldurunuz!";
            }
            if (CmbIlgiliFirmaK.Text == "")
            {
                return "Lütfen İlgili Firma Bilgisini Doldurunuz!";
            }
            if (CmbBildirimTuruK.Text == "")
            {
                return "Lütfen Bildirim Türü Bilgisini Doldurunuz!";
            }
            if (CmbPyp.Text == "")
            {
                return "Lütfen Pyp No Bilgisini Doldurunuz!";
            }
            if (CmbSiparisTuru.Text == "")
            {
                return "Lütfen Sipariş Türü Bilgisini Doldurunuz!";
            }
            if (CmbSorumluPersonel.Text == "")
            {
                return "Lütfen Sorumlu Personel Bilgisini Doldurunuz!";
            }
            if (CmbIslemTuruKapatma.Text == "")
            {
                return "Lütfen İşlem Türü Bilgisini Doldurunuz!";
            }
            if (CmbHesaplama.Text == "")
            {
                return "Lütfen Hesaplama Bilgisini Doldurunuz!";
            }
            if (TxtBildirimNoK.Text == "")
            {
                return "Lütfen Bildirim No Bilgisini Doldurunuz!";
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
            if (eksikEvrakId == 0)
            {
                MessageBox.Show("Lütfen Öncelike Geçerli Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                arizaKayitManager.BOEksikEvrakList(eksikEvrakId);
            }
            eksikEvrakId = 0;
            IsAkisNo();
            IsAkisNoAK();
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

            if (!File.Exists(dosya))
            {
                MessageBox.Show("Belirtilen Klasörde " + dosya + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya1, dosya);
            }
            webBrowser3.Navigate(dosya);
        }
        int comboId;
        private void CmbSokulenStokNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            comboId = CmbSokulenStokNo.SelectedValue.ConInt();
            Malzeme malzemeKayit = malzemeManager.Get2(comboId);
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

        private void CmbStokNoTakilan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            comboId = CmbStokNoTakilan.SelectedValue.ConInt();
            Malzeme malzemeKayit = malzemeManager.Get2(comboId);
            if (malzemeKayit == null)
            {
                TxtTakilanTanim.Text = "";
                return;
            }
            TxtTakilanTanim.Text = malzemeKayit.Tanim;
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
        void TakilanTemizle()
        {
            CmbStokNoTakilan.Text = ""; TxtTakilanSeriNo.Clear(); TxtTakilanMiktar.Clear(); CmbTakilanBirim.Text = "";
            TxtTakilanCalismaSaati.Clear(); TxtTakilanRevizyon.Clear();
        }

        private void BtnPersonelEkleAK_Click(object sender, EventArgs e)
        {
            AdvPersonelAK.Rows.Add();
            int sonSatir = AdvPersonelAK.RowCount - 1;
            AdvPersonelAK.Rows[sonSatir].Cells["AdiSoyadiAK"].Value = CmbTespitEdenPersonelAK.Text;
            AdvPersonelAK.Rows[sonSatir].Cells["GoreviAK"].Value = personelGorevi;
            AdvPersonelAK.Rows[sonSatir].Cells["BolumuAK"].Value = personelBolumu;

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)AdvPersonelAK.Columns["RemoveAK"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
        }

        private void CmbTespitEdenPersonelAK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbTespitEdenPersonelAK.SelectedIndex == -1)
            {
                return;
            }
            PersonelKayit personelKayit = kayitManager.Get(0, CmbTespitEdenPersonelAK.Text);
            personelGorevi = personelKayit.Isunvani;
            personelBolumu = personelKayit.Sirketbolum;
        }

        private void CmbTeslimEdenAK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbTeslimEdenAK.SelectedIndex == -1)
            {
                return;
            }
            PersonelKayit personelKayit = kayitManager.Get(0, CmbTeslimEdenAK.Text);
            TxtTeslimEdenSicilAK.Text = personelKayit.Sicil;
        }

        private void CmbParcaTanimiAK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = CmbParcaTanimiAK.SelectedValue.ConInt();
            Malzeme malzemeKayit = malzemeManager.Get2(id);
            if (malzemeKayit == null)
            {
                LblStokNoAK.Text = "";
                return;
            }
            LblStokNoAK.Text = malzemeKayit.StokNo;
            CmbIlgliFirmaAK.Text = malzemeKayit.OnarimYeri;
        }

        private void CmbPypNoAK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbPypNoAK.SelectedIndex == -1)
            {
                return;
            }
            Pyp pyp = pypManager.Get(CmbPypNoAK.SelectedIndex);
            TxtSorumluPersonelAK.Text = pyp.SorumluPersonel;
            TxtSiparisTuru.Text = pyp.SiparisTuru;
            TxtHesaplamaAK.Text = pyp.HesaplamaNedeni;
        }

        private void CmbGarantiDurumuAK_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = CmbGarantiDurumuAK.SelectedIndex;
            if (index == 0)
            {
                LblLojSorAK.Visible = false;
                TxtLojSorAK.Visible = false;
                TxtLJRutbesiAK.Visible = false;
                TxtLJGoreviAK.Visible = false;
                TxtLJTarihAK.Visible = false;
                TxtLJSaatAK.Visible = false;
            }
            if (index == 1)
            {
                LblLojSorAK.Visible = true;
                TxtLojSorAK.Visible = true;
                TxtLJRutbesiAK.Visible = true;
                TxtLJGoreviAK.Visible = true;
                TxtLJTarihAK.Visible = true;
                TxtLJSaatAK.Visible = true;
            }
        }

        private void CmbParcaTanim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = CmbParcaTanim.SelectedValue.ConInt();
            UstTakim ustTakim = ustTakimManager.Get(id);
            if (ustTakim == null)
            {
                LblUstStok.Text = "";

                return;
            }
            LblUstStok.Text = ustTakim.StokNo;
            CmbIlgiliFirmaK.Text = ustTakim.IlgiliFirma;
        }

        private void CmbPyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            Pyp pyp = pypManager.Get(CmbPyp.SelectedIndex);
            if (pyp == null)
            {
                return;
            }
            CmbSorumluPersonel.Text = pyp.SorumluPersonel;
            TxtSiparisTuru.Text = pyp.SiparisTuru;
            CmbHesaplama.Text = pyp.HesaplamaNedeni;
        }

        private void BtnPypEkle_Click(object sender, EventArgs e)
        {
            FrmPyp frmPyp = new FrmPyp();
            frmPyp.ShowDialog();
        }

        private void BtnIslemTuru_Click(object sender, EventArgs e)
        {
            comboAd = "ISLEM_TURU";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            comboAd = "ISLEM_TURU";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        string KontrolAK()
        {
            if (CmbProjeAK.Text == "")
            {
                return "Lütfen öncelikle PROJE bilgisini doldurunuz!";
            }
            if (CmbBolgeAdiAK.Text == "")
            {
                return "Lütfen öncelikle ÜS BÖLGESİ bilgisini doldurunuz!";
            }
            if (TxtBildirilenArizaAK.Text == "")
            {
                return "Lütfen öncelikle BİLDİRİLEN ARIZA bilgisini doldurunuz!";
            }
            if (TxtPersonelAK.Text == "")
            {
                return "Lütfen öncelikle BİRLİK PERSONELİNİN ADI SOYADI bilgisini doldurunuz!";
            }
            if (TxtGoreviAK.Text == "")
            {
                return "Lütfen öncelikle BİRLİK PERSONELİNİN GÖREVİ bilgisini doldurunuz!";
            }
            if (TxtRutbesiAK.Text == "")
            {
                return "Lütfen öncelikle BİRLİK PERSONELİNİN RÜTBESİ bilgisini doldurunuz!";
            }
            if (CmbBildirimKanaliAK.Text == "")
            {
                return "Lütfen öncelikle BİLDİRİM KANALI bilgisini doldurunuz!";
            }
            if (TxtTespitEdilenArizaAK.Text == "")
            {
                return "Lütfen öncelikle TESPİT EDİLEN ARIZA bilgisini doldurunuz!";
            }
            if (CmbGarantiDurumuAK.Text == "")
            {
                return "Lütfen öncelikle GARANTİ DURUMU bilgisini doldurunuz!";
            }
            if (TxtArizaBildirenAK.Text == "")
            {
                return "Lütfen öncelikle ARIZAYI BİLDİREN ADI SOYADI bilgisini doldurunuz!";
            }
            if (TxtABRutbesiAK.Text == "")
            {
                return "Lütfen öncelikle ARIZAYI BİLDİRENİN RÜTBESİ bilgisini doldurunuz!";
            }
            if (TxtABGoreviAK.Text == "")
            {
                return "Lütfen öncelikle ARIZAYI BİLDİRENİN GÖREVİ bilgisini doldurunuz!";
            }
            if (CmbGarantiDurumuAK.Text == "DIŞI")
            {
                if (TxtLojSorAK.Text == "")
                {
                    return "Lütfen öncelikle LOJİSTİK SORUMLUSU ADI SOYADI bilgisini doldurunuz!";
                }
                if (TxtLJRutbesiAK.Text == "")
                {
                    return "Lütfen öncelikle LOJİSTİK SORUMLUSU RÜTBESİ bilgisini doldurunuz!";
                }
                if (TxtLJGoreviAK.Text == "")
                {
                    return "Lütfen öncelikle LOJİSTİK SORUMLUSU GÖREVİ bilgisini doldurunuz!";
                }
            }
            if (CmbParcaTanimiAK.Text == "")
            {
                return "Lütfen öncelikle MALZEME ÜST TAKIM TANIM bilgisini doldurunuz!";
            }
            if (TxtSeriNoAK.Text == "")
            {
                return "Lütfen öncelikle MALZEME ÜST TAKIM SERİ NO bilgisini doldurunuz!";
            }
            if (CmbKategoriAK.Text == "")
            {
                return "Lütfen öncelikle MALZEME ÜST TAKIM KATEGORİ bilgisini doldurunuz!";
            }
            if (CmbBildirimTuruAK.Text == "")
            {
                return "Lütfen öncelikle BİLDİRİM TÜRÜ bilgisini doldurunuz!";
            }
            if (CmbPypNoAK.Text == "")
            {
                return "Lütfen öncelikle PYP NO bilgisini doldurunuz!";
            }
            if (TxtSorumluPersonelAK.Text == "")
            {
                return "Lütfen öncelikle SORUMLU PERSONEL bilgisini doldurunuz!";
            }
            if (CmbSiparisTuruAK.Text == "")
            {
                return "Lütfen öncelikle SİPARİŞ TÜRÜ bilgisini doldurunuz!";
            }
            if (TxtIslemTuruAK.Text == "")
            {
                return "Lütfen öncelikle İŞLEM TÜRÜ bilgisini doldurunuz!";
            }
            if (TxtHesaplamaAK.Text == "")
            {
                return "Lütfen öncelikle HESAPLAMA bilgisini doldurunuz!";
            }
            if (DtgSokulen.RowCount == 0)
            {
                return "Lütfen öncelikle SÖKÜLEN MALZEMELER bilgisini doldurunuz!";
            }
            if (DtgTakilan.RowCount == 0)
            {
                return "Lütfen öncelikle TAKILAN MALZEMELER bilgisini doldurunuz!";
            }
            if (AdvPersonelAK.RowCount == 0)
            {
                return "Lütfen öncelikle İŞÇİLİK HARCAYAN PERSONELLER bilgisini doldurunuz!";
            }
            if (CmbAcmaOnayiVerenAK.Text == "")
            {
                return "Lütfen öncelikle ARIZA AÇMA ONAYI VEREN SORUMLU PERSONEL bilgisini doldurunuz!";
            }
            if (TxtCSSiparisNoAK.Text == "")
            {
                return "Lütfen öncelikle CS SİPARİŞ NO bilgisini doldurunuz!";
            }
            if (TxtBildirimNoAK.Text == "")
            {
                return "Lütfen öncelikle BİLDİRİM NO bilgisini doldurunuz!";
            }
            if (TxtCRMNoAK.Text == "")
            {
                return "Lütfen öncelikle CRM NO bilgisini doldurunuz!";
            }
            if (TxtEkipmanNoAK.Text == "")
            {
                return "Lütfen öncelikle EKİPMAN NO bilgisini doldurunuz!";
            }
            if (TxtOnarimNotuAK.Text == "")
            {
                return "Lütfen öncelikle ARIZAYA YAPILAN İŞLEM ONARIM NOTU bilgisini doldurunuz!";
            }
            if (CmbTeslimEdenAK.Text == "")
            {
                return "Lütfen öncelikle TESLİM EDEN PERSONEL bilgisini doldurunuz!";
            }
            if (CmbNesneTanimiAK.Text == "")
            {
                return "Lütfen öncelikle NESNE TANIMI bilgisini doldurunuz!";
            }
            if (CmbHasarKoduAK.Text == "")
            {
                return "Lütfen öncelikle HASAR KODU bilgisini doldurunuz!";
            }
            if (CmbNedenKoduAK.Text == "")
            {
                return "Lütfen öncelikle NEDEN KODU bilgisini doldurunuz!";
            }
            if (CmbSonucAK.Text == "")
            {
                return "Lütfen öncelikle SONUÇ bilgisini doldurunuz!";
            }
            return "OK";
        }

        private void BtnKaydetAK_Click(object sender, EventArgs e)
        {
            string messege = KontrolAK();
            if (messege != "OK")
            {
                MessageBox.Show(messege, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNo();
                IsAkisNoAK();
                siparisNo = Guid.NewGuid().ToString();

                abfForm = AbfFormNo();

                ArizaKayit arizaKayit = new ArizaKayit(LblIsAkisNoAK.Text.ConInt(), abfForm, proje, CmbBolgeAdiAK.Text, bolukKomutani, telefon, birlikAdresi, il, ilce, TxtBildirilenArizaAK.Text, TxtPersonelAK.Text, TxtRutbesiAK.Text, TxtGoreviAK.Text, TxtTelefonAK.Text, DateTime.Now, infos[1].ToString(), CmbBildirimKanaliAK.Text, TxtArizaAciklamaAK.Text, "", "ONARIMI TAMAMLANDI", dosyaYolu, siparisNo, "", "");

                string mesaj = arizaKayitManager.Add(arizaKayit);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MalzemeKaydetAK();

                DateTime lojTarih = new DateTime(TxtLJTarihAK.Value.Year, TxtLJTarihAK.Value.Month, TxtLJTarihAK.Value.Day, TxtLJSaatAK.Value.Hour, TxtLJSaatAK.Value.Minute, TxtLJSaatAK.Value.Second);

                mesaj = PersonelIscilikleriEkleAK();

                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (CmbGarantiDurumuAK.Text == "İÇİ")
                {
                    lojTarihi = "";
                }
                else
                {
                    lojTarihi = lojTarih.ToString();
                }

                ArizaKayit arizaKayit2 = new ArizaKayit(id, CmbGarantiDurumuAK.Text, TxtLojSorAK.Text, TxtLJRutbesiAK.Text, TxtLJGoreviAK.Text, lojTarihi, TxtTespitEdilenArizaAK.Text, CmbAcmaOnayiVerenAK.Text);

                string mesaj2 = arizaKayitManager.ArizaSiparisOlustur(arizaKayit2);
                if (mesaj2 != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //arizaKayitManager.IslemAdimiGuncelle(id, CmbIslemAdimi.Text, CmbGorevAtanacakPersonel.Text);

                SistemCihazBilgileriKayitAK();
                mesaj2 = CRMBilgileriKayitAK();
                if (mesaj2 != "OK")
                {
                    MessageBox.Show(mesaj2, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                mesaj2 = KapatmaKayitAK();
                if (mesaj2 != "OK")
                {
                    MessageBox.Show(mesaj2, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GorevAtamaAK();
                IsAkisNo();
                IsAkisNoAK();
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TemizleAK();

            }
        }
        void GorevAtamaAK()
        {
            //int guncellenecekId = 0;
            //List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
            //gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(id, "BAKIM ONARIM");

            //foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            //{
            //    if (item.IslemAdimi == LblMevcutIslemAdimi.Text)
            //    {
            //        guncellenecekId = item.Id;
            //    }
            //}

            //GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM", infos[1].ToString(), "100_ARIZANIN BİLDİRİLMESİ (MÜŞTERİ)", DateTime.Now, TxtBildirilenAriza.Text, "00:05:00".ConOnlyTime());
            //gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            //string sure = "0 Gün " + "0 Saat " + "0 Dakika";

            //GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "BAKIM ONARIM", "100_ARIZANIN BİLDİRİLMESİ (MÜŞTERİ)", sure, DateTime.Now.Date);
            //gorevAtamaPersonelManager.Update(gorevAtama);

            //GorevAtamaPersonel gorevAtamaPersonel4 = new GorevAtamaPersonel(id, "BAKIM ONARIM", infos[1].ToString(), "ONARIMI TAMAMLANDI", DateTime.Now, TxtOnarimNotuAK.Text, "00:05:00".ConOnlyTime());
            //gorevAtamaPersonelManager.Add(gorevAtamaPersonel4);

            //GorevAtamaPersonel gorevAtama5 = new GorevAtamaPersonel(id, "BAKIM ONARIM", "ONARIMI TAMAMLANDI", sure, DateTime.Now.Date);
            //gorevAtamaPersonelManager.Update(gorevAtama5);

        }
        string KapatmaKayitAK()
        {
            DateTime teslimTarihi = new DateTime(DtTamamlanmaTarihiAK.Value.Year, DtTamamlanmaTarihiAK.Value.Month, DtTamamlanmaTarihiAK.Value.Day, DtTamamlanmaSaatiAK.Value.Hour, DtTamamlanmaSaatiAK.Value.Minute, DtTamamlanmaSaatiAK.Value.Second);

            int eksikEvrak = 0;
            if (ChkEksikEvrakAK.Checked == true)
            {
                eksikEvrak = 1;
            }
            //ArizaKayit arizaKayit = new ArizaKayit(id, TxtOnarimNotuAK.Text, CmbTeslimEdenAK.Text, TxtTeslimAlan.Text, teslimTarihi, CmbNesneTanimiAK.Text, CmbHasarKoduAK.Text, CmbNedenKoduAK.Text, eksikEvrak);

            //string message = arizaKayitManager.KapatKayit(arizaKayit);
            //if (message != "OK")
            //{
            //    return message;
            //}
            //arizaKayitManager.AbfKapat(id);
            return "OK";
        }
        string CRMBilgileriKayitAK()
        {
            ArizaKayit arizaKayit = new ArizaKayit(id, TxtCSSiparisNoAK.Text, TxtBildirimNoAK.Text, TxtCRMNoAK.Text, DtMailGondermeTarihiAK.Text, TxtEkipmanNoAK.Text,"");
            string mesaj = arizaKayitManager.CrmNoTanimla(arizaKayit);
            if (mesaj != "OK")
            {
                return mesaj;
            }
            return "OK";
        }

        private void BtnMalzemeEkle_Click(object sender, EventArgs e)
        {
            FrmUstTakim frmUstTakimEkle = new FrmUstTakim();
            frmUstTakimEkle.ShowDialog();

            //FrmUstTakimEkle frmUstTakimEkle = new FrmUstTakimEkle();
            //frmUstTakimEkle.ShowDialog();
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
                    AbfMalzemeIslemKayit abfMalzemeIslemKayit = new AbfMalzemeIslemKayit(id, "ARA DEPO (İADE)", DateTime.Now, infos[1].ToString(), 0);
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

        void TemizleAK()
        {
            CmbProjeAK.SelectedIndex = -1; CmbBolgeAdiAK.SelectedIndex = -1; TxtBildirilenArizaAK.Clear(); TxtPersonelAK.Clear(); TxtRutbesiAK.Clear(); TxtGoreviAK.Clear(); CmbBildirimKanaliAK.Text = ""; TxtTelefonAK.Clear(); TxtArizaAciklamaAK.Clear(); TxtTespitEdilenArizaAK.Clear(); CmbGarantiDurumuAK.SelectedIndex = -1; TxtArizaBildirenAK.Clear(); TxtABRutbesiAK.Clear(); TxtABGoreviAK.Clear(); DtgABSaatAK.Text = "00:00";
            TxtLojSorAK.Clear(); TxtLJRutbesiAK.Clear(); TxtLJGoreviAK.Clear(); TxtLJSaatAK.Text = "00:00"; webBrowser4.Navigate(""); LblProjeAK.Text = "00";
            LblGarantiBasAK.Text = "00"; LblGarantiBitAK.Text = "00"; CmbParcaTanimiAK.SelectedIndex = -1; LblStokNoAK.Text = "00"; TxtSeriNoAK.Clear();
            CmbKategoriAK.SelectedIndex = -1; CmbIlgliFirmaAK.SelectedIndex = -1; CmbBildirimTuruAK.SelectedIndex = -1; CmbPypNoAK.SelectedIndex = -1;
            TxtSorumluPersonelAK.Clear(); CmbSiparisTuruAK.SelectedIndex = -1; TxtIslemTuruAK.Clear(); TxtHesaplamaAK.Clear(); CmbSokulenStokNo.Text = "";
            TxtSokulenSeriNo.Clear(); TxtSokulenMiktar.Clear(); CmbSokulenBirim.Text = ""; TxtCalismaSaatiSokulen.Clear(); TxtSokulenRevizyon.Clear();
            CmbCalismaDurumu.SelectedIndex = -1; CmbFizikselDurumu.SelectedIndex = -1; CmbYapilanIslem.SelectedIndex = -1; DtgSokulen.Rows.Clear();
            CmbStokNoTakilan.Text = ""; TxtTakilanSeriNo.Clear(); TxtTakilanMiktar.Clear(); CmbTakilanBirim.Text = ""; TxtTakilanCalismaSaati.Clear();
            TxtTakilanRevizyon.Clear(); DtgTakilan.Rows.Clear(); CmbTespitEdenPersonelAK.SelectedIndex = -1; DtgIscilikSuresiAK.Text = "00:00";
            AdvPersonelAK.Rows.Clear(); DtMudehaleSaatiAK.Text = "00:00"; CmbAcmaOnayiVerenAK.SelectedIndex = -1; TxtCSSiparisNoAK.Clear(); TxtBildirimNoAK.Clear();
            TxtCRMNoAK.Clear(); TxtEkipmanNoAK.Clear(); DtTamamlanmaSaatiAK.Text = "00:00"; TxtOnarimNotuAK.Clear(); CmbTeslimEdenAK.SelectedIndex = -1;
            TxtTeslimEdenSicilAK.Clear(); CmbNesneTanimiAK.SelectedIndex = -1; CmbHasarKoduAK.SelectedIndex = -1; CmbNedenKoduAK.SelectedIndex = -1;
            CmbSonucAK.Text = ""; ChkEksikEvrakAK.Checked = false;

        }

        private void AdvPersonelAK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                AdvPersonelAK.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void BtnDosyaEkleAK_Click(object sender, EventArgs e)
        {
            IsAkisNoAK();
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\BAKIM ONARIM\ARIZA\";

            isAkisNo = LblIsAkisNoAK.Text;

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
                webBrowser4.Navigate(dosyaYolu);
                dosyaKontrol = true;

            }
        }

        private void CmbBolgeAdiAK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            string bolgeAdi = CmbBolgeAdiAK.Text;
            Bolge bolge = bolgeManager.Get(bolgeAdi);

            proje = bolge.Proje;
            bolukKomutani = bolge.IlgiliPersonel;
            telefon = bolge.Telefon;
            birlikAdresi = bolge.BirlikAdresi;
            il = bolge.Il;
            ilce = bolge.Ilce;

            if (bolge == null)
            {
                LblProjeAK.Text = "";
                LblGarantiBasAK.Text = "";
                LblGarantiBitAK.Text = "";
            }
            else
            {
                LblProjeAK.Text = bolge.Proje;
                LblGarantiBasAK.Text = bolge.GarantiBaslama;
                LblGarantiBitAK.Text = bolge.GarantiBitis;
            }
            if (LblGarantiBitAK.Text.ConDate() < DateTime.Now)
            {
                LblGarantiBitAK.BackColor = Color.Red;
            }
            else
            {
                LblGarantiBitAK.BackColor = Color.WhiteSmoke;
            }
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

            if (TxtBildirilenAriza.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle gerekli tüm bilgileri doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNo();
                IsAkisNoAK();

                siparisNo = Guid.NewGuid().ToString();

                abfForm = AbfFormNo();

                ArizaKayit arizaKayit = new ArizaKayit(LblIsAkisNo.Text.ConInt(), abfForm, proje, CmbBolgeAdi.Text, LblBolukKomutanı.Text, LblTelefon.Text, LblBirlilkAdresi.Text, LblIl.Text, LblIlce.Text, TxtBildirilenAriza.Text, TxtBirlikPersoneli.Text, TxtBirlikPerRutbesi.Text, TxtBirlikPerGorevi.Text, TxtABTelefon.Text, DateTime.Now, LblArizaBildirimiAlan.Text, CmbBildirimKanali.Text, TxtArizaAciklama.Text, CmbGorevAtanacakPersonel.Text, LblIslemAdimi.Text, dosyaYolu, siparisNo,"","");

                string mesaj = arizaKayitManager.Add(arizaKayit);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GorevAtama();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAkisNo();
                IsAkisNoAK();
                Temizle();
                kayitKontrol = true;
            }
        }
        private bool SetExcelInfoArizaKayitOlustur()
        {
            try
            {
                string excelFilePath = Path.Combine(yol, "abf.xlsx");
                bool exists = File.Exists(excelFilePath);
                IXLWorkbook xLWorkbook = new XLWorkbook(excelFilePath, XLEventTracking.Disabled);
                IXLWorksheet worksheet = xLWorkbook.Worksheet("Sayfa1");

                var range = worksheet.RangeUsed();
                worksheet.Cell("AA9").Value = CmbPypNo.Text; // PYP NO
                worksheet.Cell("AI9").Value = TxtSorumluPersonel.Text; // SORUMLU PERSONEL
                worksheet.Cell("AO9").Value = DtgMailGeldigiTarih.Value.ToString("dd.MM.yyyy"); // ARIZA BİLDİRİM TARİHİ
                worksheet.Cell("AU9").Value = TxtSiparisTuru.Text; // SİPARİŞ TÜRÜ
                worksheet.Cell("AY9").Value = CmbIslem.Text; // İŞLEM TÜRÜ
                worksheet.Cell("AZ9").Value = TxtHesaplama.Text; // HESAPLAMA NEDENİ
            
                worksheet.Cell("I13").Value = sorumluPersonel; // SORUMLU PERSONEL
                worksheet.Cell("S13").Value = bolgeBirlikAdresi + " " + bolgeIl + "/" + bolgeIlce; // BİRLİK ADRESİ
                worksheet.Cell("AJ13").Value = faturaAdresi; // FATURA ADRESİ
                worksheet.Cell("AY13").Value = bolgeTelefon; // BÖLGE TELEFON
          
                worksheet.Cell("N18").Value = LbStokNo.Text; // STOK NO
                worksheet.Cell("Y18").Value = CmbParcaNo.Text; // TANIM
                worksheet.Cell("AQ18").Value = TxtSeriNo.Text; // SERİ NO
                worksheet.Cell("AY18").Value = ""; // REVİZYON
                worksheet.Cell("I22").Value = DateTime.Now.ToString("dd.MM.yyyy"); // BİLDİRİM TARİHİ
                worksheet.Cell("I30").Value = TxtBildirilenArizaSiparis.Text; // BİLDİRİLEN ARIZA
                worksheet.Cell("I42").Value = LblTespit.Text; // BULUNAN ARIZALAR

                int sayac = 0;
                foreach (DataGridViewRow item in DtgMalzemeList.Rows)
                {
                    sayac++;
                    worksheet.Cell("I5" + sayac.ToString()).Value = item.Cells["SokulenStokNo"].Value.ToString();
                    worksheet.Cell("AO5" + sayac.ToString()).Value = item.Cells["SokulenSeriNo"].Value.ToString();
                    worksheet.Cell("U5" + sayac.ToString()).Value = item.Cells["SokulenMiktar"].Value.ToString();
                    if (sayac == 8)
                    {
                        break;
                    }
                }

                if (dosyaYolu != "")
                {
                    xLWorkbook.SaveAs(dosyaYolu + "\\" + isAkisNo + " " + LblBolgeAdi.Text + " " + abfNo + ".xlsx");
                    xLWorkbook.Dispose(); // workbook nesnesini temizler
                }
                else
                {
                    CreateFile();
                    xLWorkbook.SaveAs(dosyaYolu + "\\" + isAkisNo + " " + LblBolgeAdi.Text + " " + abfNo + ".xlsx");
                }
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
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        void CreateFile()
        {
            IsAkisNoSiparisOlustur();
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

        void GorevAtama()
        {
            

            ArizaKayit arizaKayit = arizaKayitManager.Get(abfForm);
            id = arizaKayit.Id;

            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM", infos[1].ToString(), "100_ARIZANIN BİLDİRİLMESİ (MÜŞTERİ)", DateTime.Now, TxtBildirilenAriza.Text, "00:05:00".ConOnlyTime());
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            string sure = "0 Gün " + "0 Saat " + "0 Dakika";

            int guncellenecekId = 0;
            List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(id, "BAKIM ONARIM");

            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == "100_ARIZANIN BİLDİRİLMESİ (MÜŞTERİ)")
                {
                    guncellenecekId = item.Id;
                }
            }
            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(guncellenecekId, id, "BAKIM ONARIM", "100_ARIZANIN BİLDİRİLMESİ (MÜŞTERİ)", sure, DateTime.Now.Date, infos[1].ToString());
            gorevAtamaPersonelManager.Update(gorevAtama);

            GorevAtamaPersonel gorevAtamaPersonel4 = new GorevAtamaPersonel(id, "BAKIM ONARIM", CmbGorevAtanacakPersonel.Text, LblIslemAdimi.Text, DateTime.Now, "", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel4);
        }

        string GorevAtamaSiparisOlustur()
        {
            ArizaKayit arizaKayit = arizaKayitManager.Get(abf);
            id = arizaKayit.Id;

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

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(guncellenecekId, id, "BAKIM ONARIM", LblMevcutIslemAdimi.Text, sure, "00:05:00".ConOnlyTime(), infos[1].ToString());
            string kontrol2 = gorevAtamaPersonelManager.Update(gorevAtama, TxtIslemAdimiAciklama.Text);
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

            int guncellenecekId = 0;
            List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(id, "BAKIM ONARIM");

            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == LblCrmMevcutIslemAdimi.Text)
                {
                    guncellenecekId = item.Id;
                }
            }

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(guncellenecekId, id, "BAKIM ONARIM", LblCrmMevcutIslemAdimi.Text, sure, "00:05:00".ConOnlyTime(), infos[1].ToString());
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
            abfMalzemes = abfMalzemeManager.GetList(arizaId);
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
            DtgMalzemeBilgileriSokulenTakilan.Columns["TeminDurumu"].Visible = false;
            DtgMalzemeBilgileriSokulenTakilan.Columns["AbfNo"].Visible = false;
            DtgMalzemeBilgileriSokulenTakilan.Columns["AbTarihSaat"].Visible = false;
            DtgMalzemeBilgileriSokulenTakilan.Columns["TemineAtilamTarihi"].Visible = false;
            DtgMalzemeBilgileriSokulenTakilan.Columns["MalzemeDurumu"].Visible = false;
            DtgMalzemeBilgileriSokulenTakilan.Columns["MalzemeIslemAdimi"].Visible = false;
            DtgMalzemeBilgileriSokulenTakilan.Columns["SokulenTeslimDurum"].Visible = false;
            DtgMalzemeBilgileriSokulenTakilan.Columns["BolgeAdi"].Visible = false;
            DtgMalzemeBilgileriSokulenTakilan.Columns["BolgeSorumlusu"].Visible = false;

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
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetList(arizaId, "BAKIM ONARIM");
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
