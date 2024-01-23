using Business.Concreate.IdarıIsler;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Presentation;
using Entity.IdariIsler;
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

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmTelefonRehberi : Form
    {
        PersonelKayitManager personelKayitManager;
        IzinManager izinManager;
        bool start =false;
        List<PersonelKayit> personelKayitList;
        public FrmTelefonRehberi()
        {
            InitializeComponent();
            personelKayitManager = PersonelKayitManager.GetInstance();
            izinManager = IzinManager.GetInstance();
        }

        private void FrmTelefonRehberi_Load(object sender, EventArgs e)
        {
            BolumFill();
            PersonelFill();
            start = true;
        }
        void BolumFill()
        {
            CmbBolum.DataSource = personelKayitManager.SirketBolumList();
            CmbBolum.SelectedIndex= -1;
        }
        void PersonelFill()
        {
            CmbAdSoyad.DataSource = personelKayitManager.PersonelAdSoyad();
            CmbAdSoyad.ValueMember = "Id";
            CmbAdSoyad.DisplayMember = "Adsoyad";
            CmbAdSoyad.SelectedValue = -1;
        }

        private void CmbAdSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbAdSoyad.SelectedIndex==-1)
            {
                return;
            }
            if (start==false)
            {
                return;
            }
            DtgList.Rows.Clear();
            CmbBolum.SelectedIndex= -1;

            Izin ızin = izinManager.Get(0, CmbAdSoyad.Text);

            PersonelKayit personelKayit = personelKayitManager.Get(0, CmbAdSoyad.Text);

            string foto = personelKayit.Fotoyolu + "\\" + CmbAdSoyad.Text + ".jpg";

            if (DtgList.RowCount==0)
            {
                DtgList.Rows.Add();
            }

            Image image;
            image = Image.FromFile(foto);
            DtgList.Rows[0].Cells["Photo"].Value = image;

            DtgList.Rows[0].Cells["PersonelAd"].Value = personelKayit.Adsoyad;
            DtgList.Rows[0].Cells["Sicil"].Value = personelKayit.Sicil;
            DtgList.Rows[0].Cells["Unvani"].Value = personelKayit.Isunvani;
            if (ızin != null)
            {
                if (ızin.Izindurumu == "BİTTİ")
                {
                    DtgList.Rows[0].Cells["Durum"].Value = "ÇALIŞIYOR";
                }
                else
                {
                    DtgList.Rows[0].Cells["Durum"].Value = "PERSONEL " + ızin.Bittarihi.ToString("d") + " TARİHİNE KADAR İZİNLİDİR.";
                }
            }
            else
            {
                DtgList.Rows[0].Cells["Durum"].Value = "ÇALIŞIYOR";
            }

            DtgList.Rows[0].Cells["KisaKod"].Value = personelKayit.Sirketkisakod;
            DtgList.Rows[0].Cells["Telefon"].Value = personelKayit.Sirketcep;
            DtgList.Rows[0].Cells["DahiliNo"].Value = personelKayit.Dahilino;
            DtgList.Rows[0].Cells["Mail"].Value = personelKayit.Sirketmail;

        }

        private void CmbBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbBolum.SelectedIndex==-1)
            {
                return;
            }
            if (start==false)
            {
                return;
            }
            CmbAdSoyad.SelectedIndex = -1;

            string[] bolum = CmbBolum.Text.Split('/');
            if (bolum.Length<2)
            {
                personelKayitList = personelKayitManager.PersonelBilgiList(bolum[0].ToString());
            }
            else
            {
                if (bolum.Length > 2)
                {
                    personelKayitList = personelKayitManager.PersonelBilgiList(bolum[0].ToString() + "/" + bolum[1].ToString()+ "/" + bolum[2].ToString());
                }
                else
                {
                    personelKayitList = personelKayitManager.PersonelBilgiList(bolum[0].ToString() + "/" + bolum[1].ToString());
                }
                
            }
            DtgList.Rows.Clear();

            foreach (PersonelKayit item in personelKayitList)
            {
                string foto = item.Fotoyolu + "\\" + item.Adsoyad + ".jpg";
                Izin ızin = izinManager.Get(0, item.Adsoyad);
                DtgList.Rows.Add();
                int sonSatir = DtgList.RowCount - 1;
                Image image;
                image = Image.FromFile(foto);
                DtgList.Rows[sonSatir].Cells["Photo"].Value = image;
                DtgList.Rows[sonSatir].Cells["PersonelAd"].Value = item.Adsoyad;
                DtgList.Rows[sonSatir].Cells["Sicil"].Value = item.Sicil;
                DtgList.Rows[sonSatir].Cells["Unvani"].Value = item.Isunvani;
                if (ızin!=null)
                {
                    if (ızin.Izindurumu == "BİTTİ")
                    {
                        DtgList.Rows[sonSatir].Cells["Durum"].Value = "ÇALIŞIYOR";
                    }
                    else
                    {
                        DtgList.Rows[sonSatir].Cells["Durum"].Value = "PERSONEL " + ızin.Bittarihi.ToString("d") + " TARİHİNE KADAR İZİNLİDİR.";
                    }
                }
                else
                {
                    DtgList.Rows[sonSatir].Cells["Durum"].Value = "ÇALIŞIYOR";
                }
                DtgList.Rows[sonSatir].Cells["KisaKod"].Value = item.Sirketkisakod;
                DtgList.Rows[sonSatir].Cells["Telefon"].Value = item.Sirketcep;
                DtgList.Rows[sonSatir].Cells["DahiliNo"].Value = item.Dahilino;
                DtgList.Rows[sonSatir].Cells["Mail"].Value = item.Sirketmail;
            }

        }
    }
}
