namespace GTI_Desktop.Forms {
    partial class Usuario {
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
            this.FindButton = new System.Windows.Forms.ToolStripButton();
            this.ExitButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.CancelarButton = new System.Windows.Forms.ToolStripButton();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.NomeLoginTextBox = new System.Windows.Forms.TextBox();
            this.NomeCompletoTextBox = new System.Windows.Forms.TextBox();
            this.AtivoCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LocalComboBox = new System.Windows.Forms.ComboBox();
            this.LocalTextBox = new System.Windows.Forms.TextBox();
            this.a1Panel1 = new Owf.Controls.A1Panel();
            this.LocalListBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.AddButton,
            this.EditButton,
            this.FindButton,
            this.ExitButton,
            this.toolStripSeparator1,
            this.SaveButton,
            this.CancelarButton});
            this.tBar.Location = new System.Drawing.Point(0, 345);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(490, 25);
            this.tBar.TabIndex = 0;
            this.tBar.TabStop = true;
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
            this.AddButton.ToolTipText = "Novo registro";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditButton.Image = global::GTI_Desktop.Properties.Resources.Alterar;
            this.EditButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(23, 22);
            this.EditButton.Text = "toolStripButton2";
            this.EditButton.ToolTipText = "Alterar registro";
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // FindButton
            // 
            this.FindButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FindButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.FindButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(23, 22);
            this.FindButton.Text = "toolStripButton4";
            this.FindButton.ToolTipText = "Abrir tela de pesquisa";
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
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
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // SaveButton
            // 
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Image = global::GTI_Desktop.Properties.Resources.gravar;
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(23, 22);
            this.SaveButton.Text = "btGravar";
            this.SaveButton.ToolTipText = "Gravar os dados";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.AccessibleDescription = "Cancelar operação";
            this.CancelarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelarButton.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.CancelarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(23, 22);
            this.CancelarButton.ToolTipText = "Cancelar inclusão/alteração";
            this.CancelarButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 47);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(84, 13);
            this.Label2.TabIndex = 158;
            this.Label2.Text = "Nome completo:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 74);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(85, 13);
            this.Label3.TabIndex = 159;
            this.Label3.Text = "Nome de Login.:";
            // 
            // NomeLoginTextBox
            // 
            this.NomeLoginTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NomeLoginTextBox.Location = new System.Drawing.Point(101, 71);
            this.NomeLoginTextBox.MaxLength = 25;
            this.NomeLoginTextBox.Name = "NomeLoginTextBox";
            this.NomeLoginTextBox.Size = new System.Drawing.Size(273, 20);
            this.NomeLoginTextBox.TabIndex = 2;
            this.NomeLoginTextBox.Enter += new System.EventHandler(this.NomeLoginTextBox_Enter);
            // 
            // NomeCompletoTextBox
            // 
            this.NomeCompletoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NomeCompletoTextBox.Location = new System.Drawing.Point(101, 44);
            this.NomeCompletoTextBox.MaxLength = 100;
            this.NomeCompletoTextBox.Name = "NomeCompletoTextBox";
            this.NomeCompletoTextBox.Size = new System.Drawing.Size(380, 20);
            this.NomeCompletoTextBox.TabIndex = 1;
            // 
            // AtivoCheckbox
            // 
            this.AtivoCheckbox.AutoSize = true;
            this.AtivoCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AtivoCheckbox.Location = new System.Drawing.Point(393, 74);
            this.AtivoCheckbox.Name = "AtivoCheckbox";
            this.AtivoCheckbox.Size = new System.Drawing.Size(88, 17);
            this.AtivoCheckbox.TabIndex = 3;
            this.AtivoCheckbox.Text = "Usuário ativo";
            this.AtivoCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AtivoCheckbox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 161;
            this.label1.Text = "Usuário Id.........:";
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.ForeColor = System.Drawing.Color.Maroon;
            this.IdLabel.Location = new System.Drawing.Point(98, 20);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(13, 13);
            this.IdLabel.TabIndex = 0;
            this.IdLabel.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 164;
            this.label5.Text = "Locação atual..:";
            // 
            // LocalComboBox
            // 
            this.LocalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocalComboBox.FormattingEnabled = true;
            this.LocalComboBox.Location = new System.Drawing.Point(101, 97);
            this.LocalComboBox.Name = "LocalComboBox";
            this.LocalComboBox.Size = new System.Drawing.Size(377, 21);
            this.LocalComboBox.TabIndex = 4;
            // 
            // LocalTextBox
            // 
            this.LocalTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.LocalTextBox.Location = new System.Drawing.Point(101, 97);
            this.LocalTextBox.MaxLength = 100;
            this.LocalTextBox.Name = "LocalTextBox";
            this.LocalTextBox.ReadOnly = true;
            this.LocalTextBox.Size = new System.Drawing.Size(380, 20);
            this.LocalTextBox.TabIndex = 165;
            // 
            // a1Panel1
            // 
            this.a1Panel1.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel1.Controls.Add(this.LocalListBox);
            this.a1Panel1.Controls.Add(this.label4);
            this.a1Panel1.GradientEndColor = System.Drawing.SystemColors.Control;
            this.a1Panel1.GradientStartColor = System.Drawing.SystemColors.Control;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(5, 132);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.Size = new System.Drawing.Size(485, 210);
            this.a1Panel1.TabIndex = 166;
            // 
            // LocalListBox
            // 
            this.LocalListBox.CheckOnClick = true;
            this.LocalListBox.FormattingEnabled = true;
            this.LocalListBox.Location = new System.Drawing.Point(3, 18);
            this.LocalListBox.Name = "LocalListBox";
            this.LocalListBox.Size = new System.Drawing.Size(474, 184);
            this.LocalListBox.TabIndex = 1;
            this.LocalListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LocalListBox_ItemCheck);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Maroon;
            this.label4.ForeColor = System.Drawing.Color.Linen;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(480, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Permissão de trâmite de processos nos seguintes locais";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 370);
            this.Controls.Add(this.a1Panel1);
            this.Controls.Add(this.LocalTextBox);
            this.Controls.Add(this.LocalComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AtivoCheckbox);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.NomeLoginTextBox);
            this.Controls.Add(this.NomeCompletoTextBox);
            this.Controls.Add(this.tBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de usuários";
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.a1Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton AddButton;
        private System.Windows.Forms.ToolStripButton EditButton;
        private System.Windows.Forms.ToolStripButton FindButton;
        private System.Windows.Forms.ToolStripButton ExitButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton CancelarButton;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox NomeLoginTextBox;
        internal System.Windows.Forms.TextBox NomeCompletoTextBox;
        private System.Windows.Forms.CheckBox AtivoCheckbox;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label IdLabel;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox LocalComboBox;
        internal System.Windows.Forms.TextBox LocalTextBox;
        private Owf.Controls.A1Panel a1Panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox LocalListBox;
    }
}