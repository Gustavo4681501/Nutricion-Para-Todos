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
            string csvDir = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Data", "CSV");

            string usuariosPath = Path.Combine(csvDir, "usuarios.csv");
            string alimentosPath = Path.Combine(csvDir, "alimentos.csv");

            var loginController = new LoginController(usuariosPath);
            var alimentoController = new AlimentoController(alimentosPath);

            Application.Run(new FrmLogin(loginController, alimentoController));
        }
    }
}
