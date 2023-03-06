using Business;
using DataAccess.Concreate;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class FrmAdmin : Form
    {
        YetkilerManager yetkilerManager;
        List<Yetki> yetkiler;
        string[] array;
        public object[] infos;
        bool start = true;
        int authId, control, gir, girdal, id;

        public FrmAdmin()
        {
            InitializeComponent();
            yetkilerManager = YetkilerManager.GetInstance();
        }
        void CmbYetkilerLoad()
        {
            BtnYetki.DataSource = yetkiler; BtnYetki.ValueMember = "Id"; BtnYetki.DisplayMember = "Name"; BtnYetki.SelectedValue = 0;
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {

            if (true)
            {

            }
            yetkiler = yetkilerManager.GetList();
            CmbYetkilerLoad();
            start = false;

            ChcListBoxYetkiler.Items.Add("BO01 BAKIM ONARIM"); // İndex 0 => array 1 ( 1;2;...)
            ChcListBoxYetkiler.Items.Add("   BO01 - Veri İzleme Ekranları");
            ChcListBoxYetkiler.Items.Add("       Devam Eden Arıza İzleme");
            ChcListBoxYetkiler.Items.Add("       Tamamlanan Arıza İzleme");
            ChcListBoxYetkiler.Items.Add("       İşçilik İzleme");
            ChcListBoxYetkiler.Items.Add("       Bölge Yol Durum İzleme");
            ChcListBoxYetkiler.Items.Add("       Yerleşim Kayıtları İzleme");
            ChcListBoxYetkiler.Items.Add("       OKF İzleme");
            ChcListBoxYetkiler.Items.Add("       DTF İzleme");
            ChcListBoxYetkiler.Items.Add("       Müşteri Bilgileri İzleme");
            ChcListBoxYetkiler.Items.Add("       Teslimat Eksikleri İzleme");
            ChcListBoxYetkiler.Items.Add("       Firma Servis Formu İzleme");
            ChcListBoxYetkiler.Items.Add("       Destek İşçilik İzleme");
            ChcListBoxYetkiler.Items.Add("   BO01 - Veri Giriş Ekranları");//13
            ChcListBoxYetkiler.Items.Add("       Veri Kayıt (Arıza Açma)");
            ChcListBoxYetkiler.Items.Add("       Bildirim No Tanımlama");
            ChcListBoxYetkiler.Items.Add("       Veri Güncelleme");
            ChcListBoxYetkiler.Items.Add("       Veri Kayıt (Arıza Kapatma)");
            ChcListBoxYetkiler.Items.Add("       Müşteri Bilgileri");
            ChcListBoxYetkiler.Items.Add("       Bölge Yol Durumu");
            ChcListBoxYetkiler.Items.Add("       Yerleşim Kayıtları");
            ChcListBoxYetkiler.Items.Add("       Bildirim Onayı");
            ChcListBoxYetkiler.Items.Add("       Malzeme Temini");
            ChcListBoxYetkiler.Items.Add("       Doğrudan Temin");
            ChcListBoxYetkiler.Items.Add("       Servis Talepleri");
            ChcListBoxYetkiler.Items.Add("       OKF Oluşturma");
            ChcListBoxYetkiler.Items.Add("       Teslimat Eksikleri");
            ChcListBoxYetkiler.Items.Add("       Firma Servis Formu Kayıt");
            ChcListBoxYetkiler.Items.Add("       Destek İşçilik Veri Girişi");//İndex 28
            ChcListBoxYetkiler.Items.Add("DP01 GEÇİCİ KABUL VE AMBAR"); // İndex 29
            ChcListBoxYetkiler.Items.Add("   DP01 - Veri İzleme Ekranları");//30
            ChcListBoxYetkiler.Items.Add("       Stok Görüntüle");
            ChcListBoxYetkiler.Items.Add("       Depo Hareketleri");
            ChcListBoxYetkiler.Items.Add("       Stokta Bulunmayan Malzemeler");
            ChcListBoxYetkiler.Items.Add("   DP01 - Veri Giriş Ekranları");//34
            ChcListBoxYetkiler.Items.Add("      Stok Giriş/Çıkış");
            ChcListBoxYetkiler.Items.Add("      Malzeme Kayit Ambar");
            ChcListBoxYetkiler.Items.Add("      Malzeme Hazırlama");//İndex 37
            ChcListBoxYetkiler.Items.Add("ST01 SATIN ALMA");//İndex 38
            ChcListBoxYetkiler.Items.Add("   ST01 - Veri İzleme Ekranları");//39
            ChcListBoxYetkiler.Items.Add("       Devam Eden SAT");
            ChcListBoxYetkiler.Items.Add("       Tamamlanan SAT");
            ChcListBoxYetkiler.Items.Add("       Reddedilen SAT");
            ChcListBoxYetkiler.Items.Add("       Yedek Parça Kataloğu");
            ChcListBoxYetkiler.Items.Add("   ST01 - Veri Giriş Ekranları");//44
            ChcListBoxYetkiler.Items.Add("       SAT Oluştur");
            ChcListBoxYetkiler.Items.Add("       SAT Ön Onay");
            ChcListBoxYetkiler.Items.Add("       SAT Başlatma Onayı");
            ChcListBoxYetkiler.Items.Add("       Teklif Alınacak SAT");
            ChcListBoxYetkiler.Items.Add("       Teklifsiz SAT");
            ChcListBoxYetkiler.Items.Add("       SAT Onay");
            ChcListBoxYetkiler.Items.Add("       SAT Tamamlama");
            ChcListBoxYetkiler.Items.Add("       SAT Güncelle");
            ChcListBoxYetkiler.Items.Add("       Tedarikçi Firma Bilgileri");
            ChcListBoxYetkiler.Items.Add("       Alt Yüklenici Firma Bilgileri");// 54
            ChcListBoxYetkiler.Items.Add("DS01 DOKÜMAN YÖNETİM SİSTEMİ");//İndex 55
            ChcListBoxYetkiler.Items.Add("   DS01 - Veri İzleme Ekranları");//56
            ChcListBoxYetkiler.Items.Add("       Doküman Sorgula");
            ChcListBoxYetkiler.Items.Add("       Standart Form Sorgula");
            ChcListBoxYetkiler.Items.Add("   DS01 - Veri Giriş Ekranları");// 59
            ChcListBoxYetkiler.Items.Add("       Doküman Ekle");
            ChcListBoxYetkiler.Items.Add("       Standart Form Ekle");
            ChcListBoxYetkiler.Items.Add("ID01 İDARİ İŞLER");//İndex 62
            ChcListBoxYetkiler.Items.Add("   ID01 - Veri Giriş Ekranları"); //63
            ChcListBoxYetkiler.Items.Add("       Duran Varlık"); // 64
            ChcListBoxYetkiler.Items.Add("           Duran Varlık Kayıt");
            ChcListBoxYetkiler.Items.Add("           Duran Varlık Güncelleme");
            ChcListBoxYetkiler.Items.Add("           Duran Varlık Aktarım");
            ChcListBoxYetkiler.Items.Add("           Duran Varlık Arıza Kayıt");
            ChcListBoxYetkiler.Items.Add("           DV Kalibrasyon Kayıt");
            ChcListBoxYetkiler.Items.Add("       Personel");//70
            ChcListBoxYetkiler.Items.Add("           Personel Giriş/Çıkış");
            ChcListBoxYetkiler.Items.Add("           Personel Puantaj");
            ChcListBoxYetkiler.Items.Add("       İş Akışları");//73
            ChcListBoxYetkiler.Items.Add("           Yurt İçi Görev");
            ChcListBoxYetkiler.Items.Add("           Şehir İçi Görev");
            ChcListBoxYetkiler.Items.Add("           İzin");
            ChcListBoxYetkiler.Items.Add("           Konaklama");
            ChcListBoxYetkiler.Items.Add("           Uçak ve Otobüs Bileti");
            ChcListBoxYetkiler.Items.Add("           Harcama Beyannamesi");
            ChcListBoxYetkiler.Items.Add("       Resmi Yazılar");//80
            ChcListBoxYetkiler.Items.Add("           Gelen Resmi Yazılar");
            ChcListBoxYetkiler.Items.Add("           Giden Resmi Yazılar");
            ChcListBoxYetkiler.Items.Add("           Evrak Kayıt");
            ChcListBoxYetkiler.Items.Add("       Arşiv");//84
            ChcListBoxYetkiler.Items.Add("       Ulaştırma");//85
            ChcListBoxYetkiler.Items.Add("           Araç Tahsis Kayıt");
            ChcListBoxYetkiler.Items.Add("           Araç Yakıt Beyanı");
            ChcListBoxYetkiler.Items.Add("           Araç Peryodik Bakım");
            ChcListBoxYetkiler.Items.Add("           Arac Bakım Onarım");
            ChcListBoxYetkiler.Items.Add("   ID01 - Veri İzleme Ekranları");//90
            ChcListBoxYetkiler.Items.Add("       Duran Varlık İzleme");//91
            ChcListBoxYetkiler.Items.Add("           Duran Varlık Takibi");
            ChcListBoxYetkiler.Items.Add("           DV Zimmet Takibi");
            ChcListBoxYetkiler.Items.Add("           DV Arıza Takibi");
            ChcListBoxYetkiler.Items.Add("           DV Kalibrasyon Takibi");
            ChcListBoxYetkiler.Items.Add("       Personel İzleme");//96
            ChcListBoxYetkiler.Items.Add("           Personel Listesi (Çalışan)");
            ChcListBoxYetkiler.Items.Add("           Personel Listesi (İşten Ayrılan)");
            ChcListBoxYetkiler.Items.Add("           Personel Puantaj");
            ChcListBoxYetkiler.Items.Add("       İş Akışları İzleme");//100
            ChcListBoxYetkiler.Items.Add("           Yurt İçi Görev");
            ChcListBoxYetkiler.Items.Add("           Şehir İçi Görev");
            ChcListBoxYetkiler.Items.Add("           İzin");
            ChcListBoxYetkiler.Items.Add("           Konaklama");
            ChcListBoxYetkiler.Items.Add("           Uçak ve Otobüs Bileti");
            ChcListBoxYetkiler.Items.Add("           Harcama Beyannamesi İzleme");
            ChcListBoxYetkiler.Items.Add("       Gelen Giden Resmi Yazı İzleme");//107
            ChcListBoxYetkiler.Items.Add("       Arşiv İzleme");//108
            ChcListBoxYetkiler.Items.Add("       Ulaştırma İzleme");//109
            ChcListBoxYetkiler.Items.Add("           Araç Tahsis İzleme");
            ChcListBoxYetkiler.Items.Add("           Araç Yakıt Beyan İzleme");
            ChcListBoxYetkiler.Items.Add("           Araç Periyodik Bakım İzleme");
            ChcListBoxYetkiler.Items.Add("           Araç Bakım Onarım İzleme");//İndex 113
            ChcListBoxYetkiler.Items.Add("EG01 EĞİTİM");//İndex 114
            ChcListBoxYetkiler.Items.Add("   EG01 - Veri Giriş Ekranları");//115
            ChcListBoxYetkiler.Items.Add("       Eğitim Veri Girişi");
            ChcListBoxYetkiler.Items.Add("       Eğitim Planı Oluştur");
            ChcListBoxYetkiler.Items.Add("       Eğitim Planı Güncelle");
            ChcListBoxYetkiler.Items.Add("   EG01 - Veri İzleme Ekranları");//119
            ChcListBoxYetkiler.Items.Add("       Eğitim İzleme");
            ChcListBoxYetkiler.Items.Add("       Eğitim Planı İzleme");
            ChcListBoxYetkiler.Items.Add("DP02 DESTEK DEPO");//İndex 122
            ChcListBoxYetkiler.Items.Add("   DP02 - Veri İzleme Ekranları");//123
            ChcListBoxYetkiler.Items.Add("       Stok Goruntule Depo");
            ChcListBoxYetkiler.Items.Add("       Depo Hareketleri Depo");
            ChcListBoxYetkiler.Items.Add("       Stokta Bulunmayan Malzemeler");
            ChcListBoxYetkiler.Items.Add("   DP02 - Veri Giriş Ekranları");//127
            ChcListBoxYetkiler.Items.Add("       Stok Giris");
            ChcListBoxYetkiler.Items.Add("       Malzeme Kayıt");
            ChcListBoxYetkiler.Items.Add("       Mazleme Hazırlama");
            ChcListBoxYetkiler.Items.Add("RP01 RAPORLAMALAR");//İndex 131
            ChcListBoxYetkiler.Items.Add("   RP01 - Veri İzleme Ekranları");//132
            ChcListBoxYetkiler.Items.Add("   RP01 - Veri Giriş Ekranları");//133
        }
        void RestartChcList()
        {
            for (int i = 0; i < ChcListBoxYetkiler.Items.Count; i++)
            {
                ChcListBoxYetkiler.SetItemChecked(i, false);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (BtnYetki.Text=="")
            {
                MessageBox.Show("Lütfen Öncelikle Bir Personel Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            UpdateYetkiIzinleri();
        }

        bool checkControl = false;
        private void ChcListBoxYetkiler_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkControl)
            {
                return;
            }
            if (ChcListBoxYetkiler.SelectedItem == null)
            {
                return;
            }
            string item = ChcListBoxYetkiler.SelectedItem.ToString().Trim();
            checkControl = true;
            if (e.NewValue == CheckState.Checked)
            {
                SetChcListItemChecked("BO01 BAKIM ONARIM", 1, 28, true);
                SetChcListItemChecked("DP01 GEÇİCİ KABUL VE AMBAR", 29, 37, true);
                SetChcListItemChecked("ST01 SATIN ALMA", 38, 54, true);
                SetChcListItemChecked("DS01 DOKÜMAN YÖNETİM SİSTEMİ", 55, 61, true);
                SetChcListItemChecked("ID01 İDARİ İŞLER", 62, 1113, true);
                SetChcListItemChecked("EG01 EĞİTİM", 114, 121, true);
                SetChcListItemChecked("DP02 DESTEK DEPO", 122, 130, true);
                SetChcListItemChecked("RP01 RAPORLAMALAR", 131, 133, true);


                if (item == "BO01 - Veri İzleme Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(0, true);
                    ChcListBoxYetkiler.SetItemChecked(1, true);
                    ChcListBoxYetkiler.SetItemChecked(2, true);
                    ChcListBoxYetkiler.SetItemChecked(3, true);
                    ChcListBoxYetkiler.SetItemChecked(4, true);
                    ChcListBoxYetkiler.SetItemChecked(5, true);
                    ChcListBoxYetkiler.SetItemChecked(6, true);
                    ChcListBoxYetkiler.SetItemChecked(7, true);
                    ChcListBoxYetkiler.SetItemChecked(8, true);
                    ChcListBoxYetkiler.SetItemChecked(9, true);
                    ChcListBoxYetkiler.SetItemChecked(10, true);
                    ChcListBoxYetkiler.SetItemChecked(11, true);
                    ChcListBoxYetkiler.SetItemChecked(12, true);
                }
                if (item == "BO01 - Veri Giriş Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(0, true);
                    ChcListBoxYetkiler.SetItemChecked(13, true);
                    ChcListBoxYetkiler.SetItemChecked(14, true);
                    ChcListBoxYetkiler.SetItemChecked(15, true);
                    ChcListBoxYetkiler.SetItemChecked(16, true);
                    ChcListBoxYetkiler.SetItemChecked(17, true);
                    ChcListBoxYetkiler.SetItemChecked(18, true);
                    ChcListBoxYetkiler.SetItemChecked(19, true);
                    ChcListBoxYetkiler.SetItemChecked(20, true);
                    ChcListBoxYetkiler.SetItemChecked(21, true);
                    ChcListBoxYetkiler.SetItemChecked(22, true);
                    ChcListBoxYetkiler.SetItemChecked(23, true);
                    ChcListBoxYetkiler.SetItemChecked(24, true);
                    ChcListBoxYetkiler.SetItemChecked(25, true);
                    ChcListBoxYetkiler.SetItemChecked(26, true);
                    ChcListBoxYetkiler.SetItemChecked(27, true);
                    ChcListBoxYetkiler.SetItemChecked(28, true);
                }
                if (item == "DP01 - Veri İzleme Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(29, true);
                    ChcListBoxYetkiler.SetItemChecked(30, true);
                    ChcListBoxYetkiler.SetItemChecked(31, true);
                    ChcListBoxYetkiler.SetItemChecked(32, true);
                    ChcListBoxYetkiler.SetItemChecked(33, true);
                }
                if (item == "DP01 - Veri Giriş Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(29, true);
                    ChcListBoxYetkiler.SetItemChecked(34, true);
                    ChcListBoxYetkiler.SetItemChecked(35, true);
                    ChcListBoxYetkiler.SetItemChecked(36, true);
                    ChcListBoxYetkiler.SetItemChecked(37, true);
                }
                if (item == "ST01 - Veri İzleme Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(38, true);
                    ChcListBoxYetkiler.SetItemChecked(39, true);
                    ChcListBoxYetkiler.SetItemChecked(40, true);
                    ChcListBoxYetkiler.SetItemChecked(41, true);
                    ChcListBoxYetkiler.SetItemChecked(42, true);
                    ChcListBoxYetkiler.SetItemChecked(43, true);
                }
                if (item == "ST01 - Veri Giriş Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(38, true);
                    ChcListBoxYetkiler.SetItemChecked(44, true);
                    ChcListBoxYetkiler.SetItemChecked(45, true);
                    ChcListBoxYetkiler.SetItemChecked(46, true);
                    ChcListBoxYetkiler.SetItemChecked(47, true);
                    ChcListBoxYetkiler.SetItemChecked(48, true);
                    ChcListBoxYetkiler.SetItemChecked(49, true);
                    ChcListBoxYetkiler.SetItemChecked(50, true);
                    ChcListBoxYetkiler.SetItemChecked(51, true);
                    ChcListBoxYetkiler.SetItemChecked(52, true);
                    ChcListBoxYetkiler.SetItemChecked(53, true);
                    ChcListBoxYetkiler.SetItemChecked(54, true);
                }
                if (item == "DS01 - Veri İzleme Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(55, true);
                    ChcListBoxYetkiler.SetItemChecked(56, true);
                    ChcListBoxYetkiler.SetItemChecked(57, true);
                    ChcListBoxYetkiler.SetItemChecked(58, true);
                }

                if (item == "DS01 - Veri Giriş Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(55, true);
                    ChcListBoxYetkiler.SetItemChecked(59, true);
                    ChcListBoxYetkiler.SetItemChecked(60, true);
                    ChcListBoxYetkiler.SetItemChecked(61, true);
                }

                if (item == "ID01 - Veri Giriş Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(63, true);
                    ChcListBoxYetkiler.SetItemChecked(64, true);
                    ChcListBoxYetkiler.SetItemChecked(65, true);
                    ChcListBoxYetkiler.SetItemChecked(66, true);
                    ChcListBoxYetkiler.SetItemChecked(67, true);
                    ChcListBoxYetkiler.SetItemChecked(68, true);
                    ChcListBoxYetkiler.SetItemChecked(69, true);
                    ChcListBoxYetkiler.SetItemChecked(70, true);
                    ChcListBoxYetkiler.SetItemChecked(71, true);
                    ChcListBoxYetkiler.SetItemChecked(72, true);
                    ChcListBoxYetkiler.SetItemChecked(73, true);
                    ChcListBoxYetkiler.SetItemChecked(74, true);
                    ChcListBoxYetkiler.SetItemChecked(75, true);
                    ChcListBoxYetkiler.SetItemChecked(76, true);
                    ChcListBoxYetkiler.SetItemChecked(77, true);
                    ChcListBoxYetkiler.SetItemChecked(78, true);
                    ChcListBoxYetkiler.SetItemChecked(79, true);
                    ChcListBoxYetkiler.SetItemChecked(80, true);
                    ChcListBoxYetkiler.SetItemChecked(81, true);
                    ChcListBoxYetkiler.SetItemChecked(82, true);
                    ChcListBoxYetkiler.SetItemChecked(83, true);
                    ChcListBoxYetkiler.SetItemChecked(84, true);
                    ChcListBoxYetkiler.SetItemChecked(85, true);
                    ChcListBoxYetkiler.SetItemChecked(86, true);
                    ChcListBoxYetkiler.SetItemChecked(87, true);
                    ChcListBoxYetkiler.SetItemChecked(88, true);
                    ChcListBoxYetkiler.SetItemChecked(89, true);
                }

                if (item == "ID01 - Veri İzleme Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(90, true);
                    ChcListBoxYetkiler.SetItemChecked(91, true);
                    ChcListBoxYetkiler.SetItemChecked(92, true);
                    ChcListBoxYetkiler.SetItemChecked(93, true);
                    ChcListBoxYetkiler.SetItemChecked(94, true);
                    ChcListBoxYetkiler.SetItemChecked(95, true);
                    ChcListBoxYetkiler.SetItemChecked(96, true);
                    ChcListBoxYetkiler.SetItemChecked(97, true);
                    ChcListBoxYetkiler.SetItemChecked(98, true);
                    ChcListBoxYetkiler.SetItemChecked(99, true);
                    ChcListBoxYetkiler.SetItemChecked(100, true);
                    ChcListBoxYetkiler.SetItemChecked(101, true);
                    ChcListBoxYetkiler.SetItemChecked(102, true);
                    ChcListBoxYetkiler.SetItemChecked(103, true);
                    ChcListBoxYetkiler.SetItemChecked(104, true);
                    ChcListBoxYetkiler.SetItemChecked(105, true);
                    ChcListBoxYetkiler.SetItemChecked(106, true);
                    ChcListBoxYetkiler.SetItemChecked(107, true);
                    ChcListBoxYetkiler.SetItemChecked(108, true);
                    ChcListBoxYetkiler.SetItemChecked(109, true);
                    ChcListBoxYetkiler.SetItemChecked(110, true);
                    ChcListBoxYetkiler.SetItemChecked(111, true);
                    ChcListBoxYetkiler.SetItemChecked(112, true);
                    ChcListBoxYetkiler.SetItemChecked(113, true);
                }
                if (item == "EG01 - Veri Giriş Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(114, true);
                    ChcListBoxYetkiler.SetItemChecked(115, true);
                    ChcListBoxYetkiler.SetItemChecked(116, true);
                    ChcListBoxYetkiler.SetItemChecked(117, true);
                    ChcListBoxYetkiler.SetItemChecked(118, true);
                }
                if (item == "EG01 - Veri İzleme Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(114, true);
                    ChcListBoxYetkiler.SetItemChecked(119, true);
                    ChcListBoxYetkiler.SetItemChecked(120, true);
                    ChcListBoxYetkiler.SetItemChecked(121, true);
                }
                if (item == "DP02 - Veri İzleme Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(122, true);
                    ChcListBoxYetkiler.SetItemChecked(123, true);
                    ChcListBoxYetkiler.SetItemChecked(124, true);
                    ChcListBoxYetkiler.SetItemChecked(125, true);
                    ChcListBoxYetkiler.SetItemChecked(126, true);
                }

                if (item == "DP02 - Veri Giriş Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(122, true);
                    ChcListBoxYetkiler.SetItemChecked(127, true);
                    ChcListBoxYetkiler.SetItemChecked(128, true);
                    ChcListBoxYetkiler.SetItemChecked(129, true);
                    ChcListBoxYetkiler.SetItemChecked(130, true);
                }


                if (item == "Devam Eden Arıza İzleme" || item == "Tamamlanan Arıza İzleme" || item == "İşçilik İzleme" || item == "Bölge Yol Durum İzleme"
                    || item == "Yerleşim Kayıtları İzleme" || item == "OKF İzleme" || item == "DTF İzleme" || item == "Müşteri Bilgileri İzleme"
                    || item == "Teslimat Eksikleri İzleme" || item == "Firma Servis Formu İzleme" || item == "Destek İşçilik İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(0, true);
                    ChcListBoxYetkiler.SetItemChecked(1, true);
                }
                if (item == "Veri Kayıt (Arıza Açma)" || item == "Bildirim No Tanımlama" || item == "Veri Güncelleme" || item == "Veri Kayıt (Arıza Kapatma)"
                    || item == "Müşteri Bilgileri"
                    || item == "Bölge Yol Durumu" || item == "Yerleşim Kayıtları" || item == "Bildirim Onayı" || item == "Malzeme Temini"
                    || item == "Doğrudan Temin" || item == "Servis Talepleri" || item == "OKF Oluşturma" || item == "Teslimat Eksikleri"
                    || item == "Firma Servis Formu Kayıt" || item == "Destek İşçilik Veri Girişi")
                {
                    ChcListBoxYetkiler.SetItemChecked(0, true);
                    ChcListBoxYetkiler.SetItemChecked(13, true);
                }
                if (item == "Stok Görüntüle" || item == "Depo Hareketleri" || item == "Stokta Bulunmayan Malzemeler")
                {
                    ChcListBoxYetkiler.SetItemChecked(29, true);
                    ChcListBoxYetkiler.SetItemChecked(30, true);
                }
                if (item == "Stok Giriş/Çıkış" || item == "Malzeme Kayit Ambar" || item == "Malzeme Hazırlama")
                {
                    ChcListBoxYetkiler.SetItemChecked(29, true);
                    ChcListBoxYetkiler.SetItemChecked(34, true);
                }
                if (item == "Devam Eden SAT" || item == "Tamamlanan SAT" || item == "Reddedilen SAT" || item == "Yedek Parça Kataloğu")
                {
                    ChcListBoxYetkiler.SetItemChecked(38, true);
                    ChcListBoxYetkiler.SetItemChecked(39, true);
                }
                if (item == "Tedarikçi Firma Bilgileri" || item == "Alt Yüklenici Firma Bilgileri" || item == "SAT Oluştur" || 
                    item == "SAT Tamamlama" || item == "SAT Güncelle" || item == "SAT Ön Onay" || item == "SAT Onay" || 
                    item == "Teklif Alınacak SAT" || item == "Teklifsiz SAT" || item == "SAT Başlatma Onayı")
                {
                    ChcListBoxYetkiler.SetItemChecked(38, true);
                    ChcListBoxYetkiler.SetItemChecked(44, true);
                }
                if (item == "Doküman Sorgula" || item == "Standart Form Sorgula")
                {
                    ChcListBoxYetkiler.SetItemChecked(55, true);
                    ChcListBoxYetkiler.SetItemChecked(56, true);
                }
                if (item == "Doküman Ekle" || item == "Standart Form Ekle")
                {
                    ChcListBoxYetkiler.SetItemChecked(55, true);
                    ChcListBoxYetkiler.SetItemChecked(59, true);
                }
                if (item == "Duran Varlık")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(63, true);
                    ChcListBoxYetkiler.SetItemChecked(64, true);
                    ChcListBoxYetkiler.SetItemChecked(65, true);
                    ChcListBoxYetkiler.SetItemChecked(66, true);
                    ChcListBoxYetkiler.SetItemChecked(67, true);
                    ChcListBoxYetkiler.SetItemChecked(68, true);
                    ChcListBoxYetkiler.SetItemChecked(69, true);
                }
                if (item == "Personel")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(63, true);
                    ChcListBoxYetkiler.SetItemChecked(71, true);
                    ChcListBoxYetkiler.SetItemChecked(72, true);
                }
                if (item == "İş Akışları")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(63, true);
                    ChcListBoxYetkiler.SetItemChecked(70, true);
                    ChcListBoxYetkiler.SetItemChecked(74, true);
                    ChcListBoxYetkiler.SetItemChecked(75, true);
                    ChcListBoxYetkiler.SetItemChecked(76, true);
                    ChcListBoxYetkiler.SetItemChecked(77, true);
                    ChcListBoxYetkiler.SetItemChecked(78, true);
                    ChcListBoxYetkiler.SetItemChecked(79, true);
                }
                if (item == "Resmi Yazılar")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(63, true);
                    ChcListBoxYetkiler.SetItemChecked(81, true);
                    ChcListBoxYetkiler.SetItemChecked(82, true);
                    ChcListBoxYetkiler.SetItemChecked(83, true);
                }
                if (item == "Arşiv")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(63, true);
                }
                if (item == "Ulaştırma")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(63, true);
                    ChcListBoxYetkiler.SetItemChecked(86, true);
                    ChcListBoxYetkiler.SetItemChecked(87, true);
                    ChcListBoxYetkiler.SetItemChecked(88, true);
                    ChcListBoxYetkiler.SetItemChecked(89, true);
                }
                if (item == "Duran Varlık Kayıt" || item == "Duran Varlık Güncelleme" || item == "Duran Varlık Aktarım" || item == "Duran Varlık Arıza Kayıt"
                    || item == "DV Kalibrasyon Kayıt")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(63, true);
                    ChcListBoxYetkiler.SetItemChecked(64, true);
                }
                if (item == "Personel Giriş/Çıkış" || item == "Personel Puantaj")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(63, true);
                    ChcListBoxYetkiler.SetItemChecked(70, true);
                }
                if (item == "Yurt İçi Görev" || item == "Şehir İçi Görev" || item == "İzin" || item == "Konaklama"
                    || item == "Uçak ve Otobüs Bileti" || item == "Harcama Beyannamesi")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(63, true);
                    ChcListBoxYetkiler.SetItemChecked(73, true);
                }
                if (item == "Gelen Resmi Yazılar" || item == "Giden Resmi Yazılar" || item == "Evrak Kayıt")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(63, true);
                    ChcListBoxYetkiler.SetItemChecked(80, true);
                }
                if (item == "Araç Tahsis Kayıt" || item == "Araç Yakıt Beyanı" || item == "Araç Peryodik Bakım" || item == "Arac Bakım Onarım")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(63, true);
                    ChcListBoxYetkiler.SetItemChecked(85, true);
                }
                if (item == "Duran Varlık İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(90, true);
                    ChcListBoxYetkiler.SetItemChecked(92, true);
                    ChcListBoxYetkiler.SetItemChecked(93, true);
                    ChcListBoxYetkiler.SetItemChecked(94, true);
                    ChcListBoxYetkiler.SetItemChecked(95, true);
                }
                if (item == "Duran Varlık Takibi" || item == "DV Zimmet Takibi" || item == "DV Arıza Takibi" || item == "DV Kalibrasyon Takibi")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(90, true);
                    ChcListBoxYetkiler.SetItemChecked(91, true);
                }
                if (item == "Personel İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(90, true);
                    ChcListBoxYetkiler.SetItemChecked(97, true);
                    ChcListBoxYetkiler.SetItemChecked(98, true);
                    ChcListBoxYetkiler.SetItemChecked(99, true);
                }
                if (item == "Personel Listesi (Çalışan)" || item == "Personel Listesi (İşten Ayrılan)" || item == "Personel Puantaj")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(90, true);
                    ChcListBoxYetkiler.SetItemChecked(96, true);
                }
                if (item == "İş Akışları İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(90, true);
                    ChcListBoxYetkiler.SetItemChecked(101, true);
                    ChcListBoxYetkiler.SetItemChecked(102, true);
                    ChcListBoxYetkiler.SetItemChecked(103, true);
                    ChcListBoxYetkiler.SetItemChecked(104, true);
                    ChcListBoxYetkiler.SetItemChecked(105, true);
                    ChcListBoxYetkiler.SetItemChecked(106, true);
                }
                if (item == "Yurt İçi Görev" || item == "Şehir İçi Görev" || item == "Şehir İçi Görev" || item == "İzin"
                    || item == "Konaklama" || item == "Uçak ve Otobüs Bileti" || item == "Harcama Beyannamesi İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(90, true);
                    ChcListBoxYetkiler.SetItemChecked(100, true);
                }
                if (item == "Gelen Giden Resmi Yazı İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(90, true);
                }
                if (item == "Arşiv İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(90, true);
                }
                if (item == "Ulaştırma İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(90, true);
                    ChcListBoxYetkiler.SetItemChecked(110, true);
                    ChcListBoxYetkiler.SetItemChecked(111, true);
                    ChcListBoxYetkiler.SetItemChecked(112, true);
                    ChcListBoxYetkiler.SetItemChecked(113, true);
                }
                if (item == "Araç Tahsis İzleme" || item == "Araç Yakıt Beyan İzleme" || item == "Araç Periyodik Bakım İzleme"
                    || item == "Araç Bakım Onarım İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, true);
                    ChcListBoxYetkiler.SetItemChecked(90, true);
                    ChcListBoxYetkiler.SetItemChecked(109, true);
                }
                if (item == "Eğitim Veri Girişi" || item == "Eğitim Planı Oluştur" || item == "Eğitim Planı Güncelle")
                {
                    ChcListBoxYetkiler.SetItemChecked(114, true);
                    ChcListBoxYetkiler.SetItemChecked(115, true);
                }
                if (item == "Eğitim İzleme" || item == "Eğitim Planı İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(114, true);
                    ChcListBoxYetkiler.SetItemChecked(119, true);
                }
                if (item == "Stok Goruntule Depo" || item == "Depo Hareketleri Depo" || item == "Stokta Bulunmayan Malzemeler")
                {
                    ChcListBoxYetkiler.SetItemChecked(122, true);
                    ChcListBoxYetkiler.SetItemChecked(123, true);
                }
                if (item == "Stok Giris" || item == "Malzeme Kayıt" || item == "Mazleme Hazırlama")
                {
                    ChcListBoxYetkiler.SetItemChecked(122, true);
                    ChcListBoxYetkiler.SetItemChecked(127, true);
                }

            }
            else
            {
                SetChcListItemChecked("BO01 BAKIM ONARIM", 1, 28, false);
                SetChcListItemChecked("DP01 GEÇİCİ KABUL VE AMBAR", 29, 37, false);
                SetChcListItemChecked("ST01 SATIN ALMA", 38, 54, false);
                SetChcListItemChecked("DS01 DOKÜMAN YÖNETİM SİSTEMİ", 55, 61, false);
                SetChcListItemChecked("ID01 İDARİ İŞLER", 62, 1113, false);
                SetChcListItemChecked("EG01 EĞİTİM", 114, 121, false);
                SetChcListItemChecked("DP02 DESTEK DEPO", 122, 130, false);
                SetChcListItemChecked("RP01 RAPORLAMALAR", 131, 133, false);


                if (item == "BO01 - Veri İzleme Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(0, false);
                    ChcListBoxYetkiler.SetItemChecked(1, false);
                    ChcListBoxYetkiler.SetItemChecked(2, false);
                    ChcListBoxYetkiler.SetItemChecked(3, false);
                    ChcListBoxYetkiler.SetItemChecked(4, false);
                    ChcListBoxYetkiler.SetItemChecked(5, false);
                    ChcListBoxYetkiler.SetItemChecked(6, false);
                    ChcListBoxYetkiler.SetItemChecked(7, false);
                    ChcListBoxYetkiler.SetItemChecked(8, false);
                    ChcListBoxYetkiler.SetItemChecked(9, false);
                    ChcListBoxYetkiler.SetItemChecked(10, false);
                    ChcListBoxYetkiler.SetItemChecked(11, false);
                    ChcListBoxYetkiler.SetItemChecked(12, false);
                }
                if (item == "BO01 - Veri Giriş Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(0, false);
                    ChcListBoxYetkiler.SetItemChecked(13, false);
                    ChcListBoxYetkiler.SetItemChecked(14, false);
                    ChcListBoxYetkiler.SetItemChecked(15, false);
                    ChcListBoxYetkiler.SetItemChecked(16, false);
                    ChcListBoxYetkiler.SetItemChecked(17, false);
                    ChcListBoxYetkiler.SetItemChecked(18, false);
                    ChcListBoxYetkiler.SetItemChecked(19, false);
                    ChcListBoxYetkiler.SetItemChecked(20, false);
                    ChcListBoxYetkiler.SetItemChecked(21, false);
                    ChcListBoxYetkiler.SetItemChecked(22, false);
                    ChcListBoxYetkiler.SetItemChecked(23, false);
                    ChcListBoxYetkiler.SetItemChecked(24, false);
                    ChcListBoxYetkiler.SetItemChecked(25, false);
                    ChcListBoxYetkiler.SetItemChecked(26, false);
                    ChcListBoxYetkiler.SetItemChecked(27, false);
                    ChcListBoxYetkiler.SetItemChecked(28, false);
                }
                if (item == "DP01 - Veri İzleme Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(29, false);
                    ChcListBoxYetkiler.SetItemChecked(30, false);
                    ChcListBoxYetkiler.SetItemChecked(31, false);
                    ChcListBoxYetkiler.SetItemChecked(32, false);
                    ChcListBoxYetkiler.SetItemChecked(33, false);
                }
                if (item == "DP01 - Veri Giriş Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(29, false);
                    ChcListBoxYetkiler.SetItemChecked(34, false);
                    ChcListBoxYetkiler.SetItemChecked(35, false);
                    ChcListBoxYetkiler.SetItemChecked(36, false);
                    ChcListBoxYetkiler.SetItemChecked(37, false);
                }
                if (item == "ST01 - Veri İzleme Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(38, false);
                    ChcListBoxYetkiler.SetItemChecked(39, false);
                    ChcListBoxYetkiler.SetItemChecked(40, false);
                    ChcListBoxYetkiler.SetItemChecked(41, false);
                    ChcListBoxYetkiler.SetItemChecked(42, false);
                    ChcListBoxYetkiler.SetItemChecked(43, false);
                }
                if (item == "ST01 - Veri Giriş Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(38, false);
                    ChcListBoxYetkiler.SetItemChecked(44, false);
                    ChcListBoxYetkiler.SetItemChecked(45, false);
                    ChcListBoxYetkiler.SetItemChecked(46, false);
                    ChcListBoxYetkiler.SetItemChecked(47, false);
                    ChcListBoxYetkiler.SetItemChecked(48, false);
                    ChcListBoxYetkiler.SetItemChecked(49, false);
                    ChcListBoxYetkiler.SetItemChecked(50, false);
                    ChcListBoxYetkiler.SetItemChecked(51, false);
                    ChcListBoxYetkiler.SetItemChecked(52, false);
                    ChcListBoxYetkiler.SetItemChecked(53, false);
                    ChcListBoxYetkiler.SetItemChecked(54, false);
                }
                if (item == "DS01 - Veri İzleme Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(55, false);
                    ChcListBoxYetkiler.SetItemChecked(56, false);
                    ChcListBoxYetkiler.SetItemChecked(57, false);
                    ChcListBoxYetkiler.SetItemChecked(58, false);
                }

                if (item == "DS01 - Veri Giriş Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(55, false);
                    ChcListBoxYetkiler.SetItemChecked(59, false);
                    ChcListBoxYetkiler.SetItemChecked(60, false);
                    ChcListBoxYetkiler.SetItemChecked(61, false);
                }

                if (item == "ID01 - Veri Giriş Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(63, false);
                    ChcListBoxYetkiler.SetItemChecked(64, false);
                    ChcListBoxYetkiler.SetItemChecked(65, false);
                    ChcListBoxYetkiler.SetItemChecked(66, false);
                    ChcListBoxYetkiler.SetItemChecked(67, false);
                    ChcListBoxYetkiler.SetItemChecked(68, false);
                    ChcListBoxYetkiler.SetItemChecked(69, false);
                    ChcListBoxYetkiler.SetItemChecked(70, false);
                    ChcListBoxYetkiler.SetItemChecked(71, false);
                    ChcListBoxYetkiler.SetItemChecked(72, false);
                    ChcListBoxYetkiler.SetItemChecked(73, false);
                    ChcListBoxYetkiler.SetItemChecked(74, false);
                    ChcListBoxYetkiler.SetItemChecked(75, false);
                    ChcListBoxYetkiler.SetItemChecked(76, false);
                    ChcListBoxYetkiler.SetItemChecked(77, false);
                    ChcListBoxYetkiler.SetItemChecked(78, false);
                    ChcListBoxYetkiler.SetItemChecked(79, false);
                    ChcListBoxYetkiler.SetItemChecked(80, false);
                    ChcListBoxYetkiler.SetItemChecked(81, false);
                    ChcListBoxYetkiler.SetItemChecked(82, false);
                    ChcListBoxYetkiler.SetItemChecked(83, false);
                    ChcListBoxYetkiler.SetItemChecked(84, false);
                    ChcListBoxYetkiler.SetItemChecked(85, false);
                    ChcListBoxYetkiler.SetItemChecked(86, false);
                    ChcListBoxYetkiler.SetItemChecked(87, false);
                    ChcListBoxYetkiler.SetItemChecked(88, false);
                    ChcListBoxYetkiler.SetItemChecked(89, false);
                }

                if (item == "ID01 - Veri İzleme Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(90, false);
                    ChcListBoxYetkiler.SetItemChecked(91, false);
                    ChcListBoxYetkiler.SetItemChecked(92, false);
                    ChcListBoxYetkiler.SetItemChecked(93, false);
                    ChcListBoxYetkiler.SetItemChecked(94, false);
                    ChcListBoxYetkiler.SetItemChecked(95, false);
                    ChcListBoxYetkiler.SetItemChecked(96, false);
                    ChcListBoxYetkiler.SetItemChecked(97, false);
                    ChcListBoxYetkiler.SetItemChecked(98, false);
                    ChcListBoxYetkiler.SetItemChecked(99, false);
                    ChcListBoxYetkiler.SetItemChecked(100, false);
                    ChcListBoxYetkiler.SetItemChecked(101, false);
                    ChcListBoxYetkiler.SetItemChecked(102, false);
                    ChcListBoxYetkiler.SetItemChecked(103, false);
                    ChcListBoxYetkiler.SetItemChecked(104, false);
                    ChcListBoxYetkiler.SetItemChecked(105, false);
                    ChcListBoxYetkiler.SetItemChecked(106, false);
                    ChcListBoxYetkiler.SetItemChecked(107, false);
                    ChcListBoxYetkiler.SetItemChecked(108, false);
                    ChcListBoxYetkiler.SetItemChecked(109, false);
                    ChcListBoxYetkiler.SetItemChecked(110, false);
                    ChcListBoxYetkiler.SetItemChecked(111, false);
                    ChcListBoxYetkiler.SetItemChecked(112, false);
                    ChcListBoxYetkiler.SetItemChecked(113, false);
                }
                if (item == "EG01 - Veri Giriş Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(114, false);
                    ChcListBoxYetkiler.SetItemChecked(115, false);
                    ChcListBoxYetkiler.SetItemChecked(116, false);
                    ChcListBoxYetkiler.SetItemChecked(117, false);
                    ChcListBoxYetkiler.SetItemChecked(118, false);
                }
                if (item == "EG01 - Veri İzleme Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(114, false);
                    ChcListBoxYetkiler.SetItemChecked(119, false);
                    ChcListBoxYetkiler.SetItemChecked(120, false);
                    ChcListBoxYetkiler.SetItemChecked(121, false);
                }
                if (item == "DP02 - Veri İzleme Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(122, false);
                    ChcListBoxYetkiler.SetItemChecked(123, false);
                    ChcListBoxYetkiler.SetItemChecked(124, false);
                    ChcListBoxYetkiler.SetItemChecked(125, false);
                    ChcListBoxYetkiler.SetItemChecked(126, false);
                }

                if (item == "DP02 - Veri Giriş Ekranları")
                {
                    ChcListBoxYetkiler.SetItemChecked(122, false);
                    ChcListBoxYetkiler.SetItemChecked(127, false);
                    ChcListBoxYetkiler.SetItemChecked(128, false);
                    ChcListBoxYetkiler.SetItemChecked(129, false);
                    ChcListBoxYetkiler.SetItemChecked(130, false);
                }


                if (item == "Devam Eden Arıza İzleme" || item == "Tamamlanan Arıza İzleme" || item == "İşçilik İzleme" || item == "Bölge Yol Durum İzleme"
                    || item == "Yerleşim Kayıtları İzleme" || item == "OKF İzleme" || item == "DTF İzleme" || item == "Müşteri Bilgileri İzleme"
                    || item == "Teslimat Eksikleri İzleme" || item == "Firma Servis Formu İzleme" || item == "Destek İşçilik İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(0, false);
                    ChcListBoxYetkiler.SetItemChecked(1, false);
                }
                if (item == "Veri Kayıt (Arıza Açma)" || item == "Bildirim No Tanımlama" || item == "Veri Güncelleme" || item == "Veri Kayıt (Arıza Kapatma)"
                    || item == "Müşteri Bilgileri"
                    || item == "Bölge Yol Durumu" || item == "Yerleşim Kayıtları" || item == "Bildirim Onayı" || item == "Malzeme Temini"
                    || item == "Doğrudan Temin" || item == "Servis Talepleri" || item == "OKF Oluşturma" || item == "Teslimat Eksikleri"
                    || item == "Firma Servis Formu Kayıt" || item == "Destek İşçilik Veri Girişi")
                {
                    ChcListBoxYetkiler.SetItemChecked(0, false);
                    ChcListBoxYetkiler.SetItemChecked(13, false);
                }
                if (item == "Stok Görüntüle" || item == "Depo Hareketleri" || item == "Stokta Bulunmayan Malzemeler")
                {
                    ChcListBoxYetkiler.SetItemChecked(29, false);
                    ChcListBoxYetkiler.SetItemChecked(30, false);
                }
                if (item == "Stok Giriş/Çıkış" || item == "Malzeme Kayit Ambar" || item == "Malzeme Hazırlama")
                {
                    ChcListBoxYetkiler.SetItemChecked(29, false);
                    ChcListBoxYetkiler.SetItemChecked(34, false);
                }
                if (item == "Devam Eden SAT" || item == "Tamamlanan SAT" || item == "Reddedilen SAT" || item == "Yedek Parça Kataloğu")
                {
                    ChcListBoxYetkiler.SetItemChecked(38, false);
                    ChcListBoxYetkiler.SetItemChecked(39, false);
                }
                if (item == "Tedarikçi Firma Bilgileri" || item == "Alt Yüklenici Firma Bilgileri" || item == "SAT Oluştur" ||
                    item == "SAT Tamamlama" || item == "SAT Güncelle" || item == "SAT Ön Onay" || item == "SAT Onay" ||
                    item == "Teklif Alınacak SAT" || item == "Teklifsiz SAT" || item == "SAT Başlatma Onayı")
                {
                    ChcListBoxYetkiler.SetItemChecked(38, false);
                    ChcListBoxYetkiler.SetItemChecked(44, false);
                }
                if (item == "Doküman Sorgula" || item == "Standart Form Sorgula")
                {
                    ChcListBoxYetkiler.SetItemChecked(55, false);
                    ChcListBoxYetkiler.SetItemChecked(56, false);
                }
                if (item == "Doküman Ekle" || item == "Standart Form Ekle")
                {
                    ChcListBoxYetkiler.SetItemChecked(55, false);
                    ChcListBoxYetkiler.SetItemChecked(59, false);
                }
                if (item == "Duran Varlık")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(63, false);
                    ChcListBoxYetkiler.SetItemChecked(64, false);
                    ChcListBoxYetkiler.SetItemChecked(65, false);
                    ChcListBoxYetkiler.SetItemChecked(66, false);
                    ChcListBoxYetkiler.SetItemChecked(67, false);
                    ChcListBoxYetkiler.SetItemChecked(68, false);
                    ChcListBoxYetkiler.SetItemChecked(69, false);
                }
                if (item == "Personel")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(63, false);
                    ChcListBoxYetkiler.SetItemChecked(71, false);
                    ChcListBoxYetkiler.SetItemChecked(72, false);
                }
                if (item == "İş Akışları")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(63, false);
                    ChcListBoxYetkiler.SetItemChecked(70, false);
                    ChcListBoxYetkiler.SetItemChecked(74, false);
                    ChcListBoxYetkiler.SetItemChecked(75, false);
                    ChcListBoxYetkiler.SetItemChecked(76, false);
                    ChcListBoxYetkiler.SetItemChecked(77, false);
                    ChcListBoxYetkiler.SetItemChecked(78, false);
                    ChcListBoxYetkiler.SetItemChecked(79, false);
                }
                if (item == "Resmi Yazılar")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(63, false);
                    ChcListBoxYetkiler.SetItemChecked(81, false);
                    ChcListBoxYetkiler.SetItemChecked(82, false);
                    ChcListBoxYetkiler.SetItemChecked(83, false);
                }
                if (item == "Arşiv")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(63, false);
                }
                if (item == "Ulaştırma")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(63, false);
                    ChcListBoxYetkiler.SetItemChecked(86, false);
                    ChcListBoxYetkiler.SetItemChecked(87, false);
                    ChcListBoxYetkiler.SetItemChecked(88, false);
                    ChcListBoxYetkiler.SetItemChecked(89, false);
                }
                if (item == "Duran Varlık Kayıt" || item == "Duran Varlık Güncelleme" || item == "Duran Varlık Aktarım" || item == "Duran Varlık Arıza Kayıt"
                    || item == "DV Kalibrasyon Kayıt")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(63, false);
                    ChcListBoxYetkiler.SetItemChecked(64, false);
                }
                if (item == "Personel Giriş/Çıkış" || item == "Personel Puantaj")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(63, false);
                    ChcListBoxYetkiler.SetItemChecked(70, false);
                }
                if (item == "Yurt İçi Görev" || item == "Şehir İçi Görev" || item == "İzin" || item == "Konaklama"
                    || item == "Uçak ve Otobüs Bileti" || item == "Harcama Beyannamesi")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(63, false);
                    ChcListBoxYetkiler.SetItemChecked(73, false);
                }
                if (item == "Gelen Resmi Yazılar" || item == "Giden Resmi Yazılar" || item == "Evrak Kayıt")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(63, false);
                    ChcListBoxYetkiler.SetItemChecked(80, false);
                }
                if (item == "Araç Tahsis Kayıt" || item == "Araç Yakıt Beyanı" || item == "Araç Peryodik Bakım" || item == "Arac Bakım Onarım")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(63, false);
                    ChcListBoxYetkiler.SetItemChecked(85, false);
                }
                if (item == "Duran Varlık İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(90, false);
                    ChcListBoxYetkiler.SetItemChecked(92, false);
                    ChcListBoxYetkiler.SetItemChecked(93, false);
                    ChcListBoxYetkiler.SetItemChecked(94, false);
                    ChcListBoxYetkiler.SetItemChecked(95, false);
                }
                if (item == "Duran Varlık Takibi" || item == "DV Zimmet Takibi" || item == "DV Arıza Takibi" || item == "DV Kalibrasyon Takibi")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(90, false);
                    ChcListBoxYetkiler.SetItemChecked(91, false);
                }
                if (item == "Personel İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(90, false);
                    ChcListBoxYetkiler.SetItemChecked(97, false);
                    ChcListBoxYetkiler.SetItemChecked(98, false);
                    ChcListBoxYetkiler.SetItemChecked(99, false);
                }
                if (item == "Personel Listesi (Çalışan)" || item == "Personel Listesi (İşten Ayrılan)" || item == "Personel Puantaj")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(90, false);
                    ChcListBoxYetkiler.SetItemChecked(96, false);
                }
                if (item == "İş Akışları İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(90, false);
                    ChcListBoxYetkiler.SetItemChecked(101, false);
                    ChcListBoxYetkiler.SetItemChecked(102, false);
                    ChcListBoxYetkiler.SetItemChecked(103, false);
                    ChcListBoxYetkiler.SetItemChecked(104, false);
                    ChcListBoxYetkiler.SetItemChecked(105, false);
                    ChcListBoxYetkiler.SetItemChecked(106, false);
                }
                if (item == "Yurt İçi Görev" || item == "Şehir İçi Görev" || item == "Şehir İçi Görev" || item == "İzin"
                    || item == "Konaklama" || item == "Uçak ve Otobüs Bileti" || item == "Harcama Beyannamesi İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(90, false);
                    ChcListBoxYetkiler.SetItemChecked(100, false);
                }
                if (item == "Gelen Giden Resmi Yazı İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(90, false);
                }
                if (item == "Arşiv İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(90, false);
                }
                if (item == "Ulaştırma İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(90, false);
                    ChcListBoxYetkiler.SetItemChecked(110, false);
                    ChcListBoxYetkiler.SetItemChecked(111, false);
                    ChcListBoxYetkiler.SetItemChecked(112, false);
                    ChcListBoxYetkiler.SetItemChecked(113, false);
                }
                if (item == "Araç Tahsis İzleme" || item == "Araç Yakıt Beyan İzleme" || item == "Araç Periyodik Bakım İzleme"
                    || item == "Araç Bakım Onarım İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(62, false);
                    ChcListBoxYetkiler.SetItemChecked(90, false);
                    ChcListBoxYetkiler.SetItemChecked(109, false);
                }
                if (item == "Eğitim Veri Girişi" || item == "Eğitim Planı Oluştur" || item == "Eğitim Planı Güncelle")
                {
                    ChcListBoxYetkiler.SetItemChecked(114, false);
                    ChcListBoxYetkiler.SetItemChecked(115, false);
                }
                if (item == "Eğitim İzleme" || item == "Eğitim Planı İzleme")
                {
                    ChcListBoxYetkiler.SetItemChecked(114, false);
                    ChcListBoxYetkiler.SetItemChecked(119, false);
                }
                if (item == "Stok Goruntule Depo" || item == "Depo Hareketleri Depo" || item == "Stokta Bulunmayan Malzemeler")
                {
                    ChcListBoxYetkiler.SetItemChecked(122, false);
                    ChcListBoxYetkiler.SetItemChecked(123, false);
                }
                if (item == "Stok Giris" || item == "Malzeme Kayıt" || item == "Mazleme Hazırlama")
                {
                    ChcListBoxYetkiler.SetItemChecked(122, false);
                    ChcListBoxYetkiler.SetItemChecked(127, false);
                }


            }
            checkControl = false;
        }

        void SetChcListItemChecked(string header, int startIndex, int lastIndex, bool isChecked)
        {
            if (ChcListBoxYetkiler.SelectedItem.ToString().Trim() == header)
            {
                for (int i = startIndex; i <= lastIndex; i++)
                {
                    ChcListBoxYetkiler.SetItemChecked(i, isChecked);
                }
            }
        }

        private void BtnTumYetki_Click(object sender, EventArgs e)
        {
            if (BtnYetki.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Bir Personel Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < ChcListBoxYetkiler.Items.Count; i++)
            {
                ChcListBoxYetkiler.SetItemChecked(i, true);
            }
        }
        
        private void cmbYetkiler_SelectedValueChanged(object sender, EventArgs e)
        {
            if (start)
            {
                return;
            }
            if (BtnYetki.SelectedValue.ConInt() < 1)
            {
                return;
            }
            id = BtnYetki.SelectedValue.ConInt();
            RestartChcList();
            authId = BtnYetki.SelectedValue.ConInt();

            array = yetkiler.Where(x => x.Id == authId).Select(x => x.IzinIdleri.Split(';')).FirstOrDefault();

            /*foreach (Yetki item in yetkiler)
            {
                if (item.Id == cmbYetkiler.SelectedValue.ConInt())
                {
                    string izinler=item.IzinIdleri;
                    array = izinler.Split(';');
                }
            }*/

            ControlChcList();
        }
        
        #region ControlChcList
        void ControlChcList()
        {
            if (authId == 1)
            {
                checkControl = true;
                for (int i = 0; i < ChcListBoxYetkiler.Items.Count; i++)
                {
                    ChcListBoxYetkiler.SetItemChecked(i, true);
                }
                checkControl = false;
                return;
            }

            if (array.Contains("1"))
            {
                ChcListBoxYetkiler.SetItemChecked(0, true);
                control = 1;
            }
            if (control == 1)
            {
                if (array.Contains("2"))
                {
                    ChcListBoxYetkiler.SetItemChecked(1, true);
                    gir = 1;
                }
                if (gir == 1)
                {
                    if (array.Contains("3"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(2, true);
                    }
                    if (array.Contains("4"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(3, true);
                    }
                    if (array.Contains("5"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(4, true);
                    }
                    if (array.Contains("6"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(5, true);
                    }
                    if (array.Contains("7"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(6, true);
                    }
                    if (array.Contains("8"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(7, true);
                    }
                    if (array.Contains("9"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(8, true);
                    }
                    if (array.Contains("10"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(9, true);
                    }
                    if (array.Contains("11"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(10, true);
                    }
                    if (array.Contains("12"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(11, true);
                    }
                    if (array.Contains("13"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(12, true);
                    }
                    if (array.Contains("14"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(13, true);
                        gir = 2;
                    }
                }
                if (gir == 2)
                {
                    if (array.Contains("15"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(14, true);
                    }
                    if (array.Contains("16"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(15, true);
                    }
                    if (array.Contains("17"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(16, true);
                    }
                    if (array.Contains("18"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(17, true);
                    }
                    if (array.Contains("19"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(18, true);
                    }
                    if (array.Contains("20"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(19, true);
                    }
                    if (array.Contains("21"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(20, true);
                    }
                    if (array.Contains("22"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(21, true);
                    }
                    if (array.Contains("23"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(22, true);
                    }
                    if (array.Contains("24"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(23, true);
                    }
                    if (array.Contains("25"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(24, true);
                    }
                    if (array.Contains("26"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(25, true);
                    }
                    if (array.Contains("27"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(26, true);
                    }
                    if (array.Contains("28"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(27, true);
                    }
                    if (array.Contains("29"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(28, true);
                    }
                }
            }
            if (array.Contains("30"))
            {
                ChcListBoxYetkiler.SetItemChecked(29, true);
                control = 2;
            }
            if (control == 2)
            {
                if (array.Contains("31"))
                {
                    ChcListBoxYetkiler.SetItemChecked(30, true);
                    gir = 3;
                }
                if (gir == 3)
                {
                    if (array.Contains("32"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(31, true);
                    }
                    if (array.Contains("33"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(32, true);
                    }
                    if (array.Contains("34"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(33, true);
                    }
                }
                if (array.Contains("35"))
                {
                    ChcListBoxYetkiler.SetItemChecked(34, true);
                    gir = 4;
                }
                if (gir == 4)
                {
                    if (array.Contains("36"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(35, true);
                    }
                    if (array.Contains("37"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(36, true);
                    }
                    if (array.Contains("38"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(37, true);
                    }
                }
            }
            if (array.Contains("39"))
            {
                ChcListBoxYetkiler.SetItemChecked(38, true);
                control = 3;
            }
            if (control == 3)
            {
                if (array.Contains("40"))
                {
                    ChcListBoxYetkiler.SetItemChecked(39, true);
                    gir = 5;
                }
                if (gir == 5)
                {
                    if (array.Contains("41"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(40, true);
                    }
                    if (array.Contains("42"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(41, true);
                    }
                    if (array.Contains("43"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(42, true);
                    }
                    if (array.Contains("44"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(43, true);
                    }
                }
                if (array.Contains("45"))
                {
                    ChcListBoxYetkiler.SetItemChecked(44, true);
                    gir = 6;
                }
                if (gir == 6)
                {
                    if (array.Contains("46"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(45, true);
                    }
                    if (array.Contains("47"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(46, true);
                    }
                    if (array.Contains("48"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(47, true);
                    }
                    if (array.Contains("49"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(48, true);
                    }
                    if (array.Contains("50"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(49, true);
                    }
                    if (array.Contains("51"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(50, true);
                    }
                    if (array.Contains("52"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(51, true);
                    }
                    if (array.Contains("53"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(52, true);
                    }
                    if (array.Contains("54"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(53, true);
                    }
                    if (array.Contains("55"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(54, true);
                    }
                }
            }
            if (array.Contains("56"))
            {
                ChcListBoxYetkiler.SetItemChecked(55, true);
                control = 4;
            }
            if (control == 4)
            {
                if (array.Contains("57"))
                {
                    ChcListBoxYetkiler.SetItemChecked(56, true);
                    gir = 7;
                }
                if (gir == 7)
                {
                    if (array.Contains("58"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(57, true);
                    }
                    if (array.Contains("59"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(58, true);
                    }
                }
                if (array.Contains("60"))
                {
                    ChcListBoxYetkiler.SetItemChecked(59, true);
                    gir = 8;
                }
                if (gir == 8)
                {
                    if (array.Contains("61"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(60, true);
                    }
                    if (array.Contains("62"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(61, true);
                    }
                }
            }
            if (array.Contains("63"))
            {
                ChcListBoxYetkiler.SetItemChecked(62, true);
                control = 5;
            }
            if (control == 5)
            {
                if (array.Contains("64"))
                {
                    ChcListBoxYetkiler.SetItemChecked(63, true);
                    gir = 9;
                    if (gir == 9)
                    {
                        if (array.Contains("65"))
                        {
                            ChcListBoxYetkiler.SetItemChecked(64, true);
                            girdal = 1;
                        }
                        if (girdal == 1)
                        {
                            if (array.Contains("66"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(65, true);
                            }
                            if (array.Contains("67"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(66, true);
                            }
                            if (array.Contains("68"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(67, true);
                            }
                            if (array.Contains("69"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(68, true);
                            }
                            if (array.Contains("70"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(69, true);
                            }
                        }
                        if (array.Contains("71"))
                        {
                            ChcListBoxYetkiler.SetItemChecked(70, true);
                            girdal = 2;
                        }
                        if (girdal == 2)
                        {
                            if (array.Contains("72"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(71, true);
                            }
                            if (array.Contains("73"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(72, true);
                            }
                        }
                        if (array.Contains("74"))
                        {
                            ChcListBoxYetkiler.SetItemChecked(73, true);
                            girdal = 3;
                        }
                        if (girdal == 3)
                        {
                            if (array.Contains("75"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(74, true);
                            }
                            if (array.Contains("76"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(75, true);
                            }
                            if (array.Contains("77"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(76, true);
                            }
                            if (array.Contains("78"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(77, true);
                            }
                            if (array.Contains("79"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(78, true);
                            }
                            if (array.Contains("80"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(79, true);
                            }
                        }
                        if (array.Contains("81"))
                        {
                            ChcListBoxYetkiler.SetItemChecked(80, true);
                            girdal = 4;
                        }
                        if (girdal == 4)
                        {
                            if (array.Contains("82"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(81, true);
                            }
                            if (array.Contains("83"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(82, true);
                            }
                            if (array.Contains("84"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(83, true);
                            }
                        }
                        if (array.Contains("85"))
                        {
                            ChcListBoxYetkiler.SetItemChecked(84, true);
                        }
                        if (array.Contains("86"))
                        {
                            ChcListBoxYetkiler.SetItemChecked(85, true);
                            girdal = 5;
                        }
                        if (girdal == 5)
                        {
                            if (array.Contains("87"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(86, true);
                            }
                            if (array.Contains("88"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(87, true);
                            }
                            if (array.Contains("89"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(88, true);
                            }
                            if (array.Contains("90"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(89, true);
                            }
                        }
                    }
                    if (array.Contains("91"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(90, true);
                        gir = 10;
                    }
                    if (gir == 10)
                    {
                        if (array.Contains("92"))
                        {
                            ChcListBoxYetkiler.SetItemChecked(91, true);
                            girdal = 6;
                        }
                        if (girdal == 6)
                        {
                            if (array.Contains("93"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(92, true);
                            }
                            if (array.Contains("94"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(93, true);
                            }
                            if (array.Contains("95"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(94, true);
                            }
                            if (array.Contains("96"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(95, true);
                            }
                        }
                        if (array.Contains("97"))
                        {
                            ChcListBoxYetkiler.SetItemChecked(96, true);
                            girdal = 7;
                        }
                        if (girdal == 7)
                        {
                            if (array.Contains("98"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(97, true);
                            }
                            if (array.Contains("99"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(98, true);
                            }
                            if (array.Contains("100"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(99, true);
                            }
                        }
                        if (array.Contains("101"))
                        {
                            ChcListBoxYetkiler.SetItemChecked(100, true);
                            girdal = 8;
                        }
                        if (girdal == 8)
                        {
                            if (array.Contains("102"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(101, true);
                            }
                            if (array.Contains("103"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(102, true);
                            }
                            if (array.Contains("104"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(103, true);
                            }
                            if (array.Contains("105"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(104, true);
                            }
                            if (array.Contains("106"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(105, true);
                            }
                            if (array.Contains("107"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(106, true);
                            }
                        }
                        if (array.Contains("108"))
                        {
                            ChcListBoxYetkiler.SetItemChecked(107, true);
                        }
                        if (array.Contains("109"))
                        {
                            ChcListBoxYetkiler.SetItemChecked(108, true);
                        }
                        if (array.Contains("110"))
                        {
                            ChcListBoxYetkiler.SetItemChecked(109, true);
                            girdal = 9;
                        }
                        if (girdal == 9)
                        {
                            if (array.Contains("111"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(110, true);
                            }
                            if (array.Contains("112"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(111, true);
                            }
                            if (array.Contains("113"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(112, true);
                            }
                            if (array.Contains("114"))
                            {
                                ChcListBoxYetkiler.SetItemChecked(113, true);
                            }
                        }
                    }
                }
            }
            if (array.Contains("115"))
            {
                ChcListBoxYetkiler.SetItemChecked(114, true);
                control = 6;
            }
            if (control == 6)
            {
                if (array.Contains("116"))
                {
                    ChcListBoxYetkiler.SetItemChecked(115, true);
                    gir = 11;
                }
                if (gir == 11)
                {
                    if (array.Contains("117"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(116, true);
                    }
                    if (array.Contains("118"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(117, true);
                    }
                    if (array.Contains("119"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(118, true);
                    }
                }
                if (array.Contains("120"))
                {
                    ChcListBoxYetkiler.SetItemChecked(119, true);
                    gir = 12;
                }
                if (gir == 12)
                {
                    if (array.Contains("121"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(120, true);
                    }
                    if (array.Contains("122"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(121, true);
                    }
                }
            }
            if (array.Contains("123"))
            {
                ChcListBoxYetkiler.SetItemChecked(122, true);
                control = 7;
            }
            if (control == 7)
            {
                if (array.Contains("124"))
                {
                    ChcListBoxYetkiler.SetItemChecked(123, true);
                    gir = 13;
                }
                if (gir == 13)
                {
                    if (array.Contains("125"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(124, true);
                    }
                    if (array.Contains("126"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(125, true);
                    }
                    if (array.Contains("127"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(126, true);
                    }
                }
                if (array.Contains("128"))
                {
                    ChcListBoxYetkiler.SetItemChecked(127, true);
                    gir = 14;
                }
                if (gir == 14)
                {
                    if (array.Contains("129"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(128, true);
                    }
                    if (array.Contains("130"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(129, true);
                    }
                    if (array.Contains("131"))
                    {
                        ChcListBoxYetkiler.SetItemChecked(130, true);
                    }
                }
            }
            if (array.Contains("132"))
            {
                ChcListBoxYetkiler.SetItemChecked(131, true);
                control = 8;
            }
            if (control == 8)
            {
                if (array.Contains("133"))
                {
                    ChcListBoxYetkiler.SetItemChecked(132, true);
                }
                if (array.Contains("134"))
                {
                    ChcListBoxYetkiler.SetItemChecked(133, true);
                }
            }
        }
#endregion

        void UpdateYetkiIzinleri()
        {
            List<string> idler = new List<string>();
            string izinIdleri = "";
            foreach (string item in ChcListBoxYetkiler.CheckedItems)
            {

                string header = item.Trim();
                if (header == "BO01 BAKIM ONARIM")
                {
                    idler.Add("1");
                }
                else if (header == "BO01 - Veri İzleme Ekranları")
                {
                    idler.Add("2");
                }
                else if (header == "Devam Eden Arıza İzleme")
                {
                    idler.Add("3");
                }
                else if (header == "Tamamlanan Arıza İzleme")
                {
                    idler.Add("4");
                }
                else if (header == "İşçilik İzleme")
                {
                    idler.Add("5");
                }
                else if (header == "Bölge Yol Durum İzleme")
                {
                    idler.Add("6");
                }
                else if (header == "Yerleşim Kayıtları İzleme")
                {
                    idler.Add("7");
                }
                else if (header == "OKF İzleme")
                {
                    idler.Add("8");
                }
                else if (header == "DTF İzleme")
                {
                    idler.Add("9");
                }
                else if (header == "Müşteri Bilgileri İzleme")
                {
                    idler.Add("10");
                }
                else if (header == "Teslimat Eksikleri İzleme")
                {
                    idler.Add("11");
                }
                else if (header == "Firma Servis Formu İzleme")
                {
                    idler.Add("12");
                }
                else if (header == "Destek İşçilik İzleme")
                {
                    idler.Add("13");
                }
                else if (header == "BO01 - Veri Giriş Ekranları")
                {
                    idler.Add("14");
                }
                else if (header == "Veri Kayıt (Arıza Açma)")
                {
                    idler.Add("15");
                }
                else if (header == "Bildirim No Tanımlama")
                {
                    idler.Add("16");
                }
                else if (header == "Veri Güncelleme")
                {
                    idler.Add("17");
                }
                else if (header == "Veri Kayıt (Arıza Kapatma)")
                {
                    idler.Add("18");
                }
                else if (header == "Müşteri Bilgileri")
                {
                    idler.Add("19");
                }
                else if (header == "Bölge Yol Durumu")
                {
                    idler.Add("20");
                }
                else if (header == "Yerleşim Kayıtları")
                {
                    idler.Add("21");
                }
                else if (header == "Bildirim Onayı")
                {
                    idler.Add("22");
                }
                else if (header == "Malzeme Temini")
                {
                    idler.Add("23");
                }
                else if (header == "Doğrudan Temin")
                {
                    idler.Add("24");
                }
                else if (header == "Servis Talepleri")
                {
                    idler.Add("25");
                }
                else if (header == "OKF Oluşturma")
                {
                    idler.Add("26");
                }
                else if (header == "Teslimat Eksikleri")
                {
                    idler.Add("27");
                }
                else if (header == "Firma Servis Formu Kayıt")
                {
                    idler.Add("28");
                }
                else if (header == "Destek İşçilik Veri Girişi")
                {
                    idler.Add("29");
                }
                else if (header == "DP01 GEÇİCİ KABUL VE AMBAR")
                {
                    idler.Add("30");
                }
                else if (header == "DP01 - Veri İzleme Ekranları")
                {
                    idler.Add("31");
                }
                else if (header == "Stok Görüntüle")
                {
                    idler.Add("32");
                }
                else if (header == "Depo Hareketleri")
                {
                    idler.Add("33");
                }
                else if (header == "Stokta Bulunmayan Malzemeler")
                {
                    idler.Add("34");
                }
                else if (header == "DP01 - Veri Giriş Ekranları")
                {
                    idler.Add("35");
                }
                else if (header == "Stok Giriş/Çıkış")
                {
                    idler.Add("36");
                }
                else if (header == "Malzeme Kayit Ambar")
                {
                    idler.Add("37");
                }
                else if (header == "Malzeme Hazırlama")
                {
                    idler.Add("38");
                }
                else if (header == "ST01 SATIN ALMA")
                {
                    idler.Add("39");
                }
                else if (header == "ST01 - Veri İzleme Ekranları")
                {
                    idler.Add("40");
                }
                else if (header == "Devam Eden SAT")
                {
                    idler.Add("41");
                }
                else if (header == "Tamamlanan SAT")
                {
                    idler.Add("42");
                }
                else if (header == "Reddedilen SAT")
                {
                    idler.Add("43");
                }
                else if (header == "Yedek Parça Kataloğu")
                {
                    idler.Add("44");
                }
                else if (header == "ST01 - Veri Giriş Ekranları")
                {
                    idler.Add("45");
                }
                else if (header == "SAT Oluştur")
                {
                    idler.Add("46");
                }
                else if (header == "SAT Ön Onay")
                {
                    idler.Add("47");
                }
                else if (header == "SAT Başlatma Onayı")
                {
                    idler.Add("48");
                }
                else if (header == "Teklif Alınacak SAT")
                {
                    idler.Add("49");
                }
                else if (header == "Teklifsiz SAT")
                {
                    idler.Add("50");
                }
                else if (header == "SAT Onay")
                {
                    idler.Add("51");
                }
                else if (header == "SAT Tamamlama")
                {
                    idler.Add("52");
                }
                else if (header == "SAT Güncelle")
                {
                    idler.Add("53");
                }
                else if (header == "Tedarikçi Firma Bilgileri")
                {
                    idler.Add("54");
                }
                else if (header == "Alt Yüklenici Firma Bilgileri")
                {
                    idler.Add("55");
                }
                else if (header == "DS01 DOKÜMAN YÖNETİM SİSTEMİ")
                {
                    idler.Add("56");
                }
                else if (header == "DS01 - Veri İzleme Ekranları")
                {
                    idler.Add("57");
                }
                else if (header == "Doküman Sorgula")
                {
                    idler.Add("58");
                }
                else if (header == "Standart Form Sorgula")
                {
                    idler.Add("59");
                }
                else if (header == "DS01 - Veri Giriş Ekranları")
                {
                    idler.Add("60");
                }
                else if (header == "Doküman Ekle")
                {
                    idler.Add("61");
                }
                else if (header == "Standart Form Ekle")
                {
                    idler.Add("62");
                }
                else if (header == "ID01 İDARİ İŞLER")
                {
                    idler.Add("63");
                }
                else if (header == "ID01 - Veri Giriş Ekranları")
                {
                    idler.Add("64");
                }
                else if (header == "Duran Varlık")
                {
                    idler.Add("65");
                }
                else if (header == "Standart Form Ekle")
                {
                    idler.Add("66");
                }
                else if (header == "Duran Varlık Kayıt")
                {
                    idler.Add("67");
                }
                else if (header == "Duran Varlık Güncelleme")
                {
                    idler.Add("68");
                }
                else if (header == "Duran Varlık Aktarım")
                {
                    idler.Add("69");
                }
                else if (header == "Duran Varlık Arıza Kayıt")
                {
                    idler.Add("70");
                }
                else if (header == "DV Kalibrasyon Kayıt")
                {
                    idler.Add("71");
                }
                else if (header == "Personel")
                {
                    idler.Add("72");
                }
                else if (header == "Personel Giriş/Çıkış")
                {
                    idler.Add("73");
                }
                else if (header == "Personel Puantaj")
                {
                    idler.Add("74");
                }
                else if (header == "İş Akışları")
                {
                    idler.Add("75");
                }
                else if (header == "Yurt İçi Görev")
                {
                    idler.Add("76");
                }
                else if (header == "Şehir İçi Görev")
                {
                    idler.Add("77");
                }
                else if (header == "İzin")
                {
                    idler.Add("78");
                }
                else if (header == "Konaklama")
                {
                    idler.Add("79");
                }
                else if (header == "Uçak ve Otobüs Bileti")
                {
                    idler.Add("80");
                }
                else if (header == "Harcama Beyannamesi")
                {
                    idler.Add("81");
                }
                else if (header == "Resmi Yazılar")
                {
                    idler.Add("82");
                }
                else if (header == "Gelen Resmi Yazılar")
                {
                    idler.Add("83");
                }
                else if (header == "Giden Resmi Yazılar")
                {
                    idler.Add("84");
                }
                else if (header == "Evrak Kayıt")
                {
                    idler.Add("85");
                }
                else if (header == "Arşiv")
                {
                    idler.Add("86");
                }
                else if (header == "Ulaştırma")
                {
                    idler.Add("87");
                }
                else if (header == "Araç Tahsis Kayıt")
                {
                    idler.Add("88");
                }
                else if (header == "Araç Yakıt Beyanı")
                {
                    idler.Add("89");
                }
                else if (header == "Araç Peryodik Bakım")
                {
                    idler.Add("90");
                }
                else if (header == "ID01 - Veri İzleme Ekranları")
                {
                    idler.Add("91");
                }
                else if (header == "Duran Varlık İzleme")
                {
                    idler.Add("92");
                }
                else if (header == "Duran Varlık Takibi")
                {
                    idler.Add("93");
                }
                else if (header == "DV Zimmet Takibi")
                {
                    idler.Add("94");
                }
                else if (header == "DV Arıza Takibi")
                {
                    idler.Add("95");
                }
                else if (header == "DV Kalibrasyon Takibi")
                {
                    idler.Add("96");
                }
                else if (header == "Personel İzleme")
                {
                    idler.Add("97");
                }
                else if (header == "Personel Listesi (Çalışan)")
                {
                    idler.Add("98");
                }
                else if (header == "Personel Listesi (İşten Ayrılan)")
                {
                    idler.Add("99");
                }
                else if (header == "Personel Puantaj")
                {
                    idler.Add("100");
                }
                else if (header == "İş Akışları İzleme")
                {
                    idler.Add("101");
                }
                else if (header == "Yurt İçi Görev")
                {
                    idler.Add("102");
                }
                else if (header == "Şehir İçi Görev")
                {
                    idler.Add("103");
                }
                else if (header == "İzin")
                {
                    idler.Add("104");
                }
                else if (header == "Konaklama")
                {
                    idler.Add("105");
                }
                else if (header == "Uçak ve Otobüs Bileti")
                {
                    idler.Add("106");
                }
                else if (header == "Harcama Beyannamesi İzleme")
                {
                    idler.Add("107");
                }
                else if (header == "Gelen Giden Resmi Yazı İzleme")
                {
                    idler.Add("108");
                }
                else if (header == "Arşiv İzleme")
                {
                    idler.Add("109");
                }
                else if (header == "Ulaştırma İzleme")
                {
                    idler.Add("110");
                }
                else if (header == "Araç Yakıt Beyan İzleme")
                {
                    idler.Add("111");
                }
                else if (header == "Standart Form Ekle")
                {
                    idler.Add("112");
                }
                else if (header == "Araç Periyodik Bakım İzleme")
                {
                    idler.Add("113");
                }
                else if (header == "Araç Bakım Onarım İzleme")
                {
                    idler.Add("114");
                }
                else if (header == "EG01 EĞİTİM")
                {
                    idler.Add("115");
                }
                else if (header == "EG01 - Veri Giriş Ekranları")
                {
                    idler.Add("116");
                }
                else if (header == "Eğitim Veri Girişi")
                {
                    idler.Add("117");
                }
                else if (header == "Eğitim Planı Oluştur")
                {
                    idler.Add("118");
                }
                else if (header == "Eğitim Planı Güncelle")
                {
                    idler.Add("119");
                }
                else if (header == "EG01 - Veri İzleme Ekranları")
                {
                    idler.Add("120");
                }
                else if (header == "Eğitim İzleme")
                {
                    idler.Add("121");
                }
                else if (header == "Eğitim Planı İzleme")
                {
                    idler.Add("122");
                }
                else if (header == "DP02 DESTEK DEPO")
                {
                    idler.Add("123");
                }
                else if (header == "DP02 - Veri İzleme Ekranları")
                {
                    idler.Add("124");
                }
                else if (header == "Stok Goruntule Depo")
                {
                    idler.Add("125");
                }
                else if (header == "Depo Hareketleri Depo")
                {
                    idler.Add("126");
                }
                else if (header == "Stokta Bulunmayan Malzemeler")
                {
                    idler.Add("127");
                }
                else if (header == "DP02 - Veri Giriş Ekranları")
                {
                    idler.Add("128");
                }
                else if (header == "Stok Giris")
                {
                    idler.Add("129");
                }
                else if (header == "Malzeme Kayıt")
                {
                    idler.Add("130");
                }
                else if (header == "Mazleme Hazırlama")
                {
                    idler.Add("131");
                }
                else if (header == "RP01 RAPORLAMALAR")
                {
                    idler.Add("132");
                }
                else if (header == "RP01 - Veri İzleme Ekranları")
                {
                    idler.Add("133");
                }
                else if (header == "RP01 - Veri Giriş Ekranları")
                {
                    idler.Add("134");
                }

            }

            izinIdleri = string.Join(";", idler);
            Yetki yetki = new Yetki(id, izinIdleri);
            yetkilerManager.Update(yetki, id);
            //MessageBox.Show(izinIdleri);
        }

    }
}
