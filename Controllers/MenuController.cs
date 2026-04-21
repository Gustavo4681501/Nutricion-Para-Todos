using System;
using System.Collections.Generic;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Data.Repositories.Abstractions;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Coordina la gestion de menus diarios.
    /// Delega el acceso a datos a IMenuRepository (Patron Repository).
    /// Responsabilidad unica: logica de negocio de menus.
    /// </summary>
    public class MenuController : IMenuController
    {
        private readonly IMenuRepository _menuRepo;

        public MenuController(IMenuRepository menuRepo)
        {
            _menuRepo = menuRepo;
        }

        /// <summary>Retorna todos los menus de un usuario.</summary>
        public List<Menu> ObtenerPorUsuario(string userName) =>
            _menuRepo.GetByUser(userName);

        /// <summary>
        /// Guarda un menu completo con todos sus items.
        /// La logica de coordinacion (crear menu luego items) queda en el controller.
        /// </summary>
        public void Guardar(Menu menu)
        {
            int menuId = _menuRepo.Add(menu);
            foreach (var item in menu.Items)
                _menuRepo.AddItem(menuId, item);
        }

        /// <summary>Elimina un menu y sus items por Id.</summary>
        public void Eliminar(string userName, int menuId) =>
            _menuRepo.Delete(userName, menuId);

        /// <summary>Retorna el alimento mas consumido en el rango de fechas indicado.</summary>
        public string AlimentoMasConsumido(DateTime desde, DateTime hasta) =>
            _menuRepo.GetMostConsumedFood(desde, hasta);

        /// <summary>Retorna los usuarios con mas menus registrados.</summary>
        public List<(string UserName, int Count)> TopUsuariosPorMenus(int top = 5) =>
            _menuRepo.GetTopUsersByMenus(top);
    }
}
