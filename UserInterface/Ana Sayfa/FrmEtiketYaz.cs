using DataAccess.Concreate;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmEtiketYaz : Form
    {
        public FrmEtiketYaz()
        {
            InitializeComponent();
        }

        private void FrmEtiketYaz_Load(object sender, EventArgs e)
        {

        }
        void EtiketYaz()
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < TxtMiktar.Text.ConInt(); i++)
                {
                    printDocument1.Print();
                }
                
            }

            //PrintDocument output = new PrintDocument();
            //output.DocumentName = TxtEtiket.Text;

            //PrinterSettings ps = new PrinterSettings();

            //PrintDocument printDoc = new PrintDocument
            //{
            //    PrinterSettings = ps
            //};

            //printDoc.DefaultPageSettings.PaperSize = new PaperSize("Custom", 150, 130);
            //printDoc.PrintPage += PrintPage;
            //printDoc.Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(TxtEtiket.Text, this.Font, Brushes.Black, ClientRectangle, sf);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            EtiketYaz();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(TxtEtiket.Text, new Font("Times New Romans", TxtYaziBoyut.Text.ConInt(), FontStyle.Bold), Brushes.Black, new PointF(1, 10));
        }
    }
}
