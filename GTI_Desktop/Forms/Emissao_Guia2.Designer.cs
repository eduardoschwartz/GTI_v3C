namespace GTI_Desktop.Forms {
    partial class Emissao_Guia2 {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LancamentoList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TipoGuiaList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ProcessoText = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.RuralCheck = new System.Windows.Forms.CheckBox();
            this.IndiceText = new System.Windows.Forms.Label();
            this.MesesText = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ExercicioList = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TabelaList = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.AbateNFText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CalculoDataDeText = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PercUnicaUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ParcelaUnicaCheck = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.QtdeParcelaUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LancamentoListView = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ObsText = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.QtdeButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.AtividadeList = new System.Windows.Forms.CheckedListBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PercUnicaUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtdeParcelaUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AtividadeList);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LancamentoList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TipoGuiaList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Atividade..:";
            // 
            // LancamentoList
            // 
            this.LancamentoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LancamentoList.FormattingEnabled = true;
            this.LancamentoList.Location = new System.Drawing.Point(82, 37);
            this.LancamentoList.Name = "LancamentoList";
            this.LancamentoList.Size = new System.Drawing.Size(223, 21);
            this.LancamentoList.TabIndex = 3;
            this.LancamentoList.SelectedIndexChanged += new System.EventHandler(this.LancamentoList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lançamento..:";
            // 
            // TipoGuiaList
            // 
            this.TipoGuiaList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TipoGuiaList.FormattingEnabled = true;
            this.TipoGuiaList.Items.AddRange(new object[] {
            "(Lançamentos diversos)",
            "IPTU/ITU",
            "Taxa de Licença",
            "ISS Fixo",
            "Vigilância Sanitária",
            "Roçada"});
            this.TipoGuiaList.Location = new System.Drawing.Point(82, 12);
            this.TipoGuiaList.Name = "TipoGuiaList";
            this.TipoGuiaList.Size = new System.Drawing.Size(158, 21);
            this.TipoGuiaList.TabIndex = 1;
            this.TipoGuiaList.SelectedIndexChanged += new System.EventHandler(this.TipoGuiaList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de guia..:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ProcessoText);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.RuralCheck);
            this.groupBox2.Controls.Add(this.IndiceText);
            this.groupBox2.Controls.Add(this.MesesText);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.ExercicioList);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.TabelaList);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.AbateNFText);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.CalculoDataDeText);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.PercUnicaUpDown);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ParcelaUnicaCheck);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.maskedTextBox1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.QtdeParcelaUpDown);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(4, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 92);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // ProcessoText
            // 
            this.ProcessoText.Location = new System.Drawing.Point(386, 63);
            this.ProcessoText.Name = "ProcessoText";
            this.ProcessoText.Size = new System.Drawing.Size(54, 20);
            this.ProcessoText.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(330, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Processo.:";
            // 
            // RuralCheck
            // 
            this.RuralCheck.AutoSize = true;
            this.RuralCheck.Location = new System.Drawing.Point(278, 66);
            this.RuralCheck.Name = "RuralCheck";
            this.RuralCheck.Size = new System.Drawing.Size(51, 17);
            this.RuralCheck.TabIndex = 21;
            this.RuralCheck.Text = "Rural";
            this.RuralCheck.UseVisualStyleBackColor = true;
            // 
            // IndiceText
            // 
            this.IndiceText.AutoSize = true;
            this.IndiceText.ForeColor = System.Drawing.Color.Maroon;
            this.IndiceText.Location = new System.Drawing.Point(232, 67);
            this.IndiceText.Name = "IndiceText";
            this.IndiceText.Size = new System.Drawing.Size(40, 13);
            this.IndiceText.TabIndex = 20;
            this.IndiceText.Text = "0,0000";
            // 
            // MesesText
            // 
            this.MesesText.AutoSize = true;
            this.MesesText.ForeColor = System.Drawing.Color.Maroon;
            this.MesesText.Location = new System.Drawing.Point(120, 67);
            this.MesesText.Name = "MesesText";
            this.MesesText.Size = new System.Drawing.Size(13, 13);
            this.MesesText.TabIndex = 19;
            this.MesesText.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(140, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Índice referência..:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Meses proporcionais..:";
            // 
            // ExercicioList
            // 
            this.ExercicioList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ExercicioList.FormattingEnabled = true;
            this.ExercicioList.Location = new System.Drawing.Point(500, 64);
            this.ExercicioList.Name = "ExercicioList";
            this.ExercicioList.Size = new System.Drawing.Size(63, 21);
            this.ExercicioList.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(444, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Exercício:";
            // 
            // TabelaList
            // 
            this.TabelaList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TabelaList.FormattingEnabled = true;
            this.TabelaList.Location = new System.Drawing.Point(500, 38);
            this.TabelaList.Name = "TabelaList";
            this.TabelaList.Size = new System.Drawing.Size(63, 21);
            this.TabelaList.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(444, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Tabela....:";
            // 
            // AbateNFText
            // 
            this.AbateNFText.BackColor = System.Drawing.Color.Linen;
            this.AbateNFText.Location = new System.Drawing.Point(386, 38);
            this.AbateNFText.Name = "AbateNFText";
            this.AbateNFText.ReadOnly = true;
            this.AbateNFText.Size = new System.Drawing.Size(54, 20);
            this.AbateNFText.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Abatimento NF....:";
            // 
            // CalculoDataDeText
            // 
            this.CalculoDataDeText.Location = new System.Drawing.Point(208, 38);
            this.CalculoDataDeText.Mask = "00/00/0000";
            this.CalculoDataDeText.Name = "CalculoDataDeText";
            this.CalculoDataDeText.Size = new System.Drawing.Size(67, 20);
            this.CalculoDataDeText.TabIndex = 10;
            this.CalculoDataDeText.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Cálculo proporcional a partir da data de..:";
            // 
            // PercUnicaUpDown
            // 
            this.PercUnicaUpDown.Location = new System.Drawing.Point(500, 13);
            this.PercUnicaUpDown.Name = "PercUnicaUpDown";
            this.PercUnicaUpDown.Size = new System.Drawing.Size(62, 20);
            this.PercUnicaUpDown.TabIndex = 8;
            this.PercUnicaUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(444, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "% única...:";
            // 
            // ParcelaUnicaCheck
            // 
            this.ParcelaUnicaCheck.AutoSize = true;
            this.ParcelaUnicaCheck.Location = new System.Drawing.Point(342, 16);
            this.ParcelaUnicaCheck.Name = "ParcelaUnicaCheck";
            this.ParcelaUnicaCheck.Size = new System.Drawing.Size(93, 17);
            this.ParcelaUnicaCheck.TabIndex = 6;
            this.ParcelaUnicaCheck.Text = "Parcela Única";
            this.ParcelaUnicaCheck.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = global::GTI_Desktop.Properties.Resources.add;
            this.button1.Location = new System.Drawing.Point(300, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 18);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(232, 12);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(67, 20);
            this.maskedTextBox1.TabIndex = 4;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Data 1º Vencto..:";
            // 
            // QtdeParcelaUpDown
            // 
            this.QtdeParcelaUpDown.Location = new System.Drawing.Point(82, 12);
            this.QtdeParcelaUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.QtdeParcelaUpDown.Name = "QtdeParcelaUpDown";
            this.QtdeParcelaUpDown.Size = new System.Drawing.Size(41, 20);
            this.QtdeParcelaUpDown.TabIndex = 2;
            this.QtdeParcelaUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.QtdeParcelaUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Qtde.Parcela.:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LancamentoListView);
            this.groupBox3.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox3.Location = new System.Drawing.Point(4, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 178);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Composição do lançamento";
            // 
            // LancamentoListView
            // 
            this.LancamentoListView.Location = new System.Drawing.Point(4, 18);
            this.LancamentoListView.Name = "LancamentoListView";
            this.LancamentoListView.Size = new System.Drawing.Size(280, 154);
            this.LancamentoListView.TabIndex = 0;
            this.LancamentoListView.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ObsText);
            this.groupBox4.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox4.Location = new System.Drawing.Point(299, 158);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(275, 142);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Observação";
            // 
            // ObsText
            // 
            this.ObsText.Location = new System.Drawing.Point(6, 18);
            this.ObsText.Multiline = true;
            this.ObsText.Name = "ObsText";
            this.ObsText.Size = new System.Drawing.Size(263, 118);
            this.ObsText.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Maroon;
            this.label16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(0, 338);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(578, 26);
            this.label16.TabIndex = 4;
            this.label16.Text = "Obs: A parcela única (quando houver) e a 1ª parcela serão geradas através de bole" +
    "to no site do Banco do Brasil, o restante das parcelas impressas serão registrad" +
    "as durante a noite.";
            // 
            // QtdeButton
            // 
            this.QtdeButton.Location = new System.Drawing.Point(209, 155);
            this.QtdeButton.Name = "QtdeButton";
            this.QtdeButton.Size = new System.Drawing.Size(50, 20);
            this.QtdeButton.TabIndex = 6;
            this.QtdeButton.Text = "Qtde.";
            this.QtdeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.QtdeButton.UseVisualStyleBackColor = true;
            // 
            // PrintButton
            // 
            this.PrintButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrintButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PrintButton.FlatAppearance.BorderSize = 0;
            this.PrintButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.PrintButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.PrintButton.Image = global::GTI_Desktop.Properties.Resources.print;
            this.PrintButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PrintButton.Location = new System.Drawing.Point(481, 306);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.PrintButton.Size = new System.Drawing.Size(87, 24);
            this.PrintButton.TabIndex = 17;
            this.PrintButton.Text = "      Gerar guia";
            this.PrintButton.UseVisualStyleBackColor = true;
            // 
            // AtividadeList
            // 
            this.AtividadeList.FormattingEnabled = true;
            this.AtividadeList.Location = new System.Drawing.Point(312, 10);
            this.AtividadeList.Name = "AtividadeList";
            this.AtividadeList.Size = new System.Drawing.Size(252, 49);
            this.AtividadeList.TabIndex = 5;
            this.AtividadeList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AtividadeList_MouseMove);
            // 
            // Emissao_Guia2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(578, 364);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.QtdeButton);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Emissao_Guia2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Composição da guia";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PercUnicaUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtdeParcelaUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox LancamentoList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TipoGuiaList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown QtdeParcelaUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown PercUnicaUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ParcelaUnicaCheck;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ExercicioList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox TabelaList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox AbateNFText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox CalculoDataDeText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ProcessoText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox RuralCheck;
        private System.Windows.Forms.Label IndiceText;
        private System.Windows.Forms.Label MesesText;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView LancamentoListView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox ObsText;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button QtdeButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.CheckedListBox AtividadeList;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}