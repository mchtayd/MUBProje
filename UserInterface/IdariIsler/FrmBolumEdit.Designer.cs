namespace UserInterface.IdariIsler
{
    partial class FrmBolumEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBolumEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DtgBolum1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DtgBolum2 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DtgBolum3 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtBolum1 = new System.Windows.Forms.TextBox();
            this.TxtBolum2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtBolum3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnEkle = new System.Windows.Forms.Button();
            this.BtnEkle2 = new System.Windows.Forms.Button();
            this.BtnEkle3 = new System.Windows.Forms.Button();
            this.BtnKaydet = new System.Windows.Forms.Button();
            this.Id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bolum1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bolum2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bolum3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolum1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolum2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolum3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bölüm 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bölüm 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 519);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bölüm 3:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DtgBolum1);
            this.panel1.Location = new System.Drawing.Point(74, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 200);
            this.panel1.TabIndex = 9;
            // 
            // DtgBolum1
            // 
            this.DtgBolum1.AllowUserToAddRows = false;
            this.DtgBolum1.AllowUserToDeleteRows = false;
            this.DtgBolum1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgBolum1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgBolum1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id1,
            this.Bolum1,
            this.Remove1});
            this.DtgBolum1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgBolum1.Location = new System.Drawing.Point(0, 0);
            this.DtgBolum1.Name = "DtgBolum1";
            this.DtgBolum1.ReadOnly = true;
            this.DtgBolum1.Size = new System.Drawing.Size(374, 200);
            this.DtgBolum1.TabIndex = 1;
            this.DtgBolum1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgBolum1_CellContentClick);
            this.DtgBolum1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgBolum1_CellMouseClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DtgBolum2);
            this.panel3.Location = new System.Drawing.Point(74, 220);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(374, 200);
            this.panel3.TabIndex = 10;
            // 
            // DtgBolum2
            // 
            this.DtgBolum2.AllowUserToAddRows = false;
            this.DtgBolum2.AllowUserToDeleteRows = false;
            this.DtgBolum2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgBolum2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgBolum2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id2,
            this.Bolum2,
            this.Remove2});
            this.DtgBolum2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgBolum2.Location = new System.Drawing.Point(0, 0);
            this.DtgBolum2.Name = "DtgBolum2";
            this.DtgBolum2.ReadOnly = true;
            this.DtgBolum2.Size = new System.Drawing.Size(374, 200);
            this.DtgBolum2.TabIndex = 2;
            this.DtgBolum2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgBolum2_CellContentClick);
            this.DtgBolum2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgBolum2_CellMouseClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DtgBolum3);
            this.panel2.Location = new System.Drawing.Point(74, 426);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 200);
            this.panel2.TabIndex = 11;
            // 
            // DtgBolum3
            // 
            this.DtgBolum3.AllowUserToAddRows = false;
            this.DtgBolum3.AllowUserToDeleteRows = false;
            this.DtgBolum3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgBolum3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgBolum3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id3,
            this.Bolum3,
            this.Remove3});
            this.DtgBolum3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgBolum3.Location = new System.Drawing.Point(0, 0);
            this.DtgBolum3.Name = "DtgBolum3";
            this.DtgBolum3.ReadOnly = true;
            this.DtgBolum3.Size = new System.Drawing.Size(374, 200);
            this.DtgBolum3.TabIndex = 2;
            this.DtgBolum3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgBolum3_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(460, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Bölüm 1:";
            // 
            // TxtBolum1
            // 
            this.TxtBolum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtBolum1.Location = new System.Drawing.Point(463, 92);
            this.TxtBolum1.Name = "TxtBolum1";
            this.TxtBolum1.Size = new System.Drawing.Size(307, 21);
            this.TxtBolum1.TabIndex = 13;
            // 
            // TxtBolum2
            // 
            this.TxtBolum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtBolum2.Location = new System.Drawing.Point(463, 294);
            this.TxtBolum2.Name = "TxtBolum2";
            this.TxtBolum2.Size = new System.Drawing.Size(307, 21);
            this.TxtBolum2.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(463, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Bölüm 2:";
            // 
            // TxtBolum3
            // 
            this.TxtBolum3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtBolum3.Location = new System.Drawing.Point(463, 494);
            this.TxtBolum3.Name = "TxtBolum3";
            this.TxtBolum3.Size = new System.Drawing.Size(307, 21);
            this.TxtBolum3.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(463, 476);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Bölüm 3:";
            // 
            // BtnEkle
            // 
            this.BtnEkle.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEkle.Image = ((System.Drawing.Image)(resources.GetObject("BtnEkle.Image")));
            this.BtnEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEkle.Location = new System.Drawing.Point(463, 119);
            this.BtnEkle.Name = "BtnEkle";
            this.BtnEkle.Size = new System.Drawing.Size(85, 33);
            this.BtnEkle.TabIndex = 465;
            this.BtnEkle.Text = "  EKLE";
            this.BtnEkle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEkle.UseVisualStyleBackColor = false;
            this.BtnEkle.Click += new System.EventHandler(this.BtnEkle_Click);
            // 
            // BtnEkle2
            // 
            this.BtnEkle2.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnEkle2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEkle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEkle2.Image = ((System.Drawing.Image)(resources.GetObject("BtnEkle2.Image")));
            this.BtnEkle2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEkle2.Location = new System.Drawing.Point(463, 321);
            this.BtnEkle2.Name = "BtnEkle2";
            this.BtnEkle2.Size = new System.Drawing.Size(85, 33);
            this.BtnEkle2.TabIndex = 466;
            this.BtnEkle2.Text = "  EKLE";
            this.BtnEkle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEkle2.UseVisualStyleBackColor = false;
            this.BtnEkle2.Click += new System.EventHandler(this.BtnEkle2_Click);
            // 
            // BtnEkle3
            // 
            this.BtnEkle3.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnEkle3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEkle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEkle3.Image = ((System.Drawing.Image)(resources.GetObject("BtnEkle3.Image")));
            this.BtnEkle3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEkle3.Location = new System.Drawing.Point(463, 521);
            this.BtnEkle3.Name = "BtnEkle3";
            this.BtnEkle3.Size = new System.Drawing.Size(85, 33);
            this.BtnEkle3.TabIndex = 467;
            this.BtnEkle3.Text = "  EKLE";
            this.BtnEkle3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEkle3.UseVisualStyleBackColor = false;
            this.BtnEkle3.Click += new System.EventHandler(this.BtnEkle3_Click);
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.Image")));
            this.BtnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnKaydet.Location = new System.Drawing.Point(74, 632);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(130, 51);
            this.BtnKaydet.TabIndex = 468;
            this.BtnKaydet.Text = "     KAYDET";
            this.BtnKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnKaydet.UseVisualStyleBackColor = false;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // Id1
            // 
            this.Id1.HeaderText = "ID";
            this.Id1.Name = "Id1";
            this.Id1.ReadOnly = true;
            this.Id1.Visible = false;
            this.Id1.Width = 43;
            // 
            // Bolum1
            // 
            this.Bolum1.HeaderText = "BÖLÜM ADI";
            this.Bolum1.Name = "Bolum1";
            this.Bolum1.ReadOnly = true;
            this.Bolum1.Width = 91;
            // 
            // Remove1
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Red;
            this.Remove1.DefaultCellStyle = dataGridViewCellStyle7;
            this.Remove1.HeaderText = "KALDIR";
            this.Remove1.Name = "Remove1";
            this.Remove1.ReadOnly = true;
            this.Remove1.Text = "X";
            this.Remove1.ToolTipText = "X";
            this.Remove1.UseColumnTextForButtonValue = true;
            this.Remove1.Width = 52;
            // 
            // Id2
            // 
            this.Id2.HeaderText = "ID";
            this.Id2.Name = "Id2";
            this.Id2.ReadOnly = true;
            this.Id2.Visible = false;
            this.Id2.Width = 43;
            // 
            // Bolum2
            // 
            this.Bolum2.HeaderText = "BÖLÜM ADI";
            this.Bolum2.Name = "Bolum2";
            this.Bolum2.ReadOnly = true;
            this.Bolum2.Width = 91;
            // 
            // Remove2
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Red;
            this.Remove2.DefaultCellStyle = dataGridViewCellStyle8;
            this.Remove2.HeaderText = "KALDIR";
            this.Remove2.Name = "Remove2";
            this.Remove2.ReadOnly = true;
            this.Remove2.Text = "X";
            this.Remove2.ToolTipText = "X";
            this.Remove2.UseColumnTextForButtonValue = true;
            this.Remove2.Width = 52;
            // 
            // Id3
            // 
            this.Id3.HeaderText = "ID";
            this.Id3.Name = "Id3";
            this.Id3.ReadOnly = true;
            this.Id3.Visible = false;
            this.Id3.Width = 43;
            // 
            // Bolum3
            // 
            this.Bolum3.HeaderText = "BÖLÜM ADI";
            this.Bolum3.Name = "Bolum3";
            this.Bolum3.ReadOnly = true;
            this.Bolum3.Width = 91;
            // 
            // Remove3
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Red;
            this.Remove3.DefaultCellStyle = dataGridViewCellStyle9;
            this.Remove3.HeaderText = "KALDIR";
            this.Remove3.Name = "Remove3";
            this.Remove3.ReadOnly = true;
            this.Remove3.Text = "X";
            this.Remove3.ToolTipText = "X";
            this.Remove3.UseColumnTextForButtonValue = true;
            this.Remove3.Width = 52;
            // 
            // FrmBolumEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 693);
            this.Controls.Add(this.BtnKaydet);
            this.Controls.Add(this.BtnEkle3);
            this.Controls.Add(this.BtnEkle2);
            this.Controls.Add(this.BtnEkle);
            this.Controls.Add(this.TxtBolum3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtBolum2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtBolum1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBolumEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bölüm Düzenle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBolumEdit_FormClosing);
            this.Load += new System.EventHandler(this.FrmBolumEdit_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolum1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolum2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgBolum3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtBolum1;
        private System.Windows.Forms.TextBox TxtBolum2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtBolum3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnEkle;
        private System.Windows.Forms.Button BtnEkle2;
        private System.Windows.Forms.Button BtnEkle3;
        private System.Windows.Forms.DataGridView DtgBolum1;
        private System.Windows.Forms.DataGridView DtgBolum2;
        private System.Windows.Forms.DataGridView DtgBolum3;
        private System.Windows.Forms.Button BtnKaydet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bolum1;
        private System.Windows.Forms.DataGridViewButtonColumn Remove1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bolum2;
        private System.Windows.Forms.DataGridViewButtonColumn Remove2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bolum3;
        private System.Windows.Forms.DataGridViewButtonColumn Remove3;
    }
}