
namespace UserInterface.Ana_Sayfa
{
    partial class FrmGorevlerim
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgGorevlerim = new ADGV.AdvancedDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTop3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.advancedDataGridView1 = new ADGV.AdvancedDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.görevAtaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.göreveGitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yönlendirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.durumGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arızaKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgGorevlerim)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(973, 780);
            this.tabControl1.TabIndex = 314;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.TxtTop);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(965, 754);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AÇIK ARIZA GÖREVLERİM";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(6, 701);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 342;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(106, 701);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 343;
            this.TxtTop.Text = "00";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgGorevlerim);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(809, 682);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GÖREV LİSTESİ";
            // 
            // DtgGorevlerim
            // 
            this.DtgGorevlerim.AllowUserToAddRows = false;
            this.DtgGorevlerim.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgGorevlerim.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgGorevlerim.AutoGenerateContextFilters = true;
            this.DtgGorevlerim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgGorevlerim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgGorevlerim.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgGorevlerim.DateWithTime = false;
            this.DtgGorevlerim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgGorevlerim.Location = new System.Drawing.Point(3, 16);
            this.DtgGorevlerim.MultiSelect = false;
            this.DtgGorevlerim.Name = "DtgGorevlerim";
            this.DtgGorevlerim.ReadOnly = true;
            this.DtgGorevlerim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgGorevlerim.Size = new System.Drawing.Size(803, 663);
            this.DtgGorevlerim.TabIndex = 3;
            this.DtgGorevlerim.TimeFilter = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(965, 754);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "YÖNETİCİ GÖREVLERİM";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.TxtTop3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(965, 754);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "İŞ AKIŞI GÖREVLERİM";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(13, 712);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 344;
            this.label1.Text = "Toplam Kayıt:";
            // 
            // TxtTop3
            // 
            this.TxtTop3.AutoSize = true;
            this.TxtTop3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop3.Location = new System.Drawing.Point(113, 712);
            this.TxtTop3.Name = "TxtTop3";
            this.TxtTop3.Size = new System.Drawing.Size(21, 15);
            this.TxtTop3.TabIndex = 345;
            this.TxtTop3.Text = "00";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.advancedDataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(13, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(939, 682);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GÖREV LİSTESİ";
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.advancedDataGridView1.AutoGenerateContextFilters = true;
            this.advancedDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column5,
            this.Column3,
            this.dataGridViewTextBoxColumn6});
            this.advancedDataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.advancedDataGridView1.DateWithTime = false;
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView1.Location = new System.Drawing.Point(3, 16);
            this.advancedDataGridView1.MultiSelect = false;
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.ReadOnly = true;
            this.advancedDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridView1.Size = new System.Drawing.Size(933, 663);
            this.advancedDataGridView1.TabIndex = 3;
            this.advancedDataGridView1.TimeFilter = false;
            this.advancedDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellContentClick);
            this.advancedDataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridView1_CellMouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridViewTextBoxColumn1.HeaderText = "İŞ AKIŞ NO";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn1.Width = 81;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.görevAtaToolStripMenuItem,
            this.göreveGitToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(130, 48);
            // 
            // görevAtaToolStripMenuItem
            // 
            this.görevAtaToolStripMenuItem.Name = "görevAtaToolStripMenuItem";
            this.görevAtaToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.görevAtaToolStripMenuItem.Text = "Görev Ata";
            // 
            // göreveGitToolStripMenuItem
            // 
            this.göreveGitToolStripMenuItem.Name = "göreveGitToolStripMenuItem";
            this.göreveGitToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.göreveGitToolStripMenuItem.Text = "Göreve Git";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridViewTextBoxColumn2.HeaderText = "GÖREVİN TANIMI";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn2.Width = 111;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridViewTextBoxColumn3.HeaderText = "GÖREVİ İLETEN";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn3.Width = 105;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "GÖREV ATAMA TARİHİ/SAATİ";
            this.Column5.MinimumWidth = 22;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column5.Width = 168;
            // 
            // Column3
            // 
            this.Column3.ContextMenuStrip = this.contextMenuStrip2;
            this.Column3.HeaderText = "BULUNDUĞU İŞLEM ADIMI";
            this.Column3.MinimumWidth = 22;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column3.Width = 127;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridViewTextBoxColumn6.HeaderText = "İŞLEM ADIMI BEKLEME SÜRESİ";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 22;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn6.Width = 140;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yönlendirToolStripMenuItem,
            this.durumGüncelleToolStripMenuItem,
            this.arızaKapatToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 70);
            // 
            // yönlendirToolStripMenuItem
            // 
            this.yönlendirToolStripMenuItem.Name = "yönlendirToolStripMenuItem";
            this.yönlendirToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.yönlendirToolStripMenuItem.Text = "Sipariş Oluştur";
            // 
            // durumGüncelleToolStripMenuItem
            // 
            this.durumGüncelleToolStripMenuItem.Name = "durumGüncelleToolStripMenuItem";
            this.durumGüncelleToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.durumGüncelleToolStripMenuItem.Text = "Durum Güncelle";
            // 
            // arızaKapatToolStripMenuItem
            // 
            this.arızaKapatToolStripMenuItem.Name = "arızaKapatToolStripMenuItem";
            this.arızaKapatToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.arızaKapatToolStripMenuItem.Text = "Arıza Kapat";
            // 
            // FrmGorevlerim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 804);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGorevlerim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GÖREVLERİM";
            this.Load += new System.EventHandler(this.FrmGorevlerim_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgGorevlerim)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgGorevlerim;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yönlendirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem durumGüncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arızaKapatToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TxtTop3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem görevAtaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem göreveGitToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}