using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using DataAccess.Concreate.BakimOnarim;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;
using Entity;
using Entity.BakimOnarim;
using Entity.BakimOnarimAtolye;
using Entity.Gecic_Kabul_Ambar;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Gecic_Kabul_Ambar;
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmArizaKayitlariKapatilan : Form
    {
        ArizaKayitManager arizaKayitManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        AbfMalzemeManager abfMalzemeManager;
        StokGirisCikisManager stokGirisCikisManager;
        AtolyeManager atolyeManager;

        List<ArizaKayit> arizaKayits;
        List<GorevAtamaPersonel> gorevAtamaPersonels;
        List<AbfMalzeme> abfMalzemes;
        List<StokGirisCıkıs> stokGirisCikis;
        List<Atolye> atolyes;

        public object[] infos;
        string dosyaYolu, abfNo, bolgeSorumlusu;
        int id, atolyeId;
        int malzemeId;
        string stok, tanim, miktar, birim;
        int rowIndex;
        bool isComplete = false;

        public FrmArizaKayitlariKapatilan()
        {
            InitializeComponent();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
            atolyeManager = AtolyeManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageTamamlananArizalar"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        string bolgeAdi, arizaBildirimTarih, arizayiBildiren, bildirilenAriza, tespitEdilenAriza, garantiDurumu, kategori, bildirimTuru, bildirimNo, okfBildirimNo;
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DtgAtolyeIslemler.DataSource = null;
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            dosyaYolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            abfNo = DtgList.CurrentRow.Cells["AbfFormNo"].Value.ToString();
            bolgeSorumlusu = DtgList.CurrentRow.Cells["AcmaOnayiVeren"].Value.ToString();
            bolgeAdi = DtgList.CurrentRow.Cells["BolgeAdi"].Value.ToString();
            arizaBildirimTarih = DtgList.CurrentRow.Cells["AbTarihSaat"].Value.ToString();
            arizayiBildiren = DtgList.CurrentRow.Cells["AbRutbesi"].Value.ToString() + " " + DtgList.CurrentRow.Cells["ArizaiBildirenPersonel"].Value.ToString();
            bildirilenAriza = DtgList.CurrentRow.Cells["BildirilenAriza"].Value.ToString();
            tespitEdilenAriza = DtgList.CurrentRow.Cells["TespitEdilenAriza"].Value.ToString();
            garantiDurumu = DtgList.CurrentRow.Cells["GarantiDurumu"].Value.ToString();
            kategori = DtgList.CurrentRow.Cells["Kategori"].Value.ToString();
            bildirimTuru = DtgList.CurrentRow.Cells["BildirimTuru"].Value.ToString();
            bildirimNo = DtgList.CurrentRow.Cells["BildirimNo"].Value.ToString();
            okfBildirimNo = DtgList.CurrentRow.Cells["OkfBildirimNo"].Value.ToString();
            LblSeciliAbf.Text = abfNo;
            IslemAdimlariSureleri();
            MalzemeListesi();
            DepoHareketleri();
            AtolyeKayitlari();
            VeriGecmisiFill();
            if (bolgeSorumlusu != infos[1].ToString())
            {
                if (infos[11].ToString() == "YÖNETİCİ" || infos[11].ToString() == "ADMİN" || infos[0].ConInt() == 39)
                {
                    contextMenuStrip1.Items[1].Enabled = true;
                }
                else
                {
                    contextMenuStrip1.Items[1].Enabled = false;
                }
            }
            else
            {
                contextMenuStrip1.Items[1].Enabled = true;
            }
        }
        void AtolyeKayitlari()
        {
            atolyes = atolyeManager.AtolyeAbf(abfNo);
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

        }
        void DepoHareketleri()
        {
            stokGirisCikis = stokGirisCikisManager.AtolyeDepoHareketleri(abfNo);
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
            DtgMalzemeListesi.Columns["Secim"].Visible = false;
            DtgMalzemeListesi.Columns["TakilanTeslimDurum"].DisplayIndex = 26;

            DtgSokulen.DataSource = null;
            DtgSokulen.DataSource = abfMalzemes;

            DtgSokulen.Columns["Id"].Visible = false;
            DtgSokulen.Columns["BenzersizId"].Visible = false;
            DtgSokulen.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgSokulen.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgSokulen.Columns["SokulenSeriNo"].HeaderText = "SERİ NO";
            DtgSokulen.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgSokulen.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgSokulen.Columns["SokulenCalismaSaati"].Visible = false;
            DtgSokulen.Columns["SokulenRevizyon"].HeaderText = "REVİZYON";
            DtgSokulen.Columns["CalismaDurumu"].HeaderText = "ÇALIŞMA DURUMU";
            DtgSokulen.Columns["FizikselDurum"].HeaderText = "FİSİZKSEL DURUM";
            DtgSokulen.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgSokulen.Columns["TakilanStokNo"].Visible = false;
            DtgSokulen.Columns["TakilanTanim"].Visible = false;
            DtgSokulen.Columns["TakilanSeriNo"].Visible = false;
            DtgSokulen.Columns["TakilanMiktar"].Visible = false;
            DtgSokulen.Columns["TakilanBirim"].Visible = false;
            DtgSokulen.Columns["TakilanCalismaSaati"].Visible = false;
            DtgSokulen.Columns["TakilanRevizyon"].Visible = false;
            DtgSokulen.Columns["TeminDurumu"].Visible = false;
            DtgSokulen.Columns["AbfNo"].Visible = false;
            DtgSokulen.Columns["AbTarihSaat"].Visible = false;
            DtgSokulen.Columns["TemineAtilamTarihi"].Visible = false;
            DtgSokulen.Columns["MalzemeDurumu"].Visible = false;
            DtgSokulen.Columns["MalzemeIslemAdimi"].Visible = false;
            DtgSokulen.Columns["SokulenTeslimDurum"].HeaderText = "MALZEMENİN YERİ";
            DtgSokulen.Columns["BolgeAdi"].Visible = false;
            DtgSokulen.Columns["BolgeSorumlusu"].Visible = false;
            DtgSokulen.Columns["YerineMalzemeTakilma"].Visible = false;
            DtgSokulen.Columns["DosyaYolu"].Visible = false;
            DtgSokulen.Columns["AltYukleniciKayit"].Visible = false;
            DtgSokulen.Columns["TakilanTeslimDurum"].Visible = false;
            DtgSokulen.Columns["Secim"].Visible = false;

            DtgTakilan.DataSource = null;
            DtgTakilan.DataSource = abfMalzemes;

            DtgTakilan.Columns["Id"].Visible = false;
            DtgTakilan.Columns["BenzersizId"].Visible = false;
            DtgTakilan.Columns["SokulenStokNo"].Visible = false;
            DtgTakilan.Columns["SokulenTanim"].Visible = false;
            DtgTakilan.Columns["SokulenSeriNo"].Visible = false;
            DtgTakilan.Columns["SokulenMiktar"].Visible = false;
            DtgTakilan.Columns["SokulenBirim"].Visible = false;
            DtgTakilan.Columns["SokulenCalismaSaati"].Visible = false;
            DtgTakilan.Columns["SokulenRevizyon"].Visible = false;
            DtgTakilan.Columns["CalismaDurumu"].Visible = false;
            DtgTakilan.Columns["FizikselDurum"].Visible = false;
            DtgTakilan.Columns["YapilacakIslem"].Visible = false;
            DtgTakilan.Columns["TakilanStokNo"].HeaderText = "STOK NO";
            DtgTakilan.Columns["TakilanTanim"].HeaderText = "TANIM";
            DtgTakilan.Columns["TakilanSeriNo"].HeaderText = "SERİ NO";
            DtgTakilan.Columns["TakilanMiktar"].HeaderText = "MİKTAR";
            DtgTakilan.Columns["TakilanBirim"].HeaderText = "BİRİM";
            DtgTakilan.Columns["TakilanCalismaSaati"].Visible = false;
            DtgTakilan.Columns["TakilanRevizyon"].HeaderText = "REVİZYON";
            DtgTakilan.Columns["TeminDurumu"].Visible = false;
            DtgTakilan.Columns["AbfNo"].Visible = false;
            DtgTakilan.Columns["AbTarihSaat"].Visible = false;
            DtgTakilan.Columns["TemineAtilamTarihi"].Visible = false;
            DtgTakilan.Columns["MalzemeDurumu"].Visible = false;
            DtgTakilan.Columns["MalzemeIslemAdimi"].Visible = false;
            DtgTakilan.Columns["SokulenTeslimDurum"].Visible = false;
            DtgTakilan.Columns["BolgeAdi"].Visible = false;
            DtgTakilan.Columns["BolgeSorumlusu"].Visible = false;
            DtgTakilan.Columns["YerineMalzemeTakilma"].Visible = false;
            DtgTakilan.Columns["DosyaYolu"].Visible = false;
            DtgTakilan.Columns["AltYukleniciKayit"].Visible = false;
            DtgTakilan.Columns["TakilanTeslimDurum"].HeaderText = "MALZEMENİN YERİ";
            DtgTakilan.Columns["Secim"].Visible = false;

        }
        void IslemAdimlariSureleri()
        {
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetList(id, "BAKIM ONARIM");
            List<GorevAtamaPersonel> gorevAtamaPersonels2 = new List<GorevAtamaPersonel>();
            string oncekiAdim = "";
            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                if (oncekiAdim != item.IslemAdimi)
                {
                    gorevAtamaPersonels2.Add(item);
                }
                else
                {
                    if (item.Sure == "Devam Ediyor")
                    {
                        gorevAtamaPersonels2.Add(item);
                    }
                }
                oncekiAdim = item.IslemAdimi;
            }

            DtgIslemKayitlari.DataSource = gorevAtamaPersonels2;

            DtgIslemKayitlari.Columns["Id"].Visible = false;
            DtgIslemKayitlari.Columns["BenzersizId"].Visible = false;
            DtgIslemKayitlari.Columns["Departman"].Visible = false;
            DtgIslemKayitlari.Columns["GorevAtanacakPersonel"].HeaderText = "GÖREV ATANAN PERSONEL";
            DtgIslemKayitlari.Columns["IslemAdimi"].HeaderText = "İŞLEM ADIMI";
            DtgIslemKayitlari.Columns["Tarih"].HeaderText = "TARİH";
            DtgIslemKayitlari.Columns["Sure"].HeaderText = "İŞLEM ADIMI SÜRELERİ";
            DtgIslemKayitlari.Columns["YapilanIslem"].Visible = false;
            DtgIslemKayitlari.Columns["CalismaSuresi"].HeaderText = "ÇALIŞMA SÜRESİ";
            DtgIslemKayitlari.Columns["DevamEdenGorev"].Visible = false;
            DtgIslemKayitlari.Columns["TamamlananGorev"].Visible = false;
            DtgIslemKayitlari.Columns["BeklemeSuresi"].Visible = false;
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

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void FrmArizaKayitlariKapatilan_Load(object sender, EventArgs e)
        {
            if (infos[11].ToString() == "YÖNETİCİ" || infos[11].ToString() == "ADMİN" || infos[0].ConInt() == 39)
            {
                contextMenuStrip1.Items[0].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[0].Enabled = false;
            }
            DataDisplay();
        }

        private void DtgAtolye_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgAtolye.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
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

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmArizaGuncelle frmArizaGuncelle = new FrmArizaGuncelle();
            frmArizaGuncelle.abfNo = abfNo;
            frmArizaGuncelle.id = id;
            frmArizaGuncelle.ShowDialog();
        }

        private void açıklamaNotEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen açıklama yazacağınız arızanın üzerine bir kez sol tık yapıp seçtikten sonra sağ tık yapıp Açıklama/Not Ekle penceresini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmArizaAciklama frmArizaAciklama = new FrmArizaAciklama();
            frmArizaAciklama.infos = infos;
            frmArizaAciklama.arizaId = id;
            frmArizaAciklama.ShowDialog();
            id = 0;
        }


        string sokulenSeriLotNo, sokulenRevizyon, takilanStokNo, takilanTanim, takilanBirim, takilanSeriNo, takilanRevizyon;
        int takilanMiktar;
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

        private void sökülenMalzemeBilgisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle bir arıza seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmSokulenMalzeme frmSokulenMalzeme = new FrmSokulenMalzeme();
            frmSokulenMalzeme.benzersizId = id;
            frmSokulenMalzeme.infos = infos;
            frmSokulenMalzeme.ShowDialog();
        }

        public void Yenilenecekler()
        {
            DataDisplay();
        }
        void DataDisplay()
        {
            arizaKayits = arizaKayitManager.BOTamamlananGetList();
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
            DtgList.Columns["GecenSure"].Visible = false;


            DtgList.Columns["BildirimTuru"].DisplayIndex = 0;
            DtgList.Columns["GecenSure"].DisplayIndex = 1;
            DtgList.Columns["AbfFormNo"].DisplayIndex = 2;
            DtgList.Columns["BildirimNo"].DisplayIndex = 3;
            DtgList.Columns["OkfBildirimNo"].DisplayIndex = 4;
            DtgList.Columns["Kategori"].DisplayIndex = 5;
            DtgList.Columns["BolgeAdi"].DisplayIndex = 6;
            DtgList.Columns["Il"].DisplayIndex = 7;
            DtgList.Columns["Ilce"].DisplayIndex = 8;
            DtgList.Columns["IslemAdimi"].DisplayIndex = 9;
            DtgList.Columns["Proje"].DisplayIndex = 10;
            DtgList.Columns["StokNo"].DisplayIndex = 11;
            DtgList.Columns["Tanim"].DisplayIndex = 12;
            DtgList.Columns["SeriNo"].DisplayIndex = 13;
            DtgList.Columns["GorevAtanacakPersonel"].DisplayIndex = 14;
            DtgList.Columns["TespitEdilenAriza"].DisplayIndex = 15;
            DtgList.Columns["GarantiDurumu"].DisplayIndex = 16;
            DtgList.Columns["IlgiliFirma"].DisplayIndex = 17;
            DtgList.Columns["BildirimMailTarihi"].DisplayIndex = 18;
            DtgList.Columns["BildirilenAriza"].DisplayIndex = 19;
            DtgList.Columns["ArizaiBildirenPersonel"].DisplayIndex = 20;
            DtgList.Columns["AbRutbesi"].DisplayIndex = 21;
            DtgList.Columns["AbGorevi"].DisplayIndex = 22;
            DtgList.Columns["AbTelefon"].DisplayIndex = 23;
            DtgList.Columns["AbTarihSaat"].DisplayIndex = 24;
            DtgList.Columns["ABAlanPersonel"].DisplayIndex = 25;
            DtgList.Columns["BildirimKanali"].DisplayIndex = 26;
            DtgList.Columns["LojistikSorumluPersonel"].DisplayIndex = 27;
            DtgList.Columns["LojRutbesi"].DisplayIndex = 28;
            DtgList.Columns["LojGorevi"].DisplayIndex = 29;
            DtgList.Columns["LojTarihi"].DisplayIndex = 30;
            DtgList.Columns["AcmaOnayiVeren"].DisplayIndex = 31;
            DtgList.Columns["PypNo"].DisplayIndex = 32;
            DtgList.Columns["MalzemeDurum"].DisplayIndex = 33;
        }
        void VeriGecmisiFill()
        {
            StringBuilder strB = new StringBuilder();

            strB.Append("<h4 style='color:DodgerBlue;font-size:15px;font-family: Arial;'><ins>" + bolgeAdi + "</ins></h4>");
            strB.Append("<font style='color:DodgerBlue;font-size:12px;font-family: Arial;'><u><b>" + "ABF NO:" + "</b></u>" + "  ");
            strB.Append("<font style='color:Red;font-size:18px;font-family: Arial;'><u><b>" + abfNo + "</b></u>");
            for (int i = 0; i < gorevAtamaPersonels.Count; i++)
            {

            }
            for (int i = 0; i < gorevAtamaPersonels.Count; i++)
            {
                if (gorevAtamaPersonels[i].IslemAdimi.ToString() == "100_ARIZANIN BİLDİRİLMESİ (MÜŞTERİ)")
                {
                    strB.Append("<br><br><font style='color:DodgerBlue;font-size:12px;font-family: Arial'><u>" + gorevAtamaPersonels[i].IslemAdimi.ToString() + "</u>" + " ");
                    strB.Append("<font style='color:DarkGray;font-size:12px;'>(Otomatik Kayıt)");
                    strB.Append("<br><font style='color:DimGray;font-size:12px;background-color:yellow;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());

                    strB.Append("<br><br><font style='color:Black;font-size:12px;background-color:White;font-family: Arial;'><b>ARIZA BİLDİRİM TARİHİ/SAATİ:</b>");
                    strB.Append("<font style='color:Black;font-size:12px;padding-left:0.5em;font-family: Arial;'>" + arizaBildirimTarih);

                    strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'><b>ARIZAYI BİLDİREN:</b>");
                    strB.Append("<font style='color:Black;font-size:12px;padding-left:0.5em;font-family: Arial;'>" + arizayiBildiren);

                    strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'><b>BİLDİRİLEN ARIZA:</b>");
                    strB.Append("<font style='color:Black;font-size:12px;padding-left:0.5em;font-family: Arial;'>" + bildirilenAriza);


                    strB.Append("<br><br><font style='color:DimGray;font-size:12px;background-color:yellow;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());
                    strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;background-color:white;'>" + "<b> İŞLEM ADIMI</b>" + " ");
                    strB.Append("<font style='color:DodgerBlue;font-size:12px;font-family:'><u>" + gorevAtamaPersonels[i].IslemAdimi.ToString() + "</u>" + " ");
                    strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;'>" + "ADIMINDAN" + " ");
                    strB.Append("<font style='color:DodgerBlue;font-size:12px;font-family: Arial;'><u>" + gorevAtamaPersonels[i + 1].IslemAdimi.ToString() + "</u>" + " ");
                    strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;'>" + "<b>ADIMINA GÜNCELLEMİŞTİR.</b>");
                }

                else if (gorevAtamaPersonels[i].IslemAdimi.ToString() == "200_ARIZA TESPİTİ (FI/FD) (SAHA)")
                {
                    strB.Append("<br><br><font style='color:DodgerBlue;font-size:12px;font-family: Arial'><u>" + gorevAtamaPersonels[i].IslemAdimi.ToString() + "</u>" + " ");
                    //strB.Append("<font style='color:DarkGray;font-size:12px;'>(Otomatik Kayıt)");
                    strB.Append("<br><font style='color:DimGray;font-size:12px;background-color:yellow;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());

                    if (gorevAtamaPersonels[i].YapilanIslem.ToString() != "")
                    {
                        if (gorevAtamaPersonels[i].IslemAdimi.ToString() == gorevAtamaPersonels[i + 1].IslemAdimi.ToString())
                        {
                            strB.Append("<br><br><font style='color:White;font-size:12px;background-color:DarkGoldenrod;font-family: Arial;'><b>AÇIKLAMA:</b>" + " ");
                            strB.Append("<font style='color:DimGray;font-size:12px;background-color:white;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());
                            strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'>" + gorevAtamaPersonels[i].YapilanIslem.ToString());

                        }
                        else
                        {
                            strB.Append("<br><br><font style='color:Black;font-size:12px;background-color:White;font-family: Arial;'><b>ARIZAYA MÜDAHALE TARİH/SAAT:</b>");
                            strB.Append("<font style='color:Black;font-size:12px;padding-left:0.5em;font-family: Arial;'>" + gorevAtamaPersonels[i].Tarih.ToString());

                            strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'><b>ARIZAYA MÜDAHALE EDEN:</b>");
                            strB.Append("<font style='color:Black;font-size:12px;padding-left:0.5em;font-family: Arial;'>" + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());

                            strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'><b>TESPİT EDİLEN ARIZA:</b>");
                            strB.Append("<font style='color:Black;font-size:12px;padding-left:0.5em;font-family: Arial;'>" + tespitEdilenAriza);

                            strB.Append("<br><br><font style='color:Black;font-size:12px;font-family: Arial'><u>" + "<b>ARIZALI TESPİT EDİLEN MALZEMELER</b>" + "</u>" + " ");

                            strB.AppendLine("<html><head><meta charset=utf-8><style>table{padding:10px;font-size:10px;} th,td{padding:8px;}</style></head><body>");
                            rowIndex = 0;
                            for (int j = 0; j < abfMalzemes.Count; j++)
                            {
                                strB.AppendLine("<center><table border='1' cellpadding='0' cellspacing='0'>");
                                strB.AppendLine("<tr>");
                                //create table header
                                for (int j1 = 0; j1 < DtgSokulen.Columns.Count; j1++) { if (DtgSokulen.Columns[j1].Visible == true) { strB.AppendLine("<th align='center' valign='middle'>" + DtgSokulen.Columns[j1].HeaderText + "</th>"); } }
                                //create table body
                                strB.AppendLine("</tr>");
                                for (int j2 = rowIndex; j2 < DtgSokulen.Rows.Count; j2++)
                                {
                                    strB.AppendLine("<tr>");
                                    foreach (DataGridViewCell dgvc in DtgSokulen.Rows[j2].Cells)
                                    {
                                        if (dgvc.OwningColumn.Visible == true)
                                        {
                                            strB.AppendLine("<td align='center' valign='middle'>" + dgvc.Value.ToString() + "</td>");
                                        }
                                    }
                                    strB.AppendLine("</tr>");

                                    if (rowIndex == abfMalzemes.Count - 1) { isComplete = true; break; }

                                    if (rowIndex < abfMalzemes.Count)
                                    {
                                        if (abfMalzemes[j].BenzersizId == abfMalzemes[j + 1].BenzersizId)
                                        {
                                            rowIndex++;
                                            j++;
                                            continue;
                                        }
                                        rowIndex++;
                                        break;
                                    }
                                }
                                strB.AppendLine("</table></center>");
                                if (isComplete)
                                {
                                    break;
                                }

                                strB.AppendLine("<br><br>");
                            }

                            strB.AppendLine("</body></html>");

                            strB.Append("<br><br><font style='color:DimGray;font-size:12px;background-color:yellow;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());
                            strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;background-color:white;'>" + "<b> İŞLEM ADIMI</b>" + " ");
                            strB.Append("<font style='color:DodgerBlue;font-size:12px;font-family:'><u>" + gorevAtamaPersonels[i].IslemAdimi.ToString() + "</u>" + " ");
                            strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;'>" + "ADIMINDAN" + " ");
                            strB.Append("<font style='color:DodgerBlue;font-size:12px;font-family: Arial;'><u>" + gorevAtamaPersonels[i + 1].IslemAdimi.ToString() + "</u>" + " ");
                            strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;'>" + "<b>ADIMINA GÜNCELLEMİŞTİR.</b>");
                        }
                    }
                }

                else if (gorevAtamaPersonels[i].IslemAdimi.ToString() == "400_SİPARİŞ OLUŞTURMA (DTS)")
                {
                    strB.Append("<br><br><font style='color:DodgerBlue;font-size:12px;font-family: Arial'><u>" + gorevAtamaPersonels[i].IslemAdimi.ToString() + "</u>" + " ");
                    strB.Append("<font style='color:DarkGray;font-size:12px;'>(Otomatik Kayıt)");
                    strB.Append("<br><font style='color:DimGray;font-size:12px;background-color:yellow;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());

                    if (gorevAtamaPersonels[i].YapilanIslem.ToString() != "")
                    {
                        if (gorevAtamaPersonels[i].IslemAdimi.ToString() == gorevAtamaPersonels[i + 1].IslemAdimi.ToString())
                        {
                            strB.Append("<br><br><font style='color:White;font-size:12px;background-color:DarkGoldenrod;font-family: Arial;'><b>AÇIKLAMA:</b>" + " ");
                            strB.Append("<font style='color:DimGray;font-size:12px;background-color:white;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());
                            strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'>" + gorevAtamaPersonels[i].YapilanIslem.ToString());

                        }
                        else
                        {
                            strB.Append("<br><br><font style='color:Black;font-size:12px;background-color:White;font-family: Arial;'><b>GARANTİ DURUMU:</b>");
                            strB.Append("<font style='color:Black;font-size:12px;padding-left:0.5em;font-family: Arial;'>" + garantiDurumu);

                            strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'><b>KATEGORİ:</b>");
                            strB.Append("<font style='color:Black;font-size:12px;padding-left:0.5em;font-family: Arial;'>" + kategori);

                            strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'><b>BİLDİRİM TÜRÜ:</b>");
                            strB.Append("<font style='color:Black;font-size:12px;padding-left:0.5em;font-family: Arial;'>" + bildirimTuru);

                            strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'>" + gorevAtamaPersonels[i].YapilanIslem.ToString());

                            strB.Append("<br><br><font style='color:DimGray;font-size:12px;background-color:yellow;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());
                            strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;background-color:white;'>" + "<b> İŞLEM ADIMI</b>" + " ");
                            strB.Append("<font style='color:DodgerBlue;font-size:12px;font-family:'><u>" + gorevAtamaPersonels[i].IslemAdimi.ToString() + "</u>" + " ");
                            strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;'>" + "ADIMINDAN" + " ");
                            strB.Append("<font style='color:DodgerBlue;font-size:12px;font-family: Arial;'><u>" + gorevAtamaPersonels[i + 1].IslemAdimi.ToString() + "</u>" + " ");
                            strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;'>" + "<b>ADIMINA GÜNCELLEMİŞTİR.</b>");

                        }
                    }
                }

                else if (gorevAtamaPersonels[i].IslemAdimi.ToString() == "500_ARIZA BİLDİRİMİ (ASELSAN)")
                {
                    strB.Append("<br><br><font style='color:DodgerBlue;font-size:12px;font-family: Arial'><u>" + gorevAtamaPersonels[i].IslemAdimi.ToString() + "</u>" + " ");
                    strB.Append("<font style='color:DarkGray;font-size:12px;'>(Otomatik Kayıt)");
                    strB.Append("<br><font style='color:DimGray;font-size:12px;background-color:yellow;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());

                    if (gorevAtamaPersonels[i].YapilanIslem.ToString() != "")
                    {
                        if (gorevAtamaPersonels[i].IslemAdimi.ToString() == gorevAtamaPersonels[i + 1].IslemAdimi.ToString())
                        {
                            strB.Append("<br><br><font style='color:White;font-size:12px;background-color:DarkGoldenrod;font-family: Arial;'><b>AÇIKLAMA:</b>" + " ");
                            strB.Append("<font style='color:DimGray;font-size:12px;background-color:white;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());
                            strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'>" + gorevAtamaPersonels[i].YapilanIslem.ToString());

                        }
                        else
                        {
                            strB.Append("<br><br><font style='color:Black;font-size:12px;font-family: Arial;background-color:White'><b>BİLDİRİM NO:</b>");
                            strB.Append("<font style='color:Black;font-size:12px;padding-left:0.5em;font-family: Arial;'>" + bildirimNo);

                            strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'><b>OKF BİLDİRİM NO:</b>");
                            strB.Append("<font style='color:Black;font-size:12px;padding-left:0.5em;font-family: Arial;'>" + okfBildirimNo);

                            strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'>" + gorevAtamaPersonels[i].YapilanIslem.ToString());

                            strB.Append("<br><br><font style='color:DimGray;font-size:12px;background-color:yellow;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());
                            strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;background-color:white;'>" + "<b> İŞLEM ADIMI</b>" + " ");
                            strB.Append("<font style='color:DodgerBlue;font-size:12px;font-family:'><u>" + gorevAtamaPersonels[i].IslemAdimi.ToString() + "</u>" + " ");
                            strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;'>" + "ADIMINDAN" + " ");
                            strB.Append("<font style='color:DodgerBlue;font-size:12px;font-family: Arial;'><u>" + gorevAtamaPersonels[i + 1].IslemAdimi.ToString() + "</u>" + " ");
                            strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;'>" + "<b>ADIMINA GÜNCELLEMİŞTİR.</b>");

                        }
                    }
                }

                else if (gorevAtamaPersonels[i].IslemAdimi.ToString() == "1500_BAKIM ONARIM (SAHA)")
                {
                    strB.Append("<br><br><font style='color:DodgerBlue;font-size:12px;font-family: Arial'><u>" + gorevAtamaPersonels[i].IslemAdimi.ToString() + "</u>" + " ");
                    //strB.Append("<font style='color:DarkGray;font-size:12px;'>(Otomatik Kayıt)");
                    strB.Append("<br><font style='color:DimGray;font-size:12px;background-color:yellow;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());

                    if (gorevAtamaPersonels[i].YapilanIslem.ToString() != "")
                    {
                        if (gorevAtamaPersonels[i].IslemAdimi.ToString() == gorevAtamaPersonels[i + 1].IslemAdimi.ToString())
                        {
                            strB.Append("<br><br><font style='color:White;font-size:12px;background-color:DarkGoldenrod;font-family: Arial;'><b>AÇIKLAMA:</b>" + " ");
                            strB.Append("<font style='color:DimGray;font-size:12px;background-color:white;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());
                            strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'>" + gorevAtamaPersonels[i].YapilanIslem.ToString());

                        }
                        else
                        {
                            strB.Append("<br><br><font style='color:White;font-size:12px;background-color:DarkGoldenrod;font-family: Arial;'><b>AÇIKLAMA:</b>" + " ");
                            strB.Append("<font style='color:DimGray;font-size:12px;background-color:white;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());
                            strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'>" + gorevAtamaPersonels[i].YapilanIslem.ToString());

                            strB.Append("<br><br><font style='color:Black;font-size:12px;font-family: Arial;background-color:white;'><u>" + "<b>TAKILAN MALZEMELER</b>" + "</u>" + " ");

                            strB.AppendLine("<html><head><meta charset=utf-8><style>table{padding:10px;font-size:10px;} th,td{padding:8px;}</style></head><body>");
                            rowIndex = 0;
                            for (int j = 0; j < abfMalzemes.Count; j++)
                            {
                                strB.AppendLine("<center><table border='1' cellpadding='0' cellspacing='0'>");
                                strB.AppendLine("<tr>");
                                //create table header
                                for (int j1 = 0; j1 < DtgTakilan.Columns.Count; j1++) { if (DtgTakilan.Columns[j1].Visible == true) { strB.AppendLine("<th align='center' valign='middle'>" + DtgTakilan.Columns[j1].HeaderText + "</th>"); } }
                                //create table body
                                strB.AppendLine("</tr>");

                                for (int j2 = rowIndex; j2 < DtgTakilan.Rows.Count; j2++)
                                {
                                    strB.AppendLine("<tr>");
                                    foreach (DataGridViewCell dgvc in DtgTakilan.Rows[j2].Cells)
                                    {
                                        if (dgvc.OwningColumn.Visible == true)
                                        {
                                            strB.AppendLine("<td align='center' valign='middle'>" + dgvc.Value.ToString() + "</td>");
                                        }
                                    }
                                    strB.AppendLine("</tr>");

                                    if (rowIndex == abfMalzemes.Count - 1) { isComplete = true; break; }

                                    if (rowIndex < abfMalzemes.Count)
                                    {
                                        if (j + 1 < abfMalzemes.Count)
                                        {
                                            if (abfMalzemes[j].BenzersizId == abfMalzemes[j + 1].BenzersizId)
                                            {
                                                rowIndex++;
                                                j++;
                                                continue;
                                            }
                                            rowIndex++;
                                            break;
                                        }

                                    }
                                }
                                strB.AppendLine("</table></center>");
                                if (isComplete)
                                {
                                    break;
                                }
                                strB.AppendLine("<br><br>");

                            }

                            strB.AppendLine("</body></html>");

                            strB.Append("<br><br><font style='color:DimGray;font-size:12px;background-color:yellow;font-family: Arial;text-align:left;'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());
                            strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;background-color:white;'>" + "<b> İŞLEM ADIMI</b>" + " ");
                            strB.Append("<font style='color:DodgerBlue;font-size:12px;font-family:'><u>" + gorevAtamaPersonels[i].IslemAdimi.ToString() + "</u>" + " ");
                            strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;'>" + "ADIMINDAN" + " ");
                            strB.Append("<font style='color:DodgerBlue;font-size:12px;font-family: Arial;'><u>" + gorevAtamaPersonels[i + 1].IslemAdimi.ToString() + "</u>" + " ");
                            strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;'>" + "<b>ADIMINA GÜNCELLEMİŞTİR.</b>");
                        }
                    }
                }

                else
                {
                    strB.Append("<br><br><font style='color:DodgerBlue;font-size:12px;font-family: Arial;background-color:white;text-align:left;'><u>" + gorevAtamaPersonels[i].IslemAdimi.ToString() + "</u>" + " ");
                    //strB.Append("<font style='color:DarkGray;font-size:12px;'>(Otomatik Kayıt)");
                    strB.Append("<br><font style='color:DimGray;font-size:12px;background-color:yellow;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());

                    if (gorevAtamaPersonels[i].YapilanIslem.ToString() != "")
                    {
                        strB.Append("<br><br><font style='color:White;font-size:12px;background-color:DarkGoldenrod;font-family: Arial;'><b>AÇIKLAMA:</b>" + " ");
                        strB.Append("<font style='color:DimGray;font-size:12px;background-color:white;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());
                        strB.Append("<br><font style='color:Black;font-size:12px;font-family: Arial;'>" + gorevAtamaPersonels[i].YapilanIslem.ToString());

                        if (i + 1 < gorevAtamaPersonels.Count)
                        {
                            if (gorevAtamaPersonels[i].IslemAdimi.ToString() != gorevAtamaPersonels[i + 1].IslemAdimi.ToString())
                            {
                                strB.Append("<br><br><font style='color:DimGray;font-size:12px;background-color:yellow;font-family: Arial'>" + gorevAtamaPersonels[i].Tarih.ToString() + " " + gorevAtamaPersonels[i].GorevAtanacakPersonel.ToString());
                                strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;background-color:white;'>" + "<b> İŞLEM ADIMI</b>" + " ");
                                strB.Append("<font style='color:DodgerBlue;font-size:12px;font-family:'><u>" + gorevAtamaPersonels[i].IslemAdimi.ToString() + "</u>" + " ");
                                strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;'>" + "ADIMINDAN" + " ");
                                strB.Append("<font style='color:DodgerBlue;font-size:12px;font-family: Arial;'><u>" + gorevAtamaPersonels[i + 1].IslemAdimi.ToString() + "</u>" + " ");
                                strB.Append("<font style='color:Black;font-size:12px;font-family: Arial;'>" + "<b>ADIMINA GÜNCELLEMİŞTİR.</b>");

                            }
                        }
                    }
                }

            }
            BrowserVeriGecmis.DocumentText = strB.ToString();

        }

    }
}
