using Business;
using Business.Concreate.BakimOnarimAtolye;
using DataAccess.Concreate;
using Entity;
using Entity.BakimOnarimAtolye;
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
    public partial class FrmAtolyeVeri : Form
    {
        AtolyeRaporManager atolyeRaporManager;
        AtolyeRapor atolyeRapor;
        AtolyeManager atolyeManager;

        List<Atolye> kategoris;
        List<Atolye> atolyes;
        List<Atolye> atolyesAdet;
        public FrmAtolyeVeri()
        {
            InitializeComponent();
            atolyeRaporManager = AtolyeRaporManager.GetInstance();
            atolyeManager = AtolyeManager.GetInstance();
        }

        private void FrmAtolyeVeri_Load(object sender, EventArgs e)
        {
            KategoriGetir();
            AtolyeIslemAdimlari();
            timer1.Start();
        }
        void KategoriGetir()
        {
            kategoris = atolyeManager.AtolyeKategori();
            atolyes = atolyeManager.GetListVeriMalzeme();

            foreach (Atolye item in kategoris)
            {
                atolyesAdet = null;
                atolyesAdet = atolyeManager.AtolyeKategoriAdet(item.AtolyeKategori.ToString());


                if (item.AtolyeKategori == "AYTS")
                {

                    LblAyts.Text = atolyesAdet[0].AtolyeKategori.ToString();
                    continue;
                }
                if (item.AtolyeKategori == "DAS-YAMGÖZ")
                {
                    LblDasYamgoz.Text = atolyesAdet[0].AtolyeKategori.ToString();
                    continue;
                }
                if (item.AtolyeKategori == "DRAGONEYE")
                {
                    LblDragoneye.Text = atolyesAdet[0].AtolyeKategori.ToString();
                    continue;
                }
                if (item.AtolyeKategori == "EKİNOKS")
                {
                    LblEkinoks.Text = atolyesAdet[0].AtolyeKategori.ToString();
                    continue;
                }
                if (item.AtolyeKategori == "EKRANLI CİHAZLAR")
                {
                    LblEkranliCihazlar.Text = atolyesAdet[0].AtolyeKategori.ToString();
                    continue;
                }
                if (item.AtolyeKategori == "GÖREVSAYAR")
                {
                    LblGorevsayar.Text = atolyesAdet[0].AtolyeKategori.ToString();
                    continue;
                }
                if (item.AtolyeKategori == "HAREKETLİ PLATFORM")
                {
                    LblHareketliPlatform.Text = atolyesAdet[0].AtolyeKategori.ToString();
                    continue;
                }
                if (item.AtolyeKategori == "İŞ İSTASYONU (PC)")
                {
                    LblPc.Text = atolyesAdet[0].AtolyeKategori.ToString();
                    continue;
                }
                if (item.AtolyeKategori == "KABLAJ-KABLO TAKIMLARI")
                {
                    LblKabloKablaj.Text = atolyesAdet[0].AtolyeKategori.ToString();
                    continue;
                }
                if (item.AtolyeKategori == "PANO CİHAZLARI")
                {
                    LblPanoCihaz.Text = atolyesAdet[0].AtolyeKategori.ToString();
                    continue;
                }
                if (item.AtolyeKategori == "SİSMİK SENSÖR")
                {
                    LblSismik.Text = atolyesAdet[0].AtolyeKategori.ToString();
                    continue;
                }
                if (item.AtolyeKategori == "ŞAHİNGÖZÜ")
                {
                    LblSahingozu.Text = atolyesAdet[0].AtolyeKategori.ToString();
                    continue;
                }
                if (item.AtolyeKategori == "UYUMLAMA BİRİMLERİ")
                {
                    LblUyumlamaBrimleri.Text = atolyesAdet[0].AtolyeKategori.ToString();
                    continue;
                }

            }

            //LblGorevsayar.Text = "0";
            //LblAyts.Text = "1";
            //LblDas.Text = "8";
            //LblYamgoz.Text = "10";
            //LblDragoneye.Text = "1";
            //LblSahingozu.Text = "2";
            //LblTunga.Text = "6";
            //LblEkinoks.Text = "8";
            //LblGukas.Text = "4";
            //LblPc.Text = "10";
            //LblMonitor.Text = "10";
            //LblSismik.Text = "10";
            //LblDiger.Text = "52";

        }
        void AtolyeIslemAdimlari()
        {

            atolyeRapor = atolyeRaporManager.Get();


            Lbl400.Text = atolyeRapor.A400.ToString();
            Lbl500.Text = atolyeRapor.A500.ToString();
            Lbl600.Text = atolyeRapor.A600.ToString();
            Lbl700.Text = atolyeRapor.A700.ToString();
            Lbl800.Text = atolyeRapor.A800.ToString();
            Lbl900.Text = atolyeRapor.A900.ToString();
            Lbl1000.Text = atolyeRapor.A1000.ToString();
            Lbl1100.Text = atolyeRapor.A1100.ToString();
            Lbl1200.Text = atolyeRapor.A1200.ToString();

            #region EskiKod
            //atolyeRapor = atolyeRaporManager.Get();
            //DtgIslemAdimi.Rows.Add();
            //int sonSatir2 = DtgIslemAdimi.RowCount - 1;
            //for (int i = 0; i < 13; i++)
            //{
            //    if (i == 0)
            //    {
            //        DtgIslemAdimi.Rows[sonSatir2].Cells["C400"].Value = atolyeRapor.A400;
            //        continue;
            //    }
            //    if (i == 1)
            //    {
            //        DtgIslemAdimi.Rows[sonSatir2].Cells["C500"].Value = atolyeRapor.A500;
            //        continue;
            //    }
            //    if (i == 2)
            //    {
            //        DtgIslemAdimi.Rows[sonSatir2].Cells["C600"].Value = atolyeRapor.A600;
            //        continue;
            //    }
            //    if (i == 3)
            //    {
            //        DtgIslemAdimi.Rows[sonSatir2].Cells["C700"].Value = atolyeRapor.A700;
            //        continue;
            //    }
            //    if (i == 4)
            //    {
            //        DtgIslemAdimi.Rows[sonSatir2].Cells["C800"].Value = atolyeRapor.A800;
            //        continue;
            //    }
            //    if (i == 5)
            //    {
            //        DtgIslemAdimi.Rows[sonSatir2].Cells["C900"].Value = atolyeRapor.A900;
            //        continue;
            //    }
            //    if (i == 6)
            //    {
            //        DtgIslemAdimi.Rows[sonSatir2].Cells["C1000"].Value = atolyeRapor.A1000;
            //        continue;
            //    }
            //    if (i == 7)
            //    {
            //        DtgIslemAdimi.Rows[sonSatir2].Cells["C1100"].Value = atolyeRapor.A1100;
            //        continue;
            //    }
            //    if (i == 8)
            //    {
            //        DtgIslemAdimi.Rows[sonSatir2].Cells["C1200"].Value = atolyeRapor.A1200;
            //        continue;
            //    }
            //    if (i == 9)
            //    {
            //        DtgIslemAdimi.Rows[sonSatir2].Cells["C1300"].Value = atolyeRapor.A1300;
            //        continue;
            //    }
            //    if (i == 10)
            //    {
            //        DtgIslemAdimi.Rows[sonSatir2].Cells["C1400"].Value = atolyeRapor.A1400;
            //        continue;
            //    }
            //    if (i == 11)
            //    {
            //        DtgIslemAdimi.Rows[sonSatir2].Cells["C1500"].Value = atolyeRapor.A1500;
            //        continue;
            //    }
            //    if (i == 12)
            //    {
            //        DtgIslemAdimi.Rows[sonSatir2].Cells["C1600"].Value = atolyeRapor.A1600;
            //        continue;
            //    }
            //}
            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            KategoriGetir();
            AtolyeIslemAdimlari();
        }
    }
}
