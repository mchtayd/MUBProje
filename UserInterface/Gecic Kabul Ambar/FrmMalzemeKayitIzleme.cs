using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity.Gecic_Kabul_Ambar;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmMalzemeKayitIzleme : Form
    {
        List<Malzeme> malzemes;
        List<Malzeme> malzemesFiltired;
        public object[] infos;

        //List<MalzemeStok> malzemeStoks;
        //List<MalzemeStok> malzemeStokssFiltired;

        MalzemeManager malzemeManage;
        MalzemeKayitManager kayitManager;
        MalzemeStokManager malzemeStokManager;

        string dosyaYolu = "";
        public FrmMalzemeKayitIzleme()
        {
            InitializeComponent();
            kayitManager = MalzemeKayitManager.GetInstance();
            malzemeStokManager = MalzemeStokManager.GetInstance();
            malzemeManage = MalzemeManager.GetInstance();
        }

        private void FrmMalzemeKayitIzleme_Load(object sender, EventArgs e)
        {
            if (infos[11].ToString() == "YÖNETİCİ" || infos[11].ToString() == "ADMİN" || infos[0].ConInt() == 39)
            {
                contextMenuStrip1.Items[0].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[0].Enabled = false;
            }
            DataDisplay();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageKayitliMalzemeler"]);

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
            malzemes = malzemeManage.GetList();
            malzemesFiltired = malzemes;
            dataBinder.DataSource = malzemes.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["UstStok"].Visible = false;
            DtgList.Columns["UstTanim"].Visible = false;
            DtgList.Columns["BenzersizId"].Visible = false;
            DtgList.Columns["StokNo"].HeaderText = "STOK NO";
            DtgList.Columns["Tanim"].HeaderText = "TANIM";
            DtgList.Columns["Birim"].HeaderText = "BİRİM";
            DtgList.Columns["TedarikciFirma"].HeaderText = "TEDARİKÇİ FİRMA";
            DtgList.Columns["OnarimDurumu"].HeaderText = "MALZEME ONARIM DURUMU";
            DtgList.Columns["OnarimYeri"].HeaderText = "MALZEME ONARIM YERİ";
            DtgList.Columns["TedarikTuru"].HeaderText = "TEDARİK TÜRÜ";
            DtgList.Columns["ParcaSinifi"].HeaderText = "PARÇA SINIFI";
            DtgList.Columns["TakipDurumu"].HeaderText = "MALZEME TAKİP DURUMU";
            //DtgList.Columns["Malzemekul"].HeaderText = "MALZEMENİN KULLANILDIĞI ÜST TAKIM STOK NO";
            DtgList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgList.Columns["DosyaYolu"].Visible = false;
            DtgList.Columns["IslemYapan"].Visible = false;
            DtgList.Columns["AlternatifParca"].HeaderText = "ALTERNATİF PARÇA";
            DtgList.Columns["SistemStokNo"].HeaderText = "SİSTEM STOK NO";
            DtgList.Columns["SistemTanimi"].HeaderText = "SİSTEM TANIM";
            DtgList.Columns["SistemSorumlusu"].HeaderText = "SİSTEM SORUMLUSU";
            DtgList.Columns["Photo"].Visible = false;

            //string fileName = "";
            //int index = 0;
            //foreach (Malzeme item in malzemes)
            //{
            //    DirectoryInfo di = new DirectoryInfo(item.DosyaYolu);
            //    foreach (FileInfo fi in di.GetFiles())
            //    {
            //        if (fi.Name != "." && fi.Name != ".." && fi.Name != "Thumbs.db")
            //        {
            //            fileName = fi.Name;
            //        }
            //    }
            //    string foto = item.DosyaYolu + "\\" + fileName;

            //    Image image;
            //    image = Image.FromFile(foto);
            //    DtgList.Rows[index].Cells["Photo"].Value = image;
            //    index++;
            //    if (index==665)
            //    {

            //    }
            //}


        }
        /*void DataDisplayGuncelStok()
        {
            malzemeStoks = malzemeStokManager.GetList();
            malzemeStokssFiltired = malzemeStoks;
            dataBinderGuncel.DataSource = malzemeKayits.ToDataTable();
            DtgGuncelStok.DataSource = dataBinderGuncel;
            LbGuncelToplam.Text = DtgGuncelStok.RowCount.ToString();

            /*DtgGuncelStok.Columns["Id"].Visible = false;
            DtgGuncelStok.Columns["StokNo"].HeaderText = "STOK NO";
            DtgGuncelStok.Columns["Tanim"].HeaderText = "TANIM";
            DtgGuncelStok.Columns["MalzemeninKulYer"].HeaderText = "MALZEME KULLANIM YERİ";
            DtgGuncelStok.Columns["MalzemeUstTakim"].HeaderText = "MALZEME ÜST TAKIM";
            DtgGuncelStok.Columns["DosyaYolu"].Visible = false;
            
        }*/

        private void TxtStokNo_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtStokNo.Text;
            if (string.IsNullOrEmpty(isim))
            {
                malzemesFiltired = malzemes;
                dataBinder.DataSource = malzemes.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtStokNo.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = malzemesFiltired.Where(x => x.StokNo.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            malzemesFiltired = malzemes;
            TxtTop.Text = DtgList.RowCount.ToString();
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
        int id;
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.RowCount==0)
            {
                return;
            }
            dosyaYolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            try
            {
                webBrowser1.Navigate(dosyaYolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void TxtTanim_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtTanim.Text;
            if (string.IsNullOrEmpty(isim))
            {
                malzemesFiltired = malzemes;
                dataBinder.DataSource = malzemes.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtTanim.Text.Length < 3)
            {
                return;
            }

            dataBinder.DataSource = malzemesFiltired.Where(x => x.Tanim.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            malzemesFiltired = malzemes;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMalzemeGuncelle frmMalzemeGuncelle = new FrmMalzemeGuncelle();
            frmMalzemeGuncelle.id = id;
            frmMalzemeGuncelle.infos = infos;
            frmMalzemeGuncelle.ShowDialog();
        }
    }
}
