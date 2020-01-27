namespace GTI_Desktop.Forms {
    partial class Imovel_Lista {
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
            this.MainListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CondominioToolStrip = new System.Windows.Forms.ToolStrip();
            this.CondominioAddButton = new System.Windows.Forms.ToolStripButton();
            this.CondominioDelButton = new System.Windows.Forms.ToolStripButton();
            this.ProprietarioToolStrip = new System.Windows.Forms.ToolStrip();
            this.ProprietarioAddButton = new System.Windows.Forms.ToolStripButton();
            this.ProprietarioDelButton = new System.Windows.Forms.ToolStripButton();
            this.Condominio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EnderecoToolStrip = new System.Windows.Forms.ToolStrip();
            this.EnderecoAddButton = new System.Windows.Forms.ToolStripButton();
            this.EnderecoDelButton = new System.Windows.Forms.ToolStripButton();
            this.Bairro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Numero = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Logradouro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Inscricao = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Proprietario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PrincipalCheckBox = new System.Windows.Forms.CheckBox();
            this.Codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.FindButton = new System.Windows.Forms.ToolStripButton();
            this.SelectButton = new System.Windows.Forms.ToolStripButton();
            this.ClearButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TotalImovel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ExcelButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.OrdemList = new System.Windows.Forms.ToolStripComboBox();
            this.panel1.SuspendLayout();
            this.CondominioToolStrip.SuspendLayout();
            this.ProprietarioToolStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.EnderecoToolStrip.SuspendLayout();
            this.tBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainListView
            // 
            this.MainListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.MainListView.FullRowSelect = true;
            this.MainListView.Location = new System.Drawing.Point(0, 171);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(689, 220);
            this.MainListView.TabIndex = 6;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.VirtualMode = true;
            this.MainListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.MainListView_RetrieveVirtualItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Inscrição";
            this.columnHeader2.Width = 170;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Proprietário";
            this.columnHeader4.Width = 220;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Endereço";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nº";
            this.columnHeader5.Width = 38;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Compl.";
            this.columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Bairro";
            this.columnHeader7.Width = 130;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Condomínio";
            this.columnHeader8.Width = 130;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CondominioToolStrip);
            this.panel1.Controls.Add(this.ProprietarioToolStrip);
            this.panel1.Controls.Add(this.Condominio);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.Inscricao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Proprietario);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.PrincipalCheckBox);
            this.panel1.Controls.Add(this.Codigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 169);
            this.panel1.TabIndex = 75;
            // 
            // CondominioToolStrip
            // 
            this.CondominioToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.CondominioToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.CondominioToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.CondominioToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CondominioAddButton,
            this.CondominioDelButton});
            this.CondominioToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.CondominioToolStrip.Location = new System.Drawing.Point(404, 130);
            this.CondominioToolStrip.Name = "CondominioToolStrip";
            this.CondominioToolStrip.Size = new System.Drawing.Size(49, 25);
            this.CondominioToolStrip.TabIndex = 208;
            this.CondominioToolStrip.Text = "toolStrip2";
            // 
            // CondominioAddButton
            // 
            this.CondominioAddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CondominioAddButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.CondominioAddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CondominioAddButton.Name = "CondominioAddButton";
            this.CondominioAddButton.Size = new System.Drawing.Size(23, 22);
            this.CondominioAddButton.Text = "Adicionar um condomínio";
            this.CondominioAddButton.ToolTipText = "Adicionar um condomínio";
            this.CondominioAddButton.Click += new System.EventHandler(this.CondominioButton_Click);
            // 
            // CondominioDelButton
            // 
            this.CondominioDelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CondominioDelButton.Image = global::GTI_Desktop.Properties.Resources.cancelar;
            this.CondominioDelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CondominioDelButton.Name = "CondominioDelButton";
            this.CondominioDelButton.Size = new System.Drawing.Size(23, 22);
            this.CondominioDelButton.Text = "Remover o condomínio";
            this.CondominioDelButton.ToolTipText = "Remover o condomínio";
            this.CondominioDelButton.Click += new System.EventHandler(this.CondominioDelButton_Click);
            // 
            // ProprietarioToolStrip
            // 
            this.ProprietarioToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.ProprietarioToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ProprietarioToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ProprietarioToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProprietarioAddButton,
            this.ProprietarioDelButton});
            this.ProprietarioToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ProprietarioToolStrip.Location = new System.Drawing.Point(404, 31);
            this.ProprietarioToolStrip.Name = "ProprietarioToolStrip";
            this.ProprietarioToolStrip.Size = new System.Drawing.Size(49, 25);
            this.ProprietarioToolStrip.TabIndex = 207;
            this.ProprietarioToolStrip.Text = "toolStrip2";
            // 
            // ProprietarioAddButton
            // 
            this.ProprietarioAddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ProprietarioAddButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.ProprietarioAddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProprietarioAddButton.Name = "ProprietarioAddButton";
            this.ProprietarioAddButton.Size = new System.Drawing.Size(23, 22);
            this.ProprietarioAddButton.Text = "toolStripButton1";
            this.ProprietarioAddButton.ToolTipText = "Adicionar um proprietário";
            this.ProprietarioAddButton.Click += new System.EventHandler(this.ProprietarioButton_Click);
            // 
            // ProprietarioDelButton
            // 
            this.ProprietarioDelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ProprietarioDelButton.Image = global::GTI_Desktop.Properties.Resources.cancelar;
            this.ProprietarioDelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProprietarioDelButton.Name = "ProprietarioDelButton";
            this.ProprietarioDelButton.Size = new System.Drawing.Size(23, 22);
            this.ProprietarioDelButton.Text = "toolStripButton3";
            this.ProprietarioDelButton.ToolTipText = "Remover o proprietário";
            this.ProprietarioDelButton.Click += new System.EventHandler(this.ProprietarioDelButton_Click);
            // 
            // Condominio
            // 
            this.Condominio.Location = new System.Drawing.Point(78, 134);
            this.Condominio.MaxLength = 0;
            this.Condominio.Name = "Condominio";
            this.Condominio.ReadOnly = true;
            this.Condominio.Size = new System.Drawing.Size(323, 20);
            this.Condominio.TabIndex = 94;
            this.Condominio.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 92;
            this.label7.Text = "Condomínio:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EnderecoToolStrip);
            this.groupBox1.Controls.Add(this.Bairro);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Numero);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Logradouro);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(3, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 72);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // EnderecoToolStrip
            // 
            this.EnderecoToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.EnderecoToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.EnderecoToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.EnderecoToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EnderecoAddButton,
            this.EnderecoDelButton});
            this.EnderecoToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.EnderecoToolStrip.Location = new System.Drawing.Point(401, 36);
            this.EnderecoToolStrip.Name = "EnderecoToolStrip";
            this.EnderecoToolStrip.Size = new System.Drawing.Size(49, 25);
            this.EnderecoToolStrip.TabIndex = 208;
            this.EnderecoToolStrip.Text = "toolStrip2";
            // 
            // EnderecoAddButton
            // 
            this.EnderecoAddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EnderecoAddButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.EnderecoAddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EnderecoAddButton.Name = "EnderecoAddButton";
            this.EnderecoAddButton.Size = new System.Drawing.Size(23, 22);
            this.EnderecoAddButton.Text = "toolStripButton1";
            this.EnderecoAddButton.ToolTipText = "Selecionar um endereço";
            this.EnderecoAddButton.Click += new System.EventHandler(this.EnderecoAddButton_Click);
            // 
            // EnderecoDelButton
            // 
            this.EnderecoDelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EnderecoDelButton.Image = global::GTI_Desktop.Properties.Resources.cancelar;
            this.EnderecoDelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EnderecoDelButton.Name = "EnderecoDelButton";
            this.EnderecoDelButton.Size = new System.Drawing.Size(23, 22);
            this.EnderecoDelButton.Text = "toolStripButton3";
            this.EnderecoDelButton.ToolTipText = "Limpar o campo endereço";
            this.EnderecoDelButton.Click += new System.EventHandler(this.EnderecoDelButton_Click);
            // 
            // Bairro
            // 
            this.Bairro.Location = new System.Drawing.Point(75, 40);
            this.Bairro.MaxLength = 0;
            this.Bairro.Name = "Bairro";
            this.Bairro.ReadOnly = true;
            this.Bairro.Size = new System.Drawing.Size(323, 20);
            this.Bairro.TabIndex = 92;
            this.Bairro.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 91;
            this.label6.Text = "Bairro..........:";
            // 
            // Numero
            // 
            this.Numero.Location = new System.Drawing.Point(392, 13);
            this.Numero.MaxLength = 0;
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Size = new System.Drawing.Size(52, 20);
            this.Numero.TabIndex = 90;
            this.Numero.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(361, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 89;
            this.label5.Text = "Nº.:";
            // 
            // Logradouro
            // 
            this.Logradouro.Location = new System.Drawing.Point(75, 14);
            this.Logradouro.MaxLength = 0;
            this.Logradouro.Name = "Logradouro";
            this.Logradouro.ReadOnly = true;
            this.Logradouro.Size = new System.Drawing.Size(272, 20);
            this.Logradouro.TabIndex = 87;
            this.Logradouro.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 86;
            this.label4.Text = "Logradouro.:";
            // 
            // Inscricao
            // 
            this.Inscricao.Location = new System.Drawing.Point(355, 8);
            this.Inscricao.Mask = "9.99.9999.99999";
            this.Inscricao.Name = "Inscricao";
            this.Inscricao.PromptChar = ' ';
            this.Inscricao.Size = new System.Drawing.Size(92, 20);
            this.Inscricao.TabIndex = 2;
            this.Inscricao.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 77;
            this.label3.Text = "Inscrição...:";
            // 
            // Proprietario
            // 
            this.Proprietario.Location = new System.Drawing.Point(78, 33);
            this.Proprietario.MaxLength = 0;
            this.Proprietario.Name = "Proprietario";
            this.Proprietario.ReadOnly = true;
            this.Proprietario.Size = new System.Drawing.Size(323, 20);
            this.Proprietario.TabIndex = 75;
            this.Proprietario.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Proprietário.:";
            // 
            // PrincipalCheckBox
            // 
            this.PrincipalCheckBox.AutoSize = true;
            this.PrincipalCheckBox.Checked = true;
            this.PrincipalCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PrincipalCheckBox.Location = new System.Drawing.Point(164, 10);
            this.PrincipalCheckBox.Name = "PrincipalCheckBox";
            this.PrincipalCheckBox.Size = new System.Drawing.Size(121, 17);
            this.PrincipalCheckBox.TabIndex = 1;
            this.PrincipalCheckBox.Text = "Proprietário principal";
            this.PrincipalCheckBox.UseVisualStyleBackColor = true;
            // 
            // Codigo
            // 
            this.Codigo.Location = new System.Drawing.Point(78, 7);
            this.Codigo.MaxLength = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(65, 20);
            this.Codigo.TabIndex = 0;
            this.Codigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Codigo_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Código........:";
            // 
            // tBar
            // 
            this.tBar.AllowMerge = false;
            this.tBar.BackColor = System.Drawing.SystemColors.Control;
            this.tBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FindButton,
            this.SelectButton,
            this.ClearButton,
            this.toolStripSeparator1,
            this.TotalImovel,
            this.toolStripLabel2,
            this.ExcelButton,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.OrdemList});
            this.tBar.Location = new System.Drawing.Point(0, 394);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(689, 25);
            this.tBar.TabIndex = 70;
            this.tBar.Text = "toolStrip1";
            // 
            // FindButton
            // 
            this.FindButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FindButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.FindButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(23, 22);
            this.FindButton.Text = "toolStripButton1";
            this.FindButton.ToolTipText = "Pesquisar";
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SelectButton.Image = global::GTI_Desktop.Properties.Resources.rightarrow;
            this.SelectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(23, 22);
            this.SelectButton.Text = "toolStripButton2";
            this.SelectButton.ToolTipText = "Retornar";
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearButton.Image = global::GTI_Desktop.Properties.Resources.delete;
            this.ClearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(23, 22);
            this.ClearButton.Text = "toolStripButton1";
            this.ClearButton.ToolTipText = "Limpar todos os campos";
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TotalImovel
            // 
            this.TotalImovel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TotalImovel.ForeColor = System.Drawing.Color.Maroon;
            this.TotalImovel.Name = "TotalImovel";
            this.TotalImovel.Size = new System.Drawing.Size(13, 22);
            this.TotalImovel.Text = "0";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabel2.Text = "Total encontrado:";
            // 
            // ExcelButton
            // 
            this.ExcelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExcelButton.Image = global::GTI_Desktop.Properties.Resources.excel;
            this.ExcelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExcelButton.Name = "ExcelButton";
            this.ExcelButton.Size = new System.Drawing.Size(23, 22);
            this.ExcelButton.Text = "toolStripButton1";
            this.ExcelButton.ToolTipText = "Exportar resultado para o Excel";
            this.ExcelButton.Click += new System.EventHandler(this.ExcelButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 22);
            this.toolStripLabel1.Text = "Ordenar por:";
            // 
            // OrdemList
            // 
            this.OrdemList.BackColor = System.Drawing.SystemColors.Control;
            this.OrdemList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OrdemList.ForeColor = System.Drawing.Color.DarkRed;
            this.OrdemList.Name = "OrdemList";
            this.OrdemList.Size = new System.Drawing.Size(121, 25);
            this.OrdemList.SelectedIndexChanged += new System.EventHandler(this.OrdemList_SelectedIndexChanged);
            // 
            // Imovel_Lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 419);
            this.Controls.Add(this.MainListView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tBar);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(530, 380);
            this.Name = "Imovel_Lista";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lista dos imóveis cadastrados";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.CondominioToolStrip.ResumeLayout(false);
            this.CondominioToolStrip.PerformLayout();
            this.ProprietarioToolStrip.ResumeLayout(false);
            this.ProprietarioToolStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.EnderecoToolStrip.ResumeLayout(false);
            this.EnderecoToolStrip.PerformLayout();
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton FindButton;
        private System.Windows.Forms.ToolStripButton SelectButton;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.CheckBox PrincipalCheckBox;
        private System.Windows.Forms.TextBox Proprietario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox Inscricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel TotalImovel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Bairro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Numero;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Logradouro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Condominio;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStrip CondominioToolStrip;
        private System.Windows.Forms.ToolStripButton CondominioAddButton;
        private System.Windows.Forms.ToolStripButton CondominioDelButton;
        private System.Windows.Forms.ToolStrip ProprietarioToolStrip;
        private System.Windows.Forms.ToolStripButton ProprietarioAddButton;
        private System.Windows.Forms.ToolStripButton ProprietarioDelButton;
        private System.Windows.Forms.ToolStrip EnderecoToolStrip;
        private System.Windows.Forms.ToolStripButton EnderecoAddButton;
        private System.Windows.Forms.ToolStripButton EnderecoDelButton;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ToolStripButton ExcelButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox OrdemList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ClearButton;
    }
}