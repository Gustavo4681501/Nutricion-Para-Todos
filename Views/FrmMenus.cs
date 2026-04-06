using System;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Models;

namespace NutricionApp.Views
{
    /// <summary>
    /// Represents a form that allows users to view, create, and delete daily menus associated with their account.
    /// </summary>
    /// <remarks>This form interacts with the menu and food controllers to manage menu data for the active
    /// user. Menus are displayed in a DataGridView, and users can add new menus or remove existing ones. The form
    /// requires a valid username and controller instances to function correctly.</remarks>
    public partial class FrmMenus : Form
    {
        private readonly MenuController    _menuController;
        private readonly AlimentoController _alimentoController;
        private readonly string            _userName;

       /// <summary>
       /// Initializes a new instance of the FrmMenus form, allowing menu and food data to be managed and displayed
       /// according to the specified user and controllers.
       /// </summary>
       /// <remarks>This constructor sets up the form's components and loads the menu data using the
       /// provided controllers. Ensure that both controllers are properly initialized before passing them to this
       /// constructor.</remarks>
       /// <param name="userName">The name of the user for whom the menu interface is being customized. This value is used to personalize the
       /// menu display and interactions.</param>
       /// <param name="menuController">An instance of MenuController that provides access to menu-related operations and data management.</param>
       /// <param name="alimentoController">An instance of AlimentoController that supplies food-related data and operations for the form.</param>
        public FrmMenus(string userName, MenuController menuController, AlimentoController alimentoController)
        {
            InitializeComponent();
            _userName           = userName;
            _menuController     = menuController;
            _alimentoController = alimentoController;
            CargarTabla();
        }

        
        private void CargarTabla()
        {
            dgvMenus.Rows.Clear();

            foreach (var m in _menuController.ObtenerPorUsuario(_userName))
            {
                dgvMenus.Rows.Add(
                    m.Fecha.ToString("dd/MM/yyyy"),
                    m.Items.Count,
                    string.Format("{0:F1} kcal", m.TotalCalorias()));
            }
        }

       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new FrmCrearMenu(_userName, _menuController, _alimentoController);
            frm.FormClosed += (s, args) => CargarTabla();
            frm.ShowDialog();
        }

       
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMenus.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Selecciona un menu para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show(
                "Seguro que deseas eliminar este menu?",
                "Confirmar eliminacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                _menuController.Eliminar(_userName, dgvMenus.SelectedRows[0].Index);
                CargarTabla();
            }
        }

       
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
