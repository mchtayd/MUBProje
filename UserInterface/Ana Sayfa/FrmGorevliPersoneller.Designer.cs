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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.LblToplamGorev = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DtgGorevler = new ADGV.AdvancedDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.göreviGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.açıklamaTalepEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.açıklamaTalepEtToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PcFoto = new System.Windows.Forms.PictureBox();
            this.LblToplamGorevSayisi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblTamamlananGorev = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblDevamEdenGorev = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.dataBinder2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgGorevler)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PcFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgList.DateWithTime = false;
            this.DtgList.Location = new System.Drawing.Point(12, 12);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgList.Size = new System.Drawing.Size(493, 672);
            this.DtgList.TabIndex = 3;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 695);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Toplam Personel:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(138, 695);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 6;
            this.TxtTop.Text = "00";
            // 
            // LblToplamGorev
            // 
            this.LblToplamGorev.AutoSize = true;
            this.LblToplamGorev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblToplamGorev.Location = new System.Drawing.Point(409, 695);
            this.LblToplamGorev.Name = "LblToplamGorev";
            this.LblToplamGorev.Size = new System.Drawing.Size(21, 15);
            this.LblToplamGorev.TabIndex = 9;
            this.LblToplamGorev.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(218, 695);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Toplam Devam Eden Görev:";
            // 
            // DtgGorevler
            // 
            this.DtgGorevler.AllowUserToAddRows = false;
            this.DtgGorevler.AllowUserToDeleteRows = false;
            this.DtgGorevler.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgGorevler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgGorevler.AutoGenerateContextFilters = true;
            this.DtgGorevler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgGorevler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgGorevler.ContextMenuStrip = this.contextMenuStrip1;
            this.DtgGorevler.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgGorevler.DateWithTime = false;
            this.DtgGorevler.Location = new System.Drawing.Point(511, 12);
            this.DtgGorevler.Name = "DtgGorevler";
            this.DtgGorevler.ReadOnly = true;
            this.DtgGorevler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgGorevler.Size = new System.Drawing.Size(651, 672);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            // 
            // göreviGörüntüleToolStripMenuItem
            // 
            this.göreviGörüntüleToolStripMenuItem.Name = "göreviGörüntüleToolStripMenuItem";
            this.göreviGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.göreviGörüntüleToolStripMenuItem.Text = "Görevi Görüntüle";
            this.göreviGörüntüleToolStripMenuItem.Click += new System.EventHandler(this.göreviGörüntüleToolStripMenuItem_Click);
            // 
            // açıklamaTalepEtToolStripMenuItem
            // 
            this.açıklamaTalepEtToolStripMenuItem.Name = "açıklamaTalepEtToolStripMenuItem";
            this.açıklamaTalepEtToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.açıklamaTalepEtToolStripMenuItem.Text = "Personeli Uyar";
            this.açıklamaTalepEtToolStripMenuItem.Click += new System.EventHandler(this.açıklamaTalepEtToolStripMenuItem_Click);
            // 
            // açıklamaTalepEtToolStripMenuItem1
            // 
            this.açıklamaTalepEtToolStripMenuItem1.Name = "açıklamaTalepEtToolStripMenuItem1";
            this.açıklamaTalepEtToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.açıklamaTalepEtToolStripMenuItem1.Text = "Açıklama Talep Et";
            this.açıklamaTalepEtToolStripMenuItem1.Click += new System.EventHandler(this.açıklamaTalepEtToolStripMenuItem1_Click);
            // 
            // PcFoto
            // 
            this.PcFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PcFoto.Location = new System.Drawing.Point(1266, 12);
            this.PcFoto.Name = "PcFoto";
            this.PcFoto.Size = new System.Drawing.Size(138, 156);
            this.PcFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PcFoto.TabIndex = 113;
            this.PcFoto.TabStop = false;
            // 
            // LblToplamGorevSayisi
            // 
            this.LblToplamGorevSayisi.AutoSize = true;
            this.LblToplamGorevSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblToplamGorevSayisi.Location = new System.Drawing.Point(1181, 233);
            this.LblToplamGorevSayisi.Name = "LblToplamGorevSayisi";
            this.LblToplamGorevSayisi.Size = new System.Drawing.Size(36, 25);
            this.LblToplamGorevSayisi.TabIndex = 115;
            this.LblToplamGorevSayisi.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(1168, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(331, 16);
            this.label3.TabIndex = 114;
            this.label3.Text = "Şimdiye Kadar Ki Toplam Atanan Görev Sayısı:";
            // 
            // LblTamamlananGorev
            // 
            this.LblTamamlananGorev.AutoSize = true;
            this.LblTamamlananGorev.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTamamlananGorev.Location = new System.Drawing.Point(1181, 317);
            this.LblTamamlananGorev.Name = "LblTamamlananGorev";
            this.LblTamamlananGorev.Size = new System.Drawing.Size(36, 25);
            this.LblTamamlananGorev.TabIndex = 117;
            this.LblTamamlananGorev.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(1168, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 16);
            this.label6.TabIndex = 116;
            this.label6.Text = "Tamamlanan Görev Sayısı:";
            // 
            // LblDevamEdenGorev
            // 
            this.LblDevamEdenGorev.AutoSize = true;
            this.LblDevamEdenGorev.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblDevamEdenGorev.Location = new System.Drawing.Point(1181, 418);
            this.LblDevamEdenGorev.Name = "LblDevamEdenGorev";
            this.LblDevamEdenGorev.Size = new System.Drawing.Size(36, 25);
            this.LblDevamEdenGorev.TabIndex = 119;
            this.LblDevamEdenGorev.Text = "00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(1168, 378);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(193, 16);
            this.label8.TabIndex = 118;
            this.label8.Text = "Devam Eden Görev Sayısı:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(1182, 518);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 25);
            this.label9.TabIndex = 121;
            this.label9.Text = "00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(1169, 478);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 16);
            this.label10.TabIndex = 120;
            this.label10.Text = "Ortalama Müdehale Süresi:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(1182, 621);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 25);
            this.label11.TabIndex = 123;
            this.label11.Text = "00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(1169, 581);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 16);
            this.label12.TabIndex = 122;
            this.label12.Text = "Performans Puanı:";
            // 
            // FrmGorevliPersoneller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1501, 724);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LblDevamEdenGorev);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LblTamamlananGorev);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LblToplamGorevSayisi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PcFoto);
            this.Controls.Add(this.DtgGorevler);
            this.Controls.Add(this.LblToplamGorev);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label1);
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
            ((System.ComponentModel.ISupportInitialize)(this.PcFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.Label LblToplamGorev;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource dataBinder2;
        private ADGV.AdvancedDataGridView DtgGorevler;
        private System.Windows.Forms.PictureBox PcFoto;
        private System.Windows.Forms.Label LblToplamGorevSayisi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTamamlananGorev;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblDevamEdenGorev;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem göreviGörüntüleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem açıklamaTalepEtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem açıklamaTalepEtToolStripMenuItem1;
    }
}