using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Data;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Gestiona menus diarios usando SQLite.
    /// Iteracion 2: reemplaza la lectura/escritura de CSV.
    /// Implementa IMenuController sin cambios en la interfaz.
    /// </summary>
    public class MenuController : IMenuController
    {
        private readonly DatabaseContext _db;

        public MenuController(DatabaseContext db) { _db = db; }

        /// <summary>Retorna todos los menus de un usuario, ordenados por fecha descendente.</summary>
        public List<Menu> ObtenerPorUsuario(string userName)
        {
            var menus = new List<Menu>();
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id,UserName,Fecha FROM Menus WHERE UserName=@u ORDER BY Fecha DESC;";
            cmd.Parameters.AddWithValue("@u", userName);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                var m = new Menu(r.GetString(1), DateTime.Parse(r.GetString(2)));
                m.Items = GetItems(conn, r.GetInt32(0));
                menus.Add(m);
            }
            return menus;
        }

        /// <summary>Guarda un menu y todos sus items.</summary>
        public void Guardar(Menu menu)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Menus(UserName,Fecha) VALUES(@u,@f); SELECT last_insert_rowid();";
            cmd.Parameters.AddWithValue("@u", menu.UserName);
            cmd.Parameters.AddWithValue("@f", menu.Fecha.ToString("yyyy-MM-dd"));
            int menuId = (int)(long)cmd.ExecuteScalar()!;

            foreach (var item in menu.Items)
            {
                var ic = conn.CreateCommand();
                ic.CommandText = "INSERT INTO ItemsMenu(MenuId,NombreAlimento,CantidadGramos,Calorias,Proteinas,Carbohidratos,Grasas) VALUES(@mid,@n,@cant,@cal,@prot,@carb,@gras);";
                ic.Parameters.AddWithValue("@mid",  menuId);
                ic.Parameters.AddWithValue("@n",    item.NombreAlimento);
                ic.Parameters.AddWithValue("@cant", item.CantidadGramos);
                ic.Parameters.AddWithValue("@cal",  item.Calorias);
                ic.Parameters.AddWithValue("@prot", item.Proteinas);
                ic.Parameters.AddWithValue("@carb", item.Carbohidratos);
                ic.Parameters.AddWithValue("@gras", item.Grasas);
                ic.ExecuteNonQuery();
            }
        }

        /// <summary>Elimina un menu por su Id.</summary>
        public void Eliminar(string userName, int menuId)
        {
            using var conn = _db.OpenConnection();
            var d1 = conn.CreateCommand();
            d1.CommandText = "DELETE FROM ItemsMenu WHERE MenuId=@id;";
            d1.Parameters.AddWithValue("@id", menuId);
            d1.ExecuteNonQuery();

            var d2 = conn.CreateCommand();
            d2.CommandText = "DELETE FROM Menus WHERE Id=@id AND UserName=@u;";
            d2.Parameters.AddWithValue("@id", menuId);
            d2.Parameters.AddWithValue("@u",  userName);
            d2.ExecuteNonQuery();
        }

        /// <summary>Retorna el alimento mas consumido en un rango de fechas.</summary>
        public string AlimentoMasConsumido(DateTime desde, DateTime hasta)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT im.NombreAlimento, SUM(im.CantidadGramos) AS Total
                FROM ItemsMenu im JOIN Menus m ON im.MenuId=m.Id
                WHERE m.Fecha BETWEEN @f AND @t
                GROUP BY im.NombreAlimento ORDER BY Total DESC LIMIT 1;";
            cmd.Parameters.AddWithValue("@f", desde.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@t", hasta.ToString("yyyy-MM-dd"));
            using var r = cmd.ExecuteReader();
            return r.Read() ? r.GetString(0) : "Sin datos";
        }

        /// <summary>Retorna los usuarios con mas menus registrados.</summary>
        public List<(string UserName, int Count)> TopUsuariosPorMenus(int top = 5)
        {
            var list = new List<(string, int)>();
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT UserName,COUNT(*) FROM Menus GROUP BY UserName ORDER BY COUNT(*) DESC LIMIT @t;";
            cmd.Parameters.AddWithValue("@t", top);
            using var r = cmd.ExecuteReader();
            while (r.Read()) list.Add((r.GetString(0), r.GetInt32(1)));
            return list;
        }

        private static List<ItemMenu> GetItems(SqliteConnection conn, int menuId)
        {
            var items = new List<ItemMenu>();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT NombreAlimento,CantidadGramos,Calorias,Proteinas,Carbohidratos,Grasas FROM ItemsMenu WHERE MenuId=@mid;";
            cmd.Parameters.AddWithValue("@mid", menuId);
            using var r = cmd.ExecuteReader();
            while (r.Read())
                items.Add(new ItemMenu(r.GetString(0), r.GetDouble(1), r.GetDouble(2), r.GetDouble(3), r.GetDouble(4), r.GetDouble(5)));
            return items;
        }
    }
}
