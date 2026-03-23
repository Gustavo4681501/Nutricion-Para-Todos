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

            string filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Data", "CSV", "usuarios.csv");

            var loginController = new LoginController(filePath);

            Application.Run(new FrmLogin(loginController));
        }
    }
}
