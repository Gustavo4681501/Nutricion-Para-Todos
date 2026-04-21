using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using NutricionApp.Data.Repositories.Abstractions;
using NutricionApp.Models;

namespace NutricionApp.Data.Repositories
{
    /// <summary>
    /// Implementacion del repositorio de usuarios con SQLite.
    /// Toda la logica de acceso a datos de la tabla Usuarios esta aqui.
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DatabaseContext _db;

        public UsuarioRepository(DatabaseContext db) { _db = db; }

        /// <summary>Retorna el usuario si las credenciales son validas y la cuenta esta activa.</summary>
        public User GetByCredentials(string userName, string password)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT UserName,Password,IsAdmin,IsActive
                                FROM Usuarios
                                WHERE UserName=@u AND Password=@p AND IsActive=1;";
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.Parameters.AddWithValue("@p", password);
            using var r = cmd.ExecuteReader();
            return r.Read() ? MapUser(r) : null;
        }

        /// <summary>Retorna el usuario por nombre de usuario.</summary>
        public User GetByUserName(string userName)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT UserName,Password,IsAdmin,IsActive FROM Usuarios WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@u", userName);
            using var r = cmd.ExecuteReader();
            return r.Read() ? MapUser(r) : null;
        }

        /// <summary>Verifica si el nombre de usuario ya existe.</summary>
        public bool Exists(string userName)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@u", userName);
            return (long)cmd.ExecuteScalar()! > 0;
        }

        /// <summary>Agrega un nuevo usuario regular.</summary>
        public void Add(string userName, string password)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Usuarios(UserName,Password,IsAdmin,IsActive) VALUES(@u,@p,0,1);";
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.Parameters.AddWithValue("@p", password);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Retorna todos los usuarios ordenados por nombre.</summary>
        public List<User> GetAll()
        {
            var list = new List<User>();
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT UserName,Password,IsAdmin,IsActive FROM Usuarios ORDER BY UserName;";
            using var r = cmd.ExecuteReader();
            while (r.Read()) list.Add(MapUser(r));
            return list;
        }

        /// <summary>Actualiza la contrasena de un usuario.</summary>
        public void UpdatePassword(string userName, string newPassword)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Usuarios SET Password=@p WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@p", newPassword);
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Activa o desactiva una cuenta de usuario.</summary>
        public void UpdateActive(string userName, bool active)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Usuarios SET IsActive=@a WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@a", active ? 1 : 0);
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Elimina permanentemente un usuario.</summary>
        public void Delete(string userName)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Usuarios WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.ExecuteNonQuery();
        }

        private static User MapUser(SqliteDataReader r) =>
            new User(r.GetString(0), r.GetString(1))
            {
                IsAdmin  = r.GetInt32(2) == 1,
                IsActive = r.GetInt32(3) == 1
            };
    }
}
