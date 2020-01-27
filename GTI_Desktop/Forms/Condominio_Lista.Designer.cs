namespace GTI_Desktop.Forms {
    partial class Condominio_Lista {
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
            this.MainList = new System.Windows.Forms.ListBox();
            this.OKbutton = new System.Windows.Forms.ToolStripButton();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.tBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainList
            // 
            this.MainList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainList.FormattingEnabled = true;
            this.MainList.Location = new System.Drawing.Point(0, 0);
            this.MainList.Name = "MainList";
            this.MainList.Size = new System.Drawing.Size(367, 373);
            this.MainList.TabIndex = 3;
            // 
            // OKbutton
            // 
            this.OKbutton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.OKbutton.Image = global::GTI_Desktop.Properties.Resources.OK;
            this.OKbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(81, 22);
            this.OKbutton.Text = "Selecionar";
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // tBar
            // 
            this.tBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OKbutton});
            this.tBar.Location = new System.Drawing.Point(0, 373);
            this.tBar.Name = "tBar";
            this.tBar.Size = new System.Drawing.Size(367, 25);
            this.tBar.TabIndex = 2;
            this.tBar.Text = "toolStrip1";
            // 
            // Condominio_Lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 398);
            this.Controls.Add(this.MainList);
            this.Controls.Add(this.tBar);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 300);
            this.Name = "Condominio_Lista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista dos condomínios cadastrados";
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox MainList;
        private System.Windows.Forms.ToolStripButton OKbutton;
        private System.Windows.Forms.ToolStrip tBar;
    }
}