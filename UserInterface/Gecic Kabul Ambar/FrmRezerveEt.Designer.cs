namespace UserInterface.Gecic_Kabul_Ambar
{
    partial class FrmRezerveEt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRezerveEt));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtAbf = new System.Windows.Forms.TextBox();
            this.LblBolgeAdi = new System.Windows.Forms.Label();
            this.LblSorumluPersonel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnRezerve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(72, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Abf No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(49, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Üs Bölgesi:";
            // 
            // TxtAbf
            // 
            this.TxtAbf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtAbf.Location = new System.Drawing.Point(124, 24);
            this.TxtAbf.Name = "TxtAbf";
            this.TxtAbf.Size = new System.Drawing.Size(121, 21);
            this.TxtAbf.TabIndex = 2;
            this.TxtAbf.TextChanged += new System.EventHandler(this.TxtAbf_TextChanged);
            // 
            // LblBolgeAdi
            // 
            this.LblBolgeAdi.AutoSize = true;
            this.LblBolgeAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblBolgeAdi.Location = new System.Drawing.Point(124, 64);
            this.LblBolgeAdi.Name = "LblBolgeAdi";
            this.LblBolgeAdi.Size = new System.Drawing.Size(21, 15);
            this.LblBolgeAdi.TabIndex = 3;
            this.LblBolgeAdi.Text = "00";
            // 
            // LblSorumluPersonel
            // 
            this.LblSorumluPersonel.AutoSize = true;
            this.LblSorumluPersonel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblSorumluPersonel.Location = new System.Drawing.Point(124, 95);
            this.LblSorumluPersonel.Name = "LblSorumluPersonel";
            this.LblSorumluPersonel.Size = new System.Drawing.Size(21, 15);
            this.LblSorumluPersonel.TabIndex = 5;
            this.LblSorumluPersonel.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(10, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Bölge Sorumlusu:";
            // 
            // BtnRezerve
            // 
            this.BtnRezerve.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnRezerve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRezerve.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnRezerve.Image = ((System.Drawing.Image)(resources.GetObject("BtnRezerve.Image")));
            this.BtnRezerve.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRezerve.Location = new System.Drawing.Point(13, 147);
            this.BtnRezerve.Name = "BtnRezerve";
            this.BtnRezerve.Size = new System.Drawing.Size(140, 51);
            this.BtnRezerve.TabIndex = 361;
            this.BtnRezerve.Text = " REZERVE ET";
            this.BtnRezerve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRezerve.UseVisualStyleBackColor = false;
            this.BtnRezerve.Click += new System.EventHandler(this.BtnRezerve_Click);
            // 
            // FrmRezerveEt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 210);
            this.Controls.Add(this.BtnRezerve);
            this.Controls.Add(this.LblSorumluPersonel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblBolgeAdi);
            this.Controls.Add(this.TxtAbf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRezerveEt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rezerve Et";
            this.Load += new System.EventHandler(this.FrmRezerveEt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtAbf;
        private System.Windows.Forms.Label LblBolgeAdi;
        private System.Windows.Forms.Label LblSorumluPersonel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnRezerve;
    }
}