
namespace UserInterface.BakımOnarım
{
    partial class FrmArizaKayitlarics
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgBolgeler = new ADGV.AdvancedDataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolgeler)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1637, 27);
            this.panel1.TabIndex = 315;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgBolgeler);
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1519, 455);
            this.groupBox1.TabIndex = 316;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ARIZA KAYITLARI";
            // 
            // DtgBolgeler
            // 
            this.DtgBolgeler.AllowUserToAddRows = false;
            this.DtgBolgeler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgBolgeler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgBolgeler.AutoGenerateContextFilters = true;
            this.DtgBolgeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgBolgeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgBolgeler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column8,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column13,
            this.Column14,
            this.Column9});
            this.DtgBolgeler.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgBolgeler.DateWithTime = false;
            this.DtgBolgeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgBolgeler.Location = new System.Drawing.Point(3, 16);
            this.DtgBolgeler.MultiSelect = false;
            this.DtgBolgeler.Name = "DtgBolgeler";
            this.DtgBolgeler.ReadOnly = true;
            this.DtgBolgeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgBolgeler.Size = new System.Drawing.Size(1513, 436);
            this.DtgBolgeler.TabIndex = 2;
            this.DtgBolgeler.TimeFilter = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "ABF FORM NO";
            this.Column7.MinimumWidth = 22;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column7.Width = 82;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "PROJE";
            this.Column1.MinimumWidth = 22;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column1.Width = 67;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "BÖLGE ADI";
            this.Column2.MinimumWidth = 22;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column2.Width = 82;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "BİLDİRİLEN ARIZA";
            this.Column3.MinimumWidth = 22;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column3.Width = 115;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "ARIZA BİLDİRİM TARİH/SAATİ";
            this.Column8.MinimumWidth = 22;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column8.Width = 169;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ARIZA BİLDİREN PERSONEL";
            this.Column4.MinimumWidth = 22;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column4.Width = 162;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ARIZA BİLDİRİMİ ALAN BÖLGE SORUMLUSU";
            this.Column5.MinimumWidth = 22;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column5.Width = 173;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "AÇIKLAMA";
            this.Column6.MinimumWidth = 22;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column6.Width = 85;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            this.Column13.MinimumWidth = 22;
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column13.Width = 127;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "İŞLEM ADIMI SORUMLUSU";
            this.Column14.MinimumWidth = 22;
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column14.Width = 154;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "İŞLEM ADIMI BEKLEME SÜRESİ";
            this.Column9.MinimumWidth = 22;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column9.Width = 140;
            // 
            // FrmArizaKayitlarics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 872);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmArizaKayitlarics";
            this.Text = "FrmArizaKayitlarics";
            this.Load += new System.EventHandler(this.FrmArizaKayitlarics_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolgeler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgBolgeler;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}