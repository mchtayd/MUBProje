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
    public partial class FrmKonaklamaDetayi : Form
    {
        KonaklamaKirilimManager konaklamaKirilimManager;
        public int isAkisNo;
        public FrmKonaklamaDetayi()
        {
            InitializeComponent();
            konaklamaKirilimManager = KonaklamaKirilimManager.GetInstance();
        }

        private void FrmKonaklamaDetayi_Load(object sender, EventArgs e)
        {
            Display();
            Toplamlar();
        }
        void Display()
        {
            DtgKonaklama.DataSource = konaklamaKirilimManager.GetList(isAkisNo);
            DtgKonaklama.Columns["IsAkisNo"].Visible = false;
            DtgKonaklama.Columns["Gun"].HeaderText = "GÜN";
            DtgKonaklama.Columns["GunTl"].HeaderText = "GÜNLÜK ÜCRET";
            DtgKonaklama.Columns["Toplam"].HeaderText = "TOPLAM";
            TxtTop.Text = DtgKonaklama.RowCount.ToString();

        }
        void Toplamlar()
        {
            double toplam = 0;
            for (int i = 0; i < DtgKonaklama.Rows.Count; ++i)
            {
                toplam += Convert.ToDouble(DtgKonaklama.Rows[i].Cells[3].Value);
            }
            LblGenelTop.Text = toplam.ToString("C2");
        }
    }
}
