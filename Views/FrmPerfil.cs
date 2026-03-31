using System;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Models;

namespace NutricionApp.Views
{
   /// <summary>
   /// 
   /// </summary>
    public partial class FrmPerfil : Form
    {
        private readonly PerfilController _controller;
        private readonly string           _userName;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FrmPerfil"/>.
        /// </summary>
        /// <param name="userName">Nombre del usuario activo.</param>
        /// <param name="controller">Controlador de perfiles.</param>
        public FrmPerfil(string userName, PerfilController controller)
        {
            InitializeComponent();
            _userName   = userName;
            _controller = controller;
            CargarPerfil();
        }

        // Carga el perfil existente (o por defecto) y rellena los controles.
        private void CargarPerfil()
        {
            var p = _controller.ObtenerPerfil(_userName);

            numEdad.Value   = p.Edad;
            numPeso.Value   = (decimal)p.PesoKg;
            numAltura.Value = (decimal)p.AlturaCm;
            cmbObjetivo.SelectedIndex = (int)p.Objetivo;

            ActualizarResultados(p);
        }


        private void ActualizarResultados(Perfil p)
        {
            double cal = p.CaloriasRecomendadas();
            double imc = p.IMC();

            lblCalorias.Text = string.Format("Calorias recomendadas: {0:F0} kcal/dia", cal);
            lblIMC.Text      = string.Format("IMC: {0:F1}  ({1})", imc, ClasificarIMC(imc));
        }

        private string ClasificarIMC(double imc)
        {
            if (imc < 18.5) return "Bajo peso";
            if (imc < 25.0) return "Normal";
            if (imc < 30.0) return "Sobrepeso";
            return "Obesidad";
        }

        /// <summary>
        /// Guarda el perfil con los datos actuales del formulario.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var p = new Perfil(_userName)
            {
                Edad     = (int)numEdad.Value,
                PesoKg   = (double)numPeso.Value,
                AlturaCm = (double)numAltura.Value,
                Objetivo = (ObjetivoNutricional)cmbObjetivo.SelectedIndex
            };

            _controller.GuardarPerfil(p);
            ActualizarResultados(p);

            MessageBox.Show(
                "Perfil guardado correctamente.",
                "Exito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
