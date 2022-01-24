
namespace UserInterface.BakımOnarım
{
    partial class FrmBOAtolyeDevamEdenler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgDevamEden = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.DtgMalzemeler = new ADGV.AdvancedDataGridView();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column56 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column58 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.advancedDataGridView1 = new ADGV.AdvancedDataGridView();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDevamEden)).BeginInit();
            this.tabControl3.SuspendLayout();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeler)).BeginInit();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1455, 27);
            this.panel1.TabIndex = 318;
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DtgDevamEden);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1431, 366);
            this.groupBox1.TabIndex = 319;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DEVAM EDEN ARIZALAR";
            // 
            // DtgDevamEden
            // 
            this.DtgDevamEden.AllowUserToAddRows = false;
            this.DtgDevamEden.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgDevamEden.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgDevamEden.AutoGenerateContextFilters = true;
            this.DtgDevamEden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgDevamEden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDevamEden.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgDevamEden.DateWithTime = false;
            this.DtgDevamEden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgDevamEden.Location = new System.Drawing.Point(3, 16);
            this.DtgDevamEden.MultiSelect = false;
            this.DtgDevamEden.Name = "DtgDevamEden";
            this.DtgDevamEden.ReadOnly = true;
            this.DtgDevamEden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgDevamEden.Size = new System.Drawing.Size(1425, 347);
            this.DtgDevamEden.TabIndex = 4;
            this.DtgDevamEden.TimeFilter = false;
            this.DtgDevamEden.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgDevamEden_CellMouseClick);
            // 
            // TxtTop
            // 
            this.TxtTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 405);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 321;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 320;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Controls.Add(this.tabPage10);
            this.tabControl3.Controls.Add(this.tabPage11);
            this.tabControl3.Location = new System.Drawing.Point(12, 432);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1429, 367);
            this.tabControl3.TabIndex = 438;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1421, 341);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "İŞLEM KAYITLARI";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.DtgMalzemeler);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1421, 341);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "CİHAZ MALZEME DURUMU";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // DtgMalzemeler
            // 
            this.DtgMalzemeler.AllowUserToAddRows = false;
            this.DtgMalzemeler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgMalzemeler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgMalzemeler.AutoGenerateContextFilters = true;
            this.DtgMalzemeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgMalzemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgMalzemeler.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgMalzemeler.DateWithTime = false;
            this.DtgMalzemeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgMalzemeler.Location = new System.Drawing.Point(3, 3);
            this.DtgMalzemeler.MultiSelect = false;
            this.DtgMalzemeler.Name = "DtgMalzemeler";
            this.DtgMalzemeler.ReadOnly = true;
            this.DtgMalzemeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgMalzemeler.Size = new System.Drawing.Size(1415, 335);
            this.DtgMalzemeler.TabIndex = 3;
            this.DtgMalzemeler.TimeFilter = false;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.dataGridView1);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(1421, 341);
            this.tabPage10.TabIndex = 2;
            this.tabPage10.Text = "DEPO HAREKETLERİ";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column46,
            this.Column48,
            this.Column49,
            this.Column50,
            this.Column56,
            this.Column57,
            this.Column51,
            this.Column52,
            this.Column55,
            this.Column53,
            this.Column54,
            this.Column58});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1415, 335);
            this.dataGridView1.TabIndex = 344;
            // 
            // Column46
            // 
            this.Column46.HeaderText = "TAKİP NO";
            this.Column46.Name = "Column46";
            // 
            // Column48
            // 
            this.Column48.HeaderText = "İŞLEM TÜRÜ";
            this.Column48.Name = "Column48";
            // 
            // Column49
            // 
            this.Column49.HeaderText = "STOK NO";
            this.Column49.Name = "Column49";
            // 
            // Column50
            // 
            this.Column50.HeaderText = "TANIM";
            this.Column50.Name = "Column50";
            // 
            // Column56
            // 
            this.Column56.HeaderText = "MİKTAR";
            this.Column56.Name = "Column56";
            // 
            // Column57
            // 
            this.Column57.HeaderText = "BİRİM";
            this.Column57.Name = "Column57";
            // 
            // Column51
            // 
            this.Column51.HeaderText = "SERİ NO";
            this.Column51.Name = "Column51";
            // 
            // Column52
            // 
            this.Column52.HeaderText = "LOT NO";
            this.Column52.Name = "Column52";
            // 
            // Column55
            // 
            this.Column55.HeaderText = "REVİZYON";
            this.Column55.Name = "Column55";
            // 
            // Column53
            // 
            this.Column53.HeaderText = "DEPO ADRES NO";
            this.Column53.Name = "Column53";
            // 
            // Column54
            // 
            this.Column54.HeaderText = "DEPO YERİ";
            this.Column54.Name = "Column54";
            // 
            // Column58
            // 
            this.Column58.HeaderText = "PERSONEL SİCİL";
            this.Column58.Name = "Column58";
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.advancedDataGridView1);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(1421, 341);
            this.tabPage11.TabIndex = 3;
            this.tabPage11.Text = "İŞLEM ADIM DURUM VE SÜRELERİ";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.advancedDataGridView1.AutoGenerateContextFilters = true;
            this.advancedDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advancedDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.advancedDataGridView1.DateWithTime = false;
            this.advancedDataGridView1.Location = new System.Drawing.Point(17, 19);
            this.advancedDataGridView1.MultiSelect = false;
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.ReadOnly = true;
            this.advancedDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView1.Size = new System.Drawing.Size(1380, 145);
            this.advancedDataGridView1.TabIndex = 4;
            this.advancedDataGridView1.TimeFilter = false;
            // 
            // FrmBOAtolyeDevamEdenler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 820);
            this.Controls.Add(this.tabControl3);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBOAtolyeDevamEdenler";
            this.Text = "FrmBOAtolyeDevamEdenler";
            this.Load += new System.EventHandler(this.FrmBOAtolyeDevamEdenler_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDevamEden)).EndInit();
            this.tabControl3.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeler)).EndInit();
            this.tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgDevamEden;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private ADGV.AdvancedDataGridView DtgMalzemeler;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column46;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column48;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column49;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column50;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column56;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column57;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column51;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column52;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column55;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column53;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column54;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column58;
        private System.Windows.Forms.TabPage tabPage11;
        private ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.BindingSource dataBinder;
    }
}