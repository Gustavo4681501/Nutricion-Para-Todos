using System;
using System.Globalization;

namespace NutricionApp.Models
{
    /// <summary>
    /// Represents the nutritional goal of a user.
    /// </summary>
    public enum ObjetivoNutricional
    {
        Mantener,
        PerderPeso,
        GanarMasa
    }

    /// <summary>
    /// Represents a user's nutritional profile, including personal data
    /// and methods to calculate health-related metrics.
    /// </summary>
    public class Perfil
    {
        /// <summary>
        /// Gets or sets the username associated with this profile.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the user's age in years.
        /// </summary>
        public int Edad { get; set; }

        /// <summary>
        /// Gets or sets the user's weight in kilograms.
        /// </summary>
        public double PesoKg { get; set; }

        /// <summary>
        /// Gets or sets the user's height in centimeters.
        /// </summary>
        public double AlturaCm { get; set; }

        /// <summary>
        /// Gets or sets the user's goal.
        /// </summary>
        public ObjetivoNutricional Objetivo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Perfil"/> class
        /// with default values.
        /// </summary>
        /// <param name="userName">The username associated with this profile.</param>
        public Perfil(string userName)
        {
            UserName = userName;
            Edad = 25;
            PesoKg = 70.0;
            AlturaCm = 170.0;
            Objetivo = ObjetivoNutricional.Mantener;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Perfil"/> class
        /// from a CSV row.
        /// </summary>
        /// <param name="fila">Array of values read from a CSV file.</param>
        /// <exception cref="FormatException">
        /// Thrown when one of the values cannot be parsed correctly.
        /// </exception>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when the CSV row does not contain the expected number of elements.
        /// </exception>
        public Perfil(string[] fila)
        {
            UserName = fila[0].Trim();
            Edad = int.Parse(fila[1].Trim());
            PesoKg = double.Parse(fila[2].Trim(), CultureInfo.InvariantCulture);
            AlturaCm = double.Parse(fila[3].Trim(), CultureInfo.InvariantCulture);
            Objetivo = (ObjetivoNutricional)Enum.Parse(typeof(ObjetivoNutricional), fila[4].Trim());
        }

        /// <summary>
        /// Calculates the recommended daily calorie intake using a simplified
        /// Harris-Benedict formula and adjusts it based on the user's goal.
        /// </summary>
        /// <returns>The recommended daily calories (kcal).</returns>
        public double CaloriasRecomendadas()
        {
            // Basal Metabolic Rate
            double tmb = 10 * PesoKg + 6.25 * AlturaCm - 5 * Edad + 5;

            double tdee = tmb * 1.55;

            switch (Objetivo)
            {
                case ObjetivoNutricional.PerderPeso: return tdee - 500;
                case ObjetivoNutricional.GanarMasa: return tdee + 300;
                default: return tdee;
            }
        }

        /// <summary>
        /// Calculates the Body Mass Index (BMI) of the user.
        /// </summary>
        /// <returns>The BMI value.</returns>
        public double IMC()
        {
            double alturaM = AlturaCm / 100.0;
            return PesoKg / (alturaM * alturaM);
        }

        /// <summary>
        /// Serializes the profile into a CSV formatted string.
        /// </summary>
        /// <returns>A CSV representation of the profile.</returns>
        public string ToCsv()
        {
            return string.Format(CultureInfo.InvariantCulture,
                "{0},{1},{2},{3},{4}",
                UserName, Edad, PesoKg, AlturaCm, Objetivo);
        }
    }
}