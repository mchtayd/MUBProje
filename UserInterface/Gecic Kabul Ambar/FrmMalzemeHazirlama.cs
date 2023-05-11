using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarim;
using Entity.Depo;
using Entity.Gecic_Kabul_Ambar;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmMalzemeHazirlama : Form
    {
        ArizaKayitManager arizaKayitManager;
        AbfMalzemeManager abfMalzemeManager;
        DepoMiktarManager depoMiktarManager;
        MalzemeManager malzemeManager;
        SatDataGridview1Manager satDataGridview1Manager;
        StokGirisCikisManager stokGirisCikisManager;
        FiyatTeklifiAlManager fiyatTeklifiAlManager;
        DepoKayitManagercs depoKayitManagercs;
        DepoKayitLokasyonManager depoKayitLokasyonManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        MalzemeKayitManager malzemeKayitManager;

        List<ArizaKayit> arizaKayits;
        List<AbfMalzeme> abfMalzemes;
        List<AbfMalzeme> abfMalzemesSatinAlma;
        List<AbfMalzeme> abfMalzemesAselsan;
        List<DepoMiktar> depoMiktars;
        List<DepoMiktar> depoMiktarsTotal;
        int id, mlzId, abfNo, mevcutMiktar, miktar, malzemeId;
        public object[] infos;
        public string seciliStok, aciklama = "";
        string stokNo, malzemeDurumu, seriNo, revizyon, tanim, birim, lotNo;
        bool start, miktarKontrol = false;
        public FrmMalzemeHazirlama()
        {
            InitializeComponent();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            depoMiktarManager = DepoMiktarManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
            fiyatTeklifiAlManager = FiyatTeklifiAlManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
            depoKayitLokasyonManager = DepoKayitLokasyonManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
        }

        private void FrmMalzemeHazirlama_Load(object sender, EventArgs e)
        {
            Yenile();
            start = true;
        }
        public void Yenile()
        {
            ArizaKayitlari();
            TeminSatinAlmaDisplay();
            TeminAselsanDisplay();
            CmbDepo();
        }

        public void CmbDepo()
        {
            List<DepoKayit> depoKayits = new List<DepoKayit>();
            depoKayits = depoKayitManagercs.GetList();

            CmbDepoNo.DataSource = depoKayits;
            CmbDepoNo.ValueMember = "Id";
            CmbDepoNo.DisplayMember = "Depo";
            CmbDepoNo.SelectedValue = -1;

            CmbDepoNoAselsan.DataSource = depoKayits;
            CmbDepoNoAselsan.ValueMember = "Id";
            CmbDepoNoAselsan.DisplayMember = "Depo";
            CmbDepoNoAselsan.SelectedValue = -1;
        }

        void TeminSatinAlmaDisplay()
        {
            abfMalzemesSatinAlma = abfMalzemeManager.TeminGetList("SAT İŞLEMLERİNİ BEKLİYOR");
            dataBinder3.DataSource = abfMalzemesSatinAlma.ToDataTable();
            DtgStoktaOlmayanSat.DataSource = dataBinder3;

            DtgStoktaOlmayanSat.Columns["Id"].Visible = false;
            DtgStoktaOlmayanSat.Columns["BenzersizId"].Visible = false;
            DtgStoktaOlmayanSat.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgStoktaOlmayanSat.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgStoktaOlmayanSat.Columns["SokulenSeriNo"].HeaderText = "SERİ/LOT NO";
            DtgStoktaOlmayanSat.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgStoktaOlmayanSat.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgStoktaOlmayanSat.Columns["SokulenCalismaSaati"].Visible = false;
            DtgStoktaOlmayanSat.Columns["SokulenRevizyon"].HeaderText = "REVİZYON";
            DtgStoktaOlmayanSat.Columns["CalismaDurumu"].Visible = false;
            DtgStoktaOlmayanSat.Columns["FizikselDurum"].Visible = false;
            DtgStoktaOlmayanSat.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgStoktaOlmayanSat.Columns["TakilanStokNo"].Visible = false;
            DtgStoktaOlmayanSat.Columns["TakilanTanim"].Visible = false;
            DtgStoktaOlmayanSat.Columns["TakilanSeriNo"].Visible = false;
            DtgStoktaOlmayanSat.Columns["TakilanMiktar"].Visible = false;
            DtgStoktaOlmayanSat.Columns["TakilanBirim"].Visible = false;
            DtgStoktaOlmayanSat.Columns["TakilanCalismaSaati"].Visible = false;
            DtgStoktaOlmayanSat.Columns["TakilanRevizyon"].Visible = false;
            DtgStoktaOlmayanSat.Columns["TeminDurumu"].Visible = false;
            DtgStoktaOlmayanSat.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgStoktaOlmayanSat.Columns["AbTarihSaat"].HeaderText = "TALEP TARİHİ";
            DtgStoktaOlmayanSat.Columns["TemineAtilamTarihi"].HeaderText = "TEMİNE ATILMA TARİHİ";
            DtgStoktaOlmayanSat.Columns["MalzemeDurumu"].Visible = false;
            DtgStoktaOlmayanSat.Columns["MalzemeIslemAdimi"].HeaderText = "İŞLEM DURUMU";
            DtgStoktaOlmayanSat.Columns["SokulenTeslimDurum"].Visible = false;
            DtgStoktaOlmayanSat.Columns["BolgeAdi"].Visible = false;
            DtgStoktaOlmayanSat.Columns["BolgeSorumlusu"].Visible = false;

            LblTop2.Text = DtgStoktaOlmayanSat.RowCount.ToString();

            DtgStoktaOlmayanSat.Columns["AbfNo"].DisplayIndex = 0;

        }
        void TeminAselsanDisplay()
        {
            abfMalzemesAselsan = abfMalzemeManager.TeminGetList("ASELSAN TEMİNİ BEKLİYOR");
            dataBinder4.DataSource = abfMalzemesAselsan.ToDataTable();
            DtgStoktaOlmayanAselsan.DataSource = dataBinder4;

            DtgStoktaOlmayanAselsan.Columns["Id"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["BenzersizId"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgStoktaOlmayanAselsan.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgStoktaOlmayanAselsan.Columns["SokulenSeriNo"].HeaderText = "SERİ/LOT NO";
            DtgStoktaOlmayanAselsan.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgStoktaOlmayanAselsan.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgStoktaOlmayanAselsan.Columns["SokulenCalismaSaati"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["SokulenRevizyon"].HeaderText = "REVİZYON";
            DtgStoktaOlmayanAselsan.Columns["CalismaDurumu"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["FizikselDurum"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgStoktaOlmayanAselsan.Columns["TakilanStokNo"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["TakilanTanim"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["TakilanSeriNo"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["TakilanMiktar"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["TakilanBirim"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["TakilanCalismaSaati"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["TakilanRevizyon"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["TeminDurumu"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgStoktaOlmayanAselsan.Columns["AbTarihSaat"].HeaderText = "TALEP TARİHİ";
            DtgStoktaOlmayanAselsan.Columns["TemineAtilamTarihi"].HeaderText = "TEMİNE ATILMA TARİHİ";
            DtgStoktaOlmayanAselsan.Columns["MalzemeDurumu"].HeaderText = "İŞLEM DURUMU";
            DtgStoktaOlmayanAselsan.Columns["MalzemeIslemAdimi"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["SokulenTeslimDurum"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["BolgeAdi"].Visible = false;
            DtgStoktaOlmayanAselsan.Columns["BolgeSorumlusu"].Visible = false;

            LblTop3.Text = DtgStoktaOlmayanAselsan.RowCount.ToString();

            DtgStoktaOlmayanAselsan.Columns["AbfNo"].DisplayIndex = 0;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageMalzemeHazirmala"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void ArizaKayitlari()
        {
            DtgArizaKayitlari.DataSource = null;
            arizaKayits = arizaKayitManager.MalzemeHazirlamaList();
            dataBinder.DataSource = arizaKayits.ToDataTable();
            DtgArizaKayitlari.DataSource = dataBinder;
            TxtTop.Text = DtgArizaKayitlari.RowCount.ToString();

            DtgArizaKayitlari.Columns["Id"].Visible = false;
            DtgArizaKayitlari.Columns["IsAkisNo"].Visible = false;
            DtgArizaKayitlari.Columns["AbfFormNo"].HeaderText = "FORM NO";
            DtgArizaKayitlari.Columns["Proje"].Visible = false;
            DtgArizaKayitlari.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgArizaKayitlari.Columns["BolukKomutani"].Visible = false;
            DtgArizaKayitlari.Columns["BirlikAdresi"].Visible = false;
            DtgArizaKayitlari.Columns["Il"].Visible = false;
            DtgArizaKayitlari.Columns["Ilce"].Visible = false;
            DtgArizaKayitlari.Columns["BildirilenAriza"].Visible = false;
            DtgArizaKayitlari.Columns["ArizaiBildirenPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["AbRutbesi"].Visible = false;
            DtgArizaKayitlari.Columns["AbGorevi"].Visible = false;
            DtgArizaKayitlari.Columns["AbTelefon"].Visible = false;
            DtgArizaKayitlari.Columns["AbTarihSaat"].HeaderText = "TALEP TARİHİ";
            DtgArizaKayitlari.Columns["ABAlanPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["BildirimKanali"].Visible = false;
            DtgArizaKayitlari.Columns["ArizaAciklama"].Visible = false;
            DtgArizaKayitlari.Columns["GorevAtanacakPersonel"].HeaderText = "İŞLEM ADIMI SORUMLUSU";
            DtgArizaKayitlari.Columns["IslemAdimi"].HeaderText = "MEVCUT İŞLEM ADIMI";
            DtgArizaKayitlari.Columns["DosyaYolu"].Visible = false;
            DtgArizaKayitlari.Columns["SiparisNo"].Visible = false;
            DtgArizaKayitlari.Columns["GarantiDurumu"].Visible = false;
            DtgArizaKayitlari.Columns["LojistikSorumluPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["LojRutbesi"].Visible = false;
            DtgArizaKayitlari.Columns["LojGorevi"].Visible = false;
            DtgArizaKayitlari.Columns["LojTarihi"].Visible = false;
            DtgArizaKayitlari.Columns["LojTarihi"].Visible = false;
            DtgArizaKayitlari.Columns["TespitEdilenAriza"].Visible = false;
            DtgArizaKayitlari.Columns["AcmaOnayiVeren"].HeaderText = "ARIZA AÇMA ONAYI VEREN";
            DtgArizaKayitlari.Columns["CsSiparisNo"].Visible = false;
            DtgArizaKayitlari.Columns["BildirimNo"].Visible = false;
            DtgArizaKayitlari.Columns["CrmNo"].Visible = false;
            DtgArizaKayitlari.Columns["SiparisNo"].Visible = false;
            DtgArizaKayitlari.Columns["TelefonNo"].Visible = false;
            DtgArizaKayitlari.Columns["StokNo"].Visible = false;
            DtgArizaKayitlari.Columns["Tanim"].Visible = false;
            DtgArizaKayitlari.Columns["SeriNo"].Visible = false;
            DtgArizaKayitlari.Columns["IlgiliFirma"].Visible = false;
            DtgArizaKayitlari.Columns["BildirimTuru"].Visible = false;
            DtgArizaKayitlari.Columns["PypNo"].Visible = false;
            DtgArizaKayitlari.Columns["SorumluPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["IslemTuru"].Visible = false;
            DtgArizaKayitlari.Columns["Hesaplama"].Visible = false;
            DtgArizaKayitlari.Columns["BildirimMailTarihi"].Visible = false;
            DtgArizaKayitlari.Columns["Kategori"].Visible = false;
            DtgArizaKayitlari.Columns["IlgiliFirma"].Visible = false;
            DtgArizaKayitlari.Columns["BildirimTuru"].Visible = false;
            DtgArizaKayitlari.Columns["PypNo"].Visible = false;
            DtgArizaKayitlari.Columns["SorumluPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["IslemTuru"].Visible = false;
            DtgArizaKayitlari.Columns["Hesaplama"].Visible = false;
            DtgArizaKayitlari.Columns["Durum"].Visible = false;
            DtgArizaKayitlari.Columns["OnarimNotu"].Visible = false;
            DtgArizaKayitlari.Columns["TeslimEdenPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["TeslimAlanPersonel"].Visible = false;
            DtgArizaKayitlari.Columns["TeslimTarihi"].Visible = false;
            DtgArizaKayitlari.Columns["NesneTanimi"].Visible = false;
            DtgArizaKayitlari.Columns["HasarKodu"].Visible = false;
            DtgArizaKayitlari.Columns["NedenKodu"].Visible = false;
            DtgArizaKayitlari.Columns["EksikEvrak"].Visible = false;
            DtgArizaKayitlari.Columns["EkipmanNo"].Visible = false;
            DtgArizaKayitlari.Columns["SiparisTuru"].Visible = false;
            DtgArizaKayitlari.Columns["MalzemeDurum"].HeaderText = "DEPO MALZEME DURUMU";
            DtgArizaKayitlari.Columns["GecenSure"].HeaderText = "GEÇEN SÜRE";
            DtgArizaKayitlari.Columns["OkfBildirimNo"].Visible = false;

            TxtTop2.Text = DtgArizaKayitlari.RowCount.ToString();
        }

        private void DtgArizaKayitlari_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgArizaKayitlari.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            id = DtgArizaKayitlari.CurrentRow.Cells["Id"].Value.ConInt();
            MalzemeListDisplay(id);

            DtgDepoBilgileri.DataSource = null;
            dataBinder2.DataSource = null;


        }

        private void CmbDepoNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            id = CmbDepoNo.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(id);
            LblDepoAdresi.Text = depoKayit.DepoAdi;

            TxtMalzemeYeri.DataSource = depoKayitLokasyonManager.GetListLokasyon(id);
            TxtMalzemeYeri.ValueMember = "Id";
            TxtMalzemeYeri.DisplayMember = "Lokasyon";
            TxtMalzemeYeri.SelectedValue = "";
        }

        void MalzemeListDisplay(int id)
        {
            MalzemeList.DataSource = null;
            abfMalzemes = abfMalzemeManager.GetList(id);
            if (abfMalzemes == null)
            {
                MessageBox.Show("Arızaya ait malzeme bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MalzemeList.DataSource = abfMalzemes;
            MalzemeList.Columns["Id"].Visible = false;
            MalzemeList.Columns["BenzersizId"].Visible = false;
            MalzemeList.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            MalzemeList.Columns["SokulenTanim"].HeaderText = "TANIM";
            MalzemeList.Columns["SokulenSeriNo"].HeaderText = "SERİ NO";
            MalzemeList.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            MalzemeList.Columns["SokulenBirim"].HeaderText = "BİRİM";
            MalzemeList.Columns["SokulenCalismaSaati"].Visible = false;
            MalzemeList.Columns["SokulenRevizyon"].HeaderText = "REVİZYON";
            MalzemeList.Columns["CalismaDurumu"].Visible = false;
            MalzemeList.Columns["FizikselDurum"].Visible = false;
            MalzemeList.Columns["YapilacakIslem"].HeaderText = "MALZEMEYE YAPILACAK İŞLEM";
            MalzemeList.Columns["TakilanStokNo"].Visible = false;
            MalzemeList.Columns["TakilanTanim"].Visible = false;
            MalzemeList.Columns["TakilanSeriNo"].Visible = false;
            MalzemeList.Columns["TakilanMiktar"].Visible = false;
            MalzemeList.Columns["TakilanBirim"].Visible = false;
            MalzemeList.Columns["TakilanCalismaSaati"].Visible = false;
            MalzemeList.Columns["TakilanRevizyon"].Visible = false;
            MalzemeList.Columns["TeminDurumu"].Visible = false;
            MalzemeList.Columns["AbfNo"].Visible = false;
            MalzemeList.Columns["AbTarihSaat"].Visible = false;
            MalzemeList.Columns["TemineAtilamTarihi"].Visible = false;
            MalzemeList.Columns["MalzemeDurumu"].Visible = false;
            MalzemeList.Columns["MalzemeIslemAdimi"].HeaderText = "TEMİN DURUMU";
            MalzemeList.Columns["SokulenTeslimDurum"].Visible = false;
            MalzemeList.Columns["BolgeAdi"].Visible = false;
            MalzemeList.Columns["BolgeSorumlusu"].Visible = false;


            TxtTop.Text = MalzemeList.RowCount.ToString();

        }

        void DepoMiktarDisplay()
        {
            DtgDepoBilgileri.Columns["Secim"].Visible = false;
            DtgDepoBilgileri.Columns["Id"].Visible = false;
            DtgDepoBilgileri.Columns["StokNo"].HeaderText = "STOK NO";
            DtgDepoBilgileri.Columns["Tanim"].HeaderText = "TANIM";
            DtgDepoBilgileri.Columns["SonIslemTarihi"].HeaderText = "SON İŞLEM TARİHİ";
            DtgDepoBilgileri.Columns["SonIslemYapan"].HeaderText = "SON İŞLEM YAPAN";
            DtgDepoBilgileri.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgDepoBilgileri.Columns["DepoNo"].HeaderText = "DEPO NO";
            DtgDepoBilgileri.Columns["DepoAdresi"].HeaderText = "DEPO ADRESİ";
            DtgDepoBilgileri.Columns["DepoLokasyon"].HeaderText = "DEPO LOKASYON";
            DtgDepoBilgileri.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgDepoBilgileri.Columns["LotNo"].HeaderText = "LOT NO";
            DtgDepoBilgileri.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgDepoBilgileri.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgDepoBilgileri.Columns["RezerveId"].HeaderText = "REZERVE KİMLİK";
            DtgDepoBilgileri.Columns["RezerveDurumu"].HeaderText = "REZERVE DURUM";

            TxtTop3.Text = DtgDepoBilgileri.RowCount.ToString();
            Toplamlar();
        }

        private void DtgArizaKayitlari_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgArizaKayitlari.FilterString;
            TxtTop2.Text = DtgArizaKayitlari.RowCount.ToString();
        }

        private void DtgArizaKayitlari_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgArizaKayitlari.SortString;
        }

        private void DtgDepoBilgileri_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Filter = DtgDepoBilgileri.FilterString;
            TxtTop3.Text = DtgDepoBilgileri.RowCount.ToString();
            Toplamlar();
        }

        private void DtgDepoBilgileri_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Sort = DtgDepoBilgileri.SortString;
        }
        string teminDurum, teminStokNo = "";
        int teminId = 0;

        private void DtgStoktaOlmayanSat_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder3.Filter = DtgStoktaOlmayanSat.FilterString;
            LblTop2.Text = DtgStoktaOlmayanSat.RowCount.ToString();
        }

        private void DtgStoktaOlmayanSat_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder3.Sort = DtgStoktaOlmayanSat.SortString;
        }

        private void DtgStoktaOlmayanAselsan_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder4.Filter = DtgStoktaOlmayanAselsan.FilterString;
            LblTop3.Text = DtgStoktaOlmayanAselsan.RowCount.ToString();
        }

        private void DtgStoktaOlmayanAselsan_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder4.Sort = DtgStoktaOlmayanAselsan.SortString;
        }

        private void DtgStoktaOlmayanAselsan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgStoktaOlmayanAselsan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            abfNo = DtgStoktaOlmayanAselsan.CurrentRow.Cells["AbfNo"].Value.ConInt();
            malzemeDurumu = DtgStoktaOlmayanAselsan.CurrentRow.Cells["MalzemeDurumu"].Value.ToString();
            stokNo = DtgStoktaOlmayanAselsan.CurrentRow.Cells["SokulenStokNo"].Value.ToString();
            malzemeId = DtgStoktaOlmayanAselsan.CurrentRow.Cells["Id"].Value.ConInt();
            seriNo = DtgStoktaOlmayanAselsan.CurrentRow.Cells["SokulenSeriNo"].Value.ToString();
            lotNo = DtgStoktaOlmayanAselsan.CurrentRow.Cells["SokulenSeriNo"].Value.ToString();
            revizyon = DtgStoktaOlmayanAselsan.CurrentRow.Cells["SokulenRevizyon"].Value.ToString();
            miktar = DtgStoktaOlmayanAselsan.CurrentRow.Cells["SokulenMiktar"].Value.ConInt();
            tanim = DtgStoktaOlmayanAselsan.CurrentRow.Cells["SokulenTanim"].Value.ToString();
            birim = DtgStoktaOlmayanAselsan.CurrentRow.Cells["SokulenBirim"].Value.ToString();

            //int benzersizId = DtgStoktaOlmayanAselsan.CurrentRow.Cells["BenzersizId"].Value.ConInt();
            //abfMalzemesStoklar = new List<AbfMalzeme>();
            //abfMalzemesStoklar = abfMalzemeManager.GetList(benzersizId, "SAT İŞLEMLERİ TAMAMLANDI");
        }

        private void BtnTeslimAlAselsan_Click(object sender, EventArgs e)
        {
            if (malzemeDurumu == "")
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbDepoNoAselsan.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle malzemenin girişi yapılacak olan Depo No bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CmbMalzemeYeriAselan.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle malzemenin girişi yapılacak olan Malzeme Yeri bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show(stokNo + " stok numaralı malzemeyi teslim almak istediğinize emim misinz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                abfMalzemeManager.TeminBilgisi(malzemeId, "TEDARİK EDİLDİ", infos[1].ToString(), "MALZEME HAZIR");

                DepoGirisAselsan();

                DialogResult dr2 = MessageBox.Show(stokNo + " stok numaralı malzemeye Barkod oluşturmak ister misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr2 == DialogResult.Yes)
                {
                    FrmDepoDusum frmDepoDusum = new FrmDepoDusum();
                    frmDepoDusum.ShowDialog();
                }

                MessageBox.Show("Malzemenin Depo Giriş İşlemleri otomatik yapılarak, stoklara alınmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                CmbDepoNo.SelectedIndex = -1;
                LblDepoAdresi.Text = "00";
                TxtMalzemeYeri.SelectedIndex = -1;
            }
        }

        private void CmbDepoNoAselsan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            id = CmbDepoNoAselsan.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(id);
            LblDepoAdresiAselsan.Text = depoKayit.DepoAdi;

            CmbMalzemeYeriAselan.DataSource = depoKayitLokasyonManager.GetListLokasyon(id);
            CmbMalzemeYeriAselan.ValueMember = "Id";
            CmbMalzemeYeriAselan.DisplayMember = "Lokasyon";
            CmbMalzemeYeriAselan.SelectedValue = "";
        }

        private void MalzemeList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (MalzemeList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            teminDurum = MalzemeList.CurrentRow.Cells["TeminDurumu"].Value.ToString();
            teminStokNo = MalzemeList.CurrentRow.Cells["SokulenStokNo"].Value.ToString();
            teminId = MalzemeList.CurrentRow.Cells["Id"].Value.ConInt();

        }

        void Toplamlar()
        {
            int toplam = 0;
            for (int i = 0; i < DtgDepoBilgileri.Rows.Count; ++i)
            {
                toplam += (DtgDepoBilgileri.Rows[i].Cells["Miktar"].Value).ConInt();

            }
            LblTop.Text = toplam.ToString();
        }


        private void BtnStokKontrol_Click(object sender, EventArgs e)
        {
            if (MalzemeList.RowCount == 0)
            {
                MessageBox.Show("Malzeme listesinde herhangi bir kayıt bulunmadığı için stoklar kontrol edilemiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            StokKontrol();
        }
        void StokKontrol()
        {
            DtgDepoBilgileri.DataSource = null;
            depoMiktarsTotal = new List<DepoMiktar>();
            foreach (AbfMalzeme item in abfMalzemes)
            {
                depoMiktars = depoMiktarManager.StokKontrol(item.SokulenStokNo);

                foreach (DepoMiktar item2 in depoMiktars)
                {
                    if (item.SokulenStokNo == item2.StokNo && item.TeminDurumu != "REZERVE EDİLDİ")
                    {
                        depoMiktarsTotal.Add(item2);
                    }
                }
            }
            dataBinder2.DataSource = depoMiktarsTotal.ToDataTable();
            DtgDepoBilgileri.DataSource = dataBinder2;
            DepoMiktarDisplay();
        }

        private void BtnTeslimAlSat_Click(object sender, EventArgs e)
        {
            if (malzemeDurumu == "")
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (malzemeDurumu != "SAT İŞLEMLERİ TAMAMLANDI")
            {
                MessageBox.Show("SAT işlemleri henüz tamamlanmadığı için Teslim Alma işlemini gerçekleştiremezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CmbDepoNo.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle malzemenin girişi yapılacak olan Depo No bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TxtMalzemeYeri.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle malzemenin girişi yapılacak olan Malzeme Yeri bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show(stokNo + " stok numaralı malzemeyi teslim almak istediğinize emim misinz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                abfMalzemeManager.TeminBilgisi(malzemeId, "TEDARİK EDİLDİ", infos[1].ToString(), "MALZEME HAZIR");

                string mesaj = satDataGridview1Manager.DepoTeslimAl(abfNo.ToString());
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DepoGiris();

                DialogResult dr2 = MessageBox.Show(stokNo + " stok numaralı malzemeye Barkod oluşturmak ister misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr2 == DialogResult.Yes)
                {
                    FrmDepoDusum frmDepoDusum = new FrmDepoDusum();
                    frmDepoDusum.ShowDialog();
                }

                MessageBox.Show("Malzemenin Depo Giriş İşlemleri otomatik yapılarak, stoklara alınmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                CmbDepoNo.SelectedIndex = -1;
                LblDepoAdresi.Text = "00";
                TxtMalzemeYeri.SelectedIndex = -1;
            }

        }
        void DepoGiris()
        {
            DepoMiktar depo = depoMiktarManager.Get(stokNo, "1150", seriNo, seriNo, revizyon);
            Malzeme malzemeKayit = malzemeManager.MalzemeBul(stokNo);
            if (depo == null)
            {
                mevcutMiktar = miktar;
                miktarKontrol = true;
            }
            else
            {
                mevcutMiktar = depo.Miktar;
            }

            mevcutMiktar = +miktar;
            if (malzemeKayit.TakipDurumu == "SERİ NO")
            {
                DepoMiktar depoMiktar = new DepoMiktar(stokNo, tanim, seriNo, "N/A", revizyon, DateTime.Now, infos[1].ToString(), CmbDepoNo.Text, LblDepoAdresi.Text, TxtMalzemeYeri.Text, mevcutMiktar, "SATIN ALINAN MALZEME DEPO STOKLARINA ALINMIŞTIR.");
                depoMiktarManager.Add(depoMiktar);
            }
            else
            {
                DepoMiktar depoMiktar = new DepoMiktar(stokNo, tanim, "N/A", seriNo, revizyon, DateTime.Now, infos[1].ToString(), CmbDepoNo.Text, LblDepoAdresi.Text, TxtMalzemeYeri.Text, mevcutMiktar, "SATIN ALINAN MALZEME DEPO STOKLARINA ALINMIŞTIR.");
                depoMiktarManager.Add(depoMiktar);
            }

            if (miktarKontrol == true)
            {
                mevcutMiktar = 0;
            }

            //if (takipdurumu != "LOT NO")
            //{
            //    mevcutMiktar = 0;
            //}


            miktarKontrol = false;

            if (malzemeKayit.TakipDurumu == "SERİ NO")
            {
                StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs("100-YENİ DEPO GİRİŞİ", stokNo, tanim, birim, DateTime.Now, "", "", "", CmbDepoNo.Text, LblDepoAdresi.Text, TxtMalzemeYeri.Text, miktar, "", "SATIN ALINAN MALZEME DEPO STOKLARINA ALINMIŞTIR.", seriNo, "N/A", revizyon);

                stokGirisCikisManager.Add(stokGirisCıkıs);
            }
            else
            {
                StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs("100-YENİ DEPO GİRİŞİ", stokNo, tanim, birim, DateTime.Now, "", "", "", CmbDepoNo.Text, LblDepoAdresi.Text, TxtMalzemeYeri.Text, miktar, "", "SATIN ALINAN MALZEME DEPO STOKLARINA ALINMIŞTIR.", "N/A", seriNo, revizyon);

                stokGirisCikisManager.Add(stokGirisCıkıs);
            }


            SatDataGridview1 satDataGridview1 = satDataGridview1Manager.DepoGetlist(abfNo.ToString());

            if (satDataGridview1 == null)
            {
                stokGirisCikisManager.DepoBirimFiyat(0, stokNo);
                return;
            }

            string siparisNo = satDataGridview1.SiparisNo;
            FiyatTeklifiAl fiyatTeklifiAl = fiyatTeklifiAlManager.Get(siparisNo, stokNo);
            double toplaTutar = fiyatTeklifiAl.Btf;
            stokGirisCikisManager.DepoBirimFiyat(toplaTutar, stokNo);

        }
        void DepoGirisAselsan()
        {
            DepoMiktar depo = depoMiktarManager.Get(stokNo, "1150", seriNo, seriNo, revizyon);
            Malzeme malzemeKayit = malzemeManager.MalzemeBul(stokNo);
            if (depo == null)
            {
                mevcutMiktar = miktar;
                miktarKontrol = true;
            }
            else
            {
                mevcutMiktar = depo.Miktar;
            }

            mevcutMiktar = +miktar;

            if (malzemeKayit.TakipDurumu == "SERİ NO")
            {
                DepoMiktar depoMiktar = new DepoMiktar(stokNo, tanim, seriNo, "N/A", revizyon, DateTime.Now, infos[1].ToString(), CmbDepoNoAselsan.Text, LblDepoAdresiAselsan.Text, CmbMalzemeYeriAselan.Text, mevcutMiktar, "ASELSAN DAN GELEN MALZEME DEPO STOKLARINA ALINMIŞTIR.");
                depoMiktarManager.Add(depoMiktar);
            }
            else
            {
                DepoMiktar depoMiktar = new DepoMiktar(stokNo, tanim, "N/A", seriNo, revizyon, DateTime.Now, infos[1].ToString(), CmbDepoNoAselsan.Text, LblDepoAdresiAselsan.Text, CmbMalzemeYeriAselan.Text, mevcutMiktar, "ASELSAN DAN GELEN MALZEME DEPO STOKLARINA ALINMIŞTIR.");
                depoMiktarManager.Add(depoMiktar);
            }


            if (miktarKontrol == true)
            {
                mevcutMiktar = 0;
            }

            //if (takipdurumu != "LOT NO")
            //{
            //    mevcutMiktar = 0;
            //}

            miktarKontrol = false;
            if (malzemeKayit.TakipDurumu == "SERİ NO")
            {
                StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs("100-YENİ DEPO GİRİŞİ", stokNo, tanim, birim, DateTime.Now, "", "", "", CmbDepoNoAselsan.Text, LblDepoAdresiAselsan.Text, CmbMalzemeYeriAselan.Text, miktar, "", "ASELSAN DAN GELEN MALZEME DEPO STOKLARINA ALINMIŞTIR.", seriNo, "N/A", revizyon);

                stokGirisCikisManager.Add(stokGirisCıkıs);
            }
            else
            {
                StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs("100-YENİ DEPO GİRİŞİ", stokNo, tanim, birim, DateTime.Now, "", "", "", CmbDepoNoAselsan.Text, LblDepoAdresiAselsan.Text, CmbMalzemeYeriAselan.Text, miktar, "", "ASELSAN DAN GELEN MALZEME DEPO STOKLARINA ALINMIŞTIR.", "N/A", seriNo, revizyon);

                stokGirisCikisManager.Add(stokGirisCıkıs);
            }

            stokGirisCikisManager.DepoBirimFiyat(0, stokNo);

        }

        private void BtnRezerve_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle bir arıza kaydı seçerek STOKLARI KONTROL ET butonuna basınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (mlzId == 0)
            {
                MessageBox.Show("Lütfen rezerve edeceğiniz malzemeyi seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DtgDepoBilgileri.RowCount == 0)
            {
                if (MalzemeList.RowCount != 0)
                {
                    MessageBox.Show("Aranan stok/stoklar depo kayıtlarında bulunamadı.\nİsterseniz Tedarik Et butonunu kullanarak Tedarik etme işlemi gerçekleştirebilirsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                else
                {
                    MessageBox.Show("Lütfen öncelikle bir arıza kaydı seçerek STOKLARI KONTROL ET butonuna basınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                //FrmMalzemeAciklama frmMalzemeAciklama = new FrmMalzemeAciklama();
                //aciklama = frmMalzemeAciklama.aciklama;
                //frmMalzemeAciklama.ShowDialog();
                aciklama = "MALZEME MEVCUT BİLDİRİME REZERVE EDİLMİŞTİR.";
                DepoMiktar depoMiktar = new DepoMiktar(mlzId, infos[1].ToString(), aciklama, id);
                string mesaj = depoMiktarManager.DepoRezerve(depoMiktar);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string rezerveEdilenStok = "";
                foreach (AbfMalzeme item in abfMalzemes)
                {
                    if (seciliStok == item.SokulenStokNo)
                    {
                        if (rezerveEdilenStok != item.SokulenStokNo)
                        {
                            Malzeme malzeme = malzemeManager.Get(item.SokulenStokNo);

                            if (malzeme!=null)
                            {
                                abfMalzemeManager.TeminBilgisi(item.Id, "REZERVE EDİLDİ", infos[1].ToString(), "DEPO REZERVE İŞLEMİ YAPILDI");
                                rezerveEdilenStok = item.SokulenStokNo;
                            }
                            
                        }
                    }
                }
                bool istenilenKontrol = false;
                abfMalzemes = abfMalzemeManager.GetList(id);
                foreach (AbfMalzeme item in abfMalzemes)
                {
                    if (item.TeminDurumu != "REZERVE EDİLDİ")
                    {
                        istenilenKontrol = true;
                        break;
                    }
                }

                if (istenilenKontrol == false)
                {
                    arizaKayitManager.ArizaMalzemeDurum(id, "MALZEME HAZIR");
                }
                else
                {
                    arizaKayitManager.ArizaMalzemeDurum(id, "TEMİN BEKLİYOR");
                }

                MessageBox.Show("Rezerve işlemi başarıyla gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                StokKontrol();
                MalzemeListDisplay(id);
                mlzId = 0;
                DtgDepoBilgileri.DataSource = null;
            }
        }
        List<AbfMalzeme> abfMalzemesStoklar;
        private void DtgStoktaOlmayanSat_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgStoktaOlmayanSat.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            abfNo = DtgStoktaOlmayanSat.CurrentRow.Cells["AbfNo"].Value.ConInt();
            malzemeDurumu = DtgStoktaOlmayanSat.CurrentRow.Cells["MalzemeDurumu"].Value.ToString();
            stokNo = DtgStoktaOlmayanSat.CurrentRow.Cells["SokulenStokNo"].Value.ToString();
            malzemeId = DtgStoktaOlmayanSat.CurrentRow.Cells["Id"].Value.ConInt();
            seriNo = DtgStoktaOlmayanSat.CurrentRow.Cells["SokulenSeriNo"].Value.ToString();
            revizyon = DtgStoktaOlmayanSat.CurrentRow.Cells["SokulenRevizyon"].Value.ToString();
            miktar = DtgStoktaOlmayanSat.CurrentRow.Cells["SokulenMiktar"].Value.ConInt();
            tanim = DtgStoktaOlmayanSat.CurrentRow.Cells["SokulenTanim"].Value.ToString();
            birim = DtgStoktaOlmayanSat.CurrentRow.Cells["SokulenBirim"].Value.ToString();
            int benzersizId = DtgStoktaOlmayanSat.CurrentRow.Cells["BenzersizId"].Value.ConInt();
            abfMalzemesStoklar = new List<AbfMalzeme>();
            abfMalzemesStoklar = abfMalzemeManager.GetList(benzersizId, "SAT İŞLEMLERİ TAMAMLANDI");
        }
        string secilenSeri, secilenLot = "";
        private void DtgDepoBilgileri_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgDepoBilgileri.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            mlzId = DtgDepoBilgileri.CurrentRow.Cells["Id"].Value.ConInt();
            seciliStok = DtgDepoBilgileri.CurrentRow.Cells["StokNo"].Value.ToString();
            secilenSeri = DtgDepoBilgileri.CurrentRow.Cells["SeriNo"].Value.ToString();
            secilenLot = DtgDepoBilgileri.CurrentRow.Cells["LotNo"].Value.ToString();
        }

        private void BtnTemin_Click(object sender, EventArgs e)
        {

            if (MalzemeList.RowCount == 0)
            {
                MessageBox.Show("Lütfen öncelikle arızayı seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle arızayı seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (teminId == 0)
            {
                MessageBox.Show("Lütfen Talep Edilen Malzeme Listesinden temin edeceğiniz malzemeyi seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (teminDurum == "ASELSAN TEMİNİ BEKLİYOR")
            {
                MessageBox.Show("Malzeme zaten Aselsan Temine İletilmiştir!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Malzeme malzeme = malzemeManager.Get(teminStokNo);
            if (malzeme == null)
            {
                MessageBox.Show("Malzeme bilgilerine ulaşılamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show(teminStokNo + " stok numaralı malzemeyi " + malzeme.TedarikTuru + " tedariğine atmak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }

            StokKontrol();
            //string rezerveEdilenStok = "";
            //foreach (AbfMalzeme item in abfMalzemes)
            //{
            //    foreach (var item2 in depoMiktarsTotal)
            //    {
            //        if (item.SokulenStokNo == item2.StokNo)
            //        {
            //            MessageBox.Show(item2.StokNo + " numaralı stok depo stoklarında mevcut! Rezerve ediliyor!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            DepoMiktar depoMiktar = new DepoMiktar(item2.Id, infos[1].ToString(), "OTOMATİK REZERVE EDİLDİ", id);
            //            depoMiktarManager.DepoRezerve(depoMiktar);
            //            if (rezerveEdilenStok != item.SokulenStokNo)
            //            {
            //                abfMalzemeManager.TeminBilgisi(item.Id, "REZERVE EDİLDİ", infos[1].ToString(), "DEPO REZERVE İŞLEMİ YAPILDI");
            //                rezerveEdilenStok = item.SokulenStokNo;
            //            }
            //        }
            //    }
            //}

            MalzemeListDisplay(id);
            StokKontrol();

            if (teminDurum != "REZERVE EDİLDİ")
            {
                if (teminDurum != "ARIZAYA GÖNDERİLDİ")
                {

                    if (malzeme == null)
                    {
                        abfMalzemeManager.TeminBilgisi(teminId, "ASELSAN TEMİNİ BEKLİYOR", infos[1].ToString(), "ASELSAN TEMİNİ BEKLİYOR");
                    }
                    else
                    {
                        if (malzeme.TedarikTuru == "ASELSAN TEMİNİ")
                        {
                            abfMalzemeManager.TeminBilgisi(teminId, "ASELSAN TEMİNİ BEKLİYOR", infos[1].ToString(), "ASELSAN TEMİNİ BEKLİYOR");
                        }
                        else
                        {
                            abfMalzemeManager.TeminBilgisi(teminId, "SAT BEKLİYOR", infos[1].ToString(), "SAT BEKLİYOR");
                        }
                    }
                }
            }

            //foreach (AbfMalzeme item in abfMalzemes)
            //{
            //    if (item.TeminDurumu != "REZERVE EDİLDİ" )
            //    {
            //        if (item.TeminDurumu != "ARIZAYA GÖNDERİLDİ")
            //        {
            //            Malzeme malzeme = malzemeManager.Get(item.SokulenStokNo);
            //            if (malzeme == null)
            //            {
            //                abfMalzemeManager.TeminBilgisi(item.Id, "ASELSAN TEMİNİ BEKLİYOR", infos[1].ToString(), "ASELSAN TEMİNİ BEKLİYOR");
            //            }
            //            else
            //            {
            //                if (malzeme.TedarikTuru == "ASELSAN TEMİNİ")
            //                {
            //                    abfMalzemeManager.TeminBilgisi(item.Id, "ASELSAN TEMİNİ BEKLİYOR", infos[1].ToString(), "ASELSAN TEMİNİ BEKLİYOR");
            //                }
            //                else
            //                {
            //                    abfMalzemeManager.TeminBilgisi(item.Id, "SAT BEKLİYOR", infos[1].ToString(), "SAT BEKLİYOR");
            //                }
            //            }
            //        }
            //    }
            //}

            bool istenilenKontrol = false;
            MalzemeListDisplay(id);
            foreach (AbfMalzeme item in abfMalzemes)
            {
                if (item.TeminDurumu != "REZERVE EDİLDİ")
                {
                    if (item.TeminDurumu != "ARIZAYA GÖNDERİLDİ")
                    {
                        istenilenKontrol = true;
                        break;
                    }
                }
            }

            if (istenilenKontrol == false)
            {
                arizaKayitManager.ArizaMalzemeDurum(id, "MALZEME HAZIR");
            }
            else
            {
                arizaKayitManager.ArizaMalzemeDurum(id, "TEMİN BEKLİYOR");
            }

            MessageBox.Show("Temin işlemi başarıyla gerçekleşmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            teminId = 0;
            Yenile();
            TxtTop.Text = "00";
            TxtTop3.Text = "00";
            LblTop.Text = "00";
        }

    }
}
