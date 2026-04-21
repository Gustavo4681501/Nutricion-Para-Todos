using System;
using System.Collections.Generic;

namespace NutricionApp.Models
{
    /// <summary>
    /// Represents a daily menu associated with a user, containing a list of food items consumed.
    /// Iteracion 2: agrega Id para identificar el registro en la base de datos.
    /// </summary>
    public class Menu
    {
        /// <summary>Identificador unico del menu en la base de datos.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the username associated with this menu.</summary>
        public string UserName { get; set; }

        /// <summary>Gets or sets the date this menu was registered.</summary>
        public DateTime Fecha { get; set; }

        /// <summary>Gets or sets the list of food items in this menu.</summary>
        public List<ItemMenu> Items { get; set; }

        /// <summary>
        /// Initializes a new instance of the Menu class with the specified user and date.
        /// </summary>
        public Menu(string userName, DateTime fecha)
        {
            UserName = userName;
            Fecha    = fecha;
            Items    = new List<ItemMenu>();
        }

        /// <summary>Returns the total calories consumed in this menu.</summary>
        public double TotalCalorias()
        {
            double total = 0;
            foreach (var item in Items)
                total += item.Calorias;
            return total;
        }

        /// <summary>Returns the total proteins consumed in this menu (grams).</summary>
        public double TotalProteinas()
        {
            double total = 0;
            foreach (var item in Items)
                total += item.Proteinas;
            return total;
        }

        /// <summary>Returns the total carbohydrates consumed in this menu (grams).</summary>
        public double TotalCarbohidratos()
        {
            double total = 0;
            foreach (var item in Items)
                total += item.Carbohidratos;
            return total;
        }

        /// <summary>Returns the total fats consumed in this menu (grams).</summary>
        public double TotalGrasas()
        {
            double total = 0;
            foreach (var item in Items)
                total += item.Grasas;
            return total;
        }
    }

    /// <summary>
    /// Represents a single food item entry in a menu, including its macronutrient values
    /// calculated proportionally to the consumed quantity.
    /// </summary>
    public class ItemMenu
    {
        /// <summary>Gets or sets the name of the food item.</summary>
        public string NombreAlimento { get; set; }

        /// <summary>Gets or sets the quantity consumed in grams.</summary>
        public double CantidadGramos { get; set; }

        /// <summary>Gets or sets the calories for the consumed quantity (kcal).</summary>
        public double Calorias { get; set; }

        /// <summary>Gets or sets the proteins for the consumed quantity (g).</summary>
        public double Proteinas { get; set; }

        /// <summary>Gets or sets the carbohydrates for the consumed quantity (g).</summary>
        public double Carbohidratos { get; set; }

        /// <summary>Gets or sets the fats for the consumed quantity (g).</summary>
        public double Grasas { get; set; }

        /// <summary>
        /// Initializes an ItemMenu with full macronutrient data.
        /// </summary>
        public ItemMenu(string nombreAlimento, double cantidadGramos,
            double calorias, double proteinas, double carbohidratos, double grasas)
        {
            NombreAlimento = nombreAlimento;
            CantidadGramos = cantidadGramos;
            Calorias       = calorias;
            Proteinas      = proteinas;
            Carbohidratos  = carbohidratos;
            Grasas         = grasas;
        }

        /// <summary>
        /// Backward-compatible constructor that only stores calories (macros default to 0).
        /// </summary>
        public ItemMenu(string nombreAlimento, double cantidadGramos, double calorias)
            : this(nombreAlimento, cantidadGramos, calorias, 0, 0, 0)
        {
        }
    }
}
