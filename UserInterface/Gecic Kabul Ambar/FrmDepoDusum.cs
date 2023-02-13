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
        List<Barkod> barkodList = new List<Barkod>();

        MalzemeManager malzemeManager;
        MalzemeKayitManager malzemeKayitManager;
        BarkodManager barkodManager;

        public object[] infos;
        string readedBarcode, stokNo, tanim;
        int comboId, id = 0;
        bool start = true, firstClick = false, kayitDurumu = false;

        public string stok = "";

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
            if (stok!="")
            {
                CmbStokNo.Text = stok;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void StokBilgileri()
        {
            malzemes = malzemeManager.GetList();
            CmbStokNo.DataSource = malzemes;
            CmbStokNo.ValueMember = "Id";
            CmbStokNo.DisplayMember = "StokNo";
            CmbStokNo.SelectedValue = 0;
        }
        void TanimBilgileri()
        {
            malzemes2 = malzemeManager.GetList();
            CmbTanim.DataSource = malzemes2;
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
                Options = new ZXing.Common.EncodingOptions() { Width = 200, Height = 200 }

                //Format = BarcodeFormat.CODE_128,
                //Options = new ZXing.Common.EncodingOptions() { Width = 300, Height = 100 }
            };

            Barkod barkod = barkodManager.BarkodKontrolList(CmbStokNo.Text, TxtSeriNo.Text, TxtRevizyon.Text);

            if (barkod!=null)
            {
                id = barkod.Id;
                Bitmap myBitmap1 = writer.Write(id + " " + "\n" +  CmbStokNo.Text + "\n" + CmbTanim.Text+ "\n" + TxtSeriNo.Text + "\n" + TxtRevizyon.Text);
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
                        id = 1;
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
                        // KRAL 29.08.2022 
                    }

                    Bitmap myBitmap1 = writer.Write(id + " " + "\n" +  CmbStokNo.Text + "\n" + CmbTanim.Text + "\n" + TxtSeriNo.Text + "\n" + TxtRevizyon.Text);
                    PctBarcode.Image = myBitmap1;
                }
                else
                {
                    id = barkodList[barkodList.Count - 1].Id.ConInt();
                    id++;
                    Bitmap myBitmap1 = writer.Write(id + " " + "\n" +  CmbStokNo.Text + "\n" + CmbTanim.Text + "\n" + TxtSeriNo.Text + "\n" + TxtRevizyon.Text);
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
            if (DtgYedekParca.RowCount==0)
            {
                MessageBox.Show("Lütfen öncelikle listeye barkod ekleyiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
                        barkodManager.Add(item);
                        //barkodManager.BarkodTekrarCikti(item);
                    }

                    PrinterSettings ps = new PrinterSettings();

                    PrintDocument printDoc = new PrintDocument
                    {
                        PrinterSettings = ps
                    };
                    
                    printDoc.DefaultPageSettings.PaperSize = new PaperSize("Custom", 150, 130);
                    printDoc.PrintPage += PrintPage;
                    printDoc.Print();
                    sayi++;
                }
                

            }
            catch (Exception)
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
                e.Graphics.DrawImage(images[sayi], 2, -1, 150, 130);
                /*int size = e.MarginBounds.Width;
                Bitmap bitmap = new Bitmap(size, size);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.DrawImage(images[0], new Rectangle(0, 0, size, size));*/
                //e.Graphics.DrawImage(graphics,);

            }
            catch (Exception)
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
            stokNo = CmbStokNo.Text;
            Malzeme malzemeKayit = malzemeManager.Get(stokNo);
            if (malzemeKayit == null)
            {
                CmbTanim.Text = "";
                return;
            }
            CmbTanim.Text = malzemeKayit.Tanim;
            string takipDurumu = malzemeKayit.TakipDurumu;
            if (takipDurumu=="LOT NO")
            {
                LblTakipDurumu.Text = "Lot No :";
                BtnLotAl.Visible = true;
            }
            else
            {
                LblTakipDurumu.Text = "Seri No:";
                BtnLotAl.Visible = false;
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
                foreach (Malzeme item in malzemes)
                {
                    if (CmbStokNo.Text == item.StokNo)
                    {
                        CmbTanim.Text = item.Tanim;
                    }
                }
            }
        }

        private void BtnLotAl_Click(object sender, EventArgs e)
        {
            if (CmbStokNo.Text=="")
            {
                MessageBox.Show("Lütfen öncelikle Stok No bilgisini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CmbTanim.Text=="")
            {
                MessageBox.Show("Lütfen öncelikle Tanım bilgisini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TxtSeriNo.Text = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH");
        }

        private void CmbTanim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (start == true)
            {
                return;
            }
            comboId = CmbTanim.SelectedValue.ConInt();
            stokNo = CmbStokNo.Text;
            Malzeme malzemeKayit = malzemeManager.Get(stokNo);
            if (malzemeKayit == null)
            {
                CmbStokNo.Text = "";
                return;
            }
            CmbStokNo.Text = malzemeKayit.StokNo;
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
                foreach (Malzeme item in malzemes2)
                {
                    if (CmbTanim.Text == item.Tanim)
                    {
                        CmbStokNo.Text = item.StokNo;
                    }
                }
            }
        }
        List<Image> images = new List<Image>();
        private void BtnListeyeEkle_Click(object sender, EventArgs e)
        {
            if (PctBarcode.Image != null)
            {
                for (int i = 0; i < TxtMiktar.Text.ConInt(); i++)
                {
                    try
                    {
                        Barkod controlListKayitsiz = new Barkod(id, CmbStokNo.Text, CmbTanim.Text, TxtSeriNo.Text, TxtRevizyon.Text, infos[1].ToString(), DateTime.Now, kayitDurumu, infos[1].ToString());
                        barkodList.Add(controlListKayitsiz);
                        firstClick = true;

                        DataGridViewImageColumn dgvImageColumn = new DataGridViewImageColumn();
                        dgvImageColumn.HeaderText = "Barkod";
                        dgvImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

                        //DtgYedekParca.Rows.Add(dgvImageColumn);
                        DtgYedekParca.Rows.Add(PctBarcode.Image);

                        images.Add(PctBarcode.Image);

                    }
                    catch (Exception)
                    {
                        return;
                    }

                    LblMiktar.Text = DtgYedekParca.RowCount.ToString();
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
