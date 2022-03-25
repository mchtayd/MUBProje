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

        bool start = true, dosyaKontrol = false, kayitKontrol = false;
        public object[] infos;
        string isAkisNo, dosyaYolu = "", kaynakdosyaismi, alinandosya, proje, siparisNo, comboAd, personelGorevi, personelBolumu, sure;
        List<string> fileNames = new List<string>();
        List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
        int abfForm, id, abf, gun, saat, dakika;
        DateTime birOncekiTarih;


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
        void BildirimTuru()
        {
            CmbBildirimTuru.DataSource = comboManager.GetList("BILDIRIM TURU");
            CmbBildirimTuru.ValueMember = "Id";
            CmbBildirimTuru.DisplayMember = "Baslik";
            CmbBildirimTuru.SelectedValue = 0;
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
        void Malzemeler()
        {
            List<MalzemeKayit> malzemeKayits = new List<MalzemeKayit>();
            malzemeKayits = malzemeKayitManager.GetList();



            StokNo1.DataSource = islemAdimlariManager.GetList("BAKIM ONARIM");
            StokNo1.ValueMember = "Id";
            StokNo1.DisplayMember = "IslemaAdimi";
            StokNo1.SelectedValue = -1;
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
            
            abfMalzemes = abfMalzemeManager.GetList(id);
            DtgMalzemeList.Rows.Clear();
            /*foreach (AbfMalzeme item in abfMalzemes)
            {
                DtgMalzemeList.Rows.Add();

                DataGridViewComboBoxColumn colCombo = (DataGridViewComboBoxColumn)DtgMalzemeList.Columns["SokulenStokNo"];
                colCombo.DataSource = malzemeKayitList;
                colCombo.DataPropertyName = "StokNo";
                colCombo.ValueMember = "Id";
                colCombo.DisplayMember = "StokNo";

                int sonSatir = DtgMalzemeList.RowCount - 1;              
                DtgMalzemeList.Rows[sonSatir].Cells["SokulenStokNo"].Value = item.SokulenStokNo;
                //DtgMalzemeList.Rows[sonSatir].Cells["SokulenTanim"].Value = item.SokulenTanim;
                DtgMalzemeList.Rows[sonSatir].Cells["SokulenSeriNo"].Value = item.SokulenSeriNo;
                DtgMalzemeList.Rows[sonSatir].Cells["SokulenMiktar"].Value = item.SokulenMiktar;
                DtgMalzemeList.Rows[sonSatir].Cells["SokulenBirim"].Value = item.SokulenBirim;
                DtgMalzemeList.Rows[sonSatir].Cells["SokulenCalismaSaati"].Value = item.SokulenCalismaSaati;
                DtgMalzemeList.Rows[sonSatir].Cells["SokulenRevizyon"].Value = item.SokulenRevizyon;
                DtgMalzemeList.Rows[sonSatir].Cells["CalismaDurumu"].Value = item.CalismaDurumu;
                DtgMalzemeList.Rows[sonSatir].Cells["FizikselDurum"].Value = item.FizikselDurum;
                DtgMalzemeList.Rows[sonSatir].Cells["YapilacakIslem"].Value = item.YapilacakIslem;
                //DtgMalzemeList.Rows[sonSatir].Cells["TakilanStokNo"].Value = item.TakilanStokNo;
                //DtgMalzemeList.Rows[sonSatir].Cells["TakilanTanim"].Value = item.TakilanTanim;
                DtgMalzemeList.Rows[sonSatir].Cells["TakilanMiktar"].Value = item.TakilanMiktar;
                DtgMalzemeList.Rows[sonSatir].Cells["TakilanBirim"].Value = item.TakilanBirim;
                DtgMalzemeList.Rows[sonSatir].Cells["TakilanSeriNo"].Value = item.TakilanSeriNo;
                DtgMalzemeList.Rows[sonSatir].Cells["TakilanCalismaSaati"].Value = item.TakilanCalismaSaati;
                DtgMalzemeList.Rows[sonSatir].Cells["TakilanRevizyon"].Value = item.TakilanRevizyon;
            }*/

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
        void MalzemeTemizle()
        {
            StokNo1.Text = ""; StokNo2.Text = ""; StokNo3.Text = ""; StokNo4.Text = ""; StokNo5.Text = ""; StokNo6.Text = ""; StokNo7.Text = "";
            StokNo8.Text = ""; t1.Clear(); t2.Clear(); t3.Clear(); t4.Clear(); t5.Clear(); t6.Clear(); t7.Clear(); t8.Clear(); SokulenSeri1.Clear();
            SokulenSeri2.Clear(); SokulenSeri3.Clear(); SokulenSeri4.Clear(); SokulenSeri5.Clear(); SokulenSeri6.Clear(); SokulenSeri7.Clear();
            SokulenSeri8.Clear(); TakilanSeri1.Clear(); TakilanSeri2.Clear(); TakilanSeri3.Clear(); TakilanSeri4.Clear(); TakilanSeri5.Clear();
            TakilanSeri6.Clear(); TakilanSeri7.Clear(); TakilanSeri8.Clear(); TxtMiktar1.Clear(); TxtMiktar2.Clear(); TxtMiktar3.Clear();
            TxtMiktar4.Clear(); TxtMiktar5.Clear(); TxtMiktar6.Clear(); TxtMiktar7.Clear(); TxtMiktar8.Clear(); b1.Text = ""; b2.Text = "";
            b3.Text = ""; b4.Text = ""; b5.Text = ""; b6.Text = ""; b7.Text = ""; b8.Text = ""; Sayac1.Clear(); Sayac2.Clear(); Sayac3.Clear();
            Sayac4.Clear(); Sayac5.Clear(); Sayac6.Clear(); Sayac7.Clear(); Sayac8.Clear(); Revizyon1.Clear(); Revizyon2.Clear(); Revizyon3.Clear();
            Revizyon4.Clear(); Revizyon5.Clear(); Revizyon6.Clear(); Revizyon7.Clear(); Revizyon8.Clear(); YapilacakIslem1.SelectedIndex = -1;
            YapilacakIslem2.SelectedIndex = -1; YapilacakIslem3.SelectedIndex = -1; YapilacakIslem4.SelectedIndex = -1;
            YapilacakIslem4.SelectedIndex = -1; YapilacakIslem5.SelectedIndex = -1; YapilacakIslem6.SelectedIndex = -1;
            YapilacakIslem7.SelectedIndex = -1; YapilacakIslem8.SelectedIndex = -1;
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
                ArizaKayit arizaKayit = new ArizaKayit(id, TxtCsSiparisNo.Text, TxtBildirimNo.Text, TxtCrmNo.Text, DtgMailTarihi.Text);
                mesaj = arizaKayitManager.CrmNoTanimla(arizaKayit);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                CrmTemizle();
            }
        }
        void CrmTemizle()
        {
            TxtCrmFormNo.Clear(); DtgFormBilgileri.DataSource = null; TxtCsSiparisNo.Clear(); TxtBildirimNo.Clear(); TxtCrmNo.Clear();
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
            // stok no, tanım, seri no bilgisini alınız.


            LblMevcutIslemAdimi.Text = arizaKayit.IslemAdimi;
            abfForm = arizaKayit.AbfFormNo;
            id = arizaKayit.Id;
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
                mesaj = PersonelIscilikleriEkle();
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                DateTime lojTarih = new DateTime(DtLojistikTarih.Value.Year + DtLojistikTarih.Value.Month + DtLojistikTarih.Value.Day + DtLojistikSaat.Value.Hour, DtLojistikSaat.Value.Minute, DtLojistikSaat.Value.Second);

                ArizaKayit arizaKayit = new ArizaKayit(id, CmbGarantiDurumu.Text, TxtLojistikSorumlusu.Text, TxtLojistikSorRutbesi.Text, TxtLojistikSorGorevi.Text, lojTarih.ToString(), TxtTespitEdilenAriza.Text, CmbArizaAcmaOnayiVeren.Text);

                string mesaj2 = arizaKayitManager.ArizaSiparisOlustur(arizaKayit);
                if (mesaj2 != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SistemCihazBilgileriKayit();
                mesaj2 = GorevAtamaSiparisOlustur();
                
                if (mesaj2 != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
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

    }
}
