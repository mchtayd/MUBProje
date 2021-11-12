using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class FrmYonetim : Form
    {

        public object[] infos;

        public FrmYonetim()
        {
            InitializeComponent();
        }

        private void FrmYonetim_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
            ChkListele.Items.Insert(0, "Deneme");
           
            /*List<AltDal> list = new List<AltDal>();
            foreach (var item in list)
            {
                ChkListele.Items.Add(item,true); //Ticklenmiş Halde Geliyor
            }
            */

        }

        private void ChkListele_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
