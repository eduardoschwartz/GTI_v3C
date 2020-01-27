namespace GTI_Desktop.Forms {
    partial class Carta_Cobranca {
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
            this.CodigoInicio = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.CodigoFinal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CalcularButton = new System.Windows.Forms.Button();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.DataVencto = new System.Windows.Forms.MaskedTextBox();
            this.PrintButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CodigoInicio
            // 
            this.CodigoInicio.Location = new System.Drawing.Point(90, 21);
            this.CodigoInicio.MaxLength = 6;
            this.CodigoInicio.Name = "CodigoInicio";
            this.CodigoInicio.Size = new System.Drawing.Size(63, 20);
            this.CodigoInicio.TabIndex = 0;
            this.CodigoInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CodigoInicioText_KeyPress);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(70, 13);
            this.Label1.TabIndex = 37;
            this.Label1.Text = "Código de....:";
            // 
            // CodigoFinal
            // 
            this.CodigoFinal.Location = new System.Drawing.Point(196, 21);
            this.CodigoFinal.MaxLength = 6;
            this.CodigoFinal.Name = "CodigoFinal";
            this.CodigoFinal.Size = new System.Drawing.Size(63, 20);
            this.CodigoFinal.TabIndex = 1;
            this.CodigoFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CodigoFinalText_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Até:";
            // 
            // CalcularButton
            // 
            this.CalcularButton.ForeColor = System.Drawing.Color.Navy;
            this.CalcularButton.Image = global::GTI_Desktop.Properties.Resources.download;
            this.CalcularButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CalcularButton.Location = new System.Drawing.Point(266, 52);
            this.CalcularButton.Name = "CalcularButton";
            this.CalcularButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.CalcularButton.Size = new System.Drawing.Size(76, 24);
            this.CalcularButton.TabIndex = 3;
            this.CalcularButton.Text = "Calcular";
            this.CalcularButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CalcularButton.UseVisualStyleBackColor = true;
            this.CalcularButton.Click += new System.EventHandler(this.CalcularButton_Click);
            // 
            // PBar
            // 
            this.PBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.PBar.Location = new System.Drawing.Point(11, 95);
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(230, 8);
            this.PBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PBar.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Vencidos até:";
            // 
            // DataVencto
            // 
            this.DataVencto.Location = new System.Drawing.Point(90, 49);
            this.DataVencto.Mask = "99/99/9999";
            this.DataVencto.Name = "DataVencto";
            this.DataVencto.Size = new System.Drawing.Size(74, 20);
            this.DataVencto.TabIndex = 2;
            // 
            // PrintButton
            // 
            this.PrintButton.ForeColor = System.Drawing.Color.Navy;
            this.PrintButton.Image = global::GTI_Desktop.Properties.Resources.print;
            this.PrintButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PrintButton.Location = new System.Drawing.Point(266, 82);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.PrintButton.Size = new System.Drawing.Size(76, 24);
            this.PrintButton.TabIndex = 43;
            this.PrintButton.Text = "Imprimir";
            this.PrintButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // Carta_Cobranca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 115);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.DataVencto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PBar);
            this.Controls.Add(this.CalcularButton);
            this.Controls.Add(this.CodigoFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CodigoInicio);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Carta_Cobranca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Geração de dados para carta de cobrança";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Carta_Cobranca_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CodigoInicio;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox CodigoFinal;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CalcularButton;
        private System.Windows.Forms.ProgressBar PBar;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox DataVencto;
        private System.Windows.Forms.Button PrintButton;
    }
}