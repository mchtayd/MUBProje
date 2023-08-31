
namespace UserInterface.BakımOnarım
{
    partial class FrmDtfIzleme
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgDevamEden = new ADGV.AdvancedDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.LblGenelT = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DtgMaliyet = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.LblGenelTop = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblMaliyetTop = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTop2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtgTamamlanan = new ADGV.AdvancedDataGridView();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.dataBinderTamamlanan = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDevamEden)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMaliyet)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTamamlanan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderTamamlanan)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1555, 27);
            this.panel1.TabIndex = 316;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1543, 875);
            this.tabControl1.TabIndex = 317;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.TxtTop);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1535, 849);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DEVAM EDEN";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Location = new System.Drawing.Point(12, 555);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(856, 180);
            this.groupBox2.TabIndex = 346;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ekler:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(850, 161);
            this.webBrowser1.TabIndex = 0;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(9, 528);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 344;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(109, 528);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 345;
            this.TxtTop.Text = "00";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgDevamEden);
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1518, 516);
            this.groupBox1.TabIndex = 316;
            this.groupBox1.TabStop = false;
            // 
            // DtgDevamEden
            // 
            this.DtgDevamEden.AllowUserToAddRows = false;
            this.DtgDevamEden.AllowUserToDeleteRows = false;
            this.DtgDevamEden.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgDevamEden.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgDevamEden.AutoGenerateContextFilters = true;
            this.DtgDevamEden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgDevamEden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDevamEden.ContextMenuStrip = this.contextMenuStrip1;
            this.DtgDevamEden.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgDevamEden.DateWithTime = false;
            this.DtgDevamEden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgDevamEden.Location = new System.Drawing.Point(3, 16);
            this.DtgDevamEden.Name = "DtgDevamEden";
            this.DtgDevamEden.ReadOnly = true;
            this.DtgDevamEden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgDevamEden.Size = new System.Drawing.Size(1512, 497);
            this.DtgDevamEden.TabIndex = 2;
            this.DtgDevamEden.TimeFilter = false;
            this.DtgDevamEden.SortStringChanged += new System.EventHandler(this.DtgDevamEden_SortStringChanged);
            this.DtgDevamEden.FilterStringChanged += new System.EventHandler(this.DtgDevamEden_FilterStringChanged);
            this.DtgDevamEden.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgDevamEden_CellMouseClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.LblGenelT);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.LblGenelTop);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.LblMaliyetTop);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.TxtTop2);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1535, 849);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TAMAMLANAN";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(237, 525);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 15);
            this.label3.TabIndex = 357;
            this.label3.Text = "Genel Toplam Tutar:";
            // 
            // LblGenelT
            // 
            this.LblGenelT.AutoSize = true;
            this.LblGenelT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblGenelT.Location = new System.Drawing.Point(381, 525);
            this.LblGenelT.Name = "LblGenelT";
            this.LblGenelT.Size = new System.Drawing.Size(21, 15);
            this.LblGenelT.TabIndex = 358;
            this.LblGenelT.Text = "00";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.DtgMaliyet);
            this.groupBox5.Location = new System.Drawing.Point(756, 554);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(768, 258);
            this.groupBox5.TabIndex = 356;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "GENEL MALİYET TABLOSU";
            // 
            // DtgMaliyet
            // 
            this.DtgMaliyet.AllowUserToAddRows = false;
            this.DtgMaliyet.AllowUserToDeleteRows = false;
            this.DtgMaliyet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgMaliyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgMaliyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgMaliyet.Location = new System.Drawing.Point(3, 16);
            this.DtgMaliyet.Name = "DtgMaliyet";
            this.DtgMaliyet.ReadOnly = true;
            this.DtgMaliyet.Size = new System.Drawing.Size(762, 239);
            this.DtgMaliyet.TabIndex = 353;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(921, 819);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 15);
            this.label4.TabIndex = 354;
            this.label4.Text = "Toplam Maliyet Tutarı:";
            // 
            // LblGenelTop
            // 
            this.LblGenelTop.AutoSize = true;
            this.LblGenelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblGenelTop.Location = new System.Drawing.Point(1077, 819);
            this.LblGenelTop.Name = "LblGenelTop";
            this.LblGenelTop.Size = new System.Drawing.Size(21, 15);
            this.LblGenelTop.TabIndex = 355;
            this.LblGenelTop.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(753, 819);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 351;
            this.label2.Text = "Toplam Kayıt:";
            // 
            // LblMaliyetTop
            // 
            this.LblMaliyetTop.AutoSize = true;
            this.LblMaliyetTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblMaliyetTop.Location = new System.Drawing.Point(853, 819);
            this.LblMaliyetTop.Name = "LblMaliyetTop";
            this.LblMaliyetTop.Size = new System.Drawing.Size(21, 15);
            this.LblMaliyetTop.TabIndex = 352;
            this.LblMaliyetTop.Text = "00";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.webBrowser2);
            this.groupBox4.Location = new System.Drawing.Point(9, 554);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(741, 258);
            this.groupBox4.TabIndex = 349;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ekler:";
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(3, 16);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(735, 239);
            this.webBrowser2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 347;
            this.label1.Text = "Toplam Kayıt:";
            // 
            // TxtTop2
            // 
            this.TxtTop2.AutoSize = true;
            this.TxtTop2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop2.Location = new System.Drawing.Point(106, 525);
            this.TxtTop2.Name = "TxtTop2";
            this.TxtTop2.Size = new System.Drawing.Size(21, 15);
            this.TxtTop2.TabIndex = 348;
            this.TxtTop2.Text = "00";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DtgTamamlanan);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1521, 516);
            this.groupBox3.TabIndex = 317;
            this.groupBox3.TabStop = false;
            // 
            // DtgTamamlanan
            // 
            this.DtgTamamlanan.AllowUserToAddRows = false;
            this.DtgTamamlanan.AllowUserToDeleteRows = false;
            this.DtgTamamlanan.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgTamamlanan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgTamamlanan.AutoGenerateContextFilters = true;
            this.DtgTamamlanan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgTamamlanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgTamamlanan.ContextMenuStrip = this.contextMenuStrip1;
            this.DtgTamamlanan.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgTamamlanan.DateWithTime = false;
            this.DtgTamamlanan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgTamamlanan.Location = new System.Drawing.Point(3, 16);
            this.DtgTamamlanan.Name = "DtgTamamlanan";
            this.DtgTamamlanan.ReadOnly = true;
            this.DtgTamamlanan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgTamamlanan.Size = new System.Drawing.Size(1515, 497);
            this.DtgTamamlanan.TabIndex = 2;
            this.DtgTamamlanan.TimeFilter = false;
            this.DtgTamamlanan.SortStringChanged += new System.EventHandler(this.DtgTamamlanan_SortStringChanged);
            this.DtgTamamlanan.FilterStringChanged += new System.EventHandler(this.DtgTamamlanan_FilterStringChanged);
            this.DtgTamamlanan.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgTamamlanan_CellMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.silToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(87, 26);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // FrmDtfIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 909);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDtfIzleme";
            this.Text = "FrmDtfIzleme";
            this.Load += new System.EventHandler(this.FrmDtfIzleme_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDevamEden)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgMaliyet)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgTamamlanan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderTamamlanan)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgDevamEden;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TxtTop2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ADGV.AdvancedDataGridView DtgTamamlanan;
        private System.Windows.Forms.BindingSource dataBinderTamamlanan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblMaliyetTop;
        private System.Windows.Forms.DataGridView DtgMaliyet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblGenelTop;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblGenelT;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
    }
}