using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Data;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Autentica y registra usuarios usando SQLite.
    /// Iteracion 2: reemplaza la lectura/escritura de CSV.
    /// Implementa ILoginController sin cambios en la interfaz.
    /// </summary>
    public class LoginController : ILoginController
    {
        private readonly DatabaseContext _db;

        public LoginController(DatabaseContext db) { _db = db; }

        /// <summary>Valida credenciales contra la base de datos.</summary>
        public bool Login(string userName, string password)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE UserName=@u AND Password=@p AND IsActive=1;";
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.Parameters.AddWithValue("@p", password);
            return (long)cmd.ExecuteScalar()! > 0;
        }

        /// <summary>Registra un nuevo usuario si el nombre no existe.</summary>
        public bool Register(string userName, string password)
        {
            using var conn = _db.OpenConnection();
            var chk = conn.CreateCommand();
            chk.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE UserName=@u;";
            chk.Parameters.AddWithValue("@u", userName);
            if ((long)chk.ExecuteScalar()! > 0) return false;

            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Usuarios(UserName,Password,IsAdmin,IsActive) VALUES(@u,@p,0,1);";
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.Parameters.AddWithValue("@p", password);
            cmd.ExecuteNonQuery();
            return true;
        }

        /// <summary>Retorna el objeto User completo con IsAdmin e IsActive.</summary>
        public User GetUser(string userName)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT UserName,Password,IsAdmin,IsActive FROM Usuarios WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@u", userName);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;
            return new User(r.GetString(0), r.GetString(1))
            {
                IsAdmin  = r.GetInt32(2) == 1,
                IsActive = r.GetInt32(3) == 1
            };
        }

        /// <summary>Retorna todos los usuarios (uso del administrador).</summary>
        public List<User> GetAll()
        {
            var list = new List<User>();
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT UserName,Password,IsAdmin,IsActive FROM Usuarios ORDER BY UserName;";
            using var r = cmd.ExecuteReader();
            while (r.Read())
                list.Add(new User(r.GetString(0), r.GetString(1))
                {
                    IsAdmin  = r.GetInt32(2) == 1,
                    IsActive = r.GetInt32(3) == 1
                });
            return list;
        }

        /// <summary>Resetea la contrasena de un usuario.</summary>
        public void ResetPassword(string userName, string newPassword)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Usuarios SET Password=@p WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@p", newPassword);
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Activa o desactiva una cuenta de usuario.</summary>
        public void SetActive(string userName, bool active)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Usuarios SET IsActive=@a WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@a", active ? 1 : 0);
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Elimina permanentemente un usuario.</summary>
        public void EliminarUsuario(string userName)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Usuarios WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.ExecuteNonQuery();
        }
    }
}
