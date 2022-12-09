
namespace UserInterface.Ana_Sayfa
{
    partial class FrmBildirimYetki
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBildirimYetki));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbPersonel = new System.Windows.Forms.ComboBox();
            this.CmbBildirimPersonel = new System.Windows.Forms.ComboBox();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.BtnEkle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonelBildirim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnSil = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Personel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bildirim Alacak Personel:";
            // 
            // CmbPersonel
            // 
            this.CmbPersonel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPersonel.FormattingEnabled = true;
            this.CmbPersonel.Location = new System.Drawing.Point(171, 26);
            this.CmbPersonel.Name = "CmbPersonel";
            this.CmbPersonel.Size = new System.Drawing.Size(273, 23);
            this.CmbPersonel.TabIndex = 2;
            this.CmbPersonel.SelectedIndexChanged += new System.EventHandler(this.CmbPersonel_SelectedIndexChanged);
            // 
            // CmbBildirimPersonel
            // 
            this.CmbBildirimPersonel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBildirimPersonel.FormattingEnabled = true;
            this.CmbBildirimPersonel.Location = new System.Drawing.Point(171, 61);
            this.CmbBildirimPersonel.Name = "CmbBildirimPersonel";
            this.CmbBildirimPersonel.Size = new System.Drawing.Size(273, 23);
            this.CmbBildirimPersonel.TabIndex = 3;
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.Image")));
            this.BtnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnKaydet.Location = new System.Drawing.Point(12, 541);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(130, 51);
            this.BtnKaydet.TabIndex = 318;
            this.BtnKaydet.Text = "     KAYDET";
            this.BtnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKaydet.UseVisualStyleBackColor = false;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // BtnEkle
            // 
            this.BtnEkle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEkle.Image = ((System.Drawing.Image)(resources.GetObject("BtnEkle.Image")));
            this.BtnEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEkle.Location = new System.Drawing.Point(450, 54);
            this.BtnEkle.Name = "BtnEkle";
            this.BtnEkle.Size = new System.Drawing.Size(76, 36);
            this.BtnEkle.TabIndex = 319;
            this.BtnEkle.Text = "  Ekle";
            this.BtnEkle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEkle.UseVisualStyleBackColor = false;
            this.BtnEkle.Click += new System.EventHandler(this.BtnEkle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(12, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 427);
            this.groupBox1.TabIndex = 320;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bildirim Alacak Personeller";
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.PersonelBildirim,
            this.Remove});
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 17);
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.Size = new System.Drawing.Size(508, 407);
            this.DtgList.TabIndex = 1;
            this.DtgList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgList_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 44;
            // 
            // PersonelBildirim
            // 
            this.PersonelBildirim.HeaderText = "PERSONE ADI";
            this.PersonelBildirim.Name = "PersonelBildirim";
            this.PersonelBildirim.ReadOnly = true;
            this.PersonelBildirim.Width = 113;
            // 
            // Remove
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            this.Remove.DefaultCellStyle = dataGridViewCellStyle1;
            this.Remove.HeaderText = "KALDIR";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Text = "X";
            this.Remove.ToolTipText = "X";
            this.Remove.UseColumnTextForButtonValue = true;
            this.Remove.Width = 56;
            // 
            // BtnSil
            // 
            this.BtnSil.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Image = ((System.Drawing.Image)(resources.GetObject("BtnSil.Image")));
            this.BtnSil.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSil.Location = new System.Drawing.Point(148, 541);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(130, 51);
            this.BtnSil.TabIndex = 321;
            this.BtnSil.Text = "TÜMÜNÜ SİL";
            this.BtnSil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSil.UseVisualStyleBackColor = false;
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // FrmBildirimYetki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 604);
            this.Controls.Add(this.BtnSil);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnEkle);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.CmbBildirimPersonel);
            this.Controls.Add(this.CmbPersonel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBildirimYetki";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bildirim Yetki Düzenle";
            this.Load += new System.EventHandler(this.FrmBildirimYetki_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbPersonel;
        private System.Windows.Forms.ComboBox CmbBildirimPersonel;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.Button BtnEkle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DtgList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonelBildirim;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
        private System.Windows.Forms.Button BtnSil;
    }
}