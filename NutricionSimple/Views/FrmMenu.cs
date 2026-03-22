using System;
using System.Linq;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Data;
using NutricionApp.Models;
using ModelMenu = NutricionApp.Models.Menu;

namespace NutricionApp.Views
{
    public partial class FrmMenu : Form
    {
        private ModelMenu _menu;
        private readonly bool _esNuevo;
        private readonly MenuController     _mCtrl = new MenuController();
        private readonly AlimentoController _aCtrl = new AlimentoController();

        public FrmMenu(ModelMenu menu)
        {
            _esNuevo = (menu == null);
            _menu    = menu != null ? Clonar(menu) : new ModelMenu();
            InitializeComponent();
            this.Text = _esNuevo ? "Nuevo menu" : "Editar menu";
            cmbAlimento.DataSource    = _aCtrl.ObtenerTodos();
            cmbAlimento.DisplayMember = "Nombre";
            cmbAlimento.ValueMember   = "Id";
            if (!_esNuevo) { dtpFecha.Value = _menu.Fecha; RefrescarGrid(); }
        }

        private ModelMenu Clonar(ModelMenu o)
        {
            var c = new ModelMenu(o.Id, o.UsuarioId, o.Fecha);
            c.Items.AddRange(o.Items.Select(i => new ItemMenu {
                AlimentoId=i.AlimentoId, NombreAlimento=i.NombreAlimento,
                CantidadGramos=i.CantidadGramos, TiempoComida=i.TiempoComida,
                Calorias=i.Calorias, Proteinas=i.Proteinas,
                Carbohidratos=i.Carbohidratos, Grasas=i.Grasas }));
            return c;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbAlimento.SelectedItem == null) return;
            var a = (Alimento)cmbAlimento.SelectedItem;
            var t = (TiempoComida)cmbTiempo.SelectedIndex;
            _menu.Items.Add(new ItemMenu(a, (double)numCantidad.Value, t));
            RefrescarGrid();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0) return;
            _menu.Items.RemoveAt(dgvItems.SelectedRows[0].Index);
            RefrescarGrid();
        }

        private void RefrescarGrid()
        {
            dgvItems.Rows.Clear();
            foreach (var i in _menu.Items)
                dgvItems.Rows.Add(i.NombreAlimento, i.TiempoComida.ToString(),
                    string.Format("{0:F0}g", i.CantidadGramos),
                    string.Format("{0:F0}", i.Calorias),
                    string.Format("{0:F1}", i.Proteinas),
                    string.Format("{0:F1}", i.Carbohidratos),
                    string.Format("{0:F1}", i.Grasas));
            lblTotales.Text = string.Format(
                "Total: {0:F0} kcal  |  Prot: {1:F1}g  |  Carbs: {2:F1}g  |  Grasas: {3:F1}g",
                _menu.TotalCalorias, _menu.TotalProteinas,
                _menu.TotalCarbohidratos, _menu.TotalGrasas);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_menu.Items.Count == 0) { MessageBox.Show("Agrega al menos un alimento."); return; }
            _menu.Fecha     = dtpFecha.Value.Date;
            _menu.UsuarioId = NutricionContext.Instancia.UsuarioActivo.Id;
            try
            {
                if (_esNuevo) _mCtrl.AgregarMenu(_menu);
                else          _mCtrl.ActualizarMenu(_menu);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        { this.DialogResult = DialogResult.Cancel; this.Close(); }
    }
}
