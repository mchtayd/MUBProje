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

        public object[] infos;
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
            if (infos[0].ConInt() != 25)
            {
                contextMenuStrip1.Items[0].Visible = false;
                contextMenuStrip1.Items[1].Visible = false;
                contextMenuStrip1.Items[2].Visible = false;
            }
            if (infos[0].ConInt() != 25)
            {
                if (infos[0].ConInt() != 35)
                {
                    if (infos[0].ConInt() != 84)
                    {
                        contextMenuStrip1.Items[2].Enabled = false;
                    }
                }
            }
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

            DtgDevamEden.Columns["Id"].HeaderText = "KİMLİK";
            DtgDevamEden.Columns["AbfNo"].HeaderText = "ÜST TAKIM ABF NO";
            DtgDevamEden.Columns["StokNoUst"].HeaderText = "STOK NO";
            DtgDevamEden.Columns["TanimUst"].HeaderText = "TANIM";
            DtgDevamEden.Columns["SeriNoUst"].HeaderText = "SERİ NO";
            DtgDevamEden.Columns["GarantiDurumu"].Visible = false;
            DtgDevamEden.Columns["BildirimNo"].Visible = false;
            DtgDevamEden.Columns["CrmNo"].Visible = false;
            DtgDevamEden.Columns["Kategori"].Visible = false;
            DtgDevamEden.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgDevamEden.Columns["Proje"].Visible = false;
            DtgDevamEden.Columns["BildirilenAriza"].HeaderText = "BİLDİRİLEN ARIZA";
            DtgDevamEden.Columns["IcSiparisNo"].HeaderText = "İÇ SİPARİŞ NO";
            DtgDevamEden.Columns["CekildigiTarih"].HeaderText = "MALZEMENİN ÇEKİLDİĞİ TARİH";
            DtgDevamEden.Columns["SiparisAcmaTarihi"].HeaderText = "SİPARİŞ AÇMA TARİHİ";
            DtgDevamEden.Columns["Modifikasyonlar"].HeaderText = "MODİFİKASYONLAR";
            DtgDevamEden.Columns["Notlar"].HeaderText = "NOTLAR";
            DtgDevamEden.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgDevamEden.Columns["Gecensure"].HeaderText = "GEÇEN SÜRE (GÜN)";
            DtgDevamEden.Columns["AtolyeKategori"].HeaderText = "ATÖLYE KATEGORİ";
            DtgDevamEden.Columns["SiparisNo"].Visible = false;
            DtgDevamEden.Columns["BildirilenAriza"].Visible = false;
            DtgDevamEden.Columns["BulunduguIslemAdimi"].Visible = false;
            DtgDevamEden.Columns["ArizaDurum"].Visible = false;
            DtgDevamEden.Columns["KapatmaTarihi"].Visible = false;
            DtgDevamEden.Columns["DosyaYolu"].Visible = false;

            DtgDevamEden.Columns["Gecensure"].DisplayIndex = 1;
            DtgDevamEden.Columns["IcSiparisNo"].DisplayIndex = 0;
            DtgDevamEden.Columns["StokNoUst"].DisplayIndex = 2;
            DtgDevamEden.Columns["TanimUst"].DisplayIndex = 3;
            DtgDevamEden.Columns["SeriNoUst"].DisplayIndex = 4;
            DtgDevamEden.Columns["AtolyeKategori"].DisplayIndex = 5;
            DtgDevamEden.Columns["IslemAdimi"].DisplayIndex = 6;
            DtgDevamEden.Columns["AbfNo"].DisplayIndex = 7;
            DtgDevamEden.Columns["BolgeAdi"].DisplayIndex = 8;
            DtgDevamEden.Columns["BildirilenAriza"].DisplayIndex = 9;
            DtgDevamEden.Columns["CekildigiTarih"].DisplayIndex = 10;
            DtgDevamEden.Columns["SiparisAcmaTarihi"].DisplayIndex = 11;
            DtgDevamEden.Columns["Modifikasyonlar"].DisplayIndex = 12;
            DtgDevamEden.Columns["Notlar"].DisplayIndex = 13;


            //DtgDevamEden.Columns["IcSiparisNo"].DisplayIndex = 0;
            //DtgDevamEden.Columns["Gecensure"].DisplayIndex = 1;
            //DtgDevamEden.Columns["BolgeAdi"].DisplayIndex = 2;
            //DtgDevamEden.Columns["AbfNo"].DisplayIndex = 3;
            //DtgDevamEden.Columns["BildirimNo"].DisplayIndex = 4;
            //DtgDevamEden.Columns["CrmNo"].DisplayIndex = 5;
            //DtgDevamEden.Columns["Kategori"].DisplayIndex = 6;
            //DtgDevamEden.Columns["Proje"].DisplayIndex = 7;
            //DtgDevamEden.Columns["StokNoUst"].DisplayIndex = 8;
            //DtgDevamEden.Columns["TanimUst"].DisplayIndex = 9;
            //DtgDevamEden.Columns["SeriNoUst"].DisplayIndex = 10;
            //DtgDevamEden.Columns["GarantiDurumu"].DisplayIndex = 11;
            //DtgDevamEden.Columns["IslemAdimi"].DisplayIndex = 12;
            //DtgDevamEden.Columns["AtolyeKategori"].DisplayIndex = 12;

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

        string icSiparisNo = "";
        private void DtgDevamEden_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgDevamEden.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            id = DtgDevamEden.CurrentRow.Cells["Id"].Value.ConInt();
            siparisNo = DtgDevamEden.CurrentRow.Cells["SiparisNo"].Value.ToString();
            abfNo = DtgDevamEden.CurrentRow.Cells["AbfNo"].Value.ConInt(); 
            icSiparisNo = DtgDevamEden.CurrentRow.Cells["IcSiparisNo"].Value.ToString();
            dosyaYolu = DtgDevamEden.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            TxtBildirilenAriza.Text = DtgDevamEden.CurrentRow.Cells["BildirilenAriza"].Value.ToString();
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
            DtgIslemKayitlari.Columns["CalismaSuresi"].HeaderText = "ÇALIŞMA SÜRESİ";

            DtgIslemKayitlari.Columns["CalismaSuresi"].DefaultCellStyle.Format = @"HH:mm:ss";

            foreach (DataGridViewRow row in DtgIslemKayitlari.Rows)
            {
                string value = row.Cells["CalismaSuresi"].Value.ToString();               
                row.Cells["CalismaSuresi"].Value = value.Substring(value.IndexOf(' ') + 1);
            }

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

        private void işlemAdımlarınıGetirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DialogResult dr = MessageBox.Show("Görev Ataması Yapmak İstediğinze Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                GorevAtama();
                DataDisplay();
            }
            
        }
        string GorevAtama()
        {
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "RABİA KIPÇAK", "100-TAKIMIN ÇEKİLMESİ (AMBAR VERİ KAYIT)", DateTime.Now, "ÇEKİM İŞLEMİ TAMAMLANMIŞTIR.", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel);


            GorevAtamaPersonel gorevAtamaPersonel2 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "RABİA KIPÇAK", "200-MODİFİKASYON KONTROLÜ (AMBAR VERİ KAYIT)", DateTime.Now, "UYGULANMASI GEREKEN MODİFİKASYON BULUNMAMAKTADIR.", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel2);



            GorevAtamaPersonel gorevAtamaPersonel3 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "RABİA KIPÇAK", "300-SİPARİŞ OLUŞTURMA (AMBAR VERİ KAYIT)", DateTime.Now, icSiparisNo + " NOLU SİPARİŞ OLUŞTURULMUŞTUR.", "00:25:00".ConOnlyTime());
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel3);



            GorevAtamaPersonel gorevAtamaPersonel4 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "YUNUS KAYNAR", "400-BİLDİRİM ve B/O BAŞLAMA ONAYI (MÜHENDİS)", DateTime.Now, "", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel4);


            string sure = "0" + " Dakika";

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "100-TAKIMIN ÇEKİLMESİ (AMBAR VERİ KAYIT)", sure, DateTime.Now.Date);
            gorevAtamaPersonelManager.Update(gorevAtama);
            GorevAtamaPersonel messege2 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "200-MODİFİKASYON KONTROLÜ (AMBAR VERİ KAYIT)", sure, DateTime.Now.Date);
            gorevAtamaPersonelManager.Update(messege2);
            GorevAtamaPersonel messege3 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "300-SİPARİŞ OLUŞTURMA (AMBAR VERİ KAYIT)", sure, "00:25:00".ConOnlyTime());
            gorevAtamaPersonelManager.Update(messege3);
            return "OK";
        }
        string sure;
        private void işlemAdımSureleriniDuzeltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = DtgDevamEden.CurrentRow.Cells["Id"].Value.ConInt();
            gorevAtamaPersonels = gorevAtamaPersonelManager.GorevAtamaGetList(id);
            List<DateTime> times = new List<DateTime>();
            List<int> Idler = new List<int>();
            foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
            {
                times.Add(item.Tarih);
                Idler.Add(item.Id);
            }
            for (int i = 0; i < times.Count; i++)
            {
                if (i + 1 == times.Count)
                {
                    MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!");
                    return;
                }

                TimeSpan sonuc = times[i + 1] - times[i];

                sure = $"{sonuc.Days} Gün {sonuc.Hours} Saat {sonuc.Minutes} Dakika";
                gorevAtamaPersonelManager.SureDuzelt(Idler[i], sure);

                //string day = sonuc.Days == 0 ? "" : sonuc.Days + " Gün ";


                //sure = $"{day}{sonuc.Hours} Saat {sonuc.Minutes} Dakika";

            }
            
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAtolyeDataGuncelle frmAtolyeDataGuncelle = new FrmAtolyeDataGuncelle();
            frmAtolyeDataGuncelle.id = id;
            frmAtolyeDataGuncelle.ShowDialog();
        }

        private void durumGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (icSiparisNo=="")
            {
                MessageBox.Show("Lütfen öncelikle geçerli bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmBOAtolyeGuncelleme frmBOAtolyeGuncelleme = new FrmBOAtolyeGuncelleme();
            frmBOAtolyeGuncelleme.infos = infos;
            frmBOAtolyeGuncelleme.BtnCancel.Visible = false;
            frmBOAtolyeGuncelleme.TxtIcSiparisNo.Text = id.ToString();
            frmBOAtolyeGuncelleme.personelAd = infos[1].ToString();
            frmBOAtolyeGuncelleme.BulClick();
            frmBOAtolyeGuncelleme.ShowDialog();
        }

        private void BtnVeriDuzelt_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in DtgDevamEden.Rows)
            {
                atolyeManager.AtolyeVeriDuzelt(item.Cells["SiparisNo"].Value.ToString());
            }
            MessageBox.Show("Bilgiler Başarıyla Güncellendi!");
        }

        string Parser(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);

            //here backslash is must to tell that colon is
            //not the part of format, it just a character that we want in output
            return time.ToString(@"hh\:mm\:ss\:fff");
        }
        
        void ToplamlarIslemAdimSureleri()
        {
            int toplamDakika = 0;
            int toplamSaat = 0;
            int toplamGun = 0;

            foreach (DataGridViewRow item in DtgIslemKayitlari.Rows)
            {
                string sure = item.Cells["Sure"].Value.ToString();
                if (sure=="Devam Ediyor")
                {
                    LblIslemAdimSureleri.Text = toplamGun + " Gün " + toplamSaat + " Saat " + toplamDakika + " Dakika";
                    return;
                }

                string[] array = sure.Split(' ');
                if (array.Length==2)
                {
                    return;
                }
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
    }
}
