using System;
using System.Collections.Generic;
using NutricionApp.Models;

namespace NutricionApp.Controllers.Abstractions
{
    /// <summary>
    /// Define el contrato para las operaciones sobre menus diarios.
    /// </summary>
    public interface IMenuController
    {
        /// <summary>
        /// Obtiene todos los menus del usuario indicado.
        /// </summary>
        /// <param name="userName">Nombre del usuario.</param>
        /// <returns>Lista de menus que pertenecen al usuario.</returns>
        List<Menu> ObtenerPorUsuario(string userName);

        /// <summary>
        /// Guarda un nuevo menu y lo persiste en el origen de datos.
        /// </summary>
        /// <param name="menu">Menu a guardar.</param>
        void Guardar(Menu menu);

        /// <summary>
        /// Elimina el menu en la posicion indicada dentro de la lista del usuario.
        /// </summary>
        /// <param name="userName">Nombre del usuario.</param>
        /// <param name="indice">Indice del menu a eliminar.</param>
        void Eliminar(string userName, int indice);
    }
}
