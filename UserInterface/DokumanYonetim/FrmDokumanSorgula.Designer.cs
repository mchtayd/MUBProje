
namespace UserInterface.DokumanYonetim
{
    partial class FrmDokumanSorgula
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgDokumanListesi = new ADGV.AdvancedDataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDocumentNo = new System.Windows.Forms.TextBox();
            this.TxtDocumentName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.TxtTop = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDokumanListesi)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtgDokumanListesi);
            this.groupBox1.Location = new System.Drawing.Point(15, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1524, 462);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DOKÜMAN LİSTESİ";
            // 
            // DtgDokumanListesi
            // 
            this.DtgDokumanListesi.AllowUserToAddRows = false;
            this.DtgDokumanListesi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgDokumanListesi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DtgDokumanListesi.AutoGenerateContextFilters = true;
            this.DtgDokumanListesi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgDokumanListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDokumanListesi.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgDokumanListesi.DateWithTime = false;
            this.DtgDokumanListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgDokumanListesi.Location = new System.Drawing.Point(3, 16);
            this.DtgDokumanListesi.MultiSelect = false;
            this.DtgDokumanListesi.Name = "DtgDokumanListesi";
            this.DtgDokumanListesi.ReadOnly = true;
            this.DtgDokumanListesi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgDokumanListesi.Size = new System.Drawing.Size(1518, 443);
            this.DtgDokumanListesi.TabIndex = 2;
            this.DtgDokumanListesi.TimeFilter = false;
            this.DtgDokumanListesi.SortStringChanged += new System.EventHandler(this.DtgDokumanListesi_SortStringChanged);
            this.DtgDokumanListesi.FilterStringChanged += new System.EventHandler(this.DtgDokumanListesi_FilterStringChanged);
            this.DtgDokumanListesi.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgDokumanListesi_CellMouseClick);
            this.DtgDokumanListesi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtgDokumanListesi_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowser1);
            this.groupBox2.Location = new System.Drawing.Point(15, 606);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(670, 98);
            this.groupBox2.TabIndex = 1;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dokuman Numarasıyla Ara:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dokuman Tanımıyla Ara:";
            // 
            // TxtDocumentNo
            // 
            this.TxtDocumentNo.Location = new System.Drawing.Point(150, 41);
            this.TxtDocumentNo.Name = "TxtDocumentNo";
            this.TxtDocumentNo.Size = new System.Drawing.Size(232, 20);
            this.TxtDocumentNo.TabIndex = 4;
            this.TxtDocumentNo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TxtDocumentName
            // 
            this.TxtDocumentName.Location = new System.Drawing.Point(150, 66);
            this.TxtDocumentName.Name = "TxtDocumentName";
            this.TxtDocumentName.Size = new System.Drawing.Size(232, 20);
            this.TxtDocumentName.TabIndex = 5;
            this.TxtDocumentName.TextChanged += new System.EventHandler(this.TxtDocumentName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Location = new System.Drawing.Point(6, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1524, 27);
            this.panel1.TabIndex = 46;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.ForeColor = System.Drawing.Color.DarkRed;
            this.button5.Location = new System.Drawing.Point(12, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(35, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTop.Location = new System.Drawing.Point(190, 572);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(27, 20);
            this.TxtTop.TabIndex = 318;
            this.TxtTop.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(24, 573);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 20);
            this.label3.TabIndex = 317;
            this.label3.Text = "Güncel Form Adeti:";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmDokumanSorgula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 924);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TxtDocumentName);
            this.Controls.Add(this.TxtDocumentNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmDokumanSorgula";
            this.Text = "Dokuman Sorgula";
            this.Load += new System.EventHandler(this.FrmDokumanSorgula_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDokumanListesi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtDocumentNo;
        private System.Windows.Forms.TextBox TxtDocumentName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private ADGV.AdvancedDataGridView DtgDokumanListesi;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}