using System.Collections.Generic;
using NutricionApp.Models;

namespace NutricionApp.Data.Repositories.Abstractions
{
    /// <summary>
    /// Define el contrato de acceso a datos para la entidad Perfil.
    /// </summary>
    public interface IPerfilRepository
    {
        Perfil GetByUser(string userName);
        bool   Exists(string userName);
        void   Add(Perfil perfil);
        void   Update(Perfil perfil);
        List<(TipoDieta Dieta, int Count)> GetDietDistribution();
    }
}
