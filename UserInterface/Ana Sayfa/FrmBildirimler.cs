﻿using Business.Concreate.AnaSayfa;
using DataAccess.Concreate;
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
using Tulpep.NotificationWindow;
using UserInterface.STS;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmBildirimler : Form
    {
        public object[] infos;
        LogManager logManager;
        BildirimYetkiManager bildirimYetkiManager;

        string dosyaYolu = @"Z:\DTS\info\ou\notification.txt";
        public FrmBildirimler()
        {
            InitializeComponent();
            logManager = LogManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
        }

        private void FrmBildirimler_Load(object sender, EventArgs e)
        {
            BildirimDosyasiCreate();
            // DosyaControl();
            //TimerFileRead.Start();
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
        void BildirimDosyasiCreate()
        {
            if (File.Exists(dosyaYolu))
            {
                string kaynak = @"Z:\DTS\info\ou\";
                string yol = @"C:\DTS\Bildirim\";
                string taslakYolu = "";
                {
                    string root = @"C:\DTS";

                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    if (!Directory.Exists(yol))
                    {
                        Directory.CreateDirectory(yol);
                    }

                    taslakYolu = yol + "notification.txt";

                    if (!File.Exists(taslakYolu))
                    {
                        File.Copy(kaynak + "notification.txt", taslakYolu);
                    }
                }
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
            string[] array = new string[8];

            array[0] = "Saha Bildirim Güncelleme"; // Bildirim Başlık
            array[1] = "Mücahit AYDEMİR"; // Bildirim Sahibi Personel
            array[2] = "220546"; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "Form numaralı"; // Bildirim türü
            array[4] = "Stine Tepe Üs Bölgesi"; // İÇERİK
            array[5] = "DRAGONEYE B/O arızasını";
            array[6] = "700 FABRİKA BAKIM ONARIM adıma güncellenmiştir!";

            BildirimYetki bildirimYetki = bildirimYetkiManager.Get(infos[1].ToString());
            if (bildirimYetki == null)
            {
                array[7] = infos[0].ToString();
            }
            else
            {
                array[7] = bildirimYetki.SorumluId + infos[0].ToString();
            }

            FrmHelper.BildirimGonder(array, array[7]);

            #region EskiKod
            /*
            bool control = false;
            if (Directory.Exists(dosyaYolu))
            {
                MessageBox.Show("Bildirim okuma dosyası bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] array = new string[8];

            array[0] = "Saha Bildirim Güncelleme"; // Bildirim Başlık
            array[1] = "Mücahit AYDEMİR"; // Bildirim Sahibi Personel
            array[2] = "220546"; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            array[3] = "Form numaralı"; // Bildirim türü
            array[4] = "Stine Tepe Üs Bölgesi"; // İÇERİK
            array[5] = "DRAGONEYE B/O arızasını";
            array[6] = "700 FABRİKA BAKIM ONARIM adıma güncellenmiştir!";

            BildirimYetki bildirimYetki = bildirimYetkiManager.Get(infos[1].ToString());
            if (bildirimYetki == null)
            {
                array[7] = infos[0].ToString();
            }
            else
            {
                array[7] = bildirimYetki.SorumluId + infos[0].ToString();
            }

            string txtMetin = array[0] + " " + array[1] + " " + array[2] + " " + array[3] + " " + array[4] + " " + array[5] + " " + array[6] + " " + array[7];
            string bildirimMetin = array[1] + " " + array[2] + " " + array[3] + "\n" + array[4] + "\n" + array[5] + "\n" + array[6];

            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];

            string icerik = File.ReadAllText(dosyaYolu);
            string[] array2 = icerik.Split('\n');
            for (int i = 0; i < array2.Length; i++)
            {
                string metin = array2[i].ToString().Trim();
                if (metin != txtMetin)
                {
                    if (array2.Length==1)
                    {
                        control = true;
                    }
                    else
                    {
                        if (metin!="")
                        {
                            control = true;
                        }
                        else
                        {
                            control = false;
                        }
                    }
                    
                }
                if (control==true)
                {
                    FrmHelper.TxtBildirimEdit(txtMetin);
                    StreamWriter streamWriter = new StreamWriter(dosyaYolu, true);
                    streamWriter.WriteLine(txtMetin);
                    streamWriter.Close();

                    Log log = new Log(array[0], bildirimMetin, DateTime.Now, infos[1].ToString(), array[array.Length - 1]);
                    string mesaj = logManager.Add(log);

                    if (mesaj != "OK")
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    frmAnaSayfa.DosyaControl();
                }
            }

            control = false;


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

            */
            #endregion
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
