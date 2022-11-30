
namespace UserInterface.BakımOnarım
{
    partial class FrmHaftalikControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHaftalikControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.CmbBolgeAdi = new System.Windows.Forms.ComboBox();
            this.TxtBolgeAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.BtnDosyaEkle = new System.Windows.Forms.Button();
            this.DtGarantİBitTarihi = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1333, 27);
            this.panel1.TabIndex = 319;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnCancel.Location = new System.Drawing.Point(12, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(35, 23);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // CmbBolgeAdi
            // 
            this.CmbBolgeAdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBolgeAdi.FormattingEnabled = true;
            this.CmbBolgeAdi.Location = new System.Drawing.Point(138, 51);
            this.CmbBolgeAdi.Name = "CmbBolgeAdi";
            this.CmbBolgeAdi.Size = new System.Drawing.Size(296, 21);
            this.CmbBolgeAdi.TabIndex = 325;
            // 
            // TxtBolgeAdi
            // 
            this.TxtBolgeAdi.Location = new System.Drawing.Point(138, 51);
            this.TxtBolgeAdi.Name = "TxtBolgeAdi";
            this.TxtBolgeAdi.Size = new System.Drawing.Size(296, 20);
            this.TxtBolgeAdi.TabIndex = 324;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 323;
            this.label1.Text = "ÜS BÖLGE ADI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 326;
            this.label2.Text = "SİSTEM KAYIT TARİH:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 327;
            this.label3.Text = "00";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Location = new System.Drawing.Point(138, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(542, 108);
            this.groupBox2.TabIndex = 328;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ekler:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(536, 89);
            this.webBrowser1.TabIndex = 0;
            // 
            // BtnDosyaEkle
            // 
            this.BtnDosyaEkle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnDosyaEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDosyaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDosyaEkle.Image = ((System.Drawing.Image)(resources.GetObject("BtnDosyaEkle.Image")));
            this.BtnDosyaEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDosyaEkle.Location = new System.Drawing.Point(138, 276);
            this.BtnDosyaEkle.Name = "BtnDosyaEkle";
            this.BtnDosyaEkle.Size = new System.Drawing.Size(130, 51);
            this.BtnDosyaEkle.TabIndex = 329;
            this.BtnDosyaEkle.Text = " DOSYA EKLE";
            this.BtnDosyaEkle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDosyaEkle.UseVisualStyleBackColor = false;
            // 
            // DtGarantİBitTarihi
            // 
            this.DtGarantİBitTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtGarantİBitTarihi.Location = new System.Drawing.Point(138, 127);
            this.DtGarantİBitTarihi.Name = "DtGarantİBitTarihi";
            this.DtGarantİBitTarihi.Size = new System.Drawing.Size(139, 20);
            this.DtGarantİBitTarihi.TabIndex = 331;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(52, 133);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 330;
            this.label14.Text = "FORM TARİHİ:";
            // 
            // FrmHaftalikControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 769);
            this.Controls.Add(this.DtGarantİBitTarihi);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.BtnDosyaEkle);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbBolgeAdi);
            this.Controls.Add(this.TxtBolgeAdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmHaftalikControl";
            this.Text = "FrmHaftalikControl";
            this.Load += new System.EventHandler(this.FrmHaftalikControl_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ComboBox CmbBolgeAdi;
        private System.Windows.Forms.TextBox TxtBolgeAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button BtnDosyaEkle;
        private System.Windows.Forms.DateTimePicker DtGarantİBitTarihi;
        private System.Windows.Forms.Label label14;
    }
}