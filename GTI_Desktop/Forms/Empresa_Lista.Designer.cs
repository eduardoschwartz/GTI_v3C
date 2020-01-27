namespace GTI_Desktop.Forms {
    partial class Empresa_Lista {
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
            this.EnderecoToolStrip = new System.Windows.Forms.ToolStrip();
            this.EnderecoAddButton = new System.Windows.Forms.ToolStripButton();
            this.EnderecoDelButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.RazaoSocialText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.FindButton = new System.Windows.Forms.ToolStripButton();
            this.SelectButton = new System.Windows.Forms.ToolStripButton();
            this.ClearButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TotalEmpresa = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.ExcelButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.OrdemList = new System.Windows.Forms.ToolStripComboBox();
            this.BairroText = new System.Windows.Forms.TextBox();
            this.MainListView = new System.Windows.Forms.ListView();
            this.chCodigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRazao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAtivNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAtivCod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCompl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBairro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.AtividadeToolStrip = new System.Windows.Forms.ToolStrip();
            this.AtividadeAddButton = new System.Windows.Forms.ToolStripButton();
            this.AtividadeDelButton = new System.Windows.Forms.ToolStripButton();
            this.AtividadeText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CNPJText = new System.Windows.Forms.MaskedTextBox();
            this.CPFText = new System.Windows.Forms.MaskedTextBox();
            this.CNPJOption = new System.Windows.Forms.RadioButton();
            this.CPFOption = new System.Windows.Forms.RadioButton();
            this.ProprietarioToolStrip = new System.Windows.Forms.ToolStrip();
            this.ProprietarioAddButton = new System.Windows.Forms.ToolStripButton();
            this.ProprietarioDelButton = new System.Windows.Forms.ToolStripButton();
            this.ProprietarioText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NumeroText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LogradouroText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EnderecoToolStrip.SuspendLayout();
            this.tBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.AtividadeToolStrip.SuspendLayout();
            this.ProprietarioToolStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 22);
            this.toolStripLabel1.Text = "Ordenar por:";
            // 
            // RazaoSocialText
            // 
            this.RazaoSocialText.Location = new System.Drawing.Point(85, 32);
            this.RazaoSocialText.MaxLength = 0;
            this.RazaoSocialText.Name = "RazaoSocialText";
            this.RazaoSocialText.Size = new System.Drawing.Size(322, 20);
            this.RazaoSocialText.TabIndex = 75;
            this.RazaoSocialText.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Razão Social:";
            // 
            // Codigo
            // 
            this.Codigo.Location = new System.Drawing.Point(85, 8);
            this.Codigo.MaxLength = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(64, 20);
            this.Codigo.TabIndex = 0;
            this.Codigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Codigo_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Inscrição......:";
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
            this.TotalEmpresa,
            this.toolStripLabel2,
            this.ExcelButton,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.OrdemList});
            this.tBar.Location = new System.Drawing.Point(0, 400);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(656, 25);
            this.tBar.TabIndex = 77;
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
            // TotalEmpresa
            // 
            this.TotalEmpresa.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TotalEmpresa.ForeColor = System.Drawing.Color.Maroon;
            this.TotalEmpresa.Name = "TotalEmpresa";
            this.TotalEmpresa.Size = new System.Drawing.Size(13, 22);
            this.TotalEmpresa.Text = "0";
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
            // OrdemList
            // 
            this.OrdemList.BackColor = System.Drawing.SystemColors.Control;
            this.OrdemList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OrdemList.ForeColor = System.Drawing.Color.DarkRed;
            this.OrdemList.Name = "OrdemList";
            this.OrdemList.Size = new System.Drawing.Size(121, 25);
            this.OrdemList.SelectedIndexChanged += new System.EventHandler(this.OrdemList_SelectedIndexChanged);
            // 
            // BairroText
            // 
            this.BairroText.Location = new System.Drawing.Point(75, 40);
            this.BairroText.MaxLength = 0;
            this.BairroText.Name = "BairroText";
            this.BairroText.ReadOnly = true;
            this.BairroText.Size = new System.Drawing.Size(323, 20);
            this.BairroText.TabIndex = 92;
            this.BairroText.TabStop = false;
            // 
            // MainListView
            // 
            this.MainListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCodigo,
            this.chDoc,
            this.chRazao,
            this.chProp,
            this.chAtivNome,
            this.chAtivCod,
            this.chEnd,
            this.chNum,
            this.chCompl,
            this.chBairro});
            this.MainListView.FullRowSelect = true;
            this.MainListView.Location = new System.Drawing.Point(0, 181);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(656, 216);
            this.MainListView.TabIndex = 76;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.VirtualMode = true;
            this.MainListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.MainListView_RetrieveVirtualItem);
            // 
            // chCodigo
            // 
            this.chCodigo.Text = "Código";
            // 
            // chDoc
            // 
            this.chDoc.Text = "CPF/CNPJ";
            this.chDoc.Width = 120;
            // 
            // chRazao
            // 
            this.chRazao.Text = "Razão Social";
            this.chRazao.Width = 200;
            // 
            // chProp
            // 
            this.chProp.Text = "Proprietário";
            this.chProp.Width = 220;
            // 
            // chAtivNome
            // 
            this.chAtivNome.Text = "Atividade";
            this.chAtivNome.Width = 200;
            // 
            // chAtivCod
            // 
            this.chAtivCod.Text = "AtivCod";
            // 
            // chEnd
            // 
            this.chEnd.Text = "Endereço";
            this.chEnd.Width = 200;
            // 
            // chNum
            // 
            this.chNum.Text = "Nº";
            this.chNum.Width = 38;
            // 
            // chCompl
            // 
            this.chCompl.Text = "Compl.";
            this.chCompl.Width = 70;
            // 
            // chBairro
            // 
            this.chBairro.Text = "Bairro";
            this.chBairro.Width = 130;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.AtividadeToolStrip);
            this.panel1.Controls.Add(this.AtividadeText);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CNPJText);
            this.panel1.Controls.Add(this.CPFText);
            this.panel1.Controls.Add(this.CNPJOption);
            this.panel1.Controls.Add(this.CPFOption);
            this.panel1.Controls.Add(this.ProprietarioToolStrip);
            this.panel1.Controls.Add(this.ProprietarioText);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.RazaoSocialText);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Codigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 181);
            this.panel1.TabIndex = 78;
            // 
            // AtividadeToolStrip
            // 
            this.AtividadeToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.AtividadeToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.AtividadeToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.AtividadeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AtividadeAddButton,
            this.AtividadeDelButton});
            this.AtividadeToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.AtividadeToolStrip.Location = new System.Drawing.Point(410, 74);
            this.AtividadeToolStrip.Name = "AtividadeToolStrip";
            this.AtividadeToolStrip.Size = new System.Drawing.Size(49, 25);
            this.AtividadeToolStrip.TabIndex = 215;
            this.AtividadeToolStrip.Text = "toolStrip2";
            // 
            // AtividadeAddButton
            // 
            this.AtividadeAddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AtividadeAddButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.AtividadeAddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AtividadeAddButton.Name = "AtividadeAddButton";
            this.AtividadeAddButton.Size = new System.Drawing.Size(23, 22);
            this.AtividadeAddButton.Text = "Adicionar um condomínio";
            this.AtividadeAddButton.ToolTipText = "Adicionar um condomínio";
            this.AtividadeAddButton.Click += new System.EventHandler(this.AtividadeAddButton_Click);
            // 
            // AtividadeDelButton
            // 
            this.AtividadeDelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AtividadeDelButton.Image = global::GTI_Desktop.Properties.Resources.cancelar;
            this.AtividadeDelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AtividadeDelButton.Name = "AtividadeDelButton";
            this.AtividadeDelButton.Size = new System.Drawing.Size(23, 22);
            this.AtividadeDelButton.Text = "Remover o condomínio";
            this.AtividadeDelButton.ToolTipText = "Remover o condomínio";
            this.AtividadeDelButton.Click += new System.EventHandler(this.AtividadeDelButton_Click);
            // 
            // AtividadeText
            // 
            this.AtividadeText.Location = new System.Drawing.Point(85, 78);
            this.AtividadeText.MaxLength = 0;
            this.AtividadeText.Name = "AtividadeText";
            this.AtividadeText.ReadOnly = true;
            this.AtividadeText.Size = new System.Drawing.Size(322, 20);
            this.AtividadeText.TabIndex = 214;
            this.AtividadeText.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 213;
            this.label3.Text = "Atividade......:";
            // 
            // CNPJText
            // 
            this.CNPJText.Location = new System.Drawing.Point(280, 8);
            this.CNPJText.Mask = "99,999,999/9999-99";
            this.CNPJText.Name = "CNPJText";
            this.CNPJText.Size = new System.Drawing.Size(127, 20);
            this.CNPJText.TabIndex = 212;
            this.CNPJText.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // CPFText
            // 
            this.CPFText.Location = new System.Drawing.Point(280, 8);
            this.CPFText.Mask = "999,999,999-99";
            this.CPFText.Name = "CPFText";
            this.CPFText.Size = new System.Drawing.Size(127, 20);
            this.CPFText.TabIndex = 211;
            this.CPFText.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.CPFText.Visible = false;
            // 
            // CNPJOption
            // 
            this.CNPJOption.AutoSize = true;
            this.CNPJOption.Checked = true;
            this.CNPJOption.Location = new System.Drawing.Point(222, 9);
            this.CNPJOption.Name = "CNPJOption";
            this.CNPJOption.Size = new System.Drawing.Size(52, 17);
            this.CNPJOption.TabIndex = 210;
            this.CNPJOption.TabStop = true;
            this.CNPJOption.Text = "CNPJ";
            this.CNPJOption.UseVisualStyleBackColor = true;
            this.CNPJOption.CheckedChanged += new System.EventHandler(this.CNPJOption_CheckedChanged);
            // 
            // CPFOption
            // 
            this.CPFOption.AutoSize = true;
            this.CPFOption.Location = new System.Drawing.Point(171, 9);
            this.CPFOption.Name = "CPFOption";
            this.CPFOption.Size = new System.Drawing.Size(45, 17);
            this.CPFOption.TabIndex = 209;
            this.CPFOption.Text = "CPF";
            this.CPFOption.UseVisualStyleBackColor = true;
            this.CPFOption.CheckedChanged += new System.EventHandler(this.CPFOption_CheckedChanged);
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
            this.ProprietarioToolStrip.Location = new System.Drawing.Point(410, 51);
            this.ProprietarioToolStrip.Name = "ProprietarioToolStrip";
            this.ProprietarioToolStrip.Size = new System.Drawing.Size(49, 25);
            this.ProprietarioToolStrip.TabIndex = 208;
            this.ProprietarioToolStrip.Text = "toolStrip2";
            // 
            // ProprietarioAddButton
            // 
            this.ProprietarioAddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ProprietarioAddButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.ProprietarioAddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProprietarioAddButton.Name = "ProprietarioAddButton";
            this.ProprietarioAddButton.Size = new System.Drawing.Size(23, 22);
            this.ProprietarioAddButton.Text = "Adicionar um condomínio";
            this.ProprietarioAddButton.ToolTipText = "Adicionar um condomínio";
            this.ProprietarioAddButton.Click += new System.EventHandler(this.ProprietarioAddButton_Click);
            // 
            // ProprietarioDelButton
            // 
            this.ProprietarioDelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ProprietarioDelButton.Image = global::GTI_Desktop.Properties.Resources.cancelar;
            this.ProprietarioDelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ProprietarioDelButton.Name = "ProprietarioDelButton";
            this.ProprietarioDelButton.Size = new System.Drawing.Size(23, 22);
            this.ProprietarioDelButton.Text = "Remover o condomínio";
            this.ProprietarioDelButton.ToolTipText = "Remover o condomínio";
            this.ProprietarioDelButton.Click += new System.EventHandler(this.ProprietarioDelButton_Click);
            // 
            // ProprietarioText
            // 
            this.ProprietarioText.Location = new System.Drawing.Point(85, 55);
            this.ProprietarioText.MaxLength = 0;
            this.ProprietarioText.Name = "ProprietarioText";
            this.ProprietarioText.ReadOnly = true;
            this.ProprietarioText.Size = new System.Drawing.Size(322, 20);
            this.ProprietarioText.TabIndex = 94;
            this.ProprietarioText.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 92;
            this.label7.Text = "Proprietário...:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.EnderecoToolStrip);
            this.groupBox1.Controls.Add(this.BairroText);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.NumeroText);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LogradouroText);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(10, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 72);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
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
            // NumeroText
            // 
            this.NumeroText.Location = new System.Drawing.Point(392, 13);
            this.NumeroText.MaxLength = 0;
            this.NumeroText.Name = "NumeroText";
            this.NumeroText.ReadOnly = true;
            this.NumeroText.Size = new System.Drawing.Size(52, 20);
            this.NumeroText.TabIndex = 90;
            this.NumeroText.TabStop = false;
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
            // LogradouroText
            // 
            this.LogradouroText.Location = new System.Drawing.Point(75, 14);
            this.LogradouroText.MaxLength = 0;
            this.LogradouroText.Name = "LogradouroText";
            this.LogradouroText.ReadOnly = true;
            this.LogradouroText.Size = new System.Drawing.Size(272, 20);
            this.LogradouroText.TabIndex = 87;
            this.LogradouroText.TabStop = false;
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
            // Empresa_Lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 425);
            this.Controls.Add(this.tBar);
            this.Controls.Add(this.MainListView);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(530, 380);
            this.Name = "Empresa_Lista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista das empresas cadastradas";
            this.EnderecoToolStrip.ResumeLayout(false);
            this.EnderecoToolStrip.PerformLayout();
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.AtividadeToolStrip.ResumeLayout(false);
            this.AtividadeToolStrip.PerformLayout();
            this.ProprietarioToolStrip.ResumeLayout(false);
            this.ProprietarioToolStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip EnderecoToolStrip;
        private System.Windows.Forms.ToolStripButton EnderecoAddButton;
        private System.Windows.Forms.ToolStripButton EnderecoDelButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TextBox RazaoSocialText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton FindButton;
        private System.Windows.Forms.ToolStripButton SelectButton;
        private System.Windows.Forms.ToolStripButton ClearButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel TotalEmpresa;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton ExcelButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox OrdemList;
        private System.Windows.Forms.TextBox BairroText;
        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader chCodigo;
        private System.Windows.Forms.ColumnHeader chDoc;
        private System.Windows.Forms.ColumnHeader chProp;
        private System.Windows.Forms.ColumnHeader chEnd;
        private System.Windows.Forms.ColumnHeader chNum;
        private System.Windows.Forms.ColumnHeader chCompl;
        private System.Windows.Forms.ColumnHeader chBairro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip ProprietarioToolStrip;
        private System.Windows.Forms.ToolStripButton ProprietarioAddButton;
        private System.Windows.Forms.ToolStripButton ProprietarioDelButton;
        private System.Windows.Forms.TextBox ProprietarioText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NumeroText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox LogradouroText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton CNPJOption;
        private System.Windows.Forms.RadioButton CPFOption;
        internal System.Windows.Forms.MaskedTextBox CPFText;
        internal System.Windows.Forms.MaskedTextBox CNPJText;
        private System.Windows.Forms.ToolStrip AtividadeToolStrip;
        private System.Windows.Forms.ToolStripButton AtividadeAddButton;
        private System.Windows.Forms.ToolStripButton AtividadeDelButton;
        private System.Windows.Forms.TextBox AtividadeText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader chRazao;
        private System.Windows.Forms.ColumnHeader chAtivNome;
        private System.Windows.Forms.ColumnHeader chAtivCod;
    }
}