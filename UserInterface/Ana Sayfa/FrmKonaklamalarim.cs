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

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmKonaklamalarim : Form
    {
        KonaklamaManager konaklamaManager;
        List<Konaklama> konaklamas;
        public object[] infos;

        public FrmKonaklamalarim()
        {
            InitializeComponent();
            konaklamaManager = KonaklamaManager.GetInstance();
        }

        private void FrmKonaklamalarim_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        public void DataDisplay()
        {
            konaklamas = konaklamaManager.Konaklamalarim(infos[1].ToString());
            dataBinder.DataSource = konaklamas.ToDataTable();
            DtgList.DataSource = dataBinder;
            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["Talepturu"].Visible = false;
            DtgList.Columns["Formno"].HeaderText = "GÖREV FORM NO";
            DtgList.Columns["Butcekodu"].Visible = false;
            DtgList.Columns["Siparisno"].Visible = false;
            DtgList.Columns["Adsoyad"].HeaderText = "AD SOYAD";
            DtgList.Columns["Gorevi"].HeaderText = "GÖREVİ";
            DtgList.Columns["Masrafyerino"].HeaderText = "MASRAF YERİ NO";
            DtgList.Columns["Masrafyeri"].HeaderText = "MASRAF YERİ";
            DtgList.Columns["Tc"].Visible = false;
            DtgList.Columns["Hes"].Visible = false;
            DtgList.Columns["Email"].Visible = false;
            DtgList.Columns["Kisakod"].Visible = false;
            DtgList.Columns["Otelsehir"].HeaderText = "OTELİN BULUNDUĞU ŞEHİR";
            DtgList.Columns["Otelad"].HeaderText = "OTELİN ADI";
            DtgList.Columns["Giristarihi"].HeaderText = "GİRİŞ TARİHİ";
            DtgList.Columns["Cikistarihi"].HeaderText = "ÇIKIŞ TARİHİ";
            DtgList.Columns["Konaklamasuresi"].HeaderText = "KONAKLAMA SÜRESİ";
            DtgList.Columns["Gunukucret"].Visible = false;
            DtgList.Columns["Toplamucret"].Visible = false;
            DtgList.Columns["Onay"].Visible = false;
            DtgList.Columns["Isakisno"].HeaderText = "İŞ AKIŞ NO";
            DtgList.Columns["Isakisno"].DisplayIndex = 0;
            DtgList.Columns["Dosyayolu"].Visible = false;
            DtgList.Columns["Sayfa"].Visible = false;
            DtgList.Columns["SatNo"].Visible = false;
            DtgList.Columns["Donem"].HeaderText = "DÖNEM";
            DtgList.Columns["Gerekce"].HeaderText = "GEREKÇE";
            TxtToplam.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtToplam.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }
    }
}
