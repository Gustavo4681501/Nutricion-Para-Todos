using NutricionApp.Controllers.Abstractions;
using NutricionApp.Data.Repositories.Abstractions;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Coordina la autenticacion y registro de usuarios.
    /// Delega el acceso a datos a IUsuarioRepository (Patron Repository).
    /// Responsabilidad unica: logica de negocio de autenticacion.
    /// </summary>
    public class LoginController : ILoginController
    {
        private readonly IUsuarioRepository _usuarioRepo;

        /// <summary>Recibe el repositorio de usuarios por inyeccion de dependencias.</summary>
        public LoginController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        /// <summary>Valida las credenciales. Retorna true solo si el usuario existe y esta activo.</summary>
        public bool Login(string userName, string password)
        {
            return _usuarioRepo.GetByCredentials(userName, password) != null;
        }

        /// <summary>Registra un nuevo usuario. Retorna false si el nombre ya esta en uso.</summary>
        public bool Register(string userName, string password)
        {
            if (_usuarioRepo.Exists(userName)) return false;
            _usuarioRepo.Add(userName, password);
            return true;
        }

        /// <summary>Retorna el objeto User completo para establecer la sesion.</summary>
        public User GetUser(string userName) => _usuarioRepo.GetByUserName(userName);
    }
}
