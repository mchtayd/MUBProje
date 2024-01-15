using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity.Depo;
using Entity.Gecic_Kabul_Ambar;
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

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmSayimIzleme : Form
    {
        public object[] infos;
        DepoMiktarManager depoMiktarManager;
        DepoKayitManagercs depoKayitManagercs;
        MalzemeManager malzemeManager;
        List<DepoMiktar> depoMiktars = new List<DepoMiktar>();
        bool start = false;
        string tiklananStok, tiklananSeriNo, tiklananRevizyon, sayimYili;
        int id;
        public FrmSayimIzleme()
        {
            InitializeComponent();
            depoMiktarManager = DepoMiktarManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
            malzemeManager = MalzemeManager.GetInstance();
        }

        private void FrmSayimIzleme_Load(object sender, EventArgs e)
        {
            DepoFill();
            start = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageSayimIzleme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        void DepoFill()
        {
            CmbDepoNo.DataSource = depoKayitManagercs.GetList();
            CmbDepoNo.ValueMember = "Id";
            CmbDepoNo.DisplayMember = "Depo";
            CmbDepoNo.SelectedValue = 0;
            CmbSayimYili.DataSource = depoMiktarManager.SayimYillari();
        }

        void DataDisplay()
        {
            depoMiktars = depoMiktarManager.GetListSayim(CmbSayimYili.Text, CmbDepoNo.Text);
            dataBinder.DataSource = depoMiktars.ToDataTable();
            DtgDepoBilgileri.DataSource = dataBinder;

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
            DtgDepoBilgileri.Columns["SayimYili"].HeaderText = "SAYIM YILI";

            DtgDepoBilgileri.Columns["DepoLokasyon"].DisplayIndex = 8;
            TxtTop.Text = DtgDepoBilgileri.RowCount.ToString();
        }

        private void BtnSorgula_Click(object sender, EventArgs e)
        {
            if (CmbDepoNo.Text=="")
            {
                MessageBox.Show("Lütfen kontrol etmek istediğiniz Depo No Bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbSayimYili.Text=="")
            {
                MessageBox.Show("Lütfen kontrol etmek istediğiniz Sayım Yılı Bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataDisplay();
            Toplamlar();
        }

        private void CmbDepoNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDepoNo.SelectedIndex == -1)
            {
                return;
            }
            if (start == false)
            {
                return;
            }
            DepoKayit depoKayit = depoKayitManagercs.Get(CmbDepoNo.SelectedValue.ConInt());
            if (depoKayit != null)
            {
                LblDepoAdi.Text = depoKayit.DepoAdi;
            }
        }

        private void DtgDepoBilgileri_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgDepoBilgileri.FilterString;
            Toplamlar();
        }

        private void DtgDepoBilgileri_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgDepoBilgileri.SortString;
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgDepoBilgileri.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgDepoBilgileri.Rows[i].Cells[5].Value);
            }
            LblToplamMiktar.Text = toplam.ToString();
            TxtTop.Text = DtgDepoBilgileri.RowCount.ToString();
        }

        private void malzemeBilgisiDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Malzeme malzeme = malzemeManager.Get(tiklananStok);
            if (malzeme == null)
            {
                MessageBox.Show("Malzeme bilgilerine ulaşışlamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmMalzemeGuncelle frmMalzemeGuncelle = new FrmMalzemeGuncelle();
            frmMalzemeGuncelle.id = malzeme.Id;
            frmMalzemeGuncelle.infos = infos;
            frmMalzemeGuncelle.ShowDialog();
            id = 0;
        }

        private void miktarDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Lütfen bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            FrmStokMiktarEdit frmStokMiktarEdit = new FrmStokMiktarEdit();
            frmStokMiktarEdit.id = id;
            frmStokMiktarEdit.infos = infos;
            frmStokMiktarEdit.sayimSayfasi = true;
            frmStokMiktarEdit.sayimYili = sayimYili;
            frmStokMiktarEdit.ShowDialog();
            id = 0;
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

        private void DtgDepoBilgileri_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgDepoBilgileri.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            id = DtgDepoBilgileri.CurrentRow.Cells["Id"].Value.ConInt();
            tiklananStok = DtgDepoBilgileri.CurrentRow.Cells["StokNo"].Value.ToString();
            tiklananRevizyon = DtgDepoBilgileri.CurrentRow.Cells["Revizyon"].Value.ToString();
            sayimYili = DtgDepoBilgileri.CurrentRow.Cells["SayimYili"].Value.ToString();
            Malzeme malzeme = malzemeManager.Get(tiklananStok);
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
    }
}
