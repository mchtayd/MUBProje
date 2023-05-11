using Business.Concreate;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Wordprocessing;
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

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmMalzemeTaleplerim : Form
    {
        MalzemeTalepManager malzemeTalepManager;
        SatDataGridview1Manager satDataGridview1Manager;

        List<MalzemeTalep> malzemeTaleps = new List<MalzemeTalep>();

        public object[] infos;
        int satId, mifId = 0;
        string islemDurumu;

        public FrmMalzemeTaleplerim()
        {
            InitializeComponent();
            malzemeTalepManager = MalzemeTalepManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
        }

        private void FrmMalzemeTaleplerim_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        public void DataDisplay()
        {
            malzemeTaleps = malzemeTalepManager.GetListTalepEden(infos[1].ToString());
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
            DtgList.Columns["Secim"].Visible = false;
            DtgList.Columns["ToplamMiktar"].Visible = false;
            DtgList.Columns["DepoDurum"].Visible = false;

            DtgList.Columns["Bolum"].DisplayIndex = 11;
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

            TxtMiktar.Text = DtgList.RowCount.ToString();

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
            TxtMiktar.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void BtnTeslimAlSat_Click(object sender, EventArgs e)
        {
            if (satId==0)
            {
                MessageBox.Show("Lütfen bir malzeme seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (islemDurumu == "TEDARİK EDİLDİ")
            {
                if (satId != 0)
                {
                    string mesaj = satDataGridview1Manager.DepoTeslimMif(satId, mifId);
                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Malzeme başarıyla teslim alınmıştır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataDisplay();
                    satId = 0;
                }
            }
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            islemDurumu = DtgList.CurrentRow.Cells["IslemDurumu"].Value.ToString();
            mifId = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            satId = satDataGridview1Manager.MifTalepGet(mifId);
        }
    }
}
