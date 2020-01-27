namespace GTI_Desktop.Forms {
    partial class Foto_Imovel {
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
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.FotoNumeroText = new System.Windows.Forms.ToolStripStatusLabel();
            this.HeaderToolStrip = new System.Windows.Forms.ToolStrip();
            this.AnteriorButton = new System.Windows.Forms.ToolStripButton();
            this.ProximoButton = new System.Windows.Forms.ToolStripButton();
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.StatusBar.SuspendLayout();
            this.HeaderToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FotoNumeroText});
            this.StatusBar.Location = new System.Drawing.Point(0, 399);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(710, 22);
            this.StatusBar.TabIndex = 0;
            this.StatusBar.Text = "statusStrip1";
            // 
            // FotoNumeroText
            // 
            this.FotoNumeroText.Name = "FotoNumeroText";
            this.FotoNumeroText.Size = new System.Drawing.Size(68, 17);
            this.FotoNumeroText.Text = "Foto: 0 de 0";
            // 
            // HeaderToolStrip
            // 
            this.HeaderToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.HeaderToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnteriorButton,
            this.ProximoButton});
            this.HeaderToolStrip.Location = new System.Drawing.Point(0, 0);
            this.HeaderToolStrip.Name = "HeaderToolStrip";
            this.HeaderToolStrip.Size = new System.Drawing.Size(710, 25);
            this.HeaderToolStrip.TabIndex = 1;
            this.HeaderToolStrip.Text = "toolStrip1";
            // 
            // AnteriorButton
            // 
            this.AnteriorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AnteriorButton.Image = global::GTI_Desktop.Properties.Resources.leftarrow;
            this.AnteriorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AnteriorButton.Name = "AnteriorButton";
            this.AnteriorButton.Size = new System.Drawing.Size(23, 22);
            this.AnteriorButton.Text = "toolStripButton1";
            this.AnteriorButton.ToolTipText = "Foto anterior";
            this.AnteriorButton.Click += new System.EventHandler(this.AnteriorButton_Click);
            // 
            // ProximoButton
            // 
            this.ProximoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ProximoButton.Image = global::GTI_Desktop.Properties.Resources.rightarrow;
            this.ProximoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProximoButton.Name = "ProximoButton";
            this.ProximoButton.Size = new System.Drawing.Size(23, 22);
            this.ProximoButton.Text = "toolStripButton2";
            this.ProximoButton.ToolTipText = "Próxima foto";
            this.ProximoButton.Click += new System.EventHandler(this.ProximoButton_Click);
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPictureBox.Location = new System.Drawing.Point(0, 25);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(710, 374);
            this.MainPictureBox.TabIndex = 2;
            this.MainPictureBox.TabStop = false;
            // 
            // Foto_Imovel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 421);
            this.Controls.Add(this.MainPictureBox);
            this.Controls.Add(this.HeaderToolStrip);
            this.Controls.Add(this.StatusBar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1148, 686);
            this.MinimumSize = new System.Drawing.Size(580, 351);
            this.Name = "Foto_Imovel";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Foto(s) do imóvel";
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.HeaderToolStrip.ResumeLayout(false);
            this.HeaderToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel FotoNumeroText;
        private System.Windows.Forms.ToolStrip HeaderToolStrip;
        private System.Windows.Forms.ToolStripButton AnteriorButton;
        private System.Windows.Forms.ToolStripButton ProximoButton;
        private System.Windows.Forms.PictureBox MainPictureBox;
    }
}