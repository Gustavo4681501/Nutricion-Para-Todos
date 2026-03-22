namespace NutricionApp.Controllers.Abstractions
{
    /// <summary>
    /// Define el contrato para las operaciones de login.
    /// </summary>
    public interface ILoginController
    {
        /// <summary>
        /// Valida las credenciales de un usuario.
        /// </summary>
        bool Login(string userName, string password);

        /// <summary>
        /// Registra un nuevo usuario y lo persiste.
        /// </summary>
        bool Register(string userName, string password);
    }
}
