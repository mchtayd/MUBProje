using Business.Concreate;
using Business.Concreate.STS;
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

namespace UserInterface.STS
{
    public partial class FrmSatDosyaYoluDuzelt : Form
    {
        SatDataGridview1Manager satDataGridview1Manager;
        TamamlananManager tamamlananManager;
        string dosyaYolu, siparisNo, satno;
        int isAkisNo;
        public FrmSatDosyaYoluDuzelt()
        {
            InitializeComponent();
            satDataGridview1Manager = SatDataGridview1Manager.GetInstance();
            tamamlananManager = TamamlananManager.GetInstance();
        }

        private void FrmSatDosyaYoluDuzelt_Load(object sender, EventArgs e)
        {
            DtgList.DataSource = tamamlananManager.GetList(0);
            LblToplam.Text = DtgList.RowCount.ToString();

            //DtgList.DataSource = satDataGridview1Manager.List();
            //LblToplam.Text = DtgList.RowCount.ToString();
        }

        private void DtgList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgList.CurrentRow == null)
            {
                MessageBox.Show("Öncelikle bir kayıt seçiniz.");
                return;
            }
            dosyaYolu = DtgList.CurrentRow.Cells["DosyaYolu"].Value.ToString();
        }

        private void BtnOnayla_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tüm Yolları Düzeltmek İstediğinize Emin Misiniz?","Soru",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    dosyaYolu = item.Cells["Dosyayolu"].Value.ToString();
                    satno = item.Cells["Satno"].Value.ToString();
                    isAkisNo = item.Cells["Formno"].Value.ConInt();
                    siparisNo = item.Cells["Siparisno"].Value.ToString();

                    
                    if (satno=="0")
                    {
                        dosyaYolu = "Z:\\DTS\\SATIN ALMA\\GEÇİCİ SAT DOSYALARI\\" + isAkisNo;
                    }
                    if (satno != "0")
                    {
                        dosyaYolu = "Z:\\DTS\\SATIN ALMA\\SAT DOSYALARI\\" + satno;

                    }
                    satDataGridview1Manager.DosyaYoluDuzelt(dosyaYolu, siparisNo);


                }
                MessageBox.Show("Bilgiler Başarıyla Kaydedilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
