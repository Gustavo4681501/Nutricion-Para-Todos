using Microsoft.Win32;

namespace NutricionApp.Controllers.Abstractions
{
    /// <summary>
    /// Define métodos para autenticar usuarios y registrar nuevas cuentas de usuario.
    /// </summary>
    public interface ILoginController
    {
        /// <summary>
        /// Intenta autenticar a un usuario con el nombre de usuario y la contraseña especificados.
        /// </summary>

        bool Login(string userName, string password);

        /// <summary>
        /// Intenta registrar una nueva cuenta de usuario con el nombre de usuario y la contraseña especificados.
        /// </summary>

        bool Register(string userName, string password);
    }
}
