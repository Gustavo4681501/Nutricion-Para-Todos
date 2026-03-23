namespace NutricionApp.Models
{
    /// <summary>
    /// Representa un alimento del catalogo con sus valores nutricionales por porcion.
    /// </summary>
    public class Alimento
    {
        /// <summary>Obtiene o establece el nombre del alimento.</summary>
        public string Nombre { get; set; }

        /// <summary>Obtiene o establece las calorias por porcion en kcal.</summary>
        public double Calorias { get; set; }

        /// <summary>Obtiene o establece los gramos de proteina por porcion.</summary>
        public double Proteinas { get; set; }

        /// <summary>Obtiene o establece los gramos de carbohidratos por porcion.</summary>
        public double Carbohidratos { get; set; }

        /// <summary>Obtiene o establece los gramos de grasa por porcion.</summary>
        public double Grasas { get; set; }

        /// <summary>Obtiene o establece el tamano de la porcion de referencia en gramos.</summary>
        public double Porcion { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Alimento"/> con todos sus valores.
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
        /// Inicializa una nueva instancia de <see cref="Alimento"/> a partir de una fila CSV.
        /// </summary>
        /// <param name="fila">Arreglo de valores leidos del archivo CSV.</param>
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
        /// Serializa el alimento a una linea en formato CSV.
        /// </summary>
        public string ToCsv()
        {
            return string.Format(
                System.Globalization.CultureInfo.InvariantCulture,
                "{0},{1},{2},{3},{4},{5}",
                Nombre, Calorias, Proteinas, Carbohidratos, Grasas, Porcion);
        }

        /// <inheritdoc/>
        public override string ToString() => Nombre;
    }
}
