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
    public partial class FrmAtolyeRapor : Form
    {
        List<Atolye> kategoris;
        List<string> kategorisSayi;
        AtolyeManager atolyeManager;
        AtolyeRaporManager atolyeRaporManager;

        AtolyeRapor atolyeRapor;
        public FrmAtolyeRapor()
        {
            InitializeComponent();
            atolyeManager = AtolyeManager.GetInstance();
            atolyeRaporManager = AtolyeRaporManager.GetInstance();
        }

        private void FrmAtolyeRapor_Load(object sender, EventArgs e)
        {
            KategoriGetir();
            AtolyeIslemAdimlari();
            timer1.Start();
        }

        void KategoriGetir()
        {
            kategoris = atolyeManager.AtolyeKategori();


            //int sayac = 0;

            //DtgKategori.ColumnCount = kategoris.Count;
            //foreach (var item in kategoris)
            //{
            //    DtgKategori.Columns[sayac].Name = kategoris[sayac].ToString();
            //    sayac++;
            //}

            //int sonSatir = DtgKategori.RowCount - 1;
            //sayac = 0;
            //foreach (var item in kategoris)
            //{
            //    kategorisSayi = atolyeManager.AtolyeKategoriAdet(kategoris[sayac].ToString());
            //    DtgKategori.Rows[sonSatir].Cells[sayac].Value = kategorisSayi[0].ToString();
            //    sayac++;
            //}
            int sayac = 0;
            foreach (var item in kategoris)
            {
                //kategorisSayi = atolyeManager.AtolyeKategoriAdet(kategoris[sayac].ToString());
                string kategori = kategoris[sayac].ToString();
                string kategoriSayi = kategorisSayi[0].ToString();

                DtgKategoriler.Rows.Add();
                int sonSatir2 = DtgKategoriler.RowCount - 1;

                DtgKategoriler.Rows[sonSatir2].Cells["Adet"].Value = kategoriSayi.ToString();
                DtgKategoriler.Rows[sonSatir2].Cells["Kategori"].Value = kategori.ToString();

                sayac++;

            }
            DataGridViewColumn column = DtgKategoriler.Columns[0];
            column.Width = 120;

            DataGridViewColumn column2 = DtgIslemAdimi.Columns[0];
            column2.Width = 120;


        }
        void AtolyeIslemAdimlari()
        {
            atolyeRapor = atolyeRaporManager.Get();
            for (int i = 0; i < 13; i++)
            {
                DtgIslemAdimi.Rows.Add();
                int sonSatir2 = DtgIslemAdimi.RowCount - 1;
                if (i == 0)
                {
                    DtgIslemAdimi.Rows[sonSatir2].Cells["Adet2"].Value = atolyeRapor.A400;
                    DtgIslemAdimi.Rows[sonSatir2].Cells["IslemAdimi"].Value = "400-BİLDİRİM ve B/O BAŞLAMA ONAYI (MÜHENDİS)";
                    continue;
                }
                if (i == 1)
                {
                    DtgIslemAdimi.Rows[sonSatir2].Cells["Adet2"].Value = atolyeRapor.A500;
                    DtgIslemAdimi.Rows[sonSatir2].Cells["IslemAdimi"].Value = "500-GÖZ DENETİMİ (TEKNİK SERVİS)";
                    continue;
                }
                if (i == 2)
                {
                    DtgIslemAdimi.Rows[sonSatir2].Cells["Adet2"].Value = atolyeRapor.A600;
                    DtgIslemAdimi.Rows[sonSatir2].Cells["IslemAdimi"].Value = "600-ARIZA TESPİTİ/ELEKTRİKSEL/FONK. KONTROL";
                    continue;
                }
                if (i == 3)
                {
                    DtgIslemAdimi.Rows[sonSatir2].Cells["Adet2"].Value = atolyeRapor.A700;
                    DtgIslemAdimi.Rows[sonSatir2].Cells["IslemAdimi"].Value = "700-FABRİKA BAKIM ONARIM (ASELSAN)";
                    continue;
                }
                if (i == 4)
                {
                    DtgIslemAdimi.Rows[sonSatir2].Cells["Adet2"].Value = atolyeRapor.A800;
                    DtgIslemAdimi.Rows[sonSatir2].Cells["IslemAdimi"].Value = "800-MALZEME HAZIRLAMA (AMBAR)";
                    continue;
                }
                if (i == 5)
                {
                    DtgIslemAdimi.Rows[sonSatir2].Cells["Adet2"].Value = atolyeRapor.A900;
                    DtgIslemAdimi.Rows[sonSatir2].Cells["IslemAdimi"].Value = "900-BAKIM ONARIM (TEKNİK SERVİS)";
                    continue;
                }
                if (i == 6)
                {
                    DtgIslemAdimi.Rows[sonSatir2].Cells["Adet2"].Value = atolyeRapor.A1000;
                    DtgIslemAdimi.Rows[sonSatir2].Cells["IslemAdimi"].Value = "1000-ONARIM DENETİMİ (KALİTE)";
                    continue;
                }
                if (i == 7)
                {
                    DtgIslemAdimi.Rows[sonSatir2].Cells["Adet2"].Value = atolyeRapor.A1100;
                    DtgIslemAdimi.Rows[sonSatir2].Cells["IslemAdimi"].Value = "1100-KABUL/ELEKTRİKSEL/FONK.KONTROL/TEST";
                    continue;
                }
                if (i == 8)
                {
                    DtgIslemAdimi.Rows[sonSatir2].Cells["Adet2"].Value = atolyeRapor.A1200;
                    DtgIslemAdimi.Rows[sonSatir2].Cells["IslemAdimi"].Value = "1200-SON İŞLEMLER (TEKNİK SERVİS)";
                    continue;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            kategoris.Clear();
            atolyeRapor = null;
            DtgIslemAdimi.Rows.Clear();
            DtgKategoriler.Rows.Clear();
            KategoriGetir();
            AtolyeIslemAdimlari();
        }
    }
}
