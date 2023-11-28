using Business.Concreate.AnaSayfa;
using DataAccess.Concreate;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Ana_Sayfa
{
    public partial class FrmGorevUyarilari : Form
    {
        PersonelUyariManager personelUyariManager;
        List<PersonelUyari> personelUyarisGuncel = new List<PersonelUyari>();
        List<PersonelUyari> personelUyarisGorunen = new List<PersonelUyari>();
        List<PersonelUyari> personelUyarisUyarilanlar = new List<PersonelUyari>();
        public object[] infos;
        public FrmGorevUyarilari()
        {
            InitializeComponent();
            personelUyariManager = PersonelUyariManager.GetInstance();
        }

        private void FrmGorevUyarilari_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }

        void DataDisplay()
        {
            personelUyarisGuncel = personelUyariManager.PersonelGetList(infos[1].ToString(), "GÖRÜLMEDİ");
            dataBinderGuncel.DataSource = personelUyarisGuncel.ToDataTable();
            DtgList.DataSource = dataBinderGuncel;
            TxtTop.Text = DtgList.RowCount.ToString();

            DtgList.Columns["Id"].Visible = false;
            DtgList.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgList.Columns["UyarmaTarihi"].HeaderText = "UYARMA TARİHİ";
            DtgList.Columns["UyaranPersonel"].HeaderText = "UYARAN PERSONEL";
            DtgList.Columns["UyarilanPersonel"].Visible = false;
            DtgList.Columns["MesajId"].Visible = false;
            DtgList.Columns["GorulmeDurumu"].Visible = false;
            DtgList.Columns["GorulmeTarihi"].Visible = false;
            DtgList.Columns["UyariMiktar"].HeaderText = "UYARILMA MİKTARI";


            personelUyarisGorunen = personelUyariManager.PersonelGetList(infos[1].ToString(), "GÖRÜLDÜ");
            dataBinderGorunen.DataSource = personelUyarisGorunen.ToDataTable();
            DtgListGorunen.DataSource = dataBinderGorunen;
            LblGorunenTop.Text = DtgListGorunen.RowCount.ToString();

            DtgListGorunen.Columns["Id"].Visible = false;
            DtgListGorunen.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgListGorunen.Columns["UyarmaTarihi"].HeaderText = "UYARMA TARİHİ";
            DtgListGorunen.Columns["UyaranPersonel"].HeaderText = "UYARAN PERSONEL";
            DtgListGorunen.Columns["UyarilanPersonel"].Visible = false;
            DtgListGorunen.Columns["MesajId"].Visible = false;
            DtgListGorunen.Columns["GorulmeDurumu"].Visible = false;
            DtgListGorunen.Columns["GorulmeTarihi"].Visible = false;
            DtgListGorunen.Columns["UyariMiktar"].HeaderText = "UYARILMA MİKTARI";



            personelUyarisUyarilanlar = personelUyariManager.GetList(infos[1].ToString());
            dataBinderUyarilan.DataSource = personelUyarisUyarilanlar.ToDataTable();
            DtgListUyarilan.DataSource = dataBinderUyarilan;
            LblUyarilanTop.Text = DtgListUyarilan.RowCount.ToString();

            DtgListUyarilan.Columns["Id"].Visible = false;
            DtgListUyarilan.Columns["AbfNo"].HeaderText = "ABF NO";
            DtgListUyarilan.Columns["UyarmaTarihi"].HeaderText = "UYARMA TARİHİ";
            DtgListUyarilan.Columns["UyaranPersonel"].HeaderText = "UYARAN PERSONEL";
            DtgListUyarilan.Columns["UyarilanPersonel"].HeaderText = "UYARILAN PERSONEL";
            DtgListUyarilan.Columns["MesajId"].Visible = false;
            DtgListUyarilan.Columns["GorulmeDurumu"].HeaderText = "GÖRÜLME DURUMU";
            DtgListUyarilan.Columns["GorulmeTarihi"].HeaderText = "GÖRÜLME TARİHİ";
            DtgListUyarilan.Columns["UyariMiktar"].HeaderText = "UYARILMA MİKTARI";

            if (personelUyarisGuncel.Count>0)
            {
                foreach (PersonelUyari item in personelUyarisGuncel)
                {
                    personelUyariManager.Update(item.Id);
                }
            }
        }
    }
}
