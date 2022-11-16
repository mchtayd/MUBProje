
namespace UserInterface.IdariIsler
{
    partial class FrmKonaklamaOnay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKonaklamaOnay));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnTumunuOnaylaKonaklama = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgKonaklama = new ADGV.AdvancedDataGridView();
            this.BtnKonaklamaRed = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnKonaklamaOnay = new System.Windows.Forms.Button();
            this.TxtTopKonaklama = new System.Windows.Forms.Label();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.BtnDosyaEkle = new System.Windows.Forms.Button();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgKonaklama)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1426, 27);
            this.panel1.TabIndex = 322;
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
            // BtnTumunuOnaylaKonaklama
            // 
            this.BtnTumunuOnaylaKonaklama.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTumunuOnaylaKonaklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTumunuOnaylaKonaklama.Location = new System.Drawing.Point(199, 617);
            this.BtnTumunuOnaylaKonaklama.Name = "BtnTumunuOnaylaKonaklama";
            this.BtnTumunuOnaylaKonaklama.Size = new System.Drawing.Size(178, 50);
            this.BtnTumunuOnaylaKonaklama.TabIndex = 333;
            this.BtnTumunuOnaylaKonaklama.Text = "TÜMÜNÜ ONAYLA";
            this.BtnTumunuOnaylaKonaklama.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgKonaklama);
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1400, 531);
            this.groupBox1.TabIndex = 328;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "KONAKLAMA ONAY LİSTESİ";
            // 
            // DtgKonaklama
            // 
            this.DtgKonaklama.AllowUserToAddRows = false;
            this.DtgKonaklama.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgKonaklama.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DtgKonaklama.AutoGenerateContextFilters = true;
            this.DtgKonaklama.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgKonaklama.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DtgKonaklama.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgKonaklama.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgKonaklama.DateWithTime = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgKonaklama.DefaultCellStyle = dataGridViewCellStyle12;
            this.DtgKonaklama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgKonaklama.Location = new System.Drawing.Point(3, 16);
            this.DtgKonaklama.MultiSelect = false;
            this.DtgKonaklama.Name = "DtgKonaklama";
            this.DtgKonaklama.ReadOnly = true;
            this.DtgKonaklama.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgKonaklama.Size = new System.Drawing.Size(1394, 512);
            this.DtgKonaklama.TabIndex = 2;
            this.DtgKonaklama.TimeFilter = false;
            // 
            // BtnKonaklamaRed
            // 
            this.BtnKonaklamaRed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKonaklamaRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKonaklamaRed.Location = new System.Drawing.Point(383, 617);
            this.BtnKonaklamaRed.Name = "BtnKonaklamaRed";
            this.BtnKonaklamaRed.Size = new System.Drawing.Size(178, 50);
            this.BtnKonaklamaRed.TabIndex = 332;
            this.BtnKonaklamaRed.Text = "REDDET";
            this.BtnKonaklamaRed.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 589);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 329;
            this.label1.Text = "Toplam Kayıt:";
            // 
            // BtnKonaklamaOnay
            // 
            this.BtnKonaklamaOnay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKonaklamaOnay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKonaklamaOnay.Location = new System.Drawing.Point(15, 617);
            this.BtnKonaklamaOnay.Name = "BtnKonaklamaOnay";
            this.BtnKonaklamaOnay.Size = new System.Drawing.Size(178, 50);
            this.BtnKonaklamaOnay.TabIndex = 331;
            this.BtnKonaklamaOnay.Text = "ONAYLA";
            this.BtnKonaklamaOnay.UseVisualStyleBackColor = true;
            // 
            // TxtTopKonaklama
            // 
            this.TxtTopKonaklama.AutoSize = true;
            this.TxtTopKonaklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTopKonaklama.Location = new System.Drawing.Point(112, 589);
            this.TxtTopKonaklama.Name = "TxtTopKonaklama";
            this.TxtTopKonaklama.Size = new System.Drawing.Size(21, 15);
            this.TxtTopKonaklama.TabIndex = 330;
            this.TxtTopKonaklama.Text = "00";
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuncelle.Image")));
            this.BtnGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuncelle.Location = new System.Drawing.Point(888, 618);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(130, 51);
            this.BtnGuncelle.TabIndex = 337;
            this.BtnGuncelle.Text = "  GÜNCELLE";
            this.BtnGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuncelle.UseVisualStyleBackColor = false;
            this.BtnGuncelle.Visible = false;
            // 
            // BtnDosyaEkle
            // 
            this.BtnDosyaEkle.AutoSize = true;
            this.BtnDosyaEkle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnDosyaEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDosyaEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDosyaEkle.Image = ((System.Drawing.Image)(resources.GetObject("BtnDosyaEkle.Image")));
            this.BtnDosyaEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDosyaEkle.Location = new System.Drawing.Point(616, 618);
            this.BtnDosyaEkle.Name = "BtnDosyaEkle";
            this.BtnDosyaEkle.Size = new System.Drawing.Size(130, 51);
            this.BtnDosyaEkle.TabIndex = 336;
            this.BtnDosyaEkle.Text = "ONAYLA";
            this.BtnDosyaEkle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDosyaEkle.UseVisualStyleBackColor = false;
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.Image")));
            this.BtnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnKaydet.Location = new System.Drawing.Point(752, 618);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(130, 51);
            this.BtnKaydet.TabIndex = 335;
            this.BtnKaydet.Text = "     KAYDET";
            this.BtnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKaydet.UseVisualStyleBackColor = false;
            // 
            // FrmKonaklamaOnay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 806);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.BtnDosyaEkle);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.BtnTumunuOnaylaKonaklama);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnKonaklamaRed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnKonaklamaOnay);
            this.Controls.Add(this.TxtTopKonaklama);
            this.Controls.Add(this.panel1);
            this.Name = "FrmKonaklamaOnay";
            this.Text = "FrmKonaklamaOnay";
            this.Load += new System.EventHandler(this.FrmKonaklamaOnay_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgKonaklama)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnTumunuOnaylaKonaklama;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgKonaklama;
        private System.Windows.Forms.Button BtnKonaklamaRed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnKonaklamaOnay;
        private System.Windows.Forms.Label TxtTopKonaklama;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.Button BtnDosyaEkle;
        private System.Windows.Forms.Button BtnKaydet;
    }
}