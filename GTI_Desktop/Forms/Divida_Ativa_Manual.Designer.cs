namespace GTI_Desktop.Forms {
    partial class Divida_Ativa_Manual {
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
            this.OKButton = new System.Windows.Forms.ToolStripButton();
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
            this.label3 = new System.Windows.Forms.Label();
            this.DataInscricaoText = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PaginaText = new System.Windows.Forms.Label();
            this.LivroText = new System.Windows.Forms.Label();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.OKButton,
            this.SairButton});
            this.tBar.Location = new System.Drawing.Point(0, 230);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(589, 25);
            this.tBar.TabIndex = 2;
            this.tBar.Text = "toolStrip1";
            // 
            // OKButton
            // 
            this.OKButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OKButton.Image = global::GTI_Desktop.Properties.Resources.OK;
            this.OKButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(23, 22);
            this.OKButton.Text = "toolStripButton2";
            this.OKButton.ToolTipText = "Escrever os débitos selecionados em divida ativa";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // SairButton
            // 
            this.SairButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SairButton.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.SairButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SairButton.Name = "SairButton";
            this.SairButton.Size = new System.Drawing.Size(23, 22);
            this.SairButton.Text = "toolStripButton1";
            this.SairButton.ToolTipText = "Fechar a tela";
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
            this.columnHeader9,
            this.columnHeader8});
            this.MainListView.FullRowSelect = true;
            this.MainListView.GridLines = true;
            this.MainListView.Location = new System.Drawing.Point(6, 6);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(577, 183);
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
            this.columnHeader8.Text = "Livro";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "Data Inscrição..:";
            // 
            // DataInscricaoText
            // 
            this.DataInscricaoText.Location = new System.Drawing.Point(443, 198);
            this.DataInscricaoText.Mask = "00/00/0000";
            this.DataInscricaoText.Name = "DataInscricaoText";
            this.DataInscricaoText.Size = new System.Drawing.Size(71, 20);
            this.DataInscricaoText.TabIndex = 1;
            this.DataInscricaoText.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "Livro..:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 88;
            this.label2.Text = "Página..:";
            // 
            // PaginaText
            // 
            this.PaginaText.AutoSize = true;
            this.PaginaText.ForeColor = System.Drawing.Color.Maroon;
            this.PaginaText.Location = new System.Drawing.Point(305, 203);
            this.PaginaText.Name = "PaginaText";
            this.PaginaText.Size = new System.Drawing.Size(31, 13);
            this.PaginaText.TabIndex = 89;
            this.PaginaText.Text = "0000";
            // 
            // LivroText
            // 
            this.LivroText.AutoSize = true;
            this.LivroText.ForeColor = System.Drawing.Color.Maroon;
            this.LivroText.Location = new System.Drawing.Point(57, 203);
            this.LivroText.Name = "LivroText";
            this.LivroText.Size = new System.Drawing.Size(0, 13);
            this.LivroText.TabIndex = 90;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "DA";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 30;
            // 
            // Divida_Ativa_Manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(589, 255);
            this.Controls.Add(this.LivroText);
            this.Controls.Add(this.PaginaText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataInscricaoText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MainListView);
            this.Controls.Add(this.tBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Divida_Ativa_Manual";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inscrição em divida ativa";
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton OKButton;
        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton SairButton;
        private System.Windows.Forms.MaskedTextBox DataInscricaoText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PaginaText;
        private System.Windows.Forms.Label LivroText;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}