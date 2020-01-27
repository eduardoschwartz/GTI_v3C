namespace GTI_Desktop.Forms {
    partial class Calculo_Imposto {
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
            this.ImpostoList = new System.Windows.Forms.ComboBox();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.ExecutarButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MsgToolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.ExportarButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.QtdeLamina = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Valor_ci_Total = new System.Windows.Forms.Label();
            this.Valor_ci_IsentoProcesso = new System.Windows.Forms.Label();
            this.Valor_ci_IsentoArea = new System.Windows.Forms.Label();
            this.Valor_ci_Imune = new System.Windows.Forms.Label();
            this.Valor_ci_Normal = new System.Windows.Forms.Label();
            this.Valor_si_Total = new System.Windows.Forms.Label();
            this.Valor_si_IsentoProcesso = new System.Windows.Forms.Label();
            this.Valor_si_IsentoArea = new System.Windows.Forms.Label();
            this.Valor_si_Imune = new System.Windows.Forms.Label();
            this.Valor_si_Normal = new System.Windows.Forms.Label();
            this.QtdeTotal = new System.Windows.Forms.Label();
            this.QtdeIsentoProcesso = new System.Windows.Forms.Label();
            this.QtdeIsentoArea = new System.Windows.Forms.Label();
            this.QtdeImune = new System.Windows.Forms.Label();
            this.QtdeNormal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Cálculo..:";
            // 
            // ImpostoList
            // 
            this.ImpostoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ImpostoList.FormattingEnabled = true;
            this.ImpostoList.Items.AddRange(new object[] {
            "CÁLCULO DE IPTU",
            "CÁLCULO DE ISS FIXO/TLL",
            "CÁLCULO DE VIGILÂNCIA SANITÁRIA"});
            this.ImpostoList.Location = new System.Drawing.Point(108, 20);
            this.ImpostoList.Name = "ImpostoList";
            this.ImpostoList.Size = new System.Drawing.Size(243, 21);
            this.ImpostoList.TabIndex = 1;
            // 
            // PBar
            // 
            this.PBar.ForeColor = System.Drawing.Color.GreenYellow;
            this.PBar.Location = new System.Drawing.Point(16, 55);
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(335, 9);
            this.PBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PBar.TabIndex = 3;
            // 
            // ExecutarButton
            // 
            this.ExecutarButton.Image = global::GTI_Desktop.Properties.Resources.executar;
            this.ExecutarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExecutarButton.Location = new System.Drawing.Point(379, 12);
            this.ExecutarButton.Name = "ExecutarButton";
            this.ExecutarButton.Size = new System.Drawing.Size(75, 23);
            this.ExecutarButton.TabIndex = 2;
            this.ExecutarButton.Text = "Calcular";
            this.ExecutarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExecutarButton.UseVisualStyleBackColor = true;
            this.ExecutarButton.Click += new System.EventHandler(this.ExecutarButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsgToolStrip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 253);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(473, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MsgToolStrip
            // 
            this.MsgToolStrip.Name = "MsgToolStrip";
            this.MsgToolStrip.Size = new System.Drawing.Size(177, 17);
            this.MsgToolStrip.Text = "Selecione uma opção de cálculo";
            // 
            // ExportarButton
            // 
            this.ExportarButton.Image = global::GTI_Desktop.Properties.Resources.enviar;
            this.ExportarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExportarButton.Location = new System.Drawing.Point(379, 50);
            this.ExportarButton.Name = "ExportarButton";
            this.ExportarButton.Size = new System.Drawing.Size(75, 23);
            this.ExportarButton.TabIndex = 5;
            this.ExportarButton.Text = "Exportar";
            this.ExportarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExportarButton.UseVisualStyleBackColor = true;
            this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.QtdeLamina);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.Valor_ci_Total);
            this.groupBox1.Controls.Add(this.Valor_ci_IsentoProcesso);
            this.groupBox1.Controls.Add(this.Valor_ci_IsentoArea);
            this.groupBox1.Controls.Add(this.Valor_ci_Imune);
            this.groupBox1.Controls.Add(this.Valor_ci_Normal);
            this.groupBox1.Controls.Add(this.Valor_si_Total);
            this.groupBox1.Controls.Add(this.Valor_si_IsentoProcesso);
            this.groupBox1.Controls.Add(this.Valor_si_IsentoArea);
            this.groupBox1.Controls.Add(this.Valor_si_Imune);
            this.groupBox1.Controls.Add(this.Valor_si_Normal);
            this.groupBox1.Controls.Add(this.QtdeTotal);
            this.groupBox1.Controls.Add(this.QtdeIsentoProcesso);
            this.groupBox1.Controls.Add(this.QtdeIsentoArea);
            this.groupBox1.Controls.Add(this.QtdeImune);
            this.groupBox1.Controls.Add(this.QtdeNormal);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 163);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.Location = new System.Drawing.Point(7, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 16);
            this.label13.TabIndex = 26;
            this.label13.Text = "Descrição";
            // 
            // QtdeLamina
            // 
            this.QtdeLamina.AutoSize = true;
            this.QtdeLamina.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QtdeLamina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.QtdeLamina.Location = new System.Drawing.Point(147, 141);
            this.QtdeLamina.Name = "QtdeLamina";
            this.QtdeLamina.Size = new System.Drawing.Size(49, 14);
            this.QtdeLamina.TabIndex = 25;
            this.QtdeLamina.Text = "000000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 14);
            this.label11.TabIndex = 24;
            this.label11.Text = "Total de lâminas..:";
            // 
            // Valor_ci_Total
            // 
            this.Valor_ci_Total.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valor_ci_Total.ForeColor = System.Drawing.Color.Purple;
            this.Valor_ci_Total.Location = new System.Drawing.Point(330, 121);
            this.Valor_ci_Total.Name = "Valor_ci_Total";
            this.Valor_ci_Total.Size = new System.Drawing.Size(112, 14);
            this.Valor_ci_Total.TabIndex = 23;
            this.Valor_ci_Total.Text = "R$ 0,00";
            this.Valor_ci_Total.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Valor_ci_IsentoProcesso
            // 
            this.Valor_ci_IsentoProcesso.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valor_ci_IsentoProcesso.ForeColor = System.Drawing.Color.Purple;
            this.Valor_ci_IsentoProcesso.Location = new System.Drawing.Point(330, 94);
            this.Valor_ci_IsentoProcesso.Name = "Valor_ci_IsentoProcesso";
            this.Valor_ci_IsentoProcesso.Size = new System.Drawing.Size(112, 14);
            this.Valor_ci_IsentoProcesso.TabIndex = 22;
            this.Valor_ci_IsentoProcesso.Text = "R$ 0,00";
            this.Valor_ci_IsentoProcesso.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Valor_ci_IsentoArea
            // 
            this.Valor_ci_IsentoArea.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valor_ci_IsentoArea.ForeColor = System.Drawing.Color.Purple;
            this.Valor_ci_IsentoArea.Location = new System.Drawing.Point(330, 74);
            this.Valor_ci_IsentoArea.Name = "Valor_ci_IsentoArea";
            this.Valor_ci_IsentoArea.Size = new System.Drawing.Size(112, 14);
            this.Valor_ci_IsentoArea.TabIndex = 21;
            this.Valor_ci_IsentoArea.Text = "R$ 0,00";
            this.Valor_ci_IsentoArea.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Valor_ci_Imune
            // 
            this.Valor_ci_Imune.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valor_ci_Imune.ForeColor = System.Drawing.Color.Purple;
            this.Valor_ci_Imune.Location = new System.Drawing.Point(330, 54);
            this.Valor_ci_Imune.Name = "Valor_ci_Imune";
            this.Valor_ci_Imune.Size = new System.Drawing.Size(112, 14);
            this.Valor_ci_Imune.TabIndex = 20;
            this.Valor_ci_Imune.Text = "R$ 0,00";
            this.Valor_ci_Imune.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Valor_ci_Normal
            // 
            this.Valor_ci_Normal.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valor_ci_Normal.ForeColor = System.Drawing.Color.Purple;
            this.Valor_ci_Normal.Location = new System.Drawing.Point(330, 34);
            this.Valor_ci_Normal.Name = "Valor_ci_Normal";
            this.Valor_ci_Normal.Size = new System.Drawing.Size(112, 14);
            this.Valor_ci_Normal.TabIndex = 19;
            this.Valor_ci_Normal.Text = "R$ 0,00";
            this.Valor_ci_Normal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Valor_si_Total
            // 
            this.Valor_si_Total.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valor_si_Total.ForeColor = System.Drawing.Color.Navy;
            this.Valor_si_Total.Location = new System.Drawing.Point(212, 121);
            this.Valor_si_Total.Name = "Valor_si_Total";
            this.Valor_si_Total.Size = new System.Drawing.Size(112, 14);
            this.Valor_si_Total.TabIndex = 18;
            this.Valor_si_Total.Text = "R$ 0,00";
            this.Valor_si_Total.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Valor_si_IsentoProcesso
            // 
            this.Valor_si_IsentoProcesso.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valor_si_IsentoProcesso.ForeColor = System.Drawing.Color.Navy;
            this.Valor_si_IsentoProcesso.Location = new System.Drawing.Point(212, 94);
            this.Valor_si_IsentoProcesso.Name = "Valor_si_IsentoProcesso";
            this.Valor_si_IsentoProcesso.Size = new System.Drawing.Size(112, 14);
            this.Valor_si_IsentoProcesso.TabIndex = 17;
            this.Valor_si_IsentoProcesso.Text = "R$ 0,00";
            this.Valor_si_IsentoProcesso.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Valor_si_IsentoArea
            // 
            this.Valor_si_IsentoArea.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valor_si_IsentoArea.ForeColor = System.Drawing.Color.Navy;
            this.Valor_si_IsentoArea.Location = new System.Drawing.Point(212, 74);
            this.Valor_si_IsentoArea.Name = "Valor_si_IsentoArea";
            this.Valor_si_IsentoArea.Size = new System.Drawing.Size(112, 14);
            this.Valor_si_IsentoArea.TabIndex = 16;
            this.Valor_si_IsentoArea.Text = "R$ 0,00";
            this.Valor_si_IsentoArea.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Valor_si_Imune
            // 
            this.Valor_si_Imune.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valor_si_Imune.ForeColor = System.Drawing.Color.Navy;
            this.Valor_si_Imune.Location = new System.Drawing.Point(212, 54);
            this.Valor_si_Imune.Name = "Valor_si_Imune";
            this.Valor_si_Imune.Size = new System.Drawing.Size(112, 14);
            this.Valor_si_Imune.TabIndex = 15;
            this.Valor_si_Imune.Text = "R$ 0,00";
            this.Valor_si_Imune.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Valor_si_Normal
            // 
            this.Valor_si_Normal.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Valor_si_Normal.ForeColor = System.Drawing.Color.Navy;
            this.Valor_si_Normal.Location = new System.Drawing.Point(212, 34);
            this.Valor_si_Normal.Name = "Valor_si_Normal";
            this.Valor_si_Normal.Size = new System.Drawing.Size(112, 14);
            this.Valor_si_Normal.TabIndex = 14;
            this.Valor_si_Normal.Text = "R$ 0,00";
            this.Valor_si_Normal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // QtdeTotal
            // 
            this.QtdeTotal.AutoSize = true;
            this.QtdeTotal.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QtdeTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.QtdeTotal.Location = new System.Drawing.Point(154, 121);
            this.QtdeTotal.Name = "QtdeTotal";
            this.QtdeTotal.Size = new System.Drawing.Size(42, 14);
            this.QtdeTotal.TabIndex = 13;
            this.QtdeTotal.Text = "00000";
            // 
            // QtdeIsentoProcesso
            // 
            this.QtdeIsentoProcesso.AutoSize = true;
            this.QtdeIsentoProcesso.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QtdeIsentoProcesso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.QtdeIsentoProcesso.Location = new System.Drawing.Point(154, 94);
            this.QtdeIsentoProcesso.Name = "QtdeIsentoProcesso";
            this.QtdeIsentoProcesso.Size = new System.Drawing.Size(42, 14);
            this.QtdeIsentoProcesso.TabIndex = 12;
            this.QtdeIsentoProcesso.Text = "00000";
            // 
            // QtdeIsentoArea
            // 
            this.QtdeIsentoArea.AutoSize = true;
            this.QtdeIsentoArea.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QtdeIsentoArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.QtdeIsentoArea.Location = new System.Drawing.Point(154, 74);
            this.QtdeIsentoArea.Name = "QtdeIsentoArea";
            this.QtdeIsentoArea.Size = new System.Drawing.Size(42, 14);
            this.QtdeIsentoArea.TabIndex = 11;
            this.QtdeIsentoArea.Text = "00000";
            // 
            // QtdeImune
            // 
            this.QtdeImune.AutoSize = true;
            this.QtdeImune.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QtdeImune.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.QtdeImune.Location = new System.Drawing.Point(154, 54);
            this.QtdeImune.Name = "QtdeImune";
            this.QtdeImune.Size = new System.Drawing.Size(42, 14);
            this.QtdeImune.TabIndex = 10;
            this.QtdeImune.Text = "00000";
            // 
            // QtdeNormal
            // 
            this.QtdeNormal.AutoSize = true;
            this.QtdeNormal.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QtdeNormal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.QtdeNormal.Location = new System.Drawing.Point(154, 34);
            this.QtdeNormal.Name = "QtdeNormal";
            this.QtdeNormal.Size = new System.Drawing.Size(42, 14);
            this.QtdeNormal.TabIndex = 9;
            this.QtdeNormal.Text = "00000";
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(9, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(435, 2);
            this.label10.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 14);
            this.label9.TabIndex = 7;
            this.label9.Text = "Total de imóveis..:";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(330, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Valor c/Isenção";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(212, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Valor s/Isenção";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(147, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Qtde";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Isentos processo..:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Isentos por área..:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Imunidade total...:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Imóveis normais...:";
            // 
            // Calculo_Imposto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 275);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExportarButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.PBar);
            this.Controls.Add(this.ExecutarButton);
            this.Controls.Add(this.ImpostoList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Calculo_Imposto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculo de Imposto";
            this.Load += new System.EventHandler(this.Calculo_Imposto_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ImpostoList;
        private System.Windows.Forms.Button ExecutarButton;
        private System.Windows.Forms.ProgressBar PBar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel MsgToolStrip;
        private System.Windows.Forms.Button ExportarButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label QtdeTotal;
        private System.Windows.Forms.Label QtdeIsentoProcesso;
        private System.Windows.Forms.Label QtdeIsentoArea;
        private System.Windows.Forms.Label QtdeImune;
        private System.Windows.Forms.Label QtdeNormal;
        private System.Windows.Forms.Label Valor_ci_Total;
        private System.Windows.Forms.Label Valor_ci_IsentoProcesso;
        private System.Windows.Forms.Label Valor_ci_IsentoArea;
        private System.Windows.Forms.Label Valor_ci_Imune;
        private System.Windows.Forms.Label Valor_ci_Normal;
        private System.Windows.Forms.Label Valor_si_Total;
        private System.Windows.Forms.Label Valor_si_IsentoProcesso;
        private System.Windows.Forms.Label Valor_si_IsentoArea;
        private System.Windows.Forms.Label Valor_si_Imune;
        private System.Windows.Forms.Label Valor_si_Normal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label QtdeLamina;
        private System.Windows.Forms.Label label11;
    }
}