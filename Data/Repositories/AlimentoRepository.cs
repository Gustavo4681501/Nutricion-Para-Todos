using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using NutricionApp.Data.Repositories.Abstractions;
using NutricionApp.Models;

namespace NutricionApp.Data.Repositories
{
    /// <summary>
    /// Implementacion del repositorio de alimentos con SQLite.
    /// Toda la logica de acceso a datos de la tabla Alimentos esta aqui.
    /// </summary>
    public class AlimentoRepository : IAlimentoRepository
    {
        private readonly DatabaseContext _db;

        /// <summary>Recibe el contexto de base de datos para abrir conexiones.</summary>
        public AlimentoRepository(DatabaseContext db) { _db = db; }

        /// <summary>Retorna todos los alimentos ordenados por nombre.</summary>
        public List<Alimento> GetAll()
        {
            var list = new List<Alimento>();
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Nombre,Calorias,Proteinas,Carbohidratos,Grasas,Porcion FROM Alimentos ORDER BY Nombre;";
            using var r = cmd.ExecuteReader();
            while (r.Read()) list.Add(MapAlimento(r));
            return list;
        }

        /// <summary>Retorna un alimento por nombre exacto, o null si no existe.</summary>
        public Alimento GetByName(string nombre)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Nombre,Calorias,Proteinas,Carbohidratos,Grasas,Porcion FROM Alimentos WHERE Nombre=@n;";
            cmd.Parameters.AddWithValue("@n", nombre);
            using var r = cmd.ExecuteReader();
            return r.Read() ? MapAlimento(r) : null;
        }

        /// <summary>Inserta un nuevo alimento.</summary>
        public void Add(Alimento a)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Alimentos(Nombre,Calorias,Proteinas,Carbohidratos,Grasas,Porcion) VALUES(@n,@cal,@prot,@carb,@gras,@porc);";
            BindAlimento(cmd, a);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Actualiza los valores nutricionales de un alimento.</summary>
        public void Update(Alimento a)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Alimentos SET Calorias=@cal,Proteinas=@prot,Carbohidratos=@carb,Grasas=@gras,Porcion=@porc WHERE Nombre=@n;";
            BindAlimento(cmd, a);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Elimina un alimento por su Id.</summary>
        public void DeleteById(int id)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Alimentos WHERE Id=@id;";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Elimina un alimento por su nombre.</summary>
        public void DeleteByName(string nombre)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Alimentos WHERE Nombre=@n;";
            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.ExecuteNonQuery();
        }

        private static Alimento MapAlimento(SqliteDataReader r) =>
            new Alimento(r.GetString(0), r.GetDouble(1), r.GetDouble(2), r.GetDouble(3), r.GetDouble(4), r.GetDouble(5));

        private static void BindAlimento(SqliteCommand cmd, Alimento a)
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
