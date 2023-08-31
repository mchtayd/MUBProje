using Business.Concreate.BakimOnarim;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity.BakimOnarim;
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
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmOkfGuncelle : Form
    {
        OkfManager okfManager;
        DtfMaliyetManager dtfMaliyetManager;
        BolgeKayitManager bolgeKayitManager;
        MalzemeKayitManager malzemeKayitManager;
        List<MalzemeKayit> malzemeKayits;
        List<MalzemeKayit> malzemeKayits2;
        public int id = 0;
        double toplam, sonuc, outValue = 0;
        bool start = false;
        int sayac, sayac2 = 0;
        string topfiyat, dosyaYolu = "";


        public FrmOkfGuncelle()
        {
            InitializeComponent();
            okfManager = OkfManager.GetInstance();
            dtfMaliyetManager= DtfMaliyetManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
        }

        private void FrmOkfGuncelle_Load(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen geçerli bir kayıt seçtikten sonra sağ tıklayarak Güncelle işlemini gerçekleştirin!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
            }
            UsBolgeleri();
            Tanim();
            FillMalzeme();
            DataDisplay();
            start = true;
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
            malzemeKayits = malzemeKayitManager.GetListMalzemeKayit();
            CmbTanim.DataSource = malzemeKayits;
            CmbTanim.ValueMember = "Id";
            CmbTanim.DisplayMember = "Tanim";
            CmbTanim.SelectedValue = 0;
        }
        void FillMalzeme()
        {
            malzemeKayits2 = malzemeKayitManager.GetListMalzemeKayit();
            CmbStokNo.DataSource = malzemeKayits2;
            CmbStokNo.ValueMember = "Id";
            CmbStokNo.DisplayMember = "Stokno";
            CmbStokNo.SelectedValue = 0;

        }

        void DataDisplay()
        {
            List<Okf> okfs = new List<Okf>();
            List<DtfMaliyet> dtfMaliyets = new List<DtfMaliyet>();
            Okf okf = okfManager.Get(id);
            LblIsAkisNo.Text = okf.IsAkisNo.ToString();
            TalepEden.Text = okf.KayitYapan;
            LbKayitTarihi.Text = okf.KayitTarihi.ToString("d");
            TxtAbfNo.Text= okf.AbfNo.ToString();
            DtgArizaTarihi.Text = okf.ArizaTarihi.ToString("d");
            CmbBolgeAdi.Text = okf.UsBolgesi;
            CmbProjeKodu.Text = okf.ProjeKodu;
            TxtUsBolgesiKomutani.Text = okf.UbKomutani;
            TxtABTelefon.Text = okf.KomutanTel;
            CmbTanim.Text = okf.UstTanim;
            TxtStokNo.Text = okf.UstStok;
            TxtSeriNo.Text = okf.UstSeriNo;
            TxtBildirilenAriza.Text=okf.BildirilenAriza;
            dosyaYolu = okf.DosyaYolu;
            string durum = okf.ArizaDurum;
            if (durum== "KESİN")
            {
                RdbKesin.Checked=true;
            }
            else
            {
                RdbTahmini.Checked = true;
            }
            TxtArizaNedeni.Text=okf.ArizaNedeni;
            TxtGenelOneriler.Text=okf.GenelOneriler;
            okfs = okfManager.YapilacakIslemlerGetList(id);
            foreach (Okf item in okfs)
            {
                DtgList.Rows.Add();
                int sonSatir = DtgList.RowCount - 1;
                DtgList.Rows[sonSatir].Cells["YapilacakIslemler"].Value = item.YapilacakIslemler;
                DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Remove"];
                c.FlatStyle = FlatStyle.Popup;
                c.DefaultCellStyle.ForeColor = Color.Red;
                c.DefaultCellStyle.BackColor = Color.Gainsboro;
            }
            dtfMaliyets = dtfMaliyetManager.GetList(id, "OKF");
            foreach (DtfMaliyet item in dtfMaliyets)
            {
                DtgMalzemeList.Rows.Add();
                int sonSatir = DtgMalzemeList.RowCount - 1;

                string[] isTanim = item.IsTanimi.Split('|');

                if (isTanim.Length == 1)
                {
                    DtgMalzemeList.Rows[sonSatir].Cells["StokNo"].Value = "N/A";
                    DtgMalzemeList.Rows[sonSatir].Cells["Tanimm"].Value = isTanim[0];
                }
                else
                {
                    DtgMalzemeList.Rows[sonSatir].Cells["StokNo"].Value = isTanim[0];
                    DtgMalzemeList.Rows[sonSatir].Cells["Tanimm"].Value = isTanim[1];
                }
                DtgMalzemeList.Rows[sonSatir].Cells["Miktar"].Value = item.Miktar.ToString();
                DtgMalzemeList.Rows[sonSatir].Cells["Birim"].Value = item.Birim;
                DtgMalzemeList.Rows[sonSatir].Cells["PBirim"].Value = item.PBirimi;
                DtgMalzemeList.Rows[sonSatir].Cells["BirimTutar"].Value = item.BirimTutar;
                DtgMalzemeList.Rows[sonSatir].Cells["ToplamTutar"].Value = item.ToplamTutar;

                DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgMalzemeList.Columns["Remove2"];
                c.FlatStyle = FlatStyle.Popup;
                c.DefaultCellStyle.ForeColor = Color.Red;
                c.DefaultCellStyle.BackColor = Color.Gainsboro;
            }
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

        private void DtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgList.Rows.RemoveAt(e.RowIndex);
            }
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
            MalzemeKayit malzemeKayit = malzemeKayitManager.Get(comboId);
            if (malzemeKayit == null)
            {
                TxtStokNo.Clear();
                return;
            }
            TxtStokNo.Text = malzemeKayit.Stokno;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtYapilacakIslemler.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle yapılacak işlemler bilgisini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sayac == 4)
            {
                MessageBox.Show("Lütfen en fazla 4 adet Yapılacak İşlem bilgisi giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DtgList.Rows.Add();
            int sonSatir = DtgList.RowCount - 1;
            if (RdbKesin.Checked == true)
            {
                DtgList.Rows[sonSatir].Cells["YapilacakIslemler"].Value = "(K) " + TxtYapilacakIslemler.Text;
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

        private void BtnEkleMlz_Click(object sender, EventArgs e)
        {
            string control = MalzemeKontrol();
            if (control != "OK")
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
        string MalzemeKontrol()
        {
            if (sayac2 == 8)
            {
                return "Lütfen bir defada en fazla 8 adet malzeme kaydediniz!";
            }
            if (CmbStokNo.Text == "")
            {
                return "Lütfen öncelikle Stok No bilgisini doldurunuz!";
            }
            if (TxtTanim.Text == "")
            {
                return "Lütfen öncelikle Tanım bilgisini doldurunuz!";
            }
            if (m1.Text == "")
            {
                return "Lütfen öncelikle Miktar bilgisini doldurunuz!";
            }
            if (b1.Text == "")
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

        private void CmbStokNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            int comboId = CmbStokNo.SelectedValue.ConInt();
            MalzemeKayit malzemeKayit = malzemeKayitManager.Get(comboId);
            if (malzemeKayit == null)
            {
                TxtTanim.Text = "";
                return;
            }
            TxtTanim.Text = malzemeKayit.Tanim;
        }

        private void CmbStokNo_TextChanged(object sender, EventArgs e)
        {
            if (CmbStokNo.Text == "")
            {
                TxtTanim.Clear();
            }
            else
            {
                foreach (MalzemeKayit item in malzemeKayits)
                {
                    if (CmbStokNo.Text == item.Stokno)
                    {
                        TxtTanim.Text = item.Tanim;
                    }
                }
            }
        }

        private void m1_TextChanged(object sender, EventArgs e)
        {
            TTutar1.Text = TopFiyatHesapla(BTutar1.Text, m1.Text);
        }

        private void BTutar1_TextChanged(object sender, EventArgs e)
        {
            TTutar1.Text = TopFiyatHesapla(BTutar1.Text, m1.Text);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(LblIsAkisNo.Text + " iş akış numaralı kaydı silmek istediğinize emin misiniz!\nBu işlem geri alınamaz!", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string mesaj = okfManager.Delete(id);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    Directory.Delete(dosyaYolu, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Temizle();
                    return;
                }

                FrmOkfIzleme frmOkfIzleme = (FrmOkfIzleme)System.Windows.Forms.Application.OpenForms["FrmOkfIzleme"];
                frmOkfIzleme.Yenilenecekler();
                MessageBox.Show("Bilgiler başarıyla silinmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(LblIsAkisNo.Text + " iş akış numaralı kaydı güncellemek istediğinize emin misiniz!\nBu işlem geri alınamaz!", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {

            }
        }

        void Temizle()
        {
            TxtAbfNo.Clear(); DtgArizaTarihi.Value = DateTime.Now; CmbBolgeAdi.SelectedIndex = -1; CmbProjeKodu.SelectedIndex = -1; TxtUsBolgesiKomutani.Clear();
            TxtABTelefon.Clear(); CmbTanim.SelectedIndex = -1; TxtStokNo.Clear(); TxtSeriNo.Clear(); TxtBildirilenAriza.Clear(); RdbKesin.Checked = false; RdbTahmini.Checked = false;
            TxtArizaNedeni.Clear(); TxtYapilacakIslemler.Clear(); ChkArizaBildirim.Checked = false; ChkArizaFoto.Checked = false; ChkFiyatTeklifi.Checked = false;
            ChkTutanak.Checked = false; DtgList.Rows.Clear(); TxtGenelOneriler.Clear(); CmbStokNo.Text = ""; CmbTanim.Text = ""; m1.Clear(); b1.Text = "";
            BTutar1.Clear(); TTutar1.Clear(); DtgMalzemeList.Rows.Clear(); CmbBolgeAdi.Text = ""; CmbProjeKodu.Text = "";
            Toplamlar();
        }

        private void m1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void BTutar1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
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
    }
}
