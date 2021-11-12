
namespace UserInterface
{
    partial class FrmYonetim
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.BtnYetkilendir = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.ChkListele = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(602, 32);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(232, 473);
            this.treeView1.TabIndex = 0;
            // 
            // BtnYetkilendir
            // 
            this.BtnYetkilendir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnYetkilendir.Location = new System.Drawing.Point(343, 249);
            this.BtnYetkilendir.Name = "BtnYetkilendir";
            this.BtnYetkilendir.Size = new System.Drawing.Size(134, 47);
            this.BtnYetkilendir.TabIndex = 2;
            this.BtnYetkilendir.Text = "YETKİLENDİR";
            this.BtnYetkilendir.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(285, 98);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(267, 23);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "DEPARTMANLAR";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "VERİ İZLEME EKRANI",
            "VERİ GİRİŞ EKRANI"});
            this.comboBox2.Location = new System.Drawing.Point(285, 142);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(267, 23);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.Text = "VERİ EKRANI TÜRÜ";
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(285, 58);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(267, 23);
            this.comboBox3.TabIndex = 5;
            this.comboBox3.Text = "PERSONELLER";
            // 
            // ChkListele
            // 
            this.ChkListele.FormattingEnabled = true;
            this.ChkListele.Location = new System.Drawing.Point(12, 36);
            this.ChkListele.Name = "ChkListele";
            this.ChkListele.Size = new System.Drawing.Size(232, 469);
            this.ChkListele.TabIndex = 7;
            this.ChkListele.SelectedIndexChanged += new System.EventHandler(this.ChkListele_SelectedIndexChanged);
            // 
            // FrmYonetim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 532);
            this.Controls.Add(this.ChkListele);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BtnYetkilendir);
            this.Controls.Add(this.treeView1);
            this.Name = "FrmYonetim";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yönetim Paneli";
            this.Load += new System.EventHandler(this.FrmYonetim_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button BtnYetkilendir;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.CheckedListBox ChkListele;
    }
}