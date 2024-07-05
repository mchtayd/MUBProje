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
    public partial class FrmDVZimmetTakibi : Form
    {
        ZimmetAktarimManager zimmetAktarimManager;
        ZimmetVeriGecmisManager zimmetVeriGecmisManager;
        IdariIslerLogManager logManager;
        List<ZimmetAktarim> zimmets;
        List<ZimmetAktarim> zimmetsFiltired;
        List<ZimmetVeriGecmis> zimmetsGecmis;
        AracZimmetiManager aracZimmetiManager;
        List<AracZimmeti> aracZimmetis;
        List<AracZimmeti> aracZimmetisFiltired;
        List<ZimmetVeriGecmis> zimmetsFiltiredGecmis;
        string dosyayolu, sayfa, dosyaYoluGecmis;
        int id;
        public FrmDVZimmetTakibi()
        {
            InitializeComponent();
            zimmetAktarimManager = ZimmetAktarimManager.GetInstance();
            logManager = IdariIslerLogManager.GetInstance();
            zimmetVeriGecmisManager = ZimmetVeriGecmisManager.GetInstance();
            aracZimmetiManager = AracZimmetiManager.GetInstance();
        }

        private void FrmDVZimmetTakibi_Load(object sender, EventArgs e)
        {
            DataDisplayAsync();
            ZimmetliAraclar();

        }
        public void YenilenecekVeri()
        {
            DataDisplayAsync();
            ZimmetliAraclar();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageZimmetTakibi"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        void ZimmetliAraclar()
        {
            aracZimmetis = aracZimmetiManager.GetList();
            aracZimmetisFiltired = aracZimmetis;
            dataBinder2.DataSource = aracZimmetis.ToDataTable();
            DtgVeriGecmis.DataSource = dataBinder2;
            TxtTopGecmis.Text = DtgVeriGecmis.RowCount.ToString();

            DtgVeriGecmis.Columns["Id"].Visible = false;
            DtgVeriGecmis.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgVeriGecmis.Columns["IsAkisNo"].DisplayIndex = 1;
            DtgVeriGecmis.Columns["Plaka"].HeaderText = "PLAKA";
            DtgVeriGecmis.Columns["Marka"].HeaderText = "MARKA";
            DtgVeriGecmis.Columns["Model"].HeaderText = "MODEL";
            DtgVeriGecmis.Columns["MotorNo"].HeaderText = "MOTOR NO";
            DtgVeriGecmis.Columns["SaseNo"].HeaderText = "ŞASE NO";
            DtgVeriGecmis.Columns["MulkiyetBilgileri"].HeaderText = "MÜLKİYET BİLGİLERİ";
            DtgVeriGecmis.Columns["SiparisNo"].HeaderText = "SİPARİŞ NO";
            DtgVeriGecmis.Columns["ProjeTahsisTarihi"].HeaderText = "PROJEYE TAHSİS TARİHİ";
            DtgVeriGecmis.Columns["PersonelAd"].HeaderText = "PERSONEL AD SOYAD";
            DtgVeriGecmis.Columns["SicilNo"].HeaderText = "SİCİL NO";
            DtgVeriGecmis.Columns["MasrafYeriNo"].HeaderText = "MASRAF YERİ NO";
            DtgVeriGecmis.Columns["MasrafYeri"].HeaderText = "MASRAF YERİ";
            DtgVeriGecmis.Columns["MasYerSor"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgVeriGecmis.Columns["Bolum"].HeaderText = "BÖLÜMÜ";
            DtgVeriGecmis.Columns["AktarimTarihi"].HeaderText = "AKTARIM TARİHİ";
            DtgVeriGecmis.Columns["Gerekce"].HeaderText = "AKTARIM GEREKÇESİ";
            DtgVeriGecmis.Columns["Km"].HeaderText = "KİLOMETRE";
            DtgVeriGecmis.Columns["DosyYolu"].Visible = false;
        }

        void DataDisplayAsync()
        {
            zimmets = zimmetAktarimManager.GetList();
            zimmetsFiltired = zimmets;
            dataBinder.DataSource = zimmets.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Dvno"].HeaderText = "DURAN VARLIK NO";
            DtgList.Columns["DvEtiketNo"].HeaderText = "DV ETİKET NO";
            DtgList.Columns["DvTanim"].HeaderText = "DV TANIM";
            DtgList.Columns["DvMarka"].HeaderText = "MARKA";
            DtgList.Columns["DvModel"].HeaderText = "MODEL";
            DtgList.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgList.Columns["Durumu"].HeaderText = "DURUMU";
            DtgList.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgList.Columns["IslemTuru"].HeaderText = "İŞLEM TÜRÜ";
            DtgList.Columns["PersonelAd"].HeaderText = "PERSONEL ADI SOYADI";
            DtgList.Columns["Sicil"].HeaderText = "SİCİL";
            DtgList.Columns["MasYeriNo"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["MasYeri"].HeaderText = "MASRAF YERİ";
            DtgList.Columns["MasYeriSorumlusu"].HeaderText = "MASRAF YERİ SORUMLUSU";
            DtgList.Columns["Bolum"].HeaderText = "BOLUM";
            DtgList.Columns["AktarimTarihi"].HeaderText = "AKTARIM TARİHİ";
            DtgList.Columns["DepoAdresi"].HeaderText = "DEPO ADRESİ";
            DtgList.Columns["Lokasyon"].HeaderText = "LOKASYON";
            DtgList.Columns["LokasyonBilgi"].HeaderText = "LOKASYON BİLGİ";
            DtgList.Columns["AktarimGerekcesi"].HeaderText = "AKTARIM GEREKÇESİ";
            DtgList.Columns["Sayfa"].Visible = false;
            DtgList.Columns["FotoYolu"].Visible = false;
            DtgList.Columns["DosyaYolu"].Visible = false;
        }
        void ZimmetVeriGecmis()
        {
            zimmetsGecmis = zimmetVeriGecmisManager.GetList();
            zimmetsFiltiredGecmis = zimmetsGecmis;
            dataBinder2.DataSource = zimmetsGecmis.ToDataTable();
            DtgVeriGecmis.DataSource = dataBinder2;
            TxtTopGecmis.Text = DtgVeriGecmis.RowCount.ToString();

            DtgVeriGecmis.Columns["Id"].Visible = false;
            DtgVeriGecmis.Columns["Dvno"].HeaderText = "DURAN VARLIK NO";
            DtgVeriGecmis.Columns["DvEtiketNo"].HeaderText = "DV ETİKET NO";
            DtgVeriGecmis.Columns["DvTanim"].HeaderText = "DV TANIM";
            DtgVeriGecmis.Columns["DvMarka"].HeaderText = "MARKA";
            DtgVeriGecmis.Columns["DvModel"].HeaderText = "MODEL";
            DtgVeriGecmis.Columns["SeriNo"].HeaderText = "SERİ NO";
            DtgVeriGecmis.Columns["Durumu"].HeaderText = "DURUMU";
            DtgVeriGecmis.Columns["Miktar"].HeaderText = "MİKTAR";
            DtgVeriGecmis.Columns["IslemTuru"].HeaderText = "İŞLEM TÜRÜ";
            DtgVeriGecmis.Columns["VerenPersonel"].HeaderText = "AKTARAN PERSONEL İSİM";
            DtgVeriGecmis.Columns["VerenSicil"].HeaderText = "AKTARAN PERSONEL SİCİL";
            DtgVeriGecmis.Columns["VerenMasYeriNo"].HeaderText = "AKTARAN PERSONEL MASRAF YERİ NO";
            DtgVeriGecmis.Columns["VeremMasYeri"].HeaderText = "AKTARAN PERSONEL MASRAF YERİ";
            DtgVeriGecmis.Columns["VerenMasSorumlusu"].HeaderText = "AKTARAN PERSONEL MAS.YER.SORUMLUSU";
            DtgVeriGecmis.Columns["VerenBolum"].HeaderText = "AKTARAN PERSONEL BOLUM";
            DtgVeriGecmis.Columns["Tarih"].HeaderText = "AKTARIM TARİHİ";
            DtgVeriGecmis.Columns["AlanPersonel"].HeaderText = "ALAN PERSONEL İSİM";
            DtgVeriGecmis.Columns["AlanSicil"].HeaderText = "ALAN PERSONEL SİCİL";
            DtgVeriGecmis.Columns["AlanMasYeriNo"].HeaderText = "ALAN PERSONEL MASRAF YERİ NO";
            DtgVeriGecmis.Columns["AktarimGerekcesi"].Visible = false;
            DtgVeriGecmis.Columns["DepoAdresi"].HeaderText = "DEPO ADRESİ";
            DtgVeriGecmis.Columns["Lokasyon"].HeaderText = "LOKASYON";
            DtgVeriGecmis.Columns["LokasyonBilgi"].HeaderText = "LOKASYON BİLGİ";
            DtgVeriGecmis.Columns["IslemYapan"].HeaderText = "İŞLEM YAPAN";
            DtgVeriGecmis.Columns["DosyaYolu"].Visible = false;
        }

        private void TxtEtiketNo_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtEtiketNo.Text;
            if (string.IsNullOrEmpty(isim))
            {
                zimmetsFiltired = zimmets;
                dataBinder.DataSource = zimmets.ToDataTable();
                DtgList.DataSource = dataBinder;
                TxtTop.Text = DtgList.RowCount.ToString();
                return;
            }
            if (TxtEtiketNo.Text.Length < 3)
            {
                return;
            }
            dataBinder.DataSource = zimmetsFiltired.Where(x => x.DvEtiketNo.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgList.DataSource = dataBinder;
            zimmetsFiltired = zimmets;
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyayolu = DtgList.CurrentRow.Cells["Dosyayolu"].Value.ToString();
            sayfa = DtgList.CurrentRow.Cells["Sayfa"].Value.ToString();
            id = DtgList.CurrentRow.Cells["Id"].Value.ConInt();
            
            IslemAdimlariDisplay();
            try
            {
                webBrowser1.Navigate(dosyayolu);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataDisplayAsync();
            //ZimmetVeriGecmis();
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

        private void TxtEtiketNoGecmis_TextChanged(object sender, EventArgs e)
        {
            string isim = TxtPlaka.Text;
            if (string.IsNullOrEmpty(isim))
            {
                aracZimmetisFiltired = aracZimmetis;
                dataBinder2.DataSource = aracZimmetis.ToDataTable();
                DtgVeriGecmis.DataSource = dataBinder2;
                TxtTopGecmis.Text = DtgVeriGecmis.RowCount.ToString();
                return;
            }
            if (TxtPlaka.Text.Length < 3)
            {
                return;
            }
            dataBinder2.DataSource = aracZimmetisFiltired.Where(x => x.Plaka.ToLower().Contains(isim.ToLower())).ToList().ToDataTable();
            DtgVeriGecmis.DataSource = dataBinder2;
            aracZimmetisFiltired = aracZimmetis;
            TxtTopGecmis.Text = DtgVeriGecmis.RowCount.ToString();
        }

        private void DtgVeriGecmis_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Filter = DtgVeriGecmis.FilterString;
            TxtTopGecmis.Text = DtgVeriGecmis.RowCount.ToString();
        }

        private void DtgVeriGecmis_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Sort = DtgVeriGecmis.SortString;
        }

        void IslemAdimlariDisplay()
        {
            DtgIslemAdimlari.DataSource = logManager.GetList(sayfa, id);
            DtgIslemAdimlari.Columns["Id"].Visible = false;
            DtgIslemAdimlari.Columns["Sayfa"].Visible = false;
            DtgIslemAdimlari.Columns["Benzersizid"].Visible = false;
            DtgIslemAdimlari.Columns["Islem"].HeaderText = "YAPILAN İŞLEM";
            DtgIslemAdimlari.Columns["Islemyapan"].HeaderText = "İŞLEM YAPAN";
            DtgIslemAdimlari.Columns["Tarih"].HeaderText = "TARİH";
            DtgIslemAdimlari.Columns["Tarih"].Width = 100;
            DtgIslemAdimlari.Columns["Islemyapan"].Width = 135;
            DtgIslemAdimlari.Columns["Islem"].Width = 400;
        }
    }
}
