using Business;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using DataAccess.Concreate.IdariIsler;
using Entity.IdariIsler;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.IdariIsler;
using UserInterface.STS;

namespace UserInterface.IdariIşler
{
    public partial class FrmPersonelKayit : Form
    {
        PersonelKayitManager personelKayitManager;
        PersonelKayitDal personelKayitDal;
        SicilNoManager sicilNoManager;
        IstenAyrilisManager istenAyrilisManager;
        SiparislerDal siparislerDal;
        SiparislerManager siparislerManager;
        DevamEdenIzlemeManager devamEdenIzlemeManager;
        PersonelKayitLojisikManager personelKayitLojisikManager;
        PersonelKayitBOManager personelKayitBOManager;
        PersonelKayitIdariManager personelKayitIdariManager;
        ComboManager comboManager;
        PersKaytLojistikManager persKaytLojistikManager;
        List<Siparisler> siparislers;
        List<PersonelKayit> personelKayits;
        List<PersonelKayit> dokumens;
        List<PersonelKayit> dokumensFiltered;
        SiparisPersonelManager siparisPersonelManager;
        MasrafYeriManager masrafYeriManager;

        string[] array;

        string departman, bolum1, bolum2, bolum3, BOLUM;
        int bolumid, indis, bolumidG, indisG;
        public string askerlikdurumu, askerlikdurumuG, root, subdir, siparisNo, siparisnogelen, dosyaYolu, dosyayoluG, fotoyolu, askerlikbastarihi, guncellenecekdosya, foto, yeniad, deneme, istenayrilankisi;
        string kaynakdosyaismi, alinandosya, olusandosyaadi, guncellenecekkisiadi;
        string kaynakdosyaismi1, alinandosya1, islem, islem1, islem2, islemyapan, islemyapan1, islemyapan2, islemtarihi, islemtarihi1, islemtarihi2;
        public string adsoyad, siparis, sat, butcekoud, butcekalemi, unvan, bolum;
        public string Gadsoyad, Gsiparis, Gsat, Gbutcekoud, Gbutcekalemi, Gunvan, Gbolum;
        public string SİPARİSNO, benzersizolustur, benzersizgelen,comboAd;
        int TOPLAMARAC = 0, TOPLAMPERSONEL = 0;
        int personelyonetici = 0, personel = 0, personeldepo = 0, yoneticiarac = 0, araziarac = 0, kontenjan, mevcut;
        //İŞTEN AYIRILIŞ DEĞİŞKENLERİ
        public string tc, hes, sigortasicilno, ikametgah, kan, esad, estelefon, medenidurumu, esisdurumu, cocuksayisi, dogumyeri, asdurumu, assinifi, rutbesi, gorevi, gorevyeri, tecilsebebi, muafnedeni, okul, okulbolum, dipnotu;

        public DateTime dogumtarihi;string askerlikbas, askerlikbit, tecilbit;
        bool control = false;
        public int id=0, ids=0;
        bool start = true, personelKadroKontrol = false;
        PersonelKayit personelKayit;
        IstenAyrilis istenAyrilis;
        Siparisler siparisler;

        int index, index1, index2, index3;

        public object[] infos;
        string KontenjanControlGuncelle()
        {
            if (CmbAdSoyad.Text == "")
            {
                return "Lütfen Personelin İsmini Seçiniz!";
            }
            kontenjan = siparislerManager.KontejanKontrol(CmbSiparisG.Text);
            mevcut = siparislerManager.KontejanKontrolMevcut(CmbSiparisG.Text);
            if (kontenjan == -1)
            {
                return "";
            }
            if (kontenjan <= mevcut)
            {
                CmbSiparis.SelectedValue = "";
                return "Seçmiş Olduğunuz Personel Sipariş Numarasının Kontenjanı Doludur.Lütfen Farklı Bir Sipariş Numarası Seçiniz Veya Yöneticinizle Görüşünüz.";
                /*MessageBox.Show("Seçmiş Olduğunuz Personel Sipariş Numarasının Kontenjanı Doludur.Lütfen Farklı Bir Sipariş Numarası Seçiniz Veya Yöneticinizle Görüşünüz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            }
            return "OK";
        }
        private void CmbSiparisG_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (control == false)
            {
                return;
            }
            kontenjan = siparislerManager.KontejanKontrol(CmbSiparisG.Text);
            mevcut = siparislerManager.KontejanKontrolMevcut(CmbSiparisG.Text);
            if (kontenjan == -1)
            {
                return;
            }
            if (kontenjan <= mevcut)
            {
                MessageBox.Show("Seçmiş Olduğunuz Personel Sipariş Numarasının Kontenjanı Doludur.Lütfen Farklı Bir Sipariş Numarası Seçiniz Veya Yöneticinizle Görüşünüz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbSiparisG.SelectedValue = "";
            }
            personelKadroKontrol = true;*/
        }

        private void CmbSiparis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (control == false)
            {
                return;
            }
            kontenjan = siparislerManager.KontejanKontrol(CmbSiparis.Text);
            mevcut = siparislerManager.KontejanKontrolMevcut(CmbSiparis.Text);
            if (kontenjan == -1)
            {
                return;
            }
            if (kontenjan <= mevcut)
            {
                MessageBox.Show("Seçmiş Olduğunuz Personel Sipariş Numarasının Kontenjanı Doludur.Lütfen Farklı Bir Sipariş Numarası Seçiniz Veya Yöneticinizle Görüşünüz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbSiparis.SelectedValue = "";
            }
            personelKadroKontrol = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PagePersonelKayit"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void CmbBolum3G_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Bolum3();
        }
        void Bolum3()
        {
            CmbBolum3G.DataSource = personelKayitIdariManager.Bolum3Gun();
            CmbBolum3G.ValueMember = "Id";
            CmbBolum3G.DisplayMember = "Bolum3";
            CmbBolum3G.SelectedValue = 0;
        }
        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnDosyaEkle.Enabled = false;
            BtnFotoEkle.Enabled = false;
            BtnKaydet.Enabled = false;
            siparisNo = Guid.NewGuid().ToString();
            personelKayits = personelKayitManager.GetList();
            //AdSoyadDoldur();
            //AsoyadDoldurA();
            MevcutKadro();
            //SiparisDoldur();
            //SiparisDoludurG();
            Temizle();
            TemizleIstenAyrilis();
            TemizlePersonelKayit();
            GuncelleTemizle();
            //TOPP.Text = siparislerManager.ToplamPers().ToString();
            Toplamlar2();
            TOPA.Text = siparislerManager.ToplamArac().ToString();
            start = false;
            KadroControl();

            if (infos[1].ToString() == "RESUL GÜNEŞ")
            {
                return;
            }
            if (infos[1].ToString() == "MÜCAHİT AYDEMİR")
            {
                return;
            }
            tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage4"]);

        }

        public FrmPersonelKayit()
        {
            InitializeComponent();
            personelKayitManager = PersonelKayitManager.GetInstance();
            personelKayitDal = PersonelKayitDal.GetInstance();
            sicilNoManager = SicilNoManager.GetInstance();
            devamEdenIzlemeManager = DevamEdenIzlemeManager.GetInstance();
            istenAyrilisManager = IstenAyrilisManager.GetInstance();
            siparislerManager = SiparislerManager.GetInstance();
            siparislerDal = SiparislerDal.GetInstance();
            personelKayitLojisikManager = PersonelKayitLojisikManager.GetInstance();
            personelKayitBOManager = PersonelKayitBOManager.GetInstance();
            personelKayitIdariManager = PersonelKayitIdariManager.GetInstance();
            persKaytLojistikManager = PersKaytLojistikManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            masrafYeriManager = MasrafYeriManager.GetInstance();
        }
        private void TxtPersonelDepo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtPersonel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtPersonelYonetici_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtAraziArac_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtYoneticiArac_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtPersonelSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void CmbBolum_SelectedIndexChanged(object sender, EventArgs e) // 1
        {
            bolumid = CmbBolum.SelectedIndex;
            Bolum2Degistir();
            gecKayit = true;
        }

        private void BtnSatEkle_Click(object sender, EventArgs e)
        {
            comboAd = "SİPARİŞLER SAT";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }
        private void BtnSatKatEkle_Click(object sender, EventArgs e)
        {
            comboAd = "SİPARİŞLER SAT KATEGORİ";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnProjeEkle_Click(object sender, EventArgs e)
        {
            comboAd = "SİPARİŞLER PROJE";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void CmbBolumG_SelectedIndexChanged(object sender, EventArgs e)
        {
            bolumidG = CmbBolumG.SelectedIndex;
            Bolum2GDegistir();
            gec = true;
        }
        void Bolum2Doldur()
        {
            CmbBolum2.ValueMember = "Id";
            CmbBolum2.DisplayMember = "Bolum2";
            CmbBolum2.SelectedValue = 0;
        }
        void Bolum2GDoldur()
        {
            CmbBolum2G.ValueMember = "Id";
            CmbBolum2G.DisplayMember = "Bolum2";
            CmbBolum2G.SelectedValue = 0;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            MevcutKadro();
        }

        void Bolum3Doldur()
        {
            CmbBolum3.ValueMember = "Id";
            CmbBolum3.DisplayMember = "Bolum3";
            CmbBolum3.SelectedValue = 0;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void Bolum3GDoldur()
        {
            CmbBolum3G.ValueMember = "Id";
            CmbBolum3G.DisplayMember = "Bolum3";
            CmbBolum3G.SelectedValue = 0;
        }
        int yetkiliId;
        private void CmbMasrafYeriSorumlusuGun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==true)
            {
                return;
            }

            yetkiliId = CmbMasrafYeriSorumlusuGun.SelectedValue.ConInt();
        }

        void Bolum2GDegistir()
        {
            if (bolumidG == 0)
            {
                CmbBolum2G.DataSource = personelKayitLojisikManager.GetList();
                Bolum2GDoldur();
            }
            if (bolumidG == 1)
            {
                CmbBolum2G.DataSource = personelKayitBOManager.GetList();
                Bolum2GDoldur();
            }
            if (bolumidG == 2)
            {
                CmbBolum2G.DataSource = null;
            }
            if (bolumidG == 4)
            {
                CmbBolum2G.DataSource = personelKayitIdariManager.GetList();
                Bolum2GDoldur();
            }
        }

        private void CmbMasrafYeriSorumlusu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }

            yetkiliId = CmbMasrafYeriSorumlusu.SelectedValue.ConInt();
        }

        private void BtnMasrafYeriDuzelt_Click(object sender, EventArgs e)
        {
            FrmMasrafYeri frmMasrafYeri = new FrmMasrafYeri();
            frmMasrafYeri.ShowDialog();
        }

        void Bolum2Degistir()
        {
            if (bolumid == 0)
            {
                CmbBolum2.DataSource = personelKayitLojisikManager.GetList();
                Bolum2Doldur();
            }
            if (bolumid == 1)
            {
                CmbBolum2.DataSource = personelKayitBOManager.GetList();
                Bolum2Doldur();
            }
            if (bolumid == 2)
            {
                CmbBolum2.DataSource = null;
            }
            if (bolumid == 4)
            {
                CmbBolum2.DataSource = personelKayitIdariManager.GetList();
                Bolum2Doldur();
            }
        }
        private void CmbBolum2_SelectedIndexChanged(object sender, EventArgs e) // 2
        {
            if (gecKayit == true)
            {
                indis = CmbBolum2.SelectedIndex;
                Bolum3Degistir();
            }
            return;
        }
        private void CmbBolum2G_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gec == true)
            {
                indisG = CmbBolum2G.SelectedIndex;
                Bolum3GDegistir();
            }
            return;
        }

        void BolumOlustur()
        {
            if (CmbDepartman.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle DEPARTMAN Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbDepartman.Text == "MÜB PROJE DİREKTÖRLÜĞÜ")
            {
                departman = "MUB Prj.Dir.";
            }
            if (CmbBolum.Text == "SİSTEM TESİS BAKIM ONARIM MÜDÜRLÜĞÜ")
            {
                bolum1 = "Sist.Tes.BO.Mdl.";
            }
            if (CmbBolum.Text == "LOJİSTİK DESTEK VE PLANLAMA MÜDÜRLÜĞÜ")
            {
                bolum1 = "Loj.Des.Ve Pln.Mdl.";
            }
            if (CmbBolum.Text == "KALİTE MÜHENDİSLİĞİ")
            {
                bolum1 = "Kal.Müh.";
            }
            if (CmbBolum.Text == "YAZILIM MÜHENDİSLİĞİ")
            {
                bolum1 = "Yaz.Müh.";
            }
            if (CmbBolum.Text == "İDARİ İŞLER ŞEFLİĞİ")
            {
                bolum1 = "İd.İşl.Şefliği";
            }
            if (CmbBolum.Text == "")
            {
                BOLUM = departman;
                return;
            }
            if (CmbBolum2.Text == "")
            {
                BOLUM = departman + "/" + bolum1;
                return;
            }
            if (CmbBolum3.Text == "")
            {
                BOLUM = departman + "/" + bolum1 + "/" + CmbBolum2.Text;
                return;
            }
            BOLUM = departman + "/" + bolum1 + "/" + CmbBolum2.Text + "/" + CmbBolum3G.Text;

        }

        private void BtnMasrafYeriDuzelt_Click_1(object sender, EventArgs e)
        {
            FrmMasrafYeri frmMasrafYeri = new FrmMasrafYeri();
            frmMasrafYeri.ShowDialog();
        }

        private void BtnBolumDuzeltGuncelle_Click(object sender, EventArgs e)
        {

        }

        void BolumOlusturG()
        {
            if (CmbDepartmanG.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle DEPARTMAN Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbDepartmanG.Text == "MÜB PROJE DİREKTÖRLÜĞÜ")
            {
                departman = "MUB Prj.Dir.";
            }
            if (CmbBolumG.Text == "SİSTEM TESİS BAKIM ONARIM MÜDÜRLÜĞÜ")
            {
                bolum1 = "Sist.Tes.BO.Mdl.";
            }
            if (CmbBolumG.Text == "LOJİSTİK DESTEK VE PLANLAMA MÜDÜRLÜĞÜ")
            {
                bolum1 = "Loj.Des.Ve Pln.Mdl.";
            }
            if (CmbBolumG.Text == "KALİTE MÜHENDİSLİĞİ")
            {
                bolum1 = "Kal.Müh.";
            }
            if (CmbBolumG.Text == "YAZILIM MÜHENDİSLİĞİ")
            {
                bolum1 = "Yaz.Müh.";
            }
            if (CmbBolumG.Text == "İDARİ İŞLER ŞEFLİĞİ")
            {
                bolum1 = "İd.İşl.Şefliği";
            }
            if (CmbBolumG.Text == "")
            {
                BOLUM = departman;
                return;
            }
            if (CmbBolum2G.Text == "")
            {
                BOLUM = departman + "/" + bolum1;
                return;
            }
            if (CmbBolum3G.Text == "")
            {
                BOLUM = departman + "/" + bolum1 + "/" + CmbBolum2G.Text;
                return;
            }
            BOLUM = departman + "/" + bolum1 + "/" + CmbBolum2G.Text + "/" + CmbBolum3G.Text;

        }
        bool gec, gecKayit = false;
        void Bolum3GDegistir()
        {
            if (CmbBolum2G.Text == "Dest.Hiz.")
            {
                CmbBolum3G.DataSource = personelKayitIdariManager.Bolum3();
                CmbBolum3G.ValueMember = "Id";
                CmbBolum3G.DisplayMember = "bolum2";
                CmbBolum3G.SelectedValue = 0;
                return;
            }
            if (CmbBolum2G.Text == "Sh.Dest.Müh")
            {
                CmbBolum3G.DataSource = personelKayitIdariManager.Bolum3SahaDestek();
                CmbBolum3G.ValueMember = "Id";
                CmbBolum3G.DisplayMember = "bolum2";
                CmbBolum3G.SelectedValue = 0;
                return;
            }
            if (CmbBolum2G.Text== "Pln.Anlz.Müh")
            {
                CmbBolum3G.DataSource = personelKayitIdariManager.Bolum3Gun();
                CmbBolum3G.ValueMember = "Id";
                CmbBolum3G.DisplayMember = "bolum2";
                CmbBolum3G.SelectedValue = 0;
                return;
            }
            CmbBolum3G.DataSource = null;



            /*if (indis == 1)
            {
                CmbBolum3G.DataSource = persKaytLojistikManager.GetList(indisG);
                Bolum3GDoldur();
            }
            if (indis == 2)
            {
                CmbBolum3G.DataSource = persKaytLojistikManager.GetList(indisG);
                Bolum3GDoldur();
            }*/
        }
        void Bolum3Degistir() // 3
        {
            if (CmbBolum2.Text == "Dest.Hiz.")
            {
                CmbBolum3.DataSource = personelKayitIdariManager.Bolum3();
                CmbBolum3.ValueMember = "Id";
                CmbBolum3.DisplayMember = "bolum2";
                CmbBolum3.SelectedValue = 0;
                return;
            }
            if (CmbBolum2.Text == "Sh.Dest.Müh")
            {
                CmbBolum3.DataSource = personelKayitIdariManager.Bolum3SahaDestek();
                CmbBolum3.ValueMember = "Id";
                CmbBolum3.DisplayMember = "bolum2";
                CmbBolum3.SelectedValue = 0;
                return;
            }
            if (CmbBolum2.Text == "Pln.Anlz.Müh")
            {
                CmbBolum3.DataSource = personelKayitIdariManager.Bolum3Gun();
                CmbBolum3.ValueMember = "Id";
                CmbBolum3.DisplayMember = "bolum2";
                CmbBolum3.SelectedValue = 0;
                return;
            }
            CmbBolum3.DataSource = null;
        }
        private void BtnDosyaEkleG_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\PERSONELLER\";
            //root = @"C:\STS";
            //subdir = @"C:\STS\Personel Dosyaları\";
            olusandosyaadi = CmbAdSoyad.Text;

            if (!Directory.Exists(root))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(subdir))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi = openFileDialog1.SafeFileName.ToString();
                alinandosya = openFileDialog1.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dosyaYolu = subdir + olusandosyaadi;
            File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
            WebBrowser2();
        }
        private void BtnDosyaEkleA_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\İDARİ İŞLER\PERSONELLER\";
            //root = @"C:\STS";
            //subdir = @"C:\STS\Personel Dosyaları\";
            olusandosyaadi = CmbAdsoyadA.Text;
            if (!Directory.Exists(root))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(subdir))
            {
                MessageBox.Show("Dosya Yolu Bulunamadı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi = openFileDialog1.SafeFileName.ToString();
                alinandosya = openFileDialog1.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dosyaYolu = subdir + olusandosyaadi;
            File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
            WebBrowser3();
        }

        private void CmbMasrafYeriNoG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start==true)
            {
                return;
            }
            index3 = CmbMasrafYeriNoG.SelectedIndex;
            CmbMastafYeriG.SelectedIndex = index3;
        }

        private void RdbYaptiG_CheckedChanged(object sender, EventArgs e)
        {
            RadyobutonG();
        }

        private void RdbMuafG_CheckedChanged(object sender, EventArgs e)
        {
            RadyobutonG();
        }

        private void RdbTecilliG_CheckedChanged(object sender, EventArgs e)
        {
            RadyobutonG();
        }

        private void BtnFotoGuncelle_Click(object sender, EventArgs e)
        {
            subdir = @"Z:\DTS\İDARİ İŞLER\PERSONELLER" + "\\" + CmbAdSoyad.Text;
            //subdir = @"C:\STS\Personel Dosyaları" + "\\" + CmbAdSoyad.Text;

            olusandosyaadi = "\\" + CmbAdSoyad.Text + ".jpg";
            dosyaYolu = subdir + olusandosyaadi;

            if (!Directory.Exists(subdir))
            {
                MessageBox.Show("Personelin Dosyası Bulunamadı", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = openFileDialog2.ShowDialog();
            if (dr == DialogResult.OK)
            {
                fotoyolu = openFileDialog2.FileName;
                kaynakdosyaismi1 = openFileDialog2.SafeFileName.ToString();

                if (Path.GetExtension(fotoyolu) == ".jpg" || Path.GetExtension(fotoyolu) == ".png")
                {
                    PcFoto.ImageLocation = fotoyolu;
                    Properties.Settings.Default.FotoYolu = fotoyolu;
                    Properties.Settings.Default.Save();
                    yeniad = CmbAdSoyad.Text + ".jpg";
                    File.Delete(dosyaYolu);
                    dosyaYolu = subdir;
                    File.Copy(fotoyolu, dosyaYolu + "\\" + yeniad);
                }
                else
                {
                    MessageBox.Show("Lütfen JPEG veya PNG formatında olan bir dosyayı seçiniz.");
                }
            }
        }

        private void CmbMedeniG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbMedeniG.SelectedIndex == 0)
            {
                TxtEsAdG.Enabled = true;
                TxtEsTelefonG.Enabled = true;
                CmbEsIsDurumuG.Enabled = true;
                CmbCocukSayisiG.Enabled = true;
            }
            if (CmbMedeniG.SelectedIndex == 1)
            {
                TxtEsAdG.Clear();
                TxtEsTelefonG.Clear();
                CmbEsIsDurumuG.Text = "";
                CmbCocukSayisiG.Text = "";
                TxtEsAdG.Enabled = false;
                TxtEsTelefonG.Enabled = false;
                CmbEsIsDurumuG.Enabled = false;
            }
        }

        private void CmbButcekoduG_SelectedIndexChanged(object sender, EventArgs e)
        {
            index2 = CmbButcekoduG.SelectedIndex;
            CmbButceKalemiG.SelectedIndex = index2;
        }

        private void CmbButceKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbButceKodu.SelectedIndex;
            CmbButceKalemi.SelectedIndex = index;
        }

        private void CmbMasYeriNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            index1 = CmbMasYeriNo.SelectedIndex;
            TxtMasrafYeri.SelectedIndex = index1;
        }


        public void AdSoyadDoldur()
        {
            CmbAdSoyad.DataSource = personelKayits;
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Adsoyad";
            CmbAdSoyad.SelectedValue = 0;
        }
        public void AsoyadDoldurA()
        {
            CmbAdsoyadA.DataSource = personelKayitManager.GetList();
            CmbAdsoyadA.ValueMember = "Id";
            CmbAdsoyadA.DisplayMember = "Adsoyad";
            CmbAdsoyadA.SelectedValue = 0;
        }
        public void SiparisDoldur()
        {
            CmbSiparis.DataSource = siparislerManager.GetList();
            CmbSiparis.ValueMember = "Id";
            CmbSiparis.DisplayMember = "Siparisno";
            CmbSiparis.SelectedValue = 0;
        }
        public void SiparisDoludurG()
        {
            CmbSiparisG.DataSource = siparislerManager.GetList();
            CmbSiparisG.ValueMember = "Id";
            CmbSiparisG.DisplayMember = "Siparisno";
            CmbSiparisG.SelectedValue = 0;
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Güncellemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                BolumOlusturG();
                if (CmbSiparisG.Text!= testEdilecekSiparis)
                {
                    string mesaj2 = KontenjanControlGuncelle();
                    if (mesaj2 != "OK")
                    {
                        MessageBox.Show(mesaj2, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                personelKayit = null;

                int id = CmbAdSoyad.SelectedValue.ConInt();
                personelKayit = new PersonelKayit(id, CmbAdSoyad.Text, TxtTcG.Text, TxtHesG.Text, TxtSigortaSicil.Text, TxtIkametgahG.Text, CmbKanG.Text,
                    TxtEsAdG.Text, TxtEsTelefonG.Text, DtDogumTarihiG.Value, CmbMedeniG.Text, CmbEsIsDurumuG.Text, CmbCocukSayisiG.Text, TxtDogumYeriG.Text, TxtOkulG.Text, TxtBolumG.Text, TxtDipG.Text,
                    CmbSiparisG.Text, CmbSatG.Text, CmbButcekoduG.Text, CmbButceKalemiG.Text, TxtSicilG.Text, CmbMasrafYeriNoG.Text, CmbMastafYeriG.Text, CmbMasrafYeriSorumlusuGun.Text, BOLUM, TxtSirketMailG.Text,
                    TxtOficeMailG.Text, TxtSirketCepG.Text, TxtSirketKısaKodG.Text, TxtOficeDahiliNoG.Text, CmbIsUnvaniG.Text, DtIseGirisG.Value, askerlikdurumuG, TxtSinifG.Text, TxtRubesiG.Text,
                    TxtGoreviG.Text, DtBasTarihiG.Text.ToString(), DtBitTarihiG.Text.ToString(), TxtGorevYeriG.Text, DtTecilBitTarihiG.Text.ToString(), TxtTecilSebebiG.Text, TxtMuafNedeniG.Text,CmbProjeKoduGun.Text, TxtKgbNoGun.Text, DtKgbGuncelle.Value);
                CmbMastafYeriG.Text = ""; CmbBolumG.Text = "";

                //personelKayitManager.Update(personelKayit);
                bool gec = false;
                string mesaj = personelKayitManager.Update(personelKayit);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                
                if (eksilecekSiparis != CmbSiparisG.Text)
                {
                    personelKayitManager.MevcutKadroEksilt(eksilecekSiparis);
                    gec = true;
                }

                if (gec == true)
                {
                    personelKayitManager.MevcutKadroArttir(CmbSiparisG.Text);
                }

                string control = personelKayitManager.PersonelSorumluDegistir(personelId, yetkiliId);
                if (control != "OK")
                {
                    MessageBox.Show(control,"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                islem1 = CmbAdSoyad.Text + " Personel Güncellendi";
                islemyapan1 = infos[1].ToString();
                islemtarihi1 = DateTime.Now.ToString();
                DevamEdenIzleme devamEdenIzleme = new DevamEdenIzleme(siparisnogelen, islem1, islemyapan1, islemtarihi1.ConDate());
                devamEdenIzlemeManager.Add(devamEdenIzleme);
                Gadsoyad = CmbAdSoyad.Text;
                Gsiparis = CmbSiparisG.Text;
                Gsat = CmbSatG.Text;
                Gbutcekoud = CmbButcekoduG.Text;
                Gbutcekalemi = CmbButceKalemiG.Text;
                Gunvan = CmbIsUnvaniG.Text;
                Gbolum = BOLUM;
                Task.Factory.StartNew(() => MailSendMetotG());
                MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                GuncelleTemizle();
                MevcutKadro();
            }
        }
        private void GuncellenecekWebBrowser()
        {
            root = @"Z:\DTS";
            subdir = @"Z:\DTS\İDARİ İŞLER\PERSONELLER\";
            //root = @"C:\STS";
            //subdir = @"C:\STS\Personel Dosyaları\";
            if (!Directory.Exists(root))
            {
                MessageBox.Show("Dosya yolu bulunamadı!");
                return;
            }
            if (!Directory.Exists(subdir))
            {
                MessageBox.Show("Dosya yolu bulunamadı!");
                return;
            }
            guncellenecekdosya = subdir + guncellenecekkisiadi;
            if (!Directory.Exists(guncellenecekdosya))
            {
                MessageBox.Show(guncellenecekkisiadi + " Kişisinin Dosyası Bulunamadı.");
                return;
            }
            WebBrowser2();
        }
        private void IstenAyrilanWebBrowser()
        {
            root = @"Z:\DTS";
            subdir = @"Z:\DTS\İDARİ İŞLER\PERSONELLER\";
            //root = @"C:\STS";
            //subdir = @"C:\STS\Personel Dosyaları\";
            if (!Directory.Exists(root))
            {
                MessageBox.Show("Dosya yolu bulunamadı!");
                return;
            }
            if (!Directory.Exists(subdir))
            {
                MessageBox.Show("Dosya yolu bulunamadı!");
                return;
            }
            istenayrilankisi = subdir + istenayrilankisi;
            if (!Directory.Exists(istenayrilankisi))
            {
                MessageBox.Show(istenayrilankisi + " Kişisinin Dosyası Bulunamadı.");
                return;
            }
            WebBrowser3();
        }
        string askerlikdurum,eksilecekSiparis,testEdilecekSiparis;
        private void CmbAdSoyad_SelectedValueChanged(object sender, EventArgs e)
        {
            if (start)
            {
                return;
            }
            if (CmbAdSoyad.Text == "")
            {
                return;
            }
            int personId = CmbAdSoyad.SelectedValue.ConInt();
            PersonelKayit personelKayit = personelKayitManager.Get(personId);

            guncellenecekkisiadi = CmbAdSoyad.Text;
            TxtTcG.Text = personelKayit.Tc;
            TxtHesG.Text = personelKayit.Heskodu;
            TxtSigortaSicil.Text = personelKayit.Sigortasicilno;
            TxtIkametgahG.Text = personelKayit.Ikametgah;
            CmbKanG.Text = personelKayit.Kangrubu;
            CmbEsIsDurumuG.Text = personelKayit.Esisdurumu;
            TxtEsAdG.Text = personelKayit.Esad;
            TxtEsTelefonG.Text = personelKayit.Estelefon;
            DtDogumTarihiG.Value = personelKayit.Dogumtarihi;
            CmbMedeniG.Text = personelKayit.Medenidurumu;
            CmbCocukSayisiG.Text = personelKayit.Cocuksayisi;
            TxtDogumYeriG.Text = personelKayit.Dogumyeri;
            TxtOkulG.Text = personelKayit.Okul;
            TxtBolumG.Text = personelKayit.Bolum;
            TxtDipG.Text = personelKayit.Diplomanotu;
            CmbSiparisG.Text = personelKayit.Siparis;
            CmbSatG.Text = personelKayit.Sat;
            CmbButcekoduG.Text = personelKayit.Butcekodu;
            CmbButceKalemiG.Text = personelKayit.Butcekalemi;
            TxtSicilG.Text = personelKayit.Sicil;
            CmbMasrafYeriNoG.Text = personelKayit.Masyerino;
            CmbMastafYeriG.Text = personelKayit.Masrafyeri;
            TxtSirketMailG.Text = personelKayit.Sirketmail;
            TxtOficeMailG.Text = personelKayit.Oficemail;
            TxtSirketCepG.Text = personelKayit.Sirketcep;
            TxtSirketKısaKodG.Text = personelKayit.Sirketkisakod;
            TxtOficeDahiliNoG.Text = personelKayit.Dahilino;
            CmbIsUnvaniG.Text = personelKayit.Isunvani;
            DtIseGirisG.Value = personelKayit.Isegiristarihi;
            TxtSinifG.Text = personelKayit.Askerliksinifi;
            TxtRubesiG.Text = personelKayit.Rubesi;
            TxtGoreviG.Text = personelKayit.Gorevi;
            DtBasTarihiG.Text = personelKayit.Askerlikbastarihi.ToString();
            DtBitTarihiG.Text = personelKayit.Askerlikbittarihi.ToString();
            TxtGorevYeriG.Text = personelKayit.Gorevyeri;
            DtTecilBitTarihiG.Text = personelKayit.Tecilbittarihi.ToString();
            TxtTecilSebebiG.Text = personelKayit.Tecilsebebi;
            TxtMuafNedeniG.Text = personelKayit.Muafnedeni;
            TxtBulunduguBolum.Text = personelKayit.Sirketbolum;
            askerlikdurum = personelKayit.Askerlikdurumu;
            eksilecekSiparis = personelKayit.Siparis;
            testEdilecekSiparis = personelKayit.Siparis;
            CmbMasrafYeriSorumlusuGun.Text = personelKayit.MasrafYeriSorumlusu;
            CmbProjeKoduGun.Text = personelKayit.ProjeKodu;
            if (askerlikdurum == "YAPTI")
            {
                RdbYaptiG.Checked = true;
            }
            if (askerlikdurum == "MUAF")
            {
                RdbMuafG.Checked = true;
            }
            if (askerlikdurum == "TECİLLİ")
            {
                RdbTecilliG.Checked = true;
            }
            //CmbSirketBolumG.Text = personelKayit.Sirketbolum;
            siparisnogelen = personelKayit.SiparisNo;

            deneme = "\\" + CmbAdSoyad.Text + ".jpg";
            foto = personelKayit.Fotoyolu;
            PcFoto.ImageLocation = foto + deneme;
            SirketBolum();
            GuncellenecekWebBrowser();
        }
        List<string> list = new List<string>();
        void SirketBolum()
        {
            list = new List<string>();
            string s = TxtBulunduguBolum.Text;
            string[] subs = s.Split('/');
            foreach (var sub in subs)
            {
                list.Add(sub);
            }
            int count = list.Count;
            if (count == 0)
            {
                return;
            }
            if (count > 0)
            {
                if (list[0].ToString() == "MUB Prj.Dir.")
                {
                    CmbDepartmanG.Text = "MÜB PROJE DİREKTÖRLÜĞÜ";
                }
            }
            if (count > 1)
            {
                if (list[1].ToString() == "Sist.Tes.BO.Mdl.")
                {
                    CmbBolumG.Text = "SİSTEM TESİS BAKIM ONARIM MÜDÜRLÜĞÜ";
                }
                if (list[1].ToString() == "Loj.Des.Ve Pln.Mdl.")
                {
                    CmbBolumG.Text = "LOJİSTİK DESTEK VE PLANLAMA MÜDÜRLÜĞÜ";
                }
                if (list[1].ToString() == "Kal.Müh.")
                {
                    CmbBolumG.Text = "KALİTE MÜHENDİSLİĞİ";
                }
                if (list[1].ToString() == "Yaz.Müh.")
                {
                    CmbBolumG.Text = "YAZILIM MÜHENDİSLİĞİ";
                }
                if (list[1].ToString() == "İd.İşl.Şefliği")
                {
                    CmbBolumG.Text = "İDARİ İŞLER ŞEFLİĞİ";
                }
            }
            if (count > 2)
            {
                CmbBolum2G.Text = list[2].ToString();
            }
            if (count > 3)
            {
                CmbBolum3G.Text = list[3].ToString();
            }
        }
        //bool keepTextChanged = false;
        int personelId;
        private void CmbAdSoyad_TextChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                personelId = CmbAdSoyad.SelectedValue.ConInt();
            }
            if (control == false)
            {
                return;
            }
            control = true;
            
            /*string documentNo = CmbAdSoyad.Text;

            if (string.IsNullOrEmpty(documentNo))
            {
                dokumensFiltered = dokumens;
                dataBinder.DataSource = dokumens.ToDataTable();
                DtgDokumanListesi.DataSource = dataBinder;
                return;
            }

            dataBinder.DataSource = dokumensFiltered.Where(x => x.Numarasi.ToLower().Contains(documentNo.ToLower())).ToList().ToDataTable();
            DtgDokumanListesi.DataSource = dataBinder;
            dokumensFiltered = dokumens;*/
        }
        void GuncellemeControl()
        {
            int personId = CmbAdSoyad.SelectedValue.ConInt();
            PersonelKayit personelKayit = personelKayitManager.Get(personId);
            if (TxtTcG.Text != personelKayit.Tc)
            {
                string eski = personelKayit.Tc;
                string yeni = TxtTcG.Text;
                string ileti = "PERSONEL TC BİLGİSİ DEĞİŞTİRİLMİŞTİR.\nESKİ TC: " + eski + "\nYENİ TC: " + yeni;
            }
        }
        private void CmbAdsoyadA_SelectedValueChanged(object sender, EventArgs e)
        {
            if (start)
            {
                return;
            }
            if (CmbAdsoyadA.Text == "")
            {
                return;
            }
            int personId = CmbAdsoyadA.SelectedValue.ConInt();
            PersonelKayit personelKayit = personelKayitManager.Get(personId);
            istenayrilankisi = CmbAdsoyadA.Text;
            TxtSiparisA.Text = personelKayit.Siparis;
            TxtSatA.Text = personelKayit.Sat;
            TxtButceKoduA.Text = personelKayit.Butcekodu;
            TxtButceKalemiA.Text = personelKayit.Butcekalemi;
            TxtSiclA.Text = personelKayit.Sicil;
            TxtMasrafYeriNoA.Text = personelKayit.Masyerino;
            TxtMasrafYeriA.Text = personelKayit.Masrafyeri;
            TxtIsBolumA.Text = personelKayit.Sirketbolum;
            TxtSırketMailA.Text = personelKayit.Sirketmail;
            TxtOficeMailA.Text = personelKayit.Oficemail;
            TxtSirketCepA.Text = personelKayit.Sirketcep;
            TxtKisaKodA.Text = personelKayit.Sirketkisakod;
            TxtDahiliNoA.Text = personelKayit.Dahilino;
            TxtIsUnvaniA.Text = personelKayit.Isunvani;
            MsdIseGirisTarihi.Value = personelKayit.Isegiristarihi;
            tc = personelKayit.Tc;
            hes = personelKayit.Heskodu;
            sigortasicilno = personelKayit.Sigortasicilno;
            ikametgah = personelKayit.Ikametgah;
            kan = personelKayit.Kangrubu;
            esad = personelKayit.Esad;
            estelefon = personelKayit.Estelefon;
            dogumtarihi = personelKayit.Dogumtarihi;
            medenidurumu = personelKayit.Medenidurumu;
            esisdurumu = personelKayit.Esisdurumu;
            cocuksayisi = personelKayit.Cocuksayisi;
            dogumyeri = personelKayit.Dogumyeri;
            askerlikdurumu = personelKayit.Askerlikdurumu;
            assinifi = personelKayit.Askerliksinifi;
            rutbesi = personelKayit.Rubesi;
            gorevi = personelKayit.Gorevi;
            gorevyeri = personelKayit.Gorevyeri;
            askerlikbas = personelKayit.Askerlikbastarihi;
            askerlikbit = personelKayit.Askerlikbittarihi;
            tecilbit = personelKayit.Tecilbittarihi;
            tecilsebebi = personelKayit.Tecilsebebi;
            muafnedeni = personelKayit.Muafnedeni;
            okul = personelKayit.Okul;
            okulbolum = personelKayit.Bolum;
            dipnotu = personelKayit.Diplomanotu;
            id = personelKayit.Id;

            IstenAyrilanWebBrowser();

            mevcut = siparislerManager.KontejanKontrolMevcut(TxtSiparisA.Text);
            kontenjan = siparislerManager.KontejanKontrol(TxtSiparisA.Text);
        }
        private void FillTols()
        {
            Temizle();
            GuncelleTemizle();

            if (siparislers == null)
            {
                return;
            }
            if (siparislers.Count == 0)
            {
                return;
            }
            if (siparislers.Count > 0)
            {
                Siparisler item = siparislers[0];
                ids = item.Id;
                string proje = "";
                proje = item.Proje;
                CmbProje.Text = proje;
                TxtSatt.Text = item.Sat;
                TxtDonemYil.Text = item.Donemyil;
                CmbSatKategori.Text = item.Satkategori;
                D.Text = item.Toplamarac.ToString();
                TxtPersonelSayisi.Text = item.Personeltoplam.ToString();
                TxtYoneticiArac.Text = item.Yoneticiarac.ToString();
                TxtAraziArac.Text = item.Araziarac.ToString();
                TxtPersonelYonetici.Text = item.Personelyonetici.ToString();
                TxtPersonel.Text = item.Personel.ToString();
                TxtPersonelDepo.Text = item.Personeldepo.ToString();
                benzersizgelen = item.Benzersiz;
            }
        }
        private void DtgMevcutKadro_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            string benzersizlistele = DtgMevcutKadro.CurrentRow.Cells["Benzersiz"].Value.ToString();
            siparislers = siparislerManager.GetList(benzersizlistele);
            KadroControl();
            FillTols();

        }
        private void Txtadsoyad_TextChanged(object sender, EventArgs e)
        {
            olusandosyaadi = Txtadsoyad.Text;
            BtnDosyaEkle.Enabled = true;
            control = true;
        }
        public string sayfa = "";
        private void FrmPersonelKayit_Load(object sender, EventArgs e)
        {
            //dokumens = personelKayits.GetList();

            BtnDosyaEkle.Enabled = false;
            BtnFotoEkle.Enabled = false;
            BtnKaydet.Enabled = false;
            siparisNo = Guid.NewGuid().ToString();
            personelKayits = personelKayitManager.GetList();
            AdSoyadDoldur();
            AsoyadDoldurA();
            MevcutKadro();
            SiparisDoldur();
            SiparisDoludurG();
            MasrafYeriSorumlusu();
            MasrafYeriSorumlusuGun();
            ComboProje();
            ComboSat();
            ComboSatKategori();
            ProjeKodu();
            ProjeKoduGun();
            MasrafYeriGuncel();
            MasrafYeri();
            MasrafYeriBilgiGuncel();
            MasrafYeriBilgi();
            //TOPP.Text = siparislerManager.ToplamPers().ToString();
            Toplamlar2();
            TOPA.Text = siparislerManager.ToplamArac().ToString();
            start = false;
            KadroControl();

            /*if (sayfa == "PERSONEL KAYIT")
            {
                tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage4"]);
            }
            if (sayfa == "SİPARİŞLER")
            {
                tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage1"]);
                tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage2"]);
                tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage3"]);
                tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage5"]);
            }*/


        }
        public void MasrafYeriGuncel()
        {
            CmbMasrafYeriNoG.DataSource = masrafYeriManager.GetList();
            CmbMasrafYeriNoG.ValueMember = "Id";
            CmbMasrafYeriNoG.DisplayMember = "MasrafYeriNo";
            CmbMasrafYeriNoG.SelectedValue = 0;
        }
        public void MasrafYeri()
        {
            CmbMasYeriNo.DataSource = masrafYeriManager.GetList();
            CmbMasYeriNo.ValueMember = "Id";
            CmbMasYeriNo.DisplayMember = "MasrafYeriNo";
            CmbMasYeriNo.SelectedValue = 0;
        }
        public void MasrafYeriBilgiGuncel()
        {
            CmbMastafYeriG.DataSource = masrafYeriManager.GetList();
            CmbMastafYeriG.ValueMember = "Id";
            CmbMastafYeriG.DisplayMember = "MasrafYeriBilgi";
            CmbMastafYeriG.SelectedValue = 0;
        }
        public void MasrafYeriBilgi()
        {
            TxtMasrafYeri.DataSource = masrafYeriManager.GetList();
            TxtMasrafYeri.ValueMember = "Id";
            TxtMasrafYeri.DisplayMember = "MasrafYeriBilgi";
            TxtMasrafYeri.SelectedValue = 0;
        }
        void ProjeKodu()
        {
            CmbProjeKodu.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProjeKodu.ValueMember = "Id";
            CmbProjeKodu.DisplayMember = "Baslik";
            CmbProjeKodu.SelectedValue = 0;
        }
        void ProjeKoduGun()
        {
            CmbProjeKoduGun.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProjeKoduGun.ValueMember = "Id";
            CmbProjeKoduGun.DisplayMember = "Baslik";
            CmbProjeKoduGun.SelectedValue = 0;
        }
        void KadroControl()
        {
            foreach (DataGridViewRow item in DtgMevcutKadro.Rows)
            {
                int toplamPersonel = item.Cells["Personeltoplam"].Value.ConInt();
                int personelSayisi = item.Cells["MevcutPersonel"].Value.ConInt();
                if (personelSayisi < toplamPersonel)
                {
                    item.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        public void ComboProje()
        {
            CmbProje.DataSource = comboManager.GetList("SİPARİŞLER PROJE");
            CmbProje.ValueMember = "Id";
            CmbProje.DisplayMember = "Baslik";
            CmbProje.SelectedValue = 0;
        }
        public void ComboSat()
        {
            TxtSatt.DataSource = comboManager.GetList("SİPARİŞLER SAT");
            TxtSatt.ValueMember = "Id";
            TxtSatt.DisplayMember = "Baslik";
            TxtSatt.SelectedValue = 0;
        }
        public void ComboSatKategori()
        {
            CmbSatKategori.DataSource = comboManager.GetList("SİPARİŞLER SAT KATEGORİ");
            CmbSatKategori.ValueMember = "Id";
            CmbSatKategori.DisplayMember = "Baslik";
            CmbSatKategori.SelectedValue = 0;
        }
        void MasrafYeriSorumlusu()
        {
            CmbMasrafYeriSorumlusu.DataSource = siparisPersonelManager.MasrafYeriSorumlusu();
            CmbMasrafYeriSorumlusu.ValueMember = "Id";
            CmbMasrafYeriSorumlusu.DisplayMember = "Personel";
            CmbMasrafYeriSorumlusu.SelectedValue = 0;
        }
        void MasrafYeriSorumlusuGun()
        {
            CmbMasrafYeriSorumlusuGun.DataSource = siparisPersonelManager.MasrafYeriSorumlusu();
            CmbMasrafYeriSorumlusuGun.ValueMember = "Id";
            CmbMasrafYeriSorumlusuGun.DisplayMember = "Personel";
            CmbMasrafYeriSorumlusuGun.SelectedValue = 0;
        }
        public void YenilecekVeri()
        {
            button5.Enabled = false;
            personelKayits = personelKayitManager.GetList();
            AdSoyadDoldur();
            AsoyadDoldurA();
            MevcutKadro();
            SiparisDoldur();
            SiparisDoludurG();
            MasrafYeriSorumlusu();
            MasrafYeriSorumlusuGun();
            ComboProje();
            ComboSat();
            ComboSatKategori();
            KadroControl();
            button5.Enabled = true;
        }
        private void BtnFotoEkle_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog2.ShowDialog();

            if (dr == DialogResult.OK)
            {
                fotoyolu = openFileDialog2.FileName;
                kaynakdosyaismi1 = openFileDialog2.SafeFileName.ToString();

                alinandosya1 = openFileDialog2.FileName.ToString();


                if (Path.GetExtension(fotoyolu) == ".jpg" || Path.GetExtension(fotoyolu) == ".png")
                {
                    PctBox.ImageLocation = fotoyolu;
                    Properties.Settings.Default.FotoYolu = fotoyolu;
                    Properties.Settings.Default.Save();

                    yeniad = Txtadsoyad.Text + ".jpg";
                    if (!Directory.Exists(dosyaYolu + "\\" + yeniad))
                    {
                        string silinecek = dosyaYolu + "\\" + yeniad;
                        File.Delete(silinecek);
                    }
                    File.Copy(fotoyolu, dosyaYolu + "\\" + yeniad);
                }
                else
                {
                    MessageBox.Show("Lütfen JPEG veya PNG formatında olan bir dosyayı seçiniz.");
                }
                BtnKaydet.Enabled = true;
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            personelKayit = null;
            DialogResult dr = MessageBox.Show("Personeli Eklemek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                BolumOlustur();

                personelKayit = new PersonelKayit(Txtadsoyad.Text, MsdTc.Text, TxtHes.Text, TxtSicilno.Text, TxtIkametgah.Text, CmbKan.Text, TxtEsad.Text, MsdEsTelefon.Text,
                DtDogumTarihi.Value, CmbMedeniDurum.Text, CmbEsIsDurumu.Text, CmbCocukSayisi.Text, TxtDogumYeri.Text, TxtOkul.Text, TxtBolum.Text, TxtDipNotu.Text, CmbSiparis.Text, CmbSat.Text,
                CmbButceKodu.Text, CmbButceKalemi.Text, TxtSicil.Text, CmbMasYeriNo.Text, TxtMasrafYeri.Text, CmbMasrafYeriSorumlusu.Text, BOLUM, TxtSirketMail.Text, TxtOfficeMail.Text, MsdSırketCepNo.Text, MsdKisaKod.Text, MsdDahiliNo.Text,
                CmbIsUnvani.Text, DtIseGirisTarihi.Value, askerlikdurumu, TxtSinif.Text, TxtRutbesi.Text, TxtGorevi.Text, DtAsBasTarihi.Text.ToString(), DtAsBitTarihi.Text.ToString(), TxtGorevYeri.Text, DtTecilBitTarihi.Text.ToString(), TxtTecilSebebi.Text, TxtMuafNedeni.Text,
                siparisNo, dosyaYolu, dosyaYolu, CmbProjeKodu.Text, TxtKgbNo.Text, DtKgb.Value);

                string message = personelKayitManager.Add(personelKayit);
                if (message!="OK")
                {
                    MessageBox.Show(message,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                adsoyad = Txtadsoyad.Text;
                siparis = CmbSiparis.Text;
                sat = CmbSat.Text;
                butcekoud = CmbButceKodu.Text;
                butcekalemi = CmbButceKalemi.Text;
                unvan = CmbIsUnvani.Text;
                bolum = BOLUM;
                islem = Txtadsoyad.Text + " Kişisi Eklendi";
                islemyapan = infos[1].ToString();
                islemtarihi = DateTime.Now.ToString();

                if (message == "OK")
                {
                    DevamEdenIzleme devamEdenIzleme = new DevamEdenIzleme(siparisNo, islem, islemyapan, islemtarihi.ConDate());
                    devamEdenIzlemeManager.Add(devamEdenIzleme);
                    Task.Factory.StartNew(() => MailSendMetot());
                    control = false;
                    if (personelKadroKontrol==true)
                    {
                        mevcut++;
                        string mevcutpersonel = siparislerManager.KontejanMevcutGuncelle(CmbSiparis.Text, mevcut);

                        if (mevcutpersonel != "OK")
                        {
                            MessageBox.Show(mevcutpersonel);
                        }
                        personelKadroKontrol = false;
                    }
                    PersonelKayit personelKayit = personelKayitManager.Get(0,Txtadsoyad.Text);

                    personelId = personelKayit.Id.ConInt();

                    string mesage2 = personelKayitManager.YetkiliEkle(personelId, yetkiliId);

                    if (mesage2!="OK")
                    {
                        MessageBox.Show(mesage2, "Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }

                    TemizlePersonelKayit();
                }
            }
        }
        void TemizlePersonelKayit()
        {
            Txtadsoyad.Clear(); MsdTc.Clear(); TxtHes.Clear(); TxtSicilno.Clear(); TxtIkametgah.Clear(); CmbKan.Text = ""; TxtEsad.Clear();
            MsdEsTelefon.Clear(); CmbMedeniDurum.Text = ""; CmbEsIsDurumu.Text = ""; CmbCocukSayisi.Text = ""; TxtDogumYeri.Clear(); TxtOkul.Clear();
            TxtBolum.Clear(); TxtDipNotu.Clear(); CmbSiparis.SelectedValue = ""; CmbSat.Text = ""; CmbButceKodu.Text = ""; CmbButceKalemi.Text = "";
            TxtSicil.Clear(); CmbMasYeriNo.Text = ""; TxtMasrafYeri.Text = ""; CmbDepartman.Text = ""; CmbBolum.Text = ""; CmbBolum2.SelectedValue = "";
            CmbBolum3.SelectedValue = ""; TxtSirketMail.Text = ""; TxtOfficeMail.Text = ""; MsdSırketCepNo.Clear(); MsdKisaKod.Clear(); MsdDahiliNo.Clear();
            CmbIsUnvani.Text = ""; TxtSinif.Clear(); TxtRutbesi.Clear(); TxtGorevi.Clear(); TxtGorevYeri.Clear(); TxtTecilSebebi.Clear();
            TxtMuafNedeni.Clear(); webBrowser4.Navigate(""); PctBox.ImageLocation = ""; CmbProjeKodu.SelectedValue = -1; TxtKgbNo.Clear();
        }
        private void TxtPersonelYonetici_TextChanged(object sender, EventArgs e)
        {
            if (TxtPersonelYonetici.Text == "")
            {
                personelyonetici = 0;
                TxtPersonelYonetici.Text = (0).ToString();
            }
            personelyonetici = TxtPersonelYonetici.Text.ConInt();
            TxtPersonelSayisi.Text = (personelyonetici + personel + personeldepo).ToString();
            TOPLAMPERSONEL = personelyonetici;
        }
        private void TxtPersonel_TextChanged(object sender, EventArgs e)
        {
            if (TxtPersonel.Text == "")
            {
                personel = 0;
                TxtPersonel.Text = (0).ToString();
            }
            personel = TxtPersonel.Text.ConInt();
            TxtPersonelSayisi.Text = (personelyonetici + personel + personeldepo).ToString();
            TOPLAMPERSONEL = personelyonetici + personel;
        }
        private void TxtPersonelDepo_TextChanged(object sender, EventArgs e)
        {
            if (TxtPersonelDepo.Text == "")
            {

                personeldepo = 0;
                TxtPersonelDepo.Text = (0).ToString();
            }
            personeldepo = TxtPersonelDepo.Text.ConInt();
            TxtPersonelSayisi.Text = (personelyonetici + personel + personeldepo).ToString();
            TOPLAMPERSONEL = personelyonetici + personel + personeldepo;
        }

        private void TxtYoneticiArac_TextChanged(object sender, EventArgs e)
        {
            if (TxtYoneticiArac.Text == "")
            {
                yoneticiarac = 0;
                TxtYoneticiArac.Text = (0).ToString();
            }
            yoneticiarac = TxtYoneticiArac.Text.ConInt();
            D.Text = (yoneticiarac + araziarac).ToString();
            TOPLAMARAC = yoneticiarac;
        }
        private void TxtAraziArac_TextChanged(object sender, EventArgs e)
        {
            if (TxtAraziArac.Text == "")
            {
                araziarac = 0;
                TxtAraziArac.Text = (0).ToString();
            }
            araziarac = TxtAraziArac.Text.ConInt();
            D.Text = (araziarac + yoneticiarac).ToString();
            TOPLAMARAC = araziarac + yoneticiarac;
        }
        void Yansit()
        {
            SiparisNoOlustur();
        }
        public void MevcutKadro()
        {
            DtgMevcutKadro.DataSource = siparislerManager.GetList();
            DataDisplay();
            KadroControl();
        }
        void DataDisplay()
        {
            DtgMevcutKadro.Columns["Id"].Visible = false;
            DtgMevcutKadro.Columns["Personelsayisi"].Visible = false;
            DtgMevcutKadro.Columns["Benzersiz"].Visible = false;
            DtgMevcutKadro.Columns["MevcutPersonel"].HeaderText = "MEVCUT PERSONEL";
            DtgMevcutKadro.Columns["Proje"].HeaderText = "PROJE";
            DtgMevcutKadro.Columns["Siparisno"].HeaderText = "SİPARİŞ NO";
            DtgMevcutKadro.Columns["Personelyonetici"].HeaderText = "PERSONEL YÖNETİCİ";
            DtgMevcutKadro.Columns["Personel"].HeaderText = "PERSONEL";
            DtgMevcutKadro.Columns["Personeldepo"].HeaderText = "PERSONEL DEPO";
            DtgMevcutKadro.Columns["Personeltoplam"].HeaderText = "PERSONEL TOPLAM";
            DtgMevcutKadro.Columns["Yoneticiarac"].HeaderText = "YÖNETİCİ ARAÇ";
            DtgMevcutKadro.Columns["Araziarac"].HeaderText = "ARAZİ ARAÇ";
            DtgMevcutKadro.Columns["Toplamarac"].HeaderText = "TOPLAM ARAÇ";
            DtgMevcutKadro.Columns["Sat"].HeaderText = "SAT";
            DtgMevcutKadro.Columns["Donemyil"].HeaderText = "DÖNEM YIL";
            DtgMevcutKadro.Columns["Satkategori"].HeaderText = "SAT KATEGORİ";
            DtgMevcutKadro.Columns["MevcutPersonel"].DisplayIndex = 13;
            Toplamlar();
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMevcutKadro.Rows.Count; ++i)
            {
                if (DtgMevcutKadro.Rows[i].Cells[2].Value.ToString() != "N/A2021N/A10P0A")
                {
                    toplam += Convert.ToDouble(DtgMevcutKadro.Rows[i].Cells[15].Value);
                }
            }
            TxtMevcutPersonel.Text = toplam.ToString();
        }
        void Toplamlar2()
        {
            double toplamPersonel = 0;
            for (int i = 0; i < DtgMevcutKadro.Rows.Count; ++i)
            {
                if (DtgMevcutKadro.Rows[i].Cells[2].Value.ToString() != "N/A2021N/A10P0A")
                {
                    toplamPersonel += Convert.ToDouble(DtgMevcutKadro.Rows[i].Cells[12].Value);
                }
            }
            TOPP.Text = toplamPersonel.ToString();
        }
        void GuncelleTemizle()
        {
            CmbAdSoyad.SelectedValue = ""; TxtTcG.Clear(); TxtHesG.Clear(); TxtSigortaSicil.Clear(); CmbKanG.Text = ""; TxtEsAdG.Clear(); TxtEsTelefonG.Clear();
            TxtIkametgahG.Clear(); CmbMedeniG.Text = ""; CmbEsIsDurumuG.Text = ""; CmbCocukSayisiG.Text = ""; TxtDogumYeriG.Clear(); TxtOkulG.Clear(); TxtBolumG.Clear();
            TxtDipG.Clear(); CmbSiparisG.SelectedValue = ""; CmbSatG.Text = ""; CmbButcekoduG.Text = ""; CmbButceKalemiG.Text = ""; TxtSicilG.Clear();
            CmbMasrafYeriNoG.Text = ""; CmbDepartmanG.Text = ""; CmbBolumG.SelectedValue = ""; CmbBolum2G.SelectedValue = ""; CmbBolum3G.SelectedValue = "";
            TxtSirketMailG.Clear(); TxtOficeMailG.Clear(); TxtSirketCepG.Clear(); TxtSirketKısaKodG.Clear(); TxtOficeDahiliNoG.Clear(); CmbIsUnvaniG.Text = "";
            TxtSinifG.Text = ""; TxtRubesiG.Clear(); TxtGoreviG.Clear(); TxtGorevYeriG.Clear(); TxtTecilSebebiG.Clear(); TxtMuafNedeniG.Clear();
            PcFoto.ImageLocation = ""; webBrowserG.Navigate(""); TxtBulunduguBolum.Clear(); RdbTecilliG.Checked = false; RdbMuafG.Checked = false;
            RdbYaptiG.Checked = false; CmbProjeKoduGun.SelectedValue = -1; TxtKgbNoGun.Clear(); CmbMasrafYeriSorumlusuGun.Text = "";
        }

        void Temizle()
        {
            TxtDonemYil.Clear(); TxtYoneticiArac.Clear(); TxtAraziArac.Clear(); TxtPersonelYonetici.Clear(); TxtPersonel.Clear(); TxtPersonelDepo.Clear();
            CmbProje.Text = ""; TxtSatt.Text = ""; CmbSatKategori.Text = ""; CmbProje.SelectedValue = ""; TxtSatt.SelectedValue = ""; CmbSatKategori.SelectedValue = "";

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (ids==0)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Sipariş Kaydı Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Sipariş Numarasını Silmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                siparislerManager.Delete(ids);
                //MevcutKadro();
                Temizle();
                MevcutKadro();
            }
        }
        private void BtnSiparisGuncelle_Click(object sender, EventArgs e)
        {
            //Yansit();
            SiparisNoOlustur();
            DialogResult dr = MessageBox.Show("Yeni Sipariş Numarası GüNCELLEMEK İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                siparisler = new Siparisler(CmbProje.Text, SİPARİSNO, personelyonetici, personel, personeldepo, TOPLAMPERSONEL,
                    yoneticiarac, araziarac, TOPLAMARAC, TOPLAMPERSONEL, TxtSatt.Text, TxtDonemYil.Text, CmbSatKategori.Text, benzersizgelen);

                string messege = siparislerManager.Update(siparisler);
                MessageBox.Show(messege);
                MevcutKadro();
                Temizle();
                SiparisDoldur();
            }
        }

        void SiparisNoOlustur()
        {
            SİPARİSNO = TxtSatt.Text +"-"+ TxtDonemYil.Text + "-" + CmbSatKategori.Text + "-" + TOPLAMPERSONEL + "P" + TOPLAMARAC + "A";
        }

        private void BtnSiparisOlustur_Click(object sender, EventArgs e)
        {
            benzersizolustur = Guid.NewGuid().ToString();
            Yansit();
            siparisler = null;
            DialogResult dr = MessageBox.Show("Yeni Sipariş Numarası Oluşturmak İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                siparisler = new Siparisler(CmbProje.Text, SİPARİSNO, personelyonetici, personel, personeldepo, TOPLAMPERSONEL,
                    yoneticiarac, araziarac, TOPLAMARAC, TOPLAMPERSONEL, TxtSatt.Text, TxtDonemYil.Text, CmbSatKategori.Text, benzersizolustur);

                string messege = siparislerManager.Add(siparisler);
                MessageBox.Show(messege);
                MevcutKadro();
                Temizle();
                SiparisDoldur();
                //TOPP.Text = siparislerManager.ToplamPers().ToString();
                Toplamlar2();
                TOPA.Text = siparislerManager.ToplamArac().ToString();
            }
        }

        private void BtnKaydetA_Click(object sender, EventArgs e)
        {
            istenAyrilis = null;
            DialogResult dr = MessageBox.Show(CmbAdsoyadA.Text + " Personeli İçin İşten Ayrılış işlemini Kaydetmek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                istenAyrilis = new IstenAyrilis(CmbAdsoyadA.Text, TxtSiparisA.Text, TxtSatA.Text, TxtButceKoduA.Text, TxtButceKalemiA.Text, TxtSiclA.Text, TxtMasrafYeriNoA.Text, TxtMasrafYeriA.Text, TxtIsBolumA.Text, TxtSırketMailA.Text, TxtOficeMailA.Text,
                    TxtSirketCepA.Text, TxtKisaKodA.Text, TxtDahiliNoA.Text, TxtIsUnvaniA.Text, MsdIseGirisTarihi.Value, DtIstenAyrilis.Value, CmbIstenAyrilisNedeni.Text, TxtIstenAyrilisAciklama.Text, istenayrilankisi, tc, hes, sigortasicilno, ikametgah,
                    kan, esad, estelefon, dogumtarihi, medenidurumu, esisdurumu, cocuksayisi, dogumyeri, askerlikdurumu, assinifi, rutbesi, gorevi, gorevyeri, askerlikbas, askerlikbit, tecilbit, tecilsebebi, muafnedeni, okul, okulbolum, dipnotu, siparisNo);

                string messege = istenAyrilisManager.Add(istenAyrilis);
                MessageBox.Show(messege);

                islem2 = CmbAdsoyadA.Text + " Kişisi İçin İşten Ayrılış İşlemi Gerçekleşti.";
                islemyapan2 = infos[1].ToString();
                islemtarihi2 = DateTime.Now.ToString();

                adsoyad = CmbAdsoyadA.Text;
                Gsiparis = TxtSiparisA.Text;
                Gsat = TxtSatA.Text;
                Gbutcekoud = TxtButceKoduA.Text;
                Gbutcekalemi = TxtButceKalemiA.Text;
                Gunvan = TxtIsUnvaniA.Text;
                Gbolum = TxtIsBolumA.Text;

                if (messege == "Bilgiler Başarıyla Kaydedildi.")
                {
                    DevamEdenIzleme devamEdenIzleme = new DevamEdenIzleme(siparisNo, islem2, islemyapan2, islemtarihi2.ConDate());
                    devamEdenIzlemeManager.Add(devamEdenIzleme);
                    int yenimevcut = --mevcut;
                    siparislerManager.KontejanMevcutAzalt(TxtSiparisA.Text, yenimevcut);
                    istenAyrilisManager.Delete(id);

                    Task.Factory.StartNew(() => MailSendMetotS());
                    TemizleIstenAyrilis();
                }
            }
        }
        void TemizleIstenAyrilis()
        {
            CmbAdsoyadA.SelectedValue = ""; TxtSiparisA.Clear(); TxtSatA.Clear(); TxtButceKoduA.Clear(); TxtButceKalemiA.Clear(); TxtSiclA.Clear(); TxtMasrafYeriNoA.Clear();
            TxtMasrafYeriA.Clear(); TxtIsBolumA.Clear(); TxtSırketMailA.Clear(); TxtOficeMailA.Clear(); TxtSirketCepA.Clear(); TxtKisaKodA.Clear(); TxtDahiliNoA.Clear();
            TxtIsUnvaniA.Clear(); CmbIstenAyrilisNedeni.Text = ""; TxtIstenAyrilisAciklama.Clear(); webBrowser.Navigate("");
        }
        void RadyobutonG()
        {
            if (RdbYaptiG.Checked == true)
            {
                askerlikdurumuG = "YAPTI";
                TxtSinifG.Enabled = true;
                TxtRubesiG.Enabled = true;
                TxtGoreviG.Enabled = true;
                DtBasTarihiG.Enabled = true;
                DtBitTarihiG.Enabled = true;
                TxtGorevYeriG.Enabled = true;
                TxtMuafNedeniG.Enabled = false;
                TxtTecilSebebiG.Enabled = false;
                DtTecilBitTarihiG.Enabled = false;
                TxtMuafNedeniG.Clear();
                TxtTecilSebebiG.Clear();
            }
            if (RdbMuafG.Checked == true)
            {
                askerlikdurumuG = "MUAF";
                TxtMuafNedeniG.Enabled = true;
                TxtSinifG.Enabled = false;
                TxtRubesiG.Enabled = false;
                TxtGoreviG.Enabled = false;
                TxtGorevYeriG.Enabled = false;
                DtBasTarihiG.Enabled = false;
                DtBitTarihiG.Enabled = false;
                DtTecilBitTarihiG.Enabled = false;
                TxtTecilSebebiG.Enabled = false;
                TxtSinifG.Clear();
                TxtRubesiG.Clear();
                TxtGoreviG.Clear();
                TxtGorevYeriG.Clear();
                TxtTecilSebebiG.Clear();
            }
            if (RdbTecilliG.Checked == true)
            {
                askerlikdurumuG = "TECİLLİ";
                DtTecilBitTarihiG.Enabled = true;
                TxtTecilSebebiG.Enabled = true;
                TxtSinifG.Enabled = false;
                TxtRubesiG.Enabled = false;
                TxtGoreviG.Enabled = false;
                TxtGorevYeriG.Enabled = false;
                DtBasTarihiG.Enabled = false;
                DtBitTarihiG.Enabled = false;
                TxtMuafNedeniG.Enabled = false;
                TxtSinifG.Clear();
                TxtRubesiG.Clear();
                TxtGoreviG.Clear();
                TxtGorevYeriG.Clear();
                TxtMuafNedeniG.Clear();
            }
        }
        void Radyobuton()
        {
            if (RdbYapti.Checked == true)
            {
                askerlikdurumu = "YAPTI";
                TxtSinif.Enabled = true;
                TxtRutbesi.Enabled = true;
                TxtGorevi.Enabled = true;
                DtAsBasTarihi.Enabled = true;
                DtAsBitTarihi.Enabled = true;
                TxtGorevYeri.Enabled = true;
                TxtMuafNedeni.Enabled = false;
                TxtTecilSebebi.Enabled = false;
                DtTecilBitTarihi.Enabled = false;
                TxtMuafNedeni.Clear();
                TxtTecilSebebi.Clear();
            }
            if (RdbMuaf.Checked == true)
            {
                askerlikdurumu = "MUAF";
                TxtMuafNedeni.Enabled = true;
                TxtSinif.Enabled = false;
                TxtRutbesi.Enabled = false;
                TxtGorevi.Enabled = false;
                TxtGorevYeri.Enabled = false;
                DtAsBasTarihi.Enabled = false;
                DtAsBitTarihi.Enabled = false;
                DtTecilBitTarihi.Enabled = false;
                TxtTecilSebebi.Enabled = false;
                TxtSinif.Clear();
                TxtRutbesi.Clear();
                TxtGorevi.Clear();
                TxtGorevYeri.Clear();
                TxtTecilSebebi.Clear();
            }
            if (RdbTecilli.Checked == true)
            {
                askerlikdurumu = "TECİLLİ";
                DtTecilBitTarihi.Enabled = true;
                TxtTecilSebebi.Enabled = true;
                TxtSinif.Enabled = false;
                TxtRutbesi.Enabled = false;
                TxtGorevi.Enabled = false;
                TxtGorevYeri.Enabled = false;
                DtAsBasTarihi.Enabled = false;
                DtAsBitTarihi.Enabled = false;
                TxtMuafNedeni.Enabled = false;
                TxtSinif.Clear();
                TxtRutbesi.Clear();
                TxtGorevi.Clear();
                TxtGorevYeri.Clear();
                TxtMuafNedeni.Clear();
            }
        }
        private void CmbMedeniDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbMedeniDurum.SelectedIndex == 0)
            {
                TxtEsad.Enabled = true;
                MsdEsTelefon.Enabled = true;
                CmbEsIsDurumu.Enabled = true;
                CmbCocukSayisi.Enabled = true;
            }
            if (CmbMedeniDurum.SelectedIndex == 1)
            {
                TxtEsad.Clear();
                MsdEsTelefon.Clear();
                CmbEsIsDurumu.Text = "";
                CmbCocukSayisi.Text = "";
                TxtEsad.Enabled = false;
                MsdEsTelefon.Enabled = false;
                CmbEsIsDurumu.Enabled = false;
            }
        }
        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            root = @"Z:\DTS";
            subdir = @"Z:\DTS\İDARİ İŞLER\PERSONELLER\";
            //root = @"C:\STS";
            //subdir = @"C:\STS\Personel Dosyaları\";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            Directory.CreateDirectory(subdir + olusandosyaadi);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                kaynakdosyaismi = openFileDialog1.SafeFileName.ToString();
                alinandosya = openFileDialog1.FileName.ToString();
            }
            else
            {
                MessageBox.Show("Dosya Seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dosyaYolu = subdir + olusandosyaadi;

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
            }
            BtnFotoEkle.Enabled = true;
            WebBrowser1();
        }

        private void RdbYapti_CheckedChanged(object sender, EventArgs e)
        {
            Radyobuton();
        }

        private void RdbMuaf_CheckedChanged(object sender, EventArgs e)
        {
            Radyobuton();
        }

        private void RdbTecilli_CheckedChanged(object sender, EventArgs e)
        {
            Radyobuton();
        }
        private void WebBrowser1()
        {
            webBrowser4.Navigate(dosyaYolu);
        }
        private void WebBrowser2()
        {
            //webBrowserr.Navigate(guncellenecekdosya);
            webBrowserG.Navigate(guncellenecekdosya);


        }
        void WebBrowser3()
        {
            webBrowser.Navigate(istenayrilankisi);
        }

        public void MailSend(string subject, string body, List<string> receivers, List<string> attachments = null)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                //client.Host = "smtp.gmail.com";
                client.Host = "192.168.23.10";
                //client.Host = "smtp-mail.outlook.com ";
                client.EnableSsl = false;
                client.Timeout = 11000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //client.Credentials = new System.Net.NetworkCredential("mubotomasyon@gmail.com", "MCHT44aa:");
                client.Credentials = new System.Net.NetworkCredential("dts@mubvan.net", "123456");
                //client.Credentials = new System.Net.NetworkCredential("mucahitaydemir@basaranteknoloji.net", "Aydemir_123");
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("dts@mubvan.net", "DTS Bilgilendirme");
                mailMessage.SubjectEncoding = Encoding.UTF8;
                mailMessage.Subject = subject; //E-posta Konu Kısmı
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.Body = body; // E-posta'nın Gövde Metni
                foreach (string item in receivers)
                {
                    mailMessage.To.Add(item);
                }
                mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                if (attachments != null)
                {
                    if (attachments.Count > 0)
                    {
                        foreach (string filePath in attachments)
                        {
                            if (File.Exists(filePath))
                            {
                                Attachment attachment = new Attachment(filePath);
                                mailMessage.Attachments.Add(attachment);
                            }
                        }
                    }
                }
                client.Send(mailMessage);
            }
            catch (Exception)
            {
                //  MessageBox.Show(ex.Message);
            }
        }
        void MailSendMetot()
        {
            MailSend("Personel Listesi (Yeni Kayıt) " + adsoyad, "Merhaba; \n\nAşağıda Bilgileri verilen personelin DTS Personel Listesine kayıt işlemi tamamlanmıştır. \n\nİyi Çalışmalar.\n\n" +
                "AD SOYAD        : " + adsoyad + "\n" +
                "SİPARİŞ             : " + siparis + "\n" +
                "SAT                     : " + sat + "\n" +
                "BÜTÇE KODU    : " + butcekoud + "\n" +
                "BÜTÇE KALEMİ: " + butcekalemi + "\n" +
                "ÜNVANI            : " + unvan + "\n" +
                "BÖLÜMÜ          : " + bolum + "\n\n\n" +
                "Bu mail DTS (DATA TRACCIPT SYSTEM) tarafından " +
                "otomatik olarak gönderilmektedir. Bu mesaja Cevap vermeyiniz. Görüş  ve Önerileriniz için dtsteknik@mubvan.net adresine iletiniz.",
                new List<string>() { "resulgunes@mubvan.net", "emelayhan@mubvan.net" });
        }
        void MailSendMetotG()
        {
            MailSend("Personel Listesi (Güncelleme) " + Gadsoyad, "Merhaba; \n\nAşağıda Bilgileri verilen personelin DTS Personel Listesinde Güncelleme işlemi tamamlanmıştır. \n\nİyi Çalışmalar.\n\n" +
               "AD SOYAD        : " + Gadsoyad + "\n" +
               "SİPARİŞ             : " + Gsiparis + "\n" +
               "SAT                     : " + Gsat + "\n" +
               "BÜTÇE KODU    : " + Gbutcekoud + "\n" +
               "BÜTÇE KALEMİ: " + Gbutcekalemi + "\n" +
               "ÜNVANI            : " + Gunvan + "\n" +
               "BÖLÜMÜ          : " + Gbolum + "\n\n\n" +
               "Bu mail DTS (DATA TRACCIPT SYSTEM) tarafından " +
               "otomatik olarak gönderilmektedir. Bu mesaja Cevap vermeyiniz. Görüş  ve Önerileriniz için dtsteknik@mubvan.net adresine iletiniz.",
               new List<string>() { "resulgunes@mubvan.net", "emelayhan@mubvan.net" });
        }
        void MailSendMetotS()
        {
            MailSend("Personel Listesi (İşten Ayrılış) " + Gadsoyad, "Merhaba; \n\nAşağıda Bilgileri verilen personelin DTS Personel Listesinden Silme işlemi tamamlanmıştır. \n\nİyi Çalışmalar.\n\n" +
               "AD SOYAD        : " + Gadsoyad + "\n" +
               "SİPARİŞ             : " + Gsiparis + "\n" +
               "SAT                     : " + Gsat + "\n" +
               "BÜTÇE KODU    : " + Gbutcekoud + "\n" +
               "BÜTÇE KALEMİ: " + Gbutcekalemi + "\n" +
               "ÜNVANI            : " + Gunvan + "\n" +
               "BÖLÜMÜ          : " + Gbolum + "\n\n\n" +
               "Bu mail DTS (DATA TRACCIPT SYSTEM) tarafından " +
               "otomatik olarak gönderilmektedir. Bu mesaja Cevap vermeyiniz. Görüş  ve Önerileriniz için dtsteknik@mubvan.net adresine iletiniz.",
               new List<string>() { "resulgunes@mubvan.net", "emelayhan@mubvan.net" });
        }
    }
}
