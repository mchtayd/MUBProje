
namespace UserInterface.BakımOnarım
{
    partial class FrmDtfIzleme
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtTop = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgDevamEden = new ADGV.AdvancedDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTop2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtgTamamlanan = new ADGV.AdvancedDataGridView();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.dataBinderTamamlanan = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDevamEden)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTamamlanan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderTamamlanan)).BeginInit();
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
            this.panel1.TabIndex = 316;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1543, 875);
            this.tabControl1.TabIndex = 317;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.TxtTop);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1535, 849);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DEVAM EDEN";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Location = new System.Drawing.Point(12, 555);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(856, 180);
            this.groupBox2.TabIndex = 346;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ekler:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(850, 161);
            this.webBrowser1.TabIndex = 0;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label31.Location = new System.Drawing.Point(9, 528);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 15);
            this.label31.TabIndex = 344;
            this.label31.Text = "Toplam Kayıt:";
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(109, 528);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(21, 15);
            this.TxtTop.TabIndex = 345;
            this.TxtTop.Text = "00";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgDevamEden);
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1518, 516);
            this.groupBox1.TabIndex = 316;
            this.groupBox1.TabStop = false;
            // 
            // DtgDevamEden
            // 
            this.DtgDevamEden.AllowUserToAddRows = false;
            this.DtgDevamEden.AllowUserToDeleteRows = false;
            this.DtgDevamEden.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgDevamEden.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgDevamEden.AutoGenerateContextFilters = true;
            this.DtgDevamEden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgDevamEden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDevamEden.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgDevamEden.DateWithTime = false;
            this.DtgDevamEden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgDevamEden.Location = new System.Drawing.Point(3, 16);
            this.DtgDevamEden.Name = "DtgDevamEden";
            this.DtgDevamEden.ReadOnly = true;
            this.DtgDevamEden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgDevamEden.Size = new System.Drawing.Size(1512, 497);
            this.DtgDevamEden.TabIndex = 2;
            this.DtgDevamEden.TimeFilter = false;
            this.DtgDevamEden.SortStringChanged += new System.EventHandler(this.DtgDevamEden_SortStringChanged);
            this.DtgDevamEden.FilterStringChanged += new System.EventHandler(this.DtgDevamEden_FilterStringChanged);
            this.DtgDevamEden.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgDevamEden_CellMouseClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.TxtTop2);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1535, 849);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TAMAMLANAN";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.webBrowser2);
            this.groupBox4.Location = new System.Drawing.Point(9, 557);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(856, 180);
            this.groupBox4.TabIndex = 349;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ekler:";
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(3, 16);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(850, 161);
            this.webBrowser2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 530);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 347;
            this.label1.Text = "Toplam Kayıt:";
            // 
            // TxtTop2
            // 
            this.TxtTop2.AutoSize = true;
            this.TxtTop2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop2.Location = new System.Drawing.Point(106, 530);
            this.TxtTop2.Name = "TxtTop2";
            this.TxtTop2.Size = new System.Drawing.Size(21, 15);
            this.TxtTop2.TabIndex = 348;
            this.TxtTop2.Text = "00";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DtgTamamlanan);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1521, 516);
            this.groupBox3.TabIndex = 317;
            this.groupBox3.TabStop = false;
            // 
            // DtgTamamlanan
            // 
            this.DtgTamamlanan.AllowUserToAddRows = false;
            this.DtgTamamlanan.AllowUserToDeleteRows = false;
            this.DtgTamamlanan.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgTamamlanan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DtgTamamlanan.AutoGenerateContextFilters = true;
            this.DtgTamamlanan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgTamamlanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgTamamlanan.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgTamamlanan.DateWithTime = false;
            this.DtgTamamlanan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgTamamlanan.Location = new System.Drawing.Point(3, 16);
            this.DtgTamamlanan.Name = "DtgTamamlanan";
            this.DtgTamamlanan.ReadOnly = true;
            this.DtgTamamlanan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgTamamlanan.Size = new System.Drawing.Size(1515, 497);
            this.DtgTamamlanan.TabIndex = 2;
            this.DtgTamamlanan.TimeFilter = false;
            this.DtgTamamlanan.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgTamamlanan_CellMouseClick);
            // 
            // FrmDtfIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 909);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDtfIzleme";
            this.Text = "FrmDtfIzleme";
            this.Load += new System.EventHandler(this.FrmDtfIzleme_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDevamEden)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgTamamlanan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinderTamamlanan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgDevamEden;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TxtTop2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ADGV.AdvancedDataGridView DtgTamamlanan;
        private System.Windows.Forms.BindingSource dataBinderTamamlanan;
    }
}