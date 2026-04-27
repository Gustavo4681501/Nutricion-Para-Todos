namespace NutricionApp.Models
{
    /// <summary>
    /// Represents a food item with nutritional information such as calories, protein, carbohydrates, fat, and serving
    /// size per portion.
    /// </summary>
    /// <remarks>The Alimento class provides a structured way to store and manipulate nutritional data for
    /// individual food items. It supports initialization from explicit values or from a CSV row, and can serialize its
    /// data back to CSV format for storage or interoperability. This class is useful for applications that need to
    /// track, display, or process nutritional information for various foods.</remarks>
    public class Alimento
    {
        /// <summary>
        /// Gets or sets the name associated with the entity.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the total number of calories associated with the item.
        /// </summary>
        /// <remarks>This property is used to track the caloric content of food items, which can be
        /// important for dietary management and nutritional analysis.</remarks>
        public double Calorias { get; set; }

        /// <summary>
        /// Gets or sets the amount of protein, in grams, contained in the food item.
        /// </summary>
        public double Proteinas { get; set; }

        /// <summary>
        /// Gets or sets the total amount of carbohydrates, in grams, contained in the food item.
        /// </summary>
        /// <remarks>This property is useful for tracking carbohydrate intake and performing nutritional
        /// analysis. The value should represent the sum of all carbohydrate sources present in the food item.</remarks>
        public double Carbohidratos { get; set; }

        /// <summary>
        /// Gets or sets the amount of fats, in grams, contained in the food item.
        /// </summary>
        /// <remarks>This property is used for nutritional analysis and dietary calculations. The value
        /// should represent the total fat content per serving or per specified quantity of the food item, as
        /// appropriate for the context.</remarks>
        public double Grasas { get; set; }

        /// <summary>
        /// Gets or sets the portion size represented as a double value.
        /// </summary>
        public double Porcion { get; set; }

        /// <summary>
        /// Initializes a new instance of the Alimento class with the specified nutritional information and serving
        /// size.
        /// </summary>
        /// <remarks>All nutritional values must be provided to accurately represent the food item. This
        /// constructor is intended for creating fully specified Alimento instances.</remarks>
        /// <param name="nombre">The name of the food item.</param>
        /// <param name="calorias">The total number of calories contained in the food item.</param>
        /// <param name="proteinas">The amount of protein, in grams, present in the food item.</param>
        /// <param name="carbohidratos">The amount of carbohydrates, in grams, present in the food item.</param>
        /// <param name="grasas">The amount of fat, in grams, present in the food item.</param>
        /// <param name="porcion">The serving size, in grams, for the food item.</param>
        public Alimento(string nombre, double calorias, double proteinas,
            double carbohidratos, double grasas, double porcion)
        {
            Nombre        = nombre;
            Calorias      = calorias;
            Proteinas     = proteinas;
            Carbohidratos = carbohidratos;
            Grasas        = grasas;
            Porcion       = porcion;
        }

       /// <summary>
       /// Initializes a new instance of the Alimento class using the specified array of nutritional values.
       /// </summary>
       /// <remarks>The array must contain exactly six elements, and each value should be formatted
       /// according to the invariant culture for correct parsing. If any element is missing or incorrectly formatted, a
       /// parsing exception may occur.</remarks>
       /// <param name="fila">An array of six strings representing the food item's name, calories, proteins, carbohydrates, fats, and
       /// portion size, in that order. Each element must be properly formatted for parsing.</param>
        public Alimento(string[] fila)
        {
            Nombre        = fila[0].Trim();
            Calorias      = double.Parse(fila[1].Trim(), System.Globalization.CultureInfo.InvariantCulture);
            Proteinas     = double.Parse(fila[2].Trim(), System.Globalization.CultureInfo.InvariantCulture);
            Carbohidratos = double.Parse(fila[3].Trim(), System.Globalization.CultureInfo.InvariantCulture);
            Grasas        = double.Parse(fila[4].Trim(), System.Globalization.CultureInfo.InvariantCulture);
            Porcion       = double.Parse(fila[5].Trim(), System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the values of the object's properties to a comma-separated values (CSV) formatted string.
        /// </summary>
        /// <returns>A string containing the values of Nombre, Calorias, Proteinas, Carbohidratos, Grasas, and Porcion, separated
        /// by commas.</returns>
        public string ToCsv()
        {
            return string.Format(
                System.Globalization.CultureInfo.InvariantCulture,
                "{0},{1},{2},{3},{4},{5}",
                Nombre, Calorias, Proteinas, Carbohidratos, Grasas, Porcion);
        }

        /// <summary> sobrescribe el metodo ToString para retornar el nombre del alimento, facilitando su visualizacion en listas o interfaces de usuario.</summary>
        public override string ToString() => Nombre;
    }
}
