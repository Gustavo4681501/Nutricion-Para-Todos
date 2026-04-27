using System.Collections.Generic;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Data.Repositories.Abstractions;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Coordina las operaciones del catalogo de alimentos.
    /// Delega el acceso a datos a IAlimentoRepository (Patron Repository).
    /// Responsabilidad unica: logica de negocio de alimentos.
    /// </summary>
    public class AlimentoController : IAlimentoController
    {
        private readonly IAlimentoRepository _alimentoRepo;

        /// <summary>Recibe el repositorio de alimentos por inyeccion de dependencias.</summary>
        public AlimentoController(IAlimentoRepository alimentoRepo)
        {
            _alimentoRepo = alimentoRepo;
        }

        /// <summary>Retorna todos los alimentos del catalogo.</summary>
        public List<Alimento> ObtenerTodos() => _alimentoRepo.GetAll();

        /// <summary>Retorna un alimento por nombre, o null si no existe.</summary>
        public Alimento ObtenerPorNombre(string nombre) => _alimentoRepo.GetByName(nombre);

        /// <summary>Agrega un alimento al catalogo.</summary>
        public void Agregar(Alimento alimento) => _alimentoRepo.Add(alimento);

        /// <summary>Actualiza los datos de un alimento existente.</summary>
        public void Actualizar(Alimento alimento) => _alimentoRepo.Update(alimento);

        /// <summary>Elimina un alimento por su Id.</summary>
        public void Eliminar(int id) => _alimentoRepo.DeleteById(id);

        /// <summary>Elimina un alimento por su nombre.</summary>
        public void EliminarPorNombre(string nombre) => _alimentoRepo.DeleteByName(nombre);
    }
}
