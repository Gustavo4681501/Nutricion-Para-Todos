using System.Collections.Generic;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Data.Repositories.Abstractions;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Coordina la gestion administrativa de usuarios.
    /// Delega el acceso a datos a IUsuarioRepository (Patron Repository).
    /// Responsabilidad unica: operaciones administrativas de usuarios.
    /// </summary>
    public class UserManagementController : IUserManagementController
    {
        private readonly IUsuarioRepository _usuarioRepo;

        /// <summary>Recibe el repositorio de usuarios por inyeccion de dependencias.</summary>
        public UserManagementController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        /// <summary>Retorna todos los usuarios del sistema.</summary>
        public List<User> GetAll() => _usuarioRepo.GetAll();

        /// <summary>Resetea la contrasena de un usuario.</summary>
        public void ResetPassword(string userName, string newPassword) =>
            _usuarioRepo.UpdatePassword(userName, newPassword);

        /// <summary>Activa o desactiva una cuenta de usuario.</summary>
        public void SetActive(string userName, bool active) =>
            _usuarioRepo.UpdateActive(userName, active);

        /// <summary>Elimina permanentemente un usuario.</summary>
        public void EliminarUsuario(string userName) =>
            _usuarioRepo.Delete(userName);
    }
}
