using Business.Concreate;
using Business.Concreate.AnaSayfa;
using DataAccess.Concreate;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Ana_Sayfa;
using UserInterface.STS;

namespace UserInterface
{
    public partial class Login : Form
    {
        PersonelManager personelManager;
        LogManager logManager;
        public Login()
        {
            InitializeComponent();
            personelManager = PersonelManager.GetInstance();
            logManager = LogManager.GetInstance();
            //Task.Factory.StartNew(() => personelManager = PersonelManager.GetInstance());
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
        private void Login_Shown(object sender, EventArgs e)
        {
            // MessageBox.Show(Application.ExecutablePath);
        }
        private async void btnLogin_Click(object sender, EventArgs e)
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


            FrmAnaSayfa anaSayfa = new FrmAnaSayfa
            {
                infos = infos
            };

            //Task task = Task.Factory.StartNew(() => anaSayfa.Show());
            //Invoke((Action)(() => { anaSayfa.Show(); }));
            //Task task = new Task(anaSayfa.Show);
            //task.Start();
            //await task;

            anaSayfa.Show();
            logManager.Control();
            this.Hide();

            // string version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);

            //FrmAwait frmAwait = new FrmAwait();

            //Task task = new Task(Deneme);
            //task.Start();

            //this.Hide();
            //FrmAnaSayfa anaSayfa = new FrmAnaSayfa();
            //anaSayfa.WindowState = FormWindowState.Minimized;
            //frmAwait.WindowState = FormWindowState.Maximized;
            //anaSayfa.infos = infos;
            //anaSayfa.Show();
            //await task;
            //anaSayfa.WindowState = FormWindowState.Maximized;
        }
        void Deneme()
        {
            FrmAwait frmAwait = new FrmAwait();
            frmAwait.Show();
        }

        private void MskSicil_TextChanged(object sender, EventArgs e)
        {
            if (MskSicil.Text.Length != 4)
            {
                return;
            }
            textPassword.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDeneme frmDeneme = new FrmDeneme();
            frmDeneme.Show();
        }
    }
}