using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using NutricionApp.Data.Repositories.Abstractions;
using NutricionApp.Models;

namespace NutricionApp.Data.Repositories
{
    /// <summary>
    /// Implementacion del repositorio de menus con SQLite.
    /// Toda la logica de acceso a datos de las tablas Menus e ItemsMenu esta aqui.
    /// </summary>
    public class MenuRepository : IMenuRepository
    {
        private readonly DatabaseContext _db;

        public MenuRepository(DatabaseContext db) { _db = db; }

        /// <summary>Retorna todos los menus de un usuario ordenados por fecha descendente.</summary>
        public List<Menu> GetByUser(string userName)
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
                m.Id    = r.GetInt32(0);
                m.Items = GetItemsByMenu(conn, m.Id);
                menus.Add(m);
            }
            return menus;
        }

        /// <summary>Inserta un menu y retorna su Id generado.</summary>
        public int Add(Menu menu)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Menus(UserName,Fecha) VALUES(@u,@f); SELECT last_insert_rowid();";
            cmd.Parameters.AddWithValue("@u", menu.UserName);
            cmd.Parameters.AddWithValue("@f", menu.Fecha.ToString("yyyy-MM-dd"));
            return (int)(long)cmd.ExecuteScalar()!;
        }

        /// <summary>Inserta un item en un menu existente.</summary>
        public void AddItem(int menuId, ItemMenu item)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO ItemsMenu(MenuId,NombreAlimento,CantidadGramos,Calorias,Proteinas,Carbohidratos,Grasas) VALUES(@mid,@n,@cant,@cal,@prot,@carb,@gras);";
            cmd.Parameters.AddWithValue("@mid",  menuId);
            cmd.Parameters.AddWithValue("@n",    item.NombreAlimento);
            cmd.Parameters.AddWithValue("@cant", item.CantidadGramos);
            cmd.Parameters.AddWithValue("@cal",  item.Calorias);
            cmd.Parameters.AddWithValue("@prot", item.Proteinas);
            cmd.Parameters.AddWithValue("@carb", item.Carbohidratos);
            cmd.Parameters.AddWithValue("@gras", item.Grasas);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Elimina un menu y todos sus items por Id.</summary>
        public void Delete(string userName, int menuId)
        {
            using var conn = _db.OpenConnection();

            var delItems = conn.CreateCommand();
            delItems.CommandText = "DELETE FROM ItemsMenu WHERE MenuId=@id;";
            delItems.Parameters.AddWithValue("@id", menuId);
            delItems.ExecuteNonQuery();

            var delMenu = conn.CreateCommand();
            delMenu.CommandText = "DELETE FROM Menus WHERE Id=@id AND UserName=@u;";
            delMenu.Parameters.AddWithValue("@id", menuId);
            delMenu.Parameters.AddWithValue("@u",  userName);
            delMenu.ExecuteNonQuery();
        }

        /// <summary>Retorna el alimento mas consumido (por gramos) en un rango de fechas.</summary>
        public string GetMostConsumedFood(DateTime from, DateTime to)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT im.NombreAlimento, SUM(im.CantidadGramos) AS Total
                FROM ItemsMenu im JOIN Menus m ON im.MenuId=m.Id
                WHERE m.Fecha BETWEEN @f AND @t
                GROUP BY im.NombreAlimento ORDER BY Total DESC LIMIT 1;";
            cmd.Parameters.AddWithValue("@f", from.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@t", to.ToString("yyyy-MM-dd"));
            using var r = cmd.ExecuteReader();
            return r.Read() ? r.GetString(0) : "Sin datos";
        }

        /// <summary>Retorna los usuarios con mas menus registrados.</summary>
        public List<(string UserName, int Count)> GetTopUsersByMenus(int top)
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

        private static List<ItemMenu> GetItemsByMenu(SqliteConnection conn, int menuId)
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
