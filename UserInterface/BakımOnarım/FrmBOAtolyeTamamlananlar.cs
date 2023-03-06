using Business.Concreate;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarimAtolye;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmBOAtolyeTamamlananlar : Form
    {

        AtolyeManager atolyeManager;
        AtolyeAltMalzemeManager atolyeAltMalzemeManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        StokGirisCikisManager stokGirisCikisManager;


        List<StokGirisCıkıs> stokGirisCikis;
        List<Atolye> atolyes = new List<Atolye>();
        List<GorevAtamaPersonel> gorevAtamaPersonels;
        List<AtolyeAltMalzeme> atolyeAltMalzemes = new List<AtolyeAltMalzeme>();

        int id, abfNo;
        string siparisNo, icSiparisNo, dosyaYolu, sure;
        public FrmBOAtolyeTamamlananlar()
        {
            InitializeComponent();
            atolyeManager = AtolyeManager.GetInstance();
            atolyeAltMalzemeManager = AtolyeAltMalzemeManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
        }

        private void FrmBOAtolyeTamamlananlar_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        public void Yenilenecekler()
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageBOTamamlananlar"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void DataDisplay()
        {
            atolyes = atolyeManager.GetList(0);
            dataBinder.DataSource = atolyes.ToDataTable();
            DtgTamamlanan.DataSource = dataBinder;

            DtgTamamlanan.Columns["Id"].Visible = false;
            DtgTamamlanan.Columns["AbfNo"].HeaderText = "ÜST TAKIM ABF NO";
            DtgTamamlanan.Columns["StokNoUst"].HeaderText = "STOK NO";
            DtgTamamlanan.Columns["TanimUst"].HeaderText = "TANIM";
            DtgTamamlanan.Columns["SeriNoUst"].HeaderText = "SERİ NO";
            DtgTamamlanan.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgTamamlanan.Columns["BildirimNo"].HeaderText = "ÜST TAKIM BİLDİRİM NO";
            DtgTamamlanan.Columns["CrmNo"].HeaderText = "ÜST TAKIM CRM NO";
            DtgTamamlanan.Columns["Kategori"].HeaderText = "KATEGORİ";
            DtgTamamlanan.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgTamamlanan.Columns["Proje"].HeaderText = "PROJE";
            DtgTamamlanan.Columns["BildirilenAriza"].HeaderText = "BİLDİRİLEN ARIZA";
            DtgTamamlanan.Columns["IcSiparisNo"].HeaderText = "İÇ SİPARİŞ NO";
            DtgTamamlanan.Columns["CekildigiTarih"].HeaderText = "MALZEMENİN ÇEKİLDİĞİ TARİH";
            DtgTamamlanan.Columns["SiparisAcmaTarihi"].HeaderText = "SİPARİŞ AÇMA TARİHİ";
            DtgTamamlanan.Columns["Modifikasyonlar"].HeaderText = "MODİFİKASYONLAR";
            DtgTamamlanan.Columns["Notlar"].HeaderText = "NOTLAR";
            DtgTamamlanan.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgTamamlanan.Columns["Gecensure"].Visible = false;
            DtgTamamlanan.Columns["KapatmaTarihi"].HeaderText = "KAPATMA TARİHİ";
            DtgTamamlanan.Columns["AtolyeKategori"].HeaderText = "ATÖLYE KATEGORİ";
            DtgTamamlanan.Columns["SiparisNo"].Visible = false;
            DtgTamamlanan.Columns["BildirilenAriza"].Visible = false;
            DtgTamamlanan.Columns["BulunduguIslemAdimi"].Visible = false;
            DtgTamamlanan.Columns["ArizaDurum"].Visible = false;
            DtgTamamlanan.Columns["DosyaYolu"].Visible = false;


            DtgTamamlanan.Columns["IcSiparisNo"].DisplayIndex = 0;
            DtgTamamlanan.Columns["Gecensure"].DisplayIndex = 1;
            DtgTamamlanan.Columns["BolgeAdi"].DisplayIndex = 2;
            DtgTamamlanan.Columns["AbfNo"].DisplayIndex = 3;
            DtgTamamlanan.Columns["BildirimNo"].DisplayIndex = 4;
            DtgTamamlanan.Columns["CrmNo"].DisplayIndex = 5;
            DtgTamamlanan.Columns["Kategori"].DisplayIndex = 6;
            DtgTamamlanan.Columns["Proje"].DisplayIndex = 7;
            DtgTamamlanan.Columns["StokNoUst"].DisplayIndex = 8;
            DtgTamamlanan.Columns["TanimUst"].DisplayIndex = 9;
            DtgTamamlanan.Columns["SeriNoUst"].DisplayIndex = 10;
            DtgTamamlanan.Columns["GarantiDurumu"].DisplayIndex = 11;
            DtgTamamlanan.Columns["IslemAdimi"].DisplayIndex = 12;

            TxtTop.Text = DtgTamamlanan.RowCount.ToString();
        }

        private void DtgTamamlanan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgTamamlanan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            id = DtgTamamlanan.CurrentRow.Cells["Id"].Value.ConInt();
            siparisNo = DtgTamamlanan.CurrentRow.Cells["SiparisNo"].Value.ToString();
            abfNo = DtgTamamlanan.CurrentRow.Cells["AbfNo"].Value.ConInt();
            icSiparisNo = DtgTamamlanan.CurrentRow.Cells["IcSiparisNo"].Value.ToString();
            dosyaYolu = DtgTamamlanan.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            //MalzemeCek();
            DataDisplayAltMalzeme();
            IslemAdimlariSureleri();
            DepoHareketleri();
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
            
        }
        void DataDisplayAltMalzeme()
        {
            atolyeAltMalzemes = atolyeAltMalzemeManager.GetList(siparisNo);
            dataBinder2.DataSource = atolyeAltMalzemes.ToDataTable();
            DtgMalzemeler.DataSource = dataBinder2;

            DtgMalzemeler.Columns["Id"].Visible = false;
            DtgMalzemeler.Columns["StokNo"].HeaderText = "STOK NO";
            DtgMalzemeler.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeler.Columns["SokulenSeriNo"].HeaderText = "SÖKÜLEN SERİ NO";
            DtgMalzemeler.Columns["TakilanSeriNo"].HeaderText = "TAKILAN SERİ NO";
            DtgMalzemeler.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzemeler.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzemeler.Columns["MalzemeyeYapilanIslem"].HeaderText = "MALZEMEYE YAPILAN İŞLEM";
            DtgMalzemeler.Columns["SiparisNo"].Visible = false;
        }
        void DepoHareketleri()
        {
            stokGirisCikis = stokGirisCikisManager.AtolyeDepoHareketleri(icSiparisNo);
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
        string bulunduguIslemAdimi = "";
        DateTime birOncekiTarih;

        private void DtgTamamlanan_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgTamamlanan.FilterString;
            TxtTop.Text = DtgTamamlanan.RowCount.ToString();
        }

        private void DtgTamamlanan_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgTamamlanan.SortString;
        }

        private void işlemAdımlarınıDuzeltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = DtgTamamlanan.CurrentRow.Cells["Id"].Value.ConInt();
            gorevAtamaPersonels = gorevAtamaPersonelManager.GorevAtamaGetList(id);

            GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.Get(id, "BAKIM ONARIM ATOLYE");

            bulunduguIslemAdimi = gorevAtamaPersonel.IslemAdimi;
            birOncekiTarih = gorevAtamaPersonel.Tarih;
            id = gorevAtamaPersonel.Id;

            if (bulunduguIslemAdimi== "1600-SİPARİŞ KAPATMA  (AMBAR VERİ KAYIT)")
            {
                TimeSpan sonuc = DateTime.Now - birOncekiTarih;

                sure = $"{sonuc.Days} Gün {sonuc.Hours} Saat {sonuc.Minutes} Dakika";
                gorevAtamaPersonelManager.SureDuzelt(id, sure);
            }
            
        }

        void IslemAdimlariSureleri()
        {
            gorevAtamaPersonels = gorevAtamaPersonelManager.GetList(id, "BAKIM ONARIM ATOLYE");
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

            ToplamlarIscilik();
            ToplamlarIslemAdimSureleri();
        }
        void ToplamlarIscilik()
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
                string islemAdimi = item.Cells["IslemAdimi"].Value.ToString();
                

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

                if (islemAdimi == "1600-SİPARİŞ KAPATMA  (AMBAR VERİ KAYIT)")
                {
                    LblIslemAdimSureleri.Text = toplamGun + " Gün " + toplamSaat + " Saat " + toplamDakika + " Dakika";
                    return;
                }
            }
        }
    }
}
