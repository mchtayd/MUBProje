namespace UserInterface.Ana_Sayfa
{
    partial class FrmAcikArizaGrafikleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAcikArizaGrafikleri));
            this.chart1 = new LiveCharts.WinForms.PieChart();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.label1 = new System.Windows.Forms.Label();
            this.lBL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblSektorArizaTop = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblSaat = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LblTarih = new System.Windows.Forms.Label();
            this.TimerSaat = new System.Windows.Forms.Timer(this.components);
            this.label30 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chart1.Location = new System.Drawing.Point(68, 225);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(857, 704);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "pieChart1";
            // 
            // pieChart1
            // 
            this.pieChart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pieChart1.Location = new System.Drawing.Point(1023, 225);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(857, 704);
            this.pieChart1.TabIndex = 2;
            this.pieChart1.Text = "pieChart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(114, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(740, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "SORUMLULUK SAHALARINA DAĞILIMI";
            // 
            // lBL
            // 
            this.lBL.AutoSize = true;
            this.lBL.Font = new System.Drawing.Font("Mongolian Baiti", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBL.ForeColor = System.Drawing.Color.Black;
            this.lBL.Location = new System.Drawing.Point(809, 932);
            this.lBL.Name = "lBL";
            this.lBL.Size = new System.Drawing.Size(219, 40);
            this.lBL.TabIndex = 4;
            this.lBL.Text = "TOPLAM = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(1028, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(822, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "İŞLEM SORUMLUSU BÖLÜMLERE DAĞILIMI";
            // 
            // LblSektorArizaTop
            // 
            this.LblSektorArizaTop.AutoSize = true;
            this.LblSektorArizaTop.Font = new System.Drawing.Font("Mongolian Baiti", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSektorArizaTop.ForeColor = System.Drawing.Color.Black;
            this.LblSektorArizaTop.Location = new System.Drawing.Point(1034, 932);
            this.LblSektorArizaTop.Name = "LblSektorArizaTop";
            this.LblSektorArizaTop.Size = new System.Drawing.Size(57, 40);
            this.LblSektorArizaTop.TabIndex = 6;
            this.LblSektorArizaTop.Text = "00";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(1686, 967);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 379;
            this.label3.Text = "SAAT:";
            // 
            // LblSaat
            // 
            this.LblSaat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblSaat.AutoSize = true;
            this.LblSaat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblSaat.Location = new System.Drawing.Point(1752, 967);
            this.LblSaat.Name = "LblSaat";
            this.LblSaat.Size = new System.Drawing.Size(27, 20);
            this.LblSaat.TabIndex = 378;
            this.LblSaat.Text = "00";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(1370, 967);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 20);
            this.label10.TabIndex = 377;
            this.label10.Text = "TARİH:";
            // 
            // LblTarih
            // 
            this.LblTarih.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblTarih.AutoSize = true;
            this.LblTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTarih.Location = new System.Drawing.Point(1444, 967);
            this.LblTarih.Name = "LblTarih";
            this.LblTarih.Size = new System.Drawing.Size(27, 20);
            this.LblTarih.TabIndex = 376;
            this.LblTarih.Text = "00";
            // 
            // TimerSaat
            // 
            this.TimerSaat.Interval = 1000;
            this.TimerSaat.Tick += new System.EventHandler(this.TimerSaat_Tick);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Bahnschrift", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label30.ForeColor = System.Drawing.Color.Orange;
            this.label30.Location = new System.Drawing.Point(325, 116);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(106, 42);
            this.label30.TabIndex = 391;
            this.label30.Text = "UGES";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Bahnschrift", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(707, 44);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(405, 45);
            this.label40.TabIndex = 390;
            this.label40.Text = "GÜVENLİK SİSTEMLERİ";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Bahnschrift", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(769, 89);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(272, 45);
            this.label41.TabIndex = 384;
            this.label41.Text = "MÜB ELD OFİSİ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(466, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(184, 149);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 386;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1145, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 385;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(168, 15);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(292, 148);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 389;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1317, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(259, 119);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 387;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(1582, 36);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(205, 97);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 388;
            this.pictureBox4.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 20000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmAcikArizaGrafikleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 996);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblSaat);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LblTarih);
            this.Controls.Add(this.LblSektorArizaTop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lBL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.chart1);
            this.Name = "FrmAcikArizaGrafikleri";
            this.Text = "Açık Arıza Grafikleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAcikArizaGrafikleri_FormClosing);
            this.Load += new System.EventHandler(this.FrmAcikArizaGrafikleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.PieChart chart1;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lBL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblSektorArizaTop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblSaat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LblTarih;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.Timer TimerSaat;
        public System.Windows.Forms.Timer timer1;
    }
}