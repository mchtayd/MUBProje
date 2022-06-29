using Business.Concreate.Gecici_Kabul_Ambar;
using DataAccess.Concreate;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;
using ZXing;

namespace UserInterface.Gecic_Kabul_Ambar
{
    public partial class FrmDepoDusum : Form
    {
        List<Malzeme> malzemes;
        List<Malzeme> malzemes2;
        List<MalzemeKayit> malzemeKayits;
        List<MalzemeKayit> malzemeKayits2;
        MalzemeManager malzemeManager;
        MalzemeKayitManager malzemeKayitManager;
        string readedBarcode;
        int comboId;
        bool start = true;

        public FrmDepoDusum()
        {
            InitializeComponent();
            malzemeManager = MalzemeManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
        }

        private void FrmDepoDusum_Load(object sender, EventArgs e)
        {
            //TxtSeriNo.Select();
            StokBilgileri();
            TanimBilgileri();
            start = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void StokBilgileri()
        {
            malzemeKayits = malzemeKayitManager.GetList();
            CmbStokNo.DataSource = malzemeKayits;
            CmbStokNo.ValueMember = "Id";
            CmbStokNo.DisplayMember = "StokNo";
            CmbStokNo.SelectedValue = 0;
        }
        void TanimBilgileri()
        {
            malzemeKayits2 = malzemeKayitManager.GetList();
            CmbTanim.DataSource = malzemeKayits2;
            CmbTanim.ValueMember = "Id";
            CmbTanim.DisplayMember = "Tanim";
            CmbTanim.SelectedValue = 0;
        }

        private void TxtSeriNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                readedBarcode = TxtSeriNo.Text;

                //TxtSeriNo.Clear();

            }
        }
        int sayi = 0;
        //80mm X 40mm kuşe etiket
        private void BtnBarkodOlustur_Click(object sender, EventArgs e)
        {
            BarcodeWriter writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions() { Width = 300, Height = 100 }
            };
            Bitmap myBitmap1 = writer.Write(CmbStokNo.Text + " " + TxtSeriNo.Text + " " + TxtRevizyon.Text);
            PctBarcode.Image = myBitmap1;

        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in DtgYedekParca.Rows)
                {
                    PrinterSettings ps = new PrinterSettings();

                    PrintDocument printDoc = new PrintDocument
                    {
                        PrinterSettings = ps
                    };
                    printDoc.DefaultPageSettings.PaperSize = new PaperSize("Custom", 400, 100);
                    printDoc.PrintPage += PrintPage;
                    printDoc.Print();
                    sayi++;
                }

                

            }
            catch (Exception ex)
            {
                return;
            }

        }

        // En 10 / Boy 4cm
        private void PrintPage(object o, PrintPageEventArgs e)
        {
            try
            {
                //Point loc = new Point(1, 10);
                //e.Graphics.DrawImage(images[0], new Point(1, -1));
                e.Graphics.DrawImage(images[sayi], 2, -1, 400, 100);
                /*int size = e.MarginBounds.Width;
                Bitmap bitmap = new Bitmap(size, size);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.DrawImage(images[0], new Rectangle(0, 0, size, size));*/
                //e.Graphics.DrawImage(graphics,);

            }
            catch (Exception ex)
            {

            }

            /*foreach (DataGridViewRow item in DtgYedekParca.Rows)
            {

                try
                {
                    Point loc = new Point(8, 8);
                    e.Graphics.DrawImage((Image)item.Cells["Photo"].Value, loc);
                    //e.Graphics.DrawImage(PctBarcode.Image, loc);
                }
                catch (Exception ex)
                {
                    return;
                }
                
            }*/

        }

        private void CmbStokNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            comboId = CmbStokNo.SelectedValue.ConInt();
            MalzemeKayit malzemeKayit = malzemeKayitManager.Get(comboId);
            if (malzemeKayit == null)
            {
                CmbTanim.Text = "";
                return;
            }
            CmbTanim.Text = malzemeKayit.Tanim;
        }

        private void CmbStokNo_TextChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbStokNo.Text == "")
            {
                CmbTanim.Text = "";
            }
            else
            {
                foreach (MalzemeKayit item in malzemeKayits)
                {
                    if (CmbStokNo.Text == item.Stokno)
                    {
                        CmbTanim.Text = item.Tanim;
                    }
                }
            }
        }

        private void CmbTanim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            comboId = CmbTanim.SelectedValue.ConInt();
            MalzemeKayit malzemeKayit = malzemeKayitManager.Get(comboId);
            if (malzemeKayit == null)
            {
                CmbStokNo.Text = "";
                return;
            }
            CmbStokNo.Text = malzemeKayit.Stokno;
        }

        private void CmbTanim_TextChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            if (CmbTanim.Text == "")
            {
                CmbStokNo.Text = "";
            }
            else
            {
                foreach (MalzemeKayit item in malzemeKayits2)
                {
                    if (CmbTanim.Text == item.Tanim)
                    {
                        CmbStokNo.Text = item.Stokno;
                    }
                }
            }
        }
        List<Image> images = new List<Image>();
        private void BtnListeyeEkle_Click(object sender, EventArgs e)
        {
            if (PctBarcode.Image != null)
            {
                try
                {
                    DataGridViewImageColumn dgvImageColumn = new DataGridViewImageColumn();
                    dgvImageColumn.HeaderText = "Barkod";
                    dgvImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

                    //DtgYedekParca.Rows.Add(dgvImageColumn);
                    DtgYedekParca.Rows.Add(PctBarcode.Image);


                    images.Add(PctBarcode.Image);


                }
                catch (Exception ex)
                {

                    return;
                }
            }
            else
            {
                MessageBox.Show("Lütfen öncelikle bir barkod oluşturunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DtgYedekParca_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            return;
        }
    }
}
