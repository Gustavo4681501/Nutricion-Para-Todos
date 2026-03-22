using System;
using System.Collections.Generic;
using System.Linq;
using NutricionApp.Data;
using NutricionApp.Models;
using NutricionApp.Utils;

namespace NutricionApp.Controllers
{
    public class ResumenDia
    {
        public DateTime Fecha { get; set; }
        public double CaloriasConsumidas { get; set; }
        public double ProteinasConsumidas { get; set; }
        public double CarbsConsumidos { get; set; }
        public double GrasasConsumidas { get; set; }
        public double MetaCalorias { get; set; }
        public double MetaProteinas { get; set; }
        public double MetaCarbs { get; set; }
        public double MetaGrasas { get; set; }

        public double DiferenciaCalorias => MetaCalorias - CaloriasConsumidas;
        public double PorcentajeCalorias  => MetaCalorias > 0 ? (CaloriasConsumidas / MetaCalorias) * 100 : 0;
        public bool   MetaCumplida        => CaloriasConsumidas >= MetaCalorias * 0.9 &&
                                             CaloriasConsumidas <= MetaCalorias * 1.1;
    }

    public class ResumenMes
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int DiasCumplidos { get; set; }
        public int TotalDiasRegistrados { get; set; }
        public double PromedioCaloriasdiario { get; set; }
        public double PromedioProteinasDiario { get; set; }
        public double PromedioCarbsDiario { get; set; }
        public double PromedioGrasasDiario { get; set; }
    }

    public class EstadisticasController
    {
        private readonly NutricionContext    _ctx  = NutricionContext.Instancia;
        private readonly MenuController _mCtrl = new MenuController();

        public ResumenDia ObtenerResumenDia(int usuarioId, DateTime fecha)
        {
            var usuario = _ctx.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
            if (usuario == null) throw new Exception("Usuario no encontrado.");

            var menu    = _mCtrl.ObtenerPorFechaYUsuario(usuarioId, fecha);
            var metas   = CalculadoraNutricional.DistribucionMacros(usuario);
            double metaCal = CalculadoraNutricional.CalcularCaloriasObjetivo(usuario);

            return new ResumenDia
            {
                Fecha               = fecha,
                CaloriasConsumidas  = menu?.TotalCalorias      ?? 0,
                ProteinasConsumidas = menu?.TotalProteinas     ?? 0,
                CarbsConsumidos     = menu?.TotalCarbohidratos ?? 0,
                GrasasConsumidas    = menu?.TotalGrasas        ?? 0,
                MetaCalorias        = metaCal,
                MetaProteinas       = metas.protG,
                MetaCarbs           = metas.carbG,
                MetaGrasas          = metas.grasaG
            };
        }

        public ResumenMes ObtenerResumenMes(int usuarioId, int anio, int mes)
        {
            var inicio = new DateTime(anio, mes, 1);
            var fin    = inicio.AddMonths(1).AddDays(-1);
            var menus  = _mCtrl.ObtenerPorRangoFechas(usuarioId, inicio, fin);

            var usuario = _ctx.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
            double metaCal = CalculadoraNutricional.CalcularCaloriasObjetivo(usuario);

            int diasCumplidos = menus.Count(m =>
                m.TotalCalorias >= metaCal * 0.9 && m.TotalCalorias <= metaCal * 1.1);

            return new ResumenMes
            {
                Anio                    = anio,
                Mes                     = mes,
                DiasCumplidos           = diasCumplidos,
                TotalDiasRegistrados    = menus.Count,
                PromedioCaloriasdiario  = menus.Count > 0 ? menus.Average(m => m.TotalCalorias)      : 0,
                PromedioProteinasDiario = menus.Count > 0 ? menus.Average(m => m.TotalProteinas)     : 0,
                PromedioCarbsDiario     = menus.Count > 0 ? menus.Average(m => m.TotalCarbohidratos) : 0,
                PromedioGrasasDiario    = menus.Count > 0 ? menus.Average(m => m.TotalGrasas)        : 0
            };
        }

        /// Retorna lista de resumenes diarios para graficar en el rango
        public List<ResumenDia> ObtenerHistorialDiario(int usuarioId, DateTime inicio, DateTime fin)
        {
            var resultado = new List<ResumenDia>();
            for (var d = inicio.Date; d <= fin.Date; d = d.AddDays(1))
                resultado.Add(ObtenerResumenDia(usuarioId, d));
            return resultado;
        }
    }
}
