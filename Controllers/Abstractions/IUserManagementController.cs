using System.Collections.Generic;
using NutricionApp.Models;

namespace NutricionApp.Controllers.Abstractions
{
    /// <summary>
    /// Define el contrato para la gestion administrativa de usuarios.
    /// Separado de ILoginController siguiendo el principio de
    /// Interface Segregation (SOLID-I).
    /// </summary>
    public interface IUserManagementController
    {
        /// <summary>Retorna todos los usuarios del sistema.</summary>
        List<User> GetAll();

        /// <summary>Resetea la contrasena de un usuario.</summary>
        void ResetPassword(string userName, string newPassword);

        /// <summary>Activa o desactiva una cuenta de usuario.</summary>
        void SetActive(string userName, bool active);

        /// <summary>Elimina permanentemente un usuario.</summary>
        void EliminarUsuario(string userName);
    }
}
