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
    /// Represents the physical activity level of a user,
    /// used to adjust the daily calorie calculation (TDEE).
    /// </summary>
    public enum NivelActividad
    {
        Sedentario,      // Little or no exercise
        Ligero,          // Light exercise 1-3 days/week
        Moderado,        // Moderate exercise 3-5 days/week
        Activo,          // Hard exercise 6-7 days/week
        MuyActivo        // Very hard exercise or physical job
    }

    /// <summary>
    /// Represents the type of diet followed by the user,
    /// which influences macronutrient distribution recommendations.
    /// </summary>
    public enum TipoDieta
    {
        Estandar,
        Keto,
        Vegetariano
    }

    /// <summary>
    /// Represents a user's nutritional profile, including personal data
    /// and methods to calculate health-related metrics.
    /// </summary>
    public class Perfil
    {
        /// <summary>Gets or sets the username associated with this profile.</summary>
        public string UserName { get; set; }

        /// <summary>Gets or sets the user's age in years.</summary>
        public int Edad { get; set; }

        /// <summary>Gets or sets the user's weight in kilograms.</summary>
        public double PesoKg { get; set; }

        /// <summary>Gets or sets the user's height in centimeters.</summary>
        public double AlturaCm { get; set; }

        /// <summary>Gets or sets the user's nutritional goal.</summary>
        public ObjetivoNutricional Objetivo { get; set; }

        /// <summary>Gets or sets the user's physical activity level.</summary>
        public NivelActividad Actividad { get; set; }

        /// <summary>Gets or sets the type of diet the user follows.</summary>
        public TipoDieta Dieta { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Perfil"/> class with default values.
        /// </summary>
        /// <param name="userName">The username associated with this profile.</param>
        public Perfil(string userName)
        {
            UserName = userName;
            Edad = 25;
            PesoKg = 70.0;
            AlturaCm = 170.0;
            Objetivo = ObjetivoNutricional.Mantener;
            Actividad = NivelActividad.Moderado;
            Dieta = TipoDieta.Estandar;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Perfil"/> class from a CSV row.
        /// Supports both old format (5 columns) and new format (7 columns) for backward compatibility.
        /// </summary>
        /// <param name="fila">Array of values read from a CSV file.</param>
        public Perfil(string[] fila)
        {
            UserName = fila[0].Trim();
            Edad = int.Parse(fila[1].Trim());
            PesoKg = double.Parse(fila[2].Trim(), CultureInfo.InvariantCulture);
            AlturaCm = double.Parse(fila[3].Trim(), CultureInfo.InvariantCulture);
            Objetivo = (ObjetivoNutricional)Enum.Parse(typeof(ObjetivoNutricional), fila[4].Trim());

            // Backward compatibility: if old CSV only had 5 columns, use defaults
            Actividad = fila.Length > 5
                ? (NivelActividad)Enum.Parse(typeof(NivelActividad), fila[5].Trim())
                : NivelActividad.Moderado;

            Dieta = fila.Length > 6
                ? (TipoDieta)Enum.Parse(typeof(TipoDieta), fila[6].Trim())
                : TipoDieta.Estandar;
        }

        /// <summary>
        /// Returns the activity multiplier (PAL) corresponding to the user's activity level.
        /// Based on the Harris-Benedict / Mifflin-St Jeor activity factors.
        /// </summary>
        private double FactorActividad()
        {
            switch (Actividad)
            {
                case NivelActividad.Sedentario: return 1.2;
                case NivelActividad.Ligero: return 1.375;
                case NivelActividad.Moderado: return 1.55;
                case NivelActividad.Activo: return 1.725;
                case NivelActividad.MuyActivo: return 1.9;
                default: return 1.55;
            }
        }

        /// <summary>
        /// Calculates the recommended daily calorie intake using the Mifflin-St Jeor formula,
        /// adjusted by the user's activity level and nutritional goal.
        /// </summary>
        /// <returns>The recommended daily calories (kcal).</returns>
        public double CaloriasRecomendadas()
        {
            // Mifflin-St Jeor BMR (assuming male formula; can be extended with gender field)
            double tmb = 10 * PesoKg + 6.25 * AlturaCm - 5 * Edad + 5;
            double tdee = tmb * FactorActividad();

            switch (Objetivo)
            {
                case ObjetivoNutricional.PerderPeso: return tdee - 500;
                case ObjetivoNutricional.GanarMasa: return tdee + 300;
                default: return tdee;
            }
        }

        /// <summary>
        /// Returns the recommended macronutrient distribution in grams based on the diet type.
        /// Values are proportional to the total daily calories.
        /// Returns a tuple: (proteinasG, carbohidratosG, grasasG).
        /// </summary>
        public (double Proteinas, double Carbohidratos, double Grasas) MacrosRecomendados()
        {
            double calorias = CaloriasRecomendadas();

            double pctProt, pctCarb, pctGrasa;

            switch (Dieta)
            {
                case TipoDieta.Keto:
                    pctProt = 0.25;
                    pctCarb = 0.05;
                    pctGrasa = 0.70;
                    break;

                case TipoDieta.Vegetariano:
                    pctProt = 0.15;
                    pctCarb = 0.60;
                    pctGrasa = 0.25;
                    break;

                default:
                    pctProt = 0.30;
                    pctCarb = 0.45;
                    pctGrasa = 0.25;
                    break;
            }

            double proteinasG = (calorias * pctProt) / 4.0;
            double carbohidratosG = (calorias * pctCarb) / 4.0;
            double grasasG = (calorias * pctGrasa) / 9.0;

            return (proteinasG, carbohidratosG, grasasG);
        }

        /// <summary>
        /// Calculates the Body Mass Index (BMI) using the current weight in kilograms and height in centimeters.
        /// </summary>
        /// <remarks>Height is converted from centimeters to meters before calculation. Ensure that both
        /// weight and height are set to valid, positive values to obtain an accurate BMI result.</remarks>
        /// <returns>The BMI value as a double, representing the ratio of weight to height squared (kg/m²).</returns>
        public double IMC()
        {
            double alturaM = AlturaCm / 100.0;
            return PesoKg / (alturaM * alturaM);
        }

        /// <summary>
        /// Converts the profile data to a comma-separated values (CSV) formatted string.
        /// </summary>
        /// <remarks>The returned CSV string uses invariant culture formatting to ensure consistent number
        /// formatting regardless of locale.</remarks>
        /// <returns>A string containing the user name, age, weight in kilograms, height in centimeters, goal, activity level,
        /// and diet, separated by commas.</returns>
        public string ToCsv()
        {
            return string.Format(CultureInfo.InvariantCulture,
                "{0},{1},{2},{3},{4},{5},{6}",
                UserName, Edad, PesoKg, AlturaCm, Objetivo, Actividad, Dieta);
        }
    }
}