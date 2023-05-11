using Business;
using Business.Concreate.AnaSayfa;
using Business.Concreate.Gecici_Kabul_Ambar;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using ClosedXML.Excel;
using DataAccess.Concreate;
using Entity.AnaSayfa;
using Entity.Gecic_Kabul_Ambar;
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
using UserInterface.STS;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmMalzemeKayit : Form
    {
        MalzemeKayitManager malzemeKayitManager;
        ComboManager comboManager;
        TedarikciFirmaManager tedarikciFirmaManager;
        TeklifFirmalarManager teklifFirmalarManager;
        PersonelKayitManager personelKayitManager;
        MalzemeStokManager malzemeStokManager;
        MalzemeManager malzemeManager;
        BildirimYetkiManager bildirimYetkiManager;
        UstTakimManager ustTakimManager;

        int id, kaydedildi = 0;
        string dosyayolu, fotoyolu, kaynakdosyaismi1, yeniad, deneme, foto;
        bool start = true;
        List<string> fileNames = new List<string>();
        List<Malzeme> malzemes = new List<Malzeme>();

        public bool buton = false, dosyaControl = false, fotoControl = false;
        public string comboAd;
        public object[] infos;

        List<Malzeme> malzemes2 = new List<Malzeme>();

        public FrmMalzemeKayit()
        {
            InitializeComponent();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            tedarikciFirmaManager = TedarikciFirmaManager.GetInstance();
            teklifFirmalarManager = TeklifFirmalarManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();
            malzemeStokManager = MalzemeStokManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
            ustTakimManager = UstTakimManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageMalzemeKayit"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
            if (BtnDosyaEkle.BackColor == Color.LightGreen)
            {
                if (kaydedildi == 0)
                {
                    DialogResult dr = MessageBox.Show("Girilen Veriler Ve Eklenen Dosya Silinecek Onaylıyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Directory.Delete(dosyayolu, true);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void FrmMalzemeKayit_Load(object sender, EventArgs e)
        {
            CmbStokNo();
            Birim();
            CmbFirmalarLoad();
            OnarimYeri();
            MalzemeTuru();
            CmbStokNoUst();
            CmbStokNoUst2();
            Personeller();
            TedarikTuru();
            start = false;
            if (buton == true)
            {
                BtnCancel.Visible = false;
                return;
            }
            BtnCancel.Visible = true;
        }
        void Personeller()
        {
            CmbAdSoyad.DataSource = personelKayitManager.PersonelAdSoyad();
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Adsoyad";
            CmbAdSoyad.SelectedValue = -1;
        }
        public void CmbFirmalarLoad()
        {
            CmbTedarikciFirma.DataSource = teklifFirmalarManager.TedarikciFirmalar(true);

            CmbTedarikciFirma.ValueMember = "Id";
            CmbTedarikciFirma.DisplayMember = "Firmaname";
            CmbTedarikciFirma.SelectedValue = -1;
        }
        public void Birim()
        {
            CmbBirim.DataSource = comboManager.GetList("BİRİM");
            CmbBirim.ValueMember = "Id";
            CmbBirim.DisplayMember = "Baslik";
            CmbBirim.SelectedValue = 0;
        }
        public void MalzemeTuru()
        {
            TxtMalzemeTuru.DataSource = comboManager.GetList("MALZEME_TURU");
            TxtMalzemeTuru.ValueMember = "Id";
            TxtMalzemeTuru.DisplayMember = "Baslik";
            TxtMalzemeTuru.SelectedValue = 0;
        }
        public void TedarikTuru()
        {
            CmbTedarikTuru.DataSource = comboManager.GetList("TEDARIK_TURU");
            CmbTedarikTuru.ValueMember = "Id";
            CmbTedarikTuru.DisplayMember = "Baslik";
            CmbTedarikTuru.SelectedValue = 0;
        }
        public void OnarimYeri()
        {
            CmbOnarimYeri.DataSource = comboManager.GetList("ONARIM_YERI");
            CmbOnarimYeri.ValueMember = "Id";
            CmbOnarimYeri.DisplayMember = "Baslik";
            CmbOnarimYeri.SelectedValue = 0;
        }
        void CmbStokNo()
        {
            TxtStn.DataSource = malzemeKayitManager.GetListMalzemeKayit();
            TxtStn.ValueMember = "Id";
            TxtStn.DisplayMember = "Stokno";
            TxtStn.SelectedValue = 0;
        }
        public void CmbStokNoUst()
        {
            CmbUstTanim.DataSource = ustTakimManager.GetList();
            CmbUstTanim.ValueMember = "Id";
            CmbUstTanim.DisplayMember = "Tanim";
            CmbUstTanim.SelectedValue = -1;
        }
        public void CmbStokNoUst2()
        {
            CmbMalKulUst.DataSource = ustTakimManager.GetList();
            CmbMalKulUst.ValueMember = "Id";
            CmbMalKulUst.DisplayMember = "Tanim";
            CmbMalKulUst.SelectedValue = -1;
        }

        void Temizle()
        {
            TxtStn.Text = ""; TxtTanim.Clear(); CmbBirim.SelectedValue = ""; CmbTedarikciFirma.SelectedValue = ""; TxtOnarimDurumu.SelectedIndex = -1; CmbOnarimYeri.SelectedValue = "";
            TxtMalzemeTuru.SelectedValue = ""; CmbMalzemeTakip.SelectedIndex = -1; CmbMalKulUst.Text = ""; TxtAciklama.Clear();
            PctBox.ImageLocation = ""; webBrowser1.Navigate(""); CmbUstTanim.SelectedValue = ""; TxtUstStok.Clear();
            DtgStokTanim.Rows.Clear(); CmbAdSoyad.SelectedValue = ""; CmbMalKulUst.SelectedValue = ""; TxtUstTanim.Clear(); CmbAdSoyad.SelectedValue = ""; DtgStokTanim.Rows.Clear(); CmbTedarikTuru.SelectedIndex = -1;

        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (DtgStokTanim.RowCount==0)
                {
                    MessageBox.Show("Lütfen ilgili tabloya üst takım bilgisi ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (foto == "")
                {
                    if (dosyaControl == false)
                    {
                        MessageBox.Show("Lütfen Öncelikle Dosya Veya Fotoğraf Ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (fotoControl == false)
                    {
                        MessageBox.Show("Lütfen Öncelikle Fotoğraf Ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                else
                {
                    if (foto!=null)
                    {
                        dosyayolu = foto;
                    }
                }
                
                Malzeme malzeme = new Malzeme(TxtStn.Text, TxtTanim.Text, CmbBirim.Text, CmbTedarikciFirma.Text, TxtOnarimDurumu.Text, CmbOnarimYeri.Text, CmbTedarikTuru.Text, TxtMalzemeTuru.Text, TxtAlternatifMalzeme.Text, TxtAciklama.Text, dosyayolu, TxtUstTanim.Text, CmbMalKulUst.Text, CmbAdSoyad.Text, infos[1].ToString(), CmbMalzemeTakip.Text);

                string mesaj = malzemeManager.Add(malzeme);
                dosyaControl = false;

                if (mesaj == "OK")
                {
                    Malzeme malzeme1 = malzemeManager.Get(TxtStn.Text);
                    int benzersizId = malzeme1.Id;

                    if (DtgStokTanim.RowCount != 0)
                    {
                        foreach (DataGridViewRow item in DtgStokTanim.Rows)
                        {
                            if (malzemes.Count!=0)
                            {
                                foreach (Malzeme item2 in malzemes)
                                {
                                    if (item2.UstStok == item.Cells["stokNo"].Value.ToString())
                                    {
                                        
                                    }
                                    else
                                    {
                                        Malzeme malzeme2 = new Malzeme(item.Cells["stokNo"].Value.ToString(), item.Cells["tanim"].Value.ToString(), benzersizId);
                                        malzemeManager.UstTakimEkle(malzeme2);
                                    }
                                }
                            }
                            else
                            {
                                Malzeme malzeme2 = new Malzeme(item.Cells["stokNo"].Value.ToString(), item.Cells["tanim"].Value.ToString(), benzersizId);
                                malzemeManager.UstTakimEkle(malzeme2);
                            }
                            

                        }
                    }
                }
                else
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                fotoControl = false;
                dosyaControl = false;
                mesaj = BildirimKayit();
                if (mesaj!="OK")
                {
                    if (mesaj != "Server Ayarı Kapalı")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }


            #region ÖncekiKayit
            /*DialogResult dialogResult = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MalzemeKayit malzemeKayit = new MalzemeKayit(TxtStn.Text, TxtTanim.Text, CmbBirim.Text, CmbTedarikciFirma.Text, TxtOnarimDurumu.Text, CmbOnarimYeri.Text, TxtMalzemeTuru.Text, CmbMalzemeTakip.Text, CmbMalKulUst.Text, TxtAciklama.Text, dosyayolu, TxtAlternatifMalzeme.Text, CmbMalKulUst.Text, TxtUstTanim.Text, CmbAdSoyad.Text);
                string mesaj = malzemeKayitManager.Add(malzemeKayit);
                if (mesaj == "OK")
                {
                    if (DtgStokTanim.RowCount!=0)
                    {
                        foreach (DataGridViewRow item in DtgStokTanim.Rows)
                        {
                            malzemeKayitManager.UstTakimEkle(item.Cells["stokNo"].Value.ToString(),item.Cells["tanim"].Value.ToString(), TxtStn.Text, TxtTanim.Text);

                        }
                    }
                    MessageBox.Show("Bilgiler Başarıyla Kaydedidi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kaydedildi = 1;
                    Temizle();
                    //BtnFotoEkle.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }*/
            #endregion
        }

        string BildirimKayit()
        {
            string[] array = new string[8];

            array[0] = "Depo Malzeme Kayıt"; // Bildirim Başlık
            array[1] = infos[1].ToString(); // Bildirim Sahibi Personel
            array[2] = TxtStn.Text; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "stok numaralı"; // Bildirim türü
            array[4] = TxtTanim.Text + " adlı malzemenin"; // İÇERİK
            array[5] = "malzeme kayıt işlemlerini gerçekleştirmiştir!";
            array[6] = "";

            BildirimYetki bildirimYetki = bildirimYetkiManager.Get(infos[1].ToString());
            if (bildirimYetki == null)
            {
                array[7] = infos[0].ToString();
            }
            else
            {
                array[7] = bildirimYetki.SorumluId + infos[0].ToString();
            }

            string mesaj = FrmHelper.BildirimGonder(array, array[7]);
            return mesaj;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bilgileri Güncellemek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (TxtStn.Text == "")
                {
                    MessageBox.Show("Lütfen Öncelikle Bir Stok No Bilgisini Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MalzemeKayit malzemeKayit = new MalzemeKayit(TxtStn.Text, TxtTanim.Text, CmbBirim.Text, CmbTedarikciFirma.Text, TxtOnarimDurumu.Text, CmbOnarimYeri.Text, TxtMalzemeTuru.Text, CmbMalzemeTakip.Text, CmbMalKulUst.Text, TxtAciklama.Text, dosyayolu, TxtAlternatifMalzeme.Text, CmbMalKulUst.Text, TxtUstTanim.Text, CmbAdSoyad.Text);
                string mesaj = malzemeKayitManager.Update(malzemeKayit, id);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Temizle();
            }
        }

        private void BtnBirimEkle_Click(object sender, EventArgs e)
        {
            comboAd = "BİRİM";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnTedarilciFirmaEkle_Click(object sender, EventArgs e)
        {
            FrmTedarikciFirmaBilgileri frmTedarikciFirmaBilgileri = new FrmTedarikciFirmaBilgileri();
            frmTedarikciFirmaBilgileri.ShowDialog();
        }

        private void BtnOnarimYeriEkle_Click(object sender, EventArgs e)
        {
            comboAd = "ONARIM_YERI";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnMalzemeTuruEkle_Click(object sender, EventArgs e)
        {
            comboAd = "MALZEME_TURU";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void TxtOnarimDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxtOnarimDurumu.SelectedIndex == 1)
            {
                CmbOnarimYeri.Text = "ONARIM YOK";
                CmbOnarimYeri.Enabled = false;
            }
            if (TxtOnarimDurumu.SelectedIndex == 0)
            {
                CmbOnarimYeri.SelectedIndex = -1;
                CmbOnarimYeri.Enabled = true;
            }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (CmbUstTanim.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir Stok Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgStokTanim.Rows.Add();
            int sonSatir = DtgStokTanim.RowCount - 1;

            DtgStokTanim.Rows[sonSatir].Cells["stokNo"].Value = TxtUstStok.Text;
            DtgStokTanim.Rows[sonSatir].Cells["tanim"].Value = CmbUstTanim.Text;
            CmbUstTanim.SelectedIndex = -1;
            TxtUstStok.Clear();
        }

        private void TxtUstTakimTanim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CmbMalKulUst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbMalKulUst.SelectedIndex==-1)
            {
                TxtUstTanim.Clear();
            }
            id = CmbMalKulUst.SelectedValue.ConInt();
            UstTakim ustTakim = ustTakimManager.Get(id);
            if (ustTakim == null)
            {
                TxtUstTanim.Text = "";
                return;
            }
            TxtUstTanim.Text = ustTakim.StokNo;
        }
        string dosya = "", stok = "";
        void CreateFile()
        {
            string root2 = @"Z:\DTS";
            string subdir = @"Z:\DTS\GEÇİCİ KABUL VE AMBAR\";
            string subdir2 = @"Z:\DTS\GEÇİCİ KABUL VE AMBAR\MALZEME KAYIT\";
            string anadosya = @"Z:\DTS\GEÇİCİ KABUL VE AMBAR\MALZEME KAYIT\MALZEME_STOK\";

            if (!Directory.Exists(root2))
            {
                Directory.CreateDirectory(root2);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(subdir2))
            {
                Directory.CreateDirectory(subdir2);
            }
            if (!Directory.Exists(anadosya))
            {
                Directory.CreateDirectory(anadosya);
            }
            dosya = anadosya + stok;
            if (!Directory.Exists(dosya))
            {
                //Directory.CreateDirectory(dosya);
            }
        }
        string yeniStok = "";
        void StokAl()
        {
            Malzeme malzemeKayit = malzemeManager.MalzemeSonStok();
            string sonStok = malzemeKayit.StokNo; //UGS-0000-1167
            string[] array = sonStok.Split('-');
            string parca = array[1].ToString();
            if (parca.Length==3)
            {
                parca = "0000";
            }
            int sayi = array[2].ConInt() + 1;

            yeniStok = array[0].ToString() + "-" + parca + "-" + sayi;

            TxtStn.Text = yeniStok;
        }
        private void BtnStokAl_Click(object sender, EventArgs e)
        {
            StokAl();
        }
        int index = 0;
        private void CmbUstTanim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbUstTanim.SelectedIndex==-1)
            {
                TxtUstStok.Clear();
            }
            id = CmbUstTanim.SelectedValue.ConInt();
            UstTakim ustTakim = ustTakimManager.Get(id);
            if (ustTakim == null)
            {
                TxtUstStok.Text = "";
                return;
            }

            TxtUstStok.Text = ustTakim.StokNo;

            index = CmbUstTanim.SelectedIndex;
            CmbMalKulUst.SelectedIndex = index;

        }

        private void bTN_Click(object sender, EventArgs e)
        {
            FrmUstTakim frmUstTakimEkle = new FrmUstTakim();
            frmUstTakimEkle.ShowDialog();
            //FrmUstTakimEkle frmUstTakimEkle = new FrmUstTakimEkle();
            //frmUstTakimEkle.ShowDialog();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            malzemes2 = malzemeManager.GetList();

            foreach (Malzeme item in malzemes2)
            {
                string[] array = item.Tanim.Split('\n');
                int uzunluk = array.Length;
                if (uzunluk > 1 )
                {
                    string tanim = array[0].ToString().Trim();
                    malzemeManager.MalzemeTanimDuzelt(tanim, item.Id.ConInt());

                }
            }
            MessageBox.Show("Tanımlar Düzeldi.");
        }

        private void BtnStokDuzelt_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("UGS-000- şeklinde olan tüm Stok Numaraları UGS-0000- olarak düzeltilecektir. Dosya yolları aynı kalacaktır! OTS datası kontrol edilecek ve UGS-0000- sıfırlı olarak o stok daha önce kullanılmış ise DTS deki kayıda yeni stok verilecektir.Onaylıyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                List<Malzeme> malzemes = new List<Malzeme>();
                malzemes = malzemeManager.MalzemeStokDuzeltList();
                foreach (Malzeme item in malzemes)
                {
                    string[] array = item.StokNo.Split('-');
                    if (array[1].ToString()=="000")
                    {
                        string stok = array[0].ToString() + "-0000-" + array[2].ToString();
                        Malzeme malzeme = malzemeManager.MalzemeStokKontrolOTS(stok);
                        if (malzeme!=null)
                        {
                            if (malzeme.Tanim.Trim() != item.Tanim.Trim())
                            {
                                StokAl();
                                stok = yeniStok;
                                malzemeKayitManager.StokDuzelt(stok, item.Id.ConInt());
                            }
                            else
                            {
                                malzemeKayitManager.StokDuzelt(stok, item.Id.ConInt());
                            }
                        }
                        else
                        {
                            malzemeKayitManager.StokDuzelt(stok, item.Id.ConInt());
                        }
                    }
                }
                MessageBox.Show("Kaydedilmiştir.");
            }
        }

        private void BtnTedarikTürüEkle_Click(object sender, EventArgs e)
        {
            comboAd = "TEDARIK_TURU";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnExcelCek_Click(object sender, EventArgs e)
        {
            IXLWorkbook workbook = new XLWorkbook(@"C:\Users\MAYıldırım\Desktop\SON GÜNCEL STOK LİSTESİ-GÜNCELLEME.xlsx");
            string sayfa = "SARF MALZEME";
            IXLWorksheet worksheet = workbook.Worksheet(sayfa);

            var rows = worksheet.Rows(3, 1300);
            //List<MalzemeStok> list = new List<MalzemeStok>();
            //DateTime outDate = DateTime.Now;
            //double outDouble = 0;
            foreach (IXLRow item in rows)
            {
                stok = item.Cell("A").Value.ToString();
                //CreateFile();
                MalzemeStok entity = new MalzemeStok(
                    item.Cell("A").Value.ToString(),
                    item.Cell("B").Value.ToString(),
                    item.Cell("C").Value.ToString(),
                    sayfa,
                    dosya);
                malzemeStokManager.Add(entity);
            }

            MessageBox.Show("Bitti");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bilgileri Silmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string mesaj = malzemeKayitManager.Delete(id);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Directory.Delete(dosyayolu, true);
                Temizle();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CmbStokNo();
            //Temizle();
            //start = false;
        }
        string kaynakdosyaismi, alinandosya;

        private void TxtStn_SelectedValueChanged(object sender, EventArgs e)
        {
            if (start)
            {
                return;
            }
            if (TxtStn.Text == "")
            {
                return;
            }

            DtgStokTanim.Rows.Clear();
            id = TxtStn.SelectedValue.ConInt();
            MalzemeKayit personelKayit = malzemeKayitManager.Get(id);
            TxtTanim.Text = personelKayit.Tanim;
            CmbBirim.Text = personelKayit.Birim;
            CmbTedarikciFirma.Text = personelKayit.Tedarikcifirma;
            TxtOnarimDurumu.Text = personelKayit.Malzemeonarimdurumu;
            CmbOnarimYeri.Text = personelKayit.Malzemeonarımyeri;
            TxtMalzemeTuru.Text = personelKayit.Malzemeturu;
            CmbMalzemeTakip.Text = personelKayit.Malzemetakipdurumu;
            CmbMalKulUst.Text = personelKayit.Malzemekul;
            TxtAciklama.Text = personelKayit.Aciklama;
            dosyayolu = personelKayit.Dosyayolu;
            webBrowser1.Navigate(dosyayolu);

            deneme = "\\" + TxtStn.Text + ".jpg";
            foto = personelKayit.Dosyayolu;
            PctBox.ImageLocation = foto + deneme;

            malzemes = malzemeManager.MalzemeUstTakimList(id);

            if (malzemes.Count == 0)
            {
                return;
            }
            else
            {
                foreach (Malzeme item in malzemes)
                {
                    DtgStokTanim.Rows.Add();
                    int sonSatir = DtgStokTanim.RowCount - 1;
                    DtgStokTanim.Rows[sonSatir].Cells["stokNo"].Value = item.StokNo;
                    DtgStokTanim.Rows[sonSatir].Cells["tanim"].Value = item.Tanim;

                }


            }
        }
        private void BtnFotoEkle_Click(object sender, EventArgs e)
        {
            if (TxtStn.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Stok No Bilgisini Yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\GEÇİCİ KABUL VE AMBAR\MALZEME KAYIT\";
            //string root = @"C:\STS";
            //string subdir = @"C:\STS\GEÇİCİ KABUL VE AMBAR\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyayolu = subdir + TxtStn.Text;
            Directory.CreateDirectory(dosyayolu);

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                fotoyolu = openFileDialog2.FileName.ToString();
                kaynakdosyaismi1 = openFileDialog2.SafeFileName.ToString();
            }

            /*fotoyolu = openFileDialog2.FileName.ToString();
            kaynakdosyaismi1 = openFileDialog2.SafeFileName.ToString();

            alinandosya1 = openFileDialog2.FileName.ToString();*/


            if (Path.GetExtension(fotoyolu) == ".jpg" || Path.GetExtension(fotoyolu) == ".png" || Path.GetExtension(fotoyolu) == ".jpeg")
            {
                PctBox.ImageLocation = fotoyolu;
                Properties.Settings.Default.FotoYolu = fotoyolu;
                Properties.Settings.Default.Save();

                yeniad = TxtStn.Text + ".jpg";
                if (!Directory.Exists(dosyayolu + "\\" + yeniad))
                {
                    string silinecek = dosyayolu + "\\" + yeniad;
                    File.Delete(silinecek);
                }
                File.Copy(fotoyolu, dosyayolu + "\\" + yeniad);
                dosyaControl = true;
                fotoControl = true;
            }
            else
            {
                MessageBox.Show("Lütfen JPEG veya PNG formatında olan bir dosyayı seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            if (TxtStn.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Stok No Bilgisini Yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\GEÇİCİ KABUL VE AMBAR\MALZEME KAYIT\";
            //string root = @"C:\STS";
            //string subdir = @"C:\STS\GEÇİCİ KABUL VE AMBAR\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyayolu = subdir + TxtStn.Text;
            if (!Directory.Exists(dosyayolu))
            {
                Directory.CreateDirectory(dosyayolu);
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
            if (File.Exists(dosyayolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyayolu + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                //BtnFotoEkle.Enabled = true;
                webBrowser1.Navigate(dosyayolu);
                dosyaControl = true;
            }
        }
    }
}
