using Business.Concreate.AnaSayfa;
using Business.Concreate.BakimOnarim;
using DataAccess.Concreate;
using DataAccess.Concreate.BakimOnarim;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity.AnaSayfa;
using Entity.BakimOnarim;
using Entity.IdariIsler;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;
using Application = System.Windows.Forms.Application;
using Color = System.Drawing.Color;

namespace UserInterface.BakımOnarım
{
    public partial class FrmYolDurumlari : Form
    {
        BolgeKayitManager bolgeKayitManager;
        YolDurumManager yolDurumManager;
        DtsLogManager dtsLogManager;
        public object[] infos;
        List<BolgeKayit> bolgeKayits = new List<BolgeKayit>();
        List<BolgeKayit> bolgeKayitsEklenen = new List<BolgeKayit>();
        int index = 0;
        public bool anaSayfaYonlendirme = false;
        public FrmYolDurumlari()
        {
            InitializeComponent();
            bolgeKayitManager = BolgeKayitManager.GetInstance();
            yolDurumManager = YolDurumManager.GetInstance();
            dtsLogManager = DtsLogManager.GetInstance();
        }


        private void FrmYolDurumlari_Load(object sender, EventArgs e)
        {
            UsBolgeleri();
            DtTarih.Text = DateTime.Now.ToString("d");
            LblDonem.Text = DtTarih.Value.ConPeriod();
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
                foreach (BolgeKayit item in bolgeKayits)
                {
                    DtgBolgeler.Rows.Add();
                    int sonSatir = DtgBolgeler.RowCount - 1;
                    DtgBolgeler.Rows[sonSatir].Cells["Bolge"].Value = item.BolgeAdi;
                    DtgBolgeler.Rows[sonSatir].Cells["Id"].Value = index;
                    index++;
                }
            }
            else
            {
                bolgeKayits = bolgeKayitManager.GetList(infos[1].ToString());
                CmbBolgeAdi.DataSource = bolgeKayits;
                foreach (BolgeKayit item in bolgeKayits)
                {
                    DtgBolgeler.Rows.Add();
                    int sonSatir = DtgBolgeler.RowCount - 1;
                    DtgBolgeler.Rows[sonSatir].Cells["Bolge"].Value = item.BolgeAdi;
                    DtgBolgeler.Rows[sonSatir].Cells["Id"].Value = index;
                    index++;
                }
            }

            CmbBolgeAdi.ValueMember = "Id";
            CmbBolgeAdi.DisplayMember = "BolgeAdi";
            CmbBolgeAdi.SelectedValue = "";
            LblTop.Text = DtgBolgeler.RowCount.ToString();
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
            DtsLogKayit();
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            frmAnaSayfa.anaSayfaYonlendirme = true;
            frmAnaSayfa.TreeMenu.Enabled = true;
            frmAnaSayfa.toolStrip1.Enabled = true;
            frmAnaSayfa.PnlBildirim.Enabled = true;
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
        }
        void DtsLogKayit()
        {
            string islem = "Bölge yol durumları kaydedilmiştir.";
            DtsLog dtsLog = new DtsLog(infos[1].ToString(), DateTime.Now, "BÖLGE YOL DURUMLARI", islem);
            dtsLogManager.Add(dtsLog);
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
            UsBolgeleri();
            DtTarih.Text = DateTime.Now.ToString("d");
            LblDonem.Text = DtTarih.Value.ConPeriod();
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

            if (CmbYolDurumu.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Yol Durumu bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool secim = false;
            foreach (DataGridViewRow item in DtgBolgeler.Rows)
            {
                if (item.Cells["Secim"].Value.ConBool()==true)
                {
                    secim = true;
                    DtgList.Rows.Add();
                    int sonSatir = DtgList.RowCount - 1;
                    LblDonem.Text = DtTarih.Value.ConPeriod();
                    DtgList.Rows[sonSatir].Cells["BolgeAdi"].Value = item.Cells["Bolge"].Value;
                    DtgList.Rows[sonSatir].Cells["Donem"].Value = LblDonem.Text;
                    DtgList.Rows[sonSatir].Cells["Tarih"].Value = DtTarih.Value.ToString("d");
                    DtgList.Rows[sonSatir].Cells["YolDurumu"].Value = CmbYolDurumu.Text;
                    DtgList.Rows[sonSatir].Cells["Aciklama"].Value = TxtAciklama.Text;
                    DtgList.Rows[sonSatir].Cells["Idd"].Value = item.Cells["Id"].Value;


                    DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Remove"];
                    c.FlatStyle = FlatStyle.Popup;
                    c.DefaultCellStyle.ForeColor = Color.Red;
                    c.DefaultCellStyle.BackColor = Color.Gainsboro;

                    BolgeKayit bolgeKayit = new BolgeKayit(index, item.Cells["Bolge"].Value.ToString(), true);
                    bolgeKayitsEklenen.Add(bolgeKayit);
                    index++;
                }
            }
            if (secim == false)
            {
                MessageBox.Show("Lütfen eklemek istediğiniz üs bölgesi bilgilerini tablodan işaretleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (BolgeKayit item in bolgeKayitsEklenen)
            {
                index = 0;
                foreach (BolgeKayit item2 in bolgeKayits)
                {
                    if (item.BolgeAdi== item2.BolgeAdi)
                    {
                        bolgeKayits.RemoveAt(index);
                        break;
                    }
                    index++;
                }
            }

            bolgeKayitsEklenen.Clear();

            DtgBolgeler.Rows.Clear();
            foreach (BolgeKayit item in bolgeKayits)
            {
                DtgBolgeler.Rows.Add();
                int sonSatir = DtgBolgeler.RowCount - 1;
                DtgBolgeler.Rows[sonSatir].Cells["Bolge"].Value = item.BolgeAdi;
                DtgBolgeler.Rows[sonSatir].Cells["Id"].Value = item.Id;
            }
            LblTop2.Text = DtgList.RowCount.ToString();
            LblTop.Text = DtgBolgeler.RowCount.ToString();
        }

        private void DtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgList.Rows.RemoveAt(e.RowIndex);

                if (bolge=="")
                {
                    idd = DtgBolgeler.RowCount + 1;
                    bolge = DtgList.CurrentRow.Cells["BolgeAdi"].Value.ToString();
                }
                

                BolgeKayit bolgeKayit = new BolgeKayit(idd, bolge, false);
                bolgeKayits.Add(bolgeKayit);

                DtgBolgeler.Rows.Clear();
                foreach (BolgeKayit item in bolgeKayits)
                {
                    DtgBolgeler.Rows.Add();
                    int sonSatir = DtgBolgeler.RowCount - 1;
                    DtgBolgeler.Rows[sonSatir].Cells["Bolge"].Value = item.BolgeAdi;
                    DtgBolgeler.Rows[sonSatir].Cells["Id"].Value = item.Id;
                }

                LblTop2.Text = DtgList.RowCount.ToString();
                LblTop.Text = DtgBolgeler.RowCount.ToString();
                bolge = "";

            }
        }
        int idd;
        string bolge = "";
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            idd = DtgBolgeler.RowCount + 1;
            bolge = DtgList.CurrentRow.Cells["BolgeAdi"].Value.ToString();

        }
    }
}
