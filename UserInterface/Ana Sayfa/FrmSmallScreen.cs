using DocumentFormat.OpenXml.EMMA;
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

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmSmallScreen : Form
    {
        public object[] infos;
        public FrmSmallScreen()
        {
            InitializeComponent();
        }

        private void FrmSmallScreen_Load(object sender, EventArgs e)
        {
            //FrmAnaSayfa Go = new FrmAnaSayfa();
            //Go.infos = infos;
            //Go.FormBorderStyle = FormBorderStyle.None;
            //Go.TopLevel = false;
            //Go.AutoScroll = true;
            //OpenTabPage("PageAnaSayfa", "Ana Sayfa", Go);
            //Go.Show();
        }
        public void OpenTabPage(string pageName, string pageText, Control winForm)
        {
            if (tabAnasayfa.TabPages[pageName] != null)
            {
                tabAnasayfa.SelectedTab = tabAnasayfa.TabPages[pageName];
                return;
            }
            tabAnasayfa.Visible = true;
            TabPage tabPage = new TabPage(pageText);
            //tabPage.SetBounds(tabPage.Bounds.X, tabPage.Bounds.Y, 500, tabPage.Bounds.Height);
            tabPage.Size = new Size(500, 75);
            tabAnasayfa.TabPages.Add(tabPage);
            tabPage.Name = pageName;
            //tabPage.Width = 500;
            tabPage.Controls.Add(winForm);
            tabAnasayfa.SelectedTab = tabAnasayfa.TabPages[pageName];
        }
    }
}
