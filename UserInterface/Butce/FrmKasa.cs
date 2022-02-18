using Business;
using Business.Concreate.Butce;
using DataAccess.Concreate;
using Entity;
using Entity.Butce;
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
using UserInterface.Ana_Sayfa;
using UserInterface.STS;
using Application = Microsoft.Office.Interop.Word.Application;

namespace UserInterface.Butce
{
    public partial class FrmKasa : Form
    {
        IsAkisNoManager isAkisNoManager;
        IsAvansTalepManager ısAvansTalepManager;
        KasaManager kasaManager;
        AvansManager avansManager;
        KasaDurumManager kasaDurumManager;

        List<Kasa> kasaKaydedilecekler = new List<Kasa>();
        List<Kasa> kasas = new List<Kasa>();
        List<IsAvansTalep> ısAvansTaleps;

        string isAkisNo, taslakYolu = "";
        string yol = @"C:\DTS\Taslak\";
        string kaynak = @"Z:\DTS\SATIN ALMA\Folder\FORM\";


        public object[] infos;
        string dosyaYolu = "", kaynakdosyaismi, alinandosya;
        bool dosyaEkle = false, isAvansTalepEt = false, start = false;
        public FrmKasa()
        {
            InitializeComponent();
            kasaManager = KasaManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            ısAvansTalepManager = IsAvansTalepManager.GetInstance();
            avansManager = AvansManager.GetInstance();
            kasaDurumManager = KasaDurumManager.GetInstance();
        }

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            Personel();
            DataDisplay();
            DataVadesizHesapList();
            HesapNo();
            start = true;
        }
        void Personel()
        {
            LblAdSoyad.Text = infos[1].ToString();
            LblSiparisNo.Text = infos[9].ToString();
            LblUnvani.Text = infos[10].ToString();
            LblMasrafYeriNo.Text = infos[4].ToString();
            LblMasrafYeri.Text = infos[2].ToString();
        }
        void HesapNo()
        {
            TxtHesabSahibi.DataSource = kasaManager.GetList();
            TxtHesabSahibi.ValueMember = "Id";
            TxtHesabSahibi.DisplayMember = "HesapSahibi";
            TxtHesabSahibi.SelectedValue = -1;
        }
        void DataDisplay()
        {
            ısAvansTaleps = ısAvansTalepManager.GetList();
            dataBinder.DataSource = ısAvansTaleps.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Tarih"].HeaderText = "TALEP TARİHİ";
            DtgList.Columns["AdiSoyadi"].Visible = false;
            DtgList.Columns["SiparisNo"].Visible = false;
            DtgList.Columns["Unvani"].Visible = false;
            DtgList.Columns["MasrafYeriNo"].Visible = false;
            DtgList.Columns["MasrafYeri"].Visible = false;
            DtgList.Columns["TalepNedeni"].HeaderText = "TALEP NEDENİ";
            DtgList.Columns["Miktar"].HeaderText = "TALEP EDİLEN TUTAR";
            DtgList.Columns["Aciklamalar"].Visible = false;
            DtgList.Columns["DosyaYolu"].Visible = false;

        }
        void DataVadesizHesapList()
        {
            kasas = kasaManager.GetList();
            dataBinder2.DataSource = kasas.ToDataTable();
            DtgVadesizHesaplar.DataSource = dataBinder2;

            DtgVadesizHesaplar.Columns["Id"].Visible = false;
            DtgVadesizHesaplar.Columns["HesapSahibi"].HeaderText = "HESAP SAHİBİ";
            DtgVadesizHesaplar.Columns["MusteriNumarasi"].HeaderText = "MÜŞTERİ NUMARASI";
            DtgVadesizHesaplar.Columns["DovizCinsi"].HeaderText = "DÖVİZ CİNSİ";
            DtgVadesizHesaplar.Columns["SubeAdi"].HeaderText = "ŞUBE ADI";
            DtgVadesizHesaplar.Columns["HesapNumarasi"].HeaderText = "HESAP NUMARASI";
            DtgVadesizHesaplar.Columns["Iban"].HeaderText = "IBAN NO";

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageKasa"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            string control = Kontrol();

            if (control!="OK")
            {
                MessageBox.Show(control,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
            Kasa kasa = new Kasa(TxtHesapSahibi.Text, TxtMusteriNumarasi.Text, TxtDovizCinsi.Text, TxtSubeAdi.Text, TxtHesapNumarasi.Text, TxtIban.Text);

            kasaKaydedilecekler.Add(kasa);
            kasas = kasaManager.GetList();
            kasas.Add(kasa);

            DtgVadesizHesaplar.DataSource = kasas;

            TemizleVadesizHesaplar();

        }
        void TemizleVadesizHesaplar()
        {
            TxtHesapSahibi.Clear(); TxtMusteriNumarasi.Clear(); TxtDovizCinsi.Clear(); TxtSubeAdi.Clear(); TxtHesapNumarasi.Clear(); TxtIban.Clear();
        }
        string Kontrol()
        {
            if (TxtHesapSahibi.Text=="")
            {
                return "Lütfen Öncelikle Hesap Sahibi Bilgisini Doldurunuz!";
            }
            if (TxtMusteriNumarasi.Text=="")
            {
                return "Lütfen Öncelikle Müşteri Numarası Bilgisini Doldurunuz!";
            }
            if (TxtDovizCinsi.Text == "")
            {
                return "Lütfen Öncelikle Döviz Cinsi Bilgisini Doldurunuz!";
            }
            if (TxtSubeAdi.Text == "")
            {
                return "Lütfen Öncelikle Şube Adı Bilgisini Doldurunuz!";
            }
            if (TxtHesapNumarasi.Text == "")
            {
                return "Lütfen Öncelikle Hesap Numarası Bilgisini Doldurunuz!";
            }
            if (TxtIban.Text == "")
            {
                return "Lütfen Öncelikle Iban Numarası Bilgisini Doldurunuz!";
            }
            return "OK";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (DtgVadesizHesaplar.RowCount==0)
            {
                MessageBox.Show("Lütfen Öncelikle Vadesiz Hesap Bilgileri Listeye Ekleyiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            foreach (Kasa item in kasaKaydedilecekler)
            {

                Kasa kasa = new Kasa(item.HesapSahibi.ToString(), item.MusteriNumarasi.ToString(), item.DovizCinsi.ToString(), item.SubeAdi.ToString(), item.HesapNumarasi.ToString(), item.Iban.ToString());

                kasaManager.Add(kasa);

            }
            MessageBox.Show("Bilgileri Başarıyla Kaydediliştir!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            TemizleVadesizHesaplar();
            DtgVadesizHesaplar.DataSource = null;
            DataVadesizHesapList();
        }
        string AvansKontrol()
        {
            if (CmbHavaleyiGonderen.Text=="")
            {
                return "Lütfen Öncelikle Havleyi Gönderen Bilgisini Doldurunuz!";
            }
            if (TxtHesapNo.Text == "")
            {
                return "Lütfen Öncelikle Havale Alınan Hesap No Bilgisini Doldurunuz!";
            }
            if (TxtIbanNo.Text == "")
            {
                return "Lütfen Öncelikle Iban No Bilgisini Doldurunuz!";
            }
            if (TxtHesabSahibi.Text == "")
            {
                return "Lütfen Öncelikle Hesap Sahibi Bilgisini Doldurunuz!";
            }
            if (TxtTutar.Text == "")
            {
                return "Lütfen Öncelikle Tutar Bilgisini Doldurunuz!";
            }
            return "OK";
        }

        private void BtnKaydetAvasTalep_Click(object sender, EventArgs e)
        {
            string mesaj = Control();
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IsAkisNo();
            DosyaOlustur();
            TaslakKopyala();
            CreateWord();

            IsAvansTalep ısAvansTalep = new IsAvansTalep(isAkisNo.ConInt(), DtTarih.Value, LblAdSoyad.Text, LblSiparisNo.Text, LblUnvani.Text, LblMasrafYeriNo.Text, LblMasrafYeri.Text, TxtTalepNedeni.Text, TxtMiktar.Text.ConDouble(), TxtAciklamalar.Text, dosyaYolu);

            string control = ısAvansTalepManager.Add(ısAvansTalep);
            if (control!="OK")
            {
                MessageBox.Show(control,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
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
            DataDisplay();
            MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            TemizleTalep();
            IsAkisNo();

        }
        void TemizleTalep()
        {
            TxtTalepNedeni.Clear(); TxtMiktar.Clear(); TxtAciklamalar.Clear();
        }
        string Control()
        {
            if (TxtTalepNedeni.Text == "")
            {
                return "Lütfen Öncelikle Talep Nedeni Bilgisini Doldurunuz!";
            }
            if (TxtMiktar.Text == "")
            {
                return "Lütfen Öncelikle Miktar Bilgisini Doldurunuz!";
            }
            if (TxtAciklamalar.Text == "")
            {
                return "Lütfen Öncelikle Açıklamalar Bilgisini Doldurunuz!";
            }
            return "OK";
        }
        void CreateWord()
        {
            Application wApp = new Application();
            Documents wDocs = wApp.Documents;
            object filePath = taslakYolu;

            Document wDoc = wDocs.Open(ref filePath, ReadOnly: false); // elle müdahele açıldı
            wDoc.Activate();

            Bookmarks wBookmarks = wDoc.Bookmarks;
            wBookmarks["AdiSoyadi"].Range.Text = LblAdSoyad.Text;
            wBookmarks["Unvani"].Range.Text = LblUnvani.Text;
            wBookmarks["Bolumu"].Range.Text = LblMasrafYeri.Text;
            wBookmarks["TalepNedeni"].Range.Text = TxtTalepNedeni.Text;
            wBookmarks["TalepEdilenMiktar"].Range.Text = TxtMiktar.Text;
            wBookmarks["TalepTarihi"].Range.Text = DtTarih.Value.ToString("dd/MM/yyyy");
            wBookmarks["Aciklamalar"].Range.Text = TxtAciklamalar.Text;
            wBookmarks["AdSoyad2"].Range.Text = LblAdSoyad.Text;
            wBookmarks["Bolum2"].Range.Text = LblMasrafYeri.Text;

            wDoc.SaveAs2(dosyaYolu+ "\\" + isAkisNo + ".doc");
            wDoc.Close();
            wApp.Quit(false);

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
            var dosyalar = new DirectoryInfo(kaynak).GetFiles("*.doc");

            foreach (FileInfo item in dosyalar)
            {
                item.CopyTo(yol + item.Name);
            }

            taslakYolu = yol + "İŞ AVANS TALEP FORMU.doc";
        }
        void DosyaOlustur()
        {
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\IS AVANS TALEPLERİ\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            dosyaYolu = subdir + isAkisNo;
            Directory.CreateDirectory(dosyaYolu);
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            isAkisNo = isAkis.Id.ToString();
        }

        private void TxtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
        string dosyayolu;

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyayolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            try
            {
                webBrowser2.Navigate(dosyayolu);
            }
            catch (Exception)
            {
                return;
            }
        }
        string dosya = "";
        private void BtnBul_Click(object sender, EventArgs e)
        {
            IsAvansTalep avansTalep = ısAvansTalepManager.Get(TxtIsAkisNo.Text.ConInt());
            if (avansTalep == null)
            {
                MessageBox.Show("Girmiş Oluduğunuz İş Akış Numarasına Ait Bir Kayıt Bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtIsAkisNo.Clear();
                return;
            }
            TxtTutar.Text = avansTalep.Miktar.ToString();
            DtIstemeTarihi.Value = avansTalep.Tarih;
            LblDonem.Text = FrmHelper.DonemControl(DtHavaleTarihi.Value);
            dosya = avansTalep.DosyaYolu;
            try
            {
                webBrowser1.Navigate(dosya);
            }
            catch (Exception)
            {
                return;
            }

        }

        private void BtnDekontEkle_Click_1(object sender, EventArgs e)
        {
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

            if (File.Exists(dosya + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosya + "\\" + kaynakdosyaismi);
                webBrowser1.Navigate(dosya);
                dosyaEkle = true;
            }

        }

        private void TxtHesabSahibi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            Kasa kasa = kasaManager.Get(TxtHesabSahibi.Text);
            TxtHesapNo.Text = kasa.HesapNumarasi;
            TxtIbanNo.Text = kasa.Iban;
        }

        private void BtnAvansKaydet_Click(object sender, EventArgs e)
        {
            if (DtgAvans.RowCount == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Avans Kayıt Listenize Veri Ekleyiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            foreach (DataGridViewRow item in DtgAvans.Rows)
            {
                Avans avans = new Avans(item.Cells["AkisNo"].Value.ConInt(), item.Cells["Donem"].Value.ToString(), item.Cells["IstemeTarihi"].Value.ConDate(),
                    item.Cells["GelisTarihi"].Value.ConDate(), item.Cells["Gonderen"].Value.ToString(), item.Cells["YatanHesapNo"].Value.ToString(), 
                    item.Cells["IbanNo"].Value.ToString(), item.Cells["HesapSahibi"].Value.ToString(), item.Cells["GelenTutar"].Value.ConDouble(),  item.Cells["Column1"].Value.ToString());

                avansManager.Add(avans);

                kasaDurumManager.UpdateGelir(item.Cells["GelenTutar"].Value.ConDouble());
                
            }

            dosyaEkle = false;
            MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            webBrowser1.Navigate("");
            TxtHesabSahibi.SelectedValue = "";
        }


        private void BtnEkleAvans_Click_1(object sender, EventArgs e)
        {
            if (dosyaEkle==false)
            {
                MessageBox.Show("Lütfen Öncelikle Dekont Bilgisini Ekler Kısmına Ekleyiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            string mesaj = AvansKontrol();
            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DtgAvans.Rows.Add();
            int sonSatir = DtgAvans.RowCount - 1;
            DtgAvans.Rows[sonSatir].Cells["AkisNo"].Value = TxtIsAkisNo.Text;
            DtgAvans.Rows[sonSatir].Cells["Donem"].Value = LblDonem.Text;
            DtgAvans.Rows[sonSatir].Cells["IstemeTarihi"].Value = DtIstemeTarihi.Text;
            DtgAvans.Rows[sonSatir].Cells["GelisTarihi"].Value = DtHavaleTarihi.Text;
            DtgAvans.Rows[sonSatir].Cells["Gonderen"].Value = CmbHavaleyiGonderen.Text;
            DtgAvans.Rows[sonSatir].Cells["YatanHesapNo"].Value = TxtHesapNo.Text;
            DtgAvans.Rows[sonSatir].Cells["IbanNo"].Value = TxtIbanNo.Text;
            DtgAvans.Rows[sonSatir].Cells["HesapSahibi"].Value = TxtHesabSahibi.Text;
            DtgAvans.Rows[sonSatir].Cells["GelenTutar"].Value = TxtTutar.Text;
            DtgAvans.Rows[sonSatir].Cells["Column1"].Value = dosya;
            TemizleIsAvans();
        }
        void TemizleIsAvans()
        {
            TxtIsAkisNo.Clear(); LblDonem.Text = "00"; CmbHavaleyiGonderen.Text = ""; TxtHesapNo.Clear(); TxtIbanNo.Clear(); TxtHesabSahibi.Text = "";
            TxtTutar.Clear(); webBrowser1.Navigate("");
        }

        private void TxtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
        

        private void BtnDekontEkle_Click(object sender, EventArgs e)
        {
            if (isAvansTalepEt==false)
            {
                MessageBox.Show("Lütfen Öncelikle Avans Talep Et Butonuna Basarak İş Avansı Talebinde Bulununuz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                webBrowser1.Navigate(dosyaYolu);
                dosyaEkle = true;
            }
        }
    }
}
