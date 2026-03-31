using System;
using System.IO;
using System.Windows.Forms;
using NutricionApp.Controllers;
using NutricionApp.Views;

namespace NutricionApp
{
    internal static class Program
    {
        
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

