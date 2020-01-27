namespace GTI_Desktop.Forms {
    partial class Parcelamento_Lista {
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
            this.ProcessoList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OrigemListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DestinoListView = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ParceladoPorText = new System.Windows.Forms.TextBox();
            this.ParceladoEmText = new System.Windows.Forms.TextBox();
            this.SituacaoText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CanceladoPorText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CanceladoEmText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº do processo..:";
            // 
            // ProcessoList
            // 
            this.ProcessoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProcessoList.FormattingEnabled = true;
            this.ProcessoList.Location = new System.Drawing.Point(103, 35);
            this.ProcessoList.Name = "ProcessoList";
            this.ProcessoList.Size = new System.Drawing.Size(104, 21);
            this.ProcessoList.TabIndex = 1;
            this.ProcessoList.SelectedIndexChanged += new System.EventHandler(this.ProcessoList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OrigemListView);
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(244, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 176);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Origem do parcelamento";
            // 
            // OrigemListView
            // 
            this.OrigemListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.OrigemListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.OrigemListView.FullRowSelect = true;
            this.OrigemListView.GridLines = true;
            this.OrigemListView.Location = new System.Drawing.Point(9, 22);
            this.OrigemListView.Name = "OrigemListView";
            this.OrigemListView.Size = new System.Drawing.Size(363, 148);
            this.OrigemListView.TabIndex = 0;
            this.OrigemListView.UseCompatibleStateImageBehavior = false;
            this.OrigemListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ano";
            this.columnHeader1.Width = 45;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Lançamento";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Sq";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 30;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Pc";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 30;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Cp";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 30;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DestinoListView);
            this.groupBox2.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox2.Location = new System.Drawing.Point(244, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 176);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destino do parcelamento";
            // 
            // DestinoListView
            // 
            this.DestinoListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.DestinoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.DestinoListView.FullRowSelect = true;
            this.DestinoListView.GridLines = true;
            this.DestinoListView.Location = new System.Drawing.Point(9, 22);
            this.DestinoListView.Name = "DestinoListView";
            this.DestinoListView.Size = new System.Drawing.Size(363, 148);
            this.DestinoListView.TabIndex = 0;
            this.DestinoListView.UseCompatibleStateImageBehavior = false;
            this.DestinoListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ano";
            this.columnHeader6.Width = 45;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Lc";
            this.columnHeader7.Width = 30;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Sq";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 30;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Pc";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader9.Width = 30;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Cp";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader10.Width = 30;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Dt.Vencto";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 80;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Situação";
            this.columnHeader12.Width = 90;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LemonChiffon;
            this.groupBox3.Controls.Add(this.CanceladoEmText);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.CanceladoPorText);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.SituacaoText);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.ParceladoEmText);
            this.groupBox3.Controls.Add(this.ParceladoPorText);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.ProcessoList);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox3.Location = new System.Drawing.Point(6, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(232, 356);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dados do parcelamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(8, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Parcelado por..:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(8, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Parcelado em..:";
            // 
            // ParceladoPorText
            // 
            this.ParceladoPorText.BackColor = System.Drawing.Color.LemonChiffon;
            this.ParceladoPorText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ParceladoPorText.Location = new System.Drawing.Point(96, 88);
            this.ParceladoPorText.Name = "ParceladoPorText";
            this.ParceladoPorText.ReadOnly = true;
            this.ParceladoPorText.Size = new System.Drawing.Size(130, 13);
            this.ParceladoPorText.TabIndex = 5;
            this.ParceladoPorText.TabStop = false;
            // 
            // ParceladoEmText
            // 
            this.ParceladoEmText.BackColor = System.Drawing.Color.LemonChiffon;
            this.ParceladoEmText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ParceladoEmText.Location = new System.Drawing.Point(95, 63);
            this.ParceladoEmText.Name = "ParceladoEmText";
            this.ParceladoEmText.ReadOnly = true;
            this.ParceladoEmText.Size = new System.Drawing.Size(130, 13);
            this.ParceladoEmText.TabIndex = 6;
            this.ParceladoEmText.TabStop = false;
            // 
            // SituacaoText
            // 
            this.SituacaoText.BackColor = System.Drawing.Color.LemonChiffon;
            this.SituacaoText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SituacaoText.Location = new System.Drawing.Point(96, 113);
            this.SituacaoText.Name = "SituacaoText";
            this.SituacaoText.ReadOnly = true;
            this.SituacaoText.Size = new System.Drawing.Size(130, 13);
            this.SituacaoText.TabIndex = 8;
            this.SituacaoText.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(8, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Situação..........:";
            // 
            // CanceladoPorText
            // 
            this.CanceladoPorText.BackColor = System.Drawing.Color.LemonChiffon;
            this.CanceladoPorText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CanceladoPorText.Location = new System.Drawing.Point(96, 137);
            this.CanceladoPorText.Name = "CanceladoPorText";
            this.CanceladoPorText.ReadOnly = true;
            this.CanceladoPorText.Size = new System.Drawing.Size(130, 13);
            this.CanceladoPorText.TabIndex = 10;
            this.CanceladoPorText.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(8, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cancelado por.:";
            // 
            // CanceladoEmText
            // 
            this.CanceladoEmText.BackColor = System.Drawing.Color.LemonChiffon;
            this.CanceladoEmText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CanceladoEmText.Location = new System.Drawing.Point(96, 163);
            this.CanceladoEmText.Name = "CanceladoEmText";
            this.CanceladoEmText.ReadOnly = true;
            this.CanceladoEmText.Size = new System.Drawing.Size(130, 13);
            this.CanceladoEmText.TabIndex = 12;
            this.CanceladoEmText.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(8, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cancelado em.:";
            // 
            // Parcelamento_Lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(629, 374);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Parcelamento_Lista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lista de Parcelamentos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ProcessoList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView OrigemListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView DestinoListView;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ParceladoPorText;
        private System.Windows.Forms.TextBox ParceladoEmText;
        private System.Windows.Forms.TextBox CanceladoEmText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CanceladoPorText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SituacaoText;
        private System.Windows.Forms.Label label4;
    }
}