namespace GTI_Desktop.User_Controls {
    partial class ctlDataEditor {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cmdSair = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.MonthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // cmdSair
            // 
            this.cmdSair.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdSair.Image = global::GTI_Desktop.Properties.Resources.cancelar;
            this.cmdSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSair.Location = new System.Drawing.Point(63, 165);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(82, 22);
            this.cmdSair.TabIndex = 14;
            this.cmdSair.Text = "    &Sem Data";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Image = global::GTI_Desktop.Properties.Resources.OK;
            this.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOK.Location = new System.Drawing.Point(3, 165);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(54, 22);
            this.cmdOK.TabIndex = 13;
            this.cmdOK.Text = "    &OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // MonthCalendar1
            // 
            this.MonthCalendar1.BackColor = System.Drawing.Color.White;
            this.MonthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
            this.MonthCalendar1.Location = new System.Drawing.Point(1, 0);
            this.MonthCalendar1.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.MonthCalendar1.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.MonthCalendar1.Name = "MonthCalendar1";
            this.MonthCalendar1.TabIndex = 12;
            this.MonthCalendar1.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.MonthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar1_DateChanged);
            this.MonthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar1_DateSelected);
            // 
            // ctlDataEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.MonthCalendar1);
            this.Name = "ctlDataEditor";
            this.Size = new System.Drawing.Size(226, 190);
            this.Load += new System.EventHandler(this.ctlDataEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button cmdSair;
        internal System.Windows.Forms.Button cmdOK;
        internal System.Windows.Forms.MonthCalendar MonthCalendar1;
    }
}
