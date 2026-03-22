using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using NutricionApp.Models;

namespace NutricionApp.Data.Loaders
{
    public static class CsvLoader
    {
        // ── USUARIOS ─────────────────────────────────────────────────────────────
        public static List<Usuario> CargarUsuarios(string ruta)
        {
            var lista = new List<Usuario>();
            if (!File.Exists(ruta)) return lista;
            var lineas = File.ReadAllLines(ruta);
            for (int i = 1; i < lineas.Length; i++)
            {
                string linea = lineas[i].Trim();
                if (string.IsNullOrEmpty(linea)) continue;
                try   { lista.Add(Usuario.FromCsv(linea)); }
                catch (Exception ex) { Console.WriteLine("Error usuario linea " + (i+1) + ": " + ex.Message); }
            }
            return lista;
        }

        public static void GuardarUsuarios(string ruta, List<Usuario> lista)
        {
            var lineas = new List<string> { "id,nombre,edad,peso,altura,sexo,objetivo,nivelActividad,tipoDieta" };
            foreach (var u in lista) lineas.Add(u.ToCsv());
            File.WriteAllLines(ruta, lineas);
        }

        // ── ALIMENTOS ─────────────────────────────────────────────────────────────
        public static List<Alimento> CargarAlimentos(string ruta)
        {
            var lista = new List<Alimento>();
            if (!File.Exists(ruta)) return lista;
            var lineas = File.ReadAllLines(ruta);
            for (int i = 1; i < lineas.Length; i++)
            {
                string linea = lineas[i].Trim();
                if (string.IsNullOrEmpty(linea)) continue;
                try   { lista.Add(Alimento.FromCsv(linea)); }
                catch (Exception ex) { Console.WriteLine("Error alimento linea " + (i+1) + ": " + ex.Message); }
            }
            return lista;
        }

        public static void GuardarAlimentos(string ruta, List<Alimento> lista)
        {
            var lineas = new List<string> { "id,nombre,calorias,proteinas,carbohidratos,grasas,porcionGramos,categoria" };
            foreach (var a in lista) lineas.Add(a.ToCsv());
            File.WriteAllLines(ruta, lineas);
        }

        // ── MENUS ─────────────────────────────────────────────────────────────────
        public static List<Menu> CargarMenus(string ruta)
        {
            var menus = new Dictionary<int, Menu>();
            if (!File.Exists(ruta)) return new List<Menu>(menus.Values);
            var lineas = File.ReadAllLines(ruta);
            for (int i = 1; i < lineas.Length; i++)
            {
                string linea = lineas[i].Trim();
                if (string.IsNullOrEmpty(linea)) continue;
                try
                {
                    var p       = linea.Split(',');
                    int menuId  = int.Parse(p[0].Trim());
                    int uid     = int.Parse(p[1].Trim());
                    DateTime f  = DateTime.ParseExact(p[2].Trim(), "yyyy-MM-dd",
                                    CultureInfo.InvariantCulture);

                    if (!menus.ContainsKey(menuId))
                        menus[menuId] = new Menu(menuId, uid, f);

                    string itemCsv = string.Join(",",
                        p[3], p[4], p[5], p[6], p[7], p[8], p[9], p[10]);
                    menus[menuId].Items.Add(ItemMenu.FromCsv(itemCsv));
                }
                catch (Exception ex) { Console.WriteLine("Error menu linea " + (i+1) + ": " + ex.Message); }
            }
            return new List<Menu>(menus.Values);
        }

        public static void GuardarMenus(string ruta, List<Menu> menus)
        {
            var lineas = new List<string>
            {
                "menuId,usuarioId,fecha,alimentoId,nombreAlimento,cantidadGramos,tiempoComida,calorias,proteinas,carbohidratos,grasas"
            };
            foreach (var m in menus)
                lineas.AddRange(m.ToCsvLines());
            File.WriteAllLines(ruta, lineas);
        }
    }
}
