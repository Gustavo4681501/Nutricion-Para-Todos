using System;
using System.Windows.Forms;
using NutricionApp.Controllers;

namespace NutricionApp.Views
{
    /// <summary>
    /// Represents a welcome form that greets the user upon login and provides access to the food catalog.
    /// </summary>
    /// <remarks>This form initializes with the user's name and allows navigation to the food catalog. It is
    /// designed to enhance user experience by providing a friendly welcome message.</remarks>
    public partial class FrmBienvenida : Form
    {
        private readonly AlimentoController _alimentoController;

        /// <summary>
        /// Initializes a new instance of the FrmBienvenida class and displays a personalized welcome message for the
        /// specified user.
        /// </summary>
        /// <remarks>The welcome message label is set to include the provided user name. The
        /// AlimentoController instance is used for subsequent food management actions within the form.</remarks>
        /// <param name="userName">The name of the user to be displayed in the welcome message. Cannot be null.</param>
        /// <param name="alimentoController">An instance of AlimentoController used to manage food-related operations within the form. Cannot be null.</param>
        public FrmBienvenida(string userName, AlimentoController alimentoController)
        {
            InitializeComponent();
            _alimentoController = alimentoController;
            lblBienvenida.Text = string.Format("Bienvenido, {0}!", userName);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenus_Click(object sender, EventArgs e)
        {
            // pendiente de implementar en el siguiente avance
        }

        
        private void btnAlimentos_Click(object sender, EventArgs e)
        {
            var frm = new FrmAlimentos(_alimentoController);
            frm.ShowDialog();
        }
    }
}
