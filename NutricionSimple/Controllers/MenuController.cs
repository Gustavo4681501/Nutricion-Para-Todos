using System;
using System.Collections.Generic;
using System.Linq;
using NutricionApp.Data;
using NutricionApp.Data.Loaders;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    public class MenuController
    {
        private readonly NutricionContext _ctx = NutricionContext.Instancia;

        public List<Menu> ObtenerPorUsuario(int usuarioId)
            => _ctx.Menus.Where(m => m.UsuarioId == usuarioId).OrderByDescending(m => m.Fecha).ToList();

        public Menu ObtenerPorFechaYUsuario(int usuarioId, DateTime fecha)
            => _ctx.Menus.FirstOrDefault(m => m.UsuarioId == usuarioId && m.Fecha.Date == fecha.Date);

        public List<Menu> ObtenerPorRangoFechas(int usuarioId, DateTime inicio, DateTime fin)
            => _ctx.Menus.Where(m => m.UsuarioId == usuarioId &&
                                     m.Fecha.Date >= inicio.Date &&
                                     m.Fecha.Date <= fin.Date)
                         .OrderBy(m => m.Fecha)
                         .ToList();

        public void AgregarMenu(Menu m)
        {
            m.Id = _ctx.SiguienteIdMenu;
            _ctx.Menus.Add(m);
            GuardarCambios();
        }

        public void ActualizarMenu(Menu m)
        {
            int idx = _ctx.Menus.FindIndex(x => x.Id == m.Id);
            if (idx < 0) throw new Exception("Menu no encontrado.");
            _ctx.Menus[idx] = m;
            GuardarCambios();
        }

        public void EliminarMenu(int id)
        {
            var m = _ctx.Menus.FirstOrDefault(x => x.Id == id);
            if (m == null) throw new Exception("Menu no encontrado.");
            _ctx.Menus.Remove(m);
            GuardarCambios();
        }

        private void GuardarCambios()
        {
            CsvLoader.GuardarMenus(_ctx.RutaMenus, _ctx.Menus);
        }
    }
}
