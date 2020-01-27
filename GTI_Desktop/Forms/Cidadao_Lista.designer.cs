namespace GTI_Desktop.Forms {
    partial class Cidadao_Lista {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cidadao_Lista));
            this.MainListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CPF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BuscaText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TopBar = new System.Windows.Forms.ToolStrip();
            this.TitleMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.NomeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CPFMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CNPJMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FindButton = new System.Windows.Forms.ToolStripButton();
            this.ReturnButton = new System.Windows.Forms.ToolStripButton();
            this.StatusBar = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TotalCidadao = new System.Windows.Forms.ToolStripLabel();
            this.panel1.SuspendLayout();
            this.TopBar.SuspendLayout();
            this.StatusBar.SuspendLayout();
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
            this.CPF,
            this.columnHeader3});
            this.MainListView.FullRowSelect = true;
            this.MainListView.Location = new System.Drawing.Point(0, 28);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(648, 330);
            this.MainListView.TabIndex = 74;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.VirtualMode = true;
            this.MainListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvMain_RetrieveVirtualItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nome";
            this.columnHeader2.Width = 300;
            // 
            // CPF
            // 
            this.CPF.Text = "CPF";
            this.CPF.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "CNPJ";
            this.columnHeader3.Width = 120;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BuscaText);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TopBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 28);
            this.panel1.TabIndex = 73;
            // 
            // BuscaText
            // 
            this.BuscaText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BuscaText.Location = new System.Drawing.Point(74, 3);
            this.BuscaText.Name = "BuscaText";
            this.BuscaText.Size = new System.Drawing.Size(393, 20);
            this.BuscaText.TabIndex = 72;
            this.BuscaText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBusca_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Pesquisa..:";
            // 
            // TopBar
            // 
            this.TopBar.AllowMerge = false;
            this.TopBar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TopBar.BackColor = System.Drawing.SystemColors.Control;
            this.TopBar.Dock = System.Windows.Forms.DockStyle.None;
            this.TopBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TopBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TitleMenu,
            this.FindButton,
            this.ReturnButton});
            this.TopBar.Location = new System.Drawing.Point(574, 0);
            this.TopBar.Name = "TopBar";
            this.TopBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.TopBar.Size = new System.Drawing.Size(68, 25);
            this.TopBar.TabIndex = 70;
            this.TopBar.Text = "toolStrip1";
            // 
            // TitleMenu
            // 
            this.TitleMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TitleMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NomeMenu,
            this.CPFMenu,
            this.CNPJMenu});
            this.TitleMenu.Image = ((System.Drawing.Image)(resources.GetObject("TitleMenu.Image")));
            this.TitleMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TitleMenu.Name = "TitleMenu";
            this.TitleMenu.Size = new System.Drawing.Size(13, 22);
            // 
            // NomeMenu
            // 
            this.NomeMenu.CheckOnClick = true;
            this.NomeMenu.Name = "NomeMenu";
            this.NomeMenu.Size = new System.Drawing.Size(180, 22);
            this.NomeMenu.Text = "Nome";
            this.NomeMenu.Click += new System.EventHandler(this.MnuNome_Click);
            // 
            // CPFMenu
            // 
            this.CPFMenu.CheckOnClick = true;
            this.CPFMenu.Name = "CPFMenu";
            this.CPFMenu.Size = new System.Drawing.Size(180, 22);
            this.CPFMenu.Text = "CPF";
            this.CPFMenu.Click += new System.EventHandler(this.MnuCPF_Click);
            // 
            // CNPJMenu
            // 
            this.CNPJMenu.CheckOnClick = true;
            this.CNPJMenu.Name = "CNPJMenu";
            this.CNPJMenu.Size = new System.Drawing.Size(180, 22);
            this.CNPJMenu.Text = "CNPJ";
            this.CNPJMenu.Click += new System.EventHandler(this.MnuCNPJ_Click);
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
            this.FindButton.Click += new System.EventHandler(this.BtFind_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReturnButton.Image = global::GTI_Desktop.Properties.Resources.rightarrow;
            this.ReturnButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(23, 22);
            this.ReturnButton.Text = "toolStripButton2";
            this.ReturnButton.ToolTipText = "Retornar";
            this.ReturnButton.Click += new System.EventHandler(this.BtReturn_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.TotalCidadao});
            this.StatusBar.Location = new System.Drawing.Point(0, 361);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(648, 25);
            this.StatusBar.TabIndex = 75;
            this.StatusBar.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(106, 22);
            this.toolStripLabel1.Text = "Total encontrado..:";
            // 
            // TotalCidadao
            // 
            this.TotalCidadao.ForeColor = System.Drawing.Color.Maroon;
            this.TotalCidadao.Name = "TotalCidadao";
            this.TotalCidadao.Size = new System.Drawing.Size(13, 22);
            this.TotalCidadao.Text = "0";
            // 
            // Cidadao_Lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 386);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MainListView);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(586, 345);
            this.Name = "Cidadao_Lista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Cidadão";
            this.Activated += new System.EventHandler(this.Cidadao_Lista_Activated);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TopBar.ResumeLayout(false);
            this.TopBar.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader CPF;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox BuscaText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip TopBar;
        private System.Windows.Forms.ToolStripDropDownButton TitleMenu;
        private System.Windows.Forms.ToolStripMenuItem NomeMenu;
        private System.Windows.Forms.ToolStripMenuItem CPFMenu;
        private System.Windows.Forms.ToolStripMenuItem CNPJMenu;
        private System.Windows.Forms.ToolStripButton FindButton;
        private System.Windows.Forms.ToolStripButton ReturnButton;
        private System.Windows.Forms.ToolStrip StatusBar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel TotalCidadao;
    }
}