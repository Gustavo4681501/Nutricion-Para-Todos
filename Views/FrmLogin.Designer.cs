namespace NutricionApp.Views
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Releases the resources used by the component, optionally disposing of managed resources.
        /// </summary>
        /// <remarks>This method is called by the public Dispose() method and the finalizer. When
        /// disposing is true, this method releases all resources held by managed objects. When disposing is false, only
        /// unmanaged resources are released. Always call the base class's Dispose method to ensure that all resources
        /// are properly cleaned up.</remarks>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo    = new System.Windows.Forms.Label();
            this.lblUser      = new System.Windows.Forms.Label();
            this.txtUser      = new System.Windows.Forms.TextBox();
            this.lblPassword  = new System.Windows.Forms.Label();
            this.txtPassword  = new System.Windows.Forms.TextBox();
            this.btnLogin     = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font      = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location  = new System.Drawing.Point(50, 20);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Size      = new System.Drawing.Size(400, 30);
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "Nutricion Para Todos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(45, 74);
            this.lblUser.Name     = "lblUser";
            this.lblUser.TabIndex = 1;
            this.lblUser.Text     = "Usuario";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(165, 71);
            this.txtUser.Name     = "txtUser";
            this.txtUser.Size     = new System.Drawing.Size(253, 20);
            this.txtUser.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(45, 110);
            this.lblPassword.Name     = "lblPassword";
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text     = "Contrasena";
            // 
            // txtPassword
            // 
            this.txtPassword.Location     = new System.Drawing.Point(165, 107);
            this.txtPassword.Name         = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size         = new System.Drawing.Size(253, 20);
            this.txtPassword.TabIndex     = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(85, 160);
            this.btnLogin.Name     = "btnLogin";
            this.btnLogin.Size     = new System.Drawing.Size(150, 35);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text     = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(265, 160);
            this.btnRegistrar.Name     = "btnRegistrar";
            this.btnRegistrar.Size     = new System.Drawing.Size(150, 35);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text     = "Registrarse";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton        = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(500, 220);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "FrmLogin";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Nutricion Para Todos";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label   lblTitulo;
        private System.Windows.Forms.Label   lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label   lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button  btnLogin;
        private System.Windows.Forms.Button  btnRegistrar;
    }
}
