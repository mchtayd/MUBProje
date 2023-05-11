using Business.Concreate.BakimOnarim;
using Business.Concreate.Depo;
using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity;
using Entity.BakimOnarim;
using Entity.Depo;
using Entity.Gecic_Kabul_Ambar;
using Entity.IdariIsler;
using Microsoft.Office.Interop.Word;
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
using Application = System.Windows.Forms.Application;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmBolgedenIadeGelenMlz : Form
    {
        AbfMalzemeManager abfMalzemeManager;
        DepoKayitManagercs depoKayitManagercs;
        DepoKayitLokasyonManager depoKayitLokasyonManager;
        DepoMiktarManager depoMiktarManager;
        StokGirisCikisManager stokGirisCikisManager;

        List<AbfMalzeme> abfMalzemes = new List<AbfMalzeme>();
        public object[] infos;
        int id, abfNo, miktar, mevcutMiktar, dusulenMiktar, cekilenMiktar = 0;
        bool start = false;
        public FrmBolgedenIadeGelenMlz()
        {
            InitializeComponent();
            abfMalzemeManager = AbfMalzemeManager.GetInstance();
            depoKayitManagercs = DepoKayitManagercs.GetInstance();
            depoKayitLokasyonManager = DepoKayitLokasyonManager.GetInstance();
            depoMiktarManager = DepoMiktarManager.GetInstance();
            stokGirisCikisManager = StokGirisCikisManager.GetInstance();
        }

        private void FrmBolgedenIadeGelenMlz_Load(object sender, EventArgs e)
        {
            DataDisplay();
            CmbDepo();
            start = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageGelenMalzeme"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        public void CmbDepo()
        {
            CmbDepoNo.DataSource = depoKayitManagercs.GetList();
            CmbDepoNo.ValueMember = "Id";
            CmbDepoNo.DisplayMember = "Depo";
            CmbDepoNo.SelectedValue = -1;
        }

        void DataDisplay()
        {
            abfMalzemes = abfMalzemeManager.DepoyaTeslimEdilecekMalzemeList();
            dataBinder.DataSource = abfMalzemes.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["BenzersizId"].Visible = false;
            DtgList.Columns["SokulenStokNo"].HeaderText = "STOK NO";
            DtgList.Columns["SokulenTanim"].HeaderText = "TANIM";
            DtgList.Columns["SokulenSeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["SokulenMiktar"].HeaderText = "MİKTAR";
            DtgList.Columns["SokulenBirim"].HeaderText = "BİRİM";
            DtgList.Columns["SokulenCalismaSaati"].Visible = false;
            DtgList.Columns["SokulenRevizyon"].HeaderText = "REVİZYON";
            DtgList.Columns["CalismaDurumu"].Visible = false;
            DtgList.Columns["FizikselDurum"].Visible = false;
            DtgList.Columns["TakilanStokNo"].Visible = false;
            DtgList.Columns["TakilanTanim"].Visible = false;
            DtgList.Columns["TakilanSeriNo"].Visible = false;
            DtgList.Columns["TakilanMiktar"].Visible = false;
            DtgList.Columns["TakilanBirim"].Visible = false;
            DtgList.Columns["TakilanCalismaSaati"].Visible = false;
            DtgList.Columns["TakilanRevizyon"].Visible = false;
            DtgList.Columns["TeminDurumu"].Visible = false;
            DtgList.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgList.Columns["AbTarihSaat"].Visible = false;
            DtgList.Columns["TemineAtilamTarihi"].Visible = false;
            DtgList.Columns["MalzemeDurumu"].Visible = false;
            DtgList.Columns["MalzemeIslemAdimi"].Visible = false;
            DtgList.Columns["SokulenTeslimDurum"].HeaderText = "MALZEME TESLİM DURUMU";
            DtgList.Columns["BolgeAdi"].HeaderText = "BÖLGE ADI";
            DtgList.Columns["BolgeSorumlusu"].HeaderText = "BÖLGE SORUMLUSU";
            DtgList.Columns["YapilacakIslem"].HeaderText = "YAPILACAK İŞLEM";

            DtgList.Columns["AbfNo"].DisplayIndex = 0;
            DtgList.Columns["SokulenStokNo"].DisplayIndex = 1;
            DtgList.Columns["SokulenTanim"].DisplayIndex = 2;
            DtgList.Columns["SokulenSeriNo"].DisplayIndex = 3;
            DtgList.Columns["SokulenMiktar"].DisplayIndex = 4;
            DtgList.Columns["SokulenBirim"].DisplayIndex = 5;
            DtgList.Columns["SokulenRevizyon"].DisplayIndex = 6;
            DtgList.Columns["BolgeAdi"].DisplayIndex = 7;
            DtgList.Columns["BolgeSorumlusu"].DisplayIndex = 8;
            DtgList.Columns["SokulenTeslimDurum"].DisplayIndex = 9;
            DtgList.Columns["YapilacakIslem"].DisplayIndex = 10;

            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort= DtgList.SortString;
        }

        private void CmbDepoNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == false)
            {
                return;
            }
            if (CmbDepoNo.Text=="")
            {
                LblDepoAdresi.Text = "00";
                TxtMalzemeYeri.DataSource = null;
                TxtMalzemeYeri.Text = "";
            }
            TxtMalzemeYeri.Text = "";
            id = CmbDepoNo.SelectedValue.ConInt();
            DepoKayit depoKayit = depoKayitManagercs.Get(id);
            LblDepoAdresi.Text = depoKayit.DepoAdi;

            TxtMalzemeYeri.DataSource = depoKayitLokasyonManager.GetListLokasyon(id);
            TxtMalzemeYeri.ValueMember = "Id";
            TxtMalzemeYeri.DisplayMember = "Lokasyon";
            TxtMalzemeYeri.SelectedValue = "";
        }

        private void BtnTeslimAlSat_Click(object sender, EventArgs e)
        {
            if (stokNo == "")
            {
                MessageBox.Show("Lütfen malzemeyi seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(stokNo + " stok numaralı malzemeyi teslim almak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }
            if (abfNo==0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbDepoNo.Text=="")
            {
                MessageBox.Show("Lütfen öncelikle çekilecek depo bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtMalzemeYeri.Text=="")
            {
                MessageBox.Show("Lütfen öncelikle çekilecek deponun lokasyon bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TxtAciklama.Text=="")
            {
                MessageBox.Show("Lütfen öncelikle açıklama yazınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AbfMalzeme abfMalzeme = abfMalzemeManager.Get(malzemeId);

            DepoMiktar depo = depoMiktarManager.Get(stokNo, CmbDepoNo.Text, seriNo, lotNo, revizyon);
            if (depo == null)
            {

                mevcutMiktar = abfMalzeme.SokulenMiktar;
            }
            else
            {
                mevcutMiktar = depo.Miktar;
            }

            miktar = abfMalzeme.SokulenMiktar;

            if (depo == null)
            {
                DepoMiktar depoMiktar2 = new DepoMiktar(stokNo, tanim, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), CmbDepoNo.Text, LblDepoAdresi.Text, TxtMalzemeYeri.Text, mevcutMiktar, TxtAciklama.Text);
                depoMiktarManager.Add(depoMiktar2);
            }

            mevcutMiktar = +miktar;
            string depoNoDusulen2 = CmbDepoNo.Text; // düşülen depo
            string dusulenDepoLokasyon = TxtMalzemeYeri.Text; // düşülen depo lokasyon

            DepoMiktar depoDusulen = new DepoMiktar(stokNo, depoNoDusulen2, dusulenDepoLokasyon, seriNo, lotNo, revizyon, DateTime.Now, infos[1].ToString(), mevcutMiktar);
            depoMiktarManager.Update(depoDusulen, "REZERVE DEĞİL");

            StokGirisCıkıs stokGirisCıkıs = new StokGirisCıkıs("201-BİLDİRİMDEN DEPOYA İADE", stokNo, tanim, birim, DateTime.Now, abfNo.ToString(), "", "", CmbDepoNo.Text, LblDepoAdresi.Text, TxtMalzemeYeri.Text, miktar, personel, TxtAciklama.Text, seriNo, lotNo, revizyon);

            stokGirisCikisManager.Add(stokGirisCıkıs);

            abfMalzemeManager.MalzemeTeslimBilgisiUpdate(malzemeId);
            abfNo = 0;

            MessageBox.Show("Bilgiler başarıyla kaydedilmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CmbDepoNo.Text = "";
            LblDepoAdresi.Text = "00";
            TxtMalzemeYeri.Text = "";
            TxtAciklama.Clear();
            DataDisplay();
            stokNo = "";
        }
        string stokNo, tanim, seriNo, lotNo, revizyon, birim, personel, malzYapilacakIslem = "";
        int benzersizId, malzemeId = 0;
        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            abfNo = DtgList.CurrentRow.Cells["AbfNo"].Value.ConInt();
            stokNo = DtgList.CurrentRow.Cells["SokulenStokNo"].Value.ToString();
            tanim = DtgList.CurrentRow.Cells["SokulenTanim"].Value.ToString();
            seriNo = DtgList.CurrentRow.Cells["SokulenSeriNo"].Value.ToString();
            if (seriNo=="N/A")
            {
                lotNo = DtgList.CurrentRow.Cells["SokulenSeriNo"].Value.ToString();
            }
            else
            {
                lotNo = "N/A";
            }
            revizyon = DtgList.CurrentRow.Cells["SokulenRevizyon"].Value.ToString();
            birim = DtgList.CurrentRow.Cells["SokulenBirim"].Value.ToString();
            benzersizId = DtgList.CurrentRow.Cells["BenzersizId"].Value.ConInt();
            malzemeId = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            personel = DtgList.CurrentRow.Cells["BolgeSorumlusu"].Value.ToString();
            malzYapilacakIslem = DtgList.CurrentRow.Cells["YapilacakIslem"].Value.ToString();

            if (malzYapilacakIslem== "DEĞİTİRİLECEK (HURDA EDİLECEK)")
            {
                CmbDepoNo.Text = "9900";
            }
            else 
            {
                CmbDepoNo.Text = "";
                LblDepoAdresi.Text = "00";
                TxtMalzemeYeri.Text = "";
                TxtMalzemeYeri.DataSource = null;
            }
        }
        

    }
}
