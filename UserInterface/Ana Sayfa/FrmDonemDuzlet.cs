using Business.Concreate;
using Business.Concreate.STS;
using DataAccess.Concreate;
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
    public partial class FrmDonemDuzlet : Form
    {
        SatDataGridview1Manager satDataGridview1Manager;
        TamamlananManager tamamlananManager;

        public FrmDonemDuzlet()
        {
            InitializeComponent();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            tamamlananManager = TamamlananManager.GetInstance();
        }
        private void FrmDonemDuzlet_Load(object sender, EventArgs e)
        {

        }

        private void CmbSatTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbSatTuru.SelectedIndex==0)
            {
                DtgList.DataSource = satDataGridview1Manager.DevamEdenler();
            }
            if (CmbSatTuru.SelectedIndex == 1)
            {
                DtgList.DataSource = tamamlananManager.GetList(0);
            }
        }
        string yeniDonem;
        string donem = "", siparisNo;
        int id;
        private void BtnDuzelt_Click(object sender, EventArgs e)
        {
            if (CmbSatTuru.SelectedIndex == 0)
            {
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    donem = item.Cells["Donem"].Value.ToString();
                    siparisNo = item.Cells["SiparisNo"].Value.ToString();

                    if (donem== "OCAK")
                    {
                        yeniDonem = "OCAK 2022";
                    }
                    if (donem == "ŞUBAT")
                    {
                        yeniDonem = "ŞUBAT 2021";
                    }
                    if (donem == "MART")
                    {
                        yeniDonem = "MART 2021";
                    }
                    if (donem == "NİSAN")
                    {
                        yeniDonem = "NİSAN 2021";
                    }
                    if (donem == "MAYIS")
                    {
                        yeniDonem = "MAYIS 2021";
                    }
                    if (donem == "HAZİRAN")
                    {
                        yeniDonem = "HAZİRAN 2021";
                    }
                    if (donem == "TEMMUZ")
                    {
                        yeniDonem = "TEMMUZ 2021";
                    }
                    if (donem == "AĞUSTOS")
                    {
                        yeniDonem = "AĞUSTOS 2021";
                    }
                    if (donem == "EYLÜL")
                    {
                        yeniDonem = "EYLÜL 2021";
                    }
                    if (donem == "EKİM")
                    {
                        yeniDonem = "EKİM 2021";
                    }
                    if (donem == "KASIM")
                    {
                        yeniDonem = "KASIM 2021";
                    }
                    if (donem == "ARALIK")
                    {
                        yeniDonem = "ARALIK 2021";
                    }
                    satDataGridview1Manager.DonemGuncelle(yeniDonem, siparisNo);

                }
            }
            if (CmbSatTuru.SelectedIndex == 1)
            {
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    donem = item.Cells["Donem"].Value.ToString();
                    id = item.Cells["Id"].Value.ConInt();

                    if (donem == "OCAK")
                    {
                        yeniDonem = "OCAK 2021";
                    }
                    if (donem == "ŞUBAT")
                    {
                        yeniDonem = "ŞUBAT 2021";
                    }
                    if (donem == "MART")
                    {
                        yeniDonem = "MART 2021";
                    }
                    if (donem == "NİSAN")
                    {
                        yeniDonem = "NİSAN 2021";
                    }
                    if (donem == "MAYIS")
                    {
                        yeniDonem = "MAYIS 2021";
                    }
                    if (donem == "HAZİRAN")
                    {
                        yeniDonem = "HAZİRAN 2021";
                    }
                    if (donem == "TEMMUZ")
                    {
                        yeniDonem = "TEMMUZ 2021";
                    }
                    if (donem == "AĞUSTOS")
                    {
                        yeniDonem = "AĞUSTOS 2021";
                    }
                    if (donem == "EYLÜL")
                    {
                        yeniDonem = "EYLÜL 2021";
                    }
                    if (donem == "EKİM")
                    {
                        yeniDonem = "EKİM 2021";
                    }
                    if (donem == "KASIM")
                    {
                        yeniDonem = "KASIM 2021";
                    }
                    if (donem == "ARALIK")
                    {
                        yeniDonem = "ARALIK 2021";
                    }
                    tamamlananManager.DonemDuzelt(yeniDonem, id);
                }
            }
            MessageBox.Show("Tamamlandı.");
        }

    }
}
