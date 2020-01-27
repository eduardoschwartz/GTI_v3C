namespace GTI_Desktop.Forms {
    partial class Emissao_Guia {
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
            this.components = new System.ComponentModel.Container();
            this.DocText = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.NomeText = new System.Windows.Forms.TextBox();
            this.ConsultarCodigoButton = new System.Windows.Forms.Button();
            this.CodigoText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.LoteText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.QuadraText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.UFText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CidadeText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CepText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.InscricaoText = new System.Windows.Forms.TextBox();
            this.BairroText = new System.Windows.Forms.TextBox();
            this.EnderecoText = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.UFEntText = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CidadeEntText = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CepEntText = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.BairroEntText = new System.Windows.Forms.TextBox();
            this.EnderecoEntText = new System.Windows.Forms.TextBox();
            this.HeaderMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ImovelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmpresaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CidadaoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.HeaderMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DocText
            // 
            this.DocText.BackColor = System.Drawing.Color.Linen;
            this.DocText.Location = new System.Drawing.Point(378, 36);
            this.DocText.Name = "DocText";
            this.DocText.ReadOnly = true;
            this.DocText.Size = new System.Drawing.Size(133, 20);
            this.DocText.TabIndex = 47;
            this.DocText.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Linen;
            this.Label1.Location = new System.Drawing.Point(6, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(55, 13);
            this.Label1.TabIndex = 46;
            this.Label1.Text = "Código....:";
            // 
            // NomeText
            // 
            this.NomeText.BackColor = System.Drawing.Color.Linen;
            this.NomeText.Location = new System.Drawing.Point(9, 36);
            this.NomeText.Name = "NomeText";
            this.NomeText.ReadOnly = true;
            this.NomeText.Size = new System.Drawing.Size(363, 20);
            this.NomeText.TabIndex = 36;
            this.NomeText.TabStop = false;
            // 
            // ConsultarCodigoButton
            // 
            this.ConsultarCodigoButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.ConsultarCodigoButton.Location = new System.Drawing.Point(132, 12);
            this.ConsultarCodigoButton.Name = "ConsultarCodigoButton";
            this.ConsultarCodigoButton.Size = new System.Drawing.Size(23, 22);
            this.ConsultarCodigoButton.TabIndex = 1;
            this.ConsultarCodigoButton.UseVisualStyleBackColor = true;
            this.ConsultarCodigoButton.Click += new System.EventHandler(this.ConsultarCodigoButton_Click);
            // 
            // CodigoText
            // 
            this.CodigoText.Location = new System.Drawing.Point(67, 13);
            this.CodigoText.MaxLength = 6;
            this.CodigoText.Name = "CodigoText";
            this.CodigoText.Size = new System.Drawing.Size(63, 20);
            this.CodigoText.TabIndex = 0;
            this.CodigoText.TextChanged += new System.EventHandler(this.CodigoText_TextChanged);
            this.CodigoText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodigoText_KeyDown);
            this.CodigoText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CodigoText_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Linen;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(395, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "Lote..:";
            // 
            // LoteText
            // 
            this.LoteText.BackColor = System.Drawing.Color.Linen;
            this.LoteText.Location = new System.Drawing.Point(438, 65);
            this.LoteText.Name = "LoteText";
            this.LoteText.ReadOnly = true;
            this.LoteText.Size = new System.Drawing.Size(73, 20);
            this.LoteText.TabIndex = 58;
            this.LoteText.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Linen;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(246, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "Quadra..:";
            // 
            // QuadraText
            // 
            this.QuadraText.BackColor = System.Drawing.Color.Linen;
            this.QuadraText.Location = new System.Drawing.Point(301, 65);
            this.QuadraText.Name = "QuadraText";
            this.QuadraText.ReadOnly = true;
            this.QuadraText.Size = new System.Drawing.Size(87, 20);
            this.QuadraText.TabIndex = 56;
            this.QuadraText.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Linen;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(443, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "UF....:";
            // 
            // UFText
            // 
            this.UFText.BackColor = System.Drawing.Color.Linen;
            this.UFText.Location = new System.Drawing.Point(485, 42);
            this.UFText.Name = "UFText";
            this.UFText.ReadOnly = true;
            this.UFText.Size = new System.Drawing.Size(26, 20);
            this.UFText.TabIndex = 54;
            this.UFText.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Linen;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(246, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Cidade..:";
            // 
            // CidadeText
            // 
            this.CidadeText.BackColor = System.Drawing.Color.Linen;
            this.CidadeText.Location = new System.Drawing.Point(301, 42);
            this.CidadeText.Name = "CidadeText";
            this.CidadeText.ReadOnly = true;
            this.CidadeText.Size = new System.Drawing.Size(128, 20);
            this.CidadeText.TabIndex = 52;
            this.CidadeText.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Linen;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(394, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Cep..:";
            // 
            // CepText
            // 
            this.CepText.BackColor = System.Drawing.Color.Linen;
            this.CepText.Location = new System.Drawing.Point(435, 19);
            this.CepText.Name = "CepText";
            this.CepText.ReadOnly = true;
            this.CepText.Size = new System.Drawing.Size(76, 20);
            this.CepText.TabIndex = 50;
            this.CepText.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Linen;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Inscrição....:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Linen;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Bairro.........:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Linen;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Endereço...:";
            // 
            // InscricaoText
            // 
            this.InscricaoText.BackColor = System.Drawing.Color.Linen;
            this.InscricaoText.Location = new System.Drawing.Point(78, 65);
            this.InscricaoText.Name = "InscricaoText";
            this.InscricaoText.ReadOnly = true;
            this.InscricaoText.Size = new System.Drawing.Size(156, 20);
            this.InscricaoText.TabIndex = 38;
            this.InscricaoText.TabStop = false;
            // 
            // BairroText
            // 
            this.BairroText.BackColor = System.Drawing.Color.Linen;
            this.BairroText.Location = new System.Drawing.Point(78, 42);
            this.BairroText.Name = "BairroText";
            this.BairroText.ReadOnly = true;
            this.BairroText.Size = new System.Drawing.Size(156, 20);
            this.BairroText.TabIndex = 37;
            this.BairroText.TabStop = false;
            // 
            // EnderecoText
            // 
            this.EnderecoText.BackColor = System.Drawing.Color.Linen;
            this.EnderecoText.Location = new System.Drawing.Point(78, 19);
            this.EnderecoText.Name = "EnderecoText";
            this.EnderecoText.ReadOnly = true;
            this.EnderecoText.Size = new System.Drawing.Size(310, 20);
            this.EnderecoText.TabIndex = 36;
            this.EnderecoText.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Linen;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(446, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 55;
            this.label13.Text = "UF....:";
            // 
            // UFEntText
            // 
            this.UFEntText.BackColor = System.Drawing.Color.Linen;
            this.UFEntText.Location = new System.Drawing.Point(485, 40);
            this.UFEntText.Name = "UFEntText";
            this.UFEntText.ReadOnly = true;
            this.UFEntText.Size = new System.Drawing.Size(26, 20);
            this.UFEntText.TabIndex = 54;
            this.UFEntText.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Linen;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(246, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 53;
            this.label14.Text = "Cidade..:";
            // 
            // CidadeEntText
            // 
            this.CidadeEntText.BackColor = System.Drawing.Color.Linen;
            this.CidadeEntText.Location = new System.Drawing.Point(298, 40);
            this.CidadeEntText.Name = "CidadeEntText";
            this.CidadeEntText.ReadOnly = true;
            this.CidadeEntText.Size = new System.Drawing.Size(131, 20);
            this.CidadeEntText.TabIndex = 52;
            this.CidadeEntText.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Linen;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(396, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 51;
            this.label15.Text = "Cep..:";
            // 
            // CepEntText
            // 
            this.CepEntText.BackColor = System.Drawing.Color.Linen;
            this.CepEntText.Location = new System.Drawing.Point(435, 17);
            this.CepEntText.Name = "CepEntText";
            this.CepEntText.ReadOnly = true;
            this.CepEntText.Size = new System.Drawing.Size(76, 20);
            this.CepEntText.TabIndex = 50;
            this.CepEntText.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Linen;
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(5, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 13);
            this.label17.TabIndex = 48;
            this.label17.Text = "Bairro.........:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Linen;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(5, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 13);
            this.label18.TabIndex = 47;
            this.label18.Text = "Endereço...:";
            // 
            // BairroEntText
            // 
            this.BairroEntText.BackColor = System.Drawing.Color.Linen;
            this.BairroEntText.Location = new System.Drawing.Point(75, 40);
            this.BairroEntText.Name = "BairroEntText";
            this.BairroEntText.ReadOnly = true;
            this.BairroEntText.Size = new System.Drawing.Size(159, 20);
            this.BairroEntText.TabIndex = 37;
            this.BairroEntText.TabStop = false;
            // 
            // EnderecoEntText
            // 
            this.EnderecoEntText.BackColor = System.Drawing.Color.Linen;
            this.EnderecoEntText.Location = new System.Drawing.Point(75, 17);
            this.EnderecoEntText.Name = "EnderecoEntText";
            this.EnderecoEntText.ReadOnly = true;
            this.EnderecoEntText.Size = new System.Drawing.Size(310, 20);
            this.EnderecoEntText.TabIndex = 36;
            this.EnderecoEntText.TabStop = false;
            // 
            // HeaderMenu
            // 
            this.HeaderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImovelMenuItem,
            this.EmpresaMenuItem,
            this.CidadaoMenuItem});
            this.HeaderMenu.Name = "HeaderMenu";
            this.HeaderMenu.Size = new System.Drawing.Size(120, 70);
            // 
            // ImovelMenuItem
            // 
            this.ImovelMenuItem.Image = global::GTI_Desktop.Properties.Resources.Home;
            this.ImovelMenuItem.Name = "ImovelMenuItem";
            this.ImovelMenuItem.Size = new System.Drawing.Size(119, 22);
            this.ImovelMenuItem.Text = "Imóvel";
            this.ImovelMenuItem.Click += new System.EventHandler(this.ImovelMenuItem_Click);
            // 
            // EmpresaMenuItem
            // 
            this.EmpresaMenuItem.Image = global::GTI_Desktop.Properties.Resources.fabrica;
            this.EmpresaMenuItem.Name = "EmpresaMenuItem";
            this.EmpresaMenuItem.Size = new System.Drawing.Size(119, 22);
            this.EmpresaMenuItem.Text = "Empresa";
            this.EmpresaMenuItem.Click += new System.EventHandler(this.EmpresaMenuItem_Click);
            // 
            // CidadaoMenuItem
            // 
            this.CidadaoMenuItem.Image = global::GTI_Desktop.Properties.Resources.Pessoas;
            this.CidadaoMenuItem.Name = "CidadaoMenuItem";
            this.CidadaoMenuItem.Size = new System.Drawing.Size(119, 22);
            this.CidadaoMenuItem.Text = "Cidadão";
            this.CidadaoMenuItem.Click += new System.EventHandler(this.CidadaoMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DocText);
            this.groupBox1.Controls.Add(this.CodigoText);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.ConsultarCodigoButton);
            this.groupBox1.Controls.Add(this.NomeText);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 66);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.InscricaoText);
            this.groupBox2.Controls.Add(this.LoteText);
            this.groupBox2.Controls.Add(this.EnderecoText);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.BairroText);
            this.groupBox2.Controls.Add(this.QuadraText);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.UFText);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.CepText);
            this.groupBox2.Controls.Add(this.CidadeText);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox2.Location = new System.Drawing.Point(4, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 95);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Endereço de Localização";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.BairroEntText);
            this.groupBox3.Controls.Add(this.UFEntText);
            this.groupBox3.Controls.Add(this.EnderecoEntText);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.CidadeEntText);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.CepEntText);
            this.groupBox3.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox3.Location = new System.Drawing.Point(4, 168);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(520, 70);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Entrega de Entrega";
            // 
            // Emissao_Guia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(529, 241);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Emissao_Guia";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emissão de guia";
            this.HeaderMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox DocText;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox NomeText;
        private System.Windows.Forms.Button ConsultarCodigoButton;
        private System.Windows.Forms.TextBox CodigoText;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox InscricaoText;
        private System.Windows.Forms.TextBox BairroText;
        private System.Windows.Forms.TextBox EnderecoText;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox LoteText;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox QuadraText;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox UFText;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CidadeText;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CepText;
        internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox UFEntText;
        internal System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox CidadeEntText;
        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox CepEntText;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox BairroEntText;
        private System.Windows.Forms.TextBox EnderecoEntText;
        private System.Windows.Forms.ContextMenuStrip HeaderMenu;
        private System.Windows.Forms.ToolStripMenuItem ImovelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EmpresaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CidadaoMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}