using Business.Concreate.BakimOnarim;
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
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmBolgeler : Form
    {
        public bool buton = false;
        string il;
        int id;
        List<Bolge> bolges = new List<Bolge>();
        BolgeManager bolgeManager;
        TedarikciFirmaManager tedarikciFirmaManager;
        bool start;
        public FrmBolgeler()
        {
            InitializeComponent();
            bolgeManager = BolgeManager.GetInstance();
            tedarikciFirmaManager = TedarikciFirmaManager.GetInstance();
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
            start = false;
            if (buton == true)
            {
                BtnCancel.Visible = false;
                return;
            }
            BtnCancel.Visible = true;
        }
        void DataDisplay()
        {
            bolges = bolgeManager.GetList();
            dataBinder.DataSource = bolges.ToDataTable();
            DtgBolgeler.DataSource = dataBinder;
            TxtTop.Text = DtgBolgeler.RowCount.ToString();

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
                Bolge bolge = new Bolge(TxtBolgeAdi.Text, TxtIlgiliPersonel.Text,TxtBirlikAdresi.Text,TxtTelefon.Text,"N/A", CmbPypNo.Text, TxtBolgeSorumlusuSicil.Text, CmbIl.Text, CmbIlce.Text, CmbProje.Text, DtGarantİBasTarihi.Value.ToString("dd,MM,yyyy"), DtGarantİBitTarihi.Value.ToString("dd,MM,yyyy"), TxtSSPersonel.Text, TxtSSPGorevi.Text, TxtSSPRutbe.Text, CmbDepo.Text);

                string mesaj = bolgeManager.Add(bolge);

                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                DataDisplay();
                Temizle();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen Öncelikle Geçerli Bir Kayıt Seçiniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            Bolge bolge = new Bolge(id,TxtBolgeAdi.Text, TxtIlgiliPersonel.Text, TxtBirlikAdresi.Text, TxtTelefon.Text, "N/A", CmbPypNo.Text, TxtBolgeSorumlusuSicil.Text, CmbIl.Text, CmbIlce.Text, CmbProje.Text, DtGarantİBasTarihi.Value.ToString("dd,MM,yyyy"), DtGarantİBitTarihi.Value.ToString("dd,MM,yyyy"), TxtSSPersonel.Text, TxtSSPGorevi.Text, TxtSSPRutbe.Text, CmbDepo.Text);

            string mesaj = bolgeManager.Update(bolge);

            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Bilgiler Başarıyla Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataDisplay();
            Temizle();
        }

        private void DtgBolgeler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgBolgeler.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            id = DtgBolgeler.CurrentRow.Cells["Id"].Value.ConInt();

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
            TxtBolgeAdi.Clear(); TxtIlgiliPersonel.Clear(); TxtTelefon.Clear(); CmbIl.SelectedValue = ""; CmbIlce.SelectedValue = ""; TxtBirlikAdresi.Clear(); CmbDepo.SelectedValue = ""; CmbProje.SelectedValue = ""; CmbPypNo.SelectedValue = ""; TxtBolgeSorumlusuSicil.Clear(); TxtBolgeSorumlusuAd.Clear(); TxtSSPersonel.Clear(); TxtSSPRutbe.Clear(); TxtSSPGorevi.Clear();
        }
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
