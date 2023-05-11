using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
using Entity.BakimOnarim;
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
using UserInterface.STS;

namespace UserInterface.BakımOnarım
{
    public partial class FrmYolDurumlari : Form
    {
        BolgeKayitManager bolgeKayitManager;
        YolDurumManager yolDurumManager;
        public object[] infos;
        List<BolgeKayit> bolgeKayits = new List<BolgeKayit>();
        List<BolgeKayit> bolgeKayitsEklenen = new List<BolgeKayit>();
        public FrmYolDurumlari()
        {
            InitializeComponent();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            yolDurumManager = YolDurumManager.GetInstance();
        }


        private void FrmYolDurumlari_Load(object sender, EventArgs e)
        {
            UsBolgeleri();
            LblTarih.Text = DateTime.Now.ToString("d");
            LblDonem.Text = DateTime.Now.ConPeriod();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageYolDurumlari"]);
            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }

        }

        void UsBolgeleri()
        {
            if (infos[0].ConInt() == 25 || infos[0].ConInt() == 30 || infos[0].ConInt() == 33 || infos[0].ConInt() == 84 || infos[0].ConInt() == 39 || infos[0].ConInt() == 1140 || infos[0].ConInt() == 1139 || infos[0].ConInt() == 47 || infos[0].ConInt() == 57 || infos[0].ConInt() == 65 || infos[0].ConInt() == 1121 || infos[0].ConInt() == 1148)
            {
                bolgeKayits = bolgeKayitManager.GetList();
                CmbBolgeAdi.DataSource = bolgeKayits;
            }
            else
            {
                bolgeKayits = bolgeKayitManager.GetList(infos[1].ToString());
                CmbBolgeAdi.DataSource = bolgeKayits;
            }

            CmbBolgeAdi.ValueMember = "Id";
            CmbBolgeAdi.DisplayMember = "BolgeAdi";
            CmbBolgeAdi.SelectedValue = "";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (DtgList.RowCount==0)
            {
                MessageBox.Show("Lütfen listeye veri ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string bolgeKontrol = BolgeKontrol();
            if (bolgeKontrol!="OK")
            {
                MessageBox.Show(bolgeKontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow item in DtgList.Rows)
            {
                YolDurum yolDurum = new YolDurum(item.Cells["BolgeAdi"].Value.ToString(), item.Cells["Tarih"].Value.ConDate(), item.Cells["Donem"].Value.ToString(), item.Cells["YolDurumu"].Value.ToString(), item.Cells["Aciklama"].Value.ToString(), infos[1].ToString());

                string mesaj = yolDurumManager.Add(yolDurum);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
        }
        string BolgeKontrol()
        {
            List<BolgeKayit> bolgeEksikler = new List<BolgeKayit>();

            bolgeEksikler = bolgeKayits.Where(x => !bolgeKayitsEklenen.Select(y => y.BolgeAdi).Contains(x.BolgeAdi)).ToList();
            if (bolgeEksikler.Count!=0)
            {
                return bolgeEksikler[0].BolgeAdi + " isimli bölgenin yol durumu bilgisi girilmemiştir!\nLütfen tüm bölgelerinizin yol durumu bilgilerini eksiksiz giriniz!";
            }

            return "OK";
        }
        void Temizle()
        {
            CmbBolgeAdi.SelectedIndex = -1; CmbYolDurumu.SelectedIndex= -1; TxtAciklama.Clear(); DtgList.Rows.Clear();
        }
        
        private void BtnEkle_Click(object sender, EventArgs e)
        {

            if (CmbYolDurumu.Text == "KAPALI" || CmbYolDurumu.Text == "KISMİ")
            {
                if (TxtAciklama.Text == "")
                {
                    MessageBox.Show("Lütfen açıklama giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string kontrol = Control();
            if (kontrol != "OK")
            {
                MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DtgList.Rows.Add();
            int sonSatir = DtgList.RowCount - 1;

            DtgList.Rows[sonSatir].Cells["BolgeAdi"].Value = CmbBolgeAdi.Text;
            DtgList.Rows[sonSatir].Cells["Donem"].Value = LblDonem.Text;
            DtgList.Rows[sonSatir].Cells["Tarih"].Value = LblTarih.Text;
            DtgList.Rows[sonSatir].Cells["YolDurumu"].Value = CmbYolDurumu.Text;
            DtgList.Rows[sonSatir].Cells["Aciklama"].Value = TxtAciklama.Text;

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;

            BolgeKayit bolgeKayit = new BolgeKayit(CmbBolgeAdi.ValueMember.ConInt(), CmbBolgeAdi.Text);
            bolgeKayitsEklenen.Add(bolgeKayit);

            CmbBolgeAdi.SelectedIndex = -1;
            CmbYolDurumu.SelectedIndex= -1;

            

        }
        string Control()
        {
            if (CmbBolgeAdi.Text == "")
            {
                return "Lütfen öncelikle Bölge Adı bilgisini seçiniz!";
            }
            if (CmbYolDurumu.Text == "")
            {
                return "Lütfen öncelikle Yol Durumu bilgisini seçiniz!";
            }
            return "OK";
        }

        private void DtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgList.Rows.RemoveAt(e.RowIndex);
                bolgeKayitsEklenen.RemoveAt(e.RowIndex);
            }
        }
    }
}
