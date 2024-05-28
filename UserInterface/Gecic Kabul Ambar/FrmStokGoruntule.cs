using Business.Concreate.BakimOnarim;
using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
using Entity.BakimOnarim;
using Entity.Depo;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Gecic_Kabul_Ambar;
using UserInterface.STS;

namespace UserInterface.Depo
{
    public partial class FrmStokGoruntule : Form
    {
        StokGirisCikisManager stokGirisCikisManager;
        //MalzemeKayitManager malzemeKayitManager;
        DepoMiktarManager depoMiktarManager;
        MalzemeManager malzemeManager;
        AbfMalzemeManager abfMalzemeManager;
        DepoKayitManagercs depoKayitManagercs;

        List<DepoMiktar> depoMiktars;
        List<AbfMalzeme> abfMalzemes;

        string stokNo = "";
        int id;
        public object[] infos;
        string tiklananStok, tiklananSeriNo, tiklananRevizyon;
        bool start = false;
        public FrmStokGoruntule()
        {
            InitializeComponent();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
            //malzemeKayitManager = MalzemeKayitManager.GetInstance();
            depoMiktarManager = DepoMiktarManager.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageStokGoruntule"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void FrmStokGoruntule_Load(object sender, EventArgs e)
        {
            if (infos[1].ToString() == "RESUL GÜNEŞ" || infos[11].ToString() == "ADMİN" || infos[0].ConInt() == 39 || infos[0].ConInt() == 1148 || infos[0].ConInt() == 33)
            {
                contextMenuStrip1.Items[0].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[0].Enabled = false;
            }
            DepoFill();
            start = true;
        }
        void DepoFill()
        {
            CmbDepoNo.DataSource = depoKayitManagercs.GetList();
            CmbDepoNo.ValueMember = "Id";
            CmbDepoNo.DisplayMember = "Depo";
            CmbDepoNo.SelectedValue = 0;
        }

        void Display()
        {
            /*stokGirisCıkıs = stokGirisCikisManager.GetList();
            //stokFiltired = stokGirisCıkıs;
            dataBinder.DataSource = stokGirisCıkıs.ToDataTable();
            DtgDepoBilgileri.DataSource = dataBinder;*/


            foreach (DataGridViewRow item in DtgDepoBilgileri.Rows)
            {
                if (item.Cells["Miktar"].Value.ConInt() == 0)
                {
                    int selectedIndex = item.Index;
                    DtgDepoBilgileri.Rows.RemoveAt(selectedIndex);
                }
            }
            DtgDepoBilgileri.Columns["Secim"].Visible = false;
            DtgDepoBilgileri.Columns["Id"].Visible = false;
            DtgDepoBilgileri.Columns["StokNo"].HeaderText = "STOK NO";
            DtgDepoBilgileri.Columns["Tanim"].HeaderText = "TANIM";
            DtgDepoBilgileri.Columns["SonIslemTarihi"].HeaderText = "SON İŞLEM TARİHİ";
            DtgDepoBilgileri.Columns["SonIslemYapan"].HeaderText = "SON İŞLEM YAPAN";
            DtgDepoBilgileri.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgDepoBilgileri.Columns["DepoNo"].HeaderText = "DEPO NO";
            DtgDepoBilgileri.Columns["DepoAdresi"].HeaderText = "DEPO ADRESİ";
            DtgDepoBilgileri.Columns["DepoLokasyon"].HeaderText = "DEPO LOKASYON";
            DtgDepoBilgileri.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgDepoBilgileri.Columns["LotNo"].HeaderText = "LOT NO";
            DtgDepoBilgileri.Columns["Revizyon"].HeaderText = "REVİZYON";
            DtgDepoBilgileri.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgDepoBilgileri.Columns["RezerveDurumu"].HeaderText = "REZERVE DURUMU";
            DtgDepoBilgileri.Columns["RezerveId"].HeaderText = "REZERVE EDİLEN KİMLİK";
            DtgDepoBilgileri.Columns["SayimYili"].Visible = false;

            DtgDepoBilgileri.Columns["DepoLokasyon"].DisplayIndex = 8;
            TxtTop.Text = DtgDepoBilgileri.RowCount.ToString();
        }


        private void DtgMalzemeBilgisi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (DtgMalzemeBilgisi.CurrentRow == null)
            //{
            //    MessageBox.Show("Lütfen Öncelikle Bir Stok Bilgisi Giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //    return;
            //}

            //stokNo = DtgMalzemeBilgisi.CurrentRow.Cells["Stokno"].Value.ToString();
            //depoMiktars = depoMiktarManager.GetList(stokNo,"TÜM");

            //dataBinder.DataSource = depoMiktars.ToDataTable();
            //DtgDepoBilgileri.DataSource = dataBinder;
            ////TxtTop.Text = DtgDepoBilgileri.RowCount.ToString();
            //Display();
            //Toplamlar();
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgDepoBilgileri.Rows.Count; ++i)
            {
                /*if (DtgDepoBilgileri.Rows[i].Cells[4].Value.ConInt()==0)
                {
                    toplam += Convert.ToDouble(DtgDepoBilgileri.Rows[i].Cells[13].Value);
                }*/
                toplam += Convert.ToDouble(DtgDepoBilgileri.Rows[i].Cells[5].Value);
            }
            LblToplamMiktar.Text = toplam.ToString();
        }

        private void DtgDepoBilgileri_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgDepoBilgileri.FilterString;
            TxtTop.Text = DtgDepoBilgileri.RowCount.ToString();
            Toplamlar();
        }

        private void DtgDepoBilgileri_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgDepoBilgileri.SortString;
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmStokMiktarEdit frmStokMiktarEdit = new FrmStokMiktarEdit();
            frmStokMiktarEdit.id = id;
            frmStokMiktarEdit.infos = infos;
            frmStokMiktarEdit.ShowDialog();
            id = 0;
        }

        private void DtgDepoBilgileri_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgDepoBilgileri.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            id = DtgDepoBilgileri.CurrentRow.Cells["Id"].Value.ConInt();
            tiklananStok = DtgDepoBilgileri.CurrentRow.Cells["StokNo"].Value.ToString();
            tiklananRevizyon = DtgDepoBilgileri.CurrentRow.Cells["Revizyon"].Value.ToString();
            Malzeme malzeme = malzemeManager.Get(stokNo);
            if (malzeme != null)
            {
                if (malzeme.TakipDurumu == "LOT NO")
                {
                    tiklananSeriNo = DtgDepoBilgileri.CurrentRow.Cells["LotNo"].Value.ToString();
                }
                else
                {
                    tiklananSeriNo = DtgDepoBilgileri.CurrentRow.Cells["SeriNo"].Value.ToString();
                }
            }
            else
            {
                tiklananSeriNo = DtgDepoBilgileri.CurrentRow.Cells["SeriNo"].Value.ToString();
            }
        }

        private void BtnSorgula_Click(object sender, EventArgs e)
        {
            if (TxtStokNo.Text == "")
            {
                MessageBox.Show("Lütfen Stok No Bilgisini Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DtgMalzemeBilgisi.DataSource = malzemeManager.MalzemeGetList(TxtStokNo.Text);

            if (DtgMalzemeBilgisi.RowCount==0)
            {
                DtgMalzemeBilgisi.DataSource = null;
                MessageBox.Show("' " + TxtStokNo.Text + " '" + " stok numarası MÜB Van Depo stok kayıtlarında bulunmamaktadır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DtgMalzemeBilgisi.Columns["Id"].Visible = false;
            DtgMalzemeBilgisi.Columns["StokNo"].HeaderText = "STOK NO";
            DtgMalzemeBilgisi.Columns["Tanim"].HeaderText = "TANIM";
            DtgMalzemeBilgisi.Columns["Birim"].Visible = false;
            DtgMalzemeBilgisi.Columns["TedarikciFirma"].Visible = false;
            DtgMalzemeBilgisi.Columns["OnarimDurumu"].HeaderText = "ONARIM DURUMU";
            DtgMalzemeBilgisi.Columns["OnarimYeri"].HeaderText = "ONARIM YERİ";
            DtgMalzemeBilgisi.Columns["ParcaSinifi"].HeaderText = "PARÇA SINIFI";
            DtgMalzemeBilgisi.Columns["TedarikTuru"].Visible = false;
            DtgMalzemeBilgisi.Columns["AlternatifParca"].Visible = false;
            DtgMalzemeBilgisi.Columns["Aciklama"].Visible = false;
            DtgMalzemeBilgisi.Columns["DosyaYolu"].Visible = false;
            DtgMalzemeBilgisi.Columns["SistemStokNo"].Visible = false;
            DtgMalzemeBilgisi.Columns["SistemTanimi"].Visible = false;
            DtgMalzemeBilgisi.Columns["SistemSorumlusu"].Visible = false;
            DtgMalzemeBilgisi.Columns["IslemYapan"].Visible = false;
            DtgMalzemeBilgisi.Columns["TakipDurumu"].Visible = false;
            DtgMalzemeBilgisi.Columns["UstStok"].Visible = false;
            DtgMalzemeBilgisi.Columns["UstTanim"].Visible = false;
            DtgMalzemeBilgisi.Columns["BenzersizId"].Visible = false;
            DtgMalzemeBilgisi.Columns["KayitDurumu"].Visible = false;
            DtgMalzemeBilgisi.Columns["SeriNo"].Visible = false;
            DtgMalzemeBilgisi.Columns["Revizyon"].Visible = false;
            DtgMalzemeBilgisi.Columns["Miktar"].Visible = false;
            DtgMalzemeBilgisi.Columns["TalepTarihi"].Visible = false;
            DtgMalzemeBilgisi.Columns["Durum"].Visible = false;

            string fileName = "";
            int index = 0;
            foreach (DataGridViewRow item in DtgMalzemeBilgisi.Rows)
            {
                DirectoryInfo di = new DirectoryInfo(item.Cells["DosyaYolu"].Value.ToString());
                foreach (FileInfo fi in di.GetFiles())
                {
                    if (fi.Name != "." && fi.Name != ".." && fi.Name != "Thumbs.db")
                    {
                        fileName = fi.Name;
                    }
                }
                string foto = item.Cells["DosyaYolu"].Value.ToString() + "\\" + fileName;

                Image image;
                image = Image.FromFile(foto);
                DtgMalzemeBilgisi.Rows[index].Cells["Photo"].Value = image;
                index++;
            }

            if (DtgMalzemeBilgisi.CurrentRow == null)
            {
                MessageBox.Show("Lütfen Öncelikle Bir Stok Bilgisi Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            stokNo = DtgMalzemeBilgisi.CurrentRow.Cells["Stokno"].Value.ToString();
            depoMiktars = depoMiktarManager.GetList(stokNo, "TÜM");

            if (depoMiktars.Count<=0)
            {
                MessageBox.Show("' " + TxtStokNo.Text + " '" + " stok numaralı malzeme depo stoklarında bulunmamaktadır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dataBinder.DataSource = depoMiktars.ToDataTable();
            DtgDepoBilgileri.DataSource = dataBinder;
            //TxtTop.Text = DtgDepoBilgileri.RowCount.ToString();
            Display();
            Toplamlar();


            double birimFiyat = stokGirisCikisManager.DepoBirimFiyat(TxtStokNo.Text);

            BirimFiyat.Text = birimFiyat.ToString("C2");
        }

        private void BtnTumunuGor_Click(object sender, EventArgs e)
        {
            TxtStokNo.Clear();
            CmbDepoNo.SelectedIndex = -1;
            DtgMalzemeBilgisi.DataSource = null;
            depoMiktars = depoMiktarManager.GetListTumu();
            dataBinder.DataSource = depoMiktars.ToDataTable();
            DtgDepoBilgileri.DataSource = dataBinder;
            Display();
            Toplamlar();
        }

        private void CmbDepoNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDepoNo.SelectedIndex == -1)
            {
                return;
            }
            if (start==false)
            {
                return;
            }
            DepoKayit depoKayit = depoKayitManagercs.Get(CmbDepoNo.SelectedValue.ConInt());
            if (depoKayit != null)
            {
                LblDepoAdi.Text = depoKayit.DepoAdi;
            }
            TxtStokNo.Clear();
            DtgMalzemeBilgisi.DataSource = null;
            depoMiktars = depoMiktarManager.GetList("", CmbDepoNo.Text);
            dataBinder.DataSource = depoMiktars.ToDataTable();
            DtgDepoBilgileri.DataSource = dataBinder;
            Display();
            Toplamlar();
        }

        private void rezerveEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen bir malzeme seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmRezerveEt frmRezerveEt = new FrmRezerveEt();
            frmRezerveEt.infos = infos;
            frmRezerveEt.malzemeId = id;
            frmRezerveEt.ShowDialog();

        }

        private void barkodOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tiklananStok == "")
            {
                MessageBox.Show("Lütfen bir stok seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmDepoDusum frmDepoDusum = new FrmDepoDusum();
            frmDepoDusum.stok = tiklananStok;
            frmDepoDusum.seriNo = tiklananSeriNo;
            frmDepoDusum.revizyon = tiklananRevizyon;
            frmDepoDusum.infos = infos;
            frmDepoDusum.Show();
            tiklananStok = "";
        }
    }
}
