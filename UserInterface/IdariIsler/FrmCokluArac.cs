using Business.Concreate.IdarıIsler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.IdariIsler
{
    public partial class FrmCokluArac : Form
    {
        CokluAracManager cokluAracManager;
        public string siparisNo = "";
        public FrmCokluArac()
        {
            InitializeComponent();
            cokluAracManager = CokluAracManager.GetInstance();

        }

        private void FrmCokluArac_Load(object sender, EventArgs e)
        {
            DataDisplay();
        }
        void DataDisplay()
        {
            DtgAracList.DataSource = cokluAracManager.GetList(siparisNo);

            DtgAracList.Columns["Id"].Visible = false;
            DtgAracList.Columns["SiparisNo"].Visible = false;
            DtgAracList.Columns["Plaka"].HeaderText = "PLAKA";
            DtgAracList.Columns["BaslangicKm"].HeaderText = "BAŞLANGIÇ KM";
            DtgAracList.Columns["BitisKm"].HeaderText = "BİTİŞ KM";
            DtgAracList.Columns["ToplamKm"].HeaderText = "TOPLAM KM";
            DtgAracList.Columns["Aciklama"].HeaderText = "AÇIKLAMA";
            DtgAracList.Columns["BaslangicTarihi"].HeaderText = "BAŞLANGIÇ TARİHİ";
            DtgAracList.Columns["BitisTarihi"].HeaderText = "BİTİŞ TARİHİ";

            Toplamlar();
        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgAracList.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgAracList.Rows[i].Cells[5].Value);
            }
            LblToplamKm.Text = toplam.ToString();
        }
    }
}
