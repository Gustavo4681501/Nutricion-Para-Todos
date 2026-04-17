using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Data;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Gestiona el catalogo de alimentos usando SQLite.
    /// Iteracion 2: reemplaza la lectura/escritura de CSV.
    /// Implementa IAlimentoController sin cambios en la interfaz.
    /// </summary>
    public class AlimentoController : IAlimentoController
    {
        private readonly DatabaseContext _db;

        public AlimentoController(DatabaseContext db) { _db = db; }

        /// <summary>Retorna todos los alimentos ordenados por nombre.</summary>
        public List<Alimento> ObtenerTodos()
        {
            var list = new List<Alimento>();
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Nombre,Calorias,Proteinas,Carbohidratos,Grasas,Porcion FROM Alimentos ORDER BY Nombre;";
            using var r = cmd.ExecuteReader();
            while (r.Read())
                list.Add(new Alimento(r.GetString(0), r.GetDouble(1), r.GetDouble(2), r.GetDouble(3), r.GetDouble(4), r.GetDouble(5)));
            return list;
        }

        /// <summary>Retorna un alimento por nombre exacto, o null si no existe.</summary>
        public Alimento ObtenerPorNombre(string nombre)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Nombre,Calorias,Proteinas,Carbohidratos,Grasas,Porcion FROM Alimentos WHERE Nombre=@n;";
            cmd.Parameters.AddWithValue("@n", nombre);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;
            return new Alimento(r.GetString(0), r.GetDouble(1), r.GetDouble(2), r.GetDouble(3), r.GetDouble(4), r.GetDouble(5));
        }

        /// <summary>Agrega un alimento nuevo al catalogo.</summary>
        public void Agregar(Alimento a)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Alimentos(Nombre,Calorias,Proteinas,Carbohidratos,Grasas,Porcion) VALUES(@n,@cal,@prot,@carb,@gras,@porc);";
            Bind(cmd, a);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Actualiza los valores nutricionales de un alimento existente.</summary>
        public void Actualizar(Alimento a)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Alimentos SET Calorias=@cal,Proteinas=@prot,Carbohidratos=@carb,Grasas=@gras,Porcion=@porc WHERE Nombre=@n;";
            Bind(cmd, a);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Elimina un alimento por su Id (compatible con IAlimentoController).</summary>
        public void Eliminar(int indice)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Alimentos WHERE Id=@id;";
            cmd.Parameters.AddWithValue("@id", indice);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Elimina un alimento por nombre.</summary>
        public void EliminarPorNombre(string nombre)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Alimentos WHERE Nombre=@n;";
            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.ExecuteNonQuery();
        }

        private static void Bind(SqliteCommand cmd, Alimento a)
        {
            cmd.Parameters.AddWithValue("@n",    a.Nombre);
            cmd.Parameters.AddWithValue("@cal",  a.Calorias);
            cmd.Parameters.AddWithValue("@prot", a.Proteinas);
            cmd.Parameters.AddWithValue("@carb", a.Carbohidratos);
            cmd.Parameters.AddWithValue("@gras", a.Grasas);
            cmd.Parameters.AddWithValue("@porc", a.Porcion);
        }
    }
}
