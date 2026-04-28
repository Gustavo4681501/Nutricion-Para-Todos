using NutricionApp.Models;

namespace NutricionApp.Controllers.Abstractions
{
    /// <summary>
    /// Define el contrato para gestionar perfiles de usuario, incluyendo operaciones para recuperar y guardar información de perfil.
    /// </summary>
    public interface IPerfilController
    {
        /// <summary>
        /// Recupera el perfil de usuario asociado con el nombre de usuario especificado. Si no se encuentra ningún perfil, devuelve null.
        /// </summary>

        Perfil ObtenerPerfil(string userName);

        /// <summary>
        /// Guarda el perfil de usuario especificado en el almacén de datos subyacente.
        /// </summary>
  
        void GuardarPerfil(Perfil perfil);
    }
}
