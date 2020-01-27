namespace GTI_Desktop.Forms {
    partial class Escritorio_Contabil {
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
            this.pnlEnd = new System.Windows.Forms.GroupBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.Fone = new System.Windows.Forms.TextBox();
            this.Pais = new System.Windows.Forms.TextBox();
            this.Cep = new System.Windows.Forms.TextBox();
            this.UF = new System.Windows.Forms.TextBox();
            this.Cidade = new System.Windows.Forms.TextBox();
            this.Complemento = new System.Windows.Forms.TextBox();
            this.Bairro = new System.Windows.Forms.TextBox();
            this.Numero = new System.Windows.Forms.TextBox();
            this.Logradouro = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Nome = new System.Windows.Forms.TextBox();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.AddButton = new System.Windows.Forms.ToolStripButton();
            this.EditButton = new System.Windows.Forms.ToolStripButton();
            this.DelButton = new System.Windows.Forms.ToolStripButton();
            this.FindButton = new System.Windows.Forms.ToolStripButton();
            this.SairButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.GravarButton = new System.Windows.Forms.ToolStripButton();
            this.CancelarButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.EnderecoButton = new System.Windows.Forms.ToolStripButton();
            this.lblNomeDoc = new System.Windows.Forms.Label();
            this.CNPJ = new System.Windows.Forms.MaskedTextBox();
            this.CPF = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IM = new System.Windows.Forms.TextBox();
            this.RecebeCarneCheck = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CodigoEscritorio = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Crc = new System.Windows.Forms.TextBox();
            this.pnlEnd.SuspendLayout();
            this.tBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEnd
            // 
            this.pnlEnd.Controls.Add(this.Email);
            this.pnlEnd.Controls.Add(this.Fone);
            this.pnlEnd.Controls.Add(this.Pais);
            this.pnlEnd.Controls.Add(this.Cep);
            this.pnlEnd.Controls.Add(this.UF);
            this.pnlEnd.Controls.Add(this.Cidade);
            this.pnlEnd.Controls.Add(this.Complemento);
            this.pnlEnd.Controls.Add(this.Bairro);
            this.pnlEnd.Controls.Add(this.Numero);
            this.pnlEnd.Controls.Add(this.Logradouro);
            this.pnlEnd.Controls.Add(this.label17);
            this.pnlEnd.Controls.Add(this.label16);
            this.pnlEnd.Controls.Add(this.label15);
            this.pnlEnd.Controls.Add(this.label14);
            this.pnlEnd.Controls.Add(this.label13);
            this.pnlEnd.Controls.Add(this.label12);
            this.pnlEnd.Controls.Add(this.label11);
            this.pnlEnd.Controls.Add(this.label10);
            this.pnlEnd.Controls.Add(this.label9);
            this.pnlEnd.Controls.Add(this.label8);
            this.pnlEnd.ForeColor = System.Drawing.Color.Maroon;
            this.pnlEnd.Location = new System.Drawing.Point(6, 78);
            this.pnlEnd.Name = "pnlEnd";
            this.pnlEnd.Size = new System.Drawing.Size(442, 136);
            this.pnlEnd.TabIndex = 6;
            this.pnlEnd.TabStop = false;
            // 
            // Email
            // 
            this.Email.BackColor = System.Drawing.SystemColors.Control;
            this.Email.Location = new System.Drawing.Point(69, 109);
            this.Email.MaxLength = 50;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Size = new System.Drawing.Size(366, 20);
            this.Email.TabIndex = 159;
            this.Email.TabStop = false;
            // 
            // Fone
            // 
            this.Fone.BackColor = System.Drawing.SystemColors.Control;
            this.Fone.Location = new System.Drawing.Point(271, 85);
            this.Fone.MaxLength = 50;
            this.Fone.Name = "Fone";
            this.Fone.ReadOnly = true;
            this.Fone.Size = new System.Drawing.Size(164, 20);
            this.Fone.TabIndex = 158;
            this.Fone.TabStop = false;
            // 
            // Pais
            // 
            this.Pais.BackColor = System.Drawing.SystemColors.Control;
            this.Pais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Pais.Location = new System.Drawing.Point(69, 85);
            this.Pais.MaxLength = 25;
            this.Pais.Name = "Pais";
            this.Pais.ReadOnly = true;
            this.Pais.Size = new System.Drawing.Size(147, 20);
            this.Pais.TabIndex = 12;
            this.Pais.TabStop = false;
            this.Pais.Tag = "1";
            this.Pais.Text = "BRASIL";
            // 
            // Cep
            // 
            this.Cep.BackColor = System.Drawing.SystemColors.Control;
            this.Cep.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Cep.Location = new System.Drawing.Point(358, 61);
            this.Cep.MaxLength = 25;
            this.Cep.Name = "Cep";
            this.Cep.ReadOnly = true;
            this.Cep.Size = new System.Drawing.Size(77, 20);
            this.Cep.TabIndex = 11;
            this.Cep.TabStop = false;
            // 
            // UF
            // 
            this.UF.BackColor = System.Drawing.SystemColors.Control;
            this.UF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.UF.Location = new System.Drawing.Point(271, 61);
            this.UF.MaxLength = 25;
            this.UF.Name = "UF";
            this.UF.ReadOnly = true;
            this.UF.Size = new System.Drawing.Size(33, 20);
            this.UF.TabIndex = 10;
            this.UF.TabStop = false;
            // 
            // Cidade
            // 
            this.Cidade.BackColor = System.Drawing.SystemColors.Control;
            this.Cidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Cidade.Location = new System.Drawing.Point(69, 61);
            this.Cidade.MaxLength = 25;
            this.Cidade.Name = "Cidade";
            this.Cidade.ReadOnly = true;
            this.Cidade.Size = new System.Drawing.Size(147, 20);
            this.Cidade.TabIndex = 9;
            this.Cidade.TabStop = false;
            // 
            // Complemento
            // 
            this.Complemento.BackColor = System.Drawing.SystemColors.Control;
            this.Complemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Complemento.Location = new System.Drawing.Point(271, 37);
            this.Complemento.MaxLength = 25;
            this.Complemento.Name = "Complemento";
            this.Complemento.ReadOnly = true;
            this.Complemento.Size = new System.Drawing.Size(164, 20);
            this.Complemento.TabIndex = 8;
            this.Complemento.TabStop = false;
            // 
            // Bairro
            // 
            this.Bairro.BackColor = System.Drawing.SystemColors.Control;
            this.Bairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Bairro.Location = new System.Drawing.Point(69, 37);
            this.Bairro.MaxLength = 25;
            this.Bairro.Name = "Bairro";
            this.Bairro.ReadOnly = true;
            this.Bairro.Size = new System.Drawing.Size(147, 20);
            this.Bairro.TabIndex = 7;
            this.Bairro.TabStop = false;
            // 
            // Numero
            // 
            this.Numero.BackColor = System.Drawing.SystemColors.Control;
            this.Numero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Numero.Location = new System.Drawing.Point(364, 13);
            this.Numero.MaxLength = 25;
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Size = new System.Drawing.Size(71, 20);
            this.Numero.TabIndex = 6;
            this.Numero.TabStop = false;
            // 
            // Logradouro
            // 
            this.Logradouro.BackColor = System.Drawing.SystemColors.Control;
            this.Logradouro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Logradouro.Location = new System.Drawing.Point(69, 13);
            this.Logradouro.MaxLength = 25;
            this.Logradouro.Name = "Logradouro";
            this.Logradouro.ReadOnly = true;
            this.Logradouro.Size = new System.Drawing.Size(258, 20);
            this.Logradouro.TabIndex = 5;
            this.Logradouro.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(226, 90);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 157;
            this.label17.Text = "Fone....:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(2, 112);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 156;
            this.label16.Text = "Email........:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(2, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 131;
            this.label15.Text = "País...........:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(316, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 128;
            this.label14.Text = "CEP....:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(3, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 126;
            this.label13.Text = "Bairro.........:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(3, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 124;
            this.label12.Text = "Cidade.......:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(226, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 122;
            this.label11.Text = "UF.......:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(226, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 120;
            this.label10.Text = "Compl..:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(335, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 118;
            this.label9.Text = "Nº..:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(3, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 116;
            this.label8.Text = "Logradouro:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(11, 33);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(59, 13);
            this.Label2.TabIndex = 158;
            this.Label2.Text = "Nome.......:";
            // 
            // Nome
            // 
            this.Nome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nome.Location = new System.Drawing.Point(74, 30);
            this.Nome.MaxLength = 50;
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(367, 20);
            this.Nome.TabIndex = 2;
            // 
            // tBar
            // 
            this.tBar.AllowMerge = false;
            this.tBar.BackColor = System.Drawing.SystemColors.Control;
            this.tBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddButton,
            this.EditButton,
            this.DelButton,
            this.FindButton,
            this.SairButton,
            this.toolStripSeparator1,
            this.GravarButton,
            this.CancelarButton,
            this.toolStripSeparator2,
            this.EnderecoButton});
            this.tBar.Location = new System.Drawing.Point(0, 217);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(454, 25);
            this.tBar.TabIndex = 0;
            this.tBar.TabStop = true;
            this.tBar.Text = "toolStrip1";
            // 
            // AddButton
            // 
            this.AddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddButton.Image = global::GTI_Desktop.Properties.Resources.add_file;
            this.AddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(23, 22);
            this.AddButton.Text = "toolStripButton1";
            this.AddButton.ToolTipText = "Novo registro";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditButton.Image = global::GTI_Desktop.Properties.Resources.Alterar;
            this.EditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(23, 22);
            this.EditButton.Text = "toolStripButton2";
            this.EditButton.ToolTipText = "Alterar registro";
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DelButton
            // 
            this.DelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DelButton.Image = global::GTI_Desktop.Properties.Resources.delete;
            this.DelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(23, 22);
            this.DelButton.Text = "toolStripButton3";
            this.DelButton.ToolTipText = "Excluir registro";
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // FindButton
            // 
            this.FindButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FindButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.FindButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(23, 22);
            this.FindButton.Text = "toolStripButton4";
            this.FindButton.ToolTipText = "Abrir tela de pesquisa";
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // SairButton
            // 
            this.SairButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SairButton.Image = global::GTI_Desktop.Properties.Resources.Exit;
            this.SairButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SairButton.Name = "SairButton";
            this.SairButton.Size = new System.Drawing.Size(23, 22);
            this.SairButton.Text = "toolStripButton5";
            this.SairButton.ToolTipText = "Sair";
            this.SairButton.Click += new System.EventHandler(this.SairButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // GravarButton
            // 
            this.GravarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GravarButton.Image = global::GTI_Desktop.Properties.Resources.gravar;
            this.GravarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GravarButton.Name = "GravarButton";
            this.GravarButton.Size = new System.Drawing.Size(23, 22);
            this.GravarButton.Text = "btGravar";
            this.GravarButton.ToolTipText = "Gravar os dados";
            this.GravarButton.Click += new System.EventHandler(this.GravarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.AccessibleDescription = "Cancelar operação";
            this.CancelarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelarButton.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.CancelarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(23, 22);
            this.CancelarButton.Text = "btCancelar";
            this.CancelarButton.ToolTipText = "Cancelar inclusão/alteração";
            this.CancelarButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // EnderecoButton
            // 
            this.EnderecoButton.ForeColor = System.Drawing.Color.Navy;
            this.EnderecoButton.Image = global::GTI_Desktop.Properties.Resources.Alterar;
            this.EnderecoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EnderecoButton.Name = "EnderecoButton";
            this.EnderecoButton.Size = new System.Drawing.Size(124, 22);
            this.EnderecoButton.Text = "Alterar o endereço";
            this.EnderecoButton.Click += new System.EventHandler(this.EnderecoButton_Click);
            // 
            // lblNomeDoc
            // 
            this.lblNomeDoc.AutoSize = true;
            this.lblNomeDoc.Location = new System.Drawing.Point(172, 59);
            this.lblNomeDoc.Name = "lblNomeDoc";
            this.lblNomeDoc.Size = new System.Drawing.Size(43, 13);
            this.lblNomeDoc.TabIndex = 163;
            this.lblNomeDoc.Text = "CNPJ..:";
            // 
            // CNPJ
            // 
            this.CNPJ.Location = new System.Drawing.Point(221, 56);
            this.CNPJ.Mask = "99,999,999/9999-99";
            this.CNPJ.Name = "CNPJ";
            this.CNPJ.Size = new System.Drawing.Size(113, 20);
            this.CNPJ.TabIndex = 4;
            this.CNPJ.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // CPF
            // 
            this.CPF.Location = new System.Drawing.Point(74, 56);
            this.CPF.Mask = "999,999,999-99";
            this.CPF.Name = "CPF";
            this.CPF.Size = new System.Drawing.Size(93, 20);
            this.CPF.TabIndex = 3;
            this.CPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 164;
            this.label1.Text = "CPF..........:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(341, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 159;
            this.label3.Text = "IM..:";
            // 
            // IM
            // 
            this.IM.BackColor = System.Drawing.Color.White;
            this.IM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.IM.Location = new System.Drawing.Point(370, 56);
            this.IM.MaxLength = 6;
            this.IM.Name = "IM";
            this.IM.Size = new System.Drawing.Size(71, 20);
            this.IM.TabIndex = 5;
            this.IM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IM_KeyPress);
            // 
            // RecebeCarneCheck
            // 
            this.RecebeCarneCheck.AutoSize = true;
            this.RecebeCarneCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RecebeCarneCheck.ForeColor = System.Drawing.Color.Maroon;
            this.RecebeCarneCheck.Location = new System.Drawing.Point(347, 220);
            this.RecebeCarneCheck.Name = "RecebeCarneCheck";
            this.RecebeCarneCheck.Size = new System.Drawing.Size(94, 17);
            this.RecebeCarneCheck.TabIndex = 7;
            this.RecebeCarneCheck.Text = "Recebe carnê";
            this.RecebeCarneCheck.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 166;
            this.label4.Text = "Código......:";
            // 
            // CodigoEscritorio
            // 
            this.CodigoEscritorio.AutoSize = true;
            this.CodigoEscritorio.ForeColor = System.Drawing.Color.Maroon;
            this.CodigoEscritorio.Location = new System.Drawing.Point(72, 9);
            this.CodigoEscritorio.Name = "CodigoEscritorio";
            this.CodigoEscritorio.Size = new System.Drawing.Size(25, 13);
            this.CodigoEscritorio.TabIndex = 167;
            this.CodigoEscritorio.Text = "000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 168;
            this.label6.Text = "CRC......:";
            // 
            // Crc
            // 
            this.Crc.BackColor = System.Drawing.Color.White;
            this.Crc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Crc.Location = new System.Drawing.Point(221, 6);
            this.Crc.MaxLength = 30;
            this.Crc.Name = "Crc";
            this.Crc.Size = new System.Drawing.Size(112, 20);
            this.Crc.TabIndex = 1;
            // 
            // Escritorio_Contabil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 242);
            this.Controls.Add(this.Crc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CodigoEscritorio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RecebeCarneCheck);
            this.Controls.Add(this.IM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNomeDoc);
            this.Controls.Add(this.CNPJ);
            this.Controls.Add(this.CPF);
            this.Controls.Add(this.tBar);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.pnlEnd);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Escritorio_Contabil";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Escritório Contábil";
            this.pnlEnd.ResumeLayout(false);
            this.pnlEnd.PerformLayout();
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox pnlEnd;
        private System.Windows.Forms.TextBox Pais;
        private System.Windows.Forms.TextBox Cep;
        private System.Windows.Forms.TextBox UF;
        private System.Windows.Forms.TextBox Cidade;
        private System.Windows.Forms.TextBox Complemento;
        private System.Windows.Forms.TextBox Bairro;
        private System.Windows.Forms.TextBox Numero;
        private System.Windows.Forms.TextBox Logradouro;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton EditButton;
        private System.Windows.Forms.ToolStripButton DelButton;
        private System.Windows.Forms.ToolStripButton FindButton;
        private System.Windows.Forms.ToolStripButton SairButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton GravarButton;
        private System.Windows.Forms.ToolStripButton CancelarButton;
        internal System.Windows.Forms.Label lblNomeDoc;
        internal System.Windows.Forms.MaskedTextBox CNPJ;
        internal System.Windows.Forms.MaskedTextBox CPF;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TextBox IM;
        private System.Windows.Forms.CheckBox RecebeCarneCheck;
        private System.Windows.Forms.ToolStripButton AddButton;
        private System.Windows.Forms.ToolStripButton EnderecoButton;
        internal System.Windows.Forms.TextBox Email;
        internal System.Windows.Forms.TextBox Fone;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label CodigoEscritorio;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Crc;
    }
}