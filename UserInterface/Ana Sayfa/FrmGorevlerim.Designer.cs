
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgBolgeler = new ADGV.AdvancedDataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yönlendirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.durumGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arızaKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolgeler)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1459, 27);
            this.panel1.TabIndex = 313;
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
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1435, 758);
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
            this.tabPage1.Size = new System.Drawing.Size(1427, 732);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AÇIK ARIZA GÖREVLERİM";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1427, 732);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "YÖNETİCİ GÖREVLERİM";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgBolgeler);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1415, 679);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GÖREV LİSTESİ";
            // 
            // DtgBolgeler
            // 
            this.DtgBolgeler.AllowUserToAddRows = false;
            this.DtgBolgeler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgBolgeler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DtgBolgeler.AutoGenerateContextFilters = true;
            this.DtgBolgeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgBolgeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgBolgeler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column2,
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
            this.DtgBolgeler.Size = new System.Drawing.Size(1409, 660);
            this.DtgBolgeler.TabIndex = 3;
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
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(6, 700);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 342;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(106, 700);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 343;
            this.TxtTop.Text = "00";
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
            this.ClientSize = new System.Drawing.Size(1459, 804);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmGorevlerim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGorevlerim";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolgeler)).EndInit();
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
        private ADGV.AdvancedDataGridView DtgBolgeler;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yönlendirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem durumGüncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arızaKapatToolStripMenuItem;
    }
}