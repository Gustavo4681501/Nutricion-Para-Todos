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
        private readonly MenuController     _menuController;
        private readonly string             _userName;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FrmBienvenida"/>.
        /// </summary>
        /// <param name="userName">Nombre del usuario autenticado.</param>
        /// <param name="alimentoController">Controlador del catalogo de alimentos.</param>
        /// <param name="menuController">Controlador de menus diarios.</param>
        public FrmBienvenida(string userName, AlimentoController alimentoController, MenuController menuController)
        {
            InitializeComponent();
            _userName           = userName;
            _alimentoController = alimentoController;
            _menuController     = menuController;
            lblBienvenida.Text  = string.Format("Bienvenido, {0}!", userName);
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
    }
}
