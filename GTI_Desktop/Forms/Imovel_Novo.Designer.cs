namespace GTI_Desktop.Forms {
    partial class Imovel_Novo {
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
            this.label1 = new System.Windows.Forms.Label();
            this.Inscricao = new System.Windows.Forms.MaskedTextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.TipoList = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.UnidadeList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SubUnidadeList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 20);
            this.label1.TabIndex = 196;
            this.label1.Text = "Cadastrar um novo imóvel";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Inscricao
            // 
            this.Inscricao.Location = new System.Drawing.Point(107, 106);
            this.Inscricao.Mask = "9.99.9999.99999.99.99.999";
            this.Inscricao.Name = "Inscricao";
            this.Inscricao.Size = new System.Drawing.Size(161, 20);
            this.Inscricao.TabIndex = 191;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(13, 109);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(88, 13);
            this.label48.TabIndex = 195;
            this.label48.Text = "Nº de inscrição..:";
            // 
            // TipoList
            // 
            this.TipoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoList.FormattingEnabled = true;
            this.TipoList.Location = new System.Drawing.Point(107, 41);
            this.TipoList.Name = "TipoList";
            this.TipoList.Size = new System.Drawing.Size(262, 21);
            this.TipoList.TabIndex = 190;
            this.TipoList.SelectedIndexChanged += new System.EventHandler(this.TipoList_SelectedIndexChanged);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.Black;
            this.label46.Location = new System.Drawing.Point(13, 44);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(88, 13);
            this.label46.TabIndex = 194;
            this.label46.Text = "Tipo de imóvel...:";
            // 
            // UnidadeList
            // 
            this.UnidadeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UnidadeList.FormattingEnabled = true;
            this.UnidadeList.Location = new System.Drawing.Point(172, 68);
            this.UnidadeList.Name = "UnidadeList";
            this.UnidadeList.Size = new System.Drawing.Size(52, 21);
            this.UnidadeList.TabIndex = 197;
            this.UnidadeList.SelectedIndexChanged += new System.EventHandler(this.UnidadeList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(104, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 198;
            this.label2.Text = "Unidade....:";
            // 
            // SubUnidadeList
            // 
            this.SubUnidadeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubUnidadeList.FormattingEnabled = true;
            this.SubUnidadeList.Location = new System.Drawing.Point(317, 68);
            this.SubUnidadeList.Name = "SubUnidadeList";
            this.SubUnidadeList.Size = new System.Drawing.Size(52, 21);
            this.SubUnidadeList.TabIndex = 199;
            this.SubUnidadeList.SelectedIndexChanged += new System.EventHandler(this.SubUnidadeList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(239, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 200;
            this.label3.Text = "SubUnidade.:";
            // 
            // tBar
            // 
            this.tBar.BackColor = System.Drawing.Color.Transparent;
            this.tBar.Dock = System.Windows.Forms.DockStyle.None;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.tBar.Location = new System.Drawing.Point(317, 101);
            this.tBar.Name = "tBar";
            this.tBar.Size = new System.Drawing.Size(49, 25);
            this.tBar.TabIndex = 201;
            this.tBar.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::GTI_Desktop.Properties.Resources.OK;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Criar imóvel";
            this.toolStripButton1.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Cancelar";
            this.toolStripButton2.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Imovel_Novo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(388, 142);
            this.Controls.Add(this.tBar);
            this.Controls.Add(this.SubUnidadeList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UnidadeList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Inscricao);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.TipoList);
            this.Controls.Add(this.label46);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Imovel_Novo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imovel_Novo";
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.MaskedTextBox Inscricao;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.ComboBox TipoList;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.ComboBox UnidadeList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SubUnidadeList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}