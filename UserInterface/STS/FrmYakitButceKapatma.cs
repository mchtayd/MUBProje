using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using Entity.IdariIsler;
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
    public partial class FrmYakitButceKapatma : Form
    {

        string donem = "";

        YakitDokumManager yakitDokumManager;
        YakitManager yakitManager;

        List<Yakit> yakitBeyanlar = new List<Yakit>();
        List<YakitDokum> yakitAnlasmalilar = new List<YakitDokum>();
        List<YakitDokum> yakitTasitTanimalar = new List<YakitDokum>();

        public FrmYakitButceKapatma()
        {
            InitializeComponent();
            yakitDokumManager = YakitDokumManager.GetInstance();
            yakitManager = YakitManager.GetInstance();
        }

        private void FrmYakitButceKapatma_Load(object sender, EventArgs e)
        {

        }

        private void BtnKontrolEt_Click(object sender, EventArgs e)
        {
            if (CmbAy.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Taratacağınız Döneme Ait AY Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbYil.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Taratacağınız Döneme Ait YIL Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DtgUyanlar.Rows.Clear();
            DtgUymayanlar.Rows.Clear();

            donem = CmbAy.Text + " " + CmbYil.Text;

            yakitBeyanlar = yakitManager.YakitKontrolBeyan(donem);
            DtgBeyan.DataSource = yakitBeyanlar;

            yakitAnlasmalilar = yakitDokumManager.YakitKontrolAnlasmali(donem);
            var anaListe = yakitAnlasmalilar.Select(x => x).ToList();
            DtgAnlasmaliPetrol.DataSource = yakitAnlasmalilar;

            yakitTasitTanimalar = yakitDokumManager.YakitKontrolTT(donem);
            DtgTT.DataSource = yakitTasitTanimalar;

            anaListe.AddRange(yakitTasitTanimalar);
            var eslesmeyenler = new List<YakitDokum>(); // Akaryakıt istasyonundan gelip bizde karşılığı olmayan ögeler
            var eslesmeyenler2 = new List<Yakit>(); // Beyan edilip istasyon raporunda karşılığı bulunmayan ögeler


            foreach (YakitDokum item in anaListe)
            {
                //YakitDokum eslesmeyen = new YakitDokum();

                var kontrol = yakitBeyanlar.FirstOrDefault(x => x.YakitAlinanDonem == item.Donem && x.Plaka == item.Plaka && x.ToplamFiyat == item.ToplamTutar
                && x.Tarih.Date == item.Tarih.Date && x.AlinanLitre == item.VerilenLitre);

                if (kontrol == null)
                {
                    eslesmeyenler.Add(item);
                }
                kontrol = null;
            }

            foreach (Yakit item in yakitBeyanlar)
            {
                var kontrol = anaListe.FirstOrDefault(x => x.Donem == item.YakitAlinanDonem && x.Plaka == item.Plaka && x.ToplamTutar == item.ToplamFiyat
                && x.Tarih.Date == item.Tarih.Date && x.VerilenLitre == item.AlinanLitre);
                if (kontrol == null)
                {
                    eslesmeyenler2.Add(item);
                }
                kontrol = null;
            }

            AdtgUymayan.DataSource = eslesmeyenler; //57
            AdtgUymayan2.DataSource = eslesmeyenler2; //25

            foreach (DataGridViewRow itemTT in DtgTT.Rows)
            {
                string plakaTT = itemTT.Cells["Plaka"].Value.ToString();
                string donemTT = itemTT.Cells["Donem"].Value.ToString();
                double toplamTutarTT = itemTT.Cells["ToplamTutar"].Value.ConDouble();

                foreach (DataGridViewRow itemBeyan in DtgBeyan.Rows)
                {
                    string plakaBeyan = itemBeyan.Cells["Plaka"].Value.ToString();
                    string donemBeyan = itemBeyan.Cells["YakitAlinanDonem"].Value.ToString();
                    string toplamTutarBeyan = itemBeyan.Cells["ToplamFiyat"].Value.ToString();

                    if (plakaTT == plakaBeyan && donemTT == donemBeyan && toplamTutarTT.ConDouble() == toplamTutarBeyan.ConDouble())
                    {
                        DtgUyanlar.Rows.Add();
                        int sonSatir = DtgUyanlar.RowCount - 1;

                        DtgUyanlar.Rows[sonSatir].Cells["UyanlarPlaka"].Value = plakaTT;
                        DtgUyanlar.Rows[sonSatir].Cells["UyanlarDonem"].Value = donemTT;
                        DtgUyanlar.Rows[sonSatir].Cells["UyanlarTutar"].Value = toplamTutarTT;
                        DtgUyanlar.Rows[sonSatir].Cells["UyanlarTablo"].Value = "TAŞIT TANIMA";
                        DtgUyanlar.Rows[sonSatir].Cells["UyanlarOlay"].Value = "UYDU";



                        //DtgTT.Rows.RemoveAt();

                    }


                    /*else
                    {
                        DtgUymayanlar.Rows.Add();
                        int sonSatir = DtgUymayanlar.RowCount - 1;

                        DtgUymayanlar.Rows[sonSatir].Cells["UymayanlarPlaka"].Value = plakaTT;
                        DtgUymayanlar.Rows[sonSatir].Cells["UymayanlarDonem"].Value = donemTT;
                        DtgUymayanlar.Rows[sonSatir].Cells["UymayanlarTutar"].Value = toplamTutarTT;
                        DtgUymayanlar.Rows[sonSatir].Cells["UymayanlarTablo"].Value = "TAŞIT TANIMA";
                        DtgUymayanlar.Rows[sonSatir].Cells["UymayanlarOlay"].Value = "UYMADI";

                    }*/
                }
            }

            // TAŞIT TANIMA İLE YAKIT BEYAN KONTROLÜ BİTTİ

            foreach (DataGridViewRow itemAnlasmali in DtgAnlasmaliPetrol.Rows)
            {
                string plakaAnlasmali = itemAnlasmali.Cells["Plaka"].Value.ToString();
                string donemAnlasmali = itemAnlasmali.Cells["Donem"].Value.ToString();
                double toplamAnlasmali = itemAnlasmali.Cells["ToplamTutar"].Value.ConDouble();

                foreach (DataGridViewRow itemBeyan in DtgBeyan.Rows)
                {
                    string plakaBeyan = itemBeyan.Cells["Plaka"].Value.ToString();
                    string donemBeyan = itemBeyan.Cells["YakitAlinanDonem"].Value.ToString();
                    string toplamTutarBeyan = itemBeyan.Cells["ToplamFiyat"].Value.ToString();

                    if (plakaAnlasmali == plakaBeyan && donemAnlasmali == donemBeyan && toplamAnlasmali.ConDouble() == toplamTutarBeyan.ConDouble())
                    {
                        DtgUyanlar.Rows.Add();
                        int sonSatir = DtgUyanlar.RowCount - 1;

                        DtgUyanlar.Rows[sonSatir].Cells["UyanlarPlaka"].Value = plakaBeyan;
                        DtgUyanlar.Rows[sonSatir].Cells["UyanlarDonem"].Value = donemBeyan;
                        DtgUyanlar.Rows[sonSatir].Cells["UyanlarTutar"].Value = toplamTutarBeyan;
                        DtgUyanlar.Rows[sonSatir].Cells["UyanlarTablo"].Value = "ANLAŞMALI";
                        DtgUyanlar.Rows[sonSatir].Cells["UyanlarOlay"].Value = "UYDU";

                        //DtgAnlasmaliPetrol.Rows.RemoveAt(itemAnlasmali.Index);
                    }
                    /*else
                    {
                        DtgUymayanlar.Rows.Add();
                        int sonSatir = DtgUymayanlar.RowCount - 1;

                        DtgUymayanlar.Rows[sonSatir].Cells["UymayanlarPlaka"].Value = plakaAnlasmali;
                        DtgUymayanlar.Rows[sonSatir].Cells["UymayanlarDonem"].Value = donemAnlasmali;
                        DtgUymayanlar.Rows[sonSatir].Cells["UymayanlarTutar"].Value = toplamAnlasmali;
                        DtgUymayanlar.Rows[sonSatir].Cells["UymayanlarTablo"].Value = "ANLAŞMALI";
                        DtgUymayanlar.Rows[sonSatir].Cells["UymayanlarOlay"].Value = "UYMADI";
                    }*/


                }
            }
            Display();


        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageButceKapat"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void Display()
        {
            AdtgUymayan.Columns["Id"].Visible = false;
            AdtgUymayan.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            AdtgUymayan.Columns["Firma"].HeaderText = "FİRMA";
            AdtgUymayan.Columns["Donem"].Visible = false;
            AdtgUymayan.Columns["Tarih"].HeaderText = "TARİH";
            AdtgUymayan.Columns["DefterNo"].Visible = false;
            AdtgUymayan.Columns["SiraNo"].Visible = false;
            AdtgUymayan.Columns["Personel"].HeaderText = "PERSONEL";
            AdtgUymayan.Columns["Plaka"].HeaderText = "PLAKA";
            AdtgUymayan.Columns["AracSiparisNo"].Visible = false;
            AdtgUymayan.Columns["LitreFiyati"].Visible = false;
            AdtgUymayan.Columns["VerilenLitre"].HeaderText = "VERİLEN LİTRE";
            AdtgUymayan.Columns["ToplamTutar"].HeaderText = "TOPLAM TUTAR";
            AdtgUymayan.Columns["DosyaYolu"].Visible = false;
            AdtgUymayan.Columns["SiparisNo"].Visible = false;
            AdtgUymayan.Columns["AlimTuru"].Visible = false;
            AdtgUymayan.Columns["FisNo"].Visible = false;

            AdtgUymayan2.Columns["Id"].Visible = false;
            AdtgUymayan2.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            //AdtgUymayan2.Columns["Firma"].HeaderText = "FİRMA";
            AdtgUymayan2.Columns["YakitAlinanDonem"].Visible = false;
            AdtgUymayan2.Columns["Tarih"].HeaderText = "TARİH";
            AdtgUymayan2.Columns["BelgeTuru"].Visible = false;
            AdtgUymayan2.Columns["AlinanFirma"].HeaderText = "FİRMA";
            AdtgUymayan2.Columns["Personel"].HeaderText = "PERSONEL";
            AdtgUymayan2.Columns["Plaka"].HeaderText = "PLAKA";
            AdtgUymayan2.Columns["AlimTuru"].Visible = false;
            AdtgUymayan2.Columns["LitreFiyati"].Visible = false;
            AdtgUymayan2.Columns["AlinanLitre"].HeaderText = "VERİLEN LİTRE";
            AdtgUymayan2.Columns["ToplamFiyat"].HeaderText = "TOPLAM TUTAR";
            AdtgUymayan2.Columns["Sayfa"].Visible = false;
            AdtgUymayan2.Columns["BelgeNumarasi"].Visible = false;
            AdtgUymayan2.Columns["YakitTuru"].Visible = false;
            AdtgUymayan2.Columns["Km"].Visible = false;
            AdtgUymayan2.Columns["Aciklama"].Visible = false;


            AdtgUymayan.Columns["Plaka"].DisplayIndex = 0;
            AdtgUymayan.Columns["ToplamTutar"].DisplayIndex = 1;
            AdtgUymayan.Columns["Personel"].DisplayIndex = 2;
            AdtgUymayan.Columns["Tarih"].DisplayIndex = 3;
            AdtgUymayan.Columns["Firma"].DisplayIndex = 4;
            AdtgUymayan.Columns["VerilenLitre"].DisplayIndex = 5;
            AdtgUymayan.Columns["IsAkisNo"].DisplayIndex = 6;

            AdtgUymayan2.Columns["Plaka"].DisplayIndex = 0;
            AdtgUymayan2.Columns["ToplamFiyat"].DisplayIndex = 1;
            AdtgUymayan2.Columns["Personel"].DisplayIndex = 2;
            AdtgUymayan2.Columns["Tarih"].DisplayIndex = 3;
            AdtgUymayan2.Columns["AlinanFirma"].DisplayIndex = 4;
            AdtgUymayan2.Columns["AlinanLitre"].DisplayIndex = 5;
            AdtgUymayan2.Columns["IsAkisNo"].DisplayIndex = 6;


            LblBeyanEksik.Text = AdtgUymayan.RowCount.ToString();
            LblUymayanBildirimYok.Text = AdtgUymayan2.RowCount.ToString();
            LbUymayanlar.Text = DtgUymayanlar.RowCount.ToString();
            LblTTToplam.Text = DtgTT.RowCount.ToString();
            LblAnlasmaliToplam.Text = DtgAnlasmaliPetrol.RowCount.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*if (CmbAy.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Taratacağınız Döneme Ait AY Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbYil.Text == "")
            {
                MessageBox.Show("Lütfen Öncelikle Taratacağınız Döneme Ait YIL Bilgisini Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            donem = CmbAy.Text + " " + CmbYil.Text;

            yakitBeyanlar = yakitManager.YakitKontrolBeyan(donem);
            DtgBeyan.DataSource = yakitBeyanlar;

            yakitAnlasmalilar = yakitDokumManager.YakitKontrolAnlasmali(donem);
            DtgAnlasmaliPetrol.DataSource = yakitAnlasmalilar;

            yakitTasitTanimalar = yakitDokumManager.YakitKontrolTT(donem);
            DtgTT.DataSource = yakitTasitTanimalar;*/
        }
    }
}
