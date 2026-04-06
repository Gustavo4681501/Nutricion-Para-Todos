using System;
using System.Collections.Generic;
using NutricionApp.Models;

namespace NutricionApp.Controllers.Abstractions
{
    /// <summary>
    /// Defines a contract for managing user-specific menus, including retrieving, saving, and deleting menus associated
    /// with a particular user.
    /// </summary>
    /// <remarks>Implementations of this interface should ensure that menu operations respect user permissions
    /// and data integrity. This interface is intended to abstract menu management functionality, allowing for flexible
    /// implementations that can interact with various data sources or storage mechanisms.</remarks>
    public interface IMenuController
    {
        /// <summary>
        /// Retrieves a collection of menu items available to the specified user.
        /// </summary>
        /// <remarks>An <see cref="ArgumentNullException"/> is thrown if <paramref name="userName"/> is
        /// null.</remarks>
        /// <param name="userName">The name of the user for whom to retrieve menu items. This parameter cannot be null or empty.</param>
        /// <returns>A list of <see cref="Menu"/> objects representing the menu items accessible to the specified user. The list
        /// is empty if no menu items are found.</returns>
        List<Menu> ObtenerPorUsuario(string userName);

        /// <summary>
        /// Saves the specified menu to persistent storage.
        /// </summary>
        /// <remarks>Ensure that the menu is properly initialized before calling this method to avoid
        /// runtime errors.</remarks>
        /// <param name="menu">The menu to be saved. This parameter cannot be null and must contain valid menu data.</param>
        void Guardar(Menu menu);

        /// <summary>
        /// Removes the specified user from the collection at the given index.
        /// </summary>
        /// <remarks>If the specified index is out of range, an exception is thrown. Ensure that the user
        /// exists at the specified index before calling this method.</remarks>
        /// <param name="userName">The name of the user to remove. This parameter cannot be null or empty.</param>
        /// <param name="indice">The zero-based index of the user in the collection. Must be within the valid range of the collection.</param>
        void Eliminar(string userName, int indice);
    }
}
