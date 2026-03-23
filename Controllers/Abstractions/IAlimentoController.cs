using System.Collections.Generic;
using NutricionApp.Models;

namespace NutricionApp.Controllers.Abstractions
{
    /// <summary>
    /// Defines the contract for managing food items in a catalog, providing methods to retrieve, add, and remove items.
    /// </summary>
    /// <remarks>Implementations of this interface should ensure that all operations are performed in a
    /// thread-safe manner and that any changes to the catalog are persisted appropriately.</remarks>
    public interface IAlimentoController
    {
        /// <summary>
        /// Retrieves a list of all available food items.
        /// </summary>
        /// <returns>A list of <see cref="Alimento"/> objects representing all food items. The list will be empty if no food
        /// items are available.</returns>
        List<Alimento> ObtenerTodos();
        
           /// <summary>
           /// Adds the specified food item to the collection.
           /// </summary>
           /// <remarks>This method updates the internal state of the collection to include the new
           /// food item. Ensure that the food item meets any necessary validation criteria before calling this
           /// method.</remarks>
           /// <param name="alimento">The food item to add to the collection. Cannot be null.</param>
        void Agregar(Alimento alimento);

        /// <summary>
        /// Removes the item at the specified index from the collection.
        /// </summary>
        /// <remarks>If the index is out of range, an exception will be thrown. This method modifies the
        /// collection by shifting subsequent elements to fill the gap left by the removed item.</remarks>
        /// <param name="indice">The zero-based index of the item to remove. Must be a valid index within the bounds of the collection.</param>
        void Eliminar(int indice);
    }
}
