using Business.Concreate;
using Entity.AnaSayfa;
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
        SohbetManager sohbetManager;
        List<string> mesajlar = new List<string>();
        List<Sohbet> sohbets = new List<Sohbet>();
        List<Sohbet> sohbetsler = new List<Sohbet>();

        public object[] infos;
        public string alan = "";
        public FrmSohbet()
        {
            InitializeComponent();
            sohbetManager = SohbetManager.GetInstance();
        }

        private void FrmSohbet_Load(object sender, EventArgs e)
        {
            //Mesajlar();
        }
        void Mesajlar()
        {
            sohbetsler = sohbetManager.GetListSohbetler(alan, infos[1].ToString());

            foreach (Sohbet item in sohbetsler)
            {

                if (item.SohbetDurum != "GÖRÜLDÜ")
                {
                    sohbetManager.UpdateGoruldu(item.Id);
                }

                if (item.Gonderen == infos[1].ToString())
                {
                    StringBuilder strB = new StringBuilder();

                    strB.Append("<center><table border='2' style='background-color:azure;color:black;'>");
                    strB.Append("<td width='364px'>" + item.Mesaj + "<span style='font-size=11px;'>" + "<br><br>"
                             + DateTime.Now.ToString("t") + " " + "✓✓" + "</span></td>");
                    strB.Append("</table></center><br/>");

                    MesajBrowser.DocumentText += strB.ToString();
                }
                else
                {
                    StringBuilder strB = new StringBuilder();

                    strB.Append("<center><table border='2' style='background-color:Coral;color:black;'>");
                    strB.Append("<td width='364px'>" + item.Mesaj + "<span style='font-size=11px;'>" + "<br><br>"
                             + DateTime.Now.ToString("t") + " " + "✓✓" + "</span></td>");
                    strB.Append("</table></center><br/>");

                    MesajBrowser.DocumentText += strB.ToString();
                }
            }

            TmMesajControl.Start();
        }
        private void FrmSohbet_FormClosing(object sender, FormClosingEventArgs e)
        {
            TmMesajControl.Stop();
        }
        
        private void BtnGonder_Click(object sender, EventArgs e)
        {
            if (TxtMesaj.Text=="")
            {
                return;
            }
            string sent = TxtMesaj.Text;

            //Sohbet sohbet = new Sohbet(infos[1].ToString(), alan, DateTime.Now, sent);
            //sohbetManager.Add(sohbet);

            StringBuilder strB = new StringBuilder();

            strB.Append("<center><table border='2' style='background-color:azure;color:black;'>");
            strB.Append("<td width='364px'>" + sent + "<span style='font-size=11px;'>" + "<br><br>"
                     + DateTime.Now.ToString("t") + " " + "✓" + "</span></td>");
            strB.Append("</table></center><br/>");

            MesajBrowser.DocumentText += strB.ToString();
            TxtMesaj.Clear();




            //string sent = TxtMesaj.Text;
            //mesajlar.Add(sent);
            //StringBuilder strB = new StringBuilder();

            //strB.Append("<center><table border='2' style='background-color:azure;color:black;'>");
            //strB.Append("<td width='364px'>" + mesajlar[mesajlar.Count-1] + "<span style='font-size=11px;'>" + "<br><br>"
            //         + DateTime.Now.ToString("t") + " " + "✓" + "</span></td>");
            //strB.Append("</table></center><br/>");


            //MesajBrowser.DocumentText += strB.ToString();
            //TxtMesaj.Clear();

            //TxtSohbet.AppendText(sent);
            //TxtSohbet.AppendText(Environment.NewLine);
            //TxtMesaj.Clear();
        }

        private void MesajBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            MesajBrowser.Document.Window.ScrollTo(0, MesajBrowser.Document.Body.ScrollRectangle.Height);
        }

        private void TmMesajControl_Tick(object sender, EventArgs e)
        {
            //sohbets.Clear();
            //sohbets = sohbetManager.GetList(infos[1].ToString(), alan); // hiç görülmemiş mesajlar
            //if (sohbets.Count==0)
            //{
            //    return;
            //}

            //foreach (Sohbet item in sohbets)
            //{

            //    if (item.Gonderen == infos[1].ToString())
            //    {
            //        StringBuilder strB = new StringBuilder();

            //        strB.Append("<center><table border='2' style='background-color:azure;color:black;'>");
            //        strB.Append("<td width='364px'>" + item.Mesaj + "<span style='font-size=11px;'>" + "<br><br>"
            //                 + DateTime.Now.ToString("t") + " " + "✓✓" + "</span></td>");
            //        strB.Append("</table></center><br/>");

            //        MesajBrowser.DocumentText += strB.ToString();

            //        sohbetManager.UpdateGoruldu(item.Id);
            //    }
            //    else
            //    {
            //        StringBuilder strB = new StringBuilder();

            //        strB.Append("<center><table border='2' style='background-color:Coral;color:black;'>");
            //        strB.Append("<td width='364px'>" + item.Mesaj + "<span style='font-size=11px;'>" + "<br><br>"
            //                 + DateTime.Now.ToString("t") + " " + "✓✓" + "</span></td>");
            //        strB.Append("</table></center><br/>");

            //        MesajBrowser.DocumentText += strB.ToString();

            //        sohbetManager.UpdateGoruldu(item.Id);
            //    }
                
            //}


        }
    }
}
