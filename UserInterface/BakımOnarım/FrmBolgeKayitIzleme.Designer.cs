
namespace UserInterface.BakımOnarım
{
    partial class FrmBolgeKayitIzleme
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgBolgeler = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgMalzemeler = new ADGV.AdvancedDataGridView();
            this.TxtEkipmanSayisi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolgeler)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeler)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1479, 27);
            this.panel1.TabIndex = 310;
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
            this.BtnCancel.TabIndex = 19;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgBolgeler);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1452, 446);
            this.groupBox1.TabIndex = 311;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BÖLGELER";
            // 
            // DtgBolgeler
            // 
            this.DtgBolgeler.AllowUserToAddRows = false;
            this.DtgBolgeler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgBolgeler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgBolgeler.AutoGenerateContextFilters = true;
            this.DtgBolgeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgBolgeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgBolgeler.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgBolgeler.DateWithTime = false;
            this.DtgBolgeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgBolgeler.Location = new System.Drawing.Point(3, 16);
            this.DtgBolgeler.MultiSelect = false;
            this.DtgBolgeler.Name = "DtgBolgeler";
            this.DtgBolgeler.ReadOnly = true;
            this.DtgBolgeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgBolgeler.Size = new System.Drawing.Size(1446, 427);
            this.DtgBolgeler.TabIndex = 2;
            this.DtgBolgeler.TimeFilter = false;
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(121, 493);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 313;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(21, 493);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 312;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgMalzemeler);
            this.groupBox2.Location = new System.Drawing.Point(12, 520);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1449, 311);
            this.groupBox2.TabIndex = 313;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EKİPMAN İZLE";
            // 
            // DtgMalzemeler
            // 
            this.DtgMalzemeler.AllowUserToAddRows = false;
            this.DtgMalzemeler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgMalzemeler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgMalzemeler.AutoGenerateContextFilters = true;
            this.DtgMalzemeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgMalzemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgMalzemeler.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgMalzemeler.DateWithTime = false;
            this.DtgMalzemeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgMalzemeler.Location = new System.Drawing.Point(3, 16);
            this.DtgMalzemeler.MultiSelect = false;
            this.DtgMalzemeler.Name = "DtgMalzemeler";
            this.DtgMalzemeler.ReadOnly = true;
            this.DtgMalzemeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgMalzemeler.Size = new System.Drawing.Size(1443, 292);
            this.DtgMalzemeler.TabIndex = 5;
            this.DtgMalzemeler.TimeFilter = false;
            // 
            // TxtEkipmanSayisi
            // 
            this.TxtEkipmanSayisi.AutoSize = true;
            this.TxtEkipmanSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtEkipmanSayisi.Location = new System.Drawing.Point(188, 843);
            this.TxtEkipmanSayisi.Name = "TxtEkipmanSayisi";
            this.TxtEkipmanSayisi.Size = new System.Drawing.Size(21, 15);
            this.TxtEkipmanSayisi.TabIndex = 315;
            this.TxtEkipmanSayisi.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(21, 843);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 15);
            this.label2.TabIndex = 314;
            this.label2.Text = "Toplam Ekipman Sayısı:";
            // 
            // FrmBolgeKayitIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 872);
            this.Controls.Add(this.TxtEkipmanSayisi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBolgeKayitIzleme";
            this.Text = "FrmBolgeKayitIzleme";
            this.Load += new System.EventHandler(this.FrmBolgeKayitIzleme_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolgeler)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgMalzemeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgBolgeler;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private ADGV.AdvancedDataGridView DtgMalzemeler;
        private System.Windows.Forms.Label TxtEkipmanSayisi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource dataBinder;
    }
}