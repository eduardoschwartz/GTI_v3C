namespace GTI_Desktop.Forms {
    partial class Usuario_Lista {
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
            this.CPF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.AtivoCheckBox = new System.Windows.Forms.CheckBox();
            this.BuscaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.ReturnButton = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.tBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainListView
            // 
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.CPF,
            this.columnHeader3});
            this.MainListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainListView.FullRowSelect = true;
            this.MainListView.Location = new System.Drawing.Point(0, 28);
            this.MainListView.Name = "MainListView";
            this.MainListView.ShowItemToolTips = true;
            this.MainListView.Size = new System.Drawing.Size(752, 422);
            this.MainListView.TabIndex = 76;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.MainListView_ColumnClick);
            this.MainListView.DoubleClick += new System.EventHandler(this.MainListView_DoubleClick);
            this.MainListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nome";
            this.columnHeader2.Width = 300;
            // 
            // CPF
            // 
            this.CPF.Text = "Login";
            this.CPF.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Setor";
            this.columnHeader3.Width = 200;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.AtivoCheckBox);
            this.panel1.Controls.Add(this.BuscaTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 28);
            this.panel1.TabIndex = 75;
            // 
            // AtivoCheckBox
            // 
            this.AtivoCheckBox.AutoSize = true;
            this.AtivoCheckBox.Location = new System.Drawing.Point(563, 5);
            this.AtivoCheckBox.Name = "AtivoCheckBox";
            this.AtivoCheckBox.Size = new System.Drawing.Size(99, 17);
            this.AtivoCheckBox.TabIndex = 73;
            this.AtivoCheckBox.Text = "Somente ativos";
            this.AtivoCheckBox.UseVisualStyleBackColor = true;
            this.AtivoCheckBox.CheckedChanged += new System.EventHandler(this.AtivoCheckBox_CheckedChanged);
            // 
            // BuscaTextBox
            // 
            this.BuscaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BuscaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.BuscaTextBox.Location = new System.Drawing.Point(74, 3);
            this.BuscaTextBox.Name = "BuscaTextBox";
            this.BuscaTextBox.Size = new System.Drawing.Size(483, 20);
            this.BuscaTextBox.TabIndex = 72;
            this.BuscaTextBox.TextChanged += new System.EventHandler(this.BuscaTextBox_TextChanged);
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
            // tBar
            // 
            this.tBar.AllowMerge = false;
            this.tBar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tBar.BackColor = System.Drawing.SystemColors.Control;
            this.tBar.Dock = System.Windows.Forms.DockStyle.None;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReturnButton});
            this.tBar.Location = new System.Drawing.Point(665, 0);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(81, 25);
            this.tBar.TabIndex = 70;
            this.tBar.Text = "toolStrip1";
            // 
            // ReturnButton
            // 
            this.ReturnButton.Image = global::GTI_Desktop.Properties.Resources.rightarrow;
            this.ReturnButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(72, 22);
            this.ReturnButton.Text = "Retornar";
            this.ReturnButton.ToolTipText = "Retornar o usuário selecionado";
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // Usuario_Lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 450);
            this.Controls.Add(this.MainListView);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Usuario_Lista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuario_Lista";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader CPF;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox BuscaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton ReturnButton;
        private System.Windows.Forms.CheckBox AtivoCheckBox;
    }
}