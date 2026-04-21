using System.Collections.Generic;
using NutricionApp.Models;

namespace NutricionApp.Data.Repositories.Abstractions
{
    /// <summary>
    /// Define el contrato de acceso a datos para la entidad Alimento.
    /// </summary>
    public interface IAlimentoRepository
    {
        List<Alimento> GetAll();
        Alimento       GetByName(string nombre);
        void           Add(Alimento alimento);
        void           Update(Alimento alimento);
        void           DeleteById(int id);
        void           DeleteByName(string nombre);
    }
}
