namespace GTI_Desktop.Forms {
    partial class Processo_Tramite {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Processo_Tramite));
            this.btCancelLocal = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.btCancelEnvRec = new System.Windows.Forms.Button();
            this.cmbCCusto = new System.Windows.Forms.ComboBox();
            this.pnlLocal = new Owf.Controls.A1Panel();
            this.btOkLocal = new System.Windows.Forms.Button();
            this.lblComplemento = new System.Windows.Forms.Label();
            this.lblRequerente = new System.Windows.Forms.Label();
            this.lblNumProc = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblLocal = new System.Windows.Forms.Label();
            this.cmbDespacho2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFuncionario = new System.Windows.Forms.ComboBox();
            this.btOKEnvRec = new System.Windows.Forms.Button();
            this.btCancelDespacho = new System.Windows.Forms.Button();
            this.btOKDespacho = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblSit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDespacho = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlEnvRec = new Owf.Controls.A1Panel();
            this.lblEnvRec = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlDespacho = new Owf.Controls.A1Panel();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.btAddLocal = new System.Windows.Forms.ToolStripButton();
            this.btRemoveLocal = new System.Windows.Forms.ToolStripButton();
            this.btUp = new System.Windows.Forms.ToolStripButton();
            this.btDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btEmprestimo = new System.Windows.Forms.ToolStripButton();
            this.btAlterar = new System.Windows.Forms.ToolStripButton();
            this.btObs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btReceber = new System.Windows.Forms.ToolStripButton();
            this.btEnviar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btSair = new System.Windows.Forms.ToolStripButton();
            this.label10 = new System.Windows.Forms.Label();
            this.labelreq = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvMain = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlLocal.SuspendLayout();
            this.pnlEnvRec.SuspendLayout();
            this.pnlDespacho.SuspendLayout();
            this.tBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelLocal
            // 
            this.btCancelLocal.BackColor = System.Drawing.Color.Transparent;
            this.btCancelLocal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelLocal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelLocal.FlatAppearance.BorderSize = 0;
            this.btCancelLocal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.btCancelLocal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btCancelLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelLocal.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.btCancelLocal.Location = new System.Drawing.Point(415, 33);
            this.btCancelLocal.Name = "btCancelLocal";
            this.btCancelLocal.Size = new System.Drawing.Size(19, 19);
            this.btCancelLocal.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btCancelLocal, "Cancelar operação");
            this.btCancelLocal.UseVisualStyleBackColor = false;
            this.btCancelLocal.Click += new System.EventHandler(this.BtCancelLocal_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(14, 6);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(93, 16);
            this.label29.TabIndex = 1;
            this.label29.Text = "Inserir Local";
            // 
            // btCancelEnvRec
            // 
            this.btCancelEnvRec.BackColor = System.Drawing.Color.Transparent;
            this.btCancelEnvRec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelEnvRec.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelEnvRec.FlatAppearance.BorderSize = 0;
            this.btCancelEnvRec.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.btCancelEnvRec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btCancelEnvRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelEnvRec.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.btCancelEnvRec.Location = new System.Drawing.Point(399, 102);
            this.btCancelEnvRec.Name = "btCancelEnvRec";
            this.btCancelEnvRec.Size = new System.Drawing.Size(22, 19);
            this.btCancelEnvRec.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btCancelEnvRec, "Cancelar operação");
            this.btCancelEnvRec.UseVisualStyleBackColor = false;
            this.btCancelEnvRec.Click += new System.EventHandler(this.BtCancelEnvRec_Click);
            // 
            // cmbCCusto
            // 
            this.cmbCCusto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCCusto.FormattingEnabled = true;
            this.cmbCCusto.Location = new System.Drawing.Point(16, 31);
            this.cmbCCusto.Name = "cmbCCusto";
            this.cmbCCusto.Size = new System.Drawing.Size(368, 21);
            this.cmbCCusto.TabIndex = 22;
            // 
            // pnlLocal
            // 
            this.pnlLocal.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlLocal.BorderColor = System.Drawing.Color.DimGray;
            this.pnlLocal.Controls.Add(this.cmbCCusto);
            this.pnlLocal.Controls.Add(this.btCancelLocal);
            this.pnlLocal.Controls.Add(this.btOkLocal);
            this.pnlLocal.Controls.Add(this.label29);
            this.pnlLocal.GradientEndColor = System.Drawing.Color.White;
            this.pnlLocal.GradientStartColor = System.Drawing.Color.PaleGreen;
            this.pnlLocal.Image = null;
            this.pnlLocal.ImageLocation = new System.Drawing.Point(4, 4);
            this.pnlLocal.Location = new System.Drawing.Point(119, 109);
            this.pnlLocal.Name = "pnlLocal";
            this.pnlLocal.RoundCornerRadius = 9;
            this.pnlLocal.ShadowOffSet = 9;
            this.pnlLocal.Size = new System.Drawing.Size(452, 79);
            this.pnlLocal.TabIndex = 166;
            this.pnlLocal.Visible = false;
            // 
            // btOkLocal
            // 
            this.btOkLocal.BackColor = System.Drawing.Color.Transparent;
            this.btOkLocal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btOkLocal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btOkLocal.FlatAppearance.BorderSize = 0;
            this.btOkLocal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.btOkLocal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btOkLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOkLocal.Image = global::GTI_Desktop.Properties.Resources.OK;
            this.btOkLocal.Location = new System.Drawing.Point(390, 33);
            this.btOkLocal.Name = "btOkLocal";
            this.btOkLocal.Size = new System.Drawing.Size(19, 19);
            this.btOkLocal.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btOkLocal, "Inserir o local selecionado no trâmite do processo");
            this.btOkLocal.UseVisualStyleBackColor = false;
            this.btOkLocal.Click += new System.EventHandler(this.BtOkLocal_Click);
            // 
            // lblComplemento
            // 
            this.lblComplemento.AutoSize = true;
            this.lblComplemento.ForeColor = System.Drawing.Color.Maroon;
            this.lblComplemento.Location = new System.Drawing.Point(92, 27);
            this.lblComplemento.Name = "lblComplemento";
            this.lblComplemento.Size = new System.Drawing.Size(14, 13);
            this.lblComplemento.TabIndex = 165;
            this.lblComplemento.Text = "X";
            // 
            // lblRequerente
            // 
            this.lblRequerente.AutoSize = true;
            this.lblRequerente.ForeColor = System.Drawing.Color.Maroon;
            this.lblRequerente.Location = new System.Drawing.Point(265, 4);
            this.lblRequerente.Name = "lblRequerente";
            this.lblRequerente.Size = new System.Drawing.Size(14, 13);
            this.lblRequerente.TabIndex = 164;
            this.lblRequerente.Text = "X";
            // 
            // lblNumProc
            // 
            this.lblNumProc.AutoSize = true;
            this.lblNumProc.ForeColor = System.Drawing.Color.Maroon;
            this.lblNumProc.Location = new System.Drawing.Point(92, 5);
            this.lblNumProc.Name = "lblNumProc";
            this.lblNumProc.Size = new System.Drawing.Size(75, 13);
            this.lblNumProc.TabIndex = 163;
            this.lblNumProc.Text = "00000-0/0000";
            // 
            // txtObs
            // 
            this.txtObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObs.Location = new System.Drawing.Point(12, 297);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.ReadOnly = true;
            this.txtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObs.Size = new System.Drawing.Size(771, 44);
            this.txtObs.TabIndex = 162;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.BackColor = System.Drawing.Color.Transparent;
            this.lblHora.Location = new System.Drawing.Point(171, 59);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(34, 13);
            this.lblHora.TabIndex = 31;
            this.lblHora.Text = "12:23";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.BackColor = System.Drawing.Color.Transparent;
            this.lblData.Location = new System.Drawing.Point(93, 59);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(65, 13);
            this.lblData.TabIndex = 29;
            this.lblData.Text = "12/08/2015";
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.BackColor = System.Drawing.Color.Transparent;
            this.lblLocal.Location = new System.Drawing.Point(93, 35);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(43, 13);
            this.lblLocal.TabIndex = 28;
            this.lblLocal.Text = "lblLocal";
            // 
            // cmbDespacho2
            // 
            this.cmbDespacho2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDespacho2.FormattingEnabled = true;
            this.cmbDespacho2.Location = new System.Drawing.Point(94, 102);
            this.cmbDespacho2.Name = "cmbDespacho2";
            this.cmbDespacho2.Size = new System.Drawing.Size(273, 21);
            this.cmbDespacho2.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(17, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Despacho....:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(17, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Funcionário..:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(17, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Data/Hora...:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(17, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Local...........:";
            // 
            // cmbFuncionario
            // 
            this.cmbFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFuncionario.FormattingEnabled = true;
            this.cmbFuncionario.Location = new System.Drawing.Point(94, 78);
            this.cmbFuncionario.Name = "cmbFuncionario";
            this.cmbFuncionario.Size = new System.Drawing.Size(273, 21);
            this.cmbFuncionario.Sorted = true;
            this.cmbFuncionario.TabIndex = 22;
            // 
            // btOKEnvRec
            // 
            this.btOKEnvRec.BackColor = System.Drawing.Color.Transparent;
            this.btOKEnvRec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btOKEnvRec.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btOKEnvRec.FlatAppearance.BorderSize = 0;
            this.btOKEnvRec.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.btOKEnvRec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btOKEnvRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOKEnvRec.Image = global::GTI_Desktop.Properties.Resources.OK;
            this.btOKEnvRec.Location = new System.Drawing.Point(374, 102);
            this.btOKEnvRec.Name = "btOKEnvRec";
            this.btOKEnvRec.Size = new System.Drawing.Size(22, 19);
            this.btOKEnvRec.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btOKEnvRec, "Confirmar recebimento");
            this.btOKEnvRec.UseVisualStyleBackColor = false;
            this.btOKEnvRec.Click += new System.EventHandler(this.BtOKEnvRec_Click);
            // 
            // btCancelDespacho
            // 
            this.btCancelDespacho.BackColor = System.Drawing.Color.Transparent;
            this.btCancelDespacho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancelDespacho.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelDespacho.FlatAppearance.BorderSize = 0;
            this.btCancelDespacho.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.btCancelDespacho.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btCancelDespacho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelDespacho.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.btCancelDespacho.Location = new System.Drawing.Point(415, 33);
            this.btCancelDespacho.Name = "btCancelDespacho";
            this.btCancelDespacho.Size = new System.Drawing.Size(19, 19);
            this.btCancelDespacho.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btCancelDespacho, "Cancelar operação");
            this.btCancelDespacho.UseVisualStyleBackColor = false;
            this.btCancelDespacho.Click += new System.EventHandler(this.BtCancelDespacho_Click);
            // 
            // btOKDespacho
            // 
            this.btOKDespacho.BackColor = System.Drawing.Color.Transparent;
            this.btOKDespacho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btOKDespacho.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btOKDespacho.FlatAppearance.BorderSize = 0;
            this.btOKDespacho.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.btOKDespacho.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btOKDespacho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOKDespacho.Image = global::GTI_Desktop.Properties.Resources.OK;
            this.btOKDespacho.Location = new System.Drawing.Point(390, 33);
            this.btOKDespacho.Name = "btOKDespacho";
            this.btOKDespacho.Size = new System.Drawing.Size(19, 19);
            this.btOKDespacho.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btOKDespacho, "Alterar o despacho do processo");
            this.btOKDespacho.UseVisualStyleBackColor = false;
            this.btOKDespacho.Click += new System.EventHandler(this.BtOKDespacho_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "comment2.png");
            // 
            // lblSit
            // 
            this.lblSit.AutoSize = true;
            this.lblSit.ForeColor = System.Drawing.Color.Maroon;
            this.lblSit.Location = new System.Drawing.Point(581, 27);
            this.lblSit.Name = "lblSit";
            this.lblSit.Size = new System.Drawing.Size(14, 13);
            this.lblSit.TabIndex = 168;
            this.lblSit.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 167;
            this.label2.Text = "Situação.:";
            // 
            // cmbDespacho
            // 
            this.cmbDespacho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDespacho.FormattingEnabled = true;
            this.cmbDespacho.Location = new System.Drawing.Point(16, 31);
            this.cmbDespacho.Name = "cmbDespacho";
            this.cmbDespacho.Size = new System.Drawing.Size(368, 21);
            this.cmbDespacho.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Alterar Despacho";
            // 
            // pnlEnvRec
            // 
            this.pnlEnvRec.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlEnvRec.BorderColor = System.Drawing.Color.DimGray;
            this.pnlEnvRec.Controls.Add(this.lblHora);
            this.pnlEnvRec.Controls.Add(this.lblData);
            this.pnlEnvRec.Controls.Add(this.lblLocal);
            this.pnlEnvRec.Controls.Add(this.cmbDespacho2);
            this.pnlEnvRec.Controls.Add(this.label8);
            this.pnlEnvRec.Controls.Add(this.label7);
            this.pnlEnvRec.Controls.Add(this.label6);
            this.pnlEnvRec.Controls.Add(this.label5);
            this.pnlEnvRec.Controls.Add(this.cmbFuncionario);
            this.pnlEnvRec.Controls.Add(this.btCancelEnvRec);
            this.pnlEnvRec.Controls.Add(this.btOKEnvRec);
            this.pnlEnvRec.Controls.Add(this.lblEnvRec);
            this.pnlEnvRec.GradientEndColor = System.Drawing.Color.White;
            this.pnlEnvRec.GradientStartColor = System.Drawing.Color.LightBlue;
            this.pnlEnvRec.Image = null;
            this.pnlEnvRec.ImageLocation = new System.Drawing.Point(4, 4);
            this.pnlEnvRec.Location = new System.Drawing.Point(125, 79);
            this.pnlEnvRec.Name = "pnlEnvRec";
            this.pnlEnvRec.RoundCornerRadius = 9;
            this.pnlEnvRec.ShadowOffSet = 9;
            this.pnlEnvRec.Size = new System.Drawing.Size(443, 142);
            this.pnlEnvRec.TabIndex = 170;
            this.pnlEnvRec.Visible = false;
            // 
            // lblEnvRec
            // 
            this.lblEnvRec.AutoSize = true;
            this.lblEnvRec.BackColor = System.Drawing.Color.Transparent;
            this.lblEnvRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnvRec.Location = new System.Drawing.Point(14, 6);
            this.lblEnvRec.Name = "lblEnvRec";
            this.lblEnvRec.Size = new System.Drawing.Size(117, 16);
            this.lblEnvRec.TabIndex = 1;
            this.lblEnvRec.Text = "Enviar/Receber";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Observação";
            this.columnHeader12.Width = 0;
            // 
            // pnlDespacho
            // 
            this.pnlDespacho.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlDespacho.BorderColor = System.Drawing.Color.DimGray;
            this.pnlDespacho.Controls.Add(this.cmbDespacho);
            this.pnlDespacho.Controls.Add(this.btCancelDespacho);
            this.pnlDespacho.Controls.Add(this.btOKDespacho);
            this.pnlDespacho.Controls.Add(this.label3);
            this.pnlDespacho.GradientEndColor = System.Drawing.Color.White;
            this.pnlDespacho.GradientStartColor = System.Drawing.Color.PaleGoldenrod;
            this.pnlDespacho.Image = null;
            this.pnlDespacho.ImageLocation = new System.Drawing.Point(4, 4);
            this.pnlDespacho.Location = new System.Drawing.Point(116, 109);
            this.pnlDespacho.Name = "pnlDespacho";
            this.pnlDespacho.RoundCornerRadius = 9;
            this.pnlDespacho.ShadowOffSet = 9;
            this.pnlDespacho.Size = new System.Drawing.Size(452, 79);
            this.pnlDespacho.TabIndex = 169;
            this.pnlDespacho.Visible = false;
            // 
            // tBar
            // 
            this.tBar.AllowMerge = false;
            this.tBar.BackColor = System.Drawing.SystemColors.Control;
            this.tBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btAddLocal,
            this.btRemoveLocal,
            this.btUp,
            this.btDown,
            this.toolStripSeparator3,
            this.btEmprestimo,
            this.btAlterar,
            this.btObs,
            this.toolStripSeparator1,
            this.btReceber,
            this.btEnviar,
            this.toolStripSeparator2,
            this.btSair});
            this.tBar.Location = new System.Drawing.Point(0, 354);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(794, 25);
            this.tBar.TabIndex = 157;
            this.tBar.Text = "toolStrip1";
            // 
            // btAddLocal
            // 
            this.btAddLocal.Image = global::GTI_Desktop.Properties.Resources.addfavorite;
            this.btAddLocal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAddLocal.Name = "btAddLocal";
            this.btAddLocal.Size = new System.Drawing.Size(87, 22);
            this.btAddLocal.Text = "Inserir local";
            this.btAddLocal.ToolTipText = "Inserir um novo local de trâmite";
            this.btAddLocal.Click += new System.EventHandler(this.BtAddLocal_Click);
            // 
            // btRemoveLocal
            // 
            this.btRemoveLocal.Image = global::GTI_Desktop.Properties.Resources.removefavorite;
            this.btRemoveLocal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btRemoveLocal.Name = "btRemoveLocal";
            this.btRemoveLocal.Size = new System.Drawing.Size(102, 22);
            this.btRemoveLocal.Text = "Remover local";
            this.btRemoveLocal.ToolTipText = "Remover o local selecionado";
            this.btRemoveLocal.Click += new System.EventHandler(this.BtRemoveLocal_Click);
            // 
            // btUp
            // 
            this.btUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btUp.Image = global::GTI_Desktop.Properties.Resources.uparrow;
            this.btUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(23, 22);
            this.btUp.ToolTipText = "Mover seleção para cima";
            this.btUp.Click += new System.EventHandler(this.BtUp_Click);
            // 
            // btDown
            // 
            this.btDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btDown.Image = global::GTI_Desktop.Properties.Resources.downarrow1;
            this.btDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(23, 22);
            this.btDown.ToolTipText = "Mover seleção para baixo";
            this.btDown.Click += new System.EventHandler(this.BtDown_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btEmprestimo
            // 
            this.btEmprestimo.Image = global::GTI_Desktop.Properties.Resources.anexo;
            this.btEmprestimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btEmprestimo.Name = "btEmprestimo";
            this.btEmprestimo.Size = new System.Drawing.Size(96, 22);
            this.btEmprestimo.Text = "Empréstimos";
            this.btEmprestimo.ToolTipText = "Exibir empréstimos";
            this.btEmprestimo.Click += new System.EventHandler(this.BtEmprestimo_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.Image = global::GTI_Desktop.Properties.Resources.Alterar;
            this.btAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAlterar.Name = "btAlterar";
            this.btAlterar.Size = new System.Drawing.Size(62, 22);
            this.btAlterar.Text = "Alterar";
            this.btAlterar.ToolTipText = "Alterar o despacho selecionado";
            this.btAlterar.Click += new System.EventHandler(this.BtAlterar_Click);
            // 
            // btObs
            // 
            this.btObs.Image = global::GTI_Desktop.Properties.Resources.comment;
            this.btObs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btObs.Name = "btObs";
            this.btObs.Size = new System.Drawing.Size(89, 22);
            this.btObs.Text = "Observação";
            this.btObs.Click += new System.EventHandler(this.BtObs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btReceber
            // 
            this.btReceber.AccessibleDescription = "Cancelar operação";
            this.btReceber.Image = global::GTI_Desktop.Properties.Resources.receber;
            this.btReceber.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btReceber.Name = "btReceber";
            this.btReceber.Size = new System.Drawing.Size(69, 22);
            this.btReceber.Text = "Receber";
            this.btReceber.ToolTipText = "Recebimento de processo";
            this.btReceber.Click += new System.EventHandler(this.BtReceber_Click);
            // 
            // btEnviar
            // 
            this.btEnviar.Image = global::GTI_Desktop.Properties.Resources.enviar;
            this.btEnviar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(59, 22);
            this.btEnviar.Text = "Enviar";
            this.btEnviar.ToolTipText = "Envio de processo";
            this.btEnviar.Click += new System.EventHandler(this.BtEnviar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btSair
            // 
            this.btSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btSair.Image = global::GTI_Desktop.Properties.Resources.Exit;
            this.btSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(23, 22);
            this.btSair.Text = "toolStripButton5";
            this.btSair.ToolTipText = "Sair da tela";
            this.btSair.Click += new System.EventHandler(this.BtSair_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 161;
            this.label10.Text = "Assunto.........:";
            // 
            // labelreq
            // 
            this.labelreq.AutoSize = true;
            this.labelreq.Location = new System.Drawing.Point(184, 4);
            this.labelreq.Name = "labelreq";
            this.labelreq.Size = new System.Drawing.Size(75, 13);
            this.labelreq.TabIndex = 160;
            this.labelreq.Text = "Requerente...:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 158;
            this.label1.Text = "Nº Processo..:";
            // 
            // lvMain
            // 
            this.lvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader6,
            this.columnHeader11,
            this.columnHeader7,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader10,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader12});
            this.lvMain.FullRowSelect = true;
            this.lvMain.GridLines = true;
            this.lvMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvMain.Location = new System.Drawing.Point(12, 48);
            this.lvMain.MinimumSize = new System.Drawing.Size(565, 176);
            this.lvMain.Name = "lvMain";
            this.lvMain.Size = new System.Drawing.Size(770, 243);
            this.lvMain.SmallImageList = this.imageList1;
            this.lvMain.TabIndex = 159;
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.View = System.Windows.Forms.View.Details;
            this.lvMain.SelectedIndexChanged += new System.EventHandler(this.LvMain_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Obs";
            this.columnHeader1.Width = 32;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Sq";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 30;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "CCCod";
            this.columnHeader11.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Local";
            this.columnHeader7.Width = 230;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Hora";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Recebido por";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Despacho";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Dias";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader10.Width = 35;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Dt.Envio";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 70;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Usuário";
            this.columnHeader9.Width = 90;
            // 
            // Processo_Tramite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 379);
            this.Controls.Add(this.pnlEnvRec);
            this.Controls.Add(this.pnlDespacho);
            this.Controls.Add(this.pnlLocal);
            this.Controls.Add(this.lblComplemento);
            this.Controls.Add(this.lblRequerente);
            this.Controls.Add(this.lblNumProc);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.lblSit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelreq);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvMain);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(690, 368);
            this.Name = "Processo_Tramite";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processo_Tramite";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Processo_Tramite_FormClosing);
            this.pnlLocal.ResumeLayout(false);
            this.pnlLocal.PerformLayout();
            this.pnlEnvRec.ResumeLayout(false);
            this.pnlEnvRec.PerformLayout();
            this.pnlDespacho.ResumeLayout(false);
            this.pnlDespacho.PerformLayout();
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCancelLocal;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btCancelEnvRec;
        private System.Windows.Forms.ComboBox cmbCCusto;
        private Owf.Controls.A1Panel pnlLocal;
        private System.Windows.Forms.Button btOkLocal;
        private System.Windows.Forms.Label lblComplemento;
        private System.Windows.Forms.Label lblRequerente;
        private System.Windows.Forms.Label lblNumProc;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.ComboBox cmbDespacho2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbFuncionario;
        private System.Windows.Forms.Button btOKEnvRec;
        private System.Windows.Forms.Button btCancelDespacho;
        private System.Windows.Forms.Button btOKDespacho;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblSit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDespacho;
        private System.Windows.Forms.Label label3;
        private Owf.Controls.A1Panel pnlEnvRec;
        private System.Windows.Forms.Label lblEnvRec;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private Owf.Controls.A1Panel pnlDespacho;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton btAddLocal;
        private System.Windows.Forms.ToolStripButton btRemoveLocal;
        private System.Windows.Forms.ToolStripButton btUp;
        private System.Windows.Forms.ToolStripButton btDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btEmprestimo;
        private System.Windows.Forms.ToolStripButton btAlterar;
        private System.Windows.Forms.ToolStripButton btObs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btReceber;
        private System.Windows.Forms.ToolStripButton btEnviar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btSair;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelreq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvMain;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}