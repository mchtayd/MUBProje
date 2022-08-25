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
        List<Barkod> barkodList = new List<Barkod>();

        MalzemeManager malzemeManager;
        MalzemeKayitManager malzemeKayitManager;
        BarkodManager barkodManager;

        public object[] infos;
        string readedBarcode;
        int comboId, id = 0;
        bool start = true, firstClick = false, kayitDurumu = false;

        public FrmDepoDusum()
        {
            InitializeComponent();
            malzemeManager = MalzemeManager.GetInstance();
            malzemeKayitManager = MalzemeKayitManager.GetInstance();
            barkodManager = BarkodManager.GetInstance();
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
        string CreateBarkodControl()
        {
            if (CmbStokNo.Text=="")
            {
                return "Lütfen öncelikle bir Stok No seçiniz!";
            }
            if (TxtSeriNo.Text=="")
            {
                return "Lütfen Seri No Bilgisini doldurunuz!";
            }
            if (TxtRevizyon.Text=="")
            {
                return "Lütfen Revizyon bilgisini doldurunuz!";
            }
            return "OK";
        }
        private void BtnBarkodOlustur_Click(object sender, EventArgs e)
        {
            string mesaj = CreateBarkodControl();
            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BarcodeWriter writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions() { Width = 120, Height = 120 }

                //Format = BarcodeFormat.CODE_128,
                //Options = new ZXing.Common.EncodingOptions() { Width = 300, Height = 100 }
            };

            Barkod barkod = barkodManager.BarkodKontrolList(CmbStokNo.Text, TxtSeriNo.Text, TxtRevizyon.Text);

            if (barkod!=null)
            {
                id = barkod.Id;
                Bitmap myBitmap1 = writer.Write(CmbStokNo.Text + "\n" + CmbTanim.Text+ "\n" + TxtSeriNo.Text + "\n" + TxtRevizyon.Text);
                PctBarcode.Image = myBitmap1;
                kayitDurumu = true;
            }
            else
            {
                List<Barkod> barkods = new List<Barkod>();
                kayitDurumu = false;
                barkods = barkodManager.GetList();
                if (firstClick == false)
                {
                    if (barkods.Count()==0)
                    {
                        id = 10000;
                    }
                    else
                    {
                        if (barkodList.Count==0)
                        {
                            id = barkods[barkodList.Count].Id.ConInt();
                            id++;
                        }
                        else
                        {
                            id = barkodList[barkodList.Count - 1].Id.ConInt();
                            id++;
                        }
                        
                    }

                    Bitmap myBitmap1 = writer.Write(CmbStokNo.Text + "\n" + CmbTanim.Text + "\n" + TxtSeriNo.Text + "\n" + TxtRevizyon.Text);
                    PctBarcode.Image = myBitmap1;
                }
                else
                {
                    id = barkodList[barkodList.Count - 1].Id.ConInt();
                    id++;
                    Bitmap myBitmap1 = writer.Write(CmbStokNo.Text + "\n" + CmbTanim.Text + "\n" + TxtSeriNo.Text + "\n" + TxtRevizyon.Text);
                    PctBarcode.Image = myBitmap1;
                }
            }
            

            //BarcodeWriter writer = new BarcodeWriter()
            //{
            //    Format = BarcodeFormat.CODE_128,
            //    Options = new ZXing.Common.EncodingOptions() { Width = 300, Height = 100 }
            //};
            //Bitmap myBitmap1 = writer.Write(CmbStokNo.Text + " " + TxtSeriNo.Text + " " + TxtRevizyon.Text);
            //PctBarcode.Image = myBitmap1;

        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                
                foreach (Barkod item in barkodList)
                {
                    if (item.KayitDurumu==false)
                    {
                        barkodManager.Add(item);
                    }
                    else
                    {
                        barkodManager.BarkodTekrarCikti(item);
                    }

                    PrinterSettings ps = new PrinterSettings();

                    PrintDocument printDoc = new PrintDocument
                    {
                        PrinterSettings = ps
                    };
                    
                    printDoc.DefaultPageSettings.PaperSize = new PaperSize("Custom", 150, 120);
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
        void Temizle()
        {
            DtgYedekParca.Rows.Clear(); CmbStokNo.SelectedIndex = -1; CmbTanim.SelectedIndex = -1; TxtSeriNo.Clear(); TxtRevizyon.Clear();
        }

        // En 10 / Boy 4cm
        private void PrintPage(object o, PrintPageEventArgs e)
        {
            try
            {
                //Point loc = new Point(1, 10);
                //e.Graphics.DrawImage(images[0], new Point(1, -1));
                e.Graphics.DrawImage(images[sayi], 2, -1, 150, 120);
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
            string takipDurumu = malzemeKayit.Malzemetakipdurumu;
            if (takipDurumu=="LOT NO")
            {
                LblTakipDurumu.Text = "Lot No :";
            }
            else
            {
                LblTakipDurumu.Text = "Seri No:";
            }
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
                    Barkod controlListKayitsiz = new Barkod(id, CmbStokNo.Text, CmbTanim.Text, TxtSeriNo.Text, TxtRevizyon.Text, infos[1].ToString(), DateTime.Now, kayitDurumu);
                    barkodList.Add(controlListKayitsiz);
                    firstClick = true;

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
