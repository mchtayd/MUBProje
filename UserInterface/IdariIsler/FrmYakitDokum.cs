using Business;
using Business.Concreate.IdarıIsler;
using ClosedXML.Excel;
using DataAccess.Concreate;
using Entity;
using Entity.IdariIsler;
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

namespace UserInterface.IdariIsler
{
    public partial class FrmYakitDokum : Form
    {
        PersonelKayitManager kayitManager;
        AracZimmetiManager aracZimmetiManager;
        IsAkisNoManager isAkisNoManager;
        ComboManager comboManager;
        YakitDokumManager yakitDokumManager;
        List<AracZimmeti> aracZimmetis;
        List<string> fileNames = new List<string>();
        double toplam, litreFiyati, alinanLitre = 0;
        public string comboAd;
        bool start, dosyaKontrol, dosyaKontrol2 = false;
        string dosyaYolu, isAkisNo, kaynakdosyaismi, alinandosya, siparisNo = "";
        public FrmYakitDokum()
        {
            InitializeComponent();
            kayitManager = PersonelKayitManager.GetInstance();
            aracZimmetiManager = AracZimmetiManager.GetInstance();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            yakitDokumManager = YakitDokumManager.GetInstance();
        }

        private void FrmYakitDokum_Load(object sender, EventArgs e)
        {
            Personeller();
            Plakalar();
            Firma();
            FirmaTasit();
            IsAkisNo();
            IsAkisNoTasitTanima();
            tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage2"]);
            start = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYakitDokumleri"]);
            
            /*if (dosyaKontrol2 != true)
            {
                Directory.Delete(dosyaYolu, true);
            }
            */
            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        public void IsAkisNoTasitTanima()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNoTasit.Text = isAkis.Id.ToString();
        }
        public void IsAkisKontrolsuzGuncelle()
        {
            isAkisNoManager.UpdateKontrolsuz();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNoTasit.Text = isAkis.Id.ToString();
        }
        void Personeller()
        {
            CmbPersoneller.DataSource = kayitManager.PersonelAdSoyad();
            CmbPersoneller.ValueMember = "Id";
            CmbPersoneller.DisplayMember = "Adsoyad";
            CmbPersoneller.SelectedValue = -1;
        }

        void Plakalar()
        {
            aracZimmetis = aracZimmetiManager.GetList();
            CmbPlaka.DataSource = aracZimmetis;
            CmbPlaka.ValueMember = "Id";
            CmbPlaka.DisplayMember = "Plaka";
            CmbPlaka.SelectedValue = -1;
        }
        /*void PlakalarTasit()
        {
            aracZimmetis = aracZimmetiManager.GetList();
            CmbPlakaTT.DataSource = aracZimmetis;
            CmbPlakaTT.ValueMember = "Id";
            CmbPlakaTT.DisplayMember = "Plaka";
            CmbPlakaTT.SelectedValue = -1;
        }*/

        private void CmbPlaka_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                if (CmbPlaka.Text == "")
                {
                    return;
                }
                AracZimmeti aracZimmeti = aracZimmetiManager.Get(CmbPlaka.Text);
                if (aracZimmeti != null)
                {
                    TxtAracSiparisNo.Text = aracZimmeti.SiparisNo;
                }
            }
        }
        public void Firma()
        {
            CmbFirma.DataSource = comboManager.GetList("FİRMA");
            CmbFirma.ValueMember = "Id";
            CmbFirma.DisplayMember = "Baslik";
            CmbFirma.SelectedValue = 0;
        }
        public void FirmaTasit()
        {
            CmbFirmaTasit.DataSource = comboManager.GetList("FİRMA TAŞIT TANIMA");
            CmbFirmaTasit.ValueMember = "Id";
            CmbFirmaTasit.DisplayMember = "Baslik";
            CmbFirmaTasit.SelectedValue = 0;
        }

        private void TxtLitreFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtAlinanLitre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtAlinanLitre_TextChanged(object sender, EventArgs e)
        {
            if (TxtAlinanLitre.Text == "")
            {
                alinanLitre = 0;
                Toplam();
                return;
            }
            alinanLitre = TxtAlinanLitre.Text.ConDouble();
            Toplam();
        }

        private void TxtLitreFiyati_TextChanged(object sender, EventArgs e)
        {
            if (TxtLitreFiyati.Text == "")
            {
                litreFiyati = 0;
                Toplam();
                return;
            }
            litreFiyati = TxtLitreFiyati.Text.ConDouble();
            Toplam();
        }
        void Toplam()
        {
            toplam = litreFiyati * alinanLitre;
            LbToplam.Text = toplam.ToString();
        }
        private void BtnFirmaEkle_Click(object sender, EventArgs e)
        {
            comboAd = "FİRMA";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void AdvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                AdvList.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void BtnDosyaEkle_Click(object sender, EventArgs e)
        {
            IsAkisNo();
            IsAkisNoTasitTanima();
            isAkisNo = LblIsAkisNo.Text;
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\";
            string subdir2 = @"Z:\DTS\SATIN ALMA\YAKIT FİRMA DÖKÜMLERİ\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(subdir2))
            {
                Directory.CreateDirectory(subdir2);
            }

            dosyaYolu = subdir2 + isAkisNo;
            Directory.CreateDirectory(dosyaYolu);

            // Directory.CreateDirectory(subdir + isAkisNo);
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
                fileNames.Add(alinandosya);
                webBrowser1.Navigate(dosyaYolu);
                dosyaKontrol = true;
            }

        }
        private void BtnListeyeEkle_Click(object sender, EventArgs e)
        {
            string mesaj = Kontrol();
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string donem = FrmHelper.DonemControl(DtTarih.Value);

            AdvList.Rows.Add();
            int sonSatir = AdvList.RowCount - 1;
            AdvList.Rows[sonSatir].Cells["AkisNoList"].Value = LblIsAkisNo.Text;
            AdvList.Rows[sonSatir].Cells["FirmaList"].Value = CmbFirma.Text;
            AdvList.Rows[sonSatir].Cells["DonemList"].Value = donem;
            AdvList.Rows[sonSatir].Cells["TarihList"].Value = DtTarih.Value;
            AdvList.Rows[sonSatir].Cells["DefterNoList"].Value = TxtDefterNo.Text;
            AdvList.Rows[sonSatir].Cells["SiraNoList"].Value = TxtSiraNo.Text;
            AdvList.Rows[sonSatir].Cells["FisNoList"].Value = TxtFisNo.Text;
            AdvList.Rows[sonSatir].Cells["PersonelList"].Value = CmbPersoneller.Text;
            AdvList.Rows[sonSatir].Cells["PlakaList"].Value = CmbPlaka.Text;
            AdvList.Rows[sonSatir].Cells["AracSiparisNoList"].Value = TxtAracSiparisNo.Text;
            AdvList.Rows[sonSatir].Cells["LitreFiyatiList"].Value = TxtLitreFiyati.Text;
            AdvList.Rows[sonSatir].Cells["AlinanLitreList"].Value = TxtAlinanLitre.Text;
            AdvList.Rows[sonSatir].Cells["ToplamTutarList"].Value = toplam.ToString();


            DataGridViewButtonColumn c = (DataGridViewButtonColumn)AdvList.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;

            TxtTop.Text = AdvList.RowCount.ToString();
            groupBox2.Text = TxtDefterNo.Text + " Nolu LİSTE";

            Toplamlar();
            ToplamlarLitre();
            Temizleİcerikler();
        }

        private void CmbPlakaTasit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                if (CmbPlakaTasit.Text == "")
                {
                    return;
                }
                AracZimmeti aracZimmeti = aracZimmetiManager.Get(CmbPlakaTasit.Text);
                if (aracZimmeti != null)
                {
                    TxtAracSiparisNoTasit.Text = aracZimmeti.SiparisNo;
                }
            }
        }

        private void BtnFirmaEkleTasit_Click(object sender, EventArgs e)
        {
            comboAd = "FİRMA TAŞIT TANIMA";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }

        private void BtnDosyaEkleTasit_Click(object sender, EventArgs e)
        {
            IsAkisNo();
            IsAkisNoTasitTanima();
            isAkisNo = LblIsAkisNoTasit.Text;
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\";
            string subdir2 = @"Z:\DTS\SATIN ALMA\YAKIT FİRMA DÖKÜMLERİ\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(subdir2))
            {
                Directory.CreateDirectory(subdir2);
            }

            dosyaYolu = subdir2 + isAkisNo;
            Directory.CreateDirectory(dosyaYolu);

            // Directory.CreateDirectory(subdir + isAkisNo);
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
                fileNames.Add(alinandosya);
                webBrowser2.Navigate(dosyaYolu);
                dosyaKontrol2 = true;
            }
        }

        private void BtnListeyeEkleTasit_Click(object sender, EventArgs e)
        {
            string mesaj = KontrolTasit();
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AdvListTasit.Rows.Add();
            int sonSatir = AdvListTasit.RowCount - 1;
            AdvListTasit.Rows[sonSatir].Cells["AkisNoTasit"].Value = LblIsAkisNoTasit.Text;
            AdvListTasit.Rows[sonSatir].Cells["FirmaListTasit"].Value = CmbFirmaTasit.Text;
            AdvListTasit.Rows[sonSatir].Cells["DonemListTasit"].Value = TxtAlinanDonemTasit.Text;
            AdvListTasit.Rows[sonSatir].Cells["TarihListTasit"].Value = DtTarihTasit.Value;
            AdvListTasit.Rows[sonSatir].Cells["PlakaListTasit"].Value = CmbPlakaTasit.Text;
            AdvListTasit.Rows[sonSatir].Cells["SiparisNoListTasit"].Value = TxtAracSiparisNoTasit.Text;
            AdvListTasit.Rows[sonSatir].Cells["ToplamListTasit"].Value = TxtToplamTutar.Text.ToString();


            DataGridViewButtonColumn c = (DataGridViewButtonColumn)AdvListTasit.Columns["RemoveList"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;

            LblToplamKayit.Text = AdvListTasit.RowCount.ToString();

            ToplamlarTasit();
            TemizleİceriklerTasit();
        }

        void Temizle()
        {
            CmbFirma.SelectedValue = ""; TxtDefterNo.Clear(); TxtSiraNo.Clear(); TxtFisNo.Clear(); CmbPersoneller.Text = ""; CmbPlaka.Text = ""; TxtAracSiparisNo.Clear(); TxtLitreFiyati.Clear(); TxtAlinanLitre.Clear();
            webBrowser1.Navigate(""); AdvList.Rows.Clear();
        }
        void TemizleTasit()
        {
            CmbFirmaTasit.SelectedValue = ""; TxtAlinanDonemTasit.SelectedIndex = -1; CmbPlakaTasit.Text = ""; TxtAracSiparisNoTasit.Clear();
            webBrowser2.Navigate(""); AdvListTasit.Rows.Clear(); TxtToplamTutar.Clear();
        }

        void Temizleİcerikler()
        {
            TxtSiraNo.Clear(); TxtFisNo.Clear(); CmbPersoneller.Text = ""; CmbPlaka.Text = ""; TxtAracSiparisNo.Clear(); TxtLitreFiyati.Clear(); TxtAlinanLitre.Clear();
        }
        void TemizleİceriklerTasit()
        {
            CmbPlakaTasit.Text = ""; TxtAracSiparisNoTasit.Clear(); TxtToplamTutar.Clear();
        }

        private void BtnKaydetTasit_Click(object sender, EventArgs e)
        {
            /*if (dosyaKontrol2 == false)
            {
                MessageBox.Show("Lütfen Öncelikle Dosya Ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (AdvListTasit.RowCount == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Listeye Bir Kayıt Ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstedğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                siparisNo = Guid.NewGuid().ToString();
                YakitDokum yakitDokum = new YakitDokum(LblIsAkisNoTasit.Text.ConInt(), CmbFirmaTasit.Text, TxtAlinanDonemTasit.Text, LblGenelTopTasit.Text.ConDouble(), dosyaYolu, siparisNo,
                    "TAŞIT TANIMA");

                string mesaj = yakitDokumManager.AnaAddTasit(yakitDokum);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                KalemleriKaydetTasit();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAkisNo();
                IsAkisNoTasitTanima();
                TemizleTasit();
            }*/
        }

        private void BtnDosyaSec_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                dosyaYolu = openFileDialog1.FileName;
                kaynakdosyaismi = openFileDialog1.SafeFileName.ToString();

                dosyaYolu = openFileDialog1.FileName.ToString();


                if (Path.GetExtension(dosyaYolu) == ".xlsm" || Path.GetExtension(dosyaYolu) == ".xlsx")
                {
                    DosyaOlustur();
                }
                else
                {
                    MessageBox.Show("Lütfen Excel Formatında Bir Dosya Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ExcelCek();
                ToplamlarTT();
            }

        }
        void ToplamlarTT()
        {
            double toplam = 0;
            for (int i = 0; i < DtgTTList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgTTList.Rows[i].Cells[6].Value);
            }
            LblTTasitTanima.Text = toplam.ToString("C2");
            LblTopmaSayi.Text = DtgTTList.RowCount.ToString();
        }
        void ExcelCek()
        {
            DataTable table = FrmHelper.GetDataTableFromExcel(TxtDosyaYolu.Text.Replace(" ", ""), "CR_YakitAlimDetayRaporu");

            DtgTTList.DataSource = null;
            DtgTTList.DataSource = table;


           
            /*
            IXLWorkbook workbook = new XLWorkbook(TxtDosyaYolu.Text);
            IXLWorksheet worksheet = workbook.Worksheet("CR_YakitAlimDetayRaporu");

            var range = worksheet.RangeUsed();
            double toplamTutar = 0;
            foreach (IXLRangeRow row in range.Rows())
            {
                toplamTutar += row.Cell("G").Value.ConDouble();
            }
            */
        }

        void DosyaOlustur()
        {

            IsAkisNo();
            IsAkisNoTasitTanima();
            isAkisNo = LblIsAkisNoTasit.Text;
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\SATIN ALMA\";
            string subdir2 = @"Z:\DTS\SATIN ALMA\YAKIT FİRMA DÖKÜMLERİ\";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(subdir))
            {
                Directory.CreateDirectory(subdir);
            }
            if (!Directory.Exists(subdir2))
            {
                Directory.CreateDirectory(subdir2);
            }

            dosyaYolu = subdir2 + isAkisNo;
            Directory.CreateDirectory(dosyaYolu);

            // Directory.CreateDirectory(subdir + isAkisNo);

            kaynakdosyaismi = openFileDialog1.SafeFileName.ToString();
            alinandosya = openFileDialog1.FileName.ToString();

            if (File.Exists(dosyaYolu + "\\" + kaynakdosyaismi))
            //if (false)
            {
                MessageBox.Show("Belirtilen Klasörde " + kaynakdosyaismi + " Adıyla Zaten Bir Dosya Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Copy(alinandosya, dosyaYolu + "\\" + kaynakdosyaismi);
                fileNames.Add(alinandosya);
                webBrowser3.Navigate(dosyaYolu);
                TxtDosyaYolu.Text = alinandosya;
                dosyaKontrol2 = true;
            }
        }

        private void BtnKaydetTT_Click(object sender, EventArgs e)
        {
            if (DtgTTList.RowCount==0)
            {
                MessageBox.Show("Lütfen Öncelikle Excel Dosyanızdan Araç Yakıt Verilerini Tabloya Çekiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstoyr Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                foreach (DataGridViewRow item in DtgTTList.Rows)
                {
                    string donem = FrmHelper.DonemControl(item.Cells[7].Value.ConTime());

                    AracZimmeti aracZimmeti = aracZimmetiManager.Get(item.Cells[2].Value.ToString());
                    string aracSiparisNo = "";
                    string zimetliPersonel = "";
                    if (aracZimmeti != null)
                    {
                        aracSiparisNo = aracZimmeti.SiparisNo;
                        zimetliPersonel = aracZimmeti.PersonelAd;
                    }

                    YakitDokum yakitDokum = new YakitDokum(LblIsAkisNoTasit.Text.ConInt(), "PETROL OFİSİ", donem, item.Cells[7].Value.ConTime(), item.Cells[2].Value.ToString(), aracSiparisNo,
                        item.Cells[5].Value.ConDouble(), item.Cells[6].Value.ConDouble(), dosyaYolu, zimetliPersonel);
                    
                    string mesaj = yakitDokumManager.AddTasitTanima(yakitDokum);
                    if (mesaj!="OK")
                    {
                        MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                webBrowser3.Navigate("");
                DtgTTList.DataSource = null;
                //DtgTTList.Rows.Clear();
                TxtDosyaYolu.Clear();
                IsAkisKontrolsuzGuncelle();
                IsAkisNo();
                IsAkisNoTasitTanima();
            }
        }
        

        void KalemleriKaydet()
        {
            if (AdvList.RowCount != 0)
            {
                foreach (DataGridViewRow item in AdvList.Rows)
                {
                    YakitDokum yakitDokum = new YakitDokum(
                        item.Cells["AkisNoList"].Value.ConInt(),
                        item.Cells["FirmaList"].Value.ToString(),
                        item.Cells["DonemList"].Value.ToString(),
                        item.Cells["TarihList"].Value.ConTime(),
                        item.Cells["DefterNoList"].Value.ToString(),
                        item.Cells["SiraNoList"].Value.ToString(),
                        item.Cells["FisNoList"].Value.ToString(),
                        item.Cells["PersonelList"].Value.ToString(),
                        item.Cells["PlakaList"].Value.ToString(),
                        item.Cells["AracSiparisNoList"].Value.ToString(),
                        item.Cells["LitreFiyatiList"].Value.ConDouble(),
                        item.Cells["AlinanLitreList"].Value.ConDouble(),
                        item.Cells["ToplamTutarList"].Value.ConDouble(),
                        dosyaYolu,
                        siparisNo);
                    yakitDokumManager.Add(yakitDokum);
                }
            }
        }
        void KalemleriKaydetTasit()
        {
            if (AdvListTasit.RowCount != 0)
            {
                foreach (DataGridViewRow item in AdvListTasit.Rows)
                {
                    YakitDokum yakitDokum = new YakitDokum(
                        item.Cells["AkisNoTasit"].Value.ConInt(),
                        item.Cells["FirmaListTasit"].Value.ToString(),
                        item.Cells["DonemListTasit"].Value.ToString(),
                        item.Cells["TarihListTasit"].Value.ConTime(),
                        item.Cells["PlakaListTasit"].Value.ToString(),
                        item.Cells["SiparisNoListTasit"].Value.ToString(),
                        item.Cells["ToplamListTasit"].Value.ConDouble(),
                        dosyaYolu,
                        siparisNo);
                    yakitDokumManager.AddTasit(yakitDokum);
                }
            }
        }

        string Kontrol()
        {
            if (CmbFirma.Text == "")
            {
                return "Lütfen FİRMA Bilgisini Giriniz.";
            }
            
            if (TxtDefterNo.Text == "")
            {
                return "Lütfen YAKIT ALIM DEFTER NO Bilgisini Giriniz.";
            }
            if (TxtSiraNo.Text == "")
            {
                return "Lütfen YAKIT ALIM SIRA NO Bilgisini Giriniz.";
            }
            if (TxtFisNo.Text == "")
            {
                return "Lütfen FİŞ NO Bilgisini Giriniz.";
            }
            if (CmbPersoneller.Text == "")
            {
                return "Lütfen YAKIT ALAN PERSONEL Bilgisini Giriniz.";
            }
            if (CmbPlaka.Text == "")
            {
                return "Lütfen ARAÇ PLAKASI Bilgisini Giriniz.";
            }
            if (TxtLitreFiyati.Text == "")
            {
                return "Lütfen LİTRE FİYATI Bilgisini Giriniz.";
            }
            if (TxtAlinanLitre.Text == "")
            {
                return "Lütfen ALINAN LİTRE Bilgisini Giriniz.";
            }
            return "OK";
        }
        string KontrolTasit()
        {
            if (CmbFirmaTasit.Text == "")
            {
                return "Lütfen FİRMA Bilgisini Giriniz.";
            }
            if (TxtAlinanDonemTasit.Text == "")
            {
                return "Lütfen ALINAN DÖNEM Bilgisini Giriniz.";
            }
            if (CmbPlakaTasit.Text == "")
            {
                return "Lütfen PLAKA Bilgisini Giriniz.";
            }
            if (TxtToplamTutar.Text == "")
            {
                return "Lütfen TOPLAM TUTAR Bilgisini Giriniz.";
            }
            return "OK";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (dosyaKontrol == false)
            {
                MessageBox.Show("Lütfen Öncelikle Dosya Ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (AdvList.RowCount == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Listeye Bir Kayıt Ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstedğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                siparisNo = Guid.NewGuid().ToString();

                string donem = FrmHelper.DonemControl(DtTarih.Value);

                YakitDokum yakitDokum = new YakitDokum(LblIsAkisNo.Text.ConInt(), CmbFirma.Text, donem, ToplamLitre.Text.ConDouble(), LblGenelTop.Text.ConDouble(), dosyaYolu, siparisNo, "ANLAŞMALI PETROL");

                string mesaj = yakitDokumManager.AnaAdd(yakitDokum);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                KalemleriKaydet();
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAkisNo();
                IsAkisNoTasitTanima();
                Temizle();
            }
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < AdvList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(AdvList.Rows[i].Cells[12].Value);
            }
            LblGenelTop.Text = toplam.ToString();
        }
        void ToplamlarTasit()
        {
            double toplam = 0;
            for (int i = 0; i < AdvListTasit.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(AdvListTasit.Rows[i].Cells[6].Value);
            }
            LblGenelTopTasit.Text = toplam.ToString();
        }
        void ToplamlarLitre()
        {
            double toplam = 0;
            for (int i = 0; i < AdvList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(AdvList.Rows[i].Cells[11].Value);
            }
            ToplamLitre.Text = toplam.ToString();
        }


    }
}
