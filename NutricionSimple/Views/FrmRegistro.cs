using System;
using System.Windows.Forms;
using NutricionApp.Controllers;

namespace NutricionApp.Views
{
    public partial class FrmRegistro : Form
    {
        private readonly LoginController _loginCtrl;

        private string UserName        => txtUser.Text;
        private string Password        => txtPassword.Text;
        private string ConfirmPassword => txtConfirmPassword.Text;

        public FrmRegistro(LoginController loginCtrl)
        {
            InitializeComponent();
            _loginCtrl = loginCtrl;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show(
                    "Usuario y contrasena son obligatorios.",
                    "Error de validacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (Password != ConfirmPassword)
            {
                MessageBox.Show(
                    "Las contrasenas no coinciden.",
                    "Error de validacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var ok = _loginCtrl.Register(UserName, Password);

            if (ok)
            {
                MessageBox.Show(
                    string.Format("Usuario '{0}' registrado correctamente.\nYa puedes iniciar sesion.", UserName),
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    string.Format("El usuario '{0}' ya existe. Elige otro nombre.", UserName),
                    "Registro fallido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
