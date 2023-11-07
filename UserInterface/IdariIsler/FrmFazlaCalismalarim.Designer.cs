namespace UserInterface.IdariIsler
{
    partial class FrmFazlaCalismalarim
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblFazlaCalisma = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblIzin = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1396, 621);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.DateWithTime = false;
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 16);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.Size = new System.Drawing.Size(1390, 602);
            this.DtgList.TabIndex = 0;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(127, 643);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 337;
            this.TxtTop.Text = "00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(27, 643);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 15);
            this.label8.TabIndex = 336;
            this.label8.Text = "Toplam Kayıt:";
            // 
            // LblFazlaCalisma
            // 
            this.LblFazlaCalisma.AutoSize = true;
            this.LblFazlaCalisma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblFazlaCalisma.Location = new System.Drawing.Point(459, 643);
            this.LblFazlaCalisma.Name = "LblFazlaCalisma";
            this.LblFazlaCalisma.Size = new System.Drawing.Size(21, 15);
            this.LblFazlaCalisma.TabIndex = 339;
            this.LblFazlaCalisma.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(299, 643);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 15);
            this.label2.TabIndex = 338;
            this.label2.Text = "Toplam Fazla Çalışma:";
            // 
            // LblIzin
            // 
            this.LblIzin.AutoSize = true;
            this.LblIzin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblIzin.Location = new System.Drawing.Point(842, 643);
            this.LblIzin.Name = "LblIzin";
            this.LblIzin.Size = new System.Drawing.Size(21, 15);
            this.LblIzin.TabIndex = 341;
            this.LblIzin.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(676, 643);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 15);
            this.label4.TabIndex = 340;
            this.label4.Text = "Toplam Hak Edilen İzin:";
            // 
            // FrmFazlaCalismalarim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 675);
            this.Controls.Add(this.LblIzin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblFazlaCalisma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmFazlaCalismalarim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fazla Çalışmalarım";
            this.Load += new System.EventHandler(this.FrmFazlaCalismalarim_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.Label LblFazlaCalisma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblIzin;
        private System.Windows.Forms.Label label4;
    }
}