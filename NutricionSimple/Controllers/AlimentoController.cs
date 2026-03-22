using System;
using System.Collections.Generic;
using System.Linq;
using NutricionApp.Data;
using NutricionApp.Data.Loaders;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    public class AlimentoController
    {
        private readonly NutricionContext _ctx = NutricionContext.Instancia;

        public List<Alimento> ObtenerTodos() => _ctx.Alimentos;

        public List<Alimento> Buscar(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino)) return ObtenerTodos();
            return _ctx.Alimentos
                .Where(a => a.Nombre.IndexOf(termino, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        public Alimento ObtenerPorId(int id) => _ctx.Alimentos.FirstOrDefault(a => a.Id == id);

        public bool ExisteNombre(string nombre, int exceptoId = -1)
            => _ctx.Alimentos.Any(a => a.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) && a.Id != exceptoId);

        public void AgregarAlimento(Alimento a)
        {
            a.Id = _ctx.SiguienteIdAlimento;
            _ctx.Alimentos.Add(a);
            GuardarCambios();
        }

        public void ActualizarAlimento(Alimento a)
        {
            int idx = _ctx.Alimentos.FindIndex(x => x.Id == a.Id);
            if (idx < 0) throw new Exception("Alimento no encontrado.");
            _ctx.Alimentos[idx] = a;
            GuardarCambios();
        }

        public void EliminarAlimento(int id)
        {
            var a = ObtenerPorId(id);
            if (a == null) throw new Exception("Alimento no encontrado.");
            _ctx.Alimentos.Remove(a);
            GuardarCambios();
        }

        private void GuardarCambios()
        {
            CsvLoader.GuardarAlimentos(_ctx.RutaAlimentos, _ctx.Alimentos);
        }
    }
}
