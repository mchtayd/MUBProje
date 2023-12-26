namespace UserInterface.Ana_Sayfa
{
    partial class FrmGorevliPersoneller
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.DtgGorevler = new ADGV.AdvancedDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.göreviGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.açıklamaTalepEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.açıklamaTalepEtToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.dataBinder2 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblToplamGorev = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgGorevler)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgList.DateWithTime = false;
            this.DtgList.Location = new System.Drawing.Point(12, 12);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgList.Size = new System.Drawing.Size(1549, 293);
            this.DtgList.TabIndex = 3;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            // 
            // DtgGorevler
            // 
            this.DtgGorevler.AllowUserToAddRows = false;
            this.DtgGorevler.AllowUserToDeleteRows = false;
            this.DtgGorevler.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgGorevler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DtgGorevler.AutoGenerateContextFilters = true;
            this.DtgGorevler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgGorevler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgGorevler.ContextMenuStrip = this.contextMenuStrip1;
            this.DtgGorevler.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgGorevler.DateWithTime = false;
            this.DtgGorevler.Location = new System.Drawing.Point(12, 346);
            this.DtgGorevler.Name = "DtgGorevler";
            this.DtgGorevler.ReadOnly = true;
            this.DtgGorevler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgGorevler.Size = new System.Drawing.Size(1549, 369);
            this.DtgGorevler.TabIndex = 10;
            this.DtgGorevler.TimeFilter = false;
            this.DtgGorevler.SortStringChanged += new System.EventHandler(this.DtgGorevler_SortStringChanged);
            this.DtgGorevler.FilterStringChanged += new System.EventHandler(this.DtgGorevler_FilterStringChanged);
            this.DtgGorevler.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgGorevler_CellMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.göreviGörüntüleToolStripMenuItem,
            this.açıklamaTalepEtToolStripMenuItem,
            this.açıklamaTalepEtToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 70);
            // 
            // göreviGörüntüleToolStripMenuItem
            // 
            this.göreviGörüntüleToolStripMenuItem.Name = "göreviGörüntüleToolStripMenuItem";
            this.göreviGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.göreviGörüntüleToolStripMenuItem.Text = "Görevi Görüntüle";
            this.göreviGörüntüleToolStripMenuItem.Click += new System.EventHandler(this.göreviGörüntüleToolStripMenuItem_Click);
            // 
            // açıklamaTalepEtToolStripMenuItem
            // 
            this.açıklamaTalepEtToolStripMenuItem.Name = "açıklamaTalepEtToolStripMenuItem";
            this.açıklamaTalepEtToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.açıklamaTalepEtToolStripMenuItem.Text = "Personeli Uyar";
            this.açıklamaTalepEtToolStripMenuItem.Click += new System.EventHandler(this.açıklamaTalepEtToolStripMenuItem_Click);
            // 
            // açıklamaTalepEtToolStripMenuItem1
            // 
            this.açıklamaTalepEtToolStripMenuItem1.Name = "açıklamaTalepEtToolStripMenuItem1";
            this.açıklamaTalepEtToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.açıklamaTalepEtToolStripMenuItem1.Text = "Açıklama Talep Et";
            this.açıklamaTalepEtToolStripMenuItem1.Click += new System.EventHandler(this.açıklamaTalepEtToolStripMenuItem1_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(1023, 736);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 27);
            this.button1.TabIndex = 124;
            this.button1.Text = "Fazla Görev Temizle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(423, 736);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 15);
            this.label2.TabIndex = 128;
            this.label2.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(232, 736);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 15);
            this.label3.TabIndex = 127;
            this.label3.Text = "Toplam Devam Eden Görev:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(152, 736);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 15);
            this.label4.TabIndex = 126;
            this.label4.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(26, 736);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 15);
            this.label6.TabIndex = 125;
            this.label6.Text = "Toplam Personel:";
            // 
            // LblToplamGorev
            // 
            this.LblToplamGorev.AutoSize = true;
            this.LblToplamGorev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblToplamGorev.Location = new System.Drawing.Point(406, 318);
            this.LblToplamGorev.Name = "LblToplamGorev";
            this.LblToplamGorev.Size = new System.Drawing.Size(21, 15);
            this.LblToplamGorev.TabIndex = 132;
            this.LblToplamGorev.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(215, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 15);
            this.label5.TabIndex = 131;
            this.label5.Text = "Toplam Devam Eden Görev:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(135, 318);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 130;
            this.TxtTop.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(9, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 129;
            this.label1.Text = "Toplam Personel:";
            // 
            // FrmGorevliPersoneller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1573, 765);
            this.Controls.Add(this.LblToplamGorev);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DtgGorevler);
            this.Controls.Add(this.DtgList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGorevliPersoneller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Görevli Personeller";
            this.Load += new System.EventHandler(this.FrmGorevliPersoneller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgGorevler)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.BindingSource dataBinder2;
        private ADGV.AdvancedDataGridView DtgGorevler;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem göreviGörüntüleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem açıklamaTalepEtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem açıklamaTalepEtToolStripMenuItem1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblToplamGorev;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label1;
    }
}