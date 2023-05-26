using Business;
using DataAccess.Concreate;
using Entity;
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
    public partial class FrmAltYukIzleme : Form
    {
        ArizaIslemAdimiManager arizaIslemAdimiManager;
        public FrmAltYukIzleme()
        {
            InitializeComponent();
            arizaIslemAdimiManager = ArizaIslemAdimiManager.GetInstance();
        }

        private void FrmAltYukIzleme_Load(object sender, EventArgs e)
        {
            TimerSaat.Start();
            DataDisplay();
            timer1.Start();
        }

        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = DateTime.Now.ToString("HH:mm:ss");
            LblTarih.Text = DateTime.Now.ToLongDateString();
        }

        void DataDisplay()
        {
            ArizaIslemAdimi arizaIslemAdimi200 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM SERVİS PLANLAMA");
            LblServisPSirnak.Text = arizaIslemAdimi200.Sirnak.ToString();
            LblLblServisPCukurca.Text = arizaIslemAdimi200.Cukurca.ToString();
            LblLblServisPYukseova.Text = arizaIslemAdimi200.Yukseova.ToString();
            LblLblServisPSemdinli.Text = arizaIslemAdimi200.Semdinli.ToString();
            LblLblServisPDerecik.Text = arizaIslemAdimi200.Derecik.ToString();
            LblLblServisPDBolgesi.Text = arizaIslemAdimi200.DBolgesi.ToString();
            LblServisPToplam.Text = arizaIslemAdimi200.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi300 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (ASELSAN NET)");
            LblAselsanSirnak.Text = arizaIslemAdimi300.Sirnak.ToString();
            LblAselsanCukurca.Text = arizaIslemAdimi300.Cukurca.ToString();
            LblAselsanYukseova.Text = arizaIslemAdimi300.Yukseova.ToString();
            LblAselsanSemdinli.Text = arizaIslemAdimi300.Semdinli.ToString();
            LblAselsanDerecik.Text = arizaIslemAdimi300.Derecik.ToString();
            LblAselsanDBolgesi.Text = arizaIslemAdimi300.DBolgesi.ToString();
            LblAselsanToplam.Text = arizaIslemAdimi300.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi400 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (TEKJEN)");
            LblTekjenSirnak.Text = arizaIslemAdimi400.Sirnak.ToString();
            LblTekjenCukurca.Text = arizaIslemAdimi400.Cukurca.ToString();
            LblTekjenYukseova.Text = arizaIslemAdimi400.Yukseova.ToString();
            LblTekjenSemdinli.Text = arizaIslemAdimi400.Semdinli.ToString();
            LblTekjenDerecik.Text = arizaIslemAdimi400.Derecik.ToString();
            LblTekjenDBolgesi.Text = arizaIslemAdimi400.DBolgesi.ToString();
            LblTekjenToplam.Text = arizaIslemAdimi400.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi500 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (TESKOM)");
            LblTescomSirnak.Text = arizaIslemAdimi500.Sirnak.ToString();
            LblTescomCukurca.Text = arizaIslemAdimi500.Cukurca.ToString();
            LblTescomYukseova.Text = arizaIslemAdimi500.Yukseova.ToString();
            LblTescomSemdinli.Text = arizaIslemAdimi500.Semdinli.ToString();
            LblTescomDerecik.Text = arizaIslemAdimi500.Derecik.ToString();
            LblTescomDBolgesi.Text = arizaIslemAdimi500.DBolgesi.ToString();
            LblTescomToplam.Text = arizaIslemAdimi500.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi600 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (İŞBİR)");
            LblIsbirSirnak.Text = arizaIslemAdimi600.Sirnak.ToString();
            LblIsbirCukurca.Text = arizaIslemAdimi600.Cukurca.ToString();
            LblIsbirYukseova.Text = arizaIslemAdimi600.Yukseova.ToString();
            LblIsbirSemdinli.Text = arizaIslemAdimi600.Semdinli.ToString();
            LblIsbirDerecik.Text = arizaIslemAdimi600.Derecik.ToString();
            LblIsbirDBolgesi.Text = arizaIslemAdimi600.DBolgesi.ToString();
            LblIsbirToplam.Text = arizaIslemAdimi600.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi700 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (VAN TECH)");
            LblVanTechSirnak.Text = arizaIslemAdimi700.Sirnak.ToString();
            LblVanTechCukurca.Text = arizaIslemAdimi700.Cukurca.ToString();
            LblVanTechYukseova.Text = arizaIslemAdimi700.Yukseova.ToString();
            LblVanTechSemdinli.Text = arizaIslemAdimi700.Semdinli.ToString();
            LblVanTechDerecik.Text = arizaIslemAdimi700.Derecik.ToString();
            LblVanTechDBolgesi.Text = arizaIslemAdimi700.DBolgesi.ToString();
            LblVanTechToplam.Text = arizaIslemAdimi700.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi800 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (ŞARK UPS)");
            LblSarkUpsSirnak.Text = arizaIslemAdimi800.Sirnak.ToString();
            LblSarkUpsCukurca.Text = arizaIslemAdimi800.Cukurca.ToString();
            LblSarkUpsYukseova.Text = arizaIslemAdimi800.Yukseova.ToString();
            LblSarkUpsSemdinli.Text = arizaIslemAdimi800.Semdinli.ToString();
            LblSarkUpsDerecik.Text = arizaIslemAdimi800.Derecik.ToString();
            LblSarkUpsDBolgesi.Text = arizaIslemAdimi800.DBolgesi.ToString();
            LblSarkUpsToplam.Text = arizaIslemAdimi800.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1000 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (MAKSELSAN)");
            LblMakelsanSirnak.Text = arizaIslemAdimi1000.Sirnak.ToString();
            LblMakelsanCukurca.Text = arizaIslemAdimi1000.Cukurca.ToString();
            LblMakelsanYukseova.Text = arizaIslemAdimi1000.Yukseova.ToString();
            LblMakelsanSemdinli.Text = arizaIslemAdimi1000.Semdinli.ToString();
            LblMakelsanDerecik.Text = arizaIslemAdimi1000.Derecik.ToString();
            LblMakelsanDBolgesi.Text = arizaIslemAdimi1000.DBolgesi.ToString();
            LblMakelsanToplam.Text = arizaIslemAdimi1000.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1100 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (KELEŞ İNŞ)");
            LblKelesSirnak.Text = arizaIslemAdimi1100.Sirnak.ToString();
            LblKelesCukurca.Text = arizaIslemAdimi1100.Cukurca.ToString();
            LblKelesYukseova.Text = arizaIslemAdimi1100.Yukseova.ToString();
            LblKelesSemdinli.Text = arizaIslemAdimi1100.Semdinli.ToString();
            LblKelesDerecik.Text = arizaIslemAdimi1100.Derecik.ToString();
            LblKelesDBolgesi.Text = arizaIslemAdimi1100.DBolgesi.ToString();
            LblKelesToplam.Text = arizaIslemAdimi1100.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1200 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (DORÇE)");
            LblDorceSirnak.Text = arizaIslemAdimi1200.Sirnak.ToString();
            LblDorceCukurca.Text = arizaIslemAdimi1200.Cukurca.ToString();
            LblDorceYukseova.Text = arizaIslemAdimi1200.Yukseova.ToString();
            LblDorceSemdinli.Text = arizaIslemAdimi1200.Semdinli.ToString();
            LblDorceDerecik.Text = arizaIslemAdimi1200.Derecik.ToString();
            LblDorceDBolgesi.Text = arizaIslemAdimi1200.DBolgesi.ToString();
            LblDorceToplam.Text = arizaIslemAdimi1200.Toplam.ToString();

            ArizaIslemAdimi arizaIslemAdimi1300 = arizaIslemAdimiManager.Get("1600_BAKIM ONARIM (İNFORM)");
            LblInformSirnak.Text = arizaIslemAdimi1300.Sirnak.ToString();
            LblInformCukurca.Text = arizaIslemAdimi1300.Cukurca.ToString();
            LblInformYukseova.Text = arizaIslemAdimi1300.Yukseova.ToString();
            LblInformSemdinli.Text = arizaIslemAdimi1300.Semdinli.ToString();
            LblInformDerecik.Text = arizaIslemAdimi1300.Derecik.ToString();
            LblInformDBolgesi.Text = arizaIslemAdimi1300.DBolgesi.ToString();
            LblInformToplam.Text = arizaIslemAdimi1300.Toplam.ToString();
            

            LblToplamSirnak.Text = (LblServisPSirnak.Text.ConInt() + LblAselsanSirnak.Text.ConInt() + LblTekjenSirnak.Text.ConInt() + LblTescomSirnak.Text.ConInt() + LblIsbirSirnak.Text.ConInt() + LblVanTechSirnak.Text.ConInt() + LblSarkUpsSirnak.Text.ConInt()+ LblMakelsanSirnak.Text.ConInt() + LblKelesSirnak.Text.ConInt() + LblDorceSirnak.Text.ConInt() + LblInformSirnak.Text.ConInt()).ToString();

            LblToplamCukurca.Text = (LblLblServisPCukurca.Text.ConInt() + LblAselsanCukurca.Text.ConInt() + LblTekjenCukurca.Text.ConInt() + LblTescomCukurca.Text.ConInt() + LblIsbirCukurca.Text.ConInt() + LblVanTechCukurca.Text.ConInt() + LblSarkUpsCukurca.Text.ConInt() + LblMakelsanCukurca.Text.ConInt() + LblKelesCukurca.Text.ConInt() + LblDorceCukurca.Text.ConInt() + LblInformCukurca.Text.ConInt()).ToString();

            LblToplamYukseova.Text = (LblLblServisPYukseova.Text.ConInt() + LblAselsanYukseova.Text.ConInt() + LblTekjenYukseova.Text.ConInt() + LblTescomYukseova.Text.ConInt() + LblIsbirYukseova.Text.ConInt() + LblVanTechYukseova.Text.ConInt() + LblSarkUpsYukseova.Text.ConInt() + LblMakelsanYukseova.Text.ConInt() + LblKelesYukseova.Text.ConInt() + LblDorceYukseova.Text.ConInt() + LblInformYukseova.Text.ConInt()).ToString();

            LblToplamSemdinli.Text = (LblLblServisPSemdinli.Text.ConInt() + LblAselsanSemdinli.Text.ConInt() + LblTekjenSemdinli.Text.ConInt() + LblTescomSemdinli.Text.ConInt() + LblIsbirSemdinli.Text.ConInt() + LblVanTechSemdinli.Text.ConInt() + LblSarkUpsSemdinli.Text.ConInt() + LblMakelsanSemdinli.Text.ConInt() + LblKelesSemdinli.Text.ConInt() + LblDorceSemdinli.Text.ConInt() + LblInformSemdinli.Text.ConInt()).ToString();

            LblToplamDerecik.Text = (LblLblServisPDerecik.Text.ConInt() + LblAselsanDerecik.Text.ConInt() + LblTekjenDerecik.Text.ConInt() + LblTescomDerecik.Text.ConInt() + LblIsbirDerecik.Text.ConInt() + LblVanTechDerecik.Text.ConInt() + LblSarkUpsDerecik.Text.ConInt() + LblMakelsanDerecik.Text.ConInt() + LblKelesDerecik.Text.ConInt() + LblDorceDerecik.Text.ConInt() + LblInformDerecik.Text.ConInt()).ToString();

            LblToplamDBolgesi.Text = (LblLblServisPDBolgesi.Text.ConInt() + LblAselsanDBolgesi.Text.ConInt() + LblTekjenDBolgesi.Text.ConInt() + LblTescomDBolgesi.Text.ConInt() + LblIsbirDBolgesi.Text.ConInt() + LblVanTechDBolgesi.Text.ConInt() + LblSarkUpsDBolgesi.Text.ConInt() + LblSarkUpsDBolgesi.Text.ConInt() + LblMakelsanDBolgesi.Text.ConInt() + LblKelesDBolgesi.Text.ConInt() + LblDorceDBolgesi.Text.ConInt() + LblInformDBolgesi.Text.ConInt()).ToString();

            LblGenelToplam.Text = (LblServisPToplam.Text.ConInt() + LblAselsanToplam.Text.ConInt() + LblTekjenToplam.Text.ConInt() + LblTescomToplam.Text.ConInt() + LblIsbirToplam.Text.ConInt() + LblVanTechToplam.Text.ConInt() + LblSarkUpsToplam.Text.ConInt() + LblMakelsanToplam.Text.ConInt() + LblKelesToplam.Text.ConInt() + LblDorceToplam.Text.ConInt() + LblInformToplam.Text.ConInt()).ToString();

            LblTop.Text = LblGenelToplam.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataDisplay();
        }

        private void FrmAltYukIzleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            TimerSaat.Stop();
            FrmAnaSayfa anaSayfa = (FrmAnaSayfa)Application.OpenForms["FrmAnaSayfa"];
            anaSayfa.timerIzlemeChc.Stop();
        }
    }
}
