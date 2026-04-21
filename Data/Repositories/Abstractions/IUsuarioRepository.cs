using System.Collections.Generic;
using NutricionApp.Models;

namespace NutricionApp.Data.Repositories.Abstractions
{
    /// <summary>
    /// Define el contrato de acceso a datos para la entidad Usuario.
    /// Patron Repository: separa la logica de acceso a datos de la logica de negocio.
    /// </summary>
    public interface IUsuarioRepository
    {
        User   GetByCredentials(string userName, string password);
        User   GetByUserName(string userName);
        bool   Exists(string userName);
        void   Add(string userName, string password);
        List<User> GetAll();
        void   UpdatePassword(string userName, string newPassword);
        void   UpdateActive(string userName, bool active);
        void   Delete(string userName);
    }
}
