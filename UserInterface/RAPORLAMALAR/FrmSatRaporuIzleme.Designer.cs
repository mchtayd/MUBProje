
namespace UserInterface.RAPORLAMALAR
{
    partial class FrmSatRaporuIzleme
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgRaporList = new ADGV.AdvancedDataGridView();
            this.ToplamTutar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgRaporList)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1635, 27);
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
            this.groupBox1.Controls.Add(this.DtgRaporList);
            this.groupBox1.Location = new System.Drawing.Point(6, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(749, 391);
            this.groupBox1.TabIndex = 330;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RAPOR";
            // 
            // DtgRaporList
            // 
            this.DtgRaporList.AllowUserToAddRows = false;
            this.DtgRaporList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgRaporList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgRaporList.AutoGenerateContextFilters = true;
            this.DtgRaporList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgRaporList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgRaporList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgRaporList.DateWithTime = false;
            this.DtgRaporList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgRaporList.Location = new System.Drawing.Point(3, 16);
            this.DtgRaporList.MultiSelect = false;
            this.DtgRaporList.Name = "DtgRaporList";
            this.DtgRaporList.ReadOnly = true;
            this.DtgRaporList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgRaporList.Size = new System.Drawing.Size(743, 372);
            this.DtgRaporList.TabIndex = 2;
            this.DtgRaporList.TimeFilter = false;
            this.DtgRaporList.SortStringChanged += new System.EventHandler(this.DtgRaporList_SortStringChanged);
            this.DtgRaporList.FilterStringChanged += new System.EventHandler(this.DtgRaporList_FilterStringChanged);
            this.DtgRaporList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgRaporList_CellMouseClick);
            // 
            // ToplamTutar
            // 
            this.ToplamTutar.AutoSize = true;
            this.ToplamTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ToplamTutar.Location = new System.Drawing.Point(310, 439);
            this.ToplamTutar.Name = "ToplamTutar";
            this.ToplamTutar.Size = new System.Drawing.Size(21, 15);
            this.ToplamTutar.TabIndex = 340;
            this.ToplamTutar.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(208, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 339;
            this.label2.Text = "Toplam Tutar:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 439);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 338;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 439);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 337;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser2);
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Location = new System.Drawing.Point(9, 470);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(749, 369);
            this.groupBox2.TabIndex = 409;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EKLER:";
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(3, 16);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(743, 350);
            this.webBrowser2.TabIndex = 407;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(743, 350);
            this.webBrowser1.TabIndex = 406;
            // 
            // FrmSatRaporuIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1635, 924);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ToplamTutar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSatRaporuIzleme";
            this.Text = "FrmSatRaporuIzleme";
            this.Load += new System.EventHandler(this.FrmSatRaporuIzleme_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgRaporList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgRaporList;
        private System.Windows.Forms.Label ToplamTutar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.BindingSource dataBinder;
    }
}