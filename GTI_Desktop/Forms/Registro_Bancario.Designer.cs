namespace GTI_Desktop.Forms {
    partial class Registro_Bancario {
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
            this.CalcularButton = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.TipoList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CalcularButton
            // 
            this.CalcularButton.ForeColor = System.Drawing.Color.Navy;
            this.CalcularButton.Image = global::GTI_Desktop.Properties.Resources.download;
            this.CalcularButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CalcularButton.Location = new System.Drawing.Point(230, 73);
            this.CalcularButton.Name = "CalcularButton";
            this.CalcularButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.CalcularButton.Size = new System.Drawing.Size(71, 24);
            this.CalcularButton.TabIndex = 38;
            this.CalcularButton.Text = "Gerar  ";
            this.CalcularButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CalcularButton.UseVisualStyleBackColor = true;
            this.CalcularButton.Click += new System.EventHandler(this.CalcularButton_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(94, 13);
            this.Label1.TabIndex = 39;
            this.Label1.Text = "Tipo de Registro..:";
            // 
            // TipoList
            // 
            this.TipoList.FormattingEnabled = true;
            this.TipoList.Items.AddRange(new object[] {
            "01 - CARTA DE COBRANÇA",
            "02 - IPTU",
            "03 - ISS/TAXA DE LICENÇA",
            "04 - VIGILÂNIA SANITÁRIA",
            "05 - CIP"});
            this.TipoList.Location = new System.Drawing.Point(112, 25);
            this.TipoList.Name = "TipoList";
            this.TipoList.Size = new System.Drawing.Size(189, 21);
            this.TipoList.TabIndex = 40;
            // 
            // Registro_Bancario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 121);
            this.Controls.Add(this.TipoList);
            this.Controls.Add(this.CalcularButton);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Registro_Bancario";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Bancário";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CalcularButton;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ComboBox TipoList;
    }
}