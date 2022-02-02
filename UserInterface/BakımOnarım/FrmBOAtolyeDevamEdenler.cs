using Business.Concreate;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using DataAccess.Concreate.BakimOnarimAtolye;
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
    public partial class FrmBOAtolyeDevamEdenler : Form
    {
        AtolyeManager atolyeManager;
        AtolyeMalzemeManager atolyeMalzemeManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        AtolyeAltMalzemeManager atolyeAltMalzemeManager;
        StokGirisCikisManager stokGirisCikisManager;


        List<StokGirisCıkıs> stokGirisCikis;
        List<AtolyeAltMalzeme> atolyeAltMalzemes;
        List<GorevAtamaPersonel> gorevAtamaPersonels;
        List<Atolye> atolyes;
        string siparisNo, dosyaYolu;
        int abfNo, id;
        public FrmBOAtolyeDevamEdenler()
        {
            InitializeComponent();
            atolyeManager = AtolyeManager.GetInstance();
            atolyeMalzemeManager = AtolyeMalzemeManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            atolyeAltMalzemeManager = AtolyeAltMalzemeManager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageBODevamEdenler"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        private void FrmBOAtolyeDevamEdenler_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        public void Yenilenecekler()
        {
            DataDisplay();
        }
        void DataDisplay()
        {
            atolyes = atolyeManager.GetList(1);
            dataBinder.DataSource = atolyes.ToDataTable();
            DtgDevamEden.DataSource = dataBinder;

            DtgDevamEden.Columns["Id"].Visible = false;
            DtgDevamEden.Columns["AbfNo"].HeaderText = "ÜST TAKIM ABF NO";
            DtgDevamEden.Columns["StokNoUst"].HeaderText = "STOK NO";
            DtgDevamEden.Columns["TanimUst"].HeaderText = "TANIM";
            DtgDevamEden.Columns["SeriNoUst"].HeaderText = "SERİ NO";
            DtgDevamEden.Columns["GarantiDurumu"].HeaderText = "GARANTİ DURUMU";
            DtgDevamEden.Columns["BildirimNo"].HeaderText = "ÜST TAKIM BİLDİRİM NO";
            DtgDevamEden.Columns["CrmNo"].HeaderText = "ÜST TAKIM CRM NO";
            DtgDevamEden.Columns["Kategori"].HeaderText = "KATEGORİ";
            DtgDevamEden.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgDevamEden.Columns["Proje"].HeaderText = "PROJE";
            DtgDevamEden.Columns["BildirilenAriza"].HeaderText = "BİLDİRİLEN ARIZA";
            DtgDevamEden.Columns["IcSiparisNo"].HeaderText = "İÇ SİPARİŞ NO";
            DtgDevamEden.Columns["CekildigiTarih"].HeaderText = "MALZEMENİN ÇEKİLDİĞİ TARİH";
            DtgDevamEden.Columns["SiparisAcmaTarihi"].HeaderText = "SİPARİŞ AÇMA TARİHİ";
            DtgDevamEden.Columns["Modifikasyonlar"].HeaderText = "MODİFİKASYONLAR";
            DtgDevamEden.Columns["Notlar"].HeaderText = "NOTLAR";
            DtgDevamEden.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgDevamEden.Columns["Gecensure"].HeaderText = "GEÇEN SÜRE (GÜN)";
            DtgDevamEden.Columns["SiparisNo"].Visible = false;
            DtgDevamEden.Columns["BildirilenAriza"].Visible = false;
            DtgDevamEden.Columns["BulunduguIslemAdimi"].Visible = false;
            DtgDevamEden.Columns["ArizaDurum"].Visible = false;
            DtgDevamEden.Columns["KapatmaTarihi"].Visible = false;
            DtgDevamEden.Columns["DosyaYolu"].Visible = false;


            DtgDevamEden.Columns["IcSiparisNo"].DisplayIndex = 0;
            DtgDevamEden.Columns["Gecensure"].DisplayIndex = 1;
            DtgDevamEden.Columns["BolgeAdi"].DisplayIndex = 2;
            DtgDevamEden.Columns["AbfNo"].DisplayIndex = 3;
            DtgDevamEden.Columns["BildirimNo"].DisplayIndex = 4;
            DtgDevamEden.Columns["CrmNo"].DisplayIndex = 5;
            DtgDevamEden.Columns["Kategori"].DisplayIndex = 6;
            DtgDevamEden.Columns["Proje"].DisplayIndex = 7;
            DtgDevamEden.Columns["StokNoUst"].DisplayIndex = 8;
            DtgDevamEden.Columns["TanimUst"].DisplayIndex = 9;
            DtgDevamEden.Columns["SeriNoUst"].DisplayIndex = 10;
            DtgDevamEden.Columns["GarantiDurumu"].DisplayIndex = 11;
            DtgDevamEden.Columns["IslemAdimi"].DisplayIndex = 12;

            TxtTop.Text = DtgDevamEden.RowCount.ToString();
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

        string icSiparisNo;
        private void DtgDevamEden_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgDevamEden.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            id = DtgDevamEden.CurrentRow.Cells["Id"].Value.ConInt();
            siparisNo = DtgDevamEden.CurrentRow.Cells["SiparisNo"].Value.ToString();
            abfNo = DtgDevamEden.CurrentRow.Cells["AbfNo"].Value.ConInt();
            icSiparisNo = DtgDevamEden.CurrentRow.Cells["IcSiparisNo"].Value.ToString();
            dosyaYolu = DtgDevamEden.CurrentRow.Cells["DosyaYolu"].Value.ToString();

            //MalzemeCek();
            DataDisplayAltMalzeme();
            IslemAdimlariSureleri();
            DepoHareketleri();
            webBrowser1.Navigate(dosyaYolu);

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

        void MalzemeCek()
        {
            DtgMalzemeler.DataSource = atolyeMalzemeManager.GetList(abfNo);

            DtgMalzemeler.Columns["Id"].Visible = false;
            DtgMalzemeler.Columns["FormNo"].Visible = false;
            DtgMalzemeler.Columns["StokNo"].HeaderText = "STOK NO";
            DtgMalzemeler.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeler.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgMalzemeler.Columns["Durum"].HeaderText = "DURUM";
            DtgMalzemeler.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgMalzemeler.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzemeler.Columns["TalepTarihi"].HeaderText = "TALEP TARİHİ";
            DtgMalzemeler.Columns["SiparisNo"].Visible = false;

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
            DtgIslemKayitlari.Columns["IscilikSuresi"].HeaderText = "İŞÇİLİK SÜRESİ";
            Toplamlar();
            ToplamlarIslemAdimSureleri();
        }

        private void DtgDevamEden_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgDevamEden.FilterString;
            TxtTop.Text = DtgDevamEden.RowCount.ToString();
        }

        private void DtgDevamEden_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgDevamEden.SortString;
        }

        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgIslemKayitlari.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgIslemKayitlari.Rows[i].Cells[8].Value);

            }
            LblGenelTop.Text = toplam.ToString() + " Saat";
        }
        void ToplamlarIslemAdimSureleri()
        {
            double toplamDakika = 0;
            double toplamSaat = 0;
            double toplamGun = 0;

            foreach (DataGridViewRow item in DtgIslemKayitlari.Rows)
            {
                string sure = item.Cells["Sure"].Value.ToString();

                string[] array = sure.Split(' ');
                if (array[1].ToString()=="Dakika")
                {
                    toplamDakika += array[0].ConDouble();
                }
                
                if (array.Length > 2)
                {
                    if (array[1].ToString() == "Saat")
                    {
                        toplamSaat += array[0].ConDouble();
                        toplamDakika += array[2].ConDouble();
                    }
                    
                    if (array.Length > 4)
                    {
                        if (array[1].ToString() == "Gün")
                        {
                            toplamGun += array[0].ConDouble();
                            toplamSaat += array[2].ConDouble();
                            toplamDakika += array[4].ConDouble();
                        }
                        
                    }
                }
            }

            LblIslemAdimSureleri.Text = toplamDakika.ToString() + " Dakika";

            if (toplamSaat != 0)
            {
                LblIslemAdimSureleri.Text = toplamSaat.ToString() + " Saat " + toplamDakika.ToString() + " Dakika";
            }
            if (toplamGun != 0)
            {
                LblIslemAdimSureleri.Text = toplamGun.ToString() + " Gün " + toplamSaat.ToString() + " Saat " + toplamDakika.ToString() + " Dakika";
            }
        }
    }
}
