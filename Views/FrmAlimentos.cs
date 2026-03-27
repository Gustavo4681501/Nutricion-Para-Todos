using System;
using System.Windows.Forms;
using NutricionApp.Controllers;

namespace NutricionApp.Views
{
    /// <summary>
    /// Formulario que muestra el catalogo de alimentos disponibles en el sistema.
    /// Permite consultar, agregar y eliminar alimentos.
    /// </summary>
    public partial class FrmAlimentos : Form
    {
        private readonly AlimentoController _controller;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FrmAlimentos"/>.
        /// </summary>
        /// <param name="controller">Controlador del catalogo de alimentos.</param>
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
    }
}
