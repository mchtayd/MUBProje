
namespace UserInterface.BakımOnarım
{
    partial class FrmMalzemeDuzenle
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.TxtStokNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtTanim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgEklenecekMalzemeler = new ADGV.AdvancedDataGridView();
            this.BtnSiparisKaydet = new System.Windows.Forms.Button();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.ContextMenuEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEklenecekMalzemeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.ContextMenuEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1209, 295);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MALZEME LİSTESİ";
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
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
            this.DtgList.Size = new System.Drawing.Size(1203, 276);
            this.DtgList.TabIndex = 3;
            this.DtgList.TimeFilter = false;
            this.DtgList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DtgList_MouseDoubleClick);
            // 
            // TxtStokNo
            // 
            this.TxtStokNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtStokNo.Location = new System.Drawing.Point(90, 13);
            this.TxtStokNo.Name = "TxtStokNo";
            this.TxtStokNo.Size = new System.Drawing.Size(165, 21);
            this.TxtStokNo.TabIndex = 424;
            this.TxtStokNo.TextChanged += new System.EventHandler(this.TxtAbfFormNo_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(23, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.TabIndex = 423;
            this.label9.Text = "Stok No:";
            // 
            // TxtTanim
            // 
            this.TxtTanim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTanim.Location = new System.Drawing.Point(348, 13);
            this.TxtTanim.Name = "TxtTanim";
            this.TxtTanim.Size = new System.Drawing.Size(251, 21);
            this.TxtTanim.TabIndex = 426;
            this.TxtTanim.TextChanged += new System.EventHandler(this.TxtTanim_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(291, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 425;
            this.label1.Text = "Tanım:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgEklenecekMalzemeler);
            this.groupBox2.Location = new System.Drawing.Point(15, 387);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1209, 295);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EKLİ MALZEMELER";
            // 
            // DtgEklenecekMalzemeler
            // 
            this.DtgEklenecekMalzemeler.AllowUserToAddRows = false;
            this.DtgEklenecekMalzemeler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgEklenecekMalzemeler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DtgEklenecekMalzemeler.AutoGenerateContextFilters = true;
            this.DtgEklenecekMalzemeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgEklenecekMalzemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgEklenecekMalzemeler.ContextMenuStrip = this.ContextMenuEdit;
            this.DtgEklenecekMalzemeler.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgEklenecekMalzemeler.DateWithTime = false;
            this.DtgEklenecekMalzemeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgEklenecekMalzemeler.Location = new System.Drawing.Point(3, 16);
            this.DtgEklenecekMalzemeler.MultiSelect = false;
            this.DtgEklenecekMalzemeler.Name = "DtgEklenecekMalzemeler";
            this.DtgEklenecekMalzemeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgEklenecekMalzemeler.Size = new System.Drawing.Size(1203, 276);
            this.DtgEklenecekMalzemeler.TabIndex = 3;
            this.DtgEklenecekMalzemeler.TimeFilter = false;
            this.DtgEklenecekMalzemeler.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgEklenecekMalzemeler_CellMouseClick);
            // 
            // BtnSiparisKaydet
            // 
            this.BtnSiparisKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSiparisKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSiparisKaydet.Location = new System.Drawing.Point(17, 688);
            this.BtnSiparisKaydet.Name = "BtnSiparisKaydet";
            this.BtnSiparisKaydet.Size = new System.Drawing.Size(119, 46);
            this.BtnSiparisKaydet.TabIndex = 427;
            this.BtnSiparisKaydet.Text = "KAYDET";
            this.BtnSiparisKaydet.UseVisualStyleBackColor = true;
            this.BtnSiparisKaydet.Click += new System.EventHandler(this.BtnSiparisKaydet_Click);
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(115, 355);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 429;
            this.TxtTop.Text = "00";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(15, 355);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 428;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // ContextMenuEdit
            // 
            this.ContextMenuEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.silToolStripMenuItem});
            this.ContextMenuEdit.Name = "ContextMenuEdit";
            this.ContextMenuEdit.Size = new System.Drawing.Size(87, 26);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // FrmMalzemeDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 802);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.BtnSiparisKaydet);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.TxtTanim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtStokNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMalzemeDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BtnMalzemeDuzenle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMalzemeDuzenle_FormClosing);
            this.Load += new System.EventHandler(this.BtnMalzemeDuzenle_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgEklenecekMalzemeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ContextMenuEdit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtStokNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtTanim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ADGV.AdvancedDataGridView DtgList;
        private ADGV.AdvancedDataGridView DtgEklenecekMalzemeler;
        private System.Windows.Forms.Button BtnSiparisKaydet;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.ContextMenuStrip ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
    }
}