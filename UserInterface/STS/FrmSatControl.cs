using Business;
using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.Depo;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarim;
using Entity.Depo;
using Entity.IdariIsler;
using Entity.STS;
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

namespace UserInterface.STS
{

    public partial class FrmSatControl : Form
    {
        SatDataGridview1Manager satDataGridview1Manager;
        TedarikciFirmaManager tedarikciFirmaManager;
        SatinAlinacakMalManager satinAlinacakMalManager;
        TeklifiAlinanManager teklifiAlinanManager;
        SatIslemAdimlariManager satIslemAdimlarimanager;
        FiyatTeklifiAlManager fiyatTeklifiAlManager;
        DepoKayitManagercs depoKayitManagercs;
        BolgeKayitManager bolgeKayitManager;
        TamamlananManager tamamlananManager;
        TamamlananMalzemeManager tamamlananMalzemeManager;
        AbfMalzemeManager abfMalzemeManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        ArizaKayitManager arizaKayitManager;
        MalzemeTalepManager malzemeTalepManager;

        List<SatDataGridview1> satDatas;
        List<SatDataGridview1> satDatas2;
        List<SatDataGridview1> satDatas3;
        List<SatDataGridview1> satDatas4;
        List<SatDataGridview1> satDatas5;
        List<SatDataGridview1> satDatas6;
        List<SatDataGridview1> satDatas7;
        List<SatDataGridview1> satDatas8;
        List<SatDataGridview1> satDatas9;
        List<SatDataGridview1> satDatas10;
        List<SatDataGridview1> satDatas11;
        List<SatDataGridview1> satDatas12;
        List<SatDataGridview1> satDatas13;
        List<SatinAlinacakMalzemeler> satinAlinacakMalzemelers;
        List<AbfMalzeme> abfMalzemes;
        List<FiyatTeklifiAl> fiyatTeklifiAls;
        List<TedarikciFirma> tedarikciFirmas;
        List<int> depoStokId;

        public object[] infos;
        string dosyaYolu, siparisNo, kaynakdosyaismi, isAkisNo, alinandosya, yapilanislem, satBirim, masrafyeri, talepeden, bolum, usbolgesi, abfformno, gerekce, butcekodukalemi, harcamaturu, belgeTuru, belgeNumarasi, faturafirma, ilgilikisi, masrafyerino, donem, satOlusturmaTuru, proje, satinAlinanFirma, mlzTeslimTarihi, harcamayapan, depoTeslimBilgisi;
        int miktar, satno, formno, id;
        bool start, dosyaKontrol, secim, mailKontrol = false;
        double toplamlar;
        DateTime istenentarih, belgeTarihi, odemebilgi, depoTeslimTarihi;
        public FrmSatControl()
        {
            InitializeComponent();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            tedarikciFirmaManager = TedarikciFirmaManager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            teklifiAlinanManager = TeklifiAlinanManager.GetInstance();
            satIslemAdimlarimanager = SatIslemAdimlariManager.GetInstance();
            fiyatTeklifiAlManager = FiyatTeklifiAlManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            tamamlananManager = TamamlananManager.GetInstance();
            tamamlananMalzemeManager = TamamlananMalzemeManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            malzemeTalepManager = MalzemeTalepManager.GetInstance();
        }

        private void FrmSatControl_Load(object sender, EventArgs e)
        {
            Yenile();
        }
        void Yenile()
        {
            SatDataGrid1();
            TedarikciFirma();
            FillAlimYapilacakSatDrkt();
            FillFaturaBekleyenSatDrkt();
            FillDepoMAlzemeTeslim();
            FillSatTamamlama();
            TeklifMailMdl();
            TeklifMailMdlKayit();
            TedarikciFirma2();
            FillAlimYapilacakSatMdl();
            FillFaturaBekleyenSatMdl();
            FillOdemeBilgileri();
            FillOdemeBilgileriBekleyen();
            FillAselsanOnayMail();
            FillAselsanOnayMailAlma();
            FillFaturaBekleyenSatDrkt();
            FillFaturaBekleyenSatMdl();
            LblMailGondermeTarihi.Text = DateTime.Now.ToString("d");
            LblMailTarihi.Text = DateTime.Now.ToString("d");
            LblOdemeMailGonderme.Text = DateTime.Now.ToString("d");
            DepoTeslimTarihi.Text = DateTime.Now.ToString("d");

            tabPage4.Text = "TEKLİF ALINACAK SAT " + "( " + (LblTop.Text.ConInt() + LblTop11.Text.ConInt() + LblTop13.Text.ConInt()).ToString() + " )";
            tabPage9.Text = "ASELSAN ONAY ALINACAK SAT " + "( " + (LblTop24.Text.ConInt() + LblTop26.Text.ConInt()).ToString() + " )";
            tabPage5.Text = "ALIMI YAPILACAK SAT " + "( " + (LblTop3.Text.ConInt() + LblTop16.Text.ConInt()).ToString() + " )";
            tabPage10.Text = "FATURA BEKLEYEN SAT " + "( " + (LblTop5.Text.ConInt() + LblTop18.Text.ConInt()).ToString() + " )";
            tabPage13.Text = "ÖDEME BİLGİLERİ " + "( " + (LblTop20.Text.ConInt() + LblTop22.Text.ConInt()).ToString() + " )";
            tabPage8.Text = "DEPO MALZEME TESLİM " + "( " + LblTop6.Text + " )";
            tabPage18.Text = "FATURA KESİLECEK SAT " + "( " + (label72.Text.ConInt() + label87.Text.ConInt() + label94.Text.ConInt()).ToString() + " )";
            tabPage17.Text = "SAT TAMAMLAMA " + "( " + LblTop8.Text + " )";

            TabPage.Text = "PRJ.DİR.TEKLİF İSTENECEK/GİRİLECEK SAT " + "( " + LblTop.Text + " )";
            tabPage2.Text = "SATIN ALMA MDL. TEKLİF İSTENECEK SAT " + "( " + LblTop11.Text + " )";
            tabPage1.Text = "SATIN ALMA MDL. TEKLİF GİRİLECK SAT " + "( " + LblTop13.Text + " )";

            tabPage15.Text = "ONAY İSTENECEK SAT " + "( " + LblTop24.Text + " )";
            tabPage16.Text = "ONAY BEKLEYEN SAT " + "( " + LblTop26.Text + " )";

            tabPage6.Text = "PROJE DİREKTÖRLÜĞÜ " + "( " + LblTop3.Text + " )";
            tabPage7.Text = "SATIN ALMA MÜDÜRLÜĞÜ " + "( " + LblTop16.Text + " )";

            tabPage11.Text = "PROJE DİREKTÖRLÜĞÜ " + "( " + LblTop5.Text + " )";
            tabPage12.Text = "SATIN ALMA MÜDÜRLÜĞÜ " + "( " + LblTop18.Text + " )";

            tabPage3.Text = "ÖDEME YAPILACAK SAT " + "( " + LblTop20.Text + " )";
            tabPage14.Text = "ÖDEME YAPILAN SAT " + "( " + LblTop22.Text + " )";

            //tabControl2.TabPages.Remove(tabControl1.TabPages["tabPage18"]);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatKontrol"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        void TedarikciFirma()
        {
            tedarikciFirmas = tedarikciFirmaManager.GetList();
            CmbFirma1.DataSource = tedarikciFirmas;
            CmbFirma1.ValueMember = "Id";
            CmbFirma1.DisplayMember = "Firmaadi";
            CmbFirma1.SelectedValue = -1;
        }
        void TedarikciFirma2()
        {
            CmbFirma3.DataSource = tedarikciFirmas;
            CmbFirma3.ValueMember = "Id";
            CmbFirma3.DisplayMember = "Firmaadi";
            CmbFirma3.SelectedValue = -1;
        }
        public void CmbDepo()
        {
            CmbDepoNo.DataSource = depoKayitManagercs.GetList();
            CmbDepoNo.ValueMember = "Id";
            CmbDepoNo.DisplayMember = "Depo";
            CmbDepoNo.SelectedValue = 0;
            start = true;
        }
        void SatDataGrid1()
        {
            satDatas = satDataGridview1Manager.TekifDurumListele("Alınmadı", "Onaylandı", 1, "BELIRLENMEDI", "PRJ.DİR.SATIN ALMA");
            dataBinder.DataSource = satDatas.ToDataTable();
            DtgProjeDirTeklifGir.DataSource = dataBinder;

            DtgProjeDirTeklifGir.Columns["Id"].Visible = false;
            DtgProjeDirTeklifGir.Columns["Satno"].HeaderText = "SAT NO";
            DtgProjeDirTeklifGir.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgProjeDirTeklifGir.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgProjeDirTeklifGir.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgProjeDirTeklifGir.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgProjeDirTeklifGir.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgProjeDirTeklifGir.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgProjeDirTeklifGir.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgProjeDirTeklifGir.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgProjeDirTeklifGir.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgProjeDirTeklifGir.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgProjeDirTeklifGir.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgProjeDirTeklifGir.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgProjeDirTeklifGir.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgProjeDirTeklifGir.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgProjeDirTeklifGir.Columns["Uctekilf"].Visible = false;
            DtgProjeDirTeklifGir.Columns["SiparisNo"].Visible = false;
            DtgProjeDirTeklifGir.Columns["DosyaYolu"].Visible = false;
            DtgProjeDirTeklifGir.Columns["PersonelId"].Visible = false;
            DtgProjeDirTeklifGir.Columns["FirmaBilgisi"].Visible = false;
            DtgProjeDirTeklifGir.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgProjeDirTeklifGir.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgProjeDirTeklifGir.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgProjeDirTeklifGir.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgProjeDirTeklifGir.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgProjeDirTeklifGir.Columns["BelgeTuru"].Visible = false;
            DtgProjeDirTeklifGir.Columns["BelgeNumarasi"].Visible = false;
            DtgProjeDirTeklifGir.Columns["BelgeTarihi"].Visible = false;
            DtgProjeDirTeklifGir.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgProjeDirTeklifGir.Columns["SatOlusturmaTuru"].Visible = false;
            DtgProjeDirTeklifGir.Columns["RedNedeni"].Visible = false;
            DtgProjeDirTeklifGir.Columns["TeklifDurumu"].Visible = false;
            DtgProjeDirTeklifGir.Columns["SatinAlinanFirma"].Visible = false;
            DtgProjeDirTeklifGir.Columns["MailSiniri"].Visible = false;
            DtgProjeDirTeklifGir.Columns["MailDurumu"].Visible = false;
            DtgProjeDirTeklifGir.Columns["Durum"].Visible = false;
            DtgProjeDirTeklifGir.Columns["Donem"].HeaderText = "DÖNEM";
            DtgProjeDirTeklifGir.Columns["Proje"].HeaderText = "PROJE";
            DtgProjeDirTeklifGir.Columns["Donem"].DisplayIndex = 3;
            DtgProjeDirTeklifGir.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgProjeDirTeklifGir.Columns["HarcamaYapan"].Visible = false;
            DtgProjeDirTeklifGir.Columns["AselsanMailGondermeDate"].Visible = false;
            DtgProjeDirTeklifGir.Columns["AselsanMailAlmaDate"].Visible = false;
            DtgProjeDirTeklifGir.Columns["OdemeMailGondermeDate"].Visible = false;
            DtgProjeDirTeklifGir.Columns["OdemeMailAlmaDate"].Visible = false;
            DtgProjeDirTeklifGir.Columns["DepoTeslimTarihi"].Visible = false;
            DtgProjeDirTeklifGir.Columns["DepoTeslimBilgisi"].HeaderText = "SÖKÜLEN CİHAZ TESLİM BİLGİSİ";
            DtgProjeDirTeklifGir.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIM";
            DtgProjeDirTeklifGir.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";

            LblTop.Text = DtgProjeDirTeklifGir.RowCount.ToString();
        }


        private void TxtBirim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void DtgProjeDirTeklifGir_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgProjeDirTeklifGir.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            satinAlinacakMalzemelers = new List<SatinAlinacakMalzemeler>();
            dosyaYolu = DtgProjeDirTeklifGir.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgProjeDirTeklifGir.CurrentRow.Cells["SiparisNo"].Value.ToString();
            satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
            CmbFirma.Text = DtgProjeDirTeklifGir.CurrentRow.Cells["Satbirim"].Value.ToString();
            faturafirma = DtgProjeDirTeklifGir.CurrentRow.Cells["Faturafirma"].Value.ToString();
            isAkisNo = DtgProjeDirTeklifGir.CurrentRow.Cells["Formno"].Value.ToString();
            satno = DtgProjeDirTeklifGir.CurrentRow.Cells["Satno"].Value.ConInt();
            FillMalzemeList();
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }
        void Temize1()
        {
            DtgMalzList.DataSource = null; CmbFirma.SelectedIndex = -1; CmbFirma1.SelectedIndex = -1; TxtBirim.Clear(); LblToplam.Text = "00";
            ChkTumuneUygula.Checked = false; webBrowser1.Navigate("");
        }
        void Temize2()
        {
            DtgMalzList7.DataSource = null; CmbFirma2.SelectedIndex = -1; CmbFirma3.SelectedIndex = -1; TxtBirim2.Clear(); LblTop14.Text = "00";
            ChkTumuneUygula2.Checked = false; webBrowser2.Navigate("");
        }

        private void DtgMalzList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            secim = DtgMalzList.CurrentRow.Cells["Secim"].Value.ConBool();
            if (secim == false)
            {
                return;
            }

            TxtBirim.Text = DtgMalzList.CurrentRow.Cells["BirimFiyat"].Value.ToString();
            miktar = DtgMalzList.CurrentRow.Cells["M1"].Value.ConInt();


        }
        string ToplamHesapla(int miktar, double birimFiyat)
        {
            double toplam;
            toplam = miktar * birimFiyat;
            return toplam.ToString();
        }

        private void TxtBirim_TextChanged(object sender, EventArgs e)
        {
            LblToplam.Text = ToplamHesapla(miktar, TxtBirim.Text.ConDouble());
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in DtgMalzList.Rows)
            {
                if (item.Cells["BirimFiyat"].Value.ConDouble() == 0)
                {
                    MessageBox.Show("İstenen malzemelerde Birim Fiyatı bilgisi doldurulmamış kayıt mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (item.Cells["ToplamFiyat"].Value.ConDouble() == 0)
                {
                    MessageBox.Show("İstenen malzemelerde Toplam Fiyat bilgisi doldurulmamış kayıt mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (item.Cells["Firma"].Value.ToString() == "")
                {
                    MessageBox.Show("İstenen malzemelerde Firma bilgisi doldurulmamış kayıt mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (siparisNo == "")
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (faturafirma != "BAŞARAN İLERİ TEKNOLOJİ")
                {
                    satDataGridview1Manager.TeklifDurum(siparisNo, dosyaYolu, "SAT ONAY ASELSAN");

                    satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Sat Onay Aselsan", "SAT ONAY ASELSAN");
                }
                else
                {
                    satDataGridview1Manager.TeklifDurum(siparisNo, dosyaYolu, "SAT ONAY BAŞARAN");

                    satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Sat Onay Başaran", "SAT ONAY BAŞARAN");
                }

                yapilanislem = "FİRMANIN FİYAT TEKLİFLERİ KAYDEDİLDİ.";

                foreach (DataGridViewRow item in DtgMalzList.Rows)
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(item.Cells["Stn1"].Value.ToString(), item.Cells["T1"].Value.ToString(), item.Cells["M1"].Value.ConInt(), item.Cells["B1"].Value.ToString(), item.Cells["BirimFiyat"].Value.ConDouble(),
                        item.Cells["ToplamFiyat"].Value.ConDouble(), item.Cells["Firma"].Value.ToString());

                    teklifiAlinanManager.Add(teklifAlinan, siparisNo);

                    abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), yapilanislem);

                }

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                siparisNo = "";
                Yenile();
                Temize1();
            }
        }



        private void DtgProjeDirTeklifGir_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgProjeDirTeklifGir.FilterString;
            LblTop.Text = DtgProjeDirTeklifGir.RowCount.ToString();
        }

        private void DtgProjeDirTeklifGir_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgProjeDirTeklifGir.SortString;
        }

        private void DtgAlimYapliacalSat_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Filter = DtgAlimYapliacalSat.FilterString;
            LblTop3.Text = DtgAlimYapliacalSat.RowCount.ToString();
        }

        private void DtgAlimYapliacalSat_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Sort = DtgAlimYapliacalSat.SortString;
        }

        private void DtgAlimYapliacalSat_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgAlimYapliacalSat.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dosyaYolu = DtgAlimYapliacalSat.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgAlimYapliacalSat.CurrentRow.Cells["SiparisNo"].Value.ToString();
            isAkisNo = DtgAlimYapliacalSat.CurrentRow.Cells["Formno"].Value.ToString();
            satno = DtgAlimYapliacalSat.CurrentRow.Cells["Satno"].Value.ConInt();
            faturafirma = DtgAlimYapliacalSat.CurrentRow.Cells["Faturafirma"].Value.ToString();
            FillMalzemeList2();
            try
            {
                webBrowser5.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void DtgMdlTeklifMail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgMdlTeklifMail.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            satinAlinacakMalzemelers = new List<SatinAlinacakMalzemeler>();
            dosyaYolu = DtgMdlTeklifMail.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgMdlTeklifMail.CurrentRow.Cells["SiparisNo"].Value.ToString();
            satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
            CmbFirma.Text = DtgMdlTeklifMail.CurrentRow.Cells["Satbirim"].Value.ToString();
            isAkisNo = DtgMdlTeklifMail.CurrentRow.Cells["Formno"].Value.ToString();
            satno = DtgMdlTeklifMail.CurrentRow.Cells["Satno"].Value.ConInt();
            FillMalzemeListMdl();
            try
            {
                webBrowser4.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }
        private void BtnMailOlusturMdlTeklif_Click(object sender, EventArgs e)
        {
            if (siparisNo == "")
            {
                MessageBox.Show("Lütfen öncelikle bir SAT seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dosyaYolu == null)
            {
                MessageBox.Show("Lütfen öncelikle teklif alınacak malzemeye ait olan ürün görselleri gibi dosyalarınızı ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmMail frmMail = new FrmMail();
            frmMail.mailbilgi = "Başaran Fiyat Teklifi";
            frmMail.infos = infos;
            frmMail.dosyaYolu = dosyaYolu;
            frmMail.siparisNo = siparisNo;
            frmMail.ShowDialog();
            mailKontrol = true;
        }

        private void BtnDosyaEkle6_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + isAkisNo;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser4.Navigate(dosyaYolu);
            }
        }

        private void BtnKaydet6_Click(object sender, EventArgs e)
        {
            if (siparisNo == "")
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (mailKontrol == false)
            {
                MessageBox.Show("Lütfen öncelikle mail gönderme işlemlerini tamamlayınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Kaydetmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Başaran Teklifi Bekliyor", "BAŞARAN TEKLİFİ BEKLİYOR");
                satDataGridview1Manager.TeklifDurum(siparisNo, dosyaYolu, "BAŞARAN TEKLİFİ BEKLİYOR");

                yapilanislem = "FİYAT TEKLİFİ İÇİN MÜDÜRLÜĞE ONAY MAİLİ GÖNDERİLDİ.";
                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);

                foreach (DataGridViewRow item in DtgMalzList6.Rows)
                {
                    abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), yapilanislem);
                }

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                siparisNo = "";
                DtgMalzList6.DataSource = null;
                webBrowser4.Navigate("");
                LblTop12.Text = "00";
                mailKontrol = true;
                satDatas6.Clear();
            }
        }

        private void DtgMdlTeklifMailBekleyen_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgMdlTeklifMailBekleyen.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            satinAlinacakMalzemelers = new List<SatinAlinacakMalzemeler>();
            dosyaYolu = DtgMdlTeklifMailBekleyen.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgMdlTeklifMailBekleyen.CurrentRow.Cells["SiparisNo"].Value.ToString();
            satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
            CmbFirma2.Text = DtgMdlTeklifMailBekleyen.CurrentRow.Cells["Satbirim"].Value.ToString();
            isAkisNo = DtgMdlTeklifMailBekleyen.CurrentRow.Cells["Formno"].Value.ToString();
            faturafirma = DtgMdlTeklifMailBekleyen.CurrentRow.Cells["Faturafirma"].Value.ToString();
            satno = DtgMdlTeklifMailBekleyen.CurrentRow.Cells["Satno"].Value.ConInt();
            FillMalzemeListMd2();
            try
            {
                webBrowser2.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (ChkTumuneUygula.Checked == true)
            {
                foreach (DataGridViewRow item in DtgMalzList.Rows)
                {
                    item.Cells["BirimFiyat"].Value = TxtBirim.Text;
                    item.Cells["ToplamFiyat"].Value = LblToplam.Text;
                    item.Cells["Firma"].Value = CmbFirma1.Text;
                }
            }
            else
            {
                DtgMalzList.CurrentRow.Cells["BirimFiyat"].Value = TxtBirim.Text;
                DtgMalzList.CurrentRow.Cells["ToplamFiyat"].Value = LblToplam.Text;
                DtgMalzList.CurrentRow.Cells["Firma"].Value = CmbFirma1.Text;
            }
            Toplamlar();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtBirim2_TextChanged(object sender, EventArgs e)
        {
            LblToplam2.Text = ToplamHesapla(miktar, TxtBirim2.Text.ConDouble());
        }

        private void DtgMalzList7_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            secim = DtgMalzList7.CurrentRow.Cells["Secim"].Value.ConBool();
            if (secim == false)
            {
                return;
            }

            TxtBirim2.Text = DtgMalzList7.CurrentRow.Cells["BirimFiyat"].Value.ToString();
            miktar = DtgMalzList7.CurrentRow.Cells["M1"].Value.ConInt();
        }

        private void BtnOnayla2_Click(object sender, EventArgs e)
        {
            if (ChkTumuneUygula2.Checked == true)
            {
                foreach (DataGridViewRow item in DtgMalzList7.Rows)
                {
                    item.Cells["BirimFiyat"].Value = TxtBirim2.Text;
                    item.Cells["ToplamFiyat"].Value = LblToplam2.Text;
                    item.Cells["Firma"].Value = CmbFirma3.Text;
                }
            }
            else
            {
                DtgMalzList7.CurrentRow.Cells["BirimFiyat"].Value = TxtBirim2.Text;
                DtgMalzList7.CurrentRow.Cells["ToplamFiyat"].Value = LblToplam2.Text;
                DtgMalzList7.CurrentRow.Cells["Firma"].Value = CmbFirma3.Text;
            }
            Toplamlar5();
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + isAkisNo;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);

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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser1.Navigate(dosyaYolu);
            }
        }

        private void BtnDosyaEkle7_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + isAkisNo;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser2.Navigate(dosyaYolu);
            }
        }

        private void BtnKaydet7_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in DtgMalzList7.Rows)
            {
                if (item.Cells["BirimFiyat"].Value.ConDouble() == 0)
                {
                    MessageBox.Show("İstenen malzemelerde Birim Fiyatı bilgisi doldurulmamış kayıt mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (item.Cells["ToplamFiyat"].Value.ConDouble() == 0)
                {
                    MessageBox.Show("İstenen malzemelerde Toplam Fiyat bilgisi doldurulmamış kayıt mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (item.Cells["Firma"].Value.ToString() == "")
                {
                    MessageBox.Show("İstenen malzemelerde Firma bilgisi doldurulmamış kayıt mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (siparisNo == "")
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (faturafirma != "BAŞARAN İLER TEKNOLOJİ")
                {
                    satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Sat Onay Aselsan", "SAT ONAY ASELSAN");
                    satDataGridview1Manager.TeklifDurum(siparisNo, dosyaYolu, "SAT ONAY ASELSAN");
                }
                else
                {
                    satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Sat Onay Başaran", "SAT ONAY BAŞARAN");
                    satDataGridview1Manager.TeklifDurum(siparisNo, dosyaYolu, "SAT ONAY BAŞARAN");
                }

                yapilanislem = "FİRMANIN FİYAT TEKLİFLERİ KAYDEDİLDİ.";

                foreach (DataGridViewRow item in DtgMalzList7.Rows)
                {
                    TeklifAlinan teklifAlinan = new TeklifAlinan(item.Cells["Stn1"].Value.ToString(), item.Cells["T1"].Value.ToString(), item.Cells["M1"].Value.ConInt(), item.Cells["B1"].Value.ToString(), item.Cells["BirimFiyat"].Value.ConDouble(),
                        item.Cells["ToplamFiyat"].Value.ConDouble(), item.Cells["Firma"].Value.ToString());

                    teklifiAlinanManager.Add(teklifAlinan, siparisNo);

                    abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), yapilanislem);
                }

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                siparisNo = "";
                Yenile();
                Temize2();
            }
        }

        private void BtnDosyaEkle2_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + isAkisNo;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser5.Navigate(dosyaYolu);
            }
        }

        private void DtgAlimYapliacalSatMdl_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgAlimYapliacalSatMdl.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dosyaYolu = DtgAlimYapliacalSatMdl.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgAlimYapliacalSatMdl.CurrentRow.Cells["SiparisNo"].Value.ToString();
            isAkisNo = DtgAlimYapliacalSatMdl.CurrentRow.Cells["Formno"].Value.ToString();
            satno = DtgAlimYapliacalSatMdl.CurrentRow.Cells["Satno"].Value.ConInt();
            faturafirma = DtgAlimYapliacalSatMdl.CurrentRow.Cells["Faturafirma"].Value.ToString();
            FillMalzemeList6();
            try
            {
                webBrowser6.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void BtnKaydet2_Click(object sender, EventArgs e)
        {
            if (siparisNo == "")
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Kaydetmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                satDataGridview1Manager.MalzemeGelisTarihiUpdate(siparisNo, DtgTeslimTarihi.Value);
                satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Fatura Bekleyen SAT", "FATURA BEKLEYEN SAT");

                yapilanislem = "MALZEMENİN FİZİKİ OLARAK ALIMI YAPILDI.";

                foreach (DataGridViewRow item in DtgMalzList2.Rows)
                {
                    abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), yapilanislem);
                }

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                DtgMalzList2.DataSource = null;
                webBrowser5.Navigate("");
                LblTop4.Text = "00";
                LblGenelTop2.Text = "00";
                siparisNo = "";
            }

        }

        private void BtnDosyaEkle8_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + isAkisNo;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser6.Navigate(dosyaYolu);
            }
        }

        private void BtnKaydet8_Click(object sender, EventArgs e)
        {
            if (siparisNo == "")
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Kaydetmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                satDataGridview1Manager.MalzemeGelisTarihiUpdate(siparisNo, DtgTeslimTarihi2.Value);
                satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Fatura Bekleyen SAT", "FATURA BEKLEYEN SAT");

                yapilanislem = "MALZEMENİN FİZİKİ OLARAK ALIMI YAPILDI.";

                foreach (DataGridViewRow item in DtgMalzList8.Rows)
                {
                    abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), yapilanislem);
                }

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                DtgMalzList8.DataSource = null;
                webBrowser6.Navigate("");
                LblTop17.Text = "00";
                LblGenelTop6.Text = "00";
                siparisNo = "";
            }
        }

        private void DtgFaturaBekleyenSatProje_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgFaturaBekleyenSatProje.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fiyatTeklifiAls = new List<FiyatTeklifiAl>();
            dosyaYolu = DtgFaturaBekleyenSatProje.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgFaturaBekleyenSatProje.CurrentRow.Cells["SiparisNo"].Value.ToString();
            //satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
            isAkisNo = DtgFaturaBekleyenSatProje.CurrentRow.Cells["Formno"].Value.ToString();
            satBirim = DtgFaturaBekleyenSatProje.CurrentRow.Cells["Satbirim"].Value.ToString();
            satno = DtgFaturaBekleyenSatProje.CurrentRow.Cells["Satno"].Value.ConInt();
            FillMalzemeList5();
            TxtFirma.Text = fiyatTeklifiAls[0].Firma1;
            toplamlar = 0;
            TxtFaturaTutar.Clear();

            foreach (FiyatTeklifiAl item in fiyatTeklifiAls)
            {
                toplamlar += item.Btf;
            }

            TxtFaturaTutar.Text = toplamlar.ToString();

            try
            {
                webBrowser10.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void DtgFaturaBekleyenSatMdl_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgFaturaBekleyenSatMdl.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fiyatTeklifiAls = new List<FiyatTeklifiAl>();
            dosyaYolu = DtgFaturaBekleyenSatMdl.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgFaturaBekleyenSatMdl.CurrentRow.Cells["SiparisNo"].Value.ToString();
            //satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
            isAkisNo = DtgFaturaBekleyenSatMdl.CurrentRow.Cells["Formno"].Value.ToString();
            satBirim = DtgFaturaBekleyenSatMdl.CurrentRow.Cells["Satbirim"].Value.ToString();
            satno = DtgFaturaBekleyenSatMdl.CurrentRow.Cells["Satno"].Value.ConInt();
            FillMalzemeList7();
            TxtFirma2.Text = fiyatTeklifiAls[0].Firma1;

            toplamlar = 0;
            TxtFaturaTutar.Clear();

            foreach (FiyatTeklifiAl item in fiyatTeklifiAls)
            {
                toplamlar += item.Btf;
            }

            TxtFaturaTutar2.Text = toplamlar.ToString();

            try
            {
                webBrowser9.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void BtnDosyaEkle3_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + isAkisNo;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser10.Navigate(dosyaYolu);
                dosyaKontrol = true;
            }
        }

        private void TxtFaturaTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
        int benzersizId = 0;
        
        private void DtgDepoMalzemeTeslim_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgDepoMalzemeTeslim.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fiyatTeklifiAls = new List<FiyatTeklifiAl>();
            dosyaYolu = DtgDepoMalzemeTeslim.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgDepoMalzemeTeslim.CurrentRow.Cells["SiparisNo"].Value.ToString();
            isAkisNo = DtgDepoMalzemeTeslim.CurrentRow.Cells["Formno"].Value.ToString();
            satBirim = DtgDepoMalzemeTeslim.CurrentRow.Cells["Satbirim"].Value.ToString();
            satno = DtgDepoMalzemeTeslim.CurrentRow.Cells["Satno"].Value.ConInt();
            odemebilgi = DtgDepoMalzemeTeslim.CurrentRow.Cells["OdemeMailAlmaDate"].Value.ConDate();
            abfformno = DtgDepoMalzemeTeslim.CurrentRow.Cells["Abfformno"].Value.ToString();
            satOlusturmaTuru = DtgDepoMalzemeTeslim.CurrentRow.Cells["SatOlusturmaTuru"].Value.ToString();
            CmbNereden.Text = satBirim;
            satId = DtgDepoMalzemeTeslim.CurrentRow.Cells["Id"].Value.ConInt();
            FillMalzemeList3();
            abfMalzemes = abfMalzemeManager.TeminGetList("SAT İŞLEMLERİNİ BEKLİYOR", abfformno.ConInt());
            CmbDepoBilgi.SelectedIndex = -1;
            CmbDepoNo.SelectedIndex = -1;
            TxtDepoAdres.Clear();
            try
            {
                webBrowser7.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }


        private void BtnKaydet9_Click(object sender, EventArgs e)
        {
            if (siparisNo == "")
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (dosyaKontrol == false)
            //{
            //    MessageBox.Show("Lütfen öncelikle faturayı ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (CmbBelgeTuru2.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Belge Türünü seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtBelgeNumarasi2.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Belge Numarasını yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbHarcamaYapan2.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Harcama Yapan Bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Kaydetmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Ödeme Bilgileri", "ÖDEME BİLGİ MAİL OLUŞTURMA");

                satDataGridview1Manager.SatDevamEdenFaturaTutariAdd(siparisNo, TxtFaturaTutar2.Text.ConDouble(), CmbHarcamaYapan2.Text, TxtFirma2.Text, CmbBelgeTuru2.Text, TxtBelgeNumarasi2.Text, DtBelgeTarihi2.Value);
                yapilanislem = "FATURA ALINARAK KAYIT YAPILDI.";

                foreach (DataGridViewRow item in DtgMalzList9.Rows)
                {
                    abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), yapilanislem);
                }

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                DtgMalzList9.DataSource = null;
                webBrowser9.Navigate("");
                LblTop19.Text = "00";
                LblGenelTop5.Text = "00";
                TxtFirma2.Clear();
                CmbBelgeTuru2.SelectedIndex = -1;
                TxtBelgeNumarasi2.Clear();
                CmbHarcamaYapan2.SelectedIndex = -1;
                TxtFaturaTutar2.Clear();
                siparisNo = "";
                dosyaKontrol = false;
            }
        }

        private void BtnDosyaEkle9_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + isAkisNo;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser9.Navigate(dosyaYolu);
                dosyaKontrol = true;
            }
        }

        private void BtnKaydet3_Click(object sender, EventArgs e)
        {
            if (siparisNo == "")
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (dosyaKontrol == false)
            //{
            //    MessageBox.Show("Lütfen öncelikle faturayı ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (CmbBelgeTuru.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Belge Türünü seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtBelgeNumarasi.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Belge Numarasını yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbHarcamaYapan.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Harcama Yapan Bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Kaydetmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Depo Malzeme Teslim", "DEPO MALZEME TESLİM");

                satDataGridview1Manager.SatDevamEdenFaturaTutariAdd(siparisNo, TxtFaturaTutar.Text.ConDouble(), CmbHarcamaYapan.Text, TxtFirma.Text, CmbBelgeTuru.Text, TxtBelgeNumarasi.Text, DtBelgeTarihi.Value);
                yapilanislem = "FATURA ALINARAK KAYIT YAPILDI.";

                foreach (DataGridViewRow item in DtgMalzList5.Rows)
                {
                    abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), yapilanislem);
                }

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                //FillAlimYapilacakSatDrkt();
                DtgMalzList5.DataSource = null;
                webBrowser10.Navigate("");
                LblTop5.Text = "00";
                LblGenelTop2.Text = "00";
                TxtFirma.Clear();
                CmbBelgeTuru.SelectedIndex = -1;
                TxtBelgeNumarasi.Clear();
                CmbHarcamaYapan.SelectedIndex = -1;
                TxtFaturaTutar.Clear();
                siparisNo = "";
                dosyaKontrol = false;
            }
        }

        private void DtgOdemeYapilacak_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgOdemeYapilacak.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fiyatTeklifiAls = new List<FiyatTeklifiAl>();
            dosyaYolu = DtgOdemeYapilacak.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgOdemeYapilacak.CurrentRow.Cells["SiparisNo"].Value.ToString();
            isAkisNo = DtgOdemeYapilacak.CurrentRow.Cells["Formno"].Value.ToString();
            satBirim = DtgOdemeYapilacak.CurrentRow.Cells["Satbirim"].Value.ToString();
            satno = DtgOdemeYapilacak.CurrentRow.Cells["Satno"].Value.ConInt();
            FillMalzemeList8();
            try
            {
                webBrowser3.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void CmbDepoBilgi_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CmbDepoBilgi.Text == "DEPO")
            {
                if (CmbDepoNo.Items.Count!=0)
                {
                    CmbDepoNo.DataSource = null;
                }
                CmbDepo();
                TxtDepoAdres.Clear();
            }
            if (CmbDepoBilgi.Text == "OFİS")
            {
                CmbDepoNo.DataSource = null;
                CmbDepoNo.Items.Clear();
                CmbDepoNo.Items.Add("OFİS");
                CmbDepoNo.SelectedIndex = 0;
                TxtDepoAdres.Text = "OFİS";
                CmbDepoNo.Text = "OFİS";
            }
            if (CmbDepoBilgi.Text == "DESTEK DEPO")
            {
                CmbDepoNo.DataSource = null;
                CmbDepoNo.Items.Clear();
                CmbDepoNo.Items.Add("DESTEK DEPO");
                CmbDepoNo.SelectedIndex = 0;
                TxtDepoAdres.Text = "DESTEK DEPO";
                CmbDepoNo.Text = "DESTEK DEPO";
            }
        }

        private void BtnDosyaEkle4_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + isAkisNo;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser7.Navigate(dosyaYolu);
            }
        }

        private void BtnDosyaEkle10_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + isAkisNo;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser3.Navigate(dosyaYolu);
            }
        }

        private void BtnKaydet10_Click(object sender, EventArgs e)
        {
            if (siparisNo == "")
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (mailKontrol == false)
            {
                MessageBox.Show("Lütfen öncelikle maili oluşturup gönderiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Kaydetmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                satDataGridview1Manager.OdemeMailGondermeTarihi(LblOdemeMailGonderme.Text.ConDate(), siparisNo);
                satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Ödeme Bilgileri Kayıt", "ÖDEME BEKLEYEN SAT");

                yapilanislem = "ÖDEME BİLGİLERİ İÇİN MAİL GÖNDERİLMİŞTİR.";
                foreach (DataGridViewRow item in DtgMalzList10.Rows)
                {
                    abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), yapilanislem);
                }

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                mailKontrol = false;
                DtgMalzList10.DataSource = null;
                webBrowser3.Navigate("");
                LblTop21.Text = "00";
                LblGenelTop7.Text = "00";
                siparisNo = "";
            }
        }

        private void BtnOdemeMail_Click(object sender, EventArgs e)
        {
            if (siparisNo == "")
            {
                MessageBox.Show("Lütfen öncelikle bir sat seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmMail frmMail = new FrmMail();
            frmMail.mailbilgi = "Başaran Ödeme";
            frmMail.siparisNo = siparisNo;
            frmMail.infos = infos;
            frmMail.dosyaYolu = dosyaYolu;
            frmMail.ShowDialog();
            mailKontrol = true;
        }


        private void BtnKaydet4_Click(object sender, EventArgs e)
        {
            if (siparisNo == "")
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbDepoBilgi.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Depo Bilgisi seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbDepoNo.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Depo No seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtDepoAdres.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Depo Adresi seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Kaydetmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (satBirim == "BSRN GN.MDL.SATIN ALMA")
                {
                    if (odemebilgi == "1900-01-01".ConDate())
                    {
                        satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Ödeme Bilgileri Kayıt", "ÖDEME BEKLEYEN SAT");
                    }
                    else
                    {
                        satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Sat Tamamlama", "SAT TAMAMLAMA");
                    }
                }
                else
                {
                    satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Sat Tamamlama", "SAT TAMAMLAMA");
                }
                
                if (depoStokId!=null)
                {
                    for (int i = 0; i < depoStokId.Count; i++)
                    {
                        abfMalzemeManager.TeminBilgisi(depoStokId[i].ConInt(), "SAT İŞLEMLERİ TAMAMLANDI", infos[1].ToString(), "SAT İŞLEMLERİ TAMAMLANDI");

                    }
                }

                if (satOlusturmaTuru == "BAŞARAN")
                {
                    List<MalzemeTalep> malzemeTaleps = new List<MalzemeTalep>();
                    malzemeTaleps = malzemeTalepManager.GetSatId(satId);
                    if (malzemeTaleps.Count != 0)
                    {
                        foreach (MalzemeTalep item in malzemeTaleps)
                        {
                            malzemeTalepManager.Update(item.Id, "TEDARİK EDİLDİ");
                        }
                    }
                    
                }

                satDataGridview1Manager.DepoTeslimTarihi(DepoTeslimTarihi.Text.ConDate(), siparisNo);

                yapilanislem = "MALZEME AKTARIM İŞLEMLERİ TAMAMLANMIŞTIR.";
                foreach (DataGridViewRow item in DtgMalzList3.Rows)
                {
                    abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), yapilanislem);
                }
                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                CmbNereden.SelectedIndex = -1;
                CmbDepoBilgi.SelectedIndex = -1;
                CmbDepoNo.SelectedIndex = -1;
                TxtDepoAdres.Clear();
                webBrowser7.Navigate("");
                siparisNo = "";
                LblTop7.Text = "0";
                DtgMalzList3.DataSource = null;
            }
        }


        private void DtgOdemeYapilan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgOdemeYapilan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fiyatTeklifiAls = new List<FiyatTeklifiAl>();
            dosyaYolu = DtgOdemeYapilan.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgOdemeYapilan.CurrentRow.Cells["SiparisNo"].Value.ToString();
            isAkisNo = DtgOdemeYapilan.CurrentRow.Cells["Formno"].Value.ToString();
            satBirim = DtgOdemeYapilan.CurrentRow.Cells["Satbirim"].Value.ToString();
            satno = DtgOdemeYapilan.CurrentRow.Cells["Satno"].Value.ConInt();
            depoTeslimTarihi = DtgOdemeYapilan.CurrentRow.Cells["DepoTeslimTarihi"].Value.ConDate();
            FillMalzemeList9();
            try
            {
                webBrowser11.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }


        private void CmbDepoNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
            if (start == false)
            {
                return;
            }
            depoStokId = new List<int>();
            if (CmbDepoBilgi.Text == "DEPO")
            {
                int id = CmbDepoNo.SelectedValue.ConInt();
                DepoKayit depoKayit = depoKayitManagercs.Get(id);
                if (depoKayit == null)
                {
                    TxtDepoAdres.Text = "";
                }
                else
                {
                    TxtDepoAdres.Text = depoKayit.DepoAdi;
                }
            }
            else
            {
                TxtDepoAdres.Text = "DESTEK DEPO";
            }
            
            if (CmbDepoNo.Text == "1150")
            {
                ArizaKayit arizaKayit = arizaKayitManager.Get(abfformno.ConInt());
                abfMalzemes = abfMalzemeManager.GetList(arizaKayit.Id);
                if (abfMalzemes.Count != 0)
                {
                    foreach (AbfMalzeme item in abfMalzemes)
                    {
                        foreach (DataGridViewRow item2 in DtgMalzList3.Rows)
                        {
                            if (item.SokulenStokNo == item2.Cells["Stokno"].Value.ToString())
                            {
                                depoStokId.Add(item.Id);
                            }

                        }
                    }
                    if (depoStokId.Count != 0)
                    {
                        LblMalzemeTalebi.Text = "Malzeme Talepleri Bulundu!";
                        LblMalzemeTalebi.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        LblMalzemeTalebi.Text = "Malzeme Talepleri Bulunamadı!";
                        LblMalzemeTalebi.BackColor = Color.Red;
                    }

                }
                else
                {
                    LblMalzemeTalebi.Text = "Malzeme Talepleri Bulunamadı!";
                    LblMalzemeTalebi.BackColor = Color.Red;
                }
            }
            else
            {
                LblMalzemeTalebi.Text = "Malzeme Talepleri Bulunamadı!";
                LblMalzemeTalebi.BackColor = Color.Red;
            }
        }
        DateTime odemeMailGondermeTarihi, odemeMailTarihi, aselsanMailGondermeTarihi, aselsanMailTarihi; string butceTanimi, maliyetTuru, butceGiderTuru;
        private void DtgSatTamamla_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgSatTamamla.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            id = DtgSatTamamla.CurrentRow.Cells["Id"].Value.ConInt();
            dosyaYolu = DtgSatTamamla.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgSatTamamla.CurrentRow.Cells["SiparisNo"].Value.ToString();
            isAkisNo = DtgSatTamamla.CurrentRow.Cells["Formno"].Value.ToString();
            satBirim = DtgSatTamamla.CurrentRow.Cells["Satbirim"].Value.ToString();
            satno = DtgSatTamamla.CurrentRow.Cells["Satno"].Value.ConInt();
            formno = DtgSatTamamla.CurrentRow.Cells["Formno"].Value.ConInt();
            masrafyeri = DtgSatTamamla.CurrentRow.Cells["Masrafyeri"].Value.ToString();
            talepeden = DtgSatTamamla.CurrentRow.Cells["Talepeden"].Value.ToString();
            bolum = DtgSatTamamla.CurrentRow.Cells["Bolum"].Value.ToString();
            usbolgesi = DtgSatTamamla.CurrentRow.Cells["Usbolgesi"].Value.ToString();
            abfformno = DtgSatTamamla.CurrentRow.Cells["Abfformno"].Value.ToString();
            istenentarih = DtgSatTamamla.CurrentRow.Cells["Tarih"].Value.ConDate();
            gerekce = DtgSatTamamla.CurrentRow.Cells["Gerekce"].Value.ToString();
            butcekodukalemi = DtgSatTamamla.CurrentRow.Cells["Burcekodu"].Value.ToString();
            harcamaturu = DtgSatTamamla.CurrentRow.Cells["Harcamaturu"].Value.ToString();
            belgeTuru = DtgSatTamamla.CurrentRow.Cells["BelgeTuru"].Value.ToString();
            belgeNumarasi = DtgSatTamamla.CurrentRow.Cells["BelgeNumarasi"].Value.ToString();
            belgeTarihi = DtgSatTamamla.CurrentRow.Cells["BelgeTarihi"].Value.ConDate();
            faturafirma = DtgSatTamamla.CurrentRow.Cells["Faturafirma"].Value.ToString();
            ilgilikisi = DtgSatTamamla.CurrentRow.Cells["Ilgilikisi"].Value.ToString();
            masrafyerino = DtgSatTamamla.CurrentRow.Cells["Masyerino"].Value.ToString();
            donem = DtgSatTamamla.CurrentRow.Cells["Donem"].Value.ToString();
            satOlusturmaTuru = DtgSatTamamla.CurrentRow.Cells["SatOlusturmaTuru"].Value.ToString();
            proje = DtgSatTamamla.CurrentRow.Cells["Proje"].Value.ToString();

            fiyatTeklifiAls = new List<FiyatTeklifiAl>();
            FillMalzemeList4();

            satinAlinanFirma = fiyatTeklifiAls[0].Firma1.ToString();

            mlzTeslimTarihi = DtgSatTamamla.CurrentRow.Cells["MlzTeslimAldTarih"].Value.ToString();
            harcamayapan = DtgSatTamamla.CurrentRow.Cells["HarcamaYapan"].Value.ToString();
            depoTeslimBilgisi = DtgSatTamamla.CurrentRow.Cells["DepoTeslimBilgisi"].Value.ToString();
            odemeMailGondermeTarihi = DtgSatTamamla.CurrentRow.Cells["OdemeMailGondermeDate"].Value.ConDate();
            odemeMailTarihi = DtgSatTamamla.CurrentRow.Cells["OdemeMailAlmaDate"].Value.ConDate();
            aselsanMailGondermeTarihi = DtgSatTamamla.CurrentRow.Cells["AselsanMailGondermeDate"].Value.ConDate();
            aselsanMailTarihi = DtgSatTamamla.CurrentRow.Cells["AselsanMailAlmaDate"].Value.ConDate();
            depoTeslimTarihi = DtgSatTamamla.CurrentRow.Cells["DepoTeslimTarihi"].Value.ConDate();
            butceTanimi = DtgSatTamamla.CurrentRow.Cells["ButceTanimi"].Value.ToString();
            maliyetTuru = DtgSatTamamla.CurrentRow.Cells["MaliyetTuru"].Value.ToString();
            butceGiderTuru = DtgSatTamamla.CurrentRow.Cells["ButceGiderTuru"].Value.ToString();

            toplamlar = 0;
            foreach (FiyatTeklifiAl item in fiyatTeklifiAls)
            {
                toplamlar += item.Btf;
            }

            try
            {
                webBrowser13.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void BtnDosyaEkle11_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + isAkisNo;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser11.Navigate(dosyaYolu);
                dosyaKontrol = true;
            }
        }

        private void BtnKaydet11_Click(object sender, EventArgs e)
        {
            if (siparisNo == "")
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (dosyaKontrol == false)
            //{
            //    MessageBox.Show("Lütfen öncelikle ödeme mailini ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Kaydetmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Depo Malzeme Teslim", "DEPO MALZEME TESLİM");

                //if (depoTeslimTarihi == "1900-01-01".ConDate())
                //{
                //    satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Ödeme Bilgileri Kayıt", "DEPO MALZEME TESLİM");
                //}
                //else
                //{
                //    satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Sat Tamamlama", "SAT TAMAMLAMA");
                //}

                satDataGridview1Manager.OdemeMailTarihi(siparisNo, DtgMailTarihi.Value);


                yapilanislem = "ÖDEME BİLGİLERİNİN YAPILDIĞINA DAİR MAİL EKLENMİŞTİR.";
                foreach (DataGridViewRow item in DtgMalzList11.Rows)
                {
                    abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), yapilanislem);
                }
                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                dosyaKontrol = false;
                DtgMalzList11.DataSource = null;
                webBrowser11.Navigate("");
                LblTop23.Text = "00";
                LblGenelTop8.Text = "00";
                siparisNo = "";
            }

        }

        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMalzList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzList.Rows[i].Cells["ToplamFiyat"].Value);

            }
            LblGenelTop.Text = toplam.ToString("C2");
        }

        private void DtgAselsanOnayIste_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgAselsanOnayIste.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fiyatTeklifiAls = new List<FiyatTeklifiAl>();
            dosyaYolu = DtgAselsanOnayIste.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgAselsanOnayIste.CurrentRow.Cells["SiparisNo"].Value.ToString();
            isAkisNo = DtgAselsanOnayIste.CurrentRow.Cells["Formno"].Value.ToString();
            satBirim = DtgAselsanOnayIste.CurrentRow.Cells["Satbirim"].Value.ToString();
            satno = DtgAselsanOnayIste.CurrentRow.Cells["Satno"].Value.ConInt();
            FillMalzemeList10();
            try
            {
                webBrowser8.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        void Toplamlar5()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMalzList7.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzList7.Rows[i].Cells["ToplamFiyat"].Value);

            }
            LblGenelTop2.Text = toplam.ToString("C2");
        }

        void FillMalzemeList()
        {
            DtgMalzList.DataSource = satinAlinacakMalzemelers;

            DtgMalzList.Columns["Id"].Visible = false;
            DtgMalzList.Columns["Stn1"].HeaderText = "STOK NO";
            DtgMalzList.Columns["T1"].HeaderText = "TANIM";
            DtgMalzList.Columns["M1"].HeaderText = "MİKTAR";
            DtgMalzList.Columns["B1"].HeaderText = "BİRİM";
            DtgMalzList.Columns["BirimFiyat"].HeaderText = "BİRİM FİYATI";
            DtgMalzList.Columns["ToplamFiyat"].HeaderText = "TOPLAM FİYAT";
            DtgMalzList.Columns["Firma"].HeaderText = "FİRMA ADI";
            DtgMalzList.Columns["SiparisNo"].Visible = false;
            DtgMalzList.Columns["Secim"].HeaderText = "SEÇİM";

            LblTop2.Text = DtgMalzList.RowCount.ToString();
        }

        private void BtnDosyaEkle12_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + isAkisNo;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser8.Navigate(dosyaYolu);
            }
        }

        private void BtnKaydet12_Click(object sender, EventArgs e)
        {
            if (mailKontrol == false)
            {
                MessageBox.Show("Lütfen öncelikle mail gönderme işlemini gerçekleştiriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (siparisNo == "")
            {
                if (mailKontrol == false)
                {
                    MessageBox.Show("Lütfen öncelikle bir SAT seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Kaydetmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                satDataGridview1Manager.AselsanMailGondermeTarihi(LblMailTarihi.Text.ConDate(), siparisNo);
                satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Aselsan Onay Bekleyen", "ASELSAN ONAYI");

                yapilanislem = "ASELSAN ONAYI İÇİN MAİL OLUŞTURULDU.";


                foreach (DataGridViewRow item in DtgMalzList12.Rows)
                {
                    abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), yapilanislem);
                }

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                DtgMalzList12.DataSource = null;
                webBrowser8.Navigate("");
                LblTop25.Text = "00";
                LblGenelTop9.Text = "00";
                siparisNo = "";
            }

        }

        private void BtnAselsanMailOlustur_Click(object sender, EventArgs e)
        {
            if (siparisNo == "")
            {
                MessageBox.Show("Lütfen öncelikle bir sat seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmMail frmMail = new FrmMail();
            frmMail.mailbilgi = "Aselsan Onay Mail";
            frmMail.siparisNo = siparisNo;
            frmMail.infos = infos;
            frmMail.dosyaYolu = dosyaYolu;
            frmMail.ShowDialog();
            mailKontrol = true;
        }
        int satId = 0;
        private void DtgAselsanOnay_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgAselsanOnay.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fiyatTeklifiAls = new List<FiyatTeklifiAl>();
            dosyaYolu = DtgAselsanOnay.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgAselsanOnay.CurrentRow.Cells["SiparisNo"].Value.ToString();
            isAkisNo = DtgAselsanOnay.CurrentRow.Cells["Formno"].Value.ToString();
            satBirim = DtgAselsanOnay.CurrentRow.Cells["Satbirim"].Value.ToString();
            satno = DtgAselsanOnay.CurrentRow.Cells["Satno"].Value.ConInt();
            satId = DtgAselsanOnay.CurrentRow.Cells["Id"].Value.ConInt();
            FillMalzemeList11();
            try
            {
                webBrowser12.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        void FillMalzemeListMdl()
        {
            DtgMalzList6.DataSource = satinAlinacakMalzemelers;

            DtgMalzList6.Columns["Id"].Visible = false;
            DtgMalzList6.Columns["Stn1"].HeaderText = "STOK NO";
            DtgMalzList6.Columns["T1"].HeaderText = "TANIM";
            DtgMalzList6.Columns["M1"].HeaderText = "MİKTAR";
            DtgMalzList6.Columns["B1"].HeaderText = "BİRİM";
            DtgMalzList6.Columns["BirimFiyat"].HeaderText = "BİRİM FİYATI";
            DtgMalzList6.Columns["ToplamFiyat"].HeaderText = "TOPLAM FİYAT";
            DtgMalzList6.Columns["Firma"].HeaderText = "FİRMA ADI";
            DtgMalzList6.Columns["SiparisNo"].Visible = false;
            DtgMalzList6.Columns["Secim"].Visible = false;

            LblTop12.Text = DtgMalzList6.RowCount.ToString();
        }
        void FillMalzemeListMd2()
        {
            DtgMalzList7.DataSource = satinAlinacakMalzemelers;

            DtgMalzList7.Columns["Id"].Visible = false;
            DtgMalzList7.Columns["Stn1"].HeaderText = "STOK NO";
            DtgMalzList7.Columns["T1"].HeaderText = "TANIM";
            DtgMalzList7.Columns["M1"].HeaderText = "MİKTAR";
            DtgMalzList7.Columns["B1"].HeaderText = "BİRİM";
            DtgMalzList7.Columns["BirimFiyat"].HeaderText = "BİRİM FİYATI";
            DtgMalzList7.Columns["ToplamFiyat"].HeaderText = "TOPLAM FİYAT";
            DtgMalzList7.Columns["Firma"].HeaderText = "FİRMA ADI";
            DtgMalzList7.Columns["SiparisNo"].Visible = false;
            DtgMalzList7.Columns["Secim"].HeaderText = "SEÇİM";

            LblTop14.Text = DtgMalzList7.RowCount.ToString();
        }

        private void BtnDosyaEkle13_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + isAkisNo;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser12.Navigate(dosyaYolu);
                dosyaKontrol = true;
            }
        }

        private void BtnKaydet13_Click(object sender, EventArgs e)
        {
            if (siparisNo == "")
            {
                if (mailKontrol == false)
                {
                    MessageBox.Show("Lütfen öncelikle bir SAT seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //if (dosyaKontrol == false)
            //{
            //    MessageBox.Show("Lütfen öncelikle gelen maili ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Kaydetmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                satDataGridview1Manager.AselsanMailAlmaTarihi(DtAselsanOnayMail.Value, siparisNo);
                satDataGridview1Manager.DurumGuncelleTamamlama(siparisNo, "Sat Onay Başaran", "SAT ONAY BAŞARAN");

                yapilanislem = "ASELSAN ONAYI MAİLİ EKLENDİ.";

                foreach (DataGridViewRow item in DtgMalzList13.Rows)
                {
                    abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), yapilanislem);
                }

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);
                GorevAtama();

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                DtgMalzList13.DataSource = null;
                webBrowser12.Navigate("");
                LblTop27.Text = "00";
                LblGenelTop10.Text = "00";
                siparisNo = "";
            }
        }
        string GorevAtama()
        {
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(satId, "SATIN ALMA", "RESUL GÜNEŞ", "SAT ONAYI", DateTime.Now, "", DateTime.Now.Date);
            string kontrol = gorevAtamaPersonelManager.Add(gorevAtamaPersonel);

            if (kontrol != "OK")
            {
                return kontrol;
            }
            return "OK";
        }

        void FillMalzemeList2()
        {
            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
            DtgMalzList2.DataSource = fiyatTeklifiAls;

            DtgMalzList2.Columns["Id"].Visible = false;
            DtgMalzList2.Columns["Stokno"].HeaderText = "STOK NO";
            DtgMalzList2.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzList2.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzList2.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzList2.Columns["Firma1"].HeaderText = "FİRMA ADI";
            DtgMalzList2.Columns["Firma2"].Visible = false;
            DtgMalzList2.Columns["Firma3"].Visible = false;
            DtgMalzList2.Columns["Siparisno"].Visible = false;
            DtgMalzList2.Columns["Teklifdurumu"].Visible = false;
            DtgMalzList2.Columns["Bbf"].HeaderText = "BİRİM FİYATI";
            DtgMalzList2.Columns["Btf"].HeaderText = "TOPLAM FİYAT";
            DtgMalzList2.Columns["Ibf"].Visible = false;
            DtgMalzList2.Columns["Itf"].Visible = false;
            DtgMalzList2.Columns["Ubf"].Visible = false;
            DtgMalzList2.Columns["Utf"].Visible = false;
            DtgMalzList2.Columns["Onaylananteklif"].Visible = false;

            LblTop4.Text = DtgMalzList2.RowCount.ToString();
            Toplamlar2();

        }
        void FillMalzemeList6()
        {
            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
            DtgMalzList8.DataSource = fiyatTeklifiAls;

            DtgMalzList8.Columns["Id"].Visible = false;
            DtgMalzList8.Columns["Stokno"].HeaderText = "STOK NO";
            DtgMalzList8.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzList8.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzList8.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzList8.Columns["Firma1"].HeaderText = "FİRMA ADI";
            DtgMalzList8.Columns["Firma2"].Visible = false;
            DtgMalzList8.Columns["Firma3"].Visible = false;
            DtgMalzList8.Columns["Siparisno"].Visible = false;
            DtgMalzList8.Columns["Teklifdurumu"].Visible = false;
            DtgMalzList8.Columns["Bbf"].HeaderText = "BİRİM FİYATI";
            DtgMalzList8.Columns["Btf"].HeaderText = "TOPLAM FİYAT";
            DtgMalzList8.Columns["Ibf"].Visible = false;
            DtgMalzList8.Columns["Itf"].Visible = false;
            DtgMalzList8.Columns["Ubf"].Visible = false;
            DtgMalzList8.Columns["Utf"].Visible = false;
            DtgMalzList8.Columns["Onaylananteklif"].Visible = false;

            LblTop17.Text = DtgMalzList8.RowCount.ToString();

            Toplamlar7();

        }
        void FillMalzemeList3()
        {
            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
            DtgMalzList3.DataSource = fiyatTeklifiAls;

            DtgMalzList3.Columns["Id"].Visible = false;
            DtgMalzList3.Columns["Stokno"].HeaderText = "STOK NO";
            DtgMalzList3.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzList3.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzList3.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzList3.Columns["Firma1"].HeaderText = "FİRMA ADI";
            DtgMalzList3.Columns["Firma2"].Visible = false;
            DtgMalzList3.Columns["Firma3"].Visible = false;
            DtgMalzList3.Columns["Siparisno"].Visible = false;
            DtgMalzList3.Columns["Teklifdurumu"].Visible = false;
            DtgMalzList3.Columns["Bbf"].HeaderText = "BİRİM FİYATI";
            DtgMalzList3.Columns["Btf"].HeaderText = "TOPLAM FİYAT";
            DtgMalzList3.Columns["Ibf"].Visible = false;
            DtgMalzList3.Columns["Itf"].Visible = false;
            DtgMalzList3.Columns["Ubf"].Visible = false;
            DtgMalzList3.Columns["Utf"].Visible = false;
            DtgMalzList3.Columns["Onaylananteklif"].Visible = false;

            LblTop7.Text = DtgMalzList3.RowCount.ToString();

        }
        void FillMalzemeList8()
        {
            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
            DtgMalzList10.DataSource = fiyatTeklifiAls;

            DtgMalzList10.Columns["Id"].Visible = false;
            DtgMalzList10.Columns["Stokno"].HeaderText = "STOK NO";
            DtgMalzList10.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzList10.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzList10.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzList10.Columns["Firma1"].HeaderText = "FİRMA ADI";
            DtgMalzList10.Columns["Firma2"].Visible = false;
            DtgMalzList10.Columns["Firma3"].Visible = false;
            DtgMalzList10.Columns["Siparisno"].Visible = false;
            DtgMalzList10.Columns["Teklifdurumu"].Visible = false;
            DtgMalzList10.Columns["Bbf"].HeaderText = "BİRİM FİYATI";
            DtgMalzList10.Columns["Btf"].HeaderText = "TOPLAM FİYAT";
            DtgMalzList10.Columns["Ibf"].Visible = false;
            DtgMalzList10.Columns["Itf"].Visible = false;
            DtgMalzList10.Columns["Ubf"].Visible = false;
            DtgMalzList10.Columns["Utf"].Visible = false;
            DtgMalzList10.Columns["Onaylananteklif"].Visible = false;

            LblTop21.Text = DtgMalzList10.RowCount.ToString();
            Toplamlar8();
        }
        void FillMalzemeList10()
        {
            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
            DtgMalzList12.DataSource = fiyatTeklifiAls;

            DtgMalzList12.Columns["Id"].Visible = false;
            DtgMalzList12.Columns["Stokno"].HeaderText = "STOK NO";
            DtgMalzList12.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzList12.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzList12.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzList12.Columns["Firma1"].HeaderText = "FİRMA ADI";
            DtgMalzList12.Columns["Firma2"].Visible = false;
            DtgMalzList12.Columns["Firma3"].Visible = false;
            DtgMalzList12.Columns["Siparisno"].Visible = false;
            DtgMalzList12.Columns["Teklifdurumu"].Visible = false;
            DtgMalzList12.Columns["Bbf"].HeaderText = "BİRİM FİYATI";
            DtgMalzList12.Columns["Btf"].HeaderText = "TOPLAM FİYAT";
            DtgMalzList12.Columns["Ibf"].Visible = false;
            DtgMalzList12.Columns["Itf"].Visible = false;
            DtgMalzList12.Columns["Ubf"].Visible = false;
            DtgMalzList12.Columns["Utf"].Visible = false;
            DtgMalzList12.Columns["Onaylananteklif"].Visible = false;

            LblTop25.Text = DtgMalzList12.RowCount.ToString();
            Toplamlar10();
        }
        void FillMalzemeList11()
        {
            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
            DtgMalzList13.DataSource = fiyatTeklifiAls;

            DtgMalzList13.Columns["Id"].Visible = false;
            DtgMalzList13.Columns["Stokno"].HeaderText = "STOK NO";
            DtgMalzList13.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzList13.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzList13.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzList13.Columns["Firma1"].HeaderText = "FİRMA ADI";
            DtgMalzList13.Columns["Firma2"].Visible = false;
            DtgMalzList13.Columns["Firma3"].Visible = false;
            DtgMalzList13.Columns["Siparisno"].Visible = false;
            DtgMalzList13.Columns["Teklifdurumu"].Visible = false;
            DtgMalzList13.Columns["Bbf"].HeaderText = "BİRİM FİYATI";
            DtgMalzList13.Columns["Btf"].HeaderText = "TOPLAM FİYAT";
            DtgMalzList13.Columns["Ibf"].Visible = false;
            DtgMalzList13.Columns["Itf"].Visible = false;
            DtgMalzList13.Columns["Ubf"].Visible = false;
            DtgMalzList13.Columns["Utf"].Visible = false;
            DtgMalzList13.Columns["Onaylananteklif"].Visible = false;

            LblTop27.Text = DtgMalzList13.RowCount.ToString();
            Toplamlar11();
        }
        void FillMalzemeList9()
        {
            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
            DtgMalzList11.DataSource = fiyatTeklifiAls;

            DtgMalzList11.Columns["Id"].Visible = false;
            DtgMalzList11.Columns["Stokno"].HeaderText = "STOK NO";
            DtgMalzList11.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzList11.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzList11.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzList11.Columns["Firma1"].HeaderText = "FİRMA ADI";
            DtgMalzList11.Columns["Firma2"].Visible = false;
            DtgMalzList11.Columns["Firma3"].Visible = false;
            DtgMalzList11.Columns["Siparisno"].Visible = false;
            DtgMalzList11.Columns["Teklifdurumu"].Visible = false;
            DtgMalzList11.Columns["Bbf"].HeaderText = "BİRİM FİYATI";
            DtgMalzList11.Columns["Btf"].HeaderText = "TOPLAM FİYAT";
            DtgMalzList11.Columns["Ibf"].Visible = false;
            DtgMalzList11.Columns["Itf"].Visible = false;
            DtgMalzList11.Columns["Ubf"].Visible = false;
            DtgMalzList11.Columns["Utf"].Visible = false;
            DtgMalzList11.Columns["Onaylananteklif"].Visible = false;

            LblTop23.Text = DtgMalzList11.RowCount.ToString();
            Toplamlar9();
        }

        private void BtnDosyaEkle5_Click(object sender, EventArgs e)
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }

            dosyaYolu = subdir + isAkisNo;

            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser13.Navigate(dosyaYolu);
            }
        }


        private void BtnKayde5_Click(object sender, EventArgs e)
        {
            if (siparisNo == "")
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ChkSatTamamla.Checked == false)
            {
                MessageBox.Show("Lütfen öncelikle Sat Kontrol Onayını İşaretleyerek Satı tamamlayınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (depoTeslimBilgisi != "TESLIM ALINDI")
            //{
            //    MessageBox.Show("Malzeme ilgili depo tarafından henüz teslim alınmamıştır.\nLütfen öncelikle deponun, teslim alma işlemlerinin, tamamlanmasını sağlayınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            DialogResult dr = MessageBox.Show(satno + " Nolu SAT işlemini Kaydetmek istediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                
                string usBolgesiProje = bolgeKayitManager.BolgeProjeList(usbolgesi);
                string garantiDurumu = bolgeKayitManager.BolgeGarantiDurumList(usbolgesi);

                if (satinAlinanFirma=="-")
                {
                    MessageBox.Show("Satın alınan firma bilgisini bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //donem = DateTime.Now.ConPeriod();

                Tamamlanan tamamlanan = new Tamamlanan(satno.ToString(), formno, masrafyeri, talepeden, bolum, usbolgesi, abfformno, istenentarih, DateTime.Now, gerekce, butcekodukalemi, satBirim, harcamaturu, belgeTuru, belgeNumarasi, belgeTarihi,
                    faturafirma, ilgilikisi, masrafyerino, toplamlar, dosyaYolu, siparisNo, 0, "TAMAMLANAN SATLAR", donem, satOlusturmaTuru, proje, satinAlinanFirma, harcamayapan, usBolgesiProje, garantiDurumu, mlzTeslimTarihi, odemeMailGondermeTarihi, odemeMailTarihi, aselsanMailGondermeTarihi, aselsanMailTarihi, depoTeslimTarihi, butceTanimi, maliyetTuru, "", "", butceGiderTuru);
                string control = tamamlananManager.Add(tamamlanan);
                if (control != "OK")
                {
                    MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (FiyatTeklifiAl item in fiyatTeklifiAls)
                {
                    TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme(item.Stokno, item.Tanim, item.Miktar, item.Birim, item.Firma1, item.Bbf,
                    item.Btf, siparisNo);

                    string mesaj = tamamlananMalzemeManager.Add(tamamlananMalzeme);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                satDataGridview1Manager.Delete(id);
                satinAlinacakMalManager.Delete(siparisNo);

                yapilanislem = "SAT İŞLEMİ TAMAMLANDI.";
                foreach (DataGridViewRow item in DtgMalzList4.Rows)
                {
                    abfMalzemeManager.TeminBilgisi(item.Cells["Id"].Value.ConInt(), "SAT İŞLEMLERİNİ BEKLİYOR", infos[1].ToString(), yapilanislem);
                }
                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, infos[1].ToString(), DateTime.Now);
                satIslemAdimlarimanager.Add(satIslemAdimlari);

                MessageBox.Show(satno + " Numaralı SAT İşlemi Başarıyla Tamamlanmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Yenile();
                ChkSatTamamla.Checked = false;
                LblTop9.Text = "0";
                LblGenelTop3.Text = "0";
                webBrowser13.Navigate("");
                siparisNo = "";
                DtgMalzList4.DataSource = null;
            }
        }

        void FillMalzemeList4()
        {
            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
            DtgMalzList4.DataSource = fiyatTeklifiAls;

            DtgMalzList4.Columns["Id"].Visible = false;
            DtgMalzList4.Columns["Stokno"].HeaderText = "STOK NO";
            DtgMalzList4.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzList4.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzList4.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzList4.Columns["Firma1"].HeaderText = "FİRMA ADI";
            DtgMalzList4.Columns["Firma2"].Visible = false;
            DtgMalzList4.Columns["Firma3"].Visible = false;
            DtgMalzList4.Columns["Siparisno"].Visible = false;
            DtgMalzList4.Columns["Teklifdurumu"].Visible = false;
            DtgMalzList4.Columns["Bbf"].HeaderText = "BİRİM FİYATI";
            DtgMalzList4.Columns["Btf"].HeaderText = "TOPLAM FİYAT";
            DtgMalzList4.Columns["Ibf"].Visible = false;
            DtgMalzList4.Columns["Itf"].Visible = false;
            DtgMalzList4.Columns["Ubf"].Visible = false;
            DtgMalzList4.Columns["Utf"].Visible = false;
            DtgMalzList4.Columns["Onaylananteklif"].Visible = false;

            LblTop9.Text = DtgMalzList4.RowCount.ToString();
            Toplamlar3();
        }
        void FillMalzemeList5()
        {
            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
            DtgMalzList5.DataSource = fiyatTeklifiAls;

            DtgMalzList5.Columns["Id"].Visible = false;
            DtgMalzList5.Columns["Stokno"].HeaderText = "STOK NO";
            DtgMalzList5.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzList5.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzList5.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzList5.Columns["Firma1"].HeaderText = "FİRMA ADI";
            DtgMalzList5.Columns["Firma2"].Visible = false;
            DtgMalzList5.Columns["Firma3"].Visible = false;
            DtgMalzList5.Columns["Siparisno"].Visible = false;
            DtgMalzList5.Columns["Teklifdurumu"].Visible = false;
            DtgMalzList5.Columns["Bbf"].HeaderText = "BİRİM FİYATI";
            DtgMalzList5.Columns["Btf"].HeaderText = "TOPLAM FİYAT";
            DtgMalzList5.Columns["Ibf"].Visible = false;
            DtgMalzList5.Columns["Itf"].Visible = false;
            DtgMalzList5.Columns["Ubf"].Visible = false;
            DtgMalzList5.Columns["Utf"].Visible = false;
            DtgMalzList5.Columns["Onaylananteklif"].Visible = false;

            LblTop10.Text = DtgMalzList5.RowCount.ToString();
            Toplamlar4();
        }
        void FillMalzemeList7()
        {
            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
            DtgMalzList9.DataSource = fiyatTeklifiAls;

            DtgMalzList9.Columns["Id"].Visible = false;
            DtgMalzList9.Columns["Stokno"].HeaderText = "STOK NO";
            DtgMalzList9.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzList9.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgMalzList9.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzList9.Columns["Firma1"].HeaderText = "FİRMA ADI";
            DtgMalzList9.Columns["Firma2"].Visible = false;
            DtgMalzList9.Columns["Firma3"].Visible = false;
            DtgMalzList9.Columns["Siparisno"].Visible = false;
            DtgMalzList9.Columns["Teklifdurumu"].Visible = false;
            DtgMalzList9.Columns["Bbf"].HeaderText = "BİRİM FİYATI";
            DtgMalzList9.Columns["Btf"].HeaderText = "TOPLAM FİYAT";
            DtgMalzList9.Columns["Ibf"].Visible = false;
            DtgMalzList9.Columns["Itf"].Visible = false;
            DtgMalzList9.Columns["Ubf"].Visible = false;
            DtgMalzList9.Columns["Utf"].Visible = false;
            DtgMalzList9.Columns["Onaylananteklif"].Visible = false;

            LblTop19.Text = DtgMalzList9.RowCount.ToString();
            Toplamlar6();
        }

        void Toplamlar2()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMalzList2.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzList2.Rows[i].Cells["Btf"].Value);

            }
            LblGenelTop2.Text = toplam.ToString("C2");
        }
        void Toplamlar3()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMalzList4.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzList4.Rows[i].Cells["Btf"].Value);

            }
            LblGenelTop3.Text = toplam.ToString("C2");
        }
        void Toplamlar4()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMalzList5.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzList5.Rows[i].Cells["Btf"].Value);

            }
            LblGenelTop4.Text = toplam.ToString("C2");
        }
        void Toplamlar6()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMalzList9.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzList9.Rows[i].Cells["Btf"].Value);

            }
            LblGenelTop5.Text = toplam.ToString("C2");
        }

        void Toplamlar7()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMalzList8.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzList8.Rows[i].Cells["Btf"].Value);

            }
            LblGenelTop6.Text = toplam.ToString("C2");
        }
        void Toplamlar8()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMalzList10.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzList10.Rows[i].Cells["Btf"].Value);

            }
            LblGenelTop7.Text = toplam.ToString("C2");
        }
        void Toplamlar10()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMalzList12.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzList12.Rows[i].Cells["Btf"].Value);

            }
            LblGenelTop9.Text = toplam.ToString("C2");
        }

        void Toplamlar11()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMalzList13.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzList13.Rows[i].Cells["Btf"].Value);

            }
            LblGenelTop10.Text = toplam.ToString("C2");
        }

        void Toplamlar9()
        {
            double toplam = 0;
            for (int i = 0; i < DtgMalzList11.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzList11.Rows[i].Cells["Btf"].Value);

            }
            LblGenelTop8.Text = toplam.ToString("C2");
        }

        void FillAlimYapilacakSatDrkt()
        {
            satDatas2 = satDataGridview1Manager.TekifDurumListele("Alındı", "Alım Yapılacak Direktörlük", 1, "BELIRLENMEDI", "PRJ.DİR.SATIN ALMA");
            dataBinder2.DataSource = satDatas2.ToDataTable();
            DtgAlimYapliacalSat.DataSource = dataBinder2;

            DtgAlimYapliacalSat.Columns["Id"].Visible = false;
            DtgAlimYapliacalSat.Columns["Satno"].HeaderText = "SAT NO";
            DtgAlimYapliacalSat.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgAlimYapliacalSat.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgAlimYapliacalSat.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgAlimYapliacalSat.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgAlimYapliacalSat.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgAlimYapliacalSat.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgAlimYapliacalSat.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgAlimYapliacalSat.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgAlimYapliacalSat.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgAlimYapliacalSat.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgAlimYapliacalSat.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgAlimYapliacalSat.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgAlimYapliacalSat.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgAlimYapliacalSat.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgAlimYapliacalSat.Columns["Uctekilf"].Visible = false;
            DtgAlimYapliacalSat.Columns["SiparisNo"].Visible = false;
            DtgAlimYapliacalSat.Columns["DosyaYolu"].Visible = false;
            DtgAlimYapliacalSat.Columns["PersonelId"].Visible = false;
            DtgAlimYapliacalSat.Columns["FirmaBilgisi"].Visible = false;
            DtgAlimYapliacalSat.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgAlimYapliacalSat.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgAlimYapliacalSat.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgAlimYapliacalSat.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgAlimYapliacalSat.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgAlimYapliacalSat.Columns["BelgeTuru"].Visible = false;
            DtgAlimYapliacalSat.Columns["BelgeNumarasi"].Visible = false;
            DtgAlimYapliacalSat.Columns["BelgeTarihi"].Visible = false;
            DtgAlimYapliacalSat.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgAlimYapliacalSat.Columns["SatOlusturmaTuru"].Visible = false;
            DtgAlimYapliacalSat.Columns["RedNedeni"].Visible = false;
            DtgAlimYapliacalSat.Columns["TeklifDurumu"].Visible = false;
            DtgAlimYapliacalSat.Columns["SatinAlinanFirma"].Visible = false;
            DtgAlimYapliacalSat.Columns["MailSiniri"].Visible = false;
            DtgAlimYapliacalSat.Columns["MailDurumu"].Visible = false;
            DtgAlimYapliacalSat.Columns["Durum"].Visible = false;
            DtgAlimYapliacalSat.Columns["Donem"].HeaderText = "DÖNEM";
            DtgAlimYapliacalSat.Columns["Proje"].HeaderText = "PROJE";
            DtgAlimYapliacalSat.Columns["Donem"].DisplayIndex = 3;
            DtgAlimYapliacalSat.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgAlimYapliacalSat.Columns["HarcamaYapan"].Visible = false;
            DtgAlimYapliacalSat.Columns["AselsanMailGondermeDate"].Visible = false;
            DtgAlimYapliacalSat.Columns["AselsanMailAlmaDate"].Visible = false;
            DtgAlimYapliacalSat.Columns["OdemeMailGondermeDate"].Visible = false;
            DtgAlimYapliacalSat.Columns["OdemeMailAlmaDate"].Visible = false;
            DtgAlimYapliacalSat.Columns["DepoTeslimTarihi"].Visible = false;
            DtgAlimYapliacalSat.Columns["DepoTeslimBilgisi"].HeaderText = "SÖKÜLEN CİHAZ TESLİM BİLGİSİ";
            DtgAlimYapliacalSat.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIM";
            DtgAlimYapliacalSat.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";


            LblTop3.Text = DtgAlimYapliacalSat.RowCount.ToString();
        }

        void FillFaturaBekleyenSatDrkt()
        {
            satDatas3 = satDataGridview1Manager.TekifDurumListele("Alındı", "Fatura Bekleyen SAT", 1, "BELIRLENMEDI", "PRJ.DİR.SATIN ALMA");
            dataBinder3.DataSource = satDatas3.ToDataTable();
            DtgFaturaBekleyenSatProje.DataSource = dataBinder3;

            DtgFaturaBekleyenSatProje.Columns["Id"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["Satno"].HeaderText = "SAT NO";
            DtgFaturaBekleyenSatProje.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgFaturaBekleyenSatProje.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgFaturaBekleyenSatProje.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgFaturaBekleyenSatProje.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgFaturaBekleyenSatProje.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgFaturaBekleyenSatProje.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgFaturaBekleyenSatProje.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgFaturaBekleyenSatProje.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgFaturaBekleyenSatProje.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgFaturaBekleyenSatProje.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgFaturaBekleyenSatProje.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgFaturaBekleyenSatProje.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgFaturaBekleyenSatProje.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgFaturaBekleyenSatProje.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgFaturaBekleyenSatProje.Columns["Uctekilf"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["SiparisNo"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["DosyaYolu"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["PersonelId"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["FirmaBilgisi"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgFaturaBekleyenSatProje.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgFaturaBekleyenSatProje.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgFaturaBekleyenSatProje.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgFaturaBekleyenSatProje.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgFaturaBekleyenSatProje.Columns["BelgeTuru"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["BelgeNumarasi"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["BelgeTarihi"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgFaturaBekleyenSatProje.Columns["SatOlusturmaTuru"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["RedNedeni"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["TeklifDurumu"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["SatinAlinanFirma"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["MailSiniri"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["MailDurumu"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["Durum"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["Donem"].HeaderText = "DÖNEM";
            DtgFaturaBekleyenSatProje.Columns["Proje"].HeaderText = "PROJE";
            DtgFaturaBekleyenSatProje.Columns["Donem"].DisplayIndex = 3;
            DtgFaturaBekleyenSatProje.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["HarcamaYapan"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["AselsanMailGondermeDate"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["AselsanMailAlmaDate"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["OdemeMailGondermeDate"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["OdemeMailAlmaDate"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["DepoTeslimTarihi"].Visible = false;
            DtgFaturaBekleyenSatProje.Columns["DepoTeslimBilgisi"].HeaderText = "SÖKÜLEN CİHAZ TESLİM BİLGİSİ";
            DtgFaturaBekleyenSatProje.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIM";
            DtgFaturaBekleyenSatProje.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";

            LblTop5.Text = DtgFaturaBekleyenSatProje.RowCount.ToString();
        }
        void FillFaturaBekleyenSatMdl()
        {
            satDatas9 = satDataGridview1Manager.TekifDurumListele("Alındı", "Fatura Bekleyen SAT", 1, "BELIRLENMEDI", "BSRN GN.MDL.SATIN ALMA");
            dataBinder9.DataSource = satDatas9.ToDataTable();
            DtgFaturaBekleyenSatMdl.DataSource = dataBinder9;

            DtgFaturaBekleyenSatMdl.Columns["Id"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["Satno"].HeaderText = "SAT NO";
            DtgFaturaBekleyenSatMdl.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgFaturaBekleyenSatMdl.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgFaturaBekleyenSatMdl.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgFaturaBekleyenSatMdl.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgFaturaBekleyenSatMdl.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgFaturaBekleyenSatMdl.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgFaturaBekleyenSatMdl.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgFaturaBekleyenSatMdl.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgFaturaBekleyenSatMdl.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgFaturaBekleyenSatMdl.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgFaturaBekleyenSatMdl.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgFaturaBekleyenSatMdl.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgFaturaBekleyenSatMdl.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgFaturaBekleyenSatMdl.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgFaturaBekleyenSatMdl.Columns["Uctekilf"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["SiparisNo"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["DosyaYolu"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["PersonelId"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["FirmaBilgisi"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgFaturaBekleyenSatMdl.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgFaturaBekleyenSatMdl.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgFaturaBekleyenSatMdl.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgFaturaBekleyenSatMdl.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgFaturaBekleyenSatMdl.Columns["BelgeTuru"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["BelgeNumarasi"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["BelgeTarihi"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgFaturaBekleyenSatMdl.Columns["SatOlusturmaTuru"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["RedNedeni"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["TeklifDurumu"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["SatinAlinanFirma"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["MailSiniri"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["MailDurumu"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["Durum"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["Donem"].HeaderText = "DÖNEM";
            DtgFaturaBekleyenSatMdl.Columns["Proje"].HeaderText = "PROJE";
            DtgFaturaBekleyenSatMdl.Columns["Donem"].DisplayIndex = 3;
            DtgFaturaBekleyenSatMdl.Columns["MlzTeslimAldTarih"].HeaderText = "MALZEME TESLİM ALINMA TARİHİ";
            DtgFaturaBekleyenSatMdl.Columns["HarcamaYapan"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["AselsanMailGondermeDate"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["AselsanMailAlmaDate"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["OdemeMailGondermeDate"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["OdemeMailAlmaDate"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["DepoTeslimTarihi"].Visible = false;
            DtgFaturaBekleyenSatMdl.Columns["DepoTeslimBilgisi"].HeaderText = "SÖKÜLEN CİHAZ TESLİM BİLGİSİ";
            DtgFaturaBekleyenSatMdl.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIM";
            DtgFaturaBekleyenSatMdl.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";

            LblTop18.Text = DtgFaturaBekleyenSatMdl.RowCount.ToString();
        }
        void FillDepoMAlzemeTeslim()
        {
            satDatas4 = satDataGridview1Manager.TekifDurumListele("Alındı", "Depo Malzeme Teslim", 1, "BELIRLENMEDI");
            dataBinder4.DataSource = satDatas4.ToDataTable();
            DtgDepoMalzemeTeslim.DataSource = dataBinder4;

            DtgDepoMalzemeTeslim.Columns["Id"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["Satno"].HeaderText = "SAT NO";
            DtgDepoMalzemeTeslim.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgDepoMalzemeTeslim.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgDepoMalzemeTeslim.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgDepoMalzemeTeslim.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgDepoMalzemeTeslim.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgDepoMalzemeTeslim.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgDepoMalzemeTeslim.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgDepoMalzemeTeslim.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgDepoMalzemeTeslim.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgDepoMalzemeTeslim.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgDepoMalzemeTeslim.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgDepoMalzemeTeslim.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgDepoMalzemeTeslim.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgDepoMalzemeTeslim.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgDepoMalzemeTeslim.Columns["Uctekilf"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["SiparisNo"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["DosyaYolu"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["PersonelId"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["FirmaBilgisi"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgDepoMalzemeTeslim.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgDepoMalzemeTeslim.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgDepoMalzemeTeslim.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgDepoMalzemeTeslim.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgDepoMalzemeTeslim.Columns["BelgeTuru"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["BelgeNumarasi"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["BelgeTarihi"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgDepoMalzemeTeslim.Columns["SatOlusturmaTuru"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["RedNedeni"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["TeklifDurumu"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["SatinAlinanFirma"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["MailSiniri"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["MailDurumu"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["HarcamaYapan"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["Durum"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["Donem"].HeaderText = "DÖNEM";
            DtgDepoMalzemeTeslim.Columns["Proje"].HeaderText = "PROJE";
            DtgDepoMalzemeTeslim.Columns["Donem"].DisplayIndex = 3;
            DtgDepoMalzemeTeslim.Columns["MlzTeslimAldTarih"].HeaderText = "MALZEME TESLİM ALINMA TARİHİ";
            DtgDepoMalzemeTeslim.Columns["HarcamaYapan"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["AselsanMailGondermeDate"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["AselsanMailAlmaDate"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["OdemeMailGondermeDate"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["OdemeMailAlmaDate"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["DepoTeslimTarihi"].Visible = false;
            DtgDepoMalzemeTeslim.Columns["DepoTeslimBilgisi"].HeaderText = "SÖKÜLEN CİHAZ TESLİM BİLGİSİ";
            DtgDepoMalzemeTeslim.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIM";
            DtgDepoMalzemeTeslim.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";

            LblTop6.Text = DtgDepoMalzemeTeslim.RowCount.ToString();
        }
        void FillSatTamamlama()
        {
            satDatas5 = satDataGridview1Manager.TekifDurumListele("Alındı", "Sat Tamamlama", 1, "BELIRLENMEDI");
            dataBinder5.DataSource = satDatas5.ToDataTable();
            DtgSatTamamla.DataSource = dataBinder5;

            DtgSatTamamla.Columns["Id"].Visible = false;
            DtgSatTamamla.Columns["Satno"].HeaderText = "SAT NO";
            DtgSatTamamla.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgSatTamamla.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgSatTamamla.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgSatTamamla.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgSatTamamla.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgSatTamamla.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgSatTamamla.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgSatTamamla.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgSatTamamla.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgSatTamamla.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgSatTamamla.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgSatTamamla.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgSatTamamla.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgSatTamamla.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgSatTamamla.Columns["Uctekilf"].Visible = false;
            DtgSatTamamla.Columns["SiparisNo"].Visible = false;
            DtgSatTamamla.Columns["DosyaYolu"].Visible = false;
            DtgSatTamamla.Columns["PersonelId"].Visible = false;
            DtgSatTamamla.Columns["FirmaBilgisi"].Visible = false;
            DtgSatTamamla.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgSatTamamla.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgSatTamamla.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgSatTamamla.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgSatTamamla.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgSatTamamla.Columns["BelgeTuru"].Visible = false;
            DtgSatTamamla.Columns["BelgeNumarasi"].Visible = false;
            DtgSatTamamla.Columns["BelgeTarihi"].Visible = false;
            DtgSatTamamla.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgSatTamamla.Columns["SatOlusturmaTuru"].Visible = false;
            DtgSatTamamla.Columns["RedNedeni"].Visible = false;
            DtgSatTamamla.Columns["TeklifDurumu"].Visible = false;
            DtgSatTamamla.Columns["SatinAlinanFirma"].HeaderText = "SATIN ALINAN FİRMA";
            DtgSatTamamla.Columns["MailSiniri"].Visible = false;
            DtgSatTamamla.Columns["MailDurumu"].Visible = false;
            DtgSatTamamla.Columns["Durum"].Visible = false;
            DtgSatTamamla.Columns["Donem"].HeaderText = "DÖNEM";
            DtgSatTamamla.Columns["Proje"].HeaderText = "PROJE";
            DtgSatTamamla.Columns["Donem"].DisplayIndex = 3;
            DtgSatTamamla.Columns["AselsanMailGondermeDate"].HeaderText = "ASELSAN MAİL GÖNDERME TARİHİ";
            DtgSatTamamla.Columns["AselsanMailAlmaDate"].HeaderText = "ASELSAN MAİL ALMA TARİHİ";
            DtgSatTamamla.Columns["OdemeMailGondermeDate"].HeaderText = "ÖDEME MAİL GÖNDERME TARİHİ";
            DtgSatTamamla.Columns["OdemeMailAlmaDate"].HeaderText = "ÖDEME MAİL ALMA TARİHİ";
            DtgSatTamamla.Columns["MlzTeslimAldTarih"].HeaderText = "MALZEME TESLİM ALINMA TARİHİ";
            DtgSatTamamla.Columns["HarcamaYapan"].Visible = false;
            DtgSatTamamla.Columns["DepoTeslimTarihi"].HeaderText = "DEPO TESLİM TARİHİ";
            DtgSatTamamla.Columns["DepoTeslimBilgisi"].HeaderText = "SÖKÜLEN CİHAZ TESLİM BİLGİSİ";
            DtgSatTamamla.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIM";
            DtgSatTamamla.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";


            LblTop8.Text = DtgSatTamamla.RowCount.ToString();
        }

        void TeklifMailMdl()
        {
            satDatas6 = satDataGridview1Manager.TekifDurumListele("Alınmadı", "Onaylandı", 1, "BELIRLENMEDI", "BSRN GN.MDL.SATIN ALMA");
            dataBinder6.DataSource = satDatas6.ToDataTable();
            DtgMdlTeklifMail.DataSource = dataBinder6;

            DtgMdlTeklifMail.Columns["Id"].Visible = false;
            DtgMdlTeklifMail.Columns["Satno"].HeaderText = "SAT NO";
            DtgMdlTeklifMail.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgMdlTeklifMail.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgMdlTeklifMail.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgMdlTeklifMail.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgMdlTeklifMail.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgMdlTeklifMail.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgMdlTeklifMail.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgMdlTeklifMail.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgMdlTeklifMail.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgMdlTeklifMail.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgMdlTeklifMail.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgMdlTeklifMail.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgMdlTeklifMail.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgMdlTeklifMail.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgMdlTeklifMail.Columns["Uctekilf"].Visible = false;
            DtgMdlTeklifMail.Columns["SiparisNo"].Visible = false;
            DtgMdlTeklifMail.Columns["DosyaYolu"].Visible = false;
            DtgMdlTeklifMail.Columns["PersonelId"].Visible = false;
            DtgMdlTeklifMail.Columns["FirmaBilgisi"].Visible = false;
            DtgMdlTeklifMail.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgMdlTeklifMail.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgMdlTeklifMail.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgMdlTeklifMail.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgMdlTeklifMail.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgMdlTeklifMail.Columns["BelgeTuru"].Visible = false;
            DtgMdlTeklifMail.Columns["BelgeNumarasi"].Visible = false;
            DtgMdlTeklifMail.Columns["BelgeTarihi"].Visible = false;
            DtgMdlTeklifMail.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgMdlTeklifMail.Columns["SatOlusturmaTuru"].Visible = false;
            DtgMdlTeklifMail.Columns["RedNedeni"].Visible = false;
            DtgMdlTeklifMail.Columns["TeklifDurumu"].Visible = false;
            DtgMdlTeklifMail.Columns["SatinAlinanFirma"].Visible = false;
            DtgMdlTeklifMail.Columns["MailSiniri"].Visible = false;
            DtgMdlTeklifMail.Columns["MailDurumu"].Visible = false;
            DtgMdlTeklifMail.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgMdlTeklifMail.Columns["HarcamaYapan"].Visible = false;
            DtgMdlTeklifMail.Columns["Durum"].Visible = false;
            DtgMdlTeklifMail.Columns["Donem"].HeaderText = "DÖNEM";
            DtgMdlTeklifMail.Columns["Proje"].HeaderText = "PROJE";
            DtgMdlTeklifMail.Columns["Donem"].DisplayIndex = 3;
            DtgMdlTeklifMail.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgMdlTeklifMail.Columns["HarcamaYapan"].Visible = false;
            DtgMdlTeklifMail.Columns["AselsanMailGondermeDate"].Visible = false;
            DtgMdlTeklifMail.Columns["AselsanMailAlmaDate"].Visible = false;
            DtgMdlTeklifMail.Columns["OdemeMailGondermeDate"].Visible = false;
            DtgMdlTeklifMail.Columns["OdemeMailAlmaDate"].Visible = false;
            DtgMdlTeklifMail.Columns["DepoTeslimTarihi"].Visible = false;
            DtgMdlTeklifMail.Columns["DepoTeslimBilgisi"].HeaderText = "SÖKÜLEN CİHAZ TESLİM BİLGİSİ";
            DtgMdlTeklifMail.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIM";
            DtgMdlTeklifMail.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";

            LblTop11.Text = DtgMdlTeklifMail.RowCount.ToString();
        }
        void TeklifMailMdlKayit()
        {
            satDatas7 = satDataGridview1Manager.TekifDurumListele("Alındı", "Başaran Teklifi Bekliyor", 1, "BELIRLENMEDI", "BSRN GN.MDL.SATIN ALMA");
            dataBinder7.DataSource = satDatas7.ToDataTable();
            DtgMdlTeklifMailBekleyen.DataSource = dataBinder7;

            DtgMdlTeklifMailBekleyen.Columns["Id"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["Satno"].HeaderText = "SAT NO";
            DtgMdlTeklifMailBekleyen.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgMdlTeklifMailBekleyen.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgMdlTeklifMailBekleyen.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgMdlTeklifMailBekleyen.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgMdlTeklifMailBekleyen.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgMdlTeklifMailBekleyen.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgMdlTeklifMailBekleyen.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgMdlTeklifMailBekleyen.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgMdlTeklifMailBekleyen.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgMdlTeklifMailBekleyen.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgMdlTeklifMailBekleyen.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgMdlTeklifMailBekleyen.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgMdlTeklifMailBekleyen.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgMdlTeklifMailBekleyen.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgMdlTeklifMailBekleyen.Columns["Uctekilf"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["SiparisNo"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["DosyaYolu"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["PersonelId"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["FirmaBilgisi"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgMdlTeklifMailBekleyen.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgMdlTeklifMailBekleyen.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgMdlTeklifMailBekleyen.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgMdlTeklifMailBekleyen.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgMdlTeklifMailBekleyen.Columns["BelgeTuru"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["BelgeNumarasi"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["BelgeTarihi"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgMdlTeklifMailBekleyen.Columns["SatOlusturmaTuru"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["RedNedeni"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["TeklifDurumu"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["SatinAlinanFirma"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["MailSiniri"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["MailDurumu"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["HarcamaYapan"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["Durum"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["HarcamaYapan"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["Donem"].HeaderText = "DÖNEM";
            DtgMdlTeklifMailBekleyen.Columns["Proje"].HeaderText = "PROJE";
            DtgMdlTeklifMailBekleyen.Columns["Donem"].DisplayIndex = 3;
            DtgMdlTeklifMailBekleyen.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["HarcamaYapan"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["AselsanMailGondermeDate"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["AselsanMailAlmaDate"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["OdemeMailGondermeDate"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["OdemeMailAlmaDate"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["DepoTeslimTarihi"].Visible = false;
            DtgMdlTeklifMailBekleyen.Columns["DepoTeslimBilgisi"].HeaderText = "SÖKÜLEN CİHAZ TESLİM BİLGİSİ";
            DtgMdlTeklifMailBekleyen.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIM";
            DtgMdlTeklifMailBekleyen.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";

            LblTop13.Text = DtgMdlTeklifMailBekleyen.RowCount.ToString();
        }
        void FillAlimYapilacakSatMdl()
        {
            satDatas8 = satDataGridview1Manager.TekifDurumListele("Alındı", "Alım Yapılacak Müdürlük", 1, "BELIRLENMEDI", "BSRN GN.MDL.SATIN ALMA");
            dataBinder8.DataSource = satDatas8.ToDataTable();
            DtgAlimYapliacalSatMdl.DataSource = dataBinder8;

            DtgAlimYapliacalSatMdl.Columns["Id"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["Satno"].HeaderText = "SAT NO";
            DtgAlimYapliacalSatMdl.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgAlimYapliacalSatMdl.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgAlimYapliacalSatMdl.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgAlimYapliacalSatMdl.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgAlimYapliacalSatMdl.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgAlimYapliacalSatMdl.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgAlimYapliacalSatMdl.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgAlimYapliacalSatMdl.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgAlimYapliacalSatMdl.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgAlimYapliacalSatMdl.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgAlimYapliacalSatMdl.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgAlimYapliacalSatMdl.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgAlimYapliacalSatMdl.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgAlimYapliacalSatMdl.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgAlimYapliacalSatMdl.Columns["Uctekilf"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["SiparisNo"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["DosyaYolu"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["PersonelId"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["FirmaBilgisi"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgAlimYapliacalSatMdl.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgAlimYapliacalSatMdl.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgAlimYapliacalSatMdl.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgAlimYapliacalSatMdl.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgAlimYapliacalSatMdl.Columns["BelgeTuru"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["BelgeNumarasi"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["BelgeTarihi"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgAlimYapliacalSatMdl.Columns["SatOlusturmaTuru"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["RedNedeni"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["TeklifDurumu"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["SatinAlinanFirma"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["MailSiniri"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["MailDurumu"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["HarcamaYapan"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["Durum"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["Donem"].HeaderText = "DÖNEM";
            DtgAlimYapliacalSatMdl.Columns["Proje"].HeaderText = "PROJE";
            DtgAlimYapliacalSatMdl.Columns["Donem"].DisplayIndex = 3;
            DtgAlimYapliacalSatMdl.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["HarcamaYapan"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["AselsanMailGondermeDate"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["AselsanMailAlmaDate"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["OdemeMailGondermeDate"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["OdemeMailAlmaDate"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["DepoTeslimTarihi"].Visible = false;
            DtgAlimYapliacalSatMdl.Columns["DepoTeslimBilgisi"].HeaderText = "SÖKÜLEN CİHAZ TESLİM BİLGİSİ";
            DtgAlimYapliacalSatMdl.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIM";
            DtgAlimYapliacalSatMdl.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";

            LblTop16.Text = DtgAlimYapliacalSatMdl.RowCount.ToString();
        }
        void FillOdemeBilgileri()
        {
            satDatas10 = satDataGridview1Manager.TekifDurumListele("Alındı", "Ödeme Bilgileri", 1, "BELIRLENMEDI", "BSRN GN.MDL.SATIN ALMA");
            dataBinder10.DataSource = satDatas10.ToDataTable();
            DtgOdemeYapilacak.DataSource = dataBinder10;

            DtgOdemeYapilacak.Columns["Id"].Visible = false;
            DtgOdemeYapilacak.Columns["Satno"].HeaderText = "SAT NO";
            DtgOdemeYapilacak.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgOdemeYapilacak.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgOdemeYapilacak.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgOdemeYapilacak.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgOdemeYapilacak.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgOdemeYapilacak.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgOdemeYapilacak.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgOdemeYapilacak.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgOdemeYapilacak.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgOdemeYapilacak.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgOdemeYapilacak.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgOdemeYapilacak.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgOdemeYapilacak.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgOdemeYapilacak.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgOdemeYapilacak.Columns["Uctekilf"].Visible = false;
            DtgOdemeYapilacak.Columns["SiparisNo"].Visible = false;
            DtgOdemeYapilacak.Columns["DosyaYolu"].Visible = false;
            DtgOdemeYapilacak.Columns["PersonelId"].Visible = false;
            DtgOdemeYapilacak.Columns["FirmaBilgisi"].Visible = false;
            DtgOdemeYapilacak.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgOdemeYapilacak.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgOdemeYapilacak.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgOdemeYapilacak.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgOdemeYapilacak.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgOdemeYapilacak.Columns["BelgeTuru"].Visible = false;
            DtgOdemeYapilacak.Columns["BelgeNumarasi"].Visible = false;
            DtgOdemeYapilacak.Columns["BelgeTarihi"].Visible = false;
            DtgOdemeYapilacak.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgOdemeYapilacak.Columns["SatOlusturmaTuru"].Visible = false;
            DtgOdemeYapilacak.Columns["RedNedeni"].Visible = false;
            DtgOdemeYapilacak.Columns["TeklifDurumu"].Visible = false;
            DtgOdemeYapilacak.Columns["SatinAlinanFirma"].Visible = false;
            DtgOdemeYapilacak.Columns["MailSiniri"].Visible = false;
            DtgOdemeYapilacak.Columns["MailDurumu"].Visible = false;
            DtgOdemeYapilacak.Columns["MlzTeslimAldTarih"].HeaderText = "MALZEME TESLİM ALINMA TARİHİ";
            DtgOdemeYapilacak.Columns["HarcamaYapan"].HeaderText = "HARCAMA YAPAN";
            DtgOdemeYapilacak.Columns["Durum"].Visible = false;
            DtgOdemeYapilacak.Columns["Donem"].HeaderText = "DÖNEM";
            DtgOdemeYapilacak.Columns["Proje"].HeaderText = "PROJE";
            DtgOdemeYapilacak.Columns["Donem"].DisplayIndex = 3;
            DtgOdemeYapilacak.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgOdemeYapilacak.Columns["HarcamaYapan"].Visible = false;
            DtgOdemeYapilacak.Columns["AselsanMailGondermeDate"].Visible = false;
            DtgOdemeYapilacak.Columns["AselsanMailAlmaDate"].Visible = false;
            DtgOdemeYapilacak.Columns["OdemeMailGondermeDate"].Visible = false;
            DtgOdemeYapilacak.Columns["OdemeMailAlmaDate"].Visible = false;
            DtgOdemeYapilacak.Columns["DepoTeslimTarihi"].Visible = false;
            DtgOdemeYapilacak.Columns["DepoTeslimBilgisi"].HeaderText = "SÖKÜLEN CİHAZ TESLİM BİLGİSİ";
            DtgOdemeYapilacak.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIM";
            DtgOdemeYapilacak.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";

            LblTop20.Text = DtgOdemeYapilacak.RowCount.ToString();
        }

        void FillOdemeBilgileriBekleyen()
        {
            satDatas11 = satDataGridview1Manager.TekifDurumListele("Alındı", "Ödeme Bilgileri Kayıt", 1, "BELIRLENMEDI", "BSRN GN.MDL.SATIN ALMA");
            dataBinder11.DataSource = satDatas11.ToDataTable();
            DtgOdemeYapilan.DataSource = dataBinder11;

            DtgOdemeYapilan.Columns["Id"].Visible = false;
            DtgOdemeYapilan.Columns["Satno"].HeaderText = "SAT NO";
            DtgOdemeYapilan.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgOdemeYapilan.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgOdemeYapilan.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgOdemeYapilan.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgOdemeYapilan.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgOdemeYapilan.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgOdemeYapilan.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgOdemeYapilan.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgOdemeYapilan.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgOdemeYapilan.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgOdemeYapilan.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgOdemeYapilan.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgOdemeYapilan.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgOdemeYapilan.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgOdemeYapilan.Columns["Uctekilf"].Visible = false;
            DtgOdemeYapilan.Columns["SiparisNo"].Visible = false;
            DtgOdemeYapilan.Columns["DosyaYolu"].Visible = false;
            DtgOdemeYapilan.Columns["PersonelId"].Visible = false;
            DtgOdemeYapilan.Columns["FirmaBilgisi"].Visible = false;
            DtgOdemeYapilan.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgOdemeYapilan.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgOdemeYapilan.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgOdemeYapilan.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgOdemeYapilan.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgOdemeYapilan.Columns["BelgeTuru"].Visible = false;
            DtgOdemeYapilan.Columns["BelgeNumarasi"].Visible = false;
            DtgOdemeYapilan.Columns["BelgeTarihi"].Visible = false;
            DtgOdemeYapilan.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgOdemeYapilan.Columns["SatOlusturmaTuru"].Visible = false;
            DtgOdemeYapilan.Columns["RedNedeni"].Visible = false;
            DtgOdemeYapilan.Columns["TeklifDurumu"].Visible = false;
            DtgOdemeYapilan.Columns["SatinAlinanFirma"].Visible = false;
            DtgOdemeYapilan.Columns["MailSiniri"].Visible = false;
            DtgOdemeYapilan.Columns["MailDurumu"].Visible = false;
            DtgOdemeYapilan.Columns["MlzTeslimAldTarih"].HeaderText = "MALZEME TESLİM ALINMA TARİHİ";
            DtgOdemeYapilan.Columns["HarcamaYapan"].HeaderText = "HARCAMA YAPAN";
            DtgOdemeYapilan.Columns["Durum"].Visible = false;
            DtgOdemeYapilan.Columns["Donem"].HeaderText = "DÖNEM";
            DtgOdemeYapilan.Columns["Proje"].HeaderText = "PROJE";
            DtgOdemeYapilan.Columns["Donem"].DisplayIndex = 3;
            DtgOdemeYapilan.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgOdemeYapilan.Columns["HarcamaYapan"].Visible = false;
            DtgOdemeYapilan.Columns["AselsanMailGondermeDate"].Visible = false;
            DtgOdemeYapilan.Columns["AselsanMailAlmaDate"].Visible = false;
            DtgOdemeYapilan.Columns["OdemeMailGondermeDate"].Visible = false;
            DtgOdemeYapilan.Columns["OdemeMailAlmaDate"].Visible = false;
            DtgOdemeYapilan.Columns["DepoTeslimTarihi"].Visible = false;
            DtgOdemeYapilan.Columns["DepoTeslimBilgisi"].HeaderText = "SÖKÜLEN CİHAZ TESLİM BİLGİSİ";
            DtgOdemeYapilan.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIM";
            DtgOdemeYapilan.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";

            LblTop22.Text = DtgOdemeYapilan.RowCount.ToString();
        }

        void FillAselsanOnayMail()
        {
            satDatas12 = satDataGridview1Manager.TekifDurumListele("Alındı", "Sat Onay Aselsan", 1, "BELIRLENMEDI");
            dataBinder12.DataSource = satDatas12.ToDataTable();
            DtgAselsanOnayIste.DataSource = dataBinder12;

            DtgAselsanOnayIste.Columns["Id"].Visible = false;
            DtgAselsanOnayIste.Columns["Satno"].HeaderText = "SAT NO";
            DtgAselsanOnayIste.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgAselsanOnayIste.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgAselsanOnayIste.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgAselsanOnayIste.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgAselsanOnayIste.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgAselsanOnayIste.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgAselsanOnayIste.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgAselsanOnayIste.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgAselsanOnayIste.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgAselsanOnayIste.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgAselsanOnayIste.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgAselsanOnayIste.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgAselsanOnayIste.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgAselsanOnayIste.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgAselsanOnayIste.Columns["Uctekilf"].Visible = false;
            DtgAselsanOnayIste.Columns["SiparisNo"].Visible = false;
            DtgAselsanOnayIste.Columns["DosyaYolu"].Visible = false;
            DtgAselsanOnayIste.Columns["PersonelId"].Visible = false;
            DtgAselsanOnayIste.Columns["FirmaBilgisi"].Visible = false;
            DtgAselsanOnayIste.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgAselsanOnayIste.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgAselsanOnayIste.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgAselsanOnayIste.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgAselsanOnayIste.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgAselsanOnayIste.Columns["BelgeTuru"].Visible = false;
            DtgAselsanOnayIste.Columns["BelgeNumarasi"].Visible = false;
            DtgAselsanOnayIste.Columns["BelgeTarihi"].Visible = false;
            DtgAselsanOnayIste.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgAselsanOnayIste.Columns["SatOlusturmaTuru"].Visible = false;
            DtgAselsanOnayIste.Columns["RedNedeni"].Visible = false;
            DtgAselsanOnayIste.Columns["TeklifDurumu"].Visible = false;
            DtgAselsanOnayIste.Columns["SatinAlinanFirma"].Visible = false;
            DtgAselsanOnayIste.Columns["MailSiniri"].Visible = false;
            DtgAselsanOnayIste.Columns["MailDurumu"].Visible = false;
            DtgAselsanOnayIste.Columns["MlzTeslimAldTarih"].HeaderText = "MALZEME TESLİM ALINMA TARİHİ";
            DtgAselsanOnayIste.Columns["HarcamaYapan"].HeaderText = "HARCAMA YAPAN";
            DtgAselsanOnayIste.Columns["Durum"].Visible = false;
            DtgAselsanOnayIste.Columns["Donem"].HeaderText = "DÖNEM";
            DtgAselsanOnayIste.Columns["Proje"].HeaderText = "PROJE";
            DtgAselsanOnayIste.Columns["Donem"].DisplayIndex = 3;
            DtgAselsanOnayIste.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgAselsanOnayIste.Columns["HarcamaYapan"].Visible = false;
            DtgAselsanOnayIste.Columns["AselsanMailGondermeDate"].Visible = false;
            DtgAselsanOnayIste.Columns["AselsanMailAlmaDate"].Visible = false;
            DtgAselsanOnayIste.Columns["OdemeMailGondermeDate"].Visible = false;
            DtgAselsanOnayIste.Columns["OdemeMailAlmaDate"].Visible = false;
            DtgAselsanOnayIste.Columns["DepoTeslimTarihi"].Visible = false;
            DtgAselsanOnayIste.Columns["DepoTeslimBilgisi"].HeaderText = "SÖKÜLEN CİHAZ TESLİM BİLGİSİ";
            DtgAselsanOnayIste.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIM";
            DtgAselsanOnayIste.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";

            LblTop24.Text = DtgAselsanOnayIste.RowCount.ToString();
        }
        void FillAselsanOnayMailAlma()
        {
            satDatas13 = satDataGridview1Manager.TekifDurumListele("Alındı", "Aselsan Onay Bekleyen", 1, "BELIRLENMEDI");
            dataBinder13.DataSource = satDatas13.ToDataTable();
            DtgAselsanOnay.DataSource = dataBinder13;

            DtgAselsanOnay.Columns["Id"].Visible = false;
            DtgAselsanOnay.Columns["Satno"].HeaderText = "SAT NO";
            DtgAselsanOnay.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgAselsanOnay.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgAselsanOnay.Columns["Talepeden"].HeaderText = "TALEP EDEN";
            DtgAselsanOnay.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgAselsanOnay.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgAselsanOnay.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgAselsanOnay.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgAselsanOnay.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgAselsanOnay.Columns["Burcekodu"].HeaderText = "BÜTÇE KODU";
            DtgAselsanOnay.Columns["Satbirim"].HeaderText = "SATIN ALMA YAPCAK BİRİM";
            DtgAselsanOnay.Columns["Harcamaturu"].HeaderText = "HARCAMA TÜRÜ";
            DtgAselsanOnay.Columns["Faturafirma"].HeaderText = "FATURA EDİLECEK FİRMA";
            DtgAselsanOnay.Columns["Ilgilikisi"].HeaderText = "İLGİLİ KİŞİ";
            DtgAselsanOnay.Columns["Masyerino"].HeaderText = "İ.K MASRAF YERİ NO";
            DtgAselsanOnay.Columns["Uctekilf"].Visible = false;
            DtgAselsanOnay.Columns["SiparisNo"].Visible = false;
            DtgAselsanOnay.Columns["DosyaYolu"].Visible = false;
            DtgAselsanOnay.Columns["PersonelId"].Visible = false;
            DtgAselsanOnay.Columns["FirmaBilgisi"].Visible = false;
            DtgAselsanOnay.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgAselsanOnay.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ NO";
            DtgAselsanOnay.Columns["Unvani"].HeaderText = "ÜNVANI";
            DtgAselsanOnay.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgAselsanOnay.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgAselsanOnay.Columns["BelgeTuru"].Visible = false;
            DtgAselsanOnay.Columns["BelgeNumarasi"].Visible = false;
            DtgAselsanOnay.Columns["BelgeTarihi"].Visible = false;
            DtgAselsanOnay.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            DtgAselsanOnay.Columns["SatOlusturmaTuru"].Visible = false;
            DtgAselsanOnay.Columns["RedNedeni"].Visible = false;
            DtgAselsanOnay.Columns["TeklifDurumu"].Visible = false;
            DtgAselsanOnay.Columns["SatinAlinanFirma"].Visible = false;
            DtgAselsanOnay.Columns["MailSiniri"].Visible = false;
            DtgAselsanOnay.Columns["MailDurumu"].Visible = false;
            DtgAselsanOnay.Columns["MlzTeslimAldTarih"].HeaderText = "MALZEME TESLİM ALINMA TARİHİ";
            DtgAselsanOnay.Columns["HarcamaYapan"].HeaderText = "HARCAMA YAPAN";
            DtgAselsanOnay.Columns["Durum"].Visible = false;
            DtgAselsanOnay.Columns["Donem"].HeaderText = "DÖNEM";
            DtgAselsanOnay.Columns["Proje"].HeaderText = "PROJE";
            DtgAselsanOnay.Columns["Donem"].DisplayIndex = 3;
            DtgAselsanOnay.Columns["MlzTeslimAldTarih"].Visible = false;
            DtgAselsanOnay.Columns["HarcamaYapan"].Visible = false;
            DtgAselsanOnay.Columns["AselsanMailGondermeDate"].Visible = false;
            DtgAselsanOnay.Columns["AselsanMailAlmaDate"].Visible = false;
            DtgAselsanOnay.Columns["OdemeMailGondermeDate"].Visible = false;
            DtgAselsanOnay.Columns["OdemeMailAlmaDate"].Visible = false;
            DtgAselsanOnay.Columns["DepoTeslimTarihi"].Visible = false;
            DtgAselsanOnay.Columns["DepoTeslimBilgisi"].HeaderText = "SÖKÜLEN CİHAZ TESLİM BİLGİSİ";
            DtgAselsanOnay.Columns["ButceTanimi"].HeaderText = "BÜTÇE TANIM";
            DtgAselsanOnay.Columns["MaliyetTuru"].HeaderText = "MALİYET TÜRÜ";

            LblTop26.Text = DtgAselsanOnay.RowCount.ToString();
        }

    }
}
