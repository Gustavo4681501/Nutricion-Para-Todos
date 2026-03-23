using System;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Models;

namespace NutricionApp.Views
{
    /// <summary>
    /// Represents a form that allows users to add a new food item to the catalog with validated nutritional
    /// information.
    /// </summary>
    /// <remarks>This form ensures that all required fields are completed and that numeric values are valid
    /// before submitting the new food item to the catalog via the provided AlimentoController. It is intended for use
    /// in applications that manage or track nutritional data, and provides user feedback for validation errors or
    /// successful additions.</remarks>
    public partial class FrmAgregarAlimento : Form
    {
        private readonly AlimentoController _controller;

        /// <summary>
        /// Initializes a new instance of the FrmAgregarAlimento class using the specified AlimentoController to manage
        /// food-related operations.
        /// </summary>
        /// <param name="controller">The AlimentoController instance responsible for handling food data and operations. Cannot be null.</param>
        public FrmAgregarAlimento(AlimentoController controller)
        {
            InitializeComponent();
            _controller = controller;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "El nombre del alimento es obligatorio.",
                    "Validacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            double calorias, proteinas, carbohidratos, grasas, porcion;

            var cultura = System.Globalization.CultureInfo.InvariantCulture;

            if (!double.TryParse(txtCalorias.Text, System.Globalization.NumberStyles.Any, cultura, out calorias) ||
                !double.TryParse(txtProteinas.Text, System.Globalization.NumberStyles.Any, cultura, out proteinas) ||
                !double.TryParse(txtCarbohidratos.Text, System.Globalization.NumberStyles.Any, cultura, out carbohidratos) ||
                !double.TryParse(txtGrasas.Text, System.Globalization.NumberStyles.Any, cultura, out grasas) ||
                !double.TryParse(txtPorcion.Text, System.Globalization.NumberStyles.Any, cultura, out porcion))
            {
                MessageBox.Show(
                    "Todos los valores numericos deben ser validos.",
                    "Validacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var alimento = new Alimento(
                txtNombre.Text.Trim(),
                calorias,
                proteinas,
                carbohidratos,
                grasas,
                porcion);

            _controller.Agregar(alimento);

            MessageBox.Show(
                string.Format("Alimento '{0}' agregado correctamente.", alimento.Nombre),
                "Exito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }

        /// <summary>
        /// Cierra el formulario sin guardar.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}