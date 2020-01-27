namespace GTI_Desktop.Forms {
    partial class SecurityUserForm {
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
            this.a1Panel1 = new Owf.Controls.A1Panel();
            this.GravarButton = new System.Windows.Forms.Button();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.UsuarioComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MainTreeView = new System.Windows.Forms.TreeView();
            this.a1Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // a1Panel1
            // 
            this.a1Panel1.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel1.Controls.Add(this.GravarButton);
            this.a1Panel1.Controls.Add(this.LoginLabel);
            this.a1Panel1.Controls.Add(this.UsuarioComboBox);
            this.a1Panel1.Controls.Add(this.label2);
            this.a1Panel1.Controls.Add(this.label1);
            this.a1Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.a1Panel1.GradientEndColor = System.Drawing.SystemColors.Control;
            this.a1Panel1.GradientStartColor = System.Drawing.SystemColors.Control;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(0, 0);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.ShadowOffSet = 3;
            this.a1Panel1.Size = new System.Drawing.Size(433, 60);
            this.a1Panel1.TabIndex = 0;
            // 
            // GravarButton
            // 
            this.GravarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GravarButton.Image = global::GTI_Desktop.Properties.Resources.gravar;
            this.GravarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GravarButton.Location = new System.Drawing.Point(347, 30);
            this.GravarButton.Name = "GravarButton";
            this.GravarButton.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.GravarButton.Size = new System.Drawing.Size(74, 24);
            this.GravarButton.TabIndex = 156;
            this.GravarButton.Text = "&Gravar ";
            this.GravarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GravarButton.UseVisualStyleBackColor = true;
            this.GravarButton.Click += new System.EventHandler(this.GravarButton_Click);
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.ForeColor = System.Drawing.Color.Navy;
            this.LoginLabel.Location = new System.Drawing.Point(72, 35);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(0, 13);
            this.LoginLabel.TabIndex = 3;
            // 
            // UsuarioComboBox
            // 
            this.UsuarioComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsuarioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UsuarioComboBox.DropDownWidth = 342;
            this.UsuarioComboBox.FormattingEnabled = true;
            this.UsuarioComboBox.Location = new System.Drawing.Point(69, 7);
            this.UsuarioComboBox.Name = "UsuarioComboBox";
            this.UsuarioComboBox.Size = new System.Drawing.Size(352, 21);
            this.UsuarioComboBox.TabIndex = 2;
            this.UsuarioComboBox.SelectedIndexChanged += new System.EventHandler(this.UsuarioComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Login.....:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuário..:";
            // 
            // MainTreeView
            // 
            this.MainTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTreeView.CheckBoxes = true;
            this.MainTreeView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainTreeView.FullRowSelect = true;
            this.MainTreeView.Location = new System.Drawing.Point(1, 60);
            this.MainTreeView.Name = "MainTreeView";
            this.MainTreeView.ShowNodeToolTips = true;
            this.MainTreeView.Size = new System.Drawing.Size(429, 424);
            this.MainTreeView.TabIndex = 1;
            this.MainTreeView.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.MainTreeView_BeforeCheck);
            // 
            // SecurityUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 485);
            this.Controls.Add(this.MainTreeView);
            this.Controls.Add(this.a1Panel1);
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(449, 524);
            this.Name = "SecurityUserForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atribuição de acesso ao sistema por usuário";
            this.a1Panel1.ResumeLayout(false);
            this.a1Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Owf.Controls.A1Panel a1Panel1;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.ComboBox UsuarioComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView MainTreeView;
        private System.Windows.Forms.Button GravarButton;
    }
}