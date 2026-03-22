using System;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Data;
using NutricionApp.Models;
using NutricionApp.Utils;

namespace NutricionApp.Views
{
    public partial class FrmPrincipal : Form
    {
        private readonly UsuarioController    _uCtrl  = new UsuarioController();
        private readonly AlimentoController   _aCtrl  = new AlimentoController();
        private readonly MenuController       _mCtrl  = new MenuController();
        private readonly EstadisticasController _eCtrl = new EstadisticasController();

        public FrmPrincipal()
        {
            InitializeComponent();
            var u = NutricionContext.Instancia.UsuarioActivo;
            lblUsuario.Text = "Usuario: " + u.Nombre + "  |  Objetivo: " + u.Objetivo + "  |  Dieta: " + u.TipoDieta;
            CargarAlimentos();
            CargarMenus();
            CargarInfoNutri();
            CargarEstadisticasHoy();
        }

        // ── TAB ALIMENTOS ─────────────────────────────────────────────────────
        private void CargarAlimentos()
        {
            dgvAlimentos.Rows.Clear();
            var lista = string.IsNullOrWhiteSpace(txtBuscarAlimento.Text)
                ? _aCtrl.ObtenerTodos()
                : _aCtrl.Buscar(txtBuscarAlimento.Text);
            foreach (var a in lista)
                dgvAlimentos.Rows.Add(a.Id, a.Nombre, a.Categoria,
                    a.Calorias, a.Proteinas, a.Carbohidratos, a.Grasas, a.PorcionGramos);
        }

        private void txtBuscarAlimento_TextChanged(object sender, EventArgs e) => CargarAlimentos();

        private void btnAgregarAlimento_Click(object sender, EventArgs e)
        {
            if (new FrmAlimento(null).ShowDialog() == DialogResult.OK) CargarAlimentos();
        }

        private void btnEditarAlimento_Click(object sender, EventArgs e)
        {
            if (dgvAlimentos.SelectedRows.Count == 0) { MessageBox.Show("Selecciona un alimento."); return; }
            int id = (int)dgvAlimentos.SelectedRows[0].Cells[0].Value;
            var a  = _aCtrl.ObtenerPorId(id);
            if (new FrmAlimento(a).ShowDialog() == DialogResult.OK) CargarAlimentos();
        }

        private void btnEliminarAlimento_Click(object sender, EventArgs e)
        {
            if (dgvAlimentos.SelectedRows.Count == 0) { MessageBox.Show("Selecciona un alimento."); return; }
            if (MessageBox.Show("¿Eliminar?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = (int)dgvAlimentos.SelectedRows[0].Cells[0].Value;
                _aCtrl.EliminarAlimento(id);
                CargarAlimentos();
            }
        }

        // ── TAB MENUS ─────────────────────────────────────────────────────────
        private void CargarMenus()
        {
            int uid = NutricionContext.Instancia.UsuarioActivo.Id;
            var lista = _mCtrl.ObtenerPorRangoFechas(uid, dtpMenuDesde.Value, dtpMenuHasta.Value);
            dgvMenus.Rows.Clear();
            foreach (var m in lista)
                dgvMenus.Rows.Add(m.Id, m.Fecha.ToString("dd/MM/yyyy"), m.Items.Count,
                    string.Format("{0:F0}", m.TotalCalorias),
                    string.Format("{0:F1}", m.TotalProteinas),
                    string.Format("{0:F1}", m.TotalCarbohidratos),
                    string.Format("{0:F1}", m.TotalGrasas));
        }

        private void btnBuscarMenus_Click(object sender, EventArgs e) => CargarMenus();

        private void btnAgregarMenu_Click(object sender, EventArgs e)
        {
            if (new FrmMenu(null).ShowDialog() == DialogResult.OK) CargarMenus();
        }

        private void btnEditarMenu_Click(object sender, EventArgs e)
        {
            if (dgvMenus.SelectedRows.Count == 0) { MessageBox.Show("Selecciona un menu."); return; }
            int id  = (int)dgvMenus.SelectedRows[0].Cells[0].Value;
            int uid = NutricionContext.Instancia.UsuarioActivo.Id;
            var m   = _mCtrl.ObtenerPorRangoFechas(uid, System.DateTime.MinValue, System.DateTime.MaxValue)
                            .Find(x => x.Id == id);
            if (new FrmMenu(m).ShowDialog() == DialogResult.OK) CargarMenus();
        }

        private void btnEliminarMenu_Click(object sender, EventArgs e)
        {
            if (dgvMenus.SelectedRows.Count == 0) { MessageBox.Show("Selecciona un menu."); return; }
            if (MessageBox.Show("¿Eliminar?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = (int)dgvMenus.SelectedRows[0].Cells[0].Value;
                _mCtrl.EliminarMenu(id);
                CargarMenus();
            }
        }

        // ── TAB INFO NUTRI ────────────────────────────────────────────────────
        // SOLID break #2: FrmPrincipal calcula y muestra directamente la info
        // nutricional en lugar de delegarlo a un control separado.
        private void CargarInfoNutri()
        {
            var u  = NutricionContext.Instancia.UsuarioActivo;
            double tmb  = CalculadoraNutricional.CalcularTMB(u);
            double tdee = CalculadoraNutricional.CalcularTDEE(u);
            double obj  = CalculadoraNutricional.CalcularCaloriasObjetivo(u);
            double imc  = CalculadoraNutricional.CalcularIMC(u);
            var macros  = CalculadoraNutricional.DistribucionMacros(u);

            lblTMB.Text    = "TMB: "     + string.Format("{0:F0}", tmb)  + " kcal/dia";
            lblTDEE.Text   = "TDEE: "    + string.Format("{0:F0}", tdee) + " kcal/dia";
            lblObj.Text    = "Objetivo: "+ string.Format("{0:F0}", obj)  + " kcal/dia";
            lblIMC.Text    = "IMC: "     + string.Format("{0:F1}", imc)  + " - " + CalculadoraNutricional.ClasificacionIMC(imc);
            lblProt.Text   = "Proteinas: "     + string.Format("{0:F0}", macros.protG)  + " g/dia";
            lblCarbs.Text  = "Carbohidratos: " + string.Format("{0:F0}", macros.carbG)  + " g/dia";
            lblGrasas.Text = "Grasas: "        + string.Format("{0:F0}", macros.grasaG) + " g/dia";
            lblDieta.Text  = "Dieta: " + u.TipoDieta + "  |  Objetivo: " + u.Objetivo;
        }

        // ── TAB ESTADISTICAS ─────────────────────────────────────────────────
        private void CargarEstadisticasHoy()
        {
            int uid = NutricionContext.Instancia.UsuarioActivo.Id;
            var r   = _eCtrl.ObtenerResumenDia(uid, System.DateTime.Today);
            lblEstHoy.Text =
                "HOY - " + System.DateTime.Today.ToString("dd/MM/yyyy") + "\r\n" +
                string.Format("Calorias: {0:F0} / {1:F0} kcal\r\n", r.CaloriasConsumidas, r.MetaCalorias) +
                string.Format("Proteinas: {0:F1} / {1:F1} g\r\n", r.ProteinasConsumidas, r.MetaProteinas) +
                string.Format("Carbohidratos: {0:F1} / {1:F1} g\r\n", r.CarbsConsumidos, r.MetaCarbs) +
                string.Format("Grasas: {0:F1} / {1:F1} g\r\n", r.GrasasConsumidas, r.MetaGrasas);

            double diff = r.DiferenciaCalorias;
            lblEstFalta.Text = diff > 0
                ? string.Format("Faltan {0:F0} kcal para la meta", diff)
                : diff < 0
                    ? string.Format("Superaste la meta por {0:F0} kcal", System.Math.Abs(diff))
                    : "Meta cumplida hoy!";
            pbHoy.Value = (int)System.Math.Min(r.PorcentajeCalorias, 100);
        }

        private void btnBuscarDiario_Click(object sender, EventArgs e)
        {
            int uid = NutricionContext.Instancia.UsuarioActivo.Id;
            var lista = _eCtrl.ObtenerHistorialDiario(uid, dtpEstDesde.Value, dtpEstHasta.Value);
            dgvEstDiario.Rows.Clear();
            foreach (var d in lista)
                dgvEstDiario.Rows.Add(
                    d.Fecha.ToString("dd/MM/yyyy"),
                    string.Format("{0:F0}", d.CaloriasConsumidas),
                    string.Format("{0:F0}", d.MetaCalorias),
                    string.Format("{0:F0}%", d.PorcentajeCalorias),
                    d.MetaCumplida ? "Si" : "No");
        }

        private void btnBuscarMensual_Click(object sender, EventArgs e)
        {
            int uid  = NutricionContext.Instancia.UsuarioActivo.Id;
            int mes  = cmbMes.SelectedIndex + 1;
            int anio = (int)numAnio.Value;
            var r    = _eCtrl.ObtenerResumenMes(uid, anio, mes);
            lblMensual.Text =
                "Dias registrados: " + r.TotalDiasRegistrados + "\r\n" +
                "Dias con meta cumplida: " + r.DiasCumplidos + "\r\n" +
                string.Format("Promedio calorias: {0:F0} kcal\r\n", r.PromedioCaloriasdiario) +
                string.Format("Promedio proteinas: {0:F1} g\r\n", r.PromedioProteinasDiario) +
                string.Format("Promedio carbs: {0:F1} g\r\n", r.PromedioCarbsDiario) +
                string.Format("Promedio grasas: {0:F1} g", r.PromedioGrasasDiario);
        }

        // ── PERFIL ────────────────────────────────────────────────────────────
        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            var frm = new FrmUsuario(NutricionContext.Instancia.UsuarioActivo);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var u = NutricionContext.Instancia.UsuarioActivo;
                lblUsuario.Text = "Usuario: " + u.Nombre + "  |  Objetivo: " + u.Objetivo + "  |  Dieta: " + u.TipoDieta;
                CargarInfoNutri();
            }
        }

        private void btnCambiarUsuario_Click(object sender, EventArgs e)
        {
            NutricionContext.Instancia.UsuarioActivo = null;
            var loginCtrl = NutricionContext.Instancia.LoginCtrl;
            var login = new FrmLogin(loginCtrl);
            login.Show();
            this.Close();
        }
    }
}
