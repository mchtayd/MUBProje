using Business.Concreate;
using Business.Concreate.AnaSayfa;
using Business.Concreate.IdarıIsler;
using DataAccess.Concreate;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
using Entity;
using Entity.AnaSayfa;
using Entity.BakimOnarim;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.BakımOnarım;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmGorevliPersoneller : Form
    {
        public object[] infos;
        GorevAtamaPersonelManager gorevAtamaPersonelManager;
        PersonelUyariManager personelUyariManager;
        PersonelKayitManager personelKayitManager;
        List<GorevAtamaPersonel> gorevliPersoneller;
        List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
        string personel = "";
        int abfNo;
        public FrmGorevliPersoneller()
        {
            InitializeComponent();
            gorevAtamaPersonelManager = GorevAtamaPersonelManager.GetInstance();
            personelKayitManager = PersonelKayitManager.GetInstance();
            personelUyariManager = PersonelUyariManager.GetInstance();
        }
        
        private void FrmGorevliPersoneller_Load(object sender, EventArgs e)
        {
            if (infos[1].ToString()=="MÜCAHİT AYDEMİR")
            {
                button1.Visible = true;
            }
            DataDisplay();
        }
        void DataDisplay()
        {
            gorevliPersoneller = new List<GorevAtamaPersonel>();
            gorevliPersoneller = gorevAtamaPersonelManager.GorevliPersoneller();

            dataBinder.DataSource = gorevliPersoneller.ToDataTable();
            DtgList.DataSource = dataBinder;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["BenzersizId"].Visible = false;
            DtgList.Columns["Departman"].Visible = false;
            DtgList.Columns["GorevAtanacakPersonel"].HeaderText = "PERSONEL";
            DtgList.Columns["IslemAdimi"].Visible = false;
            DtgList.Columns["Tarih"].Visible = false;
            DtgList.Columns["Sure"].Visible = false;
            DtgList.Columns["YapilanIslem"].Visible = false;
            DtgList.Columns["CalismaSuresi"].Visible = false;
            DtgList.Columns["AbfNo"].Visible = false;
            DtgList.Columns["DevamEdenGorev"].HeaderText = "DEVAM EDEN\nBİLDİRİM GÖREV\nSAYISI";
            DtgList.Columns["TamamlananGorev"].HeaderText = "TOPLAM TAMAMLADIĞI\nBİLDİRİM GÖREV\nSAYISI";
            DtgList.Columns["ToplamGorevSayisi"].HeaderText = "TOPLAM ATANAN\nBİLDİRİM GÖREV\nSAYISI";
            DtgList.Columns["BeklemeSuresi"].Visible = false;
            DtgList.Columns["SirketBolum"].HeaderText = "BÖLÜM";
            DtgList.Columns["DevamEdenSureOrtGun"].HeaderText = "DEVAM EDEN\nBİLDİRİM SÜRE\nORTALAMASI";
            DtgList.Columns["TamamlananGorevOrtSure"].HeaderText = "TAMAMLANAN\nBİLDİRİM SÜRE\nORTALAMASI";

            DtgList.Columns["GorevAtanacakPersonel"].DisplayIndex = 0;
            DtgList.Columns["SirketBolum"].DisplayIndex = 1;
            DtgList.Columns["ToplamGorevSayisi"].DisplayIndex = 2;
            DtgList.Columns["TamamlananGorev"].DisplayIndex = 3;
            DtgList.Columns["TamamlananGorevOrtSure"].DisplayIndex = 4;
            DtgList.Columns["DevamEdenGorev"].DisplayIndex = 6;
            DtgList.Columns["DevamEdenSureOrtGun"].DisplayIndex = 8;
            Toplamlar();
        }

        void Toplamlar()
        {
            int toplam = 0;
            for (int i = 0; i < DtgList.Rows.Count; ++i)
            {
                toplam += DtgList.Rows[i].Cells["Sure"].Value.ConInt();
            }
            LblToplamGorev.Text = toplam.ToString();
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            personel = DtgList.CurrentRow.Cells["GorevAtanacakPersonel"].Value.ToString();
            
            gorevAtamaPersonels = gorevAtamaPersonelManager.IsAkisGorevlerimiGor(personel, "BAKIM ONARIM");
            dataBinder2.DataSource = gorevAtamaPersonels.ToDataTable();
            DtgGorevler.DataSource = dataBinder2;

            DtgGorevler.Columns["Id"].Visible = false;
            DtgGorevler.Columns["BenzersizId"].Visible = false;
            DtgGorevler.Columns["Departman"].Visible = false;
            DtgGorevler.Columns["GorevAtanacakPersonel"].HeaderText = "PERSONEL";
            DtgGorevler.Columns["IslemAdimi"].HeaderText = "İŞLEM ADIMI";
            DtgGorevler.Columns["Tarih"].HeaderText = "GÖREVİN ATILMA TARİHİ";
            DtgGorevler.Columns["Sure"].Visible = false;
            DtgGorevler.Columns["YapilanIslem"].Visible = false;
            DtgGorevler.Columns["CalismaSuresi"].Visible = false;
            DtgGorevler.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgGorevler.Columns["DevamEdenGorev"].Visible = false;
            DtgGorevler.Columns["TamamlananGorev"].Visible = false;
            DtgGorevler.Columns["BeklemeSuresi"].HeaderText = "BEKLEME SÜRESİ (GÜN)";
            DtgGorevler.Columns["SirketBolum"].Visible = false;
            DtgGorevler.Columns["DevamEdenSureOrtGun"].Visible = false;
            DtgGorevler.Columns["TamamlananGorevOrtSure"].Visible = false;
            DtgGorevler.Columns["ToplamGorevSayisi"].Visible = false;
            PersonelBilgi();
        }

        void PersonelBilgi()
        {
            //PersonelKayit personelKayit = personelKayitManager.Get(0, personel);
            //if (personelKayit==null)
            //{
            //    PcFoto.ImageLocation = "";
            //}
            //else
            //{
            //    string deneme = "\\" + personel + ".jpg";
            //    string foto = personelKayit.Fotoyolu;
            //    PcFoto.ImageLocation = foto + deneme;
            //}
            

            //GorevAtamaPersonel gorevAtamaPersonel = gorevAtamaPersonelManager.GorevSayilari(personel);
            //LblTamamlananGorev.Text = gorevAtamaPersonel.TamamlananGorev.ToString();
            //LblDevamEdenGorev.Text = gorevAtamaPersonel.DevamEdenGorev.ToString();
            //LblToplamGorevSayisi.Text = (LblTamamlananGorev.Text.ConInt() + LblDevamEdenGorev.Text.ConInt()).ToString();

            //MudehaleSuresi();
        }

        private void DtgList_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder.Filter = DtgList.FilterString;
            TxtTop.Text = DtgList.RowCount.ToString();

        }

        private void DtgList_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder.Sort = DtgList.SortString;
        }

        private void DtgGorevler_FilterStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Filter = DtgGorevler.FilterString;
        }

        private void DtgGorevler_SortStringChanged(object sender, EventArgs e)
        {
            dataBinder2.Sort = DtgGorevler.SortString;
        }

        private void göreviGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (abfNo==0)
            {
                MessageBox.Show("Lütfen görüntilemek istediğiniz görevi seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmGorevBilgileri frmGorevBilgileri = new FrmGorevBilgileri();
            frmGorevBilgileri.infos = infos;
            frmGorevBilgileri.abfNo = abfNo;
            frmGorevBilgileri.Show();
            abfNo = 0;
        }

        private void DtgGorevler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgGorevler.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            abfNo = DtgGorevler.CurrentRow.Cells["AbfNo"].Value.ConInt();
            personel = DtgGorevler.CurrentRow.Cells["GorevAtanacakPersonel"].Value.ToString();
        }

        private void açıklamaTalepEtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmGorevAciklamaTalebi frmGorevAciklamaTalebi = new FrmGorevAciklamaTalebi();
            frmGorevAciklamaTalebi.infos = infos;
            frmGorevAciklamaTalebi.ShowDialog();
        }

        private void açıklamaTalepEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (abfNo==0)
            {
                MessageBox.Show("Lütfen öncelikle bir kayıt seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show(abfNo + " numaralı arıza için ilgili personeli uyarmak istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                PersonelUyari personelUyari = new PersonelUyari(abfNo, DateTime.Now, infos[1].ToString(), personel, 0);
                string mesaj = personelUyariManager.Add(personelUyari);
                if (mesaj!="OK")
                {
                    MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Personel başarıyla uyarılmıştır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bütün fazla görevler temizlenecek onaylıyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                List<int> idLer = new List<int>();
                int sayi = 0;

                idLer = gorevAtamaPersonelManager.HataliGorevler();
                sayi = idLer.Count;
                foreach (int item in idLer)
                {
                    int id = gorevAtamaPersonelManager.HataliGorevlerId(item);
                    gorevAtamaPersonelManager.HataliGorevSil(id);
                }

                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                gorevAtamaPersonels = gorevAtamaPersonelManager.TamamlananGorevler();

                foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
                {
                    List<GorevAtamaPersonel> gorevAtamaPersonels1 = new List<GorevAtamaPersonel>();
                    List<GorevAtamaPersonel> gorevAtamaPersonels2 = new List<GorevAtamaPersonel>();
                    gorevAtamaPersonels1 = gorevAtamaPersonelManager.TamamlananHataliGorevler(item.BenzersizId);
                    gorevAtamaPersonels2 = gorevAtamaPersonelManager.GetList(item.BenzersizId, "BAKIM ONARIM");
                    if (gorevAtamaPersonels1.Count>0 && gorevAtamaPersonels2[gorevAtamaPersonels2.Count-1].IslemAdimi == "2100_ARIZA KAPATMA BİLDİRİMİ (ASELSAN)")
                    {
                        sayi += gorevAtamaPersonels1.Count;
                        foreach (GorevAtamaPersonel item2 in gorevAtamaPersonels1)
                        {
                            gorevAtamaPersonelManager.HataliGorevSil(item2.Id);
                        }
                    }
                }

                MessageBox.Show(sayi.ToString() + " adet hatalı görev silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
