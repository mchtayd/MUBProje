
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgBolgeler = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtEkipmanSayisi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DtgGarantiPaketi = new ADGV.AdvancedDataGridView();
            this.DtgEkipman = new ADGV.AdvancedDataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolgeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgGarantiPaketi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEkipman)).BeginInit();
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 526);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1439, 306);
            this.tabControl1.TabIndex = 316;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DtgGarantiPaketi);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1431, 280);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "GARANTİ PAKETİ BİLGİLERİ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DtgEkipman);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1431, 280);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "EKİPMAN BİLGİLERİ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DtgGarantiPaketi
            // 
            this.DtgGarantiPaketi.AllowUserToAddRows = false;
            this.DtgGarantiPaketi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgGarantiPaketi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgGarantiPaketi.AutoGenerateContextFilters = true;
            this.DtgGarantiPaketi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgGarantiPaketi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgGarantiPaketi.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgGarantiPaketi.DateWithTime = false;
            this.DtgGarantiPaketi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgGarantiPaketi.Location = new System.Drawing.Point(3, 3);
            this.DtgGarantiPaketi.MultiSelect = false;
            this.DtgGarantiPaketi.Name = "DtgGarantiPaketi";
            this.DtgGarantiPaketi.ReadOnly = true;
            this.DtgGarantiPaketi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgGarantiPaketi.Size = new System.Drawing.Size(1425, 274);
            this.DtgGarantiPaketi.TabIndex = 6;
            this.DtgGarantiPaketi.TimeFilter = false;
            // 
            // DtgEkipman
            // 
            this.DtgEkipman.AllowUserToAddRows = false;
            this.DtgEkipman.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgEkipman.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DtgEkipman.AutoGenerateContextFilters = true;
            this.DtgEkipman.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgEkipman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgEkipman.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgEkipman.DateWithTime = false;
            this.DtgEkipman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgEkipman.Location = new System.Drawing.Point(3, 3);
            this.DtgEkipman.MultiSelect = false;
            this.DtgEkipman.Name = "DtgEkipman";
            this.DtgEkipman.ReadOnly = true;
            this.DtgEkipman.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgEkipman.Size = new System.Drawing.Size(1425, 274);
            this.DtgEkipman.TabIndex = 7;
            this.DtgEkipman.TimeFilter = false;
            // 
            // FrmBolgeKayitIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 872);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.TxtEkipmanSayisi);
            this.Controls.Add(this.label2);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgGarantiPaketi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgEkipman)).EndInit();
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
        private System.Windows.Forms.Label TxtEkipmanSayisi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ADGV.AdvancedDataGridView DtgGarantiPaketi;
        private System.Windows.Forms.TabPage tabPage2;
        private ADGV.AdvancedDataGridView DtgEkipman;
    }
}