using System;
using System.Windows.Forms;

namespace NutricionApp.Views
{
    /// <summary>
    /// Represents a welcome form that greets the user upon successful login and provides navigation options to other
    /// sections of the application.
    /// </summary>
    /// <remarks>This form displays a personalized welcome message and allows the user to access different
    /// parts of the application or exit. Closing this form will terminate the application session.</remarks>
    public partial class FrmBienvenida : Form
    {
        /// <summary>
        /// Initializes a new instance of the FrmBienvenida class and displays a personalized welcome message for the
        /// specified user.
        /// </summary>
        /// <remarks>This constructor sets up the form's components before displaying the welcome message.
        /// The welcome message is personalized using the provided user name.</remarks>
        /// <param name="userName">The name of the user to be included in the welcome message. Cannot be null.</param>
        public FrmBienvenida(string userName)
        {
            InitializeComponent();
            lblBienvenida.Text = string.Format("Bienvenido!", userName);
        }

        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenus_Click(object sender, EventArgs e)
        {

        }

        private void btnAlimentos_Click(object sender, EventArgs e)
        {

        }
    }
}
