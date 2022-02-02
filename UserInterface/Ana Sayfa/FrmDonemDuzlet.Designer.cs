
namespace UserInterface.Ana_Sayfa
{
    partial class FrmDonemDuzlet
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.CmbSatTuru = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnDuzelt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1308, 563);
            this.groupBox1.TabIndex = 409;
            this.groupBox1.TabStop = false;
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgList.DateWithTime = false;
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 16);
            this.DtgList.MultiSelect = false;
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgList.Size = new System.Drawing.Size(1302, 544);
            this.DtgList.TabIndex = 2;
            this.DtgList.TimeFilter = false;
            // 
            // CmbSatTuru
            // 
            this.CmbSatTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSatTuru.FormattingEnabled = true;
            this.CmbSatTuru.Items.AddRange(new object[] {
            "DEVAM EDEN SATLAR",
            "TAMAMLANAN SATLAR"});
            this.CmbSatTuru.Location = new System.Drawing.Point(98, 26);
            this.CmbSatTuru.Name = "CmbSatTuru";
            this.CmbSatTuru.Size = new System.Drawing.Size(190, 21);
            this.CmbSatTuru.TabIndex = 410;
            this.CmbSatTuru.SelectedIndexChanged += new System.EventHandler(this.CmbSatTuru_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 411;
            this.label1.Text = "SAT TÜRÜ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 631);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 412;
            this.label2.Text = "00";
            // 
            // BtnDuzelt
            // 
            this.BtnDuzelt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDuzelt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDuzelt.Location = new System.Drawing.Point(12, 672);
            this.BtnDuzelt.Name = "BtnDuzelt";
            this.BtnDuzelt.Size = new System.Drawing.Size(147, 40);
            this.BtnDuzelt.TabIndex = 413;
            this.BtnDuzelt.Text = "DÖNEM DÜZELT";
            this.BtnDuzelt.UseVisualStyleBackColor = true;
            this.BtnDuzelt.Click += new System.EventHandler(this.BtnDuzelt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 686);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(354, 13);
            this.label3.TabIndex = 414;
            this.label3.Text = "Tüm Satların Dönem Bilgileri Yıla Göre AY + YIL Olmak Üzere Düzeltilecek";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 732);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(354, 13);
            this.label4.TabIndex = 416;
            this.label4.Text = "Tüm Satların Dönem Bilgileri Yıla Göre AY + YIL Olmak Üzere Düzeltilecek";
            // 
            // Btn
            // 
            this.Btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Btn.Location = new System.Drawing.Point(12, 718);
            this.Btn.Name = "Btn";
            this.Btn.Size = new System.Drawing.Size(147, 40);
            this.Btn.TabIndex = 415;
            this.Btn.Text = "PROJE DÜZELT";
            this.Btn.UseVisualStyleBackColor = true;
            // 
            // FrmDonemDuzlet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 818);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnDuzelt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbSatTuru);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmDonemDuzlet";
            this.Text = "FrmDonemDuzlet";
            this.Load += new System.EventHandler(this.FrmDonemDuzlet_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.ComboBox CmbSatTuru;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnDuzelt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn;
    }
}