using Business.Concreate;
using Entity;
using DataAccess.Concreate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;
using Entity.STS;
using Business.Concreate.STS;

namespace UserInterface.STS
{
    public partial class FrmSatOnOnay : Form
    {
        SatinAlinacakMalManager satinAlinacakMalManager;
        SatDataGridview1Manager satDataGridview1Manager;
        SatDataGridview1 dataGridview1;
        SatNoManager satNoManager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        ReddedilenlerManager reddedilenlerManager;
        ButceKoduManager butceKoduManager;
        ReddedilenMalzemeManager reddedilenMalzemeManager;
        List<SatinAlinacakMalzemeler> satinAlinacakMalzemelers;
        List<SatDataGridview1> satDatas;
        List<SatNo> satNos;
        public object[] infos;
        public object[] infos1;
        public object[] infos2;
        string siparisNo, masrafyerino, onaydurum, islemyapan, yapilanislem, tarih, talepeden, bolum, projekodu, usbolgesi, gerekce, dosya, rednedeni, abfno, hedefdosya, islem;
        int uctekilf = 1, id, formno, satno;

        DateTime istenentarih;
        int index;
        public FrmSatOnOnay()
        {
            InitializeComponent();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            reddedilenlerManager = ReddedilenlerManager.GetInstance();
            butceKoduManager = ButceKoduManager.GetInstance();
            reddedilenMalzemeManager = ReddedilenMalzemeManager.GetInstance();
        }

        private void FrmSatOnOnay_Load(object sender, EventArgs e)
        {
            FillInfos();
            DataDisplay();
            TxtTop.Text = DtgSatOlusturan.RowCount.ToString();
           // webBrowser1.Navigate("‪C:\\kitli");
        }

        void FillInfos()
        {
            islemyapan = infos[1].ToString();
        }

        void DataDisplay()
        {
            satDatas = satDataGridview1Manager.GetList("Ön Onay", infos[0].ConInt());
            dataBinder.DataSource = satDatas.ToDataTable();
            DtgSatOlusturan.DataSource = dataBinder;

            //DtgSatOlusturan.DataSource = satDataGridview1Manager.GetList("Ön Onay");

            DtgSatOlusturan.Columns["Id"].Visible = false;
            DtgSatOlusturan.Columns["Satno"].Visible = false;
            DtgSatOlusturan.Columns["PersonelId"].Visible = false;
            DtgSatOlusturan.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgSatOlusturan.Columns["Talepeden"].HeaderText = "İSTEKTE BULUNAN";
            DtgSatOlusturan.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgSatOlusturan.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgSatOlusturan.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgSatOlusturan.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgSatOlusturan.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgSatOlusturan.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgSatOlusturan.Columns["Burcekodu"].Visible = false;
            DtgSatOlusturan.Columns["Satbirim"].Visible = false;
            DtgSatOlusturan.Columns["Harcamaturu"].Visible = false;
            DtgSatOlusturan.Columns["Faturafirma"].Visible = false;
            DtgSatOlusturan.Columns["Ilgilikisi"].Visible = false;
            DtgSatOlusturan.Columns["Masyerino"].Visible = false;
            DtgSatOlusturan.Columns["SiparisNo"].Visible = false;
            DtgSatOlusturan.Columns["DosyaYolu"].Visible = false;
            DtgSatOlusturan.Columns["Uctekilf"].Visible = false;
        }

        private void Temizle()
        {
            stn1.Clear(); t1.Clear(); m1.Clear(); b1.Clear(); stn2.Clear(); t2.Clear(); m2.Clear(); b2.Clear();
            stn3.Clear(); t3.Clear(); m3.Clear(); b3.Clear(); stn4.Clear(); t4.Clear(); m4.Clear(); b4.Clear();
            stn5.Clear(); t5.Clear(); m5.Clear(); b5.Clear(); stn6.Clear(); t6.Clear(); m6.Clear(); b6.Clear();
            stn7.Clear(); t7.Clear(); m7.Clear(); b7.Clear(); stn8.Clear(); t8.Clear(); m8.Clear(); b8.Clear();
            stn9.Clear(); t9.Clear(); m9.Clear(); b9.Clear(); stn10.Clear(); t10.Clear(); m10.Clear(); b10.Clear();

        }

        private void FillTools()
        {
            Temizle();

            if (satinAlinacakMalzemelers == null)

            {
                return;
            }

            if (satinAlinacakMalzemelers.Count == 0)
            {
                return;
            }

            if (satinAlinacakMalzemelers.Count > 0)
            {
                SatinAlinacakMalzemeler item = satinAlinacakMalzemelers[0];
                stn1.Text = item.Stn1;
                t1.Text = item.T1;
                m1.Text = item.M1.ToString();
                b1.Text = item.B1;
            }

            if (satinAlinacakMalzemelers.Count > 1)
            {
                SatinAlinacakMalzemeler item3 = satinAlinacakMalzemelers[1];
                stn2.Text = item3.Stn1;
                t2.Text = item3.T1;
                m2.Text = item3.M1.ToString();
                b2.Text = item3.B1;
            }

            if (satinAlinacakMalzemelers.Count > 2)
            {
                SatinAlinacakMalzemeler item3 = satinAlinacakMalzemelers[2];
                stn3.Text = item3.Stn1;
                t3.Text = item3.T1;
                m3.Text = item3.M1.ToString();
                b3.Text = item3.B1;
            }

            if (satinAlinacakMalzemelers.Count > 3)
            {
                SatinAlinacakMalzemeler item4 = satinAlinacakMalzemelers[3];
                stn4.Text = item4.Stn1;
                t4.Text = item4.T1;
                m4.Text = item4.M1.ToString();
                b4.Text = item4.B1;
            }

            if (satinAlinacakMalzemelers.Count > 4)
            {
                SatinAlinacakMalzemeler item5 = satinAlinacakMalzemelers[4];
                stn5.Text = item5.Stn1;
                t5.Text = item5.T1;
                m5.Text = item5.M1.ToString();
                b5.Text = item5.B1;
            }

            if (satinAlinacakMalzemelers.Count > 5)
            {


                SatinAlinacakMalzemeler item6 = satinAlinacakMalzemelers[5];
                stn6.Text = item6.Stn1;
                t6.Text = item6.T1;
                m6.Text = item6.M1.ToString();
                b6.Text = item6.B1;
            }

            if (satinAlinacakMalzemelers.Count > 6)
            {
                SatinAlinacakMalzemeler item7 = satinAlinacakMalzemelers[6];
                stn7.Text = item7.Stn1;
                t7.Text = item7.T1;
                m7.Text = item7.M1.ToString();
                b7.Text = item7.B1;
            }

            if (satinAlinacakMalzemelers.Count > 7)
            {

                SatinAlinacakMalzemeler item8 = satinAlinacakMalzemelers[7];
                stn8.Text = item8.Stn1;
                t8.Text = item8.T1;
                m8.Text = item8.M1.ToString();
                b8.Text = item8.B1;
            }

            if (satinAlinacakMalzemelers.Count > 8)
            {
                SatinAlinacakMalzemeler item9 = satinAlinacakMalzemelers[8];
                stn9.Text = item9.Stn1;
                t9.Text = item9.T1;
                m9.Text = item9.M1.ToString();
                b9.Text = item9.B1;
            }

            if (satinAlinacakMalzemelers.Count > 9)
            {
                SatinAlinacakMalzemeler item10 = satinAlinacakMalzemelers[9];
                stn10.Text = item10.Stn1;
                t10.Text = item10.T1;
                m10.Text = item10.M1.ToString();
                b10.Text = item10.B1;
            }

            WebBrowser();
        }

        #region KeyPressCodes
        private void stn1_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void stn2_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void stn3_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void stn4_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void stn5_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void m1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void m10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void b10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn6_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void stn7_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void stn8_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void stn9_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\MAYıldırım\Desktop\ASL-001_MGÜB_BÜTÇE KALEMLERİ-2021.docx");
        }

        private void DtgSatOlusturan_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgSatOlusturan.FilterString;
            TxtTop.Text = DtgSatOlusturan.RowCount.ToString();
        }

        private void DtgSatOlusturan_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgSatOlusturan.SortString;
        }

        private void DtgSatOlusturan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgSatOlusturan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }

            id = DtgSatOlusturan.CurrentRow.Cells["Id"].Value.ConInt();
            formno = DtgSatOlusturan.CurrentRow.Cells["Formno"].Value.ConInt();
            satno = DtgSatOlusturan.CurrentRow.Cells["Satno"].Value.ConInt();
            masrafyerino = DtgSatOlusturan.CurrentRow.Cells["Masrafyeri"].Value.ToString();
            talepeden = DtgSatOlusturan.CurrentRow.Cells["Talepeden"].Value.ToString();
            bolum = DtgSatOlusturan.CurrentRow.Cells["Bolum"].Value.ToString();
            projekodu = DtgSatOlusturan.CurrentRow.Cells["Projekodu"].Value.ToString();
            usbolgesi = DtgSatOlusturan.CurrentRow.Cells["Usbolgesi"].Value.ToString();
            abfno = DtgSatOlusturan.CurrentRow.Cells["Abfformno"].Value.ToString();
            istenentarih = DtgSatOlusturan.CurrentRow.Cells["Tarih"].Value.ConTime();
            gerekce = DtgSatOlusturan.CurrentRow.Cells["Gerekce"].Value.ToString();
            siparisNo = DtgSatOlusturan.CurrentRow.Cells["SiparisNo"].Value.ToString();
            dosya = DtgSatOlusturan.CurrentRow.Cells["DosyaYolu"].Value.ToString();

            satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
            satNos = satNoManager.GetList(siparisNo);
            TxtGerekce.Text = gerekce;

            FillTools();
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay();
            TxtTop.Text = DtgSatOlusturan.RowCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatOnOnay"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void stn10_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void t1_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void t2_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void t3_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void t4_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void t5_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void t6_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void t7_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void t8_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void t9_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }

        private void t10_KeyPress(object sender, KeyPressEventArgs e) { e.Handled = true; }
        #endregion

        private void WebBrowser()
        {
            webBrowser1.Navigate(dosya);
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {

            if (DtgSatOlusturan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DialogResult dr = MessageBox.Show(formno + " Nolu SAT Ön Onay İşlemini Tamamamlamak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                /*FrmSatOnOnayVer Go = new FrmSatOnOnayVer();
                Go.ShowDialog();*/

                /*DialogResult dialog = MessageBox.Show("Ön Onay Yetkilisi:\n\nÖn Onaya gelmiş olan bu satın alma işlemi için malzemenin teknik dökümanlarına " +
                    "uygunluğunu onaylamış, malzeme ihtiyacını teyit ve kabul etmiş olacaksınız.\n\nBu satın alma işlemi için piyasa fiyat araştırmasının " +
                    "yapılarak uygun malzeme ve uygun fiyatın araştırılması üzere en az 3 firmadan fiyat teklifinin yazılı olarak istenmesi gerekmektedir.\n\n" +
                    "Bu işlem için en az 3 firmadan fiyat teklifi alınmasını onaylıyor musunuz?", "BİLGİLENDİRME", MessageBoxButtons.YesNo, MessageBoxIcon.Information);*/

                uctekilf = 0;
                islem = "SAT Ön Onaylama İşlemi: ONAYLANDI SAT Başlatma Onayı aşamasında Beklemede.";
                SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, islem, islemyapan, DateTime.Now);
                satIslemAdimlariManager.Add(satIslem);

                //DosyaAdiDegistir();
                satDataGridview1Manager.DurumGuncelleBaslamaOnay(siparisNo);
                dataGridview1 = null;
                /*dataGridview1 = new SatDataGridview1(satNo, CmbButceKodu.Text, CmbSatBirim.Text, CmbHarcamaTuru.Text, CmbFaturaFirma.Text, CmbIlgiliKisi.Text, CmbMasYeri.Text,siparisNo,uctekilf, hedefdosya);
                mesaj = satDataGridview1Manager.Update(dataGridview1);*/

                /*if (mesaj != " SAT Ön Onay İşlemi Başarıyla Tamamlandı.")
                {
                    MessageBox.Show(mesaj);
                    return;
                }*/

                onaydurum = "Onaylandı.";
                if (uctekilf != 0)
                {
                    yapilanislem = "SAT Ön Onaylama İşlemi: ONAYLANDI SAT Başlama Onayı Aşamasında Beklemede.";
                    SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, islemyapan, DateTime.Now);
                    satIslemAdimlariManager.Add(satIslemAdimlari);
                }

                DataDisplay();
                Temizle();
                //Task.Factory.StartNew(() => MailSendMetot());
                TxtTop.Text = DtgSatOlusturan.RowCount.ToString();
                webBrowser1.Navigate("");

            }
        }
        /*void DosyaAdiDegistir()
        {
            string root = @"C:\STS";
            string subdir = @"C:\STS\GEÇİCİ SAT DOSYALARI\";
            string hedef = @"C:\STS\SAT DOSYALARI\";
            //string root = @"Z:\DTS";
            //string hedef = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";
            //string subdir = @"Z:\DTS\SATIN ALMA\GEÇİCİ SAT DOSYALARI";
            if (!Directory.Exists(root))
            {
                MessageBox.Show(formNo + " SAT Form numarasının dosyası bulunamadı.");
                return;
            }
            if (!Directory.Exists(subdir))
            {
                MessageBox.Show(formNo + " SAT Form numarasının dosyası bulunamadı.");
                return;
            }
            kaynakdosya = subdir + formNo;
            if (!Directory.Exists(kaynakdosya))
            {
                MessageBox.Show(formNo + " SAT Form numarasının dosyası bulunamadı.");
                return;
            }
            if (!Directory.Exists(hedef))
            {
                Directory.CreateDirectory(hedef);

            }

            satNo = satNoManager.Add(new SatNo(siparisNo));
            int outValue = 0;
            if (!int.TryParse(satNo, out outValue))
            {
                MessageBox.Show("Klasör No Bulunamadı");
                return;
            }

            hedefdosya = hedef + satNo;
            Directory.CreateDirectory(hedefdosya);

            foreach (string item in Directory.GetFiles(kaynakdosya, "*.*", SearchOption.TopDirectoryOnly))
            {
                string newPath = item.Replace(formNo, satNo);
                newPath = newPath.Replace("GEÇİCİ SAT DOSYALARI", "SAT DOSYALARI");
                File.Copy(item, newPath, true);
            }

            // C:\STS\GEÇİCİ SAT DOSYALARI\773438838\88.pdf
            // C:\STS\SAT Dosyaları\20210183\88.pdf

            Directory.Delete(kaynakdosya, true);
        }*/

        private void btnReddet_Click(object sender, EventArgs e)
        {
            /*if (DtgSatOlusturan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DialogResult dr = MessageBox.Show(formno + " Nolu SAT Ön Onay İşlemini Reddetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                FrmSatOnOnayRed frmSatOnOnayRed = new FrmSatOnOnayRed();
                frmSatOnOnayRed.ShowDialog();
                rednedeni = Properties.Settings.Default.RedNedeni.ToString();
                if (rednedeni == "")
                {
                    MessageBox.Show("Lütfen Ret Nedenini Boş Geçmeyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Reddedilenler reddedilenler = new Reddedilenler(formno, satno, masrafyerino, talepeden, bolum,
                usbolgesi, abfno, istenentarih, gerekce, siparisNo, dosya, rednedeni,"");
                reddedilenlerManager.Add(reddedilenler);
                ReddedilenMalzemeEkle();

                satDataGridview1Manager.Delete(id);
                satinAlinacakMalManager.Delete(siparisNo);

                onaydurum = "Reddildi.";
                yapilanislem = "SAT Ön Onaylama İşlemi: REDDEDİLDİ";
                tarih = DateTime.Now.ToString();

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, islemyapan, tarih.ConTime());
                satIslemAdimlariManager.Add(satIslemAdimlari);

                MessageBox.Show("SAT Ön Onay İşlemi Tamamlanmıştır.");

                //Task.Factory.StartNew(() => MailSendMetot());
                DataDisplay();
                Temizle();
                TxtTop.Text = DtgSatOlusturan.RowCount.ToString();
                webBrowser1.Navigate("");
            }*/
        }
        void ReddedilenMalzemeEkle()
        {
            List<ReddedilenMalzeme> list = new List<ReddedilenMalzeme>();
            if (stn1.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(stn1.Text, t1.Text, m1.Text.ConInt(), b1.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (stn2.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(stn2.Text, t2.Text, m2.Text.ConInt(), b2.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (stn3.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(stn3.Text, t3.Text, m3.Text.ConInt(), b3.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (stn4.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(stn4.Text, t4.Text, m4.Text.ConInt(), b4.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (stn5.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(stn5.Text, t5.Text, m5.Text.ConInt(), b5.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (stn6.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(stn6.Text, t6.Text, m6.Text.ConInt(), b6.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (stn7.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(stn7.Text, t7.Text, m7.Text.ConInt(), b7.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (stn8.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(stn8.Text, t8.Text, m8.Text.ConInt(), b8.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (stn9.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(stn9.Text, t1.Text, m9.Text.ConInt(), b9.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (stn10.Text != "")
            {
                ReddedilenMalzeme reddedilen = new ReddedilenMalzeme(stn10.Text, t10.Text, m10.Text.ConInt(), b10.Text, siparisNo);
                list.Add(reddedilen);
            }
            if (list.Count == 0)
            {
                MessageBox.Show("Eleman Bulunamadı");
                return;
            }
            foreach (ReddedilenMalzeme item in list)
            {
                reddedilenMalzemeManager.Add(item);
            }
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
            MailSend("SAT Ön Onay İşlemi ", "Merhaba; \n\n" + masrafyerino + " Masraf Yeri Numaralı SAT Kaydı, Ön Onay Onay Aşamasında " + islemyapan +
                " tarafından " + onaydurum + "\n\nİyi Çalışmalar.", new List<string>() { "gulsahotaci@mubvan.net" });
        }
    }
}
