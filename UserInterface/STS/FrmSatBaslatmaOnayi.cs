using Business.Concreate;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity;
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

namespace UserInterface.STS
{
    public partial class FrmSatBaslatmaOnayi : Form
    {
        SatDataGridview1Manager satDataGridview1Manager;
        SatIslemAdimlariManager satIslemAdimlariManager;
        SatNoManager satNoManager;
        SatDataGridview1 dataGridview1;
        SatinAlinacakMalManager satinAlinacakMalzemeler;
        List<SatDataGridview1> satDatas;
        List<SatinAlinacakMalzemeler> satinAlinacakMalzemelers;
        ButceKoduManager butceKoduManager;
        ReddedilenlerManager reddedilenlerManager;
        SatinAlinacakMalManager satinAlinacakMalManager;
        ReddedilenMalzemeManager reddedilenMalzemeManager;
        SatOnayTarihiManager satOnayTarihiManager;
        public object[] infos;
        public bool gorevAtama = false;
        string islemyapan, masrafYeri, talepeden, bolum, usbolgesi, abfno, gerekce, siparisNo, dosya, islem, mesaj, hedefdosya, kaynakdosya, rednedeni, onaydurum, yapilanislem, islemAdimi, donem, durum, butceKodu;


        int id, uctekilf = 1, index, satNo, satno, formNo;
        DateTime istenentarih, tarih;

        public FrmSatBaslatmaOnayi()
        {
            InitializeComponent();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            satIslemAdimlariManager = SatIslemAdimlariManager.GetInstance();
            satNoManager = SatNoManager.GetInstance();
            satinAlinacakMalzemeler = SatinAlinacakMalManager.GetInstance();
            butceKoduManager = ButceKoduManager.GetInstance();
            reddedilenlerManager = ReddedilenlerManager.GetInstance();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            reddedilenMalzemeManager = ReddedilenMalzemeManager.GetInstance();
            satOnayTarihiManager = SatOnayTarihiManager.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSatBaslatma"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }

        private void FrmSatBaslatmaOnayi_Load(object sender, EventArgs e)
        {
            DataDisplay();
            FillInfos();
            ButceKoduKalemi();

        }
        public void YenilecekVeri()
        {
            DataDisplay();
            FillInfos();
            ButceKoduKalemi();
        }
        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplay();
            FillInfos();
            ButceKoduKalemi();
        }
        void FillInfos()
        {
            islemyapan = infos[1].ToString();
        }
        void ButceKoduKalemi()
        {
            CmbButceKodu.DataSource = butceKoduManager.GetList();
            CmbButceKodu.ValueMember = "Id";
            CmbButceKodu.DisplayMember = "Butcekodu";
            CmbButceKodu.SelectedValue = 0;
        }
        private void CmbFaturaFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = CmbFaturaFirma.SelectedIndex;
            CmbIlgiliKisi.SelectedIndex = index;
            CmbMasYeri.SelectedIndex = index;
        }
        void DataDisplay()
        {
            satDatas = satDataGridview1Manager.GetList("Basla");
            dataBinder.DataSource = satDatas.ToDataTable();
            DtgSatOlusturan.DataSource = dataBinder;

            //DtgSatOlusturan.DataSource = satDataGridview1Manager.GetList("Ön Onay");

            DtgSatOlusturan.Columns["Id"].Visible = false;
            DtgSatOlusturan.Columns["Satno"].Visible = false;
            DtgSatOlusturan.Columns["Formno"].HeaderText = "İŞ AKIŞ NO";
            DtgSatOlusturan.Columns["Talepeden"].HeaderText = "İSTEKTE BULUNAN";
            DtgSatOlusturan.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgSatOlusturan.Columns["Usbolgesi"].HeaderText = "ÜS BÖLGESİ";
            DtgSatOlusturan.Columns["Tarih"].HeaderText = "İSTENEN TARİH";
            DtgSatOlusturan.Columns["Gerekce"].HeaderText = "GEREKÇE";
            DtgSatOlusturan.Columns["Abfformno"].HeaderText = "ABF FORM NO";
            DtgSatOlusturan.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ NO";
            DtgSatOlusturan.Columns["PersonelId"].Visible = false;
            DtgSatOlusturan.Columns["Burcekodu"].Visible = false;
            DtgSatOlusturan.Columns["Satbirim"].Visible = false;
            DtgSatOlusturan.Columns["Harcamaturu"].Visible = false;
            DtgSatOlusturan.Columns["Faturafirma"].Visible = false;
            DtgSatOlusturan.Columns["Ilgilikisi"].Visible = false;
            DtgSatOlusturan.Columns["Masyerino"].Visible = false;
            DtgSatOlusturan.Columns["SiparisNo"].Visible = false;
            DtgSatOlusturan.Columns["DosyaYolu"].Visible = false;
            DtgSatOlusturan.Columns["Uctekilf"].Visible = false;
            DtgSatOlusturan.Columns["FirmaBilgisi"].Visible = false;
            DtgSatOlusturan.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDEN PERSONEL";
            DtgSatOlusturan.Columns["PersonelSiparis"].HeaderText = "PERSONEL SİPARİŞ";
            DtgSatOlusturan.Columns["Unvani"].HeaderText = "PERSONEL ÜNVANI";
            DtgSatOlusturan.Columns["PersonelMasYerNo"].HeaderText = "PERSONEL MASRAF YERİ NO";
            DtgSatOlusturan.Columns["PersonelMasYeri"].HeaderText = "PERSONEL MASRAF YERİ";
            DtgSatOlusturan.Columns["BelgeTuru"].Visible = false;
            DtgSatOlusturan.Columns["BelgeNumarasi"].Visible = false;
            DtgSatOlusturan.Columns["BelgeTarihi"].Visible = false;
            DtgSatOlusturan.Columns["IslemAdimi"].HeaderText = "BULUNDUĞU İŞLEM ADIMI";


            TxtTop.Text = DtgSatOlusturan.RowCount.ToString();
        }
        private void Temizle()
        {
            stn1.Clear(); t1.Clear(); m1.Clear(); b1.Clear(); stn2.Clear(); t2.Clear(); m2.Clear(); b2.Clear();
            stn3.Clear(); t3.Clear(); m3.Clear(); b3.Clear(); stn4.Clear(); t4.Clear(); m4.Clear(); b4.Clear();
            stn5.Clear(); t5.Clear(); m5.Clear(); b5.Clear(); stn6.Clear(); t6.Clear(); m6.Clear(); b6.Clear();
            stn7.Clear(); t7.Clear(); m7.Clear(); b7.Clear(); stn8.Clear(); t8.Clear(); m8.Clear(); b8.Clear();
            stn9.Clear(); t9.Clear(); m9.Clear(); b9.Clear(); stn10.Clear(); t10.Clear(); m10.Clear(); b10.Clear();
            CmbButceKodu.SelectedValue = 0; CmbSatBirim.SelectedIndex = 0; CmbHarcamaTuru.SelectedIndex = 0; CmbFaturaFirma.SelectedIndex = 0;
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

            webBrowser1.Navigate(dosya);
        }
        string satOlusturmaTuru = "", talepEdenPersonel = "", personelSiparis = "", unvani = "", personelMasTeriNo = "", personelMasrafYeri = "", firmaBilgisi = "", islemAdimiGuncelle = "", satOlusuturmaTuru = "";
        int idRed, personelIdGuncelle, personelId, ucTeklif;
        private void DtgSatOlusturan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgSatOlusturan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            idRed = DtgSatOlusturan.CurrentRow.Cells["Id"].Value.ConInt();
            formNo = DtgSatOlusturan.CurrentRow.Cells["Formno"].Value.ConInt();
            masrafYeri = DtgSatOlusturan.CurrentRow.Cells["Masrafyeri"].Value.ToString();
            bolum = DtgSatOlusturan.CurrentRow.Cells["Bolum"].Value.ToString();
            talepeden = DtgSatOlusturan.CurrentRow.Cells["Talepeden"].Value.ToString();
            usbolgesi = DtgSatOlusturan.CurrentRow.Cells["Usbolgesi"].Value.ToString();
            abfno = DtgSatOlusturan.CurrentRow.Cells["Abfformno"].Value.ToString();
            istenentarih = DtgSatOlusturan.CurrentRow.Cells["Tarih"].Value.ConDate();
            donem = DtgSatOlusturan.CurrentRow.Cells["Donem"].Value.ToString();
            talepEdenPersonel = DtgSatOlusturan.CurrentRow.Cells["TalepEdenPersonel"].Value.ToString();
            personelSiparis = DtgSatOlusturan.CurrentRow.Cells["PersonelSiparis"].Value.ToString();
            unvani = DtgSatOlusturan.CurrentRow.Cells["Unvani"].Value.ToString();
            personelMasTeriNo = DtgSatOlusturan.CurrentRow.Cells["PersonelMasYerNo"].Value.ToString();
            personelMasrafYeri = DtgSatOlusturan.CurrentRow.Cells["PersonelMasYeri"].Value.ToString();
            gerekce = DtgSatOlusturan.CurrentRow.Cells["Gerekce"].Value.ToString();
            dosya = DtgSatOlusturan.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            siparisNo = DtgSatOlusturan.CurrentRow.Cells["SiparisNo"].Value.ToString();
            personelIdGuncelle = DtgSatOlusturan.CurrentRow.Cells["PersonelId"].Value.ConInt();
            islemAdimi = DtgSatOlusturan.CurrentRow.Cells["IslemAdimi"].Value.ToString();
            satno = DtgSatOlusturan.CurrentRow.Cells["Satno"].Value.ConInt();
            satOlusturmaTuru = DtgSatOlusturan.CurrentRow.Cells["SatOlusturmaTuru"].Value.ToString();
            personelId = DtgSatOlusturan.CurrentRow.Cells["PersonelId"].Value.ConInt();
            ucTeklif = DtgSatOlusturan.CurrentRow.Cells["Uctekilf"].Value.ConInt();
            firmaBilgisi = DtgSatOlusturan.CurrentRow.Cells["FirmaBilgisi"].Value.ToString();
            satOlusuturmaTuru = DtgSatOlusturan.CurrentRow.Cells["SatOlusturmaTuru"].Value.ToString();
            try
            {
                webBrowser1.Navigate(dosya);
            }
            catch (Exception)
            {
                return;
            }
            islemAdimiGuncelle = DtgSatOlusturan.CurrentRow.Cells["IslemAdimi"].Value.ToString();
            TxtAciklama.Text = gerekce;
            satinAlinacakMalzemelers = satinAlinacakMalManager.GetList(siparisNo);
            FillTools();
        }
        /*void MalzemeList()
        {
            fiyatTeklifiAls = fiyatTeklifiAlManager.GetList("Gönderildi", siparisNo);
        }*/
        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            FrmButceKoduKalemi frmButceKoduKalemi = new FrmButceKoduKalemi();
            frmButceKoduKalemi.Show();
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
        private void btnReddet_Click(object sender, EventArgs e)
        {
            if (DtgSatOlusturan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DialogResult dr = MessageBox.Show(formNo + " Nolu SAT BAŞLATMA ONAYI İşlemini Reddetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                satDataGridview1Manager.SatRed(siparisNo, rednedeni); // SAT DURUMU REDDEDİLDİ YAPILDI.
                satinAlinacakMalManager.SatDurumRed(siparisNo); // MALZEMELERİN DURUMU RED YAPILDI.

                yapilanislem = "SAT BAŞLATMA ONAYI İŞLEMİ: REDDEDİLDİ.";
                tarih = DateTime.Now;

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, islemyapan, tarih.ConDate());
                satIslemAdimlariManager.Add(satIslemAdimlari);

                yapilanislem = "SAT RED GEREKÇESİ:" + rednedeni;
                SatIslemAdimlari satIslemAdimlari2 = new SatIslemAdimlari(siparisNo, yapilanislem, islemyapan, tarih.ConDate());
                satIslemAdimlariManager.Add(satIslemAdimlari2);

                DataDisplay();
                Temizle();
                webBrowser1.Navigate("");
                FrmAnaSayfa frmAnaSayfa = new FrmAnaSayfa();
                frmAnaSayfa.ToplamSayilar();

                #region ReddedilenlerEskiKod
                /*Reddedilenler reddedilenler = new Reddedilenler(formNo, satno, masrafYeri, talepeden, bolum, usbolgesi, abfno, istenentarih, gerekce, siparisNo, dosya, rednedeni, "Basla", "Alınmadı", donem, personelId, CmbButceKodu.Text, CmbSatBirim.Text, CmbHarcamaTuru.Text, CmbFaturaFirma.Text, CmbIlgiliKisi.Text, CmbMasYeri.Text, ucTeklif, "BELIRLENMEDI", talepEdenPersonel, personelSiparis, unvani, personelMasTeriNo, islemAdimiGuncelle, satOlusuturmaTuru);
                string mesaj = reddedilenlerManager.Add(reddedilenler);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                ReddedilenMalzemeEkle();

                satDataGridview1Manager.Delete(id);
                satinAlinacakMalManager.Delete(siparisNo);

                onaydurum = "Reddildi.";
                yapilanislem = "SAT BAŞLATMA ONAYI İŞLEMİ: REDDEDİLDİ.";
                tarih = DateTime.Now;

                SatIslemAdimlari satIslemAdimlari = new SatIslemAdimlari(siparisNo, yapilanislem, islemyapan, tarih.ConTime());
                satIslemAdimlariManager.Add(satIslemAdimlari);

                MessageBox.Show("Reddetme İşlemi Başarıyla Gerçekleşmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

                //Task.Factory.StartNew(() => MailSendMetot());
                DataDisplay();
                Temizle();
                TxtTop.Text = DtgSatOlusturan.RowCount.ToString();
                webBrowser1.Navigate("");
                */
                #endregion
            }
        }
        void GorevAta()
        {
            

            FrmGorevAta frmGorevAta = new FrmGorevAta();
            frmGorevAta.gorevinTanimi = "SAT Tekliflerinin Alınması VE DTS Sistemine Kaydedilmesi.";
            frmGorevAta.islemAdimi = islemAdimi;
            frmGorevAta.sayfa = "SAT BAŞLATMA ONAYI";
            frmGorevAta.ShowDialog();
        }
        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (DtgSatOlusturan.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            DialogResult dr = MessageBox.Show(formNo + " Nolu SAT İçin Başlatma Onayı Vermek İstediğinize Emin Misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                /*GorevAta();

                if (gorevAtama==false)
                {
                    MessageBox.Show("Lütfen Öncelikle Görev Atama İşlemini Gerçekleştiriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }*/

                
                DialogResult dialog = MessageBox.Show("Ön Onay Yetkilisi:\n\nÖn Onaya gelmiş olan bu satın alma işlemi için malzemenin teknik dökümanlarına " +
                "uygunluğunu onaylamış, malzeme ihtiyacını teyit ve kabul etmiş olacaksınız.\n\nBu satın alma işlemi için piyasa fiyat araştırmasının " +
                "yapılarak uygun malzeme ve uygun fiyatın araştırılması üzere en az 3 firmadan fiyat teklifinin yazılı olarak istenmesi gerekmektedir.\n\n" +
                "Bu işlem için en az 3 firmadan fiyat teklifi alınmasını onaylıyor musunuz?", "BİLGİLENDİRME", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialog == DialogResult.No)
                {
                    uctekilf = 0;
                    islem = "SAT BAŞLATMA ONAYI VERİLDİ.(TEKLİFSİZ SAT)"; // TEKLİFSİZ

                    SatIslemAdimlari satIslem2 = new SatIslemAdimlari(siparisNo, islem, islemyapan, DateTime.Now);
                    satIslemAdimlariManager.Add(satIslem2);
                }
                /*if (satbirim == "BSRN GN.MDL.SATIN ALMA")
                {
                    satDataGridview1Manager.SatFirmaBilgisiGuncelle(siparisNo);
                    satDataGridview1Manager.SatDurumGnlMdr(siparisNo);
                }*/

                DosyaAdiDegistir();
                satDataGridview1Manager.DurumGuncelleOnay(siparisNo);

                if (uctekilf != 0)
                {
                    islem = "SAT BAŞLATMA ONAYI VERİLDİ.(TEKLİF ALINACAK SAT)"; // TEKLİFLİ SAT

                    SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, islem, islemyapan, DateTime.Now);
                    satIslemAdimlariManager.Add(satIslem);
                }
                /*if (satbirim == "BSRN GN.MDL.SATIN ALMA") 
                {
                    satDataGridview1Manager.SatDurumGnlMdr(siparisNo);
                    islem = "SAT BAŞLATMA ONAYI VERİLDİ.(TEKLİF ALINACAK SAT)"; // TEKLİFLİ SAT

                    SatIslemAdimlari satIslem = new SatIslemAdimlari(siparisNo, islem, islemyapan, DateTime.Now);
                    satIslemAdimlariManager.Add(satIslem);
                }*/

                islemAdimi = "FİYAT TEKLİFİ AL";
                dataGridview1 = null;
                
                dataGridview1 = new SatDataGridview1(satNo, CmbButceKodu.Text, CmbSatBirim.Text, CmbHarcamaTuru.Text, CmbFaturaFirma.Text, CmbIlgiliKisi.Text, CmbMasYeri.Text, siparisNo, uctekilf, hedefdosya, islemAdimi);
                mesaj = satDataGridview1Manager.Update(dataGridview1);

                /*islem = "SAT BAŞLATMA ONAYI VERİLDİ.(TEKLİF ALINACAK SAT)"; // TEKLİFLİ SAT

                SatIslemAdimlari satIslem2 = new SatIslemAdimlari(siparisNo, islem, islemyapan, DateTime.Now);
                satIslemAdimlariManager.Add(satIslem2);*/
                SatBaslamaTarihiKayit();
                if (mesaj != " SAT Ön Onay İşlemi Başarıyla Tamamlandı.")
                {
                    MessageBox.Show(mesaj, "Hata");
                    return;
                }
                onaydurum = "Onaylandı.";
                DataDisplay();
                Temizle();
                //Task.Factory.StartNew(() => MailSendMetot());
                TxtTop.Text = DtgSatOlusturan.RowCount.ToString();
                webBrowser1.Navigate("");
            }
        }
        void SatBaslamaTarihiKayit()
        {
            SatOnayTarihi satOnayTarihi = new SatOnayTarihi(siparisNo);
            satOnayTarihiManager.UpdateBaslama(satOnayTarihi);
        }
        void DosyaAdiDegistir()
        {
            /*string root = @"C:\STS";
            string subdir = @"C:\STS\GEÇİCİ SAT DOSYALARI\";
            string hedef = @"C:\STS\SAT DOSYALARI\";*/
            string root = @"Z:\DTS";
            string hedef = @"Z:\DTS\SATIN ALMA\SAT DOSYALARI\";
            string subdir = @"Z:\DTS\SATIN ALMA\GEÇİCİ SAT DOSYALARI\";
            if (!Directory.Exists(root))
            {
                MessageBox.Show(satno + " SAT Form numarasının dosyası bulunamadı.");
                return;
            }
            if (!Directory.Exists(subdir))
            {
                MessageBox.Show(satno + " SAT Form numarasının dosyası bulunamadı.");
                return;
            }
            kaynakdosya = subdir + formNo;
            if (!Directory.Exists(kaynakdosya))
            {
                MessageBox.Show(satno + " SAT Form numarasının dosyası bulunamadı.");
                hedefdosya = dosya;
                return;
            }
            if (!Directory.Exists(hedef))
            {
                Directory.CreateDirectory(hedef);

            }

            satNo = satNoManager.Add(new SatNo(siparisNo));
            //int outValue = 0;
            /*if (!int.TryParse(satNo, out outValue))
            {
                MessageBox.Show("Klasör No Bulunamadı");
                return;
            }*/

            hedefdosya = hedef + satNo;
            Directory.CreateDirectory(hedefdosya);

            foreach (string item in Directory.GetFiles(kaynakdosya, "*.*", SearchOption.TopDirectoryOnly))
            {
                string newPath = item.Replace(formNo.ToString(), satNo.ToString());
                newPath = newPath.Replace("GEÇİCİ SAT DOSYALARI", "SAT DOSYALARI");
                File.Copy(item, newPath, true);
            }

            // C:\STS\GEÇİCİ SAT DOSYALARI\773438838\88.pdf
            // C:\STS\SAT Dosyaları\20210183\88.pdf

            Directory.Delete(kaynakdosya, true);
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
            MailSend("SAT Başlatma Onayı İşlemi ", "Merhaba; \n\n" + satno + " Numaralı SAT Kaydı, Sat Başlatma Onayı Aşamasında " + islemyapan +
                " tarafından " + onaydurum + "\n\nİyi Çalışmalar.", new List<string>() { "resulgunes@mubvan.net" });
        }
        #region KeyPress
        private void stn2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void stn10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void t10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

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

        private void stn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion
    }
}
