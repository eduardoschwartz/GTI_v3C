namespace GTI_Desktop.Forms {
    partial class Cnae {
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
            this.a1Panel1 = new Owf.Controls.A1Panel();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.Busca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.a1Panel2 = new Owf.Controls.A1Panel();
            this.CriterioListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btCC2 = new System.Windows.Forms.Button();
            this.btCC1 = new System.Windows.Forms.Button();
            this.ValorText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CriterioList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.a1Panel1.SuspendLayout();
            this.a1Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainListView
            // 
            this.MainListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MainListView.FullRowSelect = true;
            this.MainListView.Location = new System.Drawing.Point(3, 50);
            this.MainListView.MultiSelect = false;
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(573, 342);
            this.MainListView.TabIndex = 2;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.SelectedIndexChanged += new System.EventHandler(this.MainListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "CNAE";
            this.columnHeader1.Width = 81;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descrição";
            this.columnHeader2.Width = 490;
            // 
            // a1Panel1
            // 
            this.a1Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.a1Panel1.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel1.Controls.Add(this.CancelarButton);
            this.a1Panel1.Controls.Add(this.SelectButton);
            this.a1Panel1.Controls.Add(this.Busca);
            this.a1Panel1.Controls.Add(this.label1);
            this.a1Panel1.GradientEndColor = System.Drawing.SystemColors.Control;
            this.a1Panel1.GradientStartColor = System.Drawing.SystemColors.Control;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(3, 3);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.RoundCornerRadius = 7;
            this.a1Panel1.ShadowOffSet = 3;
            this.a1Panel1.Size = new System.Drawing.Size(575, 45);
            this.a1Panel1.TabIndex = 0;
            // 
            // CancelarButton
            // 
            this.CancelarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelarButton.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.CancelarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelarButton.Location = new System.Drawing.Point(475, 8);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.CancelarButton.Size = new System.Drawing.Size(86, 24);
            this.CancelarButton.TabIndex = 2;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.SelectButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SelectButton.Location = new System.Drawing.Point(383, 8);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.SelectButton.Size = new System.Drawing.Size(86, 24);
            this.SelectButton.TabIndex = 1;
            this.SelectButton.Text = "Selecionar";
            this.SelectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // Busca
            // 
            this.Busca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Busca.Location = new System.Drawing.Point(86, 10);
            this.Busca.Name = "Busca";
            this.Busca.Size = new System.Drawing.Size(291, 20);
            this.Busca.TabIndex = 0;
            this.Busca.TextChanged += new System.EventHandler(this.Busca_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pesquisa..:";
            // 
            // a1Panel2
            // 
            this.a1Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.a1Panel2.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel2.Controls.Add(this.CriterioListView);
            this.a1Panel2.Controls.Add(this.btCC2);
            this.a1Panel2.Controls.Add(this.btCC1);
            this.a1Panel2.Controls.Add(this.ValorText);
            this.a1Panel2.Controls.Add(this.label3);
            this.a1Panel2.Controls.Add(this.CriterioList);
            this.a1Panel2.Controls.Add(this.label2);
            this.a1Panel2.GradientEndColor = System.Drawing.SystemColors.Control;
            this.a1Panel2.GradientStartColor = System.Drawing.SystemColors.Control;
            this.a1Panel2.Image = null;
            this.a1Panel2.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel2.Location = new System.Drawing.Point(3, 395);
            this.a1Panel2.Name = "a1Panel2";
            this.a1Panel2.RoundCornerRadius = 7;
            this.a1Panel2.Size = new System.Drawing.Size(576, 91);
            this.a1Panel2.TabIndex = 3;
            // 
            // CriterioListView
            // 
            this.CriterioListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.CriterioListView.FullRowSelect = true;
            this.CriterioListView.Location = new System.Drawing.Point(279, 11);
            this.CriterioListView.Name = "CriterioListView";
            this.CriterioListView.Size = new System.Drawing.Size(281, 63);
            this.CriterioListView.TabIndex = 8;
            this.CriterioListView.UseCompatibleStateImageBehavior = false;
            this.CriterioListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Id";
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Criterio";
            this.columnHeader4.Width = 190;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Valor";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btCC2
            // 
            this.btCC2.Image = global::GTI_Desktop.Properties.Resources.leftarrow;
            this.btCC2.Location = new System.Drawing.Point(237, 50);
            this.btCC2.Name = "btCC2";
            this.btCC2.Size = new System.Drawing.Size(26, 22);
            this.btCC2.TabIndex = 7;
            this.btCC2.UseVisualStyleBackColor = true;
            this.btCC2.Click += new System.EventHandler(this.btCC2_Click);
            // 
            // btCC1
            // 
            this.btCC1.Image = global::GTI_Desktop.Properties.Resources.rightarrow;
            this.btCC1.Location = new System.Drawing.Point(238, 25);
            this.btCC1.Name = "btCC1";
            this.btCC1.Size = new System.Drawing.Size(26, 22);
            this.btCC1.TabIndex = 6;
            this.btCC1.UseVisualStyleBackColor = true;
            this.btCC1.Click += new System.EventHandler(this.btCC1_Click);
            // 
            // ValorText
            // 
            this.ValorText.AutoSize = true;
            this.ValorText.ForeColor = System.Drawing.Color.Navy;
            this.ValorText.Location = new System.Drawing.Point(52, 60);
            this.ValorText.Name = "ValorText";
            this.ValorText.Size = new System.Drawing.Size(28, 13);
            this.ValorText.TabIndex = 3;
            this.ValorText.Text = "0,00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Valor..:";
            // 
            // CriterioList
            // 
            this.CriterioList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CriterioList.FormattingEnabled = true;
            this.CriterioList.Location = new System.Drawing.Point(12, 27);
            this.CriterioList.Name = "CriterioList";
            this.CriterioList.Size = new System.Drawing.Size(205, 21);
            this.CriterioList.TabIndex = 1;
            this.CriterioList.SelectedIndexChanged += new System.EventHandler(this.CriterioList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Critério..:";
            // 
            // Cnae
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 486);
            this.Controls.Add(this.a1Panel2);
            this.Controls.Add(this.a1Panel1);
            this.Controls.Add(this.MainListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(590, 520);
            this.Name = "Cnae";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista dos Cnaes cadastardos";
            this.Load += new System.EventHandler(this.Cnae_Load);
            this.a1Panel1.ResumeLayout(false);
            this.a1Panel1.PerformLayout();
            this.a1Panel2.ResumeLayout(false);
            this.a1Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private Owf.Controls.A1Panel a1Panel1;
        private System.Windows.Forms.TextBox Busca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button CancelarButton;
        private Owf.Controls.A1Panel a1Panel2;
        private System.Windows.Forms.Label ValorText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CriterioList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView CriterioListView;
        private System.Windows.Forms.Button btCC2;
        private System.Windows.Forms.Button btCC1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}