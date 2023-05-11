namespace UserInterface.BakımOnarım
{
    partial class FrmSokulenMalzeme
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSokulenMalzeme));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgEklenecekMalzemeler = new ADGV.AdvancedDataGridView();
            this.CmbFizikselDurumu = new System.Windows.Forms.ComboBox();
            this.CmbCalismaDurumu = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.CmbYapilanIslem = new System.Windows.Forms.ComboBox();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEklenecekMalzemeler)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgEklenecekMalzemeler);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1209, 295);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EKLİ MALZEMELER";
            // 
            // DtgEklenecekMalzemeler
            // 
            this.DtgEklenecekMalzemeler.AllowUserToAddRows = false;
            this.DtgEklenecekMalzemeler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgEklenecekMalzemeler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgEklenecekMalzemeler.AutoGenerateContextFilters = true;
            this.DtgEklenecekMalzemeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgEklenecekMalzemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgEklenecekMalzemeler.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgEklenecekMalzemeler.DateWithTime = false;
            this.DtgEklenecekMalzemeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgEklenecekMalzemeler.Location = new System.Drawing.Point(3, 16);
            this.DtgEklenecekMalzemeler.MultiSelect = false;
            this.DtgEklenecekMalzemeler.Name = "DtgEklenecekMalzemeler";
            this.DtgEklenecekMalzemeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgEklenecekMalzemeler.Size = new System.Drawing.Size(1203, 276);
            this.DtgEklenecekMalzemeler.TabIndex = 3;
            this.DtgEklenecekMalzemeler.TimeFilter = false;
            this.DtgEklenecekMalzemeler.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgEklenecekMalzemeler_CellMouseClick);
            // 
            // CmbFizikselDurumu
            // 
            this.CmbFizikselDurumu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFizikselDurumu.FormattingEnabled = true;
            this.CmbFizikselDurumu.Items.AddRange(new object[] {
            "SÖKÜLDÜ",
            "SÖKÜLMEDİ"});
            this.CmbFizikselDurumu.Location = new System.Drawing.Point(126, 66);
            this.CmbFizikselDurumu.Name = "CmbFizikselDurumu";
            this.CmbFizikselDurumu.Size = new System.Drawing.Size(119, 21);
            this.CmbFizikselDurumu.TabIndex = 510;
            // 
            // CmbCalismaDurumu
            // 
            this.CmbCalismaDurumu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCalismaDurumu.FormattingEnabled = true;
            this.CmbCalismaDurumu.Items.AddRange(new object[] {
            "KISMİ ÇALIŞAN",
            "GAYRİ FAAL"});
            this.CmbCalismaDurumu.Location = new System.Drawing.Point(6, 66);
            this.CmbCalismaDurumu.Name = "CmbCalismaDurumu";
            this.CmbCalismaDurumu.Size = new System.Drawing.Size(114, 21);
            this.CmbCalismaDurumu.TabIndex = 509;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(256, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 26);
            this.label12.TabIndex = 505;
            this.label12.Text = "Malzemeye Yapılacak\r\nİşlem:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(131, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 26);
            this.label14.TabIndex = 508;
            this.label14.Text = "Sistem/Cihaz\r\nFiziksel Durumu:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 38);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 26);
            this.label16.TabIndex = 507;
            this.label16.Text = "Sistem/Cihaz \r\nÇalışma Durumu:";
            // 
            // CmbYapilanIslem
            // 
            this.CmbYapilanIslem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYapilanIslem.FormattingEnabled = true;
            this.CmbYapilanIslem.Items.AddRange(new object[] {
            "DEĞİTİRİLECEK (ONARILACAK)",
            "DEĞİTİRİLECEK (HURDA EDİLECEK)",
            "ONARILACAK"});
            this.CmbYapilanIslem.Location = new System.Drawing.Point(251, 66);
            this.CmbYapilanIslem.Name = "CmbYapilanIslem";
            this.CmbYapilanIslem.Size = new System.Drawing.Size(266, 21);
            this.CmbYapilanIslem.TabIndex = 506;
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuncelle.Image")));
            this.BtnGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuncelle.Location = new System.Drawing.Point(15, 445);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(127, 51);
            this.BtnGuncelle.TabIndex = 553;
            this.BtnGuncelle.Text = "  GÜNCELLE";
            this.BtnGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuncelle.UseVisualStyleBackColor = false;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CmbCalismaDurumu);
            this.groupBox1.Controls.Add(this.CmbYapilanIslem);
            this.groupBox1.Controls.Add(this.CmbFizikselDurumu);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(15, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 113);
            this.groupBox1.TabIndex = 554;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sökülen Cihaz Bilgisi";
            // 
            // FrmSokulenMalzeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 506);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSokulenMalzeme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sökülen Malzeme Düzenle";
            this.Load += new System.EventHandler(this.FrmSokulenMalzeme_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgEklenecekMalzemeler)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private ADGV.AdvancedDataGridView DtgEklenecekMalzemeler;
        private System.Windows.Forms.ComboBox CmbFizikselDurumu;
        private System.Windows.Forms.ComboBox CmbCalismaDurumu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox CmbYapilanIslem;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}