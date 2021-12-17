
namespace UserInterface
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MskSicil = new System.Windows.Forms.MaskedTextBox();
            this.TxtSifremiUnuttum = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.MskSicil);
            this.groupBox1.Controls.Add(this.TxtSifremiUnuttum);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.textPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(41, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 295);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lütfen Kullanıcı Bilgilerinizi Giriniz";
            // 
            // MskSicil
            // 
            this.MskSicil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MskSicil.Location = new System.Drawing.Point(21, 82);
            this.MskSicil.Mask = "0000";
            this.MskSicil.Name = "MskSicil";
            this.MskSicil.Size = new System.Drawing.Size(322, 26);
            this.MskSicil.TabIndex = 0;
            this.MskSicil.ValidatingType = typeof(int);
            this.MskSicil.TextChanged += new System.EventHandler(this.MskSicil_TextChanged);
            // 
            // TxtSifremiUnuttum
            // 
            this.TxtSifremiUnuttum.AutoSize = true;
            this.TxtSifremiUnuttum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TxtSifremiUnuttum.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtSifremiUnuttum.Location = new System.Drawing.Point(115, 198);
            this.TxtSifremiUnuttum.Name = "TxtSifremiUnuttum";
            this.TxtSifremiUnuttum.Size = new System.Drawing.Size(115, 16);
            this.TxtSifremiUnuttum.TabIndex = 4;
            this.TxtSifremiUnuttum.Text = "Şifremi Unuttum?";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Black;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(42, 228);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(275, 48);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "GİRİŞ";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // textPassword
            // 
            this.textPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textPassword.Location = new System.Drawing.Point(21, 156);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(322, 26);
            this.textPassword.TabIndex = 1;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(17, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Şifreniz:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(17, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kullanıcı Sicil Numaranız:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(40, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 222);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(47, 538);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 34);
            this.label1.TabIndex = 16;
            this.label1.Text = "DATA TRACKING SYSTEM";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(96, 654);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(239, 17);
            this.label7.TabIndex = 39;
            this.label7.Text = "By Designer and Developer R.GUNES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(94, 630);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "All Rights Reserved By C# M.AYDEMİR";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(153, 605);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "Copyrights @ 2021";
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(442, 680);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Girişi";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.Shown += new System.EventHandler(this.Login_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox MskSicil;
        private System.Windows.Forms.Label TxtSifremiUnuttum;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}