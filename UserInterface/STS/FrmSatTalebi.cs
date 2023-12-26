using Business;
using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity;
using Entity.AnaSayfa;
using Entity.BakimOnarim;
using Entity.IdariIsler;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ButceKodu = Entity.STS.ButceKodu;

namespace UserInterface.STS
{
    public partial class FrmSatTalebi : Form
    {
        public object[] infos;
        ButceKoduManager butceKoduManager;
        BolgeKayitManager bolgeKayitManager;
        ArizaKayitManager arizaKayitManager;
        PersonelKayitManager kayitManager;
        MalzemeTalepManager malzemeTalepManager;
        AbfMalzemeManager abfMalzemeManager;
        IsAkisNoManager isAkisNoManager;
        SatDataGridview1Manager satDataGridview1Manager;
        SatNoManager satNoManager;
        SatinAlinacakMalManager satinAlinacakMalManager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        BildirimYetkiManager bildirimYetkiManager;
        BolgeGarantiManager bolgeGarantiManager;
        ButceKoduKalemiManager butceKoduKalemiManager;
        ComboManager comboManager;
        SatTalebiDoldurManager satTalebiDoldurManager;

        List<ArizaKayit> arizaKayits;
        List<MalzemeTalep> malzemeTaleps;
        List<AbfMalzeme> abfMalzemes;
        List<AbfMalzeme> abfMalzemesSatinAlma;

        bool start = false;
        string dosyaYolu, kaynakdosyaismi, alinandosya, siparisNo, isleAdimi, mesaj;
        int satNo, comboId;
        public FrmSatTalebi()
        {
            InitializeComponent();
            butceKoduManager = ButceKoduManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            malzemeTalepManager = MalzemeTalepManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
            bolgeGarantiManager = BolgeGarantiManager.GetInstance();
            butceKoduKalemiManager = ButceKoduKalemiManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
        }

        private void FrmSatTalebi_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            ButceKoduKalemi2();
            BolgeBilgileri();
            TarihDonem();
            Personeller();
            MifMalzemeFill();
            ButceTanim();
            MaliyetTuru();
            ButceGiderTuru();
            start = true;
        }
        public void ButceGiderTuru()
        {
            CmbButceGiderTuru.DataSource = satDataGridview1Manager.ButceGiderTuruList();
            CmbButceGiderTuru.Text = "";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatTalebi"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
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

        void Personeller()
        {
            CmbAdSoyad.DataSource = kayitManager.PersonelAdSoyad();
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Adsoyad";
            CmbAdSoyad.SelectedValue = -1;
        }
        void Temizle()
        {
            CmbButceKodu.SelectedIndex = -1; CmbFirma.SelectedIndex = -1; CmbHarcamaTuru.SelectedIndex = -1; TxtAciklama.Clear();
            CmbBolgeAdi.SelectedIndex = -1; CmbAdSoyad.SelectedIndex = -1;
            DtgMalzemeList.DataSource = null; DtgMalzemeList.ClearFilter();
            TxtTop.Text = DtgMalzemeList.RowCount.ToString();
            LblSiparisNo.Text = "00";
            LblMasrafYeriNo.Text = "00";
            LblMasrafYeri.Text = "00";
            LblUnvani.Text = "00";
            LblProje.Text = "00";
            LblBolgeProje.Text = "00";
            LblGarantiDurumu.Text = "00";
            LblGarantiDurumu.Text = "00";
            LblPdl.Text = "00";
            webBrowser1.Navigate("");
            TarihDonem();
            BildirimFromNo.DataSource = null;
            BildirimFromNo.Text = "";
            BtnTumuneSatOlustur.Visible = false;
            BtnDosyaEkle.Enabled = true;
            TxtAciklama.Enabled = true;
            CmbBolgeAdi.Enabled = true;
            BildirimFromNo.Enabled = true;
            CmbButceTanimi.SelectedIndex = -1;
            CmbMaliyetTuru.SelectedIndex = -1;
            CmbDonem.SelectedIndex = -1;
            CmbDonemYil.SelectedIndex= -1;
            CmbDonemT.SelectedIndex= -1;
            CmbDonemYilT.SelectedIndex= -1;

        }
        private void CmbFaturaFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (CmbFaturaFirma.Text == "BAŞARAN İLERİ TEKNOLOJİ")
            //{
            //    CmbButceKodu.DataSource = null;
            //    if (CmbButceKodu.Items.Count!=0)
            //    {
            //        CmbButceKodu.Items.Clear();
            //    }
            //    ButceKoduKalemi2();
            //    GrnBasaran.Visible = true;
            //    GrbAselsan.Visible = false;
            //    TxtAciklama.Enabled = true;
            //}
            //else
            //{
            //    if (CmbFaturaFirma.Text== "ASELSAN AŞ. UGES İÇ GÜV.PROG.MDL.")
            //    {
            //        CmbButceKodu.DataSource = null;
            //        CmbButceKodu.Items.Clear();
            //        CmbButceKodu.Items.Add("BM14/EKSTRA ALIMLAR");
            //    }
            //    else
            //    {
            //        CmbButceKodu.DataSource = null;
            //        CmbButceKodu.Items.Clear();
            //        CmbButceKodu.Items.Add("BM02/ACİL ONARIM MALZEME ALIMI");
            //        CmbButceKodu.Items.Add("BM14/EKSTRA ALIMLAR");
            //    }

            //    GrnBasaran.Visible = false;
            //    GrbAselsan.Visible = true;
            //    TxtAciklama.Enabled = false;
            //}

            //Temizle();
            int index = CmbFaturaFirma.SelectedIndex;
            CmbIlgiliKisi.SelectedIndex = index;
            CmbMasYeri.SelectedIndex = index;
        }

        public void ButceKoduKalemi2()
        {
            Entity.IdariIsler.ButceKodu butceKodu = butceKoduKalemiManager.ButceKoduComboBilgiList("SAT OLUŞTUR");
            comboId = butceKodu.Id;
            List<Entity.IdariIsler.ButceKodu> butceKodus = new List<Entity.IdariIsler.ButceKodu>();
            List<Entity.IdariIsler.ButceKodu> butceKodus2 = new List<Entity.IdariIsler.ButceKodu>();
            butceKodus = butceKoduKalemiManager.GetList();

            foreach (Entity.IdariIsler.ButceKodu item in butceKodus)
            {
                string[] comboIdler = item.ComboId.Split(';');
                if (comboIdler.Length == 0 || comboIdler.Length == 1)
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

        private void BtnButceKodu_Click(object sender, EventArgs e)
        {
            FrmButceKoduKalemi frmButceKoduKalemi = new FrmButceKoduKalemi();
            frmButceKoduKalemi.Show();
        }
        void BolgeBilgileri()
        {
            CmbBolgeAdi.DataSource = bolgeKayitManager.GetList();
            CmbBolgeAdi.ValueMember = "Id";
            CmbBolgeAdi.DisplayMember = "BolgeAdi";
            CmbBolgeAdi.SelectedValue = -1;
        }

        private void CmbBolgeAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (CmbBolgeAdi.SelectedIndex==-1)
            {
                BildirimFromNo.DataSource = null;
                BildirimFromNo.Text = "";
                return;
            }
            BolgeKayit bolgeKayit = bolgeKayitManager.Get(CmbBolgeAdi.SelectedValue.ConInt());
            if (bolgeKayit == null)
            {
                return;
            }
            
            else
            {
                DtgMalzemeList.DataSource = null;
                LblBolgeProje.Text = bolgeKayit.Proje;
                BolgeGaranti bolgeGaranti =  bolgeGarantiManager.Get(bolgeKayit.SiparisNo);
                if (bolgeGaranti!=null)
                {
                    LblPdl.Text = bolgeGaranti.GarantiPaketi;
                }
                else
                {
                    LblPdl.Text = bolgeKayit.Proje;
                }

                AbfFormNoList();
                //arizaKayits = arizaKayitManager.GetList(CmbBolgeAdi.Text);

                CmbAdSoyad.SelectedIndex = -1;
                LblBolgeProje.Text = "00";
                LblPdl.Text = "00";
                LblGarantiDurumu.Text = "00";

                
            }


            //FormNoFill();
        }
        void AbfFormNoList()
        {
            start = false;
            BildirimFromNo.DataSource = satTalebiDoldurManager.BolgeSatList(CmbBolgeAdi.Text);
            BildirimFromNo.ValueMember = "Id";
            BildirimFromNo.DisplayMember = "AbfNo";
            BildirimFromNo.SelectedValue = "";
            start = true;
        }

        void FormNoFill()
        {
            start = false;
            BildirimFromNo.DataSource = arizaKayits;
            BildirimFromNo.ValueMember = "Id";
            BildirimFromNo.DisplayMember = "AbfFormNo";
            BildirimFromNo.SelectedValue = -1;
            start = true;
        }

        private void BildirimFromNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (BildirimFromNo.Text=="")
            {
                return;
            }

            //ArizaKayit arizaKayit1 = arizaKayitManager.Get(BildirimFromNo.Text.ConInt());
            //satinAlinacakMalzemelers = satinAlinacakMalManager.GetListDTS(arizaKayit1.Id);


            #region GuncelKod
            
            ArizaKayit arizaKayit = arizaKayitManager.Get(BildirimFromNo.Text.ConInt());
            BolgeKayit bolgeKayit = bolgeKayitManager.Get(0, arizaKayit.BolgeAdi);
            if (arizaKayit == null)
            {
                LblPdl.Text = "";
                TxtAciklama.Text = "";
                return;
            }

            LblBolgeProje.Text = arizaKayit.Proje;
            LblPdl.Text = bolgeKayit.Proje;
            LblGarantiDurumu.Text = arizaKayit.GarantiDurumu;
            TxtAciklama.Text = arizaKayit.TespitEdilenAriza;

            //abfMalzemes = abfMalzemeManager.GetList(arizaKayit.Id, "SAT BEKLİYOR");

            abfMalzemes = abfMalzemeManager.GetList(arizaKayit.Id);
            AbfMalzemeFill();
            #endregion
        }
        void TarihDonem()
        {
            LblSatOlusturmaTarihi.Text = DateTime.Now.ToString("d");

            LblSatTarihi.Text = DateTime.Now.ToString("d");
        }

        private void CmbAdSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (CmbAdSoyad.SelectedIndex==-1)
            {
                LblSiparisNo.Text = "00";
                LblUnvani.Text = "00";
                LblMasrafYeriNo.Text = "00";
                LblMasrafYeri.Text = "00";
                LblProje.Text = "00";
            }
            DtgMalzemeList.DataSource = null;
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
            MifMalzemeFill();

            CmbBolgeAdi.SelectedIndex = -1;
            BildirimFromNo.DataSource = null;
            BildirimFromNo.Text = "";
            LblPdl.Text = "";
            LblBolgeProje.Text = "";
            LblGarantiDurumu.Text = "";
            LblSatOlusturmaTarihi.Text = "";
            CmbDonem.SelectedIndex = -1;
            CmbDonemYil.SelectedIndex = -1;
        }
        void MifMalzemeFill()
        {
            if (CmbAdSoyad.Text == "")
            {
                return;
            }


            malzemeTaleps = malzemeTalepManager.GetListSat(CmbAdSoyad.Text);
            dataBinder.DataSource = malzemeTaleps.ToDataTable();
            DtgMalzemeList.DataSource = dataBinder;

            DtgMalzemeList.Columns["Id"].Visible = false;
            DtgMalzemeList.Columns["MalzemeKategorisi"].HeaderText = "MALZEME KATEGORİSİ";
            DtgMalzemeList.Columns["TalepEdenPersonel"].Visible = false;
            DtgMalzemeList.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgMalzemeList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzemeList.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzemeList.Columns["TalebiOlusturan"].Visible = false;
            DtgMalzemeList.Columns["Bolum"].Visible = false;
            DtgMalzemeList.Columns["SatBilgisi"].Visible = false;
            DtgMalzemeList.Columns["MasrafYeri"].Visible = false;
            DtgMalzemeList.Columns["IslemDurumu"].Visible = false;
            DtgMalzemeList.Columns["RedGerekcesi"].Visible = false;
            DtgMalzemeList.Columns["ToplamMiktar"].Visible = false;
            DtgMalzemeList.Columns["DepoDurum"].Visible = false;
            DtgMalzemeList.Columns["Secim"].HeaderText = "SEÇİM";


            TxtTop.Text = DtgMalzemeList.RowCount.ToString();

            CmbBolgeAdi.SelectedIndex = -1;
            BildirimFromNo.SelectedIndex = -1;
        }
        void AbfMalzemeFill()
        {
            if (abfMalzemes.Count == 0)
            {
                return;
            }
            dataBinder.DataSource = abfMalzemes.ToDataTable();
            DtgMalzemeList.DataSource = dataBinder;

            DtgMalzemeList.Columns["Id"].Visible = false;
            DtgMalzemeList.Columns["BenzersizId"].Visible = false;
            DtgMalzemeList.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgMalzemeList.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgMalzemeList.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgMalzemeList.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgMalzemeList.Columns["SokulenCalismaSaati"].Visible = false;
            DtgMalzemeList.Columns["SokulenSeriNo"].Visible = false;
            DtgMalzemeList.Columns["AbfNo"].Visible = false;
            DtgMalzemeList.Columns["AbTarihSaat"].Visible = false;
            DtgMalzemeList.Columns["TemineAtilamTarihi"].Visible = false;
            DtgMalzemeList.Columns["MalzemeDurumu"].Visible = false;
            DtgMalzemeList.Columns["SokulenRevizyon"].Visible = false;
            DtgMalzemeList.Columns["CalismaDurumu"].Visible = false;
            DtgMalzemeList.Columns["FizikselDurum"].Visible = false;
            DtgMalzemeList.Columns["YapilacakIslem"].Visible = false;
            DtgMalzemeList.Columns["TakilanStokNo"].Visible = false;
            DtgMalzemeList.Columns["TakilanTanim"].Visible = false;
            DtgMalzemeList.Columns["TakilanSeriNo"].Visible = false;
            DtgMalzemeList.Columns["TakilanMiktar"].Visible = false;
            DtgMalzemeList.Columns["TakilanBirim"].Visible = false;
            DtgMalzemeList.Columns["TakilanCalismaSaati"].Visible = false;
            DtgMalzemeList.Columns["TakilanRevizyon"].Visible = false;
            DtgMalzemeList.Columns["TeminDurumu"].Visible = false;
            DtgMalzemeList.Columns["MalzemeIslemAdimi"].Visible = false;
            DtgMalzemeList.Columns["MalzemeDurumu"].Visible = false;
            DtgMalzemeList.Columns["TemineAtilamTarihi"].Visible = false;
            DtgMalzemeList.Columns["AbTarihSaat"].Visible = false;
            DtgMalzemeList.Columns["AbfNo"].Visible = false;
            DtgMalzemeList.Columns["SokulenTeslimDurum"].Visible = false;
            DtgMalzemeList.Columns["BolgeAdi"].Visible = false;
            DtgMalzemeList.Columns["BolgeSorumlusu"].Visible = false;
            DtgMalzemeList.Columns["YerineMalzemeTakilma"].Visible = false;
            DtgMalzemeList.Columns["DosyaYolu"].Visible = false;
            DtgMalzemeList.Columns["AltYukleniciKayit"].Visible = false;
            DtgMalzemeList.Columns["TakilanTeslimDurum"].Visible = false;
            DtgMalzemeList.Columns["Secim"].HeaderText = "SEÇİM";

            TxtTop.Text = DtgMalzemeList.RowCount.ToString();
        }

        private void DtgMalzemeList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgMalzemeList.FilterString;
            TxtTop.Text = DtgMalzemeList.RowCount.ToString();
        }

        private void DtgMalzemeList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgMalzemeList.SortString;
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            IsAkisNo();
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYolu = subdir + LblIsAkisNo.Text;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }

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
                webBrowser1.Navigate(dosyaYolu);
            }
        }

        private void BtnKontrol_Click(object sender, EventArgs e)
        {
            DtgMalzemeList.DataSource = null;
            BtnTumuneSatOlustur.Visible = true;
            BtnDosyaEkle.Enabled = false;
            TxtAciklama.Enabled = false;
            CmbBolgeAdi.Enabled = false;
            BildirimFromNo.Enabled = false;
            TeminSatinAlmaDisplay();

            CmbAdSoyad.SelectedIndex = -1;
            LblBolgeProje.Text = "00";
            LblPdl.Text = "00";
            LblGarantiDurumu.Text = "00";
            CmbBolgeAdi.SelectedIndex = -1;
            TxtAciklama.Clear();

        }
        void TeminSatinAlmaDisplay()
        {
            abfMalzemesSatinAlma = abfMalzemeManager.TeminGetList("SAT İŞLEMLERİNİ BEKLİYOR");
            dataBinder.DataSource = abfMalzemesSatinAlma.ToDataTable();
            DtgMalzemeList.DataSource = dataBinder;

            DtgMalzemeList.Columns["Id"].Visible = false;
            DtgMalzemeList.Columns["BenzersizId"].Visible = false;
            DtgMalzemeList.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgMalzemeList.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgMalzemeList.Columns["SokulenSeriNo"].Visible = false;
            DtgMalzemeList.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgMalzemeList.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgMalzemeList.Columns["SokulenCalismaSaati"].Visible = false;
            DtgMalzemeList.Columns["SokulenRevizyon"].Visible = false;
            DtgMalzemeList.Columns["CalismaDurumu"].Visible = false;
            DtgMalzemeList.Columns["FizikselDurum"].Visible = false;
            DtgMalzemeList.Columns["YapilacakIslem"].Visible = false;
            DtgMalzemeList.Columns["TakilanStokNo"].Visible = false;
            DtgMalzemeList.Columns["TakilanTanim"].Visible = false;
            DtgMalzemeList.Columns["TakilanSeriNo"].Visible = false;
            DtgMalzemeList.Columns["TakilanMiktar"].Visible = false;
            DtgMalzemeList.Columns["TakilanBirim"].Visible = false;
            DtgMalzemeList.Columns["TakilanCalismaSaati"].Visible = false;
            DtgMalzemeList.Columns["TakilanRevizyon"].Visible = false;
            DtgMalzemeList.Columns["TeminDurumu"].Visible = false;
            DtgMalzemeList.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgMalzemeList.Columns["AbTarihSaat"].Visible = false;
            DtgMalzemeList.Columns["TemineAtilamTarihi"].Visible = false;
            DtgMalzemeList.Columns["MalzemeDurumu"].Visible = false;
            DtgMalzemeList.Columns["MalzemeIslemAdimi"].Visible = false;
            DtgMalzemeList.Columns["SokulenTeslimDurum"].Visible = false;
            DtgMalzemeList.Columns["BolgeAdi"].Visible = false;
            DtgMalzemeList.Columns["BolgeSorumlusu"].Visible = false;

            TxtTop.Text = DtgMalzemeList.RowCount.ToString();

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        void OtoDosyaYoluOlustur()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";


            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + satNo;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
            
        }

        List<int> abfss = new List<int>();
        private void BtnTumuneSatOlustur_Click(object sender, EventArgs e)
        {
            if (DtgMalzemeList.RowCount==0)
            {
                MessageBox.Show("Sat oluşturmak için malzeme bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbButceKodu.Text=="")
            {
                MessageBox.Show("Lütfen öncelikle Bütçe Kodu seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbFirma.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Satın Alma Yapacak Birim seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbHarcamaTuru.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Harcama Türü seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                int sayac = 0;
                abfss = new List<int>();

                foreach (DataGridViewRow item in DtgMalzemeList.Rows)
                {
                    abfss.Add(item.Cells["AbfNo"].Value.ConInt());
                    abfss.Sort();
                    if (abfss.Count > 1)
                    {
                        if (abfss[sayac - 1].ConInt() == abfss[sayac].ConInt())
                        {
                            abfss.RemoveAt(sayac);
                        }
                        sayac++;
                    }
                }

                for (int i = 0; i < abfss.Count; i++)
                {
                    IsAkisNo();
                    siparisNo = Guid.NewGuid().ToString();
                    isleAdimi = "TEKLİF";
                    satNo = satNoManager.Add(new SatNo(siparisNo));

                    int abfNo = abfss[i];

                    ArizaKayit arizaKayit = arizaKayitManager.Get(abfNo);
                    string bolgeAdi = arizaKayit.BolgeAdi;
                    string aciklama = arizaKayit.TespitEdilenAriza;
                    string bolgeProje = arizaKayit.Proje;

                    OtoDosyaYoluOlustur();

                    string donem = CmbDonem.Text + " " + CmbDonemYil.Text;

                    SatDataGridview1 satDataGridview1 = new SatDataGridview1(satNo, LblIsAkisNo.Text.ConInt(), infos[4].ToString(), infos[1].ToString(),
                        infos[2].ToString(), bolgeAdi, abfNo.ToString(), LblSatOlusturmaTarihi.Text.ConDate(), aciklama, siparisNo, "", "", "", "", "",
                  string.IsNullOrEmpty(dosyaYolu) ? "" : dosyaYolu, infos[0].ConInt(), isleAdimi, donem, "ASELSAN", bolgeProje, "-", CmbButceTanimi.Text, CmbMaliyetTuru.Text, CmbButceGiderTuru.Text);

                    mesaj = satDataGridview1Manager.Add(satDataGridview1);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (DataGridViewRow item in DtgMalzemeList.Rows)
                    {
                        if (abfss[i].ConInt() == item.Cells["AbfNo"].Value.ConInt())
                        {
                            if (CmbFaturaFirma.Text == "BAŞARAN İLERİ TEKNOLOJİ")
                            {
                                if (item.Cells["Secim"].Value.ConBool() == true)
                                {
                                    SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(), item.Cells["SokulenBirim"].Value.ToString(), siparisNo);

                                    satinAlinacakMalManager.Add(satinAlinacakMalzeme, siparisNo);

                                    abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), isleAdimi);
                                }
                            }
                            else
                            {
                                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(), item.Cells["SokulenBirim"].Value.ToString(), siparisNo);

                                satinAlinacakMalManager.Add(satinAlinacakMalzeme, siparisNo);

                                abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), isleAdimi);
                            }
                            
                        }
                    }

                    SatDataGridview1 dataGridview1 = new SatDataGridview1(satNo, CmbButceKodu.Text, CmbFirma.Text, CmbHarcamaTuru.Text, CmbFaturaFirma.Text, CmbIlgiliKisi.Text, CmbMasYeri.Text, siparisNo, 1, string.IsNullOrEmpty(dosyaYolu) ? "" : dosyaYolu, isleAdimi);
                    mesaj = satDataGridview1Manager.Update(dataGridview1);

                    if (mesaj != " SAT Ön Onay İşlemi Başarıyla Tamamlandı.")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    satDataGridview1Manager.DurumGuncelleOnay(siparisNo);

                    SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, "SATIN ALMA TALEBİ OLUŞTURULDU.", infos[1].ToString(), DateTime.Now);
                    satIslemAdimlariManager.Add(satIslem);
                }

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                IsAkisNo();
                CmbFaturaFirma.SelectedIndex = -1;
            }


        }

        string SatControl()
        {
            if (CmbButceKodu.Text=="")
            {
                return "Lütfen Bütçe Kodu bilgisini doldurunuz!";
            }
            if (CmbFaturaFirma.Text=="")
            {
                return "Lütfen Fatura Edilecek Firma bilgisini doldurunuz!";
            }
            if (CmbFirma.Text == "")
            {
                return "Lütfen Satın Alma Yapacak Firma bilgisini doldurunuz!";
            }
            if (CmbHarcamaTuru.Text == "")
            {
                return "Lütfen Harcama Türü bilgisini doldurunuz!";
            }
            if (TxtAciklama.Text == "")
            {
                return "Lütfen Açıklama bilgisini doldurunuz!";
            }
            if (DtgMalzemeList.RowCount==0)
            {
                return "Lütfen Satın Alınacak Malzeme Listesini doldurunuz!";
            }
            if (CmbAdSoyad.Text!="")
            {
                bool cs = false;
                foreach (DataGridViewRow item in DtgMalzemeList.Rows)
                {
                    if (item.Cells["Secim"].Value.ConBool() == true)
                    {
                        cs = true;
                        break;
                    }
                    
                }
                if (cs== false)
                {
                    return "Lütfen bir malzeme seçiniz!";
                }
            }
            return "OK";
        }

        private void detayGörToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmButceKoduKalemi frmButceKoduKalemi = new FrmButceKoduKalemi();
            frmButceKoduKalemi.Show();
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

        private void CmbButceKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbButceKodu.Text == "BM25/PERSONEL MAAŞ GİDERLERİ")
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
        string DataControl()
        {
            if (BildirimFromNo.Text=="")
            {
                return "OK";
            }
            List<SatDataGridview1> satDataGridview1s = new List<SatDataGridview1>();
            satDataGridview1s = satDataGridview1Manager.List();
            foreach (SatDataGridview1 item in satDataGridview1s)
            {
                if (item.Abfformno == BildirimFromNo.Text)
                {
                    return "Bu bildirim için " + item.Formno + " iş akış numaralı satın alma zaten oluşturulmuştur!";
                }
            }
            return "OK";
        }

        private void BtnMaliyetEkle_Click(object sender, EventArgs e)
        {

        }

        SatDataGridview1 satDataGridview11 = null;

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            IsAkisNo();
            string control = SatControl();
            if (control!="OK")
            {
                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            control = DataControl();
            if (control != "OK")
            {
                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool malzemeKontrol = false;
            if (CmbAdSoyad.Text == "")
            {
                foreach (DataGridViewRow item in DtgMalzemeList.Rows)
                {
                    if (item.Cells["Secim"].Value.ConBool() == true)
                    {
                        malzemeKontrol = true;
                    }
                }
                if (malzemeKontrol==false)
                {
                    MessageBox.Show("Lütfen öncelikle tablodan bir malzeme seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
                

            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                
                siparisNo = Guid.NewGuid().ToString();
                isleAdimi = "TEKLİF";
                satNo = satNoManager.Add(new SatNo(siparisNo));

                if (CmbAdSoyad.Text == "")
                {
                    string donem = CmbDonem.Text + " " + CmbDonemYil.Text;
                    SatDataGridview1 satDataGridview1 = new SatDataGridview1(satNo, LblIsAkisNo.Text.ConInt(), infos[4].ToString(), infos[1].ToString(),
                        infos[2].ToString(), CmbBolgeAdi.Text, BildirimFromNo.Text, LblSatOlusturmaTarihi.Text.ConDate(), TxtAciklama.Text, siparisNo, CmbAdSoyad.Text, LblSiparisNo.Text, LblUnvani.Text, LblMasrafYeriNo.Text, LblMasrafYeri.Text,
                  string.IsNullOrEmpty(dosyaYolu) ? "" : dosyaYolu, infos[0].ConInt(), isleAdimi, donem, "ASELSAN", LblBolgeProje.Text, "-", CmbButceTanimi.Text, CmbMaliyetTuru.Text, CmbButceGiderTuru.Text);

                    mesaj = satDataGridview1Manager.Add(satDataGridview1);
                    if (mesaj!="OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    mesaj = AselsanSatMalzemeKayit();
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                else
                {
                    string donem = CmbDonemT.Text + " " + CmbDonemYilT.Text;
                    SatDataGridview1 satDataGridview1 = new SatDataGridview1(satNo, LblIsAkisNo.Text.ConInt(), infos[4].ToString(), infos[1].ToString(),
                        infos[2].ToString(), "YOK", "0", LblSatTarihi.Text.ConDate(), TxtAciklama.Text, siparisNo, CmbAdSoyad.Text, LblSiparisNo.Text, LblUnvani.Text, LblMasrafYeriNo.Text, LblMasrafYeri.Text,
                  string.IsNullOrEmpty(dosyaYolu) ? "" : dosyaYolu, infos[0].ConInt(), isleAdimi, donem, "BAŞARAN", "ASL-001/MUB", "-", CmbButceTanimi.Text, CmbMaliyetTuru.Text, CmbButceGiderTuru.Text);

                    mesaj = satDataGridview1Manager.Add(satDataGridview1);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    satDataGridview11 = satDataGridview1Manager.Get(LblIsAkisNo.Text);
                    if (satDataGridview11 != null)
                    {
                        foreach (DataGridViewRow item in DtgMalzemeList.Rows)
                        {
                            if (item.Cells["Secim"].Value.ConBool() == true)
                            {
                                malzemeTalepManager.Update(item.Cells[0].Value.ConInt(), "SAT OLUŞTURULDU, TEDARİK AŞAMASINDA", "" , satDataGridview11.Id);
                            }
                        }
                    }

                    mesaj = BasaranSatMalzemeKayit();
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //SatDataGridview1 satDataGridview11 = satDataGridview1Manager.Get(LblIsAkisNo.Text);
                    if (satDataGridview11 != null)
                    {
                        SatDataGridview1 satDataGridview11 = satDataGridview1Manager.SatGuncelleGet(siparisNo);
                        foreach (DataGridViewRow item in DtgMalzemeList.Rows)
                        {
                            if (item.Cells["Secim"].Value.ConBool() == true)
                            {
                                malzemeTalepManager.Update(item.Cells[0].Value.ConInt(), "SAT OLUŞTURULDU, TEDARİK AŞAMASINDA", "", satDataGridview11.Id);
                                satDataGridview1Manager.MifIdUpdate(item.Cells["Id"].Value.ConInt(), satDataGridview11.Id);
                            }

                        }
                    }
                    //satDataGridview1Manager.MifIdUpdate(satDataGridview11.Id,);
                }

                SatDataGridview1 dataGridview1 = new SatDataGridview1(satNo, CmbButceKodu.Text, CmbFirma.Text, CmbHarcamaTuru.Text, CmbFaturaFirma.Text, CmbIlgiliKisi.Text, CmbMasYeri.Text, siparisNo, 1, string.IsNullOrEmpty(dosyaYolu) ? "" : dosyaYolu, isleAdimi);
                mesaj = satDataGridview1Manager.Update(dataGridview1);

                if (mesaj != " SAT Ön Onay İşlemi Başarıyla Tamamlandı.")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                satDataGridview1Manager.DurumGuncelleOnay(siparisNo);



                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, "SATIN ALMA TALEBİ OLUŞTURULDU.", infos[1].ToString(), DateTime.Now);
                satIslemAdimlariManager.Add(satIslem);
                //string bildirim = BildirimKayit();
                //if (bildirim!="OK")
                //{
                //    MessageBox.Show(bildirim, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAkisNo();
                CmbFaturaFirma.SelectedIndex = -1;
                Temizle();

            }
        }
        string BildirimKayit()
        {
            string[] array = new string[8];

            array[0] = "Sat Talebi Kayıt"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = LblIsAkisNo.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "iş akış numaralı"; // Bildirim türü
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
        string AselsanSatMalzemeKayit()
        {
            string mesaj = "";

            foreach (DataGridViewRow item in DtgMalzemeList.Rows)
            {
                if (item.Cells["Secim"].Value.ConBool()==true)
                {
                    SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(), item.Cells["SokulenBirim"].Value.ToString(), siparisNo);

                    mesaj = satinAlinacakMalManager.Add(satinAlinacakMalzeme, siparisNo);


                    if (mesaj != "OK")
                    {
                        return mesaj;
                    }
                }
            }

            return "OK";
        }
        string AselsanSatMalzemeOtoKayit()
        {
            int sayac = 0;
            foreach (DataGridViewRow item in DtgMalzemeList.Rows)
            {
                SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(), item.Cells["SokulenBirim"].Value.ToString(), siparisNo);

                satinAlinacakMalManager.Add(satinAlinacakMalzeme, siparisNo);
                sayac++;
            }

            return "OK";
        }

        string BasaranSatMalzemeKayit()
        {
            //bool kontrol = false;
            //foreach (DataGridViewRow item in DtgMalzemeList.Rows)
            //{
            //    if (item.Cells["Secim"].Value.ConBool() == true)
            //    {
            //        kontrol = true;
            //    }
            //if (kontrol== false)
            //{
            //    return "Lütfen istenilen malzeme listesinden, sat oluşturmak istediğiniz malzemeyi seçiniz!";
            //}
            //}
            string mesaj = "";
            foreach (DataGridViewRow item in DtgMalzemeList.Rows)
            {
                if (item.Cells["Secim"].Value.ConBool()==true)
                {
                    SatinAlinacakMalzemeler satinAlinacakMalzeme = new SatinAlinacakMalzemeler(item.Cells["StokNo"].Value.ToString(), item.Cells["Tanim"].Value.ToString(), item.Cells["Miktar"].Value.ConInt(), item.Cells["Birim"].Value.ToString(), siparisNo);

                    mesaj = satinAlinacakMalManager.Add(satinAlinacakMalzeme, siparisNo);

                    if (mesaj != "OK")
                    {
                        return mesaj;
                    }

                    //satDataGridview1Manager.MifIdUpdate(satDataGridview11.Id, item.Cells["Id"].Value.ConInt());
                }
            }

            return "OK";
        }
    }
}
