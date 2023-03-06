using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Depo
{
    public partial class FrmPhotoFullScreen : Form
    {
        public string imageLocation = "";
        public FrmPhotoFullScreen()
        {
            InitializeComponent();
        }

        private void FrmPhotoFullScreen_Load(object sender, EventArgs e)
        {
            Picture.ImageLocation = imageLocation;
        }
    }
}
