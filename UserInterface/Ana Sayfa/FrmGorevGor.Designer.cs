namespace UserInterface.Ana_Sayfa
{
    partial class FrmGorevGor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgDevamEden = new ADGV.AdvancedDataGridView();
            this.LblGorevAdi = new System.Windows.Forms.Label();
            this.LblDepartman = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDevamEden)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(49, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Görev Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(39, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Departman:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DtgDevamEden);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(902, 154);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // DtgDevamEden
            // 
            this.DtgDevamEden.AllowUserToAddRows = false;
            this.DtgDevamEden.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgDevamEden.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgDevamEden.AutoGenerateContextFilters = true;
            this.DtgDevamEden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgDevamEden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDevamEden.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgDevamEden.DateWithTime = false;
            this.DtgDevamEden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgDevamEden.Location = new System.Drawing.Point(3, 16);
            this.DtgDevamEden.Name = "DtgDevamEden";
            this.DtgDevamEden.ReadOnly = true;
            this.DtgDevamEden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgDevamEden.Size = new System.Drawing.Size(896, 135);
            this.DtgDevamEden.TabIndex = 4;
            this.DtgDevamEden.TimeFilter = false;
            // 
            // LblGorevAdi
            // 
            this.LblGorevAdi.AutoSize = true;
            this.LblGorevAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblGorevAdi.Location = new System.Drawing.Point(117, 26);
            this.LblGorevAdi.Name = "LblGorevAdi";
            this.LblGorevAdi.Size = new System.Drawing.Size(21, 15);
            this.LblGorevAdi.TabIndex = 50;
            this.LblGorevAdi.Text = "00";
            // 
            // LblDepartman
            // 
            this.LblDepartman.AutoSize = true;
            this.LblDepartman.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblDepartman.Location = new System.Drawing.Point(117, 56);
            this.LblDepartman.Name = "LblDepartman";
            this.LblDepartman.Size = new System.Drawing.Size(21, 15);
            this.LblDepartman.TabIndex = 51;
            this.LblDepartman.Text = "00";
            // 
            // FrmGorevGor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 278);
            this.Controls.Add(this.LblDepartman);
            this.Controls.Add(this.LblGorevAdi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGorevGor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Görev İçeriği";
            this.Load += new System.EventHandler(this.FrmGorevGor_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDevamEden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgDevamEden;
        public System.Windows.Forms.Label LblGorevAdi;
        public System.Windows.Forms.Label LblDepartman;
    }
}