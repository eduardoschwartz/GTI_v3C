namespace GTI_Desktop.Forms {
    partial class Tributo {
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
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.btAdd = new System.Windows.Forms.ToolStripButton();
            this.btEdit = new System.Windows.Forms.ToolStripButton();
            this.btDel = new System.Windows.Forms.ToolStripButton();
            this.btExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btGravar = new System.Windows.Forms.ToolStripButton();
            this.btCancelar = new System.Windows.Forms.ToolStripButton();
            this.txtResumido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompleto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstMain = new System.Windows.Forms.ListBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBar.SuspendLayout();
            this.SuspendLayout();
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
            this.tBar.Location = new System.Drawing.Point(0, 412);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(346, 25);
            this.tBar.TabIndex = 163;
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
            this.btEdit.ToolTipText = "Alterar registro";
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
            this.btDel.ToolTipText = "Excluir registro";
            this.btDel.Click += new System.EventHandler(this.BtDel_Click);
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
            this.btGravar.Click += new System.EventHandler(this.BtGravar_Click);
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
            this.btCancelar.Click += new System.EventHandler(this.BtCancelar_Click);
            // 
            // txtResumido
            // 
            this.txtResumido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtResumido.Location = new System.Drawing.Point(6, 389);
            this.txtResumido.MaxLength = 50;
            this.txtResumido.Name = "txtResumido";
            this.txtResumido.Size = new System.Drawing.Size(334, 20);
            this.txtResumido.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 159;
            this.label2.Text = "Descrição resumida";
            // 
            // txtCompleto
            // 
            this.txtCompleto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCompleto.Location = new System.Drawing.Point(6, 345);
            this.txtCompleto.MaxLength = 50;
            this.txtCompleto.Name = "txtCompleto";
            this.txtCompleto.Size = new System.Drawing.Size(334, 20);
            this.txtCompleto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 157;
            this.label1.Text = "Descrição completa";
            // 
            // lstMain
            // 
            this.lstMain.FormattingEnabled = true;
            this.lstMain.Location = new System.Drawing.Point(6, 35);
            this.lstMain.Name = "lstMain";
            this.lstMain.Size = new System.Drawing.Size(334, 290);
            this.lstMain.TabIndex = 156;
            this.lstMain.SelectedIndexChanged += new System.EventHandler(this.LstMain_SelectedIndexChanged);
            // 
            // txtFilter
            // 
            this.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFilter.Location = new System.Drawing.Point(55, 9);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(285, 20);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.TextChanged += new System.EventHandler(this.TxtFilter_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 165;
            this.label3.Text = "Busca..:";
            // 
            // Tributo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 437);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.tBar);
            this.Controls.Add(this.txtResumido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCompleto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Tributo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Tributos";
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton btAdd;
        private System.Windows.Forms.ToolStripButton btEdit;
        private System.Windows.Forms.ToolStripButton btDel;
        private System.Windows.Forms.ToolStripButton btExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btGravar;
        private System.Windows.Forms.ToolStripButton btCancelar;
        private System.Windows.Forms.TextBox txtResumido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCompleto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstMain;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label3;
    }
}