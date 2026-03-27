using System;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Models;

namespace NutricionApp.Views
{
    /// <summary>
    /// Represents a form that allows users to create and manage a menu by selecting foods, specifying quantities, and
    /// saving the menu for a given date.
    /// </summary>
    /// <remarks>This form provides functionality to add or remove food items, calculate total calories, and
    /// persist the menu using the provided controllers. It is intended for use in applications where users need to
    /// assemble and store daily menus. The form requires valid controllers for menu and food management to function
    /// correctly.</remarks>
    public partial class FrmCrearMenu : Form
    {
        private readonly string             _userName;
        private readonly MenuController     _menuController;
        private readonly AlimentoController _alimentoController;
        private readonly Menu               _menu;

        /// <summary>
        /// Initializes a new instance of the FrmCrearMenu form for creating a menu associated with the specified user.
        /// </summary>
        /// <param name="userName">The name of the user for whom the menu is being created. Cannot be null or empty.</param>
        /// <param name="menuController">The controller used to manage menu-related operations. Cannot be null.</param>
        /// <param name="alimentoController">The controller used to manage food item operations. Cannot be null.</param>
        public FrmCrearMenu(string userName, MenuController menuController, AlimentoController alimentoController)
        {
            InitializeComponent();
            _userName           = userName;
            _menuController     = menuController;
            _alimentoController = alimentoController;
            _menu               = new Menu(userName, DateTime.Today);

            CargarAlimentos();
            dtpFecha.Value = DateTime.Today;
        }

        
        private void CargarAlimentos()
        {
            cmbAlimento.Items.Clear();

            foreach (var a in _alimentoController.ObtenerTodos())
                cmbAlimento.Items.Add(a);

            if (cmbAlimento.Items.Count > 0)
                cmbAlimento.SelectedIndex = 0;
        }

       
        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            if (cmbAlimento.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un alimento.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double gramos;
            var cultura = System.Globalization.CultureInfo.InvariantCulture;

            if (!double.TryParse(txtGramos.Text,
                System.Globalization.NumberStyles.Any, cultura, out gramos) || gramos <= 0)
            {
                MessageBox.Show("Ingresa una cantidad valida en gramos.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var alimento = (Alimento)cmbAlimento.SelectedItem;

      
            double calorias = (alimento.Calorias / alimento.Porcion) * gramos;

            var item = new ItemMenu(alimento.Nombre, gramos, calorias);
            _menu.Items.Add(item);

            dgvItems.Rows.Add(
                alimento.Nombre,
                string.Format("{0} g", gramos),
                string.Format("{0:F1} kcal", calorias));

            ActualizarTotal();
            txtGramos.Text = "100";
        }

      
        private void btnQuitarItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0)
                return;

            int indice = dgvItems.SelectedRows[0].Index;
            _menu.Items.RemoveAt(indice);
            dgvItems.Rows.RemoveAt(indice);
            ActualizarTotal();
        }

       
        private void ActualizarTotal()
        {
            lblTotal.Text = string.Format("Total: {0:F1} kcal", _menu.TotalCalorias());
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_menu.Items.Count == 0)
            {
                MessageBox.Show(
                    "Agrega al menos un alimento al menu.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _menu.Fecha = dtpFecha.Value.Date;
            _menuController.Guardar(_menu);

            MessageBox.Show(
                string.Format("Menu del {0} guardado correctamente.", _menu.Fecha.ToString("dd/MM/yyyy")),
                "Exito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
