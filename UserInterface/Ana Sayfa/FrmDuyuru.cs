using Business.Concreate.AnaSayfa;
using Entity.AnaSayfa;
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
using UserInterface.STS;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmDuyuru : Form
    {
        DuyuruManager duyuruManager;
        public object[] infos;
        public FrmDuyuru()
        {
            InitializeComponent();
            duyuruManager = DuyuruManager.GetInstance();
        }

        private void FrmDuyuru_Load(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinze emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                DateTime bitisTarihi = new DateTime(DtBitTarihi.Value.Year, DtBitTarihi.Value.Month, DtBitTarihi.Value.Day, DtBitSaat.Value.Hour, DtBitSaat.Value.Minute, DtBitSaat.Value.Second);

                Duyuru duyuru = new Duyuru(TxtKonu.Text, TxtMesaj.Text, DateTime.Now, bitisTarihi, "AKTİF", infos[1].ToString());
                string mesaj = duyuruManager.Add(duyuru);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmBildirimler frmBildirimler = (FrmBildirimler)Application.OpenForms["FrmBildirimler"];
                frmBildirimler.DuyuruEditList();

                TxtKonu.Clear();
                TxtMesaj.Clear();
                DtBitTarihi.Value = DateTime.Now;
                DtBitSaat.Text = "00:00";
            }


            //notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath("Bildirim.ico"));
            //notifyIcon1.Text = "";
            //notifyIcon1.Visible = true;
            //notifyIcon1.BalloonTipTitle = "DTS";
            //notifyIcon1.BalloonTipText = "Bildirim Denemesi";
            //notifyIcon1.ShowBalloonTip(100);
        }
    }
}
