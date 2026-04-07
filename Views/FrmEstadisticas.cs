using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Models;

namespace NutricionApp.Views
{
   /// <summary>
   /// Represents a form that displays nutritional statistics for a user, including daily and monthly summaries of
   /// calorie and macronutrient consumption compared to personal goals.
   /// </summary>
   /// <remarks>The form provides visual summaries and history tables for calorie and macronutrient intake,
   /// allowing users to track their progress over custom date ranges or by month. It interacts with menu and profile
   /// controllers to retrieve and display relevant data. The default view shows statistics for the last 30 days and
   /// today's summary upon initialization.</remarks>
    public partial class FrmEstadisticas : Form
    {
        private readonly MenuController _menuController;
        private readonly PerfilController _perfilController;
        private readonly string _userName;

        /// <summary>
        /// Initializes a new instance of the FrmEstadisticas form with the specified user name and controllers.
        /// </summary>
        /// <remarks>The form initializes with a default date range of the last 30 days and preloads
        /// today's summary statistics. The provided controllers are used to interact with menu and profile data within
        /// the form.</remarks>
        /// <param name="userName">The name of the user for whom the statistics will be displayed. Cannot be null or empty.</param>
        /// <param name="menuController">The controller responsible for managing menu-related operations. Cannot be null.</param>
        /// <param name="perfilController">The controller used to manage user profile operations. Cannot be null.</param>
        public FrmEstadisticas(string userName, MenuController menuController,
            PerfilController perfilController)
        {
            InitializeComponent();
            _userName = userName;
            _menuController = menuController;
            _perfilController = perfilController;

            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;
            cmbMes.SelectedIndex = DateTime.Today.Month - 1;
            numAnio.Value = DateTime.Today.Year;

            CargarResumenHoy();
        }

        private void CargarResumenHoy()
        {
            var menus = _menuController.ObtenerPorUsuario(_userName);
            var perfil = _perfilController.ObtenerPerfil(_userName);
            double metaCal = perfil.CaloriasRecomendadas();
            var metaMacros = perfil.MacrosRecomendados();

            double consumidoCal = 0;
            double consumidoProt = 0;
            double consumidoCarb = 0;
            double consumidoGras = 0;

            foreach (var m in menus)
            {
                if (m.Fecha.Date == DateTime.Today)
                {
                    consumidoCal += m.TotalCalorias();
                    consumidoProt += m.TotalProteinas();
                    consumidoCarb += m.TotalCarbohidratos();
                    consumidoGras += m.TotalGrasas();
                }
            }

            double falta = metaCal - consumidoCal;

            lblHoyFecha.Text = "Hoy: " + DateTime.Today.ToString("dd/MM/yyyy");
            lblHoyConsumo.Text = string.Format(
                "Consumido: {0:F0} kcal     Meta: {1:F0} kcal",
                consumidoCal, metaCal);

            lblHoyMacros.Text = string.Format(
                "Proteinas: {0:F0}g / {1:F0}g   |   Carbohidratos: {2:F0}g / {3:F0}g   |   Grasas: {4:F0}g / {5:F0}g",
                consumidoProt, metaMacros.Proteinas,
                consumidoCarb, metaMacros.Carbohidratos,
                consumidoGras, metaMacros.Grasas);

            if (falta > 0)
                lblHoyFalta.Text = string.Format("Faltan {0:F0} kcal para llegar a la meta.", falta);
            else if (falta < 0)
                lblHoyFalta.Text = string.Format("Superaste la meta por {0:F0} kcal.", Math.Abs(falta));
            else
                lblHoyFalta.Text = "Meta diaria cumplida exactamente.";

            int pct = metaCal > 0 ? (int)Math.Min((consumidoCal / metaCal) * 100, 100) : 0;
            pbHoy.Value = pct;
        }

        private void btnBuscarDiario_Click(object sender, EventArgs e)
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            if (desde > hasta)
            {
                MessageBox.Show("La fecha Desde no puede ser mayor que Hasta.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var menus = _menuController.ObtenerPorUsuario(_userName);
            var perfil = _perfilController.ObtenerPerfil(_userName);
            double metaCal = perfil.CaloriasRecomendadas();

            // Aggregate per day
            var porDia = new Dictionary<DateTime, double[]>();
            // Index: 0=Cal, 1=Prot, 2=Carb, 3=Grasas

            foreach (var m in menus)
            {
                if (m.Fecha.Date < desde || m.Fecha.Date > hasta)
                    continue;

                if (!porDia.ContainsKey(m.Fecha.Date))
                    porDia[m.Fecha.Date] = new double[4];

                porDia[m.Fecha.Date][0] += m.TotalCalorias();
                porDia[m.Fecha.Date][1] += m.TotalProteinas();
                porDia[m.Fecha.Date][2] += m.TotalCarbohidratos();
                porDia[m.Fecha.Date][3] += m.TotalGrasas();
            }

            dgvDiario.Rows.Clear();

            var fechas = new List<DateTime>(porDia.Keys);
            fechas.Sort((a, b) => b.CompareTo(a));

            foreach (var fecha in fechas)
            {
                double[] vals = porDia[fecha];
                double pct = metaCal > 0 ? (vals[0] / metaCal) * 100 : 0;
                string cumple = vals[0] >= metaCal ? "Si" : "No";

                dgvDiario.Rows.Add(
                    fecha.ToString("dd/MM/yyyy"),
                    string.Format("{0:F0}", vals[0]),
                    string.Format("{0:F0}", metaCal),
                    string.Format("{0:F0}%", pct),
                    cumple,
                    string.Format("{0:F0}g", vals[1]),
                    string.Format("{0:F0}g", vals[2]),
                    string.Format("{0:F0}g", vals[3]));
            }

            if (dgvDiario.Rows.Count == 0)
                MessageBox.Show("No hay datos para ese rango de fechas.",
                    "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBuscarMensual_Click(object sender, EventArgs e)
        {
            int mes = cmbMes.SelectedIndex + 1;
            int anio = (int)numAnio.Value;

            var menus = _menuController.ObtenerPorUsuario(_userName);
            var perfil = _perfilController.ObtenerPerfil(_userName);
            double metaCal = perfil.CaloriasRecomendadas();
            var metaMacros = perfil.MacrosRecomendados();

            var porDia = new Dictionary<DateTime, double[]>();

            foreach (var m in menus)
            {
                if (m.Fecha.Month != mes || m.Fecha.Year != anio)
                    continue;

                if (!porDia.ContainsKey(m.Fecha.Date))
                    porDia[m.Fecha.Date] = new double[4];

                porDia[m.Fecha.Date][0] += m.TotalCalorias();
                porDia[m.Fecha.Date][1] += m.TotalProteinas();
                porDia[m.Fecha.Date][2] += m.TotalCarbohidratos();
                porDia[m.Fecha.Date][3] += m.TotalGrasas();
            }

            if (porDia.Count == 0)
            {
                lblMensualResultado.Text = "No hay datos registrados para ese mes.";
                return;
            }

            int diasRegistrados = porDia.Count;
            int diasCumplidos = 0;
            double totalCal = 0;
            double totalProt = 0;
            double totalCarb = 0;
            double totalGrasas = 0;

            foreach (var vals in porDia.Values)
            {
                totalCal += vals[0];
                totalProt += vals[1];
                totalCarb += vals[2];
                totalGrasas += vals[3];
                if (vals[0] >= metaCal)
                    diasCumplidos++;
            }

            double promCal = totalCal / diasRegistrados;
            double promProt = totalProt / diasRegistrados;
            double promCarb = totalCarb / diasRegistrados;
            double promGras = totalGrasas / diasRegistrados;

            lblMensualResultado.Text = string.Format(
                "Dias registrados: {0}\r\n" +
                "Dias con meta cumplida: {1}\r\n" +
                "Dias sin cumplir meta: {2}\r\n" +
                "─────────────────────────\r\n" +
                "Promedio calorias/dia:\r\n" +
                "  {3:F0} kcal  (meta: {4:F0})\r\n\r\n" +
                "Promedio macros/dia:\r\n" +
                "  Proteinas:     {5:F0}g / {6:F0}g\r\n" +
                "  Carbohidratos: {7:F0}g / {8:F0}g\r\n" +
                "  Grasas:        {9:F0}g / {10:F0}g",
                diasRegistrados,
                diasCumplidos,
                diasRegistrados - diasCumplidos,
                promCal, metaCal,
                promProt, metaMacros.Proteinas,
                promCarb, metaMacros.Carbohidratos,
                promGras, metaMacros.Grasas);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}