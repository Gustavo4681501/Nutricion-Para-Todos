using System;
using System.Windows.Forms;
using NutricionApp.Controllers;

namespace NutricionApp.Views
{
    /// <summary>
    /// Represents a welcome form that greets the user upon login and provides access to the main sections.
    /// </summary>
    public partial class FrmBienvenida : Form
    {
        private readonly AlimentoController _alimentoController;
        private readonly MenuController _menuController;
        private readonly PerfilController _perfilController;
        private readonly string _userName;

        /// <summary>
        /// Initializes a new instance of the FrmBienvenida form, displaying a personalized welcome message and
        /// configuring controllers for food, menu, and user profile management.
        /// </summary>
        /// <remarks>Ensure that all controller parameters are properly instantiated before passing them
        /// to this constructor. The welcome label will display the provided user name upon initialization.</remarks>
        /// <param name="userName">The name of the user to be displayed in the welcome message. Cannot be null.</param>
        /// <param name="alimentoController">An instance of AlimentoController used to manage food-related operations within the form. Cannot be null.</param>
        /// <param name="menuController">An instance of MenuController that provides menu management functionality for the form. Cannot be null.</param>
        /// <param name="perfilController">An instance of PerfilController responsible for handling user profile operations. Cannot be null.</param>
        public FrmBienvenida(string userName, AlimentoController alimentoController,
            MenuController menuController, PerfilController perfilController)
        {
            InitializeComponent();
            _userName = userName;
            _alimentoController = alimentoController;
            _menuController = menuController;
            _perfilController = perfilController;
            lblBienvenida.Text = string.Format("Bienvenido, {0}!", userName);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenus_Click(object sender, EventArgs e)
        {
            var frm = new FrmMenus(_userName, _menuController, _alimentoController);
            frm.ShowDialog();
        }

        private void btnAlimentos_Click(object sender, EventArgs e)
        {
            var frm = new FrmAlimentos(_alimentoController);
            frm.ShowDialog();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            var frm = new FrmPerfil(_userName, _perfilController);
            frm.ShowDialog();
        }

        private void btnPerfil_Click_1(object sender, EventArgs e)
        {
            var frm = new FrmPerfil(_userName, _perfilController);
            frm.ShowDialog();
        }

 
        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            var frm = new FrmEstadisticas(_userName, _menuController, _perfilController);
            frm.ShowDialog();
        }
    }
}
