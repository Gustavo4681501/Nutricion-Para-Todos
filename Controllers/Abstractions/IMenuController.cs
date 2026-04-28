using System;
using System.Collections.Generic;
using NutricionApp.Models;

namespace NutricionApp.Controllers.Abstractions
{
    /// <summary>
    /// Define el contrato para gestionar elementos del menú, incluyendo operaciones para recuperar, guardar y eliminar menús asociados con
    /// usuarios.
    /// </summary>
    public interface IMenuController
    {
        /// <summary>
        /// Recupera una lista de menús accesibles para el usuario especificado.
        /// </summary>
        List<Menu> ObtenerPorUsuario(string userName);

        /// <summary>
        /// Guarda el menú especificado en el almacén de datos subyacente.
        /// </summary>
        
        void Guardar(Menu menu);

        /// <summary>
        /// Elimina el elemento en el índice especificado para el usuario dado.
        /// </summary>
      
        void Eliminar(string userName, int indice);
    }
}
