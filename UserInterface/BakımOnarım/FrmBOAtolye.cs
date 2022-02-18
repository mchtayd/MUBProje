using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.BakimOnarimAtolye;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarim;
using Entity.BakimOnarimAtolye;
using Entity.Gecic_Kabul_Ambar;
using Entity.IdariIsler;
using Microsoft.Office.Interop.Word;
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
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;

namespace UserInterface.BakımOnarım
{
    public partial class FrmBOAtolye : Form
    {
        AtolyeManager atolyeManager;
        AtolyeMalzemeManager atolyeMalzemeManager;
        IslemAdimlariManager islemAdimlariManager;
        PersonelKayitManager kayitManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        IscilikIscilikManager ıscilikIscilikManager;
        SiparisPersonelManager siparisPersonelManager;

        List<AtolyeMalzeme> atolyeMalzemes;


        List<string> IcSiparisler = new List<string>();
        List<string> SiparisNos = new List<string>();
        List<string> DosyaYollari = new List<string>();

        public object[] infos;
        int id;
        string siparisNo = "", dosya, taslakYolu = "";
        string kaynak = @"Z:\DTS\BAKIM ONARIM ATOLYE\Taslak\";
        string yol = @"C:\DTS\Taslak\";
        public FrmBOAtolye()
        {
            InitializeComponent();
            atolyeManager = AtolyeManager.GetInstance();
            atolyeMalzemeManager = AtolyeMalzemeManager.GetInstance();
            islemAdimlariManager = IslemAdimlariManager.GetInstance();
            kayitManager = PersonelKayitManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            ıscilikIscilikManager = IscilikIscilikManager.GetInstance();
            siparisPersonelManager = SiparisPersonelManager.GetInstance();
        }

        private void FrmBOAtolye_Load(object sender, EventArgs e)
        {
            IslemAdimlari();
            Personeller();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageArizaAcmaAtolye"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void IslemAdimlari()
        {
            CmbIslemAdimi.DataSource = islemAdimlariManager.GetList("BAKIM ONARIM ATOLYE");
            CmbIslemAdimi.ValueMember = "Id";
            CmbIslemAdimi.DisplayMember = "IslemaAdimi";
            CmbIslemAdimi.SelectedValue = -1;
        }
        void Personeller()
        {
            CmbGorevAtanacakPersonel.DataSource = kayitManager.PersonelAdSoyad();
            CmbGorevAtanacakPersonel.ValueMember = "Id";
            CmbGorevAtanacakPersonel.DisplayMember = "Adsoyad";
            CmbGorevAtanacakPersonel.SelectedValue = -1;
        }
        int arizaDurumu;
        string icSiparisNo = "";
        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (TxtAbfFormNo.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Abf No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Atolye atolye = atolyeManager.ArizaGetir(TxtAbfFormNo.Text.ConInt());
            if (atolye == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz Abf Numarasıya Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                return;
            }
            Temizle();
            DataDisplay();
            TxtStokNoUst.Text = atolye.StokNoUst;
            TxtTanimUst.Text = atolye.TanimUst;
            TxtSeriNoUst.Text = atolye.SeriNoUst;
            TxtGarantiDurumuUst.Text = atolye.GarantiDurumu;
            TxtBildirimNo.Text = atolye.BildirimNo;
            TxtScrmNo.Text = atolye.CrmNo;
            TxtKategori.Text = atolye.Kategori;
            TxtBolgeAdi.Text = atolye.BolgeAdi;
            TxtProje.Text = atolye.Proje;
            TxtBildirilenAriza.Text = atolye.BildirilenAriza;
            arizaDurumu = atolye.ArizaDurum;
            int adet = 1;
            if (arizaDurumu == 0)
            {
                LblDurumAcik.Visible = false;
                LblDurumKapali.Visible = true;
                LblIslemAdimiAcik.Text = atolye.BulunduguIslemAdimi;
                LblIslemAdimiKapali.Visible = false;
                LblIslemAdimiAcik.Visible = true;

                if (DtgMalzemeler.RowCount > 1)
                {

                    foreach (AtolyeMalzeme item in atolyeMalzemes)
                    {
                        LblIcSiparisNo.Text = "221RWK" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                        icSiparisNo = "221RWK" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text + "/" + adet;
                        IcSiparisler.Add(icSiparisNo);

                        adet++;
                    }
                }


                /*if (DtgMalzemeler.RowCount > 1)
                {
                    foreach (AtolyeMalzeme item in atolyeMalzemes)
                    {
                        LblIcSiparisNo.Text = "221RWK" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                        icSiparisNo = "221RWK" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text + "/" + adet;
                        IcSiparisler.Add(icSiparisNo);

                        adet++;
                    }
                }*/
                else
                {
                    LblIcSiparisNo.Text = "221RWK" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                }

            }
            else
            {
                LblDurumAcik.Visible = true;
                LblDurumKapali.Visible = false;
                LblIslemAdimiKapali.Text = atolye.BulunduguIslemAdimi;
                LblIslemAdimiKapali.Visible = true;
                LblIslemAdimiAcik.Visible = false;

                if (DtgMalzemeler.RowCount > 1)
                {
                    foreach (AtolyeMalzeme item in atolyeMalzemes)
                    {
                        LblIcSiparisNo.Text = "221BO" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                        icSiparisNo = "221BO" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text + "/" + adet;
                        IcSiparisler.Add(icSiparisNo);
                        adet++;

                    }
                }
                else
                {
                    LblIcSiparisNo.Text = "221BO" + DateTime.Now.ToString("MM") + TxtAbfFormNo.Text;
                }

            }

        }
        void Temizle()
        {
            TxtStokNoUst.Clear(); TxtSeriNoUst.Clear(); TxtGarantiDurumuUst.Clear(); TxtBildirimNo.Clear(); TxtScrmNo.Clear(); TxtKategori.Clear(); TxtBolgeAdi.Clear(); TxtProje.Clear(); TxtStokNo.Clear(); TxtTanim.Clear(); TxtSeriNo.Clear(); TxtRevizyon.Clear();
            TxtMiktar.Clear(); TxtDurum.Clear(); TxtBildirilenAriza.Clear(); TxtModifikasyonlar.Clear(); TxtNotlar.Clear(); CmbGorevAtanacakPersonel.SelectedValue = ""; CmbIslemAdimi.SelectedValue = ""; TxtTanimUst.Clear(); LblIcSiparisNo.Text = "-"; LblDurumAcik.Visible = false; LblDurumKapali.Visible = false; LblIslemAdimiKapali.Visible = false; LblIslemAdimiAcik.Visible = false;
            LblToplam.Text = DtgMalzemeler.RowCount.ToString();
        }
        void DataDisplay()
        {
            atolyeMalzemes = atolyeMalzemeManager.GetList(TxtAbfFormNo.Text.ConInt());
            DtgMalzemeler.DataSource = atolyeMalzemes.ToDataTable();
            LblToplam.Text = DtgMalzemeler.RowCount.ToString();


            DtgMalzemeler.Columns["Id"].Visible = false;
            DtgMalzemeler.Columns["FormNo"].Visible = false;
            DtgMalzemeler.Columns["StokNo"].HeaderText = "STOK NO";
            DtgMalzemeler.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeler.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgMalzemeler.Columns["Durum"].HeaderText = "DURUM";
            DtgMalzemeler.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgMalzemeler.Columns["Miktar"].HeaderText = "MİKAR";
            //DtgMalzemeler.Columns["Birim"].HeaderText = "BİRİM";
            DtgMalzemeler.Columns["TalepTarihi"].HeaderText = "TALEP TARİHİ";
            DtgMalzemeler.Columns["SiparisNo"].Visible = false;
            DtgMalzemeler.Columns["Sec"].HeaderText = "KAYIT DURUMU";
            DtgMalzemeler.Columns["Sec"].DisplayIndex = 0;

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        void IscilikGir()
        {
            SiparisPersonel siparis = siparisPersonelManager.Get("", infos[1].ToString());

            if (IcSiparisler.Count > 1)
            {
                for (int i = 0; i < IcSiparisler.Count; i++)
                {
                    IscilikIscilik ıscilikIscilik1 = new IscilikIscilik(id, CmbGorevAtanacakPersonel.Text, siparis.Gorevi, siparis.Bolum, "İŞÇİLİK", IcSiparisler[i].ToString(), DateTime.Now, "0:05");
                    ıscilikIscilikManager.Add(ıscilikIscilik1);
                }
            }
            else
            {
                IscilikIscilik ıscilikIscilik = new IscilikIscilik(id, CmbGorevAtanacakPersonel.Text, siparis.Gorevi, siparis.Bolum, "İŞÇİLİK", LblIcSiparisNo.Text, DateTime.Now, "0:05");
                ıscilikIscilikManager.Add(ıscilikIscilik);
            }

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtStokNoUst.Text == "" || DtgMalzemeler.RowCount == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Tüm Bilgileri Eksiksiz Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbGorevAtanacakPersonel.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Görev Atanacak Personel Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbIslemAdimi.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle İşlem Adımı Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbIslemAdimi.Text != "400-BİLDİRİM ve B/O BAŞLAMA ONAYI (MÜHENDİS)")
            {
                MessageBox.Show("Lütfen Öncelikle İşlem Adımı Bilgisini 400-GÖZ DENETİMİ Olarak Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                CreateFile();
                if (IcSiparisler.Count > 0)
                {
                    for (int i = 0; i < IcSiparisler.Count; i++)
                    {
                        siparisNo = Guid.NewGuid().ToString();
                        Atolye atolye2 = new Atolye(TxtAbfFormNo.Text.ConInt(), TxtStokNoUst.Text, TxtTanimUst.Text, TxtSeriNoUst.Text, TxtGarantiDurumuUst.Text, TxtBildirimNo.Text, TxtScrmNo.Text, TxtKategori.Text, TxtBolgeAdi.Text, TxtProje.Text, TxtBildirilenAriza.Text, IcSiparisler[i].ToString(), DtgCekilmeTarihi.Value, DtgSiparisTarihi.Value, TxtModifikasyonlar.Text, TxtNotlar.Text, CmbIslemAdimi.Text, siparisNo,
                            DosyaYollari[i].ToString());

                        atolyeManager.Add(atolye2);

                        SiparisNos.Add(siparisNo);
                    }
                }
                else
                {
                    siparisNo = Guid.NewGuid().ToString();
                    Atolye atolye = new Atolye(TxtAbfFormNo.Text.ConInt(), TxtStokNoUst.Text, TxtTanimUst.Text, TxtSeriNoUst.Text, TxtGarantiDurumuUst.Text, TxtBildirimNo.Text, TxtScrmNo.Text, TxtKategori.Text, TxtBolgeAdi.Text, TxtProje.Text, TxtBildirilenAriza.Text, LblIcSiparisNo.Text, DtgCekilmeTarihi.Value, DtgSiparisTarihi.Value, TxtModifikasyonlar.Text, TxtNotlar.Text, CmbIslemAdimi.Text, siparisNo,
                        dosya);

                    SiparisNos.Add(siparisNo);
                    atolyeManager.Add(atolye);
                }

                int sayac = 0;
                foreach (DataGridViewRow item in DtgMalzemeler.Rows)
                {

                    AtolyeMalzeme atolyeMalzeme = new AtolyeMalzeme(item.Cells["FormNo"].Value.ConInt(), item.Cells["StokNo"].Value.ToString(),
                        item.Cells["Tanim"].Value.ToString(), item.Cells["SeriNo"].Value.ToString(), item.Cells["Durum"].Value.ToString(),
                        item.Cells["Revizyon"].Value.ToString(), item.Cells["Miktar"].Value.ConDouble(), item.Cells["TalepTarihi"].Value.ConDate(), 
                        SiparisNos[sayac].ToString());

                    atolyeMalzemeManager.Add(atolyeMalzeme);

                    sayac++;
                }

                if (IcSiparisler.Count > 0)
                {
                    for (int i = 0; i < IcSiparisler.Count; i++)
                    {
                        Atolye atolye2 = atolyeManager.Get(IcSiparisler[i].ToString());
                        id = atolye2.Id;
                        GorevAtama();
                    }
                }
                else
                {
                    Atolye atolye1 = atolyeManager.Get(LblIcSiparisNo.Text);
                    id = atolye1.Id;
                    GorevAtama();
                }
                //IscilikGir();
                
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                DtgMalzemeler.DataSource = null;
                IcSiparisler.Clear();
                SiparisNos.Clear();
                DosyaYollari.Clear();
            }
        }
        string GorevAtama()
        {
            GorevAtamaPersonel gorevAtamaPersonel = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "100-TAKIMIN ÇEKİLMESİ (AMBAR VERİ KAYIT)", DateTime.Now, "ÇEKİM İŞLEMİ TAMAMLANMIŞTIR.", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel);


            GorevAtamaPersonel gorevAtamaPersonel2 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "200-MODİFİKASYON KONTROLÜ (AMBAR VERİ KAYIT)", DateTime.Now, "UYGULANMASI GEREKEN MODİFİKASYON BULUNMAMAKTADIR.", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel2);



            GorevAtamaPersonel gorevAtamaPersonel3 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", infos[1].ToString(), "300-SİPARİŞ OLUŞTURMA (AMBAR VERİ KAYIT)", DateTime.Now, LblIcSiparisNo.Text + " NOLU SİPARİŞ OLUŞTURULMUŞTUR.", "00:25:00".ConOnlyTime());
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel3);



            GorevAtamaPersonel gorevAtamaPersonel4 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", CmbGorevAtanacakPersonel.Text, CmbIslemAdimi.Text, DateTime.Now, "", DateTime.Now.Date);
            gorevAtamaPersonelManager.Add(gorevAtamaPersonel4);

            string sure = "0 Gün " + "0 Saat " + "0 Dakika";

            GorevAtamaPersonel gorevAtama = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "100-TAKIMIN ÇEKİLMESİ (AMBAR VERİ KAYIT)", sure, DateTime.Now.Date);
            gorevAtamaPersonelManager.Update(gorevAtama);
            GorevAtamaPersonel messege2 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "200-MODİFİKASYON KONTROLÜ (AMBAR VERİ KAYIT)", sure, DateTime.Now.Date);
            gorevAtamaPersonelManager.Update(messege2);
            GorevAtamaPersonel messege3 = new GorevAtamaPersonel(id, "BAKIM ONARIM ATOLYE", "300-SİPARİŞ OLUŞTURMA (AMBAR VERİ KAYIT)", sure, "00:25:00".ConOnlyTime());
            gorevAtamaPersonelManager.Update(messege3);
            return "OK";
        }
        void CreateFile()
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
            var dosyalar = new DirectoryInfo(kaynak).GetFiles("*.docx");

            foreach (FileInfo item in dosyalar)
            {
                item.CopyTo(yol + item.Name);
            }

            taslakYolu = yol + "MP-FR-045 BO İZLEME FORMU (TEKNİK SERVİS) REV (01).docx";

            int sayac = 0;
            foreach (DataGridViewRow item in DtgMalzemeler.Rows)
            {
                string root2 = @"Z:\DTS";
                string subdir = @"Z:\DTS\BAKIM ONARIM ATOLYE\";
                string anadosya = @"Z:\DTS\BAKIM ONARIM ATOLYE\BAKIM ONARIM FORMU\";

                if (!Directory.Exists(root2))
                {
                    Directory.CreateDirectory(root2);
                }
                if (!Directory.Exists(subdir))
                {
                    Directory.CreateDirectory(subdir);
                }
                if (!Directory.Exists(anadosya))
                {
                    Directory.CreateDirectory(anadosya);
                }
                if (IcSiparisler.Count > 0)
                {
                    dosya = anadosya + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + "\\";
                    
                }
                else
                {
                    dosya = anadosya + DateTime.Now.ToString("dd_MM_yyyy") + "_" + DateTime.Now.ToString("mm_ss") + "\\";
                }
                DosyaYollari.Add(dosya);
                Directory.CreateDirectory(dosya);

                Application wApp = new Application();
                Documents wDocs = wApp.Documents;
                object filePath = taslakYolu;

                Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
                wDoc.Activate();

                Bookmarks wBookmarks = wDoc.Bookmarks;
                wBookmarks["StokNo"].Range.Text = item.Cells["StokNo"].Value.ToString();
                if (arizaDurumu == 0)
                {
                    wBookmarks["Bolge"].Range.Text = "AMBAR";
                }
                else
                {
                    wBookmarks["Bolge"].Range.Text = TxtBolgeAdi.Text;
                }
                wBookmarks["Proje"].Range.Text = TxtProje.Text;
                wBookmarks["Tanim"].Range.Text = item.Cells["Tanim"].Value.ToString();
                wBookmarks["Tarih"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                if (IcSiparisler.Count > 0)
                {
                    wBookmarks["IcSiparisNo"].Range.Text = IcSiparisler[sayac].ToString();
                }
                else
                {
                    wBookmarks["IcSiparisNo"].Range.Text = LblIcSiparisNo.Text;
                }
                
                wBookmarks["Miktar"].Range.Text = item.Cells["Miktar"].Value.ToString();
                wBookmarks["SeriNo"].Range.Text = item.Cells["SeriNo"].Value.ToString();
                wBookmarks["Tarih1"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih2"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih3"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih4"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih5"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih6"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                wBookmarks["Tarih7"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");

                //wDoc.SaveAs2(yol + "\\" + TxtIsAkisNoTamamla.Text + ".docx"); // farklı kaydet

                if (IcSiparisler.Count > 0)
                {
                    wDoc.SaveAs2(dosya + "B_O İzleme Formu" + ".docx");
                }
                else
                {
                    wDoc.SaveAs2(dosya + "B_O İzleme Formu" + ".docx");
                }
                wDoc.Close();
                wApp.Quit(false);

                sayac++;
            }
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
    }
}
