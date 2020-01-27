namespace GTI_Desktop.Forms {
    partial class Empresa_Atividade {
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
            this.components = new System.ComponentModel.Container();
            this.MainListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Codigo = new System.Windows.Forms.TextBox();
            this.Descricao = new System.Windows.Forms.TextBox();
            this.ZoomButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Aliquota1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Aliquota2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Aliquota3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.AddButton = new System.Windows.Forms.ToolStripButton();
            this.EditButton = new System.Windows.Forms.ToolStripButton();
            this.DelButton = new System.Windows.Forms.ToolStripButton();
            this.SelecionarButton = new System.Windows.Forms.ToolStripButton();
            this.PrintButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SairButton = new System.Windows.Forms.ToolStripButton();
            this.GravarButton = new System.Windows.Forms.ToolStripButton();
            this.CancelarButton = new System.Windows.Forms.ToolStripButton();
            this.tBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainListView
            // 
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.MainListView.FullRowSelect = true;
            this.MainListView.Location = new System.Drawing.Point(5, 5);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(559, 298);
            this.MainListView.TabIndex = 0;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.MainListView_ColumnClick);
            this.MainListView.SelectedIndexChanged += new System.EventHandler(this.MainListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            this.columnHeader1.Width = 55;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descrição";
            this.columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Aliq.1";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Aliq.2";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Aliq.3";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código..:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição.:";
            // 
            // Codigo
            // 
            this.Codigo.Location = new System.Drawing.Point(64, 313);
            this.Codigo.MaxLength = 5;
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(52, 20);
            this.Codigo.TabIndex = 1;
            this.Codigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Codigo_KeyPress);
            // 
            // Descricao
            // 
            this.Descricao.Location = new System.Drawing.Point(189, 313);
            this.Descricao.MaxLength = 300;
            this.Descricao.Name = "Descricao";
            this.Descricao.Size = new System.Drawing.Size(344, 20);
            this.Descricao.TabIndex = 2;
            // 
            // ZoomButton
            // 
            this.ZoomButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZoomButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ZoomButton.FlatAppearance.BorderSize = 0;
            this.ZoomButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.ZoomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.ZoomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomButton.ForeColor = System.Drawing.Color.Navy;
            this.ZoomButton.Image = global::GTI_Desktop.Properties.Resources.zoomer;
            this.ZoomButton.Location = new System.Drawing.Point(537, 312);
            this.ZoomButton.Name = "ZoomButton";
            this.ZoomButton.Size = new System.Drawing.Size(21, 21);
            this.ZoomButton.TabIndex = 3;
            this.toolTip1.SetToolTip(this.ZoomButton, "Ampliar texto");
            this.ZoomButton.UseVisualStyleBackColor = true;
            this.ZoomButton.Click += new System.EventHandler(this.ZoomButton_Click);
            // 
            // Aliquota1
            // 
            this.Aliquota1.Location = new System.Drawing.Point(78, 339);
            this.Aliquota1.MaxLength = 12;
            this.Aliquota1.Name = "Aliquota1";
            this.Aliquota1.Size = new System.Drawing.Size(86, 20);
            this.Aliquota1.TabIndex = 4;
            this.Aliquota1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Aliquota1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Aliquota 1..:";
            // 
            // Aliquota2
            // 
            this.Aliquota2.Location = new System.Drawing.Point(264, 339);
            this.Aliquota2.MaxLength = 12;
            this.Aliquota2.Name = "Aliquota2";
            this.Aliquota2.Size = new System.Drawing.Size(86, 20);
            this.Aliquota2.TabIndex = 5;
            this.Aliquota2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Aliquota2_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Aliquota 2..:";
            // 
            // Aliquota3
            // 
            this.Aliquota3.Location = new System.Drawing.Point(447, 339);
            this.Aliquota3.MaxLength = 12;
            this.Aliquota3.Name = "Aliquota3";
            this.Aliquota3.Size = new System.Drawing.Size(86, 20);
            this.Aliquota3.TabIndex = 6;
            this.Aliquota3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Aliquota3_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(383, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Aliquota 3..:";
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
            this.SelecionarButton,
            this.PrintButton,
            this.toolStripSeparator1,
            this.SairButton,
            this.GravarButton,
            this.CancelarButton});
            this.tBar.Location = new System.Drawing.Point(0, 369);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(569, 25);
            this.tBar.TabIndex = 25;
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
            this.AddButton.ToolTipText = "Adicionar atividade";
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
            this.EditButton.ToolTipText = "Alterar atividade";
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DelButton
            // 
            this.DelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DelButton.Image = global::GTI_Desktop.Properties.Resources.delete;
            this.DelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(23, 22);
            this.DelButton.Text = "toolStripButton3";
            this.DelButton.ToolTipText = "Excluir atividade";
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
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
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
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
            this.SairButton.Click += new System.EventHandler(this.SairButton_Click);
            // 
            // GravarButton
            // 
            this.GravarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GravarButton.Image = global::GTI_Desktop.Properties.Resources.gravar;
            this.GravarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GravarButton.Name = "GravarButton";
            this.GravarButton.Size = new System.Drawing.Size(23, 22);
            this.GravarButton.Text = "toolStripButton1";
            this.GravarButton.ToolTipText = "Gravar os dados";
            this.GravarButton.Click += new System.EventHandler(this.GravarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelarButton.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.CancelarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(23, 22);
            this.CancelarButton.Text = "toolStripButton2";
            this.CancelarButton.ToolTipText = "Cancelar gravação";
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // Empresa_Atividade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 394);
            this.Controls.Add(this.tBar);
            this.Controls.Add(this.Aliquota3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Aliquota2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Aliquota1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ZoomButton);
            this.Controls.Add(this.Descricao);
            this.Controls.Add(this.Codigo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Empresa_Atividade";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de atividades das empresas";
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
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Codigo;
        private System.Windows.Forms.TextBox Descricao;
        private System.Windows.Forms.Button ZoomButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox Aliquota1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Aliquota2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Aliquota3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton AddButton;
        private System.Windows.Forms.ToolStripButton EditButton;
        private System.Windows.Forms.ToolStripButton DelButton;
        private System.Windows.Forms.ToolStripButton SelecionarButton;
        private System.Windows.Forms.ToolStripButton PrintButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton SairButton;
        private System.Windows.Forms.ToolStripButton GravarButton;
        private System.Windows.Forms.ToolStripButton CancelarButton;
    }
}