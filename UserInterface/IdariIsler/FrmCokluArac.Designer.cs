
namespace UserInterface.IdariIsler
{
    partial class FrmCokluArac
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
            this.DtgAracList = new System.Windows.Forms.DataGridView();
            this.LblToplamKm = new System.Windows.Forms.Label();
            this.LblTop = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgAracList)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgAracList
            // 
            this.DtgAracList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgAracList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgAracList.Location = new System.Drawing.Point(12, 12);
            this.DtgAracList.Name = "DtgAracList";
            this.DtgAracList.Size = new System.Drawing.Size(820, 246);
            this.DtgAracList.TabIndex = 0;
            // 
            // LblToplamKm
            // 
            this.LblToplamKm.AutoSize = true;
            this.LblToplamKm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblToplamKm.Location = new System.Drawing.Point(769, 273);
            this.LblToplamKm.Name = "LblToplamKm";
            this.LblToplamKm.Size = new System.Drawing.Size(23, 15);
            this.LblToplamKm.TabIndex = 440;
            this.LblToplamKm.Text = "00";
            this.LblToplamKm.UseWaitCursor = true;
            // 
            // LblTop
            // 
            this.LblTop.AutoSize = true;
            this.LblTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTop.Location = new System.Drawing.Point(689, 273);
            this.LblTop.Name = "LblTop";
            this.LblTop.Size = new System.Drawing.Size(74, 15);
            this.LblTop.TabIndex = 439;
            this.LblTop.Text = "Toplam Km:";
            this.LblTop.UseWaitCursor = true;
            // 
            // FrmCokluArac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 311);
            this.Controls.Add(this.LblToplamKm);
            this.Controls.Add(this.LblTop);
            this.Controls.Add(this.DtgAracList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCokluArac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Çoklu Araç Bilgisi";
            this.Load += new System.EventHandler(this.FrmCokluArac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgAracList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgAracList;
        private System.Windows.Forms.Label LblToplamKm;
        private System.Windows.Forms.Label LblTop;
    }
}