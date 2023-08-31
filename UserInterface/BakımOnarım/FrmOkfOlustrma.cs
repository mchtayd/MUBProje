using Business;
using Business.Concreate.BakimOnarim;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Presentation;
using Entity;
using Entity.BakimOnarim;
using Entity.Gecic_Kabul_Ambar;
using Microsoft.Office.Core;
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
    public partial class FrmOkfOlustrma : Form
    {
        IsAkisNoManager isAkisNoManager;
        DtfManager dtfManager;
        BolgeKayitManager bolgeKayitManager;
        MalzemeManager malzemeManager;
        OkfManager okfManager;
        DtfMaliyetManager dtfMaliyetManager;

        List<Malzeme> malzemeKayits;
        List<Malzeme> malzemeKayits2;

        bool start = false;
        public object[] infos;
        double sonuc, outValue, toplam = 0;
        string topfiyat, birlikAdresi, il, ilce, dosyaYolu, taslakYolu, bildirimNo = "";
        string yol = @"C:\DTS\Taslak\";
        string kaynak = @"Z:\DTS\BAKIM ONARIM\TASLAKLAR\";
        public FrmOkfOlustrma()
        {
            InitializeComponent();
            isAkisNoManager = IsAkisNoManager.GetInstance();
            dtfManager = DtfManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
            okfManager = OkfManager.GetInstance();
            dtfMaliyetManager = DtfMaliyetManager.GetInstance();
        }

        private void FrmOkfOlustrma_Load(object sender, EventArgs e)
        {
            IsAkisNo();
            UsBolgeleri();
            Tanim();
            FillMalzeme();
            TalepEden.Text = infos[1].ToString();
            LbKayitTarihi.Text=DateTime.Now.ToString("d");
            start = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageOKFOlusturma"]);
            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        void IsAkisNo()
        {
            isAkisNoManager.Update();
            IsAkisNo isAkis = isAkisNoManager.Get();
            LblIsAkisNo.Text = isAkis.Id.ToString();
        }
        void UsBolgeleri()
        {
            CmbBolgeAdi.DataSource = bolgeKayitManager.GetList();
            CmbBolgeAdi.ValueMember = "Id";
            CmbBolgeAdi.DisplayMember = "BolgeAdi";
            CmbBolgeAdi.SelectedValue = "";
        }
        void Tanim()
        {
            malzemeKayits = malzemeManager.GetList();
            CmbTanim.DataSource = malzemeKayits;
            CmbTanim.ValueMember = "Id";
            CmbTanim.DisplayMember = "Tanim";
            CmbTanim.SelectedValue = 0;
        }

        private void TxtBildirimNo_TextChanged(object sender, EventArgs e)
        {
            if (TxtAbfNo.Text.Length >= 6)
            {
                Okf okfDTS = okfManager.OkfArizaBilgileriDTS(TxtAbfNo.Text.ConInt());
                if (okfDTS == null)
                {
                    MessageBox.Show("Bu Abf Numarasına ait kayıt bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Temizle();
                    return;
                }
                CmbBolgeAdi.Text = okfDTS.UsBolgesi;
                CmbProjeKodu.Text = okfDTS.ProjeKodu;
                TxtStokNo.Text = okfDTS.UstStok;
                CmbTanim.Text = okfDTS.UstTanim;
                TxtSeriNo.Text = okfDTS.UstSeriNo;
                TxtBildirilenAriza.Text = okfDTS.BildirilenAriza.ToUpper();
                bildirimNo = okfDTS.BildirimNo;
                if (bildirimNo == null || bildirimNo == "")
                {
                    bildirimNo = okfDTS.OkfBildirimNo;
                }
                TxtABTelefon.Text = okfDTS.KomutanTel;
                TxtUsBolgesiKomutani.Text = okfDTS.UbKomutani;
                DtgArizaTarihi.Value = okfDTS.ArizaTarihi;
                il = okfDTS.Il;
                ilce = okfDTS.Ilce;
                birlikAdresi = okfDTS.BirlikAdresi;

                //if (okfDTS!=null)
                //{
                //    CmbBolgeAdi.Text = okfDTS.UsBolgesi;
                //    CmbProjeKodu.Text = okfDTS.ProjeKodu;
                //    TxtStokNo.Text = okfDTS.UstStok;
                //    CmbTanim.Text = okfDTS.UstTanim;
                //    TxtSeriNo.Text = okfDTS.UstSeriNo;
                //    TxtBildirilenAriza.Text = okfDTS.BildirilenAriza.ToUpper();
                //    bildirimNo = okfDTS.BildirimNo;
                //    if (bildirimNo==null || bildirimNo== "")
                //    {
                //        bildirimNo = okfDTS.OkfBildirimNo;
                //    }
                //    TxtABTelefon.Text = okfDTS.KomutanTel;
                //    TxtUsBolgesiKomutani.Text = okfDTS.UbKomutani;
                //    DtgArizaTarihi.Value = okfDTS.ArizaTarihi;
                //    il = okfDTS.Il;
                //    ilce = okfDTS.Ilce;
                //    birlikAdresi = okfDTS.BirlikAdresi;
                //}
                //else
                //{
                //    Okf okf = okfManager.OkfArizaBilgileri(TxtAbfNo.Text.ConInt());
                //    if (okf != null)
                //    {
                //        CmbBolgeAdi.Text = okf.UsBolgesi;
                //        CmbProjeKodu.Text = okf.ProjeKodu;
                //        TxtStokNo.Text = okf.UstStok;
                //        CmbTanim.Text = okf.UstTanim;
                //        TxtSeriNo.Text = okf.UstSeriNo;
                //        TxtBildirilenAriza.Text = okf.BildirilenAriza.ToUpper();
                //        bildirimNo = okf.BildirimNo;
                //        TxtABTelefon.Text = okf.KomutanTel;
                //        TxtUsBolgesiKomutani.Text = okf.UbKomutani;
                //        DtgArizaTarihi.Value = okf.ArizaTarihi;
                //        il = okf.Il;
                //        ilce = okf.Ilce;
                //        birlikAdresi = okf.BirlikAdresi;
                //    }
                //}

            }
        }

        private void CmbTanim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (CmbTanim.SelectedIndex == -1)
            {
                TxtStokNo.Text = "00";
                return;
            }
            int comboId = CmbTanim.SelectedValue.ConInt();
            Malzeme malzemeKayit = malzemeManager.Get2(comboId);
            if (malzemeKayit == null)
            {
                TxtStokNo.Clear();
                return;
            }
            TxtStokNo.Text = malzemeKayit.StokNo;
        }
        int sayac = 0;
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtYapilacakIslemler.Text=="")
            {
                MessageBox.Show("Lütfen öncelikle yapılacak işlemler bilgisini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sayac==4)
            {
                MessageBox.Show("Lütfen en fazla 4 adet Yapılacak İşlem bilgisi giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgList.Rows.Add();
            int sonSatir = DtgList.RowCount - 1;
            if (RdbKesin.Checked==true)
            {
                DtgList.Rows[sonSatir].Cells["YapilacakIslemler"].Value = "(K) "+ TxtYapilacakIslemler.Text;
            }
            else
            {
                DtgList.Rows[sonSatir].Cells["YapilacakIslemler"].Value = "(T) " + TxtYapilacakIslemler.Text;
            }

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
            sayac++;
            TxtYapilacakIslemler.Clear();
        }

        private void DtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgList.Rows.RemoveAt(e.RowIndex);
            }
        }
        
        void FillMalzeme()
        {
            malzemeKayits2 = malzemeManager.GetList();
            CmbStokNo.DataSource = malzemeKayits2;
            CmbStokNo.ValueMember = "Id";
            CmbStokNo.DisplayMember = "StokNo";
            CmbStokNo.SelectedValue = 0;

        }

        private void CmbSokulenStokNo_TextChanged(object sender, EventArgs e)
        {
            if (CmbStokNo.Text == "")
            {
                TxtTanim.Clear();
            }
            else
            {
                foreach (Malzeme item in malzemeKayits)
                {
                    if (CmbStokNo.Text == item.StokNo)
                    {
                        TxtTanim.Text = item.Tanim;
                    }
                }
            }
        }

        private void CmbStokNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            int comboId = CmbStokNo.SelectedValue.ConInt();
            Malzeme malzemeKayit = malzemeManager.Get2(comboId);
            if (malzemeKayit == null)
            {
                TxtTanim.Text = "";
                return;
            }
            TxtTanim.Text = malzemeKayit.Tanim;
        }

        private void m1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void BTutar1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
        int sayac2 = 0;
        private void BtnEkleMlz_Click(object sender, EventArgs e)
        {
            string control = MalzemeKontrol();
            if (control!="OK")
            {
                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sayac2++;
            DtgMalzemeList.Rows.Add();
            int sonSatir = DtgMalzemeList.RowCount - 1;
            DtgMalzemeList.Rows[sonSatir].Cells["StokNo"].Value = CmbStokNo.Text;
            DtgMalzemeList.Rows[sonSatir].Cells["Tanimm"].Value = TxtTanim.Text;
            DtgMalzemeList.Rows[sonSatir].Cells["Miktar"].Value = m1.Text;
            DtgMalzemeList.Rows[sonSatir].Cells["Birim"].Value = b1.Text;
            DtgMalzemeList.Rows[sonSatir].Cells["PBirim"].Value = Pb1.Text;
            DtgMalzemeList.Rows[sonSatir].Cells["BirimTutar"].Value = BTutar1.Text;
            DtgMalzemeList.Rows[sonSatir].Cells["ToplamTutar"].Value = TTutar1.Text;

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgMalzemeList.Columns["Remove2"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;

            CmbStokNo.Text = ""; TxtTanim.Clear(); m1.Clear(); b1.Text = ""; BTutar1.Clear(); TTutar1.Clear();
            Toplamlar();

        }
        void Toplamlar()
        {
            toplam = 0;
            for (int i = 0; i < DtgMalzemeList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgMalzemeList.Rows[i].Cells["ToplamTutar"].Value);
            }
            TxtGenelTop.Text = toplam.ToString("C2");
        }

        private void DtgMalzemeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgMalzemeList.Rows.RemoveAt(e.RowIndex);
            }
            Toplamlar();
        }

        string TopFiyatHesapla(string a, string b)
        {
            double x, y = 0;

            if (a == "" || b == "")
            {
                sonuc = 0;
                topfiyat = sonuc.ToString("0.00");
                return topfiyat;
            }
            x = double.TryParse(a, out outValue) ? Convert.ToDouble(a) : 0;
            y = double.TryParse(b, out outValue) ? Convert.ToDouble(b) : 0;
            sonuc = x * y;
            topfiyat = sonuc.ToString("0.00");
            return topfiyat;
        }

        private void BTutar1_TextChanged(object sender, EventArgs e)
        {
            TTutar1.Text = TopFiyatHesapla(BTutar1.Text, m1.Text);
        }

        private void m1_TextChanged(object sender, EventArgs e)
        {
            TTutar1.Text = TopFiyatHesapla(BTutar1.Text, m1.Text);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (DtgList.Rows.Count==0)
                {
                    MessageBox.Show("Lütfen Yapılacak İşlemler tablosuna veri ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (DtgMalzemeList.Rows.Count == 0)
                {
                    MessageBox.Show("Lütfen Kullanılacak Malzemeler tablosuna veri ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                IsAkisNo();
                string arizaDurum = "";
                if (RdbKesin.Checked==true)
                {
                    arizaDurum = "KESİN";
                }
                else
                {
                    arizaDurum = "TAHMİNİ";
                }
                string anadosya = @"Z:\DTS\BAKIM ONARIM\OKF\";
                dosyaYolu = anadosya + LblIsAkisNo.Text + "\\";

                Okf okf = new Okf(LblIsAkisNo.Text.ConInt(), TalepEden.Text, LbKayitTarihi.Text.ConDate(), TxtAbfNo.Text, DtgArizaTarihi.Value, CmbBolgeAdi.Text, CmbProjeKodu.Text, LblGarantiDurumu.Text, TxtUsBolgesiKomutani.Text, TxtABTelefon.Text, birlikAdresi, il, ilce, TxtStokNo.Text, CmbTanim.Text, TxtSeriNo.Text, TxtBildirilenAriza.Text, arizaDurum, TxtArizaNedeni.Text, TxtGenelOneriler.Text, toplam, dosyaYolu, bildirimNo);

                string mesaj = okfManager.Add(okf);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int id = okfManager.OkfSonId();

                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    Okf okf1 = new Okf(id, item.Cells["YapilacakIslemler"].Value.ToString());
                    string mesaj2 = okfManager.YapilacakIslemlerAdd(okf1);
                    if (mesaj2!="OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                foreach (DataGridViewRow item in DtgMalzemeList.Rows)
                {
                    DtfMaliyet dtfMaliyet = new DtfMaliyet(id, item.Cells["StokNo"].Value.ToString() + "|" + item.Cells["Tanimm"].Value.ToString(), item.Cells["Miktar"].Value.ConInt(), item.Cells["Birim"].Value.ToString(), item.Cells["PBirim"].Value.ToString(), item.Cells["BirimTutar"].Value.ConDouble(), item.Cells["ToplamTutar"].Value.ConDouble(), "OKF");

                    string mesaj2 = dtfMaliyetManager.Add(dtfMaliyet);
                    if (mesaj2 != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                CreateWord();
                IsAkisNo();
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sayac = 0;
                sayac2 = 0;
                Temizle();
            }
        }

        void Temizle()
        {
            TxtAbfNo.Clear(); DtgArizaTarihi.Value = DateTime.Now; CmbBolgeAdi.SelectedIndex = -1; CmbProjeKodu.SelectedIndex= -1; TxtUsBolgesiKomutani.Clear(); 
            TxtABTelefon.Clear(); CmbTanim.SelectedIndex = -1; TxtStokNo.Clear(); TxtSeriNo.Clear(); TxtBildirilenAriza.Clear(); RdbKesin.Checked=false; RdbTahmini.Checked=false;
            TxtArizaNedeni.Clear(); TxtYapilacakIslemler.Clear(); ChkArizaBildirim.Checked=false; ChkArizaFoto.Checked=false; ChkFiyatTeklifi.Checked=false;
            ChkTutanak.Checked = false; DtgList.Rows.Clear(); TxtGenelOneriler.Clear(); CmbStokNo.Text = ""; CmbTanim.Text = ""; m1.Clear(); b1.Text = ""; 
            BTutar1.Clear(); TTutar1.Clear(); DtgMalzemeList.Rows.Clear(); CmbBolgeAdi.Text = ""; CmbProjeKodu.Text = "";
            Toplamlar();
        }
        
        void CreateWord()
        {
            TaslakKopyala();
            string root = @"Z:\DTS";
            string subdir = @"Z:\DTS\BAKIM ONARIM\";
            string anadosya = @"Z:\DTS\BAKIM ONARIM\OKF\";

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
            wBookmarks["ArizaTarihi"].Range.Text = DtgArizaTarihi.Value.ToString("d");
            wBookmarks["IsAkisNo"].Range.Text = LblIsAkisNo.Text;
            wBookmarks["BildirimNo"].Range.Text = bildirimNo;
            wBookmarks["UsBolgesi"].Range.Text = CmbBolgeAdi.Text;
            wBookmarks["GarantiDurumu"].Range.Text = LblGarantiDurumu.Text;
            wBookmarks["BirlikAdresi"].Range.Text = birlikAdresi + " " + il.ToUpper() + "/" + ilce.ToUpper();
            wBookmarks["BolgeKomutan"].Range.Text = TxtUsBolgesiKomutani.Text;
            wBookmarks["BolgeKomutanTel"].Range.Text = TxtABTelefon.Text;
            wBookmarks["UstTanim"].Range.Text = CmbTanim.Text;
            wBookmarks["UstStok"].Range.Text = TxtStokNo.Text;
            wBookmarks["UstSeri"].Range.Text = TxtSeriNo.Text;
            wBookmarks["BildirilenAriza"].Range.Text = TxtBildirilenAriza.Text;
            wBookmarks["AbfNo"].Range.Text = TxtAbfNo.Text;
            wBookmarks["Musteri"].Range.Text = CmbMusteriAdi.Text;

            if (RdbKesin.Checked==true)
            {
                wBookmarks["ArizaNedenKesin"].Range.Text = TxtArizaNedeni.Text;
            }
            else
            {
                wBookmarks["ArizaNedenTahmini"].Range.Text = TxtArizaNedeni.Text;
            }
            if (DtgList.RowCount>0)
            {
                wBookmarks["YapilacakIslem1"].Range.Text = DtgList.Rows[0].Cells["YapilacakIslemler"].Value.ToString();
            }
            if (DtgList.RowCount > 1)
            {
                wBookmarks["YapilacakIslem2"].Range.Text = DtgList.Rows[1].Cells["YapilacakIslemler"].Value.ToString();
            }
            if (DtgList.RowCount > 2)
            {
                wBookmarks["YapilacakIslem3"].Range.Text = DtgList.Rows[2].Cells["YapilacakIslemler"].Value.ToString();
            }
            if (DtgList.RowCount > 3)
            {
                wBookmarks["YapilacakIslem4"].Range.Text = DtgList.Rows[3].Cells["YapilacakIslemler"].Value.ToString();
            }
            if (DtgMalzemeList.RowCount>0)
            {
                wBookmarks["Stok1"].Range.Text = DtgMalzemeList.Rows[0].Cells["StokNo"].Value.ToString();
                wBookmarks["Tanim1"].Range.Text = DtgMalzemeList.Rows[0].Cells["Tanimm"].Value.ToString();
                wBookmarks["Miktar1"].Range.Text = DtgMalzemeList.Rows[0].Cells["Miktar"].Value.ToString() + " " +  DtgMalzemeList.Rows[0].Cells["Birim"].Value.ToString();
                double toplam = DtgMalzemeList.Rows[0].Cells["ToplamTutar"].Value.ConDouble();
                string ttutar = toplam.ToString("C2");
                wBookmarks["Tutar1"].Range.Text = ttutar;
            }
            if (DtgMalzemeList.RowCount > 1)
            {
                wBookmarks["Stok2"].Range.Text = DtgMalzemeList.Rows[1].Cells["StokNo"].Value.ToString();
                wBookmarks["Tanim2"].Range.Text = DtgMalzemeList.Rows[1].Cells["Tanimm"].Value.ToString();
                wBookmarks["Miktar2"].Range.Text = DtgMalzemeList.Rows[1].Cells["Miktar"].Value.ToString() + " " + DtgMalzemeList.Rows[1].Cells["Birim"].Value.ToString();
                double toplam = DtgMalzemeList.Rows[1].Cells["ToplamTutar"].Value.ConDouble();
                string ttutar = toplam.ToString("C2");
                wBookmarks["Tutar2"].Range.Text = ttutar;
            }
            if (DtgMalzemeList.RowCount > 2)
            {
                wBookmarks["Stok3"].Range.Text = DtgMalzemeList.Rows[2].Cells["StokNo"].Value.ToString();
                wBookmarks["Tanim3"].Range.Text = DtgMalzemeList.Rows[2].Cells["Tanimm"].Value.ToString();
                wBookmarks["Miktar3"].Range.Text = DtgMalzemeList.Rows[2].Cells["Miktar"].Value.ToString() + " " + DtgMalzemeList.Rows[2].Cells["Birim"].Value.ToString();
                double toplam = DtgMalzemeList.Rows[2].Cells["ToplamTutar"].Value.ConDouble();
                string ttutar = toplam.ToString("C2");
                wBookmarks["Tutar3"].Range.Text = ttutar;
            }
            if (DtgMalzemeList.RowCount > 3)
            {
                wBookmarks["Stok4"].Range.Text = DtgMalzemeList.Rows[3].Cells["StokNo"].Value.ToString();
                wBookmarks["Tanim4"].Range.Text = DtgMalzemeList.Rows[3].Cells["Tanimm"].Value.ToString();
                wBookmarks["Miktar4"].Range.Text = DtgMalzemeList.Rows[3].Cells["Miktar"].Value.ToString() + " " + DtgMalzemeList.Rows[3].Cells["Birim"].Value.ToString();
                double toplam = DtgMalzemeList.Rows[3].Cells["ToplamTutar"].Value.ConDouble();
                string ttutar = toplam.ToString("C2");
                wBookmarks["Tutar4"].Range.Text = ttutar;
            }
            if (DtgMalzemeList.RowCount > 4)
            {
                wBookmarks["Stok5"].Range.Text = DtgMalzemeList.Rows[4].Cells["StokNo"].Value.ToString();
                wBookmarks["Tanim5"].Range.Text = DtgMalzemeList.Rows[4].Cells["Tanimm"].Value.ToString();
                wBookmarks["Miktar5"].Range.Text = DtgMalzemeList.Rows[4].Cells["Miktar"].Value.ToString() + " " + DtgMalzemeList.Rows[4].Cells["Birim"].Value.ToString();
                double toplam = DtgMalzemeList.Rows[4].Cells["ToplamTutar"].Value.ConDouble();
                string ttutar = toplam.ToString("C2");
                wBookmarks["Tutar5"].Range.Text = ttutar;
            }
            //if (DtgMalzemeList.RowCount > 5)
            //{
            //    wBookmarks["Stok6"].Range.Text = DtgMalzemeList.Rows[5].Cells["StokNo"].Value.ToString();
            //    wBookmarks["Tanim6"].Range.Text = DtgMalzemeList.Rows[5].Cells["Tanimm"].Value.ToString();
            //    wBookmarks["Miktar6"].Range.Text = DtgMalzemeList.Rows[5].Cells["Miktar"].Value.ToString() + " " + DtgMalzemeList.Rows[5].Cells["Birim"].Value.ToString();
            //    double toplam = DtgMalzemeList.Rows[5].Cells["ToplamTutar"].Value.ConDouble();
            //    string ttutar = toplam.ToString("C2");
            //    wBookmarks["Tutar6"].Range.Text = ttutar;
            //}
            //if (DtgMalzemeList.RowCount > 6)
            //{
            //    wBookmarks["Stok7"].Range.Text = DtgMalzemeList.Rows[6].Cells["StokNo"].Value.ToString();
            //    wBookmarks["Tanim7"].Range.Text = DtgMalzemeList.Rows[6].Cells["Tanimm"].Value.ToString();
            //    wBookmarks["Miktar7"].Range.Text = DtgMalzemeList.Rows[6].Cells["Miktar"].Value.ToString() + " " + DtgMalzemeList.Rows[6].Cells["Birim"].Value.ToString();
            //    double toplam = DtgMalzemeList.Rows[6].Cells["ToplamTutar"].Value.ConDouble();
            //    string ttutar = toplam.ToString("C2");
            //    wBookmarks["Tutar7"].Range.Text = ttutar;
            //}
            //if (DtgMalzemeList.RowCount > 7)
            //{
            //    wBookmarks["Stok8"].Range.Text = DtgMalzemeList.Rows[7].Cells["StokNo"].Value.ToString();
            //    wBookmarks["Tanim8"].Range.Text = DtgMalzemeList.Rows[7].Cells["Tanimm"].Value.ToString();
            //    wBookmarks["Miktar8"].Range.Text = DtgMalzemeList.Rows[7].Cells["Miktar"].Value.ToString() + " " + DtgMalzemeList.Rows[7].Cells["Birim"].Value.ToString();
            //    double toplam = DtgMalzemeList.Rows[7].Cells["ToplamTutar"].Value.ConDouble();
            //    string ttutar = toplam.ToString("C2");
            //    wBookmarks["Tutar8"].Range.Text = ttutar;
            //}

            wBookmarks["GenelTop"].Range.Text = TxtGenelTop.Text;
            wBookmarks["GenelOneriler"].Range.Text = TxtGenelOneriler.Text;

            if (ChkArizaBildirim.Checked==true)
            {
                wBookmarks["Ekler"].Range.Text = ChkArizaBildirim.Text + "\n";
            }
            if (ChkArizaBildirim.Checked == true)
            {
                wBookmarks["Ekler"].Range.Text = ChkArizaFoto.Text + "\n";
            }
            if (ChkFiyatTeklifi.Checked == true)
            {
                wBookmarks["Ekler"].Range.Text = ChkFiyatTeklifi.Text + "\n";
            }
            if (ChkTutanak.Checked==true)
            {
                wBookmarks["Ekler"].Range.Text = ChkTutanak.Text + "\n";
            }

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

            File.Copy(kaynak + "OKF BOŞ BELGE.docx", yol + "OKF BOŞ BELGE.docx");

            taslakYolu = yol + "OKF BOŞ BELGE.docx";
        }


        string MalzemeKontrol()
        {
            if (sayac2==8)
            {
                return "Lütfen bir defada en fazla 8 adet malzeme kaydediniz!";
            }
            if (CmbStokNo.Text=="")
            {
                return "Lütfen öncelikle Stok No bilgisini doldurunuz!";
            }
            if (TxtTanim.Text=="")
            {
                return "Lütfen öncelikle Tanım bilgisini doldurunuz!";
            }
            if (m1.Text=="")
            {
                return "Lütfen öncelikle Miktar bilgisini doldurunuz!";
            }
            if (b1.Text=="")
            {
                return "Lütfen öncelikle Birim bilgisini doldurunuz!";
            }
            if (Pb1.Text == "")
            {
                return "Lütfen öncelikle Para Birimi bilgisini doldurunuz!";
            }
            if (BTutar1.Text == "")
            {
                return "Lütfen öncelikle Birim Tutar bilgisini doldurunuz!";
            }
            return "OK";
        }
    }
}
