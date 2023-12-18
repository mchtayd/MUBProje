using Business;
using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using DocumentFormat.OpenXml.Presentation;
using Entity;
using Entity.AnaSayfa;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;
using Path = System.IO.Path;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmBildirimler : Form
    {
        public object[] infos;
        LogManager logManager;
        BildirimYetkiManager bildirimYetkiManager;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        GorevAtamaManager gorevAtamaManager;
        DuyuruManager duyuruManager;
        VersionManager versionManager;
        PersonelKayitManager personelKayitManager;
        
        List<GorevAtama> gorevAtamaListYonetici;
        List<GorevAtamaPersonel> arizaGorevAtamaPersonels;
        List<GorevAtamaPersonel> gorevAtamaPersonels;
        List<GorevAtamaPersonel> arizaGorevAtamaAtolyePersonels;
        List<GorevAtamaPersonel> satinAlmaGorevs;
        List<GorevAtamaPersonel> mifGorevs;
        List<Duyuru> duyurus;

        string dosyaYolu = @"Z:\DTS\info\ou\notification.txt";
        public string version = "";
        public FrmBildirimler()
        {
            InitializeComponent();
            logManager = LogManager.GetInstance();
            bildirimYetkiManager = BildirimYetkiManager.GetInstance();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            gorevAtamaManager = GorevAtamaManager.GetInstance();
            duyuruManager = DuyuruManager.GetInstance();
            versionManager = VersionManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();

            //StartPosition = FormStartPosition.Manual;
            //Rectangle screen = Screen.FromPoint(Cursor.Position).WorkingArea;
            //int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            //int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            //Location = new Point(screen.Left + (screen.Width - w) / 2, screen.Top + (screen.Height - h) / 2);
            //Size = new Size(w, h);

        }

        private void FrmBildirimler_Load(object sender, EventArgs e)
        {
            //await Task.Run(() => Gorevler());
            //await Task.Run(() => DuyuruEditList());
            //await Task.Run(() => BolumGorevlerim());

            Gorevler();
            DuyuruEditList();
            BolumGorevlerim();

            //DuyuruEditList();
            timer2.Start();
            timer1.Start();
            //BildirimDosyasiCreate();

            // DosyaControl();
            //TimerFileRead.Start();
        }
        public void Gorevler()
        {
            arizaGorevAtamaPersonels = gorevAtamaPersonelManager.IsAkisGorevlerimBakimOnarim(infos[1].ToString());
            arizaGorevAtamaAtolyePersonels = gorevAtamaPersonelManager.IsAkisGorevlerimAtolye(infos[1].ToString());
            foreach (GorevAtamaPersonel item in arizaGorevAtamaAtolyePersonels)
            {
                arizaGorevAtamaPersonels.Add(item);
            }

            gorevAtamaPersonels = gorevAtamaPersonelManager.IsAkisGorevlerimIzin(infos[1].ToString());
            satinAlmaGorevs = gorevAtamaPersonelManager.IsAkisGorevlerimSatinAlma(infos[1].ToString());

            foreach (GorevAtamaPersonel item in satinAlmaGorevs)
            {
                gorevAtamaPersonels.Add(item);
            }

            mifGorevs = gorevAtamaPersonelManager.IsAkisGorevlerimMif(infos[1].ToString());

            foreach (GorevAtamaPersonel item in mifGorevs)
            {
                gorevAtamaPersonels.Add(item);
            }

            gorevAtamaListYonetici = gorevAtamaManager.GetListGorevlerim(infos[1].ToString());


            //LblAcikArizaGorevleri.Invoke((MethodInvoker)(() => LblAcikArizaGorevleri.Text = arizaGorevAtamaPersonels.Count.ToString()));
            //LbYoneticiGorevleri.Invoke((MethodInvoker)(() => LbYoneticiGorevleri.Text = gorevAtamaListYonetici.Count.ToString()));
            //LbYoneticiGorevleri.Invoke((MethodInvoker)(() => LblIsAkisGorevleri.Text = gorevAtamaPersonels.Count.ToString()));

            LblAcikArizaGorevleri.Text = arizaGorevAtamaPersonels.Count.ToString();
            LbYoneticiGorevleri.Text = gorevAtamaListYonetici.Count.ToString();
            LblIsAkisGorevleri.Text = gorevAtamaPersonels.Count.ToString();

            //await Task.Run(() => BolumGorevlerim());

        }
        void BolumGorevlerim()
        {
            List<string> personeller = new List<string>();
            List<PersonelKayit> personelKayits = new List<PersonelKayit>();
            List<GorevAtamaPersonel> genelList = new List<GorevAtamaPersonel>();
            List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
            List<GorevAtamaPersonel> IsAkisgorevAtamaPersonels = new List<GorevAtamaPersonel>();
            List<GorevAtamaPersonel> IsAkisgorevAtamaSatinAlma = new List<GorevAtamaPersonel>();
            List<GorevAtama> yoneticiGorevleri = new List<GorevAtama>();
            List<GorevAtamaPersonel> mifPersonels = new List<GorevAtamaPersonel>();
            List<GorevAtamaPersonel> arizaGorevAtamaAtolyePersonels = new List<GorevAtamaPersonel>();
            //MUB Prj.Dir./Loj.Dest.ve Pln./Veri Kayıt

            string[] bolum = infos[2].ToString().Split('/');
            if (bolum.Count() >= 2)
            {
                if (bolum[1].ToString()== "MÜB Proje Direktörlüğü")
                {
                    //personeller = gorevAtamaPersonelManager.BolumeBagliPersoneller("MUB Prj.Dir.");
                    personeller = gorevAtamaPersonelManager.BolumeBagliPersoneller("MÜB Proje Direktörlüğü");
                }
                else
                {
                    personeller = gorevAtamaPersonelManager.BolumeBagliPersoneller(bolum[1].ToString());
                }
                
            }
            else
            {
                if (infos[11].ToString()!="MİSAFİR")
                {
                    personeller = gorevAtamaPersonelManager.BolumeBagliPersoneller(bolum[0].ToString());
                }
            }

            foreach (string item in personeller)
            {
                gorevAtamaPersonels = gorevAtamaPersonelManager.IsAkisGorevlerimBakimOnarim(item);
                arizaGorevAtamaAtolyePersonels = gorevAtamaPersonelManager.IsAkisGorevlerimAtolye(item);
                foreach (GorevAtamaPersonel gorevAtamaPersonel in arizaGorevAtamaAtolyePersonels)
                {
                    gorevAtamaPersonels.Add(gorevAtamaPersonel);
                }

                IsAkisgorevAtamaPersonels = gorevAtamaPersonelManager.IsAkisGorevlerimIzin(item);
                IsAkisgorevAtamaSatinAlma = gorevAtamaPersonelManager.IsAkisGorevlerimSatinAlma(item);
                mifPersonels = gorevAtamaPersonelManager.IsAkisGorevlerimMif(item);

                foreach (GorevAtamaPersonel item2 in IsAkisgorevAtamaSatinAlma)
                {
                    IsAkisgorevAtamaPersonels.Add(item2);
                }

                foreach (GorevAtamaPersonel item3 in mifPersonels)
                {
                    IsAkisgorevAtamaPersonels.Add(item3);
                }

                foreach (GorevAtamaPersonel item4 in IsAkisgorevAtamaPersonels)
                {
                    gorevAtamaPersonels.Add(item4);
                }

                foreach (GorevAtamaPersonel item5 in gorevAtamaPersonels)
                {
                    genelList.Add(item5);
                }
            }

            //LbYoneticiGorevleri.Invoke((MethodInvoker)(() => LblBolumGorev.Text = genelList.Count.ToString()));
            LblBolumGorev.Text = genelList.Count.ToString();

        }


        public void DuyuruEditList()
        {
            Gorevler();
            BolumGorevlerim();
            duyurus = duyuruManager.GetList();

            if (duyurus.Count==0)
            {
                return;
            }

            StringBuilder strB = new StringBuilder();

            foreach (Duyuru item in duyurus)
            {
                strB.Append("<center><table border='2'  style='background-color:azure;color:black;'>");
                strB.Append("<td width='1300px'><h4 style='color:darkred;height:15px;'>" + item.Konu + "</h4>");

                strB.Append(item.DuyuruMesaj + "<br><br><span style='font-size=11px;'>" + item.DuyuruYapan.ToString() + "<br>" + 
                    "(" + item.BaslangicTarih.ToString("g") + ")" + "</span></td>");
                strB.Append("</table></center><br/>");

                //strB.Append("<center><table border='2' cellpadding='3' style='background:rgb(255, 255, 255);'>");
                //strB.Append("<td width='750px'><h3 class='headings'>" + item.Konu + "</h3>" + "<a href='#'>" + item.DuyuruMesaj + "</a>" + "<br>" + "(" + item.BaslangicTarih.ToString("f") + ")" + "<br>" + item.DuyuruYapan.ToString() + "</td>");
                //strB.Append("</table></center><br/>");

                //WebDuyuru.DocumentText = strB.ToString();
            }
            WebDuyuru.DocumentText = strB.ToString();
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
            notifyIcon1.Icon = new Icon(Path.GetFullPath("Bildirim.ico"));
            notifyIcon1.Text = "";
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "DTS";
            notifyIcon1.BalloonTipText = "Bildirim Denemesi";
            notifyIcon1.ShowBalloonTip(100);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string[] array = new string[4];

            array[0] = "Saha Bildirim Güncelleme"; // BAŞLIK
            array[1] = "Mücahit AYDEMİR 200015 Form numaralı Stine Tepe Üs Bölgesi DRAGONEYE B/O arızasını 700 FABRİKA BAKIM ONARIM adıma güncellenmiştir!"; // İÇERİK
            array[3] = "200015"; // BENZERSİZ_KIMLIK

            BildirimYetki bildirimYetki = bildirimYetkiManager.Get(infos[1].ToString());
            if (bildirimYetki == null)
            {
                array[2] = infos[0].ToString();

                FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
                frmAnaSayfa.LogYaz(array[0], array[1], array[2], array[3]);
                FrmHelper.Bildirim(array[0], "\n" + array[1], ımageList1.Images["okey.png"], infos[1].ToString(), array[2], array[3]);
            }
            else
            {
                string[] sorumluIdler = bildirimYetki.SorumluId.Split(';');
                for (int i = 0; i < sorumluIdler.Length; i++)
                {
                    FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
                    frmAnaSayfa.LogYaz(array[0], array[1], sorumluIdler[i], array[3]);
                }

                FrmHelper.Bildirim(array[0], "\n" + array[1], ımageList1.Images["okey.png"], infos[1].ToString(), infos[0].ToString(), array[3]);

            }


            //string[] array = new string[8];

            //array[0] = "Saha Bildirim Güncelleme"; // Bildirim Başlık
            //array[1] = "Mücahit AYDEMİR"; // Bildirim Sahibi Personel
            //array[2] = "200015"; // ABF, İŞ AKIŞ NO, iç sipaiş no, form no
            //array[3] = "Form numaralı"; // Bildirim türü
            //array[4] = "Stine Tepe Üs Bölgesi"; // İÇERİK
            //array[5] = "DRAGONEYE B/O arızasını";
            //array[6] = "700 FABRİKA BAKIM ONARIM adıma güncellenmiştir!";

            //BildirimYetki bildirimYetki = bildirimYetkiManager.Get(infos[1].ToString());
            //if (bildirimYetki == null)
            //{
            //    array[7] = infos[0].ToString();
            //    //array[7] = "25;26;27";
            //}
            //else
            //{
            //    array[7] = bildirimYetki.SorumluId + infos[0].ToString();
            //}

            //FrmHelper.BildirimGonder(array, array[7], "200015");

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            VersionBul();
        }
        void VersionBul()
        {
            List<VersionBilgi> versionBilgis = new List<VersionBilgi>();
            versionBilgis = versionManager.GetList();
            if (versionBilgis.Count == 0)
            {
                return;
            }
            string yeniversion = versionBilgis[0].VersionNo;
            string eskiversion = version;
            if (yeniversion != eskiversion)
            {
                LblVersion.Text = "Güncelle!";
                timer3.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (LblDuyuru.Visible == false)
            {
                LblDuyuru.Visible = true;
            }
            else
            {
                LblDuyuru.Visible = false;
            }
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (LblVersion.Visible == false)
            {
                LblVersion.Visible = true;
            }
            else
            {
                LblVersion.Visible = false;
            }

        }
    }

}
