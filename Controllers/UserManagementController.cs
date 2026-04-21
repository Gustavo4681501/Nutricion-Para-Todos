using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Data;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Responsabilidad unica: gestion administrativa de usuarios.
    /// Separado de LoginController siguiendo SOLID-S (Single Responsibility)
    /// e SOLID-I (Interface Segregation).
    /// Patron: implementa IUserManagementController.
    /// </summary>
    public class UserManagementController : IUserManagementController
    {
        private readonly DatabaseContext _db;

        public UserManagementController(DatabaseContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Retorna todos los usuarios del sistema ordenados por nombre.
        /// Uso exclusivo del administrador.
        /// </summary>
        public List<User> GetAll()
        {
            var list = new List<User>();
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT UserName,Password,IsAdmin,IsActive
                                FROM Usuarios ORDER BY UserName;";
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new User(r.GetString(0), r.GetString(1))
                {
                    IsAdmin  = r.GetInt32(2) == 1,
                    IsActive = r.GetInt32(3) == 1
                });
            }
            return list;
        }

        /// <summary>
        /// Resetea la contrasena de un usuario a un nuevo valor.
        /// </summary>
        public void ResetPassword(string userName, string newPassword)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Usuarios SET Password=@p WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@p", newPassword);
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Activa o desactiva una cuenta de usuario sin eliminarla.
        /// </summary>
        public void SetActive(string userName, bool active)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Usuarios SET IsActive=@a WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@a", active ? 1 : 0);
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Elimina permanentemente un usuario de la base de datos.
        /// </summary>
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
