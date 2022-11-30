
namespace UserInterface.IdariIsler
{
    partial class FrmMifOnay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMifOnay));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtgList = new ADGV.AdvancedDataGridView();
            this.dataBinder = new System.Windows.Forms.BindingSource(this.components);
            this.TxtTop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtMiktar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnOnayla = new System.Windows.Forms.Button();
            this.BtnTumunuOnayla = new System.Windows.Forms.Button();
            this.BtnReddet = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ımageList2 = new System.Windows.Forms.ImageList(this.components);
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
            this.panel1.Size = new System.Drawing.Size(1505, 27);
            this.panel1.TabIndex = 320;
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
            this.groupBox1.Controls.Add(this.DtgList);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1481, 653);
            this.groupBox1.TabIndex = 321;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MALZEME TALEP LİSTESİ";
            // 
            // DtgList
            // 
            this.DtgList.AllowUserToAddRows = false;
            this.DtgList.AllowUserToDeleteRows = false;
            this.DtgList.AutoGenerateContextFilters = true;
            this.DtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgList.DateWithTime = false;
            this.DtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtgList.Location = new System.Drawing.Point(3, 16);
            this.DtgList.MultiSelect = false;
            this.DtgList.Name = "DtgList";
            this.DtgList.ReadOnly = true;
            this.DtgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgList.Size = new System.Drawing.Size(1475, 634);
            this.DtgList.TabIndex = 0;
            this.DtgList.TimeFilter = false;
            this.DtgList.SortStringChanged += new System.EventHandler(this.DtgList_SortStringChanged);
            this.DtgList.FilterStringChanged += new System.EventHandler(this.DtgList_FilterStringChanged);
            this.DtgList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DtgList_CellMouseClick);
            // 
            // TxtTop
            // 
            this.TxtTop.AutoSize = true;
            this.TxtTop.Location = new System.Drawing.Point(158, 703);
            this.TxtTop.Name = "TxtTop";
            this.TxtTop.Size = new System.Drawing.Size(19, 13);
            this.TxtTop.TabIndex = 339;
            this.TxtTop.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 701);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 15);
            this.label1.TabIndex = 338;
            this.label1.Text = "Genel Kayıt Toplamı:";
            // 
            // TxtMiktar
            // 
            this.TxtMiktar.AutoSize = true;
            this.TxtMiktar.Location = new System.Drawing.Point(345, 705);
            this.TxtMiktar.Name = "TxtMiktar";
            this.TxtMiktar.Size = new System.Drawing.Size(19, 13);
            this.TxtMiktar.TabIndex = 341;
            this.TxtMiktar.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(236, 703);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 340;
            this.label4.Text = "Toplam Miktar:";
            // 
            // BtnOnayla
            // 
            this.BtnOnayla.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnOnayla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOnayla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnOnayla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOnayla.ImageKey = "ok.png";
            this.BtnOnayla.ImageList = this.ımageList1;
            this.BtnOnayla.Location = new System.Drawing.Point(15, 734);
            this.BtnOnayla.Name = "BtnOnayla";
            this.BtnOnayla.Size = new System.Drawing.Size(123, 51);
            this.BtnOnayla.TabIndex = 342;
            this.BtnOnayla.Text = "  ONAYLA";
            this.BtnOnayla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOnayla.UseVisualStyleBackColor = false;
            this.BtnOnayla.Click += new System.EventHandler(this.BtnOnayla_Click);
            // 
            // BtnTumunuOnayla
            // 
            this.BtnTumunuOnayla.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnTumunuOnayla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTumunuOnayla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTumunuOnayla.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTumunuOnayla.ImageKey = "Icojam-Blue-Bits-Database-check.ico";
            this.BtnTumunuOnayla.ImageList = this.ımageList2;
            this.BtnTumunuOnayla.Location = new System.Drawing.Point(144, 734);
            this.BtnTumunuOnayla.Name = "BtnTumunuOnayla";
            this.BtnTumunuOnayla.Size = new System.Drawing.Size(160, 51);
            this.BtnTumunuOnayla.TabIndex = 343;
            this.BtnTumunuOnayla.Text = "TÜMÜNÜ ONAYLA";
            this.BtnTumunuOnayla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTumunuOnayla.UseVisualStyleBackColor = false;
            this.BtnTumunuOnayla.Click += new System.EventHandler(this.BtnTumunuOnayla_Click);
            // 
            // BtnReddet
            // 
            this.BtnReddet.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnReddet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReddet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnReddet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReddet.ImageKey = "delete-sign.png";
            this.BtnReddet.ImageList = this.ımageList2;
            this.BtnReddet.Location = new System.Drawing.Point(310, 734);
            this.BtnReddet.Name = "BtnReddet";
            this.BtnReddet.Size = new System.Drawing.Size(123, 51);
            this.BtnReddet.TabIndex = 344;
            this.BtnReddet.Text = "    REDDET";
            this.BtnReddet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReddet.UseVisualStyleBackColor = false;
            this.BtnReddet.Click += new System.EventHandler(this.BtnReddet_Click);
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
            // FrmMifOnay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1505, 806);
            this.Controls.Add(this.BtnReddet);
            this.Controls.Add(this.BtnTumunuOnayla);
            this.Controls.Add(this.BtnOnayla);
            this.Controls.Add(this.TxtMiktar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtTop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMifOnay";
            this.Text = "FrmMifOnay";
            this.Load += new System.EventHandler(this.FrmMifOnay_Load);
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
        private System.Windows.Forms.BindingSource dataBinder;
        private System.Windows.Forms.Label TxtTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TxtMiktar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnOnayla;
        private System.Windows.Forms.Button BtnTumunuOnayla;
        private System.Windows.Forms.Button BtnReddet;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.ImageList ımageList2;
    }
}