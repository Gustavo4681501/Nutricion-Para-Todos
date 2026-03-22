using System;
using System.Collections.Generic;
using System.Linq;
using NutricionApp.Data;
using NutricionApp.Data.Loaders;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    public class UsuarioController
    {
        private readonly NutricionContext _ctx = NutricionContext.Instancia;

        public List<Usuario> ObtenerTodos() => _ctx.Usuarios;

        public Usuario ObtenerPorId(int id) => _ctx.Usuarios.FirstOrDefault(u => u.Id == id);

        public bool ExisteNombre(string nombre)
            => _ctx.Usuarios.Any(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

        public void AgregarUsuario(Usuario u)
        {
            u.Id = _ctx.SiguienteIdUsuario;
            _ctx.Usuarios.Add(u);
            GuardarCambios();
        }

        public void ActualizarUsuario(Usuario u)
        {
            int idx = _ctx.Usuarios.FindIndex(x => x.Id == u.Id);
            if (idx < 0) throw new Exception("Usuario no encontrado.");
            _ctx.Usuarios[idx] = u;
            GuardarCambios();
        }

        public void EliminarUsuario(int id)
        {
            var u = ObtenerPorId(id);
            if (u == null) throw new Exception("Usuario no encontrado.");
            _ctx.Usuarios.Remove(u);
            GuardarCambios();
        }

        private void GuardarCambios()
        {
            CsvLoader.GuardarUsuarios(_ctx.RutaUsuarios, _ctx.Usuarios);
        }
    }
}
