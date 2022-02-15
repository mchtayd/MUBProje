
namespace UserInterface.Butce
{
    partial class FrmKasaIzlemecs
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgTamamlananSatlar = new ADGV.AdvancedDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblGenelTop = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblSatTop = new System.Windows.Forms.Label();
            this.TxtTopKayitSat = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LblGelir = new System.Windows.Forms.Label();
            this.LblGider = new System.Windows.Forms.Label();
            this.LblKalan = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.dataBinder2 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTamamlananSatlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DtgList);
            this.groupBox3.Location = new System.Drawing.Point(12, 37);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1014, 200);
            this.groupBox3.TabIndex = 336;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "KASA GELİRLER";
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
            this.DtgList.Size = new System.Drawing.Size(1008, 181);
            this.DtgList.TabIndex = 4;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1460, 31);
            this.panel1.TabIndex = 337;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnCancel.Location = new System.Drawing.Point(14, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(41, 27);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgTamamlananSatlar);
            this.groupBox1.Location = new System.Drawing.Point(14, 373);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1009, 394);
            this.groupBox1.TabIndex = 337;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "KASA GİDERLER";
            // 
            // DtgTamamlananSatlar
            // 
            this.DtgTamamlananSatlar.AllowUserToAddRows = false;
            this.DtgTamamlananSatlar.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgTamamlananSatlar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgTamamlananSatlar.AutoGenerateContextFilters = true;
            this.DtgTamamlananSatlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgTamamlananSatlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgTamamlananSatlar.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgTamamlananSatlar.DateWithTime = false;
            this.DtgTamamlananSatlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgTamamlananSatlar.Location = new System.Drawing.Point(3, 16);
            this.DtgTamamlananSatlar.Name = "DtgTamamlananSatlar";
            this.DtgTamamlananSatlar.ReadOnly = true;
            this.DtgTamamlananSatlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgTamamlananSatlar.Size = new System.Drawing.Size(1003, 375);
            this.DtgTamamlananSatlar.TabIndex = 5;
            this.DtgTamamlananSatlar.TimeFilter = false;
            this.DtgTamamlananSatlar.SortStringChanged += new System.EventHandler(this.DtgTamamlananSatlar_SortStringChanged);
            this.DtgTamamlananSatlar.FilterStringChanged += new System.EventHandler(this.DtgTamamlananSatlar_FilterStringChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1042, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 13);
            this.label1.TabIndex = 338;
            this.label1.Text = "gelen kayıtlara göre seçilen döneme ait giderler gelecek";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(217, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 356;
            this.label3.Text = "Genel Toplam:";
            // 
            // LblGenelTop
            // 
            this.LblGenelTop.AutoSize = true;
            this.LblGenelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblGenelTop.Location = new System.Drawing.Point(324, 240);
            this.LblGenelTop.Name = "LblGenelTop";
            this.LblGenelTop.Size = new System.Drawing.Size(34, 15);
            this.LblGenelTop.TabIndex = 357;
            this.LblGenelTop.Text = "00  ₺";
            // 
            // TxtTop
            // 
            this.TxtTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(115, 240);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 355;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(15, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 354;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(217, 781);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 360;
            this.label2.Text = "Genel Toplam:";
            // 
            // LblSatTop
            // 
            this.LblSatTop.AutoSize = true;
            this.LblSatTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblSatTop.Location = new System.Drawing.Point(324, 781);
            this.LblSatTop.Name = "LblSatTop";
            this.LblSatTop.Size = new System.Drawing.Size(34, 15);
            this.LblSatTop.TabIndex = 361;
            this.LblSatTop.Text = "00  ₺";
            // 
            // TxtTopKayitSat
            // 
            this.TxtTopKayitSat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtTopKayitSat.AutoSize = true;
            this.TxtTopKayitSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTopKayitSat.Location = new System.Drawing.Point(115, 781);
            this.TxtTopKayitSat.Name = "TxtTopKayitSat";
            this.TxtTopKayitSat.Size = new System.Drawing.Size(21, 15);
            this.TxtTopKayitSat.TabIndex = 359;
            this.TxtTopKayitSat.Text = "00";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(15, 781);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 15);
            this.label7.TabIndex = 358;
            this.label7.Text = "Toplam Kayıt:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1066, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 363;
            this.label9.Text = "Kasa Gelir:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1062, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 364;
            this.label10.Text = "Kasa Gider:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1060, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 365;
            this.label11.Text = "Kasa Kalan:";
            // 
            // LblGelir
            // 
            this.LblGelir.AutoSize = true;
            this.LblGelir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblGelir.Location = new System.Drawing.Point(1130, 71);
            this.LblGelir.Name = "LblGelir";
            this.LblGelir.Size = new System.Drawing.Size(34, 15);
            this.LblGelir.TabIndex = 368;
            this.LblGelir.Text = "00  ₺";
            // 
            // LblGider
            // 
            this.LblGider.AutoSize = true;
            this.LblGider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblGider.Location = new System.Drawing.Point(1130, 102);
            this.LblGider.Name = "LblGider";
            this.LblGider.Size = new System.Drawing.Size(34, 15);
            this.LblGider.TabIndex = 369;
            this.LblGider.Text = "00  ₺";
            // 
            // LblKalan
            // 
            this.LblKalan.AutoSize = true;
            this.LblKalan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblKalan.Location = new System.Drawing.Point(1130, 133);
            this.LblKalan.Name = "LblKalan";
            this.LblKalan.Size = new System.Drawing.Size(34, 15);
            this.LblKalan.TabIndex = 370;
            this.LblKalan.Text = "00  ₺";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.webBrowser2);
            this.groupBox7.Location = new System.Drawing.Point(18, 264);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(626, 103);
            this.groupBox7.TabIndex = 372;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Ekler";
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(3, 16);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(620, 84);
            this.webBrowser2.TabIndex = 0;
            // 
            // FrmKasaIzlemecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 814);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.LblKalan);
            this.Controls.Add(this.LblGider);
            this.Controls.Add(this.LblGelir);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblSatTop);
            this.Controls.Add(this.TxtTopKayitSat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblGenelTop);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Name = "FrmKasaIzlemecs";
            this.Text = "FrmKasaIzlemecs";
            this.Load += new System.EventHandler(this.FrmKasaIzlemecs_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgTamamlananSatlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblGenelTop;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblSatTop;
        private System.Windows.Forms.Label TxtTopKayitSat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LblGelir;
        private System.Windows.Forms.Label LblGider;
        private System.Windows.Forms.Label LblKalan;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.BindingSource dataBinder2;
        private ADGV.AdvancedDataGridView DtgTamamlananSatlar;
    }
}