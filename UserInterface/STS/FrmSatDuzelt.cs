using Business;
using Business.Concreate;
using Business.Concreate.BakimOnarim;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Drawing;
using Entity.BakimOnarim;
using Entity.IdariIsler;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.STS
{
    public partial class FrmSatDuzelt : Form
    {
        TamamlananManager tamamlananManager;
        ButceKoduKalemiManager butceKoduKalemiManager;
        ComboManager comboManager;
        TamamlananMalzemeManager tamamlananMalzemeManager;
        BolgeKayitManager bolgeKayitManager;
        BolgeGarantiManager bolgeGarantiManager;
        SatTalebiDoldurManager satTalebiDoldurManager;
        List<TamamlananMalzeme> tamamlananMalzemes;
        public int id;
        bool start = false;
        string abfFormNo = "";
        int miktar, malzemeId;
        public FrmSatDuzelt()
        {
            InitializeComponent();
            tamamlananManager = TamamlananManager.GetInstance();
            butceKoduKalemiManager = ButceKoduKalemiManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            tamamlananMalzemeManager = TamamlananMalzemeManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            bolgeGarantiManager = BolgeGarantiManager.GetInstance();
            satTalebiDoldurManager = SatTalebiDoldurManager.GetInstance();
        }

        private void FrmSatDuzelt_Load(object sender, EventArgs e)
        {
            ButceKoduFill();
            ButceTanim();
            MaliyetTuru();
            BolgeBilgileri();
            start = true;
            DataDisplay();
            AbfFormNoList();
        }
        void DataDisplay()
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen bir kayıt seçtikten sonra sağ tıklayarak güncelleme işlemlerine devam ediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            Tamamlanan tamamlanan = tamamlananManager.Get(id);
            if (tamamlanan==null)
            {
                return;
            }
            LblIsAkisNo.Text = tamamlanan.Formno.ToString();
            LblSatNo.Text = tamamlanan.Satno;
            LblMasrafYeriNo.Text = tamamlanan.Masrafyerino;
            LblMasrafYeri.Text = tamamlanan.Bolum;
            LblAdSoyad.Text = tamamlanan.Talepeden;
            CmbUsBolgesi.Text = tamamlanan.Usbolgesi;
            abfFormNo = tamamlanan.Abfform;
            CmbAbfFormno.Text = abfFormNo;
            istenenTarih.Value=tamamlanan.Istenentarih;
            string[] donemArray = tamamlanan.Donem.Split(' ');
            CmbDonem.Text= donemArray[0];
            CmbDonemYil.Text= donemArray[1];
            TxtGerekceBasaran.Text = tamamlanan.Gerekce;
            CmbButceKodu.Text = tamamlanan.Butcekodukalemi;
            CmbSatBirim.Text=tamamlanan.Satbirim;
            CmbHarcamaTuru.Text = tamamlanan.Harcamaturu;
            CmbFaturaFirma.Text = tamamlanan.Faturaedilecekfirma;
            CmbFBelgeTur.Text = tamamlanan.Belgeturu;
            TxtBelgeNo.Text = tamamlanan.Belgenumarasi;
            DtgBelgeTarih.Value = tamamlanan.Belgetarihi;
            CmbHarcamaYapan.Text = tamamlanan.HarcamaYapan;
            TxtSatinAlinanFirma.Text = tamamlanan.SatinAlinanFirma;
            CmbButceTanimi.Text = tamamlanan.ButceTanimi;
            TxtFirmayaKesilenFatura.Text = tamamlanan.FirmayaKesilenFatura;
            TxtKesilenFaturaTarihi.Text = tamamlanan.KesilenFaturaTarihi;
            CmbButceGiderTuru.Text = tamamlanan.ButceGiderTuru;
            TxtProje.Text = tamamlanan.UsProjeNo;
            CmbBasaranProje.Text = tamamlanan.Proje;
            string siparisNo = tamamlanan.Siparisno;
            MalzemeFill(siparisNo);
            string dosyaYolu = tamamlanan.Dosyayolu;
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }
        void ButceKoduFill()
        {
            CmbButceKodu.DataSource = butceKoduKalemiManager.GetList();
            CmbButceKodu.ValueMember = "Id";
            CmbButceKodu.DisplayMember = "ButceKoduKalemi";
            CmbButceKodu.SelectedValue = 0;
        }
        public void ButceTanim()
        {
            CmbButceTanimi.DataSource = comboManager.GetList("BUTCE_TANIM");
            CmbButceTanimi.ValueMember = "Id";
            CmbButceTanimi.DisplayMember = "Baslik";
            CmbButceTanimi.SelectedValue = 0;
        }
        public void MaliyetTuru()
        {
            CmbMaliyetTuru.DataSource = comboManager.GetList("MALİYET_TURU");
            CmbMaliyetTuru.ValueMember = "Id";
            CmbMaliyetTuru.DisplayMember = "Baslik";
            CmbMaliyetTuru.SelectedValue = 0;
        }

        private void CmbButceTanimi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbButceTanimi.Text == "DEĞİŞKEN GİDER")
            {
                CmbMaliyetTuru.Text = "PROJE MALİYET";
            }
            if (CmbButceTanimi.Text == "HAKEDİŞ")
            {
                CmbMaliyetTuru.Text = "FİNANSMAN GİDERİ";
            }
            if (CmbButceTanimi.Text == "SABİT GİDER")
            {
                CmbMaliyetTuru.Text = "SAT GİDERİ";
            }
            if (CmbButceTanimi.Text == "")
            {
                CmbMaliyetTuru.Text = "";
            }
        }
        void MalzemeFill(string siparisNo)
        {
            tamamlananMalzemes = tamamlananMalzemeManager.GetList(siparisNo);
            DtgList.DataSource = tamamlananMalzemes;
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Stokno"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgList.Columns["Birim"].HeaderText = "BİRİM";
            DtgList.Columns["Firma"].HeaderText = "FİRMA";
            DtgList.Columns["Birimfiyat"].HeaderText = "BİRİM FİYAT";
            DtgList.Columns["Toplamfiyat"].HeaderText = "TOPLAM FİYAT";
            DtgList.Columns["Siparisno"].Visible = false;
            Toplamlar();
        }

        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells["Toplamfiyat"].Value);
            }
            LblToplam.Text = toplam.ToString("C2");
        }

        private void CmbFaturaFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = CmbFaturaFirma.SelectedIndex;
            TxtIlgiliKisi.SelectedIndex = index;
            TxtMasYerNo.SelectedIndex = index;
        }
        void BolgeBilgileri()
        {
            CmbUsBolgesi.DataSource = bolgeKayitManager.GetList();
            CmbUsBolgesi.ValueMember = "Id";
            CmbUsBolgesi.DisplayMember = "BolgeAdi";
            CmbUsBolgesi.SelectedValue = -1;
        }

        private void CmbUsBolgesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            BolgeKayit bolgeKayit = bolgeKayitManager.Get(CmbUsBolgesi.SelectedValue.ConInt());
            if (bolgeKayit == null)
            {
                return;
            }
            BolgeGaranti bolgeGaranti = bolgeGarantiManager.Get(bolgeKayit.SiparisNo);
            if (bolgeGaranti != null)
            {
                TxtProje.Text = bolgeGaranti.GarantiPaketi;
            }
            else
            {
                TxtProje.Text = bolgeKayit.Proje;
            }

            AbfFormNoList();

        }
        void AbfFormNoList()
        {
            CmbAbfFormno.DataSource = satTalebiDoldurManager.BolgeSatList(CmbUsBolgesi.Text);
            CmbAbfFormno.ValueMember = "Id";
            CmbAbfFormno.DisplayMember = "AbfNo";
            CmbAbfFormno.SelectedValue = "";
            CmbAbfFormno.Text = abfFormNo;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //if (TxtSatinAlinanFirma.Text == "-" || TxtSatinAlinanFirma.Text=="")
            //{
            //    MessageBox.Show("Satın alınan firma bilgisini bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            DialogResult dr = MessageBox.Show("Bilgileri güncellemek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {

                string donem = CmbDonem.Text + " " + CmbDonemYil.Text;
                Tamamlanan tamamlanan = new Tamamlanan(id, CmbUsBolgesi.Text, CmbAbfFormno.Text, istenenTarih.Value, TxtGerekceBasaran.Text, CmbButceKodu.Text, CmbSatBirim.Text, CmbHarcamaTuru.Text, CmbFaturaFirma.Text, TxtIlgiliKisi.Text, TxtMasYerNo.Text, CmbFBelgeTur.Text, TxtBelgeNo.Text, DtgBelgeTarih.Value, donem, CmbBasaranProje.Text, TxtSatinAlinanFirma.Text, CmbHarcamaYapan.Text, CmbButceTanimi.Text, CmbMaliyetTuru.Text, TxtFirmayaKesilenFatura.Text, TxtKesilenFaturaTarihi.Text, CmbButceGiderTuru.Text);

                string mesaj = tamamlananManager.Update(tamamlanan);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    TamamlananMalzeme tamamlananMalzeme = new TamamlananMalzeme(item.Cells["Id"].Value.ConInt(), item.Cells["Birimfiyat"].Value.ConDouble(), item.Cells["Toplamfiyat"].Value.ConDouble());
                    tamamlananMalzemeManager.Update(tamamlananMalzeme);

                }

                FrmTamamlananSat frmTamamlananSat = (FrmTamamlananSat)Application.OpenForms["FrmTamamlananSat"];
                frmTamamlananSat.TamamlananSatlar();

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }


        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtBirim.Text = DtgList.CurrentRow.Cells["Birimfiyat"].Value.ToString();
            miktar = DtgList.CurrentRow.Cells["Miktar"].Value.ConInt();
            malzemeId = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            if (miktar==0)
            {
                miktar = 1;
            }
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (malzemeId==0)
            {
                MessageBox.Show("Lütfen bir malzeme seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (DataGridViewRow item in DtgList.Rows)
            {
                if (malzemeId == item.Cells["Id"].Value.ConInt())
                {
                    item.Cells["BirimFiyat"].Value = TxtBirim.Text;
                    item.Cells["ToplamFiyat"].Value = LblToplamFiyat.Text;
                }
                
            }
            malzemeId = 0;
        }

        private void TxtBirim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void TxtBirim_TextChanged(object sender, EventArgs e)
        {
            LblToplamFiyat.Text = ToplamHesapla(miktar, TxtBirim.Text.ConDouble());
        }
        string ToplamHesapla(int miktar, double birimFiyat)
        {
            double toplam;
            toplam = miktar * birimFiyat;
            return toplam.ToString();
        }
    }
}
