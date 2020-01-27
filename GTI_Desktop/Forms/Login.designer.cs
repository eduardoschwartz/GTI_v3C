namespace GTI_Desktop.Forms {
    partial class Login {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.btGravar = new System.Windows.Forms.ToolStripButton();
            this.btCancelar = new System.Windows.Forms.ToolStripButton();
            this.txtPwd2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPwd1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LoginToolStrip = new System.Windows.Forms.ToolStrip();
            this.SairButton = new System.Windows.Forms.ToolStripButton();
            this.SenhaButton = new System.Windows.Forms.ToolStripButton();
            this.LoginButton = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.LoginToolStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Linen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tBar);
            this.panel1.Controls.Add(this.txtPwd2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPwd1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(7, 226);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 90);
            this.panel1.TabIndex = 70;
            // 
            // tBar
            // 
            this.tBar.AllowMerge = false;
            this.tBar.BackColor = System.Drawing.Color.Linen;
            this.tBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btGravar,
            this.btCancelar});
            this.tBar.Location = new System.Drawing.Point(0, 63);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(232, 25);
            this.tBar.TabIndex = 17;
            this.tBar.Text = "7";
            // 
            // btGravar
            // 
            this.btGravar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btGravar.Image = global::GTI_Desktop.Properties.Resources.gravar;
            this.btGravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(23, 22);
            this.btGravar.Text = "btGravar";
            this.btGravar.ToolTipText = "Gravar os dados";
            this.btGravar.Click += new System.EventHandler(this.BtGravar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.AccessibleDescription = "Cancelar operação";
            this.btCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCancelar.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.btCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(23, 22);
            this.btCancelar.Text = "btCancelar";
            this.btCancelar.ToolTipText = "Cancelar";
            this.btCancelar.Click += new System.EventHandler(this.BtCancelar_Click);
            // 
            // txtPwd2
            // 
            this.txtPwd2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwd2.Location = new System.Drawing.Point(100, 34);
            this.txtPwd2.MaxLength = 20;
            this.txtPwd2.Name = "txtPwd2";
            this.txtPwd2.PasswordChar = '*';
            this.txtPwd2.Size = new System.Drawing.Size(118, 20);
            this.txtPwd2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Confirmar Senha:";
            // 
            // txtPwd1
            // 
            this.txtPwd1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwd1.Location = new System.Drawing.Point(100, 8);
            this.txtPwd1.MaxLength = 20;
            this.txtPwd1.Name = "txtPwd1";
            this.txtPwd1.PasswordChar = '*';
            this.txtPwd1.Size = new System.Drawing.Size(118, 20);
            this.txtPwd1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nova Senha......:";
            // 
            // txtLogin
            // 
            this.txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogin.Location = new System.Drawing.Point(81, 32);
            this.txtLogin.MaxLength = 20;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(148, 20);
            this.txtLogin.TabIndex = 1;
            // 
            // txtPwd
            // 
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwd.Location = new System.Drawing.Point(81, 58);
            this.txtPwd.MaxLength = 20;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(148, 20);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.Text = "123456";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(8, 32);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(69, 17);
            this.Label1.TabIndex = 67;
            this.Label1.Text = "Usuário..:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(8, 59);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(69, 17);
            this.Label2.TabIndex = 68;
            this.Label2.Text = "Senha....:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(174, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 18);
            this.label5.TabIndex = 71;
            this.label5.Text = "PREFEITURA MUNICIPAL";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(197, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 18);
            this.label6.TabIndex = 72;
            this.label6.Text = "DE JABOTICABAL";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 13);
            this.label7.TabIndex = 74;
            this.label7.Text = "A senha deve ter no mínimo 6 carácteres";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::GTI_Desktop.Properties.Resources.Brasao;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(354, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 63);
            this.pictureBox2.TabIndex = 73;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Linen;
            this.pictureBox1.BackgroundImage = global::GTI_Desktop.Properties.Resources.GTI_logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 7);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 176);
            this.pictureBox1.TabIndex = 69;
            this.pictureBox1.TabStop = false;
            // 
            // txtServer
            // 
            this.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServer.Location = new System.Drawing.Point(81, 6);
            this.txtServer.MaxLength = 20;
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(148, 20);
            this.txtServer.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 76;
            this.label8.Text = "Servidor.:";
            // 
            // LoginToolStrip
            // 
            this.LoginToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.LoginToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LoginToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.LoginToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SairButton,
            this.SenhaButton,
            this.LoginButton});
            this.LoginToolStrip.Location = new System.Drawing.Point(0, 82);
            this.LoginToolStrip.Name = "LoginToolStrip";
            this.LoginToolStrip.Size = new System.Drawing.Size(231, 25);
            this.LoginToolStrip.TabIndex = 77;
            this.LoginToolStrip.Text = "toolStrip1";
            // 
            // SairButton
            // 
            this.SairButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SairButton.AutoSize = false;
            this.SairButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.SairButton.ForeColor = System.Drawing.Color.Navy;
            this.SairButton.Image = global::GTI_Desktop.Properties.Resources.Exit;
            this.SairButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SairButton.Name = "SairButton";
            this.SairButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.SairButton.Size = new System.Drawing.Size(63, 22);
            this.SairButton.Text = "Sair";
            this.SairButton.ToolTipText = "Trocar a senha";
            this.SairButton.Click += new System.EventHandler(this.SairButton_Click);
            // 
            // SenhaButton
            // 
            this.SenhaButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SenhaButton.AutoSize = false;
            this.SenhaButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.SenhaButton.ForeColor = System.Drawing.Color.Navy;
            this.SenhaButton.Image = global::GTI_Desktop.Properties.Resources.download;
            this.SenhaButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SenhaButton.Name = "SenhaButton";
            this.SenhaButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.SenhaButton.Size = new System.Drawing.Size(63, 22);
            this.SenhaButton.Text = "Senha";
            this.SenhaButton.ToolTipText = "Trocar a senha";
            this.SenhaButton.Click += new System.EventHandler(this.SenhaButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LoginButton.AutoSize = false;
            this.LoginButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LoginButton.ForeColor = System.Drawing.Color.Navy;
            this.LoginButton.Image = global::GTI_Desktop.Properties.Resources.OK;
            this.LoginButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.LoginButton.Size = new System.Drawing.Size(63, 22);
            this.LoginButton.Text = "Entrar";
            this.LoginButton.ToolTipText = "Acessar o sistema";
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtServer);
            this.panel2.Controls.Add(this.LoginToolStrip);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtLogin);
            this.panel2.Controls.Add(this.txtPwd);
            this.panel2.Controls.Add(this.Label1);
            this.panel2.Controls.Add(this.Label2);
            this.panel2.Location = new System.Drawing.Point(194, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 107);
            this.panel2.TabIndex = 78;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(433, 194);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Activated += new System.EventHandler(this.Login_Activated);
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.LoginToolStrip.ResumeLayout(false);
            this.LoginToolStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton btGravar;
        private System.Windows.Forms.ToolStripButton btCancelar;
        internal System.Windows.Forms.TextBox txtPwd2;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtPwd1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.TextBox txtLogin;
        internal System.Windows.Forms.TextBox txtPwd;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.TextBox txtServer;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStrip LoginToolStrip;
        private System.Windows.Forms.ToolStripButton LoginButton;
        private System.Windows.Forms.ToolStripButton SenhaButton;
        private System.Windows.Forms.ToolStripButton SairButton;
        private System.Windows.Forms.Panel panel2;
    }
}