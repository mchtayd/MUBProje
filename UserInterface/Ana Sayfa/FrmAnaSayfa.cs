using Business;
using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using Business.Concreate.STS;
using DataAccess.Concreate;
using DataAccess.Concreate.IdariIsler;
using Entity;
using Entity.AnaSayfa;
using Entity.IdariIsler;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.BakımOnarım;
using UserInterface.Butce;
using UserInterface.Depo;
using UserInterface.DokumanYonetim;
using UserInterface.Egitim;
using UserInterface.EgitimDok;
using UserInterface.Gecic_Kabul_Ambar;
using UserInterface.IdariIşler;
using UserInterface.IdariIsler;
using UserInterface.RAPORLAMALAR;
using UserInterface.Yerleskeler;
using System.Diagnostics;
using DocumentFormat.OpenXml.Drawing.Charts;
using Size = System.Drawing.Size;

namespace UserInterface.STS
{
    public partial class FrmAnaSayfa : Form
    {
        SatinAlinacakMalManager satinAlinacakMalManager;
        SatDataGridview1Manager satDataGridview1Manager;
        DvNoManager dvNoManager;
        VersionManager versionManager;
        TamamlananManager tamamlananManager;
        MenuManager menuManager;
        PersonelHesapManager personelHesapManager;
        LogManager logManager;
        SohbetManager sohbetManager;
        PersonelKayitManager personelKayitManager;

        FrmWait frmWait = new FrmWait();
        List<MenuBaslik> menuBasliks;
        List<MenuBaslik> menuBasliksFilter;
        List<MenuBaslik> menuBasliksVeriGiris = new List<MenuBaslik>();
        List<MenuBaslik> menuBasliksVeriIzleme = new List<MenuBaslik>();
        List<MenuBaslik> menuBasliks2 = new List<MenuBaslik>();
        List<MenuBaslik> menuBasliks3 = new List<MenuBaslik>();
        List<MenuBaslik> menuBasliks4 = new List<MenuBaslik>();
        List<PersonelHesap> personelHesaps;
        public object[] infos;
        public object[] infos1;
        int control = 0;
        int atla = 0, atladal = 0, personId, authId;
        string izinIdleri, yetkiModu;

        int index = 0;
        int indexAlt = 0;

        public FrmAnaSayfa()
        {
            InitializeComponent();
            satinAlinacakMalManager = SatinAlinacakMalManager.GetInstance();
            versionManager = VersionManager.GetInstance();
            dvNoManager = DvNoManager.GetInstance();
            tamamlananManager = TamamlananManager.GetInstance();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            menuManager = MenuManager.GetInstance();
            personelHesapManager = PersonelHesapManager.GetInstance();
            logManager = LogManager.GetInstance();
            sohbetManager = SohbetManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();
            SystemEvents.PowerModeChanged += PowerModeChanged;
        }
        
        private void PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            // GÜÇ DEĞİŞİKLİĞİ
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            /*treeView1.Nodes[0].EnsureVisible();
            treeView1.ImageList = ımageList1;*/

            tabAnasayfa.Visible = false;
            FillInfos();
            //LblTarih.Text = DateTime.Now;
            LblTarih.Text = DateTime.Now.ToLongDateString();
            TimerSaat.Start();
            personId = infos[0].ConInt();
            authId = infos[5].ConInt();
            izinIdleri = infos[6].ToString();
            yetkiModu = infos[11].ToString();
            LblYetki.Text = yetkiModu;
            if (personId == 25)
            {
                VersionEkle.Visible = true;
                button3.Visible = false;
                BtnDosyaKitle.Visible = false;
            }
            PersonelDurumAktif();
            timerOnline.Start();
            PersonelAktif();
            Basliklar(authId);
            Admin();
            ControlNodes(authId);
            button1.Image = imageList.Images["kucultme.png"];
            LblVersionNo.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            VersionBul();
            if (yetkiModu == "KULLANICI")
            {
                sayfalar.Visible = false;
            }
            string deneme, foto = "";
            PersonelKayit personelKayit = personelKayitManager.Get(personId);
            deneme = "\\" + infos[1].ToString() + ".jpg";
            foto = personelKayit.Fotoyolu;
            PcFoto.ImageLocation = foto + deneme;

            PanelEditClear();
            //bildirim paneli kapalı
            //PnlBildirim.Size = new Size(0,0);
            //tabAnasayfa.Size = new Size(1600, 955);

            FrmBildirimler Go = new FrmBildirimler();
            Go.infos = infos;
            Go.version = LblVersionNo.Text;
            Go.FormBorderStyle = FormBorderStyle.None;
            Go.TopLevel = false;
            Go.AutoScroll = true;
            OpenTabPage("PageBildirimler", "KONTROL", Go);
            Go.Show();

            BildirimControl(infos[0].ConInt());
            TimerFileRead.Start();
            ServerAyarlar();
            //MesajControl();
            //TmMesajControl.Start();



        }
        void ServerAyarlar()
        {
            FrmServer frmServer = new FrmServer();
            frmServer.infos = infos;
            frmServer.AyarControl();
        }

        DateTime giris = DateTime.Now;
        public void PersonelDurumAktif()
        {
            string mesaj = personelHesapManager.Update(personId, "ÇEVRİM İÇİ", giris);
            if (mesaj!="OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
        public void PersonelDurumPasif()
        {
            DateTime cikis= DateTime.Now;
            TimeSpan toplamSure = cikis - giris;
            string mesaj = personelHesapManager.UpdatePasif(personId, "ÇEVRİM DIŞI", cikis, toplamSure.Minutes.ConInt());
            if (mesaj != "OK")
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }
        List<PersonelHesap> personelHesapsGenel = new List<PersonelHesap>();
        public void PersonelAktif()
        {
            personelHesaps = new List<PersonelHesap>();
            DtgPersonelList.Rows.Clear();
            DateTime cikis = DateTime.Now;
            TimeSpan toplamSure = cikis - giris;
            string mesaj = personelHesapManager.UpdateSonGorulme(personId, DateTime.Now, toplamSure.Minutes.ConInt());
            if (mesaj!="OK")
            {
                kapatBilgisi = false;
                Application.Exit();
            }

            personelHesaps = personelHesapManager.GetList();
            personelHesapsGenel = personelHesaps;
            foreach (PersonelHesap item in personelHesaps)
            {
                if (item.AdSoyad != "MEHMET ŞENOL")
                {
                    DtgPersonelList.Rows.Add();
                    int sonSatir = DtgPersonelList.RowCount - 1;

                    DtgPersonelList.Rows[sonSatir].Cells["PersonelAd"].Value = item.AdSoyad;
                    if (item.Durum == "ÇEVRİM İÇİ")
                    {
                        DtgPersonelList.Rows[sonSatir].Cells["Durum"].Value = ImagesLogin.Images[0]; // YEŞİL
                    }
                    else
                    {
                        DtgPersonelList.Rows[sonSatir].Cells["Durum"].Value = ImagesLogin.Images[1]; // KIRMIZI
                    }
                }

            }

        }

        void Basliklar(int authId)
        {

            string[] array = izinIdleri.Split(';');

            int sayac = 0;
            int donguDeger = array.Length;

            menuBasliks = new List<MenuBaslik>();
            menuBasliksFilter = new List<MenuBaslik>();
            menuBasliks = menuManager.GetList();


            foreach (MenuBaslik item in menuBasliks)
            {
                if (donguDeger == sayac)
                {
                    break;
                }
                if (array[sayac].ConInt() == item.Id)
                {
                    menuBasliksFilter.Add(item);
                    sayac++;
                }

            }

            menuBasliks = menuBasliksFilter;


            menuBasliksVeriGiris.Clear();
            menuBasliksVeriIzleme.Clear();
            menuBasliks2.Clear();
            menuBasliks3.Clear();
            menuBasliks4.Clear();

            int id = 0;
            foreach (MenuBaslik item in menuBasliks)
            {
                if (item.BaslikId == 0)
                {
                    TreeMenu.Nodes.Add(item.Baslik);
                    id = item.Id;
                }
                else
                {
                    if (id == item.BaslikId)
                    {
                        if (id == 1)
                        {
                            menuBasliksVeriGiris.Add(item);
                        }
                        else
                        {
                            menuBasliksVeriIzleme.Add(item);
                        }
                    }
                }

            }

            index = 0;
            indexAlt = 0;
            sayac = 0;

            foreach (MenuBaslik item in menuBasliksVeriGiris)
            {
                TreeMenu.Nodes[0].Nodes.Add(item.Baslik);
                TreeMenu.Nodes[0].BackColor = Color.CadetBlue;
                menuBasliks2 = menuManager.GetListAlt(item.Id);
                List<MenuBaslik> menuBasliks = new List<MenuBaslik>();

                for (int i = 0; i < menuBasliks2.Count(); i++)
                {
                    sayac = 0;
                    foreach (var dizi in array)
                    {
                        if (sayac == donguDeger)
                        {
                            break;
                        }
                        if (array[sayac].ConInt() == menuBasliks2[i].Id)
                        {
                            menuBasliks.Add(menuBasliks2[i]);
                        }
                        sayac++;
                    }
                }

                menuBasliks2.Clear();
                menuBasliks2 = menuBasliks;

                menuBasliks = new List<MenuBaslik>();

                foreach (MenuBaslik item2 in menuBasliks2)
                {
                    TreeMenu.Nodes[0].Nodes[index].Nodes.Add(item2.Baslik);
                    menuBasliks4 = menuManager.GetListAlt(item2.Id);
                    int dongu = menuBasliks4.Count();
                    if (menuBasliks4.Count != 0)
                    {
                        for (int i = 0; i < dongu; i++)
                        {
                            sayac = 0;

                            foreach (var dizi in array)
                            {
                                if (sayac == donguDeger)
                                {
                                    break;
                                }
                                if (array[sayac].ConInt() == menuBasliks4[i].Id)
                                {
                                    menuBasliks.Add(menuBasliks4[i]);
                                }
                                sayac++;
                            }

                        }

                        int ind = TreeMenu.Nodes[0].Nodes[index].Nodes.Count.ConInt() - 1;
                        foreach (MenuBaslik item3 in menuBasliks)
                        {
                            TreeMenu.Nodes[0].Nodes[index].Nodes[ind].Nodes.Add(item3.Baslik);
                        }
                        menuBasliks.Clear();
                    }
                }
                index++;

            }


            index = 0;
            indexAlt = 0;
            sayac = 0;

            foreach (MenuBaslik item in menuBasliksVeriIzleme)
            {
                TreeMenu.Nodes[1].Nodes.Add(item.Baslik);
                TreeMenu.Nodes[1].BackColor = Color.CadetBlue;
                menuBasliks3 = menuManager.GetListAlt(item.Id);

                List<MenuBaslik> menuBasliks = new List<MenuBaslik>();

                for (int i = 0; i < menuBasliks3.Count(); i++)
                {
                    sayac = 0;

                    foreach (var dizi in array)
                    {
                        if (sayac == donguDeger)
                        {
                            break;
                        }
                        if (array[sayac].ConInt() == menuBasliks3[i].Id)
                        {
                            menuBasliks.Add(menuBasliks3[i]);
                        }
                        sayac++;
                    }

                }

                menuBasliks3.Clear();
                menuBasliks3 = menuBasliks;
                menuBasliks = new List<MenuBaslik>();

                foreach (MenuBaslik item2 in menuBasliks3)
                {
                    TreeMenu.Nodes[1].Nodes[index].Nodes.Add(item2.Baslik);
                    menuBasliks4 = menuManager.GetListAlt(item2.Id);
                    int dongu = menuBasliks4.Count();

                    if (menuBasliks4.Count != 0)
                    {
                        for (int i = 0; i < dongu; i++)
                        {
                            sayac = 0;
                            foreach (var dizi in array)
                            {
                                if (sayac == donguDeger)
                                {
                                    break;
                                }
                                if (array[sayac].ConInt() == menuBasliks4[i].Id)
                                {
                                    menuBasliks.Add(menuBasliks4[i]);
                                }
                                sayac++;
                            }
                        }

                        int ind = TreeMenu.Nodes[1].Nodes[index].Nodes.Count.ConInt() - 1;
                        foreach (MenuBaslik item3 in menuBasliks)
                        {
                            TreeMenu.Nodes[1].Nodes[index].Nodes[ind].Nodes.Add(item3.Baslik);
                        }
                        menuBasliks.Clear();
                    }
                }
                index++;

            }

        }
        public void ToplamSayilar()
        {
            //tamamlananSatlar = tamamlananManager.GetList(0).Count;
            //treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI IZLEME"].Nodes["Tamamlanan Sat"].Text = "Tamamlanan SAT " + "(" + tamamlananSatlar + ")";
            //devamEdenSatlar = satDataGridview1Manager.List().Count;
            //treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI IZLEME"].Nodes["devamedensat"].Text = "Devam Eden SAT " + "(" + devamEdenSatlar + ")";
            //reddedilenSatlar = satDataGridview1Manager.GetList("Reddedildi").Count;
            //treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI IZLEME"].Nodes["RedEdilenSat"].Text = "Ret Edilen SAT " + "(" + reddedilenSatlar + ")";
        }
        private void FrmAnaSayfa_Shown(object sender, EventArgs e)
        {
            //if (personId == 84 || personId == 25)
            //{
            //    FrmDevam frmDevam = new FrmDevam();
            //    frmDevam.FormBorderStyle = FormBorderStyle.None;
            //    frmDevam.TopLevel = false;
            //    frmDevam.AutoScroll = true;
            //    OpenTabPage("PageDevam", "DEVAM/DEVAMSIZLIK", frmDevam);
            //    frmDevam.Show();
            //    foreach (TabPage item in tabAnasayfa.TabPages)
            //    {
            //        item.Controls[0].Size = new Size(tabAnasayfa.Size.Width - 100, tabAnasayfa.Size.Height - 100);
            //    }
            //}
        }
        void Admin()
        {
            if (authId == 4 || authId == 1)
            {
                //FrmAdmin.Visible = true;
            }
        }
        void ControlNodes(int authId)
        {
            return;
            /*treeView2.Nodes["SATIN ALMA"].Nodes["SatOnOnay"].Remove();
            if (authId == 4 || authId == 1)
            {
                ToplamSayilar();
                return;
            }*/


            //treeView2.Nodes["BUTCE"].Remove();
            //string izin_idleri = "59;60;61";
            //string[] array = izinIdleri.Split(';');
            //#region Baslıklar

            //if (!array.Contains("1"))
            //{
            //    treeView2.Nodes["BAKIM ONARIM"].Remove();//
            //    //treeView2.Nodes.Add(1," Ana Başlık) //- Ana Başlık
            //    //treeView2.Nodes["BAKIM ONARIM"].Nodes.Add(2,) //- Alt Başlık
            //    //treeView2.Nodes.Find(2,true)[0].Nodes.Add() // Keye göre node bulup alt başlık ekleme
            //    control = 1;
            //}
            //if (control != 1)
            //{
            //    if (!array.Contains("2"))
            //    {
            //        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Remove();
            //        atla = 1;
            //    }
            //    if (atla != 1)
            //    {
            //        TreeNode treeNode = treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"];
            //        if (!array.Contains("3"))
            //        {
            //            treeNode.Nodes["Ariza Kayitlari"].Remove();
            //        }
            //        if (!array.Contains("4"))
            //        {
            //            treeNode.Nodes["Devam Eden Arıza"].Remove();
            //        }
            //        if (!array.Contains("5"))
            //        {
            //            treeNode.Nodes["Tamamlanan Arıza"].Remove();
            //        }
            //        if (!array.Contains("6"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["Iscilik Izleme"].Remove();
            //        }
            //        if (!array.Contains("7"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["Bolge Yol Durumu"].Remove();
            //        }
            //        if (!array.Contains("8"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["Yerlesim Kayıtları"].Remove();
            //        }
            //        if (!array.Contains("9"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["OKF"].Remove();
            //        }
            //        if (!array.Contains("10"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["DTF Izleme"].Remove();
            //        }
            //        if (!array.Contains("11"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["Musteri Bildiri"].Remove();
            //        }
            //        if (!array.Contains("12"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["Teslimat Istekleri"].Remove();
            //        }
            //        if (!array.Contains("13"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["Firma Servis Formu"].Remove();
            //        }
            //        if (!array.Contains("14"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["Destek Iscilik Izleme"].Remove();
            //        }
            //        if (!array.Contains("15"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI IZLEME"].Nodes["BolgeKayitIzleme"].Remove();
            //        }
            //    }
            //    if (!array.Contains("16"))
            //    {
            //        treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Remove();
            //        atla = 2;
            //    }
            //    if (atla != 2)
            //    {
            //        if (!array.Contains("17"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Veri Kayit Arıza Acma"].Remove();
            //        }
            //        if (!array.Contains("18"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Veri Guncelleme"].Remove();
            //        }
            //        if (!array.Contains("19"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Bildirim Onayi"].Remove();
            //        }
            //        if (!array.Contains("20"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Musteri Bilgileri"].Remove();
            //        }
            //        if (!array.Contains("21"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Bolge Yol Durumu"].Remove();
            //        }
            //        if (!array.Contains("22"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Yerlesim Kayitlari"].Remove();
            //        }
            //        if (!array.Contains("23"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Malzeme Temini"].Remove();
            //        }
            //        if (!array.Contains("24"))
            //        {
            //            //treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Malzeme Temini"].Remove();
            //        }
            //        if (!array.Contains("25"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Dogrudan Temini"].Remove();
            //        }
            //        if (!array.Contains("26"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Servis Talepleri"].Remove();
            //        }
            //        if (!array.Contains("27"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["DTF Olusturma"].Remove();
            //        }
            //        if (!array.Contains("28"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["OKF Olusturma"].Remove();
            //        }
            //        if (!array.Contains("29"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Teslimat Eksikleri"].Remove();
            //        }
            //        if (!array.Contains("30"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Firma Servis Formu Kayit"].Remove();
            //        }
            //        if (!array.Contains("31"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["Destek Iscilik"].Remove();
            //        }
            //        if (!array.Contains("31"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM"].Nodes["BO VERI GIRIS"].Nodes["BolgeKayit"].Remove();
            //        }
            //    }
            //}
            //if (!array.Contains("32"))
            //{
            //    treeView2.Nodes["BAKIM ONARIM ATOLYE"].Remove();
            //    control = 2;
            //}
            //if (control != 2)
            //{
            //    if (!array.Contains("33"))
            //    {
            //        treeView2.Nodes["BAKIM ONARIM ATOLYE"].Nodes["BO VERI IZLEME ATOLYE"].Remove();
            //        atla = 3;
            //    }
            //    if (atla != 3)
            //    {
            //        if (!array.Contains("34"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM ATOLYE"].Nodes["BO VERI IZLEME ATOLYE"].Nodes["Devam Eden Ariza Atolye"].Remove();
            //        }
            //        if (!array.Contains("35"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM ATOLYE"].Nodes["BO VERI IZLEME ATOLYE"].Nodes["Tamamlana Ariza Atolye"].Remove();
            //        }
            //        if (!array.Contains("36"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM ATOLYE"].Nodes["BO VERI IZLEME ATOLYE"].Nodes["IscilikIzlemeAtolye"].Remove();
            //        }
            //    }
            //    if (!array.Contains("37"))
            //    {
            //        treeView2.Nodes["BAKIM ONARIM ATOLYE"].Nodes["BO VERI GIRIS ATOLYE"].Remove();
            //        atla = 4;
            //    }
            //    if (atla != 4)
            //    {
            //        if (!array.Contains("38"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM ATOLYE"].Nodes["BO VERI GIRIS ATOLYE"].Nodes["Veri Kayit Atolye"].Remove();
            //        }
            //        if (!array.Contains("38"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM ATOLYE"].Nodes["BO VERI GIRIS ATOLYE"].Nodes["Veri Kayit Atolye Guncelleme"].Remove();
            //        }
            //        if (!array.Contains("39"))
            //        {
            //            treeView2.Nodes["BAKIM ONARIM ATOLYE"].Nodes["BO VERI GIRIS ATOLYE"].Nodes["Veri Kayit Atolye Kapatma"].Remove();
            //        }
            //    }
            //}

            //if (!array.Contains("40"))
            //{
            //    treeView2.Nodes["GECICI KABUL AMBAR"].Remove();
            //    control = 3;
            //}
            //if (control != 3)
            //{
            //    if (!array.Contains("41"))
            //    {
            //        treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI IZLEME"].Remove();
            //        atla = 5;
            //    }
            //    if (atla != 5)
            //    {
            //        if (!array.Contains("42"))
            //        {
            //            treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI IZLEME"].Nodes["Stok Goruntule"].Remove();
            //        }
            //        if (!array.Contains("43"))
            //        {
            //            treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI IZLEME"].Nodes["Depo Hareketleri"].Remove();
            //        }
            //        if (!array.Contains("44"))
            //        {
            //            treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI IZLEME"].Nodes["Stokta Bulunmayan Malzeme"].Remove();
            //        }
            //        if (!array.Contains("45"))
            //        {
            //            treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI IZLEME"].Nodes["KayitliMalzemeler"].Remove();
            //        }
            //    }
            //    if (!array.Contains("46"))
            //    {
            //        treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI GIRIS"].Remove();
            //        atla = 6;
            //    }
            //    if (atla != 6)
            //    {
            //        if (!array.Contains("47"))
            //        {
            //            treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI GIRIS"].Nodes["Stok Giris Cikis"].Remove();
            //        }
            //        if (!array.Contains("48"))
            //        {
            //            treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI GIRIS"].Nodes["Malzeme Kayit Ambar"].Remove();
            //        }
            //        if (!array.Contains("49"))
            //        {
            //            treeView2.Nodes["GECICI KABUL AMBAR"].Nodes["GKA VERI GIRIS"].Nodes["Malzeme Hazirlama"].Remove();
            //        }
            //    }
            //}

            //if (!array.Contains("50"))
            //{
            //    treeView2.Nodes["SATIN ALMA"].Remove();
            //    control = 4;
            //}
            //if (control != 4)
            //{
            //    if (!array.Contains("51"))
            //    {
            //        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI IZLEME"].Remove();
            //        atla = 7;
            //    }
            //    if (atla != 7)
            //    {
            //        if (!array.Contains("52"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI IZLEME"].Nodes["devamedensat"].Remove();
            //        }
            //        if (!array.Contains("53"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI IZLEME"].Nodes["Tamamlanan Sat"].Remove();
            //        }
            //        if (!array.Contains("54"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI IZLEME"].Nodes["RedEdilenSat"].Remove();
            //        }
            //        if (!array.Contains("55"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI IZLEME"].Nodes["Sat Yedek Parca Katalogu"].Remove();
            //        }
            //    }
            //    if (!array.Contains("56"))
            //    {
            //        treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Remove();
            //        atla = 8;
            //    }
            //    if (atla != 8)
            //    {
            //        if (!array.Contains("57"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["satolustur"].Remove();
            //        }
            //        if (!array.Contains("58"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["SatOnOnay"].Remove();
            //        }
            //        if (!array.Contains("59"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["Sat Baslatma Onayi"].Remove();
            //        }
            //        if (!array.Contains("60"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["TeklifAlınacakSat"].Remove();
            //        }
            //        if (!array.Contains("61"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["Satın Alınacak Malzemeler"].Remove();
            //        }
            //        if (!array.Contains("62"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["SatOnay"].Remove();
            //        }
            //        if (!array.Contains("63"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["Sat Tamamlama"].Remove();
            //        }
            //        if (!array.Contains("64"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["Sat Guncelle"].Remove();
            //        }
            //        if (!array.Contains("65"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["Tedarikci Firma"].Remove();
            //        }
            //        if (!array.Contains("66"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["Alt Yuklenici Firma"].Remove();
            //        }
            //        if (!array.Contains("67"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["AylikButceKapatmaYakit"].Remove();
            //        }
            //        if (!array.Contains("68"))
            //        {
            //            treeView2.Nodes["SATIN ALMA"].Nodes["SA VERI GIRIS"].Nodes["YillikButceKapatma"].Remove();
            //        }
            //    }
            //}
            //if (!array.Contains("69"))
            //{
            //    treeView2.Nodes["DOKUMAN YONETIM"].Remove();
            //    control = 5;
            //}
            //if (control != 5)
            //{
            //    if (!array.Contains("70"))
            //    {
            //        treeView2.Nodes["DOKUMAN YONETIM"].Nodes["DY VERI IZLEME"].Remove();
            //        atla = 8;
            //    }
            //    if (atla != 8)
            //    {
            //        if (!array.Contains("71"))
            //        {
            //            treeView2.Nodes["DOKUMAN YONETIM"].Nodes["DY VERI IZLEME"].Nodes["Dokuman Sorgula"].Remove();
            //        }
            //        if (!array.Contains("72"))
            //        {
            //            treeView2.Nodes["DOKUMAN YONETIM"].Nodes["DY VERI IZLEME"].Nodes["Standart Form Sorgula"].Remove();
            //        }
            //    }
            //    if (!array.Contains("73"))
            //    {
            //        treeView2.Nodes["DOKUMAN YONETIM"].Nodes["DY VERI GIRIS"].Remove();
            //        atla = 9;
            //    }
            //    if (atla != 9)
            //    {
            //        if (!array.Contains("74"))
            //        {
            //            treeView2.Nodes["DOKUMAN YONETIM"].Nodes["DY VERI GIRIS"].Nodes["Dokuman Ekle"].Remove();
            //        }
            //        if (!array.Contains("75"))
            //        {
            //            treeView2.Nodes["DOKUMAN YONETIM"].Nodes["DY VERI GIRIS"].Nodes["Standart Form Ekle"].Remove();
            //        }
            //    }
            //}
            //if (!array.Contains("76"))
            //{
            //    treeView2.Nodes["IDARI ISLER"].Remove();
            //    control = 6;
            //}
            //if (control != 6)
            //{
            //    if (!array.Contains("77"))
            //    {
            //        treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Remove();
            //        atla = 10;
            //    }
            //    if (atla != 10)
            //    {
            //        if (!array.Contains("78"))
            //        {
            //            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Duran Varlık"].Remove();
            //            atladal = 1;
            //        }
            //        if (atladal != 1)
            //        {
            //            if (!array.Contains("79"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Duran Varlık"].Nodes["DuranVarlikKayit"].Remove();
            //            }
            //            if (!array.Contains("80"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Duran Varlık"].Nodes["DuranVarlikAkarma"].Remove();
            //            }
            //            if (!array.Contains("81"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Duran Varlık"].Nodes["Duran Varlik Ariza Kayit"].Remove();
            //            }
            //            if (!array.Contains("82"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Duran Varlık"].Nodes["DV Kalibrasyon Kayit"].Remove();
            //            }
            //        }
            //        if (!array.Contains("83"))
            //        {
            //            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Personel"].Remove();
            //            atladal = 2;
            //        }
            //        if (atladal != 2)
            //        {
            //            if (!array.Contains("84"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Personel"].Nodes["PersonelKayit"].Remove();
            //            }
            //            if (!array.Contains("85"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Personel"].Nodes["PersonelPuantaj"].Remove();
            //            }
            //        }
            //        if (!array.Contains("86"))
            //        {
            //            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Is Akislari"].Remove();
            //            atladal = 3;
            //        }
            //        if (atladal != 3)
            //        {
            //            if (!array.Contains("87"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Is Akislari"].Nodes["Yurt Icı Gorev"].Remove();
            //            }
            //            if (!array.Contains("88"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Is Akislari"].Nodes["Sehir Icı Gorev"].Remove();
            //            }
            //            if (!array.Contains("89"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Is Akislari"].Nodes["Izın"].Remove();
            //            }
            //            if (!array.Contains("90"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Is Akislari"].Nodes["Konaklama"].Remove();
            //            }
            //            if (!array.Contains("91"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Is Akislari"].Nodes["Ucak Otobus Bileti"].Remove();
            //            }
            //            if (!array.Contains("92"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Is Akislari"].Nodes["Harcama Beyannamesi"].Remove();
            //            }
            //        }
            //        if (!array.Contains("93"))
            //        {
            //            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Resmi Yazilar"].Remove();
            //            atladal = 4;
            //        }
            //        if (atladal != 4)
            //        {
            //            if (!array.Contains("94"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Resmi Yazilar"].Nodes["Evrak Kayit"].Remove();
            //            }
            //        }
            //        if (!array.Contains("95"))
            //        {
            //            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Arsiv"].Remove();
            //            atladal = 5;
            //        }
            //        if (atladal != 5)
            //        {
            //            if (!array.Contains("96"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Arsiv"].Nodes["Tutanak"].Remove();
            //            }
            //            if (!array.Contains("97"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Arsiv"].Nodes["HaftalikKontrol"].Remove();
            //            }
            //        }
            //        if (!array.Contains("98"))
            //        {
            //            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Ulastırma"].Remove();
            //            atladal = 6;
            //        }
            //        if (atladal != 6)
            //        {
            //            if (!array.Contains("99"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Ulastırma"].Nodes["Arac Tesis Kayit"].Remove();
            //            }
            //            if (!array.Contains("100"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Ulastırma"].Nodes["Arac Yakit Beyani"].Remove();
            //            }
            //            if (!array.Contains("101"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Ulastırma"].Nodes["Arac Periyodik Bakım"].Remove();
            //            }
            //            if (!array.Contains("102"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Ulastırma"].Nodes["Arac Bakim Onarim"].Remove();
            //            }
            //            if (!array.Contains("103"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Ulastırma"].Nodes["YakitDokumleri"].Remove();
            //            }
            //            if (!array.Contains("104"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Ulastırma"].Nodes["Arac Talep"].Remove();
            //            }
            //            if (!array.Contains("105"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Ulastırma"].Nodes["Arac Km"].Remove();
            //            }
            //        }
            //        if (!array.Contains("106"))
            //        {
            //            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI GIRIS"].Nodes["Ziyaretci Kayit"].Remove();
            //            atladal = 5;
            //        }
            //    }
            //    if (!array.Contains("107"))
            //    {
            //        treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Remove();
            //        atla = 11;
            //    }
            //    if (atla != 11)
            //    {
            //        if (!array.Contains("108"))
            //        {
            //            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Duran Varlik Izleme"].Remove();
            //            atladal = 6;
            //        }
            //        if (atladal != 6)
            //        {
            //            if (!array.Contains("109"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Duran Varlik Izleme"].Nodes["DuranVarlikTakip"].Remove();
            //            }
            //            if (!array.Contains("110"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Duran Varlik Izleme"].Nodes["DV Zimmet Takibi"].Remove();
            //            }
            //            if (!array.Contains("111"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Duran Varlik Izleme"].Nodes["DV Ariza Takibi"].Remove();
            //            }
            //            if (!array.Contains("112"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Duran Varlik Izleme"].Nodes["DV Kalibrasyon Takibi"].Remove();
            //            }
            //        }
            //        if (!array.Contains("113"))
            //        {
            //            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Personel Izleme"].Remove();
            //            atladal = 7;
            //        }
            //        if (atladal != 7)
            //        {
            //            if (!array.Contains("114"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Personel Izleme"].Nodes["PersonelListesi"].Remove();
            //            }
            //            if (!array.Contains("115"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Personel Izleme"].Nodes["PersonelListesiAyrilan"].Remove();
            //            }
            //            if (!array.Contains("116"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Personel Izleme"].Nodes["Personel Puantaj"].Remove();
            //            }
            //        }
            //        if (!array.Contains("117"))
            //        {
            //            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Is Akislari Izleme"].Remove();
            //            atladal = 8;
            //        }
            //        if (atladal != 8)
            //        {
            //            if (!array.Contains("118"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Is Akislari Izleme"].Nodes["Yurt Icı GorevIzleme"].Remove();
            //            }
            //            if (!array.Contains("119"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Is Akislari Izleme"].Nodes["Sehir Ici Gorev"].Remove();
            //            }
            //            if (!array.Contains("120"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Is Akislari Izleme"].Nodes["Izin Izleme"].Remove();
            //            }
            //            if (!array.Contains("121"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Is Akislari Izleme"].Nodes["Konaklama Izleme"].Remove();
            //            }
            //            if (!array.Contains("122"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Is Akislari Izleme"].Nodes["Ucak Otobus Izleme"].Remove();
            //            }
            //            if (!array.Contains("123"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Is Akislari Izleme"].Nodes["Harcama Beyan Izleme"].Remove();
            //            }
            //        }
            //        if (!array.Contains("124"))
            //        {
            //            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Gelen Giden Yazi Izleme"].Remove();
            //        }
            //        if (!array.Contains("125"))
            //        {
            //            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Arsiv Izleme"].Remove();
            //            atladal = 9;
            //        }
            //        if (atladal != 9)
            //        {
            //            if (!array.Contains("126"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Arsiv Izleme"].Nodes["TutanakIzleme"].Remove();
            //            }
            //            if (!array.Contains("127"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Arsiv Izleme"].Nodes["HaftalikKontrolIzleme"].Remove();
            //            }

            //        }
            //        if (!array.Contains("128"))
            //        {
            //            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["UlastırmaIzleme"].Remove();
            //            atladal = 10;
            //        }
            //        if (atladal != 10)
            //        {
            //            if (!array.Contains("129"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["UlastırmaIzleme"].Nodes["Arac Tahsis Izleme"].Remove();
            //            }
            //            if (!array.Contains("130"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["UlastırmaIzleme"].Nodes["Arac Yakıt Izleme"].Remove();
            //            }
            //            if (!array.Contains("131"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["UlastırmaIzleme"].Nodes["Arac Periyodik Izleme"].Remove();
            //            }
            //            if (!array.Contains("132"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["UlastırmaIzleme"].Nodes["Arac Bakim Onarim Izleme"].Remove();
            //            }
            //            if (!array.Contains("133"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["UlastırmaIzleme"].Nodes["YakitDokumleriIzleme"].Remove();
            //            }
            //            if (!array.Contains("134"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["UlastırmaIzleme"].Nodes["Arac Talep Izleme"].Remove();
            //            }
            //            if (!array.Contains("135"))
            //            {
            //                treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["UlastırmaIzleme"].Nodes["Arac Km Izleme"].Remove();
            //            }
            //        }
            //        if (!array.Contains("136"))
            //        {
            //            treeView2.Nodes["IDARI ISLER"].Nodes["II VERI IZLEME"].Nodes["Ziyaretci Kayit Izleme"].Remove();
            //            atladal = 11;
            //        }
            //    }
            //}
            //if (!array.Contains("137"))
            //{
            //    treeView2.Nodes["EGITIM"].Remove();
            //    control = 7;
            //}
            //if (control != 7)
            //{
            //    if (!array.Contains("138"))
            //    {
            //        treeView2.Nodes["EGITIM"].Nodes["E VERI GIRIS"].Remove();
            //        atla = 12;
            //    }
            //    if (atla != 12)
            //    {
            //        if (!array.Contains("139"))
            //        {
            //            treeView2.Nodes["EGITIM"].Nodes["E VERI GIRIS"].Nodes["Egitim Veri Giris"].Remove();
            //        }
            //        if (!array.Contains("140"))
            //        {
            //            treeView2.Nodes["EGITIM"].Nodes["E VERI GIRIS"].Nodes["Egitim Planı Olustur"].Remove();
            //        }
            //        if (!array.Contains("141"))
            //        {
            //            treeView2.Nodes["EGITIM"].Nodes["E VERI GIRIS"].Nodes["Egitim Planı Guncelle"].Remove();
            //        }
            //    }
            //    if (!array.Contains("142"))
            //    {
            //        treeView2.Nodes["EGITIM"].Nodes["E VERI IZLEME"].Remove();
            //        atla = 12;
            //    }
            //    if (atla != 12)
            //    {
            //        if (!array.Contains("143"))
            //        {
            //            treeView2.Nodes["EGITIM"].Nodes["E VERI IZLEME"].Nodes["Egitim Izleme"].Remove();
            //        }
            //        if (!array.Contains("144"))
            //        {
            //            treeView2.Nodes["EGITIM"].Nodes["E VERI IZLEME"].Nodes["Egitim Planı Izleme"].Remove();
            //        }
            //    }
            //}
            //if (!array.Contains("145"))
            //{
            //    treeView2.Nodes["DESTEK DEPO"].Remove();
            //    control = 8;
            //}
            //if (control != 8)
            //{
            //    if (!array.Contains("146"))
            //    {
            //        treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI IZLEME"].Remove();
            //        atla = 13;
            //    }
            //    if (atla != 13)
            //    {
            //        if (!array.Contains("147"))
            //        {
            //            treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI IZLEME"].Nodes["Stok Goruntule Depo"].Remove();
            //        }
            //        if (!array.Contains("148"))
            //        {
            //            treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI IZLEME"].Nodes["Depo Hareketleri Depo"].Remove();
            //        }
            //        if (!array.Contains("149"))
            //        {
            //            treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI IZLEME"].Nodes["Stokta Bulunmayan Malz"].Remove();
            //        }
            //    }
            //    if (!array.Contains("150"))
            //    {
            //        treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI GIRIS"].Remove();
            //        atla = 14;
            //    }
            //    if (atla != 14)
            //    {
            //        if (!array.Contains("151"))
            //        {
            //            treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI GIRIS"].Nodes["Stok Giris"].Remove();
            //        }
            //        if (!array.Contains("152"))
            //        {
            //            treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI GIRIS"].Nodes["Malzeme Kayit"].Remove();
            //        }
            //        if (!array.Contains("153"))
            //        {
            //            treeView2.Nodes["DESTEK DEPO"].Nodes["DD VERI GIRIS"].Nodes["Malzeme Hazirlama"].Remove();
            //        }
            //    }
            //}
            //if (!array.Contains("154"))
            //{
            //    treeView2.Nodes["RAPORLAMALAR"].Remove();
            //    control = 9;
            //}
            //if (control != 9)
            //{
            //    if (!array.Contains("155"))
            //    {
            //        treeView2.Nodes["RAPORLAMALAR"].Nodes["R VERI IZLEME"].Remove();
            //        atla = 15;
            //    }
            //    if (atla != 15)
            //    {
            //        if (!array.Contains("156"))
            //        {
            //            treeView2.Nodes["DESTEK DEPO"].Nodes["R VERI IZLEME"].Nodes["SatRaporlamaIzleme"].Remove();
            //        }
            //        if (!array.Contains("157"))
            //        {
            //            treeView2.Nodes["DESTEK DEPO"].Nodes["R VERI IZLEME"].Nodes["Adim Islem Sureleri"].Remove();
            //        }
            //    }
            //    if (!array.Contains("158"))
            //    {
            //        treeView2.Nodes["RAPORLAMALAR"].Nodes["R VERI GIRIS"].Remove();
            //        atla = 16;
            //    }
            //    if (atla != 16)
            //    {
            //        if (!array.Contains("159"))
            //        {
            //            treeView2.Nodes["DESTEK DEPO"].Nodes["R VERI GIRIS"].Nodes["SatRaporlama"].Remove();
            //        }
            //    }
            //}
            //if (!array.Contains("160"))
            //{
            //    treeView2.Nodes["YERLESKELER"].Remove();
            //    control = 10;
            //}
            //if (control != 10)
            //{
            //    if (!array.Contains("161"))
            //    {
            //        treeView2.Nodes["YERLESKELER"].Nodes["YK VERI IZLEME"].Remove();
            //        atla = 17;
            //    }
            //    if (atla != 17)
            //    {
            //        if (!array.Contains("162"))
            //        {
            //            treeView2.Nodes["YERLESKELER"].Nodes["YK VERI IZLEME"].Nodes["YerleskeIzleme"].Remove();
            //        }
            //        if (!array.Contains("163"))
            //        {
            //            treeView2.Nodes["YERLESKELER"].Nodes["YK VERI IZLEME"].Nodes["GiderKayitIzleme"].Remove();
            //        }
            //    }
            //    if (!array.Contains("164"))
            //    {
            //        treeView2.Nodes["YERLESKELER"].Nodes["YK VERI GIRIS"].Remove();
            //        atla = 18;
            //    }
            //    if (atla != 18)
            //    {
            //        if (!array.Contains("165"))
            //        {
            //            treeView2.Nodes["YERLESKELER"].Nodes["YK VERI GIRIS"].Nodes["SatRaporlama"].Remove();
            //        }
            //        if (!array.Contains("166"))
            //        {
            //            treeView2.Nodes["YERLESKELER"].Nodes["YK VERI GIRIS"].Nodes["YerleskeGideriKayit"].Remove();
            //        }
            //    }
            //}
            //if (!array.Contains("167"))
            //{
            //    treeView2.Nodes["BUTCE"].Remove();
            //    control = 11;
            //}
            //if (control != 11)
            //{
            //    if (!array.Contains("168"))
            //    {
            //        treeView2.Nodes["BUTCE"].Nodes["BT VERI IZLEME"].Remove();
            //        atla = 19;
            //    }
            //    if (atla != 19)
            //    {
            //        if (!array.Contains("169"))
            //        {
            //            treeView2.Nodes["BUTCE"].Nodes["BT VERI IZLEME"].Nodes["Butce Izleme"].Remove();
            //        }
            //        if (!array.Contains("170"))
            //        {
            //            treeView2.Nodes["BUTCE"].Nodes["BT VERI IZLEME"].Nodes["SiparisIzleme"].Remove();
            //        }
            //        if (!array.Contains("171"))
            //        {
            //            treeView2.Nodes["BUTCE"].Nodes["BT VERI IZLEME"].Nodes["ProjeKasaIzleme"].Remove();
            //        }
            //    }
            //    if (!array.Contains("172"))
            //    {
            //        treeView2.Nodes["BUTCE"].Nodes["BT VERI GIRIS"].Remove();
            //        atla = 20;
            //    }
            //    if (atla != 20)
            //    {
            //        if (!array.Contains("173"))
            //        {
            //            treeView2.Nodes["BUTCE"].Nodes["BT VERI GIRIS"].Nodes["ButceKayit"].Remove();
            //        }
            //        if (!array.Contains("174"))
            //        {
            //            treeView2.Nodes["BUTCE"].Nodes["BT VERI GIRIS"].Nodes["SiparisOlustur"].Remove();
            //        }
            //        if (!array.Contains("175"))
            //        {
            //            treeView2.Nodes["BUTCE"].Nodes["BT VERI GIRIS"].Nodes["ButceKasa"].Remove();
            //        }
            //    }
            //}

            //if (array.Contains("50"))
            //{
            //    ToplamSayilar();
            //}

        }
        ///#endregion

        void FillInfos()
        {
            LblKullanici.Text = infos[1].ToString();
        }

        // dallar

        private void aDMİNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdmin frmAdmin = new FrmAdmin();
            frmAdmin.infos = infos;
            frmAdmin.ShowDialog();
        }

        private void şİFREDEĞİŞTİRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSifremiDegistir frmSifremiDegistir = new FrmSifremiDegistir();
            frmSifremiDegistir.infos = infos;
            frmSifremiDegistir.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width = panel1.Width + 10;
            if (panel1.Size.Width == 340)
            {
                timer1.Stop();
                button1.Image = imageList.Images["kucultme.png"];
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel1.Width = panel1.Width - 20;
            if (panel1.Size.Width == 40)
            {
                timer2.Stop();
                //lblCompanyName.Visible = true;
                button1.Image = imageList.Images["buyutme.png"];
            }
        }
        void TabControlGenislet()
        {
            tabAnasayfa.Location = new Point(47, 27);
            tabAnasayfa.Size = new Size(Size.Width - 100, Size.Height - 100);
            foreach (TabPage item in tabAnasayfa.TabPages)
            {
                item.Controls[0].Size = new Size(Size.Width - 100, Size.Height - 100);
            }
        }
        void TabControlDaralt()
        {
            tabAnasayfa.Location = new Point(335, 27);
            tabAnasayfa.Size = new Size(Size.Width - 100, Size.Height - 100);
            foreach (TabPage item in tabAnasayfa.TabPages)
            {
                item.Controls[0].Size = new Size(Size.Width - 350, Size.Height - 100);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 40)
            {
                timer1.Start();
                TreeMenu.Visible = true;
                //treeView2.Visible = true;
                TabControlDaralt();
                //lblCompanyName.Visible = false;
                panel5.Visible = true;
            }
            if (panel1.Width > 300)
            {
                timer2.Start();
                panel5.Visible = false;
                
                TreeMenu.Visible = false;
                //treeView2.Visible = false;
                TabControlGenislet();
            }
        }

        private void favorilereEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (treeView2.SelectedNode.Tag.ToString() != "Header")
            {
                string nodeName = treeView2.SelectedNode.Name;
            }*/
        }
        bool kapatBilgisi = true;
        void VersionBul()
        {
            List<VersionBilgi> versionBilgis = new List<VersionBilgi>();
            versionBilgis = versionManager.GetList();
            if (versionBilgis.Count == 0)
            {
                return;
            }
            string yeniversion = versionBilgis[0].VersionNo;
            string path = versionBilgis[0].Dosyayolu;
            string eskiversion = LblVersionNo.Text;
            if (yeniversion != eskiversion)
            {
                DialogResult dr = MessageBox.Show("Merhaba " + LblKullanici.Text + ",\nYeni Bir DTS Versionu Tespit Edilmiştir.\nVersion :" + yeniversion + " Güncellemek İster Misiniz?",
                    "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    LblVersionNo.Text = versionBilgis[0].VersionNo;
                    System.Diagnostics.Process.Start(path);
                    kapatBilgisi = false;
                    Application.Exit();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //BtnGit
        {
            if (TxtKomut.Text == "")
            {
                //MessageBox.Show("Lütfen öncelikle Komut bilgisini doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TreeMenu.Nodes[0].Remove();
                TreeMenu.Nodes[0].Remove();
                Basliklar(authId);

            }
            menuBasliksVeriGiris.Clear();
            menuBasliksVeriIzleme.Clear();
            menuBasliks2.Clear();
            menuBasliks3.Clear();
            menuBasliks4.Clear();
            index = 0;
            indexAlt = 0;

            TreeMenu.Nodes[0].Remove();
            TreeMenu.Nodes[0].Remove();
            int id = 0;

            foreach (MenuBaslik item in menuBasliks)
            {
                if (item.BaslikId == 0)
                {
                    TreeMenu.Nodes.Add(item.Baslik);
                    id = item.Id;
                }
                else
                {
                    if (id == item.BaslikId)
                    {
                        if (id == 1)
                        {
                            menuBasliksVeriGiris.Add(item);
                        }
                        else
                        {
                            menuBasliksVeriIzleme.Add(item);
                        }
                    }
                }
            }

            foreach (MenuBaslik item in menuBasliksVeriGiris)
            {
                string kod = item.Baslik;
                string[] array = kod.Split('-');
                if (array[0].ToString() == TxtKomut.Text)
                {
                    menuBasliks2 = menuManager.GetListAlt(item.Id);
                    TreeMenu.Nodes[0].Nodes.Add(item.Baslik);
                    TreeMenu.Nodes[0].BackColor = Color.CadetBlue;
                    foreach (MenuBaslik item2 in menuBasliks2)
                    {
                        TreeMenu.Nodes[0].Nodes[index].Nodes.Add(item2.Baslik);
                        menuBasliks4 = menuManager.GetListAlt(item2.Id);
                        if (menuBasliks4.Count != 0)
                        {
                            foreach (MenuBaslik item3 in menuBasliks4)
                            {
                                TreeMenu.Nodes[0].Nodes[index].Nodes[indexAlt].Nodes.Add(item3.Baslik);
                            }
                            indexAlt++;
                            menuBasliks4.Clear();
                        }
                    }
                    index++;
                }
            }

            index = 0;
            indexAlt = 0;

            foreach (MenuBaslik item in menuBasliksVeriIzleme)
            {
                string kod = item.Baslik;
                string[] array = kod.Split('-');
                if (array[0].ToString() == TxtKomut.Text)
                {
                    menuBasliks3 = menuManager.GetListAlt(item.Id);
                    TreeMenu.Nodes[1].Nodes.Add(item.Baslik);
                    TreeMenu.Nodes[1].BackColor = Color.CadetBlue;
                    foreach (MenuBaslik item2 in menuBasliks3)
                    {
                        TreeMenu.Nodes[1].Nodes[index].Nodes.Add(item2.Baslik);
                        menuBasliks4 = menuManager.GetListAlt(item2.Id);
                        if (menuBasliks4.Count != 0)
                        {
                            foreach (MenuBaslik item3 in menuBasliks4)
                            {
                                TreeMenu.Nodes[1].Nodes[index].Nodes[indexAlt].Nodes.Add(item3.Baslik);
                            }
                            indexAlt++;
                            menuBasliks4.Clear();
                        }
                    }
                    index++;
                }
            }

        }

        private void VersionEkle_Click(object sender, EventArgs e)
        {
            //Application.SetSuspendState(PowerState.Suspend, false, false); // bilgisayarı uyku moduna alır

            DialogResult dr = MessageBox.Show("Yeni Version Çıkarmadan Önce publis çıkarmayı ve onu servere atmayı unutmayın yaptıysanız devam edin, Devam Etmek İstiyor Musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //string path = "C:\\Users\\MAYıldırım\\source\\repos\\MUBProje\\UserInterface\\publish\\DTS Version.application";
                string path = "Z:\\DTS\\DTS Setup\\publish\\DTS.application";
                string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                VersionBilgi versionBilgi = new VersionBilgi(version, path);
                string mesaj = versionManager.Add(versionBilgi);
                if (mesaj == "OK")
                {
                    MessageBox.Show("Yeni Version Bilgisi VERİ TABANINA Yazıldı, Kullanıcılara Bilgi Gidecektir.");
                }
                else
                {
                    MessageBox.Show(mesaj);
                }
            }
        }

        private void BtnDosyaKitle_Click(object sender, EventArgs e)
        {
            //KİTLE
            //string folderPath = "C:\\Users\\MAYıldırım\\Desktop\\C# Notes\\Secret\\Locker";
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            string folderPath = folderBrowser.SelectedPath;
            if (folderPath == "")
            {
                MessageBox.Show("Klasor Seçmedin.");
                return;
            }
            string adminUserName = Environment.UserName;
            DirectorySecurity ds = Directory.GetAccessControl(folderPath);
            FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
            ds.AddAccessRule(fsa);
            Directory.SetAccessControl(folderPath, ds);
            MessageBox.Show(folderPath + "\nBaşarı");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DateTime dateTime = dataReader["BASLAMA_TARİHİ"].ConTime();
            //string gecenSure = (DateTime.Now.Subtract(dateTime)).ToString();
            //gecenSure = gecenSure.Substring(0, gecenSure.LastIndexOf('.')); 

            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            string folderPath = folderBrowser.SelectedPath;
            if (folderPath == "")
            {
                MessageBox.Show("Klasor Seçmedin.");
                return;
            }
            string adminUserName = Environment.UserName;
            DirectorySecurity ds = Directory.GetAccessControl(folderPath);
            FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
            bool result = ds.RemoveAccessRule(fsa);
            Directory.SetAccessControl(folderPath, ds);
            MessageBox.Show(folderPath + "\nBaşarı" + result);
        }

        private void dEVAMDEVAMSIZLIKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDevam frmDevam = new FrmDevam();
            frmDevam.FormBorderStyle = FormBorderStyle.None;
            frmDevam.TopLevel = false;
            frmDevam.AutoScroll = true;
            OpenTabPage("PageDevam", "DEVAM/DEVAMSIZLIK", frmDevam);
            frmDevam.Show();
        }

        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void tabAnasayfa_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabAnasayfa_SelectedIndexChanged(object sender, EventArgs e)
        {
            PnlBildirim.Size = new Size(0, 0);
            tabAnasayfa.Size = new Size(1600, 955);

            int index = tabAnasayfa.SelectedIndex;
            if (index == -1)
            {
                return;
            }
            else
            {
                string baslik = tabAnasayfa.SelectedTab.Text;
                if (baslik == "EVRAK KAYIT")
                {
                    var form = (FrmEvrakKayit)Application.OpenForms["FrmEvrakKayit"];
                    if (form != null)
                    {
                        form.IsAkisNo();
                    }
                }
                if (baslik == "GELEN/GİDEN RESMİ YAZI İZLEME")
                {
                    var form = (FrmEvrekKayitIzleme)Application.OpenForms["FrmEvrekKayitIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();

                    }
                }
                if (baslik == "DOKÜMAN EKLE")
                {
                    var form = (FrmDokumanEkle)Application.OpenForms["FrmDokumanEkle"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "STANDART FORM SORGULA")
                {
                    var form = (FrmStandartForm)Application.OpenForms["FrmStandartForm"];
                    if (form != null)
                    {
                        form.DtgDoldur();
                    }
                }
                if (baslik == "DOKÜMAN SORGULA")
                {
                    var form = (FrmDokumanSorgula)Application.OpenForms["FrmDokumanSorgula"];
                    if (form != null)
                    {
                        form.DtgDoldur();
                    }
                }
                if (baslik == "STANDART FORM EKLE")
                {
                    var form = (FrmStandartFormEkle)Application.OpenForms["FrmStandartFormEkle"];
                    if (form != null)
                    {
                        form.DtgDoldur();
                    }
                }
                if (baslik == "PERSONEL KAYIT")
                {
                    var form = (FrmPersonelKayit)Application.OpenForms["FrmPersonelKayit"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "PERSONEL LİSTESİ")
                {
                    var form = (FrmPersonelListesi)Application.OpenForms["FrmPersonelListesi"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "PERSONEL LİSTESİ (AYRILAN)")
                {
                    var form = (FrmPersonelListesiAyrilan)Application.OpenForms["FrmPersonelListesiAyrilan"];
                    if (form != null)
                    {
                        form.YenilecenekVeri();
                    }
                }
                if (baslik == "UÇAK/OTOBÜS BİLETİ GÖRÜNTÜLE")
                {
                    var form = (FrmUcakOtobusBiletiIzleme)Application.OpenForms["FrmUcakOtobusBiletiIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "UÇAK/OTOBÜS BİLETİ")
                {
                    var form = (FrmUcakOtobusBileti)Application.OpenForms["FrmUcakOtobusBileti"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "ŞEHİR İÇİ GÖREV")
                {
                    var form = (FrmSehirIcıGorev)Application.OpenForms["FrmSehirIcıGorev"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "YURT İÇİ GÖREV")
                {
                    var form = (FrmYurtİciGorev)Application.OpenForms["FrmYurtİciGorev"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "PERSONEL İZİN")
                {
                    var form = (FrmIzin)Application.OpenForms["FrmIzin"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "PERSONEL İZİN GÖRÜNTÜLE")
                {
                    var form = (FrmIzinIzleme)Application.OpenForms["FrmIzinIzleme"];
                    if (form != null)
                    {
                        form.DtgIzinList();
                    }
                }
                if (baslik == "KONAKLAMA")
                {
                    var form = (FrmKonaklama)Application.OpenForms["FrmKonaklama"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "KONAKLAMA GÖRÜNTÜLE")
                {
                    var form = (FrmKonaklamaIzleme)Application.OpenForms["FrmKonaklamaIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "ŞEHİR İÇİ GÖREV GÖRÜNTÜLE")
                {
                    var form = (FrmSehirIciGorevIzleme)Application.OpenForms["FrmSehirIciGorevIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "YURT İÇİ GÖREV GÖRÜNTÜLE")
                {
                    var form = (FrmYurtIciGorevIzleme)Application.OpenForms["FrmYurtIciGorevIzleme"];
                    if (form != null)
                    {
                        form.YenilecekVeriler();
                    }
                }
                if (baslik == "ARAÇ KAYDET")
                {
                    var form = (FrmAracKaydet)Application.OpenForms["FrmAracKaydet"];
                    if (form != null)
                    {
                        form.YenilecekVeriler();
                    }
                }
                if (baslik == "ARAÇ TAHSİS BİLGİLERİ")
                {
                    var form = (FrmAracTahsisBilgileri)Application.OpenForms["FrmAracTahsisBilgileri"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "DURAN VARLIK KAYIT")
                {
                    var form = (DuranVarlik)Application.OpenForms["DuranVarlik"];
                    if (form != null)
                    {
                        form.IsAkisNo();
                    }
                }
                if (baslik == "DURAN VARLIK AKTARIM")
                {
                    var form = (FrmDuranVarlikAktarim)Application.OpenForms["FrmDuranVarlikAktarim"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "DURAN VARLIK TAKİP")
                {
                    var form = (FrmDuranVarlikTakip)Application.OpenForms["FrmDuranVarlikTakip"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "ARAÇ YAKIT BEYANI")
                {
                    var form = (FrmYakitBeyani)Application.OpenForms["FrmYakitBeyani"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "ARAÇ YAKIT BEYANI GÖRÜNTÜLE")
                {
                    var form = (FrmYakitBeyaniIzleme)Application.OpenForms["FrmYakitBeyaniIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "GELEN/GİDEN RESMİ YAZI İZLEME")
                {
                    var form = (FrmEvrekKayitIzleme)Application.OpenForms["FrmEvrekKayitIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "ARAÇ BAKIM KAYIT")
                {
                    var form = (FrmAracBakimKayit)Application.OpenForms["FrmAracBakimKayit"];
                    if (form != null)
                    {
                        form.IsAkisNo();
                    }
                }
                if (baslik == "ARAÇ BAKIM ONARIM İZLEME")
                {
                    var form = (FrmAracBakimKayitIzleme)Application.OpenForms["FrmAracBakimKayitIzleme"];
                    if (form != null)
                    {
                        form.Yenilenecekler();
                    }
                }
                if (baslik == "DV ZİMMET TAKİP")
                {
                    var form = (FrmDVZimmetTakibi)Application.OpenForms["FrmDVZimmetTakibi"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "ALT YÜKLENİCİ FİRMALAR")
                {
                    var form = (FrmAltYukleniciFirma)Application.OpenForms["FrmAltYukleniciFirma"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "SAT OLUŞTUR")
                {
                    var form = (FrmSatOlustur2)Application.OpenForms["FrmSatOlustur2"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "TEKLİF ALINACAK SAT")
                {
                    var form = (FrmTeklifAlinacakSat)Application.OpenForms["FrmTeklifAlinacakSat"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "SAT ONAY")
                {
                    var form = (FrmSatOnay)Application.OpenForms["FrmSatOnay"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "SAT BAŞLATMA ONAYI")
                {
                    var form = (FrmSatBaslatmaOnayi)Application.OpenForms["FrmSatBaslatmaOnayi"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "SAT TAMAMLAMA")
                {
                    var form = (FrmSatTamamlama)Application.OpenForms["FrmSatTamamlama"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "TEDARİKÇİ FİRMA BİLGİLERİ")
                {
                    var form = (FrmTedarikciFirmaBilgileri)Application.OpenForms["FrmTedarikciFirmaBilgileri"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "DEVAM EDEN SATLAR")
                {
                    var form = (FrmDevamEdenSat)Application.OpenForms["FrmDevamEdenSat"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "DEVAM EDEN SATLAR")
                {
                    var form = (FrmDevamEdenSat)Application.OpenForms["FrmDevamEdenSat"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "REDDEDİLEN SATLAR")
                {
                    var form = (FrmReddedilenSatlar)Application.OpenForms["FrmReddedilenSatlar"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "TEKLİFSİZ SAT")
                {
                    var form = (FrmTeklifsizSat)Application.OpenForms["FrmTeklifsizSat"];
                    if (form != null)
                    {
                        form.YenilecekVeri();
                    }
                }
                if (baslik == "ZİYARETÇİ KAYIT")
                {
                    var form = (FrmZiyaretciKayit)Application.OpenForms["FrmZiyaretciKayit"];
                    if (form != null)
                    {
                        form.YenilenecekVeriler();
                    }
                }
                if (baslik == "ZİYARETÇİ KAYIT İZLEME")
                {
                    var form = (FrmZiyaretciKayitIzleme)Application.OpenForms["FrmZiyaretciKayitIzleme"];
                    if (form != null)
                    {
                        form.Yenilenecekler();
                    }
                }
                if (baslik == "ARŞİV İZLEME")
                {
                    var form = (FrmArsivIzleme)Application.OpenForms["FrmArsivIzleme"];
                    if (form != null)
                    {
                        form.DtgIzinList();
                    }
                }
                if (baslik == "YAKIT FİRMA DÖKÜMLERİ İZLEME")
                {
                    var form = (FrmYakitDokumIzleme)Application.OpenForms["FrmYakitDokumIzleme"];
                    if (form != null)
                    {
                        form.YenilenecekVeri();
                    }
                }
                if (baslik == "İŞÇİLİK İZLEME")
                {
                    var form = (FrmIscilikIzleme)Application.OpenForms["FrmIscilikIzleme"];
                    if (form != null)
                    {
                        form.Yenileneckler();
                    }
                }
                if (baslik == "DEVAM EDEN ARIZALAR (ATÖLYE)")
                {
                    var form = (FrmBOAtolyeDevamEdenler)Application.OpenForms["FrmBOAtolyeDevamEdenler"];
                    if (form != null)
                    {
                        form.Yenilenecekler();
                    }
                }
                if (baslik == "TAMAMLANAN ARIZALAR (ATÖLYE)")
                {
                    var form = (FrmBOAtolyeTamamlananlar)Application.OpenForms["FrmBOAtolyeTamamlananlar"];
                    if (form != null)
                    {
                        form.Yenilenecekler();
                    }
                }
                if (baslik == "ARAÇ KM İZLEME")
                {
                    var form = (FrmAracKmIzleme)Application.OpenForms["FrmAracKmIzleme"];
                    if (form != null)
                    {
                        form.Yenilenecekler();
                    }
                }
                if (baslik == "DEVAM EDEN ARIZALAR (ATÖLYE)")
                {
                    var form = (FrmBOAtolyeDevamEdenler)Application.OpenForms["FrmBOAtolyeDevamEdenler"];
                    if (form != null)
                    {
                        form.Yenilenecekler();
                    }
                }
                if (baslik == "AÇIK ARIZALAR")
                {
                    var form = (FrmArizaDevamEden)Application.OpenForms["FrmArizaDevamEden"];
                    if (form != null)
                    {
                        form.Yenilenecekler();
                    }
                }
                if (baslik == "TAMAMLANAN ARIZALAR")
                {
                    var form = (FrmArizaKayitlariKapatilan)Application.OpenForms["FrmArizaKayitlariKapatilan"];
                    if (form != null)
                    {
                        form.Yenilenecekler();
                    }
                }
                if (baslik == "ARAÇ TALEP İZLEME")
                {
                    var form = (FrmAracTalepIzleme)Application.OpenForms["FrmAracTalepIzleme"];
                    if (form != null)
                    {
                        form.Yenilenecekler();
                    }
                }
                if (baslik == "Firma Servis Formu Kayıt İzleme")
                {
                    var form = (FrmServisTalepleriIzleme)Application.OpenForms["FrmServisTalepleriIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "ARIZA KAYITLARI")
                {
                    var form = (FrmArizaDevamEden)Application.OpenForms["FrmArizaDevamEden"];
                    if (form != null)
                    {
                        form.Yenilenecekler();
                    }
                }
                if (baslik == "ARIZA KAYITLARI")
                {
                    var form = (FrmArizaKayitlarics)Application.OpenForms["FrmArizaKayitlarics"];
                    if (form != null)
                    {
                        form.ArizaKayitlari();
                    }
                }
                if (baslik == "MİF İZLEME")
                {
                    var form = (FrmTalepIzleme)Application.OpenForms["FrmTalepIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }

                if (baslik == "BÖLGE KAYITLARI")
                {
                    var form = (FrmBolgeKayitIzleme)Application.OpenForms["FrmBolgeKayitIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "MİF ONAY")
                {
                    var form = (FrmMifOnay)Application.OpenForms["FrmMifOnay"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "DTF İZLEME")
                {
                    var form = (FrmDtfIzleme)Application.OpenForms["FrmDtfIzleme"];
                    if (form != null)
                    {
                        form.Yenilenecekler();
                    }
                }

                if (baslik == "MALZEME HAZIRLAMA")
                {
                    var form = (FrmMalzemeHazirlama)Application.OpenForms["FrmMalzemeHazirlama"];
                    if (form != null)
                    {
                        form.Yenile();
                    }
                }
                if (baslik == "OKF İZLEME")
                {
                    var form = (FrmOkfIzleme)Application.OpenForms["FrmOkfIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }
                if (baslik == "KAYITLI MALZEMELERİ GÖRÜNTÜLE")
                {
                    var form = (FrmMalzemeKayitIzleme)Application.OpenForms["FrmMalzemeKayitIzleme"];
                    if (form != null)
                    {
                        form.DataDisplay();
                    }
                }

                if (baslik == "KONTROL")
                {
                    var form = (FrmBildirimler)Application.OpenForms["FrmBildirimler"];
                    if (form != null)
                    {
                        form.DuyuruEditList();
                    }
                }

                //if (baslik == "KONTROL")
                //{
                //    var form = (FrmArizaDevamEden)Application.OpenForms["FrmArizaDevamEden"];
                //    if (form != null)
                //    {
                //        form.DuyuruEditList();
                //    }
                //}
            }

        }

        private void oRGANİZSAYONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOrganizasyon frmOrganizasyon = new FrmOrganizasyon();
            frmOrganizasyon.ShowDialog();
        }

        private void oNAYEKRANLARIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOnayEkranlari Go = new FrmOnayEkranlari();
            Go.infos = infos;
            Go.FormBorderStyle = FormBorderStyle.None;
            Go.TopLevel = false;
            Go.AutoScroll = true;
            OpenTabPage("PageOnayEkranlari", "ONAY EKRANLARI", Go);
            Go.Show();
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


        private void TreeMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ////////////////////////////////////////////////BAKIM ONARIM/////////////////////////////////////////////////////////////////////
            ///
            PnlBildirim.Size = new Size(0, 0);
            tabAnasayfa.Size = new Size(1600, 955);


            if (e.Node.Text == "Bildirim Aç/Kapat")
            {
                FrmArizaAcmaCalisma Go = new FrmArizaAcmaCalisma();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaAc", "ARIZA AÇMA/ KAPATMA (SAHA)", Go);
                Go.Show();
            }

            if (e.Node.Text == "Firma Servis Formu Kayıt")
            {
                FrmServisFormuKayit Go = new FrmServisFormuKayit();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageServisFormuKayit", "SERVİS FORMU KAYIT", Go);
                Go.Show();
            }

            if (e.Node.Text == "İşçilik İzleme")
            {
                FrmIscilikIzleme Go = new FrmIscilikIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageIscilikIzleme", "İŞÇİLİK İZLEME", Go);
                Go.Show();
            }

            if (e.Node.Text == "Destek/İşçilik Girişi")
            {
                FrmDestekIscilikVeriGiris Go = new FrmDestekIscilikVeriGiris();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageIscilikGiris", "DESTEK VE İŞÇİLİK KAYIT", Go);
                Go.Show();
            }

            if (e.Node.Text == "Bildirim Güncelle")
            {
                FrmArizaDurumGuncelle Go = new FrmArizaDurumGuncelle();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaDurumGuncelle", "ARIZA DURUM GÜNCELLE", Go);
                Go.Show();
            }

            if (e.Node.Text == "Açık Bildirimler")
            {
                FrmArizaDevamEden Go = new FrmArizaDevamEden();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAcikArizalar", "AÇIK ARIZALAR", Go);
                Go.Show();
            }

            if (e.Node.Text == "Arıza Kayıtları")
            {
                FrmArizaKayitlarics Go = new FrmArizaKayitlarics();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaKayitlari", "ARIZA KAYITLARI", Go);
                Go.Show();
            }

            if (e.Node.Text == "Kapatılan Bildirimler")
            {
                FrmArizaKayitlariKapatilan Go = new FrmArizaKayitlariKapatilan();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageTamamlananArizalar", "TAMAMLANAN ARIZALAR", Go);
                Go.Show();
            }

            if (e.Node.Text == "Bildirim Onayı")
            {
                FrmBildirimOnayi Go = new FrmBildirimOnayi();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBildirimOnayi", "BİLDİRİM ONAYI", Go);
                Go.Show();
            }

            /*if (e.Node.Text == "Servis Talepleri")
            {
                FrmServisTalepleri Go = new FrmServisTalepleri();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageServisTalepleri", "SERVİS TALEPLERİ", Go);
                Go.Show();
            }*/

            if (e.Node.Text == "Firma Servis Formu Kayıt İzleme")
            {
                FrmServisTalepleriIzleme Go = new FrmServisTalepleriIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageServisFormuİzleme", "SERVİS FORMU İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Text == "Firma Servis Formu Kayıt")
            {
                FrmServisFormuKayit Go = new FrmServisFormuKayit();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageServisFormuKayit", "SERVİS FORMU KAYIT", Go);
                Go.Show();
            }

            /*if (e.Node.Text == "Bolge Yol Durumu")
            {
                FrmYolDurumlari Go = new FrmYolDurumlari();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYolDurumlari", "YOL DURUMLARI", Go);
                Go.Show();
            }*/

            if (e.Node.Text == "OKF Oluştur")
            {
                FrmOkfOlustrma Go = new FrmOkfOlustrma();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageOKFOlusturma", "OKF OLUŞTUR", Go);
                Go.Show();
            }
            if (e.Node.Text == "OKF İzleme")
            {
                FrmOkfIzleme Go = new FrmOkfIzleme();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageOKFIzleme", "OKF İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Text == "DTF Oluştur")
            {
                FrmDTFOlustur Go = new FrmDTFOlustur();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDTFOlusturma", "DTF OLUŞTUR", Go);
                Go.Show();
            }

            if (e.Node.Text == "DTF İzleme")
            {
                FrmDtfIzleme Go = new FrmDtfIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDTFIzleme", "DTF İZLEME", Go);
                Go.Show();
            }

            if (e.Node.Text == "OKF Kontrol")
            {
                FrmOkfKontrol Go = new FrmOkfKontrol();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageOkfOlustur", "OKF KONTROL", Go);
                Go.Show();
            }


            if (e.Node.Text == "Arıza Kaydı Oluştur")
            {
                FrmArizaKayitOlusturSaha Go = new FrmArizaKayitOlusturSaha();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaKaydiOlusturSaha", "ARIZA KAYDI OLUŞTUR", Go);
                Go.Show();
            }

            /////////////////////////////////////////////////BAKIM ONARIM ATEOLYE//////////////////////////////////////////////////////////////

            if (e.Node.Text == "Atölye Bildirim Oluştur")
            {
                FrmBOAtolye Go = new FrmBOAtolye();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaAcmaAtolye", "ARIZA AÇMA (ATÖLYE)", Go);
                Go.Show();
            }
            if (e.Node.Text == "Atölye Bildirim Güncelle")
            {
                FrmBOAtolyeGuncelleme Go = new FrmBOAtolyeGuncelleme();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaAcmaAtolyeGuncelle", "ARIZA GÜNCELLEME (ATÖLYE)", Go);
                Go.Show();
            }
            if (e.Node.Text == "Bölge ve Ekipman Kayıt")
            {
                FrmBolgeler Go = new FrmBolgeler();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBolgeler", "BÖLGE KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Text == "Bölge Kayıtları")
            {
                FrmBolgeKayitIzleme Go = new FrmBolgeKayitIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBolgeKayitIzleme", "BÖLGE KAYITLARI", Go);
                Go.Show();
            }

            if (e.Node.Text == "Atölye Açık Bildirimler")
            {
                FrmBOAtolyeDevamEdenler Go = new FrmBOAtolyeDevamEdenler();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBODevamEdenler", "DEVAM EDEN ARIZALAR (ATÖLYE)", Go);
                Go.Show();
            }

            if (e.Node.Text == "Atölye Bildirim Kapat")
            {
                FrmBOAtolyeKapatma Go = new FrmBOAtolyeKapatma();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAtolyeKapatma", "ARIZA KAPATMA (ATÖLYE)", Go);
                Go.Show();
            }
            if (e.Node.Text == "Atölye Kapatılan Bildirimler")
            {
                FrmBOAtolyeTamamlananlar Go = new FrmBOAtolyeTamamlananlar();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBOTamamlananlar", "TAMAMLANAN ARIZALAR (ATÖLYE)", Go);
                Go.Show();
            }


            /////////////////////////////////////////////////SATIN ALMA////////////////////////////////////////////////////////////////////////
            if (e.Node.Text == "SAT Oluştur")
            {
                FrmSatTalebi Go = new FrmSatTalebi();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatTalebi", "SAT OLUŞTUR", Go);
                Go.Show();

                //FrmSatOlustur2 Go = new FrmSatOlustur2();
                //Go.infos = infos;
                //Go.FormBorderStyle = FormBorderStyle.None;
                //Go.TopLevel = false;
                //Go.AutoScroll = true;
                //OpenTabPage("PageSatOlustur2", "SAT OLUŞTUR", Go);
                //Go.Show();
            }
            if (e.Node.Text == "SAT Teklif Alınacak")
            {
                FrmTeklifAlinacakSat Go = new FrmTeklifAlinacakSat();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageTeklifAlinacak", "TEKLİF ALINACAK SAT", Go);
                Go.Show();
            }
            if (e.Node.Text == "SAT Onay")
            {
                FrmSatOnay Go = new FrmSatOnay();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatOnay", "SAT ONAY", Go);
                Go.Show();
            }

            if (e.Node.Text == "SAT Kontrol")
            {
                FrmSatControl Go = new FrmSatControl();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatKontrol", "SAT KONTROL", Go);
                Go.Show();

                //FrmSatOnOnay Go = new FrmSatOnOnay();
                //Go.infos = infos;
                //Go.FormBorderStyle = FormBorderStyle.None;
                //Go.TopLevel = false;
                //Go.AutoScroll = true;
                //OpenTabPage("PageSatOnOnay", "SAT ÖN ONAY", Go);
                //Go.Show();
            }
            if (e.Node.Text == "SAT Harcaması Yapılan")
            {
                FrmHarcamasiYapilanSat Go = new FrmHarcamasiYapilanSat();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageHarcamasıYapilan", "HARCAMASI YAPILAN SAT", Go);
                Go.Show();

                //FrmSatBaslatmaOnayi Go = new FrmSatBaslatmaOnayi();
                //Go.infos = infos;
                //Go.FormBorderStyle = FormBorderStyle.None;
                //Go.TopLevel = false;
                //Go.AutoScroll = true;
                //OpenTabPage("PageSatBaslatma", "SAT BAŞLATMA ONAYI", Go);
                //Go.Show();
            }
            if (e.Node.Text == "SAT Tamamla")
            {
                FrmSatTamamlama Go = new FrmSatTamamlama();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatTamamlama", "SAT TAMAMLAMA", Go);
                Go.Show();
            }
            if (e.Node.Text == "SAT Güncelle")
            {
                FrmSATGuncelle Go = new FrmSATGuncelle();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatGuncelle", "SAT GÜNCELLE", Go);
                Go.Show();
            }
            if (e.Node.Text == "Tamamlanan SAT")
            {
                FrmTamamlananSat Go = new FrmTamamlananSat();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatTamamlanan", "TAMAMLANAN SAT", Go);
                Go.Show();

            }
            if (e.Node.Text == "Tedarikçi Firma Bilgileri")
            {
                FrmTedarikciFirmaBilgileri Go = new FrmTedarikciFirmaBilgileri();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageTedarikciFirma", "TEDARİKÇİ FİRMA BİLGİLERİ", Go);
                Go.Show();
            }
            if (e.Node.Text == "Alt Yüklenici Firma Bilgileri")
            {
                FrmAltYukleniciFirma Go = new FrmAltYukleniciFirma();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAltYüklenici", "ALT YÜKLENİCİ FİRMALAR", Go);
                Go.Show();
            }
            if (e.Node.Text == "Devam Eden SAT")
            {
                object[] infos1 = satinAlinacakMalManager.Malzemeler("1");
                FrmDevamEdenSat Go = new FrmDevamEdenSat();
                Go.infos = infos;

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDevamEdenSat", "DEVAM EDEN SATLAR", Go);
                Go.Show();
            }
            if (e.Node.Text == "Ret Edilen SAT")
            {
                FrmReddedilenSatlar Go = new FrmReddedilenSatlar();
                Go.infos = infos;

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageReddedilen", "REDDEDİLEN SATLAR", Go);
                Go.Show();
            }
            if (e.Node.Text == "SAT Teklifsiz")
            {
                FrmTeklifsizSat Go = new FrmTeklifsizSat();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatMalzemeler", "TEKLİFSİZ SAT", Go);
                Go.Show();
            }
            if (e.Node.Text == "Aylık Bütçe Kapatma (Yakıt)")
            {
                FrmYakitButceKapatma Go = new FrmYakitButceKapatma();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageButceKapat", "AYLIK BÜTÇE KAPATMA (YAKIT)", Go);
                Go.Show();
            }

            /////////////////////////////////////////////////İDARİ İŞLER////////////////////////////////////////////////////////////////////

            if (e.Node.Text == "Personel Giriş-Çıkış")
            {
                object[] infos1 = satinAlinacakMalManager.Malzemeler("1");
                FrmPersonelKayit Go = new FrmPersonelKayit();
                Go.infos = infos;
                Go.sayfa = "PERSONEL KAYIT";
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PagePersonelKayit", "PERSONEL KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Text == "Personel Listesi (Çalışan)")
            {
                object[] infos1 = satinAlinacakMalManager.Malzemeler("1");
                FrmPersonelListesi Go = new FrmPersonelListesi();
                Go.infos = infos;

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PagePersonelListesi", "PERSONEL LİSTESİ", Go);
                Go.Show();
            }

            if (e.Node.Text == "Personel Listesi (İşten Ayrılan)")
            {
                FrmPersonelListesiAyrilan Go = new FrmPersonelListesiAyrilan();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAyrilanListesi", "PERSONEL LİSTESİ (AYRILAN)", Go);
                Go.Show();
            }
            if (e.Node.Text == "Demirbaş Kayıt")
            {
                DuranVarlik Go = new DuranVarlik();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlik", "DEMİRBAŞ KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Text == "Zimmet Aktarım")
            {
                FrmDuranVarlikAktarim Go = new FrmDuranVarlikAktarim();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlikAktarim", "ZİMMET AKTARIM", Go);
                Go.Show();
            }
            if (e.Node.Text == "Demirbaş İzleme")
            {
                FrmDuranVarlikTakip Go = new FrmDuranVarlikTakip();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlikTakip", "DEMİRBAŞ İZLEME", Go);
                Go.Show();
            }

            /*if (e.Node.Text == "DuranVarlikGuncelleme")
            {
                FrmDuranVarlikGuncelleme Go = new FrmDuranVarlikGuncelleme();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlikGuncelleme", "DURAN VARLIK GÜNCELLE", Go);
                Go.Show();
            }*/

            if (e.Node.Text == "Uçak ve Otobüs Bileti")
            {
                FrmUcakOtobusBileti Go = new FrmUcakOtobusBileti();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageUcakOtobus", "UÇAK/OTOBÜS BİLETİ", Go);
                Go.Show();
            }
            if (e.Node.Text == "Uçak ve Otobüs Bileti İzleme")
            {
                FrmUcakOtobusBiletiIzleme Go = new FrmUcakOtobusBiletiIzleme();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageUcakOtobusIzleme", "UÇAK/OTOBÜS BİLETİ GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Text == "Şehir İçi Görev")
            {
                FrmSehirIcıGorev Go = new FrmSehirIcıGorev();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSehirIcıGorev", "ŞEHİR İÇİ GÖREV", Go);
                Go.Show();
            }
            if (e.Node.Text == "Yurt İçi Görev")
            {
                FrmYurtİciGorev Go = new FrmYurtİciGorev();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                Go.infos = infos;
                OpenTabPage("PageYurtIcıGorev", "YURT İÇİ GÖREV", Go);
                Go.Show();
            }
            if (e.Node.Text == "İzin")
            {
                FrmIzin Go = new FrmIzin();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageIzin", "PERSONEL İZİN", Go);
                Go.Show();
            }
            if (e.Node.Text == "İzin İzleme")
            {
                FrmIzinIzleme Go = new FrmIzinIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageIzinIzleme", "PERSONEL İZİN GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Text == "Konaklama")
            {
                FrmKonaklama Go = new FrmKonaklama();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageKonaklama", "KONAKLAMA", Go);
                Go.Show();
            }
            if (e.Node.Text == "Konaklama İzleme")
            {
                FrmKonaklamaIzleme Go = new FrmKonaklamaIzleme();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageKonaklamaIzleme", "KONAKLAMA GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Text == "Şehir İçi Görev İzleme")
            {
                FrmSehirIciGorevIzleme Go = new FrmSehirIciGorevIzleme();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSehirIzleme", "ŞEHİR İÇİ GÖREV GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Text == "Yurt İçi Görev İzleme")
            {
                FrmYurtIciGorevIzleme Go = new FrmYurtIciGorevIzleme();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYurtIciGorevIzleme", "YURT İÇİ GÖREV GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Text == "Araç Tahsis Kayıt")
            {
                FrmAracKaydet Go = new FrmAracKaydet();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAracKaydet", "ARAÇ KAYDET", Go);
                Go.Show();
            }
            if (e.Node.Text == "Araç Tahsis Bilgileri")
            {
                FrmAracTahsisBilgileri Go = new FrmAracTahsisBilgileri();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAracTahsisBilgileri", "ARAÇ TAHSİS BİLGİLERİ", Go);
                Go.Show();
            }
            if (e.Node.Text == "Araç Yakıt Beyanı")
            {
                FrmYakitBeyani Go = new FrmYakitBeyani();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYakitBeyani", "ARAÇ YAKIT BEYANI", Go);
                Go.Show();
            }
            if (e.Node.Text == "Araç Yakıt Beyan İzleme")
            {
                FrmYakitBeyaniIzleme Go = new FrmYakitBeyaniIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYakitIzleme", "ARAÇ YAKIT BEYANI GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Text == "Evrak Kayıt")
            {
                FrmEvrakKayit Go = new FrmEvrakKayit();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageEvrakKayit", "EVRAK KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Text == "Gelen Giden Resmi Yazı İzleme")
            {
                FrmEvrekKayitIzleme Go = new FrmEvrekKayitIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageEvrakKayitIzleme", "GELEN/GİDEN RESMİ YAZI İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Text == "Araç Bakım Kayıt")
            {
                FrmAracBakimKayit Go = new FrmAracBakimKayit();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBakimKayit", "ARAÇ BAKIM KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Text == "Zimmet Takip")
            {
                //frmWait.Show();
                FrmDVZimmetTakibi Go = new FrmDVZimmetTakibi();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageZimmetTakibi", "ZİMMET TAKİP", Go);
                Go.Show();
                //frmWait.Close();
            }
            if (e.Node.Text == "Araç Bakım Onarım İzleme")
            {
                FrmAracBakimKayitIzleme Go = new FrmAracBakimKayitIzleme();

                Go.FormBorderStyle = FormBorderStyle.None;

                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBakimKayitIzleme", "ARAÇ BAKIM ONARIM İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Text == "Envanter Arıza Kayıt")
            {
                FrmDuranVarlikArizaKayit Go = new FrmDuranVarlikArizaKayit();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlikArizaKayit", "ENVANTER ARIZA KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Text == "Kalibrasyon Kayit")
            {
                FrmDvKalibrasyonKayit Go = new FrmDvKalibrasyonKayit();
                Go.FormBorderStyle = FormBorderStyle.None;

                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDvKalibrasyonKayit", "KALİBRASYON KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Text == "Ziyaretçi Kayıt")
            {
                FrmZiyaretciKayit Go = new FrmZiyaretciKayit();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageZiyaretci", "ZİYARETÇİ KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Text == "Ziyaretçi Kayıt İzleme")
            {
                FrmZiyaretciKayitIzleme Go = new FrmZiyaretciKayitIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageZiyaretciIzleme", "ZİYARETÇİ KAYIT İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Text == "Tutanak")
            {
                FrmArsiv Go = new FrmArsiv();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArsiv", "ARŞİV", Go);
                Go.Show();
            }
            if (e.Node.Text == "Arşiv İzleme")
            {
                FrmArsivIzleme Go = new FrmArsivIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArsivIzleme", "ARŞİV İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Text == "Yakıt Firma Dökümleri")
            {
                FrmYakitDokum Go = new FrmYakitDokum();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYakitDokumleri", "YAKIT FİRMA DÖKÜMLERİ", Go);
                Go.Show();
            }
            if (e.Node.Text == "Yakıt Alım Dökümleri İzleme")
            {
                FrmYakitDokumIzleme Go = new FrmYakitDokumIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYakitDokumIzleme", "YAKIT FİRMA DÖKÜMLERİ İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Text == "Araç Talep")
            {
                FrmAracTalep Go = new FrmAracTalep();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAracTalep", "ARAÇ TALEP", Go);
                Go.Show();
            }
            if (e.Node.Text == "Araç Kilometre")
            {
                FrmAracKm Go = new FrmAracKm();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAracKm", "ARAÇ KM", Go);
                Go.Show();
            }
            if (e.Node.Text == "Araç Kilomete İzleme")
            {
                FrmAracKmIzleme Go = new FrmAracKmIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAracKmIzleme", "ARAÇ KM İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Text == "HaftalikKontrol")
            {
                FrmArsivKontrolFormu Go = new FrmArsivKontrolFormu();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArsivKontrolFormu", "ARŞİV KONTROL FORMU", Go);
                Go.Show();
            }
            if (e.Node.Text == "Haftalık Kontrol Formları İzleme")
            {
                FrmArsivKontrolFormuIzleme Go = new FrmArsivKontrolFormuIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArsivKontrolFormuIzleme", "ARŞİV KONTROL FORMU İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Text == "Araç Talepleri İzleme")
            {
                FrmAracTalepIzleme Go = new FrmAracTalepIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAracTalepIzleme", "ARAÇ TALEP İZLEME", Go);
                Go.Show();
            }

            if (e.Node.Text == "Bölge Yol Durumu")
            {
                FrmYolDurumlari Go = new FrmYolDurumlari();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYolDurumlari", "BÖLGE YOL DURUMLARI", Go);
                Go.Show();
            }
            if (e.Node.Text == "Bölge Yol Durumu İzleme")
            {
                FrmYolDurumlariIzleme Go = new FrmYolDurumlariIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYolDurumlariIzleme", "BÖLGE YOL DURUMLARI İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Text == "Malzeme İstek Formu")
            {
                FrmGiysiTalep Go = new FrmGiysiTalep();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageTalep", "MİF", Go);
                Go.Show();
            }
            if (e.Node.Text == "Malzeme İstek Formu İzleme")
            {
                FrmTalepIzleme Go = new FrmTalepIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageMifIzleme", "MİF İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Text == "Haftalık Kontrol Formu")
            {
                FrmHaftalikControl Go = new FrmHaftalikControl();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageHaftalikControl", "HAFTALIK KONTROL FORMU", Go);
                Go.Show();
            }
            if (e.Node.Text == "Depo Kontrol")
            {
                FrmDepoKontrol Go = new FrmDepoKontrol();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDepoKontrol", "DESTEK DEPO KONTROL", Go);
                Go.Show();
            }


            /////////////////////////////////////////////////DÖKÜMAN YÖNETİM SİSTEMİ/////////////////////////////////////////////////////////

            if (e.Node.Text == "Doküman Ekle")
            {
                FrmDokumanEkle Go = new FrmDokumanEkle();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDokumanEkle", "DOKÜMAN EKLE", Go);
                Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "Standart Form Sorgula")
            {
                FrmStandartForm Go = new FrmStandartForm();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageStandartFormSorgula", "STANDART FORM SORGULA", Go);
                Go.Show();
            }
            if (e.Node.Text == "Doküman Sorgula")
            {
                FrmDokumanSorgula Go = new FrmDokumanSorgula();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDokumanSorgula", "DOKÜMAN SORGULA", Go);
                Go.Show();
            }
            if (e.Node.Text == "Standart Form Ekle")
            {
                FrmStandartFormEkle Go = new FrmStandartFormEkle();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageFormEkle", "STANDART FORM EKLE", Go);
                Go.infos = infos;
                Go.Show();
            }

            /////////////////////////////////////////////////GEÇİCİ KABUL VE AMBAR/////////////////////////////////////////////////////////

            if (e.Node.Text == "Malzeme Kayıt")
            {
                FrmMalzemeKayit Go = new FrmMalzemeKayit();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageMalzemeKayit", "MALZEME KAYIT", Go);
                Go.infos = infos;
                Go.Show();
            }
            /*if (e.Node.Text == "Stok Giriş/Çıkış")
            {
                FrmStokGirisCikis Go = new FrmStokGirisCikis();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageStokGirisCikis", "STOK GİRİŞ/ÇIKIŞ", Go);
                Go.infos = infos;
                Go.Show();
            }*/
            if (e.Node.Text == "Stok Giriş/Çıkış")
            {
                FrmGirisCikis Go = new FrmGirisCikis();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageGirisCikis", "STOK GİRİŞ/ÇIKIŞ", Go);
                Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "Barkod Oluştur")
            {
                FrmDepoDusum Go = new FrmDepoDusum();
                Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "Depo Stok Görüntüle İzleme")
            {
                FrmStokGoruntule Go = new FrmStokGoruntule();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageStokGoruntule", "STOK GÖRÜNTÜLE", Go);
                Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "Depo Kayıtlı Malzemeler")
            {
                FrmMalzemeKayitIzleme Go = new FrmMalzemeKayitIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageKayitliMalzemeler", "KAYITLI MALZEMELERİ GÖRÜNTÜLE", Go);
                Go.infos = infos;
                Go.Show();
            }

            if (e.Node.Text == "Depo Hareketleri İzleme")
            {
                FrmDepoHareketleri Go = new FrmDepoHareketleri();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDepoHaraketleri", "DEPO HARKETLERİ", Go);
                //Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "Malzeme Hazırlama")
            {
                FrmMalzemeHazirlama Go = new FrmMalzemeHazirlama();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageMalzemeHazirmala", "MALZEME HAZIRLAMA", Go);
                Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "Depoya İade Edilecek Malzemeler")
            {
                FrmBolgedenGelecekMlz Go = new FrmBolgedenGelecekMlz();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageGelecekMalzeme", "DEPOYA İADE EDİLECEK MALZEMELER", Go);
                Go.infos = infos;
                Go.Show();
            }

            if (e.Node.Text == "Bölgeden İade Gelen Malzeme")
            {
                FrmBolgedenIadeGelenMlz Go = new FrmBolgedenIadeGelenMlz();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageGelenMalzeme", "BÖLGEDEN İADE GELEN MALZEMELER", Go);
                Go.infos = infos;
                Go.Show();
            }

            if (e.Node.Text == "Depo Bilgileri Kayıt")
            {
                FrmDepoAdresKayit Go = new FrmDepoAdresKayit();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDepolar", "DEPO BİLGİLERİ KAYIT", Go);
                Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "Van Depoya İade Edilecek Malzemeler")
            {
                FrmDepoyaIadeBolge Go = new FrmDepoyaIadeBolge();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDepoIadeEdilecekler", "VAN DEPOYA İADE EDİLECEK MALZEMELER", Go);
                Go.infos = infos;
                Go.Show();
            }

            if (e.Node.Text == "Ambar Veri İzleme")
            {
                FrmIzlemeAmbar Go = new FrmIzlemeAmbar();
                Go.ShowDialog();
            }

            /////////////////////////////////////////////////DESTEK DEPO///////////////////////////////////////////////////////////////////

            if (e.Node.Text == "Malzeme Kayıt Destek Depo")
            {
                FrmMalzemeKayitDestekDepo Go = new FrmMalzemeKayitDestekDepo();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDesteDepoMalzemeKayit", "DESTEK DEPO MALZEME KAYIT", Go);
                //Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "Destek Depo Stok Giriş/Çıkış")
            {
                FrmDDStokGirisCikis Go = new FrmDDStokGirisCikis();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDepoMlzHazirlama", "DESTEK DEPO MALZEME HAZIRLAMA", Go);
                Go.infos = infos;
                Go.Show();
            }

            /////////////////////////////////////////////////EĞİTİM///////////////////////////////////////////////////////////////////

            if (e.Node.Text == "Eğitim Planı Oluştur")
            {
                FrmEgitimPlanıOlustur Go = new FrmEgitimPlanıOlustur();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageEgitimPlaniOlustur", "EĞİTİM PLANI OLUŞTUR", Go);
                //Go.infos = infos;
                Go.Show();
            }

            /////////////////////////////////////////////////RAPORLAMALAR/////////////////////////////////////////////////////////////
            if (e.Node.Text == "SAT Raporlama")
            {
                FrmSatRaporu Go = new FrmSatRaporu();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatRaporlama", "SAT RAPORLAMA", Go);
                Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "SAT Raporu İzleme")
            {
                FrmSatRaporuIzleme Go = new FrmSatRaporuIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatRaporuIzleme", "SAT RAPORLAMA İZLEME", Go);
                //Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "Arıza Raporları")
            {
                FrmArizaRaporlama Go = new FrmArizaRaporlama();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaRapor", "ARIZA RAPORLARI", Go);
                //Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "OTS Bakım Onarım Performans")
            {
                OTSBOPerformans Go = new OTSBOPerformans();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBOPerformans", "OTS B/O PERFORMANS", Go);
                //Go.infos = infos;
                Go.Show();
            }

            ///////////////////////////////////////////YERLEŞKELER/////////////////////////////////////////////////////////

            if (e.Node.Text == "Yerleşke Kayıt")
            {
                FrmYerleskeKayit Go = new FrmYerleskeKayit();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYerleskeler", "YERLEŞKE KAYIT", Go);
                //Go.infos = infos;
                Go.Show();
            }

            if (e.Node.Text == "Yerleşkeler İzleme")
            {
                FrmYerleskeIzleme Go = new FrmYerleskeIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYerleskeIzleme", "YERLEŞKE İZLEME", Go);
                //Go.infos = infos;
                Go.Show();
            }

            if (e.Node.Text == "Yerleşke Gider Kayıt")
            {
                FrmYerleskeGideriKayit Go = new FrmYerleskeGideriKayit();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYerleskeGideriKayit", "YERLEŞKE GİDERİ KAYIT", Go);
                Go.infos = infos;
                Go.Show();
            }

            if (e.Node.Text == "Yerleşke Giderleri İzleme")
            {
                FrmYerleskeGiderKayitIzleme Go = new FrmYerleskeGiderKayitIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageGiderKayitIzleme", "YERLEŞKE GİDER KAYIT İZLEME", Go);
                //Go.infos = infos;
                Go.Show();
            }

            ///////////////////////////////////////////BÜTÇELER/////////////////////////////////////////////////////////

            if (e.Node.Text == "Bütçe Kayıt")
            {
                FrmButceKayit2 Go = new FrmButceKayit2();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageButceKayit", "BÜTÇE KAYIT", Go);
                //Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "Sipariş Oluştur")
            {
                FrmSiparisler Go = new FrmSiparisler();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSiparisler", "SİPARİŞLER", Go);
                //Go.infos = infos;
                //Go.sayfa = "SİPARİŞLER";
                Go.Show();
            }
            if (e.Node.Text == "Sipariş İzleme")
            {
                FrmSiparislerIzleme Go = new FrmSiparislerIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSiparisIzleme", "SİPARİŞLER İZLEME", Go);
                //Go.infos = infos;
                //Go.sayfa = "SİPARİŞLER";
                Go.Show();
            }

            if (e.Node.Text == "Proje Kasa")
            {
                FrmKasa Go = new FrmKasa();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageKasa", "PROJE KASA", Go);
                Go.infos = infos;
                Go.Show();
            }

            if (e.Node.Text == "Proje Kasa İzleme")
            {
                FrmKasaIzlemecs Go = new FrmKasaIzlemecs();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageKasaIzleme", "PROJE KASA İZLEME", Go);
                //Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "Bütçe İzleme")
            {
                FrmButceler Go = new FrmButceler();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageButceIzleme", "BÜTÇE İZLEME", Go);
                //Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "Genel Bütçe İzleme")
            {
                FrmGenelButceIzleme Go = new FrmGenelButceIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageGenelButce", "GENEL BÜTÇE İZLEME", Go);
                //Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Text == "Bütçe Kodu Düzenle")
            {
                FrmButceKoduKalemiDuzenle Go = new FrmButceKoduKalemiDuzenle();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageButceKoduDuzenle", "BÜTÇE KODLARI DÜZENLE", Go);
                //Go.infos = infos;
                Go.Show();
            }

        }

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    if (treeView2.SelectedNode.Tag != null)
            //    {
            //        if (treeView2.SelectedNode.Tag.ToString() == "Header")
            //        {
            //            contextTreeView.Close();
            //            string nodeName = treeView2.SelectedNode.Name;
            //        }
            //    }

            //    return;
            //}


            #region Left_Click
            ////////////////////////////////////////////////BAKIM ONARIM//////////////////////////////////////////////////////////////////////

            if (e.Node.Name == "Veri Kayit Arıza Acma")
            {
                FrmArizaAcmaCalisma Go = new FrmArizaAcmaCalisma();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaAc", "ARIZA AÇMA/ KAPATMA (SAHA)", Go);
                Go.Show();
            }
            if (e.Node.Name == "Firma Servis Formu Kayit")
            {
                FrmServisFormuKayit Go = new FrmServisFormuKayit();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageServisFormuKayit", "SERVİS FORMU KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "Musteri Bilgileri")
            {
                FrmMuseriBilgileri Go = new FrmMuseriBilgileri();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageMusteriBilgileri", "MÜŞTERİ BİLGİLERİ", Go);
                Go.Show();
            }
            if (e.Node.Name == "Destek Iscilik Izleme")
            {
                FrmIscilikIzleme Go = new FrmIscilikIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageIscilikIzleme", "İŞÇİLİK İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Name == "Iscilik Izleme")
            {
                FrmIscilikIzleme Go = new FrmIscilikIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageIscilikIzleme", "İŞÇİLİK İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Name == "Destek Iscilik")
            {
                FrmDestekIscilikVeriGiris Go = new FrmDestekIscilikVeriGiris();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageIscilikGiris", "DESTEK VE İŞÇİLİK KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "Veri Guncelleme")
            {
                FrmArizaDurumGuncelle Go = new FrmArizaDurumGuncelle();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaDurumGuncelle", "ARIZA DURUM GÜNCELLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Devam Eden Arıza")
            {
                FrmArizaDevamEden Go = new FrmArizaDevamEden();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAcikArizalar", "AÇIK ARIZALAR", Go);
                Go.Show();
            }
            if (e.Node.Name == "Tamamlanan Arıza")
            {
                FrmArizaKayitlariKapatilan Go = new FrmArizaKayitlariKapatilan();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageTamamlananArizalar", "TAMAMLANAN ARIZALAR", Go);
                Go.Show();
            }
            if (e.Node.Name == "Ariza Kayitlari")
            {
                FrmArizaKayitlarics Go = new FrmArizaKayitlarics();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaKayitlari", "ARIZA KAYITLARI", Go);
                Go.Show();
            }
            if (e.Node.Name == "Bildirim Onayi")
            {
                FrmBildirimOnayi Go = new FrmBildirimOnayi();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBildirimOnayi", "BİLDİRİM ONAYI", Go);
                Go.Show();
            }
            if (e.Node.Name == "Servis Talepleri")
            {
                FrmServisTalepleri Go = new FrmServisTalepleri();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageServisTalepleri", "SERVİS TALEPLERİ", Go);
                Go.Show();
            }
            if (e.Node.Name == "Firma Servis Formu")
            {
                FrmServisTalepleriIzleme Go = new FrmServisTalepleriIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageServisFormuİzleme", "SERVİS FORMU İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Name == "Bolge Yol Durumu")
            {
                FrmYolDurumlari Go = new FrmYolDurumlari();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYolDurumlari", "YOL DURUMLARI", Go);
                Go.Show();
            }
            if (e.Node.Name == "OKF Olusturma")
            {
                FrmOkfOlustrma Go = new FrmOkfOlustrma();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageOKFOlusturma", "OKF OLUŞTUR", Go);
                Go.Show();
            }
            if (e.Node.Name == "DTF Olusturma")
            {
                FrmDTFOlustur Go = new FrmDTFOlustur();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDTFOlusturma", "DTF OLUŞTUR", Go);
                Go.Show();
            }

            if (e.Node.Name == "DTF Izleme")
            {
                FrmDtfIzleme Go = new FrmDtfIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDTFIzleme", "DTF İZLEME", Go);
                Go.Show();
            }

            /////////////////////////////////////////////////BAKIM ONARIM ATEOLYE//////////////////////////////////////////////////////////////

            if (e.Node.Name == "Veri Kayit Atolye")
            {
                FrmBOAtolye Go = new FrmBOAtolye();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaAcmaAtolye", "ARIZA AÇMA (ATÖLYE)", Go);
                Go.Show();
            }
            if (e.Node.Name == "Veri Kayit Atolye Izleme")
            {
                FrmBOAtolyeGuncelleme Go = new FrmBOAtolyeGuncelleme();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaAcmaAtolyeGuncelle", "ARIZA GÜNCELLEME (ATÖLYE)", Go);
                Go.Show();
            }
            if (e.Node.Name == "BolgeKayit")
            {
                FrmBolgeler Go = new FrmBolgeler();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBolgeler", "BÖLGE KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "BolgeKayitIzleme")
            {
                FrmBolgeKayitIzleme Go = new FrmBolgeKayitIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBolgeKayitIzleme", "BÖLGE KAYIT İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Name == "Veri Kayit Atolye Guncelleme")
            {
                FrmBOAtolyeGuncelleme Go = new FrmBOAtolyeGuncelleme();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaAcmaAtolyeGuncelle", "BAKIM ONARIM GÜNCELLEME (ATÖLYE)", Go);
                Go.Show();
            }
            if (e.Node.Name == "Devam Eden Ariza Atolye")
            {
                FrmBOAtolyeDevamEdenler Go = new FrmBOAtolyeDevamEdenler();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBODevamEdenler", "DEVAM EDEN ARIZALAR (ATÖLYE)", Go);
                Go.Show();
            }

            if (e.Node.Name == "Veri Kayit Atolye Kapatma")
            {
                FrmBOAtolyeKapatma Go = new FrmBOAtolyeKapatma();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAtolyeKapatma", "ARIZA KAPATMA (ATÖLYE)", Go);
                Go.Show();
            }
            if (e.Node.Name == "Tamamlana Ariza Atolye")
            {
                FrmBOAtolyeTamamlananlar Go = new FrmBOAtolyeTamamlananlar();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBOTamamlananlar", "TAMAMLANAN ARIZALAR (ATÖLYE)", Go);
                Go.Show();
            }


            /////////////////////////////////////////////////SATIN ALMA////////////////////////////////////////////////////////////////////////
            if (e.Node.Name == "satolustur")
            {
                FrmSatOlustur2 Go = new FrmSatOlustur2();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatOlustur2", "SAT OLUŞTUR", Go);
                Go.Show();
            }
            if (e.Node.Name == "TeklifAlınacakSat")
            {
                FrmTeklifAlinacakSat Go = new FrmTeklifAlinacakSat();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageTeklifAlinacak", "TEKLİF ALINACAK SAT", Go);
                Go.Show();
            }
            if (e.Node.Name == "SatOnay")
            {
                FrmSatOnay Go = new FrmSatOnay();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatOnay", "SAT ONAY", Go);
                Go.Show();
            }
            if (e.Node.Name == "SatOnOnay")
            {
                /*FrmSatOnOnay Go = new FrmSatOnOnay();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatOnOnay", "SAT ÖN ONAY", Go);
                Go.Show();*/
            }
            if (e.Node.Name == "Sat Baslatma Onayi")
            {
                FrmSatBaslatmaOnayi Go = new FrmSatBaslatmaOnayi();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatBaslatma", "SAT BAŞLATMA ONAYI", Go);
                Go.Show();
            }
            if (e.Node.Name == "Sat Tamamlama")
            {
                FrmSatTamamlama Go = new FrmSatTamamlama();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatTamamlama", "SAT TAMAMLAMA", Go);
                Go.Show();
            }
            if (e.Node.Name == "Sat Guncelle")
            {
                FrmSATGuncelle Go = new FrmSATGuncelle();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatGuncelle", "SAT GÜNCELLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Tamamlanan Sat")
            {
                FrmTamamlananSat Go = new FrmTamamlananSat();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatTamamlanan", "TAMAMLANAN SAT", Go);
                Go.Show();

            }
            if (e.Node.Name == "Tedarikci Firma")
            {
                FrmTedarikciFirmaBilgileri Go = new FrmTedarikciFirmaBilgileri();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageTedarikciFirma", "TEDARİKÇİ FİRMA BİLGİLERİ", Go);
                Go.Show();
            }
            if (e.Node.Name == "Alt Yuklenici Firma")
            {
                FrmAltYukleniciFirma Go = new FrmAltYukleniciFirma();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAltYüklenici", "ALT YÜKLENİCİ FİRMALAR", Go);
                Go.Show();
            }
            if (e.Node.Name == "devamedensat")
            {
                object[] infos1 = satinAlinacakMalManager.Malzemeler("1");
                FrmDevamEdenSat Go = new FrmDevamEdenSat();
                Go.infos = infos;

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDevamEdenSat", "DEVAM EDEN SATLAR", Go);
                Go.Show();
            }
            if (e.Node.Name == "RedEdilenSat")
            {
                FrmReddedilenSatlar Go = new FrmReddedilenSatlar();
                Go.infos = infos;

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageReddedilen", "REDDEDİLEN SATLAR", Go);
                Go.Show();
            }
            if (e.Node.Name == "Satın Alınacak Malzemeler")
            {
                FrmTeklifsizSat Go = new FrmTeklifsizSat();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatMalzemeler", "TEKLİFSİZ SAT", Go);
                Go.Show();
            }
            if (e.Node.Name == "AylikButceKapatmaYakit")
            {
                FrmYakitButceKapatma Go = new FrmYakitButceKapatma();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageButceKapat", "AYLIK BÜTÇE KAPATMA (YAKIT)", Go);
                Go.Show();
            }

            /////////////////////////////////////////////////İDARİ İŞLER////////////////////////////////////////////////////////////////////

            if (e.Node.Name == "PersonelKayit")
            {
                object[] infos1 = satinAlinacakMalManager.Malzemeler("1");
                FrmPersonelKayit Go = new FrmPersonelKayit();
                Go.infos = infos;
                Go.sayfa = "PERSONEL KAYIT";
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PagePersonelKayit", "PERSONEL KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "PersonelListesi")
            {
                object[] infos1 = satinAlinacakMalManager.Malzemeler("1");
                FrmPersonelListesi Go = new FrmPersonelListesi();
                Go.infos = infos;

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PagePersonelListesi", "PERSONEL LİSTESİ", Go);
                Go.Show();
            }

            if (e.Node.Name == "PersonelListesiAyrilan")
            {
                FrmPersonelListesiAyrilan Go = new FrmPersonelListesiAyrilan();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAyrilanListesi", "PERSONEL LİSTESİ (AYRILAN)", Go);
                Go.Show();
            }
            if (e.Node.Name == "Demirbaş Kayıt")
            {
                DuranVarlik Go = new DuranVarlik();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlik", "DURAN VARLIK KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "Zimmet Aktarım")
            {
                FrmDuranVarlikAktarim Go = new FrmDuranVarlikAktarim();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlikAktarim", "DURAN VARLIK AKTARIM", Go);
                Go.Show();
            }
            if (e.Node.Name == "DuranVarlikTakip")
            {
                FrmDuranVarlikTakip Go = new FrmDuranVarlikTakip();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlikTakip", "DURAN VARLIK TAKİP", Go);
                Go.Show();
            }
            if (e.Node.Name == "DuranVarlikGuncelleme")
            {
                FrmDuranVarlikGuncelleme Go = new FrmDuranVarlikGuncelleme();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlikGuncelleme", "DURAN VARLIK GÜNCELLE", Go);
                Go.Show();
            }

            if (e.Node.Name == "Ucak Otobus Bileti")
            {
                FrmUcakOtobusBileti Go = new FrmUcakOtobusBileti();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageUcakOtobus", "UÇAK/OTOBÜS BİLETİ", Go);
                Go.Show();
            }
            if (e.Node.Name == "Ucak Otobus Izleme")
            {
                FrmUcakOtobusBiletiIzleme Go = new FrmUcakOtobusBiletiIzleme();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageUcakOtobusIzleme", "UÇAK/OTOBÜS BİLETİ GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Sehir Icı Gorev")
            {
                FrmSehirIcıGorev Go = new FrmSehirIcıGorev();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSehirIcıGorev", "ŞEHİR İÇİ GÖREV", Go);
                Go.Show();
            }
            if (e.Node.Name == "Yurt Icı Gorev")
            {
                FrmYurtİciGorev Go = new FrmYurtİciGorev();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                Go.infos = infos;
                OpenTabPage("PageYurtIcıGorev", "YURT İÇİ GÖREV", Go);
                Go.Show();
            }
            if (e.Node.Name == "Izın")
            {
                FrmIzin Go = new FrmIzin();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageIzin", "PERSONEL İZİN", Go);
                Go.Show();
            }
            if (e.Node.Name == "Izin Izleme")
            {
                FrmIzinIzleme Go = new FrmIzinIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageIzinIzleme", "PERSONEL İZİN GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Konaklama")
            {
                FrmKonaklama Go = new FrmKonaklama();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageKonaklama", "KONAKLAMA", Go);
                Go.Show();
            }
            if (e.Node.Name == "Konaklama Izleme")
            {
                FrmKonaklamaIzleme Go = new FrmKonaklamaIzleme();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageKonaklamaIzleme", "KONAKLAMA GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Sehir Ici Gorev")
            {
                FrmSehirIciGorevIzleme Go = new FrmSehirIciGorevIzleme();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSehirIzleme", "ŞEHİR İÇİ GÖREV GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Yurt Icı GorevIzleme")
            {
                FrmYurtIciGorevIzleme Go = new FrmYurtIciGorevIzleme();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYurtIciGorevIzleme", "YURT İÇİ GÖREV GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Arac Tesis Kayit")
            {
                FrmAracKaydet Go = new FrmAracKaydet();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAracKaydet", "ARAÇ KAYDET", Go);
                Go.Show();
            }
            if (e.Node.Name == "Arac Tahsis Izleme")
            {
                FrmAracTahsisBilgileri Go = new FrmAracTahsisBilgileri();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAracTahsisBilgileri", "ARAÇ TAHSİS BİLGİLERİ", Go);
                Go.Show();
            }
            if (e.Node.Name == "Arac Yakit Beyani")
            {
                FrmYakitBeyani Go = new FrmYakitBeyani();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYakitBeyani", "ARAÇ YAKIT BEYANI", Go);
                Go.Show();
            }
            if (e.Node.Name == "Arac Yakıt Izleme")
            {
                FrmYakitBeyaniIzleme Go = new FrmYakitBeyaniIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYakitIzleme", "ARAÇ YAKIT BEYANI GÖRÜNTÜLE", Go);
                Go.Show();
            }
            if (e.Node.Name == "Evrak Kayit")
            {
                FrmEvrakKayit Go = new FrmEvrakKayit();
                Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageEvrakKayit", "EVRAK KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "Gelen Giden Yazi Izleme")
            {
                FrmEvrekKayitIzleme Go = new FrmEvrekKayitIzleme();
                //Go.infos = infos;
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageEvrakKayitIzleme", "GELEN/GİDEN RESMİ YAZI İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Name == "Araç Bakım Kayıt")
            {
                FrmAracBakimKayit Go = new FrmAracBakimKayit();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBakimKayit", "ARAÇ BAKIM KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "DV Zimmet Takip İzleme")
            {
                //frmWait.Show();
                FrmDVZimmetTakibi Go = new FrmDVZimmetTakibi();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageZimmetTakibi", "DV ZİMMET TAKİP", Go);
                Go.Show();
                //frmWait.Close();
            }
            if (e.Node.Name == "Arac Bakim Onarim Izleme")
            {
                FrmAracBakimKayitIzleme Go = new FrmAracBakimKayitIzleme();

                Go.FormBorderStyle = FormBorderStyle.None;

                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageBakimKayitIzleme", "ARAÇ BAKIM ONARIM İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Name == "Duran Varlik Ariza Kayit")
            {
                FrmDuranVarlikArizaKayit Go = new FrmDuranVarlikArizaKayit();
                Go.FormBorderStyle = FormBorderStyle.None;

                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDuranVarlikArizaKayit", "DURAN VARLIK ARIZA KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "DV Kalibrasyon Kayit")
            {
                FrmDvKalibrasyonKayit Go = new FrmDvKalibrasyonKayit();
                Go.FormBorderStyle = FormBorderStyle.None;

                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDvKalibrasyonKayit", "DURAN VARLIK KALİBRASYON KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "Ziyaretci Kayit")
            {
                FrmZiyaretciKayit Go = new FrmZiyaretciKayit();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageZiyaretci", "ZİYARETÇİ KAYIT", Go);
                Go.Show();
            }
            if (e.Node.Name == "Ziyaretci Kayit Izleme")
            {
                FrmZiyaretciKayitIzleme Go = new FrmZiyaretciKayitIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageZiyaretciIzleme", "ZİYARETÇİ KAYIT İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Name == "Tutanak") // TutanakIzleme
            {
                FrmArsiv Go = new FrmArsiv();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArsiv", "ARŞİV", Go);
                Go.Show();
            }
            if (e.Node.Name == "TutanakIzleme")
            {
                FrmArsivIzleme Go = new FrmArsivIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArsivIzleme", "ARŞİV İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Name == "YakitDokumleri")
            {
                FrmYakitDokum Go = new FrmYakitDokum();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYakitDokumleri", "YAKIT FİRMA DÖKÜMLERİ", Go);
                Go.Show();
            }
            if (e.Node.Name == "YakitDokumleriIzleme")
            {
                FrmYakitDokumIzleme Go = new FrmYakitDokumIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYakitDokumIzleme", "YAKIT FİRMA DÖKÜMLERİ İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Name == "Arac Talep")
            {
                FrmAracTalep Go = new FrmAracTalep();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAracTalep", "ARAÇ TALEP", Go);
                Go.Show();
            }
            if (e.Node.Name == "Arac Km")
            {
                FrmAracKm Go = new FrmAracKm();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAracKm", "ARAÇ KM", Go);
                Go.Show();
            }
            if (e.Node.Name == "Arac Km Izleme")
            {
                FrmAracKmIzleme Go = new FrmAracKmIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAracKmIzleme", "ARAÇ KM İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Name == "HaftalikKontrol")
            {
                FrmArsivKontrolFormu Go = new FrmArsivKontrolFormu();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArsivKontrolFormu", "ARŞİV KONTROL FORMU", Go);
                Go.Show();
            }
            if (e.Node.Name == "HaftalikKontrolIzleme")
            {
                FrmArsivKontrolFormuIzleme Go = new FrmArsivKontrolFormuIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArsivKontrolFormuIzleme", "ARŞİV KONTROL FORMU İZLEME", Go);
                Go.Show();
            }
            if (e.Node.Name == "Arac Talep Izleme")
            {
                FrmAracTalepIzleme Go = new FrmAracTalepIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                //Go.infos = infos;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageAracTalepIzleme", "ARAÇ TALEP İZLEME", Go);
                Go.Show();
            }


            /////////////////////////////////////////////////DÖKÜMAN YÖNETİM SİSTEMİ/////////////////////////////////////////////////////////

            if (e.Node.Name == "Dokuman Ekle")
            {
                FrmDokumanEkle Go = new FrmDokumanEkle();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDokumanEkle", "DOKÜMAN EKLE", Go);
                Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Name == "Standart Form Sorgula")
            {
                FrmStandartForm Go = new FrmStandartForm();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageStandartFormSorgula", "STANDART FORM SORGULA", Go);
                Go.Show();
            }
            if (e.Node.Name == "Dokuman Sorgula")
            {
                FrmDokumanSorgula Go = new FrmDokumanSorgula();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDokumanSorgula", "DOKÜMAN SORGULA", Go);
                Go.Show();
            }
            if (e.Node.Name == "Standart Form Ekle")
            {
                FrmStandartFormEkle Go = new FrmStandartFormEkle();

                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageFormEkle", "STANDART FORM EKLE", Go);
                Go.infos = infos;
                Go.Show();
            }

            /////////////////////////////////////////////////GEÇİCİ KABUL VE AMBAR/////////////////////////////////////////////////////////

            if (e.Node.Name == "Malzeme Kayit Ambar")
            {
                FrmMalzemeKayit Go = new FrmMalzemeKayit();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageMalzemeKayit", "MALZEME KAYIT", Go);
                Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Name == "Stok Giris Cikis")
            {
                FrmStokGirisCikis Go = new FrmStokGirisCikis();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageStokGirisCikis", "STOK GİRİŞ/ÇIKIŞ", Go);
                Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Name == "Stok Goruntule")
            {
                FrmStokGoruntule Go = new FrmStokGoruntule();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageStokGoruntule", "STOK GÖRÜNTÜLE", Go);
                Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Name == "KayitliMalzemeler")
            {
                FrmMalzemeKayitIzleme Go = new FrmMalzemeKayitIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageKayitliMalzemeler", "KAYITLI MALZEMELERİ GÖRÜNTÜLE", Go);
                //Go.infos = infos;
                Go.Show();
            }

            if (e.Node.Name == "Depo Hareketleri")
            {
                FrmDepoHareketleri Go = new FrmDepoHareketleri();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDepoHaraketleri", "DEPO HARKETLERİ", Go);
                //Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Name == "Malzeme Hazirlama")
            {
                FrmMalzemeHazirlama Go = new FrmMalzemeHazirlama();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageMalzemeHazirmala", "MALZEME HAZIRLAMA", Go);
                Go.infos = infos;
                Go.Show();
            }

            /////////////////////////////////////////////////DESTEK DEPO///////////////////////////////////////////////////////////////////

            if (e.Node.Name == "Malzeme Kayit")
            {
                FrmMalzemeKayitDestekDepo Go = new FrmMalzemeKayitDestekDepo();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageDesteDepoMalzemeKayit", "DESTEK DEPO MALZEME KAYIT", Go);
                //Go.infos = infos;
                Go.Show();
            }
            /////////////////////////////////////////////////EĞİTİM///////////////////////////////////////////////////////////////////

            if (e.Node.Name == "Egitim Planı Olustur")
            {
                FrmEgitimPlanıOlustur Go = new FrmEgitimPlanıOlustur();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageEgitimPlaniOlustur", "EĞİTİM PLANI OLUŞTUR", Go);
                //Go.infos = infos;
                Go.Show();
            }
            /////////////////////////////////////////////////RAPORLAMALAR/////////////////////////////////////////////////////////////
            if (e.Node.Name == "SatRaporlama")
            {
                FrmSatRaporu Go = new FrmSatRaporu();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatRaporlama", "SAT RAPORLAMA", Go);
                Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Name == "SatRaporlamaIzleme")
            {
                FrmSatRaporuIzleme Go = new FrmSatRaporuIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSatRaporuIzleme", "SAT RAPORLAMA İZLEME", Go);
                //Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Name == "Ariza Raporlari")
            {
                FrmArizaRaporlama Go = new FrmArizaRaporlama();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageArizaRapor", "ARIZA RAPORLARI", Go);
                //Go.infos = infos;
                Go.Show();
            }

            ///////////////////////////////////////////YERLEŞKELER/////////////////////////////////////////////////////////

            if (e.Node.Name == "YerleskeKayit")
            {
                FrmYerleskeKayit Go = new FrmYerleskeKayit();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYerleskeler", "YERLEŞKE KAYIT", Go);
                //Go.infos = infos;
                Go.Show();
            }

            if (e.Node.Name == "YerleskeIzleme")
            {
                FrmYerleskeIzleme Go = new FrmYerleskeIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYerleskeIzleme", "YERLEŞKE İZLEME", Go);
                //Go.infos = infos;
                Go.Show();
            }

            if (e.Node.Name == "YerleskeGideriKayit")
            {
                FrmYerleskeGideriKayit Go = new FrmYerleskeGideriKayit();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageYerleskeGideriKayit", "YERLEŞKE GİDERİ KAYIT", Go);
                Go.infos = infos;
                Go.Show();
            }

            if (e.Node.Name == "GiderKayitIzleme")
            {
                FrmYerleskeGiderKayitIzleme Go = new FrmYerleskeGiderKayitIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageGiderKayitIzleme", "YERLEŞKE GİDER KAYIT İZLEME", Go);
                //Go.infos = infos;
                Go.Show();
            }

            ///////////////////////////////////////////BÜTÇELER/////////////////////////////////////////////////////////

            if (e.Node.Name == "ButceKayit")
            {
                FrmButceKayit Go = new FrmButceKayit();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageButceKayit", "BÜTÇE KAYIT", Go);
                //Go.infos = infos;
                Go.Show();
            }
            if (e.Node.Name == "SiparisOlustur")
            {
                FrmSiparisler Go = new FrmSiparisler();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSiparisler", "SİPARİŞLER", Go);
                //Go.infos = infos;
                //Go.sayfa = "SİPARİŞLER";
                Go.Show();
            }
            if (e.Node.Name == "SiparisIzleme")
            {
                FrmSiparislerIzleme Go = new FrmSiparislerIzleme();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageSiparisIzleme", "SİPARİŞLER İZLEME", Go);
                //Go.infos = infos;
                //Go.sayfa = "SİPARİŞLER";
                Go.Show();
            }

            if (e.Node.Name == "ButceKasa")
            {
                FrmKasa Go = new FrmKasa();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageKasa", "PROJE KASA", Go);
                Go.infos = infos;
                Go.Show();
            }

            if (e.Node.Name == "ProjeKasaIzleme")
            {
                FrmKasaIzlemecs Go = new FrmKasaIzlemecs();
                Go.FormBorderStyle = FormBorderStyle.None;
                Go.TopLevel = false;
                Go.AutoScroll = true;
                OpenTabPage("PageKasaIzleme", "PROJE KASA İZLEME", Go);
                //Go.infos = infos;
                Go.Show();
            }
            #endregion
        }

        private void gÖREVLERİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGorevlerim frmGorevlerim = new FrmGorevlerim();
            frmGorevlerim.infos = infos;
            frmGorevlerim.ShowDialog();
        }

        private void iŞAKIŞSÜRELERİPERFORMANSİZLEMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIsAkisiPersonel frmIsAkisiPersonel = new FrmIsAkisiPersonel();
            frmIsAkisiPersonel.ShowDialog();
        }

        private void BtnDosyaDuzelt_Click(object sender, EventArgs e)
        {
            FrmSatDosyaYoluDuzelt frmSatDosyaYoluDuzelt = new FrmSatDosyaYoluDuzelt();
            frmSatDosyaYoluDuzelt.ShowDialog();
        }

        private void iŞAKIŞSÜRELERİPERFORMANSİZLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIsAkisiPersonel frmIsAkisiPersonel = new FrmIsAkisiPersonel();
            frmIsAkisiPersonel.ShowDialog();
        }

        private void BtnDonemDuzelt_Click(object sender, EventArgs e)
        {
            FrmDonemDuzlet frmDonemDuzlet = new FrmDonemDuzlet();
            frmDonemDuzlet.ShowDialog();
        }

        private void tELEFONREHBERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTelefonRehberi frmTelefonRehberi = new FrmTelefonRehberi();
            frmTelefonRehberi.ShowDialog();
        }

        private void gÖREVATAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGorevAta frmGorevAta = new FrmGorevAta();
            frmGorevAta.infos = infos;
            frmGorevAta.ShowDialog();
        }

        private void zİMMETLERİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zimmetlerim zimmetlerim = new Zimmetlerim();
            zimmetlerim.ShowDialog();
        }

        private void iZİNLERİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIzinlerim frmIzinlerim = new FrmIzinlerim();
            frmIzinlerim.infos = infos;
            frmIzinlerim.ShowDialog();
        }

        private void yURTİÇİGÖREVLERİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmYurtIciGorevlerim frmYurtIciGorevlerim = new FrmYurtIciGorevlerim();
            frmYurtIciGorevlerim.infos = infos;
            frmYurtIciGorevlerim.ShowDialog();
        }

        private void şEHİRİÇİGÖREVLERİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSehirIciGorevlerim frmSehirIciGorevlerim = new FrmSehirIciGorevlerim();
            frmSehirIciGorevlerim.infos = infos;
            frmSehirIciGorevlerim.ShowDialog();
        }

        private void kONAKLAMALARIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKonaklamalarim frmKonaklamalarim = new FrmKonaklamalarim();
            frmKonaklamalarim.infos = infos;
            frmKonaklamalarim.ShowDialog();
        }

        private void oFİSDOSYAFİHRİSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOfisDosyaFihrist frmOfisDosyaFihrist = new FrmOfisDosyaFihrist();
            frmOfisDosyaFihrist.ShowDialog();
        }

        private void aRŞİVFİHRİSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArsivDosyaFihrist arsivDosyaFihrist = new ArsivDosyaFihrist();
            arsivDosyaFihrist.ShowDialog();
        }

        private void iZLEMESAYFALARIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aMBARVEGEÇİÇİKABULToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIzlemeAmbar frmIzlemeAmbar = new FrmIzlemeAmbar();
            frmIzlemeAmbar.ShowDialog();
        }

        private void şifremiDeğitirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSifremiDegistir frmSifremiDegistir = new FrmSifremiDegistir();
            frmSifremiDegistir.infos = infos;
            frmSifremiDegistir.ShowDialog();
        }

        private void yetkilendirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*FrmAdmin frmAdmin = new FrmAdmin();
            frmAdmin.infos = infos;
            frmAdmin.ShowDialog();*/
        }

        private void devamDevamsızlıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDevam frmDevam = new FrmDevam();
            frmDevam.FormBorderStyle = FormBorderStyle.None;
            frmDevam.TopLevel = false;
            frmDevam.AutoScroll = true;
            OpenTabPage("PageDevam", "DEVAM/DEVAMSIZLIK", frmDevam);
            frmDevam.Show();
        }

        private void organizasyonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOrganizasyon frmOrganizasyon = new FrmOrganizasyon();
            frmOrganizasyon.ShowDialog();
        }

        private void onayEkranlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmOnayEkranlari Go = new FrmOnayEkranlari();
            //Go.infos = infos;
            //Go.FormBorderStyle = FormBorderStyle.None;
            //Go.TopLevel = false;
            //Go.AutoScroll = true;
            //OpenTabPage("PageOnayEkranlari", "ONAY EKRANLARI", Go);
            //Go.Show();
        }

        private void toolStripDropDownButton4_Click(object sender, EventArgs e)
        {
            FrmTelefonRehberi frmTelefonRehberi = new FrmTelefonRehberi();
            frmTelefonRehberi.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Zimmetlerim zimmetlerim = new Zimmetlerim();
            zimmetlerim.ShowDialog();
        }

        private void izinlerimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIzinlerim frmIzinlerim = new FrmIzinlerim();
            frmIzinlerim.infos = infos;
            frmIzinlerim.ShowDialog();
        }

        private void sistemGörevlerimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGorevlerim frmGorevlerim = new FrmGorevlerim();
            frmGorevlerim.infos = infos;
            frmGorevlerim.ShowDialog();
        }

        private void görevAtaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmGorevAta frmGorevAta = new FrmGorevAta();
            frmGorevAta.infos = infos;
            frmGorevAta.ShowDialog();
        }

        private void yurtİçiGörevlerimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmYurtIciGorevlerim frmYurtIciGorevlerim = new FrmYurtIciGorevlerim();
            frmYurtIciGorevlerim.infos = infos;
            frmYurtIciGorevlerim.ShowDialog();
        }

        private void şehirİçiGörevlerimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSehirIciGorevlerim frmSehirIciGorevlerim = new FrmSehirIciGorevlerim();
            frmSehirIciGorevlerim.infos = infos;
            frmSehirIciGorevlerim.ShowDialog();
        }

        private void hesapOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHesapOlustur frmHesapOlustur = new FrmHesapOlustur();
            frmHesapOlustur.ShowDialog();
        }

        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmServer frmServer = new FrmServer();
            frmServer.infos = infos;
            frmServer.ShowDialog();
        }
        string izlemeTıklanan = "";
        private void ambarVeriİzlemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmSahaIzleme frmSahaIzleme = new FrmSahaIzleme();
            //frmSahaIzleme.Show();
            FrmIzlemeAmbar frmIzlemeAmbar = new FrmIzlemeAmbar();
            frmIzlemeAmbar.Show();
            //timerIzlemeChc.Start();
            //izlemeTıklanan = "FrmIzlemeAmbar";
        }

        private void atölyeVeriİzlemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAtolyeVeri frmAtolyeRapor = new FrmAtolyeVeri();
            frmAtolyeRapor.ShowDialog();
        }

        private void malzemeTalepOnayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMifOnay Go = new FrmMifOnay();
            Go.infos = infos;
            Go.FormBorderStyle = FormBorderStyle.None;
            Go.TopLevel = false;
            Go.AutoScroll = true;
            OpenTabPage("PageMifOnay", "MİF ONAY", Go);
            Go.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmSehitİciGorevOnay Go = new FrmSehitİciGorevOnay();
            Go.infos = infos;
            Go.FormBorderStyle = FormBorderStyle.None;
            Go.TopLevel = false;
            Go.AutoScroll = true;
            OpenTabPage("PageSehitIciGorevOnay", "ŞEHİT İÇİ GÖREV ONAY", Go);
            Go.Show();
        }

        private void konaklamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKonaklamaOnay Go = new FrmKonaklamaOnay();
            Go.infos = infos;
            Go.FormBorderStyle = FormBorderStyle.None;
            Go.TopLevel = false;
            Go.AutoScroll = true;
            OpenTabPage("PageKonaklamaOnay", "KONAKLAMA ONAY", Go);
            Go.Show();
        }

        private void uçakOtobüsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUcakOtobusOnay Go = new FrmUcakOtobusOnay();
            Go.infos = infos;
            Go.FormBorderStyle = FormBorderStyle.None;
            Go.TopLevel = false;
            Go.AutoScroll = true;
            OpenTabPage("PageUcakOtobusOnay", "UÇAK/OTOBÜS ONAY", Go);
            Go.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void YurtIci_Click(object sender, EventArgs e)
        {
            FrmYurtİciGorev Go = new FrmYurtİciGorev();
            Go.infos = infos;
            Go.FormBorderStyle = FormBorderStyle.None;
            Go.TopLevel = false;
            Go.AutoScroll = true;
            OpenTabPage("PageYurtIcıGorev", "YURT İÇİ GÖREV", Go);
            Go.Show();

        }

        private void SehirIcı_Click(object sender, EventArgs e)
        {
            FrmSehirIcıGorev Go = new FrmSehirIcıGorev();
            Go.FormBorderStyle = FormBorderStyle.None;
            Go.infos = infos;
            Go.TopLevel = false;
            Go.AutoScroll = true;
            OpenTabPage("PageSehirIcıGorev", "ŞEHİR İÇİ GÖREV", Go);
            Go.Show();
        }

        private void Izin_Click(object sender, EventArgs e)
        {
            FrmIzin Go = new FrmIzin();
            Go.FormBorderStyle = FormBorderStyle.None;
            Go.infos = infos;
            Go.TopLevel = false;
            Go.AutoScroll = true;
            OpenTabPage("PageIzin", "PERSONEL İZİN", Go);
            Go.Show();
        }

        private void malzemeİstekFormuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGiysiTalep Go = new FrmGiysiTalep();
            Go.FormBorderStyle = FormBorderStyle.None;
            Go.infos = infos;
            Go.TopLevel = false;
            Go.AutoScroll = true;
            OpenTabPage("PageTalep", "MİF", Go);
            Go.Show();
        }

        private void duyuruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDuyuru frmDuyuru = new FrmDuyuru();
            frmDuyuru.infos = infos;
            frmDuyuru.ShowDialog();
        }

        private void BtnBildirim_Click(object sender, EventArgs e)
        {
            int genislik = tabAnasayfa.Size.Width;
            if (genislik == 1600)
            {
                PnlBildirim.Size = new Size(300, 955);
                tabAnasayfa.Size = new Size(1275, 955);
            }
            else
            {
                PnlBildirim.Size = new Size(0, 0);
                tabAnasayfa.Size = new Size(1600, 955);
            }
        }

        private void tabAnasayfa_MouseClick(object sender, MouseEventArgs e)
        {
            PnlBildirim.Size = new Size(0, 0);
            tabAnasayfa.Size = new Size(1600, 955);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            PnlBildirim.Size = new Size(0, 0);
            tabAnasayfa.Size = new Size(1600, 955);
        }

        private void tabAnasayfa_Click(object sender, EventArgs e)
        {
            PnlBildirim.Size = new Size(0, 0);
            tabAnasayfa.Size = new Size(1600, 955);
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {
            PnlBildirim.Size = new Size(0, 0);
            tabAnasayfa.Size = new Size(1600, 955);
        }
        
        private void webContent_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            for (int i = 0; i < webContent.Document.Links.Count; i++)
            {

                webContent.Document.Links[i].Click -= new HtmlElementEventHandler(this.LinkClick);
                webContent.Document.Links[i].Click += new HtmlElementEventHandler(this.LinkClick);
                
            }

            //for (int i = 0; i < webContent.Document.All.Count; i++)
            //{
            //    webContent.Document.All[i].Click += new HtmlElementEventHandler(this.ButtonClick);
            //}

        }

        private void konaklamalarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKonaklamalarim frmKonaklamalarim = new FrmKonaklamalarim();
            frmKonaklamalarim.infos = infos;
            frmKonaklamalarim.ShowDialog();
        }

        public bool pencerekontrol = false;
        //string dosyaYolu = @"Z:\DTS\info\ou\notification.txt";
        string yol = @"C:\DTS\Bildirim\notification.txt";
        private void LinkClick(object sender, EventArgs e)
        {
            HtmlElement element = ((HtmlElement)sender);
            string id = element.Id;
            string href = element.GetAttribute("href");
            string metin = element.InnerText;

            if (metin==null)
            {
                return;
            }

            string[] array = metin.Split(' ');

            if (array[0] == "TEMİZLE")
            {
                webContent.Navigate("");
                PanelEditClear();
                //TopluTemizle();
                BildirimControl(infos[0].ConInt());
            }
            if (array[0] != "TEMİZLE")
            {
                FrmBildirimPanel frmBildirimPanel = new FrmBildirimPanel();
                frmBildirimPanel.icerik = metin;
                frmBildirimPanel.ShowDialog();
                //DosyaSatirSil(metin);
                BildirimControl(infos[0].ConInt());
            }

        }
        void TopluTemizle()
        {
            if (!File.Exists(yol))
            {
                TimerFileRead.Stop();
                MessageBox.Show("Bildirim okuma dosyası bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string icerik = File.ReadAllText(yol);
            string[] array = icerik.Split('\n');
            for (int i = 0; i < array.Length; i++)
            {
                string[] arrayIcerik = array[i].ToString().Split(' ');
                if (arrayIcerik[arrayIcerik.Length - 1].ConInt() == infos[0].ConInt())
                {
                    bildirimMetin = "";
                    for (int k = 3; k < arrayIcerik.Length; k++)
                    {
                        if (arrayIcerik.Length - 1 == k)
                        {
                            continue;
                        }
                        bildirimMetin += arrayIcerik[k] + " ";
                    }
                    array[i] = "";
                }
            }

            TextWriter tw = new StreamWriter(yol);
            tw.Write("");
            tw.Close();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == "")
                {
                    return;
                }

                string txtMetin = array[i];

                StreamWriter streamWriter = new StreamWriter(yol, true);
                streamWriter.WriteLine(txtMetin);
                streamWriter.Close();
            }

        }

        public void TıklananListSil(string tiklananMetin)
        {



            //for (int i = 0; i < oncekiBildirimler.Count; i++)
            //{
            //    if (oncekiBildirimler[i] == tiklananMetin)
            //    {
            //        oncekiBildirimler.RemoveAt(i);
            //    }
            //    if (tiklananMetin=="TÜMÜNÜ SİL")
            //    {

            //    }
            //}
        }


        string bildirimMetin = "";
        public void DosyaSatirSil(string tiklananMetin)
        {

            // TÜM TXT DOSYASININ İÇİNDEKİLERİ BUL VE TIKLANANA ERİŞ
            string icerik = File.ReadAllText(yol);
            if (icerik == "")
            {
                return;
            }
            string[] array = icerik.Split('\n');
            for (int i = 0; i < array.Length; i++)
            {
                string[] arrayIcerik = array[i].ToString().Split(' ');
                bildirimMetin = "";
                for (int k = 3; k < arrayIcerik.Length; k++)
                {
                    if (arrayIcerik.Length - 1 == k)
                    {
                        continue;
                    }
                    bildirimMetin += arrayIcerik[k]+ " ";
                }

                if (tiklananMetin == bildirimMetin)
                {
                    array[i] = "";
                }
            }

            // TXT İÇERİĞİNİ SİL VE TIKLANANI SİL GERİ KALANLARI TEKRAR YAZ

            TextWriter tw = new StreamWriter(yol);
            tw.Write("");
            tw.Close();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == "")
                {
                    return;
                }

                string txtMetin = array[i];

                StreamWriter streamWriter = new StreamWriter(yol, true);
                streamWriter.WriteLine(txtMetin);
                streamWriter.Close();
            }

        }
        public string LogYaz(string baslik, string icerik, string sorumluId, string benzersizKimlik)
        {
            Log log = new Log(baslik, icerik, DateTime.Now, infos[1].ToString(), sorumluId, benzersizKimlik);
            string mesaj = logManager.Add(log);

            if (mesaj != "OK")
            {
                return mesaj;
            }

            return "OK";
        }

        List<Log> controlLogs = new List<Log>();
        public void BildirimControl(int id)
        {
            List<Log> logs = new List<Log>();
            List<Log> logs2 = new List<Log>();
            logs = logManager.GetList(id);

            if (logs.Count == 0)
            {
                webContent.Navigate("");
                StringBuilder strB = new StringBuilder();

                strB.Append("<center><h2 class='headings'>" + "DTS Bildirim" + "</h2>");
                strB.Append("<a href='#'>TEMİZLE</a></center>");

                webContent.DocumentText = strB.ToString();
            }
            
            foreach (Log item in controlLogs)
            {
                foreach (Log item2 in logs)
                {
                    if (item.Icerik!=item2.Icerik)
                    {
                        return;
                    }
                }
            }

            foreach (Log item in logs)
            {
                FrmHelper.Bildirim(item.Baslik, "\n" + item.Icerik, ımageList1.Images["okey.png"], item.Kullainici, item.SorumluId, item.BenzersizKimlik, logs);
                controlLogs.Add(item);
            }

            //if (logs2.Count!=0)
            //{
            //    foreach (Log item in logs2)
            //    {
            //        FrmHelper.Bildirim(item.Baslik, "\n" + item.Icerik, ımageList1.Images["okey.png"], item.Kullainici, item.SorumluId, item.BenzersizKimlik, logs2);
            //        controlLogs.Add(item);
            //    }
            //}

            //else
            //{
            //    foreach (Log item in logs)
            //    {
            //        FrmHelper.Bildirim(item.Baslik, "\n" + item.Icerik, ımageList1.Images["okey.png"], item.Kullainici, item.SorumluId, item.BenzersizKimlik, logs);
            //        controlLogs.Add(item);
            //    }
            //}





            //if (!File.Exists(yol))
            //{
            //    TimerFileRead.Stop();
            //    MessageBox.Show("Bildirim okuma dosyası bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //string icerik = File.ReadAllText(yol);
            //metinControl = false;
            //if (icerik == "")
            //{
            //    return;
            //}

            //string[] array = icerik.Split('\n');
            //for (int i = 0; i < array.Length; i++)
            //{
            //    string[] arrayIcerik = array[i].ToString().Split(' ');
            //    string[] arrayIdler = arrayIcerik[arrayIcerik.Length - 1].ToString().Split(';');
            //    for (int j = 0; j < arrayIdler.Length; j++)
            //    {
            //        if (infos[0].ConInt() == arrayIdler[j].ConInt())
            //        {
            //            string bildirimMetin = "";
            //            string baslik = arrayIcerik[0] + " " + arrayIcerik[1] + " " + arrayIcerik[2];

            //            for (int k = 3; k < arrayIcerik.Length; k++)
            //            {
            //                if (arrayIcerik.Length - 1 == k)
            //                {
            //                    continue;
            //                }
            //                bildirimMetin += arrayIcerik[k] + " ";
            //            }

            //            if (oncekiBildirimler != null)
            //            {
            //                foreach (string item in oncekiBildirimler)
            //                {
            //                    if (item == bildirimMetin)
            //                    {
            //                        metinControl = true;
            //                        return;
            //                    }
            //                    metinControl = false;
            //                }
            //            }

            //            if (metinControl == false)
            //            {
            //                FrmHelper.Bildirim(baslik, "\n" + bildirimMetin, ımageList1.Images["okey.png"], infos[1].ToString(), arrayIcerik[arrayIcerik.Length - 1]);
            //                oncekiBildirimler.Add(bildirimMetin);
            //            }
            //        }
            //    }
            //}
        }

        private void envanterArızaKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDuranVarlikArizaKayit Go = new FrmDuranVarlikArizaKayit();
            Go.FormBorderStyle = FormBorderStyle.None;
            Go.TopLevel = false;
            Go.AutoScroll = true;
            OpenTabPage("PageDuranVarlikArizaKayit", "ENVANTER ARIZA KAYIT", Go);
            Go.Show();
        }

        private void bildirimYetkiDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBildirimYetki frmBildirimYetki = new FrmBildirimYetki();
            frmBildirimYetki.ShowDialog();
        }

        private void timerOnline_Tick(object sender, EventArgs e)
        {
            PersonelAktif();
            FrmBildirimler frmBildirimler = (FrmBildirimler)Application.OpenForms["FrmBildirimler"];
            if (frmBildirimler!=null)
            {
                frmBildirimler.DuyuruEditList();
            }
        }

        private void TimerFileRead_Tick(object sender, EventArgs e)
        {    
            BildirimControl(infos[0].ConInt());
        }

        public void PanelEditClear()
        {
            StringBuilder strB = new StringBuilder();
            strB.Append("<center><h2 class='headings'>" + "DTS Bildirim" + "</h2>");
            strB.Append("<a href='#'>TEMİZLE</a></center>");
            webContent.DocumentText = strB.ToString();
            BtnBildirim.Text = "0";
        }

        //private void ButtonClick(object sender, EventArgs e)
        //{
        //    HtmlElement element = ((HtmlElement)sender);
        //    string metin = element.InnerText;

        //}

        private void FrmAnaSayfa_SizeChanged(object sender, EventArgs e)
        {
            //Tabpage ile form penceresini boyutlandır
            /*if (treeView2.Visible)
            {
                foreach (TabPage item in tabAnasayfa.TabPages)
                {
                    item.Controls[0].Size = new Size(tabAnasayfa.Size.Width - 350, tabAnasayfa.Size.Height - 100);
                }
            }
            else
            {
                foreach (TabPage item in tabAnasayfa.TabPages)
                {
                    item.Controls[0].Size = new Size(tabAnasayfa.Size.Width - 100, tabAnasayfa.Size.Height - 100);
                }
            }*/
        }

        private void yAZDIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmDevam().Show();
        }

        private void excelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmDisaAktarExcel frmDisaAktarExcel = new FrmDisaAktarExcel();
            frmDisaAktarExcel.ShowDialog();
        }

        private void izinOnayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIzinOnay frmIzinOnay = new FrmIzinOnay();
            frmIzinOnay.infos = infos;
            frmIzinOnay.FormBorderStyle = FormBorderStyle.None;
            frmIzinOnay.TopLevel = false;
            frmIzinOnay.AutoScroll = true;
            OpenTabPage("PageIzinOnay", "İZİN ONAY", frmIzinOnay);
            frmIzinOnay.Show();
        }

        public List<PersonelHesap> personelHesapsControl = new List<PersonelHesap>();
        bool listeControl = false;

        private void DtgPersonelList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            if (DtgPersonelList.CurrentRow == null)
            {
                MessageBox.Show("Listede bir personel kaydı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string isim = DtgPersonelList.CurrentRow.Cells["PersonelAd"].Value.ToString();

            if (personelHesapsControl.Count==0)
            {
                PersonelHesap personelHesap1 = new PersonelHesap(isim);
                personelHesapsControl.Add(personelHesap1);

                DtgSohbet.Rows.Add();
                int sonSatir = DtgSohbet.RowCount - 1;
                DtgSohbet.Rows[sonSatir].Cells["Ad"].Value = isim;

                PersonelHesap personelHesap = personelHesapManager.GetSohbet(isim);

                if (personelHesap.Durum == "ÇEVRİM İÇİ")
                {
                    DtgSohbet.Rows[sonSatir].Cells["SonGorulme"].Value = "Çevrimiçi";
                }
                else
                {
                    DtgSohbet.Rows[sonSatir].Cells["SonGorulme"].Value = personelHesap.SonGorulme.ToString("G");
                }

                FrmSohbet frmSohbet1 = new FrmSohbet();
                frmSohbet1.infos = infos;
                frmSohbet1.alan = isim;
                frmSohbet1.WindowState = FormWindowState.Minimized;
                frmSohbet1.Show();
                frmSohbet1.WindowState = FormWindowState.Normal;
                frmSohbet1.Text = isim;
                frmSohbet1.Show();
            }
            else
            {
                bool control = false;
                foreach (PersonelHesap item in personelHesapsControl)
                {
                    if (item.AdSoyad == isim)
                    {
                        FrmSohbet frmSohbet = (FrmSohbet)Application.OpenForms["FrmSohbet"];
                        if (frmSohbet==null)
                        {
                            return;
                        }
                        frmSohbet.infos = infos;
                        frmSohbet.alan = isim;
                        frmSohbet.WindowState = FormWindowState.Minimized;
                        frmSohbet.Show();
                        frmSohbet.WindowState = FormWindowState.Normal;
                        frmSohbet.Text = isim;
                        frmSohbet.Show();
                        control = true;
                        break;
                    }
                }

                if (control==true)
                {
                    return;
                }

                PersonelHesap personelHesap1 = new PersonelHesap(isim);
                personelHesapsControl.Add(personelHesap1);

                DtgSohbet.Rows.Add();
                int sonSatir = DtgSohbet.RowCount - 1;
                DtgSohbet.Rows[sonSatir].Cells["Ad"].Value = isim;

                PersonelHesap personelHesap = personelHesapManager.GetSohbet(isim);

                if (personelHesap.Durum == "ÇEVRİM İÇİ")
                {
                    DtgSohbet.Rows[sonSatir].Cells["SonGorulme"].Value = "Çevrimiçi";
                }
                else
                {
                    DtgSohbet.Rows[sonSatir].Cells["SonGorulme"].Value = personelHesap.SonGorulme.ToString("G");
                }

                FrmSohbet frmSohbet1 = new FrmSohbet();
                frmSohbet1.infos = infos;
                frmSohbet1.alan = isim;
                frmSohbet1.WindowState = FormWindowState.Minimized;
                frmSohbet1.Show();
                frmSohbet1.WindowState = FormWindowState.Normal;
                frmSohbet1.Text = isim;
                frmSohbet1.Show();
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (silinecekIsim == "")
            {
                MessageBox.Show("Lütfen silinecek sohbeti seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
            frmAnaSayfa.personelHesapsControl.RemoveAt(silinecekIndex);
            DtgSohbet.Rows.RemoveAt(silinecekIndex);

            silinecekIsim = "";

        }
        string silinecekIsim = "";
        int silinecekIndex = 0;
        private void DtgSohbet_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgSohbet.CurrentRow == null)
            {
                MessageBox.Show("Listede bir personel kaydı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            silinecekIsim = DtgSohbet.CurrentRow.Cells["Ad"].Value.ToString();
            silinecekIndex = DtgSohbet.CurrentRow.Index;

        }

        private void DtgSohbet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int deger = 0;
            if (DtgSohbet.CurrentRow == null)
            {
                MessageBox.Show("Listede bir personel kaydı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string isim = DtgSohbet.CurrentRow.Cells["Ad"].Value.ToString();

            FrmSohbet frmSohbet = (FrmSohbet)Application.OpenForms["FrmSohbet"];
            if (frmSohbet!=null)
            {
                frmSohbet.WindowState = FormWindowState.Minimized;
                frmSohbet.Show();
                frmSohbet.infos = infos;
                frmSohbet.alan = isim;
                frmSohbet.WindowState = FormWindowState.Normal;
                frmSohbet.Text = isim;
                frmSohbet.Show();
            }
            else
            {
                //foreach (DataGridViewRow item in DtgSohbet.Rows)
                //{
                //    if (item.Cells["Ad"].Value.ToString() == isim)
                //    {
                //        DtgSohbet.Rows.RemoveAt(deger);
                //        FrmAnaSayfa frmAnaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnasayfa"];
                //        frmAnaSayfa.personelHesapsControl.RemoveAt(silinecekIndex);
                //    }
                //    deger++;
                //}
            }
        }

        private void duyuruYayınlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDuyuru frmDuyuru = new FrmDuyuru();
            frmDuyuru.infos = infos;
            frmDuyuru.ShowDialog();
        }

        private void malzemeTaleplerimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMalzemeTaleplerim frmMalzemeTaleplerim = new FrmMalzemeTaleplerim();
            frmMalzemeTaleplerim.infos = infos;
            frmMalzemeTaleplerim.ShowDialog();
        }

        private void işlemAdımlarıDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIslemAdimiEdit frmIslemAdimiEdit = new FrmIslemAdimiEdit();
            frmIslemAdimiEdit.ShowDialog();
        }

        private void sahaBakımOnarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmIzlemeAmbar frmIzlemeAmbar = new FrmIzlemeAmbar();
            //frmIzlemeAmbar.Show();
            FrmSahaIzleme frmSahaIzleme = new FrmSahaIzleme();
            frmSahaIzleme.Show();
            //timerIzlemeChc.Start();
            //izlemeTıklanan = "FrmSahaIzleme";
        }

        private void timerIzlemeChc_Tick(object sender, EventArgs e)
        {
            if (izlemeTıklanan == "FrmSahaIzleme")
            {
                FrmIzlemeAmbar ambar = (FrmIzlemeAmbar)Application.OpenForms["FrmIzlemeAmbar"];
                if (ambar == null)
                {
                    return;
                }
                ambar.WindowState = FormWindowState.Maximized;
                ambar.Show();
                FrmSahaIzleme frmSohbet = (FrmSahaIzleme)Application.OpenForms["FrmSahaIzleme"];
                if (frmSohbet == null)
                {
                    return;
                }
                frmSohbet.WindowState = FormWindowState.Minimized;
                frmSohbet.Show();
                izlemeTıklanan = "FrmIzlemeAmbar";
            }
            else
            {
                FrmSahaIzleme frmSohbet = (FrmSahaIzleme)Application.OpenForms["FrmSahaIzleme"];
                if (frmSohbet == null)
                {
                    return;
                }
                frmSohbet.WindowState = FormWindowState.Maximized;
                frmSohbet.Show();
                FrmIzlemeAmbar ambar = (FrmIzlemeAmbar)Application.OpenForms["FrmIzlemeAmbar"];
                if (ambar == null)
                {
                    return;
                }
                ambar.WindowState = FormWindowState.Minimized;
                ambar.Show();
                izlemeTıklanan = "FrmSahaIzleme";
            }
            
        }

        private void görevliPersonellerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DtgSohbet_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string isim = DtgSohbet.CurrentRow.Cells["Ad"].Value.ToString();
            FrmSohbet frmSohbet = (FrmSohbet)Application.OpenForms["FrmSohbet"];
            if (frmSohbet != null)
            {
                frmSohbet.infos = infos;
                frmSohbet.alan = isim;
                frmSohbet.WindowState = FormWindowState.Minimized;
                frmSohbet.Show();
                frmSohbet.WindowState = FormWindowState.Normal;
                frmSohbet.Text = isim;
                frmSohbet.Show();
            }
            else
            {
                FrmSohbet frmSohbet2 = new FrmSohbet();
                frmSohbet2.infos = infos;
                frmSohbet2.alan = isim;
                frmSohbet2.WindowState = FormWindowState.Minimized;
                frmSohbet2.Show();
                frmSohbet2.WindowState = FormWindowState.Normal;
                frmSohbet2.Text = isim;
                frmSohbet2.Show();
            }
        }
        List<Sohbet> sohbets = new List<Sohbet>();
        private void TmMesajControl_Tick(object sender, EventArgs e)
        {
            //MesajControl();
        }
        void MesajControl()
        {
            foreach (PersonelHesap item in personelHesaps)
            {
                sohbets = sohbetManager.GetList(item.AdSoyad, infos[1].ToString()); // hiç görülmemiş mesajlar

                if (sohbets.Count > 0)
                {
                    FrmSohbet frmSohbet = (FrmSohbet)Application.OpenForms["FrmSohbet"];
                    if (frmSohbet != null)
                    {
                        frmSohbet.infos = infos;
                        frmSohbet.alan = item.AdSoyad;
                        frmSohbet.WindowState = FormWindowState.Minimized;
                        frmSohbet.Show();
                        frmSohbet.WindowState = FormWindowState.Normal;
                        frmSohbet.Text = item.AdSoyad;
                        frmSohbet.Show();
                    }
                    else
                    {
                        FrmSohbet frmSohbet2 = new FrmSohbet();
                        frmSohbet2.infos = infos;
                        frmSohbet2.alan = item.AdSoyad;
                        frmSohbet2.WindowState = FormWindowState.Minimized;
                        frmSohbet2.Show();
                        frmSohbet2.WindowState = FormWindowState.Normal;
                        frmSohbet2.Text = item.AdSoyad;
                        frmSohbet2.Show();
                    }
                }

                sohbets = new List<Sohbet>();
            }
        }

        private void altYükKontKoordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAltYukIzleme frmAltYukIzleme = new FrmAltYukIzleme();
            frmAltYukIzleme.Show();
        }

        private void slatyGörünümToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAcikArizaGrafikleri frmAcikArizaGrafikleri = new FrmAcikArizaGrafikleri();
            frmAcikArizaGrafikleri.Show();
        }

        private void slaytGörünümToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmIzlemeSure frmIzlemeSure = new FrmIzlemeSure();
            frmIzlemeSure.Show();
        }

        private void bölgeBazlıİşlemAdımıGrafiğiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void etiketYazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEtiketYaz frmEtiketYaz = new FrmEtiketYaz();
            frmEtiketYaz.ShowDialog();
        }


        bool controlKapatma = false;
        private void FrmAnaSayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (controlKapatma == false)
            {
                if (kapatBilgisi == false)
                {
                    IslemleriSil();
                    controlKapatma = true;
                    PersonelDurumPasif();
                    Application.Exit();
                }
                
                DialogResult sonuc = MessageBox.Show("DTS Uygulamanızı kapatmak istiyor musunuz?", "SORU", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                IslemleriSil();
                controlKapatma = true;
                PersonelDurumPasif();
                Application.Exit();
            }

        }
        public void IslemleriSil()
        {
            var form = (DuranVarlik)Application.OpenForms["DuranVarlik"];
            if (form != null)
            {
                if (form.kaydet == false)
                {
                    dvNoManager.UpdateAzalt();
                    if (form.dosyaYolu != "")
                    {
                        Directory.Delete(form.dosyaYolu, true);
                    }
                }
            }
        }
    }
}

