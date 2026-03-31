using System;
using System.Windows.Forms;
using NutricionApp.Controllers;

namespace NutricionApp.Views
{
    /// <summary>
    /// Represents the login form for user authentication within the application.
    /// </summary>
    /// <remarks>This form provides the user interface for entering credentials and initiating the login
    /// process. Upon successful authentication, it transitions to the main application interface. The form requires
    /// controllers for login, food management, and menu management to function correctly.</remarks>
    public partial class FrmLogin : Form
    {
        private readonly LoginController _loginController;
        private readonly AlimentoController _alimentoController;
        private readonly MenuController _menuController;
        private readonly PerfilController _perfilController;

        private string UserName => txtUser.Text;
        private string Password => txtPassword.Text;

        /// <summary>
        /// Initializes a new instance of the FrmLogin form with the specified controllers.
        /// </summary>
        /// <param name="loginController">The controller responsible for handling user authentication and login operations. Cannot be null.</param>
        /// <param name="alimentoController">The controller used to manage food-related data and operations. Cannot be null.</param>
        /// <param name="menuController">The controller that manages menu-related functionality within the application. Cannot be null.</param>
        public FrmLogin(LoginController loginController, AlimentoController alimentoController,
            MenuController menuController, PerfilController perfilController)
        {
            InitializeComponent();
            _loginController = loginController;
            _alimentoController = alimentoController;
            _menuController = menuController;
            _perfilController = perfilController;
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
                var bienvenida = new FrmBienvenida(UserName, _alimentoController,
                    _menuController, _perfilController);
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
