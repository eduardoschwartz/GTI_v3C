namespace GTI_Desktop.Forms {
    partial class RptViewer {
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
            this.CrystalViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrystalViewer
            // 
            this.CrystalViewer.ActiveViewIndex = -1;
            this.CrystalViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrystalViewer.Location = new System.Drawing.Point(0, 0);
            this.CrystalViewer.Name = "CrystalViewer";
            this.CrystalViewer.Size = new System.Drawing.Size(721, 429);
            this.CrystalViewer.TabIndex = 0;
            // 
            // RptViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 429);
            this.Controls.Add(this.CrystalViewer);
            this.Name = "RptViewer";
            this.Text = "RptViewer";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalViewer;
    }
}