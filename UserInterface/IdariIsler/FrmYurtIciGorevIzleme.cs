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

namespace UserInterface.IdariIsler
{
    public partial class FrmYurtIciGorevIzleme : Form
    {
        YurtIciGorevManager yurtIciGorevManager;
        IdariIslerLogManager logManager;
        GorevlendirmeManager gorevlendirmeManager;
        List<YurtIciGorev> yurtIciGorevs;
        List<YurtIciGorev> yurtIciGorevsFiltired;
        List<YurtIciGorev> yurtIciGorevsT;
        List<YurtIciGorev> yurtIciGorevsFiltiredT;
        List<Gorevlendirme> gorevlendirmes;
        List<Gorevlendirme> gorevlendirmesFiltired;
        List<Gorevlendirme> gorevlendirmesT;
        List<Gorevlendirme> gorevlendirmesFiltiredT;
        int outValue = 0;
        string dosyayolu,sayfa, dosyayolutamamlanan, sayfatamamlanan;
        int id, idtamamlanan;
        public FrmYurtIciGorevIzleme()
        {
            InitializeComponent();
            yurtIciGorevManager = YurtIciGorevManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
            gorevlendirmeManager = GorevlendirmeManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYurtIciGorevIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void YurtIciGorevIzleme_Load(object sender, EventArgs e)
        {
            Yillar();
            YillarGorevlendirme();
            DataDisplay();
            Toplamlar();
            DataDisplayTamamlanan();
            DataDisplayGorevlendirme();
            DataDisplayGorevlendirmeTamamlanan();
            start = false;
        }
        public void YenilecekVeriler()
        {
            Yillar();
            YillarGorevlendirme();
            DataDisplay();
            DataDisplayTamamlanan();
            Toplamlar();
            DataDisplayGorevlendirme();
            DataDisplayGorevlendirmeTamamlanan();
        }
        void Yillar()
        {
            List<string> list = new List<string>();
            list = yurtIciGorevManager.Yillar();
            list.Sort();
            CmbYillar.DataSource = list;
            int index = CmbYillar.Items.Count.ConInt() - 1;
            CmbYillar.SelectedIndex = index;
        }
        void YillarGorevlendirme()
        {
            CmbYillarGorevlendirme.DataSource = gorevlendirmeManager.Yillar();
            int index = CmbYillarGorevlendirme.Items.Count.ConInt() - 1;
            CmbYillarGorevlendirme.SelectedIndex = index;
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgTamamlanan.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgTamamlanan.Rows[i].Cells[33].Value);
            }
            LblGenelTop.Text = toplam.ToString("C2");
        }
        

        void DataDisplayGorevlendirme()
        {
            gorevlendirmes = gorevlendirmeManager.GetList("DEVAM EDIYOR", 1990);
            gorevlendirmesFiltired = gorevlendirmes;
            dataBinder3.DataSource = gorevlendirmes.ToDataTable();
            DtgGorevlendirmeDevamEden.DataSource = dataBinder3;
            LblGorevlendirmeDevam.Text = DtgGorevlendirmeDevamEden.RowCount.ToString();

            DtgGorevlendirmeDevamEden.Columns["Id"].Visible = false;
            DtgGorevlendirmeDevamEden.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgGorevlendirmeDevamEden.Columns["AdSoyad"].HeaderText = "PERSONEL ADI";
            DtgGorevlendirmeDevamEden.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgGorevlendirmeDevamEden.Columns["Tc"].HeaderText = "TC";
            DtgGorevlendirmeDevamEden.Columns["Il"].HeaderText = "İL";
            DtgGorevlendirmeDevamEden.Columns["Ilce"].HeaderText = "İLÇE";
            DtgGorevlendirmeDevamEden.Columns["Tugay"].HeaderText = "KOMUTANLIK";
            DtgGorevlendirmeDevamEden.Columns["Plaka"].HeaderText = "PLAKA";
            DtgGorevlendirmeDevamEden.Columns["GorevlendirmeNedeni"].HeaderText = "GÖREVLENDİRME NEDENİ";
            DtgGorevlendirmeDevamEden.Columns["BasTarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgGorevlendirmeDevamEden.Columns["BitTarihi"].HeaderText = "BİTİŞ TARİHİ";
            DtgGorevlendirmeDevamEden.Columns["DosyaYolu"].Visible = false;
            DtgGorevlendirmeDevamEden.Columns["Durum"].Visible = false;
            DtgGorevlendirmeDevamEden.Columns["KalanSure"].HeaderText = "KALAN SÜRE";

            DtgGorevlendirmeDevamEden.Columns["KalanSure"].DisplayIndex = 2;

        }
        void DataDisplayGorevlendirmeTamamlanan()
        {
            if (ChkTumunuGosterGorev.Checked == true)
            {
                gorevlendirmesT = gorevlendirmeManager.GetList("BİTTİ", 0);
            }
            if (CmbYillarGorevlendirme.Text == "2021")
            {
                gorevlendirmesT = gorevlendirmeManager.GetList("BİTTİ", 1990);
            }
            else
            {
                gorevlendirmesT = gorevlendirmeManager.GetList("BİTTİ", CmbYillarGorevlendirme.Text.ConInt());
            }

            gorevlendirmesFiltiredT = gorevlendirmesT;
            dataBinder4.DataSource = gorevlendirmesT.ToDataTable();
            DtgGorevlendirmeTamamlanan.DataSource = dataBinder4;
            LblGorevlendirmeTamalanan.Text = DtgGorevlendirmeTamamlanan.RowCount.ToString();

            DtgGorevlendirmeTamamlanan.Columns["Id"].Visible = false;
            DtgGorevlendirmeTamamlanan.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgGorevlendirmeTamamlanan.Columns["AdSoyad"].HeaderText = "PERSONEL ADI";
            DtgGorevlendirmeTamamlanan.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgGorevlendirmeTamamlanan.Columns["Tc"].HeaderText = "TC";
            DtgGorevlendirmeTamamlanan.Columns["Il"].HeaderText = "İL";
            DtgGorevlendirmeTamamlanan.Columns["Ilce"].HeaderText = "İLÇE";
            DtgGorevlendirmeTamamlanan.Columns["Tugay"].HeaderText = "KOMUTANLIK";
            DtgGorevlendirmeTamamlanan.Columns["Plaka"].HeaderText = "PLAKA";
            DtgGorevlendirmeTamamlanan.Columns["GorevlendirmeNedeni"].HeaderText = "GÖREVLENDİRME NEDENİ";
            DtgGorevlendirmeTamamlanan.Columns["BasTarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgGorevlendirmeTamamlanan.Columns["BitTarihi"].HeaderText = "BİTİŞ TARİHİ";
            DtgGorevlendirmeTamamlanan.Columns["DosyaYolu"].Visible = false;
            DtgGorevlendirmeTamamlanan.Columns["Durum"].Visible = false;
            DtgGorevlendirmeTamamlanan.Columns["KalanSure"].Visible = false;

        }
        void DataDisplay()
        {
            yurtIciGorevs = yurtIciGorevManager.GetList("1.ADIM:GÖREV OLUŞTURULDU", 0);
            yurtIciGorevsFiltired = yurtIciGorevs;
            dataBinder.DataSource = yurtIciGorevs.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Gorevemrino"].HeaderText = "GÖREV EMRİ NO";
            DtgList.Columns["Gorevinkonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgList.Columns["Proje"].HeaderText = "PROJE";
            DtgList.Columns["Gidilecekyer"].HeaderText = "GİDİLECEK YER";
            DtgList.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgList.Columns["Bitistarihi"].HeaderText = "BİTİŞ TARİHİ";
            DtgList.Columns["Toplamsure"].HeaderText = "TOPLAM SÜRE";
            DtgList.Columns["Butcekodu"].HeaderText = "BÜTÇE KODU";
            DtgList.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgList.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgList.Columns["Ulasimgidis"].HeaderText = "ULAŞIM GİDİŞ";
            DtgList.Columns["Ulasimgorevyeri"].HeaderText = "GÖREV YERİ";
            DtgList.Columns["Ulasimdonus"].HeaderText = "ULAŞIM DÖNÜŞ";
            DtgList.Columns["Konaklamagun"].HeaderText = "KONAKLAMA GÜN";
            DtgList.Columns["Konaklamaguntl"].HeaderText = "KONAKLAMA GÜN/TL";
            DtgList.Columns["Konaklamatoplam"].HeaderText = "KONAKLAMA TOPLAM";
            DtgList.Columns["Kiralamagun"].HeaderText = "ARAÇ KİRALAMA GÜN";
            DtgList.Columns["Kiralamaguntl"].HeaderText = "ARAÇ KİRALAMA GÜN/TL";
            DtgList.Columns["Kiralamayakit"].HeaderText = "ARAÇ KİRALAMA YAKIT";
            DtgList.Columns["Kiralamatoplam"].HeaderText = "ARAÇ KİRALAMA TOPLAM";
            DtgList.Columns["Seyahatavansgun"].HeaderText = "SEYAHAT İŞ AVANSI GÜN";
            DtgList.Columns["Seyahatguntl"].HeaderText = "SEYAHAT İŞ AVANSI GÜN/TL";
            DtgList.Columns["Seyahattoplam"].HeaderText = "SEYAHAT İŞ AVANSI TOPLAM";
            DtgList.Columns["Ucakbileti"].HeaderText = "UÇAK BİLETİ";
            DtgList.Columns["Otobusbileti"].HeaderText = "OTOBÜS BİLETİ";
            DtgList.Columns["Geneltoplam"].HeaderText = "GENEL TOPLAM";
            DtgList.Columns["Plaka"].HeaderText = "PLAKA";
            DtgList.Columns["Cikiskm"].HeaderText = "ÇIKIŞ KİLOMETRESİ";
            DtgList.Columns["Donuskm"].HeaderText = "DÖNÜŞ KİLOMETRESİ";
            DtgList.Columns["Toplamkm"].HeaderText = "TOPLAM KİLOMETRE";
            DtgList.Columns["Geneltoplam"].HeaderText = "GENEL TOPLAM";
            DtgList.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgList.Columns["Islemadimi"].Visible = false;
            DtgList.Columns["Unvani"].DisplayIndex = 13;
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["KalanSure"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;
            DtgList.Columns["KonaklamaTuru"].Visible = false;
        }
        void DataDisplayTamamlanan()
        {

            if (ChkTumunuGoster.Checked == true)
            {
                yurtIciGorevsT = yurtIciGorevManager.GetList("2.ADIM:GÖREV TAMAMLANMIŞTIR", 0);
            }
            if (CmbYillar.Text == "2021")
            {
                yurtIciGorevsT = yurtIciGorevManager.GetList("2.ADIM:GÖREV TAMAMLANMIŞTIR", 1990);
            }
            else
            {
                yurtIciGorevsT = yurtIciGorevManager.GetList("2.ADIM:GÖREV TAMAMLANMIŞTIR", CmbYillar.Text.ConInt());
            }

            yurtIciGorevsFiltiredT = yurtIciGorevsT;
            dataBinder2.DataSource = yurtIciGorevsT.ToDataTable();
            DtgTamamlanan.DataSource = dataBinder2;
            TxtTop2.Text = DtgTamamlanan.RowCount.ToString();

            DtgTamamlanan.Columns["Id"].Visible = false;
            DtgTamamlanan.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgTamamlanan.Columns["Gorevemrino"].HeaderText = "GÖREV EMRİ NO";
            DtgTamamlanan.Columns["Gorevinkonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgTamamlanan.Columns["Proje"].HeaderText = "PROJE";
            DtgTamamlanan.Columns["Gidilecekyer"].HeaderText = "GİDİLECEK YER";
            DtgTamamlanan.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgTamamlanan.Columns["Bitistarihi"].HeaderText = "BİTİŞ TARİHİ";
            DtgTamamlanan.Columns["Toplamsure"].HeaderText = "TOPLAM SÜRE";
            DtgTamamlanan.Columns["Butcekodu"].HeaderText = "BÜTÇE KODU";
            DtgTamamlanan.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgTamamlanan.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgTamamlanan.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgTamamlanan.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgTamamlanan.Columns["Ulasimgidis"].HeaderText = "ULAŞIM GİDİŞ";
            DtgTamamlanan.Columns["Ulasimgorevyeri"].HeaderText = "GÖREV YERİ";
            DtgTamamlanan.Columns["Ulasimdonus"].HeaderText = "ULAŞIM DÖNÜŞ";
            DtgTamamlanan.Columns["Konaklamagun"].HeaderText = "KONAKLAMA GÜN";
            DtgTamamlanan.Columns["Konaklamaguntl"].HeaderText = "KONAKLAMA GÜN/TL";
            DtgTamamlanan.Columns["Konaklamatoplam"].HeaderText = "KONAKLAMA TOPLAM";
            DtgTamamlanan.Columns["Kiralamagun"].HeaderText = "ARAÇ KİRALAMA GÜN";
            DtgTamamlanan.Columns["Kiralamaguntl"].HeaderText = "ARAÇ KİRALAMA GÜN/TL";
            DtgTamamlanan.Columns["Kiralamayakit"].HeaderText = "ARAÇ KİRALAMA YAKIT";
            DtgTamamlanan.Columns["Kiralamatoplam"].HeaderText = "ARAÇ KİRALAMA TOPLAM";
            DtgTamamlanan.Columns["Seyahatavansgun"].HeaderText = "SEYAHAT İŞ AVANSI GÜN";
            DtgTamamlanan.Columns["Seyahatguntl"].HeaderText = "SEYAHAT İŞ AVANSI GÜN/TL";
            DtgTamamlanan.Columns["Seyahattoplam"].HeaderText = "SEYAHAT İŞ AVANSI TOPLAM";
            DtgTamamlanan.Columns["Ucakbileti"].HeaderText = "UÇAK BİLETİ";
            DtgTamamlanan.Columns["Otobusbileti"].HeaderText = "OTOBÜS BİLETİ";
            DtgTamamlanan.Columns["Geneltoplam"].HeaderText = "GENEL TOPLAM";
            DtgTamamlanan.Columns["Plaka"].HeaderText = "PLAKA";
            DtgTamamlanan.Columns["Cikiskm"].HeaderText = "ÇIKIŞ KİLOMETRESİ";
            DtgTamamlanan.Columns["Donuskm"].HeaderText = "DÖNÜŞ KİLOMETRESİ";
            DtgTamamlanan.Columns["Toplamkm"].HeaderText = "TOPLAM KİLOMETRE";
            DtgTamamlanan.Columns["Geneltoplam"].HeaderText = "GENEL TOPLAM";
            DtgTamamlanan.Columns["Islemadimi"].HeaderText = "İŞLEM ADIMI";
            DtgTamamlanan.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgTamamlanan.Columns["KonaklamaTuru"].HeaderText = "KONAKLAMA TÜRÜ";
            DtgTamamlanan.Columns["Islemadimi"].Visible = false;
            DtgTamamlanan.Columns["KonaklamaTuru"].DisplayIndex = 20;
            DtgTamamlanan.Columns["Unvani"].DisplayIndex = 13;
            DtgTamamlanan.Columns["Dosyayolu"].Visible = false;
            DtgTamamlanan.Columns["KalanSure"].Visible = false;
            DtgTamamlanan.Columns["Sayfa"].Visible = false;
            Toplamlar();
        }
        void DataDisplayTamamlananGorevlendirme()
        {

            if (ChkTumunuGoster.Checked == true)
            {
                yurtIciGorevsT = yurtIciGorevManager.GetList("2.ADIM:GÖREV TAMAMLANMIŞTIR", 0);
            }
            if (CmbYillar.Text == "2021")
            {
                yurtIciGorevsT = yurtIciGorevManager.GetList("2.ADIM:GÖREV TAMAMLANMIŞTIR", 1990);
            }
            else
            {
                yurtIciGorevsT = yurtIciGorevManager.GetList("2.ADIM:GÖREV TAMAMLANMIŞTIR", CmbYillar.Text.ConInt());
            }

            yurtIciGorevsFiltiredT = yurtIciGorevsT;
            dataBinder2.DataSource = yurtIciGorevsT.ToDataTable();
            DtgTamamlanan.DataSource = dataBinder2;
            TxtTop2.Text = DtgTamamlanan.RowCount.ToString();

            DtgTamamlanan.Columns["Id"].Visible = false;
            DtgTamamlanan.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgTamamlanan.Columns["Gorevemrino"].HeaderText = "GÖREV EMRİ NO";
            DtgTamamlanan.Columns["Gorevinkonusu"].HeaderText = "GÖREVİN KONUSU";
            DtgTamamlanan.Columns["Proje"].HeaderText = "PROJE";
            DtgTamamlanan.Columns["Gidilecekyer"].HeaderText = "GİDİLECEK YER";
            DtgTamamlanan.Columns["Baslamatarihi"].HeaderText = "BAŞLAMA TARİHİ";
            DtgTamamlanan.Columns["Bitistarihi"].HeaderText = "BİTİŞ TARİHİ";
            DtgTamamlanan.Columns["Toplamsure"].HeaderText = "TOPLAM SÜRE";
            DtgTamamlanan.Columns["Butcekodu"].HeaderText = "BÜTÇE KODU";
            DtgTamamlanan.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgTamamlanan.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgTamamlanan.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgTamamlanan.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgTamamlanan.Columns["Ulasimgidis"].HeaderText = "ULAŞIM GİDİŞ";
            DtgTamamlanan.Columns["Ulasimgorevyeri"].HeaderText = "GÖREV YERİ";
            DtgTamamlanan.Columns["Ulasimdonus"].HeaderText = "ULAŞIM DÖNÜŞ";
            DtgTamamlanan.Columns["Konaklamagun"].HeaderText = "KONAKLAMA GÜN";
            DtgTamamlanan.Columns["Konaklamaguntl"].HeaderText = "KONAKLAMA GÜN/TL";
            DtgTamamlanan.Columns["Konaklamatoplam"].HeaderText = "KONAKLAMA TOPLAM";
            DtgTamamlanan.Columns["Kiralamagun"].HeaderText = "ARAÇ KİRALAMA GÜN";
            DtgTamamlanan.Columns["Kiralamaguntl"].HeaderText = "ARAÇ KİRALAMA GÜN/TL";
            DtgTamamlanan.Columns["Kiralamayakit"].HeaderText = "ARAÇ KİRALAMA YAKIT";
            DtgTamamlanan.Columns["Kiralamatoplam"].HeaderText = "ARAÇ KİRALAMA TOPLAM";
            DtgTamamlanan.Columns["Seyahatavansgun"].HeaderText = "SEYAHAT İŞ AVANSI GÜN";
            DtgTamamlanan.Columns["Seyahatguntl"].HeaderText = "SEYAHAT İŞ AVANSI GÜN/TL";
            DtgTamamlanan.Columns["Seyahattoplam"].HeaderText = "SEYAHAT İŞ AVANSI TOPLAM";
            DtgTamamlanan.Columns["Ucakbileti"].HeaderText = "UÇAK BİLETİ";
            DtgTamamlanan.Columns["Otobusbileti"].HeaderText = "OTOBÜS BİLETİ";
            DtgTamamlanan.Columns["Geneltoplam"].HeaderText = "GENEL TOPLAM";
            DtgTamamlanan.Columns["Plaka"].HeaderText = "PLAKA";
            DtgTamamlanan.Columns["Cikiskm"].HeaderText = "ÇIKIŞ KİLOMETRESİ";
            DtgTamamlanan.Columns["Donuskm"].HeaderText = "DÖNÜŞ KİLOMETRESİ";
            DtgTamamlanan.Columns["Toplamkm"].HeaderText = "TOPLAM KİLOMETRE";
            DtgTamamlanan.Columns["Geneltoplam"].HeaderText = "GENEL TOPLAM";
            DtgTamamlanan.Columns["Islemadimi"].HeaderText = "İŞLEM ADIMI";
            DtgTamamlanan.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgTamamlanan.Columns["KonaklamaTuru"].HeaderText = "KONAKLAMA TÜRÜ";
            DtgTamamlanan.Columns["Islemadimi"].Visible = false;
            DtgTamamlanan.Columns["KonaklamaTuru"].DisplayIndex = 20;
            DtgTamamlanan.Columns["Unvani"].DisplayIndex = 13;
            DtgTamamlanan.Columns["Dosyayolu"].Visible = false;
            DtgTamamlanan.Columns["KalanSure"].Visible = false;
            DtgTamamlanan.Columns["Sayfa"].Visible = false;
            Toplamlar();
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

        private void TxtAdSoyad_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtAdSoyad.Text;
            if (string.IsNullOrEmpty(isim))
            {
                yurtIciGorevsFiltired = yurtIciGorevs;
                dataBinder.DataSource = yurtIciGorevs.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtAdSoyad.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = yurtIciGorevsFiltired.Where(x => x.Adsoyad.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            yurtIciGorevsFiltired = yurtIciGorevs;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void TxtAkısNo_TextChanged(object sender, EventArgs e)
        {
            int isno = 0;
            if (string.IsNullOrEmpty(TxtAkısNo.Text))
            {
                yurtIciGorevsFiltired = yurtIciGorevs;
                dataBinder.DataSource = yurtIciGorevs.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtAkısNo.Text.Length < 3)
            {
                return;
            }
            if (!int.TryParse(TxtAkısNo.Text, out outValue))
            {
                MessageBox.Show("Rakamsal Değer Giriniz");
                return;
            }
            isno = TxtAkısNo.Text.ConInt();
            dataBinder.DataSource = yurtIciGorevsFiltired.Where(x => x.Isakisno.ToString().Contains(isno.ToString())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            yurtIciGorevsFiltired = yurtIciGorevs;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay(); DataDisplayTamamlanan(); TxtAkısNo.Clear(); TxtAdSoyad.Clear(); TxtIsAkisNoTamamlanan.Clear(); TxtAdSoyadTamamlanan.Clear();
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyayolu = DtgList.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            sayfa = DtgList.CurrentRow.Cells["Sayfa"].Value.ToString();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            try
            {
                webBrowser1.Navigate(dosyayolu);
            }
            catch (Exception)
            {
                return;
            }
            IslemAdimlariDisplay();
        }

        private void TxtIsAkisNoTamamlanan_TextChanged(object sender, EventArgs e)
        {
            int isno = 0;
            if (string.IsNullOrEmpty(TxtIsAkisNoTamamlanan.Text))
            {
                yurtIciGorevsFiltiredT = yurtIciGorevsT;
                dataBinder2.DataSource = yurtIciGorevsT.ToDataTable();
                DtgTamamlanan.DataSource = dataBinder2;
                TxtTop2.Text = DtgTamamlanan.RowCount.ToString();
                return;
            }
            if (TxtIsAkisNoTamamlanan.Text.Length < 3)
            {
                return;
            }
            if (!int.TryParse(TxtIsAkisNoTamamlanan.Text, out outValue))
            {
                MessageBox.Show("Rakamsal Değer Giriniz");
                return;
            }
            isno = TxtIsAkisNoTamamlanan.Text.ConInt();
            dataBinder2.DataSource = yurtIciGorevsFiltiredT.Where(x => x.Isakisno.ToString().Contains(isno.ToString())).ToList().ToDataTable();
            DtgTamamlanan.DataSource = dataBinder2;
            yurtIciGorevsFiltiredT = yurtIciGorevsT;
            TxtTop2.Text = DtgTamamlanan.RowCount.ToString();
        }

        private void DtgTamamlanan_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Filter = DtgTamamlanan.FilterString;
            TxtTop2.Text = DtgTamamlanan.RowCount.ToString();
            Toplamlar();
        }

        private void DtgTamamlanan_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Sort = DtgTamamlanan.SortString;
        }

        private void TxtAdSoyadTamamlanan_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtAdSoyadTamamlanan.Text;
            if (string.IsNullOrEmpty(isim))
            {
                yurtIciGorevsFiltiredT = yurtIciGorevsT;
                dataBinder2.DataSource = yurtIciGorevsT.ToDataTable();
                DtgTamamlanan.DataSource = dataBinder2;
                TxtTop2.Text = DtgTamamlanan.RowCount.ToString();
                Toplamlar();
                return;
            }
            if (TxtAdSoyadTamamlanan.Text.Length < 3)
            {
                return;
            }
            dataBinder2.DataSource = yurtIciGorevsFiltiredT.Where(x => x.Adsoyad.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgTamamlanan.DataSource = dataBinder2;
            yurtIciGorevsFiltiredT = yurtIciGorevsT;
            TxtTop2.Text = DtgTamamlanan.RowCount.ToString();
            Toplamlar();
        }

        private void konaklamaDetayıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (konaklamaTuru==null)
            {
                MessageBox.Show("Öncelikle Bir Kayıt Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            FrmKonaklamaDetayi frmKonaklama = new FrmKonaklamaDetayi();
            frmKonaklama.isAkisNo = isAkisNo;
            frmKonaklama.ShowDialog();
        }

        string konaklamaTuru;
        bool start = true;
        private void CmbYillar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbYillar.SelectedIndex == -1)
            {
                return;
            }
            DataDisplayTamamlanan();
            Toplamlar();
        }

        private void ChkTumunuGoster_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTumunuGoster.Checked == true)
            {
                CmbYillar.SelectedIndex = -1;
                DataDisplayTamamlanan();
            }
            else
            {
                Yillar();
                DataDisplayTamamlanan();
            }
        }
        string gorevlendirmeDosyaYolu = "";
        private void DtgGorevlendirmeDevamEden_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgGorevlendirmeDevamEden.RowCount==0)
            {
                return;
            }
            gorevlendirmeDosyaYolu = DtgGorevlendirmeDevamEden.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            try
            {
                webBrowser3.Navigate(gorevlendirmeDosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void DtgGorevlendirmeDevamEden_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder3.Filter = DtgGorevlendirmeDevamEden.FilterString;
            LblGorevlendirmeDevam.Text = DtgGorevlendirmeDevamEden.RowCount.ToString();
        }

        private void DtgGorevlendirmeDevamEden_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder3.Sort = DtgGorevlendirmeDevamEden.SortString;
        }

        private void DtgGorevlendirmeTamamlanan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgGorevlendirmeTamamlanan.RowCount == 0)
            {
                return;
            }
            gorevlendirmeDosyaYolu = DtgGorevlendirmeTamamlanan.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            try
            {
                webBrowser4.Navigate(gorevlendirmeDosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void DtgGorevlendirmeTamamlanan_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder4.Filter = DtgGorevlendirmeTamamlanan.FilterString;
            LblGorevlendirmeTamalanan.Text = DtgGorevlendirmeTamamlanan.RowCount.ToString();
        }

        private void DtgGorevlendirmeTamamlanan_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder4.Sort = DtgGorevlendirmeTamamlanan.SortString;
        }

        private void ChkTumunuGosterGorev_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTumunuGosterGorev.Checked == true)
            {
                CmbYillarGorevlendirme.SelectedIndex = -1;
                DataDisplayGorevlendirmeTamamlanan();
            }
            else
            {
                YillarGorevlendirme();
                DataDisplayGorevlendirmeTamamlanan();
            }
        }

        int isAkisNo;
        private void DtgTamamlanan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgTamamlanan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyayolutamamlanan = DtgTamamlanan.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            sayfatamamlanan = DtgTamamlanan.CurrentRow.Cells["Sayfa"].Value.ToString();
            idtamamlanan = DtgTamamlanan.CurrentRow.Cells["Id"].Value.ConInt();
            konaklamaTuru = DtgTamamlanan.CurrentRow.Cells["KonaklamaTuru"].Value.ToString();
            isAkisNo = DtgTamamlanan.CurrentRow.Cells["Isakisno"].Value.ConInt();
            webBrowser2.Navigate(dosyayolutamamlanan);
            IslemAdimlariDisplayTamamlanan();
        }

        void IslemAdimlariDisplay()
        {
            DtgIslemAdimlari.DataSource = logManager.GetList(sayfa, id);

            DtgIslemAdimlari.Columns["Id"].Visible = false;
            DtgIslemAdimlari.Columns["Sayfa"].Visible = false;
            DtgIslemAdimlari.Columns["Benzersizid"].Visible = false;
            DtgIslemAdimlari.Columns["Islem"].HeaderText = "YAPILAN İŞLEM";
            DtgIslemAdimlari.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgIslemAdimlari.Columns["Tarih"].HeaderText = "TARİH";
            DtgIslemAdimlari.Columns["Tarih"].Width = 100;
            DtgIslemAdimlari.Columns["Islemyapan"].Width = 135;
            DtgIslemAdimlari.Columns["Islem"].Width = 400;
        }
        void IslemAdimlariDisplayTamamlanan()
        {
            DtgIslemAdimlariTamamlanan.DataSource = logManager.GetList(sayfatamamlanan, idtamamlanan);
            DtgIslemAdimlariTamamlanan.Columns["Id"].Visible = false;
            DtgIslemAdimlariTamamlanan.Columns["Sayfa"].Visible = false;
            DtgIslemAdimlariTamamlanan.Columns["Benzersizid"].Visible = false;
            DtgIslemAdimlariTamamlanan.Columns["Islem"].HeaderText = "YAPILAN İŞLEM";
            DtgIslemAdimlariTamamlanan.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgIslemAdimlariTamamlanan.Columns["Tarih"].HeaderText = "TARİH";
            DtgIslemAdimlariTamamlanan.Columns["Tarih"].Width = 100;
            DtgIslemAdimlariTamamlanan.Columns["Islemyapan"].Width = 135;
            DtgIslemAdimlariTamamlanan.Columns["Islem"].Width = 400;
        }
    }
}
