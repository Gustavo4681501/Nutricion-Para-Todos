using System;
using System.Windows.Forms;
using NutricionApp.Controllers;

namespace NutricionApp.Views
{
    /// <summary>
    /// Represents a user registration form that allows new users to create an account within the application.
    /// </summary>
    /// <remarks>The registration form validates user input to ensure that the username and password fields
    /// are not empty and that the password and confirmation password match. It interacts with a shared LoginController
    /// instance to register new users and provides feedback to the user regarding the success or failure of the
    /// registration process. This form is typically used in conjunction with the login form to facilitate user
    /// onboarding.</remarks>
    public partial class FrmRegistro : Form
    {
        private readonly LoginController _loginController;

        private string UserName        => txtUser.Text;
        private string Password        => txtPassword.Text;
        private string ConfirmPassword => txtConfirmPassword.Text;

        /// <summary>
        /// Initializes a new instance of the FrmRegistro class using the specified LoginController to manage
        /// authentication and session state.
        /// </summary>
        /// <param name="loginController">The LoginController instance that handles user authentication and session management for the registration
        /// form. Cannot be null.</param>
        public FrmRegistro(LoginController loginController)
        {
            InitializeComponent();
            _loginController = loginController;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show(
                    "El usuario y la contrasena son obligatorios.",
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

            bool ok = _loginController.Register(UserName, Password);

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
