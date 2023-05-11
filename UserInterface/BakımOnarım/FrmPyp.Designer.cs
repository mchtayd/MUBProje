
namespace UserInterface.BakımOnarım
{
    partial class FrmPyp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPyp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.DtgPYP = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtPypNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSorumluPersonel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbSiparisTuru = new System.Windows.Forms.ComboBox();
            this.BtnOpenFile = new System.Windows.Forms.Button();
            this.CmbHesaplamaNedeni = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnTemizle = new System.Windows.Forms.Button();
            this.BtnSil = new System.Windows.Forms.Button();
            this.BtnGuncelle = new System.Windows.Forms.Button();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgPYP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DtgPYP);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 222);
            this.panel1.TabIndex = 0;
            // 
            // DtgPYP
            // 
            this.DtgPYP.AllowUserToAddRows = false;
            this.DtgPYP.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgPYP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgPYP.AutoGenerateContextFilters = true;
            this.DtgPYP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgPYP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgPYP.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgPYP.DateWithTime = false;
            this.DtgPYP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgPYP.Location = new System.Drawing.Point(0, 0);
            this.DtgPYP.MultiSelect = false;
            this.DtgPYP.Name = "DtgPYP";
            this.DtgPYP.ReadOnly = true;
            this.DtgPYP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgPYP.Size = new System.Drawing.Size(596, 222);
            this.DtgPYP.TabIndex = 4;
            this.DtgPYP.TimeFilter = false;
            this.DtgPYP.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgPYP_CellDoubleClick);
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 244);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 309;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 308;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // TxtPypNo
            // 
            this.TxtPypNo.Location = new System.Drawing.Point(200, 283);
            this.TxtPypNo.Name = "TxtPypNo";
            this.TxtPypNo.Size = new System.Drawing.Size(288, 20);
            this.TxtPypNo.TabIndex = 311;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 310;
            this.label1.Text = "PYP NO:";
            // 
            // TxtSorumluPersonel
            // 
            this.TxtSorumluPersonel.Location = new System.Drawing.Point(200, 311);
            this.TxtSorumluPersonel.Name = "TxtSorumluPersonel";
            this.TxtSorumluPersonel.Size = new System.Drawing.Size(288, 20);
            this.TxtSorumluPersonel.TabIndex = 313;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 13);
            this.label2.TabIndex = 312;
            this.label2.Text = "ASELSAN SORUMLU PERSONEL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 314;
            this.label3.Text = "SİPARİŞ TÜRÜ:";
            // 
            // CmbSiparisTuru
            // 
            this.CmbSiparisTuru.FormattingEnabled = true;
            this.CmbSiparisTuru.Location = new System.Drawing.Point(200, 339);
            this.CmbSiparisTuru.Name = "CmbSiparisTuru";
            this.CmbSiparisTuru.Size = new System.Drawing.Size(249, 21);
            this.CmbSiparisTuru.TabIndex = 315;
            // 
            // BtnOpenFile
            // 
            this.BtnOpenFile.BackColor = System.Drawing.Color.White;
            this.BtnOpenFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpenFile.Image")));
            this.BtnOpenFile.Location = new System.Drawing.Point(454, 335);
            this.BtnOpenFile.Name = "BtnOpenFile";
            this.BtnOpenFile.Size = new System.Drawing.Size(34, 29);
            this.BtnOpenFile.TabIndex = 316;
            this.BtnOpenFile.UseVisualStyleBackColor = false;
            // 
            // CmbHesaplamaNedeni
            // 
            this.CmbHesaplamaNedeni.FormattingEnabled = true;
            this.CmbHesaplamaNedeni.Location = new System.Drawing.Point(200, 366);
            this.CmbHesaplamaNedeni.Name = "CmbHesaplamaNedeni";
            this.CmbHesaplamaNedeni.Size = new System.Drawing.Size(249, 21);
            this.CmbHesaplamaNedeni.TabIndex = 320;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 319;
            this.label6.Text = "HESAPLAMA NEDENİ:";
            // 
            // BtnTemizle
            // 
            this.BtnTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTemizle.Location = new System.Drawing.Point(424, 411);
            this.BtnTemizle.Name = "BtnTemizle";
            this.BtnTemizle.Size = new System.Drawing.Size(115, 50);
            this.BtnTemizle.TabIndex = 324;
            this.BtnTemizle.Text = "TEMİZLE";
            this.BtnTemizle.UseVisualStyleBackColor = true;
            this.BtnTemizle.Click += new System.EventHandler(this.BtnTemizle_Click);
            // 
            // BtnSil
            // 
            this.BtnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Location = new System.Drawing.Point(303, 411);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(115, 50);
            this.BtnSil.TabIndex = 323;
            this.BtnSil.Text = "SİL";
            this.BtnSil.UseVisualStyleBackColor = true;
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Location = new System.Drawing.Point(182, 411);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(115, 50);
            this.BtnGuncelle.TabIndex = 322;
            this.BtnGuncelle.Text = "GÜNCELLE";
            this.BtnGuncelle.UseVisualStyleBackColor = true;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Location = new System.Drawing.Point(61, 411);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(115, 50);
            this.BtnKaydet.TabIndex = 321;
            this.BtnKaydet.Text = "KAYDET";
            this.BtnKaydet.UseVisualStyleBackColor = true;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // FrmPyp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 482);
            this.Controls.Add(this.BtnTemizle);
            this.Controls.Add(this.BtnSil);
            this.Controls.Add(this.BtnGuncelle);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.CmbHesaplamaNedeni);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnOpenFile);
            this.Controls.Add(this.CmbSiparisTuru);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtSorumluPersonel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtPypNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPyp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PYP";
            this.Load += new System.EventHandler(this.FrmPyp_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgPYP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ADGV.AdvancedDataGridView DtgPYP;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtPypNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSorumluPersonel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbSiparisTuru;
        private System.Windows.Forms.Button BtnOpenFile;
        private System.Windows.Forms.ComboBox CmbHesaplamaNedeni;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnTemizle;
        private System.Windows.Forms.Button BtnSil;
        private System.Windows.Forms.Button BtnGuncelle;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.BindingSource dataBinder;
    }
}