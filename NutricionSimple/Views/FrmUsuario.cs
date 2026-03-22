using System;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Data;
using NutricionApp.Models;

namespace NutricionApp.Views
{
    public partial class FrmUsuario : Form
    {
        private readonly Usuario _usuario;
        private readonly bool    _esNuevo;
        // SOLID break #3: el controlador se instancia directo aqui en vez de
        // inyectarse. Viola DIP pero es lo mas comun en proyectos de estudiantes.
        private readonly UsuarioController _ctrl = new UsuarioController();

        public FrmUsuario(Usuario u)
        {
            _esNuevo = (u == null);
            _usuario = u ?? new Usuario();
            InitializeComponent();
            this.Text = _esNuevo ? "Nuevo usuario" : "Editar usuario";
            if (!_esNuevo) Precargar();
        }

        private void Precargar()
        {
            txtNombre.Text             = _usuario.Nombre;
            txtPassword.Text           = _usuario.Password;
            numEdad.Value              = _usuario.Edad;
            numPeso.Value              = (decimal)_usuario.Peso;
            numAltura.Value            = (decimal)_usuario.Altura;
            cmbSexo.SelectedIndex      = (int)_usuario.Sexo;
            cmbObjetivo.SelectedIndex  = (int)_usuario.Objetivo;
            cmbActividad.SelectedIndex = (int)_usuario.NivelActividad;
            cmbDieta.SelectedIndex     = (int)_usuario.TipoDieta;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            { MessageBox.Show("El nombre no puede estar vacio."); return; }

            if (_esNuevo && _ctrl.ExisteNombre(txtNombre.Text.Trim()))
            { MessageBox.Show("Ya existe un usuario con ese nombre."); return; }

            _usuario.Nombre         = txtNombre.Text.Trim();
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                _usuario.Password = txtPassword.Text;
            _usuario.Edad           = (int)numEdad.Value;
            _usuario.Peso           = (double)numPeso.Value;
            _usuario.Altura         = (double)numAltura.Value;
            _usuario.Sexo           = (Sexo)cmbSexo.SelectedIndex;
            _usuario.Objetivo       = (ObjetivoUsuario)cmbObjetivo.SelectedIndex;
            _usuario.NivelActividad = (NivelActividad)cmbActividad.SelectedIndex;
            _usuario.TipoDieta      = (TipoDieta)cmbDieta.SelectedIndex;

            try
            {
                if (_esNuevo) _ctrl.AgregarUsuario(_usuario);
                else
                {
                    _ctrl.ActualizarUsuario(_usuario);
                    NutricionContext.Instancia.UsuarioActivo = _usuario;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        { this.DialogResult = DialogResult.Cancel; this.Close(); }
    }
}
