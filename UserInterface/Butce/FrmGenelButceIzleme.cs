using Business.Concreate.Butce;
using DataAccess.Concreate;
using Entity.Butce;
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

namespace UserInterface.Butce
{
    public partial class FrmGenelButceIzleme : Form
    {
        List<ButceKayit> butceKayits;
        ButceManager butceManager;
        public FrmGenelButceIzleme()
        {
            InitializeComponent();
            butceManager = ButceManager.GetInstance();
        }

        private void FrmGenelButceIzleme_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageGenelButce"]);

            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
        }
        double giderTutar, gelirToplam, giderToplam, kalanToplam = 0;

        private void BtnGrafikOlsutur_Click(object sender, EventArgs e)
        {
            if (TxtButceGenelTop.Text=="")
            {
                MessageBox.Show("Veri bulunmadığı için grafik oluşturulamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmGenelButceGrafik frmGenelButceGrafik = new FrmGenelButceGrafik();

            string[] arrayGelir = TxtButceGenelTop.Text.Split('₺');
            string[] arrayGider = TxtHarcananGenelTop.Text.Split('₺');
            string[] arrayKalan = TxtKalanGenelTop.Text.Split('₺');

            frmGenelButceGrafik.gelir = arrayGelir[1].ConDouble();
            frmGenelButceGrafik.gider = arrayGider[1].ConDouble();
            frmGenelButceGrafik.kalan= arrayKalan[1].ConDouble();
            frmGenelButceGrafik.ShowDialog();
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            if (CmbButceYil.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Bütçe Yıl bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbButceDonem.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Bütçe Dönem bilgisini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CmbButceDonem.Text != "TÜM YIL")
            {
                butceKayits = butceManager.GetList(CmbButceYil.Text, CmbButceDonem.Text);
            }
            else
            {
                butceKayits = butceManager.GetList(CmbButceYil.Text);
            }

            TxtButceBM12.Clear(); TxtHarcananBM12.Clear(); TxtKalanBM12.Clear();
            TxtButceBM45.Clear(); TxtHarcananBM45.Clear(); TxtKalanBM45.Clear();
            TxtButceBM46.Clear(); TxtHarcananBM46.Clear(); TxtKalanBM46.Clear();
            TxtButceBM21.Clear(); TxtHarcananBM21.Clear(); TxtKalanBM21.Clear();
            TxtButceBM23.Clear(); TxtHarcananBM23.Clear(); TxtKalanBM23.Clear();
            TxtButceBM24.Clear(); TxtHarcananBM24.Clear(); TxtKalanBM24.Clear();
            TxtButceBM25.Clear(); TxtHarcananBM25.Clear(); TxtKalanBM25.Clear();
            TxtButceBM26.Clear(); TxtHarcananBM26.Clear(); TxtKalanBM26.Clear();

            TxtButceGenelTop.Clear(); TxtHarcananGenelTop.Clear(); TxtKalanGenelTop.Clear();

            if (butceKayits.Count==0)
            {
                MessageBox.Show("Bütçe veri girişi bulunamamıştır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CmbButceDonem.Text == "TÜM YIL")
            {
                for (int i = 0; i < butceKayits.Count; i++)
                {
                    string[] gelirTutar = butceKayits[i].ButceTutariYillik.ToString().Split('?');
                    string[] butceKalemi = butceKayits[i].ButceTanim.ToString().Split('/');

                    if (butceKalemi[0].ToString() == "BM46")
                    {
                        giderTutar = butceManager.SatButceHarcamaBM46(butceKalemi[0].ToString(), CmbButceYil.Text);
                    }
                    else
                    {
                        giderTutar = butceManager.SatButceHarcama(butceKalemi[0].ToString(), CmbButceYil.Text);
                    }

                    double yillikButceToplamGelir = gelirTutar[1].ConDouble() * 2;

                    double kalan = yillikButceToplamGelir - giderTutar;

                    if (butceKalemi[0].ToString() == "BM12")
                    {
                        TxtButceBM12.Text = yillikButceToplamGelir.ToString("C2");
                        TxtHarcananBM12.Text = giderTutar.ToString("C2");
                        TxtKalanBM12.Text = kalan.ToString("C2");

                        gelirToplam += yillikButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                    if (butceKalemi[0].ToString() == "BM21")
                    {
                        TxtButceBM21.Text = yillikButceToplamGelir.ToString("C2");
                        TxtHarcananBM21.Text = giderTutar.ToString("C2");
                        TxtKalanBM21.Text = kalan.ToString("C2");

                        gelirToplam += yillikButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                    if (butceKalemi[0].ToString() == "BM23")
                    {
                        TxtButceBM23.Text = yillikButceToplamGelir.ToString("C2");
                        TxtHarcananBM23.Text = giderTutar.ToString("C2");
                        TxtKalanBM23.Text = kalan.ToString("C2");

                        gelirToplam += yillikButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                    if (butceKalemi[0].ToString() == "BM24")
                    {
                        TxtButceBM24.Text = yillikButceToplamGelir.ToString("C2");
                        TxtHarcananBM24.Text = giderTutar.ToString("C2");
                        TxtKalanBM24.Text = kalan.ToString("C2");

                        gelirToplam += yillikButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                    if (butceKalemi[0].ToString() == "BM25")
                    {
                        TxtButceBM25.Text = yillikButceToplamGelir.ToString("C2");
                        TxtHarcananBM25.Text = giderTutar.ToString("C2");
                        TxtKalanBM25.Text = kalan.ToString("C2");

                        gelirToplam += yillikButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                    if (butceKalemi[0].ToString() == "BM26")
                    {
                        TxtButceBM26.Text = yillikButceToplamGelir.ToString("C2");
                        TxtHarcananBM26.Text = giderTutar.ToString("C2");
                        TxtKalanBM26.Text = kalan.ToString("C2");

                        gelirToplam += yillikButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                    if (butceKalemi[0].ToString() == "BM45")
                    {
                        TxtButceBM45.Text = yillikButceToplamGelir.ToString("C2");
                        TxtHarcananBM45.Text = giderTutar.ToString("C2");
                        TxtKalanBM45.Text = kalan.ToString("C2");

                        gelirToplam += yillikButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                    if (butceKalemi[0].ToString() == "BM46")
                    {
                        TxtButceBM46.Text = yillikButceToplamGelir.ToString("C2");
                        TxtHarcananBM46.Text = giderTutar.ToString("C2");
                        TxtKalanBM46.Text = kalan.ToString("C2");

                        gelirToplam += yillikButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                }

                TxtButceGenelTop.Text= gelirToplam.ToString("C2");
                TxtHarcananGenelTop.Text = giderToplam.ToString("C2");
                TxtKalanGenelTop.Text=kalanToplam.ToString("C2");
                gelirToplam = 0; giderToplam = 0; kalanToplam = 0;

            }

            else
            {
                for (int i = 0; i < butceKayits.Count; i++)
                {
                    string[] gelirTutar = butceKayits[i].ButceTutariYillik.ToString().Split('?');
                    double donemButceToplamGelir = gelirTutar[1].ConDouble();

                    string[] butceKalemi = butceKayits[i].ButceTanim.ToString().Split('/');

                    if (butceKalemi[0].ToString() == "BM46")
                    {
                        giderTutar = butceManager.SatButceHarcamaBM46(butceKalemi[0].ToString(), CmbButceYil.Text, CmbButceDonem.Text);
                    }
                    else
                    {
                        giderTutar = butceManager.SatButceHarcama(butceKalemi[0].ToString(), CmbButceYil.Text, CmbButceDonem.Text);
                    }

                    double kalan = donemButceToplamGelir - giderTutar;

                    if (butceKalemi[0].ToString() == "BM12")
                    {
                        TxtButceBM12.Text = donemButceToplamGelir.ToString("C2");
                        TxtHarcananBM12.Text = giderTutar.ToString("C2");
                        TxtKalanBM12.Text = kalan.ToString("C2");

                        gelirToplam += donemButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                    if (butceKalemi[0].ToString() == "BM21")
                    {
                        TxtButceBM21.Text = donemButceToplamGelir.ToString("C2");
                        TxtHarcananBM21.Text = giderTutar.ToString("C2");
                        TxtKalanBM21.Text = kalan.ToString("C2");

                        gelirToplam += donemButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                    if (butceKalemi[0].ToString() == "BM23")
                    {
                        TxtButceBM23.Text = donemButceToplamGelir.ToString("C2");
                        TxtHarcananBM23.Text = giderTutar.ToString("C2");
                        TxtKalanBM23.Text = kalan.ToString("C2");

                        gelirToplam += donemButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                    if (butceKalemi[0].ToString() == "BM24")
                    {
                        TxtButceBM24.Text = donemButceToplamGelir.ToString("C2");
                        TxtHarcananBM24.Text = giderTutar.ToString("C2");
                        TxtKalanBM24.Text = kalan.ToString("C2");

                        gelirToplam += donemButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                    if (butceKalemi[0].ToString() == "BM25")
                    {
                        TxtButceBM25.Text = donemButceToplamGelir.ToString("C2");
                        TxtHarcananBM25.Text = giderTutar.ToString("C2");
                        TxtKalanBM25.Text = kalan.ToString("C2");

                        gelirToplam += donemButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                    if (butceKalemi[0].ToString() == "BM26")
                    {
                        TxtButceBM26.Text = donemButceToplamGelir.ToString("C2");
                        TxtHarcananBM26.Text = giderTutar.ToString("C2");
                        TxtKalanBM26.Text = kalan.ToString("C2");

                        gelirToplam += donemButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                    if (butceKalemi[0].ToString() == "BM45")
                    {
                        TxtButceBM45.Text = donemButceToplamGelir.ToString("C2");
                        TxtHarcananBM45.Text = giderTutar.ToString("C2");
                        TxtKalanBM45.Text = kalan.ToString("C2");

                        gelirToplam += donemButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                    if (butceKalemi[0].ToString() == "BM46")
                    {
                        TxtButceBM46.Text = donemButceToplamGelir.ToString("C2");
                        TxtHarcananBM46.Text = giderTutar.ToString("C2");
                        TxtKalanBM46.Text = kalan.ToString("C2");

                        gelirToplam += donemButceToplamGelir;
                        giderToplam += giderTutar;
                        kalanToplam += kalan;
                    }
                }

                TxtButceGenelTop.Text = gelirToplam.ToString("C2");
                TxtHarcananGenelTop.Text = giderToplam.ToString("C2");
                TxtKalanGenelTop.Text = kalanToplam.ToString("C2");
                gelirToplam = 0; giderToplam = 0; kalanToplam = 0;

            }

            butceKayits.Clear();
        }
    }
}
