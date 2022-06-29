using Business;
using Business.Concreate.BakimOnarim;
using Business.Concreate.Depo;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmBolgeler : Form
    {
        public bool buton = false;
        string il, comboAd;
        int id;
        List<Bolge> bolges = new List<Bolge>();
        BolgeManager bolgeManager;
        ComboManager comboManager;
        PypManager pypManager;
        DepoKayitManagercs depoKayitManagercs;
        TedarikciFirmaManager tedarikciFirmaManager;
        bool start;
        public FrmBolgeler()
        {
            InitializeComponent();
            bolgeManager = BolgeManager.GetInstance();
            tedarikciFirmaManager = TedarikciFirmaManager.GetInstance();
            comboManager = ComboManager.GetInstance();
            pypManager = PypManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
        }

        private void BtnCancel_Click_1(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageBolgeler"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmBolgeler_Load(object sender, EventArgs e)
        {
            DataDisplay();
            CmbIlYükle();
            ComboProje();
            ComboPypNo();
            ComboDepo();
            start = false;
            if (buton == true)
            {
                BtnCancel.Visible = false;
                return;
            }
            BtnCancel.Visible = true;
        }
        public void ComboProje()
        {
            CmbProje.DataSource = comboManager.GetList("PROJE");
            CmbProje.ValueMember = "Id";
            CmbProje.DisplayMember = "Baslik";
            CmbProje.SelectedValue = 0;
        }
        public void ComboDepo()
        {
            CmbDepo.DataSource = depoKayitManagercs.GetList();
            CmbDepo.ValueMember = "Id";
            CmbDepo.DisplayMember = "Depo";
            CmbDepo.SelectedValue = 0;
        }
        public void ComboPypNo()
        {
            CmbPypNo.DataSource = pypManager.GetList();
            CmbPypNo.ValueMember = "Id";
            CmbPypNo.DisplayMember = "PypNo";
            CmbPypNo.SelectedValue = 0;
        }
        void DataDisplay()
        {
            bolges = bolgeManager.GetList();
            dataBinder.DataSource = bolges.ToDataTable();
            DtgBolgeler.DataSource = dataBinder;
            //TxtTop.Text = DtgBolgeler.RowCount.ToString();

            DtgBolgeler.Columns["Id"].Visible = false;
            DtgBolgeler.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgBolgeler.Columns["IlgiliPersonel"].HeaderText = "İLGİLİ PERSONEL";
            DtgBolgeler.Columns["BirlikAdresi"].HeaderText = "BİRLİK ADRESİ";
            DtgBolgeler.Columns["Telefon"].HeaderText = "TELEFON";
            DtgBolgeler.Columns["FaturaAdresi"].HeaderText = "FATURA ADRESİ";
            DtgBolgeler.Columns["PypNo"].HeaderText = "PYP NO";
            DtgBolgeler.Columns["SorumluSicil"].HeaderText = "BÖLGE SORUMLUSU SİCİL";
            DtgBolgeler.Columns["Il"].HeaderText = "İL";
            DtgBolgeler.Columns["Ilce"].HeaderText = "İLÇE";
            DtgBolgeler.Columns["Proje"].HeaderText = "PROJE";
            DtgBolgeler.Columns["GarantiBaslama"].HeaderText = "GARANTİ BAŞLAMA";
            DtgBolgeler.Columns["GarantiBitis"].HeaderText = "GARANTİ BİTİŞ";
            DtgBolgeler.Columns["SsPersonel"].HeaderText = "SORUMLU PERSONEL";
            DtgBolgeler.Columns["SspGorev"].HeaderText = "SORUMLU PERSONEL GÖREVİ";
            DtgBolgeler.Columns["Depo"].HeaderText = "DEPO";
            DtgBolgeler.Columns["SsRutbe"].HeaderText = "SORUMLU PERSONEL RÜTBE";
        }

        private void BtnPYPEkle_Click(object sender, EventArgs e)
        {
            FrmPyp frmPyp = new FrmPyp();
            frmPyp.ShowDialog();
        }
        void CmbIlYükle()
        {
            CmbIl.DataSource = tedarikciFirmaManager.Iller();
            CmbIl.SelectedIndex = -1;
            CmbIlce.Text = "";
        }

        private void CmbIl_SelectedValueChanged(object sender, EventArgs e)
        {
            il = CmbIl.Text;
            CmbIlceYükle();
        }
        void CmbIlceYükle()
        {
            if (start)
            {
                return;
            }
            CmbIlce.DataSource = tedarikciFirmaManager.Ilceler(il);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri Kaydetmek İstiyor Musunuz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                /*Bolge bolge = new Bolge(TxtBolgeAdi.Text, TxtIlgiliPersonel.Text,TxtBirlikAdresi.Text,TxtTelefon.Text,"N/A", CmbPypNo.Text, TxtBolgeSorumlusuSicil.Text, CmbIl.Text, CmbIlce.Text, CmbProje.Text, DtGarantİBasTarihi.Value.ToString("dd,MM,yyyy"), DtGarantİBitTarihi.Value.ToString("dd,MM,yyyy"), TxtSSPersonel.Text, TxtSSPGorevi.Text, TxtSSPRutbe.Text, CmbDepo.Text);

                string mesaj = bolgeManager.Add(bolge);

                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                DataDisplay();
                Temizle();*/
            }
        }
        void Yenilenecekler()
        {

        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir Kayıt Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            /*Bolge bolge = new Bolge(id,TxtBolgeAdi.Text, TxtIlgiliPersonel.Text, TxtBirlikAdresi.Text, TxtTelefon.Text, "N/A", CmbPypNo.Text, TxtBolgeSorumlusuSicil.Text, CmbIl.Text, CmbIlce.Text, CmbProje.Text, DtGarantİBasTarihi.Value.ToString("dd,MM,yyyy"), DtGarantİBitTarihi.Value.ToString("dd,MM,yyyy"), TxtSSPersonel.Text, TxtSSPGorevi.Text, TxtSSPRutbe.Text, CmbDepo.Text);

            string mesaj = bolgeManager.Update(bolge);

            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataDisplay();
            Temizle();*/
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr= MessageBox.Show("Bölge Kaydını Silmek İstediğize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string mesaj = bolgeManager.Delete(id);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                DataDisplay();
                Temizle();
            }

        }
        void Temizle()
        {
            /*TxtBolgeAdi.Clear(); TxtIlgiliPersonel.Clear(); TxtTelefon.Clear(); CmbIl.Text = ""; CmbIlce.Text = ""; TxtBirlikAdresi.Clear(); CmbDepo.SelectedValue = ""; CmbProje.SelectedValue = ""; CmbPypNo.SelectedValue = ""; TxtBolgeSorumlusuSicil.Clear(); TxtBolgeSorumlusuAd.Clear(); TxtSSPersonel.Clear(); TxtSSPRutbe.Clear(); TxtSSPGorevi.Clear();*/
        }
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void DtgBolgeler_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgBolgeler.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            id = DtgBolgeler.CurrentRow.Cells["Id"].Value.ConInt();
            TxtBolgeAdi.Text=DtgBolgeler.CurrentRow.Cells["BolgeAdi"].Value.ToString();
            /*TxtIlgiliPersonel.Text= DtgBolgeler.CurrentRow.Cells["IlgiliPersonel"].Value.ToString();
            TxtTelefon.Text= DtgBolgeler.CurrentRow.Cells["Telefon"].Value.ToString();*/
            CmbIl.Text= DtgBolgeler.CurrentRow.Cells["Il"].Value.ToString();
            CmbIlce.Text= DtgBolgeler.CurrentRow.Cells["Ilce"].Value.ToString();
            TxtBirlikAdresi.Text= DtgBolgeler.CurrentRow.Cells["BirlikAdresi"].Value.ToString();
            CmbDepo.Text= DtgBolgeler.CurrentRow.Cells["Depo"].Value.ToString();
            DtGarantİBasTarihi.Value= DtgBolgeler.CurrentRow.Cells["GarantiBaslama"].Value.ConDate();
            DtGarantİBitTarihi.Value = DtgBolgeler.CurrentRow.Cells["GarantiBitis"].Value.ConDate();
            CmbProje.Text= DtgBolgeler.CurrentRow.Cells["Proje"].Value.ToString(); 
            CmbPypNo.Text= DtgBolgeler.CurrentRow.Cells["PypNo"].Value.ToString();
            TxtBolgeSorumlusuSicil.Text= DtgBolgeler.CurrentRow.Cells["SorumluSicil"].Value.ToString();
            TxtBolgeSorumlusuAd.Text = "";
            /*TxtSSPersonel.Text= DtgBolgeler.CurrentRow.Cells["SsPersonel"].Value.ToString();
            TxtSSPRutbe.Text= DtgBolgeler.CurrentRow.Cells["SsRutbe"].Value.ToString();
            TxtSSPGorevi.Text= DtgBolgeler.CurrentRow.Cells["SspGorev"].Value.ToString();*/

        }

        private void BtnDepoEkle_Click(object sender, EventArgs e)
        {
            FrmDepoLokasyonKayit frmDepoLokasyonKayit = new FrmDepoLokasyonKayit();
            frmDepoLokasyonKayit.ShowDialog();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void buton_proje_Click(object sender, EventArgs e)
        {
            comboAd = "PROJE";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }
    }
}
