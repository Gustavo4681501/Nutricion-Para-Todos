using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using NutricionApp.Data.Repositories.Abstractions;
using NutricionApp.Models;

namespace NutricionApp.Data.Repositories
{
    /// <summary>
    /// Implementacion del repositorio de perfiles con SQLite.
    /// Toda la logica de acceso a datos de la tabla Perfiles esta aqui.
    /// </summary>
    public class PerfilRepository : IPerfilRepository
    {
        private readonly DatabaseContext _db;

        public PerfilRepository(DatabaseContext db) { _db = db; }

        /// <summary>Retorna el perfil del usuario, o null si no existe.</summary>
        public Perfil GetByUser(string userName)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT UserName,Edad,PesoKg,AlturaCm,Objetivo,Actividad,Dieta FROM Perfiles WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@u", userName);
            using var r = cmd.ExecuteReader();
            return r.Read() ? MapPerfil(r) : null;
        }

        /// <summary>Verifica si el usuario ya tiene perfil registrado.</summary>
        public bool Exists(string userName)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Perfiles WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@u", userName);
            return (long)cmd.ExecuteScalar()! > 0;
        }

        /// <summary>Inserta un nuevo perfil.</summary>
        public void Add(Perfil p)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Perfiles(UserName,Edad,PesoKg,AlturaCm,Objetivo,Actividad,Dieta) VALUES(@u,@e,@pk,@ac,@obj,@act,@d);";
            BindPerfil(cmd, p);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Actualiza un perfil existente.</summary>
        public void Update(Perfil p)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Perfiles SET Edad=@e,PesoKg=@pk,AlturaCm=@ac,Objetivo=@obj,Actividad=@act,Dieta=@d WHERE UserName=@u;";
            BindPerfil(cmd, p);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Retorna la distribucion de tipos de dieta de todos los usuarios.</summary>
        public List<(TipoDieta Dieta, int Count)> GetDietDistribution()
        {
            var list = new List<(TipoDieta, int)>();
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Dieta, COUNT(*) FROM Perfiles GROUP BY Dieta;";
            using var r = cmd.ExecuteReader();
            while (r.Read())
                if (Enum.TryParse<TipoDieta>(r.GetString(0), out var d))
                    list.Add((d, r.GetInt32(1)));
            return list;
        }

        private static Perfil MapPerfil(SqliteDataReader r)
        {
            Enum.TryParse<ObjetivoNutricional>(r.GetString(4), out var obj);
            Enum.TryParse<NivelActividad>(r.GetString(5),      out var act);
            Enum.TryParse<TipoDieta>(r.GetString(6),           out var diet);
            return new Perfil(r.GetString(0))
            {
                Edad      = r.GetInt32(1),
                PesoKg    = r.GetDouble(2),
                AlturaCm  = r.GetDouble(3),
                Objetivo  = obj,
                Actividad = act,
                Dieta     = diet
            };
        }

        private static void BindPerfil(SqliteCommand cmd, Perfil p)
        {
            cmd.Parameters.AddWithValue("@u",   p.UserName);
            cmd.Parameters.AddWithValue("@e",   p.Edad);
            cmd.Parameters.AddWithValue("@pk",  p.PesoKg);
            cmd.Parameters.AddWithValue("@ac",  p.AlturaCm);
            cmd.Parameters.AddWithValue("@obj", p.Objetivo.ToString());
            cmd.Parameters.AddWithValue("@act", p.Actividad.ToString());
            cmd.Parameters.AddWithValue("@d",   p.Dieta.ToString());
        }
    }
}
