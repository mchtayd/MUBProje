using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.EMMA;
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

namespace UserInterface.BakımOnarım
{
    public partial class FrmGorevBilgileri : Form
    {
        public object[] infos;
        ArizaKayitManager arizaKayitManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        StokGirisCikisManager stokGirisCikisManager;
        AbfMalzemeManager abfMalzemeManager;
        AtolyeManager atolyeManager;
        List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
        List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
        List<StokGirisCıkıs> stokGirisCikis = new List<StokGirisCıkıs>();
        List<Atolye> atolyes = new List<Atolye>();
        public int abfNo;
        int id, atolyeId, malzemeId;
        string dosyaYolu = "";
        string miktar, stok, tanim, birim, sokulenSeriLotNo, sokulenRevizyon, takilanStokNo, takilanSeriNo, takilanRevizyon, takilanTanim, takilanBirim; int takilanMiktar;

        public FrmGorevBilgileri()
        {
            InitializeComponent();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
            atolyeManager = AtolyeManager.GetInstance();
        }

        private void TxtBildirilenAriza_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TxtTespitEdilenAriza_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FrmGorevBilgileri_Load(object sender, EventArgs e)
        {
            DataFill();
        }
        void DataFill()
        {
            ArizaKayit arizaKayit = arizaKayitManager.Get(abfNo);
            if (arizaKayit==null)
            {
                MessageBox.Show("Arıza kaydına ulaşılamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            id = arizaKayit.Id;
            dosyaYolu = arizaKayit.DosyaYolu;
            LblIsAkisNo.Text = arizaKayit.IsAkisNo.ToString();
            LblAbfNo.Text = arizaKayit.AbfFormNo.ToString();
            LblIslemAdimi.Text = arizaKayit.IslemAdimi;
            LblUsBolgesi.Text = arizaKayit.BolgeAdi;
            LblPdl.Text = arizaKayit.Proje;
            LblBildirimNo.Text = arizaKayit.BildirimNo;
            LblOkfBildirimNo.Text = arizaKayit.OkfBildirimNo;
            TxtBildirilenAriza.Text = arizaKayit.BildirilenAriza;
            LblBirlikPersoneli.Text = arizaKayit.ArizaiBildirenPersonel;
            LblRutbesi.Text = arizaKayit.AbRutbesi;
            LblPersonelGorev.Text = arizaKayit.AbGorevi;
            LblPersonelTelefon.Text = arizaKayit.AbTelefon;
            LblArizaTarihi.Text = arizaKayit.AbTarihSaat.ToString("g");
            LblGarantiDurumu.Text = arizaKayit.GarantiDurumu;
            LblKayitYapan.Text = arizaKayit.ABAlanPersonel;
            TxtTespitEdilenAriza.Text = arizaKayit.TespitEdilenAriza;
            LbStokNo.Text = arizaKayit.StokNo;
            LblTanim.Text = arizaKayit.Tanim;
            LblSeriNo.Text = arizaKayit.SeriNo;
            IslemAdimlariSureleri();
            MalzemeListesi();
            DepoHareketleri();
            AtolyeKayitlari();
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
            DtgIslemKayitlari.Columns["DevamEdenGorev"].Visible = false;
            DtgIslemKayitlari.Columns["TamamlananGorev"].Visible = false;
            DtgIslemKayitlari.Columns["BeklemeSuresi"].Visible = false;

            DtgIslemKayitlari.Columns["CalismaSuresi"].DefaultCellStyle.Format = @"HH:mm:ss";

            foreach (DataGridViewRow row in DtgIslemKayitlari.Rows)
            {
                string value = row.Cells["CalismaSuresi"].Value.ToString();
                row.Cells["CalismaSuresi"].Value = value.Substring(value.IndexOf(' ') + 1);
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
        void DepoHareketleri()
        {
            stokGirisCikis = stokGirisCikisManager.AtolyeDepoHareketleri(abfNo.ToString());
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
            atolyes = atolyeManager.AtolyeAbf(abfNo.ToString());
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
    }
}
