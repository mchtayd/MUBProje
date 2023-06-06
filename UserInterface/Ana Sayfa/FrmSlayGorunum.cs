using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmSlayGorunum : Form
    {
        List<string> list = new List<string>();
        public FrmSlayGorunum()
        {
            InitializeComponent();
        }

        private void FrmSlayGorunum_Load(object sender, EventArgs e)
        {

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("20 sn içerisinde slayt başlayacaktır.Lütfen bekleyiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timer1.Start();

        }
        string Control()
        {
            if (ChkAmbar.Checked==true)
            {
                return "OK";
            }
            if (ChkAtolye.Checked == true)
            {
                return "OK";
            }
            if (ChkAcikAriza.Checked==true)
            {
                return "OK";
            }
            if (ChkAltYuk.Checked==true)
            {
                return "OK";
            }
            if (ChkBolumBazliAcik.Checked == true)
            {
                return "OK";
            }
            if (ChkBolgeBazli.Checked==true)
            {
                return "OK";
            }
            if (ChkAcikArizaSure.Checked==true)
            {
                return "OK";
            }
            if (ChkArizaSure.Checked==true)
            {
                return "OK";
            }
            return "Lütfen bir sayfa seçiniz!";
        }

        private void FrmSlayGorunum_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
        int step = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tabPanel.Visible = true;

            FrmIslemAdimlariGrafik frmIslemAdimlariGrafik = new FrmIslemAdimlariGrafik();
            FrmIzlemeSure frmIzlemeSure = new FrmIzlemeSure();
            FrmSektorIslemAdimlari frmSektorIslemAdimlari = new FrmSektorIslemAdimlari();
            FrmAcikArizaGrafikleri frmAcikArizaGrafikleri = new FrmAcikArizaGrafikleri();
            FrmAltYukIzleme frmAltYukIzleme = new FrmAltYukIzleme();
            FrmSahaIzleme frmSahaIzleme = new FrmSahaIzleme();

            if (step == 5)
            {
                frmIzlemeSure.timer1.Stop();
                frmIzlemeSure.TimerSaat.Stop();
                frmIzlemeSure.Close();
                step++;
                OpenPage(frmIslemAdimlariGrafik);
            }

            if (step == 4)
            {
                frmSektorIslemAdimlari.timer1.Stop();
                frmSektorIslemAdimlari.Close();
                step++;
                OpenPage(frmIzlemeSure);

            }

            if (step == 3)
            {
                frmAcikArizaGrafikleri.timer1.Stop();
                frmAcikArizaGrafikleri.TimerSaat.Stop();
                frmAcikArizaGrafikleri.Close();
                step++;
                OpenPage(frmSektorIslemAdimlari);
            }

            if (step == 2)
            {
                frmAltYukIzleme.timer1.Stop();
                frmAltYukIzleme.TimerSaat.Stop();
                frmAltYukIzleme.Close();
                step++;
                OpenPage(frmAcikArizaGrafikleri);
            }

            if (step == 1)
            {
                frmSahaIzleme.timer1.Stop();
                frmSahaIzleme.TimerSaat.Stop();
                frmSahaIzleme.Close();
                step++;
                OpenPage(frmAltYukIzleme);
            }

            if (step == 0 || step == 6)
            {
                if (step==6)
                {
                    frmIslemAdimlariGrafik.timer1.Stop();
                    frmIslemAdimlariGrafik.TimerSaat.Stop();
                    frmIslemAdimlariGrafik.Close();
                }
                step = 1;
                OpenPage(frmSahaIzleme);
            }

        }

        void OpenPage(Form form)
        {
            tabPanel.Controls.Clear();
            form.TopLevel = false;
            tabPanel.Controls.Add(form);
            form.Show();
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.FormBorderStyle = FormBorderStyle.None;
        }

        private void ChkAmbar_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
