using System;
using System.Windows.Forms;
using NutricionApp.Controllers;

namespace NutricionApp.Views
{
    /// <summary>
    /// Represents a login form that allows users to enter their credentials and access the system.
    /// </summary>
    /// <remarks>This form validates user credentials and provides options for logging in or registering a new
    /// account. It utilizes a <see cref="LoginController"/> to handle authentication logic.</remarks>
    public partial class FrmLogin : Form
    {
        private readonly LoginController _loginController;
        private readonly AlimentoController _alimentoController;
        private string UserName => txtUser.Text;
        private string Password => txtPassword.Text;

        /// <summary>
        /// Initializes a new instance of the FrmLogin class using the specified login controller to manage
        /// authentication operations.
        /// </summary>
        /// <param name="loginController">The LoginController instance responsible for handling user authentication and login logic. Cannot be null.</param>
        public FrmLogin(LoginController loginController, AlimentoController alimentoController)
        {
            InitializeComponent();
            _loginController = loginController;
            _alimentoController = alimentoController;
        }

    
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show(
                    "Ingresa usuario y contrasena.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (_loginController.Login(UserName, Password))
            {
                this.Hide();
                var bienvenida = new FrmBienvenida(UserName, _alimentoController);
                bienvenida.FormClosed += (s, args) => this.Show();
                bienvenida.Show();
            }
            else
            {
                MessageBox.Show(
                    "Usuario o contrasena incorrectos.",
                    "Login fallido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            var frm = new FrmRegistro(_loginController);
            frm.ShowDialog();
        }
    }
}
