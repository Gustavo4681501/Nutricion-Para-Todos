using Microsoft.Data.Sqlite;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Data;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Responsabilidad unica: autenticar y registrar usuarios.
    /// Iteracion 2: implementacion con SQLite.
    /// Los metodos de gestion administrativa fueron movidos a
    /// UserManagementController siguiendo SOLID-S e SOLID-I.
    /// </summary>
    public class LoginController : ILoginController
    {
        private readonly DatabaseContext _db;

        public LoginController(DatabaseContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Valida las credenciales del usuario contra la base de datos.
        /// Solo autentica usuarios activos.
        /// </summary>
        public bool Login(string userName, string password)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT COUNT(*) FROM Usuarios
                                WHERE UserName=@u AND Password=@p AND IsActive=1;";
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.Parameters.AddWithValue("@p", password);
            return (long)cmd.ExecuteScalar()! > 0;
        }

        /// <summary>
        /// Registra un nuevo usuario si el nombre no existe.
        /// </summary>
        public bool Register(string userName, string password)
        {
            using var conn = _db.OpenConnection();

            var check = conn.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE UserName=@u;";
            check.Parameters.AddWithValue("@u", userName);
            if ((long)check.ExecuteScalar()! > 0) return false;

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO Usuarios(UserName,Password,IsAdmin,IsActive)
                                VALUES(@u,@p,0,1);";
            cmd.Parameters.AddWithValue("@u", userName);
            cmd.Parameters.AddWithValue("@p", password);
            cmd.ExecuteNonQuery();
            return true;
        }

        /// <summary>
        /// Retorna el objeto User completo con IsAdmin e IsActive.
        /// Usado por AppState al completar el login.
        /// </summary>
        public User GetUser(string userName)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT UserName,Password,IsAdmin,IsActive
                                FROM Usuarios WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@u", userName);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;
            return new User(r.GetString(0), r.GetString(1))
            {
                IsAdmin  = r.GetInt32(2) == 1,
                IsActive = r.GetInt32(3) == 1
            };
        }
    }
}
