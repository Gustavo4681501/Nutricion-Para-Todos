using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Data;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Gestiona perfiles nutricionales usando SQLite.
    /// Iteracion 2: reemplaza la lectura/escritura de CSV.
    /// Implementa IPerfilController sin cambios en la interfaz.
    /// </summary>
    public class PerfilController : IPerfilController
    {
        private readonly DatabaseContext _db;

        public PerfilController(DatabaseContext db) { _db = db; }

        /// <summary>Obtiene el perfil de un usuario, o uno por defecto si no existe.</summary>
        public Perfil ObtenerPerfil(string userName)
        {
            using var conn = _db.OpenConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT UserName,Edad,PesoKg,AlturaCm,Objetivo,Actividad,Dieta FROM Perfiles WHERE UserName=@u;";
            cmd.Parameters.AddWithValue("@u", userName);
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return new Perfil(userName);
            return Map(r);
        }

        /// <summary>Guarda o actualiza el perfil del usuario.</summary>
        public void GuardarPerfil(Perfil p)
        {
            using var conn = _db.OpenConnection();
            var chk = conn.CreateCommand();
            chk.CommandText = "SELECT COUNT(*) FROM Perfiles WHERE UserName=@u;";
            chk.Parameters.AddWithValue("@u", p.UserName);
            bool exists = (long)chk.ExecuteScalar()! > 0;

            var cmd = conn.CreateCommand();
            cmd.CommandText = exists
                ? "UPDATE Perfiles SET Edad=@e,PesoKg=@pk,AlturaCm=@ac,Objetivo=@obj,Actividad=@act,Dieta=@d WHERE UserName=@u;"
                : "INSERT INTO Perfiles(UserName,Edad,PesoKg,AlturaCm,Objetivo,Actividad,Dieta) VALUES(@u,@e,@pk,@ac,@obj,@act,@d);";
            Bind(cmd, p);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Retorna la distribucion de tipos de dieta (uso del administrador).</summary>
        public List<(TipoDieta Dieta, int Count)> DistribucionDietas()
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

        private static Perfil Map(SqliteDataReader r)
        {
            Enum.TryParse<ObjetivoNutricional>(r.GetString(4), out var obj);
            Enum.TryParse<NivelActividad>(r.GetString(5),      out var act);
            Enum.TryParse<TipoDieta>(r.GetString(6),           out var diet);
            return new Perfil(r.GetString(0))
            {
                Edad     = r.GetInt32(1),
                PesoKg   = r.GetDouble(2),
                AlturaCm = r.GetDouble(3),
                Objetivo = obj,
                Actividad = act,
                Dieta    = diet
            };
        }

        private static void Bind(SqliteCommand cmd, Perfil p)
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
