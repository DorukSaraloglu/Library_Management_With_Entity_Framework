namespace LibraryManagement
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxLogin = new System.Windows.Forms.GroupBox();
            this.btnLoginLogin = new System.Windows.Forms.Button();
            this.tbxLoginPassword = new System.Windows.Forms.TextBox();
            this.tbxLoginUserName = new System.Windows.Forms.TextBox();
            this.lblLoginPassword = new System.Windows.Forms.Label();
            this.lblLoginUserName = new System.Windows.Forms.Label();
            this.gbxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxLogin
            // 
            this.gbxLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbxLogin.Controls.Add(this.btnLoginLogin);
            this.gbxLogin.Controls.Add(this.tbxLoginPassword);
            this.gbxLogin.Controls.Add(this.tbxLoginUserName);
            this.gbxLogin.Controls.Add(this.lblLoginPassword);
            this.gbxLogin.Controls.Add(this.lblLoginUserName);
            this.gbxLogin.Location = new System.Drawing.Point(12, 12);
            this.gbxLogin.Name = "gbxLogin";
            this.gbxLogin.Size = new System.Drawing.Size(301, 249);
            this.gbxLogin.TabIndex = 0;
            this.gbxLogin.TabStop = false;
            // 
            // btnLoginLogin
            // 
            this.btnLoginLogin.Location = new System.Drawing.Point(26, 171);
            this.btnLoginLogin.Name = "btnLoginLogin";
            this.btnLoginLogin.Size = new System.Drawing.Size(244, 48);
            this.btnLoginLogin.TabIndex = 4;
            this.btnLoginLogin.Text = "Login";
            this.btnLoginLogin.UseVisualStyleBackColor = true;
            this.btnLoginLogin.Click += new System.EventHandler(this.btnLoginLogin_Click);
            // 
            // tbxLoginPassword
            // 
            this.tbxLoginPassword.Location = new System.Drawing.Point(126, 98);
            this.tbxLoginPassword.Name = "tbxLoginPassword";
            this.tbxLoginPassword.PasswordChar = '*';
            this.tbxLoginPassword.Size = new System.Drawing.Size(144, 22);
            this.tbxLoginPassword.TabIndex = 3;
            // 
            // tbxLoginUserName
            // 
            this.tbxLoginUserName.Location = new System.Drawing.Point(126, 42);
            this.tbxLoginUserName.Name = "tbxLoginUserName";
            this.tbxLoginUserName.Size = new System.Drawing.Size(144, 22);
            this.tbxLoginUserName.TabIndex = 2;
            // 
            // lblLoginPassword
            // 
            this.lblLoginPassword.AutoSize = true;
            this.lblLoginPassword.Location = new System.Drawing.Point(23, 101);
            this.lblLoginPassword.Name = "lblLoginPassword";
            this.lblLoginPassword.Size = new System.Drawing.Size(69, 17);
            this.lblLoginPassword.TabIndex = 1;
            this.lblLoginPassword.Text = "Password";
            // 
            // lblLoginUserName
            // 
            this.lblLoginUserName.AutoSize = true;
            this.lblLoginUserName.Location = new System.Drawing.Point(23, 45);
            this.lblLoginUserName.Name = "lblLoginUserName";
            this.lblLoginUserName.Size = new System.Drawing.Size(79, 17);
            this.lblLoginUserName.TabIndex = 0;
            this.lblLoginUserName.Text = "User Name";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 278);
            this.Controls.Add(this.gbxLogin);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.gbxLogin.ResumeLayout(false);
            this.gbxLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxLogin;
        private System.Windows.Forms.Button btnLoginLogin;
        private System.Windows.Forms.TextBox tbxLoginPassword;
        private System.Windows.Forms.TextBox tbxLoginUserName;
        private System.Windows.Forms.Label lblLoginPassword;
        private System.Windows.Forms.Label lblLoginUserName;
    }
}

