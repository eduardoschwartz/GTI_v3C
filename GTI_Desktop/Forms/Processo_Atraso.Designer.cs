namespace GTI_Desktop.Forms {
    partial class Processo_Atraso {
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
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GerarButton = new System.Windows.Forms.Button();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // MainListView
            // 
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader6,
            this.columnHeader11,
            this.columnHeader7,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader10,
            this.columnHeader13});
            this.MainListView.FullRowSelect = true;
            this.MainListView.GridLines = true;
            this.MainListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MainListView.Location = new System.Drawing.Point(5, 5);
            this.MainListView.MinimumSize = new System.Drawing.Size(565, 176);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(1094, 321);
            this.MainListView.TabIndex = 160;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.VirtualMode = true;
            this.MainListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.MainListView_RetrieveVirtualItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ano";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Número";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 55;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Assunto";
            this.columnHeader11.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Requerente";
            this.columnHeader7.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Dt.Entrada";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Último trâmite";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Despacho";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Dias";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader10.Width = 42;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Próximo Trâmite";
            this.columnHeader13.Width = 150;
            // 
            // GerarButton
            // 
            this.GerarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GerarButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GerarButton.FlatAppearance.BorderSize = 0;
            this.GerarButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.GerarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.GerarButton.Image = global::GTI_Desktop.Properties.Resources.Alterar;
            this.GerarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GerarButton.Location = new System.Drawing.Point(1026, 330);
            this.GerarButton.Name = "GerarButton";
            this.GerarButton.Size = new System.Drawing.Size(69, 25);
            this.GerarButton.TabIndex = 161;
            this.GerarButton.Text = "Gerar";
            this.GerarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GerarButton.UseVisualStyleBackColor = true;
            this.GerarButton.Click += new System.EventHandler(this.GerarButton_Click);
            // 
            // PBar
            // 
            this.PBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.PBar.Location = new System.Drawing.Point(846, 347);
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(174, 8);
            this.PBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PBar.TabIndex = 162;
            // 
            // Processo_Atraso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 360);
            this.Controls.Add(this.PBar);
            this.Controls.Add(this.GerarButton);
            this.Controls.Add(this.MainListView);
            this.Name = "Processo_Atraso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processos com trâmite em atraso";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Button GerarButton;
        private System.Windows.Forms.ProgressBar PBar;
    }
}