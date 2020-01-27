namespace GTI_Desktop.Forms {
    partial class Usuario_Setor {
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
            this.SetorComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GravarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SetorComboBox
            // 
            this.SetorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SetorComboBox.FormattingEnabled = true;
            this.SetorComboBox.Location = new System.Drawing.Point(12, 40);
            this.SetorComboBox.Name = "SetorComboBox";
            this.SetorComboBox.Size = new System.Drawing.Size(410, 21);
            this.SetorComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Informe o local atual em que esta trabalhando.";
            // 
            // GravarButton
            // 
            this.GravarButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GravarButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GravarButton.Image = global::GTI_Desktop.Properties.Resources.gravar;
            this.GravarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GravarButton.Location = new System.Drawing.Point(268, 74);
            this.GravarButton.Name = "GravarButton";
            this.GravarButton.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.GravarButton.Size = new System.Drawing.Size(74, 22);
            this.GravarButton.TabIndex = 157;
            this.GravarButton.Text = "&Gravar ";
            this.GravarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GravarButton.UseVisualStyleBackColor = true;
            this.GravarButton.Click += new System.EventHandler(this.GravarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelarButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CancelarButton.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.CancelarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelarButton.Location = new System.Drawing.Point(348, 74);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(74, 22);
            this.CancelarButton.TabIndex = 158;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // Usuario_Setor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 108);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GravarButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SetorComboBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Usuario_Setor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informação necessária";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SetorComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GravarButton;
        private System.Windows.Forms.Button CancelarButton;
    }
}