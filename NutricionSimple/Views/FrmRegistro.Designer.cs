namespace NutricionApp.Views
{
    partial class FrmRegistro
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUser             = new System.Windows.Forms.Label();
            this.txtUser             = new System.Windows.Forms.TextBox();
            this.lblPassword         = new System.Windows.Forms.Label();
            this.txtPassword         = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword  = new System.Windows.Forms.Label();
            this.txtConfirmPassword  = new System.Windows.Forms.TextBox();
            this.btnRegistrar        = new System.Windows.Forms.Button();
            this.btnCancelar         = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(45, 30);
            this.lblUser.Name     = "lblUser";
            this.lblUser.TabIndex = 0;
            this.lblUser.Text     = "Usuario";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(200, 27);
            this.txtUser.Name     = "txtUser";
            this.txtUser.Size     = new System.Drawing.Size(253, 20);
            this.txtUser.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(45, 70);
            this.lblPassword.Name     = "lblPassword";
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text     = "Contrasena";
            // 
            // txtPassword
            // 
            this.txtPassword.Location     = new System.Drawing.Point(200, 67);
            this.txtPassword.Name         = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size         = new System.Drawing.Size(253, 20);
            this.txtPassword.TabIndex     = 3;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(45, 110);
            this.lblConfirmPassword.Name     = "lblConfirmPassword";
            this.lblConfirmPassword.TabIndex = 4;
            this.lblConfirmPassword.Text     = "Confirmar contrasena";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location     = new System.Drawing.Point(200, 107);
            this.txtConfirmPassword.Name         = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size         = new System.Drawing.Size(253, 20);
            this.txtConfirmPassword.TabIndex     = 5;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(130, 155);
            this.btnRegistrar.Name     = "btnRegistrar";
            this.btnRegistrar.Size     = new System.Drawing.Size(140, 35);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text     = "Registrarse";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click   += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(285, 155);
            this.btnCancelar.Name     = "btnCancelar";
            this.btnCancelar.Size     = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text     = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click   += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmRegistro
            // 
            this.AcceptButton        = this.btnRegistrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(500, 215);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.Name            = "FrmRegistro";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Registrarse";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label   lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label   lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label   lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button  btnRegistrar;
        private System.Windows.Forms.Button  btnCancelar;
    }
}
