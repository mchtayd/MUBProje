﻿
namespace UserInterface.RAPORLAMALAR
{
    partial class FrmSatRaporu
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
            this.CmbFaturaFirma = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgRaporList = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnRaporOlustur = new System.Windows.Forms.Button();
            this.CmbDonem = new System.Windows.Forms.ComboBox();
            this.label52 = new System.Windows.Forms.Label();
            this.ToplamTutar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgRaporList)).BeginInit();
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
            this.panel1.TabIndex = 320;
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
            // CmbFaturaFirma
            // 
            this.CmbFaturaFirma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFaturaFirma.FormattingEnabled = true;
            this.CmbFaturaFirma.Items.AddRange(new object[] {
            "ASELSAN",
            "BAŞARAN"});
            this.CmbFaturaFirma.Location = new System.Drawing.Point(128, 43);
            this.CmbFaturaFirma.Name = "CmbFaturaFirma";
            this.CmbFaturaFirma.Size = new System.Drawing.Size(126, 21);
            this.CmbFaturaFirma.TabIndex = 328;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 327;
            this.label6.Text = "FİRMA BİLGİSİ:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgRaporList);
            this.groupBox1.Location = new System.Drawing.Point(0, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1623, 683);
            this.groupBox1.TabIndex = 329;
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
            this.DtgRaporList.Size = new System.Drawing.Size(1617, 664);
            this.DtgRaporList.TabIndex = 2;
            this.DtgRaporList.TimeFilter = false;
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(110, 833);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 331;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(10, 833);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 330;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // BtnRaporOlustur
            // 
            this.BtnRaporOlustur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRaporOlustur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnRaporOlustur.Location = new System.Drawing.Point(12, 82);
            this.BtnRaporOlustur.Name = "BtnRaporOlustur";
            this.BtnRaporOlustur.Size = new System.Drawing.Size(157, 45);
            this.BtnRaporOlustur.TabIndex = 332;
            this.BtnRaporOlustur.Text = "RAPOR OLUŞTUR";
            this.BtnRaporOlustur.UseVisualStyleBackColor = true;
            this.BtnRaporOlustur.Click += new System.EventHandler(this.BtnRaporOlustur_Click);
            // 
            // CmbDonem
            // 
            this.CmbDonem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDonem.FormattingEnabled = true;
            this.CmbDonem.Items.AddRange(new object[] {
            "OCAK",
            "ŞUBAT",
            "MART",
            "NİSAN",
            "MAYIS",
            "HAZİRAN",
            "TEMMUZ",
            "AĞUSTOS",
            "EYLÜL",
            "EKİM",
            "KASIM",
            "ARALIK"});
            this.CmbDonem.Location = new System.Drawing.Point(347, 43);
            this.CmbDonem.Name = "CmbDonem";
            this.CmbDonem.Size = new System.Drawing.Size(126, 21);
            this.CmbDonem.TabIndex = 334;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(291, 47);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(50, 13);
            this.label52.TabIndex = 333;
            this.label52.Text = "DÖNEM:";
            // 
            // ToplamTutar
            // 
            this.ToplamTutar.AutoSize = true;
            this.ToplamTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ToplamTutar.Location = new System.Drawing.Point(308, 833);
            this.ToplamTutar.Name = "ToplamTutar";
            this.ToplamTutar.Size = new System.Drawing.Size(21, 15);
            this.ToplamTutar.TabIndex = 336;
            this.ToplamTutar.Text = "00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(206, 833);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 335;
            this.label2.Text = "Toplam Tutar:";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(13, 862);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 45);
            this.button1.TabIndex = 337;
            this.button1.Text = "KAYDET";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmSatRaporu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1635, 924);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ToplamTutar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbDonem);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.BtnRaporOlustur);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmbFaturaFirma);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSatRaporu";
            this.Text = "FrmSatRaporu";
            this.Load += new System.EventHandler(this.FrmSatRaporu_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgRaporList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ComboBox CmbFaturaFirma;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgRaporList;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnRaporOlustur;
        private System.Windows.Forms.ComboBox CmbDonem;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label ToplamTutar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.Button button1;
    }
}