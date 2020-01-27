namespace GTI_Desktop.User_Controls {
    partial class ctlTributoEditor {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lvTrib = new System.Windows.Forms.ListView();
            this.Col0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tTp = new System.Windows.Forms.ToolTip(this.components);
            this.txtValor = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label34 = new System.Windows.Forms.Label();
            this.cmbTributo = new System.Windows.Forms.ComboBox();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.btAdd = new System.Windows.Forms.ToolStripButton();
            this.btEdit = new System.Windows.Forms.ToolStripButton();
            this.btDel = new System.Windows.Forms.ToolStripButton();
            this.btExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btGravar = new System.Windows.Forms.ToolStripButton();
            this.btCancelar = new System.Windows.Forms.ToolStripButton();
            this.tBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvTrib
            // 
            this.lvTrib.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvTrib.CausesValidation = false;
            this.lvTrib.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Col0,
            this.Col1,
            this.Col2});
            this.lvTrib.FullRowSelect = true;
            this.lvTrib.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTrib.HideSelection = false;
            this.lvTrib.LabelWrap = false;
            this.lvTrib.Location = new System.Drawing.Point(5, 3);
            this.lvTrib.Name = "lvTrib";
            this.lvTrib.ShowGroups = false;
            this.lvTrib.ShowItemToolTips = true;
            this.lvTrib.Size = new System.Drawing.Size(366, 94);
            this.lvTrib.TabIndex = 84;
            this.lvTrib.UseCompatibleStateImageBehavior = false;
            this.lvTrib.View = System.Windows.Forms.View.Details;
            this.lvTrib.SelectedIndexChanged += new System.EventHandler(this.lvTrib_SelectedIndexChanged);
            // 
            // Col0
            // 
            this.Col0.Text = "Cod";
            this.Col0.Width = 40;
            // 
            // Col1
            // 
            this.Col1.Text = "Descrição do Tributo";
            this.Col1.Width = 230;
            // 
            // Col2
            // 
            this.Col2.Text = "Vl.Tributo";
            this.Col2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Col2.Width = 70;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(278, 102);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(91, 20);
            this.txtValor.TabIndex = 85;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(234, 105);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 13);
            this.Label1.TabIndex = 91;
            this.Label1.Text = "Valor..:";
            // 
            // Label34
            // 
            this.Label34.AutoSize = true;
            this.Label34.Location = new System.Drawing.Point(4, 104);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(46, 13);
            this.Label34.TabIndex = 90;
            this.Label34.Text = "Tributo.:";
            // 
            // cmbTributo
            // 
            this.cmbTributo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTributo.DropDownWidth = 280;
            this.cmbTributo.Enabled = false;
            this.cmbTributo.FormattingEnabled = true;
            this.cmbTributo.Location = new System.Drawing.Point(52, 101);
            this.cmbTributo.Name = "cmbTributo";
            this.cmbTributo.Size = new System.Drawing.Size(176, 21);
            this.cmbTributo.TabIndex = 94;
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
            this.btExit,
            this.toolStripSeparator1,
            this.btGravar,
            this.btCancelar});
            this.tBar.Location = new System.Drawing.Point(0, 130);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(374, 25);
            this.tBar.TabIndex = 164;
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
            this.btAdd.ToolTipText = "Novo registro";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btEdit
            // 
            this.btEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btEdit.Image = global::GTI_Desktop.Properties.Resources.Alterar;
            this.btEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(23, 22);
            this.btEdit.Text = "toolStripButton2";
            this.btEdit.ToolTipText = "Alterar registro";
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btDel
            // 
            this.btDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btDel.Image = global::GTI_Desktop.Properties.Resources.delete;
            this.btDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(23, 22);
            this.btDel.Text = "toolStripButton3";
            this.btDel.ToolTipText = "Excluir registro";
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
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
            this.btExit.Click += new System.EventHandler(this.btSair_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btGravar
            // 
            this.btGravar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btGravar.Image = global::GTI_Desktop.Properties.Resources.gravar;
            this.btGravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(23, 22);
            this.btGravar.Text = "btGravar";
            this.btGravar.ToolTipText = "Gravar os dados";
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.AccessibleDescription = "Cancelar operação";
            this.btCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCancelar.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.btCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(23, 22);
            this.btCancelar.Text = "btCancelar";
            this.btCancelar.ToolTipText = "Cancelar inclusão/alteração";
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // ctlTributoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tBar);
            this.Controls.Add(this.cmbTributo);
            this.Controls.Add(this.lvTrib);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label34);
            this.Name = "ctlTributoEditor";
            this.Size = new System.Drawing.Size(374, 155);
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListView lvTrib;
        internal System.Windows.Forms.ColumnHeader Col0;
        internal System.Windows.Forms.ColumnHeader Col1;
        internal System.Windows.Forms.ColumnHeader Col2;
        internal System.Windows.Forms.ToolTip tTp;
        internal System.Windows.Forms.TextBox txtValor;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label34;
        private System.Windows.Forms.ComboBox cmbTributo;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton btAdd;
        private System.Windows.Forms.ToolStripButton btEdit;
        private System.Windows.Forms.ToolStripButton btDel;
        private System.Windows.Forms.ToolStripButton btExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btGravar;
        private System.Windows.Forms.ToolStripButton btCancelar;
    }
}
