using Business;
using Business.Concreate.BakimOnarim;
using Business.Concreate.STS;
using DataAccess;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity;
using Entity.BakimOnarim;
using Entity.IdariIsler;
using Entity.STS;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;

namespace UserInterface.BakımOnarım
{
    public partial class FrmDtfHazirlanacaklar : Form
    {
        IsAkisNoManager isAkisNoManager;
        ComboManager comboManager;
        AltYukleniciManager altYukleniciManager;
        AbfMalzemeManager abfMalzemeManager;
        ArizaKayitManager arizaKayitManager;
        DtfManager dtfManager;

        List<AbfMalzeme> abfMalzemes;
        bool start = false;
        public object[] infos;
        string donem, comboAd, taslakYolu, dosyaYolu, stokNo, abfNo, projeKodu, garantiDurumu, tanim, seriNo = "";
        int id, malzemeId = 0;
        int arizaId = 0;
        string yol = @"C:\DTS\Taslak\";
        string kaynak = @"Z:\DTS\BAKIM ONARIM\TASLAKLAR\";
        public FrmDtfHazirlanacaklar()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            altYukleniciManager = AltYukleniciManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            arizaKayitManager = ArizaKayitManager.GetInstance();
            dtfManager = DtfManager.GetInstance();
        }

        private void FrmOkfKontrol_Load(object sender, EventArgs e)
        {
            DataDisplay();
            IsAkisNo();
            TalebiOlusturan();
            IsKategorisi();
            AltYukleniciFirma();
            start = true;
        }
        public void Yenileneceler()
        {
            start = false;
            DataDisplay();
            IsAkisNo();
            TalebiOlusturan();
            IsKategorisi();
            AltYukleniciFirma();
            start = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDtfHazirlanacaklar"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void DataDisplay()
        {
            abfMalzemes = new List<AbfMalzeme>();
            dataBinderOto.DataSource = null;
            abfMalzemes = abfMalzemeManager.DtfKayitList();

            dataBinderOto.DataSource = abfMalzemes.ToDataTable();
            DtgList.DataSource = dataBinderOto;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["BenzersizId"].Visible = false;
            DtgList.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgList.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgList.Columns["SokulenSeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgList.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgList.Columns["SokulenCalismaSaati"].Visible = false;
            DtgList.Columns["SokulenRevizyon"].HeaderText = "REVİZYON";
            DtgList.Columns["CalismaDurumu"].Visible = false;
            DtgList.Columns["FizikselDurum"].Visible = false;
            DtgList.Columns["TakilanStokNo"].Visible = false;
            DtgList.Columns["TakilanTanim"].Visible = false;
            DtgList.Columns["TakilanSeriNo"].Visible = false;
            DtgList.Columns["TakilanMiktar"].Visible = false;
            DtgList.Columns["TakilanBirim"].Visible = false;
            DtgList.Columns["TakilanCalismaSaati"].Visible = false;
            DtgList.Columns["TakilanRevizyon"].Visible = false;
            DtgList.Columns["TeminDurumu"].Visible = false;
            DtgList.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgList.Columns["AbTarihSaat"].Visible = false;
            DtgList.Columns["TemineAtilamTarihi"].Visible = false;
            DtgList.Columns["MalzemeDurumu"].Visible = false;
            DtgList.Columns["MalzemeIslemAdimi"].Visible = false;
            DtgList.Columns["SokulenTeslimDurum"].HeaderText = "MALZEME TESLİM DURUMU";
            DtgList.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgList.Columns["BolgeSorumlusu"].HeaderText = "BÖLGE SORUMLUSU";
            DtgList.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";
            DtgList.Columns["YerineMalzemeTakilma"].HeaderText = "YERİNE MALZEME TAKILDI MI?";
            DtgList.Columns["DosyaYolu"].Visible = false;

            DtgList.Columns["SokulenTeslimDurum"].DisplayIndex = 1;
            DtgList.Columns["SokulenStokNo"].DisplayIndex = 2;
            DtgList.Columns["SokulenTanim"].DisplayIndex = 3;
            DtgList.Columns["SokulenSeriNo"].DisplayIndex = 4;
            DtgList.Columns["SokulenRevizyon"].DisplayIndex = 5;
            DtgList.Columns["SokulenMiktar"].DisplayIndex = 6;
            DtgList.Columns["SokulenBirim"].DisplayIndex = 7;
            DtgList.Columns["BolgeAdi"].DisplayIndex = 8;
            DtgList.Columns["AbfNo"].DisplayIndex = 9;
            DtgList.Columns["YapilacakIslem"].DisplayIndex = 10;
            DtgList.Columns["BolgeSorumlusu"].DisplayIndex = 11;

            TxtTop.Text = DtgList.RowCount.ToString();
        }

        public void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        void TalebiOlusturan()
        {
            TalepEden.Text = infos[1].ToString();
            LblKayitTarihi.Text = DateTime.Now.ToString("dd.MM.yyyy");
            donem = FrmHelper.DonemControl(DateTime.Now);

            string[] array = donem.Split(' ');

            CmbDonemAy.Text = array[0].ToString();
            CmbDonemYil.Text = array[1].ToString();
        }
        public void IsKategorisi()
        {
            CmbIsKategorisi.DataSource = comboManager.GetList("IS_KATEGORISI");
            CmbIsKategorisi.ValueMember = "Id";
            CmbIsKategorisi.DisplayMember = "Baslik";
            CmbIsKategorisi.SelectedValue = 0;
        }
        void AltYukleniciFirma()
        {
            CmbAltYukleniciFirma.DataSource = altYukleniciManager.GetList(0);
            CmbAltYukleniciFirma.ValueMember = "Id";
            CmbAltYukleniciFirma.DisplayMember = "Firmaadi";
            CmbAltYukleniciFirma.SelectedValue = 0;
        }

        private void CmbAltYukleniciFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (CmbAltYukleniciFirma.SelectedIndex == -1)
            {
                LblFirmaSorumlusu.Text = "00";
                return;
            }
            id = CmbAltYukleniciFirma.SelectedValue.ConInt();
            AltYuklenici altYukleniciFirma = altYukleniciManager.Get(id);
            LblFirmaSorumlusu.Text = altYukleniciFirma.Personeladi;
        }

        private void BtnAltYukFirmaEkle_Click(object sender, EventArgs e)
        {
            FrmAltYukleniciFirma frmBolgeler = new FrmAltYukleniciFirma();
            frmBolgeler.button5.Visible = false;
            frmBolgeler.ShowDialog();
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            arizaId = DtgList.CurrentRow.Cells["BenzersizId"].Value.ConInt();
            LblBolgeAdi.Text = DtgList.CurrentRow.Cells["BolgeAdi"].Value.ToString();
            stokNo = DtgList.CurrentRow.Cells["SokulenStokNo"].Value.ToString();
            tanim = DtgList.CurrentRow.Cells["SokulenTanim"].Value.ToString();
            seriNo = DtgList.CurrentRow.Cells["SokulenSeriNo"].Value.ToString();
            abfNo = DtgList.CurrentRow.Cells["AbfNo"].Value.ToString();
            ArizaKayit arizaKayit = arizaKayitManager.GetId(arizaId);
            TxtIsinTanimi.Text = arizaKayit.BildirilenAriza;
            projeKodu = arizaKayit.Proje;
            garantiDurumu = arizaKayit.GarantiDurumu;
            malzemeId = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                IsAkisNo();

                string anadosya = @"Z:\DTS\BAKIM ONARIM\DTF\";
                dosyaYolu = anadosya + LblIsAkisNo.Text + "\\";
                Dtf dtf = new Dtf(LblIsAkisNo.Text.ConInt(), TalepEden.Text, LblKayitTarihi.Value, donem, CmbButceKodu.Text, abfNo, LblBolgeAdi.Text, projeKodu, garantiDurumu, CmbIsKategorisi.Text, TxtIsinTanimi.Text.ToUpper(), stokNo, tanim, seriNo, CmbOnarimYeri.Text, CmbAltYukleniciFirma.Text, LblFirmaSorumlusu.Text, DtgIsinVerildigiTarih.Value, dosyaYolu);

                string mesaj = dtfManager.Add(dtf);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TaslakKopyala();
                CreateWord();

                //mesaj = BildirimKayit();
                //if (mesaj != "OK")
                //{
                //    if (mesaj != "Server Ayarı Kapalı")
                //    {
                //        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}

                IsAkisNo();
                Temizle();

                mesaj = dtfManager.DtfKayitDurum(malzemeId);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void CreateWord()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\BAKIM ONARIM\";
            string anadosya = @"Z:\DTS\BAKIM ONARIM\DTF\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(anadosya))
            {
                Directory.CreateDirectory(anadosya);
            }
            dosyaYolu = anadosya + LblIsAkisNo.Text + "\\";
            Directory.CreateDirectory(dosyaYolu);

            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = taslakYolu;

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["IsAkisNo"].Range.Text = LblIsAkisNo.Text;
            wBookmarks["AbfNo"].Range.Text = abfNo;
            wBookmarks["BolgeAdi"].Range.Text = LblBolgeAdi.Text;
            wBookmarks["ProjeKodu"].Range.Text = projeKodu;
            wBookmarks["AltYukleniciFirma"].Range.Text = CmbAltYukleniciFirma.Text;
            wBookmarks["GarantiDurumu"].Range.Text = garantiDurumu;
            wBookmarks["FirmaSorumlusu"].Range.Text = LblFirmaSorumlusu.Text;
            wBookmarks["StokNo"].Range.Text = stokNo;
            wBookmarks["Tanim"].Range.Text = tanim;
            wBookmarks["ButceKodu"].Range.Text = CmbButceKodu.Text;
            wBookmarks["SeriNo"].Range.Text = seriNo;
            if (CmbOnarimYeri.Text == "YERİNDE ONARIM")
            {
                wBookmarks["YerindeOnarim"].Range.Text = "X";
            }
            else
            {
                wBookmarks["FirmadaOnarim"].Range.Text = "X";
            }
            wBookmarks["IsinTanimi"].Range.Text = TxtIsinTanimi.Text;
            wBookmarks["TalebiOlusturan"].Range.Text = TalepEden.Text;
            wBookmarks["IsinVerildigiTarih"].Range.Text = DtgIsinVerildigiTarih.Value.ToString("dd/MM/yyyy");
            wBookmarks["Tarih"].Range.Text = DtgIsinVerildigiTarih.Value.ToString("dd/MM/yyyy");
            wBookmarks["Tarih2"].Range.Text = DtgIsinVerildigiTarih.Value.ToString("dd/MM/yyyy");

            wDoc.SaveAs2(dosyaYolu + LblIsAkisNo.Text + ".docx");
            wDoc.Close();
            wApp.Quit(false);

            try
            {
                Directory.Delete(yol, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                File.Delete(taslakYolu);
            }
        }
        void TaslakKopyala()
        {
            string root = @"C:\DTS";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(yol))
            {
                Directory.CreateDirectory(yol);
            }

            File.Copy(kaynak + "MP-FR-019 DOĞRUDAN TEMİN FORMU REV (00).docx", yol + "MP-FR-019 DOĞRUDAN TEMİN FORMU REV (00).docx");

            taslakYolu = yol + "MP-FR-019 DOĞRUDAN TEMİN FORMU REV (00).docx";
        }

        private void BtnIsinTanimiEkle_Click(object sender, EventArgs e)
        {
            comboAd = "IS_KATEGORISI";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }
        void Temizle()
        {
            CmbButceKodu.SelectedIndex = -1; CmbIsKategorisi.SelectedIndex = -1; TxtIsinTanimi.Clear(); CmbOnarimYeri.Text = ""; CmbAltYukleniciFirma.SelectedIndex = -1;
            DataDisplay();
            IsAkisNo();
            TalebiOlusturan();
            IsKategorisi();
            AltYukleniciFirma();
        }
    }
}
