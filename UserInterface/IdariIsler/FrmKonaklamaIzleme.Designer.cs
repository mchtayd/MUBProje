
namespace UserInterface.IdariIsler
{
    partial class FrmKonaklamaIzleme
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yenileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sss = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.LblGenelTop = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgIslemAdimlari = new ADGV.AdvancedDataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtToplam = new System.Windows.Forms.Label();
            this.dataBinder2 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.sss.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslemAdimlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1557, 27);
            this.panel1.TabIndex = 340;
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
            this.DtgList.Location = new System.Drawing.Point(3, 3);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgList.Size = new System.Drawing.Size(1543, 633);
            this.DtgList.TabIndex = 2;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yenileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 26);
            // 
            // yenileToolStripMenuItem
            // 
            this.yenileToolStripMenuItem.Name = "yenileToolStripMenuItem";
            this.yenileToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.yenileToolStripMenuItem.Text = "Yenile";
            this.yenileToolStripMenuItem.Click += new System.EventHandler(this.yenileToolStripMenuItem_Click);
            // 
            // sss
            // 
            this.sss.Controls.Add(this.tabPage1);
            this.sss.Location = new System.Drawing.Point(0, 33);
            this.sss.Name = "sss";
            this.sss.SelectedIndex = 0;
            this.sss.Size = new System.Drawing.Size(1557, 879);
            this.sss.TabIndex = 344;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.LblGenelTop);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.TxtToplam);
            this.tabPage1.Controls.Add(this.DtgList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1549, 853);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "GÜNCEL KONAKLAMA LİSTESİ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(153, 650);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 348;
            this.label3.Text = "Genel Toplam:";
            // 
            // LblGenelTop
            // 
            this.LblGenelTop.AutoSize = true;
            this.LblGenelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblGenelTop.Location = new System.Drawing.Point(260, 650);
            this.LblGenelTop.Name = "LblGenelTop";
            this.LblGenelTop.Size = new System.Drawing.Size(34, 15);
            this.LblGenelTop.TabIndex = 349;
            this.LblGenelTop.Text = "00  ₺";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Location = new System.Drawing.Point(698, 677);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(686, 170);
            this.groupBox2.TabIndex = 347;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "KONAKLAMA DOSYASI";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(680, 151);
            this.webBrowser1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgIslemAdimlari);
            this.groupBox1.Location = new System.Drawing.Point(6, 677);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 170);
            this.groupBox1.TabIndex = 346;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İŞLEM ADIMLARI";
            // 
            // DtgIslemAdimlari
            // 
            this.DtgIslemAdimlari.AutoGenerateContextFilters = true;
            this.DtgIslemAdimlari.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtgIslemAdimlari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgIslemAdimlari.DateWithTime = false;
            this.DtgIslemAdimlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgIslemAdimlari.Location = new System.Drawing.Point(3, 16);
            this.DtgIslemAdimlari.Name = "DtgIslemAdimlari";
            this.DtgIslemAdimlari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgIslemAdimlari.Size = new System.Drawing.Size(680, 151);
            this.DtgIslemAdimlari.TabIndex = 0;
            this.DtgIslemAdimlari.TimeFilter = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(0, 650);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 344;
            this.label2.Text = "Toplam Kayıt:";
            // 
            // TxtToplam
            // 
            this.TxtToplam.AutoSize = true;
            this.TxtToplam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtToplam.Location = new System.Drawing.Point(100, 650);
            this.TxtToplam.Name = "TxtToplam";
            this.TxtToplam.Size = new System.Drawing.Size(21, 15);
            this.TxtToplam.TabIndex = 345;
            this.TxtToplam.Text = "00";
            // 
            // FrmKonaklamaIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 924);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.sss);
            this.Controls.Add(this.panel1);
            this.Name = "FrmKonaklamaIzleme";
            this.Text = "FrmKonaklamaIzleme";
            this.Load += new System.EventHandler(this.FrmKonaklamaIzleme_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.sss.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgIslemAdimlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yenileToolStripMenuItem;
        private System.Windows.Forms.TabControl sss;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.BindingSource dataBinder2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TxtToplam;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgIslemAdimlari;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblGenelTop;
    }
}