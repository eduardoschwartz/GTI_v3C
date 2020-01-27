namespace GTI_Desktop.Forms {
    partial class Atividade_ISS {
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
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.SelecionarButton = new System.Windows.Forms.ToolStripButton();
            this.PrintButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SairButton = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TipoList = new System.Windows.Forms.ComboBox();
            this.tBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainListView
            // 
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.MainListView.FullRowSelect = true;
            this.MainListView.Location = new System.Drawing.Point(4, 39);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(523, 317);
            this.MainListView.TabIndex = 0;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tipo";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Descrição";
            this.columnHeader3.Width = 350;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Aliquota";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tBar
            // 
            this.tBar.AllowMerge = false;
            this.tBar.BackColor = System.Drawing.SystemColors.Control;
            this.tBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelecionarButton,
            this.PrintButton,
            this.toolStripSeparator1,
            this.SairButton});
            this.tBar.Location = new System.Drawing.Point(0, 363);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(531, 25);
            this.tBar.TabIndex = 26;
            this.tBar.Text = "toolStrip1";
            // 
            // SelecionarButton
            // 
            this.SelecionarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SelecionarButton.Image = global::GTI_Desktop.Properties.Resources.receber;
            this.SelecionarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelecionarButton.Name = "SelecionarButton";
            this.SelecionarButton.Size = new System.Drawing.Size(23, 22);
            this.SelecionarButton.Text = "toolStripButton1";
            this.SelecionarButton.ToolTipText = "Selecionar atividade da empresa";
            this.SelecionarButton.Click += new System.EventHandler(this.SelecionarButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PrintButton.Image = global::GTI_Desktop.Properties.Resources.print;
            this.PrintButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(23, 22);
            this.PrintButton.Text = "toolStripButton1";
            this.PrintButton.ToolTipText = "Imprimir atividades";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // SairButton
            // 
            this.SairButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SairButton.Image = global::GTI_Desktop.Properties.Resources.Exit;
            this.SairButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SairButton.Name = "SairButton";
            this.SairButton.Size = new System.Drawing.Size(23, 22);
            this.SairButton.Text = "toolStripButton5";
            this.SairButton.ToolTipText = "Sair";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Tipo de ISS..:";
            // 
            // TipoList
            // 
            this.TipoList.FormattingEnabled = true;
            this.TipoList.Items.AddRange(new object[] {
            "ISS FIXO",
            "ISS ESTIMADO",
            "ISS VARIÁVEL"});
            this.TipoList.Location = new System.Drawing.Point(90, 12);
            this.TipoList.Name = "TipoList";
            this.TipoList.Size = new System.Drawing.Size(155, 21);
            this.TipoList.TabIndex = 28;
            this.TipoList.SelectedIndexChanged += new System.EventHandler(this.TipoList_SelectedIndexChanged);
            // 
            // Atividade_ISS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 388);
            this.Controls.Add(this.TipoList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBar);
            this.Controls.Add(this.MainListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Atividade_ISS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabela de atividades de ISS";
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton SelecionarButton;
        private System.Windows.Forms.ToolStripButton PrintButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton SairButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TipoList;
    }
}