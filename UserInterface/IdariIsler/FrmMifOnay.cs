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
using UserInterface.STS;

namespace UserInterface.IdariIsler
{
    public partial class FrmMifOnay : Form
    {
        MalzemeTalepManager malzemeTalepManager;
        List<MalzemeTalep> malzemeTaleps;

        string tanim, personel;
        public object[] infos;
        int id;
        public FrmMifOnay()
        {
            InitializeComponent();
            malzemeTalepManager = MalzemeTalepManager.GetInstance();
        }

        private void FrmMifOnay_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)System.Windows.Forms.Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageMifOnay"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }
        public void DataDisplay()
        {
            malzemeTaleps = malzemeTalepManager.GetListIslemDurumu("ONAY AŞAMASINDA");
            dataBinder.DataSource = malzemeTaleps.ToDataTable();
            DtgList.DataSource = dataBinder;

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["MalzemeKategorisi"].HeaderText = "MALZEME KATEGORİSİ";
            DtgList.Columns["TalepEdenPersonel"].HeaderText = "TALEP EDİLEN PERSONEL";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgList.Columns["Birim"].HeaderText = "BİRİM";
            DtgList.Columns["TalebiOlusturan"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgList.Columns["Bolum"].HeaderText = "BÖLÜM";
            DtgList.Columns["SatBilgisi"].Visible = false;
            DtgList.Columns["MasrafYeri"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["IslemDurumu"].HeaderText = "İŞLEM DURUMU";
            DtgList.Columns["RedGerekcesi"].Visible = false;
            DtgList.Columns["ToplamMiktar"].Visible = false;


            DtgList.Columns["Bolum"].DisplayIndex = 0;
            DtgList.Columns["MasrafYeri"].DisplayIndex = 1;
            DtgList.Columns["TalebiOlusturan"].DisplayIndex = 2;
            DtgList.Columns["MalzemeKategorisi"].DisplayIndex = 3;
            DtgList.Columns["StokNo"].DisplayIndex = 4;
            DtgList.Columns["Tanim"].DisplayIndex = 5;
            DtgList.Columns["TalepEdenPersonel"].DisplayIndex = 6;
            DtgList.Columns["Miktar"].DisplayIndex = 7;
            DtgList.Columns["Birim"].DisplayIndex = 8;
            DtgList.Columns["SatBilgisi"].DisplayIndex = 9;
            DtgList.Columns["Id"].DisplayIndex = 10;

            TxtTop.Text = DtgList.RowCount.ToString();
            Toplamlar();

        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgList.Rows[i].Cells["Miktar"].Value);
            }
            TxtMiktar.Text = toplam.ToString();
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

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            tanim = DtgList.CurrentRow.Cells["Tanim"].Value.ToString();
            personel = DtgList.CurrentRow.Cells["TalepEdenPersonel"].Value.ToString();

        }

        private void BtnTumunuOnayla_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Görüntülenen tüm kayıtları toplu olarak onaylamak isteiğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    malzemeTalepManager.Update(item.Cells["Id"].Value.ConInt(), "ONAYLANDI, STOK KONTROL");
                }
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataDisplay();
            }

        }

        private void BtnReddet_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen öncelikle Bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(personel + " Adlı personelin " + tanim + " talebini reddetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mesaj = malzemeTalepManager.Update(id, "REDDEDİLDİ");
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                id = 0;
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataDisplay();
            }
            
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (id==0)
            {
                MessageBox.Show("Lütfen öncelikle Bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(personel + " Adlı personelin " + tanim + " talebini onaylamak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                string mesaj = malzemeTalepManager.Update(id, "ONAYLANDI, STOK KONTROL");
                if (mesaj !="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                id = 0;
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataDisplay();
            }
            
            
        }
    }
}
