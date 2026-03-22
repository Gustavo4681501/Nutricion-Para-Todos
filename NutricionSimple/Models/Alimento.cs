using System;
using System.Globalization;

namespace NutricionApp.Models
{
    public class Alimento
    {
        public int    Id            { get; set; }
        public string Nombre        { get; set; }
        public double Calorias      { get; set; }
        public double Proteinas     { get; set; }
        public double Carbohidratos { get; set; }
        public double Grasas        { get; set; }
        public double PorcionGramos { get; set; }
        public string Categoria     { get; set; }

        public Alimento() { }

        public Alimento(int id, string nombre, double calorias, double proteinas,
            double carbohidratos, double grasas, double porcion, string categoria)
        {
            Id            = id;
            Nombre        = nombre;
            Calorias      = calorias;
            Proteinas     = proteinas;
            Carbohidratos = carbohidratos;
            Grasas        = grasas;
            PorcionGramos = porcion;
            Categoria     = categoria;
        }

        public string ToCsv()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                Id, Nombre, Calorias, Proteinas, Carbohidratos, Grasas, PorcionGramos, Categoria);
        }

        public static Alimento FromCsv(string linea)
        {
            var p = linea.Split(',');
            return new Alimento
            {
                Id            = int.Parse(p[0].Trim()),
                Nombre        = p[1].Trim(),
                Calorias      = double.Parse(p[2].Trim(), CultureInfo.InvariantCulture),
                Proteinas     = double.Parse(p[3].Trim(), CultureInfo.InvariantCulture),
                Carbohidratos = double.Parse(p[4].Trim(), CultureInfo.InvariantCulture),
                Grasas        = double.Parse(p[5].Trim(), CultureInfo.InvariantCulture),
                PorcionGramos = double.Parse(p[6].Trim(), CultureInfo.InvariantCulture),
                Categoria     = p[7].Trim()
            };
        }

        public double CaloriasParaCantidad(double g)     => (Calorias      / PorcionGramos) * g;
        public double ProteinasParaCantidad(double g)    => (Proteinas     / PorcionGramos) * g;
        public double CarbsParaCantidad(double g)        => (Carbohidratos / PorcionGramos) * g;
        public double GrasasParaCantidad(double g)       => (Grasas        / PorcionGramos) * g;

        public override string ToString() => Nombre;
    }
}
