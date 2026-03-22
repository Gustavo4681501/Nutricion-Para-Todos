using NutricionApp.Controllers;
using System.Collections.Generic;
using NutricionApp.Models;

namespace NutricionApp.Data
{
    /// <summary>
    /// Contexto global de la aplicacion. Centraliza los datos cargados en memoria
    /// y las rutas de los archivos CSV.
    /// </summary>
    public sealed class NutricionContext
    {
        private static NutricionContext _instancia;
        private static readonly object _lock = new object();

        // Singleton
        public static NutricionContext Instancia
        {
            get
            {
                lock (_lock)
                {
                    if (_instancia == null)
                        _instancia = new NutricionContext();
                    return _instancia;
                }
            }
        }

        private NutricionContext() { }

        // Datos en memoria
        public List<Usuario>  Usuarios  { get; set; } = new List<Usuario>();
        public List<Alimento> Alimentos { get; set; } = new List<Alimento>();
        public List<Menu>     Menus     { get; set; } = new List<Menu>();

        // Usuario activo en la sesion
        public Usuario UsuarioActivo { get; set; }

        // LoginController para reutilizar al cambiar usuario
        public LoginController LoginCtrl { get; set; }

        // Rutas CSV (se asignan al iniciar)
        public string RutaUsuarios  { get; set; }
        public string RutaAlimentos { get; set; }
        public string RutaMenus     { get; set; }

        // Proximos IDs disponibles
        public int SiguienteIdUsuario  => Usuarios.Count  > 0 ? Usuarios[Usuarios.Count-1].Id  + 1 : 1;
        public int SiguienteIdAlimento => Alimentos.Count > 0 ? Alimentos[Alimentos.Count-1].Id + 1 : 1;
        public int SiguienteIdMenu     => Menus.Count     > 0 ? Menus[Menus.Count-1].Id         + 1 : 1;
    }
}
