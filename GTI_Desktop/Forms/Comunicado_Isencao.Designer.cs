namespace GTI_Desktop.Forms {
    partial class Comunicado_Isencao {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.PrintButton = new System.Windows.Forms.Button();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // PrintButton
            // 
            this.PrintButton.ForeColor = System.Drawing.Color.Navy;
            this.PrintButton.Image = global::GTI_Desktop.Properties.Resources.print;
            this.PrintButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PrintButton.Location = new System.Drawing.Point(228, 24);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.PrintButton.Size = new System.Drawing.Size(76, 24);
            this.PrintButton.TabIndex = 44;
            this.PrintButton.Text = "Imprimir";
            this.PrintButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // PBar
            // 
            this.PBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.PBar.Location = new System.Drawing.Point(12, 40);
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(197, 8);
            this.PBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PBar.TabIndex = 45;
            // 
            // Comunicado_Isencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 60);
            this.Controls.Add(this.PBar);
            this.Controls.Add(this.PrintButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Comunicado_Isencao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comunicado Isenção";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.ProgressBar PBar;
    }
}