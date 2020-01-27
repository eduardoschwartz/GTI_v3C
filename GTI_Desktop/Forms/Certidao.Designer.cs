namespace GTI_Desktop.Forms {
    partial class Certidao {
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
            this.a1Panel1 = new Owf.Controls.A1Panel();
            this.TBar = new System.Windows.Forms.ToolStrip();
            this.VerificarButton = new System.Windows.Forms.ToolStripButton();
            this.ImprimirButton = new System.Windows.Forms.ToolStripButton();
            this.Assinatura = new System.Windows.Forms.CheckBox();
            this.TipoList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Processo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.a1Panel2 = new Owf.Controls.A1Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.Doc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Inscricao = new System.Windows.Forms.TextBox();
            this.Atividade = new System.Windows.Forms.TextBox();
            this.Lote = new System.Windows.Forms.TextBox();
            this.Quadra = new System.Windows.Forms.TextBox();
            this.Cep = new System.Windows.Forms.TextBox();
            this.Cidade = new System.Windows.Forms.TextBox();
            this.Bairro = new System.Windows.Forms.TextBox();
            this.Endereco = new System.Windows.Forms.TextBox();
            this.Nome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.a1Panel1.SuspendLayout();
            this.TBar.SuspendLayout();
            this.a1Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // a1Panel1
            // 
            this.a1Panel1.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel1.Controls.Add(this.TBar);
            this.a1Panel1.Controls.Add(this.Assinatura);
            this.a1Panel1.Controls.Add(this.TipoList);
            this.a1Panel1.Controls.Add(this.label3);
            this.a1Panel1.Controls.Add(this.Processo);
            this.a1Panel1.Controls.Add(this.label2);
            this.a1Panel1.Controls.Add(this.Codigo);
            this.a1Panel1.Controls.Add(this.label1);
            this.a1Panel1.GradientEndColor = System.Drawing.SystemColors.Control;
            this.a1Panel1.GradientStartColor = System.Drawing.SystemColors.Control;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(4, 4);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.RoundCornerRadius = 8;
            this.a1Panel1.ShadowOffSet = 4;
            this.a1Panel1.Size = new System.Drawing.Size(489, 77);
            this.a1Panel1.TabIndex = 0;
            // 
            // TBar
            // 
            this.TBar.Dock = System.Windows.Forms.DockStyle.None;
            this.TBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerificarButton,
            this.ImprimirButton});
            this.TBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.TBar.Location = new System.Drawing.Point(400, 15);
            this.TBar.Name = "TBar";
            this.TBar.Size = new System.Drawing.Size(74, 48);
            this.TBar.TabIndex = 7;
            this.TBar.TabStop = true;
            this.TBar.Text = "toolStrip1";
            // 
            // VerificarButton
            // 
            this.VerificarButton.Image = global::GTI_Desktop.Properties.Resources.OK;
            this.VerificarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.VerificarButton.Name = "VerificarButton";
            this.VerificarButton.Size = new System.Drawing.Size(72, 20);
            this.VerificarButton.Text = "&Verificar";
            this.VerificarButton.ToolTipText = "Verificar a disponibilidade da certidão";
            this.VerificarButton.Click += new System.EventHandler(this.VerificarButton_Click);
            // 
            // ImprimirButton
            // 
            this.ImprimirButton.Image = global::GTI_Desktop.Properties.Resources.print;
            this.ImprimirButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImprimirButton.Name = "ImprimirButton";
            this.ImprimirButton.Size = new System.Drawing.Size(72, 20);
            this.ImprimirButton.Text = "&Imprimir";
            this.ImprimirButton.ToolTipText = "Imprimir a certidão";
            this.ImprimirButton.Click += new System.EventHandler(this.ImprimirButton_Click);
            // 
            // Assinatura
            // 
            this.Assinatura.AutoSize = true;
            this.Assinatura.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Assinatura.Location = new System.Drawing.Point(256, 40);
            this.Assinatura.Name = "Assinatura";
            this.Assinatura.Size = new System.Drawing.Size(121, 17);
            this.Assinatura.TabIndex = 6;
            this.Assinatura.Text = "Ocultar Assinatura..:";
            this.Assinatura.UseVisualStyleBackColor = true;
            // 
            // TipoList
            // 
            this.TipoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoList.FormattingEnabled = true;
            this.TipoList.Items.AddRange(new object[] {
            "Débito",
            "Endereço",
            "Isenção",
            "Valor Venal"});
            this.TipoList.Location = new System.Drawing.Point(119, 38);
            this.TipoList.Name = "TipoList";
            this.TipoList.Size = new System.Drawing.Size(120, 21);
            this.TipoList.TabIndex = 5;
            this.TipoList.SelectedIndexChanged += new System.EventHandler(this.TipoList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de Certidão...:";
            // 
            // Processo
            // 
            this.Processo.Location = new System.Drawing.Point(292, 12);
            this.Processo.MaxLength = 12;
            this.Processo.Name = "Processo";
            this.Processo.Size = new System.Drawing.Size(85, 20);
            this.Processo.TabIndex = 3;
            this.Processo.TextChanged += new System.EventHandler(this.Processo_TextChanged);
            this.Processo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Processo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nº do Processo..:";
            // 
            // Codigo
            // 
            this.Codigo.Location = new System.Drawing.Point(119, 12);
            this.Codigo.MaxLength = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(63, 20);
            this.Codigo.TabIndex = 1;
            this.Codigo.TextChanged += new System.EventHandler(this.Codigo_TextChanged);
            this.Codigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Codigo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código/Inscrição..:";
            // 
            // a1Panel2
            // 
            this.a1Panel2.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel2.Controls.Add(this.label6);
            this.a1Panel2.Controls.Add(this.Doc);
            this.a1Panel2.Controls.Add(this.label13);
            this.a1Panel2.Controls.Add(this.label12);
            this.a1Panel2.Controls.Add(this.label11);
            this.a1Panel2.Controls.Add(this.label10);
            this.a1Panel2.Controls.Add(this.label9);
            this.a1Panel2.Controls.Add(this.label8);
            this.a1Panel2.Controls.Add(this.label7);
            this.a1Panel2.Controls.Add(this.label4);
            this.a1Panel2.Controls.Add(this.Inscricao);
            this.a1Panel2.Controls.Add(this.Atividade);
            this.a1Panel2.Controls.Add(this.Lote);
            this.a1Panel2.Controls.Add(this.Quadra);
            this.a1Panel2.Controls.Add(this.Cep);
            this.a1Panel2.Controls.Add(this.Cidade);
            this.a1Panel2.Controls.Add(this.Bairro);
            this.a1Panel2.Controls.Add(this.Endereco);
            this.a1Panel2.Controls.Add(this.Nome);
            this.a1Panel2.Controls.Add(this.label5);
            this.a1Panel2.GradientEndColor = System.Drawing.SystemColors.Control;
            this.a1Panel2.GradientStartColor = System.Drawing.SystemColors.Control;
            this.a1Panel2.Image = null;
            this.a1Panel2.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel2.Location = new System.Drawing.Point(4, 82);
            this.a1Panel2.Name = "a1Panel2";
            this.a1Panel2.RoundCornerRadius = 8;
            this.a1Panel2.ShadowOffSet = 4;
            this.a1Panel2.Size = new System.Drawing.Size(489, 165);
            this.a1Panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(273, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "CPF/CNPJ..:";
            // 
            // Doc
            // 
            this.Doc.BackColor = System.Drawing.SystemColors.Control;
            this.Doc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Doc.ForeColor = System.Drawing.Color.Navy;
            this.Doc.Location = new System.Drawing.Point(342, 134);
            this.Doc.Name = "Doc";
            this.Doc.ReadOnly = true;
            this.Doc.Size = new System.Drawing.Size(132, 13);
            this.Doc.TabIndex = 21;
            this.Doc.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Nº Inscrição.....:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 109);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Atividade..........:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(188, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Lote Original..:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Quadra Original.:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(347, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Cep.....:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(245, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Cidade/UF..:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Bairro................:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Endereço..........:";
            // 
            // Inscricao
            // 
            this.Inscricao.BackColor = System.Drawing.SystemColors.Control;
            this.Inscricao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Inscricao.ForeColor = System.Drawing.Color.Navy;
            this.Inscricao.Location = new System.Drawing.Point(102, 132);
            this.Inscricao.Name = "Inscricao";
            this.Inscricao.ReadOnly = true;
            this.Inscricao.Size = new System.Drawing.Size(161, 13);
            this.Inscricao.TabIndex = 12;
            this.Inscricao.TabStop = false;
            // 
            // Atividade
            // 
            this.Atividade.BackColor = System.Drawing.SystemColors.Control;
            this.Atividade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Atividade.ForeColor = System.Drawing.Color.Navy;
            this.Atividade.Location = new System.Drawing.Point(102, 109);
            this.Atividade.Name = "Atividade";
            this.Atividade.ReadOnly = true;
            this.Atividade.Size = new System.Drawing.Size(372, 13);
            this.Atividade.TabIndex = 11;
            this.Atividade.TabStop = false;
            // 
            // Lote
            // 
            this.Lote.BackColor = System.Drawing.SystemColors.Control;
            this.Lote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Lote.ForeColor = System.Drawing.Color.Navy;
            this.Lote.Location = new System.Drawing.Point(265, 86);
            this.Lote.Name = "Lote";
            this.Lote.ReadOnly = true;
            this.Lote.Size = new System.Drawing.Size(72, 13);
            this.Lote.TabIndex = 10;
            this.Lote.TabStop = false;
            // 
            // Quadra
            // 
            this.Quadra.BackColor = System.Drawing.SystemColors.Control;
            this.Quadra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Quadra.ForeColor = System.Drawing.Color.Navy;
            this.Quadra.Location = new System.Drawing.Point(102, 86);
            this.Quadra.Name = "Quadra";
            this.Quadra.ReadOnly = true;
            this.Quadra.Size = new System.Drawing.Size(80, 13);
            this.Quadra.TabIndex = 9;
            this.Quadra.TabStop = false;
            // 
            // Cep
            // 
            this.Cep.BackColor = System.Drawing.SystemColors.Control;
            this.Cep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Cep.ForeColor = System.Drawing.Color.Navy;
            this.Cep.Location = new System.Drawing.Point(394, 86);
            this.Cep.Name = "Cep";
            this.Cep.ReadOnly = true;
            this.Cep.Size = new System.Drawing.Size(80, 13);
            this.Cep.TabIndex = 8;
            this.Cep.TabStop = false;
            // 
            // Cidade
            // 
            this.Cidade.BackColor = System.Drawing.SystemColors.Control;
            this.Cidade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Cidade.ForeColor = System.Drawing.Color.Navy;
            this.Cidade.Location = new System.Drawing.Point(314, 63);
            this.Cidade.Name = "Cidade";
            this.Cidade.ReadOnly = true;
            this.Cidade.Size = new System.Drawing.Size(160, 13);
            this.Cidade.TabIndex = 7;
            this.Cidade.TabStop = false;
            // 
            // Bairro
            // 
            this.Bairro.BackColor = System.Drawing.SystemColors.Control;
            this.Bairro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Bairro.ForeColor = System.Drawing.Color.Navy;
            this.Bairro.Location = new System.Drawing.Point(102, 63);
            this.Bairro.Name = "Bairro";
            this.Bairro.ReadOnly = true;
            this.Bairro.Size = new System.Drawing.Size(137, 13);
            this.Bairro.TabIndex = 6;
            this.Bairro.TabStop = false;
            // 
            // Endereco
            // 
            this.Endereco.BackColor = System.Drawing.SystemColors.Control;
            this.Endereco.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Endereco.ForeColor = System.Drawing.Color.Navy;
            this.Endereco.Location = new System.Drawing.Point(102, 40);
            this.Endereco.Name = "Endereco";
            this.Endereco.ReadOnly = true;
            this.Endereco.Size = new System.Drawing.Size(372, 13);
            this.Endereco.TabIndex = 5;
            this.Endereco.TabStop = false;
            // 
            // Nome
            // 
            this.Nome.BackColor = System.Drawing.SystemColors.Control;
            this.Nome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Nome.ForeColor = System.Drawing.Color.Navy;
            this.Nome.Location = new System.Drawing.Point(102, 17);
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Size = new System.Drawing.Size(372, 13);
            this.Nome.TabIndex = 4;
            this.Nome.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nome................:";
            // 
            // Certidao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 248);
            this.Controls.Add(this.a1Panel2);
            this.Controls.Add(this.a1Panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Certidao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emissão de Certidões";
            this.a1Panel1.ResumeLayout(false);
            this.a1Panel1.PerformLayout();
            this.TBar.ResumeLayout(false);
            this.TBar.PerformLayout();
            this.a1Panel2.ResumeLayout(false);
            this.a1Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Owf.Controls.A1Panel a1Panel1;
        private System.Windows.Forms.TextBox Processo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Assinatura;
        private System.Windows.Forms.ComboBox TipoList;
        private System.Windows.Forms.Label label3;
        private Owf.Controls.A1Panel a1Panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Inscricao;
        private System.Windows.Forms.TextBox Atividade;
        private System.Windows.Forms.TextBox Lote;
        private System.Windows.Forms.TextBox Quadra;
        private System.Windows.Forms.TextBox Cep;
        private System.Windows.Forms.TextBox Cidade;
        private System.Windows.Forms.TextBox Bairro;
        private System.Windows.Forms.TextBox Endereco;
        private System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.ToolStrip TBar;
        private System.Windows.Forms.ToolStripButton VerificarButton;
        private System.Windows.Forms.ToolStripButton ImprimirButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Doc;
    }
}