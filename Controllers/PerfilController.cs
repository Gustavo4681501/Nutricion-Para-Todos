using System.Collections.Generic;
using System.IO;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Manages user profiles, allowing retrieval and persistence of profile data from a CSV file.
    /// </summary>
    /// <remarks>The controller loads all profiles from the specified CSV file upon initialization. If a
    /// requested user does not have a saved profile, a default profile is returned. Profile updates and additions are
    /// persisted to the CSV file, ensuring data consistency across application sessions.</remarks>
    public class PerfilController : IPerfilController
    {
        private readonly List<Perfil> _perfiles;
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the PerfilController class using the specified file path to load profile data.
        /// </summary>
        /// <param name="filePath">The path to the file that contains the profile data. This parameter cannot be null or empty.</param>
        public PerfilController(string filePath)
        {
            _filePath = filePath;
            _perfiles = LoadPerfiles();
        }

        /// <summary>
        /// Retrieves the profile associated with the specified username, or creates a default profile if none exists.
        /// </summary>
        /// <param name="userName">The username for which to retrieve the profile.</param>
        /// <returns>A Perfil object. If no profile exists, a new default one is returned.</returns>
        public Perfil ObtenerPerfil(string userName)
        {
            foreach (var p in _perfiles)
            {
                if (p.UserName == userName)
                    return p;
            }

            return new Perfil(userName);
        }

        /// <summary>
        /// Saves the specified profile by updating an existing profile with the same username or adding a new profile
        /// if none exists.
        /// </summary>
        /// <remarks>This method persists changes by calling SavePerfiles after updating or adding the
        /// profile. If the username already exists in the collection, the existing profile is overwritten.</remarks>
        /// <param name="perfil">The profile to save. Must contain a valid username. If a profile with the same username already exists, it
        /// will be replaced.</param>
        public void GuardarPerfil(Perfil perfil)
        {
            for (int i = 0; i < _perfiles.Count; i++)
            {
                if (_perfiles[i].UserName == perfil.UserName)
                {
                    _perfiles[i] = perfil;
                    SavePerfiles();
                    return;
                }
            }

            _perfiles.Add(perfil);
            SavePerfiles();
        }

        private List<Perfil> LoadPerfiles()
        {
            var lista = new List<Perfil>();

            if (!File.Exists(_filePath))
                return lista;

            var lines = File.ReadAllLines(_filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                var parts = lines[i].Split(',');

                if (parts.Length >= 5)
                    lista.Add(new Perfil(parts));
            }

            return lista;
        }

        private void SavePerfiles()
        {
            string header = "UserName,Edad,PesoKg,AlturaCm,Objetivo,Actividad,Dieta";
            var rows = new List<string> { header };

            foreach (var p in _perfiles)
                rows.Add(p.ToCsv());

            File.WriteAllLines(_filePath, rows);
        }
    }
}