namespace GTI_Desktop.Forms {
    partial class SelectForm {
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
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.BtAll = new System.Windows.Forms.ToolStripButton();
            this.BtNone = new System.Windows.Forms.ToolStripButton();
            this.BtCancel = new System.Windows.Forms.ToolStripButton();
            this.BtSair = new System.Windows.Forms.ToolStripButton();
            this.LstMain = new System.Windows.Forms.CheckedListBox();
            this.a1Panel1 = new Owf.Controls.A1Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tBar.SuspendLayout();
            this.a1Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tBar
            // 
            this.tBar.AllowMerge = false;
            this.tBar.BackColor = System.Drawing.SystemColors.Control;
            this.tBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtAll,
            this.BtNone,
            this.BtCancel,
            this.BtSair});
            this.tBar.Location = new System.Drawing.Point(0, 284);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(259, 25);
            this.tBar.TabIndex = 27;
            this.tBar.Text = "toolStrip1";
            // 
            // BtAll
            // 
            this.BtAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtAll.Image = global::GTI_Desktop.Properties.Resources.add;
            this.BtAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtAll.Name = "BtAll";
            this.BtAll.Size = new System.Drawing.Size(23, 22);
            this.BtAll.Text = "toolStripButton1";
            this.BtAll.ToolTipText = "Selecionar todas as opções";
            this.BtAll.Click += new System.EventHandler(this.BtAll_Click);
            // 
            // BtNone
            // 
            this.BtNone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtNone.Image = global::GTI_Desktop.Properties.Resources.cancelar;
            this.BtNone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtNone.Name = "BtNone";
            this.BtNone.Size = new System.Drawing.Size(23, 22);
            this.BtNone.Text = "toolStripButton2";
            this.BtNone.ToolTipText = "Desmarcar todos os ítens";
            this.BtNone.Click += new System.EventHandler(this.BtNone_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtCancel.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.BtCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(23, 22);
            this.BtCancel.Text = "toolStripButton1";
            this.BtCancel.ToolTipText = "Cancelar operação";
            // 
            // BtSair
            // 
            this.BtSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtSair.Image = global::GTI_Desktop.Properties.Resources.Exit;
            this.BtSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtSair.Name = "BtSair";
            this.BtSair.Size = new System.Drawing.Size(23, 22);
            this.BtSair.Text = "toolStripButton5";
            this.BtSair.ToolTipText = "Sair da tela e retornar a seleção";
            this.BtSair.Click += new System.EventHandler(this.BtSair_Click);
            // 
            // LstMain
            // 
            this.LstMain.BackColor = System.Drawing.Color.Linen;
            this.LstMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LstMain.CheckOnClick = true;
            this.LstMain.FormattingEnabled = true;
            this.LstMain.Location = new System.Drawing.Point(6, 6);
            this.LstMain.Name = "LstMain";
            this.LstMain.Size = new System.Drawing.Size(248, 270);
            this.LstMain.TabIndex = 28;
            // 
            // a1Panel1
            // 
            this.a1Panel1.BorderColor = System.Drawing.Color.Transparent;
            this.a1Panel1.BorderWidth = 0;
            this.a1Panel1.Controls.Add(this.LstMain);
            this.a1Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a1Panel1.GradientEndColor = System.Drawing.Color.Linen;
            this.a1Panel1.GradientStartColor = System.Drawing.Color.Linen;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(0, 0);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.Size = new System.Drawing.Size(259, 284);
            this.a1Panel1.TabIndex = 29;
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 309);
            this.ControlBox = false;
            this.Controls.Add(this.a1Panel1);
            this.Controls.Add(this.tBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecione as opções desejadas";
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.a1Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton BtAll;
        private System.Windows.Forms.ToolStripButton BtNone;
        private System.Windows.Forms.ToolStripButton BtSair;
        private System.Windows.Forms.CheckedListBox LstMain;
        private Owf.Controls.A1Panel a1Panel1;
        private System.Windows.Forms.ToolStripButton BtCancel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}