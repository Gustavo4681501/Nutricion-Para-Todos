using System;
using System.Globalization;

namespace NutricionApp.Models
{
    /// <summary>
    /// Representa el objetivo nutricional de un usuario.
    /// </summary>
    public enum ObjetivoNutricional
    {
        Mantener,
        PerderPeso,
        GanarMasa
    }

    /// <summary>
    /// Representa el nivel de actividad física de un usuario,
    /// utilizado para ajustar el cálculo de calorías diarias (TDEE).
    /// </summary>
    public enum NivelActividad
    {
        Sedentario,      // Poco o ningún ejercicio
        Ligero,          // Ejercicio ligero 1-3 días/semana
        Moderado,        // Ejercicio moderado 3-5 días/semana
        Activo,          // Ejercicio intenso 6-7 días/semana
        MuyActivo        // Ejercicio muy intenso o trabajo físico
    }

    /// <summary>
    /// Representa el tipo de dieta seguida por el usuario,
    /// lo que influye en las recomendaciones de distribución de macronutrientes.
    /// </summary>
    public enum TipoDieta
    {
        Estandar,
        Keto,
        Vegetariano
    }

    /// <summary>
    /// Representa el perfil nutricional de un usuario, incluyendo datos personales
    /// y métodos para calcular métricas relacionadas con la salud.
    /// </summary>
    public class Perfil
    {
        /// <summary>Obtiene o establece el nombre de usuario asociado con este perfil.</summary>
        public string UserName { get; set; }

        /// <summary>Obtiene o establece la edad del usuario en años.</summary>
        public int Edad { get; set; }

        /// <summary>Obtiene o establece el peso del usuario en kilogramos.</summary>
        public double PesoKg { get; set; }

        /// <summary>Obtiene o establece la altura del usuario en centímetros.</summary>
        public double AlturaCm { get; set; }

        /// <summary>Obtiene o establece el objetivo nutricional del usuario.</summary>
        public ObjetivoNutricional Objetivo { get; set; }

        /// <summary>Obtiene o establece el nivel de actividad física del usuario.</summary>
        public NivelActividad Actividad { get; set; }

        /// <summary>Obtiene o establece el tipo de dieta que sigue el usuario.</summary>
        public TipoDieta Dieta { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Perfil"/> con valores predeterminados.
        /// </summary>
        /// <param name="userName">El nombre de usuario asociado con este perfil.</param>
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
        /// Inicializa una nueva instancia de la clase <see cref="Perfil"/> a partir de una fila de CSV.
        /// Soporta tanto el formato antiguo (5 columnas) como el nuevo (7 columnas) para compatibilidad hacia atrás.
        /// </summary>
       
        public Perfil(string[] fila)
        {
            UserName = fila[0].Trim();
            Edad = int.Parse(fila[1].Trim());
            PesoKg = double.Parse(fila[2].Trim(), CultureInfo.InvariantCulture);
            AlturaCm = double.Parse(fila[3].Trim(), CultureInfo.InvariantCulture);
            Objetivo = (ObjetivoNutricional)Enum.Parse(typeof(ObjetivoNutricional), fila[4].Trim());

            // Compatibilidad hacia atrás: si el CSV antiguo solo tenía 5 columnas, usar valores predeterminados
            Actividad = fila.Length > 5
                ? (NivelActividad)Enum.Parse(typeof(NivelActividad), fila[5].Trim())
                : NivelActividad.Moderado;

            Dieta = fila.Length > 6
                ? (TipoDieta)Enum.Parse(typeof(TipoDieta), fila[6].Trim())
                : TipoDieta.Estandar;
        }

        /// <summary>
        /// Devuelve el multiplicador de actividad (PAL) correspondiente al nivel de actividad del usuario.
        /// Basado en los factores de actividad de Harris-Benedict / Mifflin-St Jeor.
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
        /// Calcula la ingesta diaria recomendada de calorías utilizando la fórmula de Mifflin-St Jeor,
        /// ajustada por el nivel de actividad del usuario y el objetivo nutricional.
        /// </summary>
        
        public double CaloriasRecomendadas()
        {
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
        /// Devuelve la distribución recomendada de macronutrientes en gramos según el tipo de dieta.
        /// Los valores son proporcionales a las calorías diarias totales.
        /// Devuelve una tupla: (proteinasG, carbohidratosG, grasasG).
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
        /// Calcula el Índice de Masa Corporal (IMC) utilizando el peso actual en kilogramos y la altura en centímetros.
        /// </summary>
        
        public double IMC()
        {
            double alturaM = AlturaCm / 100.0;
            return PesoKg / (alturaM * alturaM);
        }

        /// <summary>
        /// Convierte los datos del perfil a una cadena de valores separados por comas (CSV).
        /// </summary>
        
        public string ToCsv()
        {
            return string.Format(CultureInfo.InvariantCulture,
                "{0},{1},{2},{3},{4},{5},{6}",
                UserName, Edad, PesoKg, AlturaCm, Objetivo, Actividad, Dieta);
        }
    }
}