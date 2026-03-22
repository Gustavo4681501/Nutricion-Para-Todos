using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Data;
using NutricionApp.Data.Loaders;
using NutricionApp.Views;

namespace NutricionApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture   = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicializar rutas CSV
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "CSV");
            Directory.CreateDirectory(dir);

            var ctx = NutricionContext.Instancia;
            ctx.RutaAlimentos = Path.Combine(dir, "alimentos.csv");
            ctx.RutaMenus     = Path.Combine(dir, "menus.csv");
            ctx.Alimentos = CsvLoader.CargarAlimentos(ctx.RutaAlimentos);
            ctx.Menus     = CsvLoader.CargarMenus(ctx.RutaMenus);

            // Construir LoginController con la ruta del CSV de usuarios
            // (igual que BuildLoginController() en el proyecto de referencia)
            string rutaUsuarios = Path.Combine(dir, "usuarios.csv");
            var loginCtrl = new LoginController(rutaUsuarios);
            NutricionContext.Instancia.LoginCtrl = loginCtrl;

            Application.Run(new FrmLogin(loginCtrl));
        }
    }
}
