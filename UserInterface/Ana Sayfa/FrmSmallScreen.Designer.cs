namespace UserInterface.Ana_Sayfa
{
    partial class FrmSmallScreen
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
            this.tabAnasayfa = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tabAnasayfa
            // 
            this.tabAnasayfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabAnasayfa.Location = new System.Drawing.Point(0, -3);
            this.tabAnasayfa.Name = "tabAnasayfa";
            this.tabAnasayfa.Padding = new System.Drawing.Point(15, 10);
            this.tabAnasayfa.SelectedIndex = 0;
            this.tabAnasayfa.Size = new System.Drawing.Size(1364, 697);
            this.tabAnasayfa.TabIndex = 88;
            this.tabAnasayfa.Visible = false;
            // 
            // FrmSmallScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 692);
            this.Controls.Add(this.tabAnasayfa);
            this.Name = "FrmSmallScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmSmallScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSmallScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabAnasayfa;
    }
}