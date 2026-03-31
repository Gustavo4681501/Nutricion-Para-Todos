using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Models;

namespace NutricionApp.Views
{
    /// <summary>
    /// Formulario de estadisticas nutricionales del usuario.
    /// Muestra el consumo del dia actual, un historial diario filtrable por fechas
    /// y un resumen mensual parametrizable.
    /// </summary>
    /// <remarks>
    /// Los calculos estadisticos se hacen directamente aqui en lugar de
    /// delegarlos a un controlador separado, lo que mezcla la responsabilidad
    /// de presentacion con la logica de calculo.
    /// </remarks>
    public partial class FrmEstadisticas : Form
    {
        private readonly MenuController   _menuController;
        private readonly PerfilController _perfilController;
        private readonly string           _userName;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FrmEstadisticas"/>.
        /// </summary>
        /// <param name="userName">Nombre del usuario activo.</param>
        /// <param name="menuController">Controlador de menus.</param>
        /// <param name="perfilController">Controlador de perfiles.</param>
        public FrmEstadisticas(string userName, MenuController menuController,
            PerfilController perfilController)
        {
            InitializeComponent();
            _userName         = userName;
            _menuController   = menuController;
            _perfilController = perfilController;

            dtpDesde.Value       = DateTime.Today.AddDays(-30);
            dtpHasta.Value       = DateTime.Today;
            cmbMes.SelectedIndex = DateTime.Today.Month - 1;
            numAnio.Value        = DateTime.Today.Year;

            CargarResumenHoy();
        }

        // ── RESUMEN HOY ──────────────────────────────────────────────────────

        private void CargarResumenHoy()
        {
            var    menus  = _menuController.ObtenerPorUsuario(_userName);
            var    perfil = _perfilController.ObtenerPerfil(_userName);
            double meta   = perfil.CaloriasRecomendadas();

            double consumidoHoy = 0;
            foreach (var m in menus)
            {
                if (m.Fecha.Date == DateTime.Today)
                    consumidoHoy += m.TotalCalorias();
            }

            double falta = meta - consumidoHoy;

            lblHoyFecha.Text   = "Hoy: " + DateTime.Today.ToString("dd/MM/yyyy");
            lblHoyConsumo.Text = string.Format(
                "Consumido: {0:F0} kcal     Meta: {1:F0} kcal",
                consumidoHoy, meta);

            if (falta > 0)
                lblHoyFalta.Text = string.Format("Faltan {0:F0} kcal para llegar a la meta.", falta);
            else if (falta < 0)
                lblHoyFalta.Text = string.Format("Superaste la meta por {0:F0} kcal.", Math.Abs(falta));
            else
                lblHoyFalta.Text = "Meta diaria cumplida exactamente.";

            int pct = (int)Math.Min((consumidoHoy / meta) * 100, 100);
            pbHoy.Value = pct;
        }

        // ── HISTORIAL DIARIO ─────────────────────────────────────────────────

        /// <summary>
        /// Carga el historial diario filtrado por el rango de fechas seleccionado.
        /// </summary>
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

            var    menus  = _menuController.ObtenerPorUsuario(_userName);
            var    perfil = _perfilController.ObtenerPerfil(_userName);
            double meta   = perfil.CaloriasRecomendadas();

            var porDia = new Dictionary<DateTime, double>();
            foreach (var m in menus)
            {
                if (m.Fecha.Date >= desde && m.Fecha.Date <= hasta)
                {
                    if (!porDia.ContainsKey(m.Fecha.Date))
                        porDia[m.Fecha.Date] = 0;
                    porDia[m.Fecha.Date] += m.TotalCalorias();
                }
            }

            dgvDiario.Rows.Clear();

            var fechas = new List<DateTime>(porDia.Keys);
            fechas.Sort((a, b) => b.CompareTo(a));

            foreach (var fecha in fechas)
            {
                double cal    = porDia[fecha];
                double pct    = (cal / meta) * 100;
                string cumple = cal >= meta ? "Si" : "No";

                dgvDiario.Rows.Add(
                    fecha.ToString("dd/MM/yyyy"),
                    string.Format("{0:F0}", cal),
                    string.Format("{0:F0}", meta),
                    string.Format("{0:F0}%", pct),
                    cumple);
            }

            if (dgvDiario.Rows.Count == 0)
                MessageBox.Show("No hay datos para ese rango de fechas.",
                    "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── RESUMEN MENSUAL ──────────────────────────────────────────────────

        /// <summary>
        /// Calcula el resumen del mes seleccionado: dias registrados, dias con meta
        /// cumplida y promedio de calorias.
        /// </summary>
        private void btnBuscarMensual_Click(object sender, EventArgs e)
        {
            int mes  = cmbMes.SelectedIndex + 1;
            int anio = (int)numAnio.Value;

            var    menus  = _menuController.ObtenerPorUsuario(_userName);
            var    perfil = _perfilController.ObtenerPerfil(_userName);
            double meta   = perfil.CaloriasRecomendadas();

            var porDia = new Dictionary<DateTime, double>();
            foreach (var m in menus)
            {
                if (m.Fecha.Month == mes && m.Fecha.Year == anio)
                {
                    if (!porDia.ContainsKey(m.Fecha.Date))
                        porDia[m.Fecha.Date] = 0;
                    porDia[m.Fecha.Date] += m.TotalCalorias();
                }
            }

            if (porDia.Count == 0)
            {
                lblMensualResultado.Text = "No hay datos registrados para ese mes.";
                return;
            }

            int    diasRegistrados = porDia.Count;
            int    diasCumplidos   = 0;
            double totalCal        = 0;

            foreach (var cal in porDia.Values)
            {
                totalCal += cal;
                if (cal >= meta)
                    diasCumplidos++;
            }

            double promedio = totalCal / diasRegistrados;

            lblMensualResultado.Text = string.Format(
                "Dias registrados: {0}\r\n" +
                "Dias con meta cumplida: {1}\r\n" +
                "Dias sin cumplir meta: {2}\r\n" +
                "Promedio calorias/dia: {3:F0} kcal\r\n" +
                "Meta diaria: {4:F0} kcal",
                diasRegistrados,
                diasCumplidos,
                diasRegistrados - diasCumplidos,
                promedio,
                meta);
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
