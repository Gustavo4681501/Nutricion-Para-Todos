using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NutricionApp.Models
{
    public enum TiempoComida
    {
        Desayuno,
        MeriendaManana,
        Almuerzo,
        MeriendaTarde,
        Cena
    }

    public class ItemMenu
    {
        public int         AlimentoId     { get; set; }
        public string      NombreAlimento { get; set; }
        public double      CantidadGramos { get; set; }
        public TiempoComida TiempoComida  { get; set; }
        public double      Calorias       { get; set; }
        public double      Proteinas      { get; set; }
        public double      Carbohidratos  { get; set; }
        public double      Grasas         { get; set; }

        public ItemMenu() { }

        public ItemMenu(Alimento alimento, double cantidadGramos, TiempoComida tiempo)
        {
            AlimentoId     = alimento.Id;
            NombreAlimento = alimento.Nombre;
            CantidadGramos = cantidadGramos;
            TiempoComida   = tiempo;
            Calorias       = alimento.CaloriasParaCantidad(cantidadGramos);
            Proteinas      = alimento.ProteinasParaCantidad(cantidadGramos);
            Carbohidratos  = alimento.CarbsParaCantidad(cantidadGramos);
            Grasas         = alimento.GrasasParaCantidad(cantidadGramos);
        }

        public string ToCsv()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                AlimentoId, NombreAlimento, CantidadGramos, TiempoComida,
                Math.Round(Calorias, 2), Math.Round(Proteinas, 2),
                Math.Round(Carbohidratos, 2), Math.Round(Grasas, 2));
        }

        public static ItemMenu FromCsv(string linea)
        {
            var p = linea.Split(',');
            return new ItemMenu
            {
                AlimentoId     = int.Parse(p[0].Trim()),
                NombreAlimento = p[1].Trim(),
                CantidadGramos = double.Parse(p[2].Trim(), CultureInfo.InvariantCulture),
                TiempoComida   = (TiempoComida)Enum.Parse(typeof(TiempoComida), p[3].Trim()),
                Calorias       = double.Parse(p[4].Trim(), CultureInfo.InvariantCulture),
                Proteinas      = double.Parse(p[5].Trim(), CultureInfo.InvariantCulture),
                Carbohidratos  = double.Parse(p[6].Trim(), CultureInfo.InvariantCulture),
                Grasas         = double.Parse(p[7].Trim(), CultureInfo.InvariantCulture)
            };
        }
    }

    public class Menu
    {
        public int           Id        { get; set; }
        public int           UsuarioId { get; set; }
        public DateTime      Fecha     { get; set; }
        public List<ItemMenu> Items    { get; set; } = new List<ItemMenu>();

        public double TotalCalorias      => Items.Sum(i => i.Calorias);
        public double TotalProteinas     => Items.Sum(i => i.Proteinas);
        public double TotalCarbohidratos => Items.Sum(i => i.Carbohidratos);
        public double TotalGrasas        => Items.Sum(i => i.Grasas);

        public Menu() { }

        public Menu(int id, int usuarioId, DateTime fecha)
        {
            Id        = id;
            UsuarioId = usuarioId;
            Fecha     = fecha;
        }

        public List<string> ToCsvLines()
        {
            var lines = new List<string>();
            foreach (var item in Items)
                lines.Add(string.Format("{0},{1},{2},{3}", Id, UsuarioId,
                    Fecha.ToString("yyyy-MM-dd"), item.ToCsv()));
            return lines;
        }

        public override string ToString()
        {
            return string.Format("{0:dd/MM/yyyy} - {1:F0} kcal", Fecha, TotalCalorias);
        }
    }
}
