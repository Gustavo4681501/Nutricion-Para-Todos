using System;
using System.Collections.Generic;
using System.IO;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Provides functionality to manage user menus, including loading, retrieving, adding, and deleting menu entries
    /// persisted in a CSV file.
    /// </summary>
    /// <remarks>The controller loads all menu data from the specified CSV file upon instantiation and
    /// persists changes automatically when menus are added or removed. This class is not thread-safe. For concurrent
    /// access, external synchronization is required.</remarks>
    public class MenuController : IMenuController
    {
        private readonly List<Menu> _menus;
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the MenuController class using the specified file path to load menu data.
        /// </summary>
        /// <remarks>The constructor loads menu data from the provided file path during initialization. If
        /// the file does not exist or is invalid, subsequent operations may fail.</remarks>
        /// <param name="filePath">The path to the file containing menu data. Cannot be null or empty.</param>
        public MenuController(string filePath)
        {
            _filePath = filePath;
            _menus    = LoadMenus();
        }

        /// <summary>
        /// Retrieves a list of menus associated with the specified user, ordered by most recent date first.
        /// </summary>
        /// <param name="userName">The user name for which to retrieve menus. This value is compared to the user name associated with each
        /// menu.</param>
        /// <returns>A list of menus belonging to the specified user, sorted in descending order by date. The list is empty if
        /// the user has no associated menus.</returns>
        public List<Menu> ObtenerPorUsuario(string userName)
        {
            var resultado = new List<Menu>();

            foreach (var m in _menus)
            {
                if (m.UserName == userName)
                    resultado.Add(m);
            }

            
            resultado.Sort((a, b) => b.Fecha.CompareTo(a.Fecha));
            return resultado;
        }

        /// <summary>
        /// Adds the specified menu to the collection and persists the updated list.
        /// </summary>
        /// <param name="menu">The menu to add to the collection. Cannot be null.</param>
        public void Guardar(Menu menu)
        {
            _menus.Add(menu);
            SaveMenus();
        }

        /// <summary>
        /// Removes the menu at the specified index for the given user.
        /// </summary>
        /// <remarks>If the specified index is out of range, no action is taken. The removal affects both
        /// the user's menu list and the global menu collection.</remarks>
        /// <param name="userName">The name of the user whose menu list is targeted for removal.</param>
        /// <param name="indice">The zero-based index of the menu to remove from the user's menu list. Must be within the bounds of the list.</param>
        public void Eliminar(string userName, int indice)
        {
            var lista = ObtenerPorUsuario(userName);

            if (indice < 0 || indice >= lista.Count)
                return;

            Menu objetivo = lista[indice];

            
            for (int i = 0; i < _menus.Count; i++)
            {
                if (_menus[i] == objetivo)
                {
                    _menus.RemoveAt(i);
                    break;
                }
            }

            SaveMenus();
        }
        private List<Menu> LoadMenus()
        {
            var lista = new List<Menu>();

            if (!File.Exists(_filePath))
                return lista;

            var lines = File.ReadAllLines(_filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                var parts = lines[i].Split(',');
                if (parts.Length < 5)
                    continue;

                string   userName = parts[0].Trim();
                DateTime fecha;
                if (!DateTime.TryParse(parts[1].Trim(), out fecha))
                    continue;

                string nombreAlimento = parts[2].Trim();
                double cantidad, calorias;

                if (!double.TryParse(parts[3].Trim(),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out cantidad))
                    continue;

                if (!double.TryParse(parts[4].Trim(),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out calorias))
                    continue;

               
                Menu menu = null;
                foreach (var m in lista)
                {
                    if (m.UserName == userName && m.Fecha.Date == fecha.Date)
                    {
                        menu = m;
                        break;
                    }
                }

                if (menu == null)
                {
                    menu = new Menu(userName, fecha);
                    lista.Add(menu);
                }

                menu.Items.Add(new ItemMenu(nombreAlimento, cantidad, calorias));
            }

            return lista;
        }

        
        private void SaveMenus()
        {
            string header = "UserName,Fecha,NombreAlimento,CantidadGramos,Calorias";
            var rows = new List<string> { header };

            foreach (var menu in _menus)
            {
                foreach (var item in menu.Items)
                {
                    rows.Add(string.Format(
                        System.Globalization.CultureInfo.InvariantCulture,
                        "{0},{1:yyyy-MM-dd},{2},{3},{4}",
                        menu.UserName,
                        menu.Fecha,
                        item.NombreAlimento,
                        item.CantidadGramos,
                        item.Calorias));
                }
            }

            File.WriteAllLines(_filePath, rows);
        }
    }
}
