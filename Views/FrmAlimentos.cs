using System;
using System.Windows.Forms;
using NutricionApp.Controllers;

namespace NutricionApp.Views
{
    /// <summary>
    /// Represents a form for managing food items in the application, allowing users to add, remove, and view
    /// nutritional information.
    /// </summary>
    /// <remarks>This form interacts with an instance of <see cref="AlimentoController"/> to retrieve and
    /// manipulate food data. It initializes the food table upon creation and updates the display after adding or
    /// removing items.</remarks>
    public partial class FrmAlimentos : Form
    {
        private readonly AlimentoController _controller;

        /// <summary>
        /// Initializes a new instance of the FrmAlimentos class using the specified AlimentoController to manage food
        /// item data.
        /// </summary>
        /// <remarks>This constructor sets up the form's components and loads the initial data into the
        /// table using the provided controller.</remarks>
        /// <param name="controller">The controller responsible for managing and providing access to food item data displayed in the form. Cannot
        /// be null.</param>
        public FrmAlimentos(AlimentoController controller)
        {
            InitializeComponent();
            _controller = controller;
            CargarTabla();
        }


        private void CargarTabla()
        {
            dgvAlimentos.Rows.Clear();

            foreach (var a in _controller.ObtenerTodos())
            {
                dgvAlimentos.Rows.Add(
                    a.Nombre,
                    a.Calorias,
                    a.Proteinas,
                    a.Carbohidratos,
                    a.Grasas,
                    a.Porcion + " g");
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new FrmAgregarAlimento(_controller);
            frm.FormClosed += (s, args) => CargarTabla();
            frm.ShowDialog();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAlimentos.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Selecciona un alimento para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int indice = dgvAlimentos.SelectedRows[0].Index;

            var confirmar = MessageBox.Show(
                "Seguro que deseas eliminar este alimento?",
                "Confirmar eliminacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                _controller.Eliminar(indice);
                CargarTabla();
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAlimentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
