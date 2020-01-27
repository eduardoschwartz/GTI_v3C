namespace GTI_Desktop.Forms {
    partial class Bairro {
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
            this.AddButton = new System.Windows.Forms.ToolStripButton();
            this.EditButton = new System.Windows.Forms.ToolStripButton();
            this.DelButton = new System.Windows.Forms.ToolStripButton();
            this.ExitButton = new System.Windows.Forms.ToolStripButton();
            this.BairroListBox = new System.Windows.Forms.ListBox();
            this.CidadeCombo = new System.Windows.Forms.ComboBox();
            this.UFCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.AddButton,
            this.EditButton,
            this.DelButton,
            this.ExitButton});
            this.tBar.Location = new System.Drawing.Point(0, 330);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(303, 25);
            this.tBar.TabIndex = 24;
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
            this.AddButton.ToolTipText = "Novo";
            this.AddButton.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // EditButton
            // 
            this.EditButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditButton.Image = global::GTI_Desktop.Properties.Resources.Alterar;
            this.EditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(23, 22);
            this.EditButton.Text = "toolStripButton2";
            this.EditButton.ToolTipText = "Alterar";
            this.EditButton.Click += new System.EventHandler(this.BtEdit_Click);
            // 
            // DelButton
            // 
            this.DelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DelButton.Image = global::GTI_Desktop.Properties.Resources.delete;
            this.DelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(23, 22);
            this.DelButton.Text = "toolStripButton3";
            this.DelButton.ToolTipText = "Excluir";
            this.DelButton.Click += new System.EventHandler(this.BtDel_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExitButton.Image = global::GTI_Desktop.Properties.Resources.Exit;
            this.ExitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(23, 22);
            this.ExitButton.Text = "toolStripButton5";
            this.ExitButton.ToolTipText = "Sair";
            this.ExitButton.Click += new System.EventHandler(this.BtExit_Click);
            // 
            // BairroListBox
            // 
            this.BairroListBox.FormattingEnabled = true;
            this.BairroListBox.Location = new System.Drawing.Point(6, 59);
            this.BairroListBox.Name = "BairroListBox";
            this.BairroListBox.Size = new System.Drawing.Size(291, 264);
            this.BairroListBox.TabIndex = 23;
            this.BairroListBox.DoubleClick += new System.EventHandler(this.LstBairro_DoubleClick);
            // 
            // CidadeCombo
            // 
            this.CidadeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CidadeCombo.FormattingEnabled = true;
            this.CidadeCombo.Location = new System.Drawing.Point(58, 32);
            this.CidadeCombo.Name = "CidadeCombo";
            this.CidadeCombo.Size = new System.Drawing.Size(239, 21);
            this.CidadeCombo.TabIndex = 22;
            this.CidadeCombo.SelectedIndexChanged += new System.EventHandler(this.CmbCidade_SelectedIndexChanged);
            // 
            // UFCombo
            // 
            this.UFCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UFCombo.FormattingEnabled = true;
            this.UFCombo.Location = new System.Drawing.Point(58, 5);
            this.UFCombo.Name = "UFCombo";
            this.UFCombo.Size = new System.Drawing.Size(48, 21);
            this.UFCombo.TabIndex = 21;
            this.UFCombo.SelectedIndexChanged += new System.EventHandler(this.CmbUF_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "UF........:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Cidade..:";
            // 
            // Bairro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(303, 355);
            this.Controls.Add(this.tBar);
            this.Controls.Add(this.BairroListBox);
            this.Controls.Add(this.CidadeCombo);
            this.Controls.Add(this.UFCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Bairro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de bairros";
            this.Load += new System.EventHandler(this.Bairro_Load);
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton AddButton;
        private System.Windows.Forms.ToolStripButton EditButton;
        private System.Windows.Forms.ToolStripButton DelButton;
        private System.Windows.Forms.ToolStripButton ExitButton;
        private System.Windows.Forms.ListBox BairroListBox;
        private System.Windows.Forms.ComboBox CidadeCombo;
        private System.Windows.Forms.ComboBox UFCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}