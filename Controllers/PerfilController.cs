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
        private readonly string       _filePath;

        /// <summary>
        /// Initializes a new instance of the PerfilController class using the specified file path to load profile data.
        /// </summary>
        /// <remarks>The constructor loads profiles from the provided file path when the controller is
        /// instantiated. Ensure that the file exists and is accessible to avoid runtime errors.</remarks>
        /// <param name="filePath">The path to the file that contains the profile data. This parameter cannot be null or empty.</param>
        public PerfilController(string filePath)
        {
            _filePath = filePath;
            _perfiles = LoadPerfiles();
        }

        /// <summary>
        /// Retrieves the profile associated with the specified username, or creates a new profile if none exists.
        /// </summary>
        /// <remarks>This method searches through the existing profiles to find a match. If no match is
        /// found, it initializes a new Perfil with the provided username.</remarks>
        /// <param name="userName">The username for which to retrieve the profile. This parameter cannot be null or empty.</param>
        /// <returns>A Perfil object representing the user's profile. If a profile with the specified username exists, it is
        /// returned; otherwise, a new Perfil is created.</returns>
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
        /// Saves the specified user profile, replacing any existing profile for the same user.
        /// </summary>
        /// <remarks>If a profile with the same user name already exists, it is replaced with the new
        /// profile. Changes are persisted immediately after the operation.</remarks>
        /// <param name="perfil">The profile to save. Must contain a valid user name and associated settings.</param>
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
            string header = "UserName,Edad,PesoKg,AlturaCm,Objetivo";
            var rows = new List<string> { header };

            foreach (var p in _perfiles)
                rows.Add(p.ToCsv());

            File.WriteAllLines(_filePath, rows);
        }
    }
}
