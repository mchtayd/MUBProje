using Business.Concreate.BakimOnarimAtolye;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.BakımOnarım
{
    public partial class FrmIslemAdimiEdit : Form
    {
        List<IslemAdimlari> ıslemAdimlaris = new List<IslemAdimlari>();
        IslemAdimlariManager islemAdimlariManager;
        public FrmIslemAdimiEdit()
        {
            InitializeComponent();
            islemAdimlariManager = IslemAdimlariManager.GetInstance();
        }

        private void FrmIslemAdimiEdit_Load(object sender, EventArgs e)
        {
            
        }

        private void CmbDepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            ıslemAdimlaris = new List<IslemAdimlari>();
            if (CmbDepartman.Text == "")
            {
                DtgList.DataSource = null;
                return;
            }
            if (CmbDepartman.Text == "BAKIM ONARIM (SAHA)")
            {
                ıslemAdimlaris = islemAdimlariManager.GetList("BAKIM ONARIM");
            }
            else
            {
                ıslemAdimlaris = islemAdimlariManager.GetList("BAKIM ONARIM ATOLYE");
            }

            DtgList.Rows.Clear();
            foreach (IslemAdimlari item in ıslemAdimlaris)
            {
                DtgList.Rows.Add();
                int sonIndex = DtgList.RowCount - 1;
                DtgList.Rows[sonIndex].Cells["Id"].Value = item.Id;
                DtgList.Rows[sonIndex].Cells["Departman"].Value = item.Departman;
                DtgList.Rows[sonIndex].Cells["IslemAdimi"].Value = item.IslemaAdimi;
            }

            TxtTop.Text = DtgList.RowCount.ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bilgileri kaydetmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                foreach (DataGridViewRow item in DtgList.Rows)
                {
                    if (item.Cells["IslemAdimi"].Value==null)
                    {
                        continue;
                    }

                    IslemAdimlari ıslemAdimlari = new IslemAdimlari(item.Cells["IslemAdimi"].Value.ToString(), item.Cells["Departman"].Value.ToString());
                    islemAdimlariManager.Add(ıslemAdimlari);
                }

                foreach (IslemAdimlari item in ıslemAdimlaris)
                {
                    islemAdimlariManager.Delete(item.Id);
                }

                CmbDepartman.SelectedIndex = -1;
                TxtIslemAdimi.Clear();
                MessageBox.Show("Bilgiler başarıyla kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            DtgList.Rows.Add();
            int sonIndex = DtgList.RowCount - 1;
            DtgList.Rows[sonIndex].Cells["Id"].Value = 0;
            if (CmbDepartman.Text== "BAKIM ONARIM (SAHA)")
            {
                DtgList.Rows[sonIndex].Cells["Departman"].Value = "BAKIM ONARIM";
            }
            else
            {
                DtgList.Rows[sonIndex].Cells["Departman"].Value = "BAKIM ONARIM ATOLYE";
            }
            
            DtgList.Rows[sonIndex].Cells["IslemAdimi"].Value = TxtIslemAdimi.Text;
            TxtTop.Text = DtgList.RowCount.ToString();
        }
    }
}
