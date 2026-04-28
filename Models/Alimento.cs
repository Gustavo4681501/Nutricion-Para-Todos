namespace NutricionApp.Models
{
    /// <summary>
    /// Representa un alimento con información nutricional como calorías, proteínas, carbohidratos, grasas y tamaño de porción por porción.
    /// </summary>
   
    public class Alimento
    {
        /// <summary>
        /// Obtiene o establece el nombre asociado con la entidad.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el número total de calorías asociadas con el elemento.
        /// </summary>
        public double Calorias { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de proteínas, en gramos, contenida en el alimento.
        /// </summary>
        public double Proteinas { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad total de carbohidratos, en gramos, contenida en el alimento.
        /// </summary>
        
        public double Carbohidratos { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de grasas, en gramos, contenida en el alimento.
        /// </summary>
        
        public double Grasas { get; set; }

        /// <summary>
        /// Obtiene o establece el tamaño de la porción representado como un valor double.
        /// </summary>
        public double Porcion { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Alimento con la información nutricional especificada y el tamaño de la porción.
        /// </summary>
        
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
       /// Inicializa una nueva instancia de la clase Alimento utilizando el array especificado de valores nutricionales.
       /// </summary>
      
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
        /// Convierte los valores de las propiedades del objeto a una cadena de valores separados por comas (CSV).
        /// </summary>
        
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
