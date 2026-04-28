using NutricionApp.Views;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NutricionApp.Models
{
    /// <summary>
    /// Representa un menú diario asociado a un usuario, que contiene una lista de alimentos consumidos.
    /// Iteracion 2: agrega Id para identificar el registro en la base de datos.
    /// </summary>
    public class Menu
    {
        /// <summary>Identificador unico del menu en la base de datos.</summary>
        public int Id { get; set; }

        /// <summary>Obtiene o establece el nombre de usuario asociado con este menú.</summary>
        public string UserName { get; set; }

        /// <summary>Obtiene o establece la fecha en que se registró este menú.</summary>
        public DateTime Fecha { get; set; }

        /// <summary>Obtiene o establece la lista de alimentos en este menú.</summary>
        public List<ItemMenu> Items { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Menu con el usuario y la fecha especificados.
        /// </summary>
        public Menu(string userName, DateTime fecha)
        {
            UserName = userName;
            Fecha    = fecha;
            Items    = new List<ItemMenu>();
        }

        /// <summary>Devuelve el total de calorías consumidas en este menú.</summary>
        public double TotalCalorias()
        {
            double total = 0;
            foreach (var item in Items)
                total += item.Calorias;
            return total;
        }

        /// <summary>Devuelve el total de proteínas consumidas en este menú (gramos).</summary>
        public double TotalProteinas()
        {
            double total = 0;
            foreach (var item in Items)
                total += item.Proteinas;
            return total;
        }

        /// <summary>Devuelve el total de carbohidratos consumidos en este menú (gramos).</summary>
        public double TotalCarbohidratos()
        {
            double total = 0;
            foreach (var item in Items)
                total += item.Carbohidratos;
            return total;
        }

        /// <summary>Devuelve el total de grasas consumidas en este menú (gramos).</summary>
        public double TotalGrasas()
        {
            double total = 0;
            foreach (var item in Items)
                total += item.Grasas;
            return total;
        }
    }

    /// <summary>
    /// Representa una entrada de alimento individual en un menú, incluyendo sus valores de macronutrientes
    /// calculados proporcionalmente a la cantidad consumida.
    /// </summary>
    public class ItemMenu
    {
        /// <summary>Obtiene o establece el nombre del alimento.</summary>
        public string NombreAlimento { get; set; }

        /// <summary>Obtiene o establece la cantidad consumida en gramos.</summary>
        public double CantidadGramos { get; set; }

        /// <summary>Obtiene o establece las calorías para la cantidad consumida (kcal).</summary>
        public double Calorias { get; set; }

        /// <summary>Obtiene o establece las proteínas para la cantidad consumida (g).</summary>
        public double Proteinas { get; set; }

        /// <summary>Obtiene o establece los carbohidratos para la cantidad consumida (g).</summary>
        public double Carbohidratos { get; set; }

        /// <summary>Obtiene o establece las grasas para la cantidad consumida (g).</summary>
        public double Grasas { get; set; }

        /// <summary>
        /// Inicializa un ItemMenu con datos completos de macronutrientes.
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
        /// Inicializa un ItemMenu compatible con versiones anteriores que solo almacena calorías (los macronutrientes se establecen en 0 por defecto).
        /// </summary>
        public ItemMenu(string nombreAlimento, double cantidadGramos, double calorias)
            : this(nombreAlimento, cantidadGramos, calorias, 0, 0, 0)
        {
        }
    }
}
