
namespace UserInterface.IdariIsler
{
    partial class FrmZiyaretciKayitIzleme
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
            this.DtgZiyaretciList = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtgSatIslemAdimlari = new System.Windows.Forms.DataGridView();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgZiyaretciList)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgSatIslemAdimlari)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1557, 27);
            this.panel1.TabIndex = 321;
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
            this.groupBox1.Controls.Add(this.DtgZiyaretciList);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1533, 568);
            this.groupBox1.TabIndex = 322;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ZİYARETÇİ LİSTESİ";
            // 
            // DtgZiyaretciList
            // 
            this.DtgZiyaretciList.AllowUserToAddRows = false;
            this.DtgZiyaretciList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgZiyaretciList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgZiyaretciList.AutoGenerateContextFilters = true;
            this.DtgZiyaretciList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgZiyaretciList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgZiyaretciList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgZiyaretciList.DateWithTime = false;
            this.DtgZiyaretciList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgZiyaretciList.Location = new System.Drawing.Point(3, 16);
            this.DtgZiyaretciList.MultiSelect = false;
            this.DtgZiyaretciList.Name = "DtgZiyaretciList";
            this.DtgZiyaretciList.ReadOnly = true;
            this.DtgZiyaretciList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgZiyaretciList.Size = new System.Drawing.Size(1527, 549);
            this.DtgZiyaretciList.TabIndex = 2;
            this.DtgZiyaretciList.TimeFilter = false;
            this.DtgZiyaretciList.SortStringChanged += new System.EventHandler(this.DtgZiyaretciList_SortStringChanged);
            this.DtgZiyaretciList.FilterStringChanged += new System.EventHandler(this.DtgZiyaretciList_FilterStringChanged);
            this.DtgZiyaretciList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgZiyaretciList_CellMouseClick);
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 620);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 324;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 620);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 323;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DtgSatIslemAdimlari);
            this.groupBox3.Location = new System.Drawing.Point(15, 652);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(763, 255);
            this.groupBox3.TabIndex = 409;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "VERİ GEÇMİŞİ";
            // 
            // DtgSatIslemAdimlari
            // 
            this.DtgSatIslemAdimlari.AllowUserToAddRows = false;
            this.DtgSatIslemAdimlari.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgSatIslemAdimlari.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgSatIslemAdimlari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgSatIslemAdimlari.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgSatIslemAdimlari.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DtgSatIslemAdimlari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgSatIslemAdimlari.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgSatIslemAdimlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgSatIslemAdimlari.Location = new System.Drawing.Point(3, 16);
            this.DtgSatIslemAdimlari.MultiSelect = false;
            this.DtgSatIslemAdimlari.Name = "DtgSatIslemAdimlari";
            this.DtgSatIslemAdimlari.ReadOnly = true;
            this.DtgSatIslemAdimlari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgSatIslemAdimlari.Size = new System.Drawing.Size(757, 236);
            this.DtgSatIslemAdimlari.TabIndex = 4;
            // 
            // FrmZiyaretciKayitIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 924);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmZiyaretciKayitIzleme";
            this.Text = "FrmZiyaretciKayitIzleme";
            this.Load += new System.EventHandler(this.FrmZiyaretciKayitIzleme_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgZiyaretciList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgSatIslemAdimlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgZiyaretciList;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DtgSatIslemAdimlari;
        private System.Windows.Forms.BindingSource dataBinder;
    }
}