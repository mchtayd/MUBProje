using Business.Concreate.IdarıIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.IdariIsler
{
    public partial class FrmAracZimmetiLogKayitlari : Form
    {
        AracZimmetiLogManager aracZimmetiLogManager;
        public FrmAracZimmetiLogKayitlari()
        {
            InitializeComponent();
            aracZimmetiLogManager = AracZimmetiLogManager.GetInstance();
        }

        private void FrmAracZimmetiLogKayitlari_Load(object sender, EventArgs e)
        {
            ZimmetliAraclar();
        }
        void ZimmetliAraclar()
        {
            dataBinder.DataSource = aracZimmetiLogManager.GetList();
            DtgLog.DataSource = dataBinder;
            TxtTop.Text = DtgLog.RowCount.ToString();

            DtgLog.Columns["Id"].Visible = false;
            DtgLog.Columns["IsAkisNo"].HeaderText = "İŞ AKIŞ NO";
            DtgLog.Columns["IsAkisNo"].DisplayIndex = 1;
            DtgLog.Columns["Plaka"].HeaderText = "PLAKA";
            DtgLog.Columns["Marka"].HeaderText = "MARKA";
            DtgLog.Columns["AktaranPersonel"].HeaderText = "AKTARAN PERSONEL";
            DtgLog.Columns["AktaranMasYeriNo"].HeaderText = "AKTARAN MASRAF YERİ NO";
            DtgLog.Columns["AktaranMasYeri"].HeaderText = "AKTARAN MASRAF YERİ";
            DtgLog.Columns["AktaranMasYeriSor"].HeaderText = "AKTARAN MASRAF YERİ SORUMLUSU";
            DtgLog.Columns["AktaranBolum"].HeaderText = "AKTARAN BÖLÜM";
            DtgLog.Columns["AlanPersonel"].HeaderText = "ALAN PERSONEL";
            DtgLog.Columns["AlanMasYeriNo"].HeaderText = "ALAN MASRAF YERİ NO";
            DtgLog.Columns["AlanMasYeri"].HeaderText = "ALAN MASRAF YERİ";
            DtgLog.Columns["AlanMasYerSor"].HeaderText = "ALAN MASRAF YERİ SORUMLUSU";
            DtgLog.Columns["AlanBolum"].HeaderText = "ALAN BÖLÜM";
            DtgLog.Columns["AktarimTarihi"].HeaderText = "AKTARIM TARİHİ";
            DtgLog.Columns["IslemYapan"].HeaderText = "İŞLEM YAPAN";
            DtgLog.Columns["Km"].HeaderText = "KİLOMETRE";
            DtgLog.Columns["AktariGerekcesi"].HeaderText = "AKTARIM GEREKÇESİ";
        }

        private void DtgLog_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgLog.FilterString;
            TxtTop.Text = DtgLog.RowCount.ToString();
        }

        private void DtgLog_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgLog.SortString;
        }
    }
}
