using System;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Models;

namespace NutricionApp.Views
{
    public partial class FrmAlimento : Form
    {
        private readonly Alimento _alimento;
        private readonly bool     _esNuevo;
        private readonly AlimentoController _ctrl = new AlimentoController();

        public FrmAlimento(Alimento a)
        {
            _esNuevo  = (a == null);
            _alimento = a ?? new Alimento();
            InitializeComponent();
            this.Text = _esNuevo ? "Agregar alimento" : "Editar alimento";
            if (!_esNuevo) Precargar();
        }

        private void Precargar()
        {
            txtNombre.Text   = _alimento.Nombre;
            txtCategoria.Text= _alimento.Categoria;
            numCal.Value     = (decimal)_alimento.Calorias;
            numProt.Value    = (decimal)_alimento.Proteinas;
            numCarbs.Value   = (decimal)_alimento.Carbohidratos;
            numGrasas.Value  = (decimal)_alimento.Grasas;
            numPorcion.Value = (decimal)_alimento.PorcionGramos;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            { MessageBox.Show("El nombre es obligatorio."); return; }
            if (_ctrl.ExisteNombre(txtNombre.Text.Trim(), _esNuevo ? -1 : _alimento.Id))
            { MessageBox.Show("Ya existe un alimento con ese nombre."); return; }

            _alimento.Nombre        = txtNombre.Text.Trim();
            _alimento.Categoria     = txtCategoria.Text.Trim();
            _alimento.Calorias      = (double)numCal.Value;
            _alimento.Proteinas     = (double)numProt.Value;
            _alimento.Carbohidratos = (double)numCarbs.Value;
            _alimento.Grasas        = (double)numGrasas.Value;
            _alimento.PorcionGramos = (double)numPorcion.Value;
            try
            {
                if (_esNuevo) _ctrl.AgregarAlimento(_alimento);
                else          _ctrl.ActualizarAlimento(_alimento);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        { this.DialogResult = DialogResult.Cancel; this.Close(); }
    }
}
