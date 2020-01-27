namespace GTI_Desktop.Forms {
    partial class Empresa_Cnae {
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
            this.CnaeToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddButton = new System.Windows.Forms.ToolStripButton();
            this.DelButton = new System.Windows.Forms.ToolStripButton();
            this.ExitButton = new System.Windows.Forms.ToolStripButton();
            this.MainListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CnaeToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CnaeToolStrip
            // 
            this.CnaeToolStrip.AllowMerge = false;
            this.CnaeToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.CnaeToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CnaeToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.CnaeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddButton,
            this.DelButton,
            this.ExitButton});
            this.CnaeToolStrip.Location = new System.Drawing.Point(0, 139);
            this.CnaeToolStrip.Name = "CnaeToolStrip";
            this.CnaeToolStrip.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.CnaeToolStrip.Size = new System.Drawing.Size(590, 25);
            this.CnaeToolStrip.TabIndex = 27;
            this.CnaeToolStrip.Text = "toolStrip1";
            // 
            // AddButton
            // 
            this.AddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddButton.Image = global::GTI_Desktop.Properties.Resources.add;
            this.AddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(23, 22);
            this.AddButton.Text = "toolStripButton1";
            this.AddButton.ToolTipText = "Adicionar Cnae";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DelButton
            // 
            this.DelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DelButton.Image = global::GTI_Desktop.Properties.Resources.cancelar;
            this.DelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(23, 22);
            this.DelButton.Text = "toolStripButton3";
            this.DelButton.ToolTipText = "Remover Cnae";
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExitButton.Image = global::GTI_Desktop.Properties.Resources.Exit;
            this.ExitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(23, 22);
            this.ExitButton.Text = "toolStripButton5";
            this.ExitButton.ToolTipText = "Retornar a lista à empresa";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainListView
            // 
            this.MainListView.CheckBoxes = true;
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MainListView.FullRowSelect = true;
            this.MainListView.Location = new System.Drawing.Point(5, 5);
            this.MainListView.MultiSelect = false;
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(579, 132);
            this.MainListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.MainListView.TabIndex = 26;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "CNAE";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descrição";
            this.columnHeader2.Width = 460;
            // 
            // Empresa_Cnae
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 164);
            this.ControlBox = false;
            this.Controls.Add(this.CnaeToolStrip);
            this.Controls.Add(this.MainListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Empresa_Cnae";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecione os Cnaes da empresa e marque o principal";
            this.CnaeToolStrip.ResumeLayout(false);
            this.CnaeToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip CnaeToolStrip;
        private System.Windows.Forms.ToolStripButton AddButton;
        private System.Windows.Forms.ToolStripButton DelButton;
        private System.Windows.Forms.ToolStripButton ExitButton;
        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}