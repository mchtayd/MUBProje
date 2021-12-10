
namespace UserInterface.BakımOnarım
{
    partial class FrmIscilikIzleme
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbPersoneller = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgOnay = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbIscilikTuru = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgOnay)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1479, 27);
            this.panel1.TabIndex = 311;
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
            this.BtnCancel.TabIndex = 19;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(841, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 312;
            this.label1.Text = "PERSONEL:";
            // 
            // CmbPersoneller
            // 
            this.CmbPersoneller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPersoneller.FormattingEnabled = true;
            this.CmbPersoneller.Location = new System.Drawing.Point(915, 308);
            this.CmbPersoneller.Name = "CmbPersoneller";
            this.CmbPersoneller.Size = new System.Drawing.Size(300, 21);
            this.CmbPersoneller.TabIndex = 313;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(915, 336);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker1.TabIndex = 314;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(800, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 315;
            this.label2.Text = "BAŞLANGIÇ TARİHİ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(833, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 316;
            this.label3.Text = "BİTİŞ TARİHİ:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(915, 362);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(130, 20);
            this.dateTimePicker2.TabIndex = 317;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(915, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 43);
            this.button1.TabIndex = 318;
            this.button1.Text = "BUL";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgOnay);
            this.groupBox1.Location = new System.Drawing.Point(12, 611);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1452, 153);
            this.groupBox1.TabIndex = 319;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İŞÇİLİK İZLEME";
            // 
            // DtgOnay
            // 
            this.DtgOnay.AllowUserToAddRows = false;
            this.DtgOnay.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgOnay.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgOnay.AutoGenerateContextFilters = true;
            this.DtgOnay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgOnay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgOnay.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgOnay.DateWithTime = false;
            this.DtgOnay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgOnay.Location = new System.Drawing.Point(3, 16);
            this.DtgOnay.MultiSelect = false;
            this.DtgOnay.Name = "DtgOnay";
            this.DtgOnay.ReadOnly = true;
            this.DtgOnay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgOnay.Size = new System.Drawing.Size(1446, 134);
            this.DtgOnay.TabIndex = 3;
            this.DtgOnay.TimeFilter = false;
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 781);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 321;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 781);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 320;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // CmbIscilikTuru
            // 
            this.CmbIscilikTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIscilikTuru.FormattingEnabled = true;
            this.CmbIscilikTuru.Items.AddRange(new object[] {
            "DESTEK İŞÇİLİK",
            "İŞÇİLİK",
            "PERFORMANS"});
            this.CmbIscilikTuru.Location = new System.Drawing.Point(128, 47);
            this.CmbIscilikTuru.Name = "CmbIscilikTuru";
            this.CmbIscilikTuru.Size = new System.Drawing.Size(206, 21);
            this.CmbIscilikTuru.TabIndex = 323;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 322;
            this.label4.Text = "İŞÇİLİK TÜRÜ:";
            // 
            // FrmIscilikIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 872);
            this.Controls.Add(this.CmbIscilikTuru);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.CmbPersoneller);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmIscilikIzleme";
            this.Text = "FrmIscilikIzleme";
            this.Load += new System.EventHandler(this.FrmIscilikIzleme_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgOnay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbPersoneller;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgOnay;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbIscilikTuru;
        private System.Windows.Forms.Label label4;
    }
}