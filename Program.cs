using System;
using System.IO;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Views;

namespace NutricionApp
{
    internal static class Program
    {
        /// <summary>
        /// Serves as the main entry point for the application, initializing the user interface and ensuring required
        /// data files are present before launching the login form.
        /// </summary>
        /// <remarks>This method creates the necessary data directory and CSV files if they do not already
        /// exist. It also initializes controllers for user authentication, food items, menus, and user profiles, and
        /// then starts the application's login form. The method must be marked with the [STAThread] attribute to
        /// support Windows Forms functionality.</remarks>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string csvDir = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Data", "CSV");

            Directory.CreateDirectory(csvDir);

            string usuariosPath = Path.Combine(csvDir, "usuarios.csv");
            string alimentosPath = Path.Combine(csvDir, "alimentos.csv");
            string menusPath = Path.Combine(csvDir, "menus.csv");
            string perfilesPath = Path.Combine(csvDir, "perfiles.csv");

            if (!File.Exists(usuariosPath))
                File.WriteAllText(usuariosPath, "UserName,Password\n");

            if (!File.Exists(alimentosPath))
                File.WriteAllText(alimentosPath, "Nombre,Calorias,Proteinas,Carbohidratos,Grasas,Porcion\n");

            if (!File.Exists(menusPath))
                File.WriteAllText(menusPath, "UserName,Fecha,NombreAlimento,CantidadGramos,Calorias\n");

            if (!File.Exists(perfilesPath))
                File.WriteAllText(perfilesPath, "UserName,Edad,PesoKg,AlturaCm,Objetivo\n");

            var loginController = new LoginController(usuariosPath);
            var alimentoController = new AlimentoController(alimentosPath);
            var menuController = new MenuController(menusPath);
            var perfilController = new PerfilController(perfilesPath);

            Application.Run(new FrmLogin(loginController, alimentoController,
                menuController, perfilController));
        }
    }
}