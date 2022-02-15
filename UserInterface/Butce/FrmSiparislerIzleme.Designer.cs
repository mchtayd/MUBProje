
namespace UserInterface.Butce
{
    partial class FrmSiparislerIzleme
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.DtgMevcutKadro = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgPersoneller = new ADGV.AdvancedDataGridView();
            this.AdiSoyadi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unvani = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bolumu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Durum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgAraclar = new ADGV.AdvancedDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LblToplamlar = new System.Windows.Forms.Label();
            this.LblTop = new System.Windows.Forms.Label();
            this.binderData = new System.Windows.Forms.BindingSource(this.components);
            this.LblPersonelTop = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblAracTop = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.binderDataArac = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMevcutKadro)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgPersoneller)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgAraclar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binderData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binderDataArac)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.DtgMevcutKadro);
            this.groupBox19.Location = new System.Drawing.Point(26, 49);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(1410, 345);
            this.groupBox19.TabIndex = 39;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "SİPARİŞLER";
            // 
            // DtgMevcutKadro
            // 
            this.DtgMevcutKadro.AllowUserToAddRows = false;
            this.DtgMevcutKadro.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgMevcutKadro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgMevcutKadro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgMevcutKadro.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgMevcutKadro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgMevcutKadro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgMevcutKadro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DtgMevcutKadro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgMevcutKadro.Location = new System.Drawing.Point(3, 16);
            this.DtgMevcutKadro.MultiSelect = false;
            this.DtgMevcutKadro.Name = "DtgMevcutKadro";
            this.DtgMevcutKadro.ReadOnly = true;
            this.DtgMevcutKadro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgMevcutKadro.Size = new System.Drawing.Size(1404, 326);
            this.DtgMevcutKadro.TabIndex = 4;
            this.DtgMevcutKadro.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgMevcutKadro_CellMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgPersoneller);
            this.groupBox1.Location = new System.Drawing.Point(26, 433);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 347);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PERSONELLER";
            // 
            // DtgPersoneller
            // 
            this.DtgPersoneller.AllowUserToAddRows = false;
            this.DtgPersoneller.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgPersoneller.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DtgPersoneller.AutoGenerateContextFilters = true;
            this.DtgPersoneller.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgPersoneller.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtgPersoneller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgPersoneller.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AdiSoyadi,
            this.Unvani,
            this.Bolumu,
            this.Durum});
            this.DtgPersoneller.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgPersoneller.DateWithTime = false;
            this.DtgPersoneller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgPersoneller.Location = new System.Drawing.Point(3, 16);
            this.DtgPersoneller.Name = "DtgPersoneller";
            this.DtgPersoneller.ReadOnly = true;
            this.DtgPersoneller.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgPersoneller.Size = new System.Drawing.Size(794, 328);
            this.DtgPersoneller.TabIndex = 3;
            this.DtgPersoneller.TimeFilter = false;
            this.DtgPersoneller.SortStringChanged += new System.EventHandler(this.DtgPersoneller_SortStringChanged);
            this.DtgPersoneller.FilterStringChanged += new System.EventHandler(this.DtgPersoneller_FilterStringChanged);
            // 
            // AdiSoyadi
            // 
            this.AdiSoyadi.HeaderText = "ADI SOYADI";
            this.AdiSoyadi.MinimumWidth = 22;
            this.AdiSoyadi.Name = "AdiSoyadi";
            this.AdiSoyadi.ReadOnly = true;
            this.AdiSoyadi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.AdiSoyadi.Width = 93;
            // 
            // Unvani
            // 
            this.Unvani.HeaderText = "ÜNVANI";
            this.Unvani.MinimumWidth = 22;
            this.Unvani.Name = "Unvani";
            this.Unvani.ReadOnly = true;
            this.Unvani.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Unvani.Width = 73;
            // 
            // Bolumu
            // 
            this.Bolumu.HeaderText = "BÖLÜMÜ";
            this.Bolumu.MinimumWidth = 22;
            this.Bolumu.Name = "Bolumu";
            this.Bolumu.ReadOnly = true;
            this.Bolumu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Bolumu.Width = 78;
            // 
            // Durum
            // 
            this.Durum.HeaderText = "DURUMU";
            this.Durum.MinimumWidth = 22;
            this.Durum.Name = "Durum";
            this.Durum.ReadOnly = true;
            this.Durum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Durum.Width = 81;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgAraclar);
            this.groupBox2.Location = new System.Drawing.Point(832, 433);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(601, 347);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ARAÇLAR";
            // 
            // DtgAraclar
            // 
            this.DtgAraclar.AllowUserToAddRows = false;
            this.DtgAraclar.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgAraclar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DtgAraclar.AutoGenerateContextFilters = true;
            this.DtgAraclar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgAraclar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtgAraclar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgAraclar.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgAraclar.DateWithTime = false;
            this.DtgAraclar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgAraclar.Location = new System.Drawing.Point(3, 16);
            this.DtgAraclar.Name = "DtgAraclar";
            this.DtgAraclar.ReadOnly = true;
            this.DtgAraclar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgAraclar.Size = new System.Drawing.Size(595, 328);
            this.DtgAraclar.TabIndex = 4;
            this.DtgAraclar.TimeFilter = false;
            this.DtgAraclar.SortStringChanged += new System.EventHandler(this.DtgAraclar_SortStringChanged);
            this.DtgAraclar.FilterStringChanged += new System.EventHandler(this.DtgAraclar_FilterStringChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1448, 27);
            this.panel1.TabIndex = 308;
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
            // LblToplamlar
            // 
            this.LblToplamlar.AutoSize = true;
            this.LblToplamlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblToplamlar.Location = new System.Drawing.Point(26, 403);
            this.LblToplamlar.Name = "LblToplamlar";
            this.LblToplamlar.Size = new System.Drawing.Size(84, 13);
            this.LblToplamlar.TabIndex = 309;
            this.LblToplamlar.Text = "Toplam Kayıt:";
            // 
            // LblTop
            // 
            this.LblTop.AutoSize = true;
            this.LblTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTop.Location = new System.Drawing.Point(116, 403);
            this.LblTop.Name = "LblTop";
            this.LblTop.Size = new System.Drawing.Size(19, 13);
            this.LblTop.TabIndex = 310;
            this.LblTop.Text = "00";
            // 
            // LblPersonelTop
            // 
            this.LblPersonelTop.AutoSize = true;
            this.LblPersonelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPersonelTop.Location = new System.Drawing.Point(116, 783);
            this.LblPersonelTop.Name = "LblPersonelTop";
            this.LblPersonelTop.Size = new System.Drawing.Size(19, 13);
            this.LblPersonelTop.TabIndex = 312;
            this.LblPersonelTop.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(26, 783);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 311;
            this.label2.Text = "Toplam Kayıt:";
            // 
            // LblAracTop
            // 
            this.LblAracTop.AutoSize = true;
            this.LblAracTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAracTop.Location = new System.Drawing.Point(922, 783);
            this.LblAracTop.Name = "LblAracTop";
            this.LblAracTop.Size = new System.Drawing.Size(19, 13);
            this.LblAracTop.TabIndex = 314;
            this.LblAracTop.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(832, 783);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 313;
            this.label4.Text = "Toplam Kayıt:";
            // 
            // FrmSiparislerIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 819);
            this.Controls.Add(this.LblAracTop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblPersonelTop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblTop);
            this.Controls.Add(this.LblToplamlar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox19);
            this.Name = "FrmSiparislerIzleme";
            this.Text = "FrmSiparislerIzleme";
            this.Load += new System.EventHandler(this.FrmSiparislerIzleme_Load);
            this.groupBox19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgMevcutKadro)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgPersoneller)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgAraclar)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binderData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binderDataArac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.DataGridView DtgMevcutKadro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label LblToplamlar;
        private System.Windows.Forms.Label LblTop;
        private ADGV.AdvancedDataGridView DtgPersoneller;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdiSoyadi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unvani;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bolumu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Durum;
        private System.Windows.Forms.BindingSource binderData;
        private System.Windows.Forms.Label LblPersonelTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblAracTop;
        private System.Windows.Forms.Label label4;
        private ADGV.AdvancedDataGridView DtgAraclar;
        private System.Windows.Forms.BindingSource binderDataArac;
    }
}