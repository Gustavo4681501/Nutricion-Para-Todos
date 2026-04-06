using System;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Models;

namespace NutricionApp.Views
{
    /// <summary>
    /// Represents a form that allows users to view and edit their profile information,
    /// including age, weight, height, nutritional goal, activity level, and diet type.
    /// Also displays calculated results: recommended calories, macro distribution, and BMI.
    /// </summary>
    public partial class FrmPerfil : Form
    {
        private readonly PerfilController _controller;
        private readonly string           _userName;

        /// <summary>
        /// Initializes a new instance of the FrmPerfil class.
        /// </summary>
        /// <param name="userName">The user name associated with the profile.</param>
        /// <param name="controller">The controller responsible for managing profile-related operations.</param>
        public FrmPerfil(string userName, PerfilController controller)
        {
            InitializeComponent();
            _userName   = userName;
            _controller = controller;
            CargarPerfil();
        }

        /// <summary>
        /// Loads the user's profile from the controller and populates all form fields.
        /// </summary>
        private void CargarPerfil()
        {
            var p = _controller.ObtenerPerfil(_userName);

            numEdad.Value             = p.Edad;
            numPeso.Value             = (decimal)p.PesoKg;
            numAltura.Value           = (decimal)p.AlturaCm;
            cmbObjetivo.SelectedIndex = (int)p.Objetivo;
            cmbActividad.SelectedIndex = (int)p.Actividad;
            cmbDieta.SelectedIndex    = (int)p.Dieta;

            ActualizarResultados(p);
        }

        /// <summary>
        /// Updates the results labels (calories, macros, BMI) based on the given profile.
        /// </summary>
        private void ActualizarResultados(Perfil p)
        {
            double cal = p.CaloriasRecomendadas();
            double imc = p.IMC();
            var macros = p.MacrosRecomendados();

            lblCalorias.Text = string.Format("Calorias recomendadas: {0:F0} kcal/dia", cal);
            lblIMC.Text      = string.Format("IMC: {0:F1}  ({1})", imc, ClasificarIMC(imc));
            lblMacros.Text   = string.Format(
                "Macros ({0}):  Proteinas {1:F0}g  |  Carbohidratos {2:F0}g  |  Grasas {3:F0}g",
                p.Dieta, macros.Proteinas, macros.Carbohidratos, macros.Grasas);
        }

        private string ClasificarIMC(double imc)
        {
            if (imc < 18.5) return "Bajo peso";
            if (imc < 25.0) return "Normal";
            if (imc < 30.0) return "Sobrepeso";
            return "Obesidad";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var p = new Perfil(_userName)
            {
                Edad      = (int)numEdad.Value,
                PesoKg    = (double)numPeso.Value,
                AlturaCm  = (double)numAltura.Value,
                Objetivo  = (ObjetivoNutricional)cmbObjetivo.SelectedIndex,
                Actividad = (NivelActividad)cmbActividad.SelectedIndex,
                Dieta     = (TipoDieta)cmbDieta.SelectedIndex
            };

            _controller.GuardarPerfil(p);
            ActualizarResultados(p);

            MessageBox.Show(
                "Perfil guardado correctamente.",
                "Exito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
