using DataAccess.Concreate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using UserInterface.STS;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmBildirimler : Form
    {
        public FrmBildirimler()
        {
            InitializeComponent();
        }

        private void FrmBildirimler_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            this.Close();
            frmAnaSayfa.tabAnasayfa.TabPages.Remove(frmAnaSayfa.tabAnasayfa.TabPages["PageBildirimler"]);
            if (frmAnaSayfa.tabAnasayfa.TabPages.Count == 0)
            {
                frmAnaSayfa.tabAnasayfa.Visible = false;
            }
            else
            {
                frmAnaSayfa.tabAnasayfa.SelectedTab = frmAnaSayfa.tabAnasayfa.TabPages[frmAnaSayfa.tabAnasayfa.TabPages.Count - 1];
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath("Bildirim.ico"));
            notifyIcon1.Text = "";
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "DTS";
            notifyIcon1.BalloonTipText = "Bildirim Denemesi";
            notifyIcon1.ShowBalloonTip(100);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FrmHelper.Bildirim("DTS BİLGİ(Saha Bildirim Güncelleme)", "Mücahit AYDEMİR\n\n220546 Form numaralı Stine Tepe Üs Bölgesi \nDRAGONEYE B/O \n700 FABRİKA BAKIM ONARIM adıma güncellenmiştir!", ımageList1.Images["okey.png"]);

            //PopupNotifier popup = new PopupNotifier();

            //popup.Image = ımageList1.Images["okey.png"];
            //popup.Size = new Size(500, 150);
            //popup.BodyColor = Color.FromArgb(40, 167, 69);
            //string title = "DTS BİLGİ(Saha Bildirim Güncelleme)";
            //popup.TitleText = title;
            //popup.TitleColor = Color.White;
            //popup.TitleFont = new Font("Century Gothic", 15, FontStyle.Bold);
            ////string mesaj = "Mücahit AYDEMİR";

            //popup.ContentText = "Mücahit AYDEMİR\n\n220546 Form numaralı Stine Tepe Üs Bölgesi \nDRAGONEYE B/O \n700 FABRİKA BAKIM ONARIM adıma güncellenmiştir!";
            //popup.ContentColor = Color.White;
            //popup.ContentFont = new Font("Century Gothic", 12);
            //popup.Popup();

            //popup.Click += Popup_Click;

            //popup.Disappear += Popup_Disappear;

        }


        private void FrmBildirimler_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            frmAnaSayfa.PnlBildirim.Size = new Size(0, 0);
            frmAnaSayfa.tabAnasayfa.Size = new Size(1600, 955);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            frmAnaSayfa.PnlBildirim.Size = new Size(0, 0);
            frmAnaSayfa.tabAnasayfa.Size = new Size(1600, 955);
        }
    }

}
