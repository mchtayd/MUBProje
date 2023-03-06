
namespace UserInterface.IdariIsler
{
    partial class FrmCokluKonaklama
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgIcerik = new System.Windows.Forms.DataGridView();
            this.Gun2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GunTl2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Toplam2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.BtnTemizle = new System.Windows.Forms.Button();
            this.LblGenelTop = new System.Windows.Forms.Label();
            this.LblKonaklamaGun = new System.Windows.Forms.Label();
            this.LblKonaklamaGunTl = new System.Windows.Forms.Label();
            this.Gun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgIcerik)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgIcerik);
            this.groupBox1.Location = new System.Drawing.Point(23, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 274);
            this.groupBox1.TabIndex = 323;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "KONAKLAMA BİLGİLERİ";
            // 
            // DtgIcerik
            // 
            this.DtgIcerik.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgIcerik.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtgIcerik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgIcerik.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Gun2,
            this.GunTl2,
            this.Toplam2});
            this.DtgIcerik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgIcerik.Location = new System.Drawing.Point(3, 16);
            this.DtgIcerik.Name = "DtgIcerik";
            this.DtgIcerik.Size = new System.Drawing.Size(346, 255);
            this.DtgIcerik.TabIndex = 324;
            this.DtgIcerik.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgIcerik_CellValueChanged);
            // 
            // Gun2
            // 
            this.Gun2.HeaderText = "GÜN";
            this.Gun2.Name = "Gun2";
            // 
            // GunTl2
            // 
            this.GunTl2.HeaderText = "GÜNLÜK TL";
            this.GunTl2.Name = "GunTl2";
            // 
            // Toplam2
            // 
            this.Toplam2.HeaderText = "TOPLAM";
            this.Toplam2.Name = "Toplam2";
            this.Toplam2.ReadOnly = true;
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(26, 369);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(94, 35);
            this.BtnKaydet.TabIndex = 324;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTemizle.Location = new System.Drawing.Point(126, 369);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(94, 35);
            this.BtnTemizle.TabIndex = 325;
            this.BtnTemizle.Text = "TEMİZLE";
            this.BtnTemizle.UseVisualStyleBackColor = true;
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // LblGenelTop
            // 
            this.LblGenelTop.AutoSize = true;
            this.LblGenelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblGenelTop.Location = new System.Drawing.Point(292, 321);
            this.LblGenelTop.Name = "LblGenelTop";
            this.LblGenelTop.Size = new System.Drawing.Size(15, 15);
            this.LblGenelTop.TabIndex = 353;
            this.LblGenelTop.Text = "0";
            // 
            // LblKonaklamaGun
            // 
            this.LblKonaklamaGun.AutoSize = true;
            this.LblKonaklamaGun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblKonaklamaGun.Location = new System.Drawing.Point(86, 321);
            this.LblKonaklamaGun.Name = "LblKonaklamaGun";
            this.LblKonaklamaGun.Size = new System.Drawing.Size(15, 15);
            this.LblKonaklamaGun.TabIndex = 354;
            this.LblKonaklamaGun.Text = "0";
            // 
            // LblKonaklamaGunTl
            // 
            this.LblKonaklamaGunTl.AutoSize = true;
            this.LblKonaklamaGunTl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblKonaklamaGunTl.Location = new System.Drawing.Point(189, 321);
            this.LblKonaklamaGunTl.Name = "LblKonaklamaGunTl";
            this.LblKonaklamaGunTl.Size = new System.Drawing.Size(15, 15);
            this.LblKonaklamaGunTl.TabIndex = 355;
            this.LblKonaklamaGunTl.Text = "0";
            // 
            // Gun
            // 
            this.Gun.HeaderText = "GÜN";
            this.Gun.Name = "Gun";
            this.Gun.Width = 101;
            // 
            // FrmCokluKonaklama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 453);
            this.Controls.Add(this.LblKonaklamaGunTl);
            this.Controls.Add(this.LblKonaklamaGun);
            this.Controls.Add(this.LblGenelTop);
            this.Controls.Add(this.BtnTemizle);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCokluKonaklama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ÇOKLU KONAKLAMA";
            this.Load += new System.EventHandler(this.FrmCokluKonaklama_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgIcerik)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DtgIcerik;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Button BtnTemizle;
        private System.Windows.Forms.Label LblGenelTop;
        private System.Windows.Forms.Label LblKonaklamaGun;
        private System.Windows.Forms.Label LblKonaklamaGunTl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gun;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gun2;
        private System.Windows.Forms.DataGridViewTextBoxColumn GunTl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Toplam2;
    }
}