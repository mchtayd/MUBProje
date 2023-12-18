
namespace UserInterface.BakımOnarım
{
    partial class FrmBolgeKayitIzleme
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgBolgeler = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DtgGarantiPaketi = new ADGV.AdvancedDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DtgEnvanterList = new ADGV.AdvancedDataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.DtgList = new System.Windows.Forms.DataGridView();
            this.dataBinderEkipman = new System.Windows.Forms.BindingSource(this.components);
            this.LblEkipman = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolgeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgGarantiPaketi)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEnvanterList)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderEkipman)).BeginInit();
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
            this.panel1.TabIndex = 310;
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
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1452, 288);
            this.groupBox1.TabIndex = 311;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BÖLGELER";
            // 
            // DtgBolgeler
            // 
            this.DtgBolgeler.AllowUserToAddRows = false;
            this.DtgBolgeler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgBolgeler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgBolgeler.AutoGenerateContextFilters = true;
            this.DtgBolgeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgBolgeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgBolgeler.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgBolgeler.DateWithTime = false;
            this.DtgBolgeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgBolgeler.Location = new System.Drawing.Point(3, 16);
            this.DtgBolgeler.Name = "DtgBolgeler";
            this.DtgBolgeler.ReadOnly = true;
            this.DtgBolgeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgBolgeler.Size = new System.Drawing.Size(1446, 269);
            this.DtgBolgeler.TabIndex = 2;
            this.DtgBolgeler.TimeFilter = false;
            this.DtgBolgeler.SortStringChanged += new System.EventHandler(this.DtgBolgeler_SortStringChanged);
            this.DtgBolgeler.FilterStringChanged += new System.EventHandler(this.DtgBolgeler_FilterStringChanged);
            this.DtgBolgeler.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgBolgeler_CellMouseClick);
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(118, 328);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 313;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(18, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 312;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 349);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1449, 520);
            this.tabControl1.TabIndex = 316;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DtgGarantiPaketi);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1431, 494);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "GARANTİ PAKETİ BİLGİLERİ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DtgGarantiPaketi
            // 
            this.DtgGarantiPaketi.AllowUserToAddRows = false;
            this.DtgGarantiPaketi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgGarantiPaketi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgGarantiPaketi.AutoGenerateContextFilters = true;
            this.DtgGarantiPaketi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgGarantiPaketi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgGarantiPaketi.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgGarantiPaketi.DateWithTime = false;
            this.DtgGarantiPaketi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgGarantiPaketi.Location = new System.Drawing.Point(3, 3);
            this.DtgGarantiPaketi.MultiSelect = false;
            this.DtgGarantiPaketi.Name = "DtgGarantiPaketi";
            this.DtgGarantiPaketi.ReadOnly = true;
            this.DtgGarantiPaketi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgGarantiPaketi.Size = new System.Drawing.Size(1425, 488);
            this.DtgGarantiPaketi.TabIndex = 6;
            this.DtgGarantiPaketi.TimeFilter = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LblEkipman);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.DtgEnvanterList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1441, 494);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "EKİPMAN BİLGİLERİ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DtgEnvanterList
            // 
            this.DtgEnvanterList.AllowUserToAddRows = false;
            this.DtgEnvanterList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgEnvanterList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DtgEnvanterList.AutoGenerateContextFilters = true;
            this.DtgEnvanterList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgEnvanterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgEnvanterList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgEnvanterList.DateWithTime = false;
            this.DtgEnvanterList.Location = new System.Drawing.Point(3, 3);
            this.DtgEnvanterList.MultiSelect = false;
            this.DtgEnvanterList.Name = "DtgEnvanterList";
            this.DtgEnvanterList.ReadOnly = true;
            this.DtgEnvanterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgEnvanterList.Size = new System.Drawing.Size(1432, 453);
            this.DtgEnvanterList.TabIndex = 7;
            this.DtgEnvanterList.TimeFilter = false;
            this.DtgEnvanterList.SortStringChanged += new System.EventHandler(this.DtgEnvanterList_SortStringChanged);
            this.DtgEnvanterList.FilterStringChanged += new System.EventHandler(this.DtgEnvanterList_FilterStringChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.webBrowser1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1431, 298);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "EKLER";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1425, 292);
            this.webBrowser1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.DtgList);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1431, 298);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "NOTLAR";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 3);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.Size = new System.Drawing.Size(1425, 292);
            this.DtgList.TabIndex = 2;
            // 
            // LblEkipman
            // 
            this.LblEkipman.AutoSize = true;
            this.LblEkipman.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblEkipman.Location = new System.Drawing.Point(106, 465);
            this.LblEkipman.Name = "LblEkipman";
            this.LblEkipman.Size = new System.Drawing.Size(21, 15);
            this.LblEkipman.TabIndex = 315;
            this.LblEkipman.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 465);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 314;
            this.label2.Text = "Toplam Kayıt:";
            // 
            // FrmBolgeKayitIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 872);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBolgeKayitIzleme";
            this.Text = "FrmBolgeKayitIzleme";
            this.Load += new System.EventHandler(this.FrmBolgeKayitIzleme_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolgeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgGarantiPaketi)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEnvanterList)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderEkipman)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgBolgeler;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ADGV.AdvancedDataGridView DtgGarantiPaketi;
        private System.Windows.Forms.TabPage tabPage2;
        private ADGV.AdvancedDataGridView DtgEnvanterList;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView DtgList;
        private System.Windows.Forms.BindingSource dataBinderEkipman;
        private System.Windows.Forms.Label LblEkipman;
        private System.Windows.Forms.Label label2;
    }
}