using System;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Models;

namespace NutricionApp.Views
{
    /// <summary>
    /// Form for creating a daily menu. Allows the user to select foods, enter quantities,
    /// and saves the menu including full macronutrient data (calories, proteins, carbs, fats).
    /// </summary>
    public partial class FrmCrearMenu : Form
    {
        private readonly string _userName;
        private readonly MenuController _menuController;
        private readonly AlimentoController _alimentoController;
        private readonly Menu _menu;

        /// <summary>
        /// Initializes a new instance of FrmCrearMenu for the specified user.
        /// </summary>
        public FrmCrearMenu(string userName, MenuController menuController, AlimentoController alimentoController)
        {
            InitializeComponent();
            _userName = userName;
            _menuController = menuController;
            _alimentoController = alimentoController;
            _menu = new Menu(userName, DateTime.Today);

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

            double factor = gramos / alimento.Porcion;
            double calorias = alimento.Calorias * factor;
            double proteinas = alimento.Proteinas * factor;
            double carbohidratos = alimento.Carbohidratos * factor;
            double grasas = alimento.Grasas * factor;

            var item = new ItemMenu(alimento.Nombre, gramos, calorias, proteinas, carbohidratos, grasas);
            _menu.Items.Add(item);

            dgvItems.Rows.Add(
                alimento.Nombre,
                string.Format("{0} g", gramos),
                string.Format("{0:F1} kcal", calorias),
                string.Format("{0:F1}g", proteinas),
                string.Format("{0:F1}g", carbohidratos),
                string.Format("{0:F1}g", grasas));

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
            lblTotal.Text = string.Format(
                "Total: {0:F1} kcal  |  Prot: {1:F1}g  |  Carb: {2:F1}g  |  Grasas: {3:F1}g",
                _menu.TotalCalorias(),
                _menu.TotalProteinas(),
                _menu.TotalCarbohidratos(),
                _menu.TotalGrasas());
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
