
namespace UserInterface.IdariIsler
{
    partial class FrmArsivIzleme
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgArsiv = new ADGV.AdvancedDataGridView();
            this.TxtTop = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgArsiv)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1557, 27);
            this.panel1.TabIndex = 314;
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
            this.groupBox1.Controls.Add(this.DtgArsiv);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1533, 639);
            this.groupBox1.TabIndex = 315;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ARŞİV KAYITLARI";
            // 
            // DtgArsiv
            // 
            this.DtgArsiv.AllowUserToAddRows = false;
            this.DtgArsiv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgArsiv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtgArsiv.AutoGenerateContextFilters = true;
            this.DtgArsiv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgArsiv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgArsiv.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgArsiv.DateWithTime = false;
            this.DtgArsiv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgArsiv.Location = new System.Drawing.Point(3, 16);
            this.DtgArsiv.Name = "DtgArsiv";
            this.DtgArsiv.ReadOnly = true;
            this.DtgArsiv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgArsiv.Size = new System.Drawing.Size(1527, 620);
            this.DtgArsiv.TabIndex = 2;
            this.DtgArsiv.TimeFilter = false;
            this.DtgArsiv.SortStringChanged += new System.EventHandler(this.DtgArsiv_SortStringChanged);
            this.DtgArsiv.FilterStringChanged += new System.EventHandler(this.DtgArsiv_FilterStringChanged);
            this.DtgArsiv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgArsiv_CellMouseClick);
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(134, 691);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(27, 20);
            this.TxtTop.TabIndex = 321;
            this.TxtTop.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 691);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 320;
            this.label3.Text = "Toplam Kayıt:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Location = new System.Drawing.Point(12, 724);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(670, 98);
            this.groupBox2.TabIndex = 319;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EKLER";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(664, 79);
            this.webBrowser1.TabIndex = 0;
            // 
            // FrmArsivIzleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 924);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmArsivIzleme";
            this.Text = "FrmArsivIzleme";
            this.Load += new System.EventHandler(this.FrmArsivIzleme_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgArsiv)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgArsiv;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.BindingSource dataBinder;
    }
}