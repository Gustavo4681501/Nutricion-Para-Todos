using System;
using NutricionApp.Models;

namespace NutricionApp.Utils
{
    public static class CalculadoraNutricional
    {
        // Tasa Metabolica Basal — formula Mifflin-St Jeor
        public static double CalcularTMB(Usuario u)
        {
            if (u.Sexo == Sexo.Masculino)
                return (10 * u.Peso) + (6.25 * u.Altura) - (5 * u.Edad) + 5;
            else
                return (10 * u.Peso) + (6.25 * u.Altura) - (5 * u.Edad) - 161;
        }

        public static double CalcularTDEE(Usuario u)
        {
            double tmb = CalcularTMB(u);
            double factor = ObtenerFactorActividad(u.NivelActividad);
            return tmb * factor;
        }

        // Objetivo calorico ajustado segun meta
        public static double CalcularCaloriasObjetivo(Usuario u)
        {
            double tdee = CalcularTDEE(u);
            switch (u.Objetivo)
            {
                case ObjetivoUsuario.PerderGrasa: return tdee - 500;
                case ObjetivoUsuario.GanarMasa:   return tdee + 300;
                default:                          return tdee;
            }
        }

        public static double CalcularIMC(Usuario u)
        {
            double alturaM = u.Altura / 100.0;
            return u.Peso / (alturaM * alturaM);
        }

        public static string ClasificacionIMC(double imc)
        {
            if (imc < 18.5) return "Bajo peso";
            if (imc < 25.0) return "Normal";
            if (imc < 30.0) return "Sobrepeso";
            return "Obesidad";
        }

        // Macros en gramos segun tipo de dieta
        // NOTA: este metodo mezcla la logica de los tres tipos en un solo lugar,
        // podria haberse separado en subclases pero por ahora funciona bien asi.
        public static (double protG, double carbG, double grasaG) DistribucionMacros(Usuario u)
        {
            double calorias = CalcularCaloriasObjetivo(u);

            double porcProt, porcCarb, porcGrasa;

            switch (u.TipoDieta)
            {
                case TipoDieta.Keto:
                    porcProt  = 0.25;
                    porcCarb  = 0.05;
                    porcGrasa = 0.70;
                    break;
                case TipoDieta.Vegetariano:
                    porcProt  = 0.15;
                    porcCarb  = 0.60;
                    porcGrasa = 0.25;
                    break;
                default: // Estandar
                    porcProt  = 0.30;
                    porcCarb  = 0.45;
                    porcGrasa = 0.25;
                    break;
            }

            double protG  = (calorias * porcProt)  / 4.0;
            double carbG  = (calorias * porcCarb)  / 4.0;
            double grasaG = (calorias * porcGrasa) / 9.0;

            return (Math.Round(protG,1), Math.Round(carbG,1), Math.Round(grasaG,1));
        }

        private static double ObtenerFactorActividad(NivelActividad nivel)
        {
            switch (nivel)
            {
                case NivelActividad.Sedentario:      return 1.2;
                case NivelActividad.LigeroActivo:    return 1.375;
                case NivelActividad.Moderadamente:   return 1.55;
                case NivelActividad.MuyActivo:       return 1.725;
                case NivelActividad.ExtraActivo:     return 1.9;
                default:                             return 1.2;
            }
        }
    }
}
