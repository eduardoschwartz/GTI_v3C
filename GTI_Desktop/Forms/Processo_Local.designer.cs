namespace GTI_Desktop.Forms {
    partial class Processo_Local {
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
            this.tvMain = new System.Windows.Forms.TreeView();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.btAdd = new System.Windows.Forms.ToolStripButton();
            this.btEdit = new System.Windows.Forms.ToolStripButton();
            this.btDel = new System.Windows.Forms.ToolStripButton();
            this.btExit = new System.Windows.Forms.ToolStripButton();
            this.btGravar = new System.Windows.Forms.ToolStripButton();
            this.btCancelar = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtVinculo = new System.Windows.Forms.TextBox();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.txtFone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvMain
            // 
            this.tvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvMain.Location = new System.Drawing.Point(6, 6);
            this.tvMain.Name = "tvMain";
            this.tvMain.Size = new System.Drawing.Size(464, 330);
            this.tvMain.TabIndex = 0;
            this.tvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvMain_AfterSelect);
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
            this.btGravar,
            this.btCancelar});
            this.tBar.Location = new System.Drawing.Point(0, 434);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(476, 25);
            this.tBar.TabIndex = 32;
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
            // btGravar
            // 
            this.btGravar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btGravar.Image = global::GTI_Desktop.Properties.Resources.gravar;
            this.btGravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(23, 22);
            this.btGravar.Text = "toolStripButton1";
            this.btGravar.ToolTipText = "Gravar os dados";
            this.btGravar.Click += new System.EventHandler(this.BtGravar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCancelar.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.btCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(23, 22);
            this.btCancelar.Text = "toolStripButton2";
            this.btCancelar.ToolTipText = "Cancelar";
            this.btCancelar.Click += new System.EventHandler(this.BtCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.txtVinculo);
            this.panel1.Controls.Add(this.chkAtivo);
            this.panel1.Controls.Add(this.txtFone);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 340);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 91);
            this.panel1.TabIndex = 33;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(72, 36);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(376, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // txtVinculo
            // 
            this.txtVinculo.Location = new System.Drawing.Point(72, 10);
            this.txtVinculo.Name = "txtVinculo";
            this.txtVinculo.Size = new System.Drawing.Size(376, 20);
            this.txtVinculo.TabIndex = 1;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAtivo.Location = new System.Drawing.Point(370, 64);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(78, 17);
            this.chkAtivo.TabIndex = 4;
            this.chkAtivo.Text = "Local ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // txtFone
            // 
            this.txtFone.Location = new System.Drawing.Point(72, 62);
            this.txtFone.Name = "txtFone";
            this.txtFone.Size = new System.Drawing.Size(123, 20);
            this.txtFone.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Telefone...:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição.:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vínculo....:";
            // 
            // Processo_Local
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 459);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tBar);
            this.Controls.Add(this.tvMain);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(492, 298);
            this.Name = "Processo_Local";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local de tramitação de processos";
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton btAdd;
        private System.Windows.Forms.ToolStripButton btEdit;
        private System.Windows.Forms.ToolStripButton btDel;
        private System.Windows.Forms.ToolStripButton btExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.TextBox txtFone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtVinculo;
        private System.Windows.Forms.ToolStripButton btGravar;
        private System.Windows.Forms.ToolStripButton btCancelar;
    }
}