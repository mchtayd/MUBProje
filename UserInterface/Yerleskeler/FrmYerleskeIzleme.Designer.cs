
namespace UserInterface.Yerleskeler
{
    partial class FrmYerleskeIzleme
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgYerleskeler = new ADGV.AdvancedDataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgAbonelikler = new ADGV.AdvancedDataGridView();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTopAbonelikler = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.dataBinder2 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgYerleskeler)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgAbonelikler)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1459, 31);
            this.panel1.TabIndex = 306;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnCancel.Location = new System.Drawing.Point(12, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(41, 27);
            this.BtnCancel.TabIndex = 19;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgYerleskeler);
            this.groupBox1.Location = new System.Drawing.Point(12, 352);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1435, 263);
            this.groupBox1.TabIndex = 307;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ABONE BİLGİLERİ";
            // 
            // DtgYerleskeler
            // 
            this.DtgYerleskeler.AllowUserToAddRows = false;
            this.DtgYerleskeler.AllowUserToDeleteRows = false;
            this.DtgYerleskeler.AutoGenerateContextFilters = true;
            this.DtgYerleskeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgYerleskeler.DateWithTime = false;
            this.DtgYerleskeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgYerleskeler.Location = new System.Drawing.Point(3, 16);
            this.DtgYerleskeler.Name = "DtgYerleskeler";
            this.DtgYerleskeler.ReadOnly = true;
            this.DtgYerleskeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgYerleskeler.Size = new System.Drawing.Size(1429, 244);
            this.DtgYerleskeler.TabIndex = 0;
            this.DtgYerleskeler.TimeFilter = false;
            this.DtgYerleskeler.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgYerleskeler_CellMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgAbonelikler);
            this.groupBox2.Location = new System.Drawing.Point(12, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1435, 263);
            this.groupBox2.TabIndex = 308;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "KİRA BİLGİLERİ";
            // 
            // DtgAbonelikler
            // 
            this.DtgAbonelikler.AllowUserToAddRows = false;
            this.DtgAbonelikler.AllowUserToDeleteRows = false;
            this.DtgAbonelikler.AutoGenerateContextFilters = true;
            this.DtgAbonelikler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgAbonelikler.DateWithTime = false;
            this.DtgAbonelikler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgAbonelikler.Location = new System.Drawing.Point(3, 16);
            this.DtgAbonelikler.Name = "DtgAbonelikler";
            this.DtgAbonelikler.ReadOnly = true;
            this.DtgAbonelikler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgAbonelikler.Size = new System.Drawing.Size(1429, 244);
            this.DtgAbonelikler.TabIndex = 0;
            this.DtgAbonelikler.TimeFilter = false;
            this.DtgAbonelikler.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgAbonelikler_CellMouseClick);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(12, 625);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 342;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 625);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 343;
            this.TxtTop.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 344;
            this.label1.Text = "Toplam Kayıt:";
            // 
            // TxtTopAbonelikler
            // 
            this.TxtTopAbonelikler.AutoSize = true;
            this.TxtTopAbonelikler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTopAbonelikler.Location = new System.Drawing.Point(112, 317);
            this.TxtTopAbonelikler.Name = "TxtTopAbonelikler";
            this.TxtTopAbonelikler.Size = new System.Drawing.Size(21, 15);
            this.TxtTopAbonelikler.TabIndex = 345;
            this.TxtTopAbonelikler.Text = "00";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.webBrowser2);
            this.groupBox3.Location = new System.Drawing.Point(151, 631);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(686, 170);
            this.groupBox3.TabIndex = 348;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "EKLER";
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(3, 16);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(680, 151);
            this.webBrowser2.TabIndex = 0;
            // 
            // FrmYerleskeIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1459, 821);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtTopAbonelikler);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmYerleskeIzleme";
            this.Text = "FrmYerleskeIzleme";
            this.Load += new System.EventHandler(this.FrmYerleskeIzleme_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgYerleskeler)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgAbonelikler)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgYerleskeler;
        private System.Windows.Forms.GroupBox groupBox2;
        private ADGV.AdvancedDataGridView DtgAbonelikler;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TxtTopAbonelikler;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.BindingSource dataBinder2;
    }
}