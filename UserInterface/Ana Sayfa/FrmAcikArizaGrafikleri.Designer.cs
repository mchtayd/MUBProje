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
            this.chart1 = new LiveCharts.WinForms.PieChart();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.label1 = new System.Windows.Forms.Label();
            this.lBL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblSektorArizaTop = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chart1.Location = new System.Drawing.Point(12, 75);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(945, 805);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "pieChart1";
            // 
            // pieChart1
            // 
            this.pieChart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pieChart1.Location = new System.Drawing.Point(967, 75);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(945, 805);
            this.pieChart1.TabIndex = 2;
            this.pieChart1.Text = "pieChart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(114, 32);
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
            this.lBL.Location = new System.Drawing.Point(757, 918);
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
            this.label2.Location = new System.Drawing.Point(1028, 32);
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
            this.LblSektorArizaTop.Location = new System.Drawing.Point(982, 918);
            this.LblSektorArizaTop.Name = "LblSektorArizaTop";
            this.LblSektorArizaTop.Size = new System.Drawing.Size(57, 40);
            this.LblSektorArizaTop.TabIndex = 6;
            this.LblSektorArizaTop.Text = "00";
            // 
            // FrmAcikArizaGrafikleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 996);
            this.Controls.Add(this.LblSektorArizaTop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lBL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.chart1);
            this.Name = "FrmAcikArizaGrafikleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Açık Arıza Grafikleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAcikArizaGrafikleri_Load);
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
    }
}