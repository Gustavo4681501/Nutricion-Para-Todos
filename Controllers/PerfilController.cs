using System.Collections.Generic;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Data.Repositories.Abstractions;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Coordina la gestion de perfiles nutricionales.
    /// Delega el acceso a datos a IPerfilRepository (Patron Repository).
    /// Responsabilidad unica: logica de negocio de perfiles.
    /// </summary>
    public class PerfilController : IPerfilController
    {
        private readonly IPerfilRepository _perfilRepo;

        /// <summary>Recibe el repositorio de perfiles por inyeccion de dependencias.</summary>
        public PerfilController(IPerfilRepository perfilRepo)
        {
            _perfilRepo = perfilRepo;
        }

        /// <summary>
        /// Retorna el perfil del usuario.
        /// Si no existe, retorna un perfil por defecto con el nombre del usuario.
        /// </summary>
        public Perfil ObtenerPerfil(string userName)
        {
            return _perfilRepo.GetByUser(userName) ?? new Perfil(userName);
        }

        /// <summary>
        /// Guarda o actualiza el perfil. Decide internamente si insertar o actualizar.
        /// </summary>
        public void GuardarPerfil(Perfil perfil)
        {
            if (_perfilRepo.Exists(perfil.UserName))
                _perfilRepo.Update(perfil);
            else
                _perfilRepo.Add(perfil);
        }

        /// <summary>Retorna la distribucion de tipos de dieta de todos los usuarios.</summary>
        public List<(TipoDieta Dieta, int Count)> DistribucionDietas() =>
            _perfilRepo.GetDietDistribution();
    }
}
