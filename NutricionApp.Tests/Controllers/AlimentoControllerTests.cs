using System;
using NutricionApp.Controllers;
using NutricionApp.Models;
using NutricionApp.Tests;
using Xunit;

namespace NutricionApp.Tests.Controllers
{
    /// <summary>
    /// Tests unitarios para AlimentoController.
    /// Actualizado para usar IAlimentoRepository (Patron Repository).
    /// Cubre: ObtenerTodos, ObtenerPorNombre, Agregar, Actualizar, EliminarPorNombre.
    /// </summary>
    public class AlimentoControllerTests : IDisposable
    {
        private readonly TestDatabaseFactory _factory;
        private readonly AlimentoController  _controller;

        public AlimentoControllerTests()
        {
            _factory    = new TestDatabaseFactory();
            _controller = new AlimentoController(_factory.CreateAlimentoRepository());
        }

        // ── ObtenerTodos ───────────────────────────────────────

        [Fact]
        public void ObtenerTodos_RetornaListaNoVacia()
        {
            var lista = _controller.ObtenerTodos();
            Assert.NotEmpty(lista);
        }

        [Fact]
        public void ObtenerTodos_ContieneDatosDelSeed()
        {
            var lista = _controller.ObtenerTodos();
            Assert.Contains(lista, a => a.Nombre == "Arroz blanco cocido");
        }

        [Fact]
        public void ObtenerTodos_EstaOrdenadoPorNombre()
        {
            var lista = _controller.ObtenerTodos();
            for (int i = 0; i < lista.Count - 1; i++)
                Assert.True(string.Compare(lista[i].Nombre, lista[i + 1].Nombre, StringComparison.OrdinalIgnoreCase) <= 0);
        }

        // ── ObtenerPorNombre ───────────────────────────────────

        [Fact]
        public void ObtenerPorNombre_AlimentoExiste_RetornaAlimento()
        {
            var a = _controller.ObtenerPorNombre("Salmon");
            Assert.NotNull(a);
            Assert.Equal("Salmon", a.Nombre);
        }

        [Fact]
        public void ObtenerPorNombre_AlimentoNoExiste_RetornaNull()
        {
            var a = _controller.ObtenerPorNombre("AlimentoInventado");
            Assert.Null(a);
        }

        [Fact]
        public void ObtenerPorNombre_ValoresNutricionalesCorrectos()
        {
            var a = _controller.ObtenerPorNombre("Arroz blanco cocido");
            Assert.NotNull(a);
            Assert.Equal(130, a.Calorias);
            Assert.Equal(2.7, a.Proteinas);
        }

        // ── Agregar ────────────────────────────────────────────

        [Fact]
        public void Agregar_AlimentoNuevo_SeEncuentraEnLista()
        {
            var nuevo = new Alimento("AlimentoTest", 100, 5, 20, 3, 100);
            _controller.Agregar(nuevo);
            var encontrado = _controller.ObtenerPorNombre("AlimentoTest");
            Assert.NotNull(encontrado);
            Assert.Equal(100, encontrado.Calorias);
        }

        [Fact]
        public void Agregar_IncrementaConteoDeAlimentos()
        {
            int antes  = _controller.ObtenerTodos().Count;
            _controller.Agregar(new Alimento("NuevoAlimento", 50, 2, 10, 1, 100));
            int despues = _controller.ObtenerTodos().Count;
            Assert.Equal(antes + 1, despues);
        }

        // ── Actualizar ─────────────────────────────────────────

        [Fact]
        public void Actualizar_CambiaCalorias_SeRefleja()
        {
            var a = _controller.ObtenerPorNombre("Banana");
            a.Calorias = 999;
            _controller.Actualizar(a);
            var actualizado = _controller.ObtenerPorNombre("Banana");
            Assert.Equal(999, actualizado.Calorias);
        }

        // ── EliminarPorNombre ──────────────────────────────────

        [Fact]
        public void EliminarPorNombre_AlimentoEliminado_NoSeEncuentra()
        {
            _controller.Agregar(new Alimento("AlimentoAEliminar", 100, 5, 20, 3, 100));
            _controller.EliminarPorNombre("AlimentoAEliminar");
            var resultado = _controller.ObtenerPorNombre("AlimentoAEliminar");
            Assert.Null(resultado);
        }

        [Fact]
        public void EliminarPorNombre_DecrementaConteo()
        {
            _controller.Agregar(new Alimento("AlimentoTemp", 100, 5, 20, 3, 100));
            int antes = _controller.ObtenerTodos().Count;
            _controller.EliminarPorNombre("AlimentoTemp");
            int despues = _controller.ObtenerTodos().Count;
            Assert.Equal(antes - 1, despues);
        }

        public void Dispose() => _factory.Dispose();
    }
}
