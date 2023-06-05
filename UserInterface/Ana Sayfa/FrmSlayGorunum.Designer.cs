namespace UserInterface.Ana_Sayfa
{
    partial class FrmSlayGorunum
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSlayGorunum));
            this.ChkAmbar = new System.Windows.Forms.CheckBox();
            this.ChkAtolye = new System.Windows.Forms.CheckBox();
            this.ChkAcikAriza = new System.Windows.Forms.CheckBox();
            this.ChkAltYuk = new System.Windows.Forms.CheckBox();
            this.ChkBolumBazliAcik = new System.Windows.Forms.CheckBox();
            this.ChkBolgeBazli = new System.Windows.Forms.CheckBox();
            this.ChkArizaSure = new System.Windows.Forms.CheckBox();
            this.ChkAcikArizaSure = new System.Windows.Forms.CheckBox();
            this.BtnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PnlSlayt = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ChkAmbar
            // 
            this.ChkAmbar.AutoSize = true;
            this.ChkAmbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkAmbar.Location = new System.Drawing.Point(25, 27);
            this.ChkAmbar.Name = "ChkAmbar";
            this.ChkAmbar.Size = new System.Drawing.Size(201, 28);
            this.ChkAmbar.TabIndex = 1;
            this.ChkAmbar.Text = "Ambar Veri İzleme";
            this.ChkAmbar.UseVisualStyleBackColor = true;
            this.ChkAmbar.CheckedChanged += new System.EventHandler(this.ChkAmbar_CheckedChanged);
            // 
            // ChkAtolye
            // 
            this.ChkAtolye.AutoSize = true;
            this.ChkAtolye.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkAtolye.Location = new System.Drawing.Point(25, 63);
            this.ChkAtolye.Name = "ChkAtolye";
            this.ChkAtolye.Size = new System.Drawing.Size(198, 28);
            this.ChkAtolye.TabIndex = 2;
            this.ChkAtolye.Text = "Atölye Veri İzleme";
            this.ChkAtolye.UseVisualStyleBackColor = true;
            // 
            // ChkAcikAriza
            // 
            this.ChkAcikAriza.AutoSize = true;
            this.ChkAcikAriza.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkAcikAriza.Location = new System.Drawing.Point(26, 99);
            this.ChkAcikAriza.Name = "ChkAcikAriza";
            this.ChkAcikAriza.Size = new System.Drawing.Size(259, 28);
            this.ChkAcikAriza.TabIndex = 3;
            this.ChkAcikAriza.Text = "Açık Arıza İşlem Adımları";
            this.ChkAcikAriza.UseVisualStyleBackColor = true;
            // 
            // ChkAltYuk
            // 
            this.ChkAltYuk.AutoSize = true;
            this.ChkAltYuk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkAltYuk.Location = new System.Drawing.Point(26, 135);
            this.ChkAltYuk.Name = "ChkAltYuk";
            this.ChkAltYuk.Size = new System.Drawing.Size(198, 28);
            this.ChkAltYuk.TabIndex = 4;
            this.ChkAltYuk.Text = "Alt.Yük.Kont.Kord.";
            this.ChkAltYuk.UseVisualStyleBackColor = true;
            // 
            // ChkBolumBazliAcik
            // 
            this.ChkBolumBazliAcik.AutoSize = true;
            this.ChkBolumBazliAcik.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkBolumBazliAcik.Location = new System.Drawing.Point(26, 171);
            this.ChkBolumBazliAcik.Name = "ChkBolumBazliAcik";
            this.ChkBolumBazliAcik.Size = new System.Drawing.Size(325, 28);
            this.ChkBolumBazliAcik.TabIndex = 5;
            this.ChkBolumBazliAcik.Text = "Bölüm Bazlı Açık Arıza Grafikleri";
            this.ChkBolumBazliAcik.UseVisualStyleBackColor = true;
            // 
            // ChkBolgeBazli
            // 
            this.ChkBolgeBazli.AutoSize = true;
            this.ChkBolgeBazli.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkBolgeBazli.Location = new System.Drawing.Point(26, 207);
            this.ChkBolgeBazli.Name = "ChkBolgeBazli";
            this.ChkBolgeBazli.Size = new System.Drawing.Size(313, 28);
            this.ChkBolgeBazli.TabIndex = 6;
            this.ChkBolgeBazli.Text = "Bölge Bazlı İşlem Adımı Grafiği";
            this.ChkBolgeBazli.UseVisualStyleBackColor = true;
            // 
            // ChkArizaSure
            // 
            this.ChkArizaSure.AutoSize = true;
            this.ChkArizaSure.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkArizaSure.Location = new System.Drawing.Point(26, 279);
            this.ChkArizaSure.Name = "ChkArizaSure";
            this.ChkArizaSure.Size = new System.Drawing.Size(221, 28);
            this.ChkArizaSure.TabIndex = 7;
            this.ChkArizaSure.Text = "Arıza Süreleri Grafiği";
            this.ChkArizaSure.UseVisualStyleBackColor = true;
            // 
            // ChkAcikArizaSure
            // 
            this.ChkAcikArizaSure.AutoSize = true;
            this.ChkAcikArizaSure.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkAcikArizaSure.Location = new System.Drawing.Point(25, 243);
            this.ChkAcikArizaSure.Name = "ChkAcikArizaSure";
            this.ChkAcikArizaSure.Size = new System.Drawing.Size(267, 28);
            this.ChkAcikArizaSure.TabIndex = 8;
            this.ChkAcikArizaSure.Text = "Açık Arıza Süreleri Grafiği";
            this.ChkAcikArizaSure.UseVisualStyleBackColor = true;
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnStart.Image = ((System.Drawing.Image)(resources.GetObject("BtnStart.Image")));
            this.BtnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnStart.Location = new System.Drawing.Point(26, 322);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(130, 66);
            this.BtnStart.TabIndex = 320;
            this.BtnStart.Text = "  YÜRÜT";
            this.BtnStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 20000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PnlSlayt
            // 
            this.PnlSlayt.Location = new System.Drawing.Point(842, 279);
            this.PnlSlayt.Name = "PnlSlayt";
            this.PnlSlayt.Size = new System.Drawing.Size(200, 100);
            this.PnlSlayt.TabIndex = 321;
            this.PnlSlayt.Visible = false;
            // 
            // FrmSlayGorunum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 996);
            this.Controls.Add(this.PnlSlayt);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.ChkAcikArizaSure);
            this.Controls.Add(this.ChkArizaSure);
            this.Controls.Add(this.ChkBolgeBazli);
            this.Controls.Add(this.ChkBolumBazliAcik);
            this.Controls.Add(this.ChkAltYuk);
            this.Controls.Add(this.ChkAcikAriza);
            this.Controls.Add(this.ChkAtolye);
            this.Controls.Add(this.ChkAmbar);
            this.Name = "FrmSlayGorunum";
            this.Text = "Grafikler Slayt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSlayGorunum_FormClosing);
            this.Load += new System.EventHandler(this.FrmSlayGorunum_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ChkAmbar;
        private System.Windows.Forms.CheckBox ChkAtolye;
        private System.Windows.Forms.CheckBox ChkAcikAriza;
        private System.Windows.Forms.CheckBox ChkAltYuk;
        private System.Windows.Forms.CheckBox ChkBolumBazliAcik;
        private System.Windows.Forms.CheckBox ChkBolgeBazli;
        private System.Windows.Forms.CheckBox ChkArizaSure;
        private System.Windows.Forms.CheckBox ChkAcikArizaSure;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel PnlSlayt;
    }
}