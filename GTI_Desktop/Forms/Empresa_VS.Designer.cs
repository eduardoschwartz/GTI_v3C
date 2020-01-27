namespace GTI_Desktop.Forms {
    partial class Empresa_VS {
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
            this.OkButton = new System.Windows.Forms.ToolStripButton();
            this.CancelarButton = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.CnaeList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CriterioList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Valor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Qtde = new System.Windows.Forms.TextBox();
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
            this.OkButton,
            this.CancelarButton});
            this.CnaeToolStrip.Location = new System.Drawing.Point(0, 116);
            this.CnaeToolStrip.Name = "CnaeToolStrip";
            this.CnaeToolStrip.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.CnaeToolStrip.Size = new System.Drawing.Size(500, 25);
            this.CnaeToolStrip.TabIndex = 28;
            this.CnaeToolStrip.Text = "toolStrip1";
            // 
            // OkButton
            // 
            this.OkButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OkButton.Image = global::GTI_Desktop.Properties.Resources.OK;
            this.OkButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(23, 22);
            this.OkButton.Text = "toolStripButton1";
            this.OkButton.ToolTipText = "Adicionar Cnae";
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelarButton.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.CancelarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(23, 22);
            this.CancelarButton.Text = "toolStripButton3";
            this.CancelarButton.ToolTipText = "Remover Cnae";
            this.CancelarButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Cnae...:";
            // 
            // CnaeList
            // 
            this.CnaeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CnaeList.DropDownWidth = 430;
            this.CnaeList.FormattingEnabled = true;
            this.CnaeList.Location = new System.Drawing.Point(59, 16);
            this.CnaeList.Name = "CnaeList";
            this.CnaeList.Size = new System.Drawing.Size(430, 21);
            this.CnaeList.TabIndex = 0;
            this.CnaeList.SelectedIndexChanged += new System.EventHandler(this.CnaeList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Critério.:";
            // 
            // CriterioList
            // 
            this.CriterioList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CriterioList.DropDownWidth = 430;
            this.CriterioList.FormattingEnabled = true;
            this.CriterioList.Location = new System.Drawing.Point(59, 44);
            this.CriterioList.Name = "CriterioList";
            this.CriterioList.Size = new System.Drawing.Size(272, 21);
            this.CriterioList.TabIndex = 1;
            this.CriterioList.SelectedIndexChanged += new System.EventHandler(this.CriterioList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Valor..:";
            // 
            // Valor
            // 
            this.Valor.AutoSize = true;
            this.Valor.ForeColor = System.Drawing.Color.Maroon;
            this.Valor.Location = new System.Drawing.Point(392, 49);
            this.Valor.Name = "Valor";
            this.Valor.Size = new System.Drawing.Size(28, 13);
            this.Valor.TabIndex = 34;
            this.Valor.Text = "0,00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Qtde....:";
            // 
            // Qtde
            // 
            this.Qtde.Location = new System.Drawing.Point(59, 74);
            this.Qtde.MaxLength = 2;
            this.Qtde.Name = "Qtde";
            this.Qtde.Size = new System.Drawing.Size(56, 20);
            this.Qtde.TabIndex = 2;
            this.Qtde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Qtde_KeyPress);
            // 
            // Empresa_VS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 141);
            this.ControlBox = false;
            this.Controls.Add(this.Qtde);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Valor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CriterioList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CnaeList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CnaeToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Empresa_VS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro das Cnaes para vigilância sanitária";
            this.CnaeToolStrip.ResumeLayout(false);
            this.CnaeToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip CnaeToolStrip;
        private System.Windows.Forms.ToolStripButton OkButton;
        private System.Windows.Forms.ToolStripButton CancelarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CnaeList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CriterioList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Valor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Qtde;
    }
}