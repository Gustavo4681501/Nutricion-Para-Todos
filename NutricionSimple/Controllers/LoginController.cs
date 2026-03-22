using System.Collections.Generic;
using System.IO;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Data;
using NutricionApp.Data.Loaders;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Maneja el login y registro de usuarios contra el CSV de usuarios.
    /// Sigue el mismo patron que el LoginController del proyecto de referencia.
    /// </summary>
    public class LoginController : ILoginController
    {
        private readonly List<Usuario> _usuarios;
        private readonly string        _rutaCsv;

        public LoginController(string rutaCsv)
        {
            _rutaCsv  = rutaCsv;
            _usuarios = CsvLoader.CargarUsuarios(rutaCsv);

            // Tambien cargar en el contexto global para que el resto de la app lo use
            NutricionContext.Instancia.Usuarios  = _usuarios;
            NutricionContext.Instancia.RutaUsuarios = rutaCsv;
        }

        /// <summary>
        /// Valida usuario y contraseña. Devuelve true si existen en el CSV.
        /// </summary>
        public bool Login(string userName, string password)
        {
            foreach (var u in _usuarios)
            {
                if (u.Nombre == userName && u.Password == password)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Registra un nuevo usuario con datos minimos y lo guarda en el CSV.
        /// Si el nombre ya existe devuelve false.
        /// </summary>
        public bool Register(string userName, string password)
        {
            foreach (var u in _usuarios)
            {
                if (u.Nombre == userName)
                    return false;
            }

            // Crear usuario con valores por defecto — el usuario puede completar
            // su perfil despues desde la pantalla principal
            int nuevoId = _usuarios.Count > 0 ? _usuarios[_usuarios.Count - 1].Id + 1 : 1;
            var nuevo = new Usuario
            {
                Id             = nuevoId,
                Nombre         = userName,
                Password       = password,
                Edad           = 25,
                Peso           = 70.0,
                Altura         = 170.0,
                Sexo           = Sexo.Masculino,
                Objetivo       = ObjetivoUsuario.Mantener,
                NivelActividad = NivelActividad.Moderadamente,
                TipoDieta      = TipoDieta.Estandar
            };

            _usuarios.Add(nuevo);
            CsvLoader.GuardarUsuarios(_rutaCsv, _usuarios);
            return true;
        }

        /// <summary>
        /// Devuelve el objeto Usuario que corresponde al nombre dado (despues de login exitoso).
        /// </summary>
        public Usuario ObtenerUsuario(string userName)
        {
            foreach (var u in _usuarios)
            {
                if (u.Nombre == userName)
                    return u;
            }
            return null;
        }
    }
}
