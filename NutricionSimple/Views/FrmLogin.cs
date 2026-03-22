using System;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Data;

namespace NutricionApp.Views
{
    public partial class FrmLogin : Form
    {
        private readonly LoginController _loginCtrl;

        private string UserName => txtUser.Text;
        private string Password => txtPassword.Text;

        public FrmLogin(LoginController loginCtrl)
        {
            InitializeComponent();
            _loginCtrl = loginCtrl;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Ingresa usuario y contrasena.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_loginCtrl.Login(UserName, Password))
            {
                NutricionContext.Instancia.UsuarioActivo = _loginCtrl.ObtenerUsuario(UserName);
                this.Hide();
                var principal = new FrmPrincipal();
                principal.FormClosed += (s, args) => { this.Show(); };
                principal.Show();
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
            var frm = new FrmRegistro(_loginCtrl);
            frm.ShowDialog();
        }
    }
}
