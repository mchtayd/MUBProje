namespace UserInterface.Gecic_Kabul_Ambar
{
    partial class FrmBolgedenIadeGelenMlz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBolgedenIadeGelenMlz));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnTeslimAlSat = new System.Windows.Forms.Button();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.LblDepoAdresi = new System.Windows.Forms.Label();
            this.TxtMalzemeYeri = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbDepoNo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtAciklama = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1503, 27);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1479, 575);
            this.groupBox1.TabIndex = 309;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DEPOYA İADE EDİLECEK MALZEMELER";
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
            this.DtgList.Size = new System.Drawing.Size(1473, 556);
            this.DtgList.TabIndex = 4;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            // 
            // TxtTop
            // 
            this.TxtTop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(115, 611);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 312;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(15, 611);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 311;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // BtnTeslimAlSat
            // 
            this.BtnTeslimAlSat.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnTeslimAlSat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTeslimAlSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTeslimAlSat.Image = ((System.Drawing.Image)(resources.GetObject("BtnTeslimAlSat.Image")));
            this.BtnTeslimAlSat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTeslimAlSat.Location = new System.Drawing.Point(100, 723);
            this.BtnTeslimAlSat.Name = "BtnTeslimAlSat";
            this.BtnTeslimAlSat.Size = new System.Drawing.Size(140, 51);
            this.BtnTeslimAlSat.TabIndex = 363;
            this.BtnTeslimAlSat.Text = "   TESLİM AL";
            this.BtnTeslimAlSat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTeslimAlSat.UseVisualStyleBackColor = false;
            this.BtnTeslimAlSat.Click += new System.EventHandler(this.BtnTeslimAlSat_Click);
            // 
            // LblDepoAdresi
            // 
            this.LblDepoAdresi.AutoSize = true;
            this.LblDepoAdresi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblDepoAdresi.Location = new System.Drawing.Point(97, 668);
            this.LblDepoAdresi.Name = "LblDepoAdresi";
            this.LblDepoAdresi.Size = new System.Drawing.Size(21, 15);
            this.LblDepoAdresi.TabIndex = 377;
            this.LblDepoAdresi.Text = "00";
            // 
            // TxtMalzemeYeri
            // 
            this.TxtMalzemeYeri.FormattingEnabled = true;
            this.TxtMalzemeYeri.Location = new System.Drawing.Point(100, 690);
            this.TxtMalzemeYeri.Name = "TxtMalzemeYeri";
            this.TxtMalzemeYeri.Size = new System.Drawing.Size(224, 21);
            this.TxtMalzemeYeri.TabIndex = 376;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 668);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 375;
            this.label1.Text = "Depo Adresi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 693);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 374;
            this.label3.Text = "Malzeme Yeri:";
            // 
            // CmbDepoNo
            // 
            this.CmbDepoNo.FormattingEnabled = true;
            this.CmbDepoNo.Location = new System.Drawing.Point(100, 641);
            this.CmbDepoNo.Name = "CmbDepoNo";
            this.CmbDepoNo.Size = new System.Drawing.Size(224, 21);
            this.CmbDepoNo.TabIndex = 373;
            this.CmbDepoNo.SelectedIndexChanged += new System.EventHandler(this.CmbDepoNo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 644);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 372;
            this.label7.Text = "Depo No:";
            // 
            // TxtAciklama
            // 
            this.TxtAciklama.Location = new System.Drawing.Point(423, 641);
            this.TxtAciklama.Name = "TxtAciklama";
            this.TxtAciklama.Size = new System.Drawing.Size(433, 70);
            this.TxtAciklama.TabIndex = 378;
            this.TxtAciklama.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 644);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 379;
            this.label2.Text = "Açıklama:";
            // 
            // FrmBolgedenIadeGelenMlz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 797);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtAciklama);
            this.Controls.Add(this.LblDepoAdresi);
            this.Controls.Add(this.TxtMalzemeYeri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbDepoNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnTeslimAlSat);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBolgedenIadeGelenMlz";
            this.Text = "FrmBolgedenIadeGelenMlz";
            this.Load += new System.EventHandler(this.FrmBolgedenIadeGelenMlz_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgList;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnTeslimAlSat;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.Label LblDepoAdresi;
        private System.Windows.Forms.ComboBox TxtMalzemeYeri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbDepoNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox TxtAciklama;
        private System.Windows.Forms.Label label2;
    }
}