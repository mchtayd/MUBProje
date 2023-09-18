namespace UserInterface.IdariIsler
{
    partial class FrmFazlaCalismaOnay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFazlaCalismaOnay));
            this.TxtTopAmir = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.DtgListAmir = new ADGV.AdvancedDataGridView();
            this.ımageList3 = new System.Windows.Forms.ImageList(this.components);
            this.ımageList2 = new System.Windows.Forms.ImageList(this.components);
            this.BtnAmirRed = new System.Windows.Forms.Button();
            this.BtnAmirOnay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgListAmir)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtTopAmir
            // 
            this.TxtTopAmir.AutoSize = true;
            this.TxtTopAmir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTopAmir.Location = new System.Drawing.Point(109, 413);
            this.TxtTopAmir.Name = "TxtTopAmir";
            this.TxtTopAmir.Size = new System.Drawing.Size(21, 15);
            this.TxtTopAmir.TabIndex = 359;
            this.TxtTopAmir.Text = "00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(9, 413);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 15);
            this.label14.TabIndex = 358;
            this.label14.Text = "Toplam Kayıt:";
            // 
            // DtgListAmir
            // 
            this.DtgListAmir.AllowUserToAddRows = false;
            this.DtgListAmir.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DtgListAmir.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DtgListAmir.AutoGenerateContextFilters = true;
            this.DtgListAmir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DtgListAmir.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DtgListAmir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgListAmir.Cursor = System.Windows.Forms.Cursors.Default;
            this.DtgListAmir.DateWithTime = false;
            this.DtgListAmir.Location = new System.Drawing.Point(12, 52);
            this.DtgListAmir.Name = "DtgListAmir";
            this.DtgListAmir.ReadOnly = true;
            this.DtgListAmir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtgListAmir.Size = new System.Drawing.Size(1029, 356);
            this.DtgListAmir.TabIndex = 357;
            this.DtgListAmir.TimeFilter = false;
            // 
            // ımageList3
            // 
            this.ımageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList3.ImageStream")));
            this.ımageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList3.Images.SetKeyName(0, "okey.png");
            this.ımageList3.Images.SetKeyName(1, "ok.png");
            // 
            // ımageList2
            // 
            this.ımageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList2.ImageStream")));
            this.ımageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList2.Images.SetKeyName(0, "allokey.ico");
            this.ımageList2.Images.SetKeyName(1, "delete-sign.png");
            this.ımageList2.Images.SetKeyName(2, "Icojam-Blue-Bits-Database-check.ico");
            // 
            // BtnAmirRed
            // 
            this.BtnAmirRed.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnAmirRed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAmirRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnAmirRed.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAmirRed.ImageKey = "delete-sign.png";
            this.BtnAmirRed.ImageList = this.ımageList2;
            this.BtnAmirRed.Location = new System.Drawing.Point(136, 444);
            this.BtnAmirRed.Name = "BtnAmirRed";
            this.BtnAmirRed.Size = new System.Drawing.Size(123, 51);
            this.BtnAmirRed.TabIndex = 361;
            this.BtnAmirRed.Text = "    REDDET";
            this.BtnAmirRed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAmirRed.UseVisualStyleBackColor = false;
            // 
            // BtnAmirOnay
            // 
            this.BtnAmirOnay.BackColor = System.Drawing.Color.CadetBlue;
            this.BtnAmirOnay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAmirOnay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnAmirOnay.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAmirOnay.ImageKey = "ok.png";
            this.BtnAmirOnay.ImageList = this.ımageList3;
            this.BtnAmirOnay.Location = new System.Drawing.Point(7, 444);
            this.BtnAmirOnay.Name = "BtnAmirOnay";
            this.BtnAmirOnay.Size = new System.Drawing.Size(123, 51);
            this.BtnAmirOnay.TabIndex = 360;
            this.BtnAmirOnay.Text = "  ONAYLA";
            this.BtnAmirOnay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAmirOnay.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1053, 27);
            this.panel1.TabIndex = 362;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.BtnCancel.Location = new System.Drawing.Point(12, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(35, 23);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "X";
            this.BtnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmFazlaCalismaOnay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 566);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnAmirRed);
            this.Controls.Add(this.BtnAmirOnay);
            this.Controls.Add(this.TxtTopAmir);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.DtgListAmir);
            this.Name = "FrmFazlaCalismaOnay";
            this.Text = "FrmFazlaCalismaOnay";
            ((System.ComponentModel.ISupportInitialize)(this.DtgListAmir)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TxtTopAmir;
        private System.Windows.Forms.Label label14;
        private ADGV.AdvancedDataGridView DtgListAmir;
        private System.Windows.Forms.ImageList ımageList3;
        private System.Windows.Forms.ImageList ımageList2;
        private System.Windows.Forms.Button BtnAmirRed;
        private System.Windows.Forms.Button BtnAmirOnay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
    }
}