namespace GTI_Desktop.Forms {
    partial class Extrato_Debito_Cancelar {
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
            this.CancelarButton = new System.Windows.Forms.ToolStripButton();
            this.SairButton = new System.Windows.Forms.ToolStripButton();
            this.MainListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.TipoList = new System.Windows.Forms.ComboBox();
            this.KeepCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumeroProcessoText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DataProcessoText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MotivoText = new System.Windows.Forms.TextBox();
            this.tBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tBar
            // 
            this.tBar.AllowMerge = false;
            this.tBar.BackColor = System.Drawing.Color.LemonChiffon;
            this.tBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CancelarButton,
            this.SairButton});
            this.tBar.Location = new System.Drawing.Point(0, 323);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(520, 25);
            this.tBar.TabIndex = 5;
            this.tBar.Text = "toolStrip1";
            // 
            // CancelarButton
            // 
            this.CancelarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelarButton.Image = global::GTI_Desktop.Properties.Resources.OK;
            this.CancelarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(23, 22);
            this.CancelarButton.Text = "toolStripButton2";
            this.CancelarButton.ToolTipText = "Cancelar os débitos selecionados";
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // SairButton
            // 
            this.SairButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SairButton.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.SairButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SairButton.Name = "SairButton";
            this.SairButton.Size = new System.Drawing.Size(23, 22);
            this.SairButton.Text = "toolStripButton1";
            this.SairButton.ToolTipText = "Fechar a tela sem cancelar";
            this.SairButton.Click += new System.EventHandler(this.SairButton_Click);
            // 
            // MainListView
            // 
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader13,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.MainListView.FullRowSelect = true;
            this.MainListView.GridLines = true;
            this.MainListView.Location = new System.Drawing.Point(6, 6);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(508, 183);
            this.MainListView.TabIndex = 0;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ano";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Lançamento";
            this.columnHeader2.Width = 227;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Sq";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 27;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Pc";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 26;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Cp";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 27;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Dt.Vencto";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 72;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Principal";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Juros";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 0;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Multa";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader9.Width = 0;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Correção";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader13.Width = 0;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Total";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader10.Width = 0;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Livro";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader11.Width = 0;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Folha";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader12.Width = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Tipo de cancelamento.:";
            // 
            // TipoList
            // 
            this.TipoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoList.FormattingEnabled = true;
            this.TipoList.Location = new System.Drawing.Point(137, 199);
            this.TipoList.Name = "TipoList";
            this.TipoList.Size = new System.Drawing.Size(166, 21);
            this.TipoList.TabIndex = 1;
            this.TipoList.SelectedIndexChanged += new System.EventHandler(this.TipoList_SelectedIndexChanged);
            // 
            // KeepCheckBox
            // 
            this.KeepCheckBox.AutoSize = true;
            this.KeepCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.KeepCheckBox.Location = new System.Drawing.Point(370, 228);
            this.KeepCheckBox.Name = "KeepCheckBox";
            this.KeepCheckBox.Size = new System.Drawing.Size(144, 17);
            this.KeepCheckBox.TabIndex = 3;
            this.KeepCheckBox.Text = "Manter na tela de extrato";
            this.KeepCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.KeepCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Nº do Processo..:";
            // 
            // NumeroProcessoText
            // 
            this.NumeroProcessoText.Location = new System.Drawing.Point(108, 226);
            this.NumeroProcessoText.MaxLength = 12;
            this.NumeroProcessoText.Name = "NumeroProcessoText";
            this.NumeroProcessoText.Size = new System.Drawing.Size(76, 20);
            this.NumeroProcessoText.TabIndex = 2;
            this.NumeroProcessoText.TextChanged += new System.EventHandler(this.NumeroProcessoText_TextChanged);
            this.NumeroProcessoText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumeroProcessoText_KeyDown);
            this.NumeroProcessoText.Leave += new System.EventHandler(this.NumeroProcessoText_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "Data do Processo..:";
            // 
            // DataProcessoText
            // 
            this.DataProcessoText.AutoSize = true;
            this.DataProcessoText.ForeColor = System.Drawing.Color.Maroon;
            this.DataProcessoText.Location = new System.Drawing.Point(297, 230);
            this.DataProcessoText.Name = "DataProcessoText";
            this.DataProcessoText.Size = new System.Drawing.Size(0, 13);
            this.DataProcessoText.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = "Motivo..:";
            // 
            // MotivoText
            // 
            this.MotivoText.Location = new System.Drawing.Point(66, 256);
            this.MotivoText.MaxLength = 500;
            this.MotivoText.Multiline = true;
            this.MotivoText.Name = "MotivoText";
            this.MotivoText.Size = new System.Drawing.Size(448, 64);
            this.MotivoText.TabIndex = 4;
            // 
            // Extrato_Debito_Cancelar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(520, 348);
            this.Controls.Add(this.MotivoText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DataProcessoText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumeroProcessoText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KeepCheckBox);
            this.Controls.Add(this.TipoList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainListView);
            this.Controls.Add(this.tBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Extrato_Debito_Cancelar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelamento de débito";
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton CancelarButton;
        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TipoList;
        private System.Windows.Forms.CheckBox KeepCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NumeroProcessoText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label DataProcessoText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MotivoText;
        private System.Windows.Forms.ToolStripButton SairButton;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
    }
}