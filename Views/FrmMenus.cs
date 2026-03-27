using System;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Models;

namespace NutricionApp.Views
{
    /// <summary>
    /// Formulario que muestra los menus diarios del usuario autenticado.
    /// Permite agregar y eliminar menus.
    /// </summary>
    public partial class FrmMenus : Form
    {
        private readonly MenuController    _menuController;
        private readonly AlimentoController _alimentoController;
        private readonly string            _userName;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FrmMenus"/>.
        /// </summary>
        /// <param name="userName">Nombre del usuario activo.</param>
        /// <param name="menuController">Controlador de menus.</param>
        /// <param name="alimentoController">Controlador de alimentos, necesario para crear menus nuevos.</param>
        public FrmMenus(string userName, MenuController menuController, AlimentoController alimentoController)
        {
            InitializeComponent();
            _userName           = userName;
            _menuController     = menuController;
            _alimentoController = alimentoController;
            CargarTabla();
        }

        /// <summary>
        /// Carga los menus del usuario en el DataGridView.
        /// </summary>
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

        /// <summary>
        /// Abre el formulario para crear un nuevo menu diario.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new FrmCrearMenu(_userName, _menuController, _alimentoController);
            frm.FormClosed += (s, args) => CargarTabla();
            frm.ShowDialog();
        }

        /// <summary>
        /// Elimina el menu seleccionado.
        /// </summary>
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

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
