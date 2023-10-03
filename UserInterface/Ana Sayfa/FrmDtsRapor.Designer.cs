namespace UserInterface.Ana_Sayfa
{
    partial class FrmDtsRapor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDtsRapor));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbPersonel = new System.Windows.Forms.ComboBox();
            this.BtnSorgula = new System.Windows.Forms.Button();
            this.DtBitTarihi = new System.Windows.Forms.DateTimePicker();
            this.DtBasTarihi = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.BtnDisaAktar = new System.Windows.Forms.Button();
            this.BtnTumunuGor = new System.Windows.Forms.Button();
            this.TxtIslem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1555, 27);
            this.panel1.TabIndex = 315;
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
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(12, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1531, 780);
            this.groupBox1.TabIndex = 316;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LOG KAYITLARI";
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AllowUserToOrderColumns = true;
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
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgList.Size = new System.Drawing.Size(1525, 761);
            this.DtgList.TabIndex = 2;
            this.DtgList.TimeFilter = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(23, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 317;
            this.label1.Text = "Personel:";
            // 
            // CmbPersonel
            // 
            this.CmbPersonel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPersonel.FormattingEnabled = true;
            this.CmbPersonel.Location = new System.Drawing.Point(97, 48);
            this.CmbPersonel.Name = "CmbPersonel";
            this.CmbPersonel.Size = new System.Drawing.Size(262, 21);
            this.CmbPersonel.TabIndex = 318;
            // 
            // BtnSorgula
            // 
            this.BtnSorgula.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnSorgula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSorgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSorgula.Image = ((System.Drawing.Image)(resources.GetObject("BtnSorgula.Image")));
            this.BtnSorgula.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSorgula.Location = new System.Drawing.Point(650, 35);
            this.BtnSorgula.Name = "BtnSorgula";
            this.BtnSorgula.Size = new System.Drawing.Size(127, 51);
            this.BtnSorgula.TabIndex = 353;
            this.BtnSorgula.Text = "   SORGULA";
            this.BtnSorgula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSorgula.UseVisualStyleBackColor = false;
            this.BtnSorgula.Click += new System.EventHandler(this.BtnSorgula_Click);
            // 
            // DtBitTarihi
            // 
            this.DtBitTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtBitTarihi.Location = new System.Drawing.Point(479, 65);
            this.DtBitTarihi.Name = "DtBitTarihi";
            this.DtBitTarihi.Size = new System.Drawing.Size(165, 20);
            this.DtBitTarihi.TabIndex = 352;
            // 
            // DtBasTarihi
            // 
            this.DtBasTarihi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtBasTarihi.Location = new System.Drawing.Point(479, 39);
            this.DtBasTarihi.Name = "DtBasTarihi";
            this.DtBasTarihi.Size = new System.Drawing.Size(165, 20);
            this.DtBasTarihi.TabIndex = 351;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 350;
            this.label3.Text = "BİTİŞ TARİHİ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(374, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 349;
            this.label5.Text = "BAŞLAMA TARİHİ:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(12, 879);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 354;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(112, 879);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 355;
            this.TxtTop.Text = "00";
            // 
            // BtnDisaAktar
            // 
            this.BtnDisaAktar.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnDisaAktar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDisaAktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDisaAktar.Image = ((System.Drawing.Image)(resources.GetObject("BtnDisaAktar.Image")));
            this.BtnDisaAktar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDisaAktar.Location = new System.Drawing.Point(916, 35);
            this.BtnDisaAktar.Name = "BtnDisaAktar";
            this.BtnDisaAktar.Size = new System.Drawing.Size(130, 51);
            this.BtnDisaAktar.TabIndex = 542;
            this.BtnDisaAktar.Text = " DIŞA AKTAR";
            this.BtnDisaAktar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDisaAktar.UseVisualStyleBackColor = false;
            // 
            // BtnTumunuGor
            // 
            this.BtnTumunuGor.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnTumunuGor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTumunuGor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTumunuGor.Image = ((System.Drawing.Image)(resources.GetObject("BtnTumunuGor.Image")));
            this.BtnTumunuGor.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTumunuGor.Location = new System.Drawing.Point(783, 35);
            this.BtnTumunuGor.Name = "BtnTumunuGor";
            this.BtnTumunuGor.Size = new System.Drawing.Size(127, 51);
            this.BtnTumunuGor.TabIndex = 543;
            this.BtnTumunuGor.Text = "   TÜMÜNÜ \r\n       GÖR";
            this.BtnTumunuGor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTumunuGor.UseVisualStyleBackColor = false;
            // 
            // TxtIslem
            // 
            this.TxtIslem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtIslem.Location = new System.Drawing.Point(1085, 61);
            this.TxtIslem.Name = "TxtIslem";
            this.TxtIslem.Size = new System.Drawing.Size(291, 21);
            this.TxtIslem.TabIndex = 544;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(1082, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 15);
            this.label2.TabIndex = 545;
            this.label2.Text = "Anahtar Kelime ile Arama:";
            // 
            // FrmDtsRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 909);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtIslem);
            this.Controls.Add(this.BtnTumunuGor);
            this.Controls.Add(this.BtnDisaAktar);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.BtnSorgula);
            this.Controls.Add(this.DtBitTarihi);
            this.Controls.Add(this.DtBasTarihi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbPersonel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDtsRapor";
            this.Text = "FrmDtsRapor";
            this.Load += new System.EventHandler(this.FrmDtsRapor_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbPersonel;
        private System.Windows.Forms.Button BtnSorgula;
        private System.Windows.Forms.DateTimePicker DtBitTarihi;
        private System.Windows.Forms.DateTimePicker DtBasTarihi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Button BtnDisaAktar;
        private System.Windows.Forms.Button BtnTumunuGor;
        private System.Windows.Forms.TextBox TxtIslem;
        private System.Windows.Forms.Label label2;
    }
}