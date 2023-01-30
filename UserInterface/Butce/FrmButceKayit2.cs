using Business.Concreate.Butce;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using Entity.Butce;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.Butce
{
    public partial class FrmButceKayit2 : Form
    {
        ButceManager butceManager;
        ButceKoduManager butceKoduManager;
        SiparislerManager siparislerManager;

        public FrmButceKayit2()
        {
            InitializeComponent();
            butceManager = ButceManager.GetInstance();
            butceKoduManager = ButceKoduManager.GetInstance();
            siparislerManager = SiparislerManager.GetInstance();
        }

        private void FrmButceKayit2_Load(object sender, EventArgs e)
        {
            SiparisDoldur();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageButceKayit"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void ButceKoduKalemi()
        {
            CmbButceKodu.DataSource = butceKoduManager.GetList();
            CmbButceKodu.ValueMember = "Id";
            CmbButceKodu.DisplayMember = "Butcekodu";
            CmbButceKodu.SelectedValue = 0;
        }
        public void SiparisDoldur()
        {
            CmbSiparisNo.DataSource = siparislerManager.GetList();
            CmbSiparisNo.ValueMember = "Id";
            CmbSiparisNo.DisplayMember = "Siparisno";
            CmbSiparisNo.SelectedValue = 0;
        }
        void ToplamAy()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                string[] array = (DtgList.Rows[i].Cells["ButceTutariAylik"].Value.ToString().Split('₺'));
                toplam += Convert.ToDouble(array[1].ConDouble());

            }
            LblButceToplamAy.Text = toplam.ToString("C2");
        }
        void ToplamYıl()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                string[] array = (DtgList.Rows[i].Cells["ButceTutariYillik"].Value.ToString().Split('₺'));
                toplam += Convert.ToDouble(array[1].ConDouble());

            }
            LblButceToplamYil.Text = toplam.ToString("C2");
        }

        private void CmbSiparisNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (start==false)
            //{
            //    return;
            //}
            //Siparisler siparisler = siparislerManager.Get(CmbSiparisNo.SelectedValue.ConInt());
        }

        private void TxtButceTutari_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.';
        }

        private void TxtKisiAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        double AylikTotal(int kisiSayisi, double tutar)
        {
            double aylikTotal = kisiSayisi * tutar;
            return aylikTotal;


        }

        private void TxtKisiAdet_TextChanged(object sender, EventArgs e)
        {
            LblButceTutariAy.Text = AylikTotal(TxtKisiAdet.Text.ConInt(), TxtButceTutari.ConDouble()).ToString("C2");
        }

        private void TxtButceTutari_TextChanged(object sender, EventArgs e)
        {
            LblButceTutariAy.Text = AylikTotal(TxtKisiAdet.Text.ConInt(), TxtButceTutari.Text.ConDouble()).ToString("C2");
        }

        private void LblButceTutariAy_TextChanged(object sender, EventArgs e)
        {
            TotalDonem();
        }
        void TotalDonem()
        {
            string aylikTutar = LblButceTutariAy.Text;

            string[] array = aylikTutar.Split('₺');

            double total = array[1].ConDouble() * 6;
            LblButceTutariDonem.Text = total.ToString("C2");

        }
        string Control()
        {
            if (CmbButceYil.Text == "")
            {
                return "Lütfen öncelikle Bütçe Yıl bilgisini doldurunuz!";
            }
            if (CmbButceDonem.Text == "")
            {
                return "Lütfen öncelikle Bütçe Dönem bilgisini doldurunuz!";
            }
            if (CmbButceKodu.Text == "")
            {
                return "Lütfen öncelikle Bütçe Kodu bilgisini doldurunuz!";
            }
            if (TxtKisiAdet.Text == "")
            {
                return "Lütfen öncelikle Kişi Sayısı bilgisini doldurunuz!";
            }
            if (TxtButceTutari.Text == "")
            {
                return "Lütfen öncelikle Butçe Tutarı(Aylık) bilgisini doldurunuz!";
            }

            foreach (DataGridViewRow item in DtgList.Rows)
            {
                if (item.Cells["ButceTanim"].Value.ToString() == CmbButceKodu.Text)
                {
                    return CmbButceKodu.Text + " bütçe kodu zaten eklendi!";
                }
            }

            if (donem!="")
            {
                if (donem != CmbButceDonem.Text)
                {
                    return "Lütfen öncelikle " + donem + " dönemine ait kayıtları tamamlayınız!";
                }
            }

            return "OK";
        }

       

        string KayitControl()
        {
            if (!butceler.Contains("BM12/YERLEŞKE GİDERLERİ"))
            {
                return "BM12/YERLEŞKE GİDERLERİ bütçe kodunu girmediniz!";
            }
            if (!butceler.Contains("BM21/İAŞE"))
            {
                return "BM21/İAŞE bütçe kodunu girmediniz!";
            }
            if (!butceler.Contains("BM23/ÖZEL SİGRT. GİDERLERİ"))
            {
                return "BM23/ÖZEL SİGRT. GİDERLERİ bütçe kodunu girmediniz!";
            }
            if (!butceler.Contains("BM24/PERS. İLETİŞİM GİDERLERİ"))
            {
                return "BM24/PERS. İLETİŞİM GİDERLERİ bütçe kodunu girmediniz!";
            }
            if (!butceler.Contains("BM26/ARAÇ TAHSİS GİDERLERİ"))
            {
                return "BM26/ARAÇ TAHSİS GİDERLERİ bütçe kodunu girmediniz!";
            }
            if (!butceler.Contains("BM45/PERSONEL MAAŞ YANSIMASI"))
            {
                return "BM45/PERSONEL MAAŞ YANSIMASI bütçe kodunu girmediniz!";
            }
            if (!butceler.Contains("BM46/ARAÇ YAKIT GİDERLERİ"))
            {
                return "BM46/ARAÇ YAKIT GİDERLERİ bütçe kodunu girmediniz!";
            }
            if (!butceler.Contains("BM25/PERS. MAAŞ GİDERLERİ"))
            {
                return "BM25/PERS. MAAŞ GİDERLERİ bütçe kodunu girmediniz!";
            }
            return "OK";
        }
        void Temizle()
        {
            CmbButceYil.SelectedIndex = -1; CmbButceDonem.SelectedIndex = -1; CmbButceKodu.SelectedIndex = -1; CmbSiparisNo.SelectedIndex = -1;
            TxtKisiAdet.Clear(); TxtButceTutari.Clear();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            ToplamAy();
            ToplamYıl();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void DtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DtgList.Rows.RemoveAt(e.RowIndex);
                butceler.RemoveAt(e.RowIndex);
                ToplamAy();
                ToplamYıl();

            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (DtgList.RowCount == 0)
            {
                MessageBox.Show("Lütfen öncelikle tabloya veri ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string kontrol = KayitControl();
            if (kontrol != "OK")
            {
                MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    ButceKayit butceKayit = new ButceKayit(item.Cells["Yil"].Value.ToString(), item.Cells["Donem"].Value.ToString(), item.Cells["ButceTanim"].Value.ToString(), item.Cells["SiparisNo"].Value.ToString(), item.Cells["KisiSayisi"].Value.ConInt(), item.Cells["ButceTutari"].Value.ToString(), item.Cells["ButceTutariAylik"].Value.ToString(), item.Cells["ButceTutariYillik"].Value.ToString());

                    butceManager.Add(butceKayit);
                }
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                ToplamAy();
                ToplamYıl();
                DtgList.DataSource = null;
                donem = "";
                butceler.Clear();
            }
        }

        List<ButceKayit> butceKayits = new List<ButceKayit>();
        List<string> butceler = new List<string>();
        string donem = "";

        private void BtnEkle_Click_1(object sender, EventArgs e)
        {
            string kontrol = Control();
            if (kontrol != "OK")
            {
                MessageBox.Show(kontrol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ButceKayit butceKayit = new ButceKayit(CmbButceYil.Text, CmbButceDonem.Text, CmbButceKodu.Text, CmbSiparisNo.Text, TxtKisiAdet.Text.ConInt(), TxtButceTutari.Text, LblButceTutariAy.Text, LblButceTutariDonem.Text);
            butceKayits.Add(butceKayit);
            butceler.Add(CmbButceKodu.Text);

            dataBinder.DataSource = null;
            DtgList.DataSource = null;

            dataBinder.DataSource = butceKayits.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Yil"].HeaderText = "YIL";
            DtgList.Columns["Donem"].HeaderText = "DÖNEM";
            DtgList.Columns["ButceTanim"].HeaderText = "BÜTÇE TANIMI";
            DtgList.Columns["SiparisNo"].HeaderText = "SİPARİŞ NO";
            DtgList.Columns["KisiSayisi"].HeaderText = "KİŞİ SAYISI";
            DtgList.Columns["ButceTutari"].HeaderText = "BÜTÇE TUTARI";
            DtgList.Columns["ButceTutariAylik"].HeaderText = "BÜTÇE TUTARI AYLIK";
            DtgList.Columns["ButceTutariYillik"].HeaderText = "BÜTÇE TUTARI DÖNEM";

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)DtgList.Columns["Remove"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Red;
            c.DefaultCellStyle.BackColor = Color.Gainsboro;
            c.Visible = true;

            DtgList.Columns["Remove"].DisplayIndex = 9;

            donem = CmbButceDonem.Text;

            //DtgList.Rows.Add();
            //int sonSatir = DtgList.RowCount - 1;

            //DtgList.Rows[sonSatir].Cells["Yil"].Value = CmbButceYil.Text;
            //DtgList.Rows[sonSatir].Cells["Donem"].Value = CmbButceDonem.Text;
            //DtgList.Rows[sonSatir].Cells["ButceTanimi"].Value = CmbButceKodu.Text;
            //DtgList.Rows[sonSatir].Cells["SiparisNumarasi"].Value = CmbSiparisNo.Text;
            //DtgList.Rows[sonSatir].Cells["KisiAdet"].Value = TxtKisiAdet.Text;
            //DtgList.Rows[sonSatir].Cells["ButceTutar"].Value = TxtButceTutari.Text;
            //DtgList.Rows[sonSatir].Cells["ButceTutarAy"].Value = LblButceTutariAy.Text;
            //DtgList.Rows[sonSatir].Cells["ButceTutarDonem"].Value = LblButceTutariDonem.Text;
            Temizle();
            ToplamAy();
            ToplamYıl();
        }
    }
}
