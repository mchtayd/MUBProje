using Business;
using Business.Concreate.BakimOnarim;
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

namespace UserInterface.BakımOnarım
{
    public partial class FrmGarantiSureleri : Form
    {

        BolgeGarantiManager bolgeGarantiManager;
        BolgeKayitManager bolgeKayitManager;
        ComboManager comboManager;

        List<BolgeGaranti> bolgeGarantis;
        string comboAd;
        string toplamYilAy;
        public string siparisNo = "";
        public int id;

        public FrmGarantiSureleri()
        {
            InitializeComponent();
            comboManager = ComboManager.GetInstance();
            bolgeGarantiManager = BolgeGarantiManager.GetInstance();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
        }

        private void FrmGarantiSureleri_Load(object sender, EventArgs e)
        {
            ComboYasamAlani();
            DataDisplay();
        }
        void DataDisplay()
        {
            bolgeGarantis = bolgeGarantiManager.GetListTumu(siparisNo);

            if (bolgeGarantis.Count==0)
            {
                return;
            }

            foreach (BolgeGaranti item in bolgeGarantis)
            {
                DtgList.Rows.Add();
                int sonSatir = DtgList.Rows.Count - 1;

                DtgList.Rows[sonSatir].Cells["GarantiPaketi"].Value = item.GarantiPaketi; 
                DtgList.Rows[sonSatir].Cells["BasTarihi"].Value = item.GarantiBaslama;
                DtgList.Rows[sonSatir].Cells["BitTarihi"].Value = item.GarantiBitis;
                DtgList.Rows[sonSatir].Cells["TopSure"].Value = item.ToplamSure;

                DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Remove"];
                c.FlatStyle = FlatStyle.Popup;
                c.DefaultCellStyle.ForeColor = Color.Red;
                c.DefaultCellStyle.BackColor = Color.Gainsboro;
            }

            siparisNo = bolgeGarantis[0].SiparisNo;

        }
        
        public void ComboYasamAlani()
        {
            CmbGarantiPaketi.DataSource = comboManager.GetList("GARANTI_PAKETI");
            CmbGarantiPaketi.ValueMember = "Id";
            CmbGarantiPaketi.DisplayMember = "Baslik";
            CmbGarantiPaketi.SelectedValue = 0;
        }

        private void BtnGarantiPaketi_Click(object sender, EventArgs e)
        {
            comboAd = "GARANTI_PAKETI";
            FrmCombo frmCombo = new FrmCombo();
            frmCombo.comboAd = comboAd;
            frmCombo.ShowDialog();
        }
        string YilHesapla(DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            TimeSpan sonuc = bitisTarihi - baslangicTarihi;
            int gun = sonuc.TotalDays.ConInt();
            string yil = (gun / 365).ToString() + " Yıl";
            string ay = (gun / 30).ToString() + " Ay";

            if (yil=="0 Yıl")
            {
                return ay;
            }

            return yil;
        }

        private void BtnListeyeEkle_Click(object sender, EventArgs e)
        {

            if (CmbGarantiPaketi.Text=="")
            {
                MessageBox.Show("Lütfen öncelikle GARANTİ PAKETİ bilgisini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            toplamYilAy = YilHesapla(DtBaslamaTarihi.Value, DtBitisTarihi.Value);

            //if (toplamYil == "0 Yıl")
            //{
            //    MessageBox.Show("Garanti toplam süresi 0 olamaz. Lütfen geçerli bir tarih giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (siparisNo=="")
            {
                siparisNo = Guid.NewGuid().ToString();
            }

            DtgList.Rows.Add();
            int sonSatir = DtgList.Rows.Count - 1;

            DtgList.Rows[sonSatir].Cells["GarantiPaketi"].Value = CmbGarantiPaketi.Text;
            DtgList.Rows[sonSatir].Cells["BasTarihi"].Value = DtBaslamaTarihi.Value.ToString("dd.MM.yyyy");
            DtgList.Rows[sonSatir].Cells["BitTarihi"].Value = DtBitisTarihi.Value.ToString("dd.MM.yyyy");
            DtgList.Rows[sonSatir].Cells["TopSure"].Value = toplamYilAy;

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;

        }


        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinze emin misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {

                string mesaj = bolgeGarantiManager.Delete(siparisNo);
                
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                mesaj = bolgeKayitManager.UpdateSiparisNo(id, siparisNo);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    BolgeGaranti bolgeGaranti = new BolgeGaranti(item.Cells["GarantiPaketi"].Value.ToString(), item.Cells["BasTarihi"].Value.ConDate(),
                        item.Cells["BitTarihi"].Value.ConDate(), item.Cells["TopSure"].Value.ToString(), siparisNo);

                    bolgeGarantiManager.Add(bolgeGaranti);
                }
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                
            }
        }

        private void kToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DtgList.Rows.RemoveAt(DtgList.SelectedRows[0].Index);
        }

        private void DtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgList.Rows.RemoveAt(e.RowIndex);
            }
        }

    }
}
