
namespace UserInterface.IdariIsler
{
    partial class FrmKonaklamaOnay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKonaklamaOnay));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgKonaklama = new ADGV.AdvancedDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTopKonaklama = new System.Windows.Forms.Label();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ımageList2 = new System.Windows.Forms.ImageList(this.components);
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.BtnReddet = new System.Windows.Forms.Button();
            this.BtnTumunuOnayla = new System.Windows.Forms.Button();
            this.BtnOnayla = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgKonaklama)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1426, 27);
            this.panel1.TabIndex = 322;
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
            this.groupBox1.Controls.Add(this.DtgKonaklama);
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1400, 531);
            this.groupBox1.TabIndex = 328;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "KONAKLAMA ONAY LİSTESİ";
            // 
            // DtgKonaklama
            // 
            this.DtgKonaklama.AllowUserToAddRows = false;
            this.DtgKonaklama.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgKonaklama.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DtgKonaklama.AutoGenerateContextFilters = true;
            this.DtgKonaklama.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtgKonaklama.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DtgKonaklama.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgKonaklama.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgKonaklama.DateWithTime = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgKonaklama.DefaultCellStyle = dataGridViewCellStyle12;
            this.DtgKonaklama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgKonaklama.Location = new System.Drawing.Point(3, 16);
            this.DtgKonaklama.MultiSelect = false;
            this.DtgKonaklama.Name = "DtgKonaklama";
            this.DtgKonaklama.ReadOnly = true;
            this.DtgKonaklama.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgKonaklama.Size = new System.Drawing.Size(1394, 512);
            this.DtgKonaklama.TabIndex = 2;
            this.DtgKonaklama.TimeFilter = false;
            this.DtgKonaklama.SortStringChanged += new System.EventHandler(this.DtgKonaklama_SortStringChanged);
            this.DtgKonaklama.FilterStringChanged += new System.EventHandler(this.DtgKonaklama_FilterStringChanged);
            this.DtgKonaklama.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgKonaklama_CellMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 589);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 329;
            this.label1.Text = "Toplam Kayıt:";
            // 
            // TxtTopKonaklama
            // 
            this.TxtTopKonaklama.AutoSize = true;
            this.TxtTopKonaklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTopKonaklama.Location = new System.Drawing.Point(112, 589);
            this.TxtTopKonaklama.Name = "TxtTopKonaklama";
            this.TxtTopKonaklama.Size = new System.Drawing.Size(21, 15);
            this.TxtTopKonaklama.TabIndex = 330;
            this.TxtTopKonaklama.Text = "00";
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "okey.png");
            this.ımageList1.Images.SetKeyName(1, "ok.png");
            // 
            // ımageList2
            // 
            this.ımageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList2.ImageStream")));
            this.ımageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList2.Images.SetKeyName(0, "allokey.ico");
            this.ımageList2.Images.SetKeyName(1, "delete-sign.png");
            this.ımageList2.Images.SetKeyName(2, "Icojam-Blue-Bits-Database-check.ico");
            // 
            // BtnReddet
            // 
            this.BtnReddet.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnReddet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReddet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnReddet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReddet.ImageKey = "delete-sign.png";
            this.BtnReddet.ImageList = this.ımageList2;
            this.BtnReddet.Location = new System.Drawing.Point(309, 618);
            this.BtnReddet.Name = "BtnReddet";
            this.BtnReddet.Size = new System.Drawing.Size(123, 51);
            this.BtnReddet.TabIndex = 347;
            this.BtnReddet.Text = "    REDDET";
            this.BtnReddet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReddet.UseVisualStyleBackColor = false;
            this.BtnReddet.Click += new System.EventHandler(this.BtnReddet_Click);
            // 
            // BtnTumunuOnayla
            // 
            this.BtnTumunuOnayla.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnTumunuOnayla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTumunuOnayla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTumunuOnayla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTumunuOnayla.ImageKey = "Icojam-Blue-Bits-Database-check.ico";
            this.BtnTumunuOnayla.ImageList = this.ımageList2;
            this.BtnTumunuOnayla.Location = new System.Drawing.Point(143, 618);
            this.BtnTumunuOnayla.Name = "BtnTumunuOnayla";
            this.BtnTumunuOnayla.Size = new System.Drawing.Size(160, 51);
            this.BtnTumunuOnayla.TabIndex = 346;
            this.BtnTumunuOnayla.Text = "TÜMÜNÜ ONAYLA";
            this.BtnTumunuOnayla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTumunuOnayla.UseVisualStyleBackColor = false;
            this.BtnTumunuOnayla.Click += new System.EventHandler(this.BtnTumunuOnayla_Click);
            // 
            // BtnOnayla
            // 
            this.BtnOnayla.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnOnayla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOnayla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnOnayla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOnayla.ImageKey = "ok.png";
            this.BtnOnayla.ImageList = this.ımageList1;
            this.BtnOnayla.Location = new System.Drawing.Point(14, 618);
            this.BtnOnayla.Name = "BtnOnayla";
            this.BtnOnayla.Size = new System.Drawing.Size(123, 51);
            this.BtnOnayla.TabIndex = 345;
            this.BtnOnayla.Text = "  ONAYLA";
            this.BtnOnayla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOnayla.UseVisualStyleBackColor = false;
            this.BtnOnayla.Click += new System.EventHandler(this.BtnOnayla_Click);
            // 
            // FrmKonaklamaOnay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 806);
            this.Controls.Add(this.BtnReddet);
            this.Controls.Add(this.BtnTumunuOnayla);
            this.Controls.Add(this.BtnOnayla);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtTopKonaklama);
            this.Controls.Add(this.panel1);
            this.Name = "FrmKonaklamaOnay";
            this.Text = "FrmKonaklamaOnay";
            this.Load += new System.EventHandler(this.FrmKonaklamaOnay_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgKonaklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBinder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private ADGV.AdvancedDataGridView DtgKonaklama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TxtTopKonaklama;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.ImageList ımageList2;
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.Button BtnReddet;
        private System.Windows.Forms.Button BtnTumunuOnayla;
        private System.Windows.Forms.Button BtnOnayla;
    }
}