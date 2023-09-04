using Business;
using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity;
using Entity.AnaSayfa;
using Entity.BakimOnarim;
using Entity.BakimOnarimAtolye;
using Entity.Gecic_Kabul_Ambar;
using Entity.IdariIsler;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
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
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;

namespace UserInterface.BakımOnarım
{
    public partial class FrmBOAtolye : Form
    {
        AtolyeManager atolyeManager;
        AtolyeMalzemeManager atolyeMalzemeManager;
        IslemAdimlariManager islemAdimlariManager;
        PersonelKayitManager kayitManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        IscilikIscilikManager ıscilikIscilikManager;
        SiparisPersonelManager siparisPersonelManager;
        MalzemeKayitManager malzemeKayitManager;
        ComboManager comboManager;
        BildirimYetkiManager bildirimYetkiManager;
        AbfMalzemeManager abfMalzemeManager;
        AbfMalzemeIslemKayitManager abfMalzemeIslemKayitManager;
        ArizaKayitManager arizaKayitManager;
        MalzemeManager malzemeManager;


        List<AtolyeMalzeme> atolyeMalzemes;
        List<AbfMalzeme> abfMalzemes;

        List<string> IcSiparisler = new List<string>();
        List<string> SiparisNos = new List<string>();
        List<string> DosyaYollari = new List<string>();

        List<Malzeme> malzemes = new List<Malzeme>();
        List<Malzeme> malzemeKayits = new List<Malzeme>();
        List<Malzeme> malzemeKayitsFiltired = new List<Malzeme>();
        List<Malzeme> malzemeKayitsSecilenler = new List<Malzeme>();

        public object[] infos;
        int kayitId, id, oncekiId;
        string siparisNo = "", dosya, taslakYolu = "", comboAd, yerineMalzeme, abfNo = "";
        string kaynak = @"Z:\DTS\BAKIM ONARIM ATOLYE\Taslak\";
        string yol = @"C:\DTS\Taslak\";
        bool start = true;
        public FrmBOAtolye()
        {
            InitializeComponent();
            atolyeManager = AtolyeManager.GetInstance();
            atolyeMalzemeManager = AtolyeMalzemeManager.GetInstance();
            islemAdimlariManager = IslemAdimlariManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            ıscilikIscilikManager = IscilikIscilikManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            abfMalzemeIslemKayitManager = AbfMalzemeIslemKayitManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
        }

        private void FrmBOAtolye_Load(object sender, EventArgs e)
        {
            DataOtoKayit();
            IslemAdimlari();
            IslemAdimlariManuel();
            Personeller();
            PersonellerManuel();
            CmbStokNo();
            DataDisplayManuel();
            Kategori();
            ComboProje();
            IcSiparisNo();
            AtolyeKategoriOto();
            AtolyeKategorManuel();
            CmbIslemAdimi.Text = "400-GÖZ DENETİMİ (TEKNİK SERVİS)";
            CmbIslemAdimiManuel.Text = "400-GÖZ DENETİMİ (TEKNİK SERVİS)";
            start = false;
        }
        void Don()
        {
            start = true;
            DataOtoKayit();
            IslemAdimlari();
            IslemAdimlariManuel();
            Personeller();
            PersonellerManuel();
            CmbStokNo();
            DataDisplayManuel();
            Kategori();
            ComboProje();
            IcSiparisNo();
            AtolyeKategoriOto();
            AtolyeKategorManuel();
            start = false;
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageArizaAcmaAtolye"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        void DataOtoKayit()
        {
            abfMalzemes = new List<AbfMalzeme>();
            dataBinderOto.DataSource = null;

            abfMalzemes = abfMalzemeManager.DepoyaTeslimEdilecekMalzemeList("300 - ATÖLYEYE GİDECEK MALZEME");

            dataBinderOto.DataSource = abfMalzemes.ToDataTable();
            DtgList.DataSource = dataBinderOto;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["BenzersizId"].Visible = false;
            DtgList.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgList.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgList.Columns["SokulenSeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgList.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgList.Columns["SokulenCalismaSaati"].Visible = false;
            DtgList.Columns["SokulenRevizyon"].HeaderText = "REVİZYON";
            DtgList.Columns["CalismaDurumu"].Visible = false;
            DtgList.Columns["FizikselDurum"].Visible = false;
            DtgList.Columns["TakilanStokNo"].Visible = false;
            DtgList.Columns["TakilanTanim"].Visible = false;
            DtgList.Columns["TakilanSeriNo"].Visible = false;
            DtgList.Columns["TakilanMiktar"].Visible = false;
            DtgList.Columns["TakilanBirim"].Visible = false;
            DtgList.Columns["TakilanCalismaSaati"].Visible = false;
            DtgList.Columns["TakilanRevizyon"].Visible = false;
            DtgList.Columns["TeminDurumu"].Visible = false;
            DtgList.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgList.Columns["AbTarihSaat"].Visible = false;
            DtgList.Columns["TemineAtilamTarihi"].Visible = false;
            DtgList.Columns["MalzemeDurumu"].Visible = false;
            DtgList.Columns["MalzemeIslemAdimi"].Visible = false;
            DtgList.Columns["SokulenTeslimDurum"].HeaderText = "MALZEME TESLİM DURUMU";
            DtgList.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgList.Columns["BolgeSorumlusu"].HeaderText = "BÖLGE SORUMLUSU";
            DtgList.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgList.Columns["YerineMalzemeTakilma"].HeaderText = "YERİNE MALZEME TAKILDI MI?";
            DtgList.Columns["DosyaYolu"].Visible = false;

            DtgList.Columns["Secim"].DisplayIndex = 0;
            DtgList.Columns["SokulenTeslimDurum"].DisplayIndex = 1;
            DtgList.Columns["SokulenStokNo"].DisplayIndex = 2;
            DtgList.Columns["SokulenTanim"].DisplayIndex = 3;
            DtgList.Columns["SokulenSeriNo"].DisplayIndex = 4;
            DtgList.Columns["SokulenRevizyon"].DisplayIndex = 5;
            DtgList.Columns["SokulenMiktar"].DisplayIndex = 6;
            DtgList.Columns["SokulenBirim"].DisplayIndex = 7;
            DtgList.Columns["BolgeAdi"].DisplayIndex = 8;
            DtgList.Columns["AbfNo"].DisplayIndex = 9;
            DtgList.Columns["YapilacakIslem"].DisplayIndex = 10;
            DtgList.Columns["BolgeSorumlusu"].DisplayIndex = 11;

            LblToplam.Text = DtgList.RowCount.ToString();
        }

        void IcSiparisNo()
        {
            LblIcSiparisManuel.Text = "221RWK" + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("yy") + DateTime.Now.ToString("HH");
        }
        void ComboProje()
        {
            CmbProje.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProje.ValueMember = "Id";
            CmbProje.DisplayMember = "Baslik";
            CmbProje.SelectedValue = 0;
        }
        void CmbStokNo()
        {
            TxtTanimUs.DataSource = malzemeKayitManager.GetListMalzemeKayit();
            TxtTanimUs.ValueMember = "Id";
            TxtTanimUs.DisplayMember = "Tanim";
            TxtTanimUs.SelectedValue = 0;
        }
        void IslemAdimlari()
        {
            CmbIslemAdimi.DataSource = islemAdimlariManager.GetList("BAKIM ONARIM ATOLYE");
            CmbIslemAdimi.ValueMember = "Id";
            CmbIslemAdimi.DisplayMember = "IslemaAdimi";
            CmbIslemAdimi.SelectedValue = -1;
        }
        void IslemAdimlariManuel()
        {
            CmbIslemAdimiManuel.DataSource = islemAdimlariManager.GetList("BAKIM ONARIM ATOLYE");
            CmbIslemAdimiManuel.ValueMember = "Id";
            CmbIslemAdimiManuel.DisplayMember = "IslemaAdimi";
            CmbIslemAdimiManuel.SelectedValue = -1;
        }
        void Personeller()
        {
            List<PersonelKayit> personelKayits = new List<PersonelKayit>();
            List<PersonelKayit> personelKayits2 = new List<PersonelKayit>();
            personelKayits = kayitManager.PersonelBolumBazli("MUB Prj.Dir./Atölye");
            personelKayits2 = kayitManager.PersonelBolumBazli("MUB Prj.Dir./MGEO Van BO");
            foreach (PersonelKayit item in personelKayits2)
            {
                personelKayits.Add(item);
            }
            CmbGorevAtanacakPersonel.DataSource = personelKayits;
            CmbGorevAtanacakPersonel.ValueMember = "Id";
            CmbGorevAtanacakPersonel.DisplayMember = "Adsoyad";
            CmbGorevAtanacakPersonel.SelectedValue = -1;
        }

        void PersonellerManuel()
        {
            List<PersonelKayit> personelKayits = new List<PersonelKayit>();
            List<PersonelKayit> personelKayits2 = new List<PersonelKayit>();
            personelKayits = kayitManager.PersonelBolumBazli("MUB Prj.Dir./Atölye");
            personelKayits2 = kayitManager.PersonelBolumBazli("MUB Prj.Dir./MGEO Van BO");
            foreach (PersonelKayit item in personelKayits2)
            {
                personelKayits.Add(item);
            }
            CmbGorevAtanacakPersonelManuel.DataSource = personelKayits;
            CmbGorevAtanacakPersonelManuel.ValueMember = "Id";
            CmbGorevAtanacakPersonelManuel.DisplayMember = "Adsoyad";
            CmbGorevAtanacakPersonelManuel.SelectedValue = -1;
        }
        void DataDisplayManuel()
        {
            malzemeKayits = malzemeManager.GetList();
            malzemeKayitsFiltired = malzemeKayits;
            dataBinder.DataSource = malzemeKayits.ToDataTable();
            DtgStokList.DataSource = dataBinder;

            DtgStokList.Columns["Id"].Visible = false;
            DtgStokList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgStokList.Columns["Tanim"].HeaderText = "TANIM";
            DtgStokList.Columns["Birim"].Visible = false;
            DtgStokList.Columns["TedarikciFirma"].Visible = false;
            DtgStokList.Columns["OnarimDurumu"].Visible = false;
            DtgStokList.Columns["OnarimYeri"].Visible = false;
            DtgStokList.Columns["TedarikTuru"].Visible = false;
            DtgStokList.Columns["ParcaSinifi"].Visible = false;
            DtgStokList.Columns["AlternatifParca"].Visible = false;
            DtgStokList.Columns["Aciklama"].Visible = false;
            DtgStokList.Columns["DosyaYolu"].Visible = false;
            DtgStokList.Columns["SistemStokNo"].Visible = false;
            DtgStokList.Columns["SistemTanimi"].Visible = false;
            DtgStokList.Columns["SistemSorumlusu"].Visible = false;
            DtgStokList.Columns["IslemYapan"].Visible = false;
            DtgStokList.Columns["TakipDurumu"].Visible = false;
            DtgStokList.Columns["UstStok"].Visible = false;
            DtgStokList.Columns["UstTanim"].Visible = false;
            DtgStokList.Columns["BenzersizId"].Visible = false;

            DtgStokList.Columns["KayitDurumu"].HeaderText = "SEÇİM";
            DtgStokList.Columns["SeriNo"].Visible = false;
            DtgStokList.Columns["Durum"].Visible = false;
            DtgStokList.Columns["Revizyon"].Visible = false;
            DtgStokList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgStokList.Columns["TalepTarihi"].Visible = false;

            DtgStokList.Columns["KayitDurumu"].DisplayIndex = 0;
            DtgStokList.Columns["StokNo"].DisplayIndex = 1;
            DtgStokList.Columns["Tanim"].DisplayIndex = 3;
            DtgStokList.Columns["SeriNo"].DisplayIndex = 4;
            DtgStokList.Columns["Durum"].DisplayIndex = 5;
            DtgStokList.Columns["Revizyon"].DisplayIndex = 6;
            DtgStokList.Columns["Miktar"].DisplayIndex = 7;
            DtgStokList.Columns["TalepTarihi"].DisplayIndex = 8;
            LblTop.Text = DtgStokList.RowCount.ToString();

            for (int i = 0; i < DtgStokList.RowCount; i++)
            {
                string tarih = DateTime.Now.ToString("dd.MM.yyyy");
                DtgStokList.Rows[i].Cells["TalepTarihi"].Value = tarih;
            }

            //DtgStokList.Rows[0].Cells["asdb"].Value = "test";

        }
        int arizaDurumu;
        string icSiparisNo = "";
        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtAbfFormNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Abf No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Atolye atolyeDTS = atolyeManager.ArizaGetirDTS(TxtAbfFormNo.Text.ConInt());
            if (atolyeDTS != null)
            {
                Temizle();
                DataDisplay();
                TxtStokNoUst.Text = atolyeDTS.StokNoUst;
                TxtTanimUst.Text = atolyeDTS.TanimUst;
                TxtSeriNoUst.Text = atolyeDTS.SeriNoUst;
                TxtGarantiDurumuUst.Text = atolyeDTS.GarantiDurumu;
                TxtBildirimNo.Text = atolyeDTS.BildirimNo;
                TxtScrmNo.Text = atolyeDTS.CrmNo;
                TxtKategori.Text = atolyeDTS.Kategori;
                TxtBolgeAdi.Text = atolyeDTS.BolgeAdi;
                TxtProje.Text = atolyeDTS.Proje;
                TxtBildirilenAriza.Text = atolyeDTS.BildirilenAriza;
                arizaDurumu = atolyeDTS.ArizaDurum;
                int adet = 1;
                if (arizaDurumu == 0)
                {
                    LblDurumAcik.Visible = false;
                    LblDurumKapali.Visible = true;
                    LblIslemAdimiAcik.Text = atolyeDTS.BulunduguIslemAdimi;
                    LblIslemAdimiKapali.Visible = false;
                    LblIslemAdimiAcik.Visible = true;

                    if (DtgMalzemeler.RowCount > 1)
                    {


                        foreach (AtolyeMalzeme item in atolyeMalzemes)
                        {
                            LblIcSiparisNo.Text = "221RWK" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                            icSiparisNo = "221RWK" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text + "/" + adet;
                            IcSiparisler.Add(icSiparisNo);

                            adet++;
                        }
                    }
                    else
                    {
                        LblIcSiparisNo.Text = "221RWK" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                    }

                }
                else
                {
                    LblDurumAcik.Visible = true;
                    LblDurumKapali.Visible = false;
                    LblIslemAdimiKapali.Text = atolyeDTS.BulunduguIslemAdimi;
                    LblIslemAdimiKapali.Visible = true;
                    LblIslemAdimiAcik.Visible = false;

                    if (DtgMalzemeler.RowCount > 1)
                    {
                        foreach (AtolyeMalzeme item in atolyeMalzemes)
                        {
                            LblIcSiparisNo.Text = "221BO" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                            icSiparisNo = "221BO" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text + "/" + adet;
                            IcSiparisler.Add(icSiparisNo);
                            adet++;

                        }
                    }
                    else
                    {
                        LblIcSiparisNo.Text = "221BO" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                    }

                }
            }
            else
            {
                Atolye atolye = atolyeManager.ArizaGetir(TxtAbfFormNo.Text.ConInt());
                if (atolye == null)
                {
                    MessageBox.Show("Girmiş Oluduğunuz Abf Numarasıya Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                    return;
                }
                Temizle();
                DataDisplay();
                TxtStokNoUst.Text = atolye.StokNoUst;
                TxtTanimUst.Text = atolye.TanimUst;
                TxtSeriNoUst.Text = atolye.SeriNoUst;
                TxtGarantiDurumuUst.Text = atolye.GarantiDurumu;
                TxtBildirimNo.Text = atolye.BildirimNo;
                TxtScrmNo.Text = atolye.CrmNo;
                TxtKategori.Text = atolye.Kategori;
                TxtBolgeAdi.Text = atolye.BolgeAdi;
                TxtProje.Text = atolye.Proje;
                TxtBildirilenAriza.Text = atolye.BildirilenAriza;
                arizaDurumu = atolye.ArizaDurum;
                int adet = 1;
                if (arizaDurumu == 0)
                {
                    LblDurumAcik.Visible = false;
                    LblDurumKapali.Visible = true;
                    LblIslemAdimiAcik.Text = atolye.BulunduguIslemAdimi;
                    LblIslemAdimiKapali.Visible = false;
                    LblIslemAdimiAcik.Visible = true;

                    if (DtgMalzemeler.RowCount > 1)
                    {


                        foreach (AtolyeMalzeme item in atolyeMalzemes)
                        {
                            LblIcSiparisNo.Text = "221RWK" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                            icSiparisNo = "221RWK" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text + "/" + adet;
                            IcSiparisler.Add(icSiparisNo);

                            adet++;
                        }
                    }
                    else
                    {
                        LblIcSiparisNo.Text = "221RWK" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                    }

                }
                else
                {
                    LblDurumAcik.Visible = true;
                    LblDurumKapali.Visible = false;
                    LblIslemAdimiKapali.Text = atolye.BulunduguIslemAdimi;
                    LblIslemAdimiKapali.Visible = true;
                    LblIslemAdimiAcik.Visible = false;

                    if (DtgMalzemeler.RowCount > 1)
                    {
                        foreach (AtolyeMalzeme item in atolyeMalzemes)
                        {
                            LblIcSiparisNo.Text = "221BO" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                            icSiparisNo = "221BO" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text + "/" + adet;
                            IcSiparisler.Add(icSiparisNo);
                            adet++;

                        }
                    }
                    else
                    {
                        LblIcSiparisNo.Text = "221BO" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                    }

                }
            }

        }
        void Temizle()
        {
            TxtStokNoUst.Clear(); TxtSeriNoUst.Clear(); TxtGarantiDurumuUst.Clear(); TxtBildirimNo.Clear(); TxtScrmNo.Clear(); TxtKategori.Clear(); TxtBolgeAdi.Clear(); TxtProje.Clear(); TxtStokNo.Clear(); TxtTanim.Clear(); TxtSeriNo.Clear(); TxtRevizyon.Clear();
            TxtMiktar.Clear(); TxtDurum.Clear(); TxtBildirilenAriza.Clear(); TxtModifikasyonlar.Clear(); TxtNotlar.Clear(); CmbGorevAtanacakPersonel.SelectedValue = ""; CmbIslemAdimi.SelectedValue = ""; TxtTanimUst.Clear(); LblIcSiparisNo.Text = "-"; LblDurumAcik.Visible = false; LblDurumKapali.Visible = false; LblIslemAdimiKapali.Visible = false; LblIslemAdimiAcik.Visible = false;
            LblToplam.Text = DtgMalzemeler.RowCount.ToString();
        }
        void TemizleManuel()
        {
            TxtTanimUs.Text = ""; CmbStokUst.Clear(); TxtSeriUst.Clear(); CmbGarantiDurumuUst.Text = ""; CmbKategori.SelectedIndex = -1;
            CmbProje.SelectedIndex = -1; LblIcSiparisManuel.Text = "-"; TxtModifikasyonlarManuel.Clear(); TxtNotlarManuel.Clear();
            CmbGorevAtanacakPersonelManuel.SelectedIndex = -1; CmbIslemAdimiManuel.SelectedIndex = -1;
        }
        void DataDisplay()
        {
            atolyeMalzemes = atolyeMalzemeManager.GetListDTS(TxtAbfFormNo.Text.ConInt());
            if (atolyeMalzemes.Count == 0)
            {
                atolyeMalzemes = atolyeMalzemeManager.GetList(TxtAbfFormNo.Text.ConInt());
            }

            DtgMalzemeler.DataSource = atolyeMalzemes.ToDataTable();
            LblToplam.Text = DtgMalzemeler.RowCount.ToString();


            DtgMalzemeler.Columns["Id"].Visible = false;
            DtgMalzemeler.Columns["FormNo"].Visible = false;
            DtgMalzemeler.Columns["StokNo"].HeaderText = "STOK NO";
            DtgMalzemeler.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeler.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgMalzemeler.Columns["Durum"].HeaderText = "DURUM";
            DtgMalzemeler.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgMalzemeler.Columns["Miktar"].HeaderText = "MİKAR";
            //DtgMalzemeler.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzemeler.Columns["TalepTarihi"].HeaderText = "TALEP TARİHİ";
            DtgMalzemeler.Columns["SiparisNo"].Visible = false;
            DtgMalzemeler.Columns["Sec"].HeaderText = "KAYIT DURUMU";
            DtgMalzemeler.Columns["Sec"].DisplayIndex = 0;

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }


        void EditSiparisNos()
        {
            string value, siparisNoForEdit;
            int adet = 1;
            List<bool> secList = new List<bool>();
            foreach (DataGridViewRow row in DtgMalzemeler.Rows)
            {
                secList.Add(row.Cells[10].Value.ConBool());
            }

            for (int i = 0; i < secList.Count; i++)
            {
                value = IcSiparisler[i];
                if (atolyeMalzemes.Count > 1 && secList.Where(x => x).Count() == 1)
                {
                    siparisNoForEdit = value.Substring(0, value.Length - 2);
                    IcSiparisler.Clear();
                    IcSiparisler.Add(siparisNoForEdit);
                    break;
                }
                else if (atolyeMalzemes.Count > 1 && secList.Where(x => x).Count() > 1)
                {
                    string prefix = secList[i] ? "/" + adet : "";
                    siparisNoForEdit = value.Substring(0, value.Length - 2) + prefix;
                    if (secList[i])
                    {
                        IcSiparisler[i] = siparisNoForEdit;
                        adet++;
                    }
                    else
                    {
                        IcSiparisler[i] = siparisNoForEdit;
                    }
                }
            }
            for (int i = 0; i < IcSiparisler.Count; i++)
            {
                if (!IcSiparisler[i].Contains('/'))
                {

                    if (IcSiparisler.Count == 1)
                    {
                        break;
                    }
                    IcSiparisler.Remove(IcSiparisler[i]);
                    i--;
                }
            }
        }

        string Bildirim()
        {
            string[] array = new string[8];

            array[0] = "Atölye Sipariş Açma"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel

            if (SiparisNos[0].ToString() != null)
            {
                array[2] = SiparisNos[0].ToString();
            }
            else
            {
                array[2] = LblIcSiparisNo.Text;
            }
            array[3] = "Sipariş numaralı"; // Bildirim türü
            if (TxtBolgeAdi.Text == "")
            {
                array[4] = "Bölge Bilgisi Olmayan";
            }
            else
            {
                array[4] = TxtBolgeAdi.Text;
            }
            array[5] = TxtKategori.Text + " arızasının";
            array[6] = "Atölye kaydını Otomatik Kayıt yaparak oluşturmuştur!";

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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void CmbStokUst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            id = TxtTanimUs.SelectedValue.ConInt();
            MalzemeKayit malzemeKayit = malzemeKayitManager.Get(id);
            if (malzemeKayit == null)
            {
                CmbStokUst.Text = "";
                return;
            }
            CmbStokUst.Text = malzemeKayit.Stokno;
        }

        private void TxtStokManuel_TextChanged(object sender, EventArgs e)
        {
            string stokno = TxtStokManuel.Text;
            if (string.IsNullOrEmpty(stokno))
            {
                malzemeKayitsFiltired = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                LblTop.Text = DtgStokList.RowCount.ToString();

                for (int i = 0; i < DtgStokList.RowCount; i++)
                {
                    string tarih = DateTime.Now.ToString("dd.MM.yyyy");
                    DtgStokList.Rows[i].Cells["TalepTarihi"].Value = tarih;
                }

                return;
            }
            if (TxtStokManuel.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemeKayitsFiltired.Where(x => x.StokNo.ToLower().Contains(stokno.ToLower())).ToList().ToDataTable();
            DtgStokList.DataSource = dataBinder;
            malzemeKayitsFiltired = malzemeKayits;
            LblTop.Text = DtgStokList.RowCount.ToString();

            for (int i = 0; i < DtgStokList.RowCount; i++)
            {
                string tarih = DateTime.Now.ToString("dd.MM.yyyy");
                DtgStokList.Rows[i].Cells["TalepTarihi"].Value = tarih;
            }
        }

        private void TxtTanimManuel_TextChanged(object sender, EventArgs e)
        {
            string tanim = TxtTanimManuel.Text;
            if (string.IsNullOrEmpty(tanim))
            {
                malzemeKayitsFiltired = malzemeKayits;
                dataBinder.DataSource = malzemeKayits.ToDataTable();
                DtgStokList.DataSource = dataBinder;
                LblTop.Text = DtgStokList.RowCount.ToString();

                for (int i = 0; i < DtgStokList.RowCount; i++)
                {
                    string tarih = DateTime.Now.ToString("dd.MM.yyyy");
                    DtgStokList.Rows[i].Cells["TalepTarihi"].Value = tarih;
                }

                return;
            }
            if (TxtTanimManuel.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemeKayitsFiltired.Where(x => x.Tanim.ToLower().Contains(tanim.ToLower())).ToList().ToDataTable();
            DtgStokList.DataSource = dataBinder;
            malzemeKayitsFiltired = malzemeKayits;
            LblTop.Text = DtgStokList.RowCount.ToString();

            for (int i = 0; i < DtgStokList.RowCount; i++)
            {
                string tarih = DateTime.Now.ToString("dd.MM.yyyy");
                DtgStokList.Rows[i].Cells["TalepTarihi"].Value = tarih;
            }
        }
        string KontrolManuel()
        {
            if (DtgKayitList.RowCount<1)
            {
                return "Lütfen kaydedilecek malzemeleri ekleyiniz!";
            }
            foreach (DataGridViewRow item in DtgKayitList.Rows)
            {
                Atolye atolye3 = atolyeManager.GetControl(item.Cells["ManuelStokNo"].Value.ToString(), item.Cells["ManuelSeriNo"].Value.ToString());
                if (atolye3 != null)
                {
                    return item.Cells["ManuelStokNo"].Value.ToString() + " stok numaralı malzeme " + atolye3.Id + " kimlik numaralı kayıtta zaten var!";
                }
            }

            if (TxtTanimUs.Text == "")
            {
                return "Lütfen Öncelikle Üst Takım Stok No Bilgisini Seçiniz!";
            }
            if (TxtSeriUst.Text == "")
            {
                return "Lütfen Öncelikle Üst Takım Seri No Bilgisini Doldurunuz!\nBilmiyorsanız N/A Seçiniz.";
            }
            if (CmbGorevAtanacakPersonelManuel.Text == "")
            {
                return "Lütfen Öncelikle Görev Atanacak Personel Bilgisini Seçiniz!";
            }
            if (CmbIslemAdimiManuel.Text == "")
            {
                return "Lütfen Öncelikle İşlem Adımı Bilgisini Seçiniz!";
            }
            if (CmbAtolyeKategoriManuel.Text == "")
            {
                return "Lütfen Öncelikle Atölye Kategori Bilgisini Seçiniz!";
            }

            return "OK";


        }

        string malzemeSeriKontrol = "";

        private void BtnKaydetManuel_Click(object sender, EventArgs e)
        {
            string mesaj = KontrolManuel();
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İsteğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                malzemes = new List<Malzeme>();
                foreach (DataGridViewRow item in DtgKayitList.Rows)
                {
                    Malzeme malzemeKayit = new Malzeme(true, item.Cells["ManuelStokNo"].Value.ToString(), item.Cells["ManuelTanim"].Value.ToString(), item.Cells["ManuelSeriNo"].Value.ToString(), "ONARILACAK", item.Cells["ManuelRevizyon"].Value.ToString(), item.Cells["ManuelMiktar"].Value.ConInt(), item.Cells["ManuelTalepTarihi"].Value.ToString());

                    malzemes.Add(malzemeKayit);
                }

                foreach (Malzeme item in malzemes)
                {
                    siparisNo = Guid.NewGuid().ToString();
                    IcSiparisNo();
                    Atolye atolye2 = new Atolye(0, TxtTanimUs.Text, CmbStokUst.Text, TxtSeriUst.Text, CmbGarantiDurumuUst.Text, "", "", CmbKategori.Text, "", "", "", LblIcSiparisManuel.Text, DtgCekilmeTarihiManuel.Value, DtgSiparisTarihiManuel.Value, TxtModifikasyonlarManuel.Text, TxtNotlarManuel.Text, CmbIslemAdimiManuel.Text, siparisNo, "", CmbAtolyeKategoriManuel.Text, 0);

                    atolyeManager.Add(atolye2);

                    AtolyeMalzeme atolyeMalzeme = new AtolyeMalzeme(0, item.StokNo, item.Tanim, item.SeriNo, item.Durum, item.Revizyon, item.Miktar, item.TalepTarihi.ConDate(), siparisNo);

                    atolyeMalzemeManager.Add(atolyeMalzeme);

                    Atolye atolye1 = atolyeManager.Get(siparisNo);
                    id = atolye1.Id;
                    GorevAtamaManuel();
                }

                #region EskiKod
                //CreateFileManuel();
                //if (SiparisNos.Count > 0)
                //{
                //    //EditSiparisNos();

                //    for (int i = 0; i < SiparisNos.Count; i++)
                //    {
                //        siparisNo = Guid.NewGuid().ToString();

                //        Atolye atolye2 = new Atolye(0, TxtTanimUs.Text, CmbStokUst.Text, TxtSeriUst.Text, CmbGarantiDurumuUst.Text, "", "", CmbKategori.Text, "", "", "", IcSiparisler[i].ToString(), DtgCekilmeTarihiManuel.Value, DtgSiparisTarihiManuel.Value, TxtModifikasyonlarManuel.Text, TxtNotlarManuel.Text, CmbIslemAdimiManuel.Text, siparisNo, "", CmbAtolyeKategoriManuel.Text, 0);

                //        atolyeManager.Add(atolye2);

                //        SiparisNos.Add(siparisNo);

                //    }
                //}
                //else
                //{
                //    siparisNo = Guid.NewGuid().ToString();
                //    Atolye atolye = new Atolye(0, TxtTanimUs.Text, CmbStokUst.Text, TxtSeriUst.Text, CmbGarantiDurumuUst.Text, "", "", CmbKategori.Text, "", "", "", LblIcSiparisManuel.Text, DtgCekilmeTarihiManuel.Value, DtgSiparisTarihiManuel.Value, TxtModifikasyonlarManuel.Text, TxtNotlarManuel.Text, CmbIslemAdimiManuel.Text, siparisNo, "", CmbAtolyeKategoriManuel.Text, 0);

                //    SiparisNos.Add(siparisNo);
                //    atolyeManager.Add(atolye);
                //}

                //int sayac = 0;



                //foreach (Malzeme item in malzemeKayitsSecilenler)
                //{

                //    AtolyeMalzeme atolyeMalzeme = new AtolyeMalzeme(0, item.StokNo, item.Tanim, item.SeriNo, item.Durum, item.Revizyon, item.Miktar, item.TalepTarihi.ConDate(), SiparisNos[sayac].ToString());

                //    malzemeSeriKontrol = item.SeriNo;
                //    atolyeMalzemeManager.Add(atolyeMalzeme);
                //    sayac++;

                //}

                //if (SiparisNos.Count > 0)
                //{
                //    for (int i = 0; i < SiparisNos.Count; i++)
                //    {
                //        Atolye atolye2 = atolyeManager.Get(SiparisNos[i].ToString());
                //        id = atolye2.Id;
                //GorevAtamaManuel();
                //    }
                //}
                //else
                //{
                //    Atolye atolye1 = atolyeManager.Get(siparisNo);
                //    id = atolye1.Id;
                //    GorevAtamaManuel();
                //}
                ////IscilikGir();

                //string mesaj2 = BildirimManuel();
                //if (mesaj2 != "OK")
                //{
                //    if (mesaj2 != "Server Ayarı Kapalı")
                //    {
                //        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
                #endregion

                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnKaydet.Enabled = true;
                BtnTemizle.Enabled = true;
                BtnCancel.Enabled = true;
                BtnBul.Enabled = true;
                TemizleManuel();

                DtgKayitList.Rows.Clear();

                IcSiparisler = new List<string>();
                SiparisNos = new List<string>();
                DosyaYollari = new List<string>();
                malzemeKayitsSecilenler = new List<Malzeme>();
                IcSiparisNo();
                Don();
            }
        }

        string BildirimManuel()
        {
            string[] array = new string[8];

            array[0] = "Atölye Sipariş Açma"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            if (IcSiparisler[0].ToString() != null)
            {
                array[2] = IcSiparisler[0].ToString();
            }
            else
            {
                array[2] = LblIcSiparisManuel.Text;
            }
            array[3] = "Sipariş numaralı"; // Bildirim türü
            array[4] = "Bölge Bilgisi Olmayan"; // Bölge
            array[5] = CmbAtolyeKategoriManuel.Text + " arızasının";
            array[6] = "Atölye kaydını Manuel Kayıt yaparak oluşturmuştur!";

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

        public void Kategori()
        {
            CmbKategori.DataSource = comboManager.GetList("ABF KATEGORİ");
            CmbKategori.ValueMember = "Id";
            CmbKategori.DisplayMember = "Baslik";
            CmbKategori.SelectedValue = 0;
        }
        public void AtolyeKategoriOto()
        {
            CmbAtolyeKategoriOto.DataSource = comboManager.GetList("ATOLYE KATEGORI");
            CmbAtolyeKategoriOto.ValueMember = "Id";
            CmbAtolyeKategoriOto.DisplayMember = "Baslik";
            CmbAtolyeKategoriOto.SelectedValue = 0;
        }
        public void AtolyeKategorManuel()
        {
            CmbAtolyeKategoriManuel.DataSource = comboManager.GetList("ATOLYE KATEGORI");
            CmbAtolyeKategoriManuel.ValueMember = "Id";
            CmbAtolyeKategoriManuel.DisplayMember = "Baslik";
            CmbAtolyeKategoriManuel.SelectedValue = 0;
        }

        private void TxtTemizleManuel_Click(object sender, EventArgs e)
        {
            TxtTanimUs.Text = ""; CmbStokUst.Clear(); TxtSeriUst.Clear(); CmbGarantiDurumuUst.Text = ""; TxtModifikasyonlarManuel.Clear();
            TxtNotlarManuel.Clear(); CmbGorevAtanacakPersonelManuel.SelectedValue = ""; CmbIslemAdimiManuel.SelectedValue = ""; TxtStokManuel.Clear();
            TxtTanimManuel.Clear();
        }

        string GorevAtama()
        {
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "100-TAKIMIN ÇEKİLMESİ (AMBAR VERİ KAYIT)", DateTime.Now, "ÇEKİM İŞLEMİ TAMAMLANMIŞTIR.", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel);


            GorevAtamaPersonel gorevAtamaPersonel2 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "200-MODİFİKASYON KONTROLÜ (AMBAR VERİ KAYIT)", DateTime.Now, "UYGULANMASI GEREKEN MODİFİKASYON BULUNMAMAKTADIR.", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel2);



            GorevAtamaPersonel gorevAtamaPersonel3 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "300-SİPARİŞ OLUŞTURMA (AMBAR VERİ KAYIT)", DateTime.Now, LblIcSiparisNo.Text + " NOLU SİPARİŞ OLUŞTURULMUŞTUR.", "00:25:00".ConOnlyTime());
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel3);



            GorevAtamaPersonel gorevAtamaPersonel4 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", CmbGorevAtanacakPersonel.Text, CmbIslemAdimi.Text, DateTime.Now, "", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel4);

            string sure = "0 Gün " + "0 Saat " + "0 Dakika";

            int guncellenecekId = 0;
            List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(id, "BAKIM ONARIM ATOLYE");

            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == "100-TAKIMIN ÇEKİLMESİ (AMBAR VERİ KAYIT)")
                {
                    guncellenecekId = item.Id;
                }
            }

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(guncellenecekId, id, "BAKIM ONARIM ATOLYE", "100-TAKIMIN ÇEKİLMESİ (AMBAR VERİ KAYIT)", sure, DateTime.Now.Date, infos[1].ToString());
            gorevAtamaPersonelManager.Update(gorevAtama);


            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == "200-MODİFİKASYON KONTROLÜ (AMBAR VERİ KAYIT)")
                {
                    guncellenecekId = item.Id;
                }
            }

            GorevAtamaPersonel messege2 = new GorevAtamaPersonel(guncellenecekId, id, "BAKIM ONARIM ATOLYE", "200-MODİFİKASYON KONTROLÜ (AMBAR VERİ KAYIT)", sure, DateTime.Now.Date, infos[1].ToString());
            gorevAtamaPersonelManager.Update(messege2);


            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == "300-SİPARİŞ OLUŞTURMA (AMBAR VERİ KAYIT)")
                {
                    guncellenecekId = item.Id;
                }
            }

            GorevAtamaPersonel messege3 = new GorevAtamaPersonel(guncellenecekId, id, "BAKIM ONARIM ATOLYE", "300-SİPARİŞ OLUŞTURMA (AMBAR VERİ KAYIT)", sure, "00:25:00".ConOnlyTime(), infos[1].ToString());
            gorevAtamaPersonelManager.Update(messege3);
            return "OK";
        }
        string GorevAtamaManuel()
        {
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "100-TAKIMIN ÇEKİLMESİ (AMBAR VERİ KAYIT)", DateTime.Now, "ÇEKİM İŞLEMİ TAMAMLANMIŞTIR.", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel);


            GorevAtamaPersonel gorevAtamaPersonel2 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "200-MODİFİKASYON KONTROLÜ (AMBAR VERİ KAYIT)", DateTime.Now, "UYGULANMASI GEREKEN MODİFİKASYON BULUNMAMAKTADIR.", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel2);


            GorevAtamaPersonel gorevAtamaPersonel3 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "300-SİPARİŞ OLUŞTURMA (AMBAR VERİ KAYIT)", DateTime.Now, LblIcSiparisManuel.Text + " NOLU SİPARİŞ OLUŞTURULMUŞTUR.", "00:25:00".ConOnlyTime());
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel3);


            GorevAtamaPersonel gorevAtamaPersonel4 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", CmbGorevAtanacakPersonelManuel.Text, CmbIslemAdimiManuel.Text, DateTime.Now, "", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel4);

            string sure = "0 Gün " + "0 Saat " + "0 Dakika";


            int guncellenecekId = 0;
            List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetDevamEdenler(id, "BAKIM ONARIM ATOLYE");

            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == "100-TAKIMIN ÇEKİLMESİ (AMBAR VERİ KAYIT)")
                {
                    guncellenecekId = item.Id;
                }
            }

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(guncellenecekId, id, "BAKIM ONARIM ATOLYE", "100-TAKIMIN ÇEKİLMESİ (AMBAR VERİ KAYIT)", sure, DateTime.Now.Date, infos[1].ToString());
            gorevAtamaPersonelManager.Update(gorevAtama);

            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == "200-MODİFİKASYON KONTROLÜ (AMBAR VERİ KAYIT)")
                {
                    guncellenecekId = item.Id;
                }
            }

            GorevAtamaPersonel messege2 = new GorevAtamaPersonel(guncellenecekId, id, "BAKIM ONARIM ATOLYE", "200-MODİFİKASYON KONTROLÜ (AMBAR VERİ KAYIT)", sure, DateTime.Now.Date, infos[1].ToString());
            gorevAtamaPersonelManager.Update(messege2);

            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (item.IslemAdimi == "300-SİPARİŞ OLUŞTURMA (AMBAR VERİ KAYIT)")
                {
                    guncellenecekId = item.Id;
                }
            }
            GorevAtamaPersonel messege3 = new GorevAtamaPersonel(guncellenecekId, id, "BAKIM ONARIM ATOLYE", "300-SİPARİŞ OLUŞTURMA (AMBAR VERİ KAYIT)", sure, "00:25:00".ConOnlyTime(), infos[1].ToString());
            gorevAtamaPersonelManager.Update(messege3);
            return "OK";
        }

        private void CmbAtolyeKategori_Click(object sender, EventArgs e)
        {
            comboAd = "ATOLYE KATEGORI";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void CmbAtolyeKategoriEkle_Click(object sender, EventArgs e)
        {
            comboAd = "ATOLYE KATEGORI";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }
        int index;
        private void DtgStokList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = DtgStokList.CurrentRow.Index;
            bool deneme = DtgStokList.Rows[index].Cells["KayitDurumu"].Value.ConBool();

            if (deneme == true)
            {
                DtgStokList.Rows[index].Cells["Miktar"].Value = 1;
            }
            else
            {
                DtgStokList.Rows[index].Cells["Miktar"].Value = 0;
            }

        }

        private void DtgStokList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (kayitId == 0)
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < DtgList.Rows.Count; i++)
            {
                bool secim = DtgList.CurrentRow.Cells["Secim"].Value.ConBool();
                if (secim == true)
                {
                    break;
                }
                if (i == DtgList.Rows.Count - 1)
                {
                    MessageBox.Show("Lütfen Atölyeye Kayıt edilecek malzeme listesinden bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                continue;
            }

            #region control
            //if (TxtStokNoUst.Text == "" || DtgMalzemeler.RowCount == 0)
            //{
            //    MessageBox.Show("Lütfen Öncelikle Tüm Bilgileri Eksiksiz Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (CmbGorevAtanacakPersonel.Text == "")
            //{
            //    MessageBox.Show("Lütfen Öncelikle Görev Atanacak Personel Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (CmbIslemAdimi.Text == "")
            //{
            //    MessageBox.Show("Lütfen Öncelikle İşlem Adımı Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (CmbAtolyeKategoriOto.Text == "")
            //{
            //    MessageBox.Show("Lütfen Öncelikle Atölye Kategori Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //foreach (DataGridViewRow item in DtgMalzemeler.Rows)
            //{
            //    if (item.Cells[10].Value.ConBool())
            //    {
            //        Atolye atolye3 = atolyeManager.GetControl(item.Cells["StokNo"].Value.ToString(), item.Cells["SeriNo"].Value.ToString());
            //        if (atolye3!=null)
            //        {
            //            MessageBox.Show(item.Cells["StokNo"].Value.ToString() + " stok numaralı malzeme "+ atolye3.Id + " kimlik numaralı kayıtta zaten var!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //    }
            //}


            #endregion

            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                BtnKaydet.Enabled = false;
                BtnTemizle.Enabled = false;
                BtnCancel.Enabled = false;
                BtnBul.Enabled = false;
                //CreateFile();

                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    if (item.Cells["Secim"].Value.ConBool() == true)
                    {
                        ArizaKayit arizaKayit = arizaKayitManager.Get(item.Cells["AbfNo"].Value.ConInt());
                        if (arizaKayit != null)
                        {
                            siparisNo = Guid.NewGuid().ToString();
                            string icSiparisNo = "";

                            if (item.Cells["YerineMalzemeTakilma"].Value.ToString() == "TAKILDI")
                            {
                                icSiparisNo = "221RWK" + DateTime.Now.ToString("MM") + item.Cells["AbfNo"].Value.ToString();
                            }
                            else
                            {
                                icSiparisNo = "221BO" + DateTime.Now.ToString("MM") + item.Cells["AbfNo"].Value.ToString();
                            }


                            Atolye atolye2 = new Atolye(abfNo.ConInt(), arizaKayit.StokNo, arizaKayit.Tanim, arizaKayit.SeriNo, arizaKayit.GarantiDurumu, arizaKayit.BildirimNo, "", arizaKayit.Kategori, arizaKayit.BolgeAdi, arizaKayit.Proje, arizaKayit.BildirilenAriza, icSiparisNo, DtgCekilmeTarihi.Value, DtgSiparisTarihi.Value, TxtModifikasyonlar.Text, TxtNotlar.Text, CmbIslemAdimi.Text, siparisNo, "", CmbAtolyeKategoriOto.Text, kayitId);

                            atolyeManager.Add(atolye2);

                            Atolye atolye = atolyeManager.Get(siparisNo);
                            id = atolye.Id;
                            kayitId = item.Cells["Id"].Value.ConInt();
                            AbfMalzemeIslemKayit abfMalzemeIslemKayit = abfMalzemeIslemKayitManager.Get(kayitId, "300 - ATÖLYEYE GİDECEK MALZEME");
                            if (abfMalzemeIslemKayit != null)
                            {
                                talepTarihi = abfMalzemeIslemKayit.Tarih;
                            }
                            else
                            {
                                talepTarihi = DateTime.Now;
                            }


                            AtolyeMalzeme atolyeMalzeme = new AtolyeMalzeme(item.Cells["AbfNo"].Value.ConInt(), item.Cells["SokulenStokNo"].Value.ToString(), item.Cells["SokulenTanim"].Value.ToString(), item.Cells["SokulenSeriNo"].Value.ToString(), item.Cells["YapilacakIslem"].Value.ToString(), item.Cells["SokulenRevizyon"].Value.ToString(), item.Cells["SokulenMiktar"].Value.ConInt(), talepTarihi, siparisNo);

                            atolyeMalzemeManager.Add(atolyeMalzeme);
                            GorevAtama();

                            abfMalzemeManager.MalzemeTeslimBilgisiUpdate(kayitId, "ATÖLYE BAKIM ONARIMDA");
                            AbfMalzemeIslemKayit abfMalzemeIslemKayit2 = new AbfMalzemeIslemKayit(kayitId, "ATÖLYE BAKIM ONARIMDA", DateTime.Now, infos[1].ToString(), 0);
                            abfMalzemeIslemKayitManager.Add(abfMalzemeIslemKayit2);

                            AbfMalzemeIslemKayit abfMalzemeIslemKayit1 = abfMalzemeIslemKayitManager.Get(kayitId, "300 - ATÖLYEYE GİDECEK MALZEME");
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
                }





                #region EskiKod
                //if (IcSiparisler.Count > 0)
                //{
                //    EditSiparisNos();
                //    for (int i = 0; i < IcSiparisler.Count; i++)
                //    {
                //        siparisNo = Guid.NewGuid().ToString();


                //        Atolye atolye2 = new Atolye(TxtAbfFormNo.Text.ConInt(), TxtStokNoUst.Text, TxtTanimUst.Text, TxtSeriNoUst.Text, TxtGarantiDurumuUst.Text, TxtBildirimNo.Text, TxtScrmNo.Text, TxtKategori.Text, TxtBolgeAdi.Text, TxtProje.Text, TxtBildirilenAriza.Text, IcSiparisler[i].ToString(), DtgCekilmeTarihi.Value, DtgSiparisTarihi.Value, TxtModifikasyonlar.Text, TxtNotlar.Text, CmbIslemAdimi.Text, siparisNo,
                //            "", CmbAtolyeKategoriOto.Text);

                //        atolyeManager.Add(atolye2);

                //        SiparisNos.Add(siparisNo);

                //    }
                //}
                //else
                //{
                //    siparisNo = Guid.NewGuid().ToString();
                //    Atolye atolye = new Atolye(TxtAbfFormNo.Text.ConInt(), TxtStokNoUst.Text, TxtTanimUst.Text, TxtSeriNoUst.Text, TxtGarantiDurumuUst.Text, TxtBildirimNo.Text, TxtScrmNo.Text, TxtKategori.Text, TxtBolgeAdi.Text, TxtProje.Text, TxtBildirilenAriza.Text, LblIcSiparisNo.Text, DtgCekilmeTarihi.Value, DtgSiparisTarihi.Value, TxtModifikasyonlar.Text, TxtNotlar.Text, CmbIslemAdimi.Text, siparisNo,
                //        "", CmbAtolyeKategoriOto.Text);

                //    SiparisNos.Add(siparisNo);
                //    atolyeManager.Add(atolye);
                //}

                //int sayac = 0;
                //foreach (DataGridViewRow item in DtgMalzemeler.Rows)
                //{
                //    if (item.Cells[10].Value.ConBool())
                //    {

                //        AtolyeMalzeme atolyeMalzeme = new AtolyeMalzeme(item.Cells["FormNo"].Value.ConInt(), item.Cells["StokNo"].Value.ToString(),
                //            item.Cells["Tanim"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Durum"].Value.ToString(),
                //            item.Cells["Revizyon"].Value.ToString(), item.Cells["Miktar"].Value.ConDouble(), item.Cells["TalepTarihi"].Value.ConDate(),
                //            SiparisNos[sayac].ToString());

                //        atolyeMalzemeManager.Add(atolyeMalzeme);
                //        sayac++;
                //    }
                //}

                //if (SiparisNos.Count > 0)
                //{
                //    for (int i = 0; i < SiparisNos.Count; i++)
                //    {
                //        Atolye atolye2 = atolyeManager.Get(SiparisNos[i].ToString());
                //        id = atolye2.Id;
                //        GorevAtama();
                //    }
                //}
                //else
                //{
                //    Atolye atolye1 = atolyeManager.Get(siparisNo);
                //    id = atolye1.Id;
                //    GorevAtama();
                //}

                ////IscilikGir();

                //string mesaj = Bildirim();
                //if (mesaj != "OK")
                //{
                //    if (mesaj != "Server Ayarı Kapalı")
                //    {
                //        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}

                #endregion

                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BtnKaydet.Enabled = true;
                BtnTemizle.Enabled = true;
                BtnCancel.Enabled = true;
                BtnBul.Enabled = true;
                Temizle();
                DtgMalzemeler.DataSource = null;
                IcSiparisler.Clear();
                SiparisNos.Clear();
                DosyaYollari.Clear();
                IcSiparisNo();
                kayitId = 0;
                DataOtoKayit();
            }
        }

        private void BtnTemizle_Click_1(object sender, EventArgs e)
        {
            BtnKaydet.Enabled = true;
            BtnTemizle.Enabled = true;
            BtnCancel.Enabled = true;
            BtnBul.Enabled = true;
            Temizle();
            DtgMalzemeler.DataSource = null;
            IcSiparisler.Clear();
            SiparisNos.Clear();
            DosyaYollari.Clear();
            IcSiparisNo();
        }

        private void BtnListeyeEkle_Click(object sender, EventArgs e)
        {
            malzemes = new List<Malzeme>();
            //int index = 0;
            foreach (DataGridViewRow item in DtgStokList.Rows)
            {
                if (item.Cells["KayitDurumu"].Value.ConBool() == true)
                {
                    for (int i = 0; i < item.Cells["Miktar"].Value.ConInt(); i++)
                    {
                        DtgKayitList.Rows.Add();
                        int sonSatir = DtgKayitList.RowCount - 1;
                        DtgKayitList.Rows[sonSatir].Cells["ManuelStokNo"].Value = item.Cells["StokNo"].Value.ToString();
                        DtgKayitList.Rows[sonSatir].Cells["ManuelTanim"].Value = item.Cells["Tanim"].Value.ToString();
                        DtgKayitList.Rows[sonSatir].Cells["ManuelSeriNo"].Value = "";
                        DtgKayitList.Rows[sonSatir].Cells["ManuelRevizyon"].Value = "";
                        DtgKayitList.Rows[sonSatir].Cells["ManuelMiktar"].Value = 1;
                        DtgKayitList.Rows[sonSatir].Cells["ManuelTalepTarihi"].Value = item.Cells["TalepTarihi"].Value.ToString();

                        DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgKayitList.Columns["Remove"];
                        c.FlatStyle = FlatStyle.Popup;
                        c.DefaultCellStyle.ForeColor = Color.Red;
                        c.DefaultCellStyle.BackColor = Color.Gainsboro;
                    }

                    //Malzeme malzeme = new Malzeme(item.Cells["KayitDurumu"].Value.ConBool(), item.Cells["StokNo"].Value.ToString(), item.Cells["Tanim"].Value.ToString(), "", "ONARILACAK", "", 1, item.Cells["TalepTarihi"].Value.ToString());
                    //for (int i = 0; i < item.Cells["Miktar"].Value.ConInt(); i++)
                    //{
                    //    malzemes.Add(malzeme);
                    //}
                }
            }

            foreach (DataGridViewRow item in DtgStokList.Rows)
            {
                item.Cells["KayitDurumu"].Value = false;
                item.Cells["Miktar"].Value = 0;
            }


            //DtgKayitList.DataSource = malzemes;

            //DtgKayitList.Columns["Id"].Visible = false;
            //DtgKayitList.Columns["StokNo"].HeaderText = "STOK NO";
            //DtgKayitList.Columns["Tanim"].HeaderText = "TANIM";
            //DtgKayitList.Columns["Birim"].Visible = false;
            //DtgKayitList.Columns["TedarikciFirma"].Visible = false;
            //DtgKayitList.Columns["OnarimDurumu"].Visible = false;
            //DtgKayitList.Columns["OnarimYeri"].Visible = false;
            //DtgKayitList.Columns["TedarikTuru"].Visible = false;
            //DtgKayitList.Columns["ParcaSinifi"].Visible = false;
            //DtgKayitList.Columns["AlternatifParca"].Visible = false;
            //DtgKayitList.Columns["Aciklama"].Visible = false;
            //DtgKayitList.Columns["DosyaYolu"].Visible = false;
            //DtgKayitList.Columns["SistemStokNo"].Visible = false;
            //DtgKayitList.Columns["SistemTanimi"].Visible = false;
            //DtgKayitList.Columns["SistemSorumlusu"].Visible = false;
            //DtgKayitList.Columns["IslemYapan"].Visible = false;
            //DtgKayitList.Columns["TakipDurumu"].Visible = false;
            //DtgKayitList.Columns["UstStok"].Visible = false;
            //DtgKayitList.Columns["UstTanim"].Visible = false;
            //DtgKayitList.Columns["BenzersizId"].Visible = false;

            //DtgKayitList.Columns["KayitDurumu"].HeaderText = "SEÇİM";
            //DtgKayitList.Columns["SeriNo"].HeaderText = "SERİ NO";
            //DtgKayitList.Columns["Durum"].Visible = false;
            //DtgKayitList.Columns["Revizyon"].HeaderText = "REVİZYON";
            //DtgKayitList.Columns["Miktar"].HeaderText = "MİKTAR";
            //DtgKayitList.Columns["TalepTarihi"].HeaderText = "TALEP TARİHİ";

            //DtgKayitList.Columns["KayitDurumu"].DisplayIndex = 0;
            //DtgKayitList.Columns["StokNo"].DisplayIndex = 1;
            //DtgKayitList.Columns["Tanim"].DisplayIndex = 3;
            //DtgKayitList.Columns["SeriNo"].DisplayIndex = 4;
            //DtgKayitList.Columns["Durum"].DisplayIndex = 5;
            //DtgKayitList.Columns["Revizyon"].DisplayIndex = 6;
            //DtgKayitList.Columns["Miktar"].DisplayIndex = 7;
            //DtgKayitList.Columns["TalepTarihi"].DisplayIndex = 8;

            //foreach (DataGridViewRow item in DtgStokList.Rows)
            //{
            //    item.Cells["KayitDurumu"].Value = false;
            //    item.Cells["Miktar"].Value = 0;
            //}

            //foreach (DataGridViewRow item in DtgKayitList.Rows)
            //{
            //    foreach (Malzeme item2 in malzemes)
            //    {
            //        if (item2.StokNo == item.Cells["StokNo"].Value.ToString())
            //        {
            //            MessageBox.Show(item2.StokNo + " stok numaralı malzeme zaten listeye eklenmiltir!","");
            //            malzemes.RemoveAt(index);
            //        }
            //        index++;
            //    }
            //}
        }

        private void DtgKayitList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgKayitList.Rows.RemoveAt(e.RowIndex);
            }
        }

        string stokNo, tanim, seriNo, yapilacakIslem, revizyon; int miktar; DateTime talepTarihi;
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            kayitId = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            yerineMalzeme = DtgList.CurrentRow.Cells["YerineMalzemeTakilma"].Value.ToString();
            abfNo = DtgList.CurrentRow.Cells["AbfNo"].Value.ToString();
            stokNo = DtgList.CurrentRow.Cells["SokulenStokNo"].Value.ToString();
            tanim = DtgList.CurrentRow.Cells["SokulenTanim"].Value.ToString();
            seriNo = DtgList.CurrentRow.Cells["SokulenSeriNo"].Value.ToString();
            yapilacakIslem = DtgList.CurrentRow.Cells["YapilacakIslem"].Value.ToString();
            revizyon = DtgList.CurrentRow.Cells["SokulenRevizyon"].Value.ToString();
            miktar = DtgList.CurrentRow.Cells["SokulenMiktar"].Value.ConInt();

            AbfMalzemeIslemKayit abfMalzemeIslemKayit = abfMalzemeIslemKayitManager.Get(kayitId, "300 - ATÖLYEYE GİDECEK MALZEME");
            if (abfMalzemeIslemKayit != null)
            {
                talepTarihi = abfMalzemeIslemKayit.Tarih;
            }
            else
            {
                talepTarihi = DateTime.Now;
            }
            if (yerineMalzeme == "TAKILDI")
            {
                LblIcSiparisNo.Text = "221RWK" + DateTime.Now.ToString("MM") + abfNo;
            }
            else
            {
                LblIcSiparisNo.Text = "221BO" + DateTime.Now.ToString("MM") + abfNo;
            }

        }

        private void BtnKategoriEkle_Click(object sender, EventArgs e)
        {
            comboAd = "ABF KATEGORİ";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        void CreateFile()
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
            var dosyalar = new DirectoryInfo(kaynak).GetFiles("*.docx");

            foreach (FileInfo item in dosyalar)
            {
                item.CopyTo(yol + item.Name);
            }

            taslakYolu = yol + "MP-FR-045 BO İZLEME FORMU (TEKNİK SERVİS) REV (01).docx";

            int sayac = 0;
            foreach (DataGridViewRow item in DtgMalzemeler.Rows)
            {
                string root2 = @"Z:\DTS";
                string subdir = @"Z:\DTS\BAKIM ONARIM ATOLYE\";
                string anadosya = @"Z:\DTS\BAKIM ONARIM ATOLYE\BAKIM ONARIM FORMU\";

                if (!Directory.Exists(root2))
                {
                    Directory.CreateDirectory(root2);
                }
                if (!Directory.Exists(subdir))
                {
                    Directory.CreateDirectory(subdir);
                }
                if (!Directory.Exists(anadosya))
                {
                    Directory.CreateDirectory(anadosya);
                }
                if (IcSiparisler.Count > 0)
                {
                    dosya = anadosya + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + "\\";

                }
                else
                {
                    dosya = anadosya + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + "\\";
                }
                DosyaYollari.Add(dosya);
                Directory.CreateDirectory(dosya);

                Application wApp = new Application();
                Documents wDocs = wApp.Documents;
                object filePath = taslakYolu;

                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["StokNo"].Range.Text = item.Cells["StokNo"].Value.ToString();
                if (arizaDurumu == 0)
                {
                    wBookmarks["Bolge"].Range.Text = "AMBAR";
                }
                else
                {
                    wBookmarks["Bolge"].Range.Text = TxtBolgeAdi.Text;
                }
                wBookmarks["Proje"].Range.Text = TxtProje.Text;
                wBookmarks["Tanim"].Range.Text = item.Cells["Tanim"].Value.ToString();
                wBookmarks["Tarih"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                if (IcSiparisler.Count > 0)
                {
                    wBookmarks["IcSiparisNo"].Range.Text = IcSiparisler[sayac].ToString();
                }
                else
                {
                    wBookmarks["IcSiparisNo"].Range.Text = LblIcSiparisNo.Text;
                }

                wBookmarks["Miktar"].Range.Text = item.Cells["Miktar"].Value.ToString();
                wBookmarks["SeriNo"].Range.Text = item.Cells["SeriNo"].Value.ToString();
                wBookmarks["Tarih1"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih2"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih3"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih4"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih5"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih6"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih7"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");

                //wDoc.SaveAs2(yol + "\\" + TxtIsAkisNoTamamla.Text + ".docx"); // farklı kaydet

                if (IcSiparisler.Count > 0)
                {
                    wDoc.SaveAs2(dosya + "B_O İzleme Formu" + ".docx");
                }
                else
                {
                    wDoc.SaveAs2(dosya + "B_O İzleme Formu" + ".docx");
                }
                wDoc.Close();
                wApp.Quit(false);

                sayac++;
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

        void CreateFileManuel()
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
            var dosyalar = new DirectoryInfo(kaynak).GetFiles("*.docx");

            foreach (FileInfo item in dosyalar)
            {
                item.CopyTo(yol + item.Name);
            }
            taslakYolu = yol + "MP-FR-045 BO İZLEME FORMU (TEKNİK SERVİS) REV (01).docx";
            int sayac = 0;

            foreach (DataGridViewRow item in DtgStokList.Rows)
            {
                if (item.Cells["KayitDurumu"].Value.ConBool() == true)
                {
                    Malzeme malzemeKayit = new Malzeme(item.Cells["KayitDurumu"].Value.ConBool(), item.Cells["StokNo"].Value.ToString(), item.Cells["Tanim"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Durum"].Value.ToString(), item.Cells["Revizyon"].Value.ToString(), item.Cells["Miktar"].Value.ConInt(), item.Cells["TalepTarihi"].Value.ToString());

                    malzemeKayitsSecilenler.Add(malzemeKayit);
                }
            }
            int adet = 1;

            foreach (Malzeme item in malzemeKayitsSecilenler)
            {
                LblIcSiparisManuel.Text = "221RWK" + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("yy") + DateTime.Now.ToString("ff");
                icSiparisNo = LblIcSiparisManuel.Text + "/" + adet;
                IcSiparisler.Add(icSiparisNo);
                adet++;
            }

            foreach (Malzeme item in malzemeKayitsSecilenler)
            {
                string root2 = @"Z:\DTS";
                string subdir = @"Z:\DTS\BAKIM ONARIM ATOLYE\";
                string anadosya = @"Z:\DTS\BAKIM ONARIM ATOLYE\BAKIM ONARIM FORMU\";

                if (!Directory.Exists(root2))
                {
                    Directory.CreateDirectory(root2);
                }
                if (!Directory.Exists(subdir))
                {
                    Directory.CreateDirectory(subdir);
                }
                if (!Directory.Exists(anadosya))
                {
                    Directory.CreateDirectory(anadosya);
                }
                if (IcSiparisler.Count > 0)
                {
                    dosya = anadosya + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + "\\";

                }
                else
                {
                    dosya = anadosya + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + "\\";
                }
                DosyaYollari.Add(dosya);
                Directory.CreateDirectory(dosya);

                Application wApp = new Application();
                Documents wDocs = wApp.Documents;
                object filePath = taslakYolu;

                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["StokNo"].Range.Text = item.StokNo;
                if (arizaDurumu == 0)
                {
                    wBookmarks["Bolge"].Range.Text = "AMBAR";
                }
                else
                {
                    wBookmarks["Bolge"].Range.Text = "YOK";
                }
                wBookmarks["Proje"].Range.Text = CmbProje.Text;
                wBookmarks["Tanim"].Range.Text = item.Tanim;
                wBookmarks["Tarih"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                if (IcSiparisler.Count > 0)
                {
                    wBookmarks["IcSiparisNo"].Range.Text = IcSiparisler[sayac].ToString();
                }
                else
                {
                    wBookmarks["IcSiparisNo"].Range.Text = LblIcSiparisManuel.Text;
                }

                wBookmarks["Miktar"].Range.Text = item.Miktar.ToString();
                wBookmarks["SeriNo"].Range.Text = item.SeriNo;
                wBookmarks["Tarih1"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih2"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih3"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih4"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih5"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih6"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih7"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");

                //wDoc.SaveAs2(yol + "\\" + TxtIsAkisNoTamamla.Text + ".docx"); // farklı kaydet

                if (IcSiparisler.Count > 0)
                {
                    string dosyaYol = dosya + "B_O İzleme Formu" + ".docx";
                    wDoc.SaveAs2(dosyaYol);
                }
                else
                {
                    wDoc.SaveAs2(dosya + "B_O İzleme Formu" + ".docx");
                }
                wDoc.Close();
                wApp.Quit(false);

                sayac++;
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
    }
}
