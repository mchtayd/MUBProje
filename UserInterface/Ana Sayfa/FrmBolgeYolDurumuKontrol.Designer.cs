namespace UserInterface.Ana_Sayfa
{
    partial class FrmBolgeYolDurumuKontrol
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.LblTop = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 465);
            this.groupBox1.TabIndex = 381;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UYARILARI DİKKATE ALMAYAN PERSONELLER";
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
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 16);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgList.Size = new System.Drawing.Size(712, 446);
            this.DtgList.TabIndex = 4;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            // 
            // LblTop
            // 
            this.LblTop.AutoSize = true;
            this.LblTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTop.Location = new System.Drawing.Point(112, 485);
            this.LblTop.Name = "LblTop";
            this.LblTop.Size = new System.Drawing.Size(21, 15);
            this.LblTop.TabIndex = 383;
            this.LblTop.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 485);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 382;
            this.label3.Text = "Toplam Kayıt:";
            // 
            // FrmBolgeYolDurumuKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 514);
            this.Controls.Add(this.LblTop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBolgeYolDurumuKontrol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bölge Yol Durumu Kayıt Kontrol";
            this.Load += new System.EventHandler(this.FrmBolgeYolDurumuKontrol_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.Label LblTop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource dataBinder;
    }
}