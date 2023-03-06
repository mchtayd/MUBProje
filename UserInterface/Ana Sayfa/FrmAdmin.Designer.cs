
namespace UserInterface
{
    partial class FrmAdmin
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
            this.ChcListBoxYetkiler = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnYetki = new System.Windows.Forms.ComboBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnTumYetki = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChcListBoxYetkiler
            // 
            this.ChcListBoxYetkiler.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChcListBoxYetkiler.FormattingEnabled = true;
            this.ChcListBoxYetkiler.Location = new System.Drawing.Point(15, 72);
            this.ChcListBoxYetkiler.Name = "ChcListBoxYetkiler";
            this.ChcListBoxYetkiler.Size = new System.Drawing.Size(387, 529);
            this.ChcListBoxYetkiler.TabIndex = 0;
            this.ChcListBoxYetkiler.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ChcListBoxYetkiler_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "YETKİ VER:";
            // 
            // BtnYetki
            // 
            this.BtnYetki.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BtnYetki.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnYetki.FormattingEnabled = true;
            this.BtnYetki.Location = new System.Drawing.Point(429, 81);
            this.BtnYetki.Name = "BtnYetki";
            this.BtnYetki.Size = new System.Drawing.Size(273, 23);
            this.BtnYetki.TabIndex = 3;
            this.BtnYetki.SelectedValueChanged += new System.EventHandler(this.cmbYetkiler_SelectedValueChanged);
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSave.Location = new System.Drawing.Point(487, 119);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(157, 43);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "Güncelle";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnTumYetki
            // 
            this.BtnTumYetki.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTumYetki.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTumYetki.Location = new System.Drawing.Point(94, 25);
            this.BtnTumYetki.Name = "BtnTumYetki";
            this.BtnTumYetki.Size = new System.Drawing.Size(92, 25);
            this.BtnTumYetki.TabIndex = 7;
            this.BtnTumYetki.Text = "Tüm Yetki";
            this.BtnTumYetki.UseVisualStyleBackColor = true;
            this.BtnTumYetki.Click += new System.EventHandler(this.BtnTumYetki_Click);
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 613);
            this.Controls.Add(this.BtnTumYetki);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnYetki);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChcListBoxYetkiler);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.FrmAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ChcListBoxYetkiler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BtnYetki;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnTumYetki;
    }
}