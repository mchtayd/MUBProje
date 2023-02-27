using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
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
using UserInterface.STS;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmDevam : Form
    {
        YurtIciGorevManager yurtIciGorevManager;
        SehiriciGorevManager sehiriciGorevManager;
        IzinManager izinManager;
        YurtDisiGorevManager yurtDisiGorevManager;
        AracBakimManager aracBakimManager;
        public FrmDevam()
        {
            InitializeComponent();
            yurtIciGorevManager = YurtIciGorevManager.GetInstance();
            sehiriciGorevManager = SehiriciGorevManager.GetInstance();
            izinManager = IzinManager.GetInstance();
            yurtDisiGorevManager = YurtDisiGorevManager.GetInstance();
            aracBakimManager = AracBakimManager.GetInstance();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDevam"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmDevam_Load(object sender, EventArgs e)
        {
            YurtIciGorevList();
            SehirIciGorevList();
            IzinList();
            YurtDisiGorevList();
            AracBakimList();
            //Gorunum();
        }
        void Gorunum()
        {
            Adlandir();
            if (DtgYurtIciGorev.RowCount == 0)
            {
                groupBox1.Visible = false;
            }
            if (DtgIzin.RowCount == 0)
            {
                groupBox4.Visible = false;
            }
            if (DtgSehirIciGorev.RowCount == 0)
            {
                groupBox3.Visible = false;
            }
            if (DtgYurtDisiGorev.RowCount == 0)
            {
                groupBox2.Visible = false;
            }
            if (DtgBakimdakiAraclar.RowCount == 0)
            {
                groupBox5.Visible = false;
            }
        }
        void Adlandir()
        {
            groupBox4.Text = "İZİNLİ PERSONEL BİLGİLERİ" + " ( " + DtgIzin.RowCount.ToString() + " )";
            groupBox1.Text = "YURT İÇİ GÖREVİNDE BULUNAN PERSONEL BİLGİLERİ" + " ( " + DtgYurtIciGorev.RowCount.ToString() + " )";
            groupBox3.Text = "ŞEHİR İÇİ GÖREVİNDE BULUNAN PERSONEL BİLGİLERİ" + " ( " + DtgSehirIciGorev.RowCount.ToString() + " )";
            groupBox2.Text = "YURT DIŞI GÖREVİNDE BULUNAN PERSONEL BİLGİLERİ" + " ( " + DtgYurtDisiGorev.RowCount.ToString() + " )";
            groupBox5.Text = "BAKIMDAKİ ARAÇLAR" + " ( " + DtgBakimdakiAraclar.RowCount.ToString() + " )";
        }
        void YurtIciGorevList()
        {
            string islemadimi = "1.ADIM:GÖREV OLUŞTURULDU";

            dataBinder.DataSource = yurtIciGorevManager.DevamDevamsizlik(islemadimi);
            DtgYurtIciGorev.DataSource = dataBinder;

            DtgYurtIciGorev.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgYurtIciGorev.Columns["Bitistarihi"].HeaderText = "BİTİŞ TARİHİ";
            DtgYurtIciGorev.Columns["Adsoyad"].HeaderText = "ADI SOYADI";
            DtgYurtIciGorev.Columns["Toplamsure"].HeaderText = "TOPLAM SÜRE";
            DtgYurtIciGorev.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgYurtIciGorev.Columns["KalanSure"].HeaderText = "KALAN SÜRE";

            DtgYurtIciGorev.Columns["Adsoyad"].DisplayIndex = 0;
            DtgYurtIciGorev.Columns["Unvani"].DisplayIndex = 1;
            DtgYurtIciGorev.Columns["Baslamatarihi"].DisplayIndex = 2;
            DtgYurtIciGorev.Columns["Bitistarihi"].DisplayIndex = 3;
            DtgYurtIciGorev.Columns["Toplamsure"].DisplayIndex = 4;
            DtgYurtIciGorev.Columns["KalanSure"].DisplayIndex = 9;

            DtgYurtIciGorev.Columns["Id"].Visible = false;
            DtgYurtIciGorev.Columns["Isakisno"].Visible = false;
            DtgYurtIciGorev.Columns["Gorevemrino"].Visible = false;
            DtgYurtIciGorev.Columns["Gorevinkonusu"].Visible = false;
            DtgYurtIciGorev.Columns["Proje"].Visible = false;
            DtgYurtIciGorev.Columns["Gidilecekyer"].Visible = false;
            DtgYurtIciGorev.Columns["Butcekodu"].Visible = false;
            DtgYurtIciGorev.Columns["Siparisno"].Visible = false;
            DtgYurtIciGorev.Columns["Masrafyerino"].Visible = false;
            DtgYurtIciGorev.Columns["Masrafyeri"].Visible = false;
            DtgYurtIciGorev.Columns["Ulasimgidis"].Visible = false;
            DtgYurtIciGorev.Columns["Ulasimgorevyeri"].Visible = false;
            DtgYurtIciGorev.Columns["Ulasimdonus"].Visible = false;
            DtgYurtIciGorev.Columns["Konaklamagun"].Visible = false;
            DtgYurtIciGorev.Columns["Konaklamaguntl"].Visible = false;
            DtgYurtIciGorev.Columns["Konaklamatoplam"].Visible = false;
            DtgYurtIciGorev.Columns["Kiralamagun"].Visible = false;
            DtgYurtIciGorev.Columns["Kiralamaguntl"].Visible = false;
            DtgYurtIciGorev.Columns["Kiralamayakit"].Visible = false;
            DtgYurtIciGorev.Columns["Kiralamatoplam"].Visible = false;
            DtgYurtIciGorev.Columns["Seyahatavansgun"].Visible = false;
            DtgYurtIciGorev.Columns["Seyahatguntl"].Visible = false;
            DtgYurtIciGorev.Columns["Seyahattoplam"].Visible = false;
            DtgYurtIciGorev.Columns["Ucakbileti"].Visible = false;
            DtgYurtIciGorev.Columns["Otobusbileti"].Visible = false;
            DtgYurtIciGorev.Columns["Geneltoplam"].Visible = false;
            DtgYurtIciGorev.Columns["Plaka"].Visible = false;
            DtgYurtIciGorev.Columns["Cikiskm"].Visible = false;
            DtgYurtIciGorev.Columns["Donuskm"].Visible = false;
            DtgYurtIciGorev.Columns["Toplamkm"].Visible = false;
            DtgYurtIciGorev.Columns["Geneltoplam"].Visible = false;
            DtgYurtIciGorev.Columns["Islemadimi"].Visible = false;
            DtgYurtIciGorev.Columns["Dosyayolu"].Visible = false;
            DtgYurtIciGorev.Columns["Sayfa"].Visible = false;
            DtgYurtIciGorev.Columns["KonaklamaTuru"].Visible = false;
            DtgYurtIciGorev.Columns["HarcirahGun"].Visible = false;
            DtgYurtIciGorev.Columns["HarcirahGunTl"].Visible = false;
            DtgYurtIciGorev.Columns["HarcirahToplam"].Visible = false;
            DtgYurtIciGorev.Columns["IaseGun"].Visible = false;
            DtgYurtIciGorev.Columns["IaseGunTl"].Visible = false;
            DtgYurtIciGorev.Columns["IaseToplam"].Visible = false;
        }
        void SehirIciGorevList()
        {
            string islemadimi = "Görev Devam Ediyor";

            dataBinder2.DataSource = sehiriciGorevManager.DevamDevamsizlik(islemadimi);
            DtgSehirIciGorev.DataSource = dataBinder2;
            

            DtgSehirIciGorev.Columns["Id"].Visible = false;
            DtgSehirIciGorev.Columns["Isakisno"].Visible = false;
            DtgSehirIciGorev.Columns["Gidilecekyer"].Visible = false;
            DtgSehirIciGorev.Columns["Gorevinkonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgSehirIciGorev.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgSehirIciGorev.Columns["Bitistarihi"].Visible = false;
            DtgSehirIciGorev.Columns["Toplamsure"].Visible = false;
            DtgSehirIciGorev.Columns["Siparisno"].Visible = false;
            DtgSehirIciGorev.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgSehirIciGorev.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgSehirIciGorev.Columns["Gecensure"].HeaderText = "GEÇEN SÜRE";
            DtgSehirIciGorev.Columns["Masrafyerno"].Visible = false;
            DtgSehirIciGorev.Columns["Masrafyeri"].Visible = false;
            DtgSehirIciGorev.Columns["Proje"].Visible = false;
            DtgSehirIciGorev.Columns["Islemadimi"].Visible = false;
            DtgSehirIciGorev.Columns["Personelid"].Visible = false;
            DtgSehirIciGorev.Columns["Sayfa"].Visible = false;

            DtgSehirIciGorev.Columns["Adsoyad"].DisplayIndex = 0;
            DtgSehirIciGorev.Columns["Unvani"].DisplayIndex = 1;
            DtgSehirIciGorev.Columns["Baslamatarihi"].DisplayIndex = 4;
            DtgSehirIciGorev.Columns["Bitistarihi"].DisplayIndex = 3;
            DtgSehirIciGorev.Columns["Toplamsure"].DisplayIndex = 5;
            DtgSehirIciGorev.Columns["Gorevinkonusu"].DisplayIndex = 2;
            DtgSehirIciGorev.Columns["Gecensure"].DisplayIndex = 15;
        }
        void IzinList()
        {
            dataBinder3.DataSource = izinManager.DevamDevamsizlik();
            DtgIzin.DataSource = dataBinder3;

            DtgIzin.Columns["Id"].Visible = false;
            DtgIzin.Columns["Isakisno"].Visible = false;
            DtgIzin.Columns["Izinkategori"].Visible = false;
            DtgIzin.Columns["Izinturu"].HeaderText = "İZİN TÜRÜ";
            DtgIzin.Columns["Siparisno"].Visible = false;
            DtgIzin.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgIzin.Columns["Masrafyerino"].Visible = false;
            DtgIzin.Columns["Bolum"].Visible = false;
            DtgIzin.Columns["Izınnedeni"].Visible = false;
            DtgIzin.Columns["Bastarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgIzin.Columns["Bittarihi"].HeaderText = "BİTİŞ TARİHİ";
            DtgIzin.Columns["Izindurumu"].Visible = false;
            DtgIzin.Columns["Unvani"].HeaderText = "UNVANI";
            DtgIzin.Columns["Toplamsure"].HeaderText = "TOPLAM İZİN SÜRESİ";
            DtgIzin.Columns["KalanSure"].HeaderText = "KALAN SÜRE";
            DtgIzin.Columns["Izindurumu"].Visible = false;
            DtgIzin.Columns["Dosyayolu"].Visible = false;
            DtgIzin.Columns["Sayfa"].Visible = false;
            DtgIzin.Columns["Siparis"].Visible = false;
            DtgIzin.Columns["OnayDurum"].Visible = false;

            DtgIzin.Columns["Adsoyad"].DisplayIndex = 0;
            DtgIzin.Columns["Unvani"].DisplayIndex = 1;
            DtgIzin.Columns["Izinturu"].DisplayIndex = 2;
            DtgIzin.Columns["Bastarihi"].DisplayIndex = 5;
            DtgIzin.Columns["Bittarihi"].DisplayIndex = 6;
            DtgIzin.Columns["Toplamsure"].DisplayIndex = 10;
            DtgIzin.Columns["KalanSure"].DisplayIndex = 11;

        }
        void AracBakimList()
        {
            dataBinder5.DataSource = aracBakimManager.DevamDevamsizlik();
            DtgBakimdakiAraclar.DataSource = dataBinder5;

            DtgBakimdakiAraclar.Columns["Id"].Visible = false;
            DtgBakimdakiAraclar.Columns["IsAkisNo"].Visible = false;
            DtgBakimdakiAraclar.Columns["Plaka"].HeaderText = "PLAKA";
            DtgBakimdakiAraclar.Columns["Marka"].HeaderText = "MARKA";
            DtgBakimdakiAraclar.Columns["ModelYili"].Visible = false;
            DtgBakimdakiAraclar.Columns["MotorNo"].Visible = false;
            DtgBakimdakiAraclar.Columns["SaseNo"].Visible = false;
            DtgBakimdakiAraclar.Columns["MulkiyetBilgileri"].Visible = false;
            DtgBakimdakiAraclar.Columns["SiparisNo"].Visible = false;
            DtgBakimdakiAraclar.Columns["ProjeTahsisTarihi"].Visible = false;
            DtgBakimdakiAraclar.Columns["KullanildigiBolum"].Visible = false;
            DtgBakimdakiAraclar.Columns["ZimmetliPersonel"].Visible = false;
            DtgBakimdakiAraclar.Columns["Km"].Visible = false;
            DtgBakimdakiAraclar.Columns["BakimNedeni"].HeaderText = "BAKIM NEDENİ";
            DtgBakimdakiAraclar.Columns["TalepTarihi"].HeaderText = "TALEP TARİHİ";
            DtgBakimdakiAraclar.Columns["BakYapanFirma"].Visible = false;
            DtgBakimdakiAraclar.Columns["ArizaAciklamasi"].HeaderText = "ARIZA AÇIKLAMASI"; ;
            DtgBakimdakiAraclar.Columns["TamamlanmaTarih"].Visible = false;
            DtgBakimdakiAraclar.Columns["SonucAciklama"].Visible = false;
            DtgBakimdakiAraclar.Columns["Tutar"].Visible = false;
            DtgBakimdakiAraclar.Columns["DosyaYolu"].Visible = false;
            DtgBakimdakiAraclar.Columns["Sayfa"].Visible = false;
            DtgBakimdakiAraclar.Columns["TeslimPersonel"].Visible = false;
            DtgBakimdakiAraclar.Columns["TeslimPersonelBolum"].Visible = false;
            DtgBakimdakiAraclar.Columns["GecenSure"].HeaderText = "GEÇEN SÜRE";

            DtgBakimdakiAraclar.Columns["Plaka"].DisplayIndex = 0;
            DtgBakimdakiAraclar.Columns["Marka"].DisplayIndex = 1;
            DtgBakimdakiAraclar.Columns["BakimNedeni"].DisplayIndex = 2;
            DtgBakimdakiAraclar.Columns["ArizaAciklamasi"].DisplayIndex = 5;
            DtgBakimdakiAraclar.Columns["TalepTarihi"].DisplayIndex = 6;
            DtgBakimdakiAraclar.Columns["GecenSure"].DisplayIndex = 10;

        }
        void YurtDisiGorevList()
        {
            dataBinder4.DataSource = yurtDisiGorevManager.GetList();
            DtgYurtDisiGorev.DataSource = dataBinder4;

            DtgYurtDisiGorev.Columns["Id"].Visible = false;
            DtgYurtDisiGorev.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgYurtDisiGorev.Columns["Unvani"].HeaderText = "UNVANI";
            DtgYurtDisiGorev.Columns["Bastarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgYurtDisiGorev.Columns["Bittarihi"].HeaderText = "BİTİŞ TARİHİ";
            DtgYurtDisiGorev.Columns["Toplamsure"].HeaderText = "TOPLAM İZİN SÜRESİ";
            DtgYurtDisiGorev.Columns["KalanSure"].HeaderText = "KALAN SÜRE";
        }
        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YurtIciGorevList();
            SehirIciGorevList();
            IzinList();
            YurtDisiGorevList();
            AracBakimList();
            //Gorunum();
        }
    }
}
