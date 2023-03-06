
namespace UserInterface.Yerleskeler
{
    partial class FrmYerleskeGiderKayitIzleme
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgYerleskeSat = new ADGV.AdvancedDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgYerkeskeler = new ADGV.AdvancedDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.LblToplamKayit = new System.Windows.Forms.Label();
            this.LblTop = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.GiderTuru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Donem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgYerleskeSat)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgYerkeskeler)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgYerleskeSat);
            this.groupBox2.Location = new System.Drawing.Point(12, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 501);
            this.groupBox2.TabIndex = 309;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ABONE BİLGİLERİ";
            // 
            // DtgYerleskeSat
            // 
            this.DtgYerleskeSat.AllowUserToAddRows = false;
            this.DtgYerleskeSat.AllowUserToDeleteRows = false;
            this.DtgYerleskeSat.AutoGenerateContextFilters = true;
            this.DtgYerleskeSat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgYerleskeSat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgYerleskeSat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GiderTuru,
            this.Donem,
            this.Tutar});
            this.DtgYerleskeSat.DateWithTime = false;
            this.DtgYerleskeSat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgYerleskeSat.Location = new System.Drawing.Point(3, 16);
            this.DtgYerleskeSat.Name = "DtgYerleskeSat";
            this.DtgYerleskeSat.ReadOnly = true;
            this.DtgYerleskeSat.Size = new System.Drawing.Size(423, 482);
            this.DtgYerleskeSat.TabIndex = 0;
            this.DtgYerleskeSat.TimeFilter = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgYerkeskeler);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1435, 217);
            this.groupBox1.TabIndex = 310;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "YERLEŞKE BİLGİLERİ";
            // 
            // DtgYerkeskeler
            // 
            this.DtgYerkeskeler.AllowUserToAddRows = false;
            this.DtgYerkeskeler.AllowUserToDeleteRows = false;
            this.DtgYerkeskeler.AutoGenerateContextFilters = true;
            this.DtgYerkeskeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgYerkeskeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgYerkeskeler.DateWithTime = false;
            this.DtgYerkeskeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgYerkeskeler.Location = new System.Drawing.Point(3, 16);
            this.DtgYerkeskeler.Name = "DtgYerkeskeler";
            this.DtgYerkeskeler.ReadOnly = true;
            this.DtgYerkeskeler.Size = new System.Drawing.Size(1429, 198);
            this.DtgYerkeskeler.TabIndex = 0;
            this.DtgYerkeskeler.TimeFilter = false;
            this.DtgYerkeskeler.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgYerkeskeler_CellMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 783);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 311;
            this.label1.Text = "Toplam Kayıt:";
            // 
            // LblToplamKayit
            // 
            this.LblToplamKayit.AutoSize = true;
            this.LblToplamKayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblToplamKayit.Location = new System.Drawing.Point(112, 783);
            this.LblToplamKayit.Name = "LblToplamKayit";
            this.LblToplamKayit.Size = new System.Drawing.Size(21, 15);
            this.LblToplamKayit.TabIndex = 312;
            this.LblToplamKayit.Text = "00";
            // 
            // LblTop
            // 
            this.LblTop.AutoSize = true;
            this.LblTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTop.Location = new System.Drawing.Point(309, 783);
            this.LblTop.Name = "LblTop";
            this.LblTop.Size = new System.Drawing.Size(21, 15);
            this.LblTop.TabIndex = 314;
            this.LblTop.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(207, 783);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 313;
            this.label4.Text = "Toplam Tutar:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1453, 27);
            this.panel1.TabIndex = 319;
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
            // GiderTuru
            // 
            this.GiderTuru.HeaderText = "GİDER TÜRÜ";
            this.GiderTuru.MinimumWidth = 22;
            this.GiderTuru.Name = "GiderTuru";
            this.GiderTuru.ReadOnly = true;
            this.GiderTuru.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Donem
            // 
            this.Donem.HeaderText = "DÖNEM";
            this.Donem.MinimumWidth = 22;
            this.Donem.Name = "Donem";
            this.Donem.ReadOnly = true;
            this.Donem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Donem.Width = 72;
            // 
            // Tutar
            // 
            this.Tutar.HeaderText = "TUTAR";
            this.Tutar.MinimumWidth = 22;
            this.Tutar.Name = "Tutar";
            this.Tutar.ReadOnly = true;
            this.Tutar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Tutar.Width = 69;
            // 
            // FrmYerleskeGiderKayitIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 817);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblToplamKayit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmYerleskeGiderKayitIzleme";
            this.Text = "FrmYerleskeGiderKayitIzleme";
            this.Load += new System.EventHandler(this.FrmYerleskeGiderKayitIzleme_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgYerleskeSat)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgYerkeskeler)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private ADGV.AdvancedDataGridView DtgYerleskeSat;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgYerkeskeler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblToplamKayit;
        private System.Windows.Forms.Label LblTop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiderTuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn Donem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tutar;
    }
}