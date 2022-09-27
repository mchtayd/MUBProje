
namespace UserInterface.BakımOnarım
{
    partial class FrmDepoLokasyonKayit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgDepolar = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DtgLokasyonlar = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnDepoEkle = new System.Windows.Forms.Button();
            this.TxtDepo = new System.Windows.Forms.TextBox();
            this.TxtDepoAciklama = new System.Windows.Forms.TextBox();
            this.TxtLokasyonAcıklama = new System.Windows.Forms.TextBox();
            this.TxtLokasyon = new System.Windows.Forms.TextBox();
            this.BtnLokasyonEkle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtTop2 = new System.Windows.Forms.Label();
            this.BtnDepoSil = new System.Windows.Forms.Button();
            this.BtnLokasyonSil = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepolar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgLokasyonlar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgDepolar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 558);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DEPO ADRESİ";
            // 
            // DtgDepolar
            // 
            this.DtgDepolar.AllowUserToAddRows = false;
            this.DtgDepolar.AllowUserToDeleteRows = false;
            this.DtgDepolar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgDepolar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDepolar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgDepolar.Location = new System.Drawing.Point(3, 16);
            this.DtgDepolar.Name = "DtgDepolar";
            this.DtgDepolar.ReadOnly = true;
            this.DtgDepolar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgDepolar.Size = new System.Drawing.Size(408, 539);
            this.DtgDepolar.TabIndex = 0;
            this.DtgDepolar.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgDepolar_CellMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DtgLokasyonlar);
            this.groupBox2.Location = new System.Drawing.Point(432, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 558);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LOKASYON ADRESİ";
            // 
            // DtgLokasyonlar
            // 
            this.DtgLokasyonlar.AllowUserToAddRows = false;
            this.DtgLokasyonlar.AllowUserToDeleteRows = false;
            this.DtgLokasyonlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgLokasyonlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgLokasyonlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgLokasyonlar.Location = new System.Drawing.Point(3, 16);
            this.DtgLokasyonlar.Name = "DtgLokasyonlar";
            this.DtgLokasyonlar.ReadOnly = true;
            this.DtgLokasyonlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgLokasyonlar.Size = new System.Drawing.Size(408, 539);
            this.DtgLokasyonlar.TabIndex = 1;
            this.DtgLokasyonlar.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgLokasyonlar_CellMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 619);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "DEPO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 648);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "AÇIKLAMA:";
            // 
            // BtnDepoEkle
            // 
            this.BtnDepoEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDepoEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDepoEkle.Location = new System.Drawing.Point(83, 676);
            this.BtnDepoEkle.Name = "BtnDepoEkle";
            this.BtnDepoEkle.Size = new System.Drawing.Size(74, 27);
            this.BtnDepoEkle.TabIndex = 4;
            this.BtnDepoEkle.Text = "KAYDET";
            this.BtnDepoEkle.UseVisualStyleBackColor = true;
            this.BtnDepoEkle.Click += new System.EventHandler(this.BtnDepoEkle_Click);
            // 
            // TxtDepo
            // 
            this.TxtDepo.Location = new System.Drawing.Point(83, 615);
            this.TxtDepo.Name = "TxtDepo";
            this.TxtDepo.Size = new System.Drawing.Size(111, 20);
            this.TxtDepo.TabIndex = 5;
            // 
            // TxtDepoAciklama
            // 
            this.TxtDepoAciklama.Location = new System.Drawing.Point(83, 644);
            this.TxtDepoAciklama.Name = "TxtDepoAciklama";
            this.TxtDepoAciklama.Size = new System.Drawing.Size(340, 20);
            this.TxtDepoAciklama.TabIndex = 6;
            // 
            // TxtLokasyonAcıklama
            // 
            this.TxtLokasyonAcıklama.Location = new System.Drawing.Point(514, 645);
            this.TxtLokasyonAcıklama.Name = "TxtLokasyonAcıklama";
            this.TxtLokasyonAcıklama.Size = new System.Drawing.Size(329, 20);
            this.TxtLokasyonAcıklama.TabIndex = 11;
            // 
            // TxtLokasyon
            // 
            this.TxtLokasyon.Location = new System.Drawing.Point(514, 616);
            this.TxtLokasyon.Name = "TxtLokasyon";
            this.TxtLokasyon.Size = new System.Drawing.Size(111, 20);
            this.TxtLokasyon.TabIndex = 10;
            // 
            // BtnLokasyonEkle
            // 
            this.BtnLokasyonEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLokasyonEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnLokasyonEkle.Location = new System.Drawing.Point(514, 676);
            this.BtnLokasyonEkle.Name = "BtnLokasyonEkle";
            this.BtnLokasyonEkle.Size = new System.Drawing.Size(74, 27);
            this.BtnLokasyonEkle.TabIndex = 9;
            this.BtnLokasyonEkle.Text = "KAYDET";
            this.BtnLokasyonEkle.UseVisualStyleBackColor = true;
            this.BtnLokasyonEkle.Click += new System.EventHandler(this.BtnLokasyonEkle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 649);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "AÇIKLAMA:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 620);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "LOKASYON";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(15, 582);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 342;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(115, 582);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 343;
            this.TxtTop.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(432, 582);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 344;
            this.label5.Text = "Toplam Kayıt:";
            // 
            // TxtTop2
            // 
            this.TxtTop2.AutoSize = true;
            this.TxtTop2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop2.Location = new System.Drawing.Point(532, 582);
            this.TxtTop2.Name = "TxtTop2";
            this.TxtTop2.Size = new System.Drawing.Size(21, 15);
            this.TxtTop2.TabIndex = 345;
            this.TxtTop2.Text = "00";
            // 
            // BtnDepoSil
            // 
            this.BtnDepoSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDepoSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDepoSil.Location = new System.Drawing.Point(163, 676);
            this.BtnDepoSil.Name = "BtnDepoSil";
            this.BtnDepoSil.Size = new System.Drawing.Size(74, 27);
            this.BtnDepoSil.TabIndex = 346;
            this.BtnDepoSil.Text = "SİL";
            this.BtnDepoSil.UseVisualStyleBackColor = true;
            this.BtnDepoSil.Click += new System.EventHandler(this.BtnDepoSil_Click);
            // 
            // BtnLokasyonSil
            // 
            this.BtnLokasyonSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLokasyonSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnLokasyonSil.Location = new System.Drawing.Point(594, 676);
            this.BtnLokasyonSil.Name = "BtnLokasyonSil";
            this.BtnLokasyonSil.Size = new System.Drawing.Size(74, 27);
            this.BtnLokasyonSil.TabIndex = 347;
            this.BtnLokasyonSil.Text = "SİL";
            this.BtnLokasyonSil.UseVisualStyleBackColor = true;
            this.BtnLokasyonSil.Click += new System.EventHandler(this.BtnLokasyonSil_Click);
            // 
            // FrmDepoLokasyonKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 718);
            this.Controls.Add(this.BtnLokasyonSil);
            this.Controls.Add(this.BtnDepoSil);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtTop2);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.TxtLokasyonAcıklama);
            this.Controls.Add(this.TxtLokasyon);
            this.Controls.Add(this.BtnLokasyonEkle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtDepoAciklama);
            this.Controls.Add(this.TxtDepo);
            this.Controls.Add(this.BtnDepoEkle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDepoLokasyonKayit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Depo Ve Lokasyon Kayıt";
            this.Load += new System.EventHandler(this.FrmDepoLokasyonKayit_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepolar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgLokasyonlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnDepoEkle;
        private System.Windows.Forms.TextBox TxtDepo;
        private System.Windows.Forms.TextBox TxtDepoAciklama;
        private System.Windows.Forms.TextBox TxtLokasyonAcıklama;
        private System.Windows.Forms.TextBox TxtLokasyon;
        private System.Windows.Forms.Button BtnLokasyonEkle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DtgDepolar;
        private System.Windows.Forms.DataGridView DtgLokasyonlar;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TxtTop2;
        private System.Windows.Forms.Button BtnDepoSil;
        private System.Windows.Forms.Button BtnLokasyonSil;
    }
}