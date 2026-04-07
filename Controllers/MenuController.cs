using System;
using System.Collections.Generic;
using System.IO;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Manages user menus: loading, retrieving, adding, and deleting entries persisted in a CSV file.
    /// The CSV now stores macronutrients (Proteinas, Carbohidratos, Grasas) per item in addition to calories.
    /// </summary>
    public class MenuController : IMenuController
    {
        private readonly List<Menu> _menus;
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of MenuController and loads all menu data from the CSV file.
        /// </summary>
        /// <param name="filePath">Path to the menus CSV file. Cannot be null or empty.</param>
        public MenuController(string filePath)
        {
            _filePath = filePath;
            _menus = LoadMenus();
        }

        /// <summary>
        /// Returns all menus for the specified user, sorted by most recent date first.
        /// </summary>
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
        /// Adds a menu to the collection and persists the change.
        /// </summary>
        public void Guardar(Menu menu)
        {
            _menus.Add(menu);
            SaveMenus();
        }

        /// <summary>
        /// Removes the menu at the given index (within the user's own list) and persists the change.
        /// </summary>
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

                string userName = parts[0].Trim();
                DateTime fecha;
                if (!DateTime.TryParse(parts[1].Trim(), out fecha))
                    continue;

                string nombreAlimento = parts[2].Trim();

                double cantidad, calorias;
                if (!TryParseDouble(parts[3], out cantidad)) continue;
                if (!TryParseDouble(parts[4], out calorias)) continue;

                double proteinas = parts.Length > 5 ? ParseDoubleOrZero(parts[5]) : 0;
                double carbohidratos = parts.Length > 6 ? ParseDoubleOrZero(parts[6]) : 0;
                double grasas = parts.Length > 7 ? ParseDoubleOrZero(parts[7]) : 0;

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

                menu.Items.Add(new ItemMenu(nombreAlimento, cantidad, calorias, proteinas, carbohidratos, grasas));
            }

            return lista;
        }

        private void SaveMenus()
        {
            string header = "UserName,Fecha,NombreAlimento,CantidadGramos,Calorias,Proteinas,Carbohidratos,Grasas";
            var rows = new List<string> { header };

            foreach (var menu in _menus)
            {
                foreach (var item in menu.Items)
                {
                    rows.Add(string.Format(
                        System.Globalization.CultureInfo.InvariantCulture,
                        "{0},{1:yyyy-MM-dd},{2},{3},{4},{5},{6},{7}",
                        menu.UserName,
                        menu.Fecha,
                        item.NombreAlimento,
                        item.CantidadGramos,
                        item.Calorias,
                        item.Proteinas,
                        item.Carbohidratos,
                        item.Grasas));
                }
            }

            File.WriteAllLines(_filePath, rows);
        }

        private static bool TryParseDouble(string s, out double result)
        {
            return double.TryParse(s.Trim(),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out result);
        }

        private static double ParseDoubleOrZero(string s)
        {
            double v;
            return TryParseDouble(s, out v) ? v : 0;
        }
    }
}