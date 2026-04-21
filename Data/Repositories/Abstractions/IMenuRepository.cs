using System;
using System.Collections.Generic;
using NutricionApp.Models;

namespace NutricionApp.Data.Repositories.Abstractions
{
    /// <summary>
    /// Define el contrato de acceso a datos para la entidad Menu.
    /// </summary>
    public interface IMenuRepository
    {
        List<Menu> GetByUser(string userName);
        int        Add(Menu menu);
        void       AddItem(int menuId, ItemMenu item);
        void       Delete(string userName, int menuId);
        string     GetMostConsumedFood(DateTime from, DateTime to);
        List<(string UserName, int Count)> GetTopUsersByMenus(int top);
    }
}
