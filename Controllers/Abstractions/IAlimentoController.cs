using NutricionApp.Models;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Xml.Linq;

namespace NutricionApp.Controllers.Abstractions
{
    /// <summary>
    /// Define el contrato para gestionar una colección de artículos de alimentos, incluyendo operaciones para recuperar, agregar y eliminar items
    /// </summary>
    public interface IAlimentoController
    {
        /// <summary>
        /// Recupera todos los alimentos disponibles.
        /// </summary>
        List<Alimento> ObtenerTodos();

        /// <summary>
        /// Agrega el alimento especificado a la colección.
        /// </summary>

        void Agregar(Alimento alimento);

        /// <summary>
        ///Elimina el elemento en el índice especificado.
       /// </summary>

        void Eliminar(int indice);
    }
}
