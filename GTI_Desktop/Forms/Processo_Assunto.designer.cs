namespace GTI_Desktop.Forms {
    partial class Processo_Assunto {
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
            this.lstMain = new System.Windows.Forms.CheckedListBox();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.btAdd = new System.Windows.Forms.ToolStripButton();
            this.btEdit = new System.Windows.Forms.ToolStripButton();
            this.btDel = new System.Windows.Forms.ToolStripButton();
            this.btAtivar = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.exibirTodosOsAssuntosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.somenteOsAtivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.somenteOsInativosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btExit = new System.Windows.Forms.ToolStripButton();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstCC1 = new System.Windows.Forms.ListBox();
            this.lstCC2 = new System.Windows.Forms.ListBox();
            this.lstDoc1 = new System.Windows.Forms.ListBox();
            this.lstDoc2 = new System.Windows.Forms.ListBox();
            this.btFilter = new System.Windows.Forms.Button();
            this.tTp = new System.Windows.Forms.ToolTip(this.components);
            this.btCC1 = new System.Windows.Forms.Button();
            this.btCC2 = new System.Windows.Forms.Button();
            this.btDoc2 = new System.Windows.Forms.Button();
            this.btDoc1 = new System.Windows.Forms.Button();
            this.tBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMain
            // 
            this.lstMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMain.FormattingEnabled = true;
            this.lstMain.Location = new System.Drawing.Point(6, 36);
            this.lstMain.Name = "lstMain";
            this.lstMain.Size = new System.Drawing.Size(292, 334);
            this.lstMain.TabIndex = 2;
            this.lstMain.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LstMain_ItemCheck);
            this.lstMain.SelectedIndexChanged += new System.EventHandler(this.LstMain_SelectedIndexChanged);
            this.lstMain.DoubleClick += new System.EventHandler(this.LstMain_DoubleClick);
            this.lstMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LstMain_MouseMove);
            // 
            // tBar
            // 
            this.tBar.AllowMerge = false;
            this.tBar.BackColor = System.Drawing.SystemColors.Control;
            this.tBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btAdd,
            this.btEdit,
            this.btDel,
            this.btAtivar,
            this.toolStripDropDownButton1,
            this.btExit});
            this.tBar.Location = new System.Drawing.Point(0, 373);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(839, 25);
            this.tBar.TabIndex = 31;
            this.tBar.Text = "toolStrip1";
            // 
            // btAdd
            // 
            this.btAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAdd.Image = global::GTI_Desktop.Properties.Resources.add_file;
            this.btAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(23, 22);
            this.btAdd.Text = "toolStripButton1";
            this.btAdd.ToolTipText = "Novo";
            this.btAdd.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // btEdit
            // 
            this.btEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btEdit.Image = global::GTI_Desktop.Properties.Resources.Alterar;
            this.btEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(23, 22);
            this.btEdit.Text = "toolStripButton2";
            this.btEdit.ToolTipText = "Alterar";
            this.btEdit.Click += new System.EventHandler(this.BtEdit_Click);
            // 
            // btDel
            // 
            this.btDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btDel.Image = global::GTI_Desktop.Properties.Resources.delete;
            this.btDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(23, 22);
            this.btDel.Text = "toolStripButton3";
            this.btDel.ToolTipText = "Excluir";
            this.btDel.Click += new System.EventHandler(this.BtDel_Click);
            // 
            // btAtivar
            // 
            this.btAtivar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAtivar.Image = global::GTI_Desktop.Properties.Resources.more_1_;
            this.btAtivar.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAtivar.Name = "btAtivar";
            this.btAtivar.Size = new System.Drawing.Size(23, 22);
            this.btAtivar.Text = "toolStripButton1";
            this.btAtivar.ToolTipText = "Ativar ou desativar o assunto";
            this.btAtivar.Click += new System.EventHandler(this.BtAtivar_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exibirTodosOsAssuntosToolStripMenuItem,
            this.somenteOsAtivosToolStripMenuItem,
            this.somenteOsInativosToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::GTI_Desktop.Properties.Resources.option;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ToolTipText = "Filtrar os assuntos";
            // 
            // exibirTodosOsAssuntosToolStripMenuItem
            // 
            this.exibirTodosOsAssuntosToolStripMenuItem.Name = "exibirTodosOsAssuntosToolStripMenuItem";
            this.exibirTodosOsAssuntosToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.exibirTodosOsAssuntosToolStripMenuItem.Text = "(Exibir todos os assuntos)";
            this.exibirTodosOsAssuntosToolStripMenuItem.Click += new System.EventHandler(this.ExibirTodosOsAssuntosToolStripMenuItem_Click);
            // 
            // somenteOsAtivosToolStripMenuItem
            // 
            this.somenteOsAtivosToolStripMenuItem.Name = "somenteOsAtivosToolStripMenuItem";
            this.somenteOsAtivosToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.somenteOsAtivosToolStripMenuItem.Text = "Somente os ativos";
            this.somenteOsAtivosToolStripMenuItem.Click += new System.EventHandler(this.SomenteOsAtivosToolStripMenuItem_Click);
            // 
            // somenteOsInativosToolStripMenuItem
            // 
            this.somenteOsInativosToolStripMenuItem.Name = "somenteOsInativosToolStripMenuItem";
            this.somenteOsInativosToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.somenteOsInativosToolStripMenuItem.Text = "Somente os inativos";
            this.somenteOsInativosToolStripMenuItem.Click += new System.EventHandler(this.SomenteOsInativosToolStripMenuItem_Click);
            // 
            // btExit
            // 
            this.btExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btExit.Image = global::GTI_Desktop.Properties.Resources.Exit;
            this.btExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(23, 22);
            this.btExit.Text = "toolStripButton5";
            this.btExit.ToolTipText = "Sair";
            this.btExit.Click += new System.EventHandler(this.BtExit_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(6, 13);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(251, 20);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFilter_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(314, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(519, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Locais de tramitação padrão por Assunto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Maroon;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(314, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(519, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "Documentos necessários por Assunto";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstCC1
            // 
            this.lstCC1.FormattingEnabled = true;
            this.lstCC1.Location = new System.Drawing.Point(314, 36);
            this.lstCC1.Name = "lstCC1";
            this.lstCC1.Size = new System.Drawing.Size(242, 147);
            this.lstCC1.TabIndex = 3;
            // 
            // lstCC2
            // 
            this.lstCC2.AllowDrop = true;
            this.lstCC2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstCC2.FormattingEnabled = true;
            this.lstCC2.Location = new System.Drawing.Point(591, 36);
            this.lstCC2.Name = "lstCC2";
            this.lstCC2.Size = new System.Drawing.Size(242, 147);
            this.lstCC2.TabIndex = 6;
            this.tTp.SetToolTip(this.lstCC2, "(Arraste os ítens para ordenar)");
            this.lstCC2.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstCC2_DragDrop);
            this.lstCC2.DragOver += new System.Windows.Forms.DragEventHandler(this.LstCC2_DragOver);
            this.lstCC2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LstCC2_MouseDown);
            this.lstCC2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LstCC2_MouseMove);
            // 
            // lstDoc1
            // 
            this.lstDoc1.FormattingEnabled = true;
            this.lstDoc1.Location = new System.Drawing.Point(314, 223);
            this.lstDoc1.Name = "lstDoc1";
            this.lstDoc1.Size = new System.Drawing.Size(242, 147);
            this.lstDoc1.TabIndex = 7;
            // 
            // lstDoc2
            // 
            this.lstDoc2.FormattingEnabled = true;
            this.lstDoc2.Location = new System.Drawing.Point(591, 223);
            this.lstDoc2.Name = "lstDoc2";
            this.lstDoc2.Size = new System.Drawing.Size(242, 147);
            this.lstDoc2.TabIndex = 10;
            this.lstDoc2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LstDoc2_MouseMove);
            // 
            // btFilter
            // 
            this.btFilter.Image = global::GTI_Desktop.Properties.Resources.funnel;
            this.btFilter.Location = new System.Drawing.Point(266, 13);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(32, 22);
            this.btFilter.TabIndex = 1;
            this.tTp.SetToolTip(this.btFilter, "Filtrar os assuntos");
            this.btFilter.UseVisualStyleBackColor = true;
            this.btFilter.Click += new System.EventHandler(this.BtFilter_Click);
            // 
            // btCC1
            // 
            this.btCC1.Image = global::GTI_Desktop.Properties.Resources.rightarrow;
            this.btCC1.Location = new System.Drawing.Point(562, 81);
            this.btCC1.Name = "btCC1";
            this.btCC1.Size = new System.Drawing.Size(26, 22);
            this.btCC1.TabIndex = 4;
            this.tTp.SetToolTip(this.btCC1, "Incluir local de tramitação");
            this.btCC1.UseVisualStyleBackColor = true;
            this.btCC1.Click += new System.EventHandler(this.BtCC1_Click);
            // 
            // btCC2
            // 
            this.btCC2.Image = global::GTI_Desktop.Properties.Resources.leftarrow;
            this.btCC2.Location = new System.Drawing.Point(561, 109);
            this.btCC2.Name = "btCC2";
            this.btCC2.Size = new System.Drawing.Size(26, 22);
            this.btCC2.TabIndex = 5;
            this.tTp.SetToolTip(this.btCC2, "Remover local de tramitação");
            this.btCC2.UseVisualStyleBackColor = true;
            this.btCC2.Click += new System.EventHandler(this.BtCC2_Click);
            // 
            // btDoc2
            // 
            this.btDoc2.Image = global::GTI_Desktop.Properties.Resources.leftarrow;
            this.btDoc2.Location = new System.Drawing.Point(559, 301);
            this.btDoc2.Name = "btDoc2";
            this.btDoc2.Size = new System.Drawing.Size(26, 22);
            this.btDoc2.TabIndex = 9;
            this.tTp.SetToolTip(this.btDoc2, "Remover documento");
            this.btDoc2.UseVisualStyleBackColor = true;
            this.btDoc2.Click += new System.EventHandler(this.BtDoc2_Click);
            // 
            // btDoc1
            // 
            this.btDoc1.Image = global::GTI_Desktop.Properties.Resources.rightarrow;
            this.btDoc1.Location = new System.Drawing.Point(560, 273);
            this.btDoc1.Name = "btDoc1";
            this.btDoc1.Size = new System.Drawing.Size(26, 22);
            this.btDoc1.TabIndex = 8;
            this.tTp.SetToolTip(this.btDoc1, "Influir documento");
            this.btDoc1.UseVisualStyleBackColor = true;
            this.btDoc1.Click += new System.EventHandler(this.BtDoc1_Click);
            // 
            // Processo_Assunto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 398);
            this.Controls.Add(this.btDoc2);
            this.Controls.Add(this.btDoc1);
            this.Controls.Add(this.btCC2);
            this.Controls.Add(this.btCC1);
            this.Controls.Add(this.btFilter);
            this.Controls.Add(this.lstDoc2);
            this.Controls.Add(this.lstDoc1);
            this.Controls.Add(this.lstCC2);
            this.Controls.Add(this.lstCC1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.tBar);
            this.Controls.Add(this.lstMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Processo_Assunto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documentos necessários e locais de tramitação para cada assunto";
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstMain;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton btAdd;
        private System.Windows.Forms.ToolStripButton btEdit;
        private System.Windows.Forms.ToolStripButton btDel;
        private System.Windows.Forms.ToolStripButton btExit;
        private System.Windows.Forms.ToolStripButton btAtivar;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem exibirTodosOsAssuntosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem somenteOsAtivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem somenteOsInativosToolStripMenuItem;
        private System.Windows.Forms.ListBox lstCC1;
        private System.Windows.Forms.ListBox lstCC2;
        private System.Windows.Forms.ListBox lstDoc1;
        private System.Windows.Forms.ListBox lstDoc2;
        private System.Windows.Forms.Button btFilter;
        private System.Windows.Forms.ToolTip tTp;
        private System.Windows.Forms.Button btCC1;
        private System.Windows.Forms.Button btCC2;
        private System.Windows.Forms.Button btDoc2;
        private System.Windows.Forms.Button btDoc1;
    }
}