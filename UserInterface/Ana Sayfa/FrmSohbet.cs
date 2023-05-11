using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmSohbet : Form
    {
        List<string> mesajlar = new List<string>();
        public FrmSohbet()
        {
            InitializeComponent();
        }

        private void FrmSohbet_Load(object sender, EventArgs e)
        {
            
        }

        private void FrmSohbet_FormClosing(object sender, FormClosingEventArgs e)
        {
            //int index = 0;
            //string baslik = this.Text;
            //FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            //foreach (DataGridViewRow item in frmAnaSayfa.DtgSohbet.Rows)
            //{
            //    if (item.Cells["Ad"].Value.ToString() == baslik)
            //    {
            //        frmAnaSayfa.DtgSohbet.Rows.RemoveAt(index);
            //        frmAnaSayfa.personelHesapsControl.RemoveAt(index);
            //    }
            //    index++;
            //}
        }
        
        private void BtnGonder_Click(object sender, EventArgs e)
        {
            if (TxtMesaj.Text=="")
            {
                return;
            }

            string sent = TxtMesaj.Text;
            mesajlar.Add(sent);
            StringBuilder strB = new StringBuilder();

            strB.Append("<center><table border='2' style='background-color:azure;color:black;'>");
            strB.Append("<td width='364px'>" + mesajlar[mesajlar.Count-1] + "<span style='font-size=11px;'>" + "<br><br>"
                     + DateTime.Now.ToString("t") + " " + "-" + "</span></td>");
            strB.Append("</table></center><br/>");

            MesajBrowser.DocumentText += strB.ToString();
            TxtMesaj.Clear();

            //TxtSohbet.AppendText(sent);
            //TxtSohbet.AppendText(Environment.NewLine);
            //TxtMesaj.Clear();
        }

        private void MesajBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            MesajBrowser.Document.Window.ScrollTo(0, MesajBrowser.Document.Body.ScrollRectangle.Height);
        }
    }
}
