using System;
using System.Collections.Generic;

namespace NutricionApp.Models
{
    /// <summary>
    /// Represents a menu associated with a user and a specific date, containing a collection of menu items.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Gets or sets the user name associated with the current instance.
        /// </summary>
        public string UserName { get; set; }

       /// <summary>
       /// Gets or sets the date associated with the current instance.
       /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Gets or sets the collection of menu items displayed in the menu.
        /// </summary>
        public List<ItemMenu> Items { get; set; }

     /// <summary>
     /// Initializes a new instance of the Menu class with the specified user name and date.
     /// </summary>
     /// <param name="userName">The name of the user associated with the menu. Cannot be null.</param>
     /// <param name="fecha">The date for which the menu is created.</param>
        public Menu(string userName, DateTime fecha)
        {
            UserName = userName;
            Fecha    = fecha;
            Items    = new List<ItemMenu>();
        }

        /// <summary>
        /// Calculates the total number of calories for all items in the collection.
        /// </summary>
        /// <returns>The sum of the calories for all items. Returns 0 if the collection is empty.</returns>
        public double TotalCalorias()
        {
            double total = 0;
            foreach (var item in Items)
                total += item.Calorias;
            return total;
        }
    }

    /// <summary>
    /// Represents a menu item that records a specific food, the amount consumed in grams, and the corresponding calorie
    /// value.
    /// </summary>
    public class ItemMenu
    {
        /// <summary>
        /// Gets or sets the name of the food item.
        /// </summary>
        public string NombreAlimento { get; set; }

        /// <summary>
        /// Gets or sets the quantity in grams.
        /// </summary>
        public double CantidadGramos { get; set; }

        /// <summary>
        /// Gets or sets the number of calories associated with the item.
        /// </summary>
        public double Calorias { get; set; }

        /// <summary>
        /// Initializes a new instance of the ItemMenu class with the specified food name, weight in grams, and calorie
        /// count.
        /// </summary>
        /// <param name="nombreAlimento">The name of the food item to include in the menu. Cannot be null or empty.</param>
        /// <param name="cantidadGramos">The weight of the food item, in grams. Must be a non-negative value.</param>
        /// <param name="calorias">The number of calories contained in the specified amount of the food item. Must be a non-negative value.</param>
        public ItemMenu(string nombreAlimento, double cantidadGramos, double calorias)
        {
            NombreAlimento = nombreAlimento;
            CantidadGramos = cantidadGramos;
            Calorias       = calorias;
        }
    }
}
