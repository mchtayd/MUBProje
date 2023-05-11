using Business.Concreate.Depo;
using Business.Concreate.STS;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity.BakimOnarim;
using Entity.Depo;
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
using UserInterface.BakımOnarım;
using UserInterface.STS;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmDepoAdresKayit : Form
    {
        public object[] infos;
        TedarikciFirmaManager tedarikciFirmaManager;
        DepoKayitManagercs depoKayitManagercs;

        List<DepoKayit> depoKayits = new List<DepoKayit>();
        bool start;
        string il;
        int id;
        public FrmDepoAdresKayit()
        {
            InitializeComponent();
            tedarikciFirmaManager = TedarikciFirmaManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
        }

        private void FrmDepoAdresKayit_Load(object sender, EventArgs e)
        {
            DataDisplay();
            CmbIlYükle();
            start = false;
        }


        void CmbIlYükle()
        {
            CmbIl.DataSource = tedarikciFirmaManager.Iller();
            CmbIl.SelectedIndex = -1;
            CmbIlce.Text = "";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageDepolar"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
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
            CmbIlce.SelectedIndex = -1;
            CmbIlce.Text = "";
        }

        void DataDisplay()
        {
            depoKayits = depoKayitManagercs.GetList();
            dataBinder.DataSource = depoKayits.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Depo"].HeaderText = "DEPO NO";
            DtgList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgList.Columns["DepoAdi"].HeaderText = "DEPO ADI";
            DtgList.Columns["Il"].HeaderText = "İL";
            DtgList.Columns["Ilce"].HeaderText = "İLÇE";

            DtgList.Columns["Id"].DisplayIndex = 0;
            DtgList.Columns["Depo"].DisplayIndex = 1;
            DtgList.Columns["DepoAdi"].DisplayIndex = 2;
            DtgList.Columns["Il"].DisplayIndex = 3;
            DtgList.Columns["Ilce"].DisplayIndex = 4;
            DtgList.Columns["Aciklama"].DisplayIndex = 5;

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string control = Control();
            if (control=="OK")
            {
                DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes)
                {
                    return;
                }
                DepoKayit depoKayit = new DepoKayit(TxtDepoNo.Text, TxtAciklama.Text, TxtDepoAdi.Text, CmbIl.Text, CmbIlce.Text);
                string mesaj = depoKayitManagercs.Add(depoKayit);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            else
            {
                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataDisplay();
            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
        }
        void Temizle()
        {
            TxtDepoNo.Clear(); TxtDepoAdi.Clear(); CmbIl.Text = ""; CmbIlce.Text = ""; TxtAciklama.Clear();
        }
        string Control()
        {
            if (TxtDepoNo.Text=="")
            {
                return "Lütfen Depo No bilgisini doldurunuz!";
            }
            if (TxtDepoAdi.Text=="")
            {
                return "Lütfen Depo Adı bilgisini doldurunuz!";
            }
            if (CmbIl.Text == "")
            {
                return "Lütfen İl bilgisini doldurunuz!";
            }
            if (CmbIlce.Text == "")
            {
                return "Lütfen İlçe bilgisini doldurunuz!";
            }
            return "OK";
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            TxtDepoNo.Text = DtgList.CurrentRow.Cells["Depo"].Value.ToString();
            TxtAciklama.Text = DtgList.CurrentRow.Cells["Aciklama"].Value.ToString();
            TxtDepoAdi.Text = DtgList.CurrentRow.Cells["DepoAdi"].Value.ToString();
            CmbIl.Text = DtgList.CurrentRow.Cells["Il"].Value.ToString();
            CmbIlce.Text = DtgList.CurrentRow.Cells["Ilce"].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            string control = Control();
            if (control == "OK")
            {
                DialogResult dr = MessageBox.Show("Bilgileri güncellemek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr!=DialogResult.Yes)
                {
                    return;
                }
                DepoKayit depoKayit = new DepoKayit(id,TxtDepoNo.Text, TxtAciklama.Text, TxtDepoAdi.Text, CmbIl.Text, CmbIlce.Text);
                string mesaj = depoKayitManagercs.Update(depoKayit);
                if (mesaj != "OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                MessageBox.Show(control, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataDisplay();
            MessageBox.Show("Bilgiler başarıyla güncellenmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            id = 0;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }
            string mesaj = depoKayitManagercs.Delete(id);
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataDisplay();
            MessageBox.Show("Bilgiler başarıyla silinmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            id = 0;
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void BtnLokasyonEdit_Click(object sender, EventArgs e)
        {
            FrmDepoLokasyonKayit frmDepoLokasyonKayit = new FrmDepoLokasyonKayit();
            frmDepoLokasyonKayit.ShowDialog();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
