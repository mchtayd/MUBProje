using Business.Concreate;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.STS;

namespace UserInterface
{
    public partial class Login : Form
    {
        PersonelManager personelManager;
        public Login()
        {
            InitializeComponent();
            personelManager = PersonelManager.GetInstance();
            //Task.Factory.StartNew(() => personelManager = PersonelManager.GetInstance());
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
        private void Login_Shown(object sender, EventArgs e)
        {
           // MessageBox.Show(Application.ExecutablePath);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        
        {
            //KİTLEME
            /*string folderPath = "C:\\Users\\MAYıldırım\\Desktop\\C# Notes\\Secret\\Locker";
            string adminUserName = Environment.UserName;
            DirectorySecurity ds = Directory.GetAccessControl(folderPath);
            FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
            ds.AddAccessRule(fsa);
            Directory.SetAccessControl(folderPath, ds);

            //AÇMA
            string folderPath = "C:\\Users\\MAYıldırım\\Desktop\\C# Notes\\Secret\\Locker";
            string adminUserName = Environment.UserName;
            DirectorySecurity ds = Directory.GetAccessControl(folderPath);
            FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
            ds.RemoveAccessRule(fsa);
            Directory.SetAccessControl(folderPath, ds);*/
            
            if (MskSicil.Text.Trim() == "" || textPassword.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen Sicil Numarası ve Şifreyi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Properties.Settings.Default.FirstRun)
            {
                //SQL

                Properties.Settings.Default.FirstRun = true;
                Properties.Settings.Default.Save();
            }

            object[] infos = personelManager.Login(MskSicil.Text, textPassword.Text);

            if (infos == null)
            {
                MessageBox.Show("Hatalı Sicil Numarası Veya Şifre Girdiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Sayın " + infos[1] + " Hoşgeldiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


            // string version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);

            FrmAnaSayfa anaSayfa = new FrmAnaSayfa();
            anaSayfa.infos = infos;
            anaSayfa.Show();
            this.Hide();
        }

        private void MskSicil_TextChanged(object sender, EventArgs e)
        {
            if (MskSicil.Text.Length != 4)
            {
                return;
            }
            textPassword.Focus();
        }

    }
}