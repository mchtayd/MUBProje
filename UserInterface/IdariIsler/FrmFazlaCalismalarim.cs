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

namespace UserInterface.IdariIsler
{
    public partial class FrmFazlaCalismalarim : Form
    {
        FazlaCalismaManager fazlaCalismaManager;
        List<FazlaCalisma> fazlaCalismas = new List<FazlaCalisma>();
        public object[] infos;
        public FrmFazlaCalismalarim()
        {
            InitializeComponent();
            fazlaCalismaManager = FazlaCalismaManager.GetInstance();
        }
        private void FrmFazlaCalismalarim_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        void DataDisplay()
        {
            fazlaCalismas = fazlaCalismaManager.GetListPersonel(infos[1].ToString());
            dataBinder.DataSource = fazlaCalismas.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["PersonelAd"].HeaderText = "PERSONEL ADI";
            DtgList.Columns["PersonelBolum"].HeaderText = "BÖLÜM";
            DtgList.Columns["FazlaCalismaNedeni"].HeaderText = "FAZLA ÇALIŞMA NEDENİ";
            DtgList.Columns["MesaiBasTarihi"].HeaderText = "MESAİ BAŞLANGIÇ TAİHİ";
            DtgList.Columns["MesaiBitTarihi"].HeaderText = "MESAİ BİTİŞ TARİHİ";
            DtgList.Columns["ToplamMesaiSaati"].HeaderText = "TOPLAM MESAİ SAATİ";
            DtgList.Columns["ToplamHakEdilenIzin"].HeaderText = "TOPLAM HAK EDİLEN İZİN";
            DtgList.Columns["OnayDurumu"].HeaderText = "ONAY DURUMU";
            DtgList.Columns["OnayVeren"].HeaderText = "ONAY VEREN";

            DtgList.Columns["FazlaCalismaNedeni"].DisplayIndex = 0;
            DtgList.Columns["MesaiBasTarihi"].DisplayIndex = 1;
            DtgList.Columns["MesaiBitTarihi"].DisplayIndex = 2;
            DtgList.Columns["ToplamMesaiSaati"].DisplayIndex = 3;
            DtgList.Columns["ToplamHakEdilenIzin"].DisplayIndex = 4;
            DtgList.Columns["OnayDurumu"].DisplayIndex = 5;
            DtgList.Columns["OnayVeren"].DisplayIndex = 6;
            DtgList.Columns["PersonelAd"].DisplayIndex = 7;
            DtgList.Columns["PersonelBolum"].DisplayIndex = 8;

            ToplamlarMesai();
            ToplamlarIzin();

        }
        void ToplamlarMesai()
        {
            double toplam = 0;
            double dakikaTop = 0;
            double dakikaSaat = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                string izinsuresi = DtgList.Rows[i].Cells["ToplamMesaiSaati"].Value.ToString();
                string[] array = izinsuresi.Split(' ');
                toplam += Convert.ToDouble(array[0].ConDouble());
                if (array.Length>2)
                {
                    dakikaTop += array[2].ConDouble();
                }
            }
            if (dakikaTop != 0)
            {
                dakikaSaat = dakikaTop / 60;
                string[] saat = dakikaSaat.ToString().Split(',');
                dakikaTop = dakikaTop % 60;
                dakikaSaat = saat[0].ConDouble();
                toplam += dakikaSaat;
                LblFazlaCalisma.Text = toplam.ToString() + " Saat " + dakikaTop.ToString() + " Dakika";
            }
            else
            {
                LblFazlaCalisma.Text = toplam.ToString() + " Saat";
            }
        }

        void ToplamlarIzin()
        {
            double toplam = 0;
            double dakikaTop = 0;
            double dakikaSaat = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                string izinsuresi = DtgList.Rows[i].Cells["ToplamHakEdilenIzin"].Value.ToString();
                string[] array = izinsuresi.Split(' ');
                toplam += Convert.ToDouble(array[0].ConDouble());
                if (array.Length > 2)
                {
                    dakikaTop += array[2].ConDouble();
                }
            }
            if (dakikaTop != 0)
            {
                dakikaSaat = dakikaTop / 60;
                string[] saat = dakikaSaat.ToString().Split(',');
                dakikaTop = dakikaTop % 60;
                dakikaSaat = saat[0].ConDouble();
                toplam += dakikaSaat;
                LblIzin.Text = toplam.ToString() + " Saat " + dakikaTop.ToString() + " Dakika";
            }
            else
            {
                LblIzin.Text = toplam.ToString() + " Saat";
            }
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            ToplamlarMesai();
            ToplamlarIzin();
            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }
    }
}
